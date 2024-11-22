using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.Permissionamento
{
    public class Groups_Action : Querys<Groups_Action>
    {
        public string idGroups { get; set; }
        public string idAction { get; set; }

        /** GETS **/
        public async static Task<List<Groups_Action>> getByGroupAsync(string idGroup)
        {
            string query = $"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}] WHERE idGroups = {idGroup}";

            return await getAllToList(query);
        }

        /** Delete **/
        public async static Task deleteByGroupAsync(string idGroup)
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


                    command.CommandText = $@"DELETE FROM [{Connection.dbBase}].dbo.[{getClassName()}]                                                
                                             WHERE [idGroups] =  {idGroup}";
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
