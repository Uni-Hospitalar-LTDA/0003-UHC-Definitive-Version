using System;
using System.Runtime.Remoting;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using static UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas.frmAnaliseIqviaSintetico;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAnaliseIqviaSintetico_Parametrizacao : CustomForm
    {
        public frmAnaliseIqviaSintetico_Parametrizacao()
        {
            InitializeComponent();

            /** Form Properties **/
            ConfigureButtonProperties();
            ConfigureFormProperties();
            ConfigureTextBoxProperties();

            /** Form Events **/
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        public async Task getCode()
        {
            txtCodigo.Text =  (await RelatorioAnaliseIqvia.getQueryAsync())?.Query;
        }

        public async Task saveAsync()
        {
            try
            {
                await RelatorioAnaliseIqvia.deleteAllAsync();
                await RelatorioAnaliseIqvia.insertAsync(new RelatorioAnaliseIqvia
                {
                    Query = txtCodigo.Text
                });
                CustomNotification.defaultInformation();
            }
            catch (Exception ex) 
            {
                CustomNotification.defaultError("Falha ao adicionar o relatório: "+ex.Message);
            }
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmAnaliseIqviaSintetico_Parametrizacao_Load;
        }
        private async void frmAnaliseIqviaSintetico_Parametrizacao_Load(object sender, EventArgs e)
        {
            //Pré-Events
            await getCode();

            //Events
            ConfigureButtonEvents();
        }


        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await saveAsync();
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtCodigo.ScrollBars = ScrollBars.Vertical;
        }
    }
}
