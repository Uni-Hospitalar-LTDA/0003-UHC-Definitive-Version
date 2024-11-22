using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.NewIqvia;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAcessoRestrito_HistoricoDetalhado_LayoutProdutos : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal int id { get; set; }
        internal DateTime dt { get; set; }
        BindingSource bindingSource1 = new BindingSource();


        public frmAcessoRestrito_HistoricoDetalhado_LayoutProdutos()
        {
            InitializeComponent();
            
            //Properties 
            ConfigureMenuStripProperties();
            ConfigureButtonProperties();
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureDataGridViewProperties();

            //Events
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private async Task getData()
        {
            // Obter os dados
            DataTable dta = await IqviaLayout.getLayoutProdutoAsync(dt, 1, id);

            // Configurar o BindingSource
            bindingSource1.DataSource = dta;

            // Vincular o BindingSource ao DataGridView
            dgvData.DataSource = bindingSource1;

            // Atualizar a contagem de linhas
            txtQtdLinhas.Text = dta.Rows.Count.ToString();

            // Ajustar as colunas automaticamente
            dgvData.AutoResizeColumns();
        }


        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmAcessoRestrito_HistoricoDetalhado_LayoutProdutos_Load;
        }
        private async void frmAcessoRestrito_HistoricoDetalhado_LayoutProdutos_Load(object sender, EventArgs e)
        {
            //Pré load
            await getData();

            //Enviados
            ConfigureButtonEvents();
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnFiltrar.Click += btnFiltrar_Click;
            btnReenviar.Click += btnReenviar_Click;


        }

        private async void btnReenviar_Click(object sender, EventArgs e)
        {
            frmAcessoRestrito_PainelReenvio reenvio = new frmAcessoRestrito_PainelReenvio();
            reenvio.log = await LogIqvia.getToClassAsync(id);
            reenvio.ShowDialog();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Obtem o texto do filtro
            string filtro = txtFiltroGenerico.Text.Trim();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                // Remove o filtro caso o texto esteja vazio
                bindingSource1.RemoveFilter();
            }
            else
            {
                // Constrói o filtro para o BindingSource
                StringBuilder filter = new StringBuilder();

                // Obtém o DataTable vinculado ao BindingSource
                DataTable dt = (DataTable)bindingSource1.DataSource;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (filter.Length > 0) filter.Append(" OR ");
                    // Adiciona a condição para cada coluna
                    filter.AppendFormat("Convert([{0}], 'System.String') LIKE '%{1}%'", dt.Columns[i].ColumnName, filtro.Replace("'", "''"));
                }

                // Aplica o filtro
                bindingSource1.Filter = filter.ToString();
            }
        }


        /** DataGridView Configuration **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtQtdLinhas.ReadOnly();
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
    }
}
