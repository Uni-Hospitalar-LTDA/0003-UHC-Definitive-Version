using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.App.ModContabilFiscal.Relatorios
{
    public partial class frmRelatorioDifalDevSintetico : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal class Report : Querys<Report>
        {
            public static async Task<DataTable> getReportByDate(DateTime dt1, DateTime dt2)
            {
                string query = $@"
SELECT 
	 State.idIBGE [Cód. IBGE]
	,Cliente.Cod_Estado [UF]    
	,State.description [Descrição]
	,CONVERT(NUMERIC(18,2),SUM(IIF(Vlr_IcmsNor != 0, NF_Entrada.Vlr_Nota * (FiscalParameters.diferencialICMS/100),0)))	[ICMS Dev Total]
FROM [DMD].dbo.[NFECB] NF_Entrada 
JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Entrada.Cod_EmiCliente
JOIN [UHCDB].dbo.[State] ON State.uf = Cliente.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS
JOIN [UHCDB].dbo.[FiscalParametersByState] FiscalParameters ON FiscalParameters.idIBGE_State = state.idIBGE
WHERE
NF_ENTRADA.Tip_NF = 'D'
AND NF_ENTRADA.Dat_Emissao BETWEEN '{dt1.ToString("yyyyMMdd")}' AND '{dt2.ToString("yyyyMMdd")}'
and Cliente.Tipo_Consumidor <> 'N'
GROUP BY 	 
	 State.idIBGE
	,Cliente.Cod_Estado
	,State.description
ORDER BY [UF] ASC

";
                return await getAllToDataTable(query);
            }

        }
        public frmRelatorioDifalDevSintetico()
        {
            InitializeComponent();

            //Properties 
            ConfigureFormProperties();
            ConfigureMenuStripProperties();
            ConfigureButtonProperties();


            //Events
            ConfigureFormEvents();
        }


        /** Filtro Genérico **/
        private void genericFilter(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnFilter_Click(sender, e);
        }


        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmRelatorioDifalDevSintetico_Load;
        }

        private void frmRelatorioDifalDevSintetico_Load(object sender, EventArgs e)
        {
            ConfigureDateTimePickerAttributes();
            ConfigureButtonsEvents();            
            ConfigureDataGridViewEvents();
            ConfigureDateTimePickerEvents();

            btnFilter_Click(sender, e);

        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonsEvents()
        {
            btnFilter.Click += btnFilter_Click;
        }
        private async void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                dgvData.DataSource = await Report.getReportByDate(dtpInicial.Value, dtpFinal.Value);
            }
            catch (Exception)
            {
            }
            finally
            {
                dgvData.toDefault();
                dgvData.MultiSelect = true;
                dgvData.Columns[3].ValueType = typeof(double);
                dgvData.Columns[3].DefaultCellStyle.Format = "C2";
            }
        }

    

        /** DataGridView Configuration **/
        private void ConfigureDataGridViewEvents()
        {
            dgvData.DoubleClick += dgvData_DoubleClick;
        }
        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                frmRelatorioDifalDevAnalitico frmRelatorioDifalDevAnalitico = new frmRelatorioDifalDevAnalitico();
                frmRelatorioDifalDevAnalitico.stateCode = dgvData.CurrentRow.Cells[1].Value.ToString();
                frmRelatorioDifalDevAnalitico.dt1 = dtpInicial.Value;
                frmRelatorioDifalDevAnalitico.dt2 = dtpFinal.Value;
                frmRelatorioDifalDevAnalitico.Show();
            }
        }

        /** DataTimePicker Configuration **/
        private void ConfigureDateTimePickerEvents()
        {
            dtpInicial.KeyDown += genericFilter;
            dtpFinal.KeyDown += genericFilter;
        }
        private void ConfigureDateTimePickerAttributes()
        {
            DateTime primeiroDiaDoMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ultimoDiaDoMes = primeiroDiaDoMes.AddMonths(1).AddDays(-1);

            dtpInicial.Value = primeiroDiaDoMes;
            dtpFinal.Value = ultimoDiaDoMes;
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
