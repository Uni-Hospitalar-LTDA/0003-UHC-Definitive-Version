using System.Collections.Generic;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class State : Querys<State>
    {
        public string idIBGE { get; set; }
        public string uf { get; set; }
        public string description { get; set; }
        public string region { get; set; }


        public static async Task<List<State>> getAllToListAsync()
        {
            string query = "SELECT * FROM UHCDB.dbo.State";
            return await getAllToList(query);
        }
        public static async Task<State> getToClassAsync(string uf)

        {
            string query = $"SELECT * FROM UHCDB.dbo.State WHERE uf = '{uf}'";
            return await getToClass(query);
        }
    }
}
