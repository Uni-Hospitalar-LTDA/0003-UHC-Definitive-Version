namespace UHC3_Definitive_Version.App.ModVendas.Pedidos
{
    partial class frmInstanciaDePedidos
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
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lblDataPedido = new System.Windows.Forms.Label();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.txtFiltroGenerico = new System.Windows.Forms.TextBox();
            this.lblFiltroGenerico = new System.Windows.Forms.Label();
            this.btnPostarPrePedido = new System.Windows.Forms.Button();
            this.btnProcessarPedido = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.btnFiltrar);
            this.gpbFiltros.Controls.Add(this.lblDataPedido);
            this.gpbFiltros.Controls.Add(this.dtpDataFinal);
            this.gpbFiltros.Controls.Add(this.dtpDataInicial);
            this.gpbFiltros.Controls.Add(this.txtFiltroGenerico);
            this.gpbFiltros.Controls.Add(this.lblFiltroGenerico);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(331, 115);
            this.gpbFiltros.TabIndex = 0;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(243, 69);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 9;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // lblDataPedido
            // 
            this.lblDataPedido.AutoSize = true;
            this.lblDataPedido.Location = new System.Drawing.Point(6, 55);
            this.lblDataPedido.Name = "lblDataPedido";
            this.lblDataPedido.Size = new System.Drawing.Size(66, 13);
            this.lblDataPedido.TabIndex = 8;
            this.lblDataPedido.Text = "Data Pedido";
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFinal.Location = new System.Drawing.Point(112, 71);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(100, 20);
            this.dtpDataFinal.TabIndex = 7;
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicial.Location = new System.Drawing.Point(6, 71);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(100, 20);
            this.dtpDataInicial.TabIndex = 6;
            // 
            // txtFiltroGenerico
            // 
            this.txtFiltroGenerico.Location = new System.Drawing.Point(6, 32);
            this.txtFiltroGenerico.Name = "txtFiltroGenerico";
            this.txtFiltroGenerico.Size = new System.Drawing.Size(312, 20);
            this.txtFiltroGenerico.TabIndex = 1;
            // 
            // lblFiltroGenerico
            // 
            this.lblFiltroGenerico.AutoSize = true;
            this.lblFiltroGenerico.Location = new System.Drawing.Point(6, 16);
            this.lblFiltroGenerico.Name = "lblFiltroGenerico";
            this.lblFiltroGenerico.Size = new System.Drawing.Size(75, 13);
            this.lblFiltroGenerico.TabIndex = 0;
            this.lblFiltroGenerico.Text = "Filtro Genérico";
            // 
            // btnPostarPrePedido
            // 
            this.btnPostarPrePedido.Location = new System.Drawing.Point(670, 134);
            this.btnPostarPrePedido.Name = "btnPostarPrePedido";
            this.btnPostarPrePedido.Size = new System.Drawing.Size(118, 23);
            this.btnPostarPrePedido.TabIndex = 10;
            this.btnPostarPrePedido.Text = "Postar pré-pedido";
            this.btnPostarPrePedido.UseVisualStyleBackColor = true;
            // 
            // btnProcessarPedido
            // 
            this.btnProcessarPedido.Location = new System.Drawing.Point(548, 134);
            this.btnProcessarPedido.Name = "btnProcessarPedido";
            this.btnProcessarPedido.Size = new System.Drawing.Size(116, 23);
            this.btnProcessarPedido.TabIndex = 11;
            this.btnProcessarPedido.Text = "Processar Pedido";
            this.btnProcessarPedido.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(713, 415);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 13;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 163);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(776, 246);
            this.dgvData.TabIndex = 14;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 134);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(331, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // frmInstanciaDePedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnProcessarPedido);
            this.Controls.Add(this.btnPostarPrePedido);
            this.Controls.Add(this.gpbFiltros);
            this.Name = "frmInstanciaDePedidos";
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
            this.Text = "Instância de Pedidos";
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Label lblDataPedido;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.TextBox txtFiltroGenerico;
        private System.Windows.Forms.Label lblFiltroGenerico;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnPostarPrePedido;
        private System.Windows.Forms.Button btnProcessarPedido;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}