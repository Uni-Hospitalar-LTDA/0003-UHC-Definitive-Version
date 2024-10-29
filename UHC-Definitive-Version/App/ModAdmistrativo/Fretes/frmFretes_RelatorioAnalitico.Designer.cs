namespace UHC3_Definitive_Version.App.ModAdmistrativo.Fretes
{
    partial class frmFretes_RelatorioAnalitico
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
            this.lblCteFilter = new System.Windows.Forms.Label();
            this.txtCteFilter = new System.Windows.Forms.TextBox();
            this.lblNfFilter = new System.Windows.Forms.Label();
            this.txtNfFilter = new System.Windows.Forms.TextBox();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dtpFinalDate = new System.Windows.Forms.DateTimePicker();
            this.dtpInitialDate = new System.Windows.Forms.DateTimePicker();
            this.lblInitialDate = new System.Windows.Forms.Label();
            this.txtTransporterDescription = new System.Windows.Forms.TextBox();
            this.lblTransporter = new System.Windows.Forms.Label();
            this.txtTransporterId = new System.Windows.Forms.TextBox();
            this.btnMoreTransporter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCteFilter
            // 
            this.lblCteFilter.AutoSize = true;
            this.lblCteFilter.Location = new System.Drawing.Point(312, 74);
            this.lblCteFilter.Name = "lblCteFilter";
            this.lblCteFilter.Size = new System.Drawing.Size(28, 13);
            this.lblCteFilter.TabIndex = 98;
            this.lblCteFilter.Text = "CTE";
            // 
            // txtCteFilter
            // 
            this.txtCteFilter.Location = new System.Drawing.Point(315, 90);
            this.txtCteFilter.Name = "txtCteFilter";
            this.txtCteFilter.Size = new System.Drawing.Size(88, 20);
            this.txtCteFilter.TabIndex = 97;
            // 
            // lblNfFilter
            // 
            this.lblNfFilter.AutoSize = true;
            this.lblNfFilter.Location = new System.Drawing.Point(218, 74);
            this.lblNfFilter.Name = "lblNfFilter";
            this.lblNfFilter.Size = new System.Drawing.Size(21, 13);
            this.lblNfFilter.TabIndex = 96;
            this.lblNfFilter.Text = "NF";
            // 
            // txtNfFilter
            // 
            this.txtNfFilter.Location = new System.Drawing.Point(221, 90);
            this.txtNfFilter.Name = "txtNfFilter";
            this.txtNfFilter.Size = new System.Drawing.Size(88, 20);
            this.txtNfFilter.TabIndex = 95;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(649, 77);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(31, 13);
            this.lblTotalValue.TabIndex = 94;
            this.lblTotalValue.Text = "Total";
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.Location = new System.Drawing.Point(652, 93);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.Size = new System.Drawing.Size(138, 20);
            this.txtTotalValue.TabIndex = 93;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(430, 87);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 92;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(715, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 91;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(14, 116);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(776, 297);
            this.dgvData.TabIndex = 90;
            // 
            // dtpFinalDate
            // 
            this.dtpFinalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinalDate.Location = new System.Drawing.Point(116, 90);
            this.dtpFinalDate.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpFinalDate.Name = "dtpFinalDate";
            this.dtpFinalDate.Size = new System.Drawing.Size(99, 20);
            this.dtpFinalDate.TabIndex = 88;
            this.dtpFinalDate.Value = new System.DateTime(2019, 8, 14, 0, 0, 0, 0);
            // 
            // dtpInitialDate
            // 
            this.dtpInitialDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInitialDate.Location = new System.Drawing.Point(14, 90);
            this.dtpInitialDate.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpInitialDate.Name = "dtpInitialDate";
            this.dtpInitialDate.Size = new System.Drawing.Size(99, 20);
            this.dtpInitialDate.TabIndex = 87;
            this.dtpInitialDate.Value = new System.DateTime(2019, 8, 14, 0, 0, 0, 0);
            // 
            // lblInitialDate
            // 
            this.lblInitialDate.AutoSize = true;
            this.lblInitialDate.Location = new System.Drawing.Point(11, 74);
            this.lblInitialDate.Name = "lblInitialDate";
            this.lblInitialDate.Size = new System.Drawing.Size(89, 13);
            this.lblInitialDate.TabIndex = 89;
            this.lblInitialDate.Text = "Filtro por Registro";
            // 
            // txtTransporterDescription
            // 
            this.txtTransporterDescription.Location = new System.Drawing.Point(82, 51);
            this.txtTransporterDescription.Name = "txtTransporterDescription";
            this.txtTransporterDescription.Size = new System.Drawing.Size(423, 20);
            this.txtTransporterDescription.TabIndex = 85;
            // 
            // lblTransporter
            // 
            this.lblTransporter.AutoSize = true;
            this.lblTransporter.Location = new System.Drawing.Point(11, 35);
            this.lblTransporter.Name = "lblTransporter";
            this.lblTransporter.Size = new System.Drawing.Size(73, 13);
            this.lblTransporter.TabIndex = 86;
            this.lblTransporter.Text = "Transportador";
            // 
            // txtTransporterId
            // 
            this.txtTransporterId.Location = new System.Drawing.Point(14, 51);
            this.txtTransporterId.Name = "txtTransporterId";
            this.txtTransporterId.Size = new System.Drawing.Size(62, 20);
            this.txtTransporterId.TabIndex = 84;
            // 
            // btnMoreTransporter
            // 
            this.btnMoreTransporter.Location = new System.Drawing.Point(511, 49);
            this.btnMoreTransporter.Name = "btnMoreTransporter";
            this.btnMoreTransporter.Size = new System.Drawing.Size(24, 23);
            this.btnMoreTransporter.TabIndex = 99;
            this.btnMoreTransporter.Text = "...";
            this.btnMoreTransporter.UseVisualStyleBackColor = true;
            this.btnMoreTransporter.Click += new System.EventHandler(this.btnMoreTransporter_Click);
            // 
            // frmFretes_RelatorioAnalitico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMoreTransporter);
            this.Controls.Add(this.lblCteFilter);
            this.Controls.Add(this.txtCteFilter);
            this.Controls.Add(this.lblNfFilter);
            this.Controls.Add(this.txtNfFilter);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.txtTotalValue);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.dtpFinalDate);
            this.Controls.Add(this.dtpInitialDate);
            this.Controls.Add(this.lblInitialDate);
            this.Controls.Add(this.txtTransporterDescription);
            this.Controls.Add(this.lblTransporter);
            this.Controls.Add(this.txtTransporterId);
            this.Name = "frmFretes_RelatorioAnalitico";
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
            this.Text = "Relatório Analítico de Frete";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCteFilter;
        private System.Windows.Forms.TextBox txtCteFilter;
        private System.Windows.Forms.Label lblNfFilter;
        private System.Windows.Forms.TextBox txtNfFilter;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DateTimePicker dtpFinalDate;
        private System.Windows.Forms.DateTimePicker dtpInitialDate;
        private System.Windows.Forms.Label lblInitialDate;
        private System.Windows.Forms.TextBox txtTransporterDescription;
        private System.Windows.Forms.Label lblTransporter;
        private System.Windows.Forms.TextBox txtTransporterId;
        private System.Windows.Forms.Button btnMoreTransporter;
    }
}