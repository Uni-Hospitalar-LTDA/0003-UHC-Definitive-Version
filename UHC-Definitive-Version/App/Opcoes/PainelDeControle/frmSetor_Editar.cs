using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    public partial class frmSetor_Editar : CustomForm
    {

        internal Sector setor { get; set; }

        public frmSetor_Editar()
        {
            InitializeComponent();



            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();

            //Events
            ConfigureFormEvents();


        }


        /** Sync Methods **/
        private void getInitialAttributes()
        {
            txtCodSetor.Text = setor.Id;
            txtDescSetor.Text = setor.Description;
            chkAtivo.Checked = (Convert.ToInt16(setor.Status) == 1 ? true : false);            
        }

        /** Configure Form **/
        private void ConfigureFormEvents()
        {

            
            this.Load += frmSetor_Editar_Load;
        }
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void frmSetor_Editar_Load(object sender, EventArgs e)
        {
            //Attributes
            getInitialAttributes();


            //Events
            ConfigureButtonEvents();
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultQuestionCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await updateAsync();
        }      
        private async Task updateAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Sector iSector = new Sector();
                iSector.Id = setor.Id;
                iSector.Description = txtDescSetor.Text;
                iSector.Status = Convert.ToInt16(chkAtivo.Checked).ToString();                
                await Sector.updateAsync(iSector);

                
                this.Cursor = Cursors.Default;

                CustomNotification.defaultInformation("Setor atualizado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtCodSetor.ReadOnly();
        }

        
    }
}
