using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Threading;

namespace UHC3_Definitive_Version.App.Telas_Genericas
{
    public partial class frmGeneric_ProgressForm : CustomForm
    {
        /** Instance **/
        private Action onCancel;
        public CancellationTokenSource cancellationTokenSource { get; private set; } = new CancellationTokenSource();
        public bool IsCancelled { get; private set; } = false;
        public string chargeText { get; set; } = "Exportando...";


        public frmGeneric_ProgressForm()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureLabelProperties();
            //Events
            ConfigureFormEvents();            
        }

        private void ConfigureLabelProperties()
        {
            lblCarregando.Text = chargeText;
        }

        private void ConfigureFormEvents()
        {            
            
            

            //Events
            ConfigureButtonEvents();
        }

        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }

        /** Sync Methods **/
        public void UpdateProgress(int progress)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action<int>(UpdateProgress), progress);
            }
            else
            {
                progressBar.Value = progress;
            }
        }
        public void SetCancellationTokenSource(CancellationTokenSource cancellationTokenSource, Action onCancel)
        {
            this.cancellationTokenSource = cancellationTokenSource;
            this.onCancel = onCancel;
        }

        /** Configure Button **/
        private void ConfigureButtonEvents()
        {
            btnCancelar.Click += btnCancelar_Click;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            onCancel();
            CustomNotification.defaultAlert("Operação cancelada pelo usuário.");
            this.Close();
        }
    }
}
