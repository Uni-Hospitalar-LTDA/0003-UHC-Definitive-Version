using System.Collections.Generic;
using System;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.CI;
using System.Threading.Tasks;
using UHC3_Definitive_Version.App.Telas_Genericas;

namespace UHC3_Definitive_Version.App.ModFinanceiro.CI
{
    public partial class frmCI_EncaminhamentoVsCi : CustomForm
    {
        /** Instance **/
        internal string idCi { get; set; }
        private CI_Header header = new CI_Header();
        private CI_Finances_Obs obs = new CI_Finances_Obs();
        public frmCI_EncaminhamentoVsCi()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();

            //Events
            ConfigureFormEvents();
        }


        /** Async Methods **/
        private async Task getCiAsync()
        {
            header = await CI_Header.getToClassAsync(idCi);
            lblIdCi.Text = "Id: " + header.id;
            txtFollowUpId.Text = header.idCI_FollowUp;
            switch (header.status)
            {
                case "P":
                    txtStatus.Text = "Pendente";
                    break;
                case "F":
                    txtStatus.Text = "Aguard. Financeiro";
                    break;
                default:
                    txtStatus.Text = "Concluído";
                    break;
            }
        }

        private async Task getFinanceObs()
        {
            obs = await CI_Finances_Obs.getToClassAsync(idCi);
            txtObservation.Text = obs.observation;
        }

        /** Configure Form Properties **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCI_EncaminhamentoVsCi_Load;
        }
        private async void frmCI_EncaminhamentoVsCi_Load(object sender, EventArgs e)
        {
            //Button Events 
            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
            await getCiAsync();
            await getFinanceObs();
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtFollowUpId.JustNumbers();
            txtFollowUp.MaxLength = 2;

            txtFollowUp.ReadOnly();
            txtStatus.ReadOnly();
        }
        private void ConfigureTextBoxEvents()
        {
            txtFollowUpId.TextChanged += txtFollowUpId_TextChanged;

        }

        private async void txtFollowUpId_TextChanged(object sender, EventArgs e)
        {
            var followup = await CI_FollowUp.getToClassAsync(txtFollowUpId.Text);
            txtFollowUp.Text = followup.description;
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnCancel.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSave.Click += btnSave_Click;
            btnMoreFollowUpers.Click += btnMoreFollowUpers_Click;
            btnSetPendent.Click += btnSetPendent_Click;
            btnSetComplete.Click += btnSetComplete_Click;
            btnAguardandoFinanceiro.Click += btnAguardandoFinanceiro_Click;
        }

        private async void btnAguardandoFinanceiro_Click(object sender, EventArgs e)
        {

            if (CustomNotification.defaultQuestionAlert("O status será alterado para Aguardando Financeiro, deseja prosseguir?") == System.Windows.Forms.DialogResult.Yes)
            {
                await CI_Header.setStatusAsync(header);
                txtStatus.Text = "Aguardando Financeiro";
            }
        }

        private async void btnSetComplete_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFollowUp.Text))
            {
                CustomNotification.defaultAlert("Não é possível concluir uma C.I sem antes atribuir um encaminhamento.");
                return;
            }
            if (CustomNotification.defaultQuestionAlert("O status será alterado para Concluído, deseja prosseguir?") == System.Windows.Forms.DialogResult.Yes)
            {
                await CI_Header.setStatusAsync(header, "C");
                txtStatus.Text = "Concluído";
            }
        }

        private async void btnSetPendent_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert("O status será alterado para Pendente, deseja prosseguir?") == System.Windows.Forms.DialogResult.Yes)
            {
                await CI_Header.setStatusAsync(header, "P");
                txtStatus.Text = "Pendente";
            }
        }

        private async void btnMoreFollowUpers_Click(object sender, EventArgs e)
        {
            frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
            frmGeneric_ConsultaComSelecao.consulta = await CI_FollowUp.getAllToDataTableAsync(null, "1");
            frmGeneric_ConsultaComSelecao.elemento = "Encaminhamentos";
            frmGeneric_ConsultaComSelecao.ShowDialog();
            txtFollowUpId.Text = frmGeneric_ConsultaComSelecao.extendedCode;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            await saveAsync();
        }
        private async Task saveAsync()
        {

            try
            {
                await CI_Finances_Obs.deleteAsync(idCi);
                List<CI_Finances_Obs> obs = new List<CI_Finances_Obs>
            {
                new CI_Finances_Obs
                {
                    idCI_Header = idCi,
                    observation = txtObservation.Text
                }
            };

                if (!string.IsNullOrEmpty(txtFollowUp.Text))
                {
                    header.idCI_FollowUp = txtFollowUpId.Text;
                    header.idUser = Section.idUsuario;
                    header.dateEdited = DateTime.Now.ToString();
                    await CI_Header.updateAsync(header);
                }

                await CI_Finances_Obs.insertAsync(obs);

                CustomNotification.defaultInformation("Encaminhamento adicionado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }        
    }
}
