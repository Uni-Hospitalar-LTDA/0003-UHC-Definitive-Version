using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class Customer_Contact : Querys<Customer_Contact>
    {

        public string idContact { get; set; }
        public string Cod_Cliente { get; set; }


        public async Task<List<Customer_Contact>> getAllToListAsync(string idCustomer)
        {
            string query = $"SELECT * FROM [UHCDB].dbo.[Customer_Contact] WHERE Cod_Cliente = {idCustomer}";
            return await getAllToList(query);
        }

        public async static Task deleteAsync(string idCustomer)
        {
            string query = $"DELETE FROM [UHCDB].dbo.[Customer_Contact] WHERE Cod_Cliente = {idCustomer}";

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
                    command.CommandText = query;
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
