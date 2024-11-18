using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.App.Telas_Genericas;



namespace UHC3_Definitive_Version.App.ModFinanceiro.Recebimento
{
    public partial class frmRecebimento_CarRanking : CustomForm
    {
        /** Instance **/
        public class Report : Querys<Report>
        {
            public string sphere { get; set; }
            public string customerId { get; set; }
            public string customer { get; set; }
            public string customerGroupId { get; set; }
            public string customerGroup { get; set; }
            public string billsToReceiveValue { get; set; }

            /** this select must be optimized **/
            public static async Task<List<Report>> getAllToListAsync(
                 DateTime cutDate
                , string customerGroupId = null
                , string customerSphereTag = null
                )
            {
                string customerGroup = string.IsNullOrEmpty(customerGroupId) ? string.Empty : " AND GP_Cliente.Cod_GrpCli = " + customerGroupId;
                string customerSphere =
                       customerSphereTag == "Privado"
                    ? " AND CLI.Tipo_Consumidor IN ('N','F') "
                    : customerSphereTag == "Todos" ? string.Empty : " AND CLI.Tipo_Consumidor IN ('P','E','M') ";



                string query = $@"--Em baixo está a criação da temp table
declare @dat_inicial datetime

set @dat_inicial = '{cutDate.ToString("yyyyMMdd")}'

DECLARE @BXREC_LIMIT table (                    
 [Cod_Documento][int]            NOT NULL,                                                                                                    
 [Dat_Registro]  [datetime]        NULL,         
 [Vlr_Principal] [numeric] (18, 4) NULL  DEFAULT(0),                                                                                                                                                                                                        
 [Vlr_Desconto]  [numeric] (18, 4) NULL  DEFAULT(0),                                                                                                                                                                                                        
 [Vlr_Deducoes]  [numeric] (18, 4) NULL  DEFAULT(0),                                                                                                                                                                                                        
 [Dat_Caixa]     [datetime]        NULL         
)                                               
INSERT INTO @BXREC_LIMIT                        
(Cod_Documento, Dat_Registro, Vlr_Principal, Vlr_Desconto, Vlr_Deducoes, Dat_Caixa)                                                                                                                                                                                                            
(                                               
  SELECT BX.Cod_Documento                       
        ,BX.Dat_Registro                        
		,BX.Vlr_Principal                      
		,BX.Vlr_Desconto                       
		,BX.Vlr_Deducoes                       
		,BX.Dat_Caixa                          
                                                
  FROM[DMD].dbo.[BXREC] BX                      
  WHERE BX.Dat_Caixa <= @DAT_INICIAL             
);                                   
           
/**Em baixo está o select**/		  
SELECT                                          
 sphere = CASE             
				WHEN CLI.Tipo_Consumidor IN ('F','N') THEN 'PRIVADO'
				ELSE 'PÚBLICO'                                                                                          
			END                  
,customerId	=	CLI.Codigo     
,customer	=	CLI.Razao_Social
,customerGroupId = GP_Cliente.Cod_GrpCli
,customerGroup	=	GP_Cliente.Des_GrpCli
, billsToReceiveValue         =
CASE
    WHEN (CT.TRANSACAO < @DAT_INICIAL)
    THEN (SUM(DISTINCT CT.Vlr_ParTit) - ISNULL(SUM(BX.Vlr_Principal), 0) 
		 - ABS(ISNULL(SUM(BX.Vlr_Deducoes + BX.Vlr_Desconto), 0) 
		 + ISNULL(SUM(DISTINCT Vlr_DescConced), 0)))
    ELSE (SUM(DISTINCT CT.Vlr_ParTit) - ISNULL(SUM(BX.Vlr_Principal), 0) - ABS(ISNULL(SUM(BX.Vlr_Deducoes + BX.Vlr_Desconto), 0)))
END
FROM DMD.DBO.CTREC CT
		LEFT  JOIN @BXREC_LIMIT      BX  ON CT.Cod_Documento = BX.Cod_Documento                                                                                                                                                                                                                   
		INNER JOIN [DMD].dbo.[CLIEN] ClI ON CLI.Codigo = CT.Cod_Cliente                                                                                                                                                                                                                            
		INNER JOIN [DMD].dbo.[VENDE] Vendedor ON Vendedor.Codigo = CT.Cod_Vendedor
		LEFT  JOIN [DMD].dbo.[GRCLI] GP_Cliente ON GP_Cliente.Cod_GrpCli = CLI.Cod_GrpCli       
WHERE
        ((CT.Dat_Emissao <= @DAT_INICIAL AND NOT Status IN('C', 'B'))       
 OR(CT.Dat_Emissao <= @DAT_INICIAL AND     Status IN('B') AND CT.Dat_Quitacao > @DAT_INICIAL))      
    {customerGroup}
    {customerSphere}
    
GROUP BY                                        
         CT.Par_Documento                       
		,CT.Status                             
		,CT.Vlr_OutAcr                         
		,CT.Vlr_ParTit                         
		,CT.Num_Documento                      
		,CT.Num_NfOrigem                       
		,CT.Par_Documento                      
		,CLI.Codigo                            
		,CLI.Razao_Social                      
		,CLI.Tipo_Consumidor                   
		,CT.Dat_Emissao                        
		,CT.Dat_Vencimento                     
		,CT.Transacao
        ,GP_Cliente.Cod_GrpCli		
        ,GP_Cliente.Des_GrpCli
		,Vendedor.Codigo	
		,Vendedor.Nome_Guerra
		,Dat_Quitacao		
        
		
HAVING                                          
SUM(DISTINCT CT.Vlr_ParTit) - ISNULL(SUM(BX.Vlr_Principal), 0) - ISNULL(SUM(BX.Vlr_Deducoes + BX.Vlr_Desconto), 0) 
- ISNULL(SUM(DISTINCT CT.Vlr_DescConced), 0) > 0                                                                                                                                                                                   

"
;


                return await getAllToList(query);
            }
        }
        double totalValue = 0;
        List<Report> rep = new List<Report>();
        public frmRecebimento_CarRanking()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureDataGridViewProperties();
            ConfigureGroupBoxProperties();
            ConfigureTextBoxProperties();
            //ConfigureButtonProperties();
            ConfigureComboBoxProperties();
            ConfigureFormEvents();

        }

