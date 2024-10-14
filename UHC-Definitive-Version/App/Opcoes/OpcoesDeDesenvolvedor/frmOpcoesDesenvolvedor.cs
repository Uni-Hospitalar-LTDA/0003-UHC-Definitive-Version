using System;
using System.Drawing;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.App.Opcoes.OpcoesDeDesenvolvedor
{
    public partial class frmOpcoesDesenvolvedor : CustomForm
    {
        /** Instance **/
        private RollBackInfo rollBackInfo { get; set; } = new RollBackInfo();


        public frmOpcoesDesenvolvedor()
        {
            InitializeComponent();


            //Properties 
            ConfigureFormProperties();



            //Events 
            ConfigureFormEvents();
           
        }

       
        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmOpcoesDesenvolvedor_Load;
        }
        private async void frmOpcoesDesenvolvedor_Load(object sender, EventArgs e)
        {
            ConfigureButtonEvents();

            rollBackInfo = await RollBackInfo.getToClasAsync();
            definirCorInicialBotao();

        }

        private void definirCorInicialBotao()
        {            
            if (rollBackInfo.rollbackActivated == "1")
            {
                btnAtivarRollBack.Text = "Desativar Rollback";
                btnAtivarRollBack.BackColor = Color.IndianRed;
                
            }
            else
            {
                btnAtivarRollBack.Text = "Ativar Rollback";
                btnAtivarRollBack.BackColor = Color.DarkSeaGreen;
            }
        }

        /** Button Configuration **/
        private void ConfigureButtonEvents()
        {
            btnPermissoes.Click += btnPermissoes_Click;
            btnLiberarUpdate.Click += btnLiberarUpdate_Click;
            btnAtivarRollBack.Click += btnAtivarRollBack_Click;
            btnBasesSwagger.Click += btnBasesSwagger_Click;
        }

        private void btnBasesSwagger_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmBasesSwagger>();
        }

        private async void btnAtivarRollBack_Click(object sender, EventArgs e)
        {

            if (CustomNotification.defaultQuestionAlert() == System.Windows.Forms.DialogResult.Yes)
            {
                if (rollBackInfo.rollbackActivated == "1")
            {
               
                rollBackInfo.rollbackActivated = "0";                
                definirCorInicialBotao();
                await RollBackInfo.updateAsync(rollBackInfo,"id");
                
            }
            else
            {                
                    rollBackInfo.rollbackActivated = "1";
                    definirCorInicialBotao();
                    await RollBackInfo.updateAsync(rollBackInfo,"id");                
            }
            };
        }

        private void btnLiberarUpdate_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmLiberarUpdate>();
        }

        private void btnPermissoes_Click(object sender, EventArgs e)
        {
            FormConfiguration.ShowOrActivateForm<frmPermissoes>();
        }
    }
}
