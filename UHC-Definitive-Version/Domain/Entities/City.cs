using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class City : Querys<City>
    {
        public string idIBGE { get; set; }
        public string description { get; set; }
        public string idCounty { get; set; }
        public string capital { get; set; }
        public string idIBGE_State { get; set; }

        public static async Task<List<City>> getAllToListAsync()
        {
            string query = "SELECT * FROM UHCDB.dbo.City";
            return await getAllToList(query);
        }

        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT 
                              	 [Cód. IBGE]  = City.idIBGE
                              	,[Município] = City.description
                              	,[Capital] = CASE capital
                              					WHEN 1 THEN 'Sim'
                              					ELSE 'Não'
                              				 END
                              	,[UF] = state.uf
                              FROM [UHCDB].dbo.[City]
                              JOIN [UHCDB].dbo.[State] ON State.idIBGE = City.idIBGE_State";
            return await getAllToDataTable(query);
        }
    }
}
