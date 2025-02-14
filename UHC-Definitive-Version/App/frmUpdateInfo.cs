using Markdig;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.App
{
    public partial class frmUpdateInfo : CustomForm
    {
        public frmUpdateInfo()
        {
            InitializeComponent();

            // Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();

            // Events
            ConfigureFormEvents();
        }

        // Sync Methods 
        public static string ConvertMarkdownToHtml(string markdown)
        {
            if (string.IsNullOrEmpty(markdown))
                return "<p>Nenhuma descrição encontrada.</p>";

            // Converte Markdown para HTML
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            string html = Markdig.Markdown.ToHtml(markdown, pipeline);

            return html;
        }

        // Async Tasks 
        private async Task LoadDescriptionIntoWebBrowser()
        {
            try
            {
                // Obtém a descrição da versão em Markdown
                string markdownDescription = await WebSquirrelUpdate.GetReleaseDescriptionAsync(Application.ProductVersion);

                // Converte o Markdown para HTML
                string htmlDescription = ConvertMarkdownToHtml(markdownDescription);

                // Define o HTML no WebBrowser
                webBrowser1.DocumentText = $"<html><body>{htmlDescription}</body></html>";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a descrição: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmUpdateInfo_Load;
        }

        private async void frmUpdateInfo_Load(object sender, EventArgs e)
        {
            await LoadDescriptionIntoWebBrowser();
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }

    }
}
