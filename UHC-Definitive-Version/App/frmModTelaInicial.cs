using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.App
{
    public partial class frmModTelaInicial : CustomForm
    {
        public frmModTelaInicial()
        {
            InitializeComponent();
            
            /** Properties **/
            ConfigureFormProperties();
            ConfigureButtonProperties();

            /** Events **/
            ConfigureFormEvents();
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultModuleScreen();

        }
        private void ConfigureFormEvents()
        {
            this.Load += frmModTelaInicial_Load;
        }
        private void frmModTelaInicial_Load(object sender, EventArgs e)
        {
            
        }
        

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnDeslogar.toDefaultRestartButton();
            btnSair.toDefaultExitButton();
        }

        
        
        
    }
}
