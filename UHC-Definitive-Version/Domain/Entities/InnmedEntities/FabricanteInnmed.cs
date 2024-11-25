using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    public class FabricanteInnmed : Querys<FabricanteInnmed>
    {
        public string id { get; set; }
        public string description { get; set; }        


        public static async Task<FabricanteInnmed> getToClassAsync(string id)
        {
            string query = $@"SELECT codigo [id],fantasia [description]
                              FROM {Connection.dbDMD}.dbo.[FABRI] 
                              WHERE Codigo = {id}";

            return await getToClass(query);
        }

        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT codigo [id],fantasia [Fabricante Innmed]
                              FROM {Connection.dbDMD}.dbo.[FABRI]";

            return await getAllToDataTable(query);
        }
    }
}
