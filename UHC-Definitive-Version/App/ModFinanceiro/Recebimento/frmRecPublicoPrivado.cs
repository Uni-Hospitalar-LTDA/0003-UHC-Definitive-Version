using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.App.Telas_Genericas;

namespace UHC3_Definitive_Version.App.ModFinanceiro.Recebimento
{
    public partial class frmRecPublicoPrivado : CustomForm
    {

        /** Instance **/
        double totalValue = 0;
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal class Report : Querys<Report>
        {
            public async static Task<DataTable> getToDataTableWithFilterAsync
                (DateTime initialDate, DateTime finalDate, string customerGroudCondition
                , string sellerCondition, string regionFilter, string stateFilter, string sphere)
            {

                string query = $@"DECLARE @DAT_INICIAL DATETIME = '{initialDate.ToString("yyyyMMdd")}';
DECLARE @DAT_FINAL DATETIME = '{finalDate.ToString("yyyyMMdd")}';

SELECT 	DISTINCT       
	 [UF] = CLIEN.Cod_Estado
	,CONVERT(DATE,Dat_Caixa)	[Data de Pagamento]                          
	,CONVERT(DATE,Dat_Emissao)    [Dat. Emissão]           
	,CTREC.Cod_Cliente[Código]                             
	,CLIEN.Razao_Social[Razão Social]                      
	,VENDE.Codigo [Código vendedor]                        
	,VENDE.Nome_Guerra[Desc.Vendedor]                      
	,CTREC.Num_NfOrigem[NF]
	,Sum(BXREC.Vlr_Principal) [Vlr.Principal]                              
	,ISNULL(Sum(BXREC.Vlr_Deducoes + BXREC.Vlr_Desconto), 0) AS[Vlr.Desconto]
	,Sum(BXREC.Vlr_Principal) - ISNULL(Sum(BXREC.Vlr_Deducoes + BXREC.Vlr_Desconto), 0) AS[Vlr.Recebimento]  
FROM [DMD].dbo.[BXREC]              
JOIN [DMD].dbo.[CTREC] ON BXREC.Cod_Documento = CTREC.Cod_Documento           
JOIN [DMD].dbo.[CLIEN] ON CTREC.Cod_Cliente = CLIEN.Codigo   
JOIN [DMD].dbo.[LANCB] ON(LANCB.Cod_Lancam = BXREC.Cod_LanDep) OR(LANCB.Cod_Lancam = BXREC.Cod_CabLanFin)     
JOIN [DMD].dbo.[CTPAR] ON CTPAR.Cod_CtaPar = LANCB.Cod_CtaPar
JOIN [DMD].dbo.[VENDE] ON VENDE.CODIGO = CTREC.Cod_Vendedor
JOIN [DMD].[dbo].GRCLI  ON GRCLI.Cod_GrpCli = CLIEN.Cod_GrpCli
JOIN [UHCDB].dbo.[State] ON State.uf = CLIEN.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS
WHERE                  
CTREC.Status = 'Q'     
AND (BXREC.Dat_Caixa BETWEEN @DAT_INICIAL AND @DAT_FINAL)      
AND ({regionFilter})
AND ({stateFilter})
{sellerCondition}
{customerGroudCondition}
{sphere}
GROUP BY CLIEN.Cod_Estado, Dat_Caixa,CTREC.Cod_Cliente,CLIEN.Razao_Social,VENDE.Nome_Guerra,CTREC.Num_NfOrigem,vende.codigo,Dat_Emissao";
                Console.WriteLine(query);
                return await getAllToDataTable(query);
            }
        }


        public frmRecPublicoPrivado()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureComboBoxProperties();
            ConfigureButtonProperties();
            ConfigureFormEvents();
            ConfigureDataGridViewProperties();
        }


