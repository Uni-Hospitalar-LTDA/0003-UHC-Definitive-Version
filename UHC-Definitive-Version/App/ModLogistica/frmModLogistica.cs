using System;
using UHC3_Definitive_Version.App.ModLogistica.CI;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.App.ModLogistica
{
    public partial class frmModLogistica : CustomForm
    {
        public frmModLogistica()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureFormEvents();
        }

        private void blocks()
        {
            //SubModules            
            //gpbInformacoesRestritas.Enabled = false;
            //gpbEnvioDados.Enabled = false;


            //Screens
            //btnControladoriaDaInformacao.Enabled = false;
            //btnArquivosIqvia.Enabled = false;




        }
        private void allows()
        {
            ////SubModules
            //if (PermissionsAllowed.subModules?.Find(m => m.Name == "Informações Restridas") != null)
            //    gpbInformacoesRestritas.Enabled = true;
            //if (PermissionsAllowed.subModules?.Find(m => m.Name == "Envio de Dados") != null)
            //    gpbEnvioDados.Enabled = true;



            ////Screens
            //if (PermissionsAllowed.screens?.Find(m => m.Name == "Controladoria da Informação") != null)
            //    btnControladoriaDaInformacao.Enabled = true;
            //if (PermissionsAllowed.screens?.Find(m => m.Name == "Arquivos IQVIA") != null)
            //    btnArquivosIqvia.Enabled = true;

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
            btnConferenciaCI.Click += btnConferenciaCI_Click;
            btnMotivosCI.Click += btnMotivosCI_Click;

        }

        private void btnMotivosCI_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmCI_Motivos>();
        }

        private void btnConferenciaCI_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmCI_Conferencia>();
        }
    }
}
