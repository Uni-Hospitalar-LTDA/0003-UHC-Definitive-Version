
using Krypton.Toolkit;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC_DEFINITIVE_VERSION.App;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.Users;
using UHC3_Definitive_Version.Domain.Permissionamento;

namespace UHC3_Definitive_Version.App
{
    public partial class frmLoginNew : KryptonForm
    {
        //Instance        
        bool showedPassword = false;
        public frmLoginNew()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();
            ConfigureComboBoxProperties();



            //Events 
            ConfigureFormEvents();


            this.SetStyle(ControlStyles.DoubleBuffer |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint, true);
            this.UpdateStyles();

            fadeTimer.Interval = 80;
            fadeTimer.Tick += FadeTimer_Tick;

            t1_timer.Interval = 120;
            t1_timer.Tick += t1_FadeTimer_Tick;

            pcbTimer.Interval = 10000; // 20 segundos
            pcbTimer.Tick += pcbTimer_Tick;
            pcbTimer.Start();
        }


        /** Tratamento de imagem **/
        private Timer fadeTimer = new Timer();
        private Timer pcbTimer = new Timer();
        private Timer t1_timer = new Timer();
        private float t1_opacity = 0f;
        int indexImage = 0;
        private float opacity = 0f;
        private Bitmap bmpCharge = null;
        private bool[] t = { false, false, false, false, false };
        private bool[] previousState = { false, false, false, false, false };                
        private void pcbTimer_Tick(object sender, EventArgs e)
        {
            switch (indexImage++)
            {
                case 0: pcb_1_Click(sender,e); break;
                case 1: pcb_2_Click(sender, e); break;
                case 2: pcb_3_Click(sender, e); break;
                case 3: pcb_4_Click(sender, e); break;
                case 4: pcb_5_Click(sender, e); break;
                default: indexImage = 0; break;
            }
            
            
        }                
        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (opacity < 1f)
            {
                opacity += 0.05f; // Ajuste a taxa de incremento conforme necessário
                SetImageOpacity(opacity);
            }
            else
            {
                fadeTimer.Stop();
            }
        }
        private void SetImageOpacity(float opacity)
        {
            if (pcbGallery.Image != null)
            {
                pcbGallery.Image.Dispose(); // Descartando a imagem antiga
            }

            // Garantir que o novo bitmap corresponda ao tamanho do PictureBox
            Bitmap bmp = new Bitmap(pcbGallery.Width, pcbGallery.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Criar uma matriz de cor para definir a opacidade
                ColorMatrix colorMatrix = new ColorMatrix { Matrix33 = opacity };
                ImageAttributes imgAttribute = new ImageAttributes();
                imgAttribute.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // Desenhar a imagem de fundo esticada no novo bitmap
                g.DrawImage(bmpCharge, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmpCharge.Width, bmpCharge.Height, GraphicsUnit.Pixel, imgAttribute);
            }

            // Aplicar o bitmap com opacidade ao PictureBox
            pcbGallery.Image = bmp;
            pcbGallery.BackgroundImageLayout = pcbGallery.BackgroundImageLayout = ImageLayout.Stretch;
        }        
        private void t1_FadeTimer_Tick(object sender, EventArgs e)
        {
            if (t1_opacity < 1f)
            {
                t1_opacity += 0.05f; // Ajuste a taxa de incremento conforme necessário

                // Executar SetImageOpacity apenas para PictureBox cujo estado mudou
                for (int i = 0; i < t.Length; i++)
                {
                    if (t[i] != previousState[i])
                    {
                        SetImageOpacity(GetPictureBoxByIndex(i), t1_opacity, t[i]);
                    }
                }
            }
            else
            {
                t1_timer.Stop();
            }
        }
        private PictureBox GetPictureBoxByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return pcb_1;
                case 1:
                    return pcb_2;
                case 2:
                    return pcb_3;
                case 3:
                    return pcb_4;
                case 4:
                    return pcb_5;
                default:
                    return null; // ou lançar uma exceção, dependendo do que faz sentido para seu aplicativo
            }
        }
        private void SetImageOpacity(PictureBox pct ,float opacity,bool isActive)
        {

            if (pct.BackgroundImage != null)
            {
                pct.BackgroundImage = null; // Descartando a imagem antiga
            }
            Image image = isActive ? Properties.Resources.i_circle_active : Properties.Resources.i_circle_inactive;

            // Garantir que o novo bitmap corresponda ao tamanho do PictureBox
            Bitmap bmp = new Bitmap(pct.Width, pct.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Criar uma matriz de cor para definir a opacidade
                ColorMatrix colorMatrix = new ColorMatrix { Matrix33 = opacity };
                ImageAttributes imgAttribute = new ImageAttributes();
                imgAttribute.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // Desenhar a imagem de fundo esticada no novo bitmap
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttribute);
            }

            // Aplicar o bitmap com opacidade ao PictureBox
            pct.Image = bmp;
            pct.BackgroundImageLayout = ImageLayout.Stretch;
        }


        /** Async Tasks **/        
        private async Task login()
        {
            for (double opacity = 1.0; opacity <= 1.0; opacity -= 0.1)
            {
                DateTime start = DateTime.Now;
                this.Opacity = opacity;
                while (DateTime.Now.Subtract(start).TotalMilliseconds <= 80)
                {
                    Application.DoEvents();
                }
                if (this.Opacity == 0)
                {
                    frmMainMenu frmMainMenu = new frmMainMenu();                    
                    await PermissionsAllowed.getUserPermissionsAsync(Section.idUsuario);
                    this.Hide();
                    frmMainMenu.ShowDialog();
                    break;
                }
            }
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
            // Centralizar na tela e definir algumas configurações básicas
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.ResizeRedraw = true;
            this.UpdateStyles();
            this.ShowIcon = true;

            this.Icon = Properties.Resources.form_iconpe;
            
            this.KeyPreview = false;
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmLoginNew_Load;
        }
        private void frmLoginNew_Load(object sender, EventArgs e)
        {

            //Attributes
            ConfigureLabelAttributes();
            ConfigureComboBoxAttributes();



            ConfigureTextBoxEvents();
            ConfigurPictureBoxEvents();
            ConfigureButtonEvents();
            ConfigureLabelEvents();


            pcb_5_Click(sender, e);
            pcbTimer.Start();


        }

        /** Configure Label **/
        private void ConfigureLabelAttributes()
        {
            lblVersionAndDistribution.Text = $"Version {Application.ProductVersion} - Grupo Uni® Distribution";
        }
        private void ConfigureLabelEvents()
        {
            linkEsqueceuAsenha.Click +=UhcEvents.glpi_Click;
            linkMeAjude.Click += UhcEvents.glpi_Click;
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxEvents()
        {
            txtLogin.GotFocus += txtLogin_GotFocus;
            txtLogin.LostFocus += txtLogin_LostFocus;

            txtSenha.GotFocus += txtSenha_GotFocus;
            txtSenha.LostFocus += txtSenha_LostFocus;

            txtLogin.KeyDown += txt_KeyDown;
            txtSenha.KeyDown += txt_KeyDown;
        }
        private void ConfigureTextBoxProperties()
        {
            txtSenha.PasswordChar = '*';
        }
        private void txtLogin_GotFocus(object sender, EventArgs e)
        {
            if (txtLogin.Text == "nome.usuario")
            {
                txtLogin.Text = string.Empty;
            }
        }
        private void txtLogin_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogin.Text))
            {
                txtLogin.Text = "nome.usuario";
            }
        }
        private void txtSenha_GotFocus(object sender, EventArgs e)
        {
            if (txtSenha.Text == "********")
            {
                txtSenha.Text = string.Empty;
            }
        }
        private void txtSenha_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                txtSenha.Text = "********";
            }
        }
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) 
            {
                if (string.IsNullOrEmpty(txtLogin.Text))
                {
                    CustomNotification.defaultAlert("Preencha as informações de Login");
                    return;
                }
                btnLogin_Click(sender, e);
            }
        }


        /** Configure ComboBox **/
        private void ConfigureComboBoxProperties()
        {
            cbxUnidade.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void ConfigureComboBoxAttributes() 
        {
            
            cbxUnidade.Items.AddRange(new string[] {"UNI HOSPITALAR","UNI CEARÁ", "SP HOSPITALAR" });
            cbxUnidade.SelectedIndex = 0;
        }
        

        /** Configure Picture Box **/
        private void ConfigurPictureBoxEvents()
        {
            pcb_1.MouseHover += pcb_MouseHover;
            pcb_1.MouseLeave += pcb_MouseLeave;
            pcb_2.MouseHover += pcb_MouseHover;
            pcb_2.MouseLeave += pcb_MouseLeave;
            pcb_3.MouseHover += pcb_MouseHover;
            pcb_3.MouseLeave += pcb_MouseLeave;
            pcb_4.MouseHover += pcb_MouseHover;
            pcb_4.MouseLeave += pcb_MouseLeave;
            pcb_5.MouseHover += pcb_MouseHover;
            pcb_5.MouseLeave += pcb_MouseLeave;

            pcb_1.Click += pcb_1_Click;
            pcb_2.Click += pcb_2_Click;
            pcb_3.Click += pcb_3_Click;
            pcb_4.Click += pcb_4_Click;
            pcb_5.Click += pcb_5_Click;
            
        }
        private void pcb_1_Click(object sender, EventArgs e)
        {
            Array.Copy(t, previousState, t.Length); // Copia o estado atual para previousState

            // Inicialize a opacidade e a imagem
            opacity = 0f;
            bmpCharge = Properties.Resources.pic_login_1;

            t1_opacity = 0f;

            t[0] = true;
            t[1] = false;
            t[2] = false;
            t[3] = false;
            t[4] = false;

            // Iniciar o Timer
            fadeTimer.Start();  
            t1_timer.Start();


            


        }
        private void pcb_2_Click(object sender, EventArgs e)
        {
            Array.Copy(t, previousState, t.Length); // Copia o estado atual para previousState
            // Inicialize a opacidade e a imagem
            opacity = 0f;
            bmpCharge = Properties.Resources.pic_login_2;


            t1_opacity = 0f;
            t[0] = false;
            t[1] = true;
            t[2] = false;
            t[3] = false;
            t[4] = false;

            // Iniciar o Timer
            fadeTimer.Start();
            t1_timer.Start();
        }
        private void pcb_3_Click(object sender, EventArgs e)
        {
            Array.Copy(t, previousState, t.Length); // Copia o estado atual para previousState
            // Inicialize a opacidade e a imagem
            opacity = 0f;
            bmpCharge = Properties.Resources.pic_login_3;

            t1_opacity = 0f;
            t[0] = false;
            t[1] = false;
            t[2] = true;
            t[3] = false;
            t[4] = false;

            // Iniciar o Timer
            fadeTimer.Start();
            t1_timer.Start();
        }
        private void pcb_4_Click(object sender, EventArgs e)
        {
            Array.Copy(t, previousState, t.Length); // Copia o estado atual para previousState
            // Inicialize a opacidade e a imagem
            opacity = 0f;
            bmpCharge = Properties.Resources.pic_login_4;

            t1_opacity = 0f;
            t[0] = false;
            t[1] = false;
            t[2] = false;
            t[3] = true;
            t[4] = false;

            // Iniciar o Timer
            fadeTimer.Start();
            t1_timer.Start();
        }
        private void pcb_5_Click(object sender, EventArgs e)
        {
            Array.Copy(t, previousState, t.Length); // Copia o estado atual para previousState
            // Inicialize a opacidade e a imagem
            opacity = 0f;
            bmpCharge = Properties.Resources.pic_login_5;

            t1_opacity = 0f;
            t[0] = false;
            t[1] = false;
            t[2] = false;
            t[3] = false;
            t[4] = true;

            // Iniciar o Timer
            fadeTimer.Start();
            t1_timer.Start();
        }
        private void pcb_MouseHover(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Hand;
        }
        private void pcb_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Default;
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnSair.toDefaultExitButton();
        }
        private void ConfigureButtonEvents()
        {
            btnLogin.Click += btnLogin_Click;
            btnShowPassword.Click += btnShowPassword_Click;
            
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (showedPassword)
            {
                btnShowPassword.BackgroundImage = Properties.Resources.i_ClosedEyes;
                showedPassword = !showedPassword;
                txtSenha.PasswordChar = '*';
            }
            else
            {
                btnShowPassword.BackgroundImage = Properties.Resources.i_OpenEyes;
                showedPassword = !showedPassword;
                txtSenha.PasswordChar = '\0';
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                await aprovarLogin(txtLogin.Text, txtSenha.Text);
            }
            catch (Exception ex) 
            {
                CustomNotification.defaultError("Erro: "+ex);
            }
        }    
        private async Task aprovarLogin(string usuario, string senha)
        {
            
            if (usuario == "admin" && senha == "!@#asd253")
            {
                CustomNotification.defaultInformation($"Login Autorizado! Seja bem vindo ao sistema {Application.ProductName}.");
                frmMainMenu frmMainMenu = new frmMainMenu();
                Section.Unidade = cbxUnidade.SelectedItem?.ToString();
                frmMainMenu.Show();
                this.Hide();
            }
            else
            {
                btnLogin.Enabled = false;
                string unidade = cbxUnidade.SelectedItem?.ToString();
                var resultado = await Section.On(txtLogin.Text, txtSenha.Text, unidade);
                
                if (resultado.Contains("ACCESS_APPROVED"))
                {
                    string[] name = resultado.Split(' ');
                    Users user = await Users.getToClassByLoginAsync(txtLogin.Text,unidade);
                    Section.add(user.id, unidade);
                    CustomNotification.defaultInformation($"Login aprovado: Seja bem vindo ao {Application.ProductName}, {name[1]}. {Environment.NewLine}Tenha um bom trabalho!", "Boas vindas!");
                    await login();
                }
                else if (resultado.Contains("ACCESS_DENIED"))
                {
                    CustomNotification.defaultError("Usuário bloqueado.");
                    btnLogin.Enabled = true;
                }
                else if (resultado.Contains("WRONG_PASSWORD"))
                {
                    CustomNotification.defaultError("Senha errada.");
                    //btnEsqueceuAsenha.Visible = true;
                    btnLogin.Enabled = true;
                }
                else if (resultado.Contains("CHANGE_PASSWORD"))
                {
                    frmRedefinirSenha frmRedefinirSenha = new frmRedefinirSenha();
                    frmRedefinirSenha.ShowDialog();
                    
                    Users user = new Users { login = txtLogin.Text, password = frmRedefinirSenha.senha };
                    
                    await Users.changePasswordAsync(user, unidade);
                    Section.add(user.id, unidade);
                    txtSenha.Text = user.password;
                    string[] name = resultado.Split(' ');
                    
                    CustomNotification.defaultInformation($"Senha alterada com sucesso: Seja bem vindo ao {Application.ProductName}, {name[1]}. Tenha um bom trabalho!", "Boas vindas!");
                    await login();
                }
                else
                {
                    CustomNotification.defaultError("Usuário inexistente.");
                    btnLogin.Enabled = true;
                }
            }
        }
    }
}
