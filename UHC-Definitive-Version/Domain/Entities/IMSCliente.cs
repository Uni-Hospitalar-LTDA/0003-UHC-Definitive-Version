using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.IMS
{
    public class IMSCliente
    {
        public static async Task<string> writeIMSCliente(DateTime date, string id)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\{Application.ResourceAssembly.FullName}\Iqvia";
            string archiveName = $"C{Section.CodIqvia}M{date.ToString("MM")}.D{date.ToString("dd")}";

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
            await writer.WriteLineAsync(await Header_IMSCliente.getHeaderAsync(date));
            var description = await Descricao_IMSCliente.getDescriptionAsync(date, id);

            // Verifica se description.Item1 é nulo
            if (description.Item1 == null)
            {
                writer.Close();
                File.Delete(filePath);
                return null;
            }

            await writer.WriteLineAsync(description.Item1);
            await writer.WriteLineAsync(await Trailler_IMSCliente.getTraillerAsync(description.Item2));
            writer.Close();

            
            return $@"{folder}\{archiveName}";
        }

        public async static Task<Tuple<List<Descricao_IMSCliente>, List<Descricao_IMSCliente>>> getDescriptionsAsync(DateTime date,string id)
        {
            return await Descricao_IMSCliente.getAllTolistAsync(Convert.ToDateTime(date),id);
        }



    }
}
