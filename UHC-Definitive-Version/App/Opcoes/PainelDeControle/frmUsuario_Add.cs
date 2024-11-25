using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace _0009_Integra_Cob.App.Opcoes.PainelDeControle
{
    public partial class frmUsuario_Add : CustomForm
    {

        /** Instance **/
        List<Sector> sectors = new List<Sector>();

        public frmUsuario_Add()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();
            ConfigureListBoxProperties();

            //Events
            ConfigureFormEvents();
        }




        /** Async Tasks **/
        private async Task getInitialAttributes()
        {

            sectors = await Sector.getAllToListAsync();

            foreach (var sector in sectors)
            {
                lsbSetor.Items.Add(sector.Description);
            }
            lsbSetor.SelectedIndex = 0;
            lsbSetor.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private async Task saveAsync()
        {
            this.Cursor = Cursors.WaitCursor;
            Users us = await Users.getToClassByLoginAsync(txtDescUsuario.Text,Section.Unidade);
            if (!string.IsNullOrEmpty(us?.ToString()))
            {
                if (us.login?.ToUpper() == txtDescUsuario.Text.ToUpper())
                {
                    CustomNotification.defaultAlert($"Login já existente para outro usuário ({us.id} | {us.name})");
                    this.Cursor = Cursors.Default;
                    return;

                }
            }

            List<Users> users = new List<Users>();
            if (txtDescUsuario.Text.ToString().Trim().Equals(string.Empty))
            {
                CustomNotification.defaultAlert("O campo Usuário não pode estar nulo.");
                return;
            }
            if (txtNome.Text.ToString().Trim().Equals(string.Empty))
            {
                CustomNotification.defaultAlert("O campo Nome não pode estar nulo.");
                return;
            }


            if (txtPassword.Text.Equals(String.Empty))
            {
                users.Add(new Users
                {

                    login = txtDescUsuario.Text
                    ,
                    name = txtNome.Text
                    ,
                    email = txtEmail.Text
                    ,
                    idSector = sectors.First(s => s.Description.Equals(lsbSetor.SelectedItem.ToString())).Id
                    ,
                    setPassword = "1"
                });

            }
            else
            {
                users.Add(new Users
                {

                    login = txtDescUsuario.Text
                    ,
                    name = txtNome.Text
                    ,
                    email = txtEmail.Text
                    ,
                    idSector = sectors.First(s => s.Description.Equals(lsbSetor.SelectedItem.ToString())).Id
                    ,
                    password = Cryptography.crypt(txtPassword.Text)
                    ,
                    setPassword = "1"
                });
            }
            try
            {
                await Users.insertAsync(users);
                this.Cursor = Cursors.Default;
                CustomNotification.defaultInformation("Usuário inserido com sucesso!");
                this.Close();

            }
            catch (Exception ex)
            {
                CustomNotification.defaultAlert(ex.Message);
                this.Cursor = Cursors.Default;
                return;
            }

        }


        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmUsuario_Add_Load;
        }
        private async void frmUsuario_Add_Load(object sender, EventArgs e)
        {

            //Attributes
            await getInitialAttributes();

            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
            ConfigureListBoxEvents();


        }


        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            /** Comprimento suportado **/
            txtDescUsuario.MaxLength = 50;
            txtDescUsuario.Focus();

            txtNome.MaxLength = 50;
            txtEmail.MaxLength = 100;
            txtPassword.MaxLength = 30;
            txtPassword.PasswordChar = '*';

            txtDescUsuario.blockBackSpace();
            txtPassword.blockBackSpace();
        }
        private void ConfigureTextBoxEvents()
        {
        }

        /** Configure Button **/
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
        }
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultCloseButton();
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await saveAsync();
        }



        /** Configure ListBox **/
        private void ConfigureListBoxProperties()
        {
            lsbSetor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ConfigureListBoxEvents()
        {

        }
    }
}
