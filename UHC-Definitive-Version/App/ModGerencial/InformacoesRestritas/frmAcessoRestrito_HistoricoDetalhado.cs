using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.NewIqvia;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAcessoRestrito_HistoricoDetalhado : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal DateTime dataBase { get; set; } = DateTime.Today;

        public frmAcessoRestrito_HistoricoDetalhado()
        {
            InitializeComponent();


            //Properties
            ConfigureMenuStripProperties();
            CustomFormProperties();
            CustomButtonProperties();
            ConfigureDataGridViewProperties();


            //Events
            CustomFormEvents();

        }

        /** Async Tasks **/
        private async Task getData()
        {
            dgvData.DataSource = await LogIqvia.getToDataTableByDateAsync(dtp0.Value);
        }


        /** Form Properties **/
        private void CustomFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void CustomFormEvents()
        {
            this.Load += frmAcessoRestrito_HistoricoDetalhado_Load;
        }
        private void frmAcessoRestrito_HistoricoDetalhado_Load(object sender, EventArgs e)
        {
            /** Pré Load events **/
            ConfigureDateTimePickerAttributes();

            //Events
            ConfigureButtonEvents();

            //Post events

            btnFiltrar_Click(null, null);
        }

        /** Button Configuration **/
        private void CustomButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnFiltrar.Click += btnFiltrar_Click;
            btnRestricoes.Click += btnRestricoes_Click;
            btnClientes.Click += btnClientes_Click;
            btnProdutos.Click += btnProdutos_Click;
            btnVendas.Click += btnVendas_Click;
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                frmAcessoRestrito_HistoricoDetalhado_LayoutVendas layoutVendas = new frmAcessoRestrito_HistoricoDetalhado_LayoutVendas();
                layoutVendas.id = Convert.ToInt32(dgvData.CurrentRow.Cells[0].Value);
                layoutVendas.dt = Convert.ToDateTime(dgvData.CurrentRow.Cells[1].Value);
                layoutVendas.ShowDialog();
            }
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                frmAcessoRestrito_HistoricoDetalhado_LayoutProdutos layoutProdutos = new frmAcessoRestrito_HistoricoDetalhado_LayoutProdutos();
                layoutProdutos.id = Convert.ToInt32(dgvData.CurrentRow.Cells[0].Value);
                layoutProdutos.dt = Convert.ToDateTime(dgvData.CurrentRow.Cells[1].Value);
                layoutProdutos.ShowDialog();
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                frmAcessoRestrito_HistoricoDetalhado_LayoutClientes layoutClientes = new frmAcessoRestrito_HistoricoDetalhado_LayoutClientes();
                layoutClientes.id = Convert.ToInt32(dgvData.CurrentRow.Cells[0].Value);
                layoutClientes.dt = Convert.ToDateTime(dgvData.CurrentRow.Cells[1].Value);
                layoutClientes.ShowDialog();
            }
        }

        private async void btnRestricoes_Click(object sender, EventArgs e)
        {            
            DataTable consultaGenerica = await IqviaRestriction.getAllEspecificoToDataTableAsync(dgvData.CurrentRow.Cells[0].Value.ToString(),dtp0.Value);
            frmConsultaGenerica cg = new frmConsultaGenerica();
            cg.consulta = consultaGenerica;
            cg.ShowDialog();
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            await getData();
        }

        /** DateTimePicker Configuratiopn **/
        private void ConfigureDateTimePickerAttributes()
        {
            dtp0.Value = dataBase;
        }


        /** DataGridView Configuration **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
