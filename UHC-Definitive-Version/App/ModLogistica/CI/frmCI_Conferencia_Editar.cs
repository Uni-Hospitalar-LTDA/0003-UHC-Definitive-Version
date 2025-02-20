using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.CI;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModLogistica.CI
{
    public partial class frmCI_Conferencia_Editar : CustomForm
    {
        internal string id { get; set; }
        private CI_Header header { get; set; }         

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
            txtArquivo.Text = header.archiveLink;
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
        private async Task updateAsync()
        {          
            if (string.IsNullOrEmpty(txtResponsible.Text))
            {
                CustomNotification.defaultAlert("Responsável não selecionado!");
                return;
            }
            if (rdbSim.Checked && string.IsNullOrEmpty(txtTransporter.Text))
            {
                CustomNotification.defaultAlert("Transportador não selecionado!");
                return;
            }           

            header.id = id;
            header.idCI_Responsible = txtResponsibleId.Text;
            header.nfRebill = txtNF_rebill.Text;
            header.idTransporter = txtTransporterId.Text;
            header.observation = txtObservation.Text;
            header.archiveLink = txtArquivo.Text;
            try
            {
                await CI_Header.updateAsync(header);
                CustomNotification.defaultInformation("C.I alterada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }
        public frmCI_Conferencia_Editar()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();
            ConfigureListBoxProperties();

            //Events
            ConfigureFormEvents();


            /** Blocks **/
            gpbOperationType.Enabled = false;
            gpbPhysicalReturn.Enabled = false;  
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCI_Conferencia_Editar_Load;
        }
        private async void frmCI_Conferencia_Editar_Load(object sender, EventArgs e)
        {

            //Events
            ConfigureTextBoxEvents();
            ConfigureButtonEvents();

            //Changed Attributes (Event dependent)
            await getCiAsync();
            await getReturnsAsync();
            await getOriginsAsync();
            await getProducts();
        }

        
        /** Configure ListBox **/
        private void ConfigureListBoxProperties()
        {
            lsbNFOrigin.TabStop = false;
            lsbNFReturn.TabStop = false;
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
            txtResponsibleId.JustNumbers();
            txtTransporterId.JustNumbers();
            txtNF_rebill.JustNumbers();

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
        private void txtResponsible_DoubleClick(object sender, EventArgs e)
        {
            btnMoreResponsible_Click(sender, e);
        }
        private void txtTransporter_DoubleClick(object sender, EventArgs e)
        {
            btnMoreTransporter_Click(sender, e);
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnCancel.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnMoreTransporter.Click += btnMoreTransporter_Click;
            btnMoreResponsible.Click += btnMoreResponsible_Click;
            btnSave.Click += btnSave_Click;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await updateAsync();
        }

        private void btnMoreTransporter_Click(object sender, EventArgs e)
        {
            frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            frmConsultarTransportador.ShowDialog();
            txtTransporterId.Text = frmConsultarTransportador.extendedCode;
        }
        private async void btnMoreResponsible_Click(object sender, EventArgs e)
        {
            frmGeneric_ConsultaComSelecao frmConsultaGenerica = new frmGeneric_ConsultaComSelecao();
            frmConsultaGenerica.consulta = await CI_Responsible.getAllToDataTableAsync();
            frmConsultaGenerica.elemento = "Responsável";
            frmConsultaGenerica.ShowDialog();
            txtResponsibleId.Text = frmConsultaGenerica.extendedCode;
        }
    }
}
