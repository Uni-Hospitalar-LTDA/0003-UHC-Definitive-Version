using UHC3_Definitive_Version.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities.CI
{
    public class CI_FollowUp : Querys<CI_FollowUp>
    {
        public string id { get; set; }
        public string description { get; set; }
        public string observation { get; set; }        
        public string status { get; set; }
        public string dateCreated { get; set; }
        public string dateEdited { get; set; }
        public string idUser { get; set; }

        public static async Task<DataTable> getAllToDataTableAsync(string genericDescription, string status)
        {
            string query = $@"SELECT Id
                             ,Description [Descrição]                             
                             ,[Status] =
                                CASE STATUS
                                    WHEN 1 THEN 'Ativo'
                                    WHEN 0 THEN 'Inativo'
                                END
                    FROM [UHCDB].dbo.[{getClassName()}]
                              WHERE (CONVERT(VARCHAR,id) = '{genericDescription}' OR description LIKE '%{genericDescription}%') 
                              and Status IN ({status}) ";

            return await getAllToDataTable(query);
        }
        public static async Task<CI_FollowUp> getToClassAsync(string id)
        {
            string query = $"SELECT * FROM [UHCDB].dbo.[{getClassName()}] WHERE id = {id}";
            Console.WriteLine(query);
            return await getToClass(query);
        }
        public async static Task<string> updateAsync(CI_FollowUp followup)
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


                    {
                        command.CommandText = $@"UPDATE [UHCDB].dbo.[{getClassName()}]
                                              SET [description] = '{followup.description}'
                                                 ,[observation] = '{followup.observation}'                                                 
                                                 ,[status] = {followup.status}
                                                 ,[dateEdited] = '{followup.dateEdited}'                                             
                                                 ,[idUser] = {Section.idUsuario}
                                            WHERE [id] =  {followup.id}";
                    }


                    await command.ExecuteNonQueryAsync();
                    return null;
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    transaction.Rollback();
                    conn.Close();
                    return "error";
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
