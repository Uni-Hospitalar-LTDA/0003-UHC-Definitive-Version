using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    public class Transportadores_Externos : Querys<Transportadores_Externos>
    {
        public string Codigo { get; set; }
        public string Razao_Social { get; set; }
        public string Cgc_Cpf { get; set; }

        public async static Task<List<Transportadores_Externos>> getAllToListAsync()
        {
            string query = $@"SELECT 
                              	 Codigo
                              	,Razao_Social
                              	,Cgc_Cpf
                              FROM [DMD].dbo.[TRANS]";
            return await getAllToList(query);
        }

        public async static Task<DataTable> getToDataTableAsync(string text)
        {
            string query = $@"SELECT
                                     Codigo [Código]
                              	    ,Razao_Social [Razão Social]	
                              	    ,FORMAT(CAST(Cgc_Cpf AS BIGINT), '00\.000\.000\/0000\-00') [CNPJ]
                              FROM [DMD].dbo.[TRANS] Transportador
                              WHERE (Razao_Social LIKE '%{text}%' 
                                     OR CAST(Cgc_Cpf AS VARCHAR) LIKE '%{text}%')";
            return await getAllToDataTable(query);
        }

        public async static Task<string> getDescriptionByCode(string codigoTransportador)
        {
            string query = $@"SELECT
                                     Codigo[Codigo]
                              	    ,Razao_Social[Razao_Social]
                              	    ,FORMAT(CAST(Cgc_Cpf AS BIGINT), '00\.000\.000\/0000\-00')[CGC_CPF]
                              FROM [DMD].dbo.[TRANS] Transportador
                              WHERE codigo = {codigoTransportador}";
            var transprotador = await getToClass(query);
            return transprotador.Razao_Social;
        }

    }
}
