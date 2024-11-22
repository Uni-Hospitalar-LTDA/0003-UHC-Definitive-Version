namespace UHC3_Definitive_Version.App.ModLicitacao.AnaliseVendas
{
    partial class frmInformativoDeProdutos
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
            this.lblItemSelecionado = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblPaginas = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.cbxVendas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gpbTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItemSelecionado
            // 
            this.lblItemSelecionado.AutoSize = true;
            this.lblItemSelecionado.Location = new System.Drawing.Point(10, 162);
            this.lblItemSelecionado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItemSelecionado.Name = "lblItemSelecionado";
            this.lblItemSelecionado.Size = new System.Drawing.Size(56, 13);
            this.lblItemSelecionado.TabIndex = 57;
            this.lblItemSelecionado.Text = "Itens (0/0)";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(467, 154);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(56, 19);
            this.btnPrevious.TabIndex = 56;
            this.btnPrevious.Text = "Anterior";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // lblPaginas
            // 
            this.lblPaginas.AutoSize = true;
            this.lblPaginas.Location = new System.Drawing.Point(490, 138);
            this.lblPaginas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaginas.Name = "lblPaginas";
            this.lblPaginas.Size = new System.Drawing.Size(74, 13);
            this.lblPaginas.TabIndex = 55;
            this.lblPaginas.Text = "Paginas: (0/0)";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(527, 154);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(56, 19);
            this.btnNext.TabIndex = 54;
            this.btnNext.Text = "Próximo";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Location = new System.Drawing.Point(13, 505);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(93, 13);
            this.lblLastUpdate.TabIndex = 53;
            this.lblLastUpdate.Text = "Última atualização";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(936, 508);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 45;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // cbxVendas
            // 
            this.cbxVendas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVendas.FormattingEnabled = true;
            this.cbxVendas.Location = new System.Drawing.Point(283, 137);
            this.cbxVendas.Name = "cbxVendas";
            this.cbxVendas.Size = new System.Drawing.Size(121, 21);
            this.cbxVendas.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Vendas para o:";
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(13, 179);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.Size = new System.Drawing.Size(999, 323);
            this.dgvData.TabIndex = 46;
            // 
            // gpbTipo
            // 
            this.gpbTipo.Controls.Add(this.chkHospitalar);
            this.gpbTipo.Controls.Add(this.chkOncologico);
            this.gpbTipo.Location = new System.Drawing.Point(105, 122);
            this.gpbTipo.Name = "gpbTipo";
            this.gpbTipo.Size = new System.Drawing.Size(169, 36);
            this.gpbTipo.TabIndex = 51;
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
            this.lblMaiorQue.Location = new System.Drawing.Point(10, 122);
            this.lblMaiorQue.Name = "lblMaiorQue";
            this.lblMaiorQue.Size = new System.Drawing.Size(89, 13);
            this.lblMaiorQue.TabIndex = 50;
            this.lblMaiorQue.Text = "Estoque mair que";
            // 
            // txtEstoque
            // 
            this.txtEstoque.Location = new System.Drawing.Point(13, 138);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(81, 20);
            this.txtEstoque.TabIndex = 43;
            // 
            // txtCodFabricante
            // 
            this.txtCodFabricante.Location = new System.Drawing.Point(13, 99);
            this.txtCodFabricante.Name = "txtCodFabricante";
            this.txtCodFabricante.Size = new System.Drawing.Size(72, 20);
            this.txtCodFabricante.TabIndex = 41;
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(10, 83);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(100, 13);
            this.lblFabricante.TabIndex = 49;
            this.lblFabricante.Text = "Filtro por Fabricante";
            // 
            // lblProdutoGenerico
            // 
            this.lblProdutoGenerico.AutoSize = true;
            this.lblProdutoGenerico.Location = new System.Drawing.Point(10, 46);
            this.lblProdutoGenerico.Name = "lblProdutoGenerico";
            this.lblProdutoGenerico.Size = new System.Drawing.Size(179, 13);
            this.lblProdutoGenerico.TabIndex = 48;
            this.lblProdutoGenerico.Text = "Filtro por Nome Genérico do Produto";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(10, 7);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(87, 13);
            this.lblProduto.TabIndex = 47;
            this.lblProduto.Text = "Filtro por Produto";
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Location = new System.Drawing.Point(13, 23);
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.Size = new System.Drawing.Size(72, 20);
            this.txtCodProduto.TabIndex = 38;
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.Location = new System.Drawing.Point(91, 23);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.Size = new System.Drawing.Size(383, 20);
            this.txtDescricaoProduto.TabIndex = 39;
            // 
            // txtProdutoGenerico
            // 
            this.txtProdutoGenerico.Location = new System.Drawing.Point(13, 60);
            this.txtProdutoGenerico.Name = "txtProdutoGenerico";
            this.txtProdutoGenerico.Size = new System.Drawing.Size(461, 20);
            this.txtProdutoGenerico.TabIndex = 40;
            // 
            // txtDescricaoFabricante
            // 
            this.txtDescricaoFabricante.Location = new System.Drawing.Point(91, 99);
            this.txtDescricaoFabricante.Name = "txtDescricaoFabricante";
            this.txtDescricaoFabricante.Size = new System.Drawing.Size(383, 20);
            this.txtDescricaoFabricante.TabIndex = 42;
            // 
            // frmInformativoDeProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 539);
            this.Controls.Add(this.lblItemSelecionado);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblPaginas);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.cbxVendas);
            this.Controls.Add(this.label1);
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
            this.Name = "frmInformativoDeProdutos";
            this.Text = "Detalhes do Pedido";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gpbTipo.ResumeLayout(false);
            this.gpbTipo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemSelecionado;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblPaginas;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ComboBox cbxVendas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvData;
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
    }
}