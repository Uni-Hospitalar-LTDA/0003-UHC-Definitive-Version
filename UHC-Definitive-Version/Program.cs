using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC_DEFINITIVE_VERSION.App;
using UHC3_Definitive_Version.App.ModFinanceiro.MonitoresFinanceiros;
using UHC3_Definitive_Version.App.ModGerencial;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Task.Factory.StartNew(() => Section.carregar_Dependencias());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmUpdateScreen());
            Application.Run(new frmMonitores_ExpXmlGnre());

        }
    }
}
