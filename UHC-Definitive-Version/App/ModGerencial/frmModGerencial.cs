using System;
using UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas;
using UHC3_Definitive_Version.App.ModGerencial.Informativo;
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
            gpbControladoriaDeDados.Enabled = false;
            btnEnvioDeDados.Enabled = false;


            //Screens
            btnAuditoriaDeDados.Enabled = false;
            btnValidacaoIntegridade.Enabled = false;




        }
        private void allows()
        {
            //SubModules
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Informações Restridas") != null)
                btnAuditoriaDeDados.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Envio de Dados") != null)
                btnEnvioDeDados.Enabled = true;



            //Screens
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Controladoria da Informação") != null)
                btnAuditoriaDeDados.Enabled = true;
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Arquivos IQVIA") != null)
                btnValidacaoIntegridade.Enabled = true;

        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultModuleScreen();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmModGerencial_Load;


            
        }

        private void frmModGerencial_Load(object sender, EventArgs e)
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
            //Controladoria de Informações 
            btnRestricaoDeDados.Click += btnRestricaoDeDados_Click;
            btnEnvioDeDados.Click += btnEnvioDeDados_Click;
            btnAuditoriaDeDados.Click += btnAuditoriaDeDados_Click;
            btnValidacaoIntegridade.Click += btnValidacaoIntegridade_Click;
            //Informativo
            btnMargemCompraVenda.Click += btnMargemCompraVenda_Click;
            

        }

        private void btnValidacaoIntegridade_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmAnaliseIqviaSintetico>();
        }

        private void btnAuditoriaDeDados_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmAcessoRestrito_Historico>();
        }

        private void btnEnvioDeDados_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmAcessoRestrito_EnviarArquivos>();
        }

        private void btnRestricaoDeDados_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmAcessoRestrito>();
        }

        private void btnMargemCompraVenda_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmMargemCompraVenda>();
        }

        private void bnArquivosIqvia_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmEnvioDeDados_IQVIA>();
        }

        private void btnControladoriaDaInformacao_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmControladoria>();
        }
    

        private void lblGerencial_Click(object sender, EventArgs e)
        {

        }

        private void btnDeslogar_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }
    }
}
