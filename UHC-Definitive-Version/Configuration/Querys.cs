using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Domain.Log;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Configuration
{
    public class Querys<Gen> where Gen : new()
    {
        // Método para mapear uma linha de dados para um objeto Gen
        private Gen MapRow(IDataReader reader)
        {
            Gen item = new Gen();
            var typeProperties = typeof(Gen).GetProperties();

            foreach (var property in typeProperties)
            {
                int ordinal = reader.GetOrdinal(property.Name);

                if (!reader.IsDBNull(ordinal))
                {
                    property.SetValue(item, reader[ordinal].ToString(), null);
                }
            }
            return item;
        }

        // Método para mapear os resultados da consulta para uma lista de objetos Gen
        public List<Gen> MapResultsToObject(IDataReader reader)
        {
            List<Gen> objects = new List<Gen>();

            while (reader.Read())
            {
                objects.Add(MapRow(reader));
            }
            return objects;
        }

        // Método para obter qualquer campo do banco de dados como string
        public async static Task<string> getString(string query)
        {
            using (SqlConnection conn = new Connection().getConnectionApp(Session.Unidade))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = query;

                    object result = await command.ExecuteScalarAsync();
                    return result != null ? result.ToString() : null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        // Método para obter todos os registros como uma lista de objetos Gen
        public async static Task<List<Gen>> getAllToList(string query)
        {
            using (SqlConnection conn = new Connection().getConnectionApp(Session.Unidade))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = query;

                    Querys<Gen> resultsMapper = new Querys<Gen>();

                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    List<Gen> results = resultsMapper.MapResultsToObject(reader);
                    return results;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Método para obter um único registro como um objeto Gen
        public async static Task<Gen> getToClass(string query)
        {
            using (SqlConnection conn = new Connection().getConnectionApp(Session.Unidade))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = query;
                    command.CommandTimeout = 60;

                    Querys<Gen> resultsMapper = new Querys<Gen>();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    List<Gen> results = resultsMapper.MapResultsToObject(reader);
                    return results[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Querys.getToClass method error => " + ex.Message);
                    return new Gen();
                }
            }
        }

        // Método para obter todos os registros como um DataTable
        public async static Task<DataTable> getAllToDataTable(string query)
        {
            using (SqlConnection conn = new Connection().getConnectionApp(Session.Unidade))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = query;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Método para obter o nome da classe Gen
        public static string getClassName()
        {
            Gen instance = new Gen();
            Type type = instance.GetType();
            return type.Name;
        }

        // Método para obter o último código inserido na tabela Gen
        public async static Task<int> getLastCodeAsync()
        {
            int lastCode = 0;
            using (SqlConnection conn = new Connection().getConnectionApp(Session.Unidade))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = $"SELECT lastCode = ident_current ('{Connection.dbBase}.dbo.[{typeof(Gen).Name}]')";

                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            lastCode = Convert.ToInt32(reader["lastCode"].ToString());
                        }
                    }
                    return lastCode;
                }
                catch (Exception)
                {
                    return lastCode;
                }
            }
        }

        // Métodos de inserção (sobrecargas para lista e único objeto)
        public async static Task insertAsync(List<Gen> gens)
        {
            await insertAsync(gens.AsEnumerable());
        }

        public async static Task insertAsync(Gen gen)
        {
            await insertAsync(new List<Gen> { gen });
        }

        // Método privado para inserção        
        private async static Task insertAsync(IEnumerable<Gen> gens)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Session.Unidade))
            {
                await conn.OpenAsync();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    using (var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                    {
                        bulkCopy.BatchSize = 100;
                        bulkCopy.DestinationTableName = $"{Connection.dbBase}.dbo.[{typeof(Gen).Name}]";
                        await bulkCopy.WriteToServerAsync(IEnumerableExtensions.AsDataTable(gens));
                    }
                    transaction.Commit();

                    List<Logs> logs = new List<Logs>
            {
                new Logs
                {
                    Descricao = "Inserção de Registro",
                    Data = DateTime.Now.ToString(),
                    TipoRegistro = typeof(Gen).Name,
                    idRegistro = Convert.ToString(await getLastCodeAsync()),
                    idUsuario = Session.idUsuario.ToString()
                }
            };

                    await Logs.insertAsync(logs);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    CustomNotification.defaultError(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        // Método de atualização genérica
        //public async static Task updateAsync(Gen gen)
        //{
        //    using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Session.Unidade))
        //    {
        //        await conn.OpenAsync();
        //        SqlTransaction transaction = conn.BeginTransaction();
        //        try
        //        {
        //            SqlCommand command = conn.CreateCommand();
        //            command.Transaction = transaction;

        //            var typeProperties = typeof(Gen).GetProperties();
        //            var updateQuery = new StringBuilder($"UPDATE {Connection.dbBase}.dbo.[{typeof(Gen).Name}] SET ");

        //            foreach (var property in typeProperties)
        //            {
        //                if (property.Name.ToLower() != "id")
        //                {
        //                    updateQuery.Append($"{property.Name} = @{property.Name}, ");
        //                    command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(gen) ?? DBNull.Value);
        //                }
        //            }

        //            updateQuery.Length -= 2; // Remove the last comma and space
        //            updateQuery.Append(" WHERE Id = @Id");
        //            command.Parameters.AddWithValue("@Id", typeof(Gen).GetProperty("Id").GetValue(gen));

        //            command.CommandText = updateQuery.ToString();
        //            await command.ExecuteNonQueryAsync();
        //            transaction.Commit();

        //            List<Logs> logs = new List<Logs>
        //            {
        //                new Logs
        //                {
        //                    Descricao = "Atualização de Registro",
        //                    Data = DateTime.Now.ToString(),
        //                    TipoRegistro = typeof(Gen).Name,
        //                    idRegistro = typeof(Gen).GetProperty("Id").GetValue(gen).ToString(),
        //                    idUsuario = Session.idUsuario.ToString()
        //                }
        //            };

        //            await Logs.insertAsync(logs);
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            CustomNotification.DefaultError(ex.Message);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //}

        public async static Task updateAsync<T>(T entity, string primaryKeyName = "Id") where T : class
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Session.Unidade))
            {
                await conn.OpenAsync();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    SqlCommand command = conn.CreateCommand();
                    command.Transaction = transaction;

                    var typeProperties = typeof(T).GetProperties();
                    var updateQuery = new StringBuilder($"UPDATE {Connection.dbBase}.dbo.[{typeof(T).Name}] SET ");

                    foreach (var property in typeProperties)
                    {
                        if (property.Name.ToLower() != primaryKeyName.ToLower())
                        {
                            updateQuery.Append($"{property.Name} = @{property.Name}, ");
                            command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(entity) ?? DBNull.Value);
                        }
                    }


                    updateQuery.Length -= 2; // Remove the last comma and space
                    updateQuery.Append($" WHERE {primaryKeyName} = @{primaryKeyName}");
                    command.Parameters.AddWithValue($"@{primaryKeyName}", typeof(T).GetProperty(primaryKeyName).GetValue(entity));

                    command.CommandText = updateQuery.ToString();
                    Console.WriteLine(command.CommandText);
                    await command.ExecuteNonQueryAsync();
                    transaction.Commit();

                    List<Logs> logs = new List<Logs>
                    {
                        new Logs
                        {
                            Descricao = "Atualização de Registro",
                            Data = DateTime.Now.ToString(),
                            TipoRegistro = typeof(T).Name,
                            idRegistro = typeof(T).GetProperty(primaryKeyName).GetValue(entity).ToString(),
                            idUsuario = Session.idUsuario.ToString()
                        }
                    };

                    await Logs.insertAsync(logs);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    CustomNotification.defaultError(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public async static Task updateAsync<T>(List<T> entities, string[] primaryKeyNames) where T : class
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Session.Unidade))
            {
                await conn.OpenAsync();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    foreach (var entity in entities)
                    {
                        SqlCommand command = conn.CreateCommand();
                        command.Transaction = transaction;

                        var typeProperties = typeof(T).GetProperties();
                        var updateQuery = new StringBuilder($"UPDATE {Connection.dbBase}.dbo.[{typeof(T).Name}] SET ");

                        foreach (var property in typeProperties)
                        {
                            if (!primaryKeyNames.Any(pk => pk.Equals(property.Name, StringComparison.OrdinalIgnoreCase)))
                            {
                                updateQuery.Append($"{property.Name} = @{property.Name}, ");
                                command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(entity) ?? DBNull.Value);
                            }
                        }

                        updateQuery.Length -= 2; // Remove the last comma and space

                        updateQuery.Append(" WHERE ");
                        foreach (var pkName in primaryKeyNames)
                        {
                            updateQuery.Append($"{pkName} = @{pkName} AND ");
                            command.Parameters.AddWithValue($"@{pkName}", typeof(T).GetProperty(pkName).GetValue(entity));
                        }
                        updateQuery.Length -= 5; // Remove the last ' AND '

                        command.CommandText = updateQuery.ToString();
                        Console.WriteLine(command.CommandText);
                        await command.ExecuteNonQueryAsync();
                    }

                    transaction.Commit();

                    List<Logs> logs = entities.Select(entity => new Logs
                    {
                        Descricao = "Atualização de Registro",
                        Data = DateTime.Now.ToString(),
                        TipoRegistro = typeof(T).Name,
                        idRegistro = string.Join(",", primaryKeyNames.Select(pk => typeof(T).GetProperty(pk).GetValue(entity).ToString())),
                        idUsuario = Session.idUsuario.ToString()
                    }).ToList();

                    await Logs.insertAsync(logs);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    CustomNotification.defaultError(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }




        // Método de exclusão genérica
        public async static Task deleteAsync(string parameterName, object id)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Session.Unidade))
            {
                await conn.OpenAsync();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    SqlCommand command = conn.CreateCommand();
                    command.Transaction = transaction;

                    // Log da consulta para verificação
                    string query = $"DELETE FROM {Connection.dbBase}.dbo.[{typeof(Gen).Name}] WHERE {parameterName} = @Id";
                    Console.WriteLine("Query: " + query);
                    Console.WriteLine("Parameter Name: " + parameterName);
                    Console.WriteLine("ID: " + id.ToString());

                    command.CommandText = query;
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    Console.WriteLine("Rows affected: " + rowsAffected);

                    if (rowsAffected > 0)
                    {
                        transaction.Commit();

                        List<Logs> logs = new List<Logs>
                {
                    new Logs
                    {
                        Descricao = "Exclusão de Registro",
                        Data = DateTime.Now.ToString(),
                        TipoRegistro = typeof(Gen).Name,
                        idRegistro = id.ToString(),
                        idUsuario = Session.idUsuario.ToString()
                    }
                };

                        await Logs.insertAsync(logs);
                    }
                    else
                    {
                        //throw new Exception("No rows affected. The ID might not exist.");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    CustomNotification.defaultError(ex.Message);
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        // Método para excluir todos os registros
        public static async Task deleteAllAsync()
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Session.Unidade))
            {
                SqlTransaction transaction = null;
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    transaction = conn.BeginTransaction();
                    command.Connection = conn;
                    command.Transaction = transaction;
                    command.CommandText = $@"DELETE FROM {Connection.dbBase}.dbo.{typeof(Gen).Name}";
                    Console.WriteLine(command.CommandText);
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

        // Métodos para conversão de lista para DataTable
        public static DataTable ConvertTo<T>(IList<Gen> list)
        {
            DataTable table = CreateTable<Gen>();
            Type entityType = typeof(Gen);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (Gen item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                table.Rows.Add(row);
            }
            return table;
        }
        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(Gen);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            return table;
        }
    }
}
