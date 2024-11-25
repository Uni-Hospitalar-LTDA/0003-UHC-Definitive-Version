using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.CI;

namespace UHC3_Definitive_Version.App.ModLogistica.CI
{
    public partial class frmCI_Motivos_Add : CustomForm
    {
        public frmCI_Motivos_Add()
        {
            InitializeComponent();
            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();
            
            //Events
            ConfigureFormEvents();
        }

      

        //Async Tasks 
        private async Task saveAsync()
        {

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                CustomNotification.defaultAlert($"O campo [{txtDescription.Name}] não pode estar vazio!");
                return;
            }
            List<CI_Reason> reasons = new List<CI_Reason>();
            reasons.Add(new CI_Reason
            {
                description = txtDescription.Text,
                observation = txtObservacao.Text,
                moveReturns = (rdbYes.Checked ? "1": "0"),
                status = "1",
                dateCreated = DateTime.Now.ToString(),
                dateEdited = DateTime.Now.ToString(),
                idUser = Section.idUsuario
            }) ;

            try
            {
                await CI_Reason.insertAsync(reasons);
                CustomNotification.defaultInformation("Motivo de C.I inserido com sucesso!");
                this.Close();
            }catch (Exception ex)
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
            this.Load += frmCI_Motivos_Add_Load;
        }

        private void frmCI_Motivos_Add_Load(object sender, EventArgs e)
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

        /** TextBox configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtDescription.MaxLength = 255;
            txtObservacao.ScrollBars = ScrollBars.Vertical;
        }
    }
}
