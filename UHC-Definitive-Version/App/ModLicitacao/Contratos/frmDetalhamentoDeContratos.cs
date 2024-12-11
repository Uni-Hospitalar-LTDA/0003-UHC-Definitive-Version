using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.App.Telas_Genericas;
using System.Data.SqlClient;

namespace UHC3_Definitive_Version.App.ModLicitacao.AnaliseVendas
{
    public partial class frmDetalhamentoDeContratos : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        public frmDetalhamentoDeContratos()
        {
            InitializeComponent();
            this.defaultMaximableForm();
            this.WindowState = FormWindowState.Maximized;

            ConfigureComponentesInternosEvents();

            btnFechar.toDefaultCloseButton();
            txtCodProduto.JustNumbers();
            txtCodCliente.JustNumbers();
            txtCodFabricante.JustNumbers();
            txtGiroInicial.JustNumbers();
            txtGiroFinal.JustNumbers();

            //Pesquisa por Alteração
            txtDescricaoFabricante.TextChanged += pesquisar;
            txtDescricaoProduto.TextChanged += pesquisar;
            txtDescricaoCliente.TextChanged += pesquisar;
            txtProdutoGenerico.TextChanged += pesquisar;
            txtEstado.TextChanged += pesquisar;
            txtGiroInicial.TextChanged += pesquisar;
            txtGiroFinal.TextChanged += pesquisar;
            dtpInicial.ValueChanged += pesquisar;
            dtpFinal.ValueChanged += pesquisar;
            cbxStatus.SelectedIndexChanged += pesquisar;
            txtGiroFinal.TextChanged += pesquisar;
            txtFiltroPregao.TextChanged += pesquisar;
            rdbDatInicial.CheckedChanged += pesquisar;
            rdbDatFinal.CheckedChanged += pesquisar;
            rdbDatInicioFinal.CheckedChanged += pesquisar;

            txtGiroInicial.Text = 0.ToString();
            txtGiroFinal.Text = 100.ToString();


            ConfigreFormEvents();
            RadioButtonsProperties();
        }

        /** Instância **/
        List<ExternalContrato> Contratos = new List<ExternalContrato>();
        private CancellationTokenSource cancellationTokenSource;

