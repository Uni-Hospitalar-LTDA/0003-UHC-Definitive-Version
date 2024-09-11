using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace UHC3_Definitive_Version.Domain.IMS
{
    public class IMSProduto
    {        
        public static async Task<string> writeIMSProduto(DateTime date, string id)
        {
            try
            {                
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\{Application.ResourceAssembly.FullName}\Iqvia";
                string archiveName = $"P{Section.CodIqvia}M{date.ToString("MM")}.D{date.ToString("dd")}";

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

                await writer.WriteLineAsync(await Header_IMSProduto.getHeaderAsync(date));
                var description = await Descricao_IMSProduto.getDescricao(date, id);

                // Verifica se description.Item1 é nulo
                if (description.Item1 == null)
                {
                    writer.Close();
                    File.Delete(filePath);
                    return null;
                }

                await writer.WriteLineAsync(description.Item1);
                await writer.WriteLineAsync(await Trailer_IMSProduto.getTraillerAsync(description.Item2));
                writer.Close();                
                return $@"{folder}\{archiveName}";
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
                return null;
            }
            
        }

        public async static Task<Tuple<List<Descricao_IMSProduto>, List<Descricao_IMSProduto>>> getDescriptionsAsync(DateTime date,string id)
        {
            return await Descricao_IMSProduto.getAllTolistAsync(date,id);
        }


    }
}
