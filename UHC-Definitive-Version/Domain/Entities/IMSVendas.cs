using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.IMS
{
    public class IMSVendas
    {
        public static async Task<string> writeIMSVendas(DateTime date, string id)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\{Application.ResourceAssembly.FullName}\Iqvia";
            string archiveName = $"V{Section.CodIqvia}M{date.ToString("MM")}.D{date.ToString("dd")}";
            string filePath = $@"{folder}\{archiveName}";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            // Adiciona verificação e remoção de arquivo
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                await writer.WriteLineAsync(await Header_IMSVendas.getHeaderAsync(date));
                var description = await Descricao_IMSVendas.getDescricao(date, id);

                // Verifica se description.Item1 é nulo
                if (description.Item1 == null)
                {
                    writer.Close();
                    File.Delete(filePath);
                    return null;
                }

                string str = RemoveEmptyLinesFromString(description.Item1);                
                await writer.WriteLineAsync(str);                
                await writer.WriteAsync(await Trailer_IMSVendas.getTraillerAsync(CountLinesInString(str)+2, description.Item3, description.Item4));
            }

            // Após escrever o arquivo, remover as linhas vazias
            

            return filePath;
        }


        private static int CountLinesInString(string input, bool countEmptyLines = true)
        {
            // Dividir a string em linhas
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            if (countEmptyLines)
            {
                // Retorna o número total de linhas
                return lines.Length;
            }
            else
            {
                // Retorna o número de linhas não vazias
                return lines.Count(line => !string.IsNullOrWhiteSpace(line));
            }
        }

        private static string RemoveEmptyLinesFromString(string input)
        {
            // Dividir a string em linhas, filtrar as não vazias e juntar as linhas novamente
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                             .Where(line => !string.IsNullOrWhiteSpace(line))
                             .ToArray();
            return string.Join(Environment.NewLine, lines);
        }


        public static async Task<Tuple<List<Descricao_IMSVendas>, List<Descricao_IMSVendas>>> getDescriptionsAsync(DateTime date, string id)
        {
            return await Descricao_IMSVendas.getAllTolistAsync(date, id);
        }
    }

}
