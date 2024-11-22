using DocumentFormat.OpenXml.Wordprocessing;
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
using UHC3_Definitive_Version.Domain.Entities.NewIqvia;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAcessoRestrito_HistoricoDetalhado_LayoutClientes : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal int id { get; set; }
        internal DateTime dt { get; set; }
        BindingSource bindingSource1 = new BindingSource();

        public frmAcessoRestrito_HistoricoDetalhado_LayoutClientes()
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

        private async Task getData()
        {
            // Obter os dados
            DataTable dta = await IqviaLayout.getLayoutClienteAsync(dt,1, id);

            // Configurar o BindingSource
            bindingSource1.DataSource = dta;

            // Vincular o BindingSource ao DataGridView
            dgvData.DataSource = bindingSource1;

            // Atualizar a contagem de linhas
            txtQtdLinhas.Text = dta.Rows.Count.ToString();

            // Ajustar as colunas automaticamente
            dgvData.AutoResizeColumns();
        }

        private void pesquisarElementos(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                // Remove o filtro
                bindingSource1.RemoveFilter();
            }
            else
            {
                // Cria uma expressão de filtro para o BindingSource
                StringBuilder filter = new StringBuilder();

                DataTable dt = (DataTable)bindingSource1.DataSource;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (filter.Length > 0) filter.Append(" OR ");
                    filter.AppendFormat("Convert([{0}], 'System.String') LIKE '%{1}%'", dt.Columns[i].ColumnName, text.Replace("'", "''"));
                }

                // Aplica o filtro ao BindingSource
                bindingSource1.Filter = filter.ToString();
            }
        }


        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmAcessoRestrito_HistoricoDetalhado_LayoutClientes_Load;
        }
        private async void frmAcessoRestrito_HistoricoDetalhado_LayoutClientes_Load(object sender, EventArgs e)
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
            pesquisarElementos(txtFiltroGenerico.Text);
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
