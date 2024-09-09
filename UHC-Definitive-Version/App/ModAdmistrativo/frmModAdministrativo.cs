using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.ModAdmistrativo.Cadastral;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;

namespace UHC3_Definitive_Version.App.ModAdmistrativo
{
    public partial class frmModAdministrativo : CustomForm
    {
        public frmModAdministrativo()
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
            //Screen

        }
        private void allows()
        {
            //SubModules

            //Screen            

        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultModuleScreen();
        }
        private void ConfigureFormEvents()
        {
            blocks();
            allows();


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
            btnInformacoesTransportadora.Click += btnInformacoesTransportadora_Click; ;          
        }

        private void btnInformacoesTransportadora_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmCadastroTransportador>();
        }

        

    }
}
