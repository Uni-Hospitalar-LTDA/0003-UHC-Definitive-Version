using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class MonitorGnre : Querys<MonitorGnre>
    {
        public string num_Nota { get; set; }
        public string Data_Bloqueio { get; set; }
        public string Data_Exportacao { get; set; }
        public string flg_BloqExport { get; set; } = "0";
        public string Observacao { get; set; }
        public string idUsers { get; set; } = "0";

        /** GETS **/
        public static async Task<MonitorGnre> getToClassAsync(string numNota)
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{getClassName()}]
                              WHERE num_Nota = {numNota}";
            return await getToClass(query);
        }
        public static async Task<string> getEstadoAsync(string uf)
        {
            if (uf.Length == 2)
            {
                string query = $@"SELECT DESCRICAO FROM {Connection.dbDMD}.DBO.ESTAD
WHERE Codigo LIKE '{uf}' ";
                DataTable dt = await getAllToDataTable(query);

                return dt.Rows[0][0].ToString();
            }
            return null;

        }



        /** Updates **/

        public static async Task updateBloqueioAsync(MonitorGnre gnre)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Section.Unidade))
            {
                SqlTransaction transaction = null;
                try
                {
                    await conn.OpenAsync();
                    transaction = conn.BeginTransaction();
                    SqlCommand command = conn.CreateCommand();
                    command.Transaction = transaction; // associa a transação com o comando
                    command.CommandText =
$@" UPDATE [{Connection.dbBase}].dbo.[{getClassName()}] 
    SET  Data_Bloqueio = Getdate()
        ,Observacao = '{gnre.Observacao}' 
        ,flg_BloqExport = {gnre.flg_BloqExport}
        ,idUsers = {Section.idUsuario}
    WHERE num_nota = {gnre.num_Nota}";
                    await command.ExecuteNonQueryAsync();
                    transaction.Commit(); // commit da transação após sucesso do comando
                    //CustomNotification.defaultInformation();
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    if (transaction != null)
                    {
                        transaction.Dispose(); // libera a transação
                    }
                    conn.Close();
                }
            }
        }
        public static async Task updateManualAsync(MonitorGnre gnre)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Section.Unidade))
            {
                SqlTransaction transaction = null;
                try
                {
                    await conn.OpenAsync();
                    transaction = conn.BeginTransaction();
                    SqlCommand command = conn.CreateCommand();
                    command.Transaction = transaction; // associa a transação com o comando
                    command.CommandText =
$@" UPDATE [{Connection.dbBase}].dbo.[{getClassName()}] 
    SET  Data_Exportacao = Getdate()
        ,Observacao = '{gnre.Observacao}' 
        ,idUsers = {Section.idUsuario}
    WHERE num_nota = {gnre.num_Nota}";
                    await command.ExecuteNonQueryAsync();
                    transaction.Commit(); // commit da transação após sucesso do comando
                    //CustomNotification.defaultInformation();
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    if (transaction != null)
                    {
                        transaction.Dispose(); // libera a transação
                    }
                    conn.Close();
                }
            }
        }

        public static async Task desbloquearAsync(string NF)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Section.Unidade))
            {
                SqlTransaction transaction = null;
                try
                {
                    await conn.OpenAsync();
                    transaction = conn.BeginTransaction();
                    SqlCommand command = conn.CreateCommand();
                    command.Transaction = transaction; // associa a transação com o comando
                    command.CommandText = $@"UPDATE 
[{Connection.dbBase}].dbo.[{getClassName()}] SET flg_BloqExport = 0
, Data_Bloqueio = Getdate()
, idUsers = '{Section.idUsuario}' WHERE num_nota = {NF}";
                    await command.ExecuteNonQueryAsync();
                    transaction.Commit(); // commit da transação após sucesso do comando
                    CustomNotification.defaultInformation();
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    if (transaction != null)
                    {
                        transaction.Dispose(); // libera a transação
                    }
                    conn.Close();
                }
            }
        }
        public static async Task reiniciarAsync(string NF)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Section.Unidade))
            {
                SqlTransaction transaction = null;
                try
                {
                    await conn.OpenAsync();
                    transaction = conn.BeginTransaction();
                    SqlCommand command = conn.CreateCommand();
                    command.Transaction = transaction; // associa a transação com o comando
                    command.CommandText = $@"UPDATE 
[{Connection.dbBase}].dbo.[{getClassName()}] SET flg_BloqExport = 0
, Data_Exportacao = null
, idUsers = '{Section.idUsuario}' WHERE num_nota = {NF}";
                    await command.ExecuteNonQueryAsync();
                    transaction.Commit(); // commit da transação após sucesso do comando
                    //CustomNotification.defaultInformation();
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    if (transaction != null)
                    {
                        transaction.Dispose(); // libera a transação
                    }
                    conn.Close();
                }
            }
        }
    }
}
