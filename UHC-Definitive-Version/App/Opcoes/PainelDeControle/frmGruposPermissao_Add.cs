using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    public partial class frmGruposPermissao_Add : CustomForm
    {
        public frmGruposPermissao_Add()
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

        private async Task<bool> saveGroupAsync()
        {
            if (string.IsNullOrEmpty(txtNomeGrupo.Text))
            {
                CustomNotification.defaultAlert("O nome do grupo não pode ser nulo.");
                return false;
            }

            List<Groups> groups = new List<Groups>();
            groups.Add(new Groups {name = txtNomeGrupo.Text, description = txtGroupDescription.Text });
            await Groups.insertAsync(groups);
            return true;
        }
        private async Task savePermissionAsync()
        {
            bool groupSaved = await saveGroupAsync();
            if (!groupSaved)
                return;

            string idGroup = (await Groups.getLastCodeAsync()).ToString();

            //Instance of Permition relations
            List<Groups_Module> groups_Modules = new List<Groups_Module>();
            List<Groups_SubModule> groups_SubModules = new List<Groups_SubModule>();
            List<Groups_Screen> groups_Screens = new List<Groups_Screen>();
            List<Groups_Action> groups_Actions = new List<Groups_Action>();

            foreach (TreeNode node in treePermission.Nodes)
            {
                //Cadeia de permissões nível 1 (Módulo)
                foreach (TreeNode node_1 in node.Nodes)
                {
                    if (node_1.Checked)
                    {
                        Console.WriteLine("Added to save: Module - " + node_1.Text);
                        groups_Modules.Add(new Groups_Module { idGroups = idGroup, idModule = node_1.Name });
                    }

                    foreach (TreeNode node_2 in node_1.Nodes)
                    {
                        if (node_2.Checked)
                        {
                            Console.WriteLine("Added to save: SubModule - " + node_2.Text);
                            groups_SubModules.Add(new Groups_SubModule { idGroups = idGroup, idSubModule = node_2.Name });

                        }
                        //Cadeia de permissões nível 3 (Screen)
                        foreach (TreeNode node_3 in node_2.Nodes)
                        {
                            if (node_3.Checked)
                            {
                                Console.WriteLine("Added to save: Screen - " + node_3.Text);
                                groups_Screens.Add(new Groups_Screen { idGroups = idGroup, idScreen = node_3.Name });
                            }
                            //Cadeia de permissões nível 4 (Action)
                            foreach (TreeNode node_4 in node_3.Nodes)
                            {
                                if (node_4.Checked)
                                {
                                    Console.WriteLine("Added to save: Action - " + node_4.Text);
                                    groups_Actions.Add(new Groups_Action { idGroups = idGroup, idAction = node_4.Name });
                                }

                            }
                        }
                    }
                }

            }

            try
            {
                await Groups_Module.insertAsync(groups_Modules);
                await Groups_SubModule.insertAsync(groups_SubModules);
                await Groups_Screen.insertAsync(groups_Screens);
                await Groups_Action.insertAsync(groups_Actions);
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
                return;
            }
            finally
            {
                CustomNotification.defaultInformation();
                this.Close();
            }
        }

        /** Form Configuration **/       
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmGruposPermissao_Add_Load;
        }
        private async void frmGruposPermissao_Add_Load(object sender, EventArgs e)
        {
            /** Attributes **/
            await Permission.configureTreeView(treePermission);

            //Events 
            ConfigureButtonEvents();
            ConfigureTreeViewEvents();
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultQuestionCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await savePermissionAsync();
        }
       
        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtName.ReadOnly();
            txtDescription.ReadOnly();            
        }

        /** Configure Treeiew **/
        private void ConfigureTreeViewEvents()
        {
            treePermission.AfterSelect += treeView1_AfterSelect;
        }
        private async void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeText = e.Node.Text;
            if (nodeText.ToString().Contains("MOD"))
            {
                
                var module = await Module.getToClassAsync(nodeText.ToString().Replace("MOD", "").Split('-')[0].ToString());                
                txtName.Text = module.Name;
                txtDescription.Text = module.Description;
            }
            else if (nodeText.ToString().Contains("SUB"))
            {                
                var submodule = await SubModule.getToClassAsync(nodeText.ToString().Replace("SUB", "").Split('-')[0].ToString());

                txtName.Text = submodule.Name;
                txtDescription.Text = submodule.Description;
            }
            else if (nodeText.ToString().Contains("SCR"))
            {                
                var screen = await UHC3_Definitive_Version.Domain.Permissionamento.Screen.getToClassAsync(nodeText.ToString().Replace("SCR", "").Split('-')[0].ToString());                
                txtName.Text = screen.Name;
                txtDescription.Text = screen.Description;
            }
            else if (nodeText.ToString().Contains("ACT"))
            {                
                var action = await UHC3_Definitive_Version.Domain.Permissionamento.Action.getToClassAsync(nodeText.ToString().Replace("ACT", "").Split('-')[0].ToString());                
                txtName.Text = action.Name;
                txtDescription.Text = action.Description;
            }
            else
            {                
                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty;
            }
        }
    }
}

