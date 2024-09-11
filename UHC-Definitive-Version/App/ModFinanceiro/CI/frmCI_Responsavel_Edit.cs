using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.CI;

namespace UHC3_Definitive_Version.App.ModFinanceiro.CI
{
    public partial class frmCI_Responsavel_Edit : CustomForm
    {
        internal string responsibleId { get; set; }
        CI_Responsible responsible = new CI_Responsible();

        public frmCI_Responsavel_Edit()
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
            responsible = await CI_Responsible.getToClassAsync(responsibleId);
            txtId.Text = responsible.id;
            txtDescription.Text = responsible.description;
            txtObservation.Text = responsible.observation;
            if (Convert.ToInt16(responsible.status) == 1)
            {
                chkAtivo.Checked = true;
            }
            txtCreationDate.Text = Convert.ToDateTime(responsible.dateCreated).ToShortDateString();
            txtEditionDate.Text = Convert.ToDateTime(responsible.dateEdited).ToShortDateString();
        }
        private async Task updateAsync()
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                CustomNotification.defaultAlert($"O campo [{txtDescription.Name}] não pode estar vazio!");
                return;
            }

            responsible.description = txtDescription.Text;
            responsible.observation = txtObservation.Text;
            responsible.status = chkAtivo.Checked ? "1" : "0";
            responsible.dateEdited = DateTime.Now.ToString();

            try
            {
                await CI_Responsible.updateAsync(responsible);
                CustomNotification.defaultInformation("Responsável da CI alterado com sucesso!");
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
            this.Load += frmCI_Responsavel_Edit_Load;
        }

        private async void frmCI_Responsavel_Edit_Load(object sender, EventArgs e)
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
