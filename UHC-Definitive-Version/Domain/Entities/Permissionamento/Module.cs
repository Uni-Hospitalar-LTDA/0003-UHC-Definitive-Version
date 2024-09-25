using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.Permissionamento
{
    public class Module : Querys<Module>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }



        /** GETS **/
        public static async Task<Module> getToClassAsync(string id)
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}]
                                WHERE id = {id}";
            return await getToClass(query);
        }
        public static async Task<List<Module>> getAllToListAsync()
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}]";
            return await getAllToList(query);
        }
        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT 
	                             Id [Id]
	                            ,Name [Nome]
	                            ,Description [Observação]
                             FROM [{Connection.dbBase}].dbo.[{getClassName()}]";

            return await getAllToDataTable(query);
        }
        public static async Task<List<Module>> getAllowedAsync(string idUsers)
        {
            string query = $@"SELECT module.id,module.name,module.description
                              FROM [{Connection.dbBase}].dbo.[Groups]
                              JOIN [{Connection.dbBase}].dbo.[Users_Groups] ON  Users_Groups.idGroups = Groups.id
                              JOIN [{Connection.dbBase}].dbo.[Groups_Module] ON Groups_Module.idGroups = Groups.id
                              JOIN [{Connection.dbBase}].dbo.[Module] ON Module.id = Groups_Module.idModule
                              WHERE idUsers = {idUsers}";
            Console.WriteLine(query);
            return await getAllToList(query);
        }


        /** UPDATES **/
        public static async Task updateAsync(Module module)
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
                                SET  [name] = '{module.Name}'
                                    ,[description] = '{module.Description}'
                                WHERE [id] = {module.Id}";

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
