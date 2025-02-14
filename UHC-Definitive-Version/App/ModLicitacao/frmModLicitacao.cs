using System;
using UHC3_Definitive_Version.App.AplicacoesParceiras;
using UHC3_Definitive_Version.App.ModLicitacao.AnaliseVendas;
using UHC3_Definitive_Version.App.ModLicitacao.Cadastro;
using UHC3_Definitive_Version.App.ModLicitacao.Processos.AgendaProcessos;
using UHC3_Definitive_Version.App.ModLicitacao.Processos.RelatoriosGerenciais;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Permissionamento;

namespace UHC3_Definitive_Version.App
{
    public partial class frmModLicitacao : CustomForm
    {
        public frmModLicitacao()
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
                gpbAnaliseDeVendas.Enabled = false;
                gpbCadastro.Enabled = false;
                gpbContratos.Enabled = false;
                gpbProcessos.Enabled = false;
                gpbProgramasAuxiliares.Enabled = false;
                btnAgendaProcessos.Enabled = false;
                btnRelatoriosGerenciaisSintetico.Enabled = false;
                btnRelatoriosGerenciaisAnaliticos.Enabled = false;
        }
        private void allows()
        {
            //SubModules            
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Análise de Vendas") != null)
                gpbAnaliseDeVendas.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Cadastro") != null)
                gpbCadastro.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Contratos") != null)
                gpbContratos.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Processos") != null)
                gpbProcessos.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Programas auxiliares") != null)
                gpbProgramasAuxiliares.Enabled = true;


            if (PermissionsAllowed.screens?.Find(m => m.Name == "Agenda de Processos") != null)
                btnAgendaProcessos.Enabled = true;
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Relatórios Gerenciais") != null)
            {
                btnRelatoriosGerenciaisSintetico.Enabled = true;
                btnRelatoriosGerenciaisAnaliticos.Enabled = true;
            }

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
            btnDetalhamentoContratos.Click += btnDetalhamentoContratos_Click;
            
            btnInformativoProdutos.Click += btnInformativoProdutos_Click;
            
            btnPlataformas.Click += btnPlataformas_Click;
            btnJustificativaAgenda.Click += btnJustificativaAgenda_Click;

            btnAgendaProcessos.Click += btnAgendaProcessos_Click;
            btnRelatoriosGerenciaisAnaliticos.Click += btnRelatoriosGerenciaisAnaliticos_Click;
            btnRelatoriosGerenciaisSintetico.Click += btnRelatoriosGerenciaisSintetico_Click;

            btnKairos.Click += btnKairos_Click;
        }

        private void btnKairos_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmKairos>();
        }
        private void btnRelatoriosGerenciaisSintetico_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmProcGenDashboardPorResponsavel>();
        }
        private void btnRelatoriosGerenciaisAnaliticos_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmProcGenDashboardPorTempo>();
        }
        private void btnAgendaProcessos_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmListaAgenda>();
        }
        private void btnJustificativaAgenda_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmCadastrarJustificativasDeParticipacao>();
        }
        private void btnPlataformas_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmPlataformas>();
        }
        private void btnInformativoProdutos_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmInformativoDeProdutos>();
        }
        private void btnDetalhamentoContratos_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmDetalhamentoDeContratos>();
        }
    }
}
