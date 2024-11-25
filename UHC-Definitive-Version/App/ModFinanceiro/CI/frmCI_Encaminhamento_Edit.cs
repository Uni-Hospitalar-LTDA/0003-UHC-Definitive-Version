using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.CI;

namespace UHC3_Definitive_Version.App.ModFinanceiro.CI
{
    public partial class frmCI_Encaminhamento_Edit : CustomForm
    {
        /** Instance **/
        internal string followUpId { get; set; }
        CI_FollowUp followUp = new CI_FollowUp();
        public frmCI_Encaminhamento_Edit()
        {
            InitializeComponent();

            //Properties 
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();

            //Events 
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private async Task getResponsibleInformation()
        {
            followUp = await CI_FollowUp.getToClassAsync(followUpId);
            txtId.Text = followUp.id;
            txtDescription.Text = followUp.description;
            txtObservation.Text = followUp.observation;
            if (Convert.ToInt16(followUp.status) == 1)
            {
                chkAtivo.Checked = true;
            }
            txtCreationDate.Text = Convert.ToDateTime(followUp.dateCreated).ToShortDateString();
            txtEditionDate.Text = Convert.ToDateTime(followUp.dateEdited).ToShortDateString();
        }
        private async Task updateAsync()
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                CustomNotification.defaultAlert($"O campo [{txtDescription.Name}] não pode estar vazio!");
                return;
            }

            followUp.description = txtDescription.Text;
            followUp.observation = txtObservation.Text;
            followUp.status = chkAtivo.Checked ? "1" : "0";
            followUp.dateEdited = DateTime.Now.ToString();

            try
            {
                await CI_FollowUp.updateAsync(followUp);
                CustomNotification.defaultInformation("Encaminhamento da CI alterado com sucesso!");
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
            this.Load += frmCI_Acompanhamento_Edit_Load; ;
        }

        private async void frmCI_Acompanhamento_Edit_Load(object sender, EventArgs e)
        {
            //Atributes
            await getResponsibleInformation();


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
