using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModVendas.Consultas
{
    public partial class frmConsultarPedidoOL : CustomForm
    {
        public frmConsultarPedidoOL()
        {
            InitializeComponent();
            chkNFemitida.Checked = true;
            chkNFProblema.Checked = true;

            this.defaultMaximableForm();            
            
            btnFechar.toDefaultCloseButton();
            this.Load += frmConsultarPedidoOL_Load;


            txtCodCliente.JustNumbers();
            txtNF.JustNumbers();
            txtPedidoOL.JustNumbers();


            txtDescricaoCliente.TextChanged += pesquisar;
            chkNFemitida.CheckedChanged += pesquisar;
            chkNFProblema.CheckedChanged += pesquisar;
            txtNF.KeyDown += pesquiar_KeyDown;
            txtPedidoOL.KeyDown += pesquiar_KeyDown;

            txtCodCliente.TextChanged += txtCodCliente_TextChanged;
            txtDescricaoCliente.DoubleClick += txtDescricaoCliente_DoubleClick;


            dgvHistorico.SelectionChanged += dgvHistorico_SelectionChanged;
        }

        private async void pesquiar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                await carregarInfoAsync();
            }
        }

        internal class Consultas : Querys<Consultas>
        {
            public static async Task<DataTable> getPedidosToDataTableAsync(string razaoSocial, string numNota, string codPedOL, string flgPedido, string flgProblema)
            {
                string query = $@"SELECT
          Log_OL.Num_PedidoOL[Pedido OL]
 		,Log_OL.Dat_Entrada_PedidoOL [Dt.Entrada OL]
 		,NotaFiscal_CB.Num_Nota[NF]
 		,CONVERT(DATE,NotaFiscal_CB.Dat_Emissao) [Dt.Emissão NF]
 		,Log_OL.Observacao_Retorno_PedidoOL[Retorno]
 		,Cliente.Codigo[Cód.Cliente]
 		,Cliente.Razao_Social[Cliente]
 FROM[UNIDB].dbo.[ROBOT_LogOL] Log_OL
 INNER JOIN[DMD].dbo.[PDECB] Pedido_OL ON Pedido_OL.Cod_PedCli = Log_OL.Num_PedidoOL COLLATE Latin1_General_CI_AS
 LEFT JOIN[DMD].dbo.[NFSCB] NotaFiscal_CB ON NotaFiscal_CB.Num_Nota = Log_OL.NF_Pedido_OL
 INNER JOIN[DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = Pedido_OL.Cod_Client
 WHERE
 Cliente.Razao_Social like '%{razaoSocial}%'
 AND NotaFiscal_CB.Num_Nota LIKE '%{numNota}%'

 AND Pedido_OL.Cod_PedCli LIKE '%{codPedOL}%'
 AND((Log_OL.NF_Pedido_OL IS NULL AND      0 = {flgPedido})
   OR(LOG_OL.NF_Pedido_OL IS NOT NULL AND  1 = {flgPedido}))
 AND((Observacao_Retorno_PedidoOL IS not NULL AND 1 = {flgProblema})
   OR(Observacao_Retorno_PedidoOL IS NULL AND     0 = {flgProblema}))";                
                return await getAllToDataTable(query);
            }
            public static async Task<DataTable> getInfoPedidoToDataTableAsync(string codPedOL)
            {
                string query = $@"SELECT                                                                                                                                          
                                          Produto.Codigo[Cód.Produto]                                                                                   
                                		 ,Produto.Descricao[Produto]                                                                                    
                                		 ,Produto.Cod_EAN[Cód.EAN]                                                                                      
                                		 ,Pedido_OL_Itens.Prc_Unitario[Prc.Unitário]                                                                    
                                		 ,Pedido_OL_Itens.Qtd_Atendi[Qtd.Itens]                                                                         
                                		 ,[Total] = Pedido_OL_Itens.Prc_Unitario * Pedido_OL_Itens.Qtd_Atendi                                           
                                FROM[UNIDB].dbo.[ROBOT_LogOL] Log_OL                                                                                   
                                INNER JOIN[DMD].dbo.[PDECB] Pedido_OL ON Pedido_OL.Cod_PedCli = Log_OL.Num_PedidoOL COLLATE Latin1_General_CI_AS       
                                INNER JOIN[DMD].dbo.[PDEIT] Pedido_OL_Itens ON Pedido_OL_Itens.Cod_PedCli = Pedido_OL.Cod_PedCli                       
                                INNER JOIN[DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = Pedido_OL.Cod_Client                                           
                                INNER JOIN[DMD].dbo.[PRODU] Produto ON Produto.Codigo = Pedido_OL_Itens.Cod_Produt                                     
                                INNER JOIN[DMD].dbo.[NFSCB] NotaFiscal_CB ON NotaFiscal_CB.Num_Nota = Log_OL.NF_Pedido_OL                               
                                WHERE Log_OL.Num_PedidoOL ={codPedOL}";                
                return await getAllToDataTable(query);
            }
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

        /** Carregar informações **/
        private async Task carregarInfoAsync()
        {
            string descricaoCliente = null;
            string nf = null;
            string pedidoOL = null;
            int nfEmitida = 0;
            int nfProblema = 0;

            txtDescricaoCliente.Invoke((Action)delegate
            {
                descricaoCliente = string.IsNullOrEmpty(txtDescricaoCliente.Text) ? null : txtDescricaoCliente.Text;
            });

            txtNF.Invoke((Action)delegate
            {
                nf = string.IsNullOrEmpty(txtNF.Text) ? null : txtNF.Text;
            });

            txtPedidoOL.Invoke((Action)delegate
            {
                pedidoOL = string.IsNullOrEmpty(txtPedidoOL.Text) ? null : txtPedidoOL.Text;
            });

            chkNFemitida.Invoke((Action)delegate
            {
                nfEmitida = Convert.ToInt16(chkNFemitida.CheckState);
            });

            chkNFProblema.Invoke((Action)delegate
            {
                nfProblema = Convert.ToInt16(chkNFProblema.CheckState);
            });

            DataTable dt = null;
            dt = await Consultas.getPedidosToDataTableAsync(descricaoCliente, nf, pedidoOL, nfEmitida.ToString(), nfProblema.ToString());
            dgvHistorico.DataSource = dt;
            dgvHistorico.toDefault();
        }

        private async void pesquisar(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(()=> carregarInfoAsync() );
            dgvInfoPedido.ClearSelection();
        }
        /** Eventos do Form **/
        private async void frmConsultarPedidoOL_Load(object sender, EventArgs e)
        {
            txtDescricaoCliente.ReadOnly = true;
            txtDescricaoCliente.TabStop = false;
            
            await carregarInfoAsync();            
        }

        private async void dgvHistorico_SelectionChanged(object sender, EventArgs e)
        {            
            dgvInfoPedido.DataSource =  await Consultas.getInfoPedidoToDataTableAsync(dgvHistorico.CurrentRow.Cells[0].Value.ToString());
            dgvInfoPedido.toDefault();
        }
        
    }
}
