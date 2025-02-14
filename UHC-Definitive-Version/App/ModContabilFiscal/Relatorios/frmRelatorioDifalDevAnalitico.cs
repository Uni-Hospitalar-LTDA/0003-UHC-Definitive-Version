using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModContabilFiscal.Relatorios
{
    public partial class frmRelatorioDifalDevAnalitico : CustomForm
    {

        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal class Report : Querys<Report>
        {
            public static async Task<DataTable> getReportByDate(DateTime dt1, DateTime dt2, string idCustomer, string NF, bool notZero, string state)
            {
                string customerCondition = (!string.IsNullOrEmpty(idCustomer) ? $" AND Cliente.Codigo = {idCustomer}" : null);
                string nfCondition = (!string.IsNullOrEmpty(NF) ? $" AND nf_entrada.Numero = {NF}" : null);
                string notZeroCondition = null;
                if (notZero)
                    notZeroCondition = " AND NF_Entrada.Vlr_IcmsNor > 0 ";
                string stateCondiditon = (!string.IsNullOrEmpty(state) ? $" AND Cliente.Cod_Estado = '{state}'" : null); ;

                string query = $@"
SELECT 
	 NF_Entrada.Protocolo [Protocolo Entrada]
	,NF_Entrada.Numero [NF Dev]
    ,REPLACE(NF_Entrada.Str_RelDoc,',1','') [Relação NF Saída]
	,NF_Entrada.Dat_Emissao [Dt. Emissão Dev]
	,Cliente.Codigo [Cód. Cliente]
	,Cliente.Razao_Social [Cliente]
	,Cliente.Cod_Estado [UF]	
	,NF_Entrada.Vlr_Nota [Vlr. NF]
	,NF_Entrada.Vlr_IcmsNor [ICMS Normal]
	,CONVERT(NUMERIC(18,4),IIF(NF_Entrada.Vlr_IcmsNor != 0, NF_Entrada.Vlr_Nota * (FiscalParameters.diferencialICMS/100),0)) [ICMS Diferencial]		    
	
FROM [DMD].dbo.[NFECB] NF_Entrada 
JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Entrada.Cod_EmiCliente
JOIN [UHCDB].dbo.[State] ON State.uf = Cliente.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS
JOIN [UHCDB].dbo.[FiscalParametersByState] FiscalParameters ON FiscalParameters.idIbge_State = state.idIBGE
WHERE
NF_ENTRADA.Tip_NF = 'D'
AND NF_ENTRADA.Dat_Emissao BETWEEN '{dt1.ToString("yyyyMMdd")}' AND '{dt2.ToString("yyyyMMdd")}'
and Cliente.Tipo_Consumidor <> 'N'
{customerCondition}
{nfCondition}
{notZeroCondition}
{stateCondiditon}
order by nf_entrada.Dat_Emissao desc

";
                return await getAllToDataTable(query);
            }
        }

        internal string stateCode { get; set; }
        internal DateTime dt1 { get; set; }
        internal DateTime dt2 { get; set; }

        public frmRelatorioDifalDevAnalitico()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();
            ConfigureMenuStripProperties();
            //Events
            ConfigureFormEvents();
        }

        /** Generic Filter **/
        private void genericFilter(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnFilter_Click(sender, e);
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
            this.WindowState = FormWindowState.Maximized;
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmRelatorioDifalDevAnalitico_Load;
        }

        private void frmRelatorioDifalDevAnalitico_Load(object sender, EventArgs e)
        {
            ConfigureDateTimePickerAttributes();


            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
            ConfigureDateTimePickerEvents();

            if (!string.IsNullOrEmpty(stateCode))
            {
                txtStateUF.Text = stateCode;
                dtpInitial.Value = dt1;
                dtpFinal.Value = dt2;
            }
            btnFilter_Click(sender, e); 
        }

        

        /** Configure Button **/
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
            try
            {
                dgvData.DataSource = await Report.getReportByDate(dtpInitial.Value, dtpFinal.Value, txtCustomerId.Text, txtNF.Text, chkNotZero.Checked, txtStateUF.Text);
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                dgvData.toDefault();
                dgvData.MultiSelect = true;

                dgvData.Columns[0].ValueType = typeof(int);
                dgvData.Columns[0].DefaultCellStyle.Format = "N0";
                dgvData.Columns[1].ValueType = typeof(int);
                dgvData.Columns[1].DefaultCellStyle.Format = "N0";

                dgvData.Columns[3].ValueType = typeof(DateTime);
                dgvData.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvData.Columns[4].ValueType = typeof(int);
                dgvData.Columns[4].DefaultCellStyle.Format = "N0";

                dgvData.Columns[7].ValueType = typeof(double);
                dgvData.Columns[7].DefaultCellStyle.Format = "C2";
                dgvData.Columns[8].ValueType = typeof(double);
                dgvData.Columns[8].DefaultCellStyle.Format = "C2";
                dgvData.Columns[9].ValueType = typeof(double);
                dgvData.Columns[9].DefaultCellStyle.Format = "C2";


                double sum = 0;
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    sum += Convert.ToDouble(row.Cells[9].Value);
                }

                txtVlrTotal.Text = sum.ToString("C2");
            }
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtCustomerId.JustNumbers();
            txtCustomerId.MaxLength = 8;
            txtStateUF.MaxLength = 2;
            txtNF.MaxLength = 10;

            txtStateDescription.ReadOnly = true;
            txtStateDescription.TabStop = false;

            txtCustomerDescription.ReadOnly = true;
            txtCustomerDescription.TabStop = false;

            txtVlrTotal.ReadOnly = true;
            txtVlrTotal.TabStop = false;

        }
        private void ConfigureTextBoxEvents()
        {
            txtCustomerId.TextChanged += txtCustomerId_TextChanged;
            txtCustomerDescription.DoubleClick += txtCustomerDescription_DoubleClick;
            txtStateUF.TextChanged += txtStateUF_TextChanged;

            txtCustomerId.KeyDown += genericFilter;
            txtCustomerDescription.KeyDown += genericFilter;
            txtStateUF.KeyDown += genericFilter;
            txtNF.KeyDown += genericFilter;
        }
        private async void txtStateUF_TextChanged(object sender, EventArgs e)
        {
            var state = await State.getToClassAsync(txtStateUF.Text);
            txtStateDescription.Text = state?.description;
        }
        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            txtCustomerDescription.Text = Clientes_Externos.getDescripionByCode(txtCustomerId.Text);
        }
        private void txtCustomerDescription_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            txtCustomerId.Text = frmConsultarCliente.extendedCode;
        }

        /** Configure DataTimePicker **/
        private void ConfigureDateTimePickerEvents()
        {
            dtpFinal.KeyDown += genericFilter;
            dtpInitial.KeyDown += genericFilter;
        }
        private void ConfigureDateTimePickerAttributes()
        {
            DateTime primeiroDiaDoMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ultimoDiaDoMes = primeiroDiaDoMes.AddMonths(1).AddDays(-1);

            dtpInitial.Value = primeiroDiaDoMes;
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
