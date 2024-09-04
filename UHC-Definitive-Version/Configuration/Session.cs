using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Configuration
{
    public class Session
    {
        public static string idUsuario { get; private set; } = "0";
        public static DateTime HoraLogin { get; private set; } = DateTime.Now;
        public static string Unidade { get; private set; } = "XX";
        public static string CodIqvia { get; private set; } = "XXXX";
        public static string Empresa { get; private set; } = "Rec";
        public static string pdfLogo { get; private set; } = "";
        public static string logoEmail { get; private set; } = "";



        public static void add(string id, string unidade)
        {
            idUsuario = id;
            HoraLogin = DateTime.Now;
            Unidade = unidade;
            if (unidade == "PE")
            {
                CodIqvia = "";
                Empresa = "REC";
                pdfLogo = "";
                logoEmail = "";
            }
        }
        public async static Task<string> On(string user, string password, string unidade = "PE")
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp("PE"))
            {
                string result = null;
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = $@"SELECT CASE 
                                                         WHEN status = 0 THEN 'ACCESS_DENIED' 														 
														 WHEN setPassword = 1 THEN 'CHANGE_PASSWORD'
                                                         WHEN status =  1 THEN 'ACCESS_APPROVED'                                                         
                                                         END [result]
                                                     ,password
                                                     ,setPassword
                                                     ,name                                                     
                                                     from [{Connection.dbBase}].dbo.[Users] 
                                             WHERE login like '{user}'";
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            if (reader["result"].ToString() == "ACCESS_DENIED")
                            {
                                result = $"USER BLOCKED: {reader["RESULT"].ToString()}";
                                return reader["RESULT"].ToString();
                            }
                            else if (user == "admin" && reader["setPassword"].ToString() == "1")
                            {
                                result = $"USER MUST CHANGE YOUR PASSWORD: {reader["result"]}";
                                return reader["result"].ToString() + " " + reader["name"].ToString();
                            }
                            else if (reader["setPassword"].ToString() == "1" && (Cryptography.decrypt(reader["PASSWORD"].ToString()) == password))
                            {
                                result = $"USER MUST CHANGE YOUR PASSWORD: {reader["result"]}";
                                return reader["result"].ToString() + " " + reader["name"].ToString();
                            }
                            else if (reader["setPassword"].ToString() == "0" && Cryptography.decrypt(reader["PASSWORD"].ToString()) == password)
                            {
                                result = $"LOGIN ACEPTED: {reader["result"]}";
                                return reader["RESULT"].ToString() + " " + reader["name"].ToString();
                            }
                            else
                            {
                                result = "ERROR: WRONG_PASSWORD";
                                return "WRONG_PASSWORD";
                            }
                        }
                    }
                    result = "USER NOT EXISTS: NOT_EXIST";
                    return "NOT_EXIST";
                }
                catch (SqlException ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    return null;
                }
            }

        }
    }
}
