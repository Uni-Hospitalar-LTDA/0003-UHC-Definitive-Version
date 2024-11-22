using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    public partial class frmGruposPermissao_Editar : CustomForm
    {
        /** Instance **/
        List<Groups_Module> initialGroups_Modules = new List<Groups_Module>();
        List<Groups_SubModule> initialGroups_SubModules = new List<Groups_SubModule>();
        List<Groups_Screen> initialGroups_Screens = new List<Groups_Screen>();
        List<Groups_Action> initialGroups_Actions = new List<Groups_Action>();

        internal Groups group { get;set;} = new Groups();

        public frmGruposPermissao_Editar()
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
        private async Task getInitialPermissionsAsync()
        {
            initialGroups_Modules = await Groups_Module.getByGroupAsync(group.id);
            initialGroups_SubModules = await Groups_SubModule.getByGroupAsync(group.id);
            initialGroups_Screens = await Groups_Screen.getByGroupAsync(group.id);
            initialGroups_Actions = await Groups_Action.getByGroupAsync(group.id);

            await Permission.configureTreeView(treePermission);
            Permission.checkTreeView(treePermission, initialGroups_Modules, initialGroups_SubModules, initialGroups_Screens, initialGroups_Actions);
        }
        private async Task savePermissionAsync()
        {

            bool groupSaved = await updateGroupAsync();
            if (!groupSaved)
                return;

            string idGroup = group.id;

            //Enfileiramento das Tabelas de Exclusão
            Task t1 = Groups_Module.deleteByGroupAsync(idGroup);
            Task t2 = Groups_SubModule.deleteByGroupAsync(idGroup);
            Task t3 = Groups_Screen.deleteByGroupAsync(idGroup);
            Task t4 = Groups_Action.deleteByGroupAsync(idGroup);
            await Task.WhenAll(t1, t2, t3, t4);
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
        private async Task<bool> updateGroupAsync()
        {
            if (string.IsNullOrEmpty(txtNomeGrupo.Text))
            {
                CustomNotification.defaultAlert("O nome do grupo não pode ser nulo.");
                return false;
            }
            
            group.name = txtNomeGrupo.Text;
            group.description = txtDescricaoGrupo.Text;
            group.status = Convert.ToInt16(chkAtivo.Checked).ToString();            
            await Groups.updateAsync(group);
            return true;
        }

        /** sync Methods **/
        private void getInitialParameters()
        {
            txtCodGrupo.Text = group.id;
            txtNomeGrupo.Text = group.name;
            txtDescricaoGrupo.Text = group.description;
            chkAtivo.Checked = Convert.ToBoolean(Convert.ToInt16(group.status));            
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmGruposPermissao_Editar_Load;
        }
        private async void frmGruposPermissao_Editar_Load(object sender, EventArgs e)
        {
            //Attributes 
            await getInitialPermissionsAsync();
            getInitialParameters();


            //Events
            ConfigureButtonEvents();
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtCodGrupo.ReadOnly();
            txtName.ReadOnly();
            txtDescription.ReadOnly();
            
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
            if (CustomNotification.defaultQuestionAlert("A ação a seguir terá consequências, deseja continuar?") == DialogResult.Yes)
            {
                await savePermissionAsync();
            }
        }
    }
}
