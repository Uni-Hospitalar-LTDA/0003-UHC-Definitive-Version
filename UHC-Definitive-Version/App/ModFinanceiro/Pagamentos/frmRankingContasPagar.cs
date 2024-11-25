using LiveCharts.Defaults;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System.Drawing;

namespace UHC3_Definitive_Version.App.ModFinanceiro.Pagamentos
{
    public partial class frmRankingContasPagar : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        List<Consulta> rankingContasPagar = new List<Consulta>();
        internal class Consulta : Querys<Consulta>
        {
            public string codigoEntidade { get; set; }
            public string descricaoEntidade { get; set; }
            public string tipoEntidade { get; set; }
            public string valorPrincipal { get; set; }

            public async static Task<List<Consulta>> getAllToListAsync(DateTime date)
            {
                string query = $@"
SELECT
    [codigoEntidade] =COALESCE(Fornecedor.Codigo, Favorecido.Cod_Favore, Transportadora.Codigo) ,
    [descricaoEntidade] = COALESCE(Fornecedor.Razao_Social, Favorecido.Des_Favore, Transportadora.Razao_Social),
    [tipoEntidade] = CASE
        WHEN CT.Cod_Fornec IS NOT NULL THEN 'Fornecedor'
        WHEN CT.Cod_Favore IS NOT NULL THEN 'Favorecido'
        ELSE 'Transportadora'
    END,
    [valorPrincipal] = SUM(CT.Val_Docume)
FROM [DMD].dbo.[PAGCT] CT
LEFT JOIN [DMD].dbo.[FAVOR] Favorecido ON Favorecido.Cod_Favore = CT.Cod_Favore
LEFT JOIN [DMD].dbo.[FORNE] Fornecedor ON Fornecedor.Codigo = CT.Cod_Fornec
LEFT JOIN [DMD].dbo.[TRANS] Transportadora ON Transportadora.Codigo = CT.Cod_Transp
WHERE  

/** Filtros Fixos **/
                        (Sta_Docume NOT LIKE 'C' or Sta_Docume = 'C' AND Dat_Cancel > '{date.ToString("yyyyMMdd")}') 					
                        AND(CT.Dat_Quitac > '{date.ToString("yyyyMMdd")}' OR not (CT.Dat_Quitac <= '{date.ToString("yyyyMMdd")}' and Sta_Docume = 'Q')) 	
                        AND(CT.Dat_Registro <= '{date.ToString("yyyyMMdd")}' AND Convert(date, Dat_Emissa) <= '{date.ToString("yyyyMMdd")}')  			
                        AND Num_Docume NOT LIKE '%P%'  																
                        AND Tip_Documento not like 'OR'
                        AND Dat_Vencim < '{date.ToString("yyyyMMdd")}'
GROUP BY
    CT.Cod_Fornec,
    CT.Cod_Favore,
    CT.Cod_Transp,
	Fornecedor.Codigo, Favorecido.Cod_Favore, Transportadora.Codigo,
    Transportadora.Razao_Social,
    Fornecedor.Razao_Social,
    Favorecido.Des_Favore
ORDER BY 
	valorPrincipal DESC";

                return await getAllToList(query);
            }
        }


        public frmRankingContasPagar()
        {
            InitializeComponent();

            //Properties 
            ConfigureFormProperties();
            ConfigureDateTimePickerProperties();
            ConfigureTextBoxProperties();
            ConfigureMenuStripProperties();
            ConfiguraPropriedadesGrid(dgvData);

            //Events
            ConfigureFormEvents();
            

            //btnFechar.toDefaultCloseButton();
        }

        /** Async Tasks **/
        private async Task getRankingFromDB()
        {
            rankingContasPagar = await Consulta.getAllToListAsync(dtpDatCorte.Value);
        }
        private async Task filter()
        {

            await getRankingFromDB();
            addItemsToDGV(rankingContasPagar);
            adicionarItensNaBox(rankingContasPagar);

        }

