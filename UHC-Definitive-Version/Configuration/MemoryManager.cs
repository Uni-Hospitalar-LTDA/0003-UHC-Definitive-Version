using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHC3_Definitive_Version.Configuration
{
    public class MemoryManager
    {
        private const long MemoryLimitBytes = 800 * 1024 * 1024; // 800 MB em bytes

        // Método para monitorar o uso de memória
        public static void MonitorMemoryUsage()
        {
            // Obtém o processo atual
            Process currentProcess = Process.GetCurrentProcess();

            // Verifica o uso de memória
            long memoryUsage = currentProcess.PrivateMemorySize64;

            if (memoryUsage > MemoryLimitBytes)
            {
                // Aciona a coleta de lixo para liberar memória
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                // Verifica novamente após a coleta
                memoryUsage = currentProcess.PrivateMemorySize64;

                // Se ainda estiver acima do limite, exibir alerta ou tomar outras ações
                if (memoryUsage > MemoryLimitBytes)
                {
                    MessageBox.Show("O limite de memória foi atingido. A aplicação pode fechar formulários inativos ou encerrar processos para liberar recursos.",
                                    "Aviso de Memória",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    // Você pode fechar formulários não essenciais aqui ou parar certas operações
                    CloseInactiveForms();
                }
            }
        }

        // Método para fechar formulários inativos e liberar memória
        private static void CloseInactiveForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                // Fechar formulários inativos ou menos importantes
                if (!form.Focused && form.Name != "MainForm") // Exceção para o form principal
                {
                    form.Close();
                    form.Dispose();
                }
            }

            // Força a coleta de lixo novamente após fechar os formulários
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
