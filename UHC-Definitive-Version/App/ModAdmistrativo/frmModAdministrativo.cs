using System;
using UHC3_Definitive_Version.App.ModAdmistrativo.Cadastral;
using UHC3_Definitive_Version.App.ModAdmistrativo.Canhotos;
using UHC3_Definitive_Version.App.ModAdmistrativo.Fretes;
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
            //SubModules            
            gpbCadastral.Enabled = false;
            gpbCanhotos.Enabled = false;
            gpbFretes.Enabled = false;

            //Screen                        
            btnInformacoesTransportadora.Enabled = false;
            btnControleCanhotos.Enabled = false;            
            btnRelatorioAusencias.Enabled = false;            
            btnConversorParaLayoutFrete.Enabled = false;            
            btnConferenciaFretes.Enabled = false; 
            btnRelatorioAnaliticoFretes.Enabled = false;            
            btnManutencaoFretes.Enabled = false;

        }
        private void allows()
        {
            //SubModules
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Cadastral") != null)
                gpbCadastral.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Canhotos") != null)
                gpbCanhotos.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Fretes") != null)
                gpbFretes.Enabled = true;

            //Screen            
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Informações de Transportadora") != null)
                btnInformacoesTransportadora.Enabled = true;

            if (PermissionsAllowed.screens?.Find(m => m.Name == "Controle de Canhotos") != null)
                btnControleCanhotos.Enabled = true;
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Relatório de Ausências") != null)
                btnRelatorioAusencias.Enabled = true;

            if (PermissionsAllowed.screens?.Find(m => m.Name == "Conversor para Layout") != null)
                btnConversorParaLayoutFrete.Enabled = true;
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Conferência de Fretes") != null)
                btnConferenciaFretes.Enabled = true;
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Relatório Analítico") != null)
                btnRelatorioAnaliticoFretes.Enabled = true;
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Manutenção de Fretes") != null)
                btnManutencaoFretes.Enabled = true;

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
            //btnDeslogar.toDefaultRestartButton();
            //btnSair.toDefaultExitButton();
        }
            
        private void ConfigureButtonsEvents()
        {
            //Cadastral 
            btnInformacoesTransportadora.Click += btnInformacoesTransportadora_Click;

            //Canhotos
            btnControleCanhotos.Click += btnControleCanhotos_Click;
            btnRelatorioAusencias.Click += btnRelatorioAusencias_Click;

            //Fretes
            btnConversorParaLayoutFrete.Click += btnConversorParaLayoutFrete_Click;
            btnConferenciaFretes.Click += btnConferenciaFretes_Click;
            btnRelatorioAnaliticoFretes.Click += btnRelatorioAnaliticoFretes_Click;
            btnManutencaoFretes.Click += btnManutencaoFretes_Click;
        }

        private void btnManutencaoFretes_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmFretes_Conferencia_Ajuste>();
        }

        private void btnRelatorioAnaliticoFretes_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmFretes_RelatorioAnalitico>();
        }

        private void btnConferenciaFretes_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmFretes_Conferencia>();
        }

        private void btnConversorParaLayoutFrete_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmFretes_ConveresorDeLayout>();
        }

        private void btnRelatorioAusencias_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmRelatorioAusencias>();
        }

        private void btnControleCanhotos_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmControleCanhotos>();
        }

        private void btnInformacoesTransportadora_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmCadastroTransportador>();
        }

        

    }
}
