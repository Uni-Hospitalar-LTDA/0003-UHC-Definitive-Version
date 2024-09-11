using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.Telas_Genericas
{
    public partial class frmConsultarFornecedor : CustomForm
    {
        public frmConsultarFornecedor()
        {
            InitializeComponent();
            this.defaultFixedForm();

            this.Load += frmConsultarTransportador_Load;

            txtPesquisar.KeyDown += txtPesquisar_KeyDown;


            btnPesquisar.Click += btnPesquisar_Click;
            btnFechar.Click += btnFechar_Click;
            btnSalvar.Click += btnSalvar_Click;

            dgvData.DoubleClick += dgvData_DoubleClick;
        }


        /** Instance **/
        public string extendedCode;

        /** Load do form**/
        private async void frmConsultarTransportador_Load(object sender, EventArgs e)
        {           
            await carregarFornecedores(txtPesquisar.Text.ToUpper());
        }

        /** Função de carga **/
        private async Task carregarFornecedores(string text)
        {
            try
            {
                dgvData.DataSource = await Fornecedores_Externos.getToDataTableAsync(text);
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
        private void DataGridViewEvents()
        {            
            dgvData.DoubleClick += dgvData_DoubleClick;
            txtPesquisar.KeyDown += txtPesquisar_KeyDown;
        }
        private async void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                await carregarFornecedores(txtPesquisar.Text.ToUpper());
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


        /** Buttons **/
        private void ConfigureButtonEvents()
        {
            btnPesquisar.Click += btnPesquisar_Click;
            btnSalvar.Click += btnSalvar_Click;
            btnFechar.Click += btnFechar_Click;
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            await carregarFornecedores(txtPesquisar.Text.ToUpper());
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
