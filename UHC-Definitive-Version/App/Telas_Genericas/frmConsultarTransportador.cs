using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.Telas_Genericas
{
   

    public partial class frmConsultarTransportador : CustomForm
    {
        /**Instance **/
        public string extendedCode { get; private set; }

        public frmConsultarTransportador()
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
            this.Load += frmConsultarTransportador_Load;
        }

        private void frmConsultarTransportador_Load(object sender, System.EventArgs e)
        {
            //pré load
            carregar(txtPesquisar.Text.ToUpper(), dgvData);


            //Events
            ConfigureButtonEvents();
            ConfigureDataGridViewEvents();
            ConfigureTextBoxEvents();
        }

        //Sync task
        private void carregar(string text, DataGridView dgvData)
        {
            try
            {
                dgvData.DataSource = Transportadores_Externos.getAllToDataTable(text);
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                dgvData.toDefault();
                dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                carregar(txtPesquisar.Text.ToUpper(), dgvData);
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
            carregar(txtPesquisar.Text.ToUpper(), dgvData);
        }
    }
}
