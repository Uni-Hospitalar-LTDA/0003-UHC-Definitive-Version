using Irony.Ast;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities.Users
{
    public class Users : Querys<Users>
    {
        private const string defaultPassword = ("uni123");
        public string id { get; set; }
        public string login { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; } = Cryptography.crypt(defaultPassword);
        public string idSector { get; set; }
        public string setPassword { get; set; } = "0";
        public string Status { get; set; } = "1";        

        /** Gets **/
        public async static Task<Users> getToClassByLoginAsync(string userLogin,string unidade)
        {
            string query = $@"SELECT [id] 
                                    ,[login]
                                    ,[name]
                                    ,[email]
                                    ,[password]
                                    ,[idSector]
                                    ,[setPassword]
                                    ,[Status]
                                FROM [{Connection.dbBase}].dbo.[{getClassName()}]
                               WHERE login = '{userLogin}'";            
            return await getToClass(query,unidade);
        }
        public async static Task<string> getUserCodeAsync(string login)
        {
            
            using (SqlConnection conn = new Connection().getConnectionApp(Section.Unidade))
            {
                string code = null;
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = $@"SELECT TOP 1 id
                                                FROM [{Connection.dbBase}].dbo.[{Users.getClassName()}] 
                                            WHERE login like '{login}'";
                    Console.WriteLine(command.CommandText);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    
                    

                    while (await reader.ReadAsync())
                    {
                        code = reader["id"].ToString();
                    }
                    return code;
                }
                catch (Exception ex) 
                {
                    CustomNotification.defaultError(ex.Message);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public async static Task<Users> getToClassByIdAsync(string id)
        {
            string query = $@"SELECT [id] 
                                    ,[login]
                                    ,[name]
                                    ,[email]
                                    ,[password]
                                    ,[idSector]
                                    ,[setPassword]
                                    ,[Status]
                                FROM [{Connection.dbBase}].dbo.[{getClassName()}]
                               WHERE id = {id}";
            return await getToClass(query);
        }
        public async static Task<DataTable> getAllToDataTableAsync(string filter, string status)
        {
            string query = $@"SELECT 
	 Usr.Id
	,Usr.Login
	,Usr.Name [Nome]
	,Setor.description [Setor]
    ,[Status] = CASE Usr.Status WHEN 1 THEN 'Ativo' ELSE 'Inativo' END 
FROM [{Connection.dbBase}].dbo.[{getClassName()}] Usr
JOIN [{Connection.dbBase}].dbo.[Sector] Setor ON Setor.id = Usr.idSector
WHERE 
                                (CONVERT(VARCHAR,Usr.Id) = '{filter}' OR Usr.name LIKE '%{filter}%' OR Usr.login LIKE '%{filter}%') AND Usr.Status IN ({status})";            
            return await getAllToDataTable(query);
        }
        public async static Task<List<Users>> getAllToListBySectorAsync(string idSector)
        {
            string query = $@"SELECT 
                                * FROM [{Connection.dbBase}].dbo.[{getClassName()}] WHERE idSector = {idSector} and status = 1";
            return await getAllToList(query);
        }
        public async static Task<List<Users>> getAllToListAsync()
        {
            string query = $@"SELECT 
                                * FROM [{Connection.dbBase}].dbo.[{getClassName()}] WHERE Status = 1";
            return await getAllToList(query);
        }
        public async static Task<List<Users>> getAllElegiveisParaCobrancaAsync()
        {
            string query = $@"SELECT 
                                Users.* 
                                FROM [{Connection.dbBase}].dbo.[{Users.getClassName()}] Users 
                                JOIN [{Connection.dbBase}].dbo.[{Sector.getClassName()}] Sector 
                                on Users.idSector = Sector.Id
                                WHERE Sector.ElegivelParaCobranca=1 AND Users.Status = 1 AND Sector.Status = 1";
            Console.WriteLine(query);
            return await getAllToList(query);
        }
        public async static Task<List<Users>> getUsersByGroup(string idGroup)
        {
            string query = $@"SELECT distinct
                                users.*
                                FROM [{Connection.dbBase}].dbo.[{getClassName()}] 
                                JOIN [{Connection.dbBase}].dbo.[Users_Groups] UG ON UG.idUsers = users.id
                                WHERE idGroups = {idGroup} AND status = 1 ";
            return await getAllToList(query);
        }
        /** Updates **/
        public async static Task<string> updateSectorAsync(Users user)
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

                    command.CommandText = $@"UPDATE [{Connection.dbBase}].dbo.[{getClassName()}]
                                SET [idSector] = {user.idSector}
                                WHERE [id] = {user.id}";

                    await command.ExecuteNonQueryAsync();
                    return null;
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    transaction.Rollback();
                    conn.Close();
                    return "error";
                }
                finally
                {
                    transaction.Commit();
                    conn.Close();

                }
            }
        }
        public async static Task<string> updateAsync(Users user)
        {
            Users us = await getToClassByLoginAsync(user.login,Section.Unidade);
            if (!string.IsNullOrEmpty(us?.ToString()))
            {
                if (us?.id != user.id && us.login?.ToUpper() == user.login.ToUpper())
                {
                    CustomNotification.defaultAlert($"Login já existente para outro usuário ({us.id} | {us.name})");
                    return "error";

                }
            }
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

                    if (user.password.ToString().Trim().Equals(string.Empty))
                    {
                        command.CommandText = $@"UPDATE [{Connection.dbBase}].dbo.[{getClassName()}]
                                              SET [login] = '{user.login}'
                                                 ,[name] = '{user.name}'
                                                 ,[email] = '{user.email}'                                                 
                                                 ,[idSector] = {user.idSector}
                                                 ,[Password] = '{Cryptography.crypt(defaultPassword)}'
                                                 ,[setPassword] = {1}              
                                                 ,Status = {user.Status}
                                            WHERE [id] =  {user.id}";
                    }
                    else
                    {
                        command.CommandText = $@"UPDATE [{Connection.dbBase}].dbo.[{getClassName()}]
                                              SET [login] = '{user.login}'
                                                 ,[name] = '{user.name}'
                                                 ,[email] = '{user.email}'
                                                 ,[password] = '{Cryptography.crypt(user.password)}'
                                                 ,[idSector] = {user.idSector}                                                 
                                                 ,Status = {user.Status}
                                            WHERE [id] =  {user.id}";
                    }


                    await command.ExecuteNonQueryAsync();
                    return null;
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    transaction.Rollback();
                    conn.Close();
                    return "error";
                }
                finally
                {

                    transaction.Commit();
                    conn.Close();
                }
            }
        }
        public async static Task changePasswordAsync(Users user,string unidade)
        {
            if (!user.password.ToString().Trim().Equals(string.Empty))
            {
                Console.WriteLine($"Alterar a senha usuário {user.login} para {user.password}");
                using (SqlConnection conn = Connection.getInstancia().getConnectionApp(unidade))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        await conn.OpenAsync();
                        SqlCommand command = conn.CreateCommand();
                        transaction = conn.BeginTransaction();
                        command.Connection = conn;
                        command.Transaction = transaction;


                        command.CommandText = $@"UPDATE [{Connection.dbBase}].dbo.[{getClassName()}]
                                              SET [password] = '{Cryptography.crypt(user.password)}'    
                                              ,[setPassword] = 0
                                            WHERE [login] = '{user.login}'";

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
        }
    }
}
