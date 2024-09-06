using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.Permissionamento
{
    public class Action : Querys<Action>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string idScreen { get; set; }

        /** GETS **/
        public static async Task<Action> getToClassAsync(string id)
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}]
                                WHERE id = {id}";
            return await getToClass(query);
        }
        public static async Task<List<Action>> getAllToListAsync()
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}]";
            return await getAllToList(query);
        }
        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT 
	                             {getClassName()}.Id [Id]
	                            ,{getClassName()}.Name [Nome]
	                            ,Action.Description [Mãe]
	                            ,{getClassName()}.Description [Observação]	
                             FROM [{Connection.dbBase}].dbo.[{getClassName()}]
                             JOIN [{Connection.dbBase}].dbo.Action ON Action.Id = {getClassName()}.idAction";

            return await getAllToDataTable(query);
        }
        public async static Task<List<Action>> getAllowedAsync(string idUsers)
        {
            string query = $@"SELECT Action.id, Action.name, Action.description,Action.idScreen
                            FROM [{Connection.dbBase}].dbo.[Groups]
                            JOIN [{Connection.dbBase}].dbo.[Users_Groups] ON  Users_Groups.idGroups = Groups.id
                            JOIN [{Connection.dbBase}].dbo.[Groups_Action] ON Groups_Action.idGroups = Groups.id
                            JOIN [{Connection.dbBase}].dbo.[Action] ON Action.id = Groups_Action.idAction
                            WHERE idUSers = {idUsers}";
            return await getAllToList(query);
        }
        /** UPDATES **/
        public static async Task updateAsync(Action action)
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
                                SET  [name] = '{action.Name}'
                                    ,[description] = '{action.Description}'
                                WHERE [id] = {action.Id}";

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
