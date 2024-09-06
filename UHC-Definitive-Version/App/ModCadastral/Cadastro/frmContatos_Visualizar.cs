using System.Windows.Forms;
using System;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.App.ModCadastral.Cadastro
{
    public partial class frmContatos_Visualizar : CustomForm
    {
        /** Instance  **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        public string linkedType { get; set; }

        public frmContatos_Visualizar()
        {
            InitializeComponent();

            //Properties
            ConfigureMenuStripProperties();
            ConfigureButtonProperties();
            ConfigureFormProperties();
            ConfigureDataGridViewProperties();

            //Events
            ConfigureFormEvents();
        }

        /** async Tasks **/
        private async Task getContacts()
        {
            dgvData.DataSource = (await Contact.getAllToDataTableByTypeAsync(linkedType));
            dgvData.AutoResizeColumns();
        }
        private void Pesquisar(DataGridView dgv, string pesquisa)
        {
            try
            {
                // Itera em todas as linhas
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    bool encontrado = false;

                    // Itera em todas as células na linha atual
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().Contains(pesquisa))
                        {
                            encontrado = true;
                            break;
                        }
                    }

                    // Se o valor foi encontrado na linha, a linha é tornada visível. Caso contrário, torna-se invisível.
                    row.Visible = encontrado;
                }
            }
            catch
            {

            }
            finally
            {
                dgv.AutoResizeColumns();
            }

        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCadastrarContatos_Load;

            ConfigureDataGridViewEvents();
        }
        private async void frmCadastrarContatos_Load(object sender, EventArgs e)
        {
            await getContacts();
            ConfigureTextBoxEvents();
            ConfigureButtonEvents();

        }

        /**Configure Button**/
        private void ConfigureButtonEvents()
        {
            btnSearch.Click += btnSearch_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
        }
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Pesquisar(dgvData, txtSearch.Text);
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmContatos_Inserir fmContatos_Inserir = new frmContatos_Inserir();
            frmContatos_Inserir.linkedType = linkedType;
            frmContatos_Inserir.ShowDialog();
            await getContacts();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                frmContatos_Editar fmContatos_Editar = new frmContatos_Editar();
                frmContatos_Editar.contactId = dgvData.CurrentRow.Cells[0].Value.ToString();
                frmContatos_Editar.ShowDialog();
                await getContacts();
            }
            else
                CustomMessage.Alert("Selecione um registro para editar.");
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

            menuArquivo.DropDownItems.Add(itemArquivoAbrir);
            menuArquivo.DropDownItems.Add(itemArquivoExportar);
            itemArquivoAbrir.DropDownItems.Add(itemArquivoAbrirExcel);
            itemArquivoExportar.DropDownItems.Add(itemArquivoExportarExcel);

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
