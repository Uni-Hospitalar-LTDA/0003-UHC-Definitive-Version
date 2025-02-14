using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.Users
{
    public class Sector : Querys<Sector>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }        



        //Gets
        public async static Task<Sector> getToClassAsync(string id)
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{Sector.getClassName()}] WHERE id = {id}";
            return await getToClass(query);
        }
        public async static Task<DataTable> getAllToDataTableAsync(string filter, string status)
        {
            string query = $@"SELECT   [Sector].id [Código]
		,[Sector].description [Descrição]    	
		,CASE [Sector].status
			WHEN 1 THEN 'Ativo'
			ELSE 'Inativo'
		  END [Status]
		 ,[Qtd. Usuários] = COUNT(Us.Id)
FROM [{Connection.dbBase}].dbo.[{getClassName()}] 
LEFT JOIN [{Connection.dbBase}].dbo.[Users]  Us ON Us.idSector = [{getClassName()}].Id
                              WHERE 
                                (CONVERT(VARCHAR,{getClassName()}.Id) = '{filter}' OR {getClassName()}.description LIKE '%{filter}%') AND {getClassName()}.Status IN ({status})
GROUP BY
 [Sector].id 
,[Sector].description 
,[Sector].status";

            return await getAllToDataTable(query);
        }
        public async static Task<List<Sector>> getAllToListAsync()
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}] WHERE Status = 1";
            return await getAllToList(query);
        }

    }
}
