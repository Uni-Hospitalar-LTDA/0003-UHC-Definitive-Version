using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    public partial class frmGruposPermissao_Usuarios : CustomForm
    {
        /** Instance **/
        List<Users> initialUsers = new List<Users>();
        List<Users> finalUsers = new List<Users>();
        internal Groups group { get; set; }

        public frmGruposPermissao_Usuarios()
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
        private async Task getUsersAsync()
        {
            initialUsers = await Users.getUsersByGroup(group.id);
            finalUsers = await Users.getUsersByGroup(group.id);

            lsbUsuarios.Invoke((MethodInvoker)delegate
            {
                foreach (var user in initialUsers)
                {
                    lsbUsuarios.Items.Add($"{user.id} - {user.login} - {user.name}");
                }
            });
        }
        private async Task saveAsync()
        {
            List<Users_Groups> users_Groups = new List<Users_Groups>();
            await Users_Groups.deleteUsersFromGroupAsync(group.id);
            foreach (var user in finalUsers)
            {
                users_Groups.Add(new Users_Groups { idUsers = user.id, idGroups = txtCodGrupo.Text });
            }
            await Users_Groups.insertAsync(users_Groups);
        }
        /** Sync Methods **/
        private void getGroup()
        {
            txtCodGrupo.Text = group.id;
            txtGrupo.Text = group.name;
        }
        private void limparDados()
        {
            lsbUsuarios.Items.Clear();
            finalUsers.Clear();
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmGruposPermissao_Usuarios_Load;
            this.KeyDown += frmGruposPermissao_Usuarios_KeyDown;
        }
        private async void frmGruposPermissao_Usuarios_Load(object sender, EventArgs e)
        {
            //Attributes 
            await getUsersAsync();
            getGroup();

            //Events
            ConfigureButtonEvents();
        }
        private void frmGruposPermissao_Usuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                btnRemover_Click(sender, e);
            }
        }
        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtCodGrupo.ReadOnly();
            txtGrupo.ReadOnly();
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnAdd.Click += btnAdd_Click;
            btnRemover.Click += btnRemover_Click;
            btnSalvar.Click += btnSalvar_Click;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSelecionarUsuario frmSelecionarUsuario = new frmSelecionarUsuario();
            foreach (var user in lsbUsuarios.Items)
            {
                string[] id = user.ToString().Split('-');
                frmSelecionarUsuario.markedUsers.Add(initialUsers.Where(u => u.id.Equals(id[0].Trim())).FirstOrDefault());
            }
            frmSelecionarUsuario.ShowDialog();

            limparDados();
            if (frmSelecionarUsuario.markedUsers.Count > 0)
            {

                foreach (var markedUser in frmSelecionarUsuario.markedUsers)
                {
                    finalUsers.Add(markedUser);
                    lsbUsuarios.Items.Add($"{markedUser.id} - {markedUser.login} - {markedUser.name}");
                }
            }
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lsbUsuarios.SelectedItem != null)
            {
                string[] id = lsbUsuarios.SelectedItem.ToString().Split('-');
                if (finalUsers.Contains(finalUsers.Where(u => u.id.Equals(id[0].Trim())).FirstOrDefault()))
                {
                    finalUsers.Remove(finalUsers.Where(u => u.id.Equals(id[0].Trim())).FirstOrDefault());
                    lsbUsuarios.Items.Remove(lsbUsuarios.SelectedItem);
                }
            }
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
           
            try
            {
                await saveAsync();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                CustomNotification.defaultInformation();
                this.Close();
            }
        }
    }
}
