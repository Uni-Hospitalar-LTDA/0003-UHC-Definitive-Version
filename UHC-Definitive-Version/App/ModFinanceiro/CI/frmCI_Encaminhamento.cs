using System.Collections.Generic;
using System.Windows.Forms;
using System;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.CI;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.App.ModFinanceiro.CI
{
    public partial class frmCI_Encaminhamento : CustomForm
    {
        public frmCI_Encaminhamento()
        {
            InitializeComponent();
            
            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureDataGridViewProperties();

            //Events
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private async Task filterAsync()
        {

            List<string> vstatus = new List<string>();
            string status = null;
            if (chkActive.Checked)
                vstatus.Add("1");
            if (chkInactive.Checked)
                vstatus.Add("0");

            if (vstatus.Count > 0)
                status = string.Join(",", vstatus);
            else
                status = "3";
            try
            {
                dgvData.DataSource = await CI_FollowUp.getAllToDataTableAsync(txtGenericFilter.Text, status);
                dgvData.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }

        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCI_Acompanhamento_Load; ; ;
        }

        private void frmCI_Acompanhamento_Load(object sender, EventArgs e)
        {
            //Attributes
            btnFilter_Click(sender, e);



            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
            ConfigureDataGridViewEvents();
        }

        /** Configure Buttons **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnFilter.Click += btnFilter_Click;
        }
        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await filterAsync();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                frmCI_Encaminhamento_Edit frmCI_Acompanhamento_Edit = new frmCI_Encaminhamento_Edit();
                frmCI_Acompanhamento_Edit.followUpId = dgvData.CurrentRow.Cells[0].Value.ToString();
                frmCI_Acompanhamento_Edit.ShowDialog();
                btnFilter_Click(sender, e);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCI_Encaminhamento_Add frmCI_Acompanhamento_Add = new frmCI_Encaminhamento_Add();
            frmCI_Acompanhamento_Add.ShowDialog();
            btnFilter_Click(sender, e);
        }


        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        private void ConfigureDataGridViewEvents()
        {
            dgvData.DoubleClick += dgvData_DoubleClick;
        }

        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            dgvData.DoubleClick += dgvData_DoubleClick;
        }


        /** Configure TextBox **/
        private void ConfigureTextBoxEvents()
        {
            txtGenericFilter.KeyDown += txtGenericFilter_KeyDown;
        }
        private void txtGenericFilter_KeyDown(object sender, KeyEventArgs e)
        {

            btnFilter_Click(sender, e);
        }
    }
}
