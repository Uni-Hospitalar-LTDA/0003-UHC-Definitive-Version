using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    public partial class frmSelecionarUsuario : CustomForm
    {

        /** Instance **/
        internal List<Users> markedUsers = new List<Users>();
        List<Users> users = new List<Users>();

        public frmSelecionarUsuario()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            

            //Events
            ConfigureFormEvents();                        
        }


        /** Async Tasks **/
        private async Task getUsersAsync()
        {
            users = await Users.getAllToListAsync();


            foreach (var user in users)
            {
                clbUsers.Items.Add($"{user.id} - {user.login} - {user.name}");
            }

            foreach (var markedUser in markedUsers)
            {
                clbUsers.SetItemCheckState(clbUsers.Items.IndexOf($"{markedUser.id} - {markedUser.login} - {markedUser.name}"), CheckState.Checked);
            }
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmSelecionarUsuario_Load;
        }
        private async void frmSelecionarUsuario_Load(object sender, EventArgs e)
        {
            //attributes
            await getUsersAsync();


            ConfigureButtonEvents();
        }




        

        /** Button Configuration **/
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            markedUsers.Clear();
            this.Close();
        }
        
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            markedUsers.Clear();
            foreach (var checkedUser in clbUsers.CheckedItems)
            {
                string[] id = checkedUser.ToString().Split('-');
                markedUsers.Add(users.Where(u => u.id.Equals(id[0].Trim())).FirstOrDefault());
            }
            this.Close();
        }
    }
}
