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
    public class Iqvia_DetailedBlocks : Querys<Iqvia_DetailedBlocks>
    {
        public string id_Panel { get; set; }
        public string TypeBlock { get; set; }
        public string external_Code { get; set; }

        public string cod_Cliente { get; set; }
        public string cod_Produto { get; set; }
        public string qtd_Produto { get; set; }
        public string indexColumn { get; set; }

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


                    command.CommandText = $@"DELETE FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]                                                
                                             WHERE [id_Panel] =  {id}";
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

        public async static Task deleteLineBlockAsync(string id)
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


                    command.CommandText = $@"DELETE FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]                                                
                                             WHERE [id_Panel] IN ({id}-1,{id}-2,{id}) and (TypeBlock = 'L' OR indexColumn = -1)                                             
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


        //** GETS **//
        public async static Task<List<Iqvia_DetailedBlocks>> getAllToListAsync(string id)
        {
            string query = $@"SELECT 
                                id_Panel
                                ,TypeBlock
                                ,external_Code
                                ,cod_Cliente
                                ,cod_Produto
                                ,qtd_Produto
                                ,indexColumn
                                FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
                                WHERE 
                                id_Panel = '{id}'";
            return await getAllToList(query);
        }

    }
}
