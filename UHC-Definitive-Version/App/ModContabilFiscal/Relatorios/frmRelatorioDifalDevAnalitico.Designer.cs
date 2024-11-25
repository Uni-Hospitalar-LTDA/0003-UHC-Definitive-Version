namespace UHC3_Definitive_Version.App.ModContabilFiscal.Relatorios
{
    partial class frmRelatorioDifalDevAnalitico
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
            this.lblVlrTotal = new System.Windows.Forms.Label();
            this.txtVlrTotal = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.gpbFilters = new System.Windows.Forms.GroupBox();
            this.chkNotZero = new System.Windows.Forms.CheckBox();
            this.lblNF = new System.Windows.Forms.Label();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtStateDescription = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtStateUF = new System.Windows.Forms.TextBox();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.dtpInitial = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerDescription = new System.Windows.Forms.TextBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gpbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVlrTotal
            // 
            this.lblVlrTotal.AutoSize = true;
            this.lblVlrTotal.Location = new System.Drawing.Point(485, 138);
            this.lblVlrTotal.Name = "lblVlrTotal";
            this.lblVlrTotal.Size = new System.Drawing.Size(49, 13);
            this.lblVlrTotal.TabIndex = 24;
            this.lblVlrTotal.Text = "Vlr. Total";
            // 
            // txtVlrTotal
            // 
            this.txtVlrTotal.Location = new System.Drawing.Point(488, 154);
            this.txtVlrTotal.Name = "txtVlrTotal";
            this.txtVlrTotal.Size = new System.Drawing.Size(121, 20);
            this.txtVlrTotal.TabIndex = 25;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(713, 355);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 180);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(776, 169);
            this.dgvData.TabIndex = 22;
            // 
            // gpbFilters
            // 
            this.gpbFilters.Controls.Add(this.chkNotZero);
            this.gpbFilters.Controls.Add(this.lblNF);
            this.gpbFilters.Controls.Add(this.txtNF);
            this.gpbFilters.Controls.Add(this.btnFilter);
            this.gpbFilters.Controls.Add(this.lblDate);
            this.gpbFilters.Controls.Add(this.txtStateDescription);
            this.gpbFilters.Controls.Add(this.lblState);
            this.gpbFilters.Controls.Add(this.txtStateUF);
            this.gpbFilters.Controls.Add(this.dtpFinal);
            this.gpbFilters.Controls.Add(this.lblCustomer);
            this.gpbFilters.Controls.Add(this.dtpInitial);
            this.gpbFilters.Controls.Add(this.txtCustomerDescription);
            this.gpbFilters.Controls.Add(this.txtCustomerId);
            this.gpbFilters.Location = new System.Drawing.Point(12, 32);
            this.gpbFilters.Name = "gpbFilters";
            this.gpbFilters.Size = new System.Drawing.Size(470, 142);
            this.gpbFilters.TabIndex = 21;
            this.gpbFilters.TabStop = false;
            this.gpbFilters.Text = "Filtros";
            // 
            // chkNotZero
            // 
            this.chkNotZero.AutoSize = true;
            this.chkNotZero.Location = new System.Drawing.Point(218, 110);
            this.chkNotZero.Name = "chkNotZero";
            this.chkNotZero.Size = new System.Drawing.Size(109, 17);
            this.chkNotZero.TabIndex = 14;
            this.chkNotZero.Text = "Maiores que Zero";
            this.chkNotZero.UseVisualStyleBackColor = true;
            // 
            // lblNF
            // 
            this.lblNF.AutoSize = true;
            this.lblNF.Location = new System.Drawing.Point(299, 54);
            this.lblNF.Name = "lblNF";
            this.lblNF.Size = new System.Drawing.Size(21, 13);
            this.lblNF.TabIndex = 13;
            this.lblNF.Text = "NF";
            // 
            // txtNF
            // 
            this.txtNF.Location = new System.Drawing.Point(299, 70);
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(85, 20);
            this.txtNF.TabIndex = 12;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(389, 110);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 93);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Data";
            // 
            // txtStateDescription
            // 
            this.txtStateDescription.Location = new System.Drawing.Point(61, 70);
            this.txtStateDescription.Name = "txtStateDescription";
            this.txtStateDescription.Size = new System.Drawing.Size(232, 20);
            this.txtStateDescription.TabIndex = 11;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(6, 54);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 13);
            this.lblState.TabIndex = 10;
            this.lblState.Text = "State";
            // 
            // txtStateUF
            // 
            this.txtStateUF.Location = new System.Drawing.Point(6, 70);
            this.txtStateUF.Name = "txtStateUF";
            this.txtStateUF.Size = new System.Drawing.Size(49, 20);
            this.txtStateUF.TabIndex = 9;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(112, 109);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(100, 20);
            this.dtpFinal.TabIndex = 6;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(6, 16);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(39, 13);
            this.lblCustomer.TabIndex = 8;
            this.lblCustomer.Text = "Cliente";
            // 
            // dtpInitial
            // 
            this.dtpInitial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInitial.Location = new System.Drawing.Point(6, 109);
            this.dtpInitial.Name = "dtpInitial";
            this.dtpInitial.Size = new System.Drawing.Size(100, 20);
            this.dtpInitial.TabIndex = 5;
            // 
            // txtCustomerDescription
            // 
            this.txtCustomerDescription.Location = new System.Drawing.Point(61, 32);
            this.txtCustomerDescription.Name = "txtCustomerDescription";
            this.txtCustomerDescription.Size = new System.Drawing.Size(403, 20);
            this.txtCustomerDescription.TabIndex = 7;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(6, 32);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(49, 20);
            this.txtCustomerId.TabIndex = 6;
            // 
            // frmRelatorioDifalDevAnalitico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 384);
            this.Controls.Add(this.lblVlrTotal);
            this.Controls.Add(this.txtVlrTotal);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.gpbFilters);
            this.Name = "frmRelatorioDifalDevAnalitico";
            this.Text = "Relação de Difal x Devoluções Analítica por Estado";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gpbFilters.ResumeLayout(false);
            this.gpbFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVlrTotal;
        private System.Windows.Forms.TextBox txtVlrTotal;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox gpbFilters;
        private System.Windows.Forms.CheckBox chkNotZero;
        private System.Windows.Forms.Label lblNF;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtStateDescription;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtStateUF;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.DateTimePicker dtpInitial;
        private System.Windows.Forms.TextBox txtCustomerDescription;
        private System.Windows.Forms.TextBox txtCustomerId;
    }
}