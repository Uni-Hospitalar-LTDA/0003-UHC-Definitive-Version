using System;
using System.Data;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAnaliseIqviaSintetico : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        string unidade_Login;
        public class RelatorioAnaliseIqvia : Querys<RelatorioAnaliseIqvia>
        {

            public string Query { get; set; }


            public static async  Task<RelatorioAnaliseIqvia> getQueryAsync()
            {
                string query = $@"SELECT * FROM {Connection.dbBase}.dbo.{RelatorioAnaliseIqvia.getClassName()}";
                return await getToClass(query);
            }

            public static async Task<DataTable> getRelatorioIqviaAnaliticoToDataTableAsync(DateTime data)
            {
                string query = $@"  DECLARE @DATA DATE = '{data}';
                                                                   
                            SELECT
	  NF_Saida.Num_Nota [NF]
	  ,NF_Saida.Cod_Cliente [Cód. Cliente]
	  ,Cliente.Razao_Social [Cliente]
	  ,IIF(Cliente.Tipo_Consumidor IN ('N','F'),'Privado','Público') [Consumidor]
	  ,GrupoCliente.Des_GrpCli [Grupo]
	  ,Cod_Cfo1 [CFOP]
	  ,cfop.Descricao [Desc. CFOP]
	  ,MONTH(DAT_EMISSAO) [Mês]
	  ,NF_Saida_Itens.Cod_Produto
	  ,Produto.Descricao [Produto]
	  ,Fabricante.Fantasia [Fabricante]
	  ,SUM(NF_Saida_Itens.Qtd_Produto) [Qtd. Produto]		 	 
FROM {Connection.dbDMD}.dbo.NFSCB NF_Saida
JOIN {Connection.dbDMD}.dbo.NFSIT NF_Saida_Itens ON NF_Saida_Itens.Num_Nota = NF_Saida.Num_Nota
JOIN {Connection.dbDMD}.dbo.CLIEN Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente
JOIN {Connection.dbDMD}.dbo.PRODU Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
JOIN {Connection.dbDMD}.dbo.FABRI Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante
JOIN {Connection.dbDMD}.dbo.GRCLI GrupoCliente ON GrupoCliente.Cod_GrpCli = Cliente.Cod_GrpCli
JOIN {Connection.dbDMD}.dbo.TBCFO Cfop ON Cfop.Codigo = NF_Saida.Cod_Cfo1
WHERE 
Status = 'F'
AND NF_Saida.Dat_Emissao = @DATA


GROUP BY 
NF_Saida.Num_Nota
,NF_Saida.Cod_Cliente 
,Cliente.Razao_Social 
,Cliente.Tipo_Consumidor
,Cod_Cfo1 
,NF_Saida_Itens.Cod_Produto
,Produto.Descricao
,MONTH(DAT_EMISSAO)
,Fabricante.Fantasia
,GrupoCliente.Des_GrpCli
,cfop.Descricao
ORDER BY [Qtd. Produto] DESC

                    ";
                Console.Write(query);
                return await getAllToDataTable(query);
            }

            public static async Task<DataTable> getRelatorioIqviaSinteticoToDataTableAsync(DateTime dt0, DateTime dtf)
            {
                string q = (await RelatorioAnaliseIqvia.getQueryAsync())?.Query;

                if (string.IsNullOrEmpty(q))
                {
                    CustomNotification.defaultAlert("Query não registrada");
                }

                string query = $@"  DECLARE @DATA1 DATE = '{dt0}';
                                    DECLARE @DATA2 DATE = '{dtf}';                                
                    {q}";
                Console.Write(query);
                return await getAllToDataTable(query);
            }
        }

        


        public frmAnaliseIqviaSintetico()
        {
            InitializeComponent();

            //unidade_Login = Section.Unidade;
            //Properties
            CustomFormProperites();
            ConfigureMenuStripProperties();
            ConfigureButtonProperties();
            ConfigureComboBoxProperties();
            ConfigureDataGridViewProperties();


            //Events
            CustomFormEvents();
        }

        /** Async tasks **/
        private async Task getRelatorioAsync()
        {
            
            Section.Unidade = cbxUnidade.SelectedItem?.ToString();
            dgvData.DataSource = await RelatorioAnaliseIqvia.getRelatorioIqviaSinteticoToDataTableAsync(dtpDataInicial.Value,dtpDataFinal.Value);
            dgvData.Columns[0].ValueType = typeof(DateTime);
            dgvData.Columns[dgvData.Columns.Count-1].ValueType = typeof(int);
            dgvData.Columns[dgvData.Columns.Count - 1].DefaultCellStyle.Format = "N0";


            int sum = 0;
            foreach (DataGridViewRow _row in dgvData.Rows)
            {
                sum += Convert.ToInt32(_row.Cells[dgvData.Columns.Count - 1].Value);
            }
            txtQtdsTotais.Text = sum.ToString("N0");

        }

        /** Form Configuration **/
        private void CustomFormProperites()
        {
            this.defaultFixedForm();
        }
        private void CustomFormEvents()
        {
            this.Load += frmAnaliseIqviaSintetico_Load;
            this.FormClosing += frmAnaliseIqviaSintetico_FormClosing;
        }

        private void frmAnaliseIqviaSintetico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Section.Unidade = unidade_Login;
        }

        private void frmAnaliseIqviaSintetico_Load(object sender, EventArgs e)
        {
            //Pre events
            ConfigureDateTimePickerAttributes();

            ConfigureButtonEvents();
            ConfigureDataGridViewEvents();


            //Post events
            btnFiltrar_Click(null,null);
        }


        /** DateTimePicker configuration **/
        private void ConfigureDateTimePickerAttributes()
        {
            dtpDataInicial.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDataFinal.Value = DateTime.Today;

        }

        /** ComboBox Configuration **/
        private void ConfigureComboBoxProperties()
        {
            cbxUnidade.Items.AddRange(new object[]
            {
                "UNI HOSPITALAR",
                "UNI CEARÁ",
                "SP HOSPITALAR"
            });
            cbxUnidade.SelectedIndex = 0;
            cbxUnidade.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnFiltrar.Click += btnFiltrar_Click;
        }
        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            await getRelatorioAsync();
        }


        /** Menu Strip Configuration **/
        private void ConfigureMenuStripProperties()
        {
            CustomToolStripMenuItem menuArquivo = new CustomToolStripMenuItem("Arquivo");
            CustomToolStripMenuItem itemArquivoAbrir = new CustomToolStripMenuItem("Abrir");
            CustomToolStripMenuItem itemArquivoAbrirExcel = new CustomToolStripMenuItem("Excel");
            CustomToolStripMenuItem itemArquivoExportar = new CustomToolStripMenuItem("Exportar");
            CustomToolStripMenuItem itemArquivoExportarExcel = new CustomToolStripMenuItem("Excel");

            CustomToolStripMenuItem menuConfiguracoes = new CustomToolStripMenuItem("Configurações");
            CustomToolStripMenuItem menuConfiguracoesParametrizacao = new CustomToolStripMenuItem("Parametrização");

            itemArquivoAbrirExcel.Click += ItemArquivoAbrirExcel_Click;
            itemArquivoExportarExcel.Click += ItemArquivoExportarExcel_Click;
            menuConfiguracoesParametrizacao.Click += menuConfiguracoesParametrizacao_Click;

            // Adicionando o item 'Empresa' e seu evento de clique

            menuArquivo.DropDownItems.Add(itemArquivoAbrir);
            menuArquivo.DropDownItems.Add(itemArquivoExportar);
            menuArquivo.DropDownItems.Add(menuConfiguracoes);
            
            itemArquivoAbrir.DropDownItems.Add(itemArquivoAbrirExcel);
            itemArquivoExportar.DropDownItems.Add(itemArquivoExportarExcel);

            menuConfiguracoes.DropDownItems.Add(menuConfiguracoesParametrizacao);
            // Adiciona o menuConfiguracao ao menu principal
            menuStrip.Items.Add(menuArquivo);
            this.Controls.Add(menuStrip);

        }
        private void menuConfiguracoesParametrizacao_Click(object sender, EventArgs e)
        {
            frmAnaliseIqviaSintetico_Parametrizacao frmAnaliseIqviaSintetico_Parametrizacao = new frmAnaliseIqviaSintetico_Parametrizacao();
            frmAnaliseIqviaSintetico_Parametrizacao.ShowDialog();
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

        /** Configure DataGridView  **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvData.DoubleClick += dgvData_DoubleClick;
        }

        private async void dgvData_DoubleClick(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                frmConsultaGenerica frmConsultaGenerica = new frmConsultaGenerica();
                frmConsultaGenerica.consulta = await RelatorioAnaliseIqvia.getRelatorioIqviaAnaliticoToDataTableAsync(Convert.ToDateTime(dgvData.CurrentRow.Cells[0].Value)) ;
                frmConsultaGenerica.ShowDialog();
            }
        }
    }
}
