using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.CI;

namespace UHC3_Definitive_Version.App.ModFinanceiro.CI
{
    public partial class frmCI_Responsavel_Add : CustomForm
    {
        public frmCI_Responsavel_Add()
        {
            InitializeComponent();


            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();

            //Events
            ConfigureFormEvents();

        }

        /** Async Tasks **/
        private async Task saveAsync()
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                CustomNotification.defaultAlert("A descrição do Responsável não pode estar vazia!");
                txtDescription.Focus();

                return;
            }



            List<CI_Responsible> responsibles = new List<CI_Responsible>
            {   new CI_Responsible
            {
                description = txtDescription.Text,
                observation = txtObservation.Text,
                status = "1",
                dateCreated = DateTime.Now.ToString(),
                dateEdited = DateTime.Now.ToString(),
                idUser = Section.idUsuario.ToString()
            }
            };


            try
            {
                await CI_Responsible.insertAsync(responsibles);
                CustomNotification.defaultInformation("Responsável de C.I inserido com sucesso!");
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
            this.Load += frmCI_Responsavel_Add_Load;
        }
        private void frmCI_Responsavel_Add_Load(object sender, EventArgs e)
        {
            ConfigureButtonEvents();
        }


        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnCancel.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSave.Click += btnSave_Click;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            await saveAsync();
        }


    }
}
