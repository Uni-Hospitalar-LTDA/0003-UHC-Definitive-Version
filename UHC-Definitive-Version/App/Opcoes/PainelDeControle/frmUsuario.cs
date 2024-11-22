using _0009_Integra_Cob.App.Opcoes.PainelDeControle;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    public partial class frmUsuario : CustomForm
    {
        public frmUsuario()
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
        private async Task getUsers()
        {
            string filter = txtPesquisar.Text;
            List<string> vStatus = new List<string>();
            if (chkAtivos.Checked)
                vStatus.Add("1");
            if (chkInativos.Checked)
                vStatus.Add("0");
            string status = string.Join(",", vStatus);

            dgvDados.DataSource = await Users.getAllToDataTableAsync(filter, (string.IsNullOrEmpty(status) ? "3" : status));
            dgvDados.AutoResizeColumns();
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmUsuario_Load;
        }
        private async void frmUsuario_Load(object sender, EventArgs e)
        {
            //Attributes
            await getUsers();
            //Events
            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
            ConfigureDataGridViewEvents();

        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnAdicionar.Click += btnAdicionar_Click;
            btnPesquisar.Click += btnPesquisar_Click;
            btnEditar.Click += btnEditar_Click;
        }
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null)
            {
                // Armazenar o valor da chave única (ID) da linha atual
                var chaveUnicaLinhaAtual = dgvDados.CurrentRow.Cells[0].Value.ToString();

                // Abrir o formulário de edição
                frmUsuario_Editar frmUsuario_Editar = new frmUsuario_Editar();
                frmUsuario_Editar.persistent = await Users.getToClassByIdAsync(chaveUnicaLinhaAtual);
                frmUsuario_Editar.ShowDialog();

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
        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            await getUsers();
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmUsuario_Add frmUsuario_Add = new frmUsuario_Add();
            frmUsuario_Add.ShowDialog();
            btnPesquisar_Click(sender, e);
        }


        /** Configure TextBox **/
        private void ConfigureTextBoxEvents()
        {
            txtPesquisar.KeyDown += txtPesquisar_KeyDown;
        }
        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnPesquisar_Click(sender,e);
            }
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
