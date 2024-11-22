using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.ModFinanceiro.Cobranca
{
    public partial class frmParametrosDeCobranca : CustomForm
    {

        ChargingSections chargingSections = new ChargingSections();
        ChargingParameters chargingParameters = new ChargingParameters();


        public frmParametrosDeCobranca()
        {
            InitializeComponent();


            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();


            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private async Task save()
        {
            try
            {

                List<ChargingSections> css = new List<ChargingSections>();
                css.Add(new ChargingSections
                {
                    DueDateNotification = Convert.ToInt16(chkDueDateNotification.Enabled).ToString()
                });


                await ChargingSections.deleteAsync();
                await ChargingSections.insertAsync(css);

                await ChargingParameters.deleteAsync();
                List<ChargingParameters> chargingParameters = new List<ChargingParameters>();
                chargingParameters.Add(new ChargingParameters()
                {
                    DaysDueDateAlert = txtDaysDueDateAlert.Text
                    ,
                    DaysPostDueDateAlert = txtDaysPostDueDateAlert.Text
                    ,
                    DaysRecoveryNotification = txtDaysRecoveryNotification.Text
                    ,
                    NotifyOnDueDate = Convert.ToInt16(chkNotifyOnDueDate.Checked).ToString()
                });
                await ChargingParameters.insertAsync(chargingParameters);
                CustomNotification.defaultInformation();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }

        }

        private async Task getInfoFromDB()
        {
            chargingSections = await ChargingSections.getClassAsync();
            chargingParameters = await ChargingParameters.getToClassAsync();
        }
        /** Configure Form **/
        private void ConfigureFormEvents()
        {
            this.Load += frmParametrosDeCobranca_Load;
        }
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private async void frmParametrosDeCobranca_Load(object sender, EventArgs e)
        {
            await getInfoFromDB();


            ConfigureButtonEvents();
            ConfigureTextBoxAttributes();
            ConfigureCheckBoxEvents();
            chkDueDateNotification_CheckedChanged(sender, e);
        }

        private void ConfigureCheckBoxEvents()
        {
            chkDueDateNotification.CheckedChanged += chkDueDateNotification_CheckedChanged;
        }
        private void chkDueDateNotification_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDueDateNotification.Checked)
            {
                foreach (Control cc in gpbNotification.Controls)
                {
                    if (cc.Name != "chkDueDateNotification")
                        cc.Enabled = false;
                }
            }
            else
            {
                foreach (Control cc in gpbNotification.Controls)
                {
                    cc.Enabled = true;
                }
            }
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxAttributes()
        {
            txtDaysDueDateAlert.Text = (string.IsNullOrEmpty(chargingParameters.DaysDueDateAlert) ? "0" : chargingParameters.DaysDueDateAlert);
            txtDaysPostDueDateAlert.Text = (string.IsNullOrEmpty(chargingParameters.DaysPostDueDateAlert) ? "0" : chargingParameters.DaysPostDueDateAlert);
            txtDaysRecoveryNotification.Text = (string.IsNullOrEmpty(chargingParameters.DaysRecoveryNotification) ? "0" : chargingParameters.DaysRecoveryNotification);
            chkNotifyOnDueDate.Checked = Convert.ToBoolean(Convert.ToInt16(chargingParameters.NotifyOnDueDate));

            chkDueDateNotification.Checked = Convert.ToBoolean(Convert.ToInt16(chargingSections.DueDateNotification));
        }
        private void ConfigureTextBoxProperties()
        {
            txtDaysDueDateAlert.MaxLength = 4;
            txtDaysPostDueDateAlert.MaxLength = 4;
            txtDaysRecoveryNotification.MaxLength = 4;

            txtDaysDueDateAlert.JustNumbers();
            txtDaysPostDueDateAlert.JustNumbers();
            txtDaysRecoveryNotification.JustNumbers();
        }

        /** Configure Buttons **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSave.Click += btnSave_Click;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await save();
        }
    }
}