        /** Sync Methods**/
        private void ConfiguraPropriedadesGrid(DataGridView _dgv)
        {
            _dgv.Columns.Add("id", "Posição");
            _dgv.Columns.Add("codigoEntidade", "Código");
            _dgv.Columns.Add("descricaoEntidade", "Descrição");
            _dgv.Columns.Add("tipoEntidade", "Tipo");
            _dgv.Columns.Add("valorPrincipal", "Valor (R$)");

            // Definir o tipo de dados das colunas
            _dgv.Columns["codigoEntidade"].ValueType = typeof(int);
            _dgv.Columns["descricaoEntidade"].ValueType = typeof(string);
            _dgv.Columns["tipoEntidade"].ValueType = typeof(string);
            _dgv.Columns["valorPrincipal"].ValueType = typeof(double);

            // Formatar a coluna "valorPrincipal" como um valor monetário
            //dgvData.Columns["valorPrincipal"].DefaultCellStyle.Format = "R$ #,##0.00";
            _dgv.Columns["valorPrincipal"].DefaultCellStyle.Format = "C2";

            _dgv.toDefault();
            _dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgv.MultiSelect = true;

            _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void addItemsToDGV(List<Consulta> _list)
        {
            dgvData.Rows.Clear();
            int x = 0;
            foreach (var item in _list)
            {
                dgvData.Rows.Add(++x, Convert.ToInt32(item.codigoEntidade), item.descricaoEntidade, item.tipoEntidade, $"{Convert.ToDouble(item.valorPrincipal):C2}");
            }
            dgvData.AutoResizeColumns();
        }       
        private void adicionarItensNaBox(List<Consulta> consulta)
        {
            var values = new ChartValues<ObservableValue>();
            var labels = new List<string>();

            double totalValor = 0;

            foreach (var cliente in consulta.Take(10))
            {
                values.Add(new ObservableValue(Convert.ToDouble(cliente.valorPrincipal)));
                labels.Add(cliente.descricaoEntidade);
                totalValor += Convert.ToDouble(cliente.valorPrincipal);
            }

            double mediaTotal = totalValor / consulta.Count;
            double mediaTop10 = totalValor / 10;

            txtMediaTop10.Text = $"{mediaTotal:C2}";
            txtMediaTotal.Text = $"{mediaTop10:C2}";
            txtVlrTotal.Text = $"{consulta.Sum(c => Convert.ToDouble(c.valorPrincipal)):C2}";
        }

    

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmRankingContasPagar_Load;
            this.KeyDown += frmRankingContasPagar_KeyDown;
        }
        private void frmRankingContasPagar_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyData)
            {
                btnPesquisar_Click(null, null);
            }
        }
        private void frmRankingContasPagar_Load(object sender, EventArgs e)
        {
            //Pre events
            ConfigureDateTimePickerAttributes();
            
            //Events
            ConfigureButtonsEvents();

            //Post events
            btnPesquisar_Click(null,null);
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtMediaTotal.ReadOnly = true;
            txtMediaTop10.ReadOnly = true;
            txtVlrTotal.ReadOnly = true;


            // Define o fundo para "Média Top 10 vendas" Cor chamativa para destecar os top 10 valores
            txtMediaTop10.BackColor = Color.DodgerBlue;

            //// Define o fundo para "Média Total" cor cinza, para demonstrar a média de valores nada chamativo
            txtMediaTotal.BackColor = Color.DarkGray;

            // Define o fundo para "Vlr Total" cor vende representando o dinheiro ou valores
            txtVlrTotal.BackColor = Color.ForestGreen;
           
        }
                       
        /** Configure DateTimePicker **/
        private void ConfigureDateTimePickerProperties()
        {
            dtpDatCorte.MaximumSize = new System.Drawing.Size(dtpDatCorte.Width, dtpDatCorte.Height);
            dtpDatCorte.MinimumSize = new System.Drawing.Size(dtpDatCorte.Width, dtpDatCorte.Height);
        }
        private void ConfigureDateTimePickerAttributes()
        {
            DateTime today = DateTime.Now;
            DateTime firstDayOfNextMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1);
            DateTime lastDayOfMonth = firstDayOfNextMonth.AddDays(-1);
            dtpDatCorte.Value = lastDayOfMonth;
        }


        /** Button Configuration **/                
        private void ConfigureButtonsEvents()
        {
            btnPesquisar.Click += btnPesquisar_Click;
        }
        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            await filter();
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
