using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModVendas.AnaliseVendas
{
    public partial class frmAdicionarProdutoAoPedido : CustomForm
    {

        public Produtos_Externos pe { get; private set ; } = new Produtos_Externos();
        public int Quantidade { get; private set; }
        public double Preco { get; private set; }
        public double Desconto { get; private set; }        
        public string Lote { get; private set; }
        public frmAdicionarProdutoAoPedido()
        {
            InitializeComponent();



            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();

            //txtProductId.Text = "1119";
            //txtLote.Text = "teste";
            //Events
            ConfigureFormEvents();
        }



        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmAdicionarProdutoAoPedido_Load;
        }
        private void frmAdicionarProdutoAoPedido_Load(object sender, EventArgs e)
        {
            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
        }


        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtProductId.JustNumbers();            
            txtProductId.MaxLength = 8;

            txtQuantidade.JustNumbers();
            txtQuantidade.MaxLength = 8;

            txtPreco.justDecimalNumbers();
            txtDesconto.justDecimalNumbers();

            txtProduto.ReadOnly();
            txtLote.ReadOnly();
            
        }
        private void ConfigureTextBoxEvents()
        {
            txtProductId.TextChanged += txtProductId_TextChanged;
            txtLote.LostFocus += TxtLote_LostFocus;
        }

        private void TxtLote_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLote.Text))
            {
                txtProductId.ReadOnly();
                
            }
            else
            {
                txtProductId.ReadOnly(false);
            }
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            Produtos_Externos pe = Produtos_Externos.getProductByCode(txtProductId.Text);
            txtProduto.Text = pe?.descricao;
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultQuestionCloseButton();            
            btnMoreProducts.TabStop = false;
            
        }

      

        private void ConfigureButtonEvents()
        {
            btnMoreProducts.Click += btnMoreProducts_Click;
            btnMoreLotes.Click += btnMoreLotes_Click;
            btnAdicionar.Click += btnAdicionar_Click;
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!this.requiredInformationValidation()) return;
            pe = Produtos_Externos.getProductByCode(txtProductId.Text);
            Quantidade = Convert.ToInt32(txtQuantidade.Text);
            Preco = Convert.ToDouble(txtPreco.Text);
            Desconto = Convert.ToDouble(txtDesconto.Text);
            Lote = txtLote.Text;
            this.Close();

        }
        private async void btnMoreLotes_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtProduto.Text)) {
                
                frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
                frmGeneric_ConsultaComSelecao.consulta = await Produtos_Externos.getLotesByCodeAsync(txtProductId.Text);
                frmGeneric_ConsultaComSelecao.ShowDialog();
                txtLote.Text = frmGeneric_ConsultaComSelecao.extendedCode;
                TxtLote_LostFocus(null, null);
            }
        }
       

        private async void btnMoreProducts_Click(object sender, EventArgs e)
        {
            frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
            frmGeneric_ConsultaComSelecao.consulta = await Produtos_Externos.getAllToDataTable($@"SELECT Produto.Codigo [Cód. Produto]
, Produto.Descricao [Produto]
, Produto.Des_NomGen [Nom. Genérico]
, Produto.qtd_disponivel +qtd_reservado [Quantidade] 
,Fabricante.Fantasia [Fabricante]
FROM [{Connection.dbDMD}].dbo.[PRODU] Produto
JOIN [{Connection.dbDMD}].dbo.[FABRI] Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante");
            frmGeneric_ConsultaComSelecao.ShowDialog();
            txtProductId.Text = frmGeneric_ConsultaComSelecao.extendedCode;
            txtLote.Text = string.Empty;
            
        }
    }
}
