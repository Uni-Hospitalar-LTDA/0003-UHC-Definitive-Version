using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.Users;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    public partial class frmUsuario_BoasVindas : CustomForm
    {
        /** Instance **/
        List<Users> usuarios = new List<Users>();
        List<Sector> Setores = new List<Sector>();
        public frmUsuario_BoasVindas()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureComboBoxProperties();
            ConfigureButtonProperties();
            ConfigureLabelProperties();

            //Events
            ConfigureFormEvents();

        }

        //Async Methods 
        private async Task saveUserUhcAsync()
        {
            this.Cursor = Cursors.WaitCursor;

            if (lblDisponivel.Text != "Disponível")
            {
                CustomNotification.defaultAlert("Usuário indisponível.");
                return;
            }

            List<Users> users = new List<Users>();
            if (txtUsuarioSugerido.Text.ToString().Trim().Equals(string.Empty))
            {
                CustomNotification.defaultAlert("O campo Usuário não pode estar nulo.");
                return;
            }
            if (txtUsuarioSugerido.Text.ToString().Trim().Equals(string.Empty))
            {
                CustomNotification.defaultAlert("O campo Nome não pode estar nulo.");
                return;
            }



            users.Add(new Users
            {

                login = txtUsuarioSugerido.Text
                ,
                name = txtNomePreferencial.Text + " " + txtSobrenomePreferencial.Text
                ,
                email = txtEmailSugerido.Text
                ,
                idSector = Setores.First(s => s.Description.Equals(cbxSetor.SelectedItem.ToString())).Id
                ,
                setPassword = "1"
            });


            try
            {
                string sessaoBase = Section.Unidade;

                try
                {
                    Section.Unidade = "UNI HOSPITALAR";
                    await Users.insertAsync(users);
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError($"Erro ao inserir na undiade {Section.Unidade}: " + ex.Message);
                }
                try
                {
                    Section.Unidade = "UNI CEARÁ";
                    await Users.insertAsync(users);
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError($"Erro ao inserir na undiade {Section.Unidade}: " + ex.Message);
                }
                try
                {
                    Section.Unidade = "SP HOSPITALAR";
                    await Users.insertAsync(users);
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError($"Erro ao inserir na undiade {Section.Unidade}: " + ex.Message);
                }

                this.Cursor = Cursors.Default;


            }
            catch (Exception ex)
            {
                CustomNotification.defaultAlert(ex.Message);
                this.Cursor = Cursors.Default;
                return;
            }

        }



        // Método para gerar a assinatura de e-mail
        public void GerarAssinatura(string nome, string cargo, string telefone, string email, string usuario, bool skype = false)
        {
            // Dimensões ajustadas para garantir espaço suficiente
            int largura = 800;
            int altura = 400;

            // Criar uma nova imagem em branco
            using (Bitmap imagemAssinatura = new Bitmap(largura, altura))
            {
                // Criar um objeto Graphics para desenhar na imagem
                using (Graphics g = Graphics.FromImage(imagemAssinatura))
                {
                    // Melhorar a qualidade do desenho
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(Color.White); // Fundo branco

                    // Definir as fontes ajustadas
                    Font fonteNome = new Font("Arial", 20, FontStyle.Bold); // Aumentar o nome para destacar mais
                    Font fonteCargo = new Font("Arial", 14, FontStyle.Regular); // Cargo em tamanho menor
                    Font fonteTexto = new Font("Arial", 12, FontStyle.Regular); // Fonte regular para textos
                    Font fonteRodape = new Font("Arial", 10, FontStyle.Italic); // Rodapé mais elegante
                    Font fontePenseVerde = new Font("Arial", 11, FontStyle.Regular); // Texto "Pense Verde" em tamanho intermediário

                    // Carregar as imagens dos recursos
                    Image logo = Properties.Resources.logo_UNI_Ceara; // Certifique-se que o logo está referenciado corretamente
                    Image iconeTelefone = Properties.Resources.telefone;
                    Image iconeEmail = Properties.Resources.email;
                    Image iconeEndereco = Properties.Resources.local;
                    Image iconeSite = Properties.Resources.site;
                    Image iconeSkype = Properties.Resources.skype;
                    Image iconePenseVerde = Properties.Resources.planet_earth;

                    // Aumentar a proporção da logomarca em 300%
                    int larguraLogotipo = 350; // Aumento de 300%
                    int alturaLogotipo = 250; // Proporcional ao aumento da largura

                    // Tamanho dos ícones
                    int larguraIcones = 18; // Ícones menores para contraste com o logotipo grande
                    int alturaIcones = 18;
                    int margemEsquerdaTexto = larguraLogotipo + 50; // Alinhar os textos e ícones à direita do logotipo
                    int espacamentoVertical = 35; // Espaçamento entre as linhas

                    // Desenhar o logotipo no primeiro quadrante (90% do quadrante)
                    g.DrawImage(logo, new Rectangle(10, 10, larguraLogotipo, alturaLogotipo));

                    // Desenhar o nome ao lado do logotipo
                    g.DrawString(nome, fonteNome, Brushes.Black, new PointF(margemEsquerdaTexto, 10));

                    // Desenhar o cargo/setor
                    g.DrawString(cargo, fonteCargo, Brushes.Black, new PointF(margemEsquerdaTexto, 10 + espacamentoVertical));

                    // Desenhar o telefone
                    g.DrawImage(iconeTelefone, new Rectangle(margemEsquerdaTexto, 10 + 2 * espacamentoVertical, larguraIcones, alturaIcones));
                    g.DrawString(telefone, fonteTexto, Brushes.Black, new PointF(margemEsquerdaTexto + 30, 10 + 2 * espacamentoVertical));

                    // Desenhar o e-mail
                    g.DrawImage(iconeEmail, new Rectangle(margemEsquerdaTexto, 10 + 3 * espacamentoVertical, larguraIcones, alturaIcones));
                    g.DrawString(email.Split('@')[0] + "@uniceara.com.br", fonteTexto, Brushes.Black, new PointF(margemEsquerdaTexto + 30, 10 + 3 * espacamentoVertical));

                    // Desenhar o Skype (apenas se houver)
                    if (skype)
                    {
                        g.DrawImage(iconeSkype, new Rectangle(margemEsquerdaTexto, 10 + 4 * espacamentoVertical, larguraIcones, alturaIcones));
                        g.DrawString(usuario.Replace(".", "") + ".uni", fonteTexto, Brushes.Black, new PointF(margemEsquerdaTexto + 30, 10 + 4 * espacamentoVertical));
                    }

                    // Desenhar o endereço
                    g.DrawImage(iconeEndereco, new Rectangle(margemEsquerdaTexto, 10 + 5 * espacamentoVertical, larguraIcones, alturaIcones));
                    g.DrawString("Rua Francisco José Albuquerque Pereira, 1085, Cajazeiras", fonteTexto, Brushes.Black, new PointF(margemEsquerdaTexto + 30, 10 + 5 * espacamentoVertical));
                    g.DrawString("Fortaleza-CE 60.864-520", fonteTexto, Brushes.Black, new PointF(margemEsquerdaTexto + 30, 10 + 5 * espacamentoVertical + 20));

                    // Desenhar o site
                    g.DrawImage(iconeSite, new Rectangle(margemEsquerdaTexto, 10 + 6 * espacamentoVertical, larguraIcones, alturaIcones));
                    g.DrawString("www.unihospitalar.com.br", fonteTexto, Brushes.Black, new PointF(margemEsquerdaTexto + 30, 10 + 6 * espacamentoVertical));

                    // Rodapé de privacidade
                    string rodape = "Mensagens recebidas após a jornada de trabalho não precisam ser respondidas imediatamente.\n" +
                                    "Responda dentro de sua jornada de trabalho. Comunicação sujeita a sigilo. " +
                                    "Sua recepção ou utilização indevida está sujeita às penalidades legais.";
                    g.DrawString(rodape, fonteRodape, Brushes.Gray, new RectangleF(10, 300, largura - 20, 40));

                    // Desenhar o "Pense Verde"
                    g.DrawImage(iconePenseVerde, new Rectangle(10, 350, 24, 24));
                    string textoPenseVerde = "Antes de imprimir pense em sua responsabilidade com o meio ambiente";
                    g.DrawString(textoPenseVerde, fontePenseVerde, Brushes.Green, new PointF(40, 355));

                    // Criar o SaveFileDialog para permitir o usuário escolher o local para salvar a imagem
                    using (SaveFileDialog salvarDialog = new SaveFileDialog())
                    {
                        salvarDialog.Filter = "Imagem PNG|*.png";
                        salvarDialog.Title = "Salvar a assinatura como imagem";
                        salvarDialog.FileName = "assinatura-email.png"; // Nome padrão para o arquivo

                        // Mostrar o diálogo de salvar e verificar se o usuário escolheu um caminho
                        if (salvarDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Salvar a imagem no caminho escolhido pelo usuário
                            imagemAssinatura.Save(salvarDialog.FileName, ImageFormat.Png);

                            // Exibir mensagem de sucesso
                            MessageBox.Show("Assinatura de e-mail salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }











        private string formarUsuarioBase(string nome, string sobrenome)
        {
            return string.Concat(nome.substituirCaracteresEspeciais(),
                string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(sobrenome) ? "" : "."
                , sobrenome.substituirCaracteresEspeciais());
        }
        private void verificarDisponibilidade(string usuario)
        {

            var u = usuarios.Where(x => x.login == usuario).FirstOrDefault();
            if (u == null)
            {
                lblDisponivel.Text = "Disponível";
                lblDisponivel.ForeColor = Color.DarkSeaGreen; // Cor disponível
                lblDisponivel.Visible = true;
            }
            else
            {
                lblDisponivel.Text = "Indisponível";
                lblDisponivel.ForeColor = Color.IndianRed; // Cor indisponível
                lblDisponivel.Visible = true;
            }

        }
        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmUsuario_BoasVindas_Load;
        }
        private async void frmUsuario_BoasVindas_Load(object sender, EventArgs e)
        {
            //Pré load events 
            usuarios = await Users.getAllToListAsync();

            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
        }


        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtCargo.MaxLength = 100;
            txtSobrenomePreferencial.MaxLength = 100;
            txtNomePreferencial.MaxLength = 50;
            txtUsuarioSugerido.MaxLength = 100;
        }
        private void ConfigureTextBoxEvents()
        {
            txtNomePreferencial.LostFocus += txt_LostFocus;
            txtSobrenomePreferencial.LostFocus += txt_LostFocus;
            txtNomePreferencial.KeyPress += txt_KeyPress;
            txtSobrenomePreferencial.KeyPress += txt_KeyPress;
        }
        private void txt_LostFocus(object sender, EventArgs e)
        {
            string usuario = formarUsuarioBase(txtNomePreferencial.Text, txtSobrenomePreferencial.Text);
            txtEmailSugerido.Text =
                usuario + "@dominio.com.br";
            txtUsuarioSugerido.Text = usuario;
            verificarDisponibilidade(usuario);
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se o caractere pressionado é um espaço ou um número
            if (e.KeyChar == (char)Keys.Space || char.IsDigit(e.KeyChar))
            {
                // Cancela o evento se for um espaço ou número
                e.Handled = true;
            }
        }

        /** ComboBox configuration **/
        private async void ConfigureComboBoxProperties()
        {
            cbxSetor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            Setores = await Sector.getAllToListAsync();
            foreach (var setor in Setores)
            {
                cbxSetor.Items.Add(setor.Description);
            }
        }

        /** Label configuration **/
        private void ConfigureLabelProperties()
        {
            lblDisponivel.Visible = false;
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultQuestionCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnCriarUsusarioUhcPe.Click += btnCriarUsusarioUhcPe_Click;
        }

        private void btnCriarUsusarioUhcPe_Click(object sender, EventArgs e)
        {
            //if (    chkUnidade_SpHospitalar.Checked 
            //    ||  chkUnidade_UniCeara.Checked 
            //    || chkUnidade_UniHospitalar.Checked)
            //{
            //    await saveUserUhcAsync();
            //}

            GerarAssinatura($"{txtNomePreferencial.Text} {txtSobrenomePreferencial.Text}"
                ,txtCargo.Text
                ,txtTelefone.Text
                ,txtEmailSugerido.Text
                ,txtUsuarioSugerido.Text
                ,true
                );


        }
    }
}
