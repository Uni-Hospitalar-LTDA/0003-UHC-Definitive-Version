using System;
using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.NewIqvia
{
    public class IqviaRestriction : Querys<IqviaRestriction>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string EditedAt { get; set; }
        public string lastUser { get; set; }
        public string InitialDate { get; set; }
        public string FinalDate { get; set; }



        public static async Task<IqviaRestriction> getToClassAsync(string id)
        {
            string query = $@"SELECT * FROM [{Connection.dbBase}].dbo.[{IqviaRestriction.getClassName()}] WHERE id = {id}";
            return await getToClass(query);
        }
        public static async Task<DataTable> getAllToDataTableAsync(string filter, string status, DateTime dt2)
        {
            string query = $@"SELECT 
                                	 Restriction.Id
                                	,Restriction.Description [Descrição]
                                	,Restriction.InitialDate [Data Inicial]
                                	,Restriction.FinalDate [Data Final]
                                    ,[Status] = CASE Restriction.Status WHEN 1 THEN 'Ativo' ELSE 'Inativo' END 
                                    ,[Vigência] = CASE                                                                                                                 
                                                        WHEN Restriction.InitialDate > CONVERT(DATE,GETDATE()) THEN 'Vigência futura'
														WHEN Restriction.InitialDate <= CONVERT(DATE,GETDATE())
														AND	 Restriction.FinalDate >= CONVERT(DATE,GETDATE()) THEN 'Vigente'
														ELSE 'Vencido'																												
                                                   END
                                FROM [{Connection.dbBase}].dbo.[{getClassName()}] Restriction                                
                                WHERE 
                                (CONVERT(VARCHAR,Restriction.Id) = '{filter}' OR Restriction.Description LIKE '%{filter}%') AND Restriction.Status IN ({status})
                                AND (Restriction.FinalDate >= '{dt2.ToString("yyyyMMdd")}' AND 
                                     Restriction.InitialDate <= '{dt2.ToString("yyyyMMdd")}') ";
            return await getAllToDataTable(query);
        }
      
    }

    public class IqviaRestriction_IqviaRestrictionItens : Querys<IqviaRestriction_IqviaRestrictionItens>
    {
        public string idIqviaRestriction { get; set; }
        public string idIqviaRestrictionItens { get; set; }
    }
}


