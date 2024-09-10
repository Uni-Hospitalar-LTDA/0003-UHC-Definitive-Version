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
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.linklblNotifyByMail = new System.Windows.Forms.LinkLabel();
            this.lblIHasInvoiceStubFilter = new System.Windows.Forms.Label();
            this.lblHasPackedFilter = new System.Windows.Forms.Label();
            this.lblHasPayedsFilter = new System.Windows.Forms.Label();
            this.cbxHasInvoiceStubFilter = new System.Windows.Forms.ComboBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.cbxHasPackedFilter = new System.Windows.Forms.ComboBox();
            this.cbxHasPayedFilter = new System.Windows.Forms.ComboBox();
            this.lblDat_Emissao = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInitial = new System.Windows.Forms.DateTimePicker();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.txtCodTransportadora = new System.Windows.Forms.TextBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.linklblNotifyByMail);
            this.gpbFiltros.Controls.Add(this.lblIHasInvoiceStubFilter);
            this.gpbFiltros.Controls.Add(this.lblHasPackedFilter);
            this.gpbFiltros.Controls.Add(this.lblHasPayedsFilter);
            this.gpbFiltros.Controls.Add(this.cbxHasInvoiceStubFilter);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.cbxHasPackedFilter);
            this.gpbFiltros.Controls.Add(this.cbxHasPayedFilter);
            this.gpbFiltros.Controls.Add(this.lblDat_Emissao);
            this.gpbFiltros.Controls.Add(this.dtpFinal);
            this.gpbFiltros.Controls.Add(this.dtpInitial);
            this.gpbFiltros.Controls.Add(this.txtTransportadora);
            this.gpbFiltros.Controls.Add(this.txtCodTransportadora);
            this.gpbFiltros.Controls.Add(this.lblTransportadora);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 31);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(513, 102);
            this.gpbFiltros.TabIndex = 56;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // linklblNotifyByMail
            // 
            this.linklblNotifyByMail.AutoSize = true;
            this.linklblNotifyByMail.Location = new System.Drawing.Point(337, 21);
            this.linklblNotifyByMail.Name = "linklblNotifyByMail";
            this.linklblNotifyByMail.Size = new System.Drawing.Size(167, 13);
            this.linklblNotifyByMail.TabIndex = 69;
            this.linklblNotifyByMail.TabStop = true;
            this.linklblNotifyByMail.Text = "Notificar Transporadora por E-mail";
            // 
            // lblIHasInvoiceStubFilter
            // 
            this.lblIHasInvoiceStubFilter.AutoSize = true;
            this.lblIHasInvoiceStubFilter.Location = new System.Drawing.Point(349, 60);
            this.lblIHasInvoiceStubFilter.Name = "lblIHasInvoiceStubFilter";
            this.lblIHasInvoiceStubFilter.Size = new System.Drawing.Size(53, 13);
            this.lblIHasInvoiceStubFilter.TabIndex = 68;
            this.lblIHasInvoiceStubFilter.Text = "Canhoto?";
            // 
            // lblHasPackedFilter
            // 
            this.lblHasPackedFilter.AutoSize = true;
            this.lblHasPackedFilter.Location = new System.Drawing.Point(280, 60);
            this.lblHasPackedFilter.Name = "lblHasPackedFilter";
            this.lblHasPackedFilter.Size = new System.Drawing.Size(61, 13);
            this.lblHasPackedFilter.TabIndex = 67;
            this.lblHasPackedFilter.Text = "Romaneio?";
            // 
            // lblHasPayedsFilter
            // 
            this.lblHasPayedsFilter.AutoSize = true;
            this.lblHasPayedsFilter.Location = new System.Drawing.Point(205, 60);
            this.lblHasPayedsFilter.Name = "lblHasPayedsFilter";
            this.lblHasPayedsFilter.Size = new System.Drawing.Size(43, 13);
            this.lblHasPayedsFilter.TabIndex = 66;
            this.lblHasPayedsFilter.Text = "Pagos?";
            // 
            // cbxHasInvoiceStubFilter
            // 
            this.cbxHasInvoiceStubFilter.FormattingEnabled = true;
            this.cbxHasInvoiceStubFilter.Location = new System.Drawing.Point(352, 76);
            this.cbxHasInvoiceStubFilter.Name = "cbxHasInvoiceStubFilter";
            this.cbxHasInvoiceStubFilter.Size = new System.Drawing.Size(66, 21);
            this.cbxHasInvoiceStubFilter.TabIndex = 53;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(427, 73);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 25);
            this.btnPesquisar.TabIndex = 50;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            // 
            // cbxHasPackedFilter
            // 
            this.cbxHasPackedFilter.FormattingEnabled = true;
            this.cbxHasPackedFilter.Location = new System.Drawing.Point(280, 76);
            this.cbxHasPackedFilter.Name = "cbxHasPackedFilter";
            this.cbxHasPackedFilter.Size = new System.Drawing.Size(66, 21);
            this.cbxHasPackedFilter.TabIndex = 52;
            // 
            // cbxHasPayedFilter
            // 
            this.cbxHasPayedFilter.FormattingEnabled = true;
            this.cbxHasPayedFilter.Location = new System.Drawing.Point(208, 76);
            this.cbxHasPayedFilter.Name = "cbxHasPayedFilter";
            this.cbxHasPayedFilter.Size = new System.Drawing.Size(66, 21);
            this.cbxHasPayedFilter.TabIndex = 51;
            // 
            // lblDat_Emissao
            // 
            this.lblDat_Emissao.AutoSize = true;
            this.lblDat_Emissao.Location = new System.Drawing.Point(6, 60);
            this.lblDat_Emissao.Name = "lblDat_Emissao";
            this.lblDat_Emissao.Size = new System.Drawing.Size(69, 13);
            this.lblDat_Emissao.TabIndex = 27;
            this.lblDat_Emissao.Text = "Dat. Emissão";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(107, 76);
            this.dtpFinal.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(95, 20);
            this.dtpFinal.TabIndex = 25;
            this.dtpFinal.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            // 
            // dtpInitial
            // 
            this.dtpInitial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInitial.Location = new System.Drawing.Point(6, 76);
            this.dtpInitial.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpInitial.Name = "dtpInitial";
            this.dtpInitial.Size = new System.Drawing.Size(95, 20);
            this.dtpInitial.TabIndex = 24;
            this.dtpInitial.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.Location = new System.Drawing.Point(55, 37);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.Size = new System.Drawing.Size(449, 20);
            this.txtTransportadora.TabIndex = 20;
            // 
            // txtCodTransportadora
            // 
            this.txtCodTransportadora.Location = new System.Drawing.Point(6, 37);
            this.txtCodTransportadora.Name = "txtCodTransportadora";
            this.txtCodTransportadora.Size = new System.Drawing.Size(44, 20);
            this.txtCodTransportadora.TabIndex = 19;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(3, 20);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(79, 13);
            this.lblTransportadora.TabIndex = 18;
            this.lblTransportadora.Text = "Transportadora";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 139);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(1050, 421);
            this.dgvData.TabIndex = 66;
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
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(353, 25);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(164, 23);
            this.progressBar1.TabIndex = 68;
            // 
            // frmRelatorioAusencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 596);
            this.Controls.Add(this.progressBar1);
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
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.LinkLabel linklblNotifyByMail;
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
    }
}