using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class ProcessScheduleJustify : Querys<ProcessScheduleJustify>
    {
        public string id { get; set; }
        public string description { get; set; }

        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = "SELECT id,description [Justificativa] FROM [UHCDB].dbo.[ProcessScheduleJustify] ";
            return await getAllToDataTable(query);
        }

        public async static Task<string> updateAsync(ProcessScheduleJustify justify, string unidade)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(unidade))
            {
                SqlTransaction transaction = null;
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    transaction = conn.BeginTransaction();
                    command.Connection = conn;
                    command.Transaction = transaction;


                    string query =

                        command.CommandText = $@"UPDATE [UHCDB].dbo.[ProcessScheduleJustify]
   SET [description] = '{justify.description}'      
    WHERE id = {justify.id}";


                    Console.WriteLine(query);
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
        public async static Task<string> deleteAsync(ProcessScheduleJustify justify, string unidade)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(unidade))
            {
                SqlTransaction transaction = null;
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    transaction = conn.BeginTransaction();
                    command.Connection = conn;
                    command.Transaction = transaction;


                    string query =

                        command.CommandText = $@"DELETE FROM [UHCDB].dbo.[ProcessScheduleJustify]   
                                                 WHERE id = {justify.id}";


                    Console.WriteLine(query);
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

        public async static Task<ProcessScheduleJustify> getToClassAsync(string id)
        {
            string query = $"SELECT * FROM [UHCDB].dbo.[ProcessScheduleJustify] WHERE id = {id}";
            return await getToClass(query);
        }
    }
}
