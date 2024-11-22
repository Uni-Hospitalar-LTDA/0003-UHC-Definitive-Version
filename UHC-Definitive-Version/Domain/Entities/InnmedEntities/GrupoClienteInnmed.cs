using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    public class GrupoClienteInnmed : Querys<GrupoClienteInnmed>
    {
        public string id { get; set; }
        public string description { get; set; }

        public static async Task<GrupoClienteInnmed> getToClassAsync(string id)
        {
            string query = $@" SELECT Cod_GrpCli [id], Des_GrpCli [description] 
                               FROM [{Connection.dbDMD}].dbo.[GRCLI] WHERE Cod_GrpCli = {id}
                             ";
            return await getToClass(query);
        }

        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT Cod_GrpCli [id]
                                    ,Des_GrpCli [Grupo de Cliente Innmed] 
                               FROM [{Connection.dbDMD}].dbo.[GRCLI] ";
            return await getAllToDataTable(query);
        }
    }
}
