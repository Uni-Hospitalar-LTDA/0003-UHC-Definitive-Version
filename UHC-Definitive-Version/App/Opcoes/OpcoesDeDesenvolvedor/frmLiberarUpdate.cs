using System;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.App.Opcoes.OpcoesDeDesenvolvedor
{
    public partial class frmLiberarUpdate : CustomForm
    {
        public frmLiberarUpdate()
        {
            InitializeComponent();


            //Properties
            ConfigureFormProperties();

            //Properties
            ConfigureFormEvents();

        }

        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }

        private void ConfigureFormEvents()
        {
            ConfigureButtonEvents();
        }

        private void ConfigureButtonEvents()
        {
            btnSave.Click += btnSave_Click;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                await IntUpdate.insertAsync(new IntUpdate { Version = txtVersion.Text , Description = txtDescricao.Text});
                CustomNotification.defaultInformation();
                txtDescricao.ReadOnly();
                txtVersion.ReadOnly();
            }
            catch (Exception ex) 
            {
                CustomNotification.defaultError(ex.Message);
            }
        }
    }
}
