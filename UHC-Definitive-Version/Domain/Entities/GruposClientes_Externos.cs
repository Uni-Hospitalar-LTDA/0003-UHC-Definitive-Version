using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities
{
    internal class GruposClientes_Externos : Querys<GruposClientes_Externos>
    {
        public string Cod_GrpCli { get; set; }
        public string Des_GrpCli { get; set; }


        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = @"SELECT Cod_GrpCli, Des_GrpCli FROM [DMD].dbo.[GRCLI]";
            return await getAllToDataTable(query);
        }

        public static async Task<GruposClientes_Externos> getToClassAsync(string id)
        {
            string query = $"SELECT Cod_GrpCli, Des_GrpCli FROM [DMD].dbo.[GRCLI] WHERE Cod_GrpCli = {id}";
            return await getToClass(query);
        }
    }
}
