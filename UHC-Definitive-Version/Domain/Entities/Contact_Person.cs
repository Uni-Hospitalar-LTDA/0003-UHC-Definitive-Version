using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class Contact_Person : Querys<Contact_Person>
    {
        public string idPerson { get; set; }
        public string idContact { get; set; }
        public string name { get; set; }
        public string observation { get; set; }

        public static Task<List<Contact_Person>> getAllToListByIdAsync(string idContact)
        {
            string query = $"SELECT * FROM [UHCDB].dbo.[Contact_Person] WHERE idContact = {idContact}";
            return getAllToList(query);
        }

        public async static Task deleteAsync(Contact_Person person)
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
                                             DELETE FROM [UHCDB].dbo.[Contact_Person]                                                
                                             WHERE [idContact] = {person.idContact}
                                             and idPerson like '{person.idPerson}'
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
                    CustomNotification.defaultInformation();
                }
            }
        }

        public async static Task updateAsync(Contact_Person person)
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
                                             UPDATE [UHCDB].dbo.[Contact_Person]      
                                             SET Name = '{person.name}'
                                             ,observation = '{person.observation}'
                                             WHERE [idContact] = {person.idContact}
                                             and idPerson like '{person.idPerson}'
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
