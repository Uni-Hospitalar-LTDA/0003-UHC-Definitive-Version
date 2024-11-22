using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.ModLicitacao.Cadastro
{
    public partial class frmCadastrarPlataformas : CustomForm
    {
        public frmCadastrarPlataformas()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();
            ConfigureFormEvents();
        }

        /** Async Methods **/
        public async Task saveAsync()
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

                List<UHC3_Definitive_Version.Domain.Entities.Platform> platforms = new List<UHC3_Definitive_Version.Domain.Entities.Platform>();
                platforms.Add(new UHC3_Definitive_Version.Domain.Entities.Platform
                {
                    name = txtPlatformName.Text,
                    description = txtPlatformDescription.Text,
                    link = txtAccessLink.Text,
                });

                if (valid)
                {
                    await UHC3_Definitive_Version.Domain.Entities.Platform.insertMultiUnityAsync(platforms, "UNI HOSPITALAR");
                    await UHC3_Definitive_Version.Domain.Entities.Platform.insertMultiUnityAsync(platforms, "UNI CEARÁ");
                    await UHC3_Definitive_Version.Domain.Entities.Platform.insertMultiUnityAsync(platforms, "SP HOSPITALAR");
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
            this.Load += frmCadastrarPlataformas_Load;
        }
        private async void frmCadastrarPlataformas_Load(object sender, System.EventArgs e)
        {
            await ConfigureTextBoxAttributes();
            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtPlatformId.ReadOnly = true;
            txtPlatformId.TabStop = false;

        }
        private async Task ConfigureTextBoxAttributes()
        {
            txtPlatformId.Text = (await UHC3_Definitive_Version.Domain.Entities.Platform.getNextCodeAsync()).ToString();
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
            await saveAsync();
        }

    }
}
