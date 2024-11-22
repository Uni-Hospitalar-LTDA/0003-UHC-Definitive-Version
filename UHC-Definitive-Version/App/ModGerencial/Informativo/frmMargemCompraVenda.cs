using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModGerencial.Informativo
{
    public partial class frmMargemCompraVenda : CustomForm
    {
        public frmMargemCompraVenda()
        {
            InitializeComponent();
            this.defaultMaximableForm();
            this.WindowState = FormWindowState.Maximized;
            this.Load += frmInformativoProdutosVxC_Load;
            this.FormClosing += frmInformativoProdutosVxC_FormClosing;
            txtCodFabricante.JustNumbers();
            txtCodProduto.JustNumbers();
            txtCodCliente.JustNumbers();
            txtCodFabricante.KeyDown += keyDown_filtrarDados;
            txtCodProduto.KeyDown += keyDown_filtrarDados;
            txtCodCliente.KeyDown += keyDown_filtrarDados;
            txtEstado.KeyDown += keyDown_filtrarDados;
            btnPesquisar.Click += btnPesquisar_Click;
            btnFechar.toDefaultCloseButton();



        }
        //Instancia
        List<Entradas> comprasSelect = new List<Entradas>();
        List<Saidas> vendasSelect = new List<Saidas>();

        private CancellationTokenSource cancellationTokenSource;
        private class Entradas : Querys<Entradas>
        {
            public string protocolo { get; set; }
            public string codProduto { get; set; }
            public string vlrUnitario { get; set; }
            public string quantidade { get; set; }
            public string dat_Entrada { get; set; }
            public async static Task<List<Entradas>> getAllToListAsync(DateTime datInicial, DateTime datFinal)
            {
                string query = $@"SELECT 
                                    		 NF_Entrada.Protocolo                                     		
                                    		,NF_Entrada_Itens.Cod_Produto [codProduto]
                                    		,NF_Entrada_Itens.Prc_Unitario [vlrUnitario]
                                    		,NF_Entrada_Itens.Qtd_Pedido [quantidade]
                                            ,NF_Entrada.Dat_Entrada
                                    FROM [DMD].dbo.[NFECB] NF_Entrada
                                    JOIN [DMD].dbo.[NFEIT] NF_Entrada_Itens ON NF_Entrada_Itens.Protocolo = NF_Entrada.Protocolo
                                    WHERE NF_Entrada.Dat_Entrada BETWEEN '{datInicial.ToString("yyyyMMdd")}' AND '{datFinal.ToString("yyyyMMdd")}'                                      
                                    AND Status = 'F' AND Tip_NF = 'C'";
                return await getAllToList(query);
            }
        }
        private class Saidas : Querys<Saidas>
        {
            public string numNota { get; set; }
            public string codCliente { get; set; }
            public string codProduto { get; set; }
            public string vlrUnitario { get; set; }
            public string quantidade { get; set; }
            public string dat_Emissao { get; set; }
            public string estado { get; set; }
            public async static Task<List<Saidas>> getAllToListAsync(DateTime datInicial, DateTime datFinal)
            {
                string query = $@"SELECT 
                                    		 NF_Saida.Num_Nota [numNota]
                                    		,NF_Saida.Cod_Cliente [codCliente]
                                    		,NF_Saida_Itens.Cod_Produto [codProduto]
                                    		,isnull(NF_Saida_Itens.vlr_liqitem/NULLIF(NF_Saida_Itens.Qtd_Produto, 0),0) [vlrUnitario]
                                    		,NF_Saida_Itens.Qtd_Produto [quantidade]
                                            ,NF_Saida.Dat_Emissao
                                            ,NF_Saida.Estado
                                    FROM [DMD].dbo.[NFSCB] NF_Saida
                                    JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida_Itens.Num_Nota = NF_Saida.Num_Nota
                                    WHERE NF_Saida.Dat_Emissao BETWEEN '{datInicial.ToString("yyyyMMdd")}' AND '{datFinal.ToString("yyyyMMdd")}'                                                                            
                                    AND Status = 'F' AND Tip_Saida = 'V'";
                return await getAllToList(query);
            }
        }




        private async void frmInformativoProdutosVxC_Load(object sender, EventArgs e)
        {


            cbxVendas.Items.Add("Todos");
            cbxVendas.Items.Add("Público");
            cbxVendas.Items.Add("Privado");
            cbxVendas.SelectedItem = "Todos";
            txtCodProduto.MaxLength = 11;
            txtCodFabricante.MaxLength = 11;
            txtCodCliente.MaxLength = 11;
            txtCodCliente.Focus();

            pcbCompras.Value = 0;
            pcbVendas.Value = 0;
            pcbCompras.Maximum = 100;
            pcbVendas.Maximum = 100;


            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            dtpInicial.Value = firstDayOfMonth;
            dtpFinal.Value = lastDayOfMonth;
            //dtpInicial.Value = Convert.ToDateTime("01/01/2022");
            //dtpFinal.Value = Convert.ToDateTime("31/12/2022");

            configureGridVendas();
            configureGridCompras();
            ConfigureEvents();

            cancellationTokenSource = new CancellationTokenSource();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CustomTextBox.readOnlyAll(this, true);
                if (cancellationTokenSource?.Token.CanBeCanceled == true)
                {
                    await DoFirstWorkAsync(cancellationTokenSource.Token);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
                CustomTextBox.readOnlyAll(this, false);
                txtQtdTotalCompras.ReadOnly = true;
                txtQtdTotalVendas.ReadOnly = true;
                txtVlrTotalCompras.ReadOnly = true;
                txtVlrTotalVendas.ReadOnly = true;
                txtTotalCompras.ReadOnly = true;
                txtTotalVendas.ReadOnly = true;
                txtMargem.ReadOnly = true;
                txtMediaCompra.ReadOnly = true;
                txtMediaVenda.ReadOnly = true;
                txtDescricaoCliente.ReadOnly = true;
                txtDescricaoProduto.ReadOnly = true;
                txtDescricaoFabricante.ReadOnly = true;


                txtQtdTotalCompras.TabStop = false;
                txtQtdTotalVendas.TabStop = false;
                txtVlrTotalCompras.TabStop = false;
                txtVlrTotalVendas.TabStop = false;
                txtTotalCompras.TabStop = false;
                txtTotalVendas.TabStop = false;
                txtMargem.TabStop = false;
                txtMediaCompra.TabStop = false;
                txtMediaVenda.TabStop = false;
                txtDescricaoCliente.TabStop = false;
                txtDescricaoProduto.TabStop = false;
                txtDescricaoFabricante.TabStop = false;
                this.Cursor = Cursors.Default;
            }


        }

        private void configureGridVendas()

        {
            dgvVendas.Columns.Add("codProduto", "Cód. Produto");
            dgvVendas.Columns.Add("descProduto", "Produto");
            dgvVendas.Columns.Add("quantidade", "Qtd. Compras");
            dgvVendas.Columns.Add("codProduto", "Vlr. Compras");
            dgvVendas.Columns.Add("totVenda", "Total Compras");
            dgvVendas.toDefault();
        }
        private void configureGridCompras()
        {
            dgvCompras.Columns.Add("codProduto", "Cód. Produto");
            dgvCompras.Columns.Add("descProduto", "Produto");
            dgvCompras.Columns.Add("quantidade", "Qtd. Vendas");
            dgvCompras.Columns.Add("codProduto", "Vlr. Vendas");
            dgvCompras.Columns.Add("totVenda", "Total Vendas");
            dgvCompras.toDefault();
        }

        private void frmInformativoProdutosVxC_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }



        /** Tasks **/
        private async Task DoFirstWorkAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Cursor = Cursors.WaitCursor;
                });

                Task t1 = Produtos_Externos.carregarAsync();
                Task t2 = Clientes_Externos.carregarAsync();
                Task t3 = Fabricantes_Externos.carregarAsync();
                await Task.WhenAll(t1, t2, t3);
                this.Invoke((MethodInvoker)delegate
                {
                    this.Cursor = Cursors.Default;
                });
            }
        }
        private async Task DoWorkFilterAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Cursor = Cursors.WaitCursor;
                });

                await filtrarDadosEntrada();
                await filtrarDadosSaida();

                this.Invoke((MethodInvoker)delegate
                {
                    this.Cursor = Cursors.Default;
                });
            }

        }
        private void keyDown_filtrarDados(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPesquisar_Click(sender, e);
            }
        }
        private async void filtrarDados(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (dgvVendas.Rows.Count > 0)
                dgvVendas.Rows.Clear();

            if (dgvCompras.Rows.Count > 0)
                dgvCompras.Rows.Clear();
            cancellationTokenSource = new CancellationTokenSource();
            try
            {

                if (cancellationTokenSource?.Token.CanBeCanceled == true)
                {
                    await DoWorkFilterAsync(cancellationTokenSource.Token);
                }
            }
            catch (Exception)
            {

            }
            finally
            {

            }

            txtMargem.Text = calculoMargem(txtMediaVenda.Text, txtMediaCompra.Text);
            this.Cursor = Cursors.Default;
        }
        private async Task filtrarDadosSaida()
        {

            pcbVendas.Invoke((MethodInvoker)delegate { pcbVendas.Value = 0; });
            string descricaoProduto = txtDescricaoProduto.Text;
            string descricaoFabricante = txtDescricaoFabricante.Text;
            string descricaoCliente = txtDescricaoCliente.Text.ToUpper();
            string vendas = cbxVendas.SelectedItem.ToString();
            string[] estados = txtEstado.Text.Split(',');

            int Qtd_Vendas = 0;
            double Vlr_Vendas = 0;
            double Tot_Vendas = 0;


            foreach (var estado in estados)
            {
                pcbVendas.Invoke((MethodInvoker)delegate { pcbVendas.Value = 10; });
                vendasSelect = await Saidas.getAllToListAsync(dtpInicial.Value, dtpFinal.Value);
                var select = from venda in vendasSelect
                             join produto in Produtos_Externos.produtos on venda.codProduto equals produto.codigo
                             join fabricante in Fabricantes_Externos.fabricantes on produto.Cod_Fabricante equals fabricante.codigo
                             join cliente in Clientes_Externos.clientes on venda.codCliente equals cliente.codigo
                             where
                                    (produto.descricao.Contains(descricaoProduto))
                                 && (fabricante.Fantasia.Contains(descricaoFabricante))
                                 && (cliente.razao_social.Contains(descricaoCliente))
                                 && (Convert.ToDateTime(venda.dat_Emissao) >= dtpInicial.Value && Convert.ToDateTime(venda.dat_Emissao) <= dtpFinal.Value)
                             && (
                                    cliente.grupo_Cliente.Equals(vendas)
                                    || (vendas.Equals("Todos"))
                                    )
                                    && (venda.estado.Equals(estado.ToUpper()) || string.IsNullOrEmpty(estado))
                             select new { Venda = venda, Produto = produto };

                dgvVendas.SuspendLayout();

                pcbVendas.Invoke((MethodInvoker)delegate { pcbVendas.Value = 50; });


                double pcbTotal = (Convert.ToDouble(50 / estados.Count()) / Convert.ToDouble(select.Count()));
                double count = 0;

                foreach (var linha in select)
                {

                    double produto = Convert.ToDouble(linha.Venda.quantidade) * Convert.ToDouble(linha.Venda.vlrUnitario);
                    dgvVendas.Rows.Add(linha.Venda.codProduto
                        , linha.Produto.descricao
                        , Convert.ToInt32(linha.Venda.quantidade).ToString("N0")
                        , Convert.ToDouble(linha.Venda.vlrUnitario).ToString("C")
                        , produto.ToString("C"));
                    Qtd_Vendas += Convert.ToInt32(linha.Venda.quantidade);
                    Vlr_Vendas += Convert.ToDouble(linha.Venda.vlrUnitario);
                    Tot_Vendas += produto;

                    count = pcbTotal + count;


                    //MessageBox.Show(count.ToString());
                    if (count > 1)
                    {
                        count = 0;
                        pcbVendas.Invoke((MethodInvoker)delegate { pcbVendas.Value += 1; });
                    };

                }
            }
            txtQtdTotalVendas.Text = Qtd_Vendas.ToString("N0");
            txtVlrTotalVendas.Text = Vlr_Vendas.ToString("C");
            txtTotalVendas.Text = Tot_Vendas.ToString("C");
            txtMediaVenda.Text = (Tot_Vendas / Qtd_Vendas).ToString("C");
            dgvVendas.ResumeLayout();
            dgvVendas.AutoResizeColumns();
            pcbVendas.Invoke((MethodInvoker)delegate { pcbVendas.Value = 100; });
        }
        private async Task filtrarDadosEntrada()
        {
            pcbCompras.Invoke((MethodInvoker)delegate { pcbCompras.Value = 0; });
            string descricaoProduto = txtDescricaoProduto.Text;
            string descricaoFabricante = txtDescricaoFabricante.Text;
            pcbCompras.Invoke((MethodInvoker)delegate { pcbCompras.Value = 10; });

            comprasSelect = await Entradas.getAllToListAsync(dtpInicial.Value, dtpFinal.Value);

            var select = from compra in comprasSelect
                         join produto in Produtos_Externos.produtos on compra.codProduto equals produto.codigo
                         join fabricante in Fabricantes_Externos.fabricantes on produto.Cod_Fabricante equals fabricante.codigo
                         where
                                (produto.descricao.Contains(descricaoProduto))
                             && (fabricante.Fantasia.Contains(descricaoFabricante))
                             && (Convert.ToDateTime(compra.dat_Entrada) >= dtpInicial.Value && Convert.ToDateTime(compra.dat_Entrada) <= dtpFinal.Value)
                         select new { Compra = compra, Produto = produto };

            dgvCompras.SuspendLayout();

            int Qtd_Compras = 0;
            double Vlr_Compras = 0;
            double Tot_Compras = 0;
            double pcbTotal = (Convert.ToDouble(50) / Convert.ToDouble(select.Count()));
            double count = 0;
            foreach (var linha in select)
            {
                double produto = Convert.ToDouble(linha.Compra.quantidade) * Convert.ToDouble(linha.Compra.vlrUnitario);
                dgvCompras.Rows.Add(linha.Compra.codProduto
                    , linha.Produto.descricao
                    , Convert.ToInt32(linha.Compra.quantidade).ToString("N0")
                    , Convert.ToDouble(linha.Compra.vlrUnitario).ToString("C")
                    , produto.ToString("C"));
                Qtd_Compras += Convert.ToInt32(linha.Compra.quantidade);
                Vlr_Compras += Convert.ToDouble(linha.Compra.vlrUnitario);
                Tot_Compras += produto;
                count = pcbTotal + count;


                if (count > 1)
                {
                    count = 0;
                    pcbCompras.Invoke((MethodInvoker)delegate { pcbCompras.Value += 1; });
                }
            }
            //Tot_Vendas = Qtd_Vendas * Vlr_Vendas;

            txtQtdTotalCompras.Text = Qtd_Compras.ToString("N0");
            txtVlrTotalCompras.Text = Vlr_Compras.ToString("C");
            txtTotalCompras.Text = Tot_Compras.ToString("C");
            txtMediaCompra.Text = (Tot_Compras / Qtd_Compras).ToString("C");

            dgvCompras.ResumeLayout();
            dgvCompras.AutoResizeColumns();
            pcbCompras.Invoke((MethodInvoker)delegate { pcbCompras.Value = 100; });
        }

        private string calculoMargem(string vendas, string compras)
        {
            double v = Convert.ToDouble(vendas.Replace("R$", ""));
            double c = Convert.ToDouble(compras.Replace("R$", ""));
            //MessageBox.Show((v/c).ToString());
            //MessageBox.Show(((v/c)-100).ToString());
            return ((v / c) - 1).ToString("P");
        }

        /** Events **/

        private void ConfigureEvents()
        {
            txtCodProduto.TextChanged += txtCodProduto_TextChanged;
            txtCodCliente.TextChanged += txtCodCliente_TextChanged;
            txtCodFabricante.TextChanged += txtCodFabricante_TextChanged;
            txtDescricaoProduto.DoubleClick += txtDescricaoProduto_DoubleClick;
            txtDescricaoCliente.DoubleClick += txtDescricaoCliente_DoubleClick;
            txtDescricaoFabricante.DoubleClick += txtDescricaoFabricante_DoubleClick;
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
        private void txtDescricaoProduto_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarProduto frmConsultarProduto = new frmConsultarProduto();
            frmConsultarProduto.ShowDialog();
            txtCodProduto.Text = frmConsultarProduto.extendedCode;
        }
        private void txtDescricaoCliente_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            txtCodCliente.Text = frmConsultarCliente.extendedCode;
        }
        private void txtDescricaoFabricante_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarFabricante frmConsultarFabricante = new frmConsultarFabricante();
            frmConsultarFabricante.ShowDialog();
            txtCodFabricante.Text = frmConsultarFabricante.extendedCode;
        }

        /** Buttons **/
        private void btnPesquisar_Click(object sender, EventArgs e)
        {

            filtrarDados(sender, e);

        }

    }
}
