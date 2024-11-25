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
    public partial class frmConsultaDeprecos_NewDetalhamentoProduto : CustomForm
    {

        /** Instance **/
        internal Produtos_Externos product { get; set; }

        internal class Report_UltimasVendas  : Querys<Report_UltimasVendas>
        {
            public async static Task<DataTable> getUltimasVendasByCode(string code, string cod_cliente, int contLinhas = 40)
            {
                string customerFilter = null;
                if (!string.IsNullOrEmpty(cod_cliente))
                {                    
                    customerFilter = $"AND Cliente.Codigo = {cod_cliente}";
                }
                string query = $@"SELECT top {contLinhas}                                         
                                         NF_Saida_Itens.Prc_Unitario  [Prc. Unitário]
                                        ,NF_Saida_Itens.Qtd_Produto [Qtd. Produto]
										,NF_Saida.Num_Nota [NF]
                                		,CONVERT(DATE,NF_Saida.Dat_Emissao) [Emissão]
                                		,NF_Saida.Cod_Cliente		[Cód. Cliente]
										,Cliente.Razao_Social [Cliente]
                                FROM [DMD].dbo.[NFSCB] NF_Saida
                                JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente
                                JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens  ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
								JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto                                
                                AND NF_Saida.STATUS = 'F' AND Tip_Saida = 'V'
                                AND Tipo_Consumidor IN ('F','N')
                                AND Cod_Produto =  {code}    
                                {customerFilter}
                                ORDER BY Dat_Emissao DESC";                
                return await getAllToDataTable(query);
            }
        }


        public frmConsultaDeprecos_NewDetalhamentoProduto()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();
            ConfigureDataGridViewProperties();

            //Events
            ConfigureFormEvents();
        }


        /** Async Tasks **/
        private async Task getReportAsync()
        {
            string customer_Filter = null;
            string top_Filter = null;
            if (!string.IsNullOrEmpty(txtCustomer.Text))
            {
                customer_Filter = txtCustomerId.Text;
            }
            if (!string.IsNullOrEmpty(txtTop.Text))
            {
                top_Filter = txtTop.Text;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dgvHistorico.DataSource = await Report_UltimasVendas.getUltimasVendasByCode(product.codigo, customer_Filter, (top_Filter is null ? 40 : Convert.ToInt32(top_Filter)));
                //dgvHistorico.Columns[0].DefaultCellStyle.Format = "N0";
                dgvHistorico.Columns[0].DefaultCellStyle.Format = "C2";
                dgvHistorico.Columns[0].ValueType = typeof(double);
                
                dgvHistorico.Columns[1].DefaultCellStyle.Format = "N0";
                dgvHistorico.Columns[1].ValueType = typeof(int);
                
                dgvHistorico.Columns[2].DefaultCellStyle.Format = "N0";
                dgvHistorico.Columns[2].ValueType = typeof(int);

                dgvHistorico.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvHistorico.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvHistorico.Columns[4].DefaultCellStyle.Format = "N0";
                dgvHistorico.Columns[4].ValueType = typeof(int);
                this.Cursor = Cursors.Default;
                dgvHistorico.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }

        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmConsultaDeprecos_NewDetalhamentoProduto_Load;
        }
        private async void frmConsultaDeprecos_NewDetalhamentoProduto_Load(object sender, EventArgs e)
        {
            //Attributes
            ConfigureTextBoxAttributes();
            lblProduto.Text = $"Produto: {product.codigo} - {product.descricao}";

            await getReportAsync();

            //Events
            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
        }


        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnFilter.Click += btnFilter_Click;
        }
        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await getReportAsync();
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxAttributes()
        {
            txtTop.Text = "40";
        }
        private void ConfigureTextBoxProperties()
        {
            txtCustomer.ReadOnly();
            txtCustomerId.JustNumbers();
            txtCustomerId.MaxLength = 8;

            txtTop.MaxLength = 4;
            txtTop.JustNumbers();
        }
        private void ConfigureTextBoxEvents()
        {
            txtCustomerId.TextChanged += txtCustomerId_TextChanged;
            txtCustomerId.KeyDown += txtCustomerId_KeyDown;
            txtTop.KeyDown += txtCustomerId_KeyDown;
            txtCustomer.DoubleClick += txtCustomer_DoubleClick;
        }
        private void txtCustomerId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnFilter_Click(sender, e);
            }
        }
        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            txtCustomer.Text = Clientes_Externos.getDescripionByCode(txtCustomerId.Text);
        }
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            txtCustomerId.Text = frmConsultarCliente.extendedCode;
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvHistorico.toDefault();
            dgvHistorico.MultiSelect = true;
        }

    }
}
