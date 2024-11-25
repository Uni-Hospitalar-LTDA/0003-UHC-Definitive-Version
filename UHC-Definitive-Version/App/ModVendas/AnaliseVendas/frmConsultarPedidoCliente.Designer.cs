namespace UHC3_Definitive_Version.App.ModVendas.Consultas
{
    partial class frmConsultarPedidoCliente
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
            this.gpbProdutosNF = new System.Windows.Forms.GroupBox();
            this.dgvInfoPedido = new System.Windows.Forms.DataGridView();
            this.gpbDadosConsulta = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtDescricaoCliente = new System.Windows.Forms.TextBox();
            this.lblPedidoCliente = new System.Windows.Forms.Label();
            this.txtPedidoCliente = new System.Windows.Forms.TextBox();
            this.gpbProdutosNF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoPedido)).BeginInit();
            this.gpbDadosConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbProdutosNF
            // 
            this.gpbProdutosNF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbProdutosNF.Controls.Add(this.dgvInfoPedido);
            this.gpbProdutosNF.Location = new System.Drawing.Point(815, 87);
            this.gpbProdutosNF.Name = "gpbProdutosNF";
            this.gpbProdutosNF.Size = new System.Drawing.Size(457, 455);
            this.gpbProdutosNF.TabIndex = 42;
            this.gpbProdutosNF.TabStop = false;
            this.gpbProdutosNF.Text = "Produtos da NF";
            // 
            // dgvInfoPedido
            // 
            this.dgvInfoPedido.AllowUserToAddRows = false;
            this.dgvInfoPedido.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvInfoPedido.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInfoPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfoPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfoPedido.Location = new System.Drawing.Point(3, 16);
            this.dgvInfoPedido.Name = "dgvInfoPedido";
            this.dgvInfoPedido.ReadOnly = true;
            this.dgvInfoPedido.RowHeadersVisible = false;
            this.dgvInfoPedido.RowHeadersWidth = 51;
            this.dgvInfoPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfoPedido.Size = new System.Drawing.Size(451, 436);
            this.dgvInfoPedido.TabIndex = 0;
            // 
            // gpbDadosConsulta
            // 
            this.gpbDadosConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbDadosConsulta.Controls.Add(this.dgvData);
            this.gpbDadosConsulta.Location = new System.Drawing.Point(12, 87);
            this.gpbDadosConsulta.Name = "gpbDadosConsulta";
            this.gpbDadosConsulta.Size = new System.Drawing.Size(797, 455);
            this.gpbDadosConsulta.TabIndex = 41;
            this.gpbDadosConsulta.TabStop = false;
            this.gpbDadosConsulta.Text = "Dados da consulta";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 16);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(791, 436);
            this.dgvData.TabIndex = 0;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(1197, 548);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 43;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(12, 7);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(82, 13);
            this.lblCliente.TabIndex = 46;
            this.lblCliente.Text = "Filtro por Cliente";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(15, 23);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(72, 20);
            this.txtCodCliente.TabIndex = 44;
            // 
            // txtDescricaoCliente
            // 
            this.txtDescricaoCliente.Location = new System.Drawing.Point(93, 23);
            this.txtDescricaoCliente.Name = "txtDescricaoCliente";
            this.txtDescricaoCliente.Size = new System.Drawing.Size(383, 20);
            this.txtDescricaoCliente.TabIndex = 45;
            // 
            // lblPedidoCliente
            // 
            this.lblPedidoCliente.AutoSize = true;
            this.lblPedidoCliente.Location = new System.Drawing.Point(15, 45);
            this.lblPedidoCliente.Name = "lblPedidoCliente";
            this.lblPedidoCliente.Size = new System.Drawing.Size(90, 13);
            this.lblPedidoCliente.TabIndex = 48;
            this.lblPedidoCliente.Text = "Pedido do Cliente";
            // 
            // txtPedidoCliente
            // 
            this.txtPedidoCliente.Location = new System.Drawing.Point(15, 61);
            this.txtPedidoCliente.Name = "txtPedidoCliente";
            this.txtPedidoCliente.Size = new System.Drawing.Size(137, 20);
            this.txtPedidoCliente.TabIndex = 47;
            // 
            // frmConsultasPedidoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 577);
            this.Controls.Add(this.lblPedidoCliente);
            this.Controls.Add(this.txtPedidoCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.txtDescricaoCliente);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gpbProdutosNF);
            this.Controls.Add(this.gpbDadosConsulta);
            this.Name = "frmConsultasPedidoCliente";
            this.Text = "Consulta por Pedido de Cliente";
            this.gpbProdutosNF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoPedido)).EndInit();
            this.gpbDadosConsulta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbProdutosNF;
        private System.Windows.Forms.DataGridView dgvInfoPedido;
        private System.Windows.Forms.GroupBox gpbDadosConsulta;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TextBox txtDescricaoCliente;
        private System.Windows.Forms.Label lblPedidoCliente;
        private System.Windows.Forms.TextBox txtPedidoCliente;
    }
}