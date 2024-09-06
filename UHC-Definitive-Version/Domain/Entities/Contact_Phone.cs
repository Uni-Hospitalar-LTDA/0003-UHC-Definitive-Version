using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class Contact_Phone : Querys<Contact_Phone>
    {
        public string idPhone { get; set; }
        public string idContact { get; set; }
        public string phone { get; set; }
        public string observation { get; set; }

        public static async Task<List<Contact_Phone>> getAllToListByIdAsync(string id)
        {
            string query = $"SELECT * FROM [UHCDB].dbo.[Contact_Phone] WHERE idContact = {id}";

            return await getAllToList(query);
        }

        public async static Task updateAsync(Contact_Phone phone)
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


                    command.CommandText = $@"
                                             UPDATE [UHCDB].dbo.[Contact_Phone]                                                
                                             SET Phone = '{phone.phone}'
                                             , observation = '{phone.observation}'
                                             WHERE [idContact] = {phone.idContact}
                                             AND idPhone like '{phone.idPhone}'
";
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
        public async static Task deleteAsync(Contact_Phone phone)
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


                    command.CommandText = $@"
                                             DELETE FROM [UHCDB].dbo.[Contact_Phone]                                                
                                             WHERE [idContact] = {phone.idContact}
                                             AND idPhone like '{phone.idPhone}'
";
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
