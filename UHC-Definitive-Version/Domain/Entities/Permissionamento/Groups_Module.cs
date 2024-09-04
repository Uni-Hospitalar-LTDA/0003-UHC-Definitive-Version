using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.Permissionamento
{
    public class Groups_Module : Querys<Groups_Module>
    {
        public string idGroups { get; set; }
        public string idModule { get; set; }

        /** GETS **/
        public async static Task<List<Groups_Module>> getByGroupAsync(string idGroup)
        {
            string query = $"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}] WHERE idGroups = {idGroup}";

            return await getAllToList(query);
        }

        /** Delete **/
        public async static Task deleteByGroupAsync(string idGroup)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Session.Unidade))
            {
                SqlTransaction transaction = null;
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    transaction = conn.BeginTransaction();
                    command.Connection = conn;
                    command.Transaction = transaction;


                    command.CommandText = $@"DELETE FROM [{Connection.dbBase}].dbo.[{getClassName()}]                                                
                                             WHERE [idGroups] =  {idGroup}";
                    Console.WriteLine(command.CommandText);
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
