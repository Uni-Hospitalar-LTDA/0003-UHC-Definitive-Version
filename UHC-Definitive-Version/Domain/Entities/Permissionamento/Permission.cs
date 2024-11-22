using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHC3_Definitive_Version.Domain.Permissionamento
{
    public class Permission
    {
        public static List<Module> Modules = new List<Module>();
        public static List<SubModule> SubModules = new List<SubModule>();
        public static List<Screen> Screens = new List<Screen>();
        public static List<Action> Actions = new List<Action>();


        public static List<Module> ModulesAllowed = new List<Module>();
        public static List<SubModule> SubModulesAllowed = new List<SubModule>();
        public static List<Screen> ScreensAllowed = new List<Screen>();
        public static List<Action> ActionsAllowed = new List<Action>();
        public async static Task configureTreeView(TreeView treePermission, bool checkable = true)
        {
            Modules = await Module.getAllToListAsync();
            SubModules = await SubModule.getAllToListAsync();
            Screens = await Screen.getAllToListAsync();
            Actions = await Action.getAllToListAsync();

            treePermission.CheckBoxes = checkable;
            treePermission.Nodes.Add("0", $"Permissões {Application.ProductName}");
            foreach (var module in Modules)
            {
                treePermission.Nodes["0"]
                    .Nodes.Add(module.Id, $"MOD{module.Id} - {module.Name}");
            }

            foreach (var subModule in SubModules)
            {
                treePermission.Nodes["0"]
                    .Nodes[subModule.idModule]
                    .Nodes.Add(subModule.Id, $"SUB{subModule.Id} - {subModule.Name}");
            }

            foreach (var screen in Screens)
            {
                treePermission.Nodes["0"]
                    .Nodes[SubModules.Find(sm => sm.Id == screen.idSubModule).idModule]
                    .Nodes[screen.idSubModule]
                    .Nodes.Add(screen.Id, $"SCR{screen.Id} - {screen.Name}");
            }
            foreach (var action in Actions)
            {
                treePermission.Nodes["0"]
                    .Nodes[SubModules.Find(sm => sm.Id == Screens.Find(s => s.Id == action.idScreen).idSubModule).idModule]
                    .Nodes[Screens.Find(s => s.Id == action.idScreen).idSubModule]
                    .Nodes[action.idScreen]
                    .Nodes.Add(action.Id, $"ACT{action.Id} - {action.Name}");
            }

            treePermission.AfterCheck += treePermission_AfterCheck;
            treePermission.ExpandAll();
            //return treePermission;
        }
        public static void checkTreeView(TreeView treePermission, List<Groups_Module> modules, List<Groups_SubModule> subModules, List<Groups_Screen> screens, List<Groups_Action> actions)
        {
            foreach (TreeNode node in treePermission.Nodes)
            {
                treePermission.AfterCheck -= treePermission_AfterCheck;
                //Cadeia de permissões nível 1 (Módulo)
                foreach (TreeNode node_1 in node.Nodes)
                {
                    var node_1Checked = from module in modules
                                        where module.idModule == node_1.Name
                                        select module.idModule;
                    foreach (var index in node_1Checked)
                    {
                        node.Nodes[Convert.ToInt32(index) - 1].Checked = true;
                    }
                    //Cadeia de permissões nível 2 (SubMódulo)
                    foreach (TreeNode node_2 in node_1.Nodes)
                    {
                        var node_2Checked = from subModule in subModules
                                            where subModule.idSubModule == node_2.Name
                                            select subModule.idSubModule;

                        foreach (var index in node_2Checked)
                        {
                            string key = (Convert.ToInt32(index)).ToString();
                            if (node_1.Nodes.ContainsKey(key))
                                node_1.Nodes[key].Checked = true;
                        }
                        //Cadeia de permissões nível 3 (Screen)
                        foreach (TreeNode node_3 in node_2.Nodes)
                        {
                            //MessageBox.Show(node_3.Name);
                            var node_3Checked = from screen in screens
                                                where screen.idScreen == node_3.Name
                                                select screen.idScreen;
                            foreach (var index in node_3Checked)
                            {
                                string key = (Convert.ToInt32(index)).ToString();
                                if (node_2.Nodes.ContainsKey(key))
                                    node_2.Nodes[key].Checked = true;
                            }
                            //Cadeia de permissões nível 4 (Action)
                            foreach (TreeNode node_4 in node_3.Nodes)
                            {
                                var node_4Checked = from action in actions
                                                    where action.idAction == node_4.Name
                                                    select action.idAction;
                                foreach (var index in node_4Checked)
                                {

                                    string key = (Convert.ToInt32(index)).ToString();
                                    if (node_3.Nodes.ContainsKey(key))
                                        node_3.Nodes[key].Checked = true;
                                }
                            }
                        }
                    }
                }
            }
            treePermission.AfterCheck += treePermission_AfterCheck;
            treePermission.ExpandAll();
        }
        private static void treePermission_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                e.Node.Expand();
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = true;
                }
            }
            else
            {
                e.Node.Toggle();
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = false;
                }
            }

        }
    }
}
