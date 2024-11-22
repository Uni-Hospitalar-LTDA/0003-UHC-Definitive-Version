namespace UHC3_Definitive_Version.App.ModFinanceiro.Recebimento
{
    partial class frmContasReceber
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
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.gpbFilters = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCustomerSphere = new System.Windows.Forms.Label();
            this.cbxCustomerSphere = new System.Windows.Forms.ComboBox();
            this.lblDatCorte = new System.Windows.Forms.Label();
            this.txtCustomerGroupDescription = new System.Windows.Forms.TextBox();
            this.lblCustomerGroup = new System.Windows.Forms.Label();
            this.txtCustomerGroupId = new System.Windows.Forms.TextBox();
            this.txtCustomerDescription = new System.Windows.Forms.TextBox();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.lblBill = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtBill = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gpbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(949, 544);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(9, 154);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(49, 13);
            this.lblTotalValue.TabIndex = 50;
            this.lblTotalValue.Text = "Vlr. Total";
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.Location = new System.Drawing.Point(12, 170);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.Size = new System.Drawing.Size(145, 20);
            this.txtTotalValue.TabIndex = 51;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 196);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(1012, 342);
            this.dgvData.TabIndex = 49;
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
            this.gpbFilters.Controls.Add(this.txtCustomerDescription);
            this.gpbFilters.Controls.Add(this.dtpFinal);
            this.gpbFilters.Controls.Add(this.lblBill);
            this.gpbFilters.Controls.Add(this.txtCustomerId);
            this.gpbFilters.Controls.Add(this.lblCustomer);
            this.gpbFilters.Controls.Add(this.txtBill);
            this.gpbFilters.Location = new System.Drawing.Point(12, 23);
            this.gpbFilters.Name = "gpbFilters";
            this.gpbFilters.Size = new System.Drawing.Size(576, 130);
            this.gpbFilters.TabIndex = 48;
            this.gpbFilters.TabStop = false;
            this.gpbFilters.Text = "Filtros";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(491, 97);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 48;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblCustomerSphere
            // 
            this.lblCustomerSphere.AutoSize = true;
            this.lblCustomerSphere.Location = new System.Drawing.Point(359, 55);
            this.lblCustomerSphere.Name = "lblCustomerSphere";
            this.lblCustomerSphere.Size = new System.Drawing.Size(37, 13);
            this.lblCustomerSphere.TabIndex = 46;
            this.lblCustomerSphere.Text = "Esfera";
            // 
            // cbxCustomerSphere
            // 
            this.cbxCustomerSphere.FormattingEnabled = true;
            this.cbxCustomerSphere.Location = new System.Drawing.Point(362, 70);
            this.cbxCustomerSphere.Name = "cbxCustomerSphere";
            this.cbxCustomerSphere.Size = new System.Drawing.Size(97, 21);
            this.cbxCustomerSphere.TabIndex = 45;
            // 
            // lblDatCorte
            // 
            this.lblDatCorte.AutoSize = true;
            this.lblDatCorte.Location = new System.Drawing.Point(462, 55);
            this.lblDatCorte.Name = "lblDatCorte";
            this.lblDatCorte.Size = new System.Drawing.Size(55, 13);
            this.lblDatCorte.TabIndex = 44;
            this.lblDatCorte.Text = "Dat. Corte";
            // 
            // txtCustomerGroupDescription
            // 
            this.txtCustomerGroupDescription.Location = new System.Drawing.Point(52, 71);
            this.txtCustomerGroupDescription.Name = "txtCustomerGroupDescription";
            this.txtCustomerGroupDescription.Size = new System.Drawing.Size(153, 20);
            this.txtCustomerGroupDescription.TabIndex = 39;
            // 
            // lblCustomerGroup
            // 
            this.lblCustomerGroup.AutoSize = true;
            this.lblCustomerGroup.Location = new System.Drawing.Point(3, 55);
            this.lblCustomerGroup.Name = "lblCustomerGroup";
            this.lblCustomerGroup.Size = new System.Drawing.Size(71, 13);
            this.lblCustomerGroup.TabIndex = 38;
            this.lblCustomerGroup.Text = "Grupo Cliente";
            // 
            // txtCustomerGroupId
            // 
            this.txtCustomerGroupId.Location = new System.Drawing.Point(6, 71);
            this.txtCustomerGroupId.Name = "txtCustomerGroupId";
            this.txtCustomerGroupId.Size = new System.Drawing.Size(40, 20);
            this.txtCustomerGroupId.TabIndex = 37;
            // 
            // txtCustomerDescription
            // 
            this.txtCustomerDescription.Location = new System.Drawing.Point(67, 31);
            this.txtCustomerDescription.Name = "txtCustomerDescription";
            this.txtCustomerDescription.Size = new System.Drawing.Size(499, 20);
            this.txtCustomerDescription.TabIndex = 36;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(465, 71);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(101, 20);
            this.dtpFinal.TabIndex = 43;
            // 
            // lblBill
            // 
            this.lblBill.AutoSize = true;
            this.lblBill.Location = new System.Drawing.Point(211, 55);
            this.lblBill.Name = "lblBill";
            this.lblBill.Size = new System.Drawing.Size(35, 13);
            this.lblBill.TabIndex = 41;
            this.lblBill.Text = "Título";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(6, 31);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(55, 20);
            this.txtCustomerId.TabIndex = 35;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(6, 15);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(39, 13);
            this.lblCustomer.TabIndex = 34;
            this.lblCustomer.Text = "Cliente";
            // 
            // txtBill
            // 
            this.txtBill.Location = new System.Drawing.Point(211, 71);
            this.txtBill.Name = "txtBill";
            this.txtBill.Size = new System.Drawing.Size(145, 20);
            this.txtBill.TabIndex = 40;
            // 
            // frmContasReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 574);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.txtTotalValue);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.gpbFilters);
            this.Name = "frmContasReceber";
            this.Text = "Contas a Receber";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gpbFilters.ResumeLayout(false);
            this.gpbFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox gpbFilters;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCustomerSphere;
        private System.Windows.Forms.ComboBox cbxCustomerSphere;
        private System.Windows.Forms.Label lblDatCorte;
        private System.Windows.Forms.TextBox txtCustomerGroupDescription;
        private System.Windows.Forms.Label lblCustomerGroup;
        private System.Windows.Forms.TextBox txtCustomerGroupId;
        private System.Windows.Forms.TextBox txtCustomerDescription;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtBill;
    }
}