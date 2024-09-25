using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModLicitacao.AnaliseVendas
{
    public partial class frmInformativoDeProdutos : CustomForm
    {


        public frmInformativoDeProdutos()
        {

            InitializeComponent();
            this.defaultMaximableForm();
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Maximized;

            txtCodFabricante.JustNumbers();
            txtCodProduto.JustNumbers();
            txtEstoque.JustNumbers();
            btnFechar.toDefaultCloseButton();
            this.Load += frmInformativoDeProdutos_Load;
        }
        
        /** Instância **/
        private CancellationTokenSource cancellationTokenSource;
        int pagina = 1;
        int paginas = 1;
        int itens = 1;
        int interval = 150000;

        //Lista que receberá os dados oriundos da classe ScreenProducts
        List<ScreenProducts> screenProducts = new List<ScreenProducts>();
        //Classe feita para poupar recursos de banco de dados e processar a informação na máquina, guardando algumas informações na memória da aplicação.
        internal class ScreenProducts : Querys<ScreenProducts>
        {
            public string Cod_Produto { get; set; }
            public string Cod_Fabricante { get; set; }
            public string Vendas_Publico { get; set; }
            public string Vendas_Privado { get; set; }
            public static async Task<List<ScreenProducts>> getAllToListAsync()
            {
                string query = @"SELECT 
                                     Produto.Codigo			[Cod_Produto]  
                                    ,Produto.Cod_Fabricante	[Cod_Fabricante]  
                                    ,[Vendas_Publico] = IIF(isnull(count(Cliente_Publico.Codigo),0) > 0, 'Sim','Não') 								
                                    ,[Vendas_Privado] = IIF(isnull(count(Cliente_Privado.Codigo),0) > 0, 'Sim','Não')
                                    FROM [DMD].dbo.[PRODU] Produto 
                                    LEFT JOIN  [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida_Itens.Cod_Produto = Produto.Codigo
                                    LEFT JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_nota = NF_Saida_Itens.Num_Nota 
                                    LEFT JOIN [DMD].dbo.[CLIEN] Cliente_Publico ON (Cliente_Publico.Codigo = NF_Saida.Cod_Cliente AND Cliente_Publico.Tipo_Consumidor IN ('P','M','E'))
                                    LEFT JOIN [DMD].dbo.[CLIEN] Cliente_Privado ON (Cliente_Privado.Codigo = NF_Saida.Cod_Cliente AND Cliente_Privado.Tipo_Consumidor IN ('F','N'))
                                    WHERE Produto.Tipo = 'R' 
                                    AND (YEAR(Produto.Dat_Cadastro) > YEAR(GETDATE())-3 OR NF_Saida.Dat_Emissao IS NOT NULL)
                                    GROUP BY
                                      Produto.Codigo		
                                     ,Produto.Cod_Fabricante                                    
                                    ORDER BY Produto.Codigo";
                return await getAllToList(query);
            }
        }

        /** Tasks **/
        //Configure o datagridview com layout  exibição
        private void configureDgv(DataGridView dataGridView)
        {

            if (dataGridView.Columns.Count == 0)
            {
                dataGridView.toDefault();
                dataGridView.Columns.Add("Cod_produto", "Cód. Produto");
                dataGridView.Columns.Add("Des_produto", "Produto");
                dataGridView.Columns.Add("Ean_Produto", "Cód. EAN");
                dataGridView.Columns.Add("QtdEstoque_Produto", "Estoque");
                dataGridView.Columns.Add("NmGenerico_Produto", "Nome Genérico");
                dataGridView.Columns.Add("Des_Fabricante", "Fabricante");
                dataGridView.Columns.Add("Tipo_Produto", "Tipo do Medicamente");
                dataGridView.Columns.Add("VenPubl_Produto", "Vendas para o Público?");
                dataGridView.Columns.Add("VenPriv_Produto", "Vendas para o Privado?");
            }

        }
        //Carrega todas as tarefas de dados (Funcionará em um timer de 1 em 1 minuto
        private async Task carregarScreenProducts()
        {
            screenProducts = await ScreenProducts.getAllToListAsync();
        }
        private async Task carregarDepedenciasTela()
        {
            try
            {
                var tasks = new List<Task>();
                tasks.Add(Section.carregar_Dependencias());
                tasks.Add(carregarScreenProducts());
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);

            }

        }
        private async Task DoWorkAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Cursor = Cursors.WaitCursor;
                });

                await carregarDepedenciasTela();
                lblLastUpdate.Invoke((MethodInvoker)delegate
                {
                    lblLastUpdate.Text = $"Última atualização: {DateTime.Now.ToLongTimeString()}, próximo update: {DateTime.Now.AddMilliseconds(interval).ToLongTimeString()}";
                });

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
                await carregarDepedenciasTela();

                await Task.Delay(interval, token);
                lblLastUpdate.Invoke((MethodInvoker)delegate
                {
                    lblLastUpdate.Text = $"Última atualização: {DateTime.Now.ToLongTimeString()}, próximo update: {DateTime.Now.AddMilliseconds(interval).ToLongTimeString()}";
                });
            }
        }
        //Filtro majoritário, será por LINQ visando performance, todo o processamento fica às custas do C# e da máquina local
        private void searchData(DataGridView dataGridView, int pagina)
        {
            this.Cursor = Cursors.WaitCursor;
            string descricaoProduto = txtDescricaoProduto.Text;
            string descricaoFabricante = txtDescricaoFabricante.Text;
            string descricaoProdutoGenerico = txtProdutoGenerico.Text.ToUpper();
            string estoque = txtEstoque.Text;

            bool oncologico = chkOncologico.Checked;
            bool hospitalar = chkHospitalar.Checked;

            string vendas = cbxVendas.SelectedItem.ToString();

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
                         && (
                                (vendas.Equals("Público") && screenProduto.Vendas_Publico == "Sim")
                                || (vendas.Equals("Privado") && screenProduto.Vendas_Privado == "Sim")
                                || (vendas.Equals("Todos"))
                                )
                         select new { ProdutoTela = screenProduto, Produto = produto, Fabricante = fabricante };

            dataGridView.SuspendLayout();
            dataGridView.Rows.Clear();

            if (dataGridView.RowCount > 0)
            {
                dataGridView.Rows.Clear();
            }

            int x = 0;
            itens = select.Count();

            if ((Convert.ToDouble(itens) / 50) % 2 != 0)
            {

                paginas = (itens / 50) + 1;
            }
            else
                paginas = itens / 50;

            lblPaginas.Text = $"Páginas: ({pagina}/{paginas})";


            foreach (var produto in select)
            {

                if ((50 * (pagina - 1)) <= x && x < (50 * pagina))
                {

                    dataGridView.Rows.Add(produto.Produto.codigo, produto.Produto.descricao, produto.Produto.cod_EAN
                                    , produto.Produto.Qtd_Disponivel, produto.Produto.Des_NomGen, produto.Fabricante.Fantasia
                                    , produto.Produto.Tipo, produto.ProdutoTela.Vendas_Publico, produto.ProdutoTela.Vendas_Privado);
                }
                x++;
            }
            dataGridView.AutoResizeColumns();
            dataGridView.ResumeLayout();


            if (dataGridView.Rows.Count > 0)
            {
                dataGridView.Rows[0].Selected = true;
                lblItemSelecionado.Text = $"Item selecionado: ({(0 + 1) + ((pagina - 1) * 50)}/{itens})";
            }
            else
            {
                lblItemSelecionado.Text = $"Item selecionado: (0/0)";
                lblPaginas.Text = $"Páginas: (0/0)";
            }
            this.Cursor = Cursors.Default;

        }

        /**Load do Form **/
        private async void frmInformativoDeProdutos_Load(object sender, EventArgs e)
        {
            cbxVendas.Items.Add("Todos");
            cbxVendas.Items.Add("Público");
            cbxVendas.Items.Add("Privado");
            cbxVendas.SelectedItem = "Todos";
            txtEstoque.Text = "0";
            txtCodProduto.MaxLength = 11;
            txtCodFabricante.MaxLength = 11;
            btnPrevious.Enabled = false;

            cancellationTokenSource = new CancellationTokenSource();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CustomTextBox.readOnlyAll(this, true);
                if (cancellationTokenSource?.Token.CanBeCanceled == true)
                {
                    lblLastUpdate.Text = "Atualizando...";
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
                txtDescricaoProduto.TabStop = false;
                txtDescricaoFabricante.TabStop = false;
                configureDgv(dgvData);
                searchData(dgvData, 1);

            }

            /**Eventos de Pesquisa**/
            txtDescricaoFabricante.TextChanged += searchDataEvent;
            txtDescricaoProduto.TextChanged += searchDataEvent;
            txtProdutoGenerico.TextChanged += searchDataEvent;
            txtEstoque.TextChanged += searchDataEvent;
            chkHospitalar.CheckedChanged += searchDataEvent;
            chkOncologico.CheckedChanged += searchDataEvent;
            cbxVendas.SelectedValueChanged += searchDataEvent;
            ConfigureFormEvents();

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


        }



        //Cancelar tarefas quando o formulário estiver fechando
        private void frmInformativoDeProdutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

        /** Eventos **/
        /** Configure Form Events**/
        private void ConfigureFormEvents()
        {
            txtDescricaoProduto.DoubleClick += txtDescricaoProduto_DoubleClick;
            txtDescricaoFabricante.DoubleClick  += txtDescricaoFabricante_DoubleClick;
            txtCodProduto.TextChanged           += txtCodProduto_TextChanged;
            txtCodFabricante.TextChanged        += txtCodFabricante_TextChanged;
            dgvData.RowEnter                    += dgvData_RowEnter;
            dgvData.DoubleClick                 += dgvData_DoubleClick;
            btnNext.Click                       += btnNext_Click;
            btnPrevious.Click                   += btnPrevious_Click;
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
            txtDescricaoProduto.Text = Produtos_Externos.getDescripionByCode(txtCodProduto.Text);
        }
        private void txtCodFabricante_TextChanged(object sender, EventArgs e)
        {
            txtDescricaoFabricante.Text = Fabricantes_Externos.getDescripionByCode(txtCodFabricante.Text);
        }
        private void dgvData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView != null)
            {
                if (dataGridView.CurrentRow != null)
                {
                    lblItemSelecionado.Invoke((MethodInvoker)delegate
                    {
                        lblItemSelecionado.Text = $"Item selecionado: ({(e.RowIndex + 1) + ((pagina - 1) * 50)}/{itens})";
                    });
                }
            }

        }
        /** Evento Genérico de Pesquisa**/
        private void searchDataEvent(object sender, EventArgs e)
        {
            searchData(dgvData, 1);
            pagina = 1;
            if (paginas == pagina)
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;
            }

        }

         
        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            frmInformativoDeProdutos_detail frmInformativoDeProdutos_detail = new frmInformativoDeProdutos_detail();
            frmInformativoDeProdutos_detail.produto = Produtos_Externos.getProductByCode(dgvData.CurrentRow.Cells[0].Value.ToString());
            frmInformativoDeProdutos_detail.Show();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            pagina++;
            lblPaginas.Text = $"Página: ({pagina},{paginas})";
            searchData(dgvData, pagina);

            if (!btnPrevious.Enabled)
                btnPrevious.Enabled = true;
            if (pagina == (paginas))
                btnNext.Enabled = false;
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pagina == 2)
                btnPrevious.Enabled = false;
            if (!btnNext.Enabled)
                btnNext.Enabled = true;
            pagina--;
            lblPaginas.Text = $"Página: ({pagina},{paginas})";
            searchData(dgvData, pagina);
        }

    }
}
