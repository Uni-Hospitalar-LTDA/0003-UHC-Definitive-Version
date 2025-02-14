using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.ModLicitacao.Cadastro
{
    public partial class frmPlataformas : CustomForm
    {
        public frmPlataformas()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureDataGridViewProperties();
            ConfigureFormEvents();
        }


        /** Async Task **/
        private async Task getPlatforms()
        {
            DataTable dt = await UHC3_Definitive_Version.Domain.Entities.Platform.getToDataTableAsync(txtPlatformName.Text);
            dgvData.Invoke((Action)delegate
            {
                dgvData.DataSource = dt;
                dgvData.Columns[0].ValueType = typeof(int);
                dgvData.AutoResizeColumns();
                dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            });
        }
        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmPlataformas_Load;
        }
        private async void frmPlataformas_Load(object sender, System.EventArgs e)
        {

            await ConfigureDataGridViewAttributes();
            ConfigureButtonEvents();
            ConfigureTextBoxEvents();

            btnSearch_Click(sender, e);

        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
        }
        private async Task ConfigureDataGridViewAttributes()
        {
            await getPlatforms();
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
            btnSearch.Click += btnSearch_Click;
        }
        private async void btnSearch_Click(object sender, System.EventArgs e)
        {
            await getPlatforms();
        }
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            frmCadastrarPlataformas frmCadastrarPlataformas = new frmCadastrarPlataformas();
            frmCadastrarPlataformas.ShowDialog();
            btnSearch_Click(sender, e);
        }
        private async void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                frmEditarPlataforma frmEditarPlataforma = new frmEditarPlataforma();
                frmEditarPlataforma.platform = await UHC3_Definitive_Version.Domain.Entities.Platform.getToClassAsync(dgvData.CurrentRow.Cells[0].Value.ToString());
                frmEditarPlataforma.ShowDialog();
                btnSearch_Click(sender, e);
            }
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxEvents()
        {
            txtPlatformName.KeyDown += txtPlatformName_KeyDown;
        }
        private void txtPlatformName_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyData)
            {
                btnSearch_Click(sender, e);
            }
        }

    }
}
