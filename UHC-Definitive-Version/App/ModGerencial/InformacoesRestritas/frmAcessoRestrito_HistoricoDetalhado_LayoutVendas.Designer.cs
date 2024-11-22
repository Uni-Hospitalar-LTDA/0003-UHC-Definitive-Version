namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    partial class frmAcessoRestrito_HistoricoDetalhado_LayoutVendas
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
            this.txtTotalVendas = new System.Windows.Forms.TextBox();
            this.lblTotalVendas = new System.Windows.Forms.Label();
            this.txtQtdLinhas = new System.Windows.Forms.TextBox();
            this.qtdLinhas = new System.Windows.Forms.Label();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltroGenerico = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVendasSemBloq = new System.Windows.Forms.TextBox();
            this.lblVendasSemBloqueio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gpbSomadores.SuspendLayout();
            this.gpbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReenviar
            // 
            this.btnReenviar.Location = new System.Drawing.Point(750, 105);
            this.btnReenviar.Name = "btnReenviar";
            this.btnReenviar.Size = new System.Drawing.Size(155, 23);
            this.btnReenviar.TabIndex = 11;
            this.btnReenviar.Text = "Painel de Reenvio";
            this.btnReenviar.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(830, 429);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 12;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(9, 134);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(896, 288);
            this.dgvData.TabIndex = 13;
            // 
            // gpbSomadores
            // 
            this.gpbSomadores.Controls.Add(this.txtVendasSemBloq);
            this.gpbSomadores.Controls.Add(this.lblVendasSemBloqueio);
            this.gpbSomadores.Controls.Add(this.txtTotalVendas);
            this.gpbSomadores.Controls.Add(this.lblTotalVendas);
            this.gpbSomadores.Controls.Add(this.txtQtdLinhas);
            this.gpbSomadores.Controls.Add(this.qtdLinhas);
            this.gpbSomadores.Location = new System.Drawing.Point(439, 28);
            this.gpbSomadores.Name = "gpbSomadores";
            this.gpbSomadores.Size = new System.Drawing.Size(232, 70);
            this.gpbSomadores.TabIndex = 10;
            this.gpbSomadores.TabStop = false;
            this.gpbSomadores.Text = "Somadores";
            // 
            // txtTotalVendas
            // 
            this.txtTotalVendas.Location = new System.Drawing.Point(80, 36);
            this.txtTotalVendas.Name = "txtTotalVendas";
            this.txtTotalVendas.Size = new System.Drawing.Size(64, 20);
            this.txtTotalVendas.TabIndex = 3;
            // 
            // lblTotalVendas
            // 
            this.lblTotalVendas.AutoSize = true;
            this.lblTotalVendas.Location = new System.Drawing.Point(77, 20);
            this.lblTotalVendas.Name = "lblTotalVendas";
            this.lblTotalVendas.Size = new System.Drawing.Size(70, 13);
            this.lblTotalVendas.TabIndex = 2;
            this.lblTotalVendas.Text = "Total Vendas";
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
            this.qtdLinhas.Size = new System.Drawing.Size(66, 13);
            this.qtdLinhas.TabIndex = 0;
            this.qtdLinhas.Text = "Qtd. Vendas";
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.btnFiltrar);
            this.gpbFiltros.Controls.Add(this.txtFiltroGenerico);
            this.gpbFiltros.Controls.Add(this.label1);
            this.gpbFiltros.Location = new System.Drawing.Point(9, 28);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(424, 100);
            this.gpbFiltros.TabIndex = 9;
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
            // txtVendasSemBloq
            // 
            this.txtVendasSemBloq.Location = new System.Drawing.Point(150, 36);
            this.txtVendasSemBloq.Name = "txtVendasSemBloq";
            this.txtVendasSemBloq.Size = new System.Drawing.Size(64, 20);
            this.txtVendasSemBloq.TabIndex = 5;
            // 
            // lblVendasSemBloqueio
            // 
            this.lblVendasSemBloqueio.AutoSize = true;
            this.lblVendasSemBloqueio.Location = new System.Drawing.Point(147, 20);
            this.lblVendasSemBloqueio.Name = "lblVendasSemBloqueio";
            this.lblVendasSemBloqueio.Size = new System.Drawing.Size(63, 13);
            this.lblVendasSemBloqueio.TabIndex = 4;
            this.lblVendasSemBloqueio.Text = "Total s Bloq";
            // 
            // frmAcessoRestrito_HistoricoDetalhado_LayoutVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 464);
            this.Controls.Add(this.btnReenviar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.gpbSomadores);
            this.Controls.Add(this.gpbFiltros);
            this.Name = "frmAcessoRestrito_HistoricoDetalhado_LayoutVendas";
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
            this.Text = "IMS - Layout Vendas";
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
        private System.Windows.Forms.TextBox txtTotalVendas;
        private System.Windows.Forms.Label lblTotalVendas;
        private System.Windows.Forms.TextBox txtQtdLinhas;
        private System.Windows.Forms.Label qtdLinhas;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtFiltroGenerico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVendasSemBloq;
        private System.Windows.Forms.Label lblVendasSemBloqueio;
    }
}