using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;

namespace UHC3_Definitive_Version.App.ModGerencial
{
    public partial class frmModGerencial : CustomForm
    {
        public frmModGerencial()
        {
            InitializeComponent();

            /** Properties **/
            ConfigureFormProperties();
            ConfigureButtonProperties();
            /** Events **/
            ConfigureFormEvents();

        }

        private void blocks()
        {
            //SubModules            
            gpbInformacoesRestritas.Enabled = false;
            gpbEnvioDados.Enabled = false;


            //Screens
            btnControladoriaDaInformacao.Enabled = false;
            btnArquivosIqvia.Enabled = false;




        }
        private void allows()
        {
            //SubModules
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Informações Restridas") != null)
                gpbInformacoesRestritas.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Envio de Dados") != null)
                gpbEnvioDados.Enabled = true;
          


            //Screens
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Controladoria da Informação") != null)
                btnControladoriaDaInformacao.Enabled = true;
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Arquivos IQVIA") != null)
                btnArquivosIqvia.Enabled = true;
           
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultModuleScreen();
        }
        private void ConfigureFormEvents()
        {
            //blocks();
            //allows();


            //Events
            ConfigureButtonsEvents();
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnDeslogar.toDefaultRestartButton();
            btnSair.toDefaultExitButton();
        }

        private void ConfigureButtonsEvents()
        {
            //Informações Restridas
            btnControladoriaDaInformacao.Click += btnControladoriaDaInformacao_Click;

            //Envio de Dados
            btnArquivosIqvia.Click += bnArquivosIqvia_Click;

        }

        private void bnArquivosIqvia_Click(object sender, System.EventArgs e)
        {
            
        }

        private void btnControladoriaDaInformacao_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmControladoria>();
        }
    }
}
