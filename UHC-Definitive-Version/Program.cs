using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.App;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLoginNew());
        }
    }
}
