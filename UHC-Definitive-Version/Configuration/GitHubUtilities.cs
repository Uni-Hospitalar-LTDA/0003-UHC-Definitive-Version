using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version
{
    public class GitHubUtilities
    {
        private const string UserAgent = "C# App";



        /// <summary>
        /// Obtém os detalhes de uma release específica de um repositório no GitHub com base na tag fornecida.
        /// </summary>
        /// <param name="repoOwner">Proprietário do repositório.</param>
        /// <param name="repoName">Nome do repositório.</param>
        /// <param name="tag">Tag da release desejada.</param>
        /// <param name="token">Token de autenticação opcional.</param>
        /// <returns>Uma tupla contendo a descrição, tag e título da release.</returns>
        public static async Task<(string Description, string Tag, string Title)> GetReleaseDetailsAsync(string repoOwner, string repoName, string tag, string token = null)
        {
            string apiUrl = $"https://api.github.com/repos/{repoOwner}/{repoName}/releases/tags/{tag}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configurar o User-Agent
                    client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

                    // Adicionar autenticação, se fornecido um token
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    }

                    // Fazer a requisição à API
                    string response = await client.GetStringAsync(apiUrl);

                    // Processar o JSON retornado
                    var json = JObject.Parse(response);
                    string description = json["body"]?.ToString() ?? "Nenhuma descrição encontrada.";
                    string releaseTag = json["tag_name"]?.ToString() ?? "Nenhuma tag encontrada.";
                    string releaseTitle = json["name"]?.ToString() ?? "Nenhum título encontrado.";

                    return (description, releaseTag, releaseTitle);
                }
            }
            catch (HttpRequestException ex)
            {
                return ($"Erro ao acessar a API do GitHub: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return ($"Erro inesperado: {ex.Message}", null, null);
            }
        }


        /// <summary>
        /// Obtém a última release válida (não rascunho e não pré-release) de um repositório do GitHub.
        /// </summary>
        /// <param name="repoOwner">Proprietário do repositório.</param>
        /// <param name="repoName">Nome do repositório.</param>
        /// <param name="token">Token de autenticação opcional.</param>
        /// <returns>Uma tupla contendo a tag, nome e corpo da release mais recente.</returns>
        public static async Task<(string TagName, string ReleaseName, string Body)> GetLatestReleaseAsync(string repoOwner, string repoName, string token = null)
        {
            string apiUrl = $"https://api.github.com/repos/{repoOwner}/{repoName}/releases";
            Console.WriteLine(apiUrl);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configurar o User-Agent
                    client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

                    // Adicionar autenticação, se fornecido um token
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    }

                    // Fazer a requisição à API
                    string response = await client.GetStringAsync(apiUrl);

                    // Processar o JSON retornado
                    var json = JArray.Parse(response);

                    foreach (var release in json)
                    {
                        // Ignorar rascunhos e pré-releases
                        bool isDraft = release["draft"]?.ToObject<bool>() ?? false;
                        bool isPrerelease = release["prerelease"]?.ToObject<bool>() ?? false;

                        if (!isDraft && !isPrerelease)
                        {
                            // Retorna a primeira release válida (mais recente)
                            string tagName = release["tag_name"]?.ToString();
                            string releaseName = release["name"]?.ToString();
                            string body = release["body"]?.ToString();

                            return (tagName, releaseName, body);
                        }
                    }

                    return ("", "Nenhuma release válida encontrada.", "");
                }
            }
            catch (HttpRequestException ex)
            {
                return ("", $"Erro ao acessar a API do GitHub: {ex.Message}", "");
            }
            catch (Exception ex)
            {
                return ("", $"Erro inesperado: {ex.Message}", "");
            }
        }

        /// <summary>
        /// Lista todas as tags de um repositório do GitHub e as ordena alfabeticamente.
        /// </summary>
        /// <param name="repoOwner">Proprietário do repositório.</param>
        /// <param name="repoName">Nome do repositório.</param>
        /// <param name="token">Token de autenticação opcional.</param>
        /// <returns>Uma lista de strings contendo as tags ordenadas.</returns>
        public static async Task<List<string>> ListAndSortTagsAsync(string repoOwner, string repoName, string token = null)
        {
            string apiUrl = $"https://api.github.com/repos/{repoOwner}/{repoName}/tags";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configurar o User-Agent
                    client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

                    // Adicionar autenticação, se fornecido um token
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    }

                    // Fazer a requisição à API
                    string response = await client.GetStringAsync(apiUrl);

                    // Processar o JSON retornado
                    var json = JArray.Parse(response);

                    // Extrair e ordenar as tags
                    List<string> tags = new List<string>();
                    foreach (var item in json)
                    {
                        string tagName = item["name"]?.ToString();
                        if (!string.IsNullOrEmpty(tagName))
                        {
                            tags.Add(tagName);
                        }
                    }

                    tags.Sort(); // Ordenar alfabeticamente
                    return tags;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro ao acessar a API do GitHub: {ex.Message}");
                return new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return new List<string>();
            }
        }


        /// <summary>
        /// Faz o download de um ativo específico de uma release no GitHub com base na tag fornecida.
        /// </summary>
        /// <param name="repoOwner">Proprietário do repositório.</param>
        /// <param name="repoName">Nome do repositório.</param>
        /// <param name="tag">Tag da release que contém o ativo.</param>
        /// <param name="fileName">Nome do arquivo a ser baixado.</param>
        /// <param name="token">Token de autenticação obrigatório.</param>
        /// <param name="outputDirectory">Diretório de destino para salvar o arquivo.</param>
        public static async Task DownloadAssetFromTagAsync(
        string repoOwner, string repoName, string tag, string fileName, string token, string outputDirectory)
        {
            try
            {
                // URL da API para buscar os detalhes da release pela tag
                string apiUrl = $"https://api.github.com/repos/{repoOwner}/{repoName}/releases/tags/{tag}";
                Console.WriteLine($"URL da API: {apiUrl}");

                using (HttpClient client = new HttpClient())
                {
                    // Configurar cabeçalhos
                    client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    }

                    // Obter os detalhes da release
                    string response = await client.GetStringAsync(apiUrl);
                    Console.WriteLine($"JSON retornado: {response}");
                    var releaseData = JObject.Parse(response);

                    // Procurar pelo asset desejado pelo nome
                    var asset = releaseData["assets"]?.FirstOrDefault(a => a["name"]?.ToString() == fileName);
                    if (asset == null)
                    {
                        throw new Exception($"O arquivo '{fileName}' não foi encontrado na tag '{tag}'.");
                    }

                    // Obter o ID do asset
                    string assetId = asset["id"]?.ToString();
                    if (string.IsNullOrEmpty(assetId))
                    {
                        throw new Exception($"O ID do asset '{fileName}' não foi encontrado.");
                    }

                    // URL para download do asset pela API
                    string assetApiUrl = $"https://api.github.com/repos/{repoOwner}/{repoName}/releases/assets/{assetId}";
                    Console.WriteLine($"URL para download do asset: {assetApiUrl}");

                    // Criar o diretório de saída, se necessário
                    if (!Directory.Exists(outputDirectory))
                    {
                        Directory.CreateDirectory(outputDirectory);
                    }

                    // Caminho completo para salvar o arquivo
                    string outputPath = Path.Combine(outputDirectory, fileName);

                    // Fazer o download do arquivo
                    Console.WriteLine($"Iniciando download do arquivo...");
                    var request = new HttpRequestMessage(HttpMethod.Get, assetApiUrl);
                    request.Headers.Add("User-Agent", "C# App");
                    request.Headers.Add("Authorization", $"Bearer {token}");
                    request.Headers.Add("Accept", "application/octet-stream");

                    var httpResponse = await client.SendAsync(request);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        using (var stream = await httpResponse.Content.ReadAsStreamAsync())
                        using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                        Console.WriteLine($"Arquivo '{fileName}' baixado com sucesso para '{outputPath}'.");
                    }
                    else
                    {
                        Console.WriteLine($"Erro ao baixar o arquivo: {httpResponse.StatusCode} - {httpResponse.ReasonPhrase}");
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Erro ao acessar a API do GitHub: {httpEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                throw;
            }
        }






    }
}
