namespace UHC3_Definitive_Version.App.ModVendas.Consultas
{
    partial class frmConsultarPedidoOL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtDescricaoCliente = new System.Windows.Forms.TextBox();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPedidoOL = new System.Windows.Forms.TextBox();
            this.lblPedidoOL = new System.Windows.Forms.Label();
            this.chkNFemitida = new System.Windows.Forms.CheckBox();
            this.chkNFProblema = new System.Windows.Forms.CheckBox();
            this.gpbHistDeVendas = new System.Windows.Forms.GroupBox();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.gpPedidosDoProduto = new System.Windows.Forms.GroupBox();
            this.dgvInfoPedido = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.gpbHistDeVendas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            this.gpPedidosDoProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(9, 8);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(82, 13);
            this.lblCliente.TabIndex = 17;
            this.lblCliente.Text = "Filtro por Cliente";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(12, 24);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(72, 20);
            this.txtCodCliente.TabIndex = 15;
            // 
            // txtDescricaoCliente
            // 
            this.txtDescricaoCliente.Location = new System.Drawing.Point(90, 24);
            this.txtDescricaoCliente.Name = "txtDescricaoCliente";
            this.txtDescricaoCliente.Size = new System.Drawing.Size(383, 20);
            this.txtDescricaoCliente.TabIndex = 16;
            // 
            // txtNF
            // 
            this.txtNF.Location = new System.Drawing.Point(12, 63);
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(72, 20);
            this.txtNF.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "NF";
            // 
            // txtPedidoOL
            // 
            this.txtPedidoOL.Location = new System.Drawing.Point(90, 63);
            this.txtPedidoOL.Name = "txtPedidoOL";
            this.txtPedidoOL.Size = new System.Drawing.Size(137, 20);
            this.txtPedidoOL.TabIndex = 30;
            // 
            // lblPedidoOL
            // 
            this.lblPedidoOL.AutoSize = true;
            this.lblPedidoOL.Location = new System.Drawing.Point(90, 47);
            this.lblPedidoOL.Name = "lblPedidoOL";
            this.lblPedidoOL.Size = new System.Drawing.Size(57, 13);
            this.lblPedidoOL.TabIndex = 31;
            this.lblPedidoOL.Text = "Pedido OL";
            // 
            // chkNFemitida
            // 
            this.chkNFemitida.AutoSize = true;
            this.chkNFemitida.Location = new System.Drawing.Point(233, 50);
            this.chkNFemitida.Name = "chkNFemitida";
            this.chkNFemitida.Size = new System.Drawing.Size(77, 17);
            this.chkNFemitida.TabIndex = 32;
            this.chkNFemitida.Text = "NF Emitida";
            this.chkNFemitida.UseVisualStyleBackColor = true;
            // 
            // chkNFProblema
            // 
            this.chkNFProblema.AutoSize = true;
            this.chkNFProblema.Location = new System.Drawing.Point(233, 73);
            this.chkNFProblema.Name = "chkNFProblema";
            this.chkNFProblema.Size = new System.Drawing.Size(70, 17);
            this.chkNFProblema.TabIndex = 33;
            this.chkNFProblema.Text = "Problema";
            this.chkNFProblema.UseVisualStyleBackColor = true;
            // 
            // gpbHistDeVendas
            // 
            this.gpbHistDeVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbHistDeVendas.Controls.Add(this.dgvHistorico);
            this.gpbHistDeVendas.Location = new System.Drawing.Point(12, 96);
            this.gpbHistDeVendas.Name = "gpbHistDeVendas";
            this.gpbHistDeVendas.Size = new System.Drawing.Size(765, 619);
            this.gpbHistDeVendas.TabIndex = 39;
            this.gpbHistDeVendas.TabStop = false;
            this.gpbHistDeVendas.Text = "Histórico de vendas";
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.AllowUserToAddRows = false;
            this.dgvHistorico.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHistorico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorico.Location = new System.Drawing.Point(3, 16);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.ReadOnly = true;
            this.dgvHistorico.RowHeadersVisible = false;
            this.dgvHistorico.RowHeadersWidth = 51;
            this.dgvHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorico.Size = new System.Drawing.Size(759, 600);
            this.dgvHistorico.TabIndex = 0;
            // 
            // gpPedidosDoProduto
            // 
            this.gpPedidosDoProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpPedidosDoProduto.Controls.Add(this.dgvInfoPedido);
            this.gpPedidosDoProduto.Location = new System.Drawing.Point(783, 96);
            this.gpPedidosDoProduto.Name = "gpPedidosDoProduto";
            this.gpPedidosDoProduto.Size = new System.Drawing.Size(588, 619);
            this.gpPedidosDoProduto.TabIndex = 40;
            this.gpPedidosDoProduto.TabStop = false;
            this.gpPedidosDoProduto.Text = "Pedidos do Produto";
            // 
            // dgvInfoPedido
            // 
            this.dgvInfoPedido.AllowUserToAddRows = false;
            this.dgvInfoPedido.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvInfoPedido.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInfoPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfoPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfoPedido.Location = new System.Drawing.Point(3, 16);
            this.dgvInfoPedido.Name = "dgvInfoPedido";
            this.dgvInfoPedido.ReadOnly = true;
            this.dgvInfoPedido.RowHeadersVisible = false;
            this.dgvInfoPedido.RowHeadersWidth = 51;
            this.dgvInfoPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfoPedido.Size = new System.Drawing.Size(582, 600);
            this.dgvInfoPedido.TabIndex = 0;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(1293, 718);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 41;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // frmConsultarPedidoOL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 749);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gpPedidosDoProduto);
            this.Controls.Add(this.gpbHistDeVendas);
            this.Controls.Add(this.chkNFProblema);
            this.Controls.Add(this.chkNFemitida);
            this.Controls.Add(this.lblPedidoOL);
            this.Controls.Add(this.txtPedidoOL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNF);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.txtDescricaoCliente);
            this.Name = "frmConsultarPedidoOL";
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
            this.Text = "Consultar pedido OL";
            this.gpbHistDeVendas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            this.gpPedidosDoProduto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoPedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TextBox txtDescricaoCliente;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPedidoOL;
        private System.Windows.Forms.Label lblPedidoOL;
        private System.Windows.Forms.CheckBox chkNFemitida;
        private System.Windows.Forms.CheckBox chkNFProblema;
        private System.Windows.Forms.GroupBox gpbHistDeVendas;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.GroupBox gpPedidosDoProduto;
        private System.Windows.Forms.DataGridView dgvInfoPedido;
        private System.Windows.Forms.Button btnFechar;
    }
}