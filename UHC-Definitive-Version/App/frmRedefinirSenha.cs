using _0009_Integra_Cob.Configuration;
using _0009_Integra_Cob.Customization;
using Krypton.Toolkit;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace _0009_Integra_Cob.App
{
    public partial class frmRedefinirSenha : CustomForm
    {                

        /** Instance **/
        internal string senha { get; set; }



        public frmRedefinirSenha()
        {
            InitializeComponent();

            //Properties 
            ConfigureFormProperties();
            ConfigureTextBoxProperties();

            //Events
            ConfigureFormEvents();

            
        }


        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmRedefinirSenha_Load; 
        }
        private void frmRedefinirSenha_Load(object sender, EventArgs e)
        {
            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
        }



        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            // Define a cor inicial dos textos como cinza
            txtNovaSenha.ForeColor = Color.Gray; // Mudança para Color.Gray
            txtRepetirSenha.ForeColor = Color.Gray; // Mudança para Color.Gray

            // Configura a descrição inicial
            txtNovaSenha.Text = "Nova Senha";
            txtRepetirSenha.Text = "Repetir Senha";
        }

        private void ConfigureTextBoxEvents()
        {
            // Eventos KeyDown
            txtNovaSenha.KeyDown += Logar_ComEnter;
            txtRepetirSenha.KeyDown += Logar_ComEnter;

            // Eventos Enter e Leave para manipulação do texto de descrição
            txtNovaSenha.Enter += TextBox_Enter;
            txtRepetirSenha.Enter += TextBox_Enter;
            txtNovaSenha.Leave += TextBox_Leave;
            txtRepetirSenha.Leave += TextBox_Leave;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            KryptonTextBox tb = sender as KryptonTextBox;
            if (tb != null)
            {
                tb.Text = string.Empty;
                tb.ForeColor = Color.Black; // Mudança para cor preta ao entrar
                tb.PasswordChar = '*'; // Define o caractere de senha
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            KryptonTextBox tb = sender as KryptonTextBox;
            if (tb != null && tb.Text == string.Empty)
            {
                // Retorna para as configurações iniciais se não tiver texto
                tb.ForeColor = Color.Gray; // Cor cinza ao sair
                tb.PasswordChar = '\0'; // Remove o caractere de senha
                tb.Text = tb == txtNovaSenha ? "Nova Senha" : "Repetir Senha";
            }
        }

        private void Logar_ComEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               btnConfirmar_Click(sender, e);
            }
        }


        /** Button Configuration **/
        private void ConfigureButtonEvents()
        {
            btnConfirmar.Click += btnConfirmar_Click; ;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtRepetirSenha.Text == txtNovaSenha.Text)
            {
                senha = txtNovaSenha.Text;
                this.Close();
            }
            else
            {
                CustomNotification.defaultError("As senhas não conferem.");
            }
        }
    }
}
