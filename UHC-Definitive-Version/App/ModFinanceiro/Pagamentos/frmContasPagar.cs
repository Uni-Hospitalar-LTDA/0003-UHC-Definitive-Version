using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using System.Linq;
using UHC3_Definitive_Version.App.Telas_Genericas;

namespace UHC3_Definitive_Version.App.ModFinanceiro.Pagamentos
{
    public partial class frmContasPagar : CustomForm
    {
        /** Instância **/
        List<ContasPagar> contasPagar = new List<ContasPagar>();
        DateTime datePersistent;
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal class ContasPagar : Querys<ContasPagar>
        {
            public string codigoEntidade { get; set; }
            public string descricaoEntidade { get; set; }
            public string tipoEntidade { get; set; }
            public string duplicata { get; set; }
            public string dataEmissao { get; set; }
            public string dataPagamento { get; set; }
            public string dataVencimento { get; set; }
            public string valorPrincipal { get; set; }


            public static Task<List<ContasPagar>> getContasPagarToListAsync(DateTime date)
            {
                string query = $@"SELECT																						
                        [codigoEntidade] = 																					
                        		CASE ISNULL(CT.Cod_Fornec,0)															
                        		WHEN 0 THEN 																			
                        			CASE ISNULL(CT.Cod_Favore,0)														
                        			WHEN 0 THEN CT.Cod_Transp															
                        			ELSE CT.Cod_Favore																	
                        			END																					
                        		ELSE CT.Cod_Fornec																		
                        		END																						
                        ,[descricaoEntidade] = 																		
                        		CASE ISNULL(CT.Cod_Fornec,0)															
                        		WHEN 0 THEN 																			
                        			CASE ISNULL(CT.Cod_Favore,0)											
                        			WHEN 0 THEN Transportadora.Razao_Social									
                        			ELSE Favorecido.Des_Favore												
                        			END																		
                        		ELSE Fornecedor.Razao_Social												
                        		END																			
                        ,[tipoEntidade] =																	
                        		CASE ISNULL(CT.Cod_Fornec,0)												
                        		WHEN 0 THEN 																
                        			CASE ISNULL(CT.Cod_Favore,0)											
                        			WHEN 0 THEN 'Transportadora'											
                        			ELSE 'Favorecido'														
                        			END																		
                        		ELSE 'Fornecedor'															
                        		END																			
                        																					
                        ,CT.Num_Docume					[duplicata]											
                        ,[dataEmissao]		= Convert(date, CT.Dat_Emissa)										
                        ,[dataPagamento]	= Convert(date,Dat_Quitac)		
                        ,[dataVencimento]	= Convert(date, Dat_Vencim) 										
                        ,[valorPrincipal] = CT.Val_Docume													
                        FROM [DMD].dbo.[PAGCT] CT 																		
                        LEFT JOIN [DMD].dbo.[FAVOR] Favorecido ON Favorecido.Cod_Favore = CT.Cod_Favore					
                        LEFT JOIN [DMD].dbo.[FORNE] Fornecedor ON Fornecedor.Codigo = CT.Cod_Fornec						
                        LEFT JOIN [DMD].dbo.[TRANS] Transportadora ON Transportadora.Codigo = CT.Cod_Transp 			
                        WHERE 			
						
						/** Filtros Fixos **/
                        (Sta_Docume NOT LIKE 'C' or Sta_Docume = 'C' AND Dat_Cancel > '{date.ToString("yyyyMMdd")}') 					
                        AND(CT.Dat_Quitac > '{date.ToString("yyyyMMdd")}' OR not (CT.Dat_Quitac <= '{date.ToString("yyyyMMdd")}' and Sta_Docume = 'Q')) 	
                        AND(CT.Dat_Registro <= '{date.ToString("yyyyMMdd")}' AND Convert(date, Dat_Emissa) <= '{date.ToString("yyyyMMdd")}')  			
                        AND Num_Docume NOT LIKE '%P%'  																
                        AND Tip_Documento not like 'OR'";
                Console.WriteLine(query);
                ;
                return getAllToList(query);
            }
        }

        public frmContasPagar()
        {
            InitializeComponent();

            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();
            ConfigureMenuStripProperties();
            ConfigureFormEvents();
            







        }

