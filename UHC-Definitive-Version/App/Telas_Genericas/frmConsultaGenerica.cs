using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Data;
using System.Windows.Forms;

namespace UHC3_Definitive_Version.App.Telas_Genericas
{
    public partial class frmConsultaGenerica : CustomForm
    {
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        /** Instance **/
        internal DataTable consulta { get; set; } //Consulta externa                
        BindingSource bindingSource1 = new BindingSource();

        public string extendedCode;
        public frmConsultaGenerica()
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


        /**Funções dos componentes internos**/
        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                pesquisarElementos(txtPesquisar.Text.ToUpper());
            }
        }
        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
                //CustomApplication.closeForm();
            }
        }
        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
                   
                }
            }
        }

        /** Buttons **/
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
            }
            
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisarElementos(txtPesquisar.Text.ToUpper());
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmConsultaGenerica_Load; ;
        }

        private void frmConsultaGenerica_Load(object sender, EventArgs e)
        {
            //Attibutes
            carregarElementos();


            //Events 
            //ConfigureButtonEvents();
            //ConfigureTextBoxEvents();
        }     

        /** TextBox Configuration **/

        //private void ConfigureTextBoxEvents()
        //{
        //    txtPesquisar.KeyDown += txtPesquisar_KeyDown;
        //}
        //private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Enter)
        //    {
        //        pesquisarElementos(txtPesquisar.Text.ToUpper());
        //    }
        //}


        /** DataGridView Configuration **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }      

        /** Button Configuration **/
        //private void ConfigureButtonEvents()
        //{            
        //    btnPesquisar.Click += btnPesquisar_Click;
        //}
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        
        //private void btnPesquisar_Click(object sender, EventArgs e)
        //{
        //    pesquisarElementos(txtPesquisar.Text.ToUpper());
        //}

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
