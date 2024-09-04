using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.Permissionamento
{
    public class SubModule : Querys<SubModule>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string idModule { get; set; }

        /** GETS **/
        public static async Task<SubModule> getToClassAsync(string id)
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}]
                                WHERE id = {id}";
            return await getToClass(query);
        }
        public static async Task<List<SubModule>> getAllToListAsync()
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}]";
            return await getAllToList(query);
        }
        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT 
	                             {getClassName()}.Id [Id]
	                            ,{getClassName()}.Name [Nome]
	                            ,Module.Description [Mãe]
	                            ,{getClassName()}.Description [Observação]	
                             FROM [{Connection.dbBase}].dbo.[{getClassName()}]
                             JOIN [{Connection.dbBase}].dbo.Module ON Module.Id = {getClassName()}.idModule";
            return await getAllToDataTable(query);
        }

        public async static Task<List<SubModule>> getAllowedAsync(string idUsers)
        {
            string query = $@"SELECT SubModule.id, SubModule.name, SubModule.description , SubModule.idModule
                              FROM [{Connection.dbBase}].dbo.[Groups]
                              JOIN [{Connection.dbBase}].dbo.[Users_Groups] ON  Users_Groups.idGroups = Groups.id
                              JOIN [{Connection.dbBase}].dbo.[Groups_SubModule] ON Groups_SubModule.idGroups = Groups.id
                              JOIN [{Connection.dbBase}].dbo.[SubModule] ON SubModule.id = Groups_SubModule.idSubModule
                              WHERE idUSers = {idUsers}";
            return await getAllToList(query);
        }

        /** UPDATES **/
        public static async Task updateAsync(SubModule subModule)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp("PE"))
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
                                SET  [name] = '{subModule.Name}'
                                    ,[description] = '{subModule.Description}'
                                WHERE [id] = {subModule.Id}";

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
