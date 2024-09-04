using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Log
{
    public class Logs : Querys<Logs>
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Data { get; set; }
        public string TipoRegistro { get; set; }
        public string idRegistro { get; set; }
        public string idUsuario { get; set; }

        public static async new Task insertAsync(List<Logs> gens)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp("PE"))
            {
                await conn.OpenAsync();
                SqlTransaction transaction = conn.BeginTransaction();

                using (var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                {
                    bulkCopy.BatchSize = 100;
                    bulkCopy.DestinationTableName = $"{Connection.dbBase}.dbo.[{typeof(Logs).Name}]";
                    try
                    {
                        await bulkCopy.WriteToServerAsync(gens.AsDataTable());
                        Console.WriteLine(gens.AsDataTable());

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
}
