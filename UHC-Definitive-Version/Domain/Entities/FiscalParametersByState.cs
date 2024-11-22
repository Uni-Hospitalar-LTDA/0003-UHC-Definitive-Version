using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain
{
    public class FiscalParametersByState : Querys<FiscalParametersByState>
    {
        public string idIBGE_State { get; set; }
        public string diferencialICMS { get; set; }
        public string idUser { get; set; }
        public string modifiedDate { get; set; }



        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"
                                SELECT  idIBGE [Cód. IBGE]
                                        ,UF
                                		,description [Descrição]
                                		,region  [Região]
                                		,diferencialICMS [Dif. Alíquota]
                                		FROM 
                                uhcdb.dbo.FiscalParametersByState
                                JOIN UHCDB.DBO.State on idIBGE = idIBGE_State
                                ORDER BY description asc";
            return await getAllToDataTable(query);
        }

        public static async Task<List<FiscalParametersByState>> getAllToListAsync()
        {
            string query = $@"
                                SELECT  *
                                		FROM 
                                [UHCDB].dbo.[{getClassName()}] ";
            return await getAllToList(query);
        }
        public async static Task deleteAllAsync(string id)
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
                    command.CommandText = $@" DELETE FROM [UHCDB].dbo.[{getClassName()}] where idIBGE_State = {id} "; await command.ExecuteNonQueryAsync();
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
