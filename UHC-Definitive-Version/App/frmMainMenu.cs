using UHC3_Definitive_Version.App;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;
using System;
using System.Windows.Forms;

namespace UHC3_Definitive_Version
{
    public partial class frmMainMenu : CustomForm
    {
        public frmMainMenu()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigurePanelProperties();
            ConfigureButtonProperties();
            ConfigurePictureBoxProperties();
            ConfigureFormEvents();
        }



        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMainMenu();
            //pcbLogo.Visible = false;
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmMainMenu_Load;
        }
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            /** Initialize **/
            ConfigurePictureBoxAttributes();

            /** Attributes **/
            blocks();
            allows();

            /** Events **/
            ConfigureButtonEvents();
        }

        /** Screen Permissions Methods **/
        private void blocks()
        {
            //Block modelo licitação
            
            //btnModCobranca.Enabled = false;           
            //btnOpcoes.Enabled = false;
        }
        private void allows()
        {            
            //if (PermissionsAllowed.modules.Find(m => m.Name == "Módulo de Cobrança") != null)
            //    btnModCobranca.Enabled = true;            
            //if (PermissionsAllowed.modules.Find(m => m.Name == "Opções do Sistema") != null || Session.idUsuario == "0")
            //    btnOpcoes.Enabled = true;            
        }
        
        /** Configure PictureBox **/
        private void ConfigurePictureBoxProperties()
        {
            pcbLogo.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ConfigurePictureBoxAttributes()
        {            
            if (Session.Unidade == "UNI HOSPITALAR")
            {
                if (DateTime.Now.Month != 12)                
                    pcbLogo.Image = Properties.Resources.logo_UNI_Hospitalar;
                else
                    pcbLogo.Image = Properties.Resources.logo_UNI_HospitalarNatal;
            }
            else if (Session.Unidade == "UNI CEARÁ")
            {
                if (DateTime.Now.Month != 12)
                    pcbLogo.Image = Properties.Resources.logo_UNI_Ceara;
                else
                    pcbLogo.Image = Properties.Resources.logo_UNI_CearaNatal;
            }
            else if (Session.Unidade == "SP HOSPITALAR")
            {
                if (DateTime.Now.Month != 12)
                    pcbLogo.Image = Properties.Resources.logo_SP_Hospitalar;
                else
                    pcbLogo.Image = Properties.Resources.logo_SP_HospitalarNatal;
            }
            pcbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {                                    
            //btnModCobranca.Enabled = true;
                        
        }
        private void ConfigureButtonEvents()
        {
            //btnModCobranca.Click += btnModCobranca_Click;           
            btnOpcoes.Click += btnOpcoes_Click;
            btnSair.Click += btnSair_Click;
        }   
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Restart();            
        }
        private void btnOpcoes_Click(object sender, EventArgs e)
        {
            //FormConfiguration.ShowOrActivateForm<frmOpcoes>();
        }

        
        /** Configure Panel **/
        private void ConfigurePanelProperties()
        {
            
        }        
    }
}
