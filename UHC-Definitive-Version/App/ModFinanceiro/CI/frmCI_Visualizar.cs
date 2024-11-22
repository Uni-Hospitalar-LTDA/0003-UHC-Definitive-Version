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
using UHC3_Definitive_Version.Domain.Entities.CI;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModFinanceiro.CI
{
    public partial class frmCI_Visualizar : CustomForm
    {
        internal string id { get; set; }
        private CI_Header header { get; set; }

        public frmCI_Visualizar()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();


            //Events
            ConfigureFormEvents();
        }


        /** Async Tasks **/
        private async Task getCiAsync()
        {
            header = await CI_Header.getToClassAsync(id);
            lblIdCi.Text = "Id: " + header.id;
            txtReasonId.Text = header.idCI_Reason;
            txtResponsibleId.Text = header.idCI_Responsible;
            txtCustomerId.Text = header.idCustomer;
            txtTransporterId.Text = header.idTransporter;
            txtNF_rebill.Text = header.nfRebill;
            txtObservation.Text = header.observation;
            switch (header.operationType)
            {
                case "P":
                    rdbPartialDevolution.Checked = true;
                    break;
                case "T":
                    rdbTotalReturn.Checked = true;
                    break;
                default:
                    rdbWithoutDevolution.Checked = true;
                    break;
            }
            switch (header.status)
            {
                case "P":
                    txtStatus.Text = "Pendente";
                    break;
                case "F":
                    txtStatus.Text = "Aguard. Financeiro";
                    break;
                default:
                    txtStatus.Text = "Concluído";
                    break;
            }
            switch (Convert.ToInt16(header.physicalReturn))
            {
                case 1:
                    rdbSim.Checked = true;
                    break;
                default:
                    rdbNao.Checked = true;
                    break;
            }
            gpbOperationType.Enabled = false;
            gpbPhysicalReturn.Enabled = false;

            txtRegister.Text = header.dateCreated?.ToString();
            txtEdited.Text = header.dateEdited?.ToString();
        }
        private async Task getReturnsAsync()
        {
            var list = await CI_ReturnNF.getAllToListAsync(id);
            lsbNFReturn.Items.AddRange(list.Select(item => item.NF_Return).ToArray());
        }
        private async Task getOriginsAsync()
        {
            var list = await CI_OriginNF.getAllToListAsync(id);
            lsbNFOrigin.Items.AddRange(list.Select(item => item.NF_Origin).ToArray());
        }
        private async Task getProducts()
        {
            dgvProducts.DataSource = await CI_Itens.getAllToDataTableAsync(id);
            dgvProducts.toDefault();
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCI_Visualizar_Load;
        }

        private async void frmCI_Visualizar_Load(object sender, EventArgs e)
        {

            ConfigureTextBoxEvents();

            ConfigureButtonProperties();

            //Changed Attributes (Event dependent)
            await getCiAsync();
            await getReturnsAsync();
            await getOriginsAsync();
            await getProducts();
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnCancel.toDefaultCloseButton();
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtStatus.ReadOnly();
            txtRegister.ReadOnly();
            txtEdited.ReadOnly();
            txtCustomerId.ReadOnly();
            txtCustomer.ReadOnly();
            txtReasonId.ReadOnly();
            txtReason.ReadOnly();
            txtResponsible.ReadOnly();
            txtTransporter.ReadOnly();
            txtResponsibleId.ReadOnly();
            txtTransporterId.ReadOnly();
            txtNF_rebill.ReadOnly();
            txtObservation.ReadOnly();

        }
        private void ConfigureTextBoxEvents()
        {
            txtCustomerId.TextChanged += txtCustomerId_TextChanged;
            txtReasonId.TextChanged += txtReasonId_TextChanged;
            txtResponsibleId.TextChanged += txtResponsibleId_TextChanged;
            txtTransporterId.TextChanged += txtTransporterId_TextChanged;
            txtNF_rebill.LostFocus += txtNF_rebill_LostFocus;
        }
        private async void txtNF_rebill_LostFocus(object sender, EventArgs e)
        {
            var nf = await CI_Header.checkNfRebillUsabilityAsync(txtNF_rebill.Text);

            if (nf.Rows.Count == 0 & !string.IsNullOrEmpty(txtNF_rebill.Text))
            {
                CustomNotification.defaultAlert("Nota fiscal inválida.");
                txtNF_rebill.Clear();
                txtNF_rebill.Focus();
                return;
            }
        }
        private void txtCustomerId_TextChanged(object sender, System.EventArgs e)
        {
            txtCustomer.Text = Clientes_Externos.getDescripionByCode(txtCustomerId.Text);
        }
        private async void txtReasonId_TextChanged(object sender, EventArgs e)
        {
            CI_Reason selectedReason = await CI_Reason.getToClassAsync(txtReasonId.Text);
            txtReason.Text = selectedReason.description;
        }
        private async void txtResponsibleId_TextChanged(object sender, EventArgs e)
        {
            var responsible = await CI_Responsible.getToClassAsync(txtResponsibleId.Text);
            txtResponsible.Text = responsible.description;
        }
        private async void txtTransporterId_TextChanged(object sender, EventArgs e)
        {
            txtTransporter.Text = await Transportadores_Externos.getDescriptionByCode(txtTransporterId.Text);
        }
    }
}
