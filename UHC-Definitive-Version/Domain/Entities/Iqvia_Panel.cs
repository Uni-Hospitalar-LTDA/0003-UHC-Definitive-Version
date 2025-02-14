using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class Iqvia_Panel : Querys<Iqvia_Panel>
    {
        public string id { get; set; }
        public string description { get; set; }
        public string day { get; set; }
        public string hasBlock { get; set; } = "0";
        public string hasSent { get; set; } = "0";


        /** Gets **/
        public async static Task<DataTable> getAllExternalToDataTableAsync(DateTime dateInicial, DateTime dateFinal)
        {
            string query = $@"
                                 SELECT 
                              	 id 
                              	,description [Nome do Arquivo]
                              	,day [Dia do arquivo]
                              	,CASE hasBlock
                                    WHEN 0 THEN 'Não'
                                    ELSE 'Sim'
                                    END [Existem Bloqueios?]
                              	,CASE hasSent 
                                    WHEN 1 THEN 'Sim'
                                    ELSE 'Não' 
                                    END
                                 [Foi enviado?]	
                              FROM [UHCDB].dbo.[Iqvia_Panel]  
                              WHERE day BETWEEN '{dateInicial.ToString("yyyyMMdd")}' AND '{dateFinal.ToString("yyyyMMdd")}'";
            return await getAllToDataTable(query);
        }
        public async static Task<List<Iqvia_Panel>> getAllToListAsync(DateTime dateInicial, DateTime dateFinal)
        {
            string query =
                $@"SELECT 
                   	 id
                   	,description
                   	,day
                   	,hasBlock
                   	,hasSent
                   FROM UHCDB.DBO.Iqvia_Panel
                   WHERE CONVERT(DATE,DAY) >= '{dateInicial.ToString("yyyyMMdd")}' 
                   AND CONVERT(DATE,DAY) <= '{dateFinal.ToString("yyyyMMdd")}'
                    AND 
		            (
			        (
				        (SELECT Layout_Vendas FROM [UHCDB].dbo.[Iqvia_Control]) = 1
				        AND description like 'V%'
        			)			
		        	OR
			        (
				        (SELECT Layout_Produtos FROM [UHCDB].dbo.[Iqvia_Control]) = 1
				        AND description like 'P%'
			        )
			        OR
			        (
				        (SELECT Layout_Clientes FROM [UHCDB].dbo.[Iqvia_Control]) = 1
				        AND description like 'C%'
			        )
		        )";
            return await getAllToList(query);
        }

        public async static Task<bool> exists(DateTime date)
        {
            using (SqlConnection conn = new Connection().getConnectionApp(Section.Unidade))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = $@"SELECT 
                              	 id 
                              	,description 
                              	,day
                              	,hasBlock                                 
                              	,hasSent                                    
                              FROM [UHCDB].dbo.[Iqvia_Panel] 
                             WHERE Convert(date,day) = '{date.ToString("yyyyMMdd")}'
                        ";
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public async static Task updateHasBlock(string id)
        {
            using (SqlConnection conn = new Connection().getConnectionApp(Section.Unidade))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = $@"
                                             UPDATE [UHCDB].dbo.[Iqvia_Panel] 
                                             SET hasBlock = 
                                                            (IIF((SELECT top 1 id_panel
                                                             FROM [UHCDB].dbo.[Iqvia_DetailedBlocks] 
                                                             WHERE id_Panel = {id}) IS NOT NULL,1,0))
                                             WHERE id = {id} 
                        ";
                    Console.WriteLine(command.CommandText);
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public async static Task updateHasSent(string id)
        {
            using (SqlConnection conn = new Connection().getConnectionApp(Section.Unidade))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = $@"UPDATE [UHCDB].dbo.[Iqvia_Panel] 
                              	                SET hasSent = 1
                                             WHERE id = {id}
                        ";
                    await command.ExecuteNonQueryAsync();
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
