using Newtonsoft.Json.Linq;
using Squirrel;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Configuration
{
    public class WebSquirrelUpdate
    {
        // Constantes
        private const string repositoryOwner = "Uni-Hospitalar-LTDA";
        private const string repositoryName = "0003-UHC-Definitive-Version";
        //private const string token = ""

        private const string token = "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";


        public static async Task rollbackAsync(string rollbackTag)
        {
            CustomNotification.defaultAlert("Rollback detectado! A aplicação passará por reparos automáticos. Aguarde a tela de login.");

            string fileName = "Setup.exe";
            string outputDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName);

            try
            {
                await GitHubUtilities.DownloadAssetFromTagAsync(repositoryOwner, repositoryName, rollbackTag, fileName, token, outputDirectory);

                string outputPath = Path.Combine(outputDirectory, fileName);

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = outputPath,
                        UseShellExecute = true,
                        Verb = "runas"
                    }
                };
                process.Start();

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar o rollback: {ex.Message}");
            }
        }


        public static async Task UpdateAppAsync(string updateTag)
        {
            string fileName = "Setup.exe";
            string outputDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName);

            try
            {
                await GitHubUtilities.DownloadAssetFromTagAsync(repositoryOwner, repositoryName, updateTag, fileName, token, outputDirectory);

                string outputPath = Path.Combine(outputDirectory, fileName);

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = outputPath,
                        UseShellExecute = true,
                        Verb = "runas"
                    }
                };
                process.Start();

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError($"Erro ao realizar a atualização: {ex.Message}");
            }
        }


        public static void RestartApplication()
        {
            UpdateManager.RestartApp();
        }


        public static async Task<string> GetReleaseDescriptionAsync(string tag)
        {
            string apiUrl = $"https://api.github.com/repos/{repositoryOwner}/{repositoryName}/releases/tags/{tag}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "C# App");

                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    }

                    string response = await client.GetStringAsync(apiUrl);

                    var json = JObject.Parse(response);
                    string description = json["body"]?.ToString();

                    if (string.IsNullOrEmpty(description))
                    {
                        return "Nenhuma descrição encontrada.";
                    }

                    return description.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
                }
            }
            catch (HttpRequestException ex)
            {
                return $"Erro ao acessar a API do GitHub: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Erro inesperado: {ex.Message}";
            }
        }


        public static async Task<string> CheckVersionAsync()
        {
            try
            {
                string latestRelease = await getWebVersionAsync();
                string currentVersion = Application.ProductVersion;

                int comparison = CompareVersions(currentVersion, string.IsNullOrEmpty(latestRelease) ? "1.0.0" : latestRelease);

                if (comparison > 0)
                {
                    return $"A versão atual ({currentVersion}) é maior que a última versão válida ({latestRelease}).";
                }
                else if (comparison < 0)
                {
                    return $"A versão atual ({currentVersion}) é menor que a última versão válida ({latestRelease}).";
                }
                else
                {
                    return $"A versão atual ({currentVersion}) é igual à última versão válida ({latestRelease}).";
                }
            }
            catch (Exception ex)
            {
                return $"Erro ao verificar a versão: {ex.Message}";
            }
        }


        public static async Task<string> getWebVersionAsync()
        {
            return (await GitHubUtilities.GetLatestReleaseAsync(repositoryOwner, repositoryName, token)).TagName;
        }


        private static int CompareVersions(string currentVersion, string latestVersion)
        {
            var currentParts = currentVersion.Split('.').Select(int.Parse).ToArray();
            var latestParts = latestVersion.Split('.').Select(int.Parse).ToArray();

            for (int i = 0; i < Math.Max(currentParts.Length, latestParts.Length); i++)
            {
                int currentPart = i < currentParts.Length ? currentParts[i] : 0;
                int latestPart = i < latestParts.Length ? latestParts[i] : 0;

                if (currentPart > latestPart) return 1;
                if (currentPart < latestPart) return -1;
            }

            return 0; // As versões são iguais
        }
    }
}
