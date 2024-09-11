using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.IMS
{
    public class IMSVendas  
    {
        public static async Task<string> writeIMSVendas(DateTime date,string id)
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


            StreamWriter writer = new StreamWriter($@"{folder}\{archiveName}");


            await writer.WriteLineAsync(await Header_IMSVendas.getHeaderAsync(date));
            var description = await Descricao_IMSVendas.getDescricao(date,id);
            


            // Verifica se description.Item1 é nulo
            if (description.Item1 == null)
            {
                writer.Close();
                File.Delete(filePath);
                return null;
            }

            await writer.WriteLineAsync(description.Item1);
            await writer.WriteAsync(await Trailer_IMSVendas.getTraillerAsync(description.Item2, description.Item3, description.Item4));
            writer.Close();

            return $@"{folder}\{archiveName}";
        }

        public static async Task<Tuple<List<Descricao_IMSVendas>, List<Descricao_IMSVendas>>> getDescriptionsAsync(DateTime date,string id)
        {
            return await Descricao_IMSVendas.getAllTolistAsync(date,id);
        }
    }
}
