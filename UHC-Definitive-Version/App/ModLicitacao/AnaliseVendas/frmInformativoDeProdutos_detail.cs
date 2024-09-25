using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModLicitacao.AnaliseVendas
{
    public partial class frmInformativoDeProdutos_detail : CustomForm
    {
        public frmInformativoDeProdutos_detail()
        {
            InitializeComponent();
            this.defaultFixedForm();
            this.FormClosing += frmInformativoDeProdutos_FormClosing;
            btnFechar.toDefaultCloseButton();
            ConfigureFormEvents();

        }

        /** Instância **/
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

            public async static Task<List<Produtos_UltimasVendas>> getUltimasVendasByCode(string code)
            {
                string query = $@"SELECT distinct
                                	     NF_Saida_itens.Cod_Produto 
                                        ,NF_Saida_Itens.Prc_Unitario 
                                        ,NF_Saida_Itens.Qtd_Produto
										,NF_Saida.Num_Nota
                                		,NF_Saida.Dat_Emissao 
                                		,NF_Saida.Cod_Cliente		
                                FROM [DMD].dbo.[NFSIT] NF_Saida_Itens 
                                JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
                                AND NF_Saida.STATUS = 'F' AND Tip_Saida = 'V'
                                AND Cod_Produto = {code}
                                ORDER BY Dat_Emissao DESC";

                return await getAllToList(query);
            }
        }


        /**Tasks**/
        private async Task carregarDadosAsync()
        {
            dgvLotes.DataSource = await Produtos_Externos.getLotesByCodeAsync(produto.codigo);
            ultimasVendas = await Produtos_UltimasVendas.getUltimasVendasByCode(produto.codigo);
        }

        private async Task DoWorkAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                await carregarDadosAsync();
            }
        }

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
                         (cliente.razao_social.Contains(txtDescricaoCliente.Text.ToUpper())
                         && (
                                (cliente.grupo_Cliente == cbxEsfera.SelectedItem.ToString())
                            || (cbxEsfera.SelectedItem.ToString() == "Todos"))
                         )



                         select new { vendas, cliente };

            foreach (var linha in select)
            {
                dgvHistorico.Rows.Add(
                     Convert.ToDouble(linha.vendas.Prc_Unitario).ToString("C")
                    , Convert.ToDateTime(linha.vendas.Dat_Emissao).ToString("dd/MM/yyyy")
                    , linha.cliente.codigo
                    , linha.cliente.razao_social
                    , linha.cliente.grupo_Cliente
                    , linha.vendas.Qtd_Produto
                    , linha.vendas.num_nota
                    );
                media += Convert.ToDouble(linha.vendas.Prc_Unitario);
            }
            dgvHistorico.AutoResizeColumns();
            txtMediaPreco.Text = (media / dgvHistorico.RowCount).ToString("C");
        }

        public void filtrarDadosEvent(object sender, EventArgs e)
        {
            filtrarDados();
        }

        /** Form events**/
        private void ConfigureFormEvents()
        {
            this.Load += frmInformativoDeProdutos_detail_Load;
        }
        private async void frmInformativoDeProdutos_detail_Load(object sender, EventArgs e)
        {
            /** Parâmetros iniciais **/

            configurarGrid();
            txtCodProduto.Text = produto.codigo;
            txtDescricaoProduto.Text = produto.descricao;
            txtPrcUltimaEntrada.Text = Convert.ToDouble(produto.prcUltimaEntrada).ToString("C");
            cbxEsfera.Items.Add("Todos");
            cbxEsfera.SelectedItem = "Todos";
            cbxEsfera.Items.Add("Público");
            cbxEsfera.Items.Add("Privado");

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


                txtPrcUltimaEntrada.ReadOnly = true;
                txtMediaPreco.ReadOnly = true;
                txtDescricaoProduto.ReadOnly = true;
                txtCodProduto.ReadOnly = true;
                txtDescricaoCliente.ReadOnly = true;

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

                txtDescricaoCliente.TextChanged += filtrarDadosEvent;
                cbxEsfera.TextChanged += filtrarDadosEvent;
            }


            filtrarDados();

            ConfigureTextBoxEvents();
            this.Cursor = Cursors.Default;
        }
        private void frmInformativoDeProdutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
        
        /** Textbox Configuration  **/
        private void ConfigureTextBoxEvents()
        {
            txtCodCliente.TextChanged += txtCodCliente_TextChanged;
            txtDescricaoCliente.DoubleClick += txtDescricaoCliente_DoubleClick;
        }
        private void txtCodCliente_TextChanged(object sender, EventArgs e)
        {
            txtDescricaoCliente.Text = Clientes_Externos.getDescripionByCode(txtCodCliente.Text);
        }
        private void txtDescricaoCliente_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            txtCodCliente.Text = frmConsultarCliente.extendedCode;
        }
    }
}
