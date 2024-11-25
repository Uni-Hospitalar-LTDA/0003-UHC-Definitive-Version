using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    public partial class frmSetor : CustomForm
    {
        public frmSetor()
        {
            InitializeComponent();


            //Properties
            ConfigureFormProperties();
            ConfigureDataGridViewProperties();
            ConfigureButtonProperties();

            //Events
            ConfigureFormEvents();
            
        }



        /** Async Tasks **/
        private async Task getSectors()
        {
            string filter = txtPesquisar.Text;
            List<string> vStatus = new List<string>();

            if (chkAtivos.Checked)
                vStatus.Add("1");
            if (chkInativos.Checked)
                vStatus.Add("0");
            string status = string.Join(",", vStatus);
            dgvDados.DataSource = await Sector.getAllToDataTableAsync(filter,(string.IsNullOrEmpty(status) ? "3" : status));
            dgvDados.AutoResizeColumns();
        }

        /** Form Configuration **/
        private void ConfigureFormEvents()
        {
            this.Load += frmSetor_Load;
        }        
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private async void frmSetor_Load(object sender, EventArgs e)
        {
            //Attributes
            await getSectors();


            //Events 
            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
            ConfigureDataGridViewEvents();
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



        /** Configure TextBox **/
        private void ConfigureTextBoxEvents()
        {
            txtPesquisar.KeyDown += genericFilter_KeyDown;
        }
        private void genericFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnPesquisar_Click(sender, e);  
            }
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnAdicionar.Click += bnAdicionar_Click;
            btnEditar.Click += btnEditar_Click;
            btnDefinirUserSetor.Click += btnDefinirUserSetor_Click;
            btnPesquisar.Click += btnPesquisar_Click;
        }
        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            await getSectors();
        }
        private void bnAdicionar_Click(object sender, EventArgs e)
        {
            frmSetor_Add frmSetor_Add = new frmSetor_Add();
            frmSetor_Add.ShowDialog();
            btnPesquisar_Click (sender,e);  
        }
        private async void btnDefinirUserSetor_Click(object sender, EventArgs e)
        {
            
            if (dgvDados.CurrentRow != null)
            {
                // Armazenar o valor da chave única (ID) da linha atual
                var chaveUnicaLinhaAtual = dgvDados.CurrentRow.Cells[0].Value.ToString();

                // Abrir o formulário de edição
                frmSetor_Usuarios frmSetor_Usuarios = new frmSetor_Usuarios();
                frmSetor_Usuarios.selectedSector = await Sector.getToClassAsync(chaveUnicaLinhaAtual);
                frmSetor_Usuarios.ShowDialog();

                // Executar a pesquisa novamente
                btnPesquisar_Click(sender, e);

                // Após a pesquisa, localizar e selecionar a linha com a chave única armazenada
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[0].Value.ToString() == chaveUnicaLinhaAtual)
                    {
                        // Definir a linha encontrada como a linha atual selecionada
                        dgvDados.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
        }
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null)
            {
                // Armazenar o valor da chave única (ID) da linha atual
                var chaveUnicaLinhaAtual = dgvDados.CurrentRow.Cells[0].Value.ToString();

                // Abrir o formulário de edição
                frmSetor_Editar frmSetor_Editar = new frmSetor_Editar();
                frmSetor_Editar.setor = await Sector.getToClassAsync(chaveUnicaLinhaAtual);
                frmSetor_Editar.ShowDialog();

                // Executar a pesquisa novamente
                btnPesquisar_Click(sender, e);

                // Após a pesquisa, localizar e selecionar a linha com a chave única armazenada
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[0].Value.ToString() == chaveUnicaLinhaAtual)
                    {
                        // Definir a linha encontrada como a linha atual selecionada
                        dgvDados.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
        }

    }
}