        //Configuração inicial do Grid
        private void configurarGrid(DataGridView dataGridView)
        {

            dataGridView.Columns.Add("Indicador", "Index");
            dataGridView.Columns[0].Frozen = true;
            dataGridView.Columns[0].Width = 10;
            dataGridView.Columns.Add("UF", "UF");
            dataGridView.Columns.Add("cod_cliente", "Cód. Cliente");
            dataGridView.Columns.Add("rzsocial_cliente", "Cliente");
            dataGridView.Columns.Add("esfera_cliente", "Tipo do Orgão");
            dataGridView.Columns.Add("cod_contrato", "Cód. Pregão (Contrato)");
            dataGridView.Columns.Add("contrato", "Pregão (Contrato)");
            dataGridView.Columns.Add("cod_produto", "Cód. Produto");
            dataGridView.Columns.Add("produto", "Produto");
            dataGridView.Columns.Add("nmgenerico_produto", "Nome Genérico do Produto");
            dataGridView.Columns.Add("Preco_unitario", "Preço Unitário");
            dataGridView.Columns.Add("Preco_Compra", "Preço Compra");
            dataGridView.Columns.Add("Margem", "Margem");
            dataGridView.Columns.Add("codFabricante", "Cód. Fabricante");
            dataGridView.Columns.Add("fabricanteFantasia", "Fabricante");
            dataGridView.Columns.Add("qtd_pedido", "Qtd. Pedido");
            dataGridView.Columns.Add("qtd_faturada", "Qtd. Faturada");
            dataGridView.Columns.Add("saldo", "Qtd. Saldo");
            dataGridView.Columns.Add("giro", "Giro (%)");
            //dataGridView.Columns["Giro"].ValueType = typeof(double);
            //dataGridView.Columns["Giro"].DefaultCellStyle.Format = "##0.#0";
            dataGridView.Columns.Add("status", "Status");
            dataGridView.Columns.Add("data_inicio", "Data Início");
            dataGridView.Columns["data_inicio"].ValueType = typeof(DateTime);
            dataGridView.Columns["data_inicio"].DefaultCellStyle.Format = "dd/MM/yyyy";


            dataGridView.Columns["Preco_unitario"].ValueType = typeof(double);
            dataGridView.Columns["Preco_unitario"].DefaultCellStyle.Format = "C2";

            dataGridView.Columns["Preco_Compra"].ValueType = typeof(double);
            dataGridView.Columns["Preco_Compra"].DefaultCellStyle.Format = "C2";

            dataGridView.Columns["Margem"].ValueType = typeof(double);
            dataGridView.Columns["Margem"].DefaultCellStyle.Format = "P2";

            dataGridView.Columns.Add("data_Final", "Data Fim");
            dataGridView.Columns["data_Final"].ValueType = typeof(DateTime);
            dataGridView.Columns["data_Final"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView.toDefault();
            dataGridView.MultiSelect = true;
            dataGridView.ReadOnly = false;
            //dataGridView.Columns["Preco_Compra"].ReadOnly = false;
            //dgvColor.ClearSelection();

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Name != "Preco_Compra")
                    column.ReadOnly = true;
            }
        }
        private void configurarGridCor()
        {
            dgvColor.Columns.Add("cor", "Cor");
            dgvColor.Columns.Add("description", "Descrição");
            dgvColor.Columns[0].Width = 10;
            dgvColor.toDefault();            
            dgvColor.DefaultCellStyle.BackColor = Color.White;

            dgvColor.Rows.Add(1, "Em andamento");
            dgvColor.Rows[dgvColor.Rows.Count - 1].Cells[0].Style.BackColor = Color.Blue;
            dgvColor.Rows[dgvColor.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Blue;
            dgvColor.Rows.Add(2, "Em aberto");
            dgvColor.Rows[dgvColor.Rows.Count - 1].Cells[0].Style.BackColor = Color.Black;
            dgvColor.Rows[dgvColor.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Black;
            dgvColor.Rows.Add(3, "Vencido");
            dgvColor.Rows[dgvColor.Rows.Count - 1].Cells[0].Style.BackColor = Color.Red;
            dgvColor.Rows[dgvColor.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Red;
            dgvColor.Rows.Add(4, "Finalizado");
            dgvColor.Rows[dgvColor.Rows.Count - 1].Cells[0].Style.BackColor = Color.Green;
            dgvColor.Rows[dgvColor.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Green;
            dgvColor.Rows.Add(5, "Cancelado");
            dgvColor.Rows[dgvColor.Rows.Count - 1].Cells[0].Style.BackColor = Color.Purple;
            dgvColor.Rows[dgvColor.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Purple;
            dgvColor.ReadOnly = true;
            dgvColor.AutoResizeColumns();
            dgvColor.TabStop = false;
            dgvColor.BackgroundColor = SystemColors.Control;
            dgvColor.BorderStyle = BorderStyle.None;
            dgvColor.Enabled = false;
            dgvColor.ClearSelection();

        }

        /** Tarefas **/
        public async Task carregarContratosDetalhados()
        {
            Contratos = await ExternalContrato.getAllToListAsync();

            //Dados relacionados
            await Section.carregar_Dependencias();
        }

        private async Task DoWorkAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                await carregarContratosDetalhados();
            }
        }

        private void filtrarDados()
        {
            dgvData.SuspendLayout();
            if (dgvData.Rows.Count > 0)
            {
                dgvData.Rows.Clear();
            }

            string[] estados = txtEstado.Text.Split(',');

            foreach (var estado in estados)
            {



                var select = from contrato in Contratos
                             join produto in Produtos_Externos.produtos on contrato.cod_produto equals produto.codigo
                             join fabricante in Fabricantes_Externos.fabricantes on produto.Cod_Fabricante equals fabricante.codigo
                             where                                                           
                                 (rdbDatInicial.Checked && Convert.ToDateTime(contrato.data_inicio) >= dtpInicial.Value && Convert.ToDateTime(contrato.data_inicio) <= dtpFinal.Value)
                                 || (rdbDatFinal.Checked && Convert.ToDateTime(contrato.data_Final) >= dtpInicial.Value && Convert.ToDateTime(contrato.data_Final) <= dtpFinal.Value)
                                 || (rdbDatInicioFinal.Checked && Convert.ToDateTime(contrato.data_inicio) >= dtpInicial.Value && Convert.ToDateTime(contrato.data_Final) <= dtpFinal.Value)
                                 && contrato.fabricanteFantasia.Contains(txtDescricaoFabricante.Text)
                                 && contrato.rzsocial_cliente.Contains(txtDescricaoCliente.Text)
                                 && contrato.produto.Contains(txtDescricaoProduto.Text)
                                 && (contrato.nmgenerico_produto.ToUpper().Contains(txtProdutoGenerico.Text.ToUpper()) ||
                                 contrato.produto.ToUpper().Contains(txtProdutoGenerico.Text.ToUpper()))
                                 && (
                                    (contrato.UF.Contains(estado.Trim().ToUpper()) && (txtEstado.Text.Contains(",") && !string.IsNullOrEmpty(estado.Trim())))
                                     || (!txtEstado.Text.Contains(",") && string.IsNullOrEmpty(estado.Trim())
                                     || (!txtEstado.Text.Contains(",") && contrato.UF.Contains(estado.Trim().ToUpper()))
                                     )
                                 )
                                 && (
                                    (!string.IsNullOrEmpty(txtGiroInicial?.Text) && (Convert.ToDouble(txtGiroInicial?.Text) <= Convert.ToDouble(contrato.giro) * 100))
                                     && (!string.IsNullOrEmpty(txtGiroInicial?.Text) && (Convert.ToDouble(txtGiroFinal?.Text) >= Convert.ToDouble(contrato.giro) * 100))
                                    )
                                 && (contrato.contrato.Contains(txtFiltroPregao.Text.ToUpper()))
                                 && ((contrato.status.ToUpper().Contains(cbxStatus.SelectedItem.ToString().ToUpper()))
                                     || cbxStatus.SelectedItem.ToString() == "Todos")
                             select new { contrato, fabricante };

                foreach (var contrato in select)
                {

                    dgvData.Rows.Add(""
                     , contrato.contrato.UF
                    , Convert.ToInt32(contrato.contrato.cod_cliente)
                    , contrato.contrato.rzsocial_cliente
                    , contrato.contrato.esfera_cliente
                    , Convert.ToInt32(contrato.contrato.cod_contrato)
                    , contrato.contrato.contrato
                    , Convert.ToInt32(contrato.contrato.cod_produto)
                    , contrato.contrato.produto
                    , contrato.contrato.nmgenerico_produto
                    , Convert.ToDouble(contrato.contrato.Preco_unitario)
                    , Convert.ToDouble(contrato.contrato.Preco_Compra)
                    , Convert.ToDouble(contrato.contrato.Preco_Compra) == 0 ? 0 : -1 + (Convert.ToDouble(contrato.contrato.Preco_unitario) / Convert.ToDouble(contrato.contrato.Preco_Compra))
                    , contrato.fabricante.codigo
                    , contrato.fabricante.Fantasia
                    , Convert.ToInt32(contrato.contrato.qtd_pedido).ToString("N0")
                    , Convert.ToInt32(contrato.contrato.qtd_faturada).ToString("N0")
                    , Convert.ToInt32(contrato.contrato.saldo).ToString("N0")
                    , Convert.ToDouble(contrato.contrato.giro) * 100.00
                    , contrato.contrato.status
                    , Convert.ToDateTime(contrato.contrato.data_inicio)
                    , Convert.ToDateTime(contrato.contrato.data_Final));

                    if (contrato.contrato.status.Equals("Finalizado"))
                    {
                        dgvData.Rows[dgvData.Rows.Count - 1].Cells[0].Style.BackColor = Color.Green;
                    }
                    else if (contrato.contrato.status.Equals("Em Andamento"))
                    {
                        dgvData.Rows[dgvData.Rows.Count - 1].Cells[0].Style.BackColor = Color.Blue;
                    }
                    else if (contrato.contrato.status.Equals("Vencido"))
                    {
                        dgvData.Rows[dgvData.Rows.Count - 1].Cells[0].Style.BackColor = Color.Red;
                    }
                    else if (contrato.contrato.status.Equals("Em Aberto"))
                    {
                        dgvData.Rows[dgvData.Rows.Count - 1].Cells[0].Style.BackColor = Color.Black;
                    }
                    else if (contrato.contrato.status.Equals("Cancelado"))
                    {
                        dgvData.Rows[dgvData.Rows.Count - 1].Cells[0].Style.BackColor = Color.Purple;
                    }

                }


                dgvData.AutoResizeColumns();
                dgvData.ResumeLayout();
            }


        }
        /** Evento do filtro**/
        private void pesquisar(object sender, EventArgs e)
        {
            filtrarDados();
        }

        /** Load do form **/
        private void ConfigreFormEvents()
        {
            this.Load += frmDetalhamentoDeContratos_Load;
            this.FormClosing += frmDetalhamentoDeContratos_FormClosing;


        }
        private async void frmDetalhamentoDeContratos_Load(object sender, EventArgs e)
        {

            /** Sessão de Teste **/
            //await Session.add("0","PE");
            configurarGrid(dgvData);
            configurarGridCor();
            lblContadorDeLinhas.Text = "";

            /** Definindo métricas de primeiro dia do mês e último dia do mês**/
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            dtpInicial.Value = firstDayOfMonth;
            //dtpFinal.Value = lastDayOfMonth;
            dtpFinal.Value = DateTime.Now;

            cbxStatus.Items.Add("Todos");
            cbxStatus.SelectedItem = "Todos";
            cbxStatus.Items.Add("Em aberto");
            cbxStatus.Items.Add("Em andamento");
            cbxStatus.Items.Add("Vencido");
            cbxStatus.Items.Add("Finalizado");
            cbxStatus.Items.Add("Cancelado");


            cbxStatus.SelectedIndexChanged += pesquisar;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                cancellationTokenSource = new CancellationTokenSource();

                if (cancellationTokenSource?.Token.CanBeCanceled == true)
                {
                    await DoWorkAsync(cancellationTokenSource.Token);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
                filtrarDados();
            }



            //lblFiltroPorGiro.Text = $"Filtro por giro ({tbGiro.Value}%)";

            //tbGiro.Maximum = 100;
            //tbGiro.Minimum = 0;


            /** Configurações dos componentes**/
            txtDescricaoProduto.ReadOnly = true;
            txtDescricaoCliente.ReadOnly = true;
            txtDescricaoFabricante.ReadOnly = true;

            txtDescricaoProduto.TabStop = false;
            txtDescricaoCliente.TabStop = false;
            txtDescricaoFabricante.TabStop = false;

            txtEstado.ScrollBars = ScrollBars.Vertical;
            txtCodProduto.MaxLength = 11;
            txtCodCliente.MaxLength = 11;
            txtCodFabricante.MaxLength = 11;

            ConfigureMenuStripProperties();
            DataGridViewEvents();
            ButtonEvents();
        }




        //Componentes Internos
        private void ConfigureComponentesInternosEvents()
        {
            txtCodProduto.TextChanged += txtCodProduto_TextChanged;
            txtCodCliente.TextChanged += txtCodCliente_TextChanged;
            txtCodFabricante.TextChanged += txtCodFabricante_TextChanged;
            txtDescricaoFabricante.DoubleClick += txtDescricaoFabricante_DoubleClick;
            txtDescricaoCliente.DoubleClick += txtDescricaoCliente_DoubleClick;
            txtDescricaoProduto.DoubleClick += txtDescricaoProduto_DoubleClick;
            txtGiroFinal.Leave += txtPorcentagem_Leave;
            txtGiroInicial.Leave += txtPorcentagem_Leave;
            txtGiroFinal.KeyDown += txtPorcentagem_KeyDown;
            txtGiroInicial.KeyDown += txtPorcentagem_KeyDown;
            txtGiroFinal.TextChanged += txtPorcentagem_TextChanged;
            txtGiroInicial.TextChanged += txtPorcentagem_TextChanged;
            dgvData.RowEnter += dgvData_RowEnter;
            dgvData.CellEnter += dgvData_CellEnter;

        }        

        private void txtCodProduto_TextChanged(object sender, EventArgs e)
        {
            txtDescricaoProduto.Text = Produtos_Externos.getDescripionByCode(txtCodProduto.Text);
        }
        private void txtCodCliente_TextChanged(object sender, EventArgs e)
        {
            txtDescricaoCliente.Text = Clientes_Externos.getDescripionByCode(txtCodCliente.Text);
        }
        private void txtCodFabricante_TextChanged(object sender, EventArgs e)
        {
            txtDescricaoFabricante.Text = Fabricantes_Externos.getDescripionByCode(txtCodFabricante.Text);
        }
        private void txtDescricaoFabricante_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarFabricante frmConsultarFabricante = new frmConsultarFabricante();
            frmConsultarFabricante.ShowDialog();
            txtCodFabricante.Text = frmConsultarFabricante.extendedCode;
            filtrarDados();
        }
        private void txtDescricaoCliente_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            txtCodCliente.Text = frmConsultarCliente.extendedCode;
            filtrarDados();
        }
        private void txtDescricaoProduto_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarProduto frmConsultarProduto = new frmConsultarProduto();
            frmConsultarProduto.ShowDialog();
            txtCodProduto.Text = frmConsultarProduto.extendedCode;
            filtrarDados();
        }
        //Pesquisa na saída do campo giro
        private void txtPorcentagem_Leave(object sender, EventArgs e)
        {

            if (sender is TextBox)
            {
                TextBox txt = (TextBox)sender;
                if (string.IsNullOrEmpty(txt.Text))
                {
                    txt.Text = 0.ToString();
                    //tbGiro.Value = 0;
                }
                else if (Convert.ToInt32(txt.Text) > 100)
                {
                    txt.Text = 100.ToString();
                    //tbGiro.Value = Convert.ToInt32(txtGiroFinal.Text);

                }
                //else
                //{
                //    //tbGiro.Value = Convert.ToInt32(txtGiroFinal.Text);
                //}

                //lblFiltroPorGiro.Text = $"Filtro por giro ({tbGiro.Value}%)";
                filtrarDados();
            }

        }
        //Controla a alteração do Giro        
        private void txtPorcentagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filtrarDados();
            }
        }
        // Controla o contador de linhas
        private void dgvData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            lblContadorDeLinhas.Text = $"Selecionado ({e.RowIndex}/{dgvData.Rows.Count - 1})"; ;
        }
        /** Botões **/
        private void ButtonEvents()
        {
            btnSalvarPrecosCompra.Click += btnSalvarPrecosCompra_Click;
        }

        private async void btnSalvarPrecosCompra_Click(object sender, EventArgs e)
        {
            List<DetalhamentoContratos> listDc = new List<DetalhamentoContratos>();
            List<string> errorMessages = new List<string>(); // Lista para capturar os erros
            string currentContrato = string.Empty;

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                ExternalContrato contrato = Contratos
                    .Where(x => x.cod_contrato == row.Cells["cod_contrato"].Value.ToString()
                                && x.cod_produto == row.Cells["cod_produto"].Value.ToString())
                    .FirstOrDefault();

                if (contrato != null)
                {
                    // Verifica se o preço mudou
                    double precoAtual = Convert.ToDouble(contrato.Preco_Compra);
                    double precoDigitado = Convert.ToDouble(row.Cells["preco_compra"].Value);

                    if (precoAtual != precoDigitado)
                    {
                        listDc.Add(new DetalhamentoContratos
                        {
                            cod_contrato = contrato.cod_contrato,
                            cod_produto = contrato.cod_produto,
                            preco_compra_digitado = precoDigitado.ToString()
                        });

                        try
                        {
                            // Tenta deletar o contrato antigo
                            await DetalhamentoContratos.deleteAsync(contrato.cod_contrato, contrato.cod_produto);
                        }
                        catch (SqlException ex)
                        {
                            // Acumula o erro para exibir posteriormente
                            errorMessages.Add($"Erro ao deletar o contrato {contrato.cod_contrato} para o produto {contrato.cod_produto}: {ex.Message}");
                        }
                    }
                }
                else
                {
                    errorMessages.Add($"Contrato não encontrado para cod_contrato: {row.Cells["cod_contrato"].Value} e cod_produto: {row.Cells["cod_produto"].Value}");
                }
            }

            // Se houve erros durante o delete
            if (errorMessages.Count == 0 && listDc.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    await DetalhamentoContratos.insertAsync(listDc);
                    CustomNotification.defaultInformation($"{listDc.Count} preço(s) atualizado(s) com sucesso!");
                    await carregarContratosDetalhados();
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError($"Erro ao inserir novos valores: {ex.Message}");
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else if (errorMessages.Count > 0)
            {
                // Exibe todos os erros encontrados
                string errorMsg = string.Join(Environment.NewLine, errorMessages);
                CustomNotification.defaultError($"Ocorreram erros durante o processo: {Environment.NewLine}{errorMsg}");
            }
            else
            {
                CustomNotification.defaultInformation("Nenhuma alteração de preços foi encontrada.");
            }
        }


        private void DataGridViewEvents()
        {
            dgvData.CellValidated += dgvData_CellValidated;
        }
        private void txtPorcentagem_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGiroFinal.Text))
            {
                filtrarDados();
            }
        }
        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvData.Rows[e.RowIndex].Selected = true;
            }
        }
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a célula atual é a de "Preco_Compra"
            if (e.ColumnIndex == dgvData.Columns["Preco_Compra"].Index)
            {
                // Tenta converter os valores de "Preco_Unitario" e "Preco_Compra"
                if (double.TryParse(dgvData.Rows[e.RowIndex].Cells["Preco_Unitario"].Value?.ToString(), out double precoUnitario) &&
                    double.TryParse(dgvData.Rows[e.RowIndex].Cells["Preco_Compra"].Value?.ToString(), out double precoCompra))
                {
                    // Verifica se o valor de "Preco_Compra" é maior que zero para evitar divisão por zero
                    if (precoCompra > 0)
                    {
                        double margem = -1 + (precoUnitario / precoCompra);
                        dgvData.Rows[e.RowIndex].Cells["Margem"].Value = margem;
                    }
                    else
                    {
                        // Se o valor de "Preco_Compra" for zero, define a margem como zero
                        dgvData.Rows[e.RowIndex].Cells["Margem"].Value = 0;
                    }
                }
                else
                {
                    // Caso algum dos valores não seja válido, define a margem como zero
                    dgvData.Rows[e.RowIndex].Cells["Margem"].Value = 0;
                }
            }
        }
        private void frmDetalhamentoDeContratos_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }


        


        /** Menu Strip Configuration **/
        private void ConfigureMenuStripProperties()
        {
            CustomToolStripMenuItem menuArquivo = new CustomToolStripMenuItem("Arquivo");
            CustomToolStripMenuItem itemArquivoAbrir = new CustomToolStripMenuItem("Abrir");
            CustomToolStripMenuItem itemArquivoAbrirExcel = new CustomToolStripMenuItem("Excel");
            CustomToolStripMenuItem itemArquivoExportar = new CustomToolStripMenuItem("Exportar");
            CustomToolStripMenuItem itemArquivoExportarExcel = new CustomToolStripMenuItem("Excel");
            CustomToolStripMenuItem menuConsultas = new CustomToolStripMenuItem("Consulta externas");
            CustomToolStripMenuItem itemConsultasClientes = new CustomToolStripMenuItem("Clientes");
            CustomToolStripMenuItem itemConsultasFabricantes = new CustomToolStripMenuItem("Fabricantes"); 
            CustomToolStripMenuItem itemConsultasProdutos = new CustomToolStripMenuItem("Produtos");

            itemArquivoAbrirExcel.Click += ItemArquivoAbrirExcel_Click;
            itemArquivoExportarExcel.Click += ItemArquivoExportarExcel_Click;
            itemConsultasClientes.Click += ItemConsultasClientes_Click;
            itemConsultasFabricantes.Click += ItemConsultasFabricantes_Click;
            itemConsultasProdutos.Click += ItemConsultasProdutos_Click;

            // Adicionando o item 'Empresa' e seu evento de clique

            menuArquivo.DropDownItems.Add(itemArquivoAbrir);
            menuArquivo.DropDownItems.Add(itemArquivoExportar);
            itemArquivoAbrir.DropDownItems.Add(itemArquivoAbrirExcel);
            itemArquivoExportar.DropDownItems.Add(itemArquivoExportarExcel);

            menuConsultas.DropDownItems.Add(itemConsultasClientes);
            menuConsultas.DropDownItems.Add(itemConsultasFabricantes);
            menuConsultas.DropDownItems.Add(itemConsultasProdutos);

            // Adiciona o menuConfiguracao ao menu principal
            menuStrip.Items.Add(menuArquivo);
            menuStrip.Items.Add(menuConsultas);
            this.Controls.Add(menuStrip);

        }

        private void ItemConsultasProdutos_Click(object sender, EventArgs e)
        {
            frmConsultarProduto frmConsultarProduto = new frmConsultarProduto();
            txtCodProduto.Text = frmConsultarProduto.extendedCode;
            frmConsultarProduto.Show();
        }

        private void ItemConsultasFabricantes_Click(object sender, EventArgs e)
        {
            frmConsultarFabricante frmConsultarFabricante = new frmConsultarFabricante();
            txtCodFabricante.Text = frmConsultarFabricante.extendedCode;
            frmConsultarFabricante.Show();
        }

        private void ItemConsultasClientes_Click(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            txtCodCliente.Text = frmConsultarCliente.extendedCode;
            frmConsultarCliente.Show();
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

        private void RadioButtonsProperties()
        {
            rdbDatInicial.Checked = true;
        }

    }

}
