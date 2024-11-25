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
    public partial class frmConsultarPedidoCliente : CustomForm
    {
        public frmConsultarPedidoCliente()
        {
            InitializeComponent();
            this.defaultMaximableForm();            

            btnFechar.toDefaultCloseButton();
            this.Load += frmConsultarPedidoOL_Load;


            txtCodCliente.JustNumbers();            

            txtDescricaoCliente.TextChanged += pesquisar;            
            txtCodCliente.TextChanged += txtCodCliente_TextChanged;
            txtDescricaoCliente.DoubleClick += txtDescricaoCliente_DoubleClick;

            txtPedidoCliente.KeyDown += pesquisar_KeyDown;

            dgvData.SelectionChanged += dgvHistorico_SelectionChanged;

        }
        /** Instância**/
        internal class Consultas : Querys<Consultas>
        {
            public static async Task<DataTable> getPedidosToDataTableAsync(string pedidoCliente, string razaoSocial)
            {
                int condicaoPedido = (!string.IsNullOrEmpty(pedidoCliente) ? 1 : 0);
                

                string query = $@"   SELECT top 50 NSCB.Num_Nota [NF]                                               
      ,CONVERT(DATE,NSCB.Dat_Emissao)[Dat. Emissão]                                      
	  ,CLIE.Codigo[Cód. Cliente]                                           
	  ,CLIE.Razao_Social[Cliente]                                          
	  ,[CNPJ] = SUBSTRING(CLIE.Cgc_Cpf, 1, 2) + '.'                        
               + SUBSTRING(CLIE.Cgc_Cpf, 3, 3) + '.'                       
               + SUBSTRING(CLIE.Cgc_Cpf, 6, 3) + '/'                       
               + SUBSTRING(CLIE.Cgc_Cpf, 9, 4) + '-'                       
               + SUBSTRING(CLIE.Cgc_Cpf, 13, 2)                            
	  ,PVCB.Numero[Número Pedido Ally]                                     
	  ,PVCB.Dat_Pedido[Dat. Pedido Ally]                                   
	  ,PVCB.Observacao [Observação]                                        
   FROM[DMD].dbo.[PDVCB] PVCB                                              
   INNER JOIN[DMD].dbo.[CLIEN] CLIE ON CLIE.Codigo = PVCB.Cod_Cliente      
   LEFT JOIN[DMD].dbo.[NFSCB] NSCB ON NSCB.Cod_Pedido = PVCB.Numero        
   WHERE                                                                   
   PVCB.Observacao NOT LIKE '%TESTE%'   
   AND (PVCB.Observacao LIKE '%{pedidoCliente}%' AND 1={condicaoPedido} OR 0={condicaoPedido})
   AND CLIE.Razao_Social LIKE '%{razaoSocial}%'
   ORDER BY nscb.dAT_Emissao desc";
                Console.WriteLine(query);
                return await getAllToDataTable(query);
            }
            public static async Task<DataTable> getInfoPedidoToDataTableAsync(string numNota)
            {
                string query = $@"SELECT PROD.Codigo[Cód.Produto]                                       
                                        ,PROD.Descricao[Produto]                                              
                                        	  ,NSIT.Qtd_Produto[Qtd.]                                           
                                        	  ,NSIT.Prc_Unitario[Prc.Unitario]                                  
                                        FROM[DMD].dbo.[PDVCB] PVCB                                            
                                        INNER JOIN[DMD].dbo.[CLIEN] CLIE ON CLIE.Codigo = PVCB.Cod_Cliente    
                                        LEFT JOIN[DMD].dbo.[NFSCB] NSCB ON NSCB.Cod_Pedido = PVCB.Numero      
                                        LEFT JOIN[DMD].dbo.[NFSIT] NSIT ON NSIT.Num_Nota = NSCB.Num_Nota      
                                        INNER JOIN[DMD].dbo.[PRODU] PROD ON PROD.Codigo = NSIT.Cod_Produto    
                                  WHERE NSCB.Num_Nota = {numNota}";
                return await getAllToDataTable(query);
            }
        }

        private async void pesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await carregarInfoAsync();
            }
        }

        /** Carregar informações **/
        private async Task carregarInfoAsync()
        {
            dgvData.DataSource = await Consultas.getPedidosToDataTableAsync(txtPedidoCliente.Text,txtDescricaoCliente.Text);
            dgvData.toDefault();
        }

        private async void pesquisar(object sender, EventArgs e)
        {
            await carregarInfoAsync();
            dgvInfoPedido.ClearSelection();
        }

        private void frmConsultarPedidoOL_Load(object sender, EventArgs e)
        {
            txtDescricaoCliente.ReadOnly = true;
            txtDescricaoCliente.TabStop = false;

            //await carregarInfoAsync();
        }

        private async void dgvHistorico_SelectionChanged(object sender, EventArgs e)
        {
            dgvInfoPedido.DataSource = await Consultas.getInfoPedidoToDataTableAsync(dgvData.CurrentRow.Cells[0].Value.ToString());
            dgvInfoPedido.toDefault();
        }

        /** Events **/
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
