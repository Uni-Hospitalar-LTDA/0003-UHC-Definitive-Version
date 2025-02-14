using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    public class Favorecidos_Externos : Querys<Favorecidos_Externos>
    {
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string cnpj_cpf { get; set; }

        public async static Task<DataTable> getToDataTableAsync(string text)
        {
            string query = $@"SELECT
                                     Cod_Favore [Código]
                              	    ,Des_Favore [Descrição]	
									,[CPF/CNPJ] = 
									CASE LEN(LTRIM(Num_CgcCpf))
									WHEN 11 THEN FORMAT(CAST(Num_CgcCpf AS BIGINT), '000\.000\.000\-00') 
									WHEN 14 THEN FORMAT(CAST(Num_CgcCpf AS BIGINT), '00\.000\.000\/0000\-00')
									ELSE Num_CgcCpf
									END                              
                              FROM [DMD].dbo.[FAVOR] Favorecido
                              WHERE (Des_Favore LIKE '%{text}%' 
                                     OR CAST(Num_CgcCpf AS VARCHAR) LIKE '%{text}%')";
            return await getAllToDataTable(query);
        }


        public async static Task<string> getDescriptionByCode(string codigoFavorecido)
        {
            string query = $@"SELECT
                                     Cod_Favore [codigo]
                              	    ,Des_Favore [descricao]	
									,[cnpj_cpf] = 
									CASE LEN(LTRIM(Num_CgcCpf))
									WHEN 11 THEN FORMAT(CAST(Num_CgcCpf AS BIGINT), '000\.000\.000\-00') 
									WHEN 14 THEN FORMAT(CAST(Num_CgcCpf AS BIGINT), '00\.000\.000\/0000\-00')
									ELSE Num_CgcCpf
									END                              
                              FROM [DMD].dbo.[FAVOR] Favorecido
                              WHERE Cod_Favore = {codigoFavorecido} ";
            var favorecido = await getToClass(query);
            return favorecido.descricao;
        }
    }
}
