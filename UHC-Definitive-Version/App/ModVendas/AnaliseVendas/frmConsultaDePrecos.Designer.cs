namespace UHC3_Definitive_Version.App.ModVendas.Precificacao
{
    partial class frmConsultaDePrecos
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
            this.gpbTipo = new System.Windows.Forms.GroupBox();
            this.chkHospitalar = new System.Windows.Forms.CheckBox();
            this.chkOncologico = new System.Windows.Forms.CheckBox();
            this.lblMaiorQue = new System.Windows.Forms.Label();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.txtCodFabricante = new System.Windows.Forms.TextBox();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.lblProdutoGenerico = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
            this.txtProdutoGenerico = new System.Windows.Forms.TextBox();
            this.txtDescricaoFabricante = new System.Windows.Forms.TextBox();
            this.lblLocalizacao = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblVencimento = new System.Windows.Forms.Label();
            this.btnUltimasVendas = new System.Windows.Forms.Button();
            this.btnLotes = new System.Windows.Forms.Button();
            this.txtVencimento = new System.Windows.Forms.TextBox();
            this.txtLocalizacao = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtUltimaEntrada = new System.Windows.Forms.TextBox();
            this.lblUltimaEntrada = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gpbTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbTipo
            // 
            this.gpbTipo.Controls.Add(this.chkHospitalar);
            this.gpbTipo.Controls.Add(this.chkOncologico);
            this.gpbTipo.Location = new System.Drawing.Point(107, 124);
            this.gpbTipo.Name = "gpbTipo";
            this.gpbTipo.Size = new System.Drawing.Size(169, 36);
            this.gpbTipo.TabIndex = 41;
            this.gpbTipo.TabStop = false;
            this.gpbTipo.Text = "Tipo";
            // 
            // chkHospitalar
            // 
            this.chkHospitalar.AutoSize = true;
            this.chkHospitalar.Checked = true;
            this.chkHospitalar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHospitalar.Location = new System.Drawing.Point(92, 19);
            this.chkHospitalar.Name = "chkHospitalar";
            this.chkHospitalar.Size = new System.Drawing.Size(73, 17);
            this.chkHospitalar.TabIndex = 1;
            this.chkHospitalar.Text = "Hospitalar";
            this.chkHospitalar.UseVisualStyleBackColor = true;
            // 
            // chkOncologico
            // 
            this.chkOncologico.AutoSize = true;
            this.chkOncologico.Checked = true;
            this.chkOncologico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOncologico.Location = new System.Drawing.Point(6, 19);
            this.chkOncologico.Name = "chkOncologico";
            this.chkOncologico.Size = new System.Drawing.Size(80, 17);
            this.chkOncologico.TabIndex = 0;
            this.chkOncologico.Text = "Oncológico";
            this.chkOncologico.UseVisualStyleBackColor = true;
            // 
            // lblMaiorQue
            // 
            this.lblMaiorQue.AutoSize = true;
            this.lblMaiorQue.Location = new System.Drawing.Point(12, 124);
            this.lblMaiorQue.Name = "lblMaiorQue";
            this.lblMaiorQue.Size = new System.Drawing.Size(89, 13);
            this.lblMaiorQue.TabIndex = 40;
            this.lblMaiorQue.Text = "Estoque mair que";
            // 
            // txtEstoque
            // 
            this.txtEstoque.Location = new System.Drawing.Point(15, 140);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(81, 20);
            this.txtEstoque.TabIndex = 35;
            // 
            // txtCodFabricante
            // 
            this.txtCodFabricante.Location = new System.Drawing.Point(15, 101);
            this.txtCodFabricante.Name = "txtCodFabricante";
            this.txtCodFabricante.Size = new System.Drawing.Size(72, 20);
            this.txtCodFabricante.TabIndex = 33;
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(12, 85);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(100, 13);
            this.lblFabricante.TabIndex = 39;
            this.lblFabricante.Text = "Filtro por Fabricante";
            // 
            // lblProdutoGenerico
            // 
            this.lblProdutoGenerico.AutoSize = true;
            this.lblProdutoGenerico.Location = new System.Drawing.Point(12, 48);
            this.lblProdutoGenerico.Name = "lblProdutoGenerico";
            this.lblProdutoGenerico.Size = new System.Drawing.Size(179, 13);
            this.lblProdutoGenerico.TabIndex = 38;
            this.lblProdutoGenerico.Text = "Filtro por Nome Genérico do Produto";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(12, 9);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(87, 13);
            this.lblProduto.TabIndex = 37;
            this.lblProduto.Text = "Filtro por Produto";
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Location = new System.Drawing.Point(15, 25);
            this.txtCodProduto.MaxLength = 12;
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.Size = new System.Drawing.Size(72, 20);
            this.txtCodProduto.TabIndex = 30;
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.Location = new System.Drawing.Point(93, 25);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.Size = new System.Drawing.Size(383, 20);
            this.txtDescricaoProduto.TabIndex = 31;
            // 
            // txtProdutoGenerico
            // 
            this.txtProdutoGenerico.Location = new System.Drawing.Point(15, 62);
            this.txtProdutoGenerico.Name = "txtProdutoGenerico";
            this.txtProdutoGenerico.Size = new System.Drawing.Size(461, 20);
            this.txtProdutoGenerico.TabIndex = 32;
            // 
            // txtDescricaoFabricante
            // 
            this.txtDescricaoFabricante.Location = new System.Drawing.Point(93, 101);
            this.txtDescricaoFabricante.Name = "txtDescricaoFabricante";
            this.txtDescricaoFabricante.Size = new System.Drawing.Size(383, 20);
            this.txtDescricaoFabricante.TabIndex = 34;
            // 
            // lblLocalizacao
            // 
            this.lblLocalizacao.AutoSize = true;
            this.lblLocalizacao.Location = new System.Drawing.Point(125, 18);
            this.lblLocalizacao.Name = "lblLocalizacao";
            this.lblLocalizacao.Size = new System.Drawing.Size(64, 13);
            this.lblLocalizacao.TabIndex = 56;
            this.lblLocalizacao.Text = "Localização";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(13, 18);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 54;
            this.lblTipo.Text = "Tipo";
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(15, 166);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.Size = new System.Drawing.Size(1220, 360);
            this.dgvData.TabIndex = 57;
            this.dgvData.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvData_Scroll);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(1160, 529);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 58;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // lblVencimento
            // 
            this.lblVencimento.AutoSize = true;
            this.lblVencimento.Location = new System.Drawing.Point(272, 18);
            this.lblVencimento.Name = "lblVencimento";
            this.lblVencimento.Size = new System.Drawing.Size(63, 13);
            this.lblVencimento.TabIndex = 104;
            this.lblVencimento.Text = "Vencimento";
            // 
            // btnUltimasVendas
            // 
            this.btnUltimasVendas.Location = new System.Drawing.Point(12, 529);
            this.btnUltimasVendas.Name = "btnUltimasVendas";
            this.btnUltimasVendas.Size = new System.Drawing.Size(96, 23);
            this.btnUltimasVendas.TabIndex = 105;
            this.btnUltimasVendas.Text = "Últimas Vendas";
            this.btnUltimasVendas.UseVisualStyleBackColor = true;
            // 
            // btnLotes
            // 
            this.btnLotes.Location = new System.Drawing.Point(114, 529);
            this.btnLotes.Name = "btnLotes";
            this.btnLotes.Size = new System.Drawing.Size(96, 23);
            this.btnLotes.TabIndex = 106;
            this.btnLotes.Text = "Lotes";
            this.btnLotes.UseVisualStyleBackColor = true;
            // 
            // txtVencimento
            // 
            this.txtVencimento.Location = new System.Drawing.Point(272, 36);
            this.txtVencimento.Name = "txtVencimento";
            this.txtVencimento.Size = new System.Drawing.Size(107, 20);
            this.txtVencimento.TabIndex = 62;
            // 
            // txtLocalizacao
            // 
            this.txtLocalizacao.Location = new System.Drawing.Point(128, 36);
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.Size = new System.Drawing.Size(138, 20);
            this.txtLocalizacao.TabIndex = 61;
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(15, 36);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(107, 20);
            this.txtTipo.TabIndex = 60;
            // 
            // txtUltimaEntrada
            // 
            this.txtUltimaEntrada.Location = new System.Drawing.Point(16, 84);
            this.txtUltimaEntrada.Name = "txtUltimaEntrada";
            this.txtUltimaEntrada.Size = new System.Drawing.Size(106, 20);
            this.txtUltimaEntrada.TabIndex = 56;
            // 
            // lblUltimaEntrada
            // 
            this.lblUltimaEntrada.AutoSize = true;
            this.lblUltimaEntrada.Location = new System.Drawing.Point(14, 68);
            this.lblUltimaEntrada.Name = "lblUltimaEntrada";
            this.lblUltimaEntrada.Size = new System.Drawing.Size(61, 13);
            this.lblUltimaEntrada.TabIndex = 57;
            this.lblUltimaEntrada.Text = "Última Entr.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTipo);
            this.groupBox1.Controls.Add(this.txtVencimento);
            this.groupBox1.Controls.Add(this.lblUltimaEntrada);
            this.groupBox1.Controls.Add(this.txtLocalizacao);
            this.groupBox1.Controls.Add(this.txtUltimaEntrada);
            this.groupBox1.Controls.Add(this.lblLocalizacao);
            this.groupBox1.Controls.Add(this.lblTipo);
            this.groupBox1.Controls.Add(this.lblVencimento);
            this.groupBox1.Location = new System.Drawing.Point(482, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 125);
            this.groupBox1.TabIndex = 107;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações Adicionais";
            // 
            // frmConsultaDePrecos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 554);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLotes);
            this.Controls.Add(this.btnUltimasVendas);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.gpbTipo);
            this.Controls.Add(this.lblMaiorQue);
            this.Controls.Add(this.txtEstoque);
            this.Controls.Add(this.txtCodFabricante);
            this.Controls.Add(this.lblFabricante);
            this.Controls.Add(this.lblProdutoGenerico);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.txtCodProduto);
            this.Controls.Add(this.txtDescricaoProduto);
            this.Controls.Add(this.txtProdutoGenerico);
            this.Controls.Add(this.txtDescricaoFabricante);
            this.Name = "frmConsultaDePrecos";
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Text = "Precificação";
            this.gpbTipo.ResumeLayout(false);
            this.gpbTipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gpbTipo;
        private System.Windows.Forms.CheckBox chkHospitalar;
        private System.Windows.Forms.CheckBox chkOncologico;
        private System.Windows.Forms.Label lblMaiorQue;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.TextBox txtCodFabricante;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.Label lblProdutoGenerico;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtCodProduto;
        private System.Windows.Forms.TextBox txtDescricaoProduto;
        private System.Windows.Forms.TextBox txtProdutoGenerico;
        private System.Windows.Forms.TextBox txtDescricaoFabricante;
        private System.Windows.Forms.Label lblLocalizacao;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblVencimento;
        private System.Windows.Forms.Button btnUltimasVendas;
        private System.Windows.Forms.Button btnLotes;
        private System.Windows.Forms.TextBox txtUltimaEntrada;
        private System.Windows.Forms.Label lblUltimaEntrada;
        private System.Windows.Forms.TextBox txtVencimento;
        private System.Windows.Forms.TextBox txtLocalizacao;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}