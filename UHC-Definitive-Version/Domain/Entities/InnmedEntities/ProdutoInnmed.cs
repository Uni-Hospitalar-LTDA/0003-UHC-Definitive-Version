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
        public string idFabricante { get; set; }
        public string precoFabrica { get; set; }
        public string classFiscal { get; set; }
        public string datCadastro { get; set; }

        public static async Task<ProdutoInnmed> getToClassAsync(string id)
        {
            string query = $@"SELECT Produto.codigo [id]    
                                    ,Produto.descricao [description]
                                    ,Produto.cod_ean [ean]
                                    ,Produto.Cod_Fabricante [idFabricante]
                                    ,CONVERT(NUMERIC(14,2),ROUND(Produto.Prc_CustoMedio,2)) [precoFabrica]
                                    ,Produto.Cod_ClaFis [classFiscal]
                                    ,Produto.Dat_Cadastro [datCadastro]
                              FROM {Connection.dbDMD}.dbo.[PRODU] Produto
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
