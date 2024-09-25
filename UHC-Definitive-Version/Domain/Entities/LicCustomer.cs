using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain
{
    public class LicCustomer : Querys<LicCustomer>
    {
        public string codigo { get; set; }
        public string razao_social { get; set; }
        public string Cod_Estado { get; set; }
        public string Unity { get; set; }

        public static async Task<LicCustomer> getToClassAsync(string id)
        {
            string query = $@"SELECT 
                                    	 Codigo 
                                    	,Razao_Social	
                                        ,Cod_Estado     
                                        ,Unity = '{Section.Empresa}'
                                    FROM 
                                    [DMD].dbo.[CLIEN] Cliente
                                    WHERE 
                                    Tipo_Consumidor IN ('P','M','E')
                                    AND Codigo = {id} "
                           ;
            return await getToClass(query);
        }

    }
}
