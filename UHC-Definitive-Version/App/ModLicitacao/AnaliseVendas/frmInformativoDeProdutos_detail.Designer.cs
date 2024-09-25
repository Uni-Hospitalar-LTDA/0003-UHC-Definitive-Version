namespace UHC3_Definitive_Version.App.ModLicitacao.AnaliseVendas
{
    partial class frmInformativoDeProdutos_detail
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
            this.lblMediaPreco = new System.Windows.Forms.Label();
            this.txtMediaPreco = new System.Windows.Forms.TextBox();
            this.cbxEsfera = new System.Windows.Forms.ComboBox();
            this.lblEsfera = new System.Windows.Forms.Label();
            this.gpbLotes = new System.Windows.Forms.GroupBox();
            this.dgvLotes = new System.Windows.Forms.DataGridView();
            this.gpbHistDeVendas = new System.Windows.Forms.GroupBox();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.lblUltimaEntrada = new System.Windows.Forms.Label();
            this.txtPrcUltimaEntrada = new System.Windows.Forms.TextBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.txtDescricaoCliente = new System.Windows.Forms.TextBox();
            this.gpbLotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
            this.gpbHistDeVendas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMediaPreco
            // 
            this.lblMediaPreco.AutoSize = true;
            this.lblMediaPreco.Location = new System.Drawing.Point(708, 49);
            this.lblMediaPreco.Name = "lblMediaPreco";
            this.lblMediaPreco.Size = new System.Drawing.Size(82, 13);
            this.lblMediaPreco.TabIndex = 60;
            this.lblMediaPreco.Text = "Média de Preço";
            // 
            // txtMediaPreco
            // 
            this.txtMediaPreco.Location = new System.Drawing.Point(711, 65);
            this.txtMediaPreco.Name = "txtMediaPreco";
            this.txtMediaPreco.Size = new System.Drawing.Size(72, 20);
            this.txtMediaPreco.TabIndex = 59;
            // 
            // cbxEsfera
            // 
            this.cbxEsfera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEsfera.FormattingEnabled = true;
            this.cbxEsfera.Location = new System.Drawing.Point(451, 65);
            this.cbxEsfera.Name = "cbxEsfera";
            this.cbxEsfera.Size = new System.Drawing.Size(121, 21);
            this.cbxEsfera.TabIndex = 47;
            // 
            // lblEsfera
            // 
            this.lblEsfera.AutoSize = true;
            this.lblEsfera.Location = new System.Drawing.Point(448, 50);
            this.lblEsfera.Name = "lblEsfera";
            this.lblEsfera.Size = new System.Drawing.Size(37, 13);
            this.lblEsfera.TabIndex = 58;
            this.lblEsfera.Text = "Esfera";
            // 
            // gpbLotes
            // 
            this.gpbLotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbLotes.Controls.Add(this.dgvLotes);
            this.gpbLotes.Location = new System.Drawing.Point(906, 91);
            this.gpbLotes.Name = "gpbLotes";
            this.gpbLotes.Size = new System.Drawing.Size(264, 243);
            this.gpbLotes.TabIndex = 57;
            this.gpbLotes.TabStop = false;
            this.gpbLotes.Text = "Lotes";
            // 
            // dgvLotes
            // 
            this.dgvLotes.AllowUserToAddRows = false;
            this.dgvLotes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLotes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLotes.Location = new System.Drawing.Point(3, 16);
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.ReadOnly = true;
            this.dgvLotes.RowHeadersVisible = false;
            this.dgvLotes.RowHeadersWidth = 51;
            this.dgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLotes.Size = new System.Drawing.Size(258, 224);
            this.dgvLotes.TabIndex = 0;
            // 
            // gpbHistDeVendas
            // 
            this.gpbHistDeVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbHistDeVendas.Controls.Add(this.dgvHistorico);
            this.gpbHistDeVendas.Location = new System.Drawing.Point(15, 91);
            this.gpbHistDeVendas.Name = "gpbHistDeVendas";
            this.gpbHistDeVendas.Size = new System.Drawing.Size(885, 243);
            this.gpbHistDeVendas.TabIndex = 56;
            this.gpbHistDeVendas.TabStop = false;
            this.gpbHistDeVendas.Text = "Histórico de vendas";
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.AllowUserToAddRows = false;
            this.dgvHistorico.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHistorico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorico.Location = new System.Drawing.Point(3, 16);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.ReadOnly = true;
            this.dgvHistorico.RowHeadersVisible = false;
            this.dgvHistorico.RowHeadersWidth = 51;
            this.dgvHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorico.Size = new System.Drawing.Size(879, 224);
            this.dgvHistorico.TabIndex = 0;
            // 
            // lblUltimaEntrada
            // 
            this.lblUltimaEntrada.AutoSize = true;
            this.lblUltimaEntrada.Location = new System.Drawing.Point(630, 49);
            this.lblUltimaEntrada.Name = "lblUltimaEntrada";
            this.lblUltimaEntrada.Size = new System.Drawing.Size(75, 13);
            this.lblUltimaEntrada.TabIndex = 55;
            this.lblUltimaEntrada.Text = "Última entrada";
            // 
            // txtPrcUltimaEntrada
            // 
            this.txtPrcUltimaEntrada.Location = new System.Drawing.Point(633, 65);
            this.txtPrcUltimaEntrada.Name = "txtPrcUltimaEntrada";
            this.txtPrcUltimaEntrada.Size = new System.Drawing.Size(72, 20);
            this.txtPrcUltimaEntrada.TabIndex = 54;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(1086, 340);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 48;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(12, 10);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(44, 13);
            this.lblProduto.TabIndex = 53;
            this.lblProduto.Text = "Produto";
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Location = new System.Drawing.Point(15, 26);
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.Size = new System.Drawing.Size(72, 20);
            this.txtCodProduto.TabIndex = 51;
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.Location = new System.Drawing.Point(93, 26);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.Size = new System.Drawing.Size(352, 20);
            this.txtDescricaoProduto.TabIndex = 52;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(15, 65);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(72, 20);
            this.txtCodCliente.TabIndex = 46;
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(12, 49);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(82, 13);
            this.lblFabricante.TabIndex = 50;
            this.lblFabricante.Text = "Filtro por Cliente";
            // 
            // txtDescricaoCliente
            // 
            this.txtDescricaoCliente.Location = new System.Drawing.Point(93, 65);
            this.txtDescricaoCliente.Name = "txtDescricaoCliente";
            this.txtDescricaoCliente.Size = new System.Drawing.Size(352, 20);
            this.txtDescricaoCliente.TabIndex = 49;
            // 
            // frmInformativoDeProdutos_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 373);
            this.Controls.Add(this.lblMediaPreco);
            this.Controls.Add(this.txtMediaPreco);
            this.Controls.Add(this.cbxEsfera);
            this.Controls.Add(this.lblEsfera);
            this.Controls.Add(this.gpbLotes);
            this.Controls.Add(this.gpbHistDeVendas);
            this.Controls.Add(this.lblUltimaEntrada);
            this.Controls.Add(this.txtPrcUltimaEntrada);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.txtCodProduto);
            this.Controls.Add(this.txtDescricaoProduto);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.lblFabricante);
            this.Controls.Add(this.txtDescricaoCliente);
            this.Name = "frmInformativoDeProdutos_detail";
            this.Text = "Detalhe dos Produtos";
            this.gpbLotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            this.gpbHistDeVendas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMediaPreco;
        private System.Windows.Forms.TextBox txtMediaPreco;
        private System.Windows.Forms.ComboBox cbxEsfera;
        private System.Windows.Forms.Label lblEsfera;
        private System.Windows.Forms.GroupBox gpbLotes;
        private System.Windows.Forms.DataGridView dgvLotes;
        private System.Windows.Forms.GroupBox gpbHistDeVendas;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.Label lblUltimaEntrada;
        private System.Windows.Forms.TextBox txtPrcUltimaEntrada;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtCodProduto;
        private System.Windows.Forms.TextBox txtDescricaoProduto;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.TextBox txtDescricaoCliente;
    }
}