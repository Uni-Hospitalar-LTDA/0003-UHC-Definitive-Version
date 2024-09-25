namespace UHC3_Definitive_Version.App.ModGerencial.Informativo
{
    partial class frmMargemCompraVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtDescricaoFabricante = new System.Windows.Forms.TextBox();
            this.txtDescricaoCliente = new System.Windows.Forms.TextBox();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.txtCodFabricante = new System.Windows.Forms.TextBox();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblFiltroPorData = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxVendas = new System.Windows.Forms.ComboBox();
            this.gpbResultados = new System.Windows.Forms.GroupBox();
            this.txtMediaCompra = new System.Windows.Forms.TextBox();
            this.lblMediaCompra = new System.Windows.Forms.Label();
            this.txtMediaVenda = new System.Windows.Forms.TextBox();
            this.lblMediaVenda = new System.Windows.Forms.Label();
            this.txtMargem = new System.Windows.Forms.TextBox();
            this.lblMargem = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.lblTotalCompras = new System.Windows.Forms.Label();
            this.txtTotalCompras = new System.Windows.Forms.TextBox();
            this.lblVlrTotalCompras = new System.Windows.Forms.Label();
            this.txtVlrTotalCompras = new System.Windows.Forms.TextBox();
            this.lblQtdTotalCompras = new System.Windows.Forms.Label();
            this.txtQtdTotalCompras = new System.Windows.Forms.TextBox();
            this.lblTotalVendas = new System.Windows.Forms.Label();
            this.txtTotalVendas = new System.Windows.Forms.TextBox();
            this.lblVlrTotalVendas = new System.Windows.Forms.Label();
            this.txtVlrTotalVendas = new System.Windows.Forms.TextBox();
            this.lblQtdTotalVendas = new System.Windows.Forms.Label();
            this.txtQtdTotalVendas = new System.Windows.Forms.TextBox();
            this.lblCompras = new System.Windows.Forms.Label();
            this.lblVendas = new System.Windows.Forms.Label();
            this.pcbVendas = new Krypton.Toolkit.KryptonProgressBar();
            this.pcbCompras = new Krypton.Toolkit.KryptonProgressBar();
            this.gpbFiltros.SuspendLayout();
            this.gpbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.txtEstado);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.txtDescricaoFabricante);
            this.gpbFiltros.Controls.Add(this.txtDescricaoCliente);
            this.gpbFiltros.Controls.Add(this.txtCodCliente);
            this.gpbFiltros.Controls.Add(this.txtDescricaoProduto);
            this.gpbFiltros.Controls.Add(this.txtCodProduto);
            this.gpbFiltros.Controls.Add(this.lblProduto);
            this.gpbFiltros.Controls.Add(this.lblCliente);
            this.gpbFiltros.Controls.Add(this.lblFabricante);
            this.gpbFiltros.Controls.Add(this.txtCodFabricante);
            this.gpbFiltros.Controls.Add(this.dtpFinal);
            this.gpbFiltros.Controls.Add(this.dtpInicial);
            this.gpbFiltros.Controls.Add(this.lblEstado);
            this.gpbFiltros.Controls.Add(this.lblFiltroPorData);
            this.gpbFiltros.Controls.Add(this.label1);
            this.gpbFiltros.Controls.Add(this.cbxVendas);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(569, 181);
            this.gpbFiltros.TabIndex = 59;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(10, 152);
            this.txtEstado.MaxLength = 40;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(113, 20);
            this.txtEstado.TabIndex = 3;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(486, 140);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 36);
            this.btnPesquisar.TabIndex = 7;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // txtDescricaoFabricante
            // 
            this.txtDescricaoFabricante.Location = new System.Drawing.Point(88, 114);
            this.txtDescricaoFabricante.Name = "txtDescricaoFabricante";
            this.txtDescricaoFabricante.Size = new System.Drawing.Size(473, 20);
            this.txtDescricaoFabricante.TabIndex = 18;
            // 
            // txtDescricaoCliente
            // 
            this.txtDescricaoCliente.Location = new System.Drawing.Point(88, 73);
            this.txtDescricaoCliente.Name = "txtDescricaoCliente";
            this.txtDescricaoCliente.Size = new System.Drawing.Size(473, 20);
            this.txtDescricaoCliente.TabIndex = 20;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(10, 73);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(72, 20);
            this.txtCodCliente.TabIndex = 1;
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.Location = new System.Drawing.Point(88, 32);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.Size = new System.Drawing.Size(473, 20);
            this.txtDescricaoProduto.TabIndex = 21;
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Location = new System.Drawing.Point(10, 32);
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.Size = new System.Drawing.Size(72, 20);
            this.txtCodProduto.TabIndex = 0;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(7, 16);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(87, 13);
            this.lblProduto.TabIndex = 22;
            this.lblProduto.Text = "Filtro por Produto";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(7, 57);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(82, 13);
            this.lblCliente.TabIndex = 23;
            this.lblCliente.Text = "Filtro por Cliente";
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(7, 98);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(100, 13);
            this.lblFabricante.TabIndex = 24;
            this.lblFabricante.Text = "Filtro por Fabricante";
            // 
            // txtCodFabricante
            // 
            this.txtCodFabricante.Location = new System.Drawing.Point(10, 114);
            this.txtCodFabricante.Name = "txtCodFabricante";
            this.txtCodFabricante.Size = new System.Drawing.Size(72, 20);
            this.txtCodFabricante.TabIndex = 2;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(238, 152);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpFinal.Size = new System.Drawing.Size(99, 20);
            this.dtpFinal.TabIndex = 5;
            // 
            // dtpInicial
            // 
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicial.Location = new System.Drawing.Point(136, 152);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpInicial.Size = new System.Drawing.Size(96, 20);
            this.dtpInicial.TabIndex = 4;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(7, 136);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(83, 13);
            this.lblEstado.TabIndex = 28;
            this.lblEstado.Text = "Filtro por Estado";
            // 
            // lblFiltroPorData
            // 
            this.lblFiltroPorData.AutoSize = true;
            this.lblFiltroPorData.Location = new System.Drawing.Point(132, 136);
            this.lblFiltroPorData.Name = "lblFiltroPorData";
            this.lblFiltroPorData.Size = new System.Drawing.Size(69, 13);
            this.lblFiltroPorData.TabIndex = 29;
            this.lblFiltroPorData.Text = "Dat. Emissão";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Vendas para o:";
            // 
            // cbxVendas
            // 
            this.cbxVendas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVendas.FormattingEnabled = true;
            this.cbxVendas.Location = new System.Drawing.Point(350, 152);
            this.cbxVendas.Name = "cbxVendas";
            this.cbxVendas.Size = new System.Drawing.Size(121, 21);
            this.cbxVendas.TabIndex = 6;
            // 
            // gpbResultados
            // 
            this.gpbResultados.Controls.Add(this.txtMediaCompra);
            this.gpbResultados.Controls.Add(this.lblMediaCompra);
            this.gpbResultados.Controls.Add(this.txtMediaVenda);
            this.gpbResultados.Controls.Add(this.lblMediaVenda);
            this.gpbResultados.Controls.Add(this.txtMargem);
            this.gpbResultados.Controls.Add(this.lblMargem);
            this.gpbResultados.Location = new System.Drawing.Point(587, 12);
            this.gpbResultados.Name = "gpbResultados";
            this.gpbResultados.Size = new System.Drawing.Size(420, 181);
            this.gpbResultados.TabIndex = 60;
            this.gpbResultados.TabStop = false;
            this.gpbResultados.Text = "Resultados";
            // 
            // txtMediaCompra
            // 
            this.txtMediaCompra.Location = new System.Drawing.Point(87, 50);
            this.txtMediaCompra.Name = "txtMediaCompra";
            this.txtMediaCompra.Size = new System.Drawing.Size(70, 20);
            this.txtMediaCompra.TabIndex = 64;
            // 
            // lblMediaCompra
            // 
            this.lblMediaCompra.AutoSize = true;
            this.lblMediaCompra.Location = new System.Drawing.Point(84, 34);
            this.lblMediaCompra.Name = "lblMediaCompra";
            this.lblMediaCompra.Size = new System.Drawing.Size(71, 13);
            this.lblMediaCompra.TabIndex = 65;
            this.lblMediaCompra.Text = "Prc Médio (C)";
            // 
            // txtMediaVenda
            // 
            this.txtMediaVenda.Location = new System.Drawing.Point(6, 50);
            this.txtMediaVenda.Name = "txtMediaVenda";
            this.txtMediaVenda.Size = new System.Drawing.Size(70, 20);
            this.txtMediaVenda.TabIndex = 62;
            // 
            // lblMediaVenda
            // 
            this.lblMediaVenda.AutoSize = true;
            this.lblMediaVenda.Location = new System.Drawing.Point(3, 34);
            this.lblMediaVenda.Name = "lblMediaVenda";
            this.lblMediaVenda.Size = new System.Drawing.Size(71, 13);
            this.lblMediaVenda.TabIndex = 63;
            this.lblMediaVenda.Text = "Prc Médio (V)";
            // 
            // txtMargem
            // 
            this.txtMargem.Location = new System.Drawing.Point(170, 50);
            this.txtMargem.Name = "txtMargem";
            this.txtMargem.Size = new System.Drawing.Size(70, 20);
            this.txtMargem.TabIndex = 60;
            // 
            // lblMargem
            // 
            this.lblMargem.AutoSize = true;
            this.lblMargem.Location = new System.Drawing.Point(170, 34);
            this.lblMargem.Name = "lblMargem";
            this.lblMargem.Size = new System.Drawing.Size(62, 13);
            this.lblMargem.TabIndex = 61;
            this.lblMargem.Text = "Margem (%)";
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(932, 625);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 77;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 214);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvVendas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCompras);
            this.splitContainer1.Size = new System.Drawing.Size(995, 377);
            this.splitContainer1.SplitterDistance = 489;
            this.splitContainer1.TabIndex = 76;
            // 
            // dgvVendas
            // 
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendas.Location = new System.Drawing.Point(0, 0);
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.RowHeadersWidth = 51;
            this.dgvVendas.Size = new System.Drawing.Size(489, 377);
            this.dgvVendas.TabIndex = 31;
            // 
            // dgvCompras
            // 
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompras.Location = new System.Drawing.Point(0, 0);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.RowHeadersWidth = 51;
            this.dgvCompras.Size = new System.Drawing.Size(502, 377);
            this.dgvCompras.TabIndex = 30;
            // 
            // lblTotalCompras
            // 
            this.lblTotalCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCompras.AutoSize = true;
            this.lblTotalCompras.Location = new System.Drawing.Point(749, 611);
            this.lblTotalCompras.Name = "lblTotalCompras";
            this.lblTotalCompras.Size = new System.Drawing.Size(31, 13);
            this.lblTotalCompras.TabIndex = 75;
            this.lblTotalCompras.Text = "Total";
            // 
            // txtTotalCompras
            // 
            this.txtTotalCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalCompras.Location = new System.Drawing.Point(752, 627);
            this.txtTotalCompras.Name = "txtTotalCompras";
            this.txtTotalCompras.Size = new System.Drawing.Size(154, 20);
            this.txtTotalCompras.TabIndex = 74;
            // 
            // lblVlrTotalCompras
            // 
            this.lblVlrTotalCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVlrTotalCompras.AutoSize = true;
            this.lblVlrTotalCompras.Location = new System.Drawing.Point(604, 611);
            this.lblVlrTotalCompras.Name = "lblVlrTotalCompras";
            this.lblVlrTotalCompras.Size = new System.Drawing.Size(61, 13);
            this.lblVlrTotalCompras.TabIndex = 73;
            this.lblVlrTotalCompras.Text = "Vlr. Vendas";
            // 
            // txtVlrTotalCompras
            // 
            this.txtVlrTotalCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVlrTotalCompras.Location = new System.Drawing.Point(607, 627);
            this.txtVlrTotalCompras.Name = "txtVlrTotalCompras";
            this.txtVlrTotalCompras.Size = new System.Drawing.Size(139, 20);
            this.txtVlrTotalCompras.TabIndex = 72;
            // 
            // lblQtdTotalCompras
            // 
            this.lblQtdTotalCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQtdTotalCompras.AutoSize = true;
            this.lblQtdTotalCompras.Location = new System.Drawing.Point(514, 611);
            this.lblQtdTotalCompras.Name = "lblQtdTotalCompras";
            this.lblQtdTotalCompras.Size = new System.Drawing.Size(54, 13);
            this.lblQtdTotalCompras.TabIndex = 71;
            this.lblQtdTotalCompras.Text = "Qtd. Total";
            // 
            // txtQtdTotalCompras
            // 
            this.txtQtdTotalCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQtdTotalCompras.Location = new System.Drawing.Point(514, 627);
            this.txtQtdTotalCompras.Name = "txtQtdTotalCompras";
            this.txtQtdTotalCompras.Size = new System.Drawing.Size(84, 20);
            this.txtQtdTotalCompras.TabIndex = 70;
            // 
            // lblTotalVendas
            // 
            this.lblTotalVendas.AutoSize = true;
            this.lblTotalVendas.Location = new System.Drawing.Point(239, 611);
            this.lblTotalVendas.Name = "lblTotalVendas";
            this.lblTotalVendas.Size = new System.Drawing.Size(31, 13);
            this.lblTotalVendas.TabIndex = 69;
            this.lblTotalVendas.Text = "Total";
            // 
            // txtTotalVendas
            // 
            this.txtTotalVendas.Location = new System.Drawing.Point(242, 627);
            this.txtTotalVendas.Name = "txtTotalVendas";
            this.txtTotalVendas.Size = new System.Drawing.Size(154, 20);
            this.txtTotalVendas.TabIndex = 68;
            // 
            // lblVlrTotalVendas
            // 
            this.lblVlrTotalVendas.AutoSize = true;
            this.lblVlrTotalVendas.Location = new System.Drawing.Point(94, 611);
            this.lblVlrTotalVendas.Name = "lblVlrTotalVendas";
            this.lblVlrTotalVendas.Size = new System.Drawing.Size(61, 13);
            this.lblVlrTotalVendas.TabIndex = 67;
            this.lblVlrTotalVendas.Text = "Vlr. Vendas";
            // 
            // txtVlrTotalVendas
            // 
            this.txtVlrTotalVendas.Location = new System.Drawing.Point(97, 627);
            this.txtVlrTotalVendas.Name = "txtVlrTotalVendas";
            this.txtVlrTotalVendas.Size = new System.Drawing.Size(139, 20);
            this.txtVlrTotalVendas.TabIndex = 66;
            // 
            // lblQtdTotalVendas
            // 
            this.lblQtdTotalVendas.AutoSize = true;
            this.lblQtdTotalVendas.Location = new System.Drawing.Point(4, 611);
            this.lblQtdTotalVendas.Name = "lblQtdTotalVendas";
            this.lblQtdTotalVendas.Size = new System.Drawing.Size(54, 13);
            this.lblQtdTotalVendas.TabIndex = 65;
            this.lblQtdTotalVendas.Text = "Qtd. Total";
            // 
            // txtQtdTotalVendas
            // 
            this.txtQtdTotalVendas.Location = new System.Drawing.Point(7, 627);
            this.txtQtdTotalVendas.Name = "txtQtdTotalVendas";
            this.txtQtdTotalVendas.Size = new System.Drawing.Size(84, 20);
            this.txtQtdTotalVendas.TabIndex = 64;
            // 
            // lblCompras
            // 
            this.lblCompras.AutoSize = true;
            this.lblCompras.Location = new System.Drawing.Point(502, 198);
            this.lblCompras.Name = "lblCompras";
            this.lblCompras.Size = new System.Drawing.Size(48, 13);
            this.lblCompras.TabIndex = 63;
            this.lblCompras.Text = "Compras";
            // 
            // lblVendas
            // 
            this.lblVendas.AutoSize = true;
            this.lblVendas.Location = new System.Drawing.Point(15, 198);
            this.lblVendas.Name = "lblVendas";
            this.lblVendas.Size = new System.Drawing.Size(43, 13);
            this.lblVendas.TabIndex = 62;
            this.lblVendas.Text = "Vendas";
            // 
            // pcbVendas
            // 
            this.pcbVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pcbVendas.Location = new System.Drawing.Point(12, 595);
            this.pcbVendas.Name = "pcbVendas";
            this.pcbVendas.Size = new System.Drawing.Size(487, 13);
            this.pcbVendas.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.pcbVendas.StateDisabled.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.pcbVendas.StateNormal.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.pcbVendas.TabIndex = 78;
            this.pcbVendas.Values.Text = "";
            // 
            // pcbCompras
            // 
            this.pcbCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbCompras.Location = new System.Drawing.Point(505, 595);
            this.pcbCompras.Name = "pcbCompras";
            this.pcbCompras.Size = new System.Drawing.Size(504, 13);
            this.pcbCompras.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.pcbCompras.StateDisabled.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.pcbCompras.StateNormal.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.pcbCompras.TabIndex = 79;
            this.pcbCompras.Values.Text = "";
            // 
            // frmMargemCompraVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 658);
            this.Controls.Add(this.pcbCompras);
            this.Controls.Add(this.pcbVendas);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblTotalCompras);
            this.Controls.Add(this.txtTotalCompras);
            this.Controls.Add(this.lblVlrTotalCompras);
            this.Controls.Add(this.txtVlrTotalCompras);
            this.Controls.Add(this.lblQtdTotalCompras);
            this.Controls.Add(this.txtQtdTotalCompras);
            this.Controls.Add(this.lblTotalVendas);
            this.Controls.Add(this.txtTotalVendas);
            this.Controls.Add(this.lblVlrTotalVendas);
            this.Controls.Add(this.txtVlrTotalVendas);
            this.Controls.Add(this.lblQtdTotalVendas);
            this.Controls.Add(this.txtQtdTotalVendas);
            this.Controls.Add(this.lblCompras);
            this.Controls.Add(this.lblVendas);
            this.Controls.Add(this.gpbResultados);
            this.Controls.Add(this.gpbFiltros);
            this.Name = "frmMargemCompraVenda";
            this.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Border.ColorAngle = 45F;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Width = 5;
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.Text = "Informativo de Produtos (Vendas x Compras)";
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            this.gpbResultados.ResumeLayout(false);
            this.gpbResultados.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtDescricaoFabricante;
        private System.Windows.Forms.TextBox txtDescricaoCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TextBox txtDescricaoProduto;
        private System.Windows.Forms.TextBox txtCodProduto;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.TextBox txtCodFabricante;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFiltroPorData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxVendas;
        private System.Windows.Forms.GroupBox gpbResultados;
        private System.Windows.Forms.TextBox txtMediaCompra;
        private System.Windows.Forms.Label lblMediaCompra;
        private System.Windows.Forms.TextBox txtMediaVenda;
        private System.Windows.Forms.Label lblMediaVenda;
        private System.Windows.Forms.TextBox txtMargem;
        private System.Windows.Forms.Label lblMargem;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvVendas;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.Label lblTotalCompras;
        private System.Windows.Forms.TextBox txtTotalCompras;
        private System.Windows.Forms.Label lblVlrTotalCompras;
        private System.Windows.Forms.TextBox txtVlrTotalCompras;
        private System.Windows.Forms.Label lblQtdTotalCompras;
        private System.Windows.Forms.TextBox txtQtdTotalCompras;
        private System.Windows.Forms.Label lblTotalVendas;
        private System.Windows.Forms.TextBox txtTotalVendas;
        private System.Windows.Forms.Label lblVlrTotalVendas;
        private System.Windows.Forms.TextBox txtVlrTotalVendas;
        private System.Windows.Forms.Label lblQtdTotalVendas;
        private System.Windows.Forms.TextBox txtQtdTotalVendas;
        private System.Windows.Forms.Label lblCompras;
        private System.Windows.Forms.Label lblVendas;
        private Krypton.Toolkit.KryptonProgressBar pcbVendas;
        private Krypton.Toolkit.KryptonProgressBar pcbCompras;
    }
}