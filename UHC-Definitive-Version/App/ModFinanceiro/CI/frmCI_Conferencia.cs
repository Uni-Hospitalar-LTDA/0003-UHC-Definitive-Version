using System.Collections.Generic;
using System.Windows.Forms;
using System;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Domain.Entities.CI;
using System.Drawing;
using System.Threading.Tasks;
using UHC3_Definitive_Version.App.Telas_Genericas;

namespace UHC3_Definitive_Version.App.ModFinanceiro.CI
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

            dgvData.DataSource = await CI_Header.getAllToDataTableAsync(status, customer, transporter, txtRebill.Text, txtNFOrigin.Text, txtNFReturn.Text, txtIdCI.Text, txtIdUhc2.Text);
            dgvData.AutoResizeColumns();

            //Definindo cores
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (Convert.ToDateTime(row.Cells["Registro"].Value) < DateTime.Now.AddDays(-30)
                    && row.Cells["status"].Value.ToString() != "Concluído")
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
            ConfigureTextBoxEvents();
            ConfigureDataGridViewEvents();
        }
        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnFilter.Click += btnFilter_Click;
            btnMoreCustomers.Click += btnMoreCustomer_Click;
            btnMoreTransporters.Click += btnMoreTransporter_Click;
            btnInformation.Click += btnInformation_Click;
            btnFollowUp.Click += btnFollowUp_Click;
        }

        private void btnFollowUp_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                // Armazenar o ID da linha atual antes de atualizar a grade
                string currentRowId = dgvData.CurrentRow.Cells[0].Value?.ToString();

                string status = dgvData.CurrentRow.Cells["Status"].Value?.ToString();
                if (status != "Pendente")
                {
                    frmCI_EncaminhamentoVsCi frmCI_EncaminhamentoVsCi = new frmCI_EncaminhamentoVsCi();
                    frmCI_EncaminhamentoVsCi.idCi = currentRowId;
                    frmCI_EncaminhamentoVsCi.ShowDialog();
                    btnFilter_Click(sender, e);
                    ReselectRowById(currentRowId);
                }
                else
                {
                    CustomNotification.defaultAlert($"Não é possível editar a C.I, status: {status}. Para mais informações consulte o setor de Logística.");
                }




            }
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

        private void btnInformation_Click(object sender, EventArgs e)
        {
            frmCI_Visualizar frmCI_Visualizar = new frmCI_Visualizar();
            frmCI_Visualizar.id = dgvData.CurrentRow.Cells[0].Value.ToString();
            frmCI_Visualizar.Show();
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
            dgvData.CellEnter += dgvData_CellEnter;
        }

        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            lsbNfReturn.Items.Clear();
            lsbNfOrigin.Items.Clear();
            if (dgvData.CurrentRow != null)
            {
                foreach (var i in CI_ReturnNF.getAllToListSync(dgvData.CurrentRow.Cells[0].Value.ToString()))
                {
                    lsbNfReturn.Items.Add(i.NF_Return.ToString());
                };
            }
            if (dgvData.CurrentRow != null)
            {
                foreach (var i in CI_OriginNF.getAllToListSync(dgvData.CurrentRow.Cells[0].Value.ToString()))
                {
                    lsbNfOrigin.Items.Add(i.NF_Origin.ToString());
                };
            }
        }

        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            btnFollowUp_Click(sender, e);
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
