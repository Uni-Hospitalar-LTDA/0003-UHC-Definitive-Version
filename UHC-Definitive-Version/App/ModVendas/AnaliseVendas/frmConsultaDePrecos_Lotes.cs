using System;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModVendas.Precificacao
{
    public partial class frmConsultaDePrecos_Lotes : CustomForm
    {
        public frmConsultaDePrecos_Lotes()
        {
            InitializeComponent();
            this.defaultFixedForm();
            btnFechar.toDefaultCloseButton();
            this.Load += frmPrecificacao_Lotes_Load;
        }

        internal Produtos_Externos produto { get; set; }

        private async void frmPrecificacao_Lotes_Load(object sender, EventArgs e)
        {
            lblProduto.Text = $"Produto: {produto.codigo} | {produto.descricao}";
            dgvLotes.DataSource = await Produtos_Externos.getLotesByCodeAsync(produto.codigo);                        
        }

    }
}
