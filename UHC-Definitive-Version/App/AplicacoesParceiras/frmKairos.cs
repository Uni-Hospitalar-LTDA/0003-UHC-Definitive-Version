using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.AplicacoesParceiras
{
    public partial class frmKairos : CustomForm
    {



        public frmKairos()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureDateTimePickerProperties();





            ConfigureFormEvents();
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmKairos_Load;
        }
        private void frmKairos_Load(object sender, EventArgs e)
        {
            ConfigureButtonEvents();
            ConfigureDateTimePickerEvents();
        }

        /** Configure DateTimePicker **/
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int DTM_GETMONTHCAL = 0x1000 + 8;
        private const int MCM_SETCURRENTVIEW = 0x1000 + 32;
        private void ConfigureDateTimePickerProperties()
        {
            // Define o formato personalizado
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
        }
        private void ConfigureDateTimePickerEvents()
        {
            dateTimePicker1.MouseDown += DateTimePicker1_MouseDown;
        }
        private void DateTimePicker1_MouseDown(object sender, MouseEventArgs e)
        {
            IntPtr calHandle = SendMessage(dateTimePicker1.Handle, DTM_GETMONTHCAL, IntPtr.Zero, IntPtr.Zero);
            SendMessage(calHandle, MCM_SETCURRENTVIEW, IntPtr.Zero, (IntPtr)1);
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {

        }
        private void ConfigureButtonEvents()
        {
            btnAttKairos.Click += btnAttKairos_Click;
            btnOpenKairos.Click += btnOpenKairos_Click;
            btnNotOpen.Click += btnNotOpen_Click;
        }

        private async void btnNotOpen_Click(object sender, EventArgs e)
        {
            frmGeneric_ProgressForm cf = new frmGeneric_ProgressForm();
            cf.chargeText = "Carregando...";
            cf.Show();
            await Kairos.reinstallKairos(dateTimePicker1.Value);
            cf.Close();
        }

        private void btnOpenKairos_Click(object sender, EventArgs e)
        {

            Kairos.StartShortcutFromDesktop();

        }

        private async void btnAttKairos_Click(object sender, EventArgs e)
        {

            frmGeneric_ProgressForm cf = new frmGeneric_ProgressForm();
            cf.chargeText = "Carregando...";
            cf.Show();
            if (!await Kairos.ProcessAndDeleteKairosAsync(dateTimePicker1.Value))
            {
                CustomNotification.defaultAlert("Não há atualização disponível para o mês selecionado.");
            };
            cf.Close();
        }
    }
}
