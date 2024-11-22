using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    public class Fornecedores_Externos : Querys<Fornecedores_Externos>
    {
        public string codigo { get; set; }
        public string razaoSocial { get; set; }
        public string cnpj { get; set; }
        public async static Task<DataTable> getToDataTableAsync(string text)
        {
            string query = $@"SELECT
                                     Codigo [Código]
                              	    ,Razao_Social [Razão Social]	
                              	    ,FORMAT(CAST(Cgc_Cpf AS BIGINT), '00\.000\.000\/0000\-00') [CNPJ]
                              FROM [DMD].dbo.[FORNE] Fornecedor
                              WHERE (Razao_Social LIKE '%{text}%' 
                                     OR CAST(Cgc_Cpf AS VARCHAR) LIKE '%{text}%')";
            return await getAllToDataTable(query);
        }

        public async static Task<List<Fornecedores_Externos>> getToListAsync()
        {
            string query = $@"SELECT
                                     Codigo [codigo]
                              	    ,Razao_Social [razaoSocial]	
                              	    ,Cgc_Cpf [cnpj]
                              FROM [DMD].dbo.[FORNE] Fornecedor";                                                                 
            return await getAllToList(query);
        }

        public async static Task<Fornecedores_Externos> getFornecedorByCodeAsync(string code)
        {
            string query = $@"SELECT
                                     Codigo [codigo]
                              	    ,Razao_Social [razaoSocial]	
                              	    ,Cgc_Cpf [cnpj]      
                              FROM [DMD].dbo.[FORNE] Fornecedor where codigo = {code}";
            return await getToClass(query);
        }

        public async static Task<string> getDescriptionByCode(string codigoFornecedor)
        {
            string query = $@"SELECT
                                     Codigo [codigo]
                              	    ,Razao_Social [razaoSocial]	
                              	    ,FORMAT(CAST(Cgc_Cpf AS BIGINT), '00\.000\.000\/0000\-00') [cnpj]
                              FROM [DMD].dbo.[FORNE] Fornecedor
                              WHERE Codigo = {codigoFornecedor} ";
            var fornecedor = await getToClass(query);
            return fornecedor.razaoSocial;
        }
    }
}
