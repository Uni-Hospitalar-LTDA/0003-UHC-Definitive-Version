using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    public class Vendedores_Externos : Querys<Vendedores_Externos>
    {
        public string Codigo { get; set; }
        public string Nome_Guerra { get; set; }


        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = @"SELECT Codigo, Nome_Guerra FROM [DMD].dbo.[VENDE]";
            return await getAllToDataTable(query);
        }

        public static async Task<Vendedores_Externos> getToClassAsync(string id)
        {
            string query = $"SELECT Codigo, Nome_Guerra FROM [DMD].dbo.[VENDE] WHERE Codigo = {id}";
            return await getToClass(query);
        }

    }
}
