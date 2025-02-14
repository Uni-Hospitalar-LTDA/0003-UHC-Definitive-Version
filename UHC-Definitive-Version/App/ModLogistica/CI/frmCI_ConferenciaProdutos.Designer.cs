namespace UHC3_Definitive_Version.App.ModLogistica.CI
{
    partial class frmCI_ConferenciaProdutos
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
            this.gpbNfInformation = new System.Windows.Forms.GroupBox();
            this.txtResponsible = new System.Windows.Forms.TextBox();
            this.lblNfOrigin = new System.Windows.Forms.Label();
            this.lblResponsible = new System.Windows.Forms.Label();
            this.lsbNFOrigin = new System.Windows.Forms.ListBox();
            this.lblNFreturn = new System.Windows.Forms.Label();
            this.txtPhysicalReturn = new System.Windows.Forms.TextBox();
            this.lsbNFReturn = new System.Windows.Forms.ListBox();
            this.lblPhysicalReturn = new System.Windows.Forms.Label();
            this.txtOperation = new System.Windows.Forms.TextBox();
            this.lblOperation = new System.Windows.Forms.Label();
            this.lblIdCi = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTransporter = new System.Windows.Forms.TextBox();
            this.txtTransporterId = new System.Windows.Forms.TextBox();
            this.lblTransporter = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.txtReasonId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbEntitiesInformation = new System.Windows.Forms.GroupBox();
            this.lblNF = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnTotalReceipt = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEncaminharFinanceiro = new System.Windows.Forms.Button();
            this.gpbNfInformation.SuspendLayout();
            this.gpbEntitiesInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbNfInformation
            // 
            this.gpbNfInformation.Controls.Add(this.txtResponsible);
            this.gpbNfInformation.Controls.Add(this.lblNfOrigin);
            this.gpbNfInformation.Controls.Add(this.lblResponsible);
            this.gpbNfInformation.Controls.Add(this.lsbNFOrigin);
            this.gpbNfInformation.Controls.Add(this.lblNFreturn);
            this.gpbNfInformation.Controls.Add(this.txtPhysicalReturn);
            this.gpbNfInformation.Controls.Add(this.lsbNFReturn);
            this.gpbNfInformation.Controls.Add(this.lblPhysicalReturn);
            this.gpbNfInformation.Controls.Add(this.txtOperation);
            this.gpbNfInformation.Controls.Add(this.lblOperation);
            this.gpbNfInformation.Location = new System.Drawing.Point(12, 36);
            this.gpbNfInformation.Name = "gpbNfInformation";
            this.gpbNfInformation.Size = new System.Drawing.Size(295, 145);
            this.gpbNfInformation.TabIndex = 0;
            this.gpbNfInformation.TabStop = false;
            this.gpbNfInformation.Text = "Informações sobre NF";
            // 
            // txtResponsible
            // 
            this.txtResponsible.Location = new System.Drawing.Point(169, 109);
            this.txtResponsible.Name = "txtResponsible";
            this.txtResponsible.Size = new System.Drawing.Size(115, 20);
            this.txtResponsible.TabIndex = 82;
            // 
            // lblNfOrigin
            // 
            this.lblNfOrigin.AutoSize = true;
            this.lblNfOrigin.Location = new System.Drawing.Point(86, 16);
            this.lblNfOrigin.Name = "lblNfOrigin";
            this.lblNfOrigin.Size = new System.Drawing.Size(40, 13);
            this.lblNfOrigin.TabIndex = 79;
            this.lblNfOrigin.Text = "Origem";
            // 
            // lblResponsible
            // 
            this.lblResponsible.AutoSize = true;
            this.lblResponsible.Location = new System.Drawing.Point(166, 93);
            this.lblResponsible.Name = "lblResponsible";
            this.lblResponsible.Size = new System.Drawing.Size(69, 13);
            this.lblResponsible.TabIndex = 83;
            this.lblResponsible.Text = "Responsável";
            // 
            // lsbNFOrigin
            // 
            this.lsbNFOrigin.FormattingEnabled = true;
            this.lsbNFOrigin.Location = new System.Drawing.Point(89, 32);
            this.lsbNFOrigin.Name = "lsbNFOrigin";
            this.lsbNFOrigin.Size = new System.Drawing.Size(74, 95);
            this.lsbNFOrigin.TabIndex = 78;
            // 
            // lblNFreturn
            // 
            this.lblNFreturn.AutoSize = true;
            this.lblNFreturn.Location = new System.Drawing.Point(6, 16);
            this.lblNFreturn.Name = "lblNFreturn";
            this.lblNFreturn.Size = new System.Drawing.Size(59, 13);
            this.lblNFreturn.TabIndex = 77;
            this.lblNFreturn.Text = "Devolução";
            // 
            // txtPhysicalReturn
            // 
            this.txtPhysicalReturn.Location = new System.Drawing.Point(169, 70);
            this.txtPhysicalReturn.Name = "txtPhysicalReturn";
            this.txtPhysicalReturn.Size = new System.Drawing.Size(115, 20);
            this.txtPhysicalReturn.TabIndex = 80;
            // 
            // lsbNFReturn
            // 
            this.lsbNFReturn.FormattingEnabled = true;
            this.lsbNFReturn.Location = new System.Drawing.Point(9, 32);
            this.lsbNFReturn.Name = "lsbNFReturn";
            this.lsbNFReturn.Size = new System.Drawing.Size(74, 95);
            this.lsbNFReturn.TabIndex = 0;
            // 
            // lblPhysicalReturn
            // 
            this.lblPhysicalReturn.AutoSize = true;
            this.lblPhysicalReturn.Location = new System.Drawing.Point(166, 54);
            this.lblPhysicalReturn.Name = "lblPhysicalReturn";
            this.lblPhysicalReturn.Size = new System.Drawing.Size(77, 13);
            this.lblPhysicalReturn.TabIndex = 81;
            this.lblPhysicalReturn.Text = "Retorno Físico";
            // 
            // txtOperation
            // 
            this.txtOperation.Location = new System.Drawing.Point(169, 31);
            this.txtOperation.Name = "txtOperation";
            this.txtOperation.Size = new System.Drawing.Size(115, 20);
            this.txtOperation.TabIndex = 78;
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.Location = new System.Drawing.Point(166, 15);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(54, 13);
            this.lblOperation.TabIndex = 79;
            this.lblOperation.Text = "Operação";
            // 
            // lblIdCi
            // 
            this.lblIdCi.AutoSize = true;
            this.lblIdCi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCi.Location = new System.Drawing.Point(12, 9);
            this.lblIdCi.Name = "lblIdCi";
            this.lblIdCi.Size = new System.Drawing.Size(83, 24);
            this.lblIdCi.TabIndex = 67;
            this.lblIdCi.Text = "Id: 0000";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(64, 31);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(405, 20);
            this.txtCustomer.TabIndex = 69;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(6, 31);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(49, 20);
            this.txtCustomerId.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 76;
            this.label7.Text = "Cliente";
            // 
            // txtTransporter
            // 
            this.txtTransporter.Location = new System.Drawing.Point(61, 109);
            this.txtTransporter.Name = "txtTransporter";
            this.txtTransporter.Size = new System.Drawing.Size(408, 20);
            this.txtTransporter.TabIndex = 73;
            // 
            // txtTransporterId
            // 
            this.txtTransporterId.Location = new System.Drawing.Point(6, 109);
            this.txtTransporterId.Name = "txtTransporterId";
            this.txtTransporterId.Size = new System.Drawing.Size(49, 20);
            this.txtTransporterId.TabIndex = 72;
            // 
            // lblTransporter
            // 
            this.lblTransporter.AutoSize = true;
            this.lblTransporter.Location = new System.Drawing.Point(3, 93);
            this.lblTransporter.Name = "lblTransporter";
            this.lblTransporter.Size = new System.Drawing.Size(73, 13);
            this.lblTransporter.TabIndex = 75;
            this.lblTransporter.Text = "Transportador";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(64, 70);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(405, 20);
            this.txtReason.TabIndex = 71;
            // 
            // txtReasonId
            // 
            this.txtReasonId.Location = new System.Drawing.Point(6, 70);
            this.txtReasonId.Name = "txtReasonId";
            this.txtReasonId.Size = new System.Drawing.Size(49, 20);
            this.txtReasonId.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Motivo";
            // 
            // gpbEntitiesInformation
            // 
            this.gpbEntitiesInformation.Controls.Add(this.txtCustomerId);
            this.gpbEntitiesInformation.Controls.Add(this.txtCustomer);
            this.gpbEntitiesInformation.Controls.Add(this.label1);
            this.gpbEntitiesInformation.Controls.Add(this.txtReasonId);
            this.gpbEntitiesInformation.Controls.Add(this.label7);
            this.gpbEntitiesInformation.Controls.Add(this.txtReason);
            this.gpbEntitiesInformation.Controls.Add(this.txtTransporter);
            this.gpbEntitiesInformation.Controls.Add(this.lblTransporter);
            this.gpbEntitiesInformation.Controls.Add(this.txtTransporterId);
            this.gpbEntitiesInformation.Location = new System.Drawing.Point(313, 36);
            this.gpbEntitiesInformation.Name = "gpbEntitiesInformation";
            this.gpbEntitiesInformation.Size = new System.Drawing.Size(475, 145);
            this.gpbEntitiesInformation.TabIndex = 1;
            this.gpbEntitiesInformation.TabStop = false;
            this.gpbEntitiesInformation.Text = "Informações sobre C.I";
            // 
            // lblNF
            // 
            this.lblNF.AutoSize = true;
            this.lblNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblNF.Location = new System.Drawing.Point(12, 184);
            this.lblNF.Name = "lblNF";
            this.lblNF.Size = new System.Drawing.Size(178, 20);
            this.lblNF.TabIndex = 68;
            this.lblNF.Text = "NF Refatura: 000000";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(16, 210);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(772, 204);
            this.dgvData.TabIndex = 69;
            // 
            // btnTotalReceipt
            // 
            this.btnTotalReceipt.Location = new System.Drawing.Point(632, 184);
            this.btnTotalReceipt.Name = "btnTotalReceipt";
            this.btnTotalReceipt.Size = new System.Drawing.Size(156, 23);
            this.btnTotalReceipt.TabIndex = 70;
            this.btnTotalReceipt.Text = "Recebimento Total";
            this.btnTotalReceipt.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(632, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 71;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(713, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 72;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnEncaminharFinanceiro
            // 
            this.btnEncaminharFinanceiro.Location = new System.Drawing.Point(470, 184);
            this.btnEncaminharFinanceiro.Name = "btnEncaminharFinanceiro";
            this.btnEncaminharFinanceiro.Size = new System.Drawing.Size(156, 23);
            this.btnEncaminharFinanceiro.TabIndex = 73;
            this.btnEncaminharFinanceiro.Text = "Encaminhar p/ Financeiro";
            this.btnEncaminharFinanceiro.UseVisualStyleBackColor = true;
            // 
            // frmCI_ConferenciaProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEncaminharFinanceiro);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTotalReceipt);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.lblNF);
            this.Controls.Add(this.gpbEntitiesInformation);
            this.Controls.Add(this.lblIdCi);
            this.Controls.Add(this.gpbNfInformation);
            this.Name = "frmCI_ConferenciaProdutos";
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Text = "Conferência de Produtos da C.I";
            this.gpbNfInformation.ResumeLayout(false);
            this.gpbNfInformation.PerformLayout();
            this.gpbEntitiesInformation.ResumeLayout(false);
            this.gpbEntitiesInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbNfInformation;
        private System.Windows.Forms.Label lblIdCi;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTransporter;
        private System.Windows.Forms.TextBox txtTransporterId;
        private System.Windows.Forms.Label lblTransporter;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox txtReasonId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpbEntitiesInformation;
        private System.Windows.Forms.Label lblNFreturn;
        private System.Windows.Forms.ListBox lsbNFReturn;
        private System.Windows.Forms.Label lblNfOrigin;
        private System.Windows.Forms.ListBox lsbNFOrigin;
        private System.Windows.Forms.TextBox txtOperation;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.TextBox txtPhysicalReturn;
        private System.Windows.Forms.Label lblPhysicalReturn;
        private System.Windows.Forms.TextBox txtResponsible;
        private System.Windows.Forms.Label lblResponsible;
        private System.Windows.Forms.Label lblNF;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnTotalReceipt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEncaminharFinanceiro;
    }
}