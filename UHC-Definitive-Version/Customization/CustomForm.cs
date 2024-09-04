using Krypton.Toolkit;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System;

namespace UHC3_Definitive_Version.Customization
{
    public class CustomForm : KryptonForm
    {
        public CustomForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.ResizeRedraw = true;
            this.UpdateStyles();
            this.ShowIcon = true;
            //this.Icon = Properties.Resources.Integra_Cob_Logo1;


            this.KeyDown += CustomForm_KeyDown;
        }

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
