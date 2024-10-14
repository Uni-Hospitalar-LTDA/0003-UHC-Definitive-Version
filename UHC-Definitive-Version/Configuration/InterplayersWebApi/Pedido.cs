using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.Configuration.InterplayersWebApi
{
    public class Pedido
    {
        public string CnpjCliente { get; set; }
        public List<Distribuidor> Distribuidores { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataProgramada { get; set; }
        public string NumeroPedidoErp { get; set; } 
        public string NumeroPedidoCliente { get; set; }
        public List<Item> Itens { get; set; }
        
        public async Task<Token> getToken(Credentials cc)
        {
            return await Token.POST(cc);
        }

        public async static Task<string> PostPedidoAsync(List<Pedido> pedidos, Token token,CredenciaisSwagger cc)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{cc.RotaSwagger}/api/v1/pre-pedidos-v2");

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token.data.token);
            httpWebRequest.Accept = "application/json";

            // Serializa a lista de pedidos em vez de apenas um único pedido
            var pedidoSerialization = JsonConvert.SerializeObject(pedidos, Formatting.Indented);
            Console.WriteLine(pedidoSerialization);

            // Salvando o JSON em um arquivo
            string filePath = SaveJsonToFile(pedidoSerialization, "pedidos");

            using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
            {
                streamWriter.Write(pedidoSerialization);
                Console.WriteLine(pedidoSerialization);
            }

            string httpResponseContent = null;
            try
            {
                using (var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    // Captura a resposta HTTP
                    httpResponseContent = await streamReader.ReadToEndAsync();
                }
            }
            catch (Exception ex)
            {
                // Captura qualquer erro de exceção
                httpResponseContent = ex.Message;
            }

            // Unificando o conteúdo enviado e a resposta HTTP em um único arquivo .txt
            SaveRequestAndResponseToFile(filePath, pedidoSerialization, httpResponseContent);

            return httpResponseContent;
        }
        public async static Task<string> PostNumeroPedidoPortalAsync(int numeroPedidoPortal, Token token, CredenciaisSwagger cc)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{cc.RotaSwagger}/api/v1/pedido");

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token.data.token);
            httpWebRequest.Accept = "application/json";

            // Cria o objeto anônimo com a propriedade NumeroPedidoPortal
            var payload = new
            {
                NumeroPedidoPortal = numeroPedidoPortal
            };

            // Serializa o objeto anônimo para JSON
            var payloadSerialization = JsonConvert.SerializeObject(payload, Formatting.Indented);
            Console.WriteLine(payloadSerialization);

            // Salvando o JSON em um arquivo (opcional)
            string filePath = SaveJsonToFile(payloadSerialization, "pedido_portal");

            using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
            {
                streamWriter.Write(payloadSerialization);
                Console.WriteLine(payloadSerialization);
            }

            string httpResponseContent = null;
            try
            {
                using (var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    // Captura a resposta HTTP
                    httpResponseContent = await streamReader.ReadToEndAsync();
                }
            }
            catch (Exception ex)
            {
                // Captura qualquer erro de exceção
                httpResponseContent = ex.Message;
            }

            // Unificando o conteúdo enviado e a resposta HTTP em um único arquivo .txt
            SaveRequestAndResponseToFile(filePath, payloadSerialization, httpResponseContent);

            return httpResponseContent;
        }

        public async static Task<PedidoDetalhadoResposta> GetPedidoPorIdAsync(string id, Token token, CredenciaisSwagger cc)
        {
            string rotaGet = $"{cc.RotaSwagger}/api/v1/pedido/{id}";


            var httpWebRequest = (HttpWebRequest)WebRequest.Create(rotaGet);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token.data.token);
            httpWebRequest.Accept = "application/json";

            try
            {
                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    // Deserializa a resposta JSON em um objeto PedidoDetalhadoResposta
                    var responseString = await streamReader.ReadToEndAsync();
                    var pedidoDetalhadoResposta = JsonConvert.DeserializeObject<PedidoDetalhadoResposta>(responseString);

                    return pedidoDetalhadoResposta;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar pedido: {ex.Message}");
                return null;
            }
        }


        private static string SaveJsonToFile(string jsonContent, string baseFileName)
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyAppData");
            Directory.CreateDirectory(folderPath); // Garante que o diretório exista

            int fileCount = Directory.GetFiles(folderPath, $"{baseFileName}_*.json").Length + 1;
            string fileName = $"{baseFileName}_{fileCount}.json";
            string finalPath = Path.Combine(folderPath, fileName);

            File.WriteAllText(finalPath, jsonContent);

            return finalPath;
        }

        // Método para salvar o conteúdo enviado e a resposta em um único arquivo .txt
        private static void SaveRequestAndResponseToFile(string originalFilePath, string requestContent, string responseContent)
        {
            // Gera o nome do arquivo com o sufixo _retorno
            string responseFilePath = Path.ChangeExtension(originalFilePath, null) + "_retorno.txt";

            // Formata o conteúdo para incluir tanto o JSON enviado quanto a resposta
            var combinedContent = new System.Text.StringBuilder();
            combinedContent.AppendLine("===== JSON Enviado =====");
            combinedContent.AppendLine(requestContent);
            combinedContent.AppendLine();
            combinedContent.AppendLine("===== Resposta Recebida =====");
            combinedContent.AppendLine(responseContent);

            // Escreve o conteúdo combinado em um arquivo de texto
            File.WriteAllText(responseFilePath, combinedContent.ToString());
        }

    }
}
