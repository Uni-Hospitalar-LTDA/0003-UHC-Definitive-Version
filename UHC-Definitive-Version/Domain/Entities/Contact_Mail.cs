using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class Contact_Mail : Querys<Contact_Mail>
    {
        public string idMail { get; set; }
        public string idContact { get; set; }
        public string mail { get; set; }
        public string observation { get; set; }

        public static Task<List<Contact_Mail>> getAllToListByTransporterAsync(string idTransporter)
        {
            string query = $@"SELECT Mail.* FROM [UHCDB].dbo.[Contact_Mail] Mail
JOIN [UHCDB].dbo.[Contact] ON Contact.idContact = Mail.idContact
JOIN [UHCDB].dbo.[Transporter_Contact] TC ON TC.idContact = Contact.idContact
WHERE TC.Cod_Transportador = {idTransporter}";
            return getAllToList(query);
        }
        public static Task<List<Contact_Mail>> getAllToListByIdAsync(string idContact)
        {
            string query = $"SELECT * FROM [UHCDB].dbo.[Contact_Mail] WHERE idContact = {idContact}";
            return getAllToList(query);
        }

        public async static Task deleteAsync(Contact_Mail mail)
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
                                             DELETE FROM [UHCDB].dbo.[Contact_Mail]                                                
                                             WHERE [idContact] = {mail.idContact}
                                             AND idMail like '{mail.idMail}'

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

        public async static Task updateAsync(Contact_Mail mail)
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
                                             UPDATE [UHCDB].dbo.[Contact_Mail]                                                
                                             SET mail = '{mail.mail}'
                                             ,observation = '{mail.observation}'
                                             WHERE [idContact] = {mail.idContact}
                                             AND idMail like '{mail.idMail}'

"; Console.WriteLine(command.CommandText);
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
    }
}
