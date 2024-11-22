using System;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
using UHC_DEFINITIVE_VERSION.App;
using UHC3_Definitive_Version.App.ModFinanceiro.Pagamentos;
using UHC3_Definitive_Version.App.ModFinanceiro.Recebimento;
=======
using UHC3_Definitive_Version.App.ModGerencial;
>>>>>>> feature/analiseiqvia
using UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas;
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
            Application.Run(new frmUpdateScreen());
<<<<<<< HEAD
            //Application.Run(new frmRecebimento_CarRanking());
=======
            //Application.Run(new frmModGerencial());
            //Application.Run(new frmAcessoRestrito());
>>>>>>> feature/analiseiqvia
        }
    }
}
