using OfficeOpenXml.Drawing.Slicer.Style;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.Opcoes.OpcoesDeDesenvolvedor
{
    public partial class frmBasesSwagger_Add : CustomForm
    {
        public frmBasesSwagger_Add()
        {
            InitializeComponent();


            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();

            //Events
            ConfigureFormEvents();
        }

        /** Async Task **/
        private async Task saveAsync()
        {
            try
            {
                this.requiredInformationValidation();
                
                saving(true);
                CredenciaisSwagger cs = new CredenciaisSwagger();

                cs.Description = txtDescricao.Text;
                cs.Observation = txtObservation.Text;
                cs.RotaSwagger = txtRotaSwagger.Text;
                cs.LoginSwagger = txtLoginSwagger.Text;
                cs.SenhaSwagger = Cryptography.crypt(txtSenha.Text);
                cs.Matricula = txtMatricula.Text;                

                await CredenciaisSwagger.insertAsync(cs);

                saving(false);
            }
            catch (Exception ex) 
            {
                CustomNotification.defaultError("Erro ao inserir Base Swagger "+ex.Message);
            }

        }
        private void saving(bool saving = true)
        {
            if (saving)
            {
                this.Cursor = Cursors.WaitCursor;
                btnSalvar.Enabled = !saving;
                btnCancelar.Enabled = !saving;
            }
            else
            {
                this.Cursor = Cursors.Default;
                btnSalvar.Enabled = !saving;
                btnCancelar.Enabled = !saving;
                CustomNotification.defaultInformation();
                this.Close();
            }
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmBasesSwagger_Add_Load;
        }
        private void frmBasesSwagger_Add_Load(object sender, EventArgs e)
        {
            ConfigureButtonEvents();
        }


        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {

        }
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;            
        }

        private async  void btnSalvar_Click(object sender, EventArgs e)
        {
            await saveAsync();
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtDescricao.MaxLength = 255;
            txtObservation.ScrollBars = ScrollBars.Vertical;
            txtRotaSwagger.MaxLength = 255;
            txtLoginSwagger.MaxLength = 50;
            txtMatricula.MaxLength = 50;
        }

        
    }
}
