using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Configuration
{
    public class IntUpdate : Querys<IntUpdate>
    {
        public string Id { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }

        public static async Task<IntUpdate> getLastToClassAsync()
        {
            string query = $"SELECT TOP 1 * FROM [{Connection.dbBase}].dbo.[{getClassName()}] ORDER BY Id DESC";
            return await getToClass(query);
        }
    }
}
