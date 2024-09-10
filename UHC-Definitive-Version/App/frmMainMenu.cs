using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.Domain.Entities.Users;
using Section = UHC3_Definitive_Version.Configuration.Section;
using UHC3_Definitive_Version.App.ModAdmistrativo;
using UHC3_Definitive_Version.App;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version
{
    public partial class frmMainMenu : CustomForm
    {
        public frmMainMenu()
        {
            InitializeComponent();

            /** Properties **/
            ConfigureFormProperties();
            ConfigurePanelProperties();
            ConfigureButtonProperties();
            ConfigurePictureBoxProperties();

            /** Events **/
            ConfigureFormEvents();
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMainMenu();
            this.WindowState = FormWindowState.Maximized;
            pcbLogo_Click(null,null);

            
            //pcbLogo.Visible = false;
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmMainMenu_Load;
        }
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            /** Initialize **/
            ConfigureLabelAttributes();
            ConfigurePictureBoxAttributes();
            Task.Factory.StartNew(() => Section.carregar_Dependencias());

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
            //if (PermissionsAllowed.modules.Find(m => m.Name == "Opções do Sistema") != null || Section.idUsuario == "0")
            //    btnOpcoes.Enabled = true;            
        }
        
        /** Configure PictureBox **/
        private void ConfigurePictureBoxProperties()
        {
            pcbLogo.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ConfigurePictureBoxAttributes()
        {            
            if (Section.Unidade == "UNI HOSPITALAR")
            {
                if (DateTime.Now.Month != 12)                
                    pcbLogo.Image = Properties.Resources.logo_UNI_Hospitalar;
                else
                    pcbLogo.Image = Properties.Resources.logo_UNI_HospitalarNatal;
            }
            else if (Section.Unidade == "UNI CEARÁ")
            {
                if (DateTime.Now.Month != 12)
                    pcbLogo.Image = Properties.Resources.logo_UNI_Ceara;
                else
                    pcbLogo.Image = Properties.Resources.logo_UNI_CearaNatal;
            }
            else if (Section.Unidade == "SP HOSPITALAR")
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
            btnModAdministrativo.Click += btnModAdministrativo_Click;
            pcbLogo.Click += pcbLogo_Click;
            btnOpcoes.Click += btnOpcoes_Click;
            
        }

        private void pcbLogo_Click(object sender, EventArgs e)
        {                
            FormConfiguration.ShowOrActivateFormInPanel<frmModTelaInicial>(panel, "");
        }

        private void btnModAdministrativo_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateFormInPanel<frmModAdministrativo>(panel, "");
        }

        
        private void btnOpcoes_Click(object sender, EventArgs e)
        {
            //FormConfiguration.ShowOrActivateForm<frmOpcoes>();
        }

        /** Configure Label **/
        private async void ConfigureLabelAttributes()
        {
            Users user = new Users();
            user = await Users.getToClassByIdAsync(Section.idUsuario);

            lblSessao.Text = $"Sessão: {user.name}";
            lblEmpresa.Text = Section.Empresa;
        }
        
        /** Configure Panel **/
        private void ConfigurePanelProperties()
        {
            
        }

       
    }
}
