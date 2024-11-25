using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;

namespace UHC3_Definitive_Version.App.Opcoes.OpcoesDeDesenvolvedor
{
    public partial class frmPermissoes : CustomForm
    {
        public frmPermissoes()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();
            //Events
            ConfigureFormEvents();


        }

        /** Async Tasks **/
        private async Task getPermissionTree()
        {
            treeView1.Nodes.Clear();
            await Permission.configureTreeView(treeView1, false);
        }
        private async Task updateAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (txtCategoria.Text.Equals("Module"))
                {
                    Module module = new Module();
                    module.Id = txtId.Text;
                    module.Name = txtDescricao.Text;
                    module.Description = txtObservacao.Text;

                    await Module.updateAsync(module);
                }
                else if (txtCategoria.Text.Equals("SubModule"))
                {
                    SubModule subModule = new SubModule();
                    subModule.Id = txtId.Text;
                    subModule.Name = txtDescricao.Text;
                    subModule.Description = txtObservacao.Text;

                    await SubModule.updateAsync(subModule);
                }
                else if (txtCategoria.Text.Equals("Screen"))
                {
                    Domain.Permissionamento.Screen screen = new Domain.Permissionamento.Screen();
                    screen.Id = txtId.Text;
                    screen.Name = txtDescricao.Text;
                    screen.Description = txtObservacao.Text;

                    await Domain.Permissionamento.Screen.updateAsync(screen);
                }
                else if (txtCategoria.Text.Equals("Action"))
                {
                    Domain.Permissionamento.Action action = new Domain.Permissionamento.Action();
                    action.Id = txtId.Text;
                    action.Name = txtDescricao.Text;
                    action.Description = txtObservacao.Text;
                    await Domain.Permissionamento.Action.updateAsync(action);
                }
                this.Cursor = Cursors.Default;
                CustomNotification.defaultInformation();
            }
            catch (Exception ex) 
            {
                CustomNotification.defaultError(ex.Message);
            }

            
        }
        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmPermissoes_Load;
        }
        private async void frmPermissoes_Load(object sender, EventArgs e)
        {
            //Attributes 
            await getPermissionTree();

            //Events
            ConfigureStripMenuEvents();
            ConfigureTreeViewEvents();
            ConfigureButtonEvents();
        }

        /** Configure StripMenu **/
        private void ConfigureStripMenuEvents()
        {
            stripMenuInserirPermissao_Modulo.Click += stripMenuInserirPermissao_Modulo_Click;
            stripMenuInserirPermissao_SubModulo.Click += stripMenuInserirPermissao_SubModulo_Click;
            stripMenuInserirPermissao_Tela.Click += stripMenuInserirPermissao_Tela_Click;
            stripMenuInserirPermissao_Acao.Click += stripMenuInserirPermissao_Acao_Click;
        }
        private async void stripMenuInserirPermissao_Acao_Click(object sender, EventArgs e)
        {
            frmPermissoes_Add frmPermissoes_Add = new frmPermissoes_Add();
            frmPermissoes_Add.type = "Action";
            frmPermissoes_Add.ShowDialog();
            await getPermissionTree();

        }
        private async void stripMenuInserirPermissao_Tela_Click(object sender, EventArgs e)
        {
            frmPermissoes_Add frmPermissoes_Add = new frmPermissoes_Add();
            frmPermissoes_Add.type = "Screen";
            frmPermissoes_Add.ShowDialog();
            await getPermissionTree();

        }
        private async void stripMenuInserirPermissao_SubModulo_Click(object sender, EventArgs e)
        {
            frmPermissoes_Add frmPermissoes_Add = new frmPermissoes_Add();
            frmPermissoes_Add.type = "SubModule";
            frmPermissoes_Add.ShowDialog();
            await getPermissionTree();
        }
        private async void stripMenuInserirPermissao_Modulo_Click(object sender, EventArgs e)
        {
            frmPermissoes_Add frmPermissoes_Add = new frmPermissoes_Add();
            frmPermissoes_Add.type = "Module";
            frmPermissoes_Add.ShowDialog();
            await getPermissionTree();

        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultQuestionCloseButton();
        }

        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await updateAsync();
            await getPermissionTree();
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtCategoria.ReadOnly();
            txtId.ReadOnly();
        }
        /** Configure Treeiew **/      
        private void ConfigureTreeViewEvents()
        {
            treeView1.AfterSelect += treeView1_AfterSelect;
        }
        private async void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeText = e.Node.Text;
            if (nodeText.ToString().Contains("MOD"))
            {
                txtCategoria.Text = "Module";
                var module = await Module.getToClassAsync(nodeText.ToString().Replace("MOD", "").Split('-')[0].ToString());
                txtId.Text = module.Id;
                txtDescricao.Text = module.Name;
                txtObservacao.Text = module.Description;
            }
            else if (nodeText.ToString().Contains("SUB"))
            {
                txtCategoria.Text = "SubModule";
                var submodule = await SubModule.getToClassAsync(nodeText.ToString().Replace("SUB", "").Split('-')[0].ToString());
                txtId.Text = submodule.Id;
                txtDescricao.Text = submodule.Name;
                txtObservacao.Text = submodule.Description;
            }
            else if (nodeText.ToString().Contains("SCR"))
            {
                txtCategoria.Text = "Screen";
                var screen = await Domain.Permissionamento.Screen.getToClassAsync(nodeText.ToString().Replace("SCR", "").Split('-')[0].ToString());
                txtId.Text = screen.Id;
                txtDescricao.Text = screen.Name;
                txtObservacao.Text = screen.Description;
            }
            else if (nodeText.ToString().Contains("ACT"))
            {
                txtCategoria.Text = "Action";
                
                var action = await Domain.Permissionamento.Action.getToClassAsync(nodeText.ToString().Replace("ACT", "").Split('-')[0].ToString());
                txtId.Text = action.Id;
                txtDescricao.Text = action.Name;
                txtObservacao.Text = action.Description;
            }
            else
            {
                txtCategoria.Text = string.Empty;
                txtId.Text = string.Empty;
                txtDescricao.Text = string.Empty;
                txtObservacao.Text = string.Empty;
            }
        }
    }
}

