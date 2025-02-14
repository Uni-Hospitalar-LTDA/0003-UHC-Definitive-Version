using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class ShippingPercentageCity : Querys<ShippingPercentageCity>
    {
        public string idTransporter { get; set; }
        public string idIbge_City { get; set; }
        public string cityPercentage { get; set; }
        public string cityMinValue { get; set; }

        public async static Task<List<ShippingPercentageCity>> getAllToListByCodeAsync(string idTransporter)
        {
            string query = $"SELECT * FROM [UHCDB].dbo.[ShippingPercentageCity] WHERE idTransporter = {idTransporter} ORDER BY idIbge_City ASC";
            return await getAllToList(query);
        }

        public async static Task<bool> exist(string idTransporter)
        {
            string query = $"SELECT TOP 1 * FROM [UHCDB].dbo.[ShippingPercentageCity] WHERE idTransporter = {idTransporter}";
            var shipping = (await getToClass(query));
            if (shipping != null)
                return true;
            else
                return false;
        }

        public async static Task deleteAsync(string idTransporter)
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
                                             DELETE FROM [UHCDB].dbo.[ShippingPercentageCity]                                                
                                             WHERE [idTransporter] = {idTransporter}";

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
