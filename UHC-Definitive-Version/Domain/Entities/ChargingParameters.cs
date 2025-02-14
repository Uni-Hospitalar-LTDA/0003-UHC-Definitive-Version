using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class ChargingParameters : Querys<ChargingParameters>
	{
		public string DaysDueDateAlert { get; set; }
		public string DaysPostDueDateAlert { get; set; }
		public string DaysRecoveryNotification { get; set; }
		public string NotifyOnDueDate { get; set; }

		public async static Task<ChargingParameters> getToClassAsync()
		{
			string query = $@" SELECT * FROM [UHCDB].dbo.[ChargingParameters] ";
			return await getToClass(query);
		}
		public async static Task deleteAsync()
		{
			string query = " DELETE FROM [UHCDB].dbo.[ChargingParameters] ";

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
					command.CommandText = query;
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
