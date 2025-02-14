using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Configuration.Update;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC_DEFINITIVE_VERSION.App
{
    public partial class frmUpdateScreen : CustomForm
    {
        public frmUpdateScreen()
        {
            InitializeComponent();
            this.Opacity = 0;
            //Properties 
            ConfigurePictureBoxProperties();
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            
            //Events
            ConfigureFormEvents();
        }

        /** async Tasks **/
        private async Task updateAsync()
        {

            //Checking Version
            var version = await WebUpdateSquirrel.CheckVersionAsync();
            
            if (version == Application.ProductVersion)
            {
                Console.WriteLine($"{version} = {Application.ProductVersion}");
                updateCheckComplete();
                return;
            }
            else if (version == "Version not identified")
            {
                Console.WriteLine($"{"Version not identified (Laço)"}");
                updateCheckComplete();
                return;
            }


            //Checking for Update
            


            var update = await WebUpdateSquirrel.CheckForUpdatesAsync();
            this.Opacity = 100;
            this.BringToFront();


            if (update.Contains("detected"))
            {
                progressBar1.Invoke((Action)delegate
                {
                    progressBar1.Value = 70;
                });

                try
                {
                    var att = await WebUpdateSquirrel.UpdateAppAsync();
                    progressBar1.Invoke((Action)delegate
                    {
                        progressBar1.Value = 100;
                        WebUpdateSquirrel.RestartApplication();
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update error, please call the support: " + ex.Message);
                }
            }
            else
            {
                updateCheckComplete();
            }
        }

        /** sync Methods **/
        private void updateCheckComplete()
        {
            progressBar1.Invoke((Action)delegate
            {
                progressBar1.Value = 100;
            });
            //CustomNotification.defaultInformation($"Você tem a versão mais recente do {Application.ProductName} ({Application.ProductVersion}).");
            this.Hide();
            FormConfiguration.ShowOrActivateForm<frmLoginNew>();
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmUpdateScreen_Load;
        }
        private async void frmUpdateScreen_Load(object sender, EventArgs e)
        {
            var update = (await IntUpdate.getLastToClassAsync());
            txtInfo.Text = update.Description;
            RollBackInfo rollback = new RollBackInfo();
            rollback = await RollBackInfo.getToClasAsync();


            ///** async Tasks **/
           
                if (rollback.rollbackActivated == "1" && update.Version != Application.ProductVersion)
                    await WebUpdateSquirrel.rollbackAsync();
                await updateAsync();
            
            



            ConfigureLabelEvents();

        }

        private void ConfigureLabelEvents()
        {
            lblQueroSaber.Click += lblQueroSaber_Click;
        }

        private void lblQueroSaber_Click(object sender, EventArgs e)
        {
            txtInfo.Visible = true;
        }

        /** PictureBox  Configuration **/
        
        private void ConfigurePictureBoxProperties()
        {
            progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
            progressBar1.Maximum = 100;
            progressBar1.Value = 30;            
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtInfo.ReadOnly();
            txtInfo.Visible = false;
            txtInfo.ScrollBars = ScrollBars.Vertical;            
        }
        
    }
}
