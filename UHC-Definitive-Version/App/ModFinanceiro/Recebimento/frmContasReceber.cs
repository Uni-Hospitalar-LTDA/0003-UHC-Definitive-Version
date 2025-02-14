using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModFinanceiro.Recebimento
{
    public partial class frmContasReceber : CustomForm
    {
        /** Instance **/
        
        double totalValue = 0;
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal class BillsToReceive : Querys<BillsToReceive>
        {
            /** this select must be optimized **/
            public static async Task<DataTable> getAllToDataTableAsync(
                 DateTime cutDate
                , string title = null
                , string customerId = null
                , string customerGroupId = null
                , string customerSphereTag = null
                )
            {
                string customer = string.IsNullOrEmpty(customerId) ? string.Empty : " AND CLI.Codigo = " + customerId;
                string customerGroup = string.IsNullOrEmpty(customerGroupId) ? string.Empty : " AND GP_Cliente.Cod_GrpCli = " + customerGroupId;
                string customerSphere =
                       customerSphereTag == "Privado"
                    ? " AND CLI.Tipo_Consumidor IN ('N','F') "
                    : customerSphereTag == "Todos" ? string.Empty : " AND CLI.Tipo_Consumidor IN ('P','E','M') ";

                string query = $@"


DECLARE @dat_inicial DATETIME = '{cutDate.ToString("yyyyMMdd")}';


WITH CTE_BXREC_LIMIT AS (
    SELECT 
		   BX.Cod_Documento,                      
		   [Vlr. Recebido] = sum((ISNULL(BX.Vlr_Principal,0))) /** - SUM(ISNULL(BX.Vlr_Deducoes,0) + ISNULL(BX.Vlr_Desconto,0) ) **/
    FROM [DMD].dbo.[BXREC] BX
    WHERE BX.Dat_Caixa <= @DAT_INICIAL
	GROUP BY 
	BX.Cod_Documento                               
)
,CT AS (
  SELECT 
	     CT.Cod_Documento
        ,CT.Par_Documento                       
		,CT.Status                             		
		,CT.Num_Documento                      
		,CT.Num_NfOrigem                       	
		,CT.Dat_Emissao                        
		,CT.Dat_Vencimento                     
		,CT.Transacao
		,CT.Dat_Quitacao
		,CT.Cod_Cliente
		,CT.Cod_Vendedor
		,[Vlr. Acres] =		ISNULL(CT.Vlr_OutAcr    ,0)                     
		,[Vlr. Principal] = ISNULL(CT.Vlr_ParTit	,0)
		,[Vlr. Desc] =		ISNULL(CT.Vlr_DescConced,0) 
		,[Vlr. Princ. Acres.] = ISNULL(CT.Vlr_OutAcr,0) + isnull(CT.Vlr_ParTit,0)				
        ,CONVERT(INT,GETDATE () - CT.Dat_Vencimento) AS Dias_Vencidos
    FROM DMD.dbo.CTREC CT
WHERE (
	(CT.Dat_Emissao <= @DAT_INICIAL AND NOT ct.Status IN('C', 'B'))       
 OR (CT.Dat_Emissao <= @DAT_INICIAL AND     ct.Status IN('B') AND CT.Dat_Quitacao > @DAT_INICIAL))        
)

SELECT                                  
 [Esfera] = CASE             
				WHEN CLI.Tipo_Consumidor IN ('F','N') THEN 'PRIVADO'
				ELSE 'PÚBLICO'                                                                                          
			END                  
,[Cód. Cliente]	=	CLI.Codigo       
,[Cliente]	=	CLI.Razao_Social
,[Cód. Grp. Cliente] = GP_Cliente.Cod_GrpCli
,[Grp. Cliente]	=	GP_Cliente.Des_GrpCli
,[Duplicata]	=	CT.Num_Documento + ' ' + CT.Par_Documento
,[Dat. Emissao]            = CONVERT(DATE, CT.Dat_Emissao)                                                                                                                                                                                                                                      
,[Dat. Vencimento]         = CONVERT(DATE, CT.Dat_Vencimento)
,[Dias Vencidos]	=	IIF(CT.Dias_Vencidos < 0,0,CT.DIAS_VENCIDOS)
,[Período] = 
CASE	
    WHEN CT.Dias_Vencidos < 0 THEN 'A vencer'
	WHEN CT.Dias_Vencidos = 0 THEN 'Vence Hoje'
    WHEN CT.Dias_Vencidos <= 90 THEN 'Vencidos de 1 dia até 90 dias'
    WHEN CT.Dias_Vencidos <= 180 THEN 'Vencidos de 91 dias até 180 dias'
    WHEN CT.Dias_Vencidos <= 360 THEN 'Vencidos de 181 dias até 360 dias'
    ELSE 'Vencidos a mais de 360 dias'	
END
,[Dat. Pagamento] = CONVERT(DATE,ct.Dat_Quitacao)
,CT.[Vlr. Principal]
,CT.[Vlr. Princ. Acres.]
,isnull(BX.[Vlr. Recebido],0) [Vlr. Recebido]
,[Sld. Receber] = [Vlr. Princ. Acres.] - isnull([Vlr. Recebido],0)
FROM CT
LEFT  JOIN CTE_BXREC_LIMIT      BX  ON CT.Cod_Documento = BX.Cod_Documento                                                                                                                                                                                                                   
INNER JOIN [DMD].dbo.[CLIEN] ClI ON CLI.Codigo = CT.Cod_Cliente                                                                                                                                                                                                                            
INNER JOIN [DMD].dbo.[VENDE] Vendedor ON Vendedor.Codigo = CT.Cod_Vendedor
LEFT  JOIN [DMD].dbo.[GRCLI] GP_Cliente ON GP_Cliente.Cod_GrpCli = CLI.Cod_GrpCli      
where 
	(
		(ISNULL(CT.[Vlr. Principal],0) - ISNULL(BX.[Vlr. Recebido],0)) > 0
		AND (CT.Dat_Quitacao >= @dat_inicial OR CT.Dat_Quitacao IS NULL)
		)
		 AND CT.Num_Documento LIKE '%{title}%'
    {customer}
    {customerGroup}
    {customerSphere}
order by [Sld. Receber] DESC


";



                Console.WriteLine(query);
                return await getAllToDataTable(query);
            }
        }
        
        public frmContasReceber()
        {
            InitializeComponent();

            //Properties
            ConfigureTextBoxProperties();
            ConfigureFormProperties();
            ConfigureComboBoxProperties();
            ConfigureDataGridViewProperties();
            ConfigureButtonProperties();
            ConfigureGroupBoxProperties();
            ConfigureMenuStripProperties();
            //Events 
            ConfigureFormEvents();
        }

        /** Async Task **/
        private async Task getAllBillsToReceive(DateTime date, string title, string customerId, string customerGroupId, string customerSphere)
        {
            totalValue = 0;



            DataTable dt = null;
            var t = Task.Factory.StartNew(() =>
            {
                return BillsToReceive.getAllToDataTableAsync(
                    date
                    , title
                    , customerId
                    , customerGroupId
                    , customerSphere
                );
            });
            dt = await t.Result;



            dgvData.Invoke((Action)delegate
            {
                dgvData.DataSource = dt;
                dgvData.AutoResizeColumns();
                dgvData.MultiSelect = true;
                dgvData.SelectionMode = DataGridViewSelectionMode.CellSelect;


                dgvData.Columns[14].ValueType = typeof(double);
                dgvData.Columns[13].ValueType = typeof(double);
                dgvData.Columns[12].ValueType = typeof(double);
                dgvData.Columns[11].ValueType = typeof(double);
                dgvData.Columns[10].ValueType = typeof(DateTime);
                dgvData.Columns[8].ValueType = typeof(int);
                dgvData.Columns[7].ValueType = typeof(DateTime);
                dgvData.Columns[6].ValueType = typeof(DateTime);
                dgvData.Columns[3].ValueType = typeof(int);
                dgvData.Columns[1].ValueType = typeof(int);


                dgvData.Columns[14].DefaultCellStyle.Format = "C2";
                dgvData.Columns[13].DefaultCellStyle.Format = "C2";
                dgvData.Columns[12].DefaultCellStyle.Format = "C2";
                dgvData.Columns[11].DefaultCellStyle.Format = "C2";


                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    totalValue += Convert.ToDouble(row.Cells[14].Value);
                }
            });



            txtTotalValue.Invoke((Action)delegate
            {
                txtTotalValue.Text = totalValue.ToString("C2");
            });


        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmRecebimento_CarSintetico_Load;
        }
        private void frmRecebimento_CarSintetico_Load(object sender, EventArgs e)
        {
            ConfigureComboBoxAttributes();
            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
            
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtCustomerGroupDescription.ReadOnly = true;
            txtCustomerGroupDescription.TabStop = false;

            txtCustomerDescription.ReadOnly = true;
            txtCustomerDescription.TabStop = false;

            txtTotalValue.ReadOnly = true;
            txtTotalValue.TabStop = false;

            txtCustomerId.JustNumbers();
            txtCustomerGroupId.JustNumbers();
            txtCustomerGroupId.MaxLength = 3;
        }
        private void ConfigureTextBoxEvents()
        {
            txtCustomerId.TextChanged += txtCustomerId_TextChanged;
            txtCustomerDescription.DoubleClick += txtCustomerDescription_DoubleClick;
            txtCustomerGroupId.TextChanged += txtCustomerGroupId_TextChanged;
            txtCustomerGroupDescription.DoubleClick += txtCustomerGroupDescription_DoubleClick;


            txtCustomerId.KeyDown += genericFilter_KeyDown;
            txtCustomerDescription.KeyDown += genericFilter_KeyDown;
            txtCustomerGroupId.KeyDown += genericFilter_KeyDown;
            txtBill.KeyDown += genericFilter_KeyDown;
            dtpFinal.KeyDown += genericFilter_KeyDown;
        }
        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            txtCustomerDescription.Text = Clientes_Externos.getDescripionByCode(txtCustomerId.Text);
        }
        private void txtCustomerDescription_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            txtCustomerId.Text = frmConsultarCliente.extendedCode;
        }
        private async void txtCustomerGroupId_TextChanged(object sender, System.EventArgs e)
        {
            var customerGroup = await GruposClientes_Externos.getToClassAsync(txtCustomerGroupId.Text);
            txtCustomerGroupDescription.Text = customerGroup.Des_GrpCli;
        }
        private async void txtCustomerGroupDescription_DoubleClick(object sender, System.EventArgs e)
        {
            frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
            frmGeneric_ConsultaComSelecao.consulta = await GruposClientes_Externos.getAllToDataTableAsync();
            frmGeneric_ConsultaComSelecao.ShowDialog();
            txtCustomerGroupId.Text = frmGeneric_ConsultaComSelecao.extendedCode;
        }
        private void genericFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnSearch_Click(sender, new EventArgs());
            }
        }

        /** Configurte ComboBox **/
        private void ConfigureComboBoxProperties()
        {
            cbxCustomerSphere.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void ConfigureComboBoxAttributes()
        {
            cbxCustomerSphere.Items.Add("Todos");
            cbxCustomerSphere.Items.Add("Público");
            cbxCustomerSphere.Items.Add("Privado");
            cbxCustomerSphere.SelectedIndex = 0;
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
        }

        /** Configure Buttons **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSearch.Click += btnSearch_Click;
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            frmGeneric_ProgressForm chargeForm = new frmGeneric_ProgressForm();
            chargeForm.chargeText = "Carregando...";
            chargeForm.Show();
            string customerId = string.IsNullOrEmpty(txtCustomerDescription.Text) ? string.Empty : txtCustomerId.Text;
            string customerGroupId = string.IsNullOrEmpty(txtCustomerGroupDescription.Text) ? string.Empty : txtCustomerGroupId.Text;
            string customerSphere = cbxCustomerSphere.Text;

            this.Cursor = Cursors.WaitCursor;
            await Task.Factory.StartNew(() => getAllBillsToReceive(dtpFinal.Value, txtBill.Text, customerId, customerGroupId, customerSphere));
            this.Cursor = Cursors.Default;
            chargeForm.Close();


        }



        /** Configure GroupBox **/
        private void ConfigureGroupBoxProperties()
        {
            gpbFilters.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        }

        /** Menu Strip Configuration **/
        private void ConfigureMenuStripProperties()
        {
            CustomToolStripMenuItem menuArquivo = new CustomToolStripMenuItem("Arquivo");
            CustomToolStripMenuItem itemArquivoAbrir = new CustomToolStripMenuItem("Abrir");
            CustomToolStripMenuItem itemArquivoAbrirExcel = new CustomToolStripMenuItem("Excel");
            CustomToolStripMenuItem itemArquivoExportar = new CustomToolStripMenuItem("Exportar");
            CustomToolStripMenuItem itemArquivoExportarExcel = new CustomToolStripMenuItem("Excel");


            itemArquivoAbrirExcel.Click += ItemArquivoAbrirExcel_Click;
            itemArquivoExportarExcel.Click += ItemArquivoExportarExcel_Click;

            // Adicionando o item 'Empresa' e seu evento de clique

            menuArquivo.DropDownItems.Add(itemArquivoAbrir);
            menuArquivo.DropDownItems.Add(itemArquivoExportar);
            itemArquivoAbrir.DropDownItems.Add(itemArquivoAbrirExcel);
            itemArquivoExportar.DropDownItems.Add(itemArquivoExportarExcel);

            // Adiciona o menuConfiguracao ao menu principal
            menuStrip.Items.Add(menuArquivo);
            this.Controls.Add(menuStrip);

        }
        private void ItemArquivoAbrirExcel_Click(object sender, EventArgs e)
        {
            Exportacao.abrirDataGridViewEmExcel(dgvData);
        }
        private void ItemArquivoExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {

                //this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (dgvData.Rows.Count > 0)
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel File|*.xlsx";
                        saveFileDialog.Title = "Save Excel File";
                        saveFileDialog.FileName = $"{this.Text.substituirCaracteresEspeciais()}_{DateTime.Now.ToString("ddMMyyyy_HHmm")}";
                        saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        saveFileDialog.RestoreDirectory = true;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            RunMethodWithProgressBar((progress, cancellationToken) => Exportacao.exportarExcelComContaLinhas(dgvData, saveFileDialog.FileName, progress, cancellationToken));
                        }
                    }
                }
                catch (OperationCanceledException)
                {

                }
            }
        }
    }
}