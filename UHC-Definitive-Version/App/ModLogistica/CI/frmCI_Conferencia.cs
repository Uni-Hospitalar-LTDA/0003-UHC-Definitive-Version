using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.ModFinanceiro.CI;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.CI;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModLogistica.CI
{
    public partial class frmCI_Conferencia : CustomForm
    {
        public frmCI_Conferencia()
        {
            InitializeComponent();


            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureDataGridViewProperties();
            ConfigureTextBoxProperties();

            //Events
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private async Task getCIsAsync()
        {
            List<string> statusFilter = new List<string>();
            string status = null;
            if (chkPendent.Checked)
                statusFilter.Add("'P'");
            if (chkWaitingFinance.Checked)
                statusFilter.Add("'F'");
            if (chkCompleted.Checked)
                statusFilter.Add("'C'");


            if (statusFilter.Count == 0)
                status = "'P','F','C'";
            else
                status = string.Join(",", statusFilter);


            string customer = (!string.IsNullOrEmpty(txtCustomer.Text) ? txtCustomerId.Text : null);
            string transporter = (!string.IsNullOrEmpty(txtTransporter.Text) ? txtTransporterId.Text : null);

            dgvData.DataSource = await CI_Header.getAllToDataTableAsync(status, customer, transporter, txtRebill.Text, txtNFOrigin.Text, txtNFReturn.Text, txtIdCI.Text,txtIdUhc2.Text);
            dgvData.AutoResizeColumns();

            //Definindo cores
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (Convert.ToDateTime(row.Cells["Registro"].Value) < DateTime.Now.AddDays(-30)
                    && row.Cells["Status"].Value.ToString() != "Concluído")
                {
                    row.DefaultCellStyle.BackColor = Color.IndianRed;
                }
                else
                {
                    if (row.Cells["status"].Value.ToString() == "Pendente")
                    {
                        row.DefaultCellStyle.BackColor = Color.Khaki;
                    }
                    if (row.Cells["status"].Value.ToString().Contains("Financeiro"))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    if (row.Cells["status"].Value.ToString().Contains("Concluído"))
                    {
                        row.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    }
                }

            }

        }


        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
            this.WindowState = FormWindowState.Maximized;
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCI_Conferencia_Load;
        }
        private void frmCI_Conferencia_Load(object sender, EventArgs e)
        {
            //Attributes
            btnFilter_Click(sender, e);
            ConfigureButtonEvents();
            ConfigureDataGridViewEvents();
            ConfigureTextBoxEvents();

        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnFilter.Click += btnFilter_Click;
            btnMoreCustomers.Click += btnMoreCustomer_Click;
            btnMoreTransporters.Click += btnMoreTransporter_Click;
            btnProducts.Click += btnProducts_Click;
            btnVisualizar.Click += btnVisualizar_Click;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            frmCI_Visualizar frmCI_Visualizar = new frmCI_Visualizar();
            frmCI_Visualizar.id = dgvData.CurrentRow.Cells[0].Value.ToString();
            frmCI_Visualizar.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null)
            {
                CustomNotification.defaultAlert("Nenhuma linha selecionada.");
                return;
            }

            string operacao = dgvData.CurrentRow.Cells["Operação"].Value?.ToString();
            string status = dgvData.CurrentRow.Cells["Status"].Value?.ToString();
            string idCI = dgvData.CurrentRow.Cells[0].Value?.ToString();

            if (operacao == "Sem Devolução")
            {
                CustomNotification.defaultAlert("Não é possível alterar Produtos de uma C.I sem devolução.");
            }
            else if (status == "Pendente")
            {
                frmCI_ConferenciaProdutos frmCI_ConferenciaProdutos = new frmCI_ConferenciaProdutos
                {
                    idCI = idCI
                };
                frmCI_ConferenciaProdutos.ShowDialog();
            }
            else
            {
                CustomNotification.defaultAlert($"Não é possível editar a C.I, status: {status}. Para mais informações consulte o Financeiro.");
            }
            btnFilter_Click(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string status = dgvData.CurrentRow.Cells["Status"].Value?.ToString();
            string currentRowId = dgvData.CurrentRow.Cells[0].Value?.ToString();


            if (status == "Concluído")
            {
                CustomNotification.defaultAlert("Não é possível modificar uma C.I da qual já foi finalizada. Entre em contato com o suporte.");
                return;
            }
            frmCI_Conferencia_Editar frmCI_Conferencia_Editar = new frmCI_Conferencia_Editar();
            frmCI_Conferencia_Editar.id = dgvData.CurrentRow.Cells[0].Value.ToString();
            frmCI_Conferencia_Editar.ShowDialog();
            ReselectRowById(currentRowId);
        }


        private void ReselectRowById(string rowId)
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells[0].Value?.ToString() == rowId)
                {
                    // Selecionar a linha e sair do loop
                    dgvData.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCI_Conferencia_Add frmCI_Conferencia_Add = new frmCI_Conferencia_Add();
            frmCI_Conferencia_Add.ShowDialog();
            btnFilter_Click(sender, e);
        }
        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await getCIsAsync();
        }
        private void btnMoreTransporter_Click(object sender, EventArgs e)
        {
            frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            frmConsultarTransportador.ShowDialog();
            txtTransporterId.Text = frmConsultarTransportador.extendedCode;
        }
        private void btnMoreCustomer_Click(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            txtCustomerId.Text = frmConsultarCliente.extendedCode;
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvData.DoubleClick += dgvData_DoubleClick;
        }

        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            btnProducts_Click(sender, e);
        }

        /** Configure TextBox Properties **/
        private void ConfigureTextBoxProperties()
        {
            txtCustomer.ReadOnly();
            txtTransporter.ReadOnly();
            txtCustomerId.JustNumbers();
            txtTransporterId.JustNumbers();
            txtRebill.JustNumbers();
            txtNFOrigin.JustNumbers();
            txtNFReturn.JustNumbers();
            txtIdCI.JustNumbers();
            txtIdUhc2.JustNumbers();
        }
        private void ConfigureTextBoxEvents()
        {
            txtCustomerId.TextChanged += txtCustomerId_TextChanged;
            txtCustomer.DoubleClick += txtCustomer_DoubleClick;

            txtTransporterId.TextChanged += txtTransporterId_TextChanged;
            txtTransporter.DoubleClick += txtTransporter_DoubleClick;


            txtIdCI.KeyDown += genericFilter_KeyDown;
            txtCustomerId.KeyDown += genericFilter_KeyDown;
            txtTransporterId.KeyDown += genericFilter_KeyDown;
            txtRebill.KeyDown += genericFilter_KeyDown;
            txtNFOrigin.KeyDown += genericFilter_KeyDown;
            txtNFReturn.KeyDown += genericFilter_KeyDown;
            txtIdCI.KeyDown += genericFilter_KeyDown;
            txtIdUhc2.KeyDown += genericFilter_KeyDown;

        }

        private void genericFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnFilter_Click(sender, e);
            }

        }

        private void txtCustomerId_TextChanged(object sender, System.EventArgs e)
        {
            txtCustomer.Text = Clientes_Externos.getDescripionByCode(txtCustomerId.Text);
        }
        private async void txtTransporterId_TextChanged(object sender, EventArgs e)
        {
            txtTransporter.Text = await Transportadores_Externos.getDescriptionByCode(txtTransporterId.Text);
        }
        private void txtTransporter_DoubleClick(object sender, EventArgs e)
        {
            btnMoreTransporter_Click(sender, e);
        }
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            btnMoreCustomer_Click(sender, e);
        }
    }
}
