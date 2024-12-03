namespace UHC3_Definitive_Version.App.ModVendas.Pedidos
{
    partial class frmPedidoBayerInterplayers
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
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPostarPedido = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblProdutos = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.lblPedidoCliente = new System.Windows.Forms.Label();
            this.txtPedidoCliente = new System.Windows.Forms.TextBox();
            this.lblDataProgramada = new System.Windows.Forms.Label();
            this.dtpDataProgramada = new System.Windows.Forms.DateTimePicker();
            this.btnMoreFornecedores = new System.Windows.Forms.Button();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.txtFornecedorId = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemover
            // 
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.Location = new System.Drawing.Point(46, 417);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(25, 23);
            this.btnRemover.TabIndex = 23;
            this.btnRemover.Text = "-";
            this.btnRemover.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(15, 417);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnPostarPedido
            // 
            this.btnPostarPedido.Location = new System.Drawing.Point(605, 421);
            this.btnPostarPedido.Name = "btnPostarPedido";
            this.btnPostarPedido.Size = new System.Drawing.Size(102, 23);
            this.btnPostarPedido.TabIndex = 24;
            this.btnPostarPedido.Text = "Postar pedido";
            this.btnPostarPedido.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(713, 421);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblProdutos
            // 
            this.lblProdutos.AutoSize = true;
            this.lblProdutos.Location = new System.Drawing.Point(12, 86);
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(49, 13);
            this.lblProdutos.TabIndex = 30;
            this.lblProdutos.Text = "Produtos";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(15, 102);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(773, 313);
            this.dgvData.TabIndex = 29;
            // 
            // lblPedidoCliente
            // 
            this.lblPedidoCliente.AutoSize = true;
            this.lblPedidoCliente.Location = new System.Drawing.Point(115, 46);
            this.lblPedidoCliente.Name = "lblPedidoCliente";
            this.lblPedidoCliente.Size = new System.Drawing.Size(82, 13);
            this.lblPedidoCliente.TabIndex = 28;
            this.lblPedidoCliente.Text = "Pedido Cliente *";
            // 
            // txtPedidoCliente
            // 
            this.txtPedidoCliente.Location = new System.Drawing.Point(118, 62);
            this.txtPedidoCliente.Name = "txtPedidoCliente";
            this.txtPedidoCliente.Size = new System.Drawing.Size(126, 20);
            this.txtPedidoCliente.TabIndex = 21;
            // 
            // lblDataProgramada
            // 
            this.lblDataProgramada.AutoSize = true;
            this.lblDataProgramada.Location = new System.Drawing.Point(12, 46);
            this.lblDataProgramada.Name = "lblDataProgramada";
            this.lblDataProgramada.Size = new System.Drawing.Size(90, 13);
            this.lblDataProgramada.TabIndex = 27;
            this.lblDataProgramada.Text = "Data Programada";
            // 
            // dtpDataProgramada
            // 
            this.dtpDataProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataProgramada.Location = new System.Drawing.Point(15, 62);
            this.dtpDataProgramada.Name = "dtpDataProgramada";
            this.dtpDataProgramada.Size = new System.Drawing.Size(97, 20);
            this.dtpDataProgramada.TabIndex = 20;
            // 
            // btnMoreFornecedores
            // 
            this.btnMoreFornecedores.Location = new System.Drawing.Point(577, 22);
            this.btnMoreFornecedores.Name = "btnMoreFornecedores";
            this.btnMoreFornecedores.Size = new System.Drawing.Size(24, 23);
            this.btnMoreFornecedores.TabIndex = 19;
            this.btnMoreFornecedores.Text = "...";
            this.btnMoreFornecedores.UseVisualStyleBackColor = true;
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(86, 23);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Size = new System.Drawing.Size(485, 20);
            this.txtFornecedor.TabIndex = 18;
            // 
            // txtFornecedorId
            // 
            this.txtFornecedorId.Location = new System.Drawing.Point(15, 23);
            this.txtFornecedorId.Name = "txtFornecedorId";
            this.txtFornecedorId.Size = new System.Drawing.Size(65, 20);
            this.txtFornecedorId.TabIndex = 17;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 7);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(68, 13);
            this.lblCustomer.TabIndex = 26;
            this.lblCustomer.Text = "Fornecedor *";
            // 
            // frmPedidoBayerInterplayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPostarPedido);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblProdutos);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.lblPedidoCliente);
            this.Controls.Add(this.txtPedidoCliente);
            this.Controls.Add(this.lblDataProgramada);
            this.Controls.Add(this.dtpDataProgramada);
            this.Controls.Add(this.btnMoreFornecedores);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.txtFornecedorId);
            this.Controls.Add(this.lblCustomer);
            this.Name = "frmPedidoBayerInterplayers";
            this.Text = "Postar Pedido Bayer na Interplayers";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPostarPedido;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblProdutos;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lblPedidoCliente;
        private System.Windows.Forms.TextBox txtPedidoCliente;
        private System.Windows.Forms.Label lblDataProgramada;
        private System.Windows.Forms.DateTimePicker dtpDataProgramada;
        private System.Windows.Forms.Button btnMoreFornecedores;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.TextBox txtFornecedorId;
        private System.Windows.Forms.Label lblCustomer;
    }
}