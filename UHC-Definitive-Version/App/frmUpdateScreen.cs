using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Properties;

namespace UHC_DEFINITIVE_VERSION.App
{
    public partial class frmUpdateScreen : CustomForm
    {
        public frmUpdateScreen()
        {
            InitializeComponent();


            //Properties
            ConfigureFormProperties();
            ConfigurePictureBoxProperties();

            //Events
            ConfigureFormEvents();

        }

        /** async Tasks **/
        private async Task checkUpdate()
        {
            var versao = await WebSquirrelUpdate.CheckVersionAsync();
            progressBar.Value = 10;

            if (string.IsNullOrEmpty(versao) || versao.ToString().ToLower().Contains("igual"))
            {
                this.Hide();
                FormConfiguration.ShowOrActivateForm<frmLoginNew>();
            }
            else
            {
                this.Opacity = 100;
                progressBar.Value = 30;
                var tag = await WebSquirrelUpdate.getWebVersionAsync();
                try
                {
                    if (versao.ToString().ToLower().Contains("menor"))
                    {
                        label1.Text = $"Atualização disponível ({tag})";
                        await Task.Delay(1000);
                        label1.Text = $"Atualizando...";
                        progressBar.Value = 80;
                        await WebSquirrelUpdate.UpdateAppAsync(tag);
                    }
                    else
                    {
                        await WebSquirrelUpdate.rollbackAsync(tag);
                    }
                }
                catch (Exception)
                {
                    this.Hide();
                    FormConfiguration.ShowOrActivateForm<frmLoginNew>();
                }
                finally
                {
                    label1.Text = $"{Application.ProductName} atualizado.";
                    progressBar.Value = 100;
                    CustomNotification.defaultInformation();
                    WebSquirrelUpdate.RestartApplication();
                    this.Hide();
                    FormConfiguration.ShowOrActivateForm<frmLoginNew>();
                }

            }
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.Opacity = 0;
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmUpdateScreen_Load;
        }

        private async void frmUpdateScreen_Load(object sender, EventArgs e)
        {
            //Pre events
            ConfigurePictureBoxAttributes();

            await checkUpdate();
        }


        /** PictureBox Configuration **/
        private void ConfigurePictureBoxAttributes()
        {
            pcbGears.Image = Resources.gear;
        }
        private void ConfigurePictureBoxProperties()
        {
            pcbGears.Dock = System.Windows.Forms.DockStyle.Fill;
            pcbGears.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

    }
}