        /** Async Tasks  **/
        private async Task getFromDataBase(DateTime date)
        {
            contasPagar = await ContasPagar.getContasPagarToListAsync(date);
        }
        private async Task filtrarDados()
        {

            if (chkValor.Checked && (string.IsNullOrEmpty(txtValorInicial.Text) || string.IsNullOrEmpty(txtValorFinal.Text)))
            {
                CustomNotification.defaultAlert("O parâmetro de valor não pode estar vazio!");
                return;
            }


            if (datePersistent == dtpDatCorte.Value)
            {
                filtrarDadosMemoria();
            }
            else
            {
                await getFromDataBase(dtpDatCorte.Value);
                datePersistent = dtpDatCorte.Value;
                filtrarDadosMemoria();
            }
        }

        /** Sync Methods **/
        private void filtrarDadosMemoria()
        {
            var filteredList = contasPagar.Where(c =>
            //( (chkFornecedor.Checked && c.codigoEntidade == txtCodFornecedor.Text) ||

            /** Condicional favorecidos **/

            ((chkFavorecido.Checked &&
            (txtCodFavorecidos.Text == c.codigoEntidade && !string.IsNullOrEmpty(txtDescFavorecidos.Text))
             || string.IsNullOrEmpty(txtDescFavorecidos.Text))
             && (chkFavorecido.Checked && chkFavorecido.Text == c.tipoEntidade)
        ||
        (chkFornecedor.Checked &&
            (txtCodFornecedor.Text == c.codigoEntidade && !string.IsNullOrEmpty(txtDescFornecedor.Text))
             || string.IsNullOrEmpty(txtDescFornecedor.Text))
        && (chkFornecedor.Checked && chkFornecedor.Text == c.tipoEntidade)
            ||
            (chkTransportadora.Checked &&
                (txtCodTransportadores.Text == c.codigoEntidade && !string.IsNullOrEmpty(txtDescTransportadores.Text))
                 || string.IsNullOrEmpty(txtDescTransportadores.Text))
            && (chkTransportadora.Checked && chkTransportadora.Text == c.tipoEntidade)
            )
    &&
    ((chkVencimento.Checked && DateTime.Parse(c.dataVencimento) >= dtpDtVencInicial.Value && DateTime.Parse(c.dataVencimento) <= dtpDtVencFinal.Value)
    || !chkVencimento.Checked)
    &&
    ((chkValor.Checked && (Convert.ToDouble(c.valorPrincipal) >= Convert.ToDouble(txtValorInicial.Text))
                      && (Convert.ToDouble(c.valorPrincipal) <= Convert.ToDouble(txtValorFinal.Text)))
                      || !chkValor.Checked)
    && (c.duplicata.Contains(txtTitulo.Text))
    ).ToList();


            dgvData.Rows.Clear();
            double valorTotal = 0.0;

            foreach (var row in filteredList)
            {
                dgvData.Rows.Add(
                    Convert.ToInt32(row.codigoEntidade)
                   , row.descricaoEntidade
                   , row.tipoEntidade
                   , row.duplicata
                   , row.dataEmissao != null ? Convert.ToDateTime(row.dataEmissao) : (DateTime?)null
                   , row.dataPagamento != null ? Convert.ToDateTime(row.dataPagamento) : (DateTime?)null
                   , row.dataVencimento != null ? Convert.ToDateTime(row.dataVencimento) : (DateTime?)null
                   , Convert.ToDouble(row.valorPrincipal).ToString("C")
                        );

                valorTotal += Convert.ToDouble(row.valorPrincipal);
            }
            txtVlrTotal.Text = valorTotal.ToString("C");
            dgvData.Columns["valorPrincipal"].DefaultCellStyle.Format = "R$ #,##0.00";
            dgvData.Columns["dataEmissao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvData.Columns["dataVencimento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvData.Columns["dataPagamento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvData.AutoResizeColumns();
            dgvData.Columns["valorPrincipal"].Width = 120;

        }

        /** Generic events**/
        private async void pesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                await filtrarDados();
            }
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmContasPagar_Load;
        }



        private async void frmContasPagar_Load(object sender, EventArgs e)
        {
            /** Components configuration **/
            dtpDtVencInicial.Value = DateTime.Now.AddDays(-90);
            dtpDtVencFinal.Value = DateTime.Now;
            dtpDtVencInicial.Enabled = false;
            dtpDtVencFinal.Enabled = false;

            configurarGrid(dgvData);

            /**Getting last day of month**/
            DateTime data = DateTime.Today;
            DateTime ultimoDiaDoMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
            datePersistent = ultimoDiaDoMes;
            dtpDatCorte.Value = ultimoDiaDoMes;

            await getFromDataBase(dtpDatCorte.Value);

            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
            ConfigureCheckBoxEvents();
            
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();


        }
        private void ConfigureButtonEvents()
        {
            btnPesquisar.Click += btnPesquisar_Click;
        }

