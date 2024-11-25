using UHC3_Definitive_Version.App.ModContabilFiscal.Configuracoes;
using UHC3_Definitive_Version.App.ModContabilFiscal.Relatorios;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;

namespace UHC3_Definitive_Version.App.ModContabilFiscal
{
    public partial class frmModContabilFiscal : CustomForm
    {
        public frmModContabilFiscal()
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
            gpbConfiguracao.Enabled = false;
            gpbRelatorios.Enabled = false;

            ////Screen                        
            btnParametrizacaoFiscalPorUf.Enabled = false;
            btnRelatorioDifalDevAnalitico.Enabled = false;
            btnRelatorioDifalDevSintetico.Enabled = false;
            

        }
        private void allows()
        {
            //SubModules
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Configurações") != null)
                gpbConfiguracao.Enabled = true;
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Relatórios") != null)
                gpbRelatorios.Enabled = true;
            

            //Screen            
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Parametrização Fiscal por UF") != null)
                btnParametrizacaoFiscalPorUf.Enabled = true;

            if (PermissionsAllowed.screens?.Find(m => m.Name == "Relação de Difal x Dev. (Analítico)") != null)
                btnRelatorioDifalDevAnalitico.Enabled = true;
            if (PermissionsAllowed.screens?.Find(m => m.Name == "Relação de Difal x Dev. (Sintético)") != null)
                btnRelatorioDifalDevSintetico.Enabled = true;        
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
            //Configurações
            btnParametrizacaoFiscalPorUf.Click += btnParametrizacaoFiscalPorUf_Click;

            //Relatórios
            btnRelatorioDifalDevAnalitico.Click += btnRelatorioDifalDevAnalitico_Click;
            btnRelatorioDifalDevSintetico.Click += btnRelatorioDifalDevSintetico_Click;
            

            
        }

        private void btnRelatorioDifalDevSintetico_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmRelatorioDifalDevSintetico>();
        }

        private void btnRelatorioDifalDevAnalitico_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmRelatorioDifalDevAnalitico>();
        }

        private void btnParametrizacaoFiscalPorUf_Click(object sender, System.EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmParametrizacaoFiscalPorUf>();
        }
    }
}
