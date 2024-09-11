using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class FTP : Querys<FTP>
    {
        public string id { get; set; }
        public string description { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string observation { get; set; }
        public string enabled { get; set; } = "1";

        //** Gets **//
        public async static Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT
                              	 id [Código]
                                ,description [Descrição]
                              	,address [Endereço]
                              	,CASE enabled 
                              	 WHEN 1 THEN 'Ativado'
                              	 ELSE 'Desativado' 
                              	 END [Ativado]
                              FROM [UHCDB].dbo.[Ftp]";
            return await getAllToDataTable(query);
        }
        public async static Task<FTP> getToClassAsync(int id)
        {
            string query = $@"SELECT * 
                              FROM [UHCDB].dbo.[Ftp] 
                              WHERE id = {id}";
            return await getToClass(query);
        }
        public async static Task<List<FTP>> getAllToListAsync()
        {
            string query = $@"SELECT
                              	 id 
                                ,description
                                ,login
                              	,password 
                              	,address
                                ,observation
                                ,enabled
                              FROM [UHCDB].dbo.[Ftp]";
            return await getAllToList(query);
        }
        // ** Update ** //
        public async static Task<bool> updateAsync(FTP ftp, List<string> fields)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($@"ftp://{ftp.address}");
                request.Credentials = new NetworkCredential(ftp.login, ftp.password);
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = false; // useful when only to check the connection.
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync();


                if (response.StatusCode == FtpStatusCode.OpeningData)
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
                            command.CommandText = $@"UPDATE [UHCDB].dbo.[Ftp]
                                             SET [description] = '{ftp.description}'
                                                ,[login] = '{ftp.login}'
                                                ,[password] = '{ftp.password}'
                                                ,[address] = '{ftp.address}'
                                                ,[observation] =    '{ftp.observation}'
                                                ,[enabled] = {ftp.enabled}
                                         WHERE id = {ftp.id}";
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
                            
                            CustomNotification.defaultInformation();
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // ** Insert **//
        public async static Task<bool> save(FTP ftp)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($@"ftp://{ftp.address}");
                request.Credentials = new NetworkCredential(ftp.login, ftp.password);
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = false; // useful when only to check the connection.
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync();


                if (response.StatusCode == FtpStatusCode.OpeningData)
                {
                    List<FTP> ftps = new List<FTP>();
                    ftps.Add(ftp);
                    await insertAsync(ftps);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // ** Delete ** //        
        public async static Task deleteAsync(string id)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Section.Unidade))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = $@"delete from [UHCDB].dbo.[FTP]                                         
                                         WHERE ID = {id}";
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

        //** Send archives** //

        public async static Task<bool> sendAsync(FTP ftp, string archive, string archiveName)
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;

            try
            {
                // Verificar se os parâmetros são válidos
                if (ftp == null || string.IsNullOrEmpty(archive) || string.IsNullOrEmpty(archiveName))
                {
                    CustomNotification.defaultAlert("Parâmetros inválidos para o método sendAsync.");
                    return false;
                }

                // Define os requisitos para se conectar com o servidor
                ftpRequest = (FtpWebRequest)WebRequest.Create($@"ftp://{ftp.address}/{archiveName}");
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.Proxy = null;
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential(ftp.login, ftp.password);

                // Seleção do arquivo a ser enviado
                FileInfo arquivo = new FileInfo(archive);
                byte[] fileContents = new byte[arquivo.Length];

                using (FileStream fr = arquivo.OpenRead())
                {
                    await fr.ReadAsync(fileContents, 0, Convert.ToInt32(arquivo.Length));
                }

                using (Stream writer = await ftpRequest.GetRequestStreamAsync())
                {
                    await writer.WriteAsync(fileContents, 0, fileContents.Length);
                }

                // Obtém o FtpWebResponse da operação de upload
                ftpResponse = (FtpWebResponse)await ftpRequest.GetResponseAsync();
                return true;
            }
            catch (WebException ex)
            {
                if (ex.Response is FtpWebResponse ftpExResponse)
                {
                    CustomNotification.defaultError($"1- Erro ao enviar arquivo via FTP: {ftpExResponse.StatusDescription}");
                }
                else
                {
                    CustomNotification.defaultError($"2 - Erro ao enviar arquivo via FTP: {ex.Message}");
                }
                return false;
            }
            catch (IOException ex)
            {
                CustomNotification.defaultError($"Erro ao ler o arquivo: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError($"Erro inesperado: {ex.Message}");
                return false;
            }
        }


    }
}
