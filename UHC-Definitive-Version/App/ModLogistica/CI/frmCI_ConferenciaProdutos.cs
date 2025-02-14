using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.CI;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModLogistica.CI
{
    public partial class frmCI_ConferenciaProdutos : CustomForm
    {

        //Instance 
        internal string idCI { get; set; } = "1";
        List<CI_Itens> persistentItens = new List<CI_Itens>();
        List<CI_Itens> changedItens = new List<CI_Itens>();
        private CI_Header header { get; set; }

        public frmCI_ConferenciaProdutos()
        {
            InitializeComponent();

            //Properties 
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureDataGridViewProperties();
            ConfigureButtonProperties();
            //Events 
            ConfigureFormEvents();
        }

        //Async Tasks 
        private async Task getProducts()
        {
            persistentItens = await CI_Itens.getAllToListByIdAsync(idCI);

            foreach (var product in persistentItens)
            {
                dgvData.Rows.Add(
                    product.idProduct
                    ,Produtos_Externos.getDescripionByCode(product.idProduct)
                    ,Convert.ToInt32(product.arrivalQuantity)
                    , Convert.ToInt32(product.remainingQuantity)
                    , Convert.ToInt32(product.arrivalQuantity) + Convert.ToInt32(product.remainingQuantity)
                    );
            }

            dgvData.AutoResizeColumns();
            
        }
        private async Task getInformationAsync()
        {
            header = await CI_Header.getToClassAsync(idCI);


            //ID da CI                                   
            lblIdCi.Text = "Id: " + header.id;

            //NF Refatura
            lblNF.Text = "NF Refatura: " + header.nfRebill;                                                   
            
            //Informações NF
            txtResponsible.Text = (await CI_Responsible.getToClassAsync(header.idCI_Responsible)).description;                                    
            switch (header.operationType)
            {
                case "P":
                    txtOperation.Text = "Devolução Parcial";
                    break;
                case "T":
                    txtOperation.Text = "Devolução Total";
                    break;
                default:
                    txtOperation.Text = "Sem Devolução";
                    break;
            }            
            switch (Convert.ToInt16(header.physicalReturn))
            {
                case 1:
                    txtPhysicalReturn.Text = "Sim";
                    break;
                default:
                    txtPhysicalReturn.Text = "Não";
                    break;
            }

            var listNfReturn = await CI_ReturnNF.getAllToListAsync(idCI);
            lsbNFReturn.Items.AddRange(listNfReturn.Select(item => item.NF_Return).ToArray());
            var listNfOrigin = await CI_OriginNF.getAllToListAsync(idCI);
            lsbNFOrigin.Items.AddRange(listNfOrigin.Select(item => item.NF_Origin).ToArray());

            //Informações sobre C.I
            txtReasonId.Text = header.idCI_Reason;
            txtReason.Text = (await CI_Reason.getToClassAsync(header.idCI_Reason)).description;
            txtCustomerId.Text = header.idCustomer;
            txtCustomer.Text = Clientes_Externos.getDescripionByCode(header.idCustomer);
            txtTransporterId.Text = header.idTransporter;
            txtTransporter.Text = await Transportadores_Externos.getDescriptionByCode(header.idTransporter); 
        }
        private async Task updateAsync()
        {
            try
            {

                int totalArrivalQuantity = 0;
                int totalTotalQuantity = 0;

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int arrivalQuantity = Convert.ToInt32(row.Cells["arrivalQuantity"].Value ?? 0);
                        int totalQuantity = Convert.ToInt32(row.Cells["totalQuantity"].Value ?? 0);

                        totalArrivalQuantity += arrivalQuantity;
                        totalTotalQuantity += totalQuantity;
                    }
                }

                if (totalArrivalQuantity == totalTotalQuantity)
                {
                    // Executar a ação desejada aqui
                    await CI_Header.setStatusAsync(header,"F");
                }

                await CI_Itens.updateAsync(changedItens);
                CustomNotification.defaultInformation("Produtos da C.I atualizados com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }


        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCI_ConferenciaProdutos_Load;
        }

        private async void frmCI_ConferenciaProdutos_Load(object sender, EventArgs e)
        {
            //Load 
            ConfigureDataGridViewEvents();
            ConfigureButtonEvents();

            //Attributes
            await getProducts();
            await getInformationAsync();
        }


        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {            
            foreach (var control in this.Controls)
            {
                if (control is GroupBox)
                {
                    GroupBox gp = (GroupBox) control;
                    foreach (var internalControl in gp.Controls)
                    {
                        if (internalControl is TextBox)
                        {
                            TextBox txt = (TextBox)internalControl;
                            txt.ReadOnly();
                        }
                    }
                }
            }     
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();                        
            dgvData.Columns.Add("idProduct", "Cód. Produto");
            dgvData.Columns.Add("nameProduct", "Produto");
            dgvData.Columns.Add("arrivalQuantity", "Entregues");
            dgvData.Columns.Add("remainingQuantity", "Restantes");
            dgvData.Columns.Add("totalQuantity", "Qtd. Total");
            dgvData.ReadOnly = false;

            foreach (DataGridViewColumn col in dgvData.Columns)
            {                
                if (col.Name != "arrivalQuantity")
                {
                    col.ReadOnly = true;
                    col.DefaultCellStyle.SelectionBackColor = Color.DarkGray;
                }
            }            
        }        
        private void ConfigureDataGridViewEvents()
        {
            dgvData.CellValidating += dgvData_CellValidating;
            dgvData.CellValueChanged += dgvData_CellValueChanged;
        }
        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Verifique se a coluna é "arrivalQuantity"
            if (dgvData.Columns[e.ColumnIndex].Name == "arrivalQuantity")
            {
                // Tente converter o valor para um número
                if (!int.TryParse(e.FormattedValue.ToString(), out _))
                {
                    e.Cancel = true; // Cancela a edição se não for um número
                    CustomNotification.defaultAlert("Por favor, insira apenas números.");
                }
            }
        }
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verifique se a coluna alterada é "arrivalQuantity"
            int totalQuantity = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["totalQuantity"].Value);
            int arrivalQuantity = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["arrivalQuantity"].Value);

            if (dgvData.Columns[e.ColumnIndex].Name == "arrivalQuantity")
            {                
                dgvData.Rows[e.RowIndex].Cells["remainingQuantity"].Value = totalQuantity - arrivalQuantity;
            }

                        
            

            if (arrivalQuantity > totalQuantity)
            {
                dgvData.Rows[e.RowIndex].Cells["arrivalQuantity"].Value = dgvData.Rows[e.RowIndex].Cells["totalQuantity"].Value;
                dgvData.Rows[e.RowIndex].Cells["remainingQuantity"].Value = 0;
            }

            if (arrivalQuantity < 0)
            {
                dgvData.Rows[e.RowIndex].Cells["arrivalQuantity"].Value = 0;
                dgvData.Rows[e.RowIndex].Cells["remainingQuantity"].Value = dgvData.Rows[e.RowIndex].Cells["totalQuantity"].Value;
            }

        }      

        /** Configure Buttons **/
        private void ConfigureButtonProperties()
        {
            btnCancel.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSave.Click += bnSave_Click;
            btnTotalReceipt.Click += btnTotalReceipt_Click;
            btnEncaminharFinanceiro.Click += btnEncaminharFinanceiro_Click;
        }

        private async void btnEncaminharFinanceiro_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert("Deseja realmente encaminhar para o Financeiro?") == DialogResult.Yes )
            {
                try
                {
                    await CI_Header.setStatusAsync(header, "F");
                    CustomNotification.defaultInformation("C.I encaminhada para o Financeiro.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                }
                
                
            }
        }

        private void btnTotalReceipt_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert("Tem certeza que deseja marcar a chegada de todos os produtos?") == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    row.Cells["arrivalQuantity"].Value = row.Cells["totalQuantity"].Value;
                }
            };
            
        }

        private async void bnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                var product = persistentItens.Where(x => x.idProduct == row.Cells[0].Value.ToString()).FirstOrDefault();
                if (Convert.ToInt32(product.arrivalQuantity) != Convert.ToInt32(row.Cells["arrivalQuantity"].Value.ToString()))
                {
                    product.arrivalQuantity = row.Cells["arrivalQuantity"].Value.ToString();
                    product.remainingQuantity = row.Cells["remainingQuantity"].Value.ToString();
                    changedItens.Add(product);
                }
            }
            await updateAsync();
        }             
    }
}
