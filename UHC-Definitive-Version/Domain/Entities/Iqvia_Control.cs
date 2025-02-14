using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class Iqvia_Control : Querys<Iqvia_Control>
    {
        public string Layout_Vendas { get; set; }
        public string Layout_Produtos { get; set; }
        public string Layout_Clientes { get; set; }

        // ** Delete ** // 
        public async static Task deleteAsync()
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Section.Unidade))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = $@"delete from [UHCDB].dbo.[Iqvia_Control]";
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    conn.Close();

                }
                finally
                {
                    CustomNotification.defaultInformation();
                    conn.Close();
                }
            }

        }

        public async static Task<Iqvia_Control> getToClassAsync()
        {
            string query = @"SELECT 
                                Layout_Vendas 
                               ,Layout_Produtos
                               ,Layout_Clientes
                             FROM [UHCDB].dbo.[Iqvia_Control] ";
            return await getToClass(query);
        }
    }
}
