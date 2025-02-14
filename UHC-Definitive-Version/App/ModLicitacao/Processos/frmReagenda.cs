using System;
using System.Drawing;
using System.Windows.Forms;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.App.ModLicitacao.Processos.AgendaProcessos
{
    public partial class frmReagenda : CustomForm
    {
        public static string MotivoReagendamento;
        public frmReagenda()
        {
            InitializeComponent();            
            ConfigureButtonsProperties();            
            ConfigureFormProperties();
        }

        private void frmReagenda_Load(object sender, EventArgs e)
        {
            lblCreation.Text = "Criação do Reagendamento";
            lblCreation.Font = new Font("Open Sans", 12, FontStyle.Italic);
            this.Text = "Reagendamento";
            this.Icon = Properties.Resources.form_iconpe;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MotivoReagendamento = txtMotivo.Text.ToUpper();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MotivoReagendamento = null;
            this.Close();
        }

       
        private void ConfigureButtonsProperties()
        {
            btnSave.Cursor = Cursors.Hand;
            btnCancel.Cursor = Cursors.Hand;
        }

        private void ConfigureFormProperties()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impede o redimensionamento
            this.MaximizeBox = false; // Desativa o botão de maximizar
        }
  
    }
}
