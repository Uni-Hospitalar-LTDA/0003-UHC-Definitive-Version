using System;
using UHC3_Definitive_Version.App.AplicacoesParceiras;
using UHC3_Definitive_Version.App.ModVendas.AnaliseVendas;
using UHC3_Definitive_Version.App.ModVendas.Cadastros;
using UHC3_Definitive_Version.App.ModVendas.Consultas;
using UHC3_Definitive_Version.App.ModVendas.Pedidos;
using UHC3_Definitive_Version.App.ModVendas.Precificacao;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Permissionamento;

namespace UHC3_Definitive_Version.App.ModVendas
{
    public partial class frmModVendas : CustomForm
    {
        public frmModVendas()
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
            gpbIngestaoDados.Enabled = false;
            


            ////Screens
            //btnControladoriaDaInformacao.Enabled = false;
            //btnArquivosIqvia.Enabled = false;




        }
        private void allows()
        {
            //SubModules
            if (PermissionsAllowed.subModules?.Find(m => m.Name == "Ingestão de Dados") != null)
                gpbIngestaoDados.Enabled = true;
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
            btnConsultaPrecos.Click += btnPrecificacao_Click;
            btnConsultarPedidoCliente.Click += btnConsultarPedidoCliente_Click;
            btnConsultarPedidoOL.Click += btnConsultarPedidoOL_Click;
            btnKairos.Click += btnKairos_Click;            
            btnAnaliseDebCredAche.Click += btnCreditDebitAnalysis_Click;
            btnDataIngestion.Click += btnDataIngestion_Click;
            btnPedidoPfizerInterplayers.Click += btnPedidoPfizerInterplayers_Click;
            btnBayerInterplayers.Click += btnBayerInterplayers_Click;
        }

        private void btnBayerInterplayers_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmPedidoBayerInterplayers>();
        }

        private void btnPedidoPfizerInterplayers_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmPedidoPfizerInterplayers>();
        }

        private void btnKairos_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmKairos>();
        }
        private void btnPrecificacao_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmConsultaDePrecos>();
        }
        private void btnConsultarPedidoCliente_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmConsultarPedidoCliente>();
        }
        private void btnConsultarPedidoOL_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmConsultarPedidoOL>();
        }
        private void btnDataIngestion_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmVendas_DataIngestion>();
        }

        private void btnCreditDebitAnalysis_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmAnaliseDebitoCreditoAche>();
        }

    }
}
