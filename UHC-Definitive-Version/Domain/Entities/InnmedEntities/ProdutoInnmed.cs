using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    public class ProdutoInnmed : Querys<ProdutoInnmed>
    {
        public string id { get; set; }
        public string description { get; set; }
        public string ean { get; set; }

        public static async Task<ProdutoInnmed> getToClassAsync(string id)
        {
            string query = $@"SELECT codigo [id],descricao [description], cod_ean [ean]
                              FROM {Connection.dbDMD}.dbo.[PRODU] 
                              WHERE Codigo = {id}";

            return await getToClass(query);
        }

        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT codigo [id],descricao [description], cod_ean [ean]
                              FROM {Connection.dbDMD}.dbo.[PRODU] ";

            return await getAllToDataTable(query);
        }
    }
}
