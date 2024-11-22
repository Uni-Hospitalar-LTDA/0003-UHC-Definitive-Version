using UHC3_Definitive_Version.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities.CI
{
    public class CI_Itens : Querys<CI_Itens>
    {
        public string idCI_Header { get; set; }
        public string idProduct { get; set; }
        public string arrivalQuantity { get; set; }
        public string remainingQuantity { get; set; }
        public string dateEdited { get; set; }
        public string idUser { get; set; }

        public async static Task<string> getProductQuantityAsync(string NFs, string productId)
        {
            using (SqlConnection conn = new Connection().getConnectionApp(Section.Unidade))
            {
                string code = null;
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = $@"SELECT 
	SUM(Qtd_Produto) Qtd
FROM DMD.dbo.NFSIT NF_Saida_Itens 
JOIN DMD.dbo.NFSCB NF_Saida ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
WHERE NF_Saida.Num_Nota IN ({NFs}) 
  AND NF_Saida_Itens.Cod_Produto = {productId}";

                    Console.WriteLine(command.CommandText);
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        code = reader["Qtd"].ToString();
                    }
                    return code;
                }
                catch
                {
                    return "0";
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public async static Task<DataTable> getAllToDataTableAsync(string idCI)
        {
            string query = $@" SELECT 
                                	 Product.Codigo [Cód. Produto]
                                	,Product.Descricao [Produto]
                                	,arrivalQuantity [Entregues]
                                	,remainingQuantity [Restante]
                                FROM [UHCDB].dbo.[CI_Itens] Itens
                                JOIN [DMD].dbo.[PRODU] Product ON Product.Codigo = Itens.idProduct
                                WHERE idCI_Header = {idCI}";
            return await getAllToDataTable(query);

        }

        public async static Task<List<CI_Itens>> getAllToListByIdAsync(string idCI )
        {
            string query = $@"SELECT * FROM [UHCDB].dbo.[{getClassName()}] WHERE idCI_Header = {idCI}";
            return await getAllToList(query);
        }

        public async static Task updateAsync(List<CI_Itens> Itens )
        {
            foreach (var product in Itens)
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
                            command.CommandText = $@"UPDATE [UHCDB].dbo.[{getClassName()}]
                                              SET [arrivalQuantity] = '{product.arrivalQuantity}'
                                                 ,[remainingQuantity] = {product.remainingQuantity}                                                 
                                                 ,[dateEdited] = getdate()
                                                 ,[idUser] = {Section.idUsuario}
                                            WHERE [idCI_Header] =  {product.idCI_Header}
                                            AND idProduct = {product.idProduct}";
                        }


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
}
