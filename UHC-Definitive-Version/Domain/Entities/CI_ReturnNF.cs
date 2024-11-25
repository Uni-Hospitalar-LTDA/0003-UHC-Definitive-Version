using UHC3_Definitive_Version.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.Entities.CI
{
    public class CI_ReturnNF : Querys<CI_ReturnNF>
    {
        public string idCI_Header { get; set; }
        public string NF_Return { get; set; }

        public static async Task<List<CI_ReturnNF>> getAllToListAsync(string idCI)
        {
            string query = $@"SELECT * FROM [UHCDB].dbo.[{getClassName()}] WHERE idCI_Header = {idCI}";
            return await getAllToList(query);
        }

        public static List<CI_ReturnNF> getAllToListSync(string idCI)
        {
            string query = $@"SELECT * FROM [UHCDB].dbo.[{getClassName()}] WHERE idCI_Header = {idCI}";
            return getAllToListS(query);
        }
    }
}
