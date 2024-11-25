using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class Contact : Querys<Contact>
    {
        public string idContact { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string linkedAt { get; set; }

        public static async Task<DataTable> getAllToDataTableByTypeAsync(string type)
        {
            string query = $@"
               SELECT
                     Contact.idContact [Cód. Contato]
                    ,Contact.name [Contato]
                    ,Contact.description [Description]
                    ,CASE Contact.linkedAt
                     WHEN 'Transporter' THEN 'Contato de Transportador' 
                     WHEN 'Customer' THEN 'Contato de Cliente'
                     END [Tipo]
                    ,[Telefones] = count(Phone.idPhone)
					,[Emails] = count(Mail.idMail)
					,[Pessoas] = count(Person.idPerson)
FROM [UHCDB].dbo.[Contact]
LEFT JOIN [UHCDB].dbo.[Contact_Phone] Phone on Phone.idContact = Contact.idContact
LEFT JOIN [UHCDB].dbo.[Contact_Mail] Mail on Mail.idContact = Contact.idContact
LEFT JOIN [UHCDB].dbo.[Contact_Person] Person on Person.idContact = contact.idContact                
WHERE linkedAt LIKE '{type}'
GROUP BY 
  Contact.idContact
 ,Contact.name
 ,Contact.description
 ,Contact.linkedAt
                ";


            return await getAllToDataTable(query);
        }
        public static async Task<List<Contact>> getAllToListByCodeAsync(string idContact)
        {
            string query = $@"SELECT * FROM [UHCDB].dbo.[Contact] where idContact = {idContact}";
            return await getAllToList(query);
        }

        public static async Task<List<Contact>> getAllToListTransporterByCodeAsync(string idTransporter)
        {
            string query = $@"SELECT Contact.* FROM [UHCDB].dbo.[Contact] JOIN [UHCDB].dbo.[Transporter_Contact] TC ON TC.idContact = Contact.idContact where Cod_Transportador = {idTransporter}";
            return await getAllToList(query);
        }

        public static async Task<List<Contact>> getAllToListCustomerByCodeAsync(string idCustomer)
        {
            string query = $@"SELECT Contact.* FROM [UHCDB].dbo.[Contact] 
                              JOIN [UHCDB].dbo.[Customer_Contact] CC ON CC.idContact = Contact.idContact 
                              where Cod_Cliente = {idCustomer}";

            return await getAllToList(query);
        }

        public async static Task<Contact> getToClassAsync(string id)
        {
            string query = $"SELECT * FROM [UHCDB].dbo.[Contact] WHERE idContact = {id}";
            return await getToClass(query);
        }



        public async static Task updateAsync(Contact contact)
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
                                             UPDATE [UHCDB].dbo.[Contact]       
                                             SET name = '{contact.name}'
                                             ,description = '{contact.description}'
                                             WHERE [idContact] = {contact.idContact}
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
    }
}
