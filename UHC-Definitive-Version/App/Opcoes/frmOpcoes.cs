using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Opcoes.OpcoesDeDesenvolvedor;
using UHC3_Definitive_Version.App.Opcoes.PainelDeControle;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;

namespace UHC3_Definitive_Version.App.Opcoes
{
    public partial class frmOpcoes : CustomForm
    {

        /** Instance **/

        int count = 0; //Contador de teclas para abrir o menu de desenvolvedor
        public frmOpcoes()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            //Events
            ConfigureFormEvents();
        }


        private void blocks()
        {
            //Block modelo licitação

            gpbPainelDeControle.Enabled = false;
            btnOpcoesDesenvolvedor.Visible = false;

            btnPermissoes.Enabled = false;
            btnSetores.Enabled = false;
            btnUsuarios.Enabled = false;
        }
        private void allows()
        {
            if (PermissionsAllowed.subModules.Find(m => m.Name == "Painel de Controle") != null || Section.idUsuario == "0")
                gpbPainelDeControle.Enabled = true;            
            if (PermissionsAllowed.subModules.Find(m => m.Name == "Opções de Desenvolvedor") != null || Section.idUsuario == "0")
                btnOpcoesDesenvolvedor.Visible = true;

            if (PermissionsAllowed.screens.Find(m => m.Name == "Manutenção de Permissões") != null || Section.idUsuario == "0")
                btnPermissoes.Enabled = true;
            if (PermissionsAllowed.screens.Find(m => m.Name == "Manutenção de Setores") != null || Section.idUsuario == "0")
                btnSetores.Enabled = true;
            if (PermissionsAllowed.screens.Find(m => m.Name == "Manutenção de Usuários") != null || Section.idUsuario == "0")
                btnUsuarios.Enabled = true;            
            
            
        }

        private void ConfigureButtonProperties()
        {
            btnOpcoesDesenvolvedor.Visible = false;
        }

        /**Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultModuleScreen();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmOpcoes_Load;
            this.KeyDown += frmOpcoes_KeyDown;
        }
        private void frmOpcoes_Load(object sender, EventArgs e)
        {
            blocks();
            allows();
            
            if (Section.idUsuario == "0")
            {
                btnOpcoesDesenvolvedor.Visible = true;
            }



            //Events
            ConfigureButtonEvents();
        }
        private void frmOpcoes_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.D)
            {
                // Conta o número de vezes que a tecla D foi pressionada

                count++;

                if (count == 6)
                {
                    CustomNotification.defaultAlert("Ao apertar Ctrl + D por mais 3 vezes o modo desenvolvedor será acionado.");
                }

                // Verifica se a tecla D foi pressionada 9 vezes consecutivas
                if (count == 9)
                {
                    FormConfiguration.ShowOrActivateForm<frmOpcoesDesenvolvedor>();
                    count = 0;
                }
            }
        }
        /** Configure Buttons**/
        private void ConfigureButtonEvents()
        {
            btnSetores.Click += btnSetores_Click;
            btnUsuarios.Click += btnUsuarios_Click;
            btnPermissoes.Click += btnPermissoes_Click;
            btnOpcoesDesenvolvedor.Click += btnOpcoesDesenvolvedor_Click;            
        }

        

        private void btnOpcoesDesenvolvedor_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmOpcoesDesenvolvedor>();
            count = 0;

        }

        private void btnPermissoes_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmGruposPermissao>();
        }
        private void btnUsuarios_Click(object sender, EventArgs e)
        {            
            FormConfiguration.ShowOrActivateForm<frmUsuario>();
        }
        private void btnSetores_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmSetor>();
        }        
    }
}