        /** Async Task **/
        private async Task getAllBilsToReceive(DateTime date, string customerGroupId, string customerSphere)
        {

            totalValue = 0;

            rep = await Report.getAllToListAsync(date, customerGroupId, customerSphere);

        }

        /** Sync Methods **/
        private List<Report> GroupAndSum(List<Report> reports)
        {
            return reports
                .GroupBy(r => int.Parse(r.customerId))
                .Select(group => new Report
                {
                    sphere = group.First().sphere, // Ou outro critério que preferir.
                    customerId = group.Key.ToString(),
                    customer = group.First().customer, // Ou outro critério que preferir.
                    customerGroupId = group.First().customerGroupId, // Ou outro critério que preferir.
                    customerGroup = group.First().customerGroup, // Ou outro critério que preferir.
                    billsToReceiveValue = group.Sum(x => double.Parse(x.billsToReceiveValue)).ToString() // Assumindo que o valor é em formato compatível para conversão para double
                }).OrderByDescending(x => double.Parse(x.billsToReceiveValue))
                .ToList();
        }
        private void UpdateDataGridView(DataGridView dgv, List<Report> reports)
        {
            //properties
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 

            try
            {
                totalValue = 0;

                foreach (var item in GroupAndSum(reports))
                {
                    dgv.Rows.Add(
                         item.sphere
                        , Convert.ToInt32(item.customerId)
                        , item.customer
                        , Convert.ToInt32(item.customerGroupId)
                        , item.customerGroup
                        , Convert.ToDouble(item.billsToReceiveValue)
                        );

                    totalValue += Convert.ToDouble(item.billsToReceiveValue);
                }
                txtTotalValue.Text = totalValue.ToString("C2");
            }
            catch (Exception)
            {

            }
        }
        private void GerarGrafico(List<Report> reports)
        {
            // Agrupar pelo customerId e ordenar de forma decrescente
            var dadosAgrupados = reports
                .GroupBy(r => new { r.customerId, r.customer })
                .Select(g => new
                {
                    CustomerId = g.Key.customerId,
                    Customer = g.Key.customer,
                    TotalValue = g.Sum(r => Convert.ToDouble(r.billsToReceiveValue))
                })
                .OrderByDescending(g => g.TotalValue)
                .Take(10)
                .ToList();

            // Configurar as séries do gráfico
            var seriesCollection = new SeriesCollection();
            foreach (var dado in dadosAgrupados)
            {
                seriesCollection.Add(new RowSeries
                {
                    Title = $"[{dado.CustomerId}] - {dado.Customer}",
                    Values = new ChartValues<double> { dado.TotalValue },
                    DataLabels = true,
                    LabelPoint = point => point.X.ToString("C2")
                });
            }

            // Configurar o gráfico
            cartesianChart1.Series = seriesCollection;
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Top 10",
                Labels = dadosAgrupados.Select(d => $"[{d.CustomerId}]").ToArray()
            });
            cartesianChart1.AxisX.Add(new Axis
            {
                LabelFormatter = value => value.ToString("C2")
            });
            cartesianChart1.Invalidate();
        }
        private void GerarGraficoPizza(List<Report> reports)
        {
            // Agrupar pelo customerId, ordenar de forma decrescente e pegar os 5 primeiros
            var top5 = reports
                .GroupBy(r => new { r.customerId, r.customer })
                .Select(g => new
                {
                    CustomerId = g.Key.customerId,
                    Customer = g.Key.customer,
                    TotalValue = g.Sum(r => Convert.ToDouble(r.billsToReceiveValue))
                })
                .OrderByDescending(g => g.TotalValue)
                .Take(5)
                .ToList();

            // Calcular a soma dos valores dos registros restantes
            var outrosValue = reports
                .Where(r => !top5.Any(t => t.CustomerId == r.customerId))
                .Sum(r => Convert.ToDouble(r.billsToReceiveValue));

            // Configurar as séries do gráfico de pizza
            var pieSeriesCollection = new SeriesCollection();
            foreach (var dado in top5)
            {
                pieSeriesCollection.Add(new PieSeries
                {
                    Title = $"[{dado.CustomerId}] - {dado.Customer}",
                    Values = new ChartValues<double> { dado.TotalValue },
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("C2")
                });
            }

            // Adicionar a fatia "Outros" se houver valor
            if (outrosValue > 0)
            {
                pieSeriesCollection.Add(new PieSeries
                {
                    Title = "Outros",
                    Values = new ChartValues<double> { outrosValue },
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("C2")
                });
            }

            // Configurar o gráfico de pizza
            pieChart1.Series = pieSeriesCollection;
            pieChart1.Invalidate();
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private void ConfigureFormEvents()
        {
            this.Load += FrmRecebimentoCarRanking_Load;
        }
        private void FrmRecebimentoCarRanking_Load(object sender, EventArgs e)
        {

            dtpFinal.Value = DateTime.Now;

            ConfigureComboBoxAttributes();
            UpdateDataGridView(dgvData, rep);
            ConfigureButtonEvents();
            ConfigureMenuStripEvents();
            ConfigureTextBoxEvents();

        }

        /** Configure DataGridView**/
        private void ConfigureDataGridViewProperties()
        {
            dgvData_ConfigureColumns(dgvData);
            dgvData.toDefault();
            dgvData.MultiSelect = true;
            dgvData.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;

        }
        private void dgvData_ConfigureColumns(DataGridView dgv)
        {
            dgv.Columns.Add("Sphere", "Esfera");
            dgv.Columns.Add("customerId", "Cód. Cliente");
            dgv.Columns.Add("customer", "Cliente");
            dgv.Columns.Add("customerGroupId", "Cód. Grp. Cliente");
            dgv.Columns.Add("customerGroup", "Grp. Cliente");
            dgv.Columns.Add("BillsToReceive", "Sld. a Receber");

            dgv.Columns["Sphere"].HeaderText = "Esfera";
            dgv.Columns["customerId"].HeaderText = "Cód. Cliente";
            dgv.Columns["customerId"].DefaultCellStyle.Format = "N0";
            dgv.Columns["customerId"].ValueType = typeof(int);
            dgv.Columns["customer"].HeaderText = "Cliente";
            dgv.Columns["customerGroupId"].HeaderText = "Cód. Grp. Cliente";
            dgv.Columns["customerGroupId"].DefaultCellStyle.Format = "N0";
            dgv.Columns["customerGroupId"].ValueType = typeof(int);
            dgv.Columns["customerGroup"].HeaderText = "Grp. Cliente";
            dgv.Columns["billsToReceive"].HeaderText = "Sld. a Receber";
            dgv.Columns["billsToReceive"].DefaultCellStyle.Format = "C2";
            dgv.Columns["billsToReceive"].ValueType = typeof(double);

        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtTotalValue.ReadOnly = true;
            txtTotalValue.TabStop = false;
            txtCustomerGroupDescription.ReadOnly = true;
            txtCustomerGroupDescription.TabStop = false;
            dtpFinal.Value = DateTime.Now;
        }
        private void ConfigureTextBoxEvents()
        {
            txtCustomerGroupId.TextChanged += txtCustomerGroupId_TextChanged;
            txtCustomerGroupDescription.DoubleClick += txtCustomerGroupDescription_DoubleClick;
        }
        private async void txtCustomerGroupId_TextChanged(object sender, System.EventArgs e)
        {
            var customerGroup = await GruposClientes_Externos.getToClassAsync(txtCustomerGroupId.Text);
            txtCustomerGroupDescription.Text = customerGroup.Des_GrpCli;
        }
        private async void txtCustomerGroupDescription_DoubleClick(object sender, System.EventArgs e)
        {
            frmConsultaGenerica frmConsultaGenerica = new frmConsultaGenerica();
            frmConsultaGenerica.consulta = await GruposClientes_Externos.getAllToDataTableAsync();
            frmConsultaGenerica.ShowDialog();
            txtCustomerGroupId.Text = frmConsultaGenerica.extendedCode;
        }

        /** Configure ComboBox **/
        private void ConfigureComboBoxProperties()
        {
            cbxCustomerSphere.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void ConfigureComboBoxAttributes()
        {
            cbxCustomerSphere.Items.Add("Todos");
            cbxCustomerSphere.Items.Add("Privado");
            cbxCustomerSphere.Items.Add("Público");
            cbxCustomerSphere.SelectedIndex = 0;
        }

        /** Configure GroupBox **/
        private void ConfigureGroupBoxProperties()
        {
            //gpbFilters.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        }

        /** Configure Button **/
        //private void ConfigureButtonProperties()
        //{
        //    btnClose.toDefaultCloseButton();
        //}

        private void ConfigureButtonEvents()
        {
            btnSearch.Click += btnSearch_Click;
            btnTop10.Click += btnTop10_Click;
            btnTotal.Click += btnTotal_Click;

        }
        private void btnTop10_Click(object sender, EventArgs e)
        {
            frmRecebimento_CarRankingGraphVisualizer graphVisualizer = new frmRecebimento_CarRankingGraphVisualizer();
            graphVisualizer.GerarGrafico(rep);
            graphVisualizer.ShowDialog();
        }
        private void btnTotal_Click(object sender, EventArgs e)
        {
            frmRecebimento_CarRankingGraphVisualizer graphVisualizer = new frmRecebimento_CarRankingGraphVisualizer();
            graphVisualizer.GerarGraficoPizza(rep);
            graphVisualizer.ShowDialog();
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string customerId = (!string.IsNullOrEmpty(txtCustomerGroupDescription.Text) ? txtCustomerGroupId.Text : null);
            this.Cursor = Cursors.WaitCursor;
           
            try
            {
                await getAllBilsToReceive(dtpFinal.Value, customerId, cbxCustomerSphere.Text);
            }
            catch (Exception)
            {

            }
            finally
            {
                UpdateDataGridView(dgvData, rep);
                GerarGrafico(rep);
                GerarGraficoPizza(rep);


                
                this.Cursor = Cursors.Default;
            }
        }


        /** Menu Strip Configuration **/
        private void ConfigureMenuStripEvents()
        {
            menuStripAbrirExcel.Click += menuStripAbrirExcel_Click;
            menuStripExportarExcel.Click += menuStripExportarExcel_Click;
        }
        private void menuStripExportarExcel_Click(object sender, EventArgs e)
        {

            if (dgvData.Rows.Count > 0)
            {
                try
                {
                    if (dgvData.Rows.Count > 0)
                    {
                        System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                        saveFileDialog.Filter = "Excel File|*.xlsx";
                        saveFileDialog.Title = "Save Excel File";
                        saveFileDialog.FileName = $"_BoletoVsQuantidade_{DateTime.Now.ToString("ddMMyyyy_HHmm")}";
                        saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        saveFileDialog.RestoreDirectory = true;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            RunMethodWithProgressBar((progress, cancellationToken) => Exportacao.exportarExcelComSoma(dgvData, saveFileDialog.FileName, progress, cancellationToken));
                        }
                    }
                }
                catch (OperationCanceledException)
                {

                }
            }
        }
        private void menuStripAbrirExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Exportacao.abrirDataGridViewEmExcel(dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
