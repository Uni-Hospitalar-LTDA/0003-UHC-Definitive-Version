namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    partial class frmAcessoRestrito_HistoricoDetalhado_LayoutProdutos
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
            this.btnReenviar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.gpbSomadores = new System.Windows.Forms.GroupBox();
            this.txtQtdLinhas = new System.Windows.Forms.TextBox();
            this.qtdLinhas = new System.Windows.Forms.Label();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltroGenerico = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gpbSomadores.SuspendLayout();
            this.gpbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReenviar
            // 
            this.btnReenviar.Location = new System.Drawing.Point(753, 110);
            this.btnReenviar.Name = "btnReenviar";
            this.btnReenviar.Size = new System.Drawing.Size(155, 23);
            this.btnReenviar.TabIndex = 6;
            this.btnReenviar.Text = "Painel de Reenvio";
            this.btnReenviar.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(833, 427);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 7;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 139);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(896, 274);
            this.dgvData.TabIndex = 8;
            // 
            // gpbSomadores
            // 
            this.gpbSomadores.Controls.Add(this.txtQtdLinhas);
            this.gpbSomadores.Controls.Add(this.qtdLinhas);
            this.gpbSomadores.Location = new System.Drawing.Point(442, 33);
            this.gpbSomadores.Name = "gpbSomadores";
            this.gpbSomadores.Size = new System.Drawing.Size(88, 70);
            this.gpbSomadores.TabIndex = 5;
            this.gpbSomadores.TabStop = false;
            this.gpbSomadores.Text = "Somadores";
            // 
            // txtQtdLinhas
            // 
            this.txtQtdLinhas.Location = new System.Drawing.Point(10, 36);
            this.txtQtdLinhas.Name = "txtQtdLinhas";
            this.txtQtdLinhas.Size = new System.Drawing.Size(64, 20);
            this.txtQtdLinhas.TabIndex = 1;
            // 
            // qtdLinhas
            // 
            this.qtdLinhas.AutoSize = true;
            this.qtdLinhas.Location = new System.Drawing.Point(7, 20);
            this.qtdLinhas.Name = "qtdLinhas";
            this.qtdLinhas.Size = new System.Drawing.Size(72, 13);
            this.qtdLinhas.TabIndex = 0;
            this.qtdLinhas.Text = "Qtd. Produtos";
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.btnFiltrar);
            this.gpbFiltros.Controls.Add(this.txtFiltroGenerico);
            this.gpbFiltros.Controls.Add(this.label1);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 33);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(424, 100);
            this.gpbFiltros.TabIndex = 4;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(343, 62);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // txtFiltroGenerico
            // 
            this.txtFiltroGenerico.Location = new System.Drawing.Point(10, 36);
            this.txtFiltroGenerico.Name = "txtFiltroGenerico";
            this.txtFiltroGenerico.Size = new System.Drawing.Size(408, 20);
            this.txtFiltroGenerico.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtro Genérico";
            // 
            // frmAcessoRestrito_HistoricoDetalhado_LayoutProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 456);
            this.Controls.Add(this.btnReenviar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.gpbSomadores);
            this.Controls.Add(this.gpbFiltros);
            this.Name = "frmAcessoRestrito_HistoricoDetalhado_LayoutProdutos";
            this.Text = "IMS - Layout de Produtos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gpbSomadores.ResumeLayout(false);
            this.gpbSomadores.PerformLayout();
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReenviar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox gpbSomadores;
        private System.Windows.Forms.TextBox txtQtdLinhas;
        private System.Windows.Forms.Label qtdLinhas;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtFiltroGenerico;
        private System.Windows.Forms.Label label1;
    }
}