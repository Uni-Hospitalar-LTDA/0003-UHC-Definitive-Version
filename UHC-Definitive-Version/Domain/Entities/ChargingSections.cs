using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class ChargingSections : Querys<ChargingSections>
    {
        public string DueDateNotification { get; set; }

        public static async Task<ChargingSections> getClassAsync()
        {
            string query = $@" SELECT * FROM [UHCDB].dbo.[ChargingSections] ";
            return await getToClass(query);
        }
        public static async Task deleteAsync()
        {
            string query = " DELETE FROM [UHCDB].dbo.[ChargingSections] ";

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