        /** Async Task **/
        async Task getReport()
        {
            totalValue = 0;
            string regionFilter = string.Empty;
            string stateFilter = string.Empty;
            string sellerFilter = string.Empty;
            string customerGroupFilter = string.Empty;
            string sphere = string.Empty;

            if (chkNorth.Checked)
                regionFilter += "State.Region = 'NORTE'";
            if (chkNortheast.Checked)
                regionFilter += (string.IsNullOrEmpty(regionFilter) ? "" : " OR ") + "State.Region = 'NORDESTE'";
            if (chkMidwest.Checked)
                regionFilter += (string.IsNullOrEmpty(regionFilter) ? "" : " OR ") + "State.Region = 'CENTROOESTE'";
            if (chkSoutheast.Checked)
                regionFilter += (string.IsNullOrEmpty(regionFilter) ? "" : " OR ") + "State.Region = 'SUDESTE'";
            if (chkSouth.Checked)
                regionFilter += (string.IsNullOrEmpty(regionFilter) ? "" : " OR ") + "State.Region = 'SUL'";

            if (string.IsNullOrEmpty(regionFilter))
                regionFilter = "1=1";


            stateFilter += (chkAC.Checked ? "State.uf = 'AC'" : string.Empty);
            stateFilter += (chkAL.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'AL'" : string.Empty);
            stateFilter += (chkAP.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'AP'" : string.Empty);
            stateFilter += (chkAM.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'AM'" : string.Empty);
            stateFilter += (chkBA.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'BA'" : string.Empty);
            stateFilter += (chkCE.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'CE'" : string.Empty);
            stateFilter += (chkDF.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'DF'" : string.Empty);
            stateFilter += (chkES.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'ES'" : string.Empty);
            stateFilter += (chkGO.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'GO'" : string.Empty);
            stateFilter += (chkMA.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'MA'" : string.Empty);
            stateFilter += (chkMT.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'MT'" : string.Empty);
            stateFilter += (chkMS.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'MS'" : string.Empty);
            stateFilter += (chkMG.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'MG'" : string.Empty);
            stateFilter += (chkPA.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'PA'" : string.Empty);
            stateFilter += (chkPB.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'PB'" : string.Empty);
            stateFilter += (chkPR.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'PR'" : string.Empty);
            stateFilter += (chkPE.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'PE'" : string.Empty);
            stateFilter += (chkPI.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'PI'" : string.Empty);
            stateFilter += (chkRJ.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'RJ'" : string.Empty);
            stateFilter += (chkRN.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'RN'" : string.Empty);
            stateFilter += (chkRS.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'RS'" : string.Empty);
            stateFilter += (chkRO.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'RO'" : string.Empty);
            stateFilter += (chkRR.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'RR'" : string.Empty);
            stateFilter += (chkSC.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'SC'" : string.Empty);
            stateFilter += (chkSP.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'SP'" : string.Empty);
            stateFilter += (chkSE.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'SE'" : string.Empty);
            stateFilter += (chkTO.Checked ? (string.IsNullOrEmpty(stateFilter) ? "" : " OR ") + "State.uf = 'TO'" : string.Empty);

            if (string.IsNullOrEmpty(stateFilter))
                stateFilter = "1=1";

            if (!string.IsNullOrEmpty(txtSellerDescription.Text))
                sellerFilter = " AND VENDE.Codigo = " + txtSellerId.Text;

            if (!string.IsNullOrEmpty(txtCustomerGroupDescription.Text))
                customerGroupFilter = " AND GRCLI.Cod_GrpCli = " + txtCustomerGroupId.Text;


            int v = 0;

            cbxCustomerSphere.Invoke((Action)delegate
            {
                v = cbxCustomerSphere.SelectedIndex;
            });

            switch (v)
            {
                case 1:
                    sphere = " AND CLIEN.Tipo_Consumidor in ('F','N') ";
                    break;
                case 2:
                    sphere = " AND CLIEN.Tipo_Consumidor NOT in ('F','N') ";
                    break;
                default:
                    sphere = null;
                    break;
            }


            DataTable data = null;
            data = await Report.getToDataTableWithFilterAsync(dtpInitial.Value, dtpFinal.Value, customerGroupFilter, sellerFilter
               , regionFilter, stateFilter, sphere);


            dgvData.Invoke((Action)delegate
            {
                dgvData.DataSource = data;
                dgvData.AutoResizeColumns();
                dgvData.Columns[8].ValueType = typeof(double);
                dgvData.Columns[9].ValueType = typeof(double);
                dgvData.Columns[10].ValueType = typeof(double);
                dgvData.Columns[8].DefaultCellStyle.Format = "C2";
                dgvData.Columns[9].DefaultCellStyle.Format = "C2";
                dgvData.Columns[10].DefaultCellStyle.Format = "C2";

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    totalValue += Convert.ToDouble(row.Cells[10].Value);
                }
            });

            txtTotalValue.Invoke((Action)delegate
            {
                txtTotalValue.Text = totalValue.ToString("C2");
            });
        }


        /** Generic Events **/
        private async void filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox)
            {
                if (e.KeyData == Keys.Enter)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        frmGeneric_ProgressForm chargeForm = new frmGeneric_ProgressForm();
                        chargeForm.Show();
                        await Task.Factory.StartNew(() => getReport());
                        chargeForm.Close();
                        this.Cursor = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        CustomNotification.defaultError(ex.Message);
                    }

                }
            }
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
         
            this.defaultMaximableForm();
            this.WindowState = FormWindowState.Maximized;   
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmRecebimento_PublicoPrivado_Load;
        }
        private async void frmRecebimento_PublicoPrivado_Load(object sender, System.EventArgs e)
        {
            ConfigureComboBoxAttributes();
            ConfigureDateTimePickerAttributes();
            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
            ConfigureCheckBoxEvents();            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                frmGeneric_ProgressForm chargeForm = new frmGeneric_ProgressForm();
                chargeForm.Show();
                await Task.Factory.StartNew(() => getReport());
                chargeForm.Close();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }


        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtSellerId.JustNumbers();
            txtSellerId.MaxLength = 3;
            txtCustomerGroupId.JustNumbers();
            txtCustomerGroupId.MaxLength = 3;

            txtCustomerGroupDescription.ReadOnly = true;
            txtCustomerGroupDescription.TabStop = false;

            txtSellerDescription.ReadOnly = true;
            txtSellerDescription.TabStop = false;

            txtTotalValue.ReadOnly = true;
            txtTotalValue.TabStop = false;
        }
        private void ConfigureTextBoxEvents()
        {
            txtSellerId.TextChanged += txtSellerId_TextChanged;
            txtSellerDescription.DoubleClick += txtSellerDescription_DoubleClick;

            txtCustomerGroupId.TextChanged += txtCustomerGroupId_TextChanged;
            txtCustomerGroupDescription.DoubleClick += txtCustomerGroupDescription_DoubleClick;
        }
        private async void txtSellerId_TextChanged(object sender, System.EventArgs e)
        {
            var seller = await Vendedores_Externos.getToClassAsync(txtSellerId.Text);
            txtSellerDescription.Text = seller.Nome_Guerra;
        }
        private async void txtSellerDescription_DoubleClick(object sender, System.EventArgs e)
        {
            frmGeneric_ConsultaComSelecao frmConsultaGenerica = new frmGeneric_ConsultaComSelecao();
            frmConsultaGenerica.consulta = await Vendedores_Externos.getAllToDataTableAsync();
            frmConsultaGenerica.ShowDialog();
            txtSellerId.Text = frmConsultaGenerica.extendedCode;
        }
        private async void txtCustomerGroupId_TextChanged(object sender, System.EventArgs e)
        {
            var customerGroup = await GruposClientes_Externos.getToClassAsync(txtCustomerGroupId.Text);
            txtCustomerGroupDescription.Text = customerGroup.Des_GrpCli;
        }
        private async void txtCustomerGroupDescription_DoubleClick(object sender, System.EventArgs e)
        {
            frmGeneric_ConsultaComSelecao frmConsultaGenerica = new frmGeneric_ConsultaComSelecao();
            frmConsultaGenerica.consulta = await GruposClientes_Externos.getAllToDataTableAsync();
            frmConsultaGenerica.ShowDialog();
            txtCustomerGroupId.Text = frmConsultaGenerica.extendedCode;
        }
        /** Configure ComboBox **/
        private void ConfigureComboBoxProperties()
        {
            cbxCustomerSphere.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void ConfigureComboBoxAttributes()
        {
            cbxCustomerSphere.Items.Add("Todos");
            cbxCustomerSphere.Items.Add("Privado");
            cbxCustomerSphere.Items.Add("Público");
            cbxCustomerSphere.SelectedIndex = 0;
        }

        /** Configure CheckBox **/
        private void ConfigureCheckBoxEvents()
        {
            chkAll.CheckedChanged += chkAll_CheckedChanged;
        }
        private void alterar_Marcacao(CheckBox chk, Boolean status)
        {
            chk.Invoke((MethodInvoker)delegate { chk.Checked = status; });
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                Task.Factory.StartNew(() => alterar_Marcacao(chkAC, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAL, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAC, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAL, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAP, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAM, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkBA, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkCE, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkDF, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkES, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkGO, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMA, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMT, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMS, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMG, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPA, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPB, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPE, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPI, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRJ, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRN, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRS, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRO, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRR, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkSC, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkSP, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkSE, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkTO, true));
                Task.WaitAll();



            }
            else
            {
                Task.Factory.StartNew(() => alterar_Marcacao(chkAC, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAL, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAC, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAL, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAP, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAM, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkBA, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkCE, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkDF, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkES, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkGO, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMA, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMT, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMS, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMG, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPA, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPB, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPE, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPI, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRJ, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRN, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRS, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRO, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRR, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkSC, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkSP, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkSE, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkTO, false));
                Task.WaitAll();
            }
        }

        /** Configure DateTimePicker **/
        private void ConfigureDateTimePickerAttributes()
        {
            dtpInitial.Value = DateTime.Now.AddDays(-90);
            dtpFinal.Value = DateTime.Now;
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSearch.Click += btnSearch_Click;
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                frmGeneric_ProgressForm chargeForm = new frmGeneric_ProgressForm();
                chargeForm.Show();
                await Task.Factory.StartNew(() => getReport());
                chargeForm.Close();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }

        /** DataGridView Configuration **/
        private void ConfigureDataGridViewProperties()
        {

            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.toDefault();
            dgvData.MultiSelect = true;
        }

        /** Menu Strip Configuration **/
        private void ConfigureMenuStripProperties()
        {
            CustomToolStripMenuItem menuArquivo = new CustomToolStripMenuItem("Arquivo");
            CustomToolStripMenuItem itemArquivoAbrir = new CustomToolStripMenuItem("Abrir");
            CustomToolStripMenuItem itemArquivoAbrirExcel = new CustomToolStripMenuItem("Excel");
            CustomToolStripMenuItem itemArquivoExportar = new CustomToolStripMenuItem("Exportar");
            CustomToolStripMenuItem itemArquivoExportarExcel = new CustomToolStripMenuItem("Excel");


            itemArquivoAbrirExcel.Click += ItemArquivoAbrirExcel_Click;
            itemArquivoExportarExcel.Click += ItemArquivoExportarExcel_Click;

            // Adicionando o item 'Empresa' e seu evento de clique

            menuArquivo.DropDownItems.Add(itemArquivoAbrir);
            menuArquivo.DropDownItems.Add(itemArquivoExportar);
            itemArquivoAbrir.DropDownItems.Add(itemArquivoAbrirExcel);
            itemArquivoExportar.DropDownItems.Add(itemArquivoExportarExcel);

            // Adiciona o menuConfiguracao ao menu principal
            menuStrip.Items.Add(menuArquivo);
            this.Controls.Add(menuStrip);

        }
        private void ItemArquivoAbrirExcel_Click(object sender, EventArgs e)
        {
            Exportacao.abrirDataGridViewEmExcel(dgvData);
        }
        private void ItemArquivoExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {

                //this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (dgvData.Rows.Count > 0)
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel File|*.xlsx";
                        saveFileDialog.Title = "Save Excel File";
                        saveFileDialog.FileName = $"{this.Text.substituirCaracteresEspeciais()}_{DateTime.Now.ToString("ddMMyyyy_HHmm")}";
                        saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        saveFileDialog.RestoreDirectory = true;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            RunMethodWithProgressBar((progress, cancellationToken) => Exportacao.exportarExcelComContaLinhas(dgvData, saveFileDialog.FileName, progress, cancellationToken));
                        }
                    }
                }
                catch (OperationCanceledException)
                {

                }
            }
        }
    }

}