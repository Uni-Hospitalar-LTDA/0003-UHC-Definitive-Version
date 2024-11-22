using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    public class CfopInnmed : Querys<CfopInnmed>
    {
        public string codigo { get; set; }
        public string description { get; set; }
        public string tipo { get; set; }
        public string tipoNf { get; set; }

        public static async Task<CfopInnmed> getToClassAsync(string codigo)
        {
            string query = $@" SELECT Codigo [codigo], descricao [description],tip_entsai [tipo], tip_notfis [tipoNf]
                                FROM {Connection.dbDMD}.dbo.[TBCFO]
                                where codigo = {codigo} 
                             ";
            return await getToClass(query);
        }
        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT Codigo[codigo], descricao[description], tip_entsai[tipo], tip_notfis[tipoNf]
                                FROM { Connection.dbDMD}.dbo.[TBCFO]
                             ";
            return await getAllToDataTable(query);
        }

    }
}
