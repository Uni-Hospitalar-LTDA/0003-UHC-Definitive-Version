namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    partial class frmAcessoRestrito_HistoricoDetalhado
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dtp0 = new System.Windows.Forms.DateTimePicker();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnRestricoes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gpbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 84);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(776, 332);
            this.dgvData.TabIndex = 2;
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.btnFiltrar);
            this.gpbFiltros.Controls.Add(this.dtp0);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 24);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(197, 54);
            this.gpbFiltros.TabIndex = 3;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(107, 18);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Pesquisar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // dtp0
            // 
            this.dtp0.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp0.Location = new System.Drawing.Point(6, 19);
            this.dtp0.Name = "dtp0";
            this.dtp0.Size = new System.Drawing.Size(95, 20);
            this.dtp0.TabIndex = 2;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(713, 422);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // btnVendas
            // 
            this.btnVendas.Location = new System.Drawing.Point(652, 55);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(136, 23);
            this.btnVendas.TabIndex = 5;
            this.btnVendas.Text = "Vendas";
            this.btnVendas.UseVisualStyleBackColor = true;
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(510, 55);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(136, 23);
            this.btnClientes.TabIndex = 6;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            // 
            // btnProdutos
            // 
            this.btnProdutos.Location = new System.Drawing.Point(368, 55);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(136, 23);
            this.btnProdutos.TabIndex = 7;
            this.btnProdutos.Text = "Produtos";
            this.btnProdutos.UseVisualStyleBackColor = true;
            // 
            // btnRestricoes
            // 
            this.btnRestricoes.Location = new System.Drawing.Point(226, 55);
            this.btnRestricoes.Name = "btnRestricoes";
            this.btnRestricoes.Size = new System.Drawing.Size(136, 23);
            this.btnRestricoes.TabIndex = 8;
            this.btnRestricoes.Text = "Restrições";
            this.btnRestricoes.UseVisualStyleBackColor = true;
            // 
            // frmAcessoRestrito_HistoricoDetalhado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRestricoes);
            this.Controls.Add(this.btnProdutos);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnVendas);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gpbFiltros);
            this.Controls.Add(this.dgvData);
            this.Name = "frmAcessoRestrito_HistoricoDetalhado";
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
            this.Text = "Histórico Detalhado";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gpbFiltros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DateTimePicker dtp0;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnVendas;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Button btnRestricoes;
    }
}