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
//using static _2022._12_UHC_3.App.ModLicitacao.Informativo.frmInformativoDeProdutos_detail;

namespace UHC3_Definitive_Version.App.ModVendas.Precificacao
{
    public partial class frmConsultaDePrecos_DetalhamentoProduto : CustomForm
    {
        public frmConsultaDePrecos_DetalhamentoProduto()
        {
            InitializeComponent();
            this.defaultFixedForm();
            btnFechar.toDefaultCloseButton();

            this.Load += frmPreficicacao_DetalhamentoProduto_Load;
            this.FormClosing += frmInformativoDeProdutos_FormClosing;

            txtCliente.DoubleClick += txtDescricaoCliente_DoubleClick;
            txtCodigo.TextChanged += txtCodCliente_TextChanged;
            
        }

        /**Instância**/
        internal Produtos_Externos produto { get; set; }
        List<Produtos_UltimasVendas> ultimasVendas = new List<Produtos_UltimasVendas>();
        private CancellationTokenSource cancellationTokenSource;
        internal class Produtos_UltimasVendas : Querys<Produtos_UltimasVendas>
        {
            public string Prc_Unitario { get; set; }
            public string Cod_Produto { get; set; }
            public string Dat_Emissao { get; set; }
            public string Cod_Cliente { get; set; }
            public string num_nota { get; set; }
            public string Qtd_Produto { get; set; }

            public async static Task<List<Produtos_UltimasVendas>> getUltimasVendasByCode(string code, string cod_cliente, int contLinhas = 40)
            {
                string customerFilter = null;
                if (!string.IsNullOrEmpty(cod_cliente))
                {
                    contLinhas = 999;
                    customerFilter = $"AND Cliente.Codigo = {cod_cliente}";
                }
                string query = $@"SELECT top {contLinhas}
                                	     NF_Saida_itens.Cod_Produto 
                                        ,NF_Saida_Itens.Prc_Unitario 
                                        ,NF_Saida_Itens.Qtd_Produto
										,NF_Saida.Num_Nota
                                		,NF_Saida.Dat_Emissao 
                                		,NF_Saida.Cod_Cliente		
                                FROM [DMD].dbo.[NFSCB] NF_Saida
                                JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente
                                JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens  ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
                                AND NF_Saida.STATUS = 'F' AND Tip_Saida = 'V'
                                AND Tipo_Consumidor IN ('F','N')
                                AND Cod_Produto =  {code}    
                                {customerFilter}
                                ORDER BY Dat_Emissao DESC";
                
                return await getAllToList(query);
            }          
        }

        /**Tasks**/
        private async Task carregarDadosAsync()
        {
            string codigoCliente = (string.IsNullOrEmpty(txtCliente.Text) ? null : txtCliente.Text);
            ultimasVendas = await Produtos_UltimasVendas.getUltimasVendasByCode(produto.codigo, codigoCliente);
            //dgvHistorico.DataSource = await Produtos_UltimasVendas.getAllToDataTableAsync(produto.codigo);
        }
        private async Task DoWorkAsync(CancellationToken token)
        {
            try
            {
                if (!token.IsCancellationRequested)
                {
                    await carregarDadosAsync();
                }
            }
            catch
            {

            }
        }

