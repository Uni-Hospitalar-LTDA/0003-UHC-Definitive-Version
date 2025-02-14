namespace UHC3_Definitive_Version.App.ModAdmistrativo.Cadastral
{
    partial class frmCadastroTransportador_PrctFreteCidade
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
            this.btnCounties = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.txtTransporterDescription = new System.Windows.Forms.TextBox();
            this.txtTransporterId = new System.Windows.Forms.TextBox();
            this.lblTransporter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCounties
            // 
            this.btnCounties.Location = new System.Drawing.Point(13, 478);
            this.btnCounties.Name = "btnCounties";
            this.btnCounties.Size = new System.Drawing.Size(75, 23);
            this.btnCounties.TabIndex = 38;
            this.btnCounties.Text = "Municípios";
            this.btnCounties.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(713, 478);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(632, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 111);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(776, 360);
            this.dgvData.TabIndex = 36;
            // 
            // txtTransporterDescription
            // 
            this.txtTransporterDescription.Location = new System.Drawing.Point(62, 86);
            this.txtTransporterDescription.Name = "txtTransporterDescription";
            this.txtTransporterDescription.Size = new System.Drawing.Size(453, 20);
            this.txtTransporterDescription.TabIndex = 33;
            // 
            // txtTransporterId
            // 
            this.txtTransporterId.Location = new System.Drawing.Point(12, 86);
            this.txtTransporterId.Name = "txtTransporterId";
            this.txtTransporterId.Size = new System.Drawing.Size(44, 20);
            this.txtTransporterId.TabIndex = 32;
            // 
            // lblTransporter
            // 
            this.lblTransporter.AutoSize = true;
            this.lblTransporter.Location = new System.Drawing.Point(9, 68);
            this.lblTransporter.Name = "lblTransporter";
            this.lblTransporter.Size = new System.Drawing.Size(79, 13);
            this.lblTransporter.TabIndex = 37;
            this.lblTransporter.Text = "Transportadora";
            // 
            // frmCadastroTransportador_PrctFreteCidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 513);
            this.Controls.Add(this.btnCounties);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.txtTransporterDescription);
            this.Controls.Add(this.txtTransporterId);
            this.Controls.Add(this.lblTransporter);
            this.Name = "frmCadastroTransportador_PrctFreteCidade";
            this.Text = "Cadastrar Percentuais de Frete para a Cidade";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCounties;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtTransporterDescription;
        private System.Windows.Forms.TextBox txtTransporterId;
        private System.Windows.Forms.Label lblTransporter;
    }
}