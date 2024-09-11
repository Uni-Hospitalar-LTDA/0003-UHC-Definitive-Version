using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.App.ModGerencial
{
    public partial class frmControladoria : CustomForm
    {
        /** Screen Permission **/
        public frmControladoria()
        {
            InitializeComponent();            

            btnClose.toDefaultCloseButton();
        }


        /** Event Load **/
        private async void frmControladoria_Load(object sender, EventArgs e)
        {
            await Section.carregar_Dependencias();
            this.BackgroundImage = Properties.Resources.Background_Office_Gray;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            

            //Configurando botões
            this.atribuirAtributosAosLabels();



            //blocks();
            //allows();
        }


        /** Allows and Blocks **/
        private void blocks()
        {            
            //Screens
            lblArquivosIMS.Enabled = false;
        }
        private void allows()
        {
            ////SubModulo

            //if (PermissionsAllowed.subModules.Find(m => m.Id == "1") != null)
            //    pcbLogo.Enabled = true;

            ////Screens
            //if (PermissionsAllowed.screens.Find(m => m.Id == "1") != null)
            //    lblUsuarios.Enabled = true;
            //if (PermissionsAllowed.screens.Find(m => m.Id == "2") != null)
            //    lblSetores.Enabled = true;
            //if (PermissionsAllowed.screens.Find(m => m.Id == "3") != null)
            //    lblPermissoes.Enabled = true;
        }


        /** System Buttons **/
        private void lblArquivosIMS_Click(object sender, EventArgs e)
        {
            frmControladoria_Arquivos_IQVIA frmControladoria_ArquivosIMS = new frmControladoria_Arquivos_IQVIA();
            frmControladoria_ArquivosIMS.ShowDialog();
        }


    }
}
