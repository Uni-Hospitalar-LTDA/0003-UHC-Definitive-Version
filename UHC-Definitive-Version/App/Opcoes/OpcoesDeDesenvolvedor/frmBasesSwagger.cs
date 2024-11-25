using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.App.Opcoes.OpcoesDeDesenvolvedor
{
    public partial class frmBasesSwagger : CustomForm
    {
        public object Bases { get; private set; }

        public frmBasesSwagger()
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
        private async Task getBasesSwagger()
        {
            string filter = txtPesquisar.Text;
            List<string> vStatus = new List<string>();

            if (chkAtivos.Checked)
                vStatus.Add("1");
            if (chkInativos.Checked)
                vStatus.Add("0");
            string status = string.Join(",", vStatus);
            dgvDados.DataSource = await CredenciaisSwagger.getAllToDataTableAsync(filter, (string.IsNullOrEmpty(status) ? "3" : status));
            dgvDados.AutoResizeColumns();
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();   
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmBasesSwagger_Load;   
        }

        private void frmBasesSwagger_Load(object sender, EventArgs e)
        {
            
            

            //Events
            ConfigureButtonEvents();
            ConfigureDataGridViewEvents();



            //Post Events
            btnPesquisar_Click(null, null);

        }


        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnAdicionar.Click += btnAdicionar_Click;
            btnEditar.Click += btnEditar_Click;
            btnPesquisar.Click += btnPesquisar_Click;
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                await getBasesSwagger();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError("Erro ao consultar as bases: "+ex.Message);
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            frmBasesSwagger_Edit frmBasesSwagger_Edit = new frmBasesSwagger_Edit();
            frmBasesSwagger_Edit.cs = await CredenciaisSwagger.getToClassAsync(dgvDados.CurrentRow.Cells[0].Value.ToString());
            frmBasesSwagger_Edit.ShowDialog();
            btnPesquisar_Click(null, null);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmBasesSwagger_Add frmBasesSwagger_Add = new frmBasesSwagger_Add();
            frmBasesSwagger_Add.ShowDialog();
            btnPesquisar_Click(null,null);

        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvDados.toDefault();
            dgvDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvDados.DoubleClick += dgvDados_DoubleClick;
        }
        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);
        }
    }
}
