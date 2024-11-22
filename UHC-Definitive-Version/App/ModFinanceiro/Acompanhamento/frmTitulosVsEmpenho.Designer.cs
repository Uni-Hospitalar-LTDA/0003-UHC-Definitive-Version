namespace UHC3_Definitive_Version.App.ModFinanceiro.Acompanhamento
{
    partial class frmTitulosVsEmpenho
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
            this.cbxCustomerType = new System.Windows.Forms.ComboBox();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.lblCustomerGroup = new System.Windows.Forms.Label();
            this.txtCustomerGroup = new System.Windows.Forms.TextBox();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDateInterval = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInitial = new System.Windows.Forms.DateTimePicker();
            this.lblNF = new System.Windows.Forms.Label();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.txtCustomerDescription = new System.Windows.Forms.TextBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.txtEmpenho = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxCustomerType
            // 
            this.cbxCustomerType.FormattingEnabled = true;
            this.cbxCustomerType.Location = new System.Drawing.Point(171, 124);
            this.cbxCustomerType.Name = "cbxCustomerType";
            this.cbxCustomerType.Size = new System.Drawing.Size(196, 21);
            this.cbxCustomerType.TabIndex = 57;
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Location = new System.Drawing.Point(168, 108);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(86, 13);
            this.lblCustomerType.TabIndex = 68;
            this.lblCustomerType.Text = "Tipo Consumidor";
            // 
            // lblCustomerGroup
            // 
            this.lblCustomerGroup.AutoSize = true;
            this.lblCustomerGroup.Location = new System.Drawing.Point(553, 69);
            this.lblCustomerGroup.Name = "lblCustomerGroup";
            this.lblCustomerGroup.Size = new System.Drawing.Size(86, 13);
            this.lblCustomerGroup.TabIndex = 67;
            this.lblCustomerGroup.Text = "Grupo de Cliente";
            // 
            // txtCustomerGroup
            // 
            this.txtCustomerGroup.Location = new System.Drawing.Point(556, 86);
            this.txtCustomerGroup.Name = "txtCustomerGroup";
            this.txtCustomerGroup.Size = new System.Drawing.Size(165, 20);
            this.txtCustomerGroup.TabIndex = 55;
            // 
            // cbxState
            // 
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Location = new System.Drawing.Point(376, 85);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(174, 21);
            this.cbxState.TabIndex = 54;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(373, 69);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(21, 13);
            this.lblState.TabIndex = 66;
            this.lblState.Text = "UF";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(646, 112);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 34);
            this.btnSearch.TabIndex = 60;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(932, 501);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 65;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblDateInterval
            // 
            this.lblDateInterval.AutoSize = true;
            this.lblDateInterval.Location = new System.Drawing.Point(413, 108);
            this.lblDateInterval.Name = "lblDateInterval";
            this.lblDateInterval.Size = new System.Drawing.Size(94, 13);
            this.lblDateInterval.TabIndex = 64;
            this.lblDateInterval.Text = "Intervalo de Datas";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(517, 124);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(95, 20);
            this.dtpFinal.TabIndex = 59;
            // 
            // dtpInitial
            // 
            this.dtpInitial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInitial.Location = new System.Drawing.Point(416, 124);
            this.dtpInitial.Name = "dtpInitial";
            this.dtpInitial.Size = new System.Drawing.Size(95, 20);
            this.dtpInitial.TabIndex = 58;
            // 
            // lblNF
            // 
            this.lblNF.AutoSize = true;
            this.lblNF.Location = new System.Drawing.Point(12, 108);
            this.lblNF.Name = "lblNF";
            this.lblNF.Size = new System.Drawing.Size(21, 13);
            this.lblNF.TabIndex = 63;
            this.lblNF.Text = "NF";
            // 
            // txtNF
            // 
            this.txtNF.Location = new System.Drawing.Point(12, 124);
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(153, 20);
            this.txtNF.TabIndex = 56;
            // 
            // txtCustomerDescription
            // 
            this.txtCustomerDescription.Location = new System.Drawing.Point(61, 46);
            this.txtCustomerDescription.Name = "txtCustomerDescription";
            this.txtCustomerDescription.Size = new System.Drawing.Size(660, 20);
            this.txtCustomerDescription.TabIndex = 62;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(12, 46);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(44, 20);
            this.txtCustomerId.TabIndex = 51;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 30);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(39, 13);
            this.lblCustomer.TabIndex = 61;
            this.lblCustomer.Text = "Cliente";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(12, 69);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(52, 13);
            this.lbl.TabIndex = 53;
            this.lbl.Text = "Empenho";
            // 
            // txtEmpenho
            // 
            this.txtEmpenho.Location = new System.Drawing.Point(12, 85);
            this.txtEmpenho.Name = "txtEmpenho";
            this.txtEmpenho.Size = new System.Drawing.Size(355, 20);
            this.txtEmpenho.TabIndex = 52;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 151);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(995, 344);
            this.dgvData.TabIndex = 50;
            // 
            // frmTitulosVsEmpenho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 531);
            this.Controls.Add(this.cbxCustomerType);
            this.Controls.Add(this.lblCustomerType);
            this.Controls.Add(this.lblCustomerGroup);
            this.Controls.Add(this.txtCustomerGroup);
            this.Controls.Add(this.cbxState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDateInterval);
            this.Controls.Add(this.dtpFinal);
            this.Controls.Add(this.dtpInitial);
            this.Controls.Add(this.lblNF);
            this.Controls.Add(this.txtNF);
            this.Controls.Add(this.txtCustomerDescription);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtEmpenho);
            this.Controls.Add(this.dgvData);
            this.Name = "frmTitulosVsEmpenho";
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
            this.Text = "Titulos Vs Empenhos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCustomerType;
        private System.Windows.Forms.Label lblCustomerType;
        private System.Windows.Forms.Label lblCustomerGroup;
        private System.Windows.Forms.TextBox txtCustomerGroup;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDateInterval;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInitial;
        private System.Windows.Forms.Label lblNF;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.TextBox txtCustomerDescription;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtEmpenho;
        private System.Windows.Forms.DataGridView dgvData;
    }
}