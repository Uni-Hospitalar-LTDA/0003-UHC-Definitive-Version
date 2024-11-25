using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.ModVendas.Consultas;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModVendas.Precificacao
{
    public partial class frmConsultaDePrecos : CustomForm
    {
        /** Instância **/
        int itens = 0;
        int lastItem = 0;
        int contador = 0;
        private CancellationTokenSource cancellationTokenSource;
        int interval = 150000;
        private System.Windows.Forms.Timer inputTimer;
        List<Precificacao> screenProducts = new List<Precificacao>();
        internal class Precificacao : Querys<Precificacao>
        {
            public string Cod_Produto { get; set; }
            public string Cod_EAN { get; set; }
            public string Qtd_Disponivel { get; set; }
            public string T1 { get; set; }
            public string T2 { get; set; }
            public string T3 { get; set; }
            public string Cod_Fabricante { get; set; }

            public static async Task<List<Precificacao>> getAllToListAsync()
            {
                string query = $@"

                            SELECT 
                              Produto.Codigo			[Cod_Produto]                              
                             ,Produto.Cod_EAN			[Cod_EAN] 
                             ,Produto.Qtd_Disponivel	[Qtd_Disponivel] 
                             ,Produto.Prc_Venda			[T1] 
                             ,T2.Val_PrcVen			    [T2] 
                             ,T3.Val_PrcVen			    [T3]        
                             ,Fabricante.Codigo         [Cod_Fabricante]
                             FROM		[DMD].dbo.[PRODU] Produto 
                             JOIN		[DMD].dbo.[FABRI] Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante 
                             LEFT  JOIN [DMD].dbo.[TPXPR] T2 ON (T2.COD_PRODUT = Produto.Codigo AND T2.Cod_TabPrc = 2)
                             LEFT  JOIN [DMD].dbo.[TPXPR] T3 ON (T3.Cod_Produt = Produto.Codigo AND T3.Cod_TabPrc = 3)                             
                            ";
                return await getAllToList(query);
            }
            public static async Task<Tuple<string, string>> getInformacoesAdicionaisAsync(string codProduto)
            {
                string tipo = null, localizacao = null;

                using (SqlConnection connectDMD = Connection.getInstancia().getConnectionApp(Section.Unidade))
                {
                    try
                    {
                        connectDMD.Open();

                        SqlCommand command = connectDMD.CreateCommand();
                        command.CommandText = $@"SELECT	
                                                Produto.codigo
                                                ,Classificacao.Descricao, 
                                                [Localizacao] = CASE Produto.COD_LOCFIS 
                                                WHEN '1' THEN 'Medicamento comum' 
                                                WHEN '2' THEN 'Medicamento controlado' 
                                                WHEN '3' THEN 'Medicamento perecível' 
                                                WHEN '4' THEN 'Correlatos' 
                                                WHEN 'ALM' THEN 'Almoxarifado' 
                                                ELSE 
                                                'Localização inválida' 
                                                END                                                 
                                                FROM [DMD].dbo.[PRODU] Produto
                                                JOIN [DMD].dbo.[CLASS] Classificacao ON Classificacao.Codigo = SUBSTRING(COD_CLASSIF,0,5)                                                 
                                                WHERE Produto.CODIGO = {codProduto}                                                
                                                GROUP BY 
                                                 Classificacao.Descricao
                                                ,Produto.COD_LOCFIS 
                                                ,Produto.Prc_Venda
                                                ,produto.Codigo						
						 ";

                        SqlDataReader reader = await command.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            if (reader["Localizacao"] != null)
                            {
                                localizacao = reader["Localizacao"].ToString();
                                tipo = reader["Descricao"].ToString();
                            }
                        }
                        return new Tuple<string, string>(localizacao, tipo);
                    }
                    catch (SqlException SQLe)
                    {
                        CustomNotification.defaultError(SQLe.Message);
                        return null;
                    }
                    finally
                    {
                        connectDMD.Close();
                    }
                }
            }
        }

        public frmConsultaDePrecos()
        {
            InitializeComponent();
            this.Load += frmPrecificacao_Load;
            this.FormClosing += frmInformativoDeProdutos_FormClosing;

            this.defaultFixedForm();
                        
            txtCodFabricante.JustNumbers();
            txtCodProduto.JustNumbers();
            txtEstoque.JustNumbers();
            btnFechar.toDefaultCloseButton();


            btnLotes.Click += btnLotes_Click;
            btnUltimasVendas.Click += btnUltimasVendas_Click;


            txtDescricaoFabricante.DoubleClick += txtDescricaoFabricante_DoubleClick;
            txtDescricaoProduto.DoubleClick += txtDescricaoProduto_DoubleClick;
            txtCodProduto.TextChanged += txtCodProduto_TextChanged;
            txtCodFabricante.TextChanged += txtCodFabricante_TextChanged;

            // Cria um Timer com intervalo de 500ms
            inputTimer = new System.Windows.Forms.Timer();
            inputTimer.Interval = 1000;
            inputTimer.Tick += InputTimer_Tick;

            // Define o evento TextChanged do TextBox
            txtProdutoGenerico.TextChanged += delayedSearchDataEvent_TextChanged;

            dgvData.SelectionChanged += dgvData_SelectionChanged;
            dgvData.DoubleClick += dgvData_DoubleClick;
            //dgvData.Scroll += dgvData_Scroll;
        }



        
        
        /** Async Tasks **/
        private async Task carregarScreenProducts()
        {
            screenProducts = await Precificacao.getAllToListAsync();
        }        
        private async Task DoWorkAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Cursor = Cursors.WaitCursor;
                });

                await carregarScreenProducts();


                this.Invoke((MethodInvoker)delegate
                {
                    this.Cursor = Cursors.Default;
                });
            }
        }
        private async Task DoContinuousWorkAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await carregarScreenProducts();

                await Task.Delay(interval, token);
            }
        }
        
        /** Sync Methods **/
        private void searchData(DataGridView dataGridView)
        {            
            /** para teste**/
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string descricaoProduto = txtDescricaoProduto.Text;
                string descricaoFabricante = txtDescricaoFabricante.Text;
                string descricaoProdutoGenerico = txtProdutoGenerico.Text.ToUpper();
                string estoque = txtEstoque.Text;
                bool oncologico = chkOncologico.Checked;
                bool hospitalar = chkHospitalar.Checked;

                var select = from screenProduto in screenProducts
                             join produto in Produtos_Externos.produtos on screenProduto.Cod_Produto equals produto.codigo
                             join fabricante in Fabricantes_Externos.fabricantes on screenProduto.Cod_Fabricante equals fabricante.codigo
                             where

                                (produto.descricao.Contains(descricaoProduto))
                                 && (fabricante.Fantasia.Contains(descricaoFabricante))
                                 && (!string.IsNullOrEmpty(produto.Des_NomGen) &&
                                 (produto.Des_NomGen.Contains(descricaoProdutoGenerico)
                                 || produto.descricao.Contains(descricaoProdutoGenerico))
                                 )
                             && ((!string.IsNullOrEmpty(estoque) && Convert.ToInt32(produto.Qtd_Disponivel) >= Convert.ToInt32(estoque))
                                    || string.IsNullOrEmpty(estoque))
                             && ((oncologico && produto.Tipo == "Oncológico") || (hospitalar && produto.Tipo == "Hospitalar"))

                             select new { screenProduto, produto, fabricante };



                itens = select.Count();
                int contadorInterno = 0;
                foreach (var produto in select)
                {                                        
                    if (contador == (lastItem+30) ? true:false) break; 
                    else if (contadorInterno >= contador)
                    {
                        dataGridView.Rows.Add(
                         Convert.ToInt32(produto.screenProduto.Cod_Produto)
                        , produto.produto.descricao
                        , produto.produto.Des_NomGen
                        , produto.produto.cod_EAN
                        ,produto.produto.Tipo
                        , Produtos_Externos.getStockFromExternalProduct(produto.screenProduto.Cod_Produto)
                        , Convert.ToDouble(produto.screenProduto.T1).ToString("C")
                        , Convert.ToDouble(produto.screenProduto.T2).ToString("C")
                        , Convert.ToDouble(produto.screenProduto.T3).ToString("C")
                        , Convert.ToInt32(produto.fabricante.codigo)
                        , produto.fabricante.Fantasia
                        , produto.produto.Tipo                        
                        );
                        contador++;
                    }
                    contadorInterno++;
                }
                
                lastItem = contador;                
                dataGridView.AutoResizeColumns();
                this.Cursor = Cursors.Default;
            }
            catch
            {

            }
        }
        private void configureDataGridView()
        {
            dgvData.Columns.Add("Cod_Produto","Cód. Produto");
            dgvData.Columns.Add("Produto", "Produto");
            dgvData.Columns.Add("Nome_Generico", "Desc. Genérica");
            dgvData.Columns.Add("Cod_EAN", "EAN");
            dgvData.Columns.Add("Tipo", "Tipo");

            dgvData.Columns.Add("Qtd_Disponivel", "Qtd. Disponível");
            dgvData.Columns.Add("T1", "T1");
            dgvData.Columns.Add("T2", "T2");
            dgvData.Columns.Add("T3", "T3");
            dgvData.Columns.Add("Cod_Fabricante", "Cód. Fabricante");
            dgvData.Columns.Add("Fabricante", "Fabricante");
            dgvData.toDefault();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        /**Component events **/
        private void InputTimer_Tick(object sender, EventArgs e)
        {
            // Desativa o Timer
            inputTimer.Stop();

            // Executa o método que você deseja chamar após a digitação
            dgvData.Invoke((MethodInvoker)delegate
            {
                contador = 0;
                lastItem = 0;
                if (dgvData.RowCount > 0)
                {
                    dgvData.Rows.Clear();
                }
                searchData(dgvData);
            });
        }
        private void searchDataEvent_TextChanged(object sender, EventArgs e)
        {
            contador = 0;
            lastItem = 0;
            if (dgvData.RowCount > 0)
            {
                dgvData.Rows.Clear();
            }
            searchData(dgvData);
            
        }
        private void delayedSearchDataEvent_TextChanged(object sender, EventArgs e)
        {
            // Inicia o Timer se ele não estiver ativo
            if (!inputTimer.Enabled)
            {
                inputTimer.Start();
            }
            else if (string.IsNullOrEmpty(txtProdutoGenerico.Text))
            {
                contador = 0;
                lastItem = 0;
                if (dgvData.RowCount > 0)
                {
                    dgvData.Rows.Clear();
                }
                searchData(dgvData);
                
            }

        }        
        private void txtDescricaoProduto_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarProduto frmConsultarProduto = new frmConsultarProduto();
            frmConsultarProduto.ShowDialog();
            txtCodProduto.Text = frmConsultarProduto.extendedCode;
        }
        private void txtDescricaoFabricante_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarFabricante frmConsultarFabricante = new frmConsultarFabricante();
            frmConsultarFabricante.ShowDialog();
            txtCodFabricante.Text = frmConsultarFabricante.extendedCode;
        }
        private void txtCodProduto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDescricaoProduto.Text = Produtos_Externos.getDescripionByCode(txtCodProduto.Text);
            }
            catch (Exception)
            {

            }
        }
        private void txtCodFabricante_TextChanged(object sender, EventArgs e)
        {
            txtDescricaoFabricante.Text = Fabricantes_Externos.getDescripionByCode(txtCodFabricante.Text);
        }

        /** DataGridView events**/
        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            frmConsultaDePrecos_Lotes frmPrecificacao_Lotes = new frmConsultaDePrecos_Lotes();
            frmPrecificacao_Lotes.produto = Produtos_Externos.getProductByCode(dgvData.CurrentRow.Cells[0].Value.ToString());
            frmPrecificacao_Lotes.Show();
        }
        private async void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.CurrentRow != null) 
                {
                    var select = await Precificacao.getInformacoesAdicionaisAsync(dgvData.CurrentRow.Cells["Cod_Produto"].Value.ToString());
                    var produto = Produtos_Externos.getProductByCode(dgvData.CurrentRow.Cells["Cod_Produto"].Value.ToString());
                    
                    txtLocalizacao.Text = 
                        (!string.IsNullOrEmpty(select.Item1)
                        ?select.Item1
                        : string.Empty
                        )
                        ;
                    txtTipo.Text = 
                        (!string.IsNullOrEmpty(select.Item2) 
                        ? select.Item2 
                        : string.Empty);
                    txtUltimaEntrada.Text =
                    (!string.IsNullOrEmpty(produto.prcUltimaEntrada) ?
                    Convert.ToDouble(produto.prcUltimaEntrada).ToString("C")
                    : string.Empty);
                    txtVencimento.Text = (!string.IsNullOrEmpty(produto.Vencimento) 
                    ? Convert.ToDateTime(produto.Vencimento).ToString("dd/MM/yyyy") 
                    : string.Empty);
                    
                }
            }
            catch
            {

            }
            
            try
            {
                // Obtém a linha selecionada do DataGridView
                DataGridViewRow selectedRow = dgvData.CurrentRow;
                // Obtém a informação que você deseja copiar
                string info = selectedRow.Cells["Cod_EAN"].Value.ToString();
                // Copia a informação para a área de transferência
                Clipboard.SetText(info);
            }
            catch (Exception)
            {
                Clipboard.SetText(" ");
            }
        }
        private void btnUltimasVendas_Click(object sender, EventArgs e)
        {
            //frmConsultaDePrecos_DetalhamentoProduto frmPrecificacao_DetalhamentoProduto = new frmConsultaDePrecos_DetalhamentoProduto();
            //frmPrecificacao_DetalhamentoProduto.produto = Produtos_Externos.getProductByCode(dgvData.CurrentRow.Cells[0].Value.ToString());
            //frmPrecificacao_DetalhamentoProduto.Show();

            frmConsultaDeprecos_NewDetalhamentoProduto frmConsultaDeprecos_NewDetalhamentoProduto = new frmConsultaDeprecos_NewDetalhamentoProduto();
            frmConsultaDeprecos_NewDetalhamentoProduto.product = Produtos_Externos.getProductByCode(dgvData.CurrentRow.Cells[0].Value.ToString());
            frmConsultaDeprecos_NewDetalhamentoProduto.Show();
        }
        private void btnLotes_Click(object sender, EventArgs e)
        {
            frmConsultaDePrecos_Lotes frmPrecificacao_Lotes = new frmConsultaDePrecos_Lotes();
            frmPrecificacao_Lotes.produto = Produtos_Externos.getProductByCode(dgvData.CurrentRow.Cells[0].Value.ToString());
            frmPrecificacao_Lotes.Show();
        }

        /** Form Events**/
        private async void frmPrecificacao_Load(object sender, EventArgs e)
        {
            CustomTextBox.readOnlyAll(this, true);

            txtEstoque.Text = "0";
            txtCodProduto.MaxLength = 11;
            txtCodFabricante.MaxLength = 11;
            

            // Cria o ContextMenuStrip
            ContextMenuStrip menu = new ContextMenuStrip();

            // Cria o item de menu "Copiar"
            ToolStripMenuItem item1 = new ToolStripMenuItem("Verificar últimas vendas");
            ToolStripMenuItem item2 = new ToolStripMenuItem("Verificar lotes disponíveis");
            item1.Click += new EventHandler(btnUltimasVendas_Click); // define o evento de clique
            item2.Click += new EventHandler(btnLotes_Click); // define o evento de clique

            // Adiciona o item de menu ao ContextMenuStrip
            menu.Items.Add(item1);
            menu.Items.Add(item2);

            // Atribui o ContextMenuStrip ao DataGridView
            dgvData.ContextMenuStrip = menu;

            /** Configuração do Grid**/
            configureDataGridView();

            /** para teste**/
            //await Session.carregar_Dependencias();
                                           
            cancellationTokenSource = new CancellationTokenSource();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
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
                CustomTextBox.readOnlyAll(this, false);
                txtDescricaoProduto.ReadOnly = true;
                txtDescricaoFabricante.ReadOnly = true;
                txtLocalizacao.ReadOnly = true;
                txtTipo.ReadOnly = true;
                txtVencimento.ReadOnly = true;
                txtUltimaEntrada.ReadOnly = true;

                txtDescricaoProduto.TabStop = false;
                txtDescricaoFabricante.TabStop = false;                
                txtLocalizacao.TabStop = false;
                txtTipo.TabStop = false;
                txtDescricaoFabricante.TabStop = false;                
                searchData(dgvData);
                

            }

            /**Eventos de Pesquisa**/
            txtDescricaoFabricante.TextChanged += searchDataEvent_TextChanged;
            txtDescricaoProduto.TextChanged += searchDataEvent_TextChanged;
            txtProdutoGenerico.TextChanged += delayedSearchDataEvent_TextChanged;
            txtEstoque.TextChanged += searchDataEvent_TextChanged;
            chkHospitalar.CheckedChanged += searchDataEvent_TextChanged;
            chkOncologico.CheckedChanged += searchDataEvent_TextChanged;            


            try
            {
                if (cancellationTokenSource?.Token.CanBeCanceled == true)
                {

                    await DoContinuousWorkAsync(cancellationTokenSource.Token);
                }
            }
            catch (Exception)
            {

            }            
            searchData(dgvData);
            

            ///**Eventos de Pesquisa**/
            //txtDescricaoFabricante.TextChanged += searchDataEvent;
            //txtDescricaoProduto.TextChanged += searchDataEvent;
            //txtProdutoGenerico.TextChanged += searchDataEvent;
            //txtEstoque.TextChanged += searchDataEvent;
            //chkHospitalar.CheckedChanged += searchDataEvent;
            //chkOncologico.CheckedChanged += searchDataEvent;


        }        
        private void frmInformativoDeProdutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }        
        private void dgvData_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll &&
                e.NewValue + dgvData.DisplayedRowCount(false) == dgvData.RowCount)
            {
                // O scroll está na parte inferior, execute o método desejado
                searchData(dgvData);
            }

        }
    }
}