        /** Métodos internos**/
        private void configurarGrid()
        {            
                dgvHistorico.Columns.Add("prcVenda", "Prc. Venda");
                dgvHistorico.Columns.Add("datEmissao", "Dat. Emissão");
                dgvHistorico.Columns.Add("codCliente", "Cód. Cliente");
                dgvHistorico.Columns.Add("descCliente", "Cliente");
                dgvHistorico.Columns.Add("grpCliente", "Grupo de Cliente");
                dgvHistorico.Columns.Add("qtdProduto", "Quantidade Produto");
                dgvHistorico.Columns.Add("numNota", "Numero Nota");            
        }
        private void filtrarDados()
        {
            double media = 0;
            if (dgvHistorico.Rows.Count > 0)
                dgvHistorico.Rows.Clear();
            var select = from vendas in ultimasVendas
                         join cliente in Clientes_Externos.clientes
                                      on vendas.Cod_Cliente equals cliente.codigo
                         where
                         (cliente.razao_social.Contains(txtCliente.Text.ToUpper())
                         && 
                                (cliente.esfera_Cliente.Contains("Privado")))                         
                         select new { vendas, cliente };

            if (dgvHistorico.Columns.Count == 0)
            {
                configurarGrid();
            }
                foreach (var linha in select)
                {
                    dgvHistorico.Rows.Add(
                         Convert.ToDouble(linha.vendas.Prc_Unitario).ToString("C")
                        , Convert.ToDateTime(linha.vendas.Dat_Emissao)
                        , Convert.ToInt32(linha.cliente.codigo)
                        , linha.cliente.razao_social
                        , linha.cliente.grupo_Cliente
                        , Convert.ToInt32(linha.vendas.Qtd_Produto)
                        , Convert.ToInt32(linha.vendas.num_nota)
                        );
                    media += Convert.ToDouble(linha.vendas.Prc_Unitario);
                
                dgvHistorico.AutoResizeColumns();
                dgvHistorico.Columns["datEmissao"].DefaultCellStyle.Format = "dd/MM/yyy";
                //txtMediaPreco.Text = (media / dgvHistorico.RowCount).ToString("C");
            }
        }


        /** Events **/
        public void filtrarDadosEvent(object sender, EventArgs e)
        {
            filtrarDados();
        }        
        private void txtCodCliente_TextChanged(object sender, EventArgs e)
        {
            txtCliente.Text = Clientes_Externos.getDescripionByCode(txtCodigo.Text);
        }
        private async void txtCliente_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;   
            string codigoCliente = (string.IsNullOrEmpty(txtCliente.Text) ? null : txtCliente.Text);
            ultimasVendas = await Produtos_UltimasVendas.getUltimasVendasByCode(produto.codigo, codigoCliente);
            this.Cursor = Cursors.Default;
        }
        private void txtDescricaoCliente_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            txtCodigo.Text = frmConsultarCliente.extendedCode;
        }

        /** Form events **/
        private async void frmPreficicacao_DetalhamentoProduto_Load(object sender, EventArgs e)
        {
            configurarGrid();
            lblProduto.Text = produto.codigo +" "+ produto.descricao;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CustomTextBox.readOnlyAll(this, true);
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
                CustomTextBox.readOnlyAll(this, false);


                //txtMediaPreco.ReadOnly = true;
                txtCliente.ReadOnly = true;                
                txtCliente.TabStop = false;

                foreach (var control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;
                        if (textBox.ReadOnly)
                        {
                            textBox.TabStop = false;
                        }
                    }
                }

                txtCliente.TextChanged += filtrarDadosEvent;                
            }
            filtrarDados();
            this.Cursor = Cursors.Default;
        }
        private void frmInformativoDeProdutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
        private async void dgvHistorico_Scroll(object sender, ScrollEventArgs e)
        {

            int oldScrollPos = dgvHistorico.FirstDisplayedScrollingRowIndex;

            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll &&
                e.NewValue + dgvHistorico.DisplayedRowCount(false) == dgvHistorico.RowCount)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string codigoCliente = (string.IsNullOrEmpty(txtCliente.Text) ? null : txtCliente.Text);
                    ultimasVendas = await Produtos_UltimasVendas.getUltimasVendasByCode(produto.codigo, codigoCliente,dgvHistorico.Rows.Count + 5);
                    filtrarDados();
                    dgvHistorico.FirstDisplayedScrollingRowIndex = oldScrollPos;
                    dgvHistorico.Rows[oldScrollPos].Selected = true;
                    this.Cursor = Cursors.Default;
                }
                catch
                {

                }
            }
            
            

        }
    }
}