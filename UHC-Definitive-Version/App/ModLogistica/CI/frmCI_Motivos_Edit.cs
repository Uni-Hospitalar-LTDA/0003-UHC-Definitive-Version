using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.CI;

namespace UHC3_Definitive_Version.App.ModLogistica.CI
{
    public partial class frmCI_Motivos_Edit : CustomForm
    {
        /** Instance **/
        internal string reasonId {get;set;}
        CI_Reason reason = new CI_Reason();
        
        public frmCI_Motivos_Edit()
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
        private async Task getReasonInformation()
        {
            reason = await CI_Reason.getToClassAsync(reasonId);
            txtId.Text = reason.id;
            txtDescription.Text = reason.description;
            txtObservation.Text = reason.observation;
            if (Convert.ToInt16(reason.moveReturns) == 1)
                rdbYes.Checked = true;
            else
                rdbNo.Checked = true;
            if (Convert.ToInt16(reason.status) == 1)
            {
                chkAtivo.Checked = true;
            }
            txtCreationDate.Text = Convert.ToDateTime(reason.dateCreated).ToShortDateString();
            txtEditionDate.Text = Convert.ToDateTime(reason.dateEdited).ToShortDateString();
        }
        private async Task updateAsync()
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                CustomNotification.defaultAlert($"O campo [{txtDescription.Name}] não pode estar vazio!");
                return;
            }

            reason.description = txtDescription.Text;
            reason.observation = txtObservation.Text;
            reason.moveReturns = (rdbYes.Checked ? "1" : "0");
            reason.status = chkAtivo.Checked ? "1" : "0";
            reason.dateEdited = DateTime.Now.ToString();

            try
            {
                await CI_Reason.updateAsync(reason);
                CustomNotification.defaultInformation("Motivo de CI alterado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultInformation(ex.Message);
            }
        }
        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCI_Motivos_Edit_Load;
        }
        private async void frmCI_Motivos_Edit_Load(object sender, EventArgs e)
        {
            //Atributes
            await getReasonInformation();


            //Events
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
            await updateAsync();
        }

       

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtId.ReadOnly();
            txtCreationDate.ReadOnly();
            txtEditionDate.ReadOnly();

            txtDescription.MaxLength = 255;
            txtObservation.ScrollBars = ScrollBars.Vertical;
        }
    }
}
