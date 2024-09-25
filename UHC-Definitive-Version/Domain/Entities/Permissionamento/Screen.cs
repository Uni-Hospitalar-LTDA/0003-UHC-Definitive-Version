using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.Permissionamento
{
    public class Screen : Querys<Screen>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string idSubModule { get; set; }

        /** GETS **/
        public static async Task<Screen> getToClassAsync(string id)
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}]
                                WHERE id = {id}";
            return await getToClass(query);
        }
        public static async Task<List<Screen>> getAllToListAsync()
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}]";
            return await getAllToList(query);
        }
        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT 
	                             {getClassName()}.Id [Id]
	                            ,{getClassName()}.Name [Nome]
	                            ,SubModule.Description [Mãe]
	                            ,{getClassName()}.Description [Observação]	
                             FROM [{Connection.dbBase}].dbo.[{getClassName()}]
                             JOIN [{Connection.dbBase}].dbo.SubModule ON SubModule.Id = {getClassName()}.idSubModule";

            return await getAllToDataTable(query);
        }
        public async static Task<List<Screen>> getAllowedAsync(string idUsers)
        {
            string query = $@"SELECT Screen.id, Screen.name, Screen.description, Screen.idSubModule
                              FROM [{Connection.dbBase}].dbo.[Groups]
                              JOIN [{Connection.dbBase}].dbo.[Users_Groups] ON  Users_Groups.idGroups = Groups.id
                              JOIN [{Connection.dbBase}].dbo.[Groups_Screen] ON Groups_Screen.idGroups = Groups.id
                              JOIN [{Connection.dbBase}].dbo.[Screen] ON Screen.id = Groups_Screen.idScreen
                              WHERE idUSers = {idUsers}";
            return await getAllToList(query);
        }
        /** UPDATES **/
        public static async Task updateAsync(Screen screen)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp("UNI HOSPITALAR"))
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
                                SET  [name] = '{screen.Name}'
                                    ,[description] = '{screen.Description}'
                                WHERE [id] = {screen.Id}";

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
