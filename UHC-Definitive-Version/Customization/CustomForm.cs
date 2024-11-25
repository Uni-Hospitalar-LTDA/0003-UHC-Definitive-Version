using Krypton.Toolkit;
using System.Windows.Forms;
using System.Drawing;
using UHC3_Definitive_Version.Configuration;
using System.Diagnostics;
using System;
using UHC3_Definitive_Version.App.Telas_Genericas;
using System.Threading;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Customization
{
    public class CustomForm : KryptonForm
    {
        private Icon cachedIcon = null;
        private System.Windows.Forms.Timer memoryMonitorTimer;  // Corrigido para usar o Timer correto do Windows Forms
        private const long MemoryLimitBytes = 800 * 1024 * 1024; // 800 MB em bytes

        public CustomForm()
        {
            // Centralizar na tela e definir algumas configurações básicas
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.ResizeRedraw = true;
            this.UpdateStyles();
            this.ShowIcon = true;                 
            // Definir o ícone com base na unidade da sessão
            SetFormIcon();

            // Aplicar estilo de cores ao form
            ApplyCustomStyle();

            // Aplicar o papel de parede (background) reutilizando a imagem
            //FormConfiguration.defaultModuleScreen(this);

            // Vincular eventos
            this.KeyDown += CustomForm_KeyDown;
            this.FormClosed += CustomForm_FormClosed;

            // Configurar o monitoramento de memória
            ConfigureMemoryMonitoring();
        }


        // Configura o monitoramento de memória com um timer do Windows Forms
        private void ConfigureMemoryMonitoring()
        {
            memoryMonitorTimer = new System.Windows.Forms.Timer();
            memoryMonitorTimer.Interval = 10000; // Verifica a cada 10 segundos
            memoryMonitorTimer.Tick += MemoryMonitorTimer_Tick;
            memoryMonitorTimer.Start();
        }

        private void MemoryMonitorTimer_Tick(object sender, EventArgs e)
        {
            MonitorMemoryUsage();
        }

        // Método para monitorar o uso de memória e fechar formulários inativos se necessário
        private void MonitorMemoryUsage()
        {
            Process currentProcess = Process.GetCurrentProcess();
            long memoryUsage = currentProcess.PrivateMemorySize64;

            if (memoryUsage > MemoryLimitBytes)
            {
                // Aciona a coleta de lixo para liberar memória
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                // Verifica novamente após a coleta
                memoryUsage = currentProcess.PrivateMemorySize64;

                if (memoryUsage > MemoryLimitBytes)
                {
                    //MessageBox.Show("O limite de memória foi atingido. Fechando formulários inativos para liberar recursos.",
                    //                "Aviso de Memória",
                    //                MessageBoxButtons.OK,
                    //                MessageBoxIcon.Warning);

                    // Fecha formulários inativos ou menos importantes
                    //CloseInactiveForms();
                }
            }
        }

        // Método para fechar formulários inativos e liberar memória
        private void CloseInactiveForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                // Fechar formulários inativos ou menos importantes, exceto o principal
                if (!form.Focused && form.Name != "MainForm")
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

        // Define ícone baseado na unidade, com cache
        private void SetFormIcon()
        {
            if (cachedIcon == null)
            {
                cachedIcon = Properties.Resources.form_iconpe;
                if (Section.Unidade == "UNI CEARÁ")
                    cachedIcon = Properties.Resources.form_iconce;
                else if (Section.Unidade == "SP HOSPITALAR")
                    cachedIcon = Properties.Resources.form_iconsp;
            }
            this.Icon = cachedIcon;  // Reutiliza o ícone carregado
        }

        // Aplica o estilo personalizado ao formulário, com bordas em degradê
        private void ApplyCustomStyle()
        {
            this.StateCommon.Back.Color1 = Color.FromArgb(153, 0, 0);  // Vermelho escuro do logo
            this.StateCommon.Back.Color2 = Color.FromArgb(130, 0, 0);  // Tom mais suave de vermelho

            this.StateCommon.Header.Back.Color1 = Color.FromArgb(153, 0, 0);
            this.StateCommon.Header.Back.Color2 = Color.FromArgb(130, 0, 0);

            Color darkRed = Color.FromArgb(139, 0, 0);
            Color lightRed = Color.FromArgb(0, 0, 0);

            this.StateCommon.Border.Color1 = darkRed;
            this.StateCommon.Border.Color2 = lightRed;
            this.StateCommon.Border.ColorAngle = 45f;
            this.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;
            this.StateCommon.Border.Width = 5;

            this.StateCommon.Header.Content.ShortText.Color1 = Color.White;

            StyleButtons();
        }

        // Estilizar os botões com as cores do logo (vermelho e cinza metálico)
        private void StyleButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is KryptonButton button)
                {
                    button.StateCommon.Back.Color1 = Color.FromArgb(153, 0, 0);
                    button.StateCommon.Back.Color2 = Color.FromArgb(130, 0, 0);
                    button.StateCommon.Border.Color1 = Color.FromArgb(128, 128, 128);
                    button.StateCommon.Border.Color2 = Color.FromArgb(128, 128, 128);
                    button.StateCommon.Border.Rounding = 5;
                    button.StateCommon.Content.ShortText.Color1 = Color.White;
                    button.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    button.StateTracking.Back.Color1 = Color.FromArgb(180, 0, 0);
                    button.StateTracking.Back.Color2 = Color.FromArgb(160, 0, 0);
                }
            }
        }

        // Evento de fechamento para liberar recursos
        private void CustomForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Libera explicitamente os recursos do formulário quando ele for fechado
            this.Dispose();

            // Força a coleta de lixo para liberar memória de objetos não referenciados
            GC.Collect();
        }

        // Evento de fechamento ao pressionar ESC
        private void CustomForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Escape == e.KeyData)
            {
                if (Application.OpenForms.Count == 3)
                {
                    if (CustomNotification.defaultQuestionAlert("A aplicação será encerrada, deseja continuar?") == DialogResult.Yes)
                        Application.Exit();
                }
                else
                {
                    if (this.Text.Contains("Adicionar") || this.Text.Contains("Editar"))
                    {
                        if (CustomNotification.defaultQuestionAlert("Tem certeza que deseja fechar a tela?") == DialogResult.Yes)
                            this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }

        // Método com barra de progresso, com melhorias de cancelamento e gerenciamento de threads
        public async void RunMethodWithProgressBar(Action<Action<int>, CancellationToken> method)
        {
            using (var frmGeneric_ProgressForm = new frmGeneric_ProgressForm())
            {
                frmGeneric_ProgressForm.chargeText = "Carregando...";
                frmGeneric_ProgressForm.Show();

                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                CancellationToken cancellationToken = cancellationTokenSource.Token;
                TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();

                Thread staThread = new Thread(() =>
                {
                    try
                    {
                        method(frmGeneric_ProgressForm.UpdateProgress, cancellationToken);
                        tcs.SetResult(null);
                    }
                    catch (OperationCanceledException)
                    {
                        tcs.SetCanceled();
                    }
                    catch (Exception ex)
                    {
                        tcs.SetException(ex);
                    }
                    finally
                    {
                        if (frmGeneric_ProgressForm.IsHandleCreated)
                        {
                            frmGeneric_ProgressForm.Invoke(new Action(() => frmGeneric_ProgressForm.Close()));
                        }
                    }
                });

                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start();

                bool isCanceled = false;
                bool wasSuccessful = false;
                frmGeneric_ProgressForm.SetCancellationTokenSource(cancellationTokenSource, () => isCanceled = true);

                try
                {
                    await tcs.Task;
                    wasSuccessful = true;
                }
                catch (OperationCanceledException)
                {
                    CustomNotification.defaultAlert("A operação foi cancelada.");
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultAlert($"Ocorreu um erro durante a operação: {ex.Message}");
                }
                finally
                {
                    if (wasSuccessful && !isCanceled)
                    {
                        CustomNotification.defaultInformation("A operação foi concluída com sucesso!");
                    }
                }
            }
        }
    }
}
