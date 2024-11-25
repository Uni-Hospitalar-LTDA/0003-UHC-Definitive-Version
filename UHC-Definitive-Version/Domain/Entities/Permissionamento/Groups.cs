using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.Permissionamento
{
    public class Groups : Querys<Groups>
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }


        /** GETS **/
        public async static Task<object> getAllToDataTableAsync(string filter, string status)
        {
            string query = $@"SELECT 
                                	 G.Id	
                                	,G.Name [Nome]	
                                    ,[Qtd. Integrantes] = ISNULL(COUNT (UG.idUsers),0)
                                	,[Status] = CASE G.Status WHEN 1 THEN 'Ativo' ELSE 'Inativo' END 	
                                FROM [{Connection.dbBase}].dbo.[{getClassName()}]  G
                                LEFT JOIN [{Connection.dbBase}].dbo.[Users_Groups] UG ON UG.idGroups = G.Id
                                WHERE 
                                (CONVERT(VARCHAR,G.Id) = '{filter}' OR G.name LIKE '%{filter}%') AND G.Status IN ({status})
                                
                                GROUP BY
                                G.Id	
                                ,G.Name
                                ,G.Status";
            Console.WriteLine(query);
            return await getAllToDataTable(query);
        }
        public async static Task<Groups> getToClassAsync(string idGroup)
        {
            string query = $@"SELECT * 
                              FROM [{Connection.dbBase}].dbo.[{getClassName()}] 
                              WHERE id = {idGroup}
                            ";
            return await getToClass(query);
        }

        /** UPDATES **/
        public async static Task updateAsync(Groups group)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Section.Unidade))
            {
                SqlTransaction transaction = null;
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    transaction = conn.BeginTransaction();
                    command.Connection = conn;
                    command.Transaction = transaction;


                    command.CommandText = $@"UPDATE [{Connection.dbBase}].dbo.[{getClassName()}]                                                
                                             SET Name = '{group.name}'
                                           	,Description = '{group.description}'
                                           	,Status = '{group.status}'
                                           WHERE [id] =  {group.id}";
                    await command.ExecuteNonQueryAsync();

                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    transaction.Rollback();
                    conn.Close();
                }
                finally
                {
                    transaction.Commit();
                    conn.Close();
                }
            }
        }
    }
}
