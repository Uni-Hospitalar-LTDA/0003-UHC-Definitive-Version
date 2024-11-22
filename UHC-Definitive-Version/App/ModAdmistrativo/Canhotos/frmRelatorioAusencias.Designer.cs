namespace UHC3_Definitive_Version.App.ModAdmistrativo.Canhotos
{
    partial class frmRelatorioAusencias
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
            this.btnNotifyByMail = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.btnMoreTransporter = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblIHasInvoiceStubFilter = new System.Windows.Forms.Label();
            this.lblHasPackedFilter = new System.Windows.Forms.Label();
            this.lblHasPayedsFilter = new System.Windows.Forms.Label();
            this.cbxHasInvoiceStubFilter = new System.Windows.Forms.ComboBox();
            this.cbxHasPackedFilter = new System.Windows.Forms.ComboBox();
            this.cbxHasPayedFilter = new System.Windows.Forms.ComboBox();
            this.lblDat_Emissao = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInitial = new System.Windows.Forms.DateTimePicker();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.txtCodTransportadora = new System.Windows.Forms.TextBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gpbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNotifyByMail
            // 
            this.btnNotifyByMail.Location = new System.Drawing.Point(340, 30);
            this.btnNotifyByMail.Name = "btnNotifyByMail";
            this.btnNotifyByMail.Size = new System.Drawing.Size(165, 23);
            this.btnNotifyByMail.TabIndex = 69;
            this.btnNotifyByMail.Text = "button1";
            this.btnNotifyByMail.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(987, 566);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 67;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 170);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(1050, 390);
            this.dgvData.TabIndex = 66;
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.btnNotifyByMail);
            this.gpbFiltros.Controls.Add(this.btnMoreTransporter);
            this.gpbFiltros.Controls.Add(this.progressBar1);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.lblIHasInvoiceStubFilter);
            this.gpbFiltros.Controls.Add(this.lblHasPackedFilter);
            this.gpbFiltros.Controls.Add(this.lblHasPayedsFilter);
            this.gpbFiltros.Controls.Add(this.cbxHasInvoiceStubFilter);
            this.gpbFiltros.Controls.Add(this.cbxHasPackedFilter);
            this.gpbFiltros.Controls.Add(this.cbxHasPayedFilter);
            this.gpbFiltros.Controls.Add(this.lblDat_Emissao);
            this.gpbFiltros.Controls.Add(this.dtpFinal);
            this.gpbFiltros.Controls.Add(this.dtpInitial);
            this.gpbFiltros.Controls.Add(this.txtTransportadora);
            this.gpbFiltros.Controls.Add(this.txtCodTransportadora);
            this.gpbFiltros.Controls.Add(this.lblTransportadora);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 33);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(540, 131);
            this.gpbFiltros.TabIndex = 56;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // btnMoreTransporter
            // 
            this.btnMoreTransporter.Location = new System.Drawing.Point(511, 54);
            this.btnMoreTransporter.Name = "btnMoreTransporter";
            this.btnMoreTransporter.Size = new System.Drawing.Size(24, 23);
            this.btnMoreTransporter.TabIndex = 70;
            this.btnMoreTransporter.Text = "...";
            this.btnMoreTransporter.UseVisualStyleBackColor = true;
            this.btnMoreTransporter.Click += new System.EventHandler(this.btnMoreTransporter_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(89, 30);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(243, 23);
            this.progressBar1.TabIndex = 68;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(425, 91);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 25);
            this.btnPesquisar.TabIndex = 50;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            // 
            // lblIHasInvoiceStubFilter
            // 
            this.lblIHasInvoiceStubFilter.AutoSize = true;
            this.lblIHasInvoiceStubFilter.Location = new System.Drawing.Point(350, 79);
            this.lblIHasInvoiceStubFilter.Name = "lblIHasInvoiceStubFilter";
            this.lblIHasInvoiceStubFilter.Size = new System.Drawing.Size(53, 13);
            this.lblIHasInvoiceStubFilter.TabIndex = 68;
            this.lblIHasInvoiceStubFilter.Text = "Canhoto?";
            // 
            // lblHasPackedFilter
            // 
            this.lblHasPackedFilter.AutoSize = true;
            this.lblHasPackedFilter.Location = new System.Drawing.Point(281, 79);
            this.lblHasPackedFilter.Name = "lblHasPackedFilter";
            this.lblHasPackedFilter.Size = new System.Drawing.Size(61, 13);
            this.lblHasPackedFilter.TabIndex = 67;
            this.lblHasPackedFilter.Text = "Romaneio?";
            // 
            // lblHasPayedsFilter
            // 
            this.lblHasPayedsFilter.AutoSize = true;
            this.lblHasPayedsFilter.Location = new System.Drawing.Point(206, 79);
            this.lblHasPayedsFilter.Name = "lblHasPayedsFilter";
            this.lblHasPayedsFilter.Size = new System.Drawing.Size(43, 13);
            this.lblHasPayedsFilter.TabIndex = 66;
            this.lblHasPayedsFilter.Text = "Pagos?";
            // 
            // cbxHasInvoiceStubFilter
            // 
            this.cbxHasInvoiceStubFilter.FormattingEnabled = true;
            this.cbxHasInvoiceStubFilter.Location = new System.Drawing.Point(353, 95);
            this.cbxHasInvoiceStubFilter.Name = "cbxHasInvoiceStubFilter";
            this.cbxHasInvoiceStubFilter.Size = new System.Drawing.Size(66, 21);
            this.cbxHasInvoiceStubFilter.TabIndex = 53;
            // 
            // cbxHasPackedFilter
            // 
            this.cbxHasPackedFilter.FormattingEnabled = true;
            this.cbxHasPackedFilter.Location = new System.Drawing.Point(281, 95);
            this.cbxHasPackedFilter.Name = "cbxHasPackedFilter";
            this.cbxHasPackedFilter.Size = new System.Drawing.Size(66, 21);
            this.cbxHasPackedFilter.TabIndex = 52;
            // 
            // cbxHasPayedFilter
            // 
            this.cbxHasPayedFilter.FormattingEnabled = true;
            this.cbxHasPayedFilter.Location = new System.Drawing.Point(209, 95);
            this.cbxHasPayedFilter.Name = "cbxHasPayedFilter";
            this.cbxHasPayedFilter.Size = new System.Drawing.Size(66, 21);
            this.cbxHasPayedFilter.TabIndex = 51;
            // 
            // lblDat_Emissao
            // 
            this.lblDat_Emissao.AutoSize = true;
            this.lblDat_Emissao.Location = new System.Drawing.Point(7, 79);
            this.lblDat_Emissao.Name = "lblDat_Emissao";
            this.lblDat_Emissao.Size = new System.Drawing.Size(69, 13);
            this.lblDat_Emissao.TabIndex = 27;
            this.lblDat_Emissao.Text = "Dat. Emissão";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(108, 95);
            this.dtpFinal.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(95, 20);
            this.dtpFinal.TabIndex = 25;
            this.dtpFinal.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            // 
            // dtpInitial
            // 
            this.dtpInitial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInitial.Location = new System.Drawing.Point(7, 95);
            this.dtpInitial.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpInitial.Name = "dtpInitial";
            this.dtpInitial.Size = new System.Drawing.Size(95, 20);
            this.dtpInitial.TabIndex = 24;
            this.dtpInitial.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.Location = new System.Drawing.Point(56, 56);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.Size = new System.Drawing.Size(449, 20);
            this.txtTransportadora.TabIndex = 20;
            // 
            // txtCodTransportadora
            // 
            this.txtCodTransportadora.Location = new System.Drawing.Point(7, 56);
            this.txtCodTransportadora.Name = "txtCodTransportadora";
            this.txtCodTransportadora.Size = new System.Drawing.Size(44, 20);
            this.txtCodTransportadora.TabIndex = 19;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(4, 39);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(79, 13);
            this.lblTransportadora.TabIndex = 18;
            this.lblTransportadora.Text = "Transportadora";
            // 
            // frmRelatorioAusencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 558);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.gpbFiltros);
            this.Name = "frmRelatorioAusencias";
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
            this.Text = "Relatórios de Ausência de Canhotos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Label lblIHasInvoiceStubFilter;
        private System.Windows.Forms.Label lblHasPackedFilter;
        private System.Windows.Forms.Label lblHasPayedsFilter;
        private System.Windows.Forms.ComboBox cbxHasInvoiceStubFilter;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ComboBox cbxHasPackedFilter;
        private System.Windows.Forms.ComboBox cbxHasPayedFilter;
        private System.Windows.Forms.Label lblDat_Emissao;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInitial;
        private System.Windows.Forms.TextBox txtTransportadora;
        private System.Windows.Forms.TextBox txtCodTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnMoreTransporter;
        private System.Windows.Forms.Button btnNotifyByMail;
    }
}