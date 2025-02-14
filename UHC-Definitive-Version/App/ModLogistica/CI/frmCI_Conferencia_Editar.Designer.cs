namespace UHC3_Definitive_Version.App.ModLogistica.CI
{
    partial class frmCI_Conferencia_Editar
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
            this.lsbNFOrigin = new System.Windows.Forms.ListBox();
            this.lbl = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gpbPhysicalReturn = new System.Windows.Forms.GroupBox();
            this.rdbNao = new System.Windows.Forms.RadioButton();
            this.rdbSim = new System.Windows.Forms.RadioButton();
            this.txtTransporter = new System.Windows.Forms.TextBox();
            this.txtTransporterId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNF_rebill = new System.Windows.Forms.Label();
            this.txtNF_rebill = new System.Windows.Forms.TextBox();
            this.gpbOperationType = new System.Windows.Forms.GroupBox();
            this.rdbWithoutDevolution = new System.Windows.Forms.RadioButton();
            this.rdbPartialDevolution = new System.Windows.Forms.RadioButton();
            this.rdbTotalReturn = new System.Windows.Forms.RadioButton();
            this.txtObservation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResponsible = new System.Windows.Forms.TextBox();
            this.txtResponsibleId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.txtReasonId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbNFReturn = new System.Windows.Forms.ListBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.lblProdutos = new System.Windows.Forms.Label();
            this.lblIdCi = new System.Windows.Forms.Label();
            this.btnMoreTransporter = new System.Windows.Forms.Button();
            this.btnMoreResponsible = new System.Windows.Forms.Button();
            this.txtRegister = new System.Windows.Forms.TextBox();
            this.lblRegister = new System.Windows.Forms.Label();
            this.lblEdited = new System.Windows.Forms.Label();
            this.txtEdited = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gpbPhysicalReturn.SuspendLayout();
            this.gpbOperationType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // lsbNFOrigin
            // 
            this.lsbNFOrigin.FormattingEnabled = true;
            this.lsbNFOrigin.Location = new System.Drawing.Point(657, 89);
            this.lsbNFOrigin.Name = "lsbNFOrigin";
            this.lsbNFOrigin.Size = new System.Drawing.Size(104, 108);
            this.lsbNFOrigin.TabIndex = 47;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(654, 73);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(62, 13);
            this.lbl.TabIndex = 62;
            this.lbl.Text = "NFs Origem";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(719, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(800, 514);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gpbPhysicalReturn
            // 
            this.gpbPhysicalReturn.Controls.Add(this.rdbNao);
            this.gpbPhysicalReturn.Controls.Add(this.rdbSim);
            this.gpbPhysicalReturn.Enabled = false;
            this.gpbPhysicalReturn.Location = new System.Drawing.Point(771, 115);
            this.gpbPhysicalReturn.Name = "gpbPhysicalReturn";
            this.gpbPhysicalReturn.Size = new System.Drawing.Size(104, 50);
            this.gpbPhysicalReturn.TabIndex = 50;
            this.gpbPhysicalReturn.TabStop = false;
            this.gpbPhysicalReturn.Text = "Retorno físico";
            // 
            // rdbNao
            // 
            this.rdbNao.AutoSize = true;
            this.rdbNao.Location = new System.Drawing.Point(54, 19);
            this.rdbNao.Name = "rdbNao";
            this.rdbNao.Size = new System.Drawing.Size(45, 17);
            this.rdbNao.TabIndex = 1;
            this.rdbNao.TabStop = true;
            this.rdbNao.Text = "Não";
            this.rdbNao.UseVisualStyleBackColor = true;
            // 
            // rdbSim
            // 
            this.rdbSim.AutoSize = true;
            this.rdbSim.Location = new System.Drawing.Point(6, 19);
            this.rdbSim.Name = "rdbSim";
            this.rdbSim.Size = new System.Drawing.Size(42, 17);
            this.rdbSim.TabIndex = 0;
            this.rdbSim.TabStop = true;
            this.rdbSim.Text = "Sim";
            this.rdbSim.UseVisualStyleBackColor = true;
            // 
            // txtTransporter
            // 
            this.txtTransporter.Location = new System.Drawing.Point(67, 177);
            this.txtTransporter.Name = "txtTransporter";
            this.txtTransporter.Size = new System.Drawing.Size(431, 20);
            this.txtTransporter.TabIndex = 9;
            // 
            // txtTransporterId
            // 
            this.txtTransporterId.Location = new System.Drawing.Point(12, 177);
            this.txtTransporterId.Name = "txtTransporterId";
            this.txtTransporterId.Size = new System.Drawing.Size(49, 20);
            this.txtTransporterId.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Transportador de Retorno";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(70, 60);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(458, 20);
            this.txtCustomer.TabIndex = 2;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(12, 60);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(49, 20);
            this.txtCustomerId.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Cliente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(544, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "NFs Devolução";
            // 
            // lblNF_rebill
            // 
            this.lblNF_rebill.AutoSize = true;
            this.lblNF_rebill.Location = new System.Drawing.Point(768, 74);
            this.lblNF_rebill.Name = "lblNF_rebill";
            this.lblNF_rebill.Size = new System.Drawing.Size(65, 13);
            this.lblNF_rebill.TabIndex = 53;
            this.lblNF_rebill.Text = "NF Refatura";
            // 
            // txtNF_rebill
            // 
            this.txtNF_rebill.Location = new System.Drawing.Point(771, 89);
            this.txtNF_rebill.Name = "txtNF_rebill";
            this.txtNF_rebill.Size = new System.Drawing.Size(104, 20);
            this.txtNF_rebill.TabIndex = 11;
            // 
            // gpbOperationType
            // 
            this.gpbOperationType.Controls.Add(this.rdbWithoutDevolution);
            this.gpbOperationType.Controls.Add(this.rdbPartialDevolution);
            this.gpbOperationType.Controls.Add(this.rdbTotalReturn);
            this.gpbOperationType.Location = new System.Drawing.Point(537, 7);
            this.gpbOperationType.Name = "gpbOperationType";
            this.gpbOperationType.Size = new System.Drawing.Size(338, 50);
            this.gpbOperationType.TabIndex = 52;
            this.gpbOperationType.TabStop = false;
            this.gpbOperationType.Text = "Tipo de Operação";
            // 
            // rdbWithoutDevolution
            // 
            this.rdbWithoutDevolution.AutoSize = true;
            this.rdbWithoutDevolution.Location = new System.Drawing.Point(225, 19);
            this.rdbWithoutDevolution.Name = "rdbWithoutDevolution";
            this.rdbWithoutDevolution.Size = new System.Drawing.Size(99, 17);
            this.rdbWithoutDevolution.TabIndex = 2;
            this.rdbWithoutDevolution.TabStop = true;
            this.rdbWithoutDevolution.Text = "Sem devolução";
            this.rdbWithoutDevolution.UseVisualStyleBackColor = true;
            // 
            // rdbPartialDevolution
            // 
            this.rdbPartialDevolution.AutoSize = true;
            this.rdbPartialDevolution.Location = new System.Drawing.Point(108, 19);
            this.rdbPartialDevolution.Name = "rdbPartialDevolution";
            this.rdbPartialDevolution.Size = new System.Drawing.Size(111, 17);
            this.rdbPartialDevolution.TabIndex = 1;
            this.rdbPartialDevolution.TabStop = true;
            this.rdbPartialDevolution.Text = "Devolução parcial";
            this.rdbPartialDevolution.UseVisualStyleBackColor = true;
            // 
            // rdbTotalReturn
            // 
            this.rdbTotalReturn.AutoSize = true;
            this.rdbTotalReturn.Location = new System.Drawing.Point(6, 19);
            this.rdbTotalReturn.Name = "rdbTotalReturn";
            this.rdbTotalReturn.Size = new System.Drawing.Size(100, 17);
            this.rdbTotalReturn.TabIndex = 0;
            this.rdbTotalReturn.TabStop = true;
            this.rdbTotalReturn.Text = "Devolução total";
            this.rdbTotalReturn.UseVisualStyleBackColor = true;
            // 
            // txtObservation
            // 
            this.txtObservation.Location = new System.Drawing.Point(12, 365);
            this.txtObservation.Multiline = true;
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(863, 143);
            this.txtObservation.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Observação";
            // 
            // txtResponsible
            // 
            this.txtResponsible.Location = new System.Drawing.Point(67, 138);
            this.txtResponsible.Name = "txtResponsible";
            this.txtResponsible.Size = new System.Drawing.Size(431, 20);
            this.txtResponsible.TabIndex = 6;
            // 
            // txtResponsibleId
            // 
            this.txtResponsibleId.Location = new System.Drawing.Point(12, 138);
            this.txtResponsibleId.Name = "txtResponsibleId";
            this.txtResponsibleId.Size = new System.Drawing.Size(49, 20);
            this.txtResponsibleId.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Responsável";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(70, 99);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(458, 20);
            this.txtReason.TabIndex = 4;
            // 
            // txtReasonId
            // 
            this.txtReasonId.Location = new System.Drawing.Point(12, 99);
            this.txtReasonId.Name = "txtReasonId";
            this.txtReasonId.Size = new System.Drawing.Size(49, 20);
            this.txtReasonId.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Motivo";
            // 
            // lsbNFReturn
            // 
            this.lsbNFReturn.FormattingEnabled = true;
            this.lsbNFReturn.Location = new System.Drawing.Point(544, 89);
            this.lsbNFReturn.Name = "lsbNFReturn";
            this.lsbNFReturn.Size = new System.Drawing.Size(104, 108);
            this.lsbNFReturn.TabIndex = 63;
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 216);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(863, 130);
            this.dgvProducts.TabIndex = 64;
            // 
            // lblProdutos
            // 
            this.lblProdutos.AutoSize = true;
            this.lblProdutos.Location = new System.Drawing.Point(9, 200);
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(49, 13);
            this.lblProdutos.TabIndex = 65;
            this.lblProdutos.Text = "Produtos";
            // 
            // lblIdCi
            // 
            this.lblIdCi.AutoSize = true;
            this.lblIdCi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCi.Location = new System.Drawing.Point(8, 17);
            this.lblIdCi.Name = "lblIdCi";
            this.lblIdCi.Size = new System.Drawing.Size(83, 24);
            this.lblIdCi.TabIndex = 66;
            this.lblIdCi.Text = "Id: 0000";
            // 
            // btnMoreTransporter
            // 
            this.btnMoreTransporter.Location = new System.Drawing.Point(504, 176);
            this.btnMoreTransporter.Name = "btnMoreTransporter";
            this.btnMoreTransporter.Size = new System.Drawing.Size(24, 23);
            this.btnMoreTransporter.TabIndex = 10;
            this.btnMoreTransporter.Text = "...";
            this.btnMoreTransporter.UseVisualStyleBackColor = true;
            // 
            // btnMoreResponsible
            // 
            this.btnMoreResponsible.Location = new System.Drawing.Point(504, 137);
            this.btnMoreResponsible.Name = "btnMoreResponsible";
            this.btnMoreResponsible.Size = new System.Drawing.Size(24, 23);
            this.btnMoreResponsible.TabIndex = 7;
            this.btnMoreResponsible.Text = "...";
            this.btnMoreResponsible.UseVisualStyleBackColor = true;
            // 
            // txtRegister
            // 
            this.txtRegister.Location = new System.Drawing.Point(292, 26);
            this.txtRegister.Name = "txtRegister";
            this.txtRegister.Size = new System.Drawing.Size(110, 20);
            this.txtRegister.TabIndex = 67;
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Location = new System.Drawing.Point(289, 10);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(46, 13);
            this.lblRegister.TabIndex = 68;
            this.lblRegister.Text = "Registro";
            // 
            // lblEdited
            // 
            this.lblEdited.AutoSize = true;
            this.lblEdited.Location = new System.Drawing.Point(405, 10);
            this.lblEdited.Name = "lblEdited";
            this.lblEdited.Size = new System.Drawing.Size(40, 13);
            this.lblEdited.TabIndex = 70;
            this.lblEdited.Text = "Edição";
            // 
            // txtEdited
            // 
            this.txtEdited.Location = new System.Drawing.Point(408, 26);
            this.txtEdited.Name = "txtEdited";
            this.txtEdited.Size = new System.Drawing.Size(110, 20);
            this.txtEdited.TabIndex = 69;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(159, 26);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(127, 20);
            this.txtStatus.TabIndex = 71;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(156, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 72;
            this.lblStatus.Text = "Status";
            // 
            // frmCI_Conferencia_Editar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 549);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblEdited);
            this.Controls.Add(this.txtEdited);
            this.Controls.Add(this.lblRegister);
            this.Controls.Add(this.txtRegister);
            this.Controls.Add(this.lblIdCi);
            this.Controls.Add(this.lblProdutos);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.lsbNFReturn);
            this.Controls.Add(this.lsbNFOrigin);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnMoreTransporter);
            this.Controls.Add(this.btnMoreResponsible);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gpbPhysicalReturn);
            this.Controls.Add(this.txtTransporter);
            this.Controls.Add(this.txtTransporterId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblNF_rebill);
            this.Controls.Add(this.txtNF_rebill);
            this.Controls.Add(this.gpbOperationType);
            this.Controls.Add(this.txtObservation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtResponsible);
            this.Controls.Add(this.txtResponsibleId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.txtReasonId);
            this.Controls.Add(this.label1);
            this.Name = "frmCI_Conferencia_Editar";
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Text = "Conferência de C.I - Aba Logística (Editar)";
            this.gpbPhysicalReturn.ResumeLayout(false);
            this.gpbPhysicalReturn.PerformLayout();
            this.gpbOperationType.ResumeLayout(false);
            this.gpbOperationType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lsbNFOrigin;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gpbPhysicalReturn;
        private System.Windows.Forms.RadioButton rdbNao;
        private System.Windows.Forms.RadioButton rdbSim;
        private System.Windows.Forms.TextBox txtTransporter;
        private System.Windows.Forms.TextBox txtTransporterId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNF_rebill;
        private System.Windows.Forms.TextBox txtNF_rebill;
        private System.Windows.Forms.GroupBox gpbOperationType;
        private System.Windows.Forms.RadioButton rdbWithoutDevolution;
        private System.Windows.Forms.RadioButton rdbPartialDevolution;
        private System.Windows.Forms.RadioButton rdbTotalReturn;
        private System.Windows.Forms.TextBox txtObservation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResponsible;
        private System.Windows.Forms.TextBox txtResponsibleId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox txtReasonId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbNFReturn;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label lblProdutos;
        private System.Windows.Forms.Label lblIdCi;
        private System.Windows.Forms.Button btnMoreTransporter;
        private System.Windows.Forms.Button btnMoreResponsible;
        private System.Windows.Forms.TextBox txtRegister;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Label lblEdited;
        private System.Windows.Forms.TextBox txtEdited;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblStatus;
    }
}