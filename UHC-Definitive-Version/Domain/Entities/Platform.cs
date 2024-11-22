using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class Platform : Querys<Platform>
    {
        public string id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string description { get; set; }


        /** GETS **/
        public async static Task<DataTable> getToDataTableAsync(string name)
        {
            string query =
                $@"SELECT 
                   	     id [Código]
                   	    ,name [Nome]
                   	    ,link [Link]
                   FROM [UHCDB].dbo.[Platform]
                   WHERE name like  '%{name}%' ";

            return await getAllToDataTable(query);
        }
        public async static Task<List<Platform>> getAllToListAsync()
        {
            string query = "SELECT * FROM [UHCDB].dbo.[Platform]";
            return await getAllToList(query);
        }
        public async static Task<Platform> getToClassAsync(string id)
        {
            string query =
                $@"SELECT 
                   	    *
                   FROM [UHCDB].dbo.[Platform]
                   WHERE id  = {id} ";
            Console.WriteLine(query);

            return await getToClass(query);
        }

        /** SET **/
        public async static Task<string> updateMultiUnityAsync(Platform platform, string unidade)
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

                    command.CommandText = $@"UPDATE [UHCDB].dbo.[Platform]
                                            SET 	 
                                            	name = '{platform.name}'
                                            	,link = '{platform.link}'
                                            	,description = '{platform.description}'
                                            WHERE [id] = {platform.id}";

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
                    //CustomMessage.Sucess();
                }
            }
        }

        /** Validations **/
        public async static Task<bool> isValidName(string name, string id)
        {
            using (SqlConnection conn = new Connection().getConnectionApp(Section.Unidade))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();

                    command.CommandText = $@"select id from [UHCDB].dbo.[Platform]
                                             WHERE NAME LIKE '{name}' AND id != {id}";
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            return false;
                        }
                    }

                    return true;

                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    return false;
                }
            }
        }
        public async static Task<bool> isValidLink(string link, string id)
        {
            using (SqlConnection conn = new Connection().getConnectionApp(Section.Unidade))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();

                    command.CommandText = $@"select id from [UHCDB].dbo.[Platform]
                                             WHERE link LIKE '{link}' AND id != {id}";
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            return false;
                        }
                    }

                    return true;

                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    return false;
                }
            }
        }
    }
}
