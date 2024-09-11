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

namespace UHC3_Definitive_Version.App.ModFinanceiro.Recebimento
{
    public partial class frmContasRecebidas : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal class Report_ContasRecebidas : Querys<Report_ContasRecebidas>
        {
            public static async Task<DataTable> getAllDataTableAsync(DateTime initial, DateTime final)
            {
                string query = $@"SELECT 	DISTINCT 		
	CTREC.Num_NfOrigem		[NF]        		
	,CTREC.Cod_Cliente		[Cód. Cliente]        		
	,CLIEN.Razao_Social		[Cliente Razão]         		
	,CLIEN.Fantasia			[Cliente Fantasia]        		
	,CTREC.num_Documento	[Num. Documento]        		
	,CTREC.Par_Documento	[Par. Documento]        		
	,CTREC.Dat_Emissao		[Dat. Emissao]        		
	,CTREC.Dat_Vencimento	[Dat. Vencimento]       		
	,CTREC.Status			[Status CT]       		
	,CTREC.Tip_Documento	[Tip. Documento CT]      		
	,BXREC.Dat_Caixa		[Dat. Caixa]      		
	,BXREC.Status			[Status BX]      		
	,CTREC.Cod_Agente		[Cod. Agente]       		
	,BXREC.Tip_Doc			[Tip. Documento BX]     		
	,CTREC.Observacao		[Observação]     		
	,REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((CTREC.vlr_partit) AS money), 1),',', '_'), '.', ','), '_', '.')	[Vlr. Par. Tít.]   		
	,REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((CTREC.Vlr_Documento) AS money), 1),',', '_'), '.', ','), '_', '.')	[Vlr. Documento]      		
	,REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((CTREC.Vlr_OutAcr) AS money), 1),',', '_'), '.', ','), '_', '.')	[z. Out. Acr.]     		
	,REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((BXREC.vlr_juros) AS money), 1),',', '_'), '.', ','), '_', '.')		[Vlr. Juros]    		
	,REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((CTREC.vlr_Saldo) AS money), 1),',', '_'), '.', ','), '_', '.')		[Vlr. Saldo]			
	,CTPAR.Des_CtaPar [Des. Cta. Par.]    		
	,CTREC.Cod_Barra		[Cod. Barra]    		
	,REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((Sum(BXREC.Vlr_Principal)) AS money), 1),',', '_'), '.', ','), '_', '.') AS [Vlr. Principal]       		
	,REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((Sum(BXREC.Vlr_Juros)) AS money), 1),',', '_'), '.', ','), '_', '.') AS [BX Vlr. Juros]        
	,REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((Sum(BXREC.Sld_Principal)) AS money), 1),',', '_'), '.', ','), '_', '.') AS [Sld. Principal]     		
	,REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((Sum(BXREC.Vlr_Deducoes + BXREC.Vlr_Desconto)) AS money), 1),',', '_'), '.', ','), '_', '.') AS [Vlr. Outros] 
	FROM       DMD.dbo.BXREC 
    INNER JOIN DMD.dbo.CTREC ON BXREC.Cod_Documento = CTREC.Cod_Documento 
	INNER JOIN DMD.dbo.CLIEN ON CTREC.Cod_Cliente = CLIEN.Codigo 
	INNER JOIN DMD.dbo.LANCB ON (LANCB.Cod_Lancam = BXREC.Cod_LanDep) OR (LANCB.Cod_Lancam = BXREC.Cod_CabLanFin) 
	INNER JOIN DMD.dbo.CTPAR ON CTPAR.Cod_CtaPar = LANCB.Cod_CtaPar 
	WHERE 
		BXREC.Dat_Caixa 
			BETWEEN '{initial.ToString("yyyyMMdd")}' and '{final.ToString("yyyyMMdd")}' 
	GROUP BY CTREC.Num_NfOrigem,          
	CTREC.Cod_Cliente,           
	CLIEN.Razao_Social,         
	CLIEN.Fantasia,         
	CTREC.num_Documento,         
	CTREC.Par_Documento,        
	 CTREC.Dat_Emissao,         
	CTREC.Dat_Vencimento,         
	CTREC.Status,         
	CTREC.Tip_Documento,         
	BXREC.Dat_Caixa,         
	BXREC.Status,         
	CTREC.Cod_Agente,         
	BXREC.Tip_Doc,         
	CTREC.Observacao,         
	CTREC.vlr_partit,         
	CTREC.Vlr_Documento,         
	CTREC.Vlr_OutAcr,         
	BXREC.vlr_juros,         
	CTREC.vlr_Saldo,         
	CTPAR.Des_CtaPar,         
	CTREC.Cod_Barra 
	ORDER BY 
	CTREC.Num_NfOrigem,        
	CTREC.Dat_Emissao";
                Console.WriteLine(query);
                return await getAllToDataTable(query);
            }
        }


        public frmContasRecebidas()
        {
            InitializeComponent();

            //Properties 
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureDataGridViewProperties();
            ConfigureMenuStripProperties();

            //Form Events 
            ConfigureFormEvents();
        }


        /** Async Tasks **/
        private async Task filterAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dgvData.DataSource = await Report_ContasRecebidas.getAllDataTableAsync(dtpInitial.Value, dtpFinal.Value);
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }


        /** Form Configuration **/
        private void ConfigureFormEvents()
        {
            this.Load += frmRecebimento_ContasRecebidas_Load;
        }
        private void frmRecebimento_ContasRecebidas_Load(object sender, EventArgs e)
        {
            //Attributes
            ConfigureDateTimePickerAttributes();

            //Events 
            ConfigureButtonEvents();
            
        }
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
            this.WindowState = FormWindowState.Maximized;
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnFilter.Click += btnFilter_Click;
        }
        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await filterAsync();
        }

        /** DateTimePicker Configuration **/
        private void ConfigureDateTimePickerAttributes()
        {

            dtpInitial.Value = DateTime.Today.AddDays(-30);
            dtpFinal.Value = DateTime.Today;
        }

        /** DataGridView Configuration **/
        private void ConfigureDataGridViewProperties()
        {
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
