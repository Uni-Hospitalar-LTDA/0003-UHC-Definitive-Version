using System.Windows.Forms;
using System;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using System.Threading.Tasks;
using System.Threading;

namespace UHC3_Definitive_Version.App.Telas_Genericas
{
    public partial class frmConsultarFabricante : CustomForm
    {
        public frmConsultarFabricante()
        {
            InitializeComponent();
            this.defaultFixedForm();
            //txtPesquisar.TextChanged += btnPesquisar_Click;
            this.Load += frmConsultarFabricante_Load;

            txtPesquisar.KeyDown += txtPesquisar_KeyDown;
            dgvData.DoubleClick += dgvData_DoubleClick;
            dgvData.KeyDown += dgvData_KeyDown;
            btnPesquisar.Click += btnPesquisar_Click;
            btnFechar.Click += btnFechar_Click;
            btnSalvar.Click += btnSalvar_Click;

        }

        /** Instance **/
        public string extendedCode;
        //private CancellationTokenSource cancellationTokenSource;


        /** Load do form**/
        private void frmConsultarFabricante_Load(object sender, EventArgs e)
        {
           

           
            carregarFabricantes(txtPesquisar.Text.ToUpper());
        }
       



        /** Função de carga **/
        private void carregarFabricantes(string text)
        {
            try
            {
                if (Fabricantes_Externos.fabricantes.Count == 0)
                {                    
                    dgvData.DataSource = Fabricantes_Externos.getToDataTable(text);
                }
                else
                    dgvData.DataSource = Fabricantes_Externos.getToDataTable(text);
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
     

        /**Funções dos componentes internos**/
        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                carregarFabricantes(txtPesquisar.Text.ToUpper());
            }
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



        /** Buttons **/
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarFabricantes(txtPesquisar.Text.ToUpper());
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            extendedCode = "0";
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
            }
            this.Close();
        }


    }
}
