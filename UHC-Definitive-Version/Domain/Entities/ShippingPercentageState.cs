using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class ShippingPercentageState : Querys<ShippingPercentageState>
    {
        //Criar no banco de dados
        public string idTransporter { get; set; }
        public string uf { get; set; }
        public string capitalPercentage { get; set; }
        public string capitalMinPrice { get; set; }
        public string inlandPercentage { get; set; }
        public string inlandMinPrice { get; set; }


        public async static Task<List<ShippingPercentageState>> getAllToListByCodeAsync(string idTransporter)
        {
            string query = $"SELECT * FROM [UHCDB].dbo.[ShippingPercentageState] WHERE idTransporter = {idTransporter} ORDER BY UF ASC";
            return await getAllToList(query);
        }

        public async static Task<bool> exist(string idTransporter)
        {
            string query = $"SELECT TOP 1 * FROM [UHCDB].dbo.[ShippingPercentageState] WHERE idTransporter = {idTransporter}";
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
                                             DELETE FROM [UHCDB].dbo.[ShippingPercentageState]                                                
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
