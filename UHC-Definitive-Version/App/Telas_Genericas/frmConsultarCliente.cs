using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.Telas_Genericas
{
    public partial class frmConsultarCliente : CustomForm
    {
        /**Instance **/
        public string extendedCode { get; private set; }

        public frmConsultarCliente()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();

            //Events
            ConfigureFormEvents();
        }
        
        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmConsultarCliente_Load;
        }

        private void frmConsultarCliente_Load(object sender, EventArgs e)
        {
            //pré load
            carregarClientes(txtPesquisar.Text.ToUpper(), dgvData);


            //Events
            ConfigureButtonEvents();
            ConfigureDataGridViewEvents();
            ConfigureTextBoxEvents();
        }

        /** Função de carga **/
        private void carregarClientes(string text, DataGridView dataGridView)
        {
            try
            {
                dataGridView.DataSource = Clientes_Externos.getToDataTable(text);
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                dataGridView.toDefault();
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
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
                carregarClientes(txtPesquisar.Text.ToUpper(), dgvData);
            }
        }

        /** DataGridView Configuration **/
        private void ConfigureDataGridViewEvents()
        {
            dgvData.DoubleClick += dgvData_DoubleClick;
            dgvData.KeyDown += dgvData_KeyDown;
        }
     
        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
        }
        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
            }
        }

        /** Button Configuration  **/

        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
            btnPesquisar.Click += btnPesquisar_Click;
        }        

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
            }
            this.Close();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarClientes(txtPesquisar.Text.ToUpper(), dgvData);
        }
    }
}
