

using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.Domain
{
    public class LicUser : Users
    {
        public async static Task<Users> getToClassAsync(string id)
        {
            string query = $@"SELECT								 
                                     Users.*
                                FROM [{Connection.dbBase}].dbo.[{Users.getClassName()}]
								JOIN [{Connection.dbBase}].dbo.[{Sector.getClassName()}] Sector ON Sector.id = Users.idSector
                                WHERE 
									(Sector.description LIKE 'LICIT%' OR Sector.description LIKE 'DIRET%')
                                    AND Users.status = 1
									AND Users.id = {id}								
                                "

                                
                           ;
            //Console.WriteLine(query);
            return await getToClass(query);
        }
    }
}
