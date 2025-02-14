using System.Collections.Generic;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.NewIqvia
{
    public class IqviaRestrictionItens : Querys<IqviaRestrictionItens>
    { 
        public string Id { get; set; }
        public string observation { get; set; }
        public string Type { get; set; }
        public string KeyItem { get; set; }


        public static async Task<List<IqviaRestrictionItens>> getByCodeToListAsync(string id)
        {
            string query = $@"SELECT Itens.* FROM {Connection.dbBase}.dbo.{IqviaRestrictionItens.getClassName()} Itens
JOIN {Connection.dbBase}.dbo.[{IqviaRestriction_IqviaRestrictionItens.getClassName()}] II ON II.idIqviaRestrictionItens = Itens.Id
WHERE II.idIqviaRestriction = {id}";

            return await getAllToList(query);
        }

        public static async Task deleteAsync(string id)
        {
            string query = $@"DELETE Itens
FROM {Connection.dbBase}.dbo.{IqviaRestrictionItens.getClassName()} Itens
JOIN {Connection.dbBase}.dbo.[{IqviaRestriction_IqviaRestrictionItens.getClassName()}] II ON II.idIqviaRestrictionItens = Itens.Id
WHERE II.idIqviaRestriction = {id}
";
            await execAsync(query,Section.Unidade);
        }
    }
}
