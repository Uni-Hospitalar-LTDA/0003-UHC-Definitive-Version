using System.Windows.Forms;
using System;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Configuration;
using System.Threading.Tasks;
using System.Data;
using UHC3_Definitive_Version.App.Telas_Genericas;

namespace UHC3_Definitive_Version.App.ModFinanceiro.Acompanhamento
{

   
    public partial class frmTitulosVsEmpenho : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal class Report : Querys<Report>
        {
            /** Instance **/
            public static async Task<DataTable> getAllToDataTableAsync(DateTime dt1, DateTime dt2, string emp, string customerId, string nf, string state, string customerType, string customerGroup)
            {
                string uf = "";
                string type = "";
                switch (state)
                {
                    case "Acre":
                        uf = "AC";
                        break;
                    case "Alagoas":
                        uf = "AL";
                        break;
                    case "Amapá":
                        uf = "AP";
                        break;
                    case "Amazonas":
                        uf = "AM";
                        break;
                    case "Bahia":
                        uf = "BA";
                        break;
                    case "Ceará":
                        uf = "CE";
                        break;
                    case "Distrito Federal":
                        uf = "DF";
                        break;
                    case "Espírito Santo":
                        uf = "ES";
                        break;
                    case "Goiás":
                        uf = "GO";
                        break;
                    case "Maranhão":
                        uf = "MA";
                        break;
                    case "Mato Grosso":
                        uf = "MT";
                        break;
                    case "Mato Grosso do Sul":
                        uf = "MS";
                        break;
                    case "Minas Gerais":
                        uf = "MG";
                        break;
                    case "Pará":
                        uf = "PA";
                        break;
                    case "Paraíba":
                        uf = "PB";
                        break;
                    case "Paraná":
                        uf = "PR";
                        break;
                    case "Pernambuco":
                        uf = "PE";
                        break;
                    case "Piauí":
                        uf = "PI";
                        break;
                    case "Rio de Janeiro":
                        uf = "RJ";
                        break;
                    case "Rio Grande do Norte":
                        uf = "RN";
                        break;
                    case "Rio Grande do Sul":
                        uf = "RS";
                        break;
                    case "Rondônia":
                        uf = "RO";
                        break;
                    case "Roraima":
                        uf = "RR";
                        break;
                    case "Santa Catarina":
                        uf = "SC";
                        break;
                    case "São Paulo":
                        uf = "SP";
                        break;
                    case "Sergipe":
                        uf = "SE";
                        break;
                    case "Tocantins":
                        uf = "TO";
                        break;
                }

                if (customerType.ToUpper().Equals("PRIVATE"))
                    type = "AND Cliente.Tipo_Consumidor IN ('F','N')";
                else if (customerType.ToUpper().Equals("PÚBLICO"))
                    type = "AND Cliente.Tipo_Consumidor IN ('M','P','E')";



                string query =
        $@"
SELECT Cliente.Codigo					[Código],
       Cliente.fantasia					[Nome Fantasia],
       Cliente.Razao_Social				[Razão Social],
       Cliente.Cod_Estado				[UF],
       Ramo_Atividade.Descricao			[Esfera do Cliente],	 
       CT_Recebidas.Num_Documento		[Nota Fiscal],
       CT_Recebidas.Par_Documento		[Parcela],
       CT_Recebidas.Obs_Int				[Num. Empenho],
       Vendedor.Nome_Guerra				[Vendedor],
       CT_Recebidas.Dat_Emissao			[Data de Emissão],
       CT_Recebidas.Dat_Vencimento		[Data de Vencimento],
       CT_Recebidas.Vlr_Documento		[Vlr. Base do Título]
FROM	   [DMD].dbo.[CTREC] CT_Recebidas
INNER JOIN [DMD].dbo.[CLIEN] Cliente ON CT_Recebidas.Cod_Cliente = Cliente.Codigo
INNER JOIN [DMD].dbo.[RMATV] Ramo_Atividade ON Cliente.Cod_RamoAtividade = Ramo_Atividade.Codigo
INNER JOIN [DMD].dbo.[VENDE] Vendedor on CT_Recebidas.Cod_Vendedor = Vendedor.Codigo 
INNER JOIN [DMD].dbo.[GRCLI] Grupo_Cliente ON Grupo_Cliente.Cod_GRPCLI = Cliente.Cod_GRPCLI
WHERE Status = 'A'
AND CT_Recebidas.Dat_Emissao BETWEEN '{dt1.ToString("yyyyMMdd")}' AND '{dt2.ToString("yyyyMMdd")}'
AND CT_Recebidas.Obs_Int LIKE '%{emp}%'
AND Grupo_Cliente.Des_GrpCli LIKE '%{customerGroup}%'
{(!string.IsNullOrEmpty(uf) ? $"AND Cliente.Cod_Estado = '{uf}'" : null)}
{(!string.IsNullOrEmpty(customerId) ? $"AND Cliente.Codigo = '{customerId}'" : null)}
{(!string.IsNullOrEmpty(nf) ? $"AND CT_Recebidas.Num_Documento = '%{nf}%'" : null)}
{(!string.IsNullOrEmpty(type) ? type : null)}
ORDER BY CT_Recebidas.Dat_Emissao asc, Cliente.Codigo asc ,[Nota Fiscal] asc, Parcela asc

";
                Console.WriteLine(query);
                return await Report.getAllToDataTable(query);
            }
        }

        public frmTitulosVsEmpenho()
        {
            InitializeComponent();


            /** Properties **/
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureComboBoxProperties();
            ConfigureDataGridViewProperties();
            ConfigureButtonProperties();
            ConfigureMenuStripProperties();
            /** Evemts **/
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private async Task getReportAsync()
        {
            dgvData.DataSource =
                await Report.getAllToDataTableAsync(dtpInitial.Value, dtpFinal.Value, txtEmpenho.Text
                                                   , txtCustomerId.Text, txtNF.Text, cbxState.Text
                                                   , cbxCustomerType.Text, txtCustomerGroup.Text);
            dgvData.AutoResizeColumns();
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmTitulosVsEmpenhos_Load;
        }
        private async void frmTitulosVsEmpenhos_Load(object sender, EventArgs e)
        {

            ConfigureComboBoxAttributes();
            ConfigureDateTimePickerAttributes();
            await getReportAsync();
            ConfigureButtonEvents();
            ConfigureTextBoxEvents();            

        }

        /** Configure TextBox**/
        private void ConfigureTextBoxProperties()
        {
            txtCustomerDescription.ReadOnly = true;
            txtCustomerDescription.TabStop = true;
            txtCustomerId.JustNumbers();

            txtNF.JustNumbers();
        }
        private void ConfigureTextBoxEvents()
        {
            txtCustomerId.TextChanged += txtCustomerId_TextChanged;
            txtCustomerDescription.DoubleClick += txtCustomerDescription_DoubleClick;
            txtCustomerId.KeyDown += searchWithEnter_KeyDown;
            txtEmpenho.KeyDown += searchWithEnter_KeyDown;
            txtNF.KeyDown += searchWithEnter_KeyDown;
        }
        private void txtCustomerDescription_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            txtCustomerId.Text = frmConsultarCliente.extendedCode;
        }
        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            txtCustomerDescription.Text = Clientes_Externos.getDescripionByCode(txtCustomerId.Text);
        }
        private void searchWithEnter_KeyDown(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
        /** Configure DateTimePicker**/
        private void ConfigureDateTimePickerAttributes()
        {
            dtpInitial.Value = DateTime.Now.AddDays(-15);
            dtpInitial.Value = DateTime.Now.AddDays(15);
        }

        /** Configure ComboBox **/
        private void ConfigureComboBoxAttributes()
        {
            cbxState.Items.Add("Acre");
            cbxState.Items.Add("Alagoas");
            cbxState.Items.Add("Amapá");
            cbxState.Items.Add("Amazonas");
            cbxState.Items.Add("Bahia");
            cbxState.Items.Add("Ceará");
            cbxState.Items.Add("Distrito Federal");
            cbxState.Items.Add("Espírito Santo");
            cbxState.Items.Add("Goiás");
            cbxState.Items.Add("Maranhão");
            cbxState.Items.Add("Mato Grosso");
            cbxState.Items.Add("Mato Grosso do Sul");
            cbxState.Items.Add("Minas Gerais");
            cbxState.Items.Add("Pará");
            cbxState.Items.Add("Paraíba");
            cbxState.Items.Add("Paraná");
            cbxState.Items.Add("Pernambuco");
            cbxState.Items.Add("Piauí");
            cbxState.Items.Add("Rio de Janeiro");
            cbxState.Items.Add("Rio Grande do Norte");
            cbxState.Items.Add("Rio Grande do Sul");
            cbxState.Items.Add("Rondônia");
            cbxState.Items.Add("Roraima");
            cbxState.Items.Add("Santa Catarina");
            cbxState.Items.Add("São Paulo");
            cbxState.Items.Add("Sergipe");
            cbxState.Items.Add("Tocantins");


            cbxCustomerType.Items.Add("Público");
            cbxCustomerType.Items.Add("Privado");

        }
        private void ConfigureComboBoxProperties()
        {
            cbxState.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCustomerType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.MultiSelect = true;
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
            btnClose.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
        }
        private void ConfigureButtonEvents()
        {
            btnSearch.Click += btnSearch_Click;

        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (!txtCustomerDescription.Text.Equals(string.Empty))
                txtCustomerId.Text = string.Empty;
            await getReportAsync();


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