        /** Configurações **/
        private void configurarGrid(DataGridView _dgv)
        {
            _dgv.Columns.Add("codigoEntidade", "Cód. Entidade");
            _dgv.Columns.Add("descricaoEntidade", "Entidade");
            _dgv.Columns.Add("tipoEntidade", "Tipo");
            _dgv.Columns.Add("duplicata", "Duplicata");
            _dgv.Columns.Add("dataEmissao", "Dt. Emissão");
            _dgv.Columns.Add("dataPagamento", "Dt. Pagamento");
            _dgv.Columns.Add("dataVencimento", "Dt. Vencimento");
            _dgv.Columns.Add("valorPrincipal", "Vlr. Principal");

            _dgv.toDefault();
            _dgv.MultiSelect = true;
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtValorFinal.Enabled = false;
            txtValorInicial.Enabled = false;
            txtDescFornecedor.ReadOnly = true;
            txtDescFavorecidos.ReadOnly = true;
            txtDescTransportadores.ReadOnly = true;
            txtVlrTotal.ReadOnly = true;
            txtCodFavorecidos.JustNumbers();
            txtCodFornecedor.JustNumbers();
            txtCodTransportadores.JustNumbers();
            txtValorInicial.justDecimalNumbers();
            txtValorFinal.justDecimalNumbers();
        }
        private void ConfigureTextBoxEvents()
        {
            txtCodFornecedor.TextChanged += txtCodFornecedor_TextChanged;
            txtDescFornecedor.DoubleClick += txtDescFornecedor_DoubleClick;
            txtCodTransportadores.TextChanged += txtCodTransportadores_TextChanged;
            txtDescTransportadores.DoubleClick += txtDescTransportadores_DoubleClick;
            txtCodFavorecidos.TextChanged += txtCodFavorecidos_TextChanged;
            txtDescFavorecidos.DoubleClick += txtDescFavorecidos_DoubleClick;
            txtCodFornecedor.KeyDown += pesquisar_KeyDown;
            txtCodFavorecidos.KeyDown += pesquisar_KeyDown;
            txtCodTransportadores.KeyDown += pesquisar_KeyDown;
            txtTitulo.KeyDown += pesquisar_KeyDown;
            txtValorInicial.KeyDown += pesquisar_KeyDown;
            txtValorFinal.KeyDown += pesquisar_KeyDown;
        }
        private async void txtCodFornecedor_TextChanged(object sender, EventArgs e)
        {
            txtDescFornecedor.Text = await Fornecedores_Externos.getDescriptionByCode(txtCodFornecedor.Text);
        }
        private void txtDescFornecedor_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarFornecedor frmConsultarFornecedor = new frmConsultarFornecedor();
            frmConsultarFornecedor.ShowDialog();
            txtCodFornecedor.Text = frmConsultarFornecedor.extendedCode;
        }
        private async void txtCodTransportadores_TextChanged(object sender, EventArgs e)
        {
            txtDescTransportadores.Text = await Transportadores_Externos.getDescriptionByCode(txtCodTransportadores.Text);
        }
        private void txtDescTransportadores_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            frmConsultarTransportador.ShowDialog();
            txtCodTransportadores.Text = frmConsultarTransportador.extendedCode;
        }
        private async void txtCodFavorecidos_TextChanged(object sender, EventArgs e)
        {
            txtDescFavorecidos.Text = await Favorecidos_Externos.getDescriptionByCode(txtCodFavorecidos.Text);
        }
        private void txtDescFavorecidos_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarFavorecido frmConsultarFavorecido = new frmConsultarFavorecido();
            frmConsultarFavorecido.ShowDialog();
            txtCodFavorecidos.Text = frmConsultarFavorecido.extendedCode;
        }

        /** CheckBox configuration **/
        private void ConfigureCheckBoxEvents()
        {
            chkValor.CheckedChanged += chkValor_CheckedChanged;
            chkVencimento.CheckedChanged += chkVencimento_CheckedChanged;
        }
        private void chkValor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkValor.Checked)
            {
                txtValorInicial.Enabled = true;
                txtValorFinal.Enabled = true;
            }
            else
            {
                txtValorInicial.Enabled = false;
                txtValorFinal.Enabled = false;
            }
        }
        private void chkVencimento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVencimento.Checked)
            {
                dtpDtVencInicial.Enabled = true;
                dtpDtVencFinal.Enabled = true;
            }
            else
            {
                dtpDtVencInicial.Enabled = false;
                dtpDtVencFinal.Enabled = false;
            }

        }



        /** Buttons Events **/
        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            await filtrarDados();
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
