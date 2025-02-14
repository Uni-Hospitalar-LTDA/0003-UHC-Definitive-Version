using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;

namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    public partial class frmGruposPermissao : CustomForm
    {
        public frmGruposPermissao()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureDataGridViewProperties();
            ConfigureButtonProperties();
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
            this.Load += frmGruposPermissao_Load;
        }        
        private void frmGruposPermissao_Load(object sender, EventArgs e)
        {
            //Attributes


            //Events
            ConfigureButtonEvents();
            ConfigureDataGridViewEvents();

            //Afert Events 
            btnPesquisar_Click(sender, e);
        }



        /** Async Tasks **/
        private async Task getGroupsAsync()
        {
            string filter = txtPesquisar.Text;
            List<string> vStatus = new List<string>();
            if (chkAtivos.Checked)
                vStatus.Add("1");
            if (chkInativos.Checked)
                vStatus.Add("0");
            string status = string.Join(",", vStatus);

            dgvDados.DataSource = await Groups.getAllToDataTableAsync(filter, (string.IsNullOrEmpty(status) ? "3" : status));
            dgvDados.AutoResizeColumns();
        }

        /** DataGridView Configuration **/
        private void ConfigureDataGridViewProperties()
        {
            dgvDados.toDefault();
            dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvDados.DoubleClick += dgvDados_DoubleClick;
        }
        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);
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
            btnAssociar.Click += btnAssociar_Click;
        }
        private async void btnAssociar_Click(object sender, EventArgs e)
        {
           
            if (dgvDados.CurrentRow != null)
            {
                // Armazenar o valor da chave única (ID) da linha atual
                var chaveUnicaLinhaAtual = dgvDados.CurrentRow.Cells[0].Value.ToString();

                // Abrir o formulário de edição
                frmGruposPermissao_Usuarios frmGruposPermissao_Usuarios = new frmGruposPermissao_Usuarios();
                frmGruposPermissao_Usuarios.group = await Groups.getToClassAsync(dgvDados.CurrentRow.Cells[0].Value.ToString());
                frmGruposPermissao_Usuarios.ShowDialog();

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
            await getGroupsAsync();
        }
        private async void btnEditar_Click(object sender, EventArgs e)
        {           
            if (dgvDados.CurrentRow != null)
            {
                // Armazenar o valor da chave única (ID) da linha atual
                var chaveUnicaLinhaAtual = dgvDados.CurrentRow.Cells[0].Value.ToString();

                // Abrir o formulário de edição
                frmGruposPermissao_Editar frmGruposPermissao_Editar = new frmGruposPermissao_Editar();
                frmGruposPermissao_Editar.group = await Groups.getToClassAsync(dgvDados.CurrentRow.Cells[0].Value.ToString());
                frmGruposPermissao_Editar.ShowDialog();

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
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmGruposPermissao_Add frmGruposPermissao_Add = new frmGruposPermissao_Add();
            frmGruposPermissao_Add.ShowDialog();
            btnPesquisar_Click(sender, e);
        }
        
    }
}
