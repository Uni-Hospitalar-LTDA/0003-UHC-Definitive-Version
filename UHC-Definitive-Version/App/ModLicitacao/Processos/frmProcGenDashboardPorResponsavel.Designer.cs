namespace UHC3_Definitive_Version.App.ModLicitacao.Processos.RelatoriosGerenciais
{
    partial class frmProcGenDashboardPorResponsavel
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
            this.btnClose = new System.Windows.Forms.Button();
            this.gpbFilters = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.gpbUnity = new System.Windows.Forms.GroupBox();
            this.clbUnities = new System.Windows.Forms.CheckedListBox();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInitial = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cbxInfo = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gpbFilters.SuspendLayout();
            this.gpbUnity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1062, 532);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // gpbFilters
            // 
            this.gpbFilters.Controls.Add(this.btnFilter);
            this.gpbFilters.Controls.Add(this.gpbUnity);
            this.gpbFilters.Controls.Add(this.dtpFinal);
            this.gpbFilters.Controls.Add(this.dtpInitial);
            this.gpbFilters.Controls.Add(this.lblPeriod);
            this.gpbFilters.Location = new System.Drawing.Point(12, 27);
            this.gpbFilters.Name = "gpbFilters";
            this.gpbFilters.Size = new System.Drawing.Size(418, 119);
            this.gpbFilters.TabIndex = 3;
            this.gpbFilters.TabStop = false;
            this.gpbFilters.Text = "Filtros";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(332, 84);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // gpbUnity
            // 
            this.gpbUnity.Controls.Add(this.clbUnities);
            this.gpbUnity.Location = new System.Drawing.Point(6, 19);
            this.gpbUnity.Name = "gpbUnity";
            this.gpbUnity.Size = new System.Drawing.Size(196, 88);
            this.gpbUnity.TabIndex = 3;
            this.gpbUnity.TabStop = false;
            this.gpbUnity.Text = "Unidade";
            // 
            // clbUnities
            // 
            this.clbUnities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbUnities.FormattingEnabled = true;
            this.clbUnities.Location = new System.Drawing.Point(3, 16);
            this.clbUnities.Name = "clbUnities";
            this.clbUnities.Size = new System.Drawing.Size(190, 69);
            this.clbUnities.TabIndex = 0;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(312, 35);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(95, 20);
            this.dtpFinal.TabIndex = 2;
            // 
            // dtpInitial
            // 
            this.dtpInitial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInitial.Location = new System.Drawing.Point(211, 35);
            this.dtpInitial.Name = "dtpInitial";
            this.dtpInitial.Size = new System.Drawing.Size(95, 20);
            this.dtpInitial.TabIndex = 1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(208, 19);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(45, 13);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Período";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(472, 346);
            this.dgvData.TabIndex = 4;
            // 
            // cbxInfo
            // 
            this.cbxInfo.FormattingEnabled = true;
            this.cbxInfo.Location = new System.Drawing.Point(15, 147);
            this.cbxInfo.Name = "cbxInfo";
            this.cbxInfo.Size = new System.Drawing.Size(306, 21);
            this.cbxInfo.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(12, 170);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvData);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1125, 350);
            this.splitContainer1.SplitterDistance = 476;
            this.splitContainer1.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(641, 346);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // frmProcGenDashboardPorResponsavel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 559);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cbxInfo);
            this.Controls.Add(this.gpbFilters);
            this.Controls.Add(this.btnClose);
            this.Name = "frmProcGenDashboardPorResponsavel";
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
            this.Text = "Relatórios Gerenciais (Sintético)";
            this.gpbFilters.ResumeLayout(false);
            this.gpbFilters.PerformLayout();
            this.gpbUnity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gpbFilters;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInitial;
        private System.Windows.Forms.GroupBox gpbUnity;
        private System.Windows.Forms.CheckedListBox clbUnities;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ComboBox cbxInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}