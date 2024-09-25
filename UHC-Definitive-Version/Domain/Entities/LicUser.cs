using System.Threading.Tasks;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.Domain
{
    public class LicUser : Users
    {
        public async static Task<Users> getToClassAsync(string id)
        {
            string query = $@"SELECT								 Users.id
                                    ,Users.login
                                    ,Users.name
                                    ,Users.email
                                    ,Users.password
                                    ,Users.idSector
                                    ,Users.setPassword
                                    ,Users.active
                                FROM [UHCDB].dbo.[Users]
								JOIN [UHCDB].dbo.[Sector] Sector ON Sector.id = Users.idSector
                                WHERE 
									(Sector.description LIKE 'LICIT%' OR Sector.description LIKE 'DIRET%')
                                    AND Users.active = 1
									AND Users.id = {id}								
                                "
                           ;
            return await getToClass(query);
        }
    }
}
