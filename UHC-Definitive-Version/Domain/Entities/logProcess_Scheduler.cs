using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class logProcess_Scheduler : Querys<logProcess_Scheduler>
    {
        public string idProcess_Scheduler { get; set; }
        public string Dat_Schedule { get; set; }
        public string Dat_Modification { get; set; }
        public string idUser { get; set; }
        public string Observation { get; set; }


        public static async Task<DataTable> getAllToDataTableAsync(string idProcess_Scheduler)
        {
            string query = $@"SELECT 
                                       Dat_Schedule [Dat. Agendamento]
                                      ,Dat_Modification [Dat. Modificação]
                                      ,Users.Name   [Usuário]
                                      ,Observation  [Motivo do Reagendamento]
                             FROM [UHCDB].dbo.[{logProcess_Scheduler.getClassName()}] list
                             JOIN [UHCDB].dbo.[Users] Users ON Users.id = list.idUser
                             WHERE idProcess_Scheduler = {idProcess_Scheduler} 

";
            return await getAllToDataTable(query);
        }

        public static async Task<logProcess_Scheduler> getToClassAsync(string idProcess_Scheduler)
        {
            string query = $@"SELECT top 1
                                       *
                             FROM [UHCDB].dbo.[{logProcess_Scheduler.getClassName()}] list                            
                             WHERE idProcess_Scheduler = {idProcess_Scheduler} 
ORDER BY Dat_Modification asc";
            return await getToClass(query);
        }
    }
}
