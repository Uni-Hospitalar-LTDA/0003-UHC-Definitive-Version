using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    public partial class frmUsuario_Editar : CustomForm
    {
        /** Instance **/
        internal Users persistent { get; set;} =  new Users();
        List<Sector> sectors = new List<Sector>();
      
        public frmUsuario_Editar()
        {
            InitializeComponent();


            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();

            //Events
            ConfigureFormEvents();
        }
        
        /** Async Task **/
        private async Task getInitialParametersAsync()
        {
            txtCodUsuario.Text = persistent.id;
            txtNome.Text = persistent.name;
            txtDescUsuario.Text = persistent.login;
            txtEmail.Text = persistent.email;
            txtPassword.Text = Cryptography.decrypt(persistent.password);
            chkAtivo.Checked = Convert.ToBoolean(Convert.ToInt16(persistent.Status));
            sectors = await Sector.getAllToListAsync();

            foreach (var sector in sectors)
            {
                lsbSetor.Items.Add(sector.Description);
            }
            try
            {
                lsbSetor.SelectedItem = (await Sector.getToClassAsync(persistent.idSector)).Description;
            }
            catch (Exception ex) 
            {
                CustomNotification.defaultAlert(ex.Message);
            }

            lsbSetor.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        /** Sync Methods **/
        private Users getCurrentUser()
        {

            Users user = new Users
            {
                id = txtCodUsuario.Text
               ,login = txtDescUsuario.Text
               ,name = txtNome.Text
               ,email = txtEmail.Text
               ,password = txtPassword.Text
               ,idSector = sectors.First(s => s.Description.Equals(lsbSetor.SelectedItem.ToString())).Id
               ,Status = Convert.ToInt16(chkAtivo.Checked).ToString()
            };
            return user;
        }


        /** Configure Form **/
        private async void frmUsuario_Editar_Load(object sender, EventArgs e)
        {
            //Attributes
            await getInitialParametersAsync();


            //Events 
            ConfigureButtonEvents();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmUsuario_Editar_Load;
        }
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtCodUsuario.ReadOnly();


            /** Comprimento suportado **/
            txtDescUsuario.MaxLength = 50;
            txtDescUsuario.Focus();

            txtNome.MaxLength = 50;
            txtEmail.MaxLength = 100;
            //txtPassword.MaxLength = 30;
            txtPassword.PasswordChar = '*';

            txtDescUsuario.blockBackSpace();
            txtPassword.blockBackSpace();
        }

        /** Configure Button **/
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
            await updateAsync();
        }

        private async Task updateAsync()
        {
            string error = null;
            try
            {               

                if ((txtDescUsuario.Text != persistent.login) || (txtEmail.Text != persistent.email) || (txtNome.Text != persistent.name) || (txtPassword.Text != persistent.password))
                {
                    error = await Users.updateAsync(getCurrentUser());
                }
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                if (error == null)
                {
                    CustomNotification.defaultInformation();

                    this.Close();
                }
            }
        }

        
    }
}
