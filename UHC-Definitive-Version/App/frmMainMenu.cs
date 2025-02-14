using System;
using System.Linq;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.ModAdmistrativo;
using UHC3_Definitive_Version.App.ModContabilFiscal;
using UHC3_Definitive_Version.App.ModFinanceiro;
using UHC3_Definitive_Version.App.ModGerencial;
using UHC3_Definitive_Version.App.ModLogistica;
using UHC3_Definitive_Version.App.ModVendas;
using UHC3_Definitive_Version.App.Opcoes;
using UHC3_Definitive_Version.App;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;
using UHC3_Definitive_Version.Domain.Entities.Users;

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
            pcbLogo_Click(null, null);
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

            /** Attributes **/
            if (Section.idUsuario != "0")
            {
                blocks();
                allows();
            }

            /** Events **/
            ConfigureButtonEvents();
            ConfigureLabelEvents();
        }

        /** Screen Permissions Methods **/
        private void blocks()
        {
            btnModAdministrativo.Enabled = false;
            btnModContabilFiscal.Enabled = false;
            btnModFinanceiro.Enabled = false;
            btnModGerencial.Enabled = false;
            btnModLicitacao.Enabled = false;
            btnModLogistica.Enabled = false;
            btnModVendas.Enabled = false;
            btnOpcoes.Enabled = false;
        }

        private void allows()
        {
            if (PermissionsAllowed.modules?.Find(m => m.Name == "Administrativo") != null)
                btnModAdministrativo.Enabled = true;
            if (PermissionsAllowed.modules?.Find(m => m.Name.Contains("Fiscal")) != null)
                btnModContabilFiscal.Enabled = true;
            if (PermissionsAllowed.modules?.Find(m => m.Name == "Financeiro") != null)
                btnModFinanceiro.Enabled = true;
            if (PermissionsAllowed.modules?.Find(m => m.Name == "Gerencial") != null)
                btnModGerencial.Enabled = true;
            if (PermissionsAllowed.modules?.Find(m => m.Name == "Licitação") != null)
                btnModLicitacao.Enabled = true;
            if (PermissionsAllowed.modules?.Find(m => m.Name == "Logística") != null)
                btnModLogistica.Enabled = true;
            if (PermissionsAllowed.modules?.Find(m => m.Name == "Vendas") != null)
                btnModVendas.Enabled = true;
            if (PermissionsAllowed.modules?.Find(m => m.Name == "Opções") != null)
                btnOpcoes.Enabled = true;
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
                pcbLogo.Image = DateTime.Now.Month != 12
                    ? Properties.Resources.logo_UNI_Hospitalar
                    : Properties.Resources.logo_UNI_HospitalarNatal;
            }
            else if (Section.Unidade == "UNI CEARÁ")
            {
                pcbLogo.Image = DateTime.Now.Month != 12
                    ? Properties.Resources.logo_UNI_Ceara
                    : Properties.Resources.logo_UNI_CearaNatal;
            }
            else if (Section.Unidade == "SP HOSPITALAR")
            {
                pcbLogo.Image = DateTime.Now.Month != 12
                    ? Properties.Resources.logo_SP_Hospitalar
                    : Properties.Resources.logo_SP_HospitalarNatal;
            }

            pcbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            // btnModCobranca.Enabled = true;
        }

        private void ConfigureButtonEvents()
        {
            // Restaurar os eventos originais de clique dos botões
            btnModAdministrativo.Click += btnModAdministrativo_Click;
            btnModContabilFiscal.Click += btnModContabilFiscal_Click;
            btnModFinanceiro.Click += btnModFinanceiro_Click;
            btnModGerencial.Click += btnModGerencial_Click;
            btnModLicitacao.Click += btnModLicitacao_Click;
            btnModLogistica.Click += btnModLogistica_Click;
            btnModVendas.Click += btnModVendas_Click;
            pcbLogo.Click += pcbLogo_Click;
            btnOpcoes.Click += btnOpcoes_Click;
        }

        /** Singleton Pattern to avoid multiple instances of forms **/
        private void btnModAdministrativo_Click(object sender, EventArgs e)
        {
            ShowOrActivateFormInPanel<frmModAdministrativo>();
        }

        private void btnModVendas_Click(object sender, EventArgs e)
        {
            ShowOrActivateFormInPanel<frmModVendas>();
        }

        private void btnModLogistica_Click(object sender, EventArgs e)
        {
            ShowOrActivateFormInPanel<frmModLogistica>();
        }

        private void btnModLicitacao_Click(object sender, EventArgs e)
        {
            ShowOrActivateFormInPanel<frmModLicitacao>();
        }

        private void btnModGerencial_Click(object sender, EventArgs e)
        {
            ShowOrActivateFormInPanel<frmModGerencial>();
        }

        private void btnModFinanceiro_Click(object sender, EventArgs e)
        {
            ShowOrActivateFormInPanel<frmModFinanceiro>();
        }

        private void btnModContabilFiscal_Click(object sender, EventArgs e)
        {
            ShowOrActivateFormInPanel<frmModContabilFiscal>();
        }

        // Generic method to prevent multiple form instances
        private void ShowOrActivateFormInPanel<T>() where T : Form, new()
        {
            var existingForm = panel.Controls.OfType<T>().FirstOrDefault();
            if (existingForm == null)
            {
                var form = new T
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                panel.Controls.Add(form);
                form.Show();
                form.BringToFront();
            }
            else
            {
                existingForm.BringToFront();
            }
        }

        private void pcbLogo_Click(object sender, EventArgs e)
        {
            ShowOrActivateFormInPanel<frmModTelaInicial>();
        }

        private void btnOpcoes_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmOpcoes>();
        }

        /** Configure Label **/
        private async void ConfigureLabelAttributes()
        {
            Users user = await Users.getToClassByIdAsync(Section.idUsuario);
            lblSessao.Text = $"Sessão: {user.name}";
            lblVersao.Text = $"v{Application.ProductVersion}";
            lblEmpresa.Text = Section.Empresa;
        }
            private void ConfigureLabelEvents()
        {
            lblOQueHaDeNovo.Click += lblOQueHaDeNovo_Click;
            lblSair.Click += lblSair_Click;
            lDeslogar.Click += lDeslogar_Click;
        }
        private void lblOQueHaDeNovo_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmUpdateInfo>();
        }

        private void lDeslogar_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert("Deseja deslogar do sistema?") == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert("Deseja sair do sistema?") == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        /** Configure Panel **/
        private void ConfigurePanelProperties()
        {
        }
       
        
    }
}
