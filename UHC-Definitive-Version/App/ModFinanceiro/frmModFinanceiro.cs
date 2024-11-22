using UHC3_Definitive_Version.App.ModContabilFiscal.Configuracoes;
using UHC3_Definitive_Version.App.ModContabilFiscal.Relatorios;
using UHC3_Definitive_Version.App.ModFinanceiro.Acompanhamento;
using UHC3_Definitive_Version.App.ModFinanceiro.Cadastral;
using UHC3_Definitive_Version.App.ModFinanceiro.CI;
using UHC3_Definitive_Version.App.ModFinanceiro.Cobranca;
using UHC3_Definitive_Version.App.ModFinanceiro.MonitoresFinanceiros;
using UHC3_Definitive_Version.App.ModFinanceiro.Pagamentos;
using UHC3_Definitive_Version.App.ModFinanceiro.Recebimento;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;

namespace UHC3_Definitive_Version.App.ModFinanceiro
{
    public partial class frmModFinanceiro : CustomForm
    {
        public frmModFinanceiro()
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
            gpbAcompanhamento.Enabled = false;
            gpbCI.Enabled = false;
            gpbCadastral.Enabled = false;
            gpbCobranca.Enabled = false;
            gpbMonitoresFinanceiros.Enabled = false;
            gpbPagamento.Enabled = false;
            gpbRecebimento.Enabled = false;

            //Screens
            btnTitulosVsEmpenhos.Enabled = false;
            btnConferenciaCi.Enabled = false;
            btnEncaminhamentos.Enabled = false;
            btnResponsaveis.Enabled = false;
            btnContatosDoCliente.Enabled = false;
            btnParametrosCobranca.Enabled = false;
            btnMonitorGnre.Enabled = false;
            btnContasPagarAnalitico.Enabled = false;
            btnContasPagarRanking.Enabled = false;
            btnContasReceberAnalitico.Enabled = false;
            btnContasReceberRanking.Enabled = false;
            btnContasRecebidas.Enabled = false;
            btnRecPublicoPrivado.Enabled = false;


        }
        private void allows()
        {        
            //SubModules
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Acompanhamento") != null)
                gpbAcompanhamento.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "CI") != null)
                gpbCI.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Cadastral") != null)
                gpbCadastral.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Cobrança") != null)
                gpbCobranca.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Monitores Financeiros") != null)
                gpbMonitoresFinanceiros.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Pagamento") != null)
                gpbPagamento.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Recebimento") != null)
                gpbRecebimento.Enabled = true;

            //Screens
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Títulos Vs Empenho") != null) // 1
                btnTitulosVsEmpenhos.Enabled = true;

            //2
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Conferência de CI") != null) 
                btnConferenciaCi.Enabled = true;
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Encaminhamentos") != null)
                btnEncaminhamentos.Enabled = true;
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Responsáveis") != null)
                btnResponsaveis.Enabled = true;

            //3
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Contatos do Cliente") != null)
                btnContatosDoCliente.Enabled = true;
            //4
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Parâmetros de Cobrança") != null)
                btnParametrosCobranca.Enabled = true;

            //5
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Monitor GNRE") != null)
                btnMonitorGnre.Enabled = true;

            //6
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Contas a Pagar") != null)
            {
                btnContasPagarAnalitico.Enabled = true;
                btnContasPagarRanking.Enabled = true;
            }

            //7
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Contas a Receber") != null)
            {
                btnContasReceberAnalitico.Enabled = true;
                btnContasReceberRanking.Enabled = true;
            }
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Contas Recebidas") != null)
                btnContasRecebidas.Enabled = true;
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Recebimento Público e Privado") != null)
                btnRecPublicoPrivado.Enabled = true;          
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
            //Acompanhamento
            btnTitulosVsEmpenhos.Click += btnTitulosVsEmpenhos_Click;

            //Cadastral
            btnContatosDoCliente.Click += btnContatosDoCliente_Click;

            //C.I.
            btnConferenciaCi.Click += btnConferenciaCi_Click;
            btnEncaminhamentos.Click += btnEncaminhamentos_Click;
            btnResponsaveis.Click += btnResponsaveis_Click;

            //Cobrança
            btnParametrosCobranca.Click += btnParametrosCobranca_Click;

            //Monitores financeiros
            btnMonitorGnre.Click += btnMonitorGnre_Click;

            //Pagamentos
            btnContasPagarAnalitico.Click += btnContasPagarAnalitico_Click;
            btnContasPagarRanking.Click += BtnContasPagarRanking_Click;

            //Recebimento
            btnContasReceberAnalitico.Click += btnContasReceberAnalitico_Click;
            btnContasRecebidas.Click += btnContasRecebidas_Click;
            btnRecPublicoPrivado.Click += btnRecPublicoPrivado_Click;
            btnContasReceberRanking.Click += btnContasReceberRanking_Click;



        }

        private void btnContasReceberRanking_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmRecebimento_CarRanking>();
        }

        private void BtnContasPagarRanking_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmRecPublicoPrivado>();
        }
        private void btnRecPublicoPrivado_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmRecPublicoPrivado>();
        }

        private void btnContasRecebidas_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmContasRecebidas>();
        }

        private void btnContasReceberAnalitico_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmContasReceber>();
        }

        private void btnContasPagarAnalitico_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmContasPagar>();
        }

        private void btnMonitorGnre_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmMonitores_ExpXmlGnre>();
        }

        private void btnParametrosCobranca_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmParametrosDeCobranca>();
        }

        private void btnResponsaveis_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmCI_Responsavel>();
        }
        private void btnEncaminhamentos_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmCI_Encaminhamento>();
        }
        private void btnConferenciaCi_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmCI_Conferencia>();
        }

        private void btnContatosDoCliente_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmSelecionarCliente>();
        }
        
        private void btnTitulosVsEmpenhos_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmTitulosVsEmpenho>();
        }
    }
}
