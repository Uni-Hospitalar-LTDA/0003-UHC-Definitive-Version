using _0009_Integra_Cob.App;
using _0009_Integra_Cob.Configuration;
using _0009_Integra_Cob.Configuration.Update;
using _0009_Integra_Cob.Customization;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0009_Integra_Cob.App
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

            //Events
            ConfigureFormEvents();
        }

        /** async Tasks **/
        private async Task updateAsync()
        {

            //Checking Version
            var version = await WebUpdateSquirrel.CheckVersionAsync();
            Console.WriteLine(version);
            if (version == Application.ProductVersion)
            {

                updateCheckComplete();
                return;
            }
            else if (version == "Version not identified")
            {
                updateCheckComplete();
                return;
            }

            this.Opacity = 100;

            //Checking for Update
            var update = await WebUpdateSquirrel.CheckForUpdatesAsync();



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

            /** async Tasks **/
            await updateAsync();

        }

        /** PictureBox  Configuration **/
        private void ConfigurePictureBoxProperties()
        {
            progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
            progressBar1.Maximum = 100;
            progressBar1.Value = 30;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
