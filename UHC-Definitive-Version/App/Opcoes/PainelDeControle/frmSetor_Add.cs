using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    public partial class frmSetor_Add : CustomForm
    {
        public frmSetor_Add()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();

            //Events
            ConfigureFormEvents();
            ConfigureButtonEvents();
        }

        

        
        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmSetor_Add_Load;
        }                
        private void frmSetor_Add_Load(object sender, EventArgs e)
        {

        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtDescSetor.MaxLength = 30;
            txtDescSetor.Focus();
        }


        /** Configure Button **/
        private void ConfigureButtonProperties()
        {

        }
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await saveAsync();
        }

        private async Task saveAsync()
        {
            if (txtDescSetor.Text.ToString().Trim().Equals(string.Empty))
            {
                CustomNotification.defaultAlert("O campo descrição não pode ser nulo");
                return;
            }

            try
            {
                List<Sector> sectorsToInsert = new List<Sector>();
                sectorsToInsert.Add(new Sector { Description = txtDescSetor.Text});
                await Sector.insertAsync(sectorsToInsert);
                CustomNotification.defaultInformation("Setor inserido com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
                return;
            }
        }
    }
}
