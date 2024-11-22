using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Configuration
{
    public class Iqvia_LineBlock : Querys<Iqvia_LineBlock>
    {
        public string indexColumn { get; set; }
        public string id_Panel { get; set; }
        public string codCliente { get; set; }
        public string codProduto { get; set; }
        public string qtdProduto { get; set; }
        public string Num_Nota { get; set; }

        public async static Task deleteAsync(string id)
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


                    command.CommandText = $@"DELETE FROM [UHCDB].dbo.[Iqvia_LineBlock]                                                
                                             WHERE [id_Panel] = {id}
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
