namespace UHC3_Definitive_Version.App.ModFinanceiro.Recebimento
{
    partial class frmContasRecebidas
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.gpbFilter = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpInitial = new System.Windows.Forms.DateTimePicker();
            this.lblFinalDate = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.lblInitialDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gpbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(713, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 58;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 105);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(776, 304);
            this.dgvData.TabIndex = 57;
            // 
            // gpbFilter
            // 
            this.gpbFilter.Controls.Add(this.btnFilter);
            this.gpbFilter.Controls.Add(this.dtpInitial);
            this.gpbFilter.Controls.Add(this.lblFinalDate);
            this.gpbFilter.Controls.Add(this.dtpFinal);
            this.gpbFilter.Controls.Add(this.lblInitialDate);
            this.gpbFilter.Location = new System.Drawing.Point(12, 28);
            this.gpbFilter.Name = "gpbFilter";
            this.gpbFilter.Size = new System.Drawing.Size(305, 71);
            this.gpbFilter.TabIndex = 56;
            this.gpbFilter.TabStop = false;
            this.gpbFilter.Text = "Filtros";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(216, 31);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 14;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // dtpInitial
            // 
            this.dtpInitial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInitial.Location = new System.Drawing.Point(6, 34);
            this.dtpInitial.Name = "dtpInitial";
            this.dtpInitial.Size = new System.Drawing.Size(96, 20);
            this.dtpInitial.TabIndex = 10;
            // 
            // lblFinalDate
            // 
            this.lblFinalDate.AutoSize = true;
            this.lblFinalDate.Location = new System.Drawing.Point(105, 18);
            this.lblFinalDate.Name = "lblFinalDate";
            this.lblFinalDate.Size = new System.Drawing.Size(52, 13);
            this.lblFinalDate.TabIndex = 13;
            this.lblFinalDate.Text = "Dat. Final";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(108, 34);
            this.dtpFinal.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(102, 20);
            this.dtpFinal.TabIndex = 11;
            // 
            // lblInitialDate
            // 
            this.lblInitialDate.AutoSize = true;
            this.lblInitialDate.Location = new System.Drawing.Point(3, 18);
            this.lblInitialDate.Name = "lblInitialDate";
            this.lblInitialDate.Size = new System.Drawing.Size(57, 13);
            this.lblInitialDate.TabIndex = 12;
            this.lblInitialDate.Text = "Dat. Inicial";
            // 
            // frmContasRecebidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.gpbFilter);
            this.Name = "frmContasRecebidas";
            this.Text = "Contas Recebidas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gpbFilter.ResumeLayout(false);
            this.gpbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox gpbFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DateTimePicker dtpInitial;
        private System.Windows.Forms.Label lblFinalDate;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label lblInitialDate;
    }
}