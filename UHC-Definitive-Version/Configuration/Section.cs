using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.Configuration
{
    public class Section
    {
        public static string idUsuario { get; set; } = "0";
        public static DateTime HoraLogin { get; set; } = DateTime.Now;
        public static string Unidade { get; set; } = "UNI HOSPITALAR";
        public static string CodIqvia { get; set; } = "XXXX";
        public static string Empresa { get; set; } = "Uni Hospitalar";
        public static string pdfLogo { get; set; } = "";
        public static string logoEmail { get; set; } = "";

        public static async Task carregar_Dependencias()
        {
            var tasks = new List<Task>();
            tasks.Add(Clientes_Externos.carregarAsync());
            tasks.Add(Fabricantes_Externos.carregarAsync());
            tasks.Add(Produtos_Externos.carregarAsync());
            Email.getMailCredentials();
            await Task.WhenAll(tasks.ToArray());
        }
     


        public static void add(string id, string unidade)
        {            
            idUsuario = id;
            HoraLogin = DateTime.Now;
            Unidade = unidade;
            if (unidade == "UNI HOSPITALAR")
            {
                CodIqvia = "5295";
                Empresa = "Uni Hospitalar LTDA";
                pdfLogo = "logo_UNI_Hospitalar";
                logoEmail = "https://i.imgur.com/CTeGKCP.png";
            }
            else if (unidade == "UNI CEARÁ")
            {
                CodIqvia = "0638";
                Empresa = "Uni Hospitalar Ceará";
                pdfLogo = "logo_UNI_Ceara";
                logoEmail = "https://i.imgur.com/Sz2NLr3.png";
            }
            else if (unidade == "SP HOSPITALAR")
            {
                CodIqvia = "9894";
                Empresa = "SP Hospitalar";
                pdfLogo = "logo_SP_Hospitalar";
                logoEmail = "https://i.imgur.com/cp5UGaO.png";

            }
        }
        public async static Task<string> On(string user, string password,string unidade = "UNI HOSPITALAR")
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(unidade))
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
                    Console.WriteLine(command.CommandText);
                    command.CommandTimeout = 60;
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
