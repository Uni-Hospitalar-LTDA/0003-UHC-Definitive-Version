using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModFinanceiro.Cadastral
{
    public partial class frmSelecionarCliente : CustomForm
    {
        public frmSelecionarCliente()
        {
            InitializeComponent();
            
            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonsProperties();

            //Events
            ConfigureFormEvents();
        }

        /** sync Methods **/
        private void getClientsToDgv(DataGridView _dgv, string search)
        {
            _dgv.DataSource = Clientes_Externos.getToDataTable(search);
            _dgv.toDefault();
            _dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /** Configure Form **/
        private void ConfigureFormEvents()
        {
            this.Load += frmSelecionarCliente_Load;
        }
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void frmSelecionarCliente_Load(object sender, EventArgs e)
        {
            getClientsToDgv(dgvData, txtPesquisar.Text);
            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
            ConfigureDataGridViewEvents();
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxEvents()
        {
            txtPesquisar.KeyDown += txtPesquisar_KeyDown;
        }

        private void ConfigureTextBoxProperties()
        {

        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                getClientsToDgv(dgvData, txtPesquisar.Text.ToUpper());
        }

        /** Configfure DataGridView**/
        private void ConfigureDataGridViewEvents()
        {
            dgvData.DoubleClick += dgvData_DoubleClick;
        }
        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);
        }
        /** Configure Buttons **/
        private void ConfigureButtonsProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnPesquisar.Click += btnPesquisar_Click;
            btnEdit.Click += btnEditar_Click;            
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            getClientsToDgv(dgvData, txtPesquisar.Text);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                frmCadastroCliente frmCadastroCliente = new frmCadastroCliente();
                frmCadastroCliente.customerId = dgvData.CurrentRow.Cells[0].Value.ToString();
                frmCadastroCliente.ShowDialog();
            }
        }


    }
}
