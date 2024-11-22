using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain
{
    public class Process_Scheduler : Querys<Process_Scheduler>
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string idPlatform { get; set; }
        public string idResponsible { get; set; }
        public string idCustomer { get; set; }
        public string Lic { get; set; }
        public string Process { get; set; }
        public string Participation { get; set; }
        public string Dat_Scheduler { get; set; }
        public string link { get; set; }
        public string idJustify { get; set; }
        public string idUser { get; set; }


        public static async Task<DataTable> getAllToDataTableWithFilterAsync(string name, string idCustomer, string idResponsible, string idPlatform, string status, string dtpInitial, string dtpFinal, string participation)
        {
            string schedulerFilter = string.IsNullOrEmpty(name) ? null : $"AND prcsSched.name like '%{name}%' ";
            string customerFilter = string.IsNullOrEmpty(idCustomer) ? null : $"AND Cliente.Codigo = {idCustomer} ";
            string responsibleFilter = string.IsNullOrEmpty(idResponsible) ? null : $"AND Users.Id = {idResponsible} ";
            string platformFilter = string.IsNullOrEmpty(idPlatform) ? null : $"AND platform.id = {idPlatform}";
            string statusFilter = string.Empty;
            string dataFilter = $"AND CONVERT(DATE, Dat_Scheduler) Between '{dtpInitial}' AND '{dtpFinal}'";
            string participationFilter = string.Empty;



            if (!string.IsNullOrEmpty(participation))
            {
                List<string> participations = new List<string>();

                if (participation.Contains("1"))
                {
                    participations.Add($"AND Participation = 1");
                }
                if (participation.Contains("0"))
                {
                    participations.Add($"AND Participation = 0");
                }
                if (participation.Contains("B"))
                {
                    participations.Add($"AND Participation in (0,1)");
                }
                if (participations.Any())
                {
                    dataFilter += string.Join("U+002C", participations);
                }


            }

            if (!string.IsNullOrEmpty(status))
            {
                List<string> conditions = new List<string>();

                if (status.Contains("P"))
                {
                    conditions.Add("prcsSched.Dat_Scheduler > GETDATE()");
                }

                if (status.Contains("A"))
                {
                    conditions.Add("SendedProcesses.idProcessSchedule IS NOT NULL AND prcsSched.description like ''");
                }

                if (status.Contains("F"))
                {
                    conditions.Add("SendedProcesses.idProcessSchedule IS NOT NULL AND prcsSched.idJustify not like ''");
                }

                if (conditions.Any())
                {
                    statusFilter += "AND (" + string.Join(" OR ", conditions) + ")";
                }
            }



            string query = $@"  SELECT DISTINCT
                                		 prcsSched.id
										 ,prcsSched.Lic [Pregão]
                                		,prcsSched.name [nome]
										
                                		,Platform.name [Plataforma]
                                		,Cliente.Codigo
                                		,Cliente.Razao_Social
                                		,Users.name [Responsável]		
                                		,[Data] = CONVERT(DATE,Dat_Scheduler)
                                		,[Horário] = CONVERT(VARCHAR(5),Dat_Scheduler,108)
										,IIF(Participation = 1, 'Sim','Não') [Participação]
                                		,[Status] = 
                                		CASE 
                                			WHEN Dat_Scheduler > GETDATE() AND SendedProcesses.id is null THEN 'Programado'			
											WHEN SendedProcesses.idProcessSchedule IS NOT NULL
											AND prcsSched.idJustify is not null THEN 'Finalizado'
                                			WHEN SendedProcesses.idProcessSchedule IS NOT NULL
											AND prcsSched.idJustify is null THEN 'Aguardando Feedback'
											ELSE 'Não notificado'
                                		 END               
                                FROM [UHCDB].dbo.[Process_Scheduler] prcsSched
                                JOIN [UHCDB].dbo.[Platform] ON Platform.id = prcsSched.IdPlatform
                                JOIN [UHCDB].dbo.[Users] ON Users.id = prcsSched.idResponsible
                                JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = prcsSched.IdCustomer 
                                LEFT JOIN [UHCDB].dbo.Notifier_ProcessLic SendedProcesses ON SendedProcesses.idProcessSchedule = prcsSched.Id
                                WHERE 1=1
                                {schedulerFilter}
                                {customerFilter}
                                {responsibleFilter}
                                {platformFilter}
                                {statusFilter}
                                {dataFilter}                                
                                ORDER BY [data] DESC, [horário] desc, prcsSched.id asc
                                ";
            Console.WriteLine(query);
            return await getAllToDataTable(query);
        }
        public static async Task<Process_Scheduler> getToClassAsync(string id)
        {
            string query = $"SELECT * FROM [UHCDB].dbo.[Process_Scheduler] WHERE id = {id}";
            return await getToClass(query);
        }

        public async static Task<string> updateAsync(Process_Scheduler processScheduler)
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



                    string query =

                        command.CommandText = $@"UPDATE [UHCDB].dbo.[Process_Scheduler]
   SET [name] = '{processScheduler.name}'
      ,[description] = '{processScheduler.description}'
      ,[IdPlatform] = {processScheduler.idPlatform} 
      ,[IdResponsible] = {processScheduler.idResponsible}
      ,[idCustomer] = {processScheduler.idCustomer}
      ,[Lic] = '{processScheduler.Lic}'
      ,[Process] = '{processScheduler.Process}'
      ,[Participation] = {processScheduler.Participation}
      ,[Dat_Scheduler] = '{Convert.ToDateTime(processScheduler.Dat_Scheduler).ToString("yyyyMMdd HH:mm")}'
      ,[link] = '{processScheduler.link}'
      ,[idJustify] = {(string.IsNullOrEmpty(processScheduler.idJustify) ? "null" : processScheduler.idJustify)}
      ,[idUser] = {Section.idUsuario}
 WHERE id = {processScheduler.id}";


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
        public async static Task<string> deleteAsync(Process_Scheduler processScheduler)
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


                    string query =

                        command.CommandText = $@"DELETE FROM [UHCDB].dbo.[Process_Scheduler]   
                                                 WHERE id = {processScheduler.id}";


                    Console.WriteLine(query);
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

    }
}
