namespace UHC3_Definitive_Version.App.ModVendas.Consultas
{
    partial class frmConsultaDeprecos_NewDetalhamentoProduto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.gpbFilters = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.gpbHistDeVendas = new System.Windows.Forms.GroupBox();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.lbliWant = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbFilters.SuspendLayout();
            this.gpbHistDeVendas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.BackColor = System.Drawing.Color.Gainsboro;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(12, 9);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(108, 25);
            this.lblProduto.TabIndex = 37;
            this.lblProduto.Text = "Produto: ";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(12, 33);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(41, 20);
            this.txtCustomerId.TabIndex = 42;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(59, 33);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(467, 20);
            this.txtCustomer.TabIndex = 41;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(6, 16);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 40;
            this.lblCliente.Text = "Cliente";
            // 
            // gpbFilters
            // 
            this.gpbFilters.Controls.Add(this.label1);
            this.gpbFilters.Controls.Add(this.lbliWant);
            this.gpbFilters.Controls.Add(this.txtTop);
            this.gpbFilters.Controls.Add(this.btnFilter);
            this.gpbFilters.Controls.Add(this.lblCliente);
            this.gpbFilters.Controls.Add(this.txtCustomerId);
            this.gpbFilters.Controls.Add(this.txtCustomer);
            this.gpbFilters.Location = new System.Drawing.Point(12, 37);
            this.gpbFilters.Name = "gpbFilters";
            this.gpbFilters.Size = new System.Drawing.Size(538, 89);
            this.gpbFilters.TabIndex = 43;
            this.gpbFilters.TabStop = false;
            this.gpbFilters.Text = "Filtros";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(451, 59);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 43;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // gpbHistDeVendas
            // 
            this.gpbHistDeVendas.Controls.Add(this.dgvHistorico);
            this.gpbHistDeVendas.Location = new System.Drawing.Point(12, 132);
            this.gpbHistDeVendas.Name = "gpbHistDeVendas";
            this.gpbHistDeVendas.Size = new System.Drawing.Size(917, 344);
            this.gpbHistDeVendas.TabIndex = 44;
            this.gpbHistDeVendas.TabStop = false;
            this.gpbHistDeVendas.Text = "Histórico de vendas";
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.AllowUserToAddRows = false;
            this.dgvHistorico.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHistorico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorico.Location = new System.Drawing.Point(3, 16);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.ReadOnly = true;
            this.dgvHistorico.RowHeadersVisible = false;
            this.dgvHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorico.Size = new System.Drawing.Size(911, 325);
            this.dgvHistorico.TabIndex = 3;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(851, 479);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 45;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(131, 65);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(41, 20);
            this.txtTop.TabIndex = 44;
            // 
            // lbliWant
            // 
            this.lbliWant.AutoSize = true;
            this.lbliWant.Location = new System.Drawing.Point(12, 68);
            this.lbliWant.Name = "lbliWant";
            this.lbliWant.Size = new System.Drawing.Size(117, 13);
            this.lbliWant.TabIndex = 45;
            this.lbliWant.Text = "Eu quero ver as últimas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "vendas.";
            // 
            // frmConsultaDeprecos_NewDetalhamentoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 511);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gpbHistDeVendas);
            this.Controls.Add(this.gpbFilters);
            this.Controls.Add(this.lblProduto);
            this.Name = "frmConsultaDeprecos_NewDetalhamentoProduto";
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Text = "Últimas Vendas";
            this.gpbFilters.ResumeLayout(false);
            this.gpbFilters.PerformLayout();
            this.gpbHistDeVendas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.GroupBox gpbFilters;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox gpbHistDeVendas;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbliWant;
        private System.Windows.Forms.TextBox txtTop;
    }
}