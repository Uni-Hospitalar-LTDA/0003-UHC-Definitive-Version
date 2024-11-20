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
using UHC3_Definitive_Version.Domain.Entities.NewIqvia;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAcessoRestrito : CustomForm
    {

        public frmAcessoRestrito()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureDataGridViewProperties();

            //Events
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private async Task getDados()
        {

            string filter = txtPesquisar.Text;
            List<string> vStatus = new List<string>();
            if (chkAtivos.Checked)
                vStatus.Add("1");
            if (chkInativos.Checked)
                vStatus.Add("0");
            string status = string.Join(",", vStatus);

            dgvData.DataSource = await IqviaRestriction.getAllToDataTableAsync(filter, (string.IsNullOrEmpty(status) ? "3" : status),dtpDataFinal.Value);            
            dgvData.AutoResizeColumns();
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
            //Pr[e events
            ConfigureDateTimePickerAttributes();


            //Events
            ConfigureButtonEvents();


            //Pos events
            btnPesquisar_Click(null, null);

        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnAdicionar.Click += btnAdicionar_Click;
            btnPesquisar.Click += btnPesquisar_Click;
            btnEditar.Click += btnEditar_Click;
        }
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow  != null) 
            {
                frmAcessoRestrito_Edit frmAcessoRestritoIqvia_Edit = new frmAcessoRestrito_Edit();
                frmAcessoRestritoIqvia_Edit.iqviaRestriction = await IqviaRestriction.getToClassAsync(dgvData.CurrentRow.Cells[0]?.Value.ToString());
                frmAcessoRestritoIqvia_Edit.iqviaRestrictionItens = await IqviaRestrictionItens.getByCodeToListAsync(dgvData.CurrentRow.Cells[0]?.Value.ToString());
                frmAcessoRestritoIqvia_Edit.ShowDialog();
            }
        }
        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            await getDados();
        }
        private async void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmAcessoRestrito_Add frmAcessoRestritoIqvia_Add = new frmAcessoRestrito_Add();
            frmAcessoRestritoIqvia_Add.ShowDialog();
            await getDados();
        }

      

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /** Configure DateTimePicker**/ 
        private void ConfigureDateTimePickerAttributes()
        {
            dtpDataFinal.Value = DateTime.Now;  
        }
            
    }
}
