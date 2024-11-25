using System.Collections.Generic;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.Permissionamento
{
    public class PermissionsAllowed
    {
        public static List<Module> modules = new List<Module>();
        public static List<SubModule> subModules = new List<SubModule>();
        public static List<Screen> screens = new List<Screen>();
        public static List<Action> actions = new List<Action>();

        public async static Task getUserPermissionsAsync(string idUser)
        {
            modules = await Module.getAllowedAsync(idUser);
            subModules = await SubModule.getAllowedAsync(idUser);
            screens = await Screen.getAllowedAsync(idUser);
            actions = await Action.getAllowedAsync(idUser);
        }
    }
}
