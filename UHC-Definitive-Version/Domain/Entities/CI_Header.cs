using UHC3_Definitive_Version.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities.CI
{
    public class CI_Header : Querys<CI_Header>
    {
        public string id { get; set; }
        public string idUHC2 { get; set; }
        public string idCI_Reason { get; set; }
        public string idCI_Responsible { get; set; }
        public string idCI_FollowUp { get; set; }
        public string idCustomer { get; set; }
        public string idTransporter { get; set; }
        public string nfRebill { get; set; }
        public string operationType { get; set; } //T= Total, P = Parcial, N = Sem devolução
        public string physicalReturn { get; set; } // 1 = Sim, 0 = Não
        public string status { get; set; }
        // P = Pendente , F = Aguardando Financeiro, C = Concluído, A = Atrasado
        public string observation { get; set; }
        public string dateCreated { get; set; }
        public string dateEdited { get; set; }
        public string idUser { get; set; }

        public string archiveLink { get; set; }

        public static async Task<DataTable> getAllToDataTableAsync(string status, string customer, string transporter
            , string rebill, string nforigin, string nfreturn, string idCi, string idUHC2)
        {


            string customerFilter = (!string.IsNullOrEmpty(customer) ? $" AND Customer.Codigo = {customer}" : null);
            string transporterFilter = (!string.IsNullOrEmpty(transporter) ? $" AND Transporter.Codigo = {transporter}" : null);
            string idFilter = (!string.IsNullOrEmpty(idCi) ? $" AND Header.Id = '{idCi}'" : null);
            string originFilter = (!string.IsNullOrEmpty(nforigin) ? $" AND convert(varchar,CI_OriginNF.NF_Origin) like ('%{nforigin}%')" : null);
            string returnFilter = (!string.IsNullOrEmpty(nfreturn) ? $" AND convert(varchar,CI_ReturnNF.NF_Return) like ('%{nfreturn}%')" : null);
            string rebillFilter = (!string.IsNullOrEmpty(rebill) ? $"AND nfRebill like '%{rebill}%'" : null);
            string iduhc2filter = (!string.IsNullOrEmpty(idUHC2) ? $"AND idUHC2 like '%{idUHC2}%'" : null);
            string query = $@"SELECT top 200
 Header.Id
,Responsible.description [Setor Responsável] 
,Reason.description [Motivo]
,Header.idCustomer [Cód. Cliente]
,Customer.Razao_Social [Cliente]
,Transporter.Fantasia [Transportador]
,[Operação] = CASE Header.operationType
				WHEN 'T' THEN 'Dev. Total'
				WHEN 'P' THEN 'Dev. Parcial'
				WHEN 'N' THEN 'Sem Devolução'
			  END
,[Registro] = Header.dateCreated
,Status = CASE Header.Status
			WHEN 'P' THEN	'Pendente'
			WHEN 'F' THEN	'Aguard. Financeiro'
			WHEN 'C' THEN	'Concluído'
			END			
FROM [UHCDB].dbo.[CI_Header] Header
JOIN [DMD].dbo.[CLIEN] Customer ON Customer.Codigo = idCustomer
LEFT JOIN [DMD].dbo.[Trans] Transporter ON Transporter.Codigo = idTransporter
JOIN [UHCDB].dbo.[CI_Responsible] Responsible ON Responsible.id = idCI_Responsible
JOIN [UHCDB].dbo.[CI_Reason] Reason ON Reason.id = idCI_Reason
LEFT JOIN [UHCDB].dbo.[CI_OriginNF] on CI_OriginNF.idCI_Header = Header.id
LEFT JOIN [UHCDB].dbo.[CI_ReturnNF] on CI_ReturnNF.idCI_Header = Header.id
WHERE 
 Header.Status IN ({status}) 
{customerFilter}
{transporterFilter}
{rebillFilter}
{originFilter}
{returnFilter}
{iduhc2filter}
{idFilter}

GROUP BY
     Header.Id
    ,Responsible.description
    ,Reason.description
    ,Header.idCustomer
    ,Customer.Razao_Social
    ,Transporter.Fantasia
    ,Header.operationType
    ,Header.dateCreated
    ,Header.Status
ORDER BY Id DESC"
;
            Console.WriteLine(query);
            return await getAllToDataTable(query);
        }

        public static async Task<CI_Header> getToClassAsync(string id)
        {
            string query = $"SELECT * FROM [UHCDB].dbo.[{getClassName()}] WHERE id = {id} ";
            return await CI_Header.getToClass(query);
        }
        public async static Task<string> updateAsync(CI_Header header)
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


                    {
                        command.CommandText = $@"UPDATE [UHCDB].dbo.[{getClassName()}]
                                              SET [idTransporter] = {header.idTransporter}
                                                 ,[idCI_Responsible] = {header.idCI_Responsible}
                                                 ,[nfRebill] = '{header.nfRebill}'
                                                 ,[observation] = '{header.observation}'
                                                 ,[dateEdited] = GETDATE()
                                                 ,[idUser] = {Section.idUsuario}
                                            WHERE [id] =  {header.id}";
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
        public static async Task<DataTable> checkNfRebillUsabilityAsync(string nf)
        {
            string query = $@"SELECT NUM_NOTA FROM [DMD].dbo.[NFSCB] WHERE NUM_NOTA LIKE '{nf}'";
            return await getAllToDataTable(query);
        }
        public static async Task setStatusAsync(CI_Header header, string status = "F")
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


                    {
                        command.CommandText = $@"UPDATE [UHCDB].dbo.[{getClassName()}]
                                              SET 
                                                  [Status] = '{status}'                                                                                                                                                   
                                                 ,[dateEdited] = GETDATE()
                                                 ,[idUser] = {Section.idUsuario}
                                            WHERE [id] =  {header.id}";
                    }


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
