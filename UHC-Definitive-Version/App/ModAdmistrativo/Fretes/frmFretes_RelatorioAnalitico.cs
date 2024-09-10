using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.App.Telas_Genericas;
using System.Threading.Tasks;
using System.Data;

namespace UHC3_Definitive_Version.App.ModAdmistrativo.Fretes
{
    public partial class frmFretes_RelatorioAnalitico : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();

        public frmFretes_RelatorioAnalitico()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureDataGridViewProperties();
            ConfigureButtonProperties();
            ConfigureMenuStripProperties();

            //Events
            ConfigureFormEvents();
        }
        /** Async Tasks **/
        private async Task getReport()
        {
            string transporter = null;
            string nf = null;
            string cte = null;
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now;
            txtTransporterDescription.Invoke((Action)delegate
            {
                transporter = string.IsNullOrEmpty(txtTransporterDescription.Text) ? null : "AND Transportador.Codigo = " + txtTransporterId.Text;
            });
            txtNfFilter.Invoke((Action)delegate
            {
                nf = string.IsNullOrEmpty(txtNfFilter.Text) ? null : txtNfFilter.Text;
            });
            txtCteFilter.Invoke((Action)delegate
            {
                cte = string.IsNullOrEmpty(txtCteFilter.Text) ? null : txtCteFilter.Text;
            });

            dtpInitialDate.Invoke((Action)delegate { dt1 = dtpInitialDate.Value; });
            dtpFinalDate.Invoke((Action)delegate { dt2 = dtpFinalDate.Value; });

            string reportQuery = $@"SELECT 
	 NF_Saida.Num_Nota [NF]
	,shipping.Num_CTE  [CTE]
	,NF_Saida.Dat_Emissao [Emissão]
    ,shipping.Dat_register [Registro]
	,idTransporter [Cód. Transportador]
	,Transportador.Fantasia [Transprotador]
	,NF_Saida.Cidade 
	,NF_Saida.Estado
	,NF_Saida.Vlr_TotalNota [Vlr. NF]
	,shipping.calculatedValue [Vlr. Calculado]
    ,[%] = CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),ROUND(shipping.realValue / NF_Saida.Vlr_TotalNota,2)) * 100) + ' %'	
    ,shipping.realValue [Vlr. Real]
	
	
	
FROM [UHCDB].dbo.[ShippingConference] shipping
JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_nota = shipping.Num_Nota
join [DMD].dbo.[TRANS] Transportador ON Transportador.Codigo = idTransporter
WHERE CONVERT(DATE,shipping.dat_register) between '{dt1.ToString("yyyyMMdd")}' and '{dt2.ToString("yyyyMMdd")}'
{transporter}
AND shipping.Num_Nota LIKE '%{nf}%'
AND shipping.Num_CTE LIKE '%{cte}%'
UNION ALL
SELECT 
	 NF_Entrada.Numero [NF]
	,shipping.Num_CTE  [CTE]
	,NF_Entrada.Dat_Emissao [Emissão]
    ,shipping.Dat_register [Registro]
	,idTransporter [Cód. Transportador]
	,Transportador.Fantasia [Transprotador]
	,NF_Entrada.Cidade 
	,NF_Entrada.Cod_UfOrigem
	,NF_Entrada.Vlr_Nota [Vlr. NF]
	,shipping.calculatedValue [Vlr. Calculado]
    ,[%] = CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),ROUND(shipping.realValue / NF_Entrada.Vlr_Nota,2)) * 100) + ' %'	
    ,shipping.realValue [Vlr. Real]
	
	
	
FROM [UHCDB].dbo.[ShippingConference] shipping
JOIN [DMD].dbo.[NFECB] NF_Entrada ON NF_Entrada.Numero = shipping.Num_Nota AND NF_Entrada.Tip_NF = 'D'
JOIN [DMD].dbo.[TRANS] Transportador ON Transportador.Codigo = idTransporter
WHERE CONVERT(DATE,shipping.dat_register) between '{dt1.ToString("yyyyMMdd")}' and '{dt2.ToString("yyyyMMdd")}'
{transporter}
AND shipping.Num_Nota LIKE '%{nf}%'
AND shipping.Num_CTE LIKE '%{cte}%'

ORDER BY shipping.dat_register DESC";

            DataTable dt = await ShippingConference.getAllToDataTable(reportQuery);
            double total = 0.0;
            dgvData.Invoke((Action)delegate
            {
                dgvData.DataSource = dt;

                foreach (DataGridViewRow _row in dgvData.Rows)
                {
                    total += Convert.ToDouble(_row.Cells[dgvData.ColumnCount - 1].Value);
                }
            });

            txtTotalValue.Invoke((Action)delegate
            {
                txtTotalValue.Text = total.ToString("C2");
            });
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmFretes_RelatorioAnalitico_Load;

        }
        private async void frmFretes_RelatorioAnalitico_Load(object sender, EventArgs e)
        {

            ConfigureDateTimePickerAttributes();
            await Task.Factory.StartNew(() => getReport());
            ConfigureDataGridViewColumnsProperties();

            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
            
        }

        /** DateTimePicker configuration **/
        private void ConfigureDateTimePickerAttributes()
        {
            dtpInitialDate.Value = DateTime.Now.AddDays(-30);
            dtpFinalDate.Value = DateTime.Now;
        }

        /** DataGridView configuration **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.toDefault();
            dgvData.MultiSelect = true;

        }
        private void ConfigureDataGridViewColumnsProperties()
        {
            dgvData.Columns[0].ValueType = typeof(int);
            dgvData.Columns[1].ValueType = typeof(int);
            dgvData.Columns[4].ValueType = typeof(int);

            dgvData.Columns[8].ValueType = typeof(double);
            dgvData.Columns[9].ValueType = typeof(double);
            dgvData.Columns[11].ValueType = typeof(double);

            dgvData.Columns[8].DefaultCellStyle.Format = "C2";
            dgvData.Columns[9].DefaultCellStyle.Format = "C2";
            dgvData.Columns[11].DefaultCellStyle.Format = "C2";
        }
        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtTransporterDescription.ReadOnly = true;
            txtTransporterDescription.TabStop = false;
            txtTotalValue.ReadOnly = true;
            txtTotalValue.TabStop = false;
            txtTransporterId.JustNumbers();
            txtNfFilter.JustNumbers();
            txtCteFilter.JustNumbers();
        }
        private void ConfigureTextBoxEvents()
        {
            txtTransporterId.TextChanged += txtCodTransportador_TextChanged;
            txtTransporterDescription.DoubleClick += txtDescricaoTransportador_DoubleClick;

            txtTransporterId.KeyDown += GenericSearch_KeyDown;
            dtpInitialDate.KeyDown += GenericSearch_KeyDown;
            dtpFinalDate.KeyDown += GenericSearch_KeyDown;
            txtNfFilter.KeyDown += GenericSearch_KeyDown;
            txtCteFilter.KeyDown += GenericSearch_KeyDown;

        }
        private void GenericSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnSearch_Click(sender, new EventArgs());
            }
        }
        private async void txtCodTransportador_TextChanged(object sender, EventArgs e)
        {
            txtTransporterDescription.Text = await Transportadores_Externos.getDescriptionByCode(txtTransporterId.Text);
        }
        private void txtDescricaoTransportador_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            frmConsultarTransportador.ShowDialog();
            txtTransporterId.Text = frmConsultarTransportador.extendedCode;
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
        private async void btnSearch_Click(object sender, EventArgs eventArgs)
        {
            await getReport();
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
