using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Data;
using System.Windows.Forms;

namespace UHC3_Definitive_Version.App.Telas_Genericas
{   
    public partial class frmGeneric_ConsultaComSelecao : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal DataTable consulta { get; set; } //Consulta externa
        internal string elemento { get; set; } //Nome do Elemento externo
        internal string extendedCode { get; private set; } //Código herdado
        public frmGeneric_ConsultaComSelecao()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureDataGridViewProperties();
            ConfigureMenuStripProperties();

            //Events 
            ConfigureFormEvents();
        }


        //Sync Methods 
        private void carregarElementos()
        {
            bindingSource1.DataSource = consulta;
            dgvData.DataSource = bindingSource1;

            dgvData.toDefault();
        }

        BindingSource bindingSource1 = new BindingSource();
        private void pesquisarElementos(string text)
        {
            string searchText = text;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                bindingSource1.RemoveFilter();
            }
            else
            {
                string filter = "";

                // Cria uma expressão de filtro para cada coluna
                for (int i = 0; i < consulta.Columns.Count; i++)
                {
                    if (i != 0) filter += " OR ";
                    filter += string.Format("Convert([{0}], 'System.String') LIKE '%{1}%'", consulta.Columns[i].ColumnName, searchText);
                }

                bindingSource1.Filter = filter;
            }
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }        
        private void ConfigureFormEvents()
        {
            this.Load += frmGeneric_ConsultaComSelecao_Load;    
        }
        private void frmGeneric_ConsultaComSelecao_Load(object sender, EventArgs e)
        {
            //Attibutes
            carregarElementos();
            

            //Events 
            ConfigureButtonEvents();
            ConfigureDataGridViewEvents();
            ConfigureTextBoxEvents();
        }

        /** TextBox Configuration **/

        private void ConfigureTextBoxEvents()
        {
            txtPesquisar.KeyDown += txtPesquisar_KeyDown;
        }
        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                pesquisarElementos(txtPesquisar.Text.ToUpper());
            }
        }


        /** DataGridView Configuration **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvData.DoubleClick += dgvData_DoubleClick;
            dgvData.KeyDown += dgvData_KeyDown;
        }
        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            btnSalvar_Click(sender, e); 
        }
        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            btnSalvar_Click(sender, e); 
        }        
        

        /** Button Configuration **/
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
            btnPesquisar.Click += btnPesquisar_Click;
        }
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisarElementos(txtPesquisar.Text.ToUpper());
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
            }
            this.Close();
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
