using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.Entities.CI
{
    public class CI_Finances_Obs : Querys<CI_Finances_Obs>
    {
        public string idCI_Header { get; set; }
        public string observation { get; set; }
        public string dateModified { get; set; }
        public string idUser { get; set; }

        public static async Task<CI_Finances_Obs> getToClassAsync(string id)
        {
            string query = $@"SELECT * FROM UHCDB.dbo.{getClassName()} WHERE idCI_Header = {id}";
            return await getToClass(query);
        }
        public async static Task<string> deleteAsync(string id)
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


                    {
                        command.CommandText = $@"DELETE FROM [UHCDB].dbo.[{getClassName()}]                                               
                                                WHERE [idCI_Header] =  {id}";
                    }


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
                }
            }
        }
    }
}
