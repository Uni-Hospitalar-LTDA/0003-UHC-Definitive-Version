using UHC3_Definitive_Version.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.Entities.CI
{
    public class CI_OriginNF : Querys<CI_OriginNF>
    {
        public string idCI_Header { get; set; }
        public string NF_Origin { get; set; }


        public static async Task<List<CI_OriginNF>> getAllToListAsync(string idCI)
        {
            string query = $@"SELECT * FROM [UHCDB].dbo.[{getClassName()}] WHERE idCI_Header = {idCI}";
            return await getAllToList(query);            
        }

        public static List<CI_OriginNF> getAllToListSync(string idCI)
        {
            string query = $@"SELECT * FROM [UHCDB].dbo.[{getClassName()}] WHERE idCI_Header = {idCI}";
            return getAllToListS(query);
        }
    }
}
