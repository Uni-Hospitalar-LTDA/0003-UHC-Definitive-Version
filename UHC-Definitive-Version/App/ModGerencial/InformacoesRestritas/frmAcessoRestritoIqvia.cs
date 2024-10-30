using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAcessoRestritoIqvia : CustomForm
    {
        public frmAcessoRestritoIqvia()
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
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmAcessoRestritoIqvia_Load;
        }
        private void frmAcessoRestritoIqvia_Load(object sender, EventArgs e)
        {
            
        }
    }
}
