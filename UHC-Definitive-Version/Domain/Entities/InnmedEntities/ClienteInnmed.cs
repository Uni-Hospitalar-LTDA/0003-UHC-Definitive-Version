using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    internal class ClienteInnmed : Querys<ClienteInnmed>
    {
        public string id { get; set; }
        public string description { get; set; }
        public string cnpj { get; set; }


        public static async Task<ClienteInnmed> getToClassAsync(string id)
        {
            string query = $@"SELECT codigo [id],Razao_Social [description], cgc_cpf [cnpj]
                              FROM {Connection.dbDMD}.dbo.[CLIEN] 
                              WHERE Codigo = {id}";

            return await getToClass(query);
        }

        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT codigo [id],fantasia [Cliente Innmed], [CNPJ] = CGC_CPF
                              FROM {Connection.dbDMD}.dbo.[CLIEN]";

            return await getAllToDataTable(query);
        }
    }
}
