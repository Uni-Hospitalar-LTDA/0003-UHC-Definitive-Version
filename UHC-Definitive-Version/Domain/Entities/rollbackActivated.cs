using System;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class RollBackInfo : Querys<RollBackInfo>
    {
        public string id { get; set; }
        public string rollbackActivated { get; set; }

        public async static Task<RollBackInfo> getToClasAsync()
        {
            string query = $"SELECT * FROM {Connection.dbBase}.dbo.[{RollBackInfo.getClassName()}]";
            return await getToClass(query);
        }
    }
}
