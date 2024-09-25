using System;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.ModLicitacao.Cadastro
{
    public partial class frmEditarPlataforma : CustomForm
    {
        internal UHC3_Definitive_Version.Domain.Entities.Platform platform { get; set; }

        public frmEditarPlataforma()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();
            ConfigureFormEvents();
        }

        /** Async Methods **/
        public async Task updateAsync()
        {
            bool valid = true;
            try
            {
                if (!await UHC3_Definitive_Version.Domain.Entities.Platform.isValidName(txtPlatformName.Text, txtPlatformId.Text))
                {
                    CustomNotification.defaultAlert("Impossível realizar o cadastro, já existe uma plataforma com esse nome.");
                    valid = false;
                }
                if (!await UHC3_Definitive_Version.Domain.Entities.Platform.isValidLink(txtAccessLink.Text, txtPlatformId.Text) && valid)
                {
                    CustomNotification.defaultAlert("Impossível realizar o cadastro, já existe uma plataforma com esse link.");
                    valid = false; ;
                }
                if (!IsValidUrl(txtAccessLink.Text) && valid)
                {
                    CustomNotification.defaultAlert("URL inválida, por favor verifique e tente novamente.");
                    valid = false; ;
                }

                UHC3_Definitive_Version.Domain.Entities.Platform platform = new UHC3_Definitive_Version.Domain.Entities.Platform
                {
                    id = txtPlatformId.Text,
                    name = txtPlatformName.Text,
                    description = txtPlatformDescription.Text,
                    link = txtAccessLink.Text
                };

                if (valid)
                {
                    await UHC3_Definitive_Version.Domain.Entities.Platform.updateMultiUnityAsync(platform, "UNI HOSPITALAR");
                    await UHC3_Definitive_Version.Domain.Entities.Platform.updateMultiUnityAsync(platform, "UNI CEARÁ");
                    await UHC3_Definitive_Version.Domain.Entities.Platform.updateMultiUnityAsync(platform, "SP HOSPITALAR");
                    CustomNotification.defaultInformation();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.ToString());
            }


        }

        /** sync Methods **/
        public bool IsValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;

            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp ||
                    uriResult.Scheme == Uri.UriSchemeHttps ||
                    uriResult.Scheme == Uri.UriSchemeFtp);
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmEditarPlataforma_Load;
        }
        private void frmEditarPlataforma_Load(object sender, System.EventArgs e)
        {
            ConfigureTextBoxAttributes();
            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtPlatformId.ReadOnly = true;
            txtPlatformId.TabStop = false;

        }
        private void ConfigureTextBoxAttributes()
        {
            txtPlatformId.Text = platform.id;
            txtPlatformDescription.Text = platform.description;
            txtPlatformName.Text = platform.name;
            txtAccessLink.Text = platform.link;
        }
        private void ConfigureTextBoxEvents()
        {

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
            await updateAsync();
        }
    }
}
