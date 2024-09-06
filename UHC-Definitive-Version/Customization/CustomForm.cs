using Krypton.Toolkit;
using System.Windows.Forms;
using System.Drawing;
using UHC3_Definitive_Version.Configuration;
using System.Threading.Tasks;
using System.Threading;
using System;
using UHC3_Definitive_Version.App.Telas_Genericas;

namespace UHC3_Definitive_Version.Customization
{
    public class CustomForm : KryptonForm
    {
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

            // Vincular eventos
            this.KeyDown += CustomForm_KeyDown;
        }

        // Define ícone baseado na unidade
        private void SetFormIcon()
        {
            this.Icon = Properties.Resources.form_iconpe;

            if (Section.Unidade == "UNI CEARÁ")
                this.Icon = Properties.Resources.form_iconce;
            if (Section.Unidade == "SP HOSPITALAR")
                this.Icon = Properties.Resources.form_iconsp;
        }

        // Aplica o estilo personalizado ao formulário, com bordas em degradê
        private void ApplyCustomStyle()
        {
            // Definir fundo com o vermelho predominante
            this.StateCommon.Back.Color1 = Color.FromArgb(153, 0, 0);  // Vermelho escuro do logo
            this.StateCommon.Back.Color2 = Color.FromArgb(130, 0, 0);  // Tom mais suave de vermelho

            this.StateCommon.Header.Back.Color1 = Color.FromArgb(153, 0, 0);  // Vermelho escuro do logo
            this.StateCommon.Header.Back.Color2 = Color.FromArgb(130, 0, 0);  // Tom mais suave de vermelho

            // Aplicar borda degradê no formulário
            Color darkRed = Color.FromArgb(139, 0, 0);  // Vermelho escuro
            Color lightRed = Color.FromArgb(0, 0, 0);  // Vermelho mais claro

            this.StateCommon.Border.Color1 = darkRed;  // Degradê começa com vermelho escuro
            this.StateCommon.Border.Color2 = lightRed;  // Termina com vermelho claro
            this.StateCommon.Border.ColorAngle = 45f;  // Ângulo do degradê
            this.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;  // Aplicar o degradê em todas as bordas
            this.StateCommon.Border.Width = 5;  // Tamanho da borda

            // Texto branco para contraste no cabeçalho
            this.StateCommon.Header.Content.ShortText.Color1 = Color.White;

            // Aplicar a outros controles como botões e caixas de texto
            StyleButtons();
        }

        // Estilizar os botões com as cores do logo (vermelho e cinza metálico)
        private void StyleButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is KryptonButton button)
                {
                    button.StateCommon.Back.Color1 = Color.FromArgb(153, 0, 0);  // Fundo vermelho escuro
                    button.StateCommon.Back.Color2 = Color.FromArgb(130, 0, 0);  // Fundo suave de vermelho

                    button.StateCommon.Border.Color1 = Color.FromArgb(128, 128, 128);  // Borda cinza metálico
                    button.StateCommon.Border.Color2 = Color.FromArgb(128, 128, 128);
                    button.StateCommon.Border.Rounding = 5;  // Bordas levemente arredondadas

                    button.StateCommon.Content.ShortText.Color1 = Color.White;  // Texto branco
                    button.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                    // Efeitos de hover e clique suaves
                    button.StateTracking.Back.Color1 = Color.FromArgb(180, 0, 0);  // Fundo mais claro ao passar o mouse
                    button.StateTracking.Back.Color2 = Color.FromArgb(160, 0, 0);
                }
            }
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
                        this.Close();
                }
            }
        }

        public async void RunMethodWithProgressBar(Action<Action<int>, CancellationToken> method)
        {
            // Cria e exibe o formulário da barra de progresso
            frmGeneric_ProgressForm frmGeneric_ProgressForm = new frmGeneric_ProgressForm();
            frmGeneric_ProgressForm.Show();

            // Cria um CancellationToken para controle de cancelamento
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            // Cria um CancellationTokenSource para controle de cancelamento
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            // Cria um TaskCompletionSource
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();

            // Executa o método em uma nova thread STA
            Thread staThread = new Thread(() =>
            {
                try
                {
                    method(frmGeneric_ProgressForm.UpdateProgress, cancellationToken);
                    tcs.SetResult(null);
                }
                catch (OperationCanceledException)
                {
                    // A operação foi cancelada pelo usuário
                    tcs.SetCanceled();
                }
                catch (Exception ex)
                {
                    // Um erro ocorreu durante a execução do método
                    tcs.SetException(ex);
                }
                finally
                {
                    // Fecha o formulário da barra de progresso                    
                    if (frmGeneric_ProgressForm.IsHandleCreated)
                    {
                        frmGeneric_ProgressForm.Invoke(new Action(() => frmGeneric_ProgressForm.Close()));
                    }
                    else
                    {
                        EventHandler handleCreatedHandler = null;
                        handleCreatedHandler = new EventHandler((sender, e) =>
                        {
                            frmGeneric_ProgressForm.Invoke(new Action(() => frmGeneric_ProgressForm.Close()));
                            frmGeneric_ProgressForm.HandleCreated -= handleCreatedHandler;
                        });

                        frmGeneric_ProgressForm.HandleCreated += handleCreatedHandler;
                    }
                    //Form.ActiveForm.Invoke(new Action(() => ActiveForm.Focus()));
                }
            });

            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();

            if (frmGeneric_ProgressForm != null)
            {
                bool isCanceled = false;
                bool wasSuccessful = false;
                frmGeneric_ProgressForm.SetCancellationTokenSource(cancellationTokenSource, () => isCanceled = true);

                try
                {
                    await tcs.Task;
                    wasSuccessful = true;
                    isCanceled = false;

                }
                catch (OperationCanceledException)
                {
                    CustomNotification.defaultAlert("A exportação foi cancelada.");

                }
                catch (Exception ex)
                {
                    CustomNotification.defaultAlert($"Ocorreu um erro durante a exportação - {ex.Message}");
                    //MaterialMessageBox.Show(ex.Message);
                }
                finally
                {
                    if (wasSuccessful && !isCanceled)
                    {

                        this.Invoke((MethodInvoker)delegate
                        {
                            //Gambiarra, não sei pq mas só pega assim
                            CustomNotification.defaultInformation("A operação foi concluída com sucesso!");
                        });
                    }

                }

            }
        }
    }
}
