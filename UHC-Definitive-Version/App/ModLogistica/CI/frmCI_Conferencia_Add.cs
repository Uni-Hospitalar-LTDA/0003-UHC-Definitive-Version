using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.CI;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModLogistica.CI
{
    public partial class frmCI_Conferencia_Add : CustomForm
    {

        /** Instance **/
        private HashSet<string> uniqueProducts = new HashSet<string>();
        private Dictionary<int, List<string>> indexToOriginMapping = new Dictionary<int, List<string>>();
        private Dictionary<string, List<string>> nfToProductsMapping = new Dictionary<string, List<string>>();

        private bool isRadioButtonChangeProgrammatic = false;


        private CI_Reason selectedReason = new CI_Reason(); 

        //private bool rebillisvalid = false;
        private class CI_Querys : Querys<CI_Querys>
        {
            public static async Task<DataTable> getReturnsByCustomerAsync(string idCustomer)
            {
                string query = $@"SELECT NUMERO [Devolucao]
FROM [DMD].dbo.[NFECB] NF_Devolucao
 WHERE Cod_EmiCliente = {idCustomer}
 AND TIP_NF = 'D' AND Numero IS NOT NULL AND Numero NOT IN (SELECT NF_Return FROM [UHCDB].dbo.[CI_ReturnNF] )
 order by Dat_Entrada desc ";
                return await getAllToDataTable(query);
            }
            public static async Task<DataTable> getOriginFromNFReturnAsync(string nf_Return)
            {
                string query = $@" SELECT STR_RELDOC FROM [DMD].dbo.[NFECB]
                                    WHERE 
                                    NUMERO = {nf_Return}
                                    AND TIP_NF = 'D'
                                   order by Dat_Entrada desc ";
                return await getAllToDataTable(query);
            }
            public static async Task<DataTable> getProductsByOriginNFsAsync(string nfOrigins)
            {
                string query = $@"SELECT
                                  [Produto] = CONVERT(VARCHAR(MAX),Cod_Produto) + ' - ' + Produto.Descricao
                                  FROM [DMD].dbo.[NFSCB] NF
                                  JOIN [DMD].dbo.[NFSIT] NF_Produtos ON NF.Num_Nota = NF_Produtos.Num_Nota
                                  JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Produtos.Cod_Produto
                                  WHERE 
                                    	NF.Num_Nota in ({nfOrigins})
                                  GROUP BY
                                         Cod_Produto
                                        ,Produto.Descricao
                                  ORDER BY
                                         Cod_Produto
";
                return await getAllToDataTable(query);
            }

            

        }
        public frmCI_Conferencia_Add()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();
            ConfigureGroupBoxProperties();
            //Event
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private async Task AddOriginsAndUpdateProductsAsync(int index)
        {
            var nfReturn = clbNFreturn.Items[index].ToString();
            var origin = await CI_Querys.getOriginFromNFReturnAsync(nfReturn);
            List<string> collection = separateNFOrigins(origin.Rows[0][0].ToString());

            lsbNFOrigin.Items.AddRange(collection.ToArray());
            indexToOriginMapping[index] = collection;

            List<string> productsToAdd = new List<string>();
            foreach (var originItem in collection)
            {
                var products = await CI_Querys.getProductsByOriginNFsAsync(originItem);
                foreach (DataRow row in products.Rows)
                {
                    string product = row[0].ToString();
                    if (uniqueProducts.Add(product)) // Retorna true se o produto foi adicionado ao conjunto, ou seja, não é duplicado.
                    {
                        productsToAdd.Add(product);
                    }
                }
            }
            clbProducts.Items.AddRange(productsToAdd.ToArray());
            nfToProductsMapping[nfReturn] = productsToAdd; // Adicionar o mapeamento de NF para produtos.
        }

        /** Sync method **/
        private void cleanNFData()
        {
            clbNFreturn.Items.Clear();
            lsbNFOrigin.Items.Clear();
            clbProducts.Items.Clear();
            uniqueProducts.Clear();
            indexToOriginMapping.Clear();
            nfToProductsMapping.Clear();

            gpbOperationType.Enabled = false;
            gpbPhysicalReturn.Enabled = false;
            rdbWithoutDevolution.Checked = true;
            rdbNao.Checked = true;

        }
        static List<string> separateNFOrigins(string input)
        {
            List<string> result = new List<string>();
            string[] parts = input.Split(';');

            foreach (var part in parts)
            {
                string[] numberParts = part.Split(',');

                if (numberParts.Length > 1)
                {
                    // Adiciona apenas a parte após a vírgula
                    result.Add(numberParts[1]);
                }
                else
                {
                    // Caso não haja vírgula, adiciona o número completo
                    result.Add(numberParts[0]);
                }
            }

            return result;
        }
        private void RemoveSelectedOriginAndAssociatedProducts()
        {
            if (lsbNFOrigin.SelectedItem != null)
            {
                string selectedOrigin = lsbNFOrigin.SelectedItem.ToString();
                lsbNFOrigin.Items.Remove(selectedOrigin);

                // Remover produtos associados
                RemoveProductsAssociatedWithOrigin(selectedOrigin);
            }
        }
        private void RemoveProductsAssociatedWithOrigin(string origin)
        {
            // Encontrar a NF de devolução correspondente
            string nfReturn = FindNFReturnByOrigin(origin);

            if (nfReturn != null && nfToProductsMapping.TryGetValue(nfReturn, out List<string> products))
            {
                foreach (var product in products)
                {
                    clbProducts.Items.Remove(product);
                    uniqueProducts.Remove(product); // Se estiver usando para rastrear produtos únicos
                }
                // Remover a entrada do mapeamento
                nfToProductsMapping.Remove(nfReturn);
            }
        }
        private string FindNFReturnByOrigin(string origin)
        {
            foreach (var pair in indexToOriginMapping)
            {
                if (pair.Value.Contains(origin))
                {
                    return clbNFreturn.Items[pair.Key].ToString();
                }
            }
            return null;
        }        
        private void RemoveOriginsAndUpdateProducts(int index)
        {
            if (indexToOriginMapping.TryGetValue(index, out List<string> collection))
            {
                string nfReturn = clbNFreturn.Items[index].ToString();

                foreach (string originItem in collection)
                {
                    lsbNFOrigin.Items.Remove(originItem);
                }
                indexToOriginMapping.Remove(index);

                if (nfToProductsMapping.TryGetValue(nfReturn, out List<string> productsToRemove))
                {
                    foreach (var product in productsToRemove)
                    {
                        clbProducts.Items.Remove(product);
                        uniqueProducts.Remove(product); // Remover do conjunto de produtos únicos
                    }
                    nfToProductsMapping.Remove(nfReturn); // Remover o mapeamento de NF para produtos
                }
            }
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCI_Conferencia_Add_Load;
        }
        private void frmCI_Conferencia_Add_Load(object sender, EventArgs e)
        {

            //Attributes
            ConfigureRadioButtonAttributes();

            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
            ConfigureCheckedListBoxEvents();
            ConfigureListBoxEvents();
            ConfigureRadioButtonEvents();



        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtCustomer.ReadOnly();
            txtReason.ReadOnly();
            txtResponsible.ReadOnly();
            txtTransporter.ReadOnly();

            txtCustomerId.JustNumbers();
            txtReasonId.JustNumbers();
            txtResponsibleId.JustNumbers();
            txtTransporterId.JustNumbers();
            
            txtNF_rebill.JustNumbers();

            txtArquivo.ReadOnly();                       
        }
        private void ConfigureTextBoxEvents()
        {
            txtCustomerId.TextChanged += txtCustomerId_TextChanged;
            txtReasonId.TextChanged += txtReasonId_TextChanged;
            txtResponsibleId.TextChanged += txtResponsibleId_TextChanged;
            txtTransporterId.TextChanged += txtTransporterId_TextChanged;
            txtCustomer.TextChanged += txtCustomer_TextChanged;
            txtCustomer.DoubleClick += txtCustomer_DoubleClick;

            txtTransporter.DoubleClick += txtTransporter_DoubleClick;
            txtResponsible.DoubleClick += txtResponsible_DoubleClick;
            txtReason.DoubleClick += txtReason_DoubleClick;

            txtNF_rebill.LostFocus += txtNF_rebill_LostFocus;
        }

        private async void txtNF_rebill_LostFocus(object sender, EventArgs e)
        {
            var nf = await CI_Header.checkNfRebillUsabilityAsync(txtNF_rebill.Text);

            if (nf.Rows.Count == 0  & !string.IsNullOrEmpty(txtNF_rebill.Text))
            {
                CustomNotification.defaultAlert("Nota fiscal inválida.");
                txtNF_rebill.Clear();
                txtNF_rebill.Focus();                
                return;
            }
        }

        private async void txtResponsibleId_TextChanged(object sender, EventArgs e)
        {
            var responsible = await CI_Responsible.getToClassAsync(txtResponsibleId.Text);
            txtResponsible.Text = responsible.description;
        }
        private async void txtReasonId_TextChanged(object sender, EventArgs e)
        {
            selectedReason = await CI_Reason.getToClassAsync(txtReasonId.Text);
            txtReason.Text = selectedReason.description;
            rdbSim.Checked = (selectedReason.moveReturns == "1" ? true : false);
            rdbNao.Checked = (selectedReason.moveReturns == "0" ? true : false);
            if (rdbNao.Checked)
            {
                clbNFreturn.Enabled = false;
                lsbNFOrigin.Enabled = false;
                clbProducts.Enabled = false;

                for (int i = 0; i < clbNFreturn.Items.Count; i++)
                {
                    clbNFreturn.SetItemChecked(i, false);
                }

            }
            else
            {
                clbNFreturn.Enabled = true;
                lsbNFOrigin.Enabled = true;
                clbProducts.Enabled = true;
            }
        }
        private void txtCustomerId_TextChanged(object sender, System.EventArgs e)
        {
            txtCustomer.Text = Clientes_Externos.getDescripionByCode(txtCustomerId.Text);
        }
        private async void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var returns = await CI_Querys.getReturnsByCustomerAsync(txtCustomerId.Text);
                if (returns.Rows.Count > 0)
                {
                    foreach (DataRow dr in returns.Rows)
                    {
                        clbNFreturn.Items.Add(dr[0].ToString());
                    }                    
                }
                else
                {
                    cleanNFData();
                }
            }
            catch
            {
                cleanNFData();
                //CustomMessage.Error(ex.Message);
            }

            this.Cursor = Cursors.Default;
        }
        private async void txtTransporterId_TextChanged(object sender, EventArgs e)
        {
            txtTransporter.Text = await Transportadores_Externos.getDescriptionByCode(txtTransporterId.Text);
        }
        private void txtResponsible_DoubleClick(object sender, EventArgs e)
        {
            btnMoreResponsible_Click(sender, e);
        }
        private void txtReason_DoubleClick(object sender, EventArgs e)
        {
            btnMoreReason_Click(sender, e);
        }
        private void txtTransporter_DoubleClick(object sender, EventArgs e)
        {
            btnMoreTransporter_Click(sender, e);
        }
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            btnMoreCustomer_Click(sender, e);
        }


        /** Configure Button**/
        private void ConfigureButtonProperties()
        {
            btnCancel.toDefaultCloseButton();
            btnSave.Click += btnSave_Click;
            btnMoreCustomer.TabStop = false;
            btnMoreReason.TabStop = false;
            btnMoreResponsible.TabStop = false;
            btnMoreTransporter.TabStop = false;
            btnMoreNFs.TabStop = false;

            btnAddArquivo.Click += controlarArquivo;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            await saveAsync();
        }
        private async Task saveAsync()
        {
            //Validations 
            if (string.IsNullOrEmpty(txtCustomer.Text))
            {
                CustomNotification.defaultAlert("Cliente não selecionado!");                
                return;
            }
            if (string.IsNullOrEmpty(txtReason.Text))
            {
                CustomNotification.defaultAlert("Motivo não selecionado!");
                return;
            }
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
            if (rdbPartialDevolution.Checked && clbProducts.CheckedItems.Count == 0)
            {
                CustomNotification.defaultAlert("Não é possível inserir uma devolução parcial sem itens marcados.");
                return;
            }
                                 
            //CI_Header            
            List<CI_Header> header = new List<CI_Header>();
            List<CI_Itens> itens = new List<CI_Itens>();
            List<CI_OriginNF> origins = new List<CI_OriginNF>();
            List<CI_ReturnNF> returns = new List<CI_ReturnNF>();
            List<string> originNFs = new List<string>();
            string concatOrigin = null;
            header.Add(new CI_Header
            {
                idCI_Reason = txtReasonId.Text,
                idCI_Responsible = txtResponsibleId.Text,
                idCustomer = txtCustomerId.Text,
                idTransporter = txtTransporterId.Text,
                nfRebill = txtNF_rebill.Text,
                operationType = (rdbTotalReturn.Checked ? "T": rdbPartialDevolution.Checked ? "P" : "N"),
                physicalReturn = (rdbSim.Checked ?"1":"0"),
                status = (rdbWithoutDevolution.Checked ? "F": "P"),
                observation = txtObservation.Text,
                dateCreated = DateTime.Now.ToString(),
                dateEdited = DateTime.Now.ToString(),
                idUser = Section.idUsuario,
                archiveLink = txtArquivo.Text  
            });

            await CI_Header.insertAsync(header);
            var lastId = await CI_Header.getLastCodeAsync();

            //CI_OriginNF
            foreach (var origin in lsbNFOrigin.Items)
            {
                origins.Add(new CI_OriginNF
                {
                    idCI_Header = lastId.ToString(),
                    NF_Origin = origin.ToString()
                });
                originNFs.Add(origin.ToString());
            }

            //CI_ReturnNF
            foreach (var retrn in clbNFreturn.CheckedItems)
            {
                returns.Add(new CI_ReturnNF
                {
                    idCI_Header = lastId.ToString(),
                    NF_Return = retrn.ToString()
                });
                
            }

            concatOrigin = string.Join(", ", originNFs);
            //CI_Itens
            foreach (var item in clbProducts.CheckedItems)
            {

                string[] str = item.ToString().Split('-');
                itens.Add(new CI_Itens
                {
                    idCI_Header = lastId.ToString(),
                    idProduct = str[0],
                    arrivalQuantity = "0",
                    remainingQuantity = await CI_Itens.getProductQuantityAsync(concatOrigin, str[0]),
                    idUser = Section.idUsuario
                });
            }
            
            try
            {
                await CI_Itens.insertAsync(itens);
                await CI_ReturnNF.insertAsync(returns);
                await CI_OriginNF.insertAsync(origins);
                CustomNotification.defaultInformation("Protocolo de CI inserido com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }
        private void ConfigureButtonEvents()
        {
            btnMoreCustomer.Click += btnMoreCustomer_Click;
            btnMoreReason.Click += btnMoreReason_Click;
            btnMoreResponsible.Click += btnMoreResponsible_Click;
            btnMoreTransporter.Click += btnMoreTransporter_Click;

            btnMoreNFs.Click += btnMoreNFs_Click;
        }
        private void btnMoreNFs_Click(object sender, EventArgs e)
        {
            frmConsultarNF frmConsultarNF = new frmConsultarNF();
            frmConsultarNF.ShowDialog();
            txtNF_rebill.Text =  frmConsultarNF.nf;
        }
        private async void btnMoreResponsible_Click(object sender, EventArgs e)
        {
            frmGeneric_ConsultaComSelecao frmConsultaGenerica = new frmGeneric_ConsultaComSelecao();
            frmConsultaGenerica.consulta = await CI_Responsible.getAllToDataTableAsync();
            frmConsultaGenerica.elemento = "Responsável";
            frmConsultaGenerica.ShowDialog();
            txtResponsibleId.Text = frmConsultaGenerica.extendedCode;
        }
        private async void btnMoreReason_Click(object sender, EventArgs e)
        {
            frmGeneric_ConsultaComSelecao frmConsultaGenerica = new frmGeneric_ConsultaComSelecao();
            frmConsultaGenerica.consulta = await CI_Reason.getAllToDataTableAsync(null, "1");
            frmConsultaGenerica.elemento = "Motivo de C.I";
            frmConsultaGenerica.ShowDialog();
            txtReasonId.Text = frmConsultaGenerica.extendedCode;
        }
        private void btnMoreTransporter_Click(object sender, EventArgs e)
        {
            frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            frmConsultarTransportador.ShowDialog();
            txtTransporterId.Text = frmConsultarTransportador.extendedCode;
        }
        private void btnMoreCustomer_Click(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            txtCustomerId.Text = frmConsultarCliente.extendedCode;
        }

        /** Configure CheckedListBox **/
        private void ConfigureCheckedListBoxEvents()
        {
            clbNFreturn.ItemCheck += clbNFreturn_ItemCheck;
            clbProducts.ItemCheck += clbProducts_ItemCheck;
        }        
        private async void clbNFreturn_ItemCheck(object sender, ItemCheckEventArgs e)
        {            
            if (e.NewValue == CheckState.Checked)
            {
                // Código quando um item é marcado...
                await AddOriginsAndUpdateProductsAsync(e.Index);
                gpbOperationType.Enabled = true;
                rdbPartialDevolution.Checked = true;
                rdbWithoutDevolution.Enabled = false;                
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                // Código quando um item é desmarcado...
                RemoveOriginsAndUpdateProducts(e.Index);
                if (clbNFreturn.CheckedItems.Count == 1) 
                {
                    rdbWithoutDevolution.Checked = true;
                    gpbOperationType.Enabled = false;                 
                }                
            }
           
        }
        private void clbProducts_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            isRadioButtonChangeProgrammatic = true;

            if (e.NewValue == CheckState.Unchecked)
            {
                rdbPartialDevolution.Checked = true;
            }
            else if (AreAllItemsChecked(e.Index, e.NewValue))
            {
                rdbTotalReturn.Checked = true;
            }

            isRadioButtonChangeProgrammatic = false;
        }
        private bool AreAllItemsChecked(int changingItemIndex, CheckState changingItemNewState)
        {
            for (int i = 0; i < clbProducts.Items.Count; i++)
            {
                if (i == changingItemIndex)
                {
                    if (changingItemNewState == CheckState.Unchecked)
                    {
                        return false;
                    }
                }
                else if (!clbProducts.GetItemChecked(i))
                {
                    return false;
                }
            }
            return true;
        }

        /** Configure ListBox **/
        private void ConfigureListBoxEvents()
        {
            lsbNFOrigin.KeyDown += lsbNFOrigin_KeyDown;
        }
        private void lsbNFOrigin_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    RemoveSelectedOriginAndAssociatedProducts();                
            //}
        }
        


        /** Configure RadioButton **/
        private void ConfigureRadioButtonAttributes()
        {            
            rdbWithoutDevolution.Checked = true;
        }
        private void ConfigureRadioButtonEvents()
        {
            //rdbPartialDevolution.CheckedChanged += rdbPartialDevolution_CheckedChanged;
            //rdbTotalReturn.CheckedChanged += rdbTotalReturn_CheckedChanged; 
        }
        private void rdbTotalReturn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTotalReturn.Checked && !isRadioButtonChangeProgrammatic)
            {
                isRadioButtonChangeProgrammatic = true;
                for (int i = 0; i < clbProducts.Items.Count; i++)
                {
                    clbProducts.SetItemChecked(i, true);
                }
                isRadioButtonChangeProgrammatic = false;
            }
        }
        private void rdbPartialDevolution_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPartialDevolution.Checked && !isRadioButtonChangeProgrammatic)
            {
                isRadioButtonChangeProgrammatic = true;
                for (int i = 0; i < clbProducts.Items.Count; i++)
                {
                    clbProducts.SetItemChecked(i, false);
                }
                isRadioButtonChangeProgrammatic = false;
            }
        }


        private void controlarArquivo(object sender, EventArgs e)
        {
            txtArquivo.ReadOnly = false;
            btnAddArquivo.Enabled = false;
        }

        /** Configure GroupBox **/
        private void ConfigureGroupBoxProperties()
        {
            gpbPhysicalReturn.Enabled = false;
            gpbOperationType.Enabled = false;
        }

        

    }
}
