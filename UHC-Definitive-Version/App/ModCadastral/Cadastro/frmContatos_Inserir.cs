using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.ModCadastral.Cadastro
{
    public partial class frmContatos_Inserir : CustomForm
    {
        /** Instance **/
        internal string linkedType { get; set; }

        public frmContatos_Inserir()
        {
            InitializeComponent();

            /** Properties **/
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();

            /** Events **/
            ConfigureFormEvents();
        }

        /** Async Taks **/
        private async Task save()
        {

            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact
            {
                name = txtContactName.Text,
                description = txtContactDescription.Text,
                linkedAt = linkedType
            });

            try
            {
                await Contact.insertAsync(contacts);
                CustomNotification.defaultInformation();
                this.Close();
            }
            catch (Exception ex) 
            {
                CustomNotification.defaultError(ex.Message);
            }

        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCadastrarContatos_Load;
        }
        private void frmCadastrarContatos_Load(object sender, EventArgs e)
        {
            ConfigureTextBoxAttributes();
            ConfigureButtonEvents();
        }
        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSave.Click += btnSave_Click;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContactName.Text))
            {
                CustomNotification.defaultAlert("Preencha o nome do Contato.");
                return;
            }

            try
            {
                await save();                                                                
            }
            catch
            {

            }
        }

        /** Configure TextBox**/
        private async void ConfigureTextBoxAttributes()
        {
            txtIdContact.Text = (await Contact.getNextCodeAsync()).ToString();
        }
        private void ConfigureTextBoxProperties()
        {
            txtIdContact.ReadOnly = true;
            txtIdContact.TabStop = false;
            txtContactDescription.ScrollBars = ScrollBars.Vertical;
        }
    }
}
