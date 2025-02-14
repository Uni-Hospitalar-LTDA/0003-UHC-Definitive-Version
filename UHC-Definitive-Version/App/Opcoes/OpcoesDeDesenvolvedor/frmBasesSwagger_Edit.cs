using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.Opcoes.OpcoesDeDesenvolvedor
{
    public partial class frmBasesSwagger_Edit : CustomForm
    {
        internal CredenciaisSwagger cs { get; set; }

        public frmBasesSwagger_Edit()
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
        private async Task updateAsync()
        {
            try
            {
                this.requiredInformationValidation();

                saving(true);
                

                cs.Description = txtDescricao.Text;
                cs.Observation = txtObservation.Text;
                cs.RotaSwagger = txtRotaSwagger.Text;
                cs.LoginSwagger = txtLoginSwagger.Text;
                cs.SenhaSwagger = Cryptography.crypt(txtSenha.Text);
                cs.Matricula = txtMatricula.Text;
                cs.Status = Convert.ToInt16(chkStatus.Checked).ToString();
                await CredenciaisSwagger.updateAsync(cs,"id");

                saving(false);
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError("Erro ao inserir Base Swagger " + ex.Message);
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
        private void getData()
        {
            txtId.Text = cs.id;
            txtDescricao.Text = cs.Description;
            txtObservation.Text = cs.Observation;
            txtRotaSwagger.Text = cs.RotaSwagger;
            txtLoginSwagger.Text = cs.LoginSwagger;
            txtSenha.Text = Cryptography.decrypt(cs.SenhaSwagger);
            txtMatricula.Text = cs.Matricula;
            chkStatus.Checked = Convert.ToBoolean(Convert.ToInt16(cs.Status));
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
            getData();
            ConfigureButtonEvents();
        }


        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await updateAsync();
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtId.ReadOnly();
            txtDescricao.MaxLength = 255;
            txtObservation.ScrollBars = ScrollBars.Vertical;
            txtRotaSwagger.MaxLength = 255;
            txtLoginSwagger.MaxLength = 50;
            txtMatricula.MaxLength = 50;
        }
    }
}
