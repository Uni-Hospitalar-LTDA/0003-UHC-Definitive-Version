namespace UHC3_Definitive_Version.App.ModFinanceiro.Recebimento
{
    partial class frmRecebimento_CarRanking
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripAbrirExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripExportarExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.gpbFilters = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCustomerSphere = new System.Windows.Forms.Label();
            this.cbxCustomerSphere = new System.Windows.Forms.ComboBox();
            this.lblDatCorte = new System.Windows.Forms.Label();
            this.txtCustomerGroupDescription = new System.Windows.Forms.TextBox();
            this.lblCustomerGroup = new System.Windows.Forms.Label();
            this.txtCustomerGroupId = new System.Windows.Forms.TextBox();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.btnTop10 = new System.Windows.Forms.Button();
            this.btnTotal = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gpbFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1318, 24);
            this.menuStrip1.TabIndex = 53;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.exportarToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripAbrirExcel});
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // menuStripAbrirExcel
            // 
            this.menuStripAbrirExcel.Name = "menuStripAbrirExcel";
            this.menuStripAbrirExcel.Size = new System.Drawing.Size(101, 22);
            this.menuStripAbrirExcel.Text = "Excel";
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripExportarExcel});
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.exportarToolStripMenuItem.Text = "Exportar";
            // 
            // menuStripExportarExcel
            // 
            this.menuStripExportarExcel.Name = "menuStripExportarExcel";
            this.menuStripExportarExcel.Size = new System.Drawing.Size(101, 22);
            this.menuStripExportarExcel.Text = "Excel";
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 246);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(1294, 331);
            this.dgvData.TabIndex = 54;
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.Location = new System.Drawing.Point(18, 201);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.Size = new System.Drawing.Size(295, 20);
            this.txtTotalValue.TabIndex = 56;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(15, 185);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(49, 13);
            this.lblTotalValue.TabIndex = 55;
            this.lblTotalValue.Text = "Vlr. Total";
            // 
            // gpbFilters
            // 
            this.gpbFilters.Controls.Add(this.btnSearch);
            this.gpbFilters.Controls.Add(this.lblCustomerSphere);
            this.gpbFilters.Controls.Add(this.cbxCustomerSphere);
            this.gpbFilters.Controls.Add(this.lblDatCorte);
            this.gpbFilters.Controls.Add(this.txtCustomerGroupDescription);
            this.gpbFilters.Controls.Add(this.lblCustomerGroup);
            this.gpbFilters.Controls.Add(this.txtCustomerGroupId);
            this.gpbFilters.Controls.Add(this.dtpFinal);
            this.gpbFilters.Location = new System.Drawing.Point(18, 27);
            this.gpbFilters.Name = "gpbFilters";
            this.gpbFilters.Size = new System.Drawing.Size(295, 155);
            this.gpbFilters.TabIndex = 57;
            this.gpbFilters.TabStop = false;
            this.gpbFilters.Text = "Filtros";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(216, 71);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 48;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblCustomerSphere
            // 
            this.lblCustomerSphere.AutoSize = true;
            this.lblCustomerSphere.Location = new System.Drawing.Point(3, 58);
            this.lblCustomerSphere.Name = "lblCustomerSphere";
            this.lblCustomerSphere.Size = new System.Drawing.Size(37, 13);
            this.lblCustomerSphere.TabIndex = 46;
            this.lblCustomerSphere.Text = "Esfera";
            // 
            // cbxCustomerSphere
            // 
            this.cbxCustomerSphere.FormattingEnabled = true;
            this.cbxCustomerSphere.Location = new System.Drawing.Point(6, 73);
            this.cbxCustomerSphere.Name = "cbxCustomerSphere";
            this.cbxCustomerSphere.Size = new System.Drawing.Size(97, 21);
            this.cbxCustomerSphere.TabIndex = 45;
            // 
            // lblDatCorte
            // 
            this.lblDatCorte.AutoSize = true;
            this.lblDatCorte.Location = new System.Drawing.Point(106, 58);
            this.lblDatCorte.Name = "lblDatCorte";
            this.lblDatCorte.Size = new System.Drawing.Size(55, 13);
            this.lblDatCorte.TabIndex = 44;
            this.lblDatCorte.Text = "Dat. Corte";
            // 
            // txtCustomerGroupDescription
            // 
            this.txtCustomerGroupDescription.Location = new System.Drawing.Point(52, 35);
            this.txtCustomerGroupDescription.Name = "txtCustomerGroupDescription";
            this.txtCustomerGroupDescription.Size = new System.Drawing.Size(239, 20);
            this.txtCustomerGroupDescription.TabIndex = 39;
            // 
            // lblCustomerGroup
            // 
            this.lblCustomerGroup.AutoSize = true;
            this.lblCustomerGroup.Location = new System.Drawing.Point(3, 19);
            this.lblCustomerGroup.Name = "lblCustomerGroup";
            this.lblCustomerGroup.Size = new System.Drawing.Size(71, 13);
            this.lblCustomerGroup.TabIndex = 38;
            this.lblCustomerGroup.Text = "Grupo Cliente";
            // 
            // txtCustomerGroupId
            // 
            this.txtCustomerGroupId.Location = new System.Drawing.Point(6, 35);
            this.txtCustomerGroupId.Name = "txtCustomerGroupId";
            this.txtCustomerGroupId.Size = new System.Drawing.Size(40, 20);
            this.txtCustomerGroupId.TabIndex = 37;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(109, 74);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(101, 20);
            this.dtpFinal.TabIndex = 43;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.cartesianChart1);
            this.groupBox1.Location = new System.Drawing.Point(330, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 197);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Top 10";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(3, 16);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(478, 178);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.pieChart1);
            this.groupBox2.Location = new System.Drawing.Point(820, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 197);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Relação Total";
            // 
            // pieChart1
            // 
            this.pieChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChart1.Location = new System.Drawing.Point(3, 16);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(480, 178);
            this.pieChart1.TabIndex = 0;
            this.pieChart1.Text = "pieChart1";
            // 
            // btnTop10
            // 
            this.btnTop10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTop10.Location = new System.Drawing.Point(504, 597);
            this.btnTop10.Name = "btnTop10";
            this.btnTop10.Size = new System.Drawing.Size(152, 23);
            this.btnTop10.TabIndex = 60;
            this.btnTop10.Text = "Visualizar Gráfico Top 10";
            this.btnTop10.UseVisualStyleBackColor = true;
            // 
            // btnTotal
            // 
            this.btnTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTotal.Location = new System.Drawing.Point(662, 597);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(152, 23);
            this.btnTotal.TabIndex = 61;
            this.btnTotal.Text = "Visualizar Gráfico R. Total";
            this.btnTotal.UseVisualStyleBackColor = true;
            // 
            // frmRecebimento_CarRanking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 632);
            this.Controls.Add(this.btnTotal);
            this.Controls.Add(this.btnTop10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTotalValue);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.gpbFilters);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmRecebimento_CarRanking";
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
            this.Text = "frmRecebimento_CarRanking";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gpbFilters.ResumeLayout(false);
            this.gpbFilters.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuStripAbrirExcel;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuStripExportarExcel;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.GroupBox gpbFilters;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCustomerSphere;
        private System.Windows.Forms.ComboBox cbxCustomerSphere;
        private System.Windows.Forms.Label lblDatCorte;
        private System.Windows.Forms.TextBox txtCustomerGroupDescription;
        private System.Windows.Forms.Label lblCustomerGroup;
        private System.Windows.Forms.TextBox txtCustomerGroupId;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.GroupBox groupBox1;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.GroupBox groupBox2;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Button btnTop10;
        private System.Windows.Forms.Button btnTotal;
    }
}