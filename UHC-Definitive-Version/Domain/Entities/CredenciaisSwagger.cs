using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class CredenciaisSwagger : Querys<CredenciaisSwagger>
    {
        public string id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public string RotaSwagger { get; set; }
        public string LoginSwagger { get; set; }
        public string SenhaSwagger { get; set; }
        public string Matricula { get; set; }
        public string DataCriacao { get; set; } = DateTime.Now.ToString();
        public string DataEdicao { get; set; } = DateTime.Now.ToString();
        public string Status { get; set; } = 1.ToString();

        //Gets
        public async static Task<CredenciaisSwagger> getToClassAsync(string id)
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}] WHERE id = {id}";
            return await getToClass(query);
        }
        public async static Task<DataTable> getAllToDataTableAsync(string filter, string status)
        {
            string query = $@"SELECT   [{getClassName()}].id [Código]
		,[{getClassName()}].description [Descrição]    	
		,CASE [{getClassName()}].status
			WHEN 1 THEN 'Ativo'
			ELSE 'Inativo'
		  END [Status]		 
FROM [{Connection.dbBase}].dbo.[{getClassName()}] 
                              WHERE 
(CONVERT(VARCHAR,{getClassName()}.Id) = '{filter}' OR {getClassName()}.description LIKE '%{filter}%') AND {getClassName()}.Status IN ({status})
";

            return await getAllToDataTable(query);
        }
        public async static Task<List<CredenciaisSwagger>> getAllToListAsync()
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}] WHERE Status = 1";
            return await getAllToList(query);
        }

    }
}
