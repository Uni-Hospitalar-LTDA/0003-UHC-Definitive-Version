﻿namespace UHC3_Definitive_Version.App.ModLogistica.CI
{
    partial class frmCI_Conferencia_Add
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtReasonId = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.txtResponsible = new System.Windows.Forms.TextBox();
            this.txtResponsibleId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObservation = new System.Windows.Forms.TextBox();
            this.gpbOperationType = new System.Windows.Forms.GroupBox();
            this.rdbWithoutDevolution = new System.Windows.Forms.RadioButton();
            this.rdbPartialDevolution = new System.Windows.Forms.RadioButton();
            this.rdbTotalReturn = new System.Windows.Forms.RadioButton();
            this.txtNF_rebill = new System.Windows.Forms.TextBox();
            this.lblNF_rebill = new System.Windows.Forms.Label();
            this.btnMoreNFs = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTransporter = new System.Windows.Forms.TextBox();
            this.txtTransporterId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gpbPhysicalReturn = new System.Windows.Forms.GroupBox();
            this.rdbNao = new System.Windows.Forms.RadioButton();
            this.rdbSim = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMoreReason = new System.Windows.Forms.Button();
            this.btnMoreResponsible = new System.Windows.Forms.Button();
            this.btnMoreTransporter = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnMoreCustomer = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.clbNFreturn = new System.Windows.Forms.CheckedListBox();
            this.lsbNFOrigin = new System.Windows.Forms.ListBox();
            this.clbProducts = new System.Windows.Forms.CheckedListBox();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddArquivo = new System.Windows.Forms.Button();
            this.gpbOperationType.SuspendLayout();
            this.gpbPhysicalReturn.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Motivo";
            // 
            // txtReasonId
            // 
            this.txtReasonId.Location = new System.Drawing.Point(12, 62);
            this.txtReasonId.Name = "txtReasonId";
            this.txtReasonId.Size = new System.Drawing.Size(49, 20);
            this.txtReasonId.TabIndex = 2;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(70, 62);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(428, 20);
            this.txtReason.TabIndex = 3;
            // 
            // txtResponsible
            // 
            this.txtResponsible.Location = new System.Drawing.Point(67, 101);
            this.txtResponsible.Name = "txtResponsible";
            this.txtResponsible.Size = new System.Drawing.Size(431, 20);
            this.txtResponsible.TabIndex = 5;
            // 
            // txtResponsibleId
            // 
            this.txtResponsibleId.Location = new System.Drawing.Point(12, 101);
            this.txtResponsibleId.Name = "txtResponsibleId";
            this.txtResponsibleId.Size = new System.Drawing.Size(49, 20);
            this.txtResponsibleId.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Responsável";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Observação";
            // 
            // txtObservation
            // 
            this.txtObservation.Location = new System.Drawing.Point(12, 381);
            this.txtObservation.Multiline = true;
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(860, 143);
            this.txtObservation.TabIndex = 15;
            // 
            // gpbOperationType
            // 
            this.gpbOperationType.Controls.Add(this.rdbWithoutDevolution);
            this.gpbOperationType.Controls.Add(this.rdbPartialDevolution);
            this.gpbOperationType.Controls.Add(this.rdbTotalReturn);
            this.gpbOperationType.Location = new System.Drawing.Point(534, 17);
            this.gpbOperationType.Name = "gpbOperationType";
            this.gpbOperationType.Size = new System.Drawing.Size(338, 50);
            this.gpbOperationType.TabIndex = 13;
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
            // txtNF_rebill
            // 
            this.txtNF_rebill.Location = new System.Drawing.Point(299, 258);
            this.txtNF_rebill.Name = "txtNF_rebill";
            this.txtNF_rebill.Size = new System.Drawing.Size(87, 20);
            this.txtNF_rebill.TabIndex = 11;
            // 
            // lblNF_rebill
            // 
            this.lblNF_rebill.AutoSize = true;
            this.lblNF_rebill.Location = new System.Drawing.Point(296, 243);
            this.lblNF_rebill.Name = "lblNF_rebill";
            this.lblNF_rebill.Size = new System.Drawing.Size(65, 13);
            this.lblNF_rebill.TabIndex = 13;
            this.lblNF_rebill.Text = "NF Refatura";
            // 
            // btnMoreNFs
            // 
            this.btnMoreNFs.Location = new System.Drawing.Point(391, 257);
            this.btnMoreNFs.Name = "btnMoreNFs";
            this.btnMoreNFs.Size = new System.Drawing.Size(24, 23);
            this.btnMoreNFs.TabIndex = 14;
            this.btnMoreNFs.Text = "...";
            this.btnMoreNFs.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "NFs Devolução";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(70, 25);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(428, 20);
            this.txtCustomer.TabIndex = 1;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(12, 25);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(49, 20);
            this.txtCustomerId.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Cliente";
            // 
            // txtTransporter
            // 
            this.txtTransporter.Location = new System.Drawing.Point(67, 140);
            this.txtTransporter.Name = "txtTransporter";
            this.txtTransporter.Size = new System.Drawing.Size(431, 20);
            this.txtTransporter.TabIndex = 7;
            // 
            // txtTransporterId
            // 
            this.txtTransporterId.Location = new System.Drawing.Point(12, 140);
            this.txtTransporterId.Name = "txtTransporterId";
            this.txtTransporterId.Size = new System.Drawing.Size(49, 20);
            this.txtTransporterId.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Transportador de Retorno";
            // 
            // gpbPhysicalReturn
            // 
            this.gpbPhysicalReturn.Controls.Add(this.rdbNao);
            this.gpbPhysicalReturn.Controls.Add(this.rdbSim);
            this.gpbPhysicalReturn.Enabled = false;
            this.gpbPhysicalReturn.Location = new System.Drawing.Point(299, 283);
            this.gpbPhysicalReturn.Name = "gpbPhysicalReturn";
            this.gpbPhysicalReturn.Size = new System.Drawing.Size(104, 50);
            this.gpbPhysicalReturn.TabIndex = 12;
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
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(797, 530);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnMoreReason
            // 
            this.btnMoreReason.Location = new System.Drawing.Point(504, 61);
            this.btnMoreReason.Name = "btnMoreReason";
            this.btnMoreReason.Size = new System.Drawing.Size(24, 23);
            this.btnMoreReason.TabIndex = 6;
            this.btnMoreReason.Text = "...";
            this.btnMoreReason.UseVisualStyleBackColor = true;
            // 
            // btnMoreResponsible
            // 
            this.btnMoreResponsible.Location = new System.Drawing.Point(504, 100);
            this.btnMoreResponsible.Name = "btnMoreResponsible";
            this.btnMoreResponsible.Size = new System.Drawing.Size(24, 23);
            this.btnMoreResponsible.TabIndex = 9;
            this.btnMoreResponsible.Text = "...";
            this.btnMoreResponsible.UseVisualStyleBackColor = true;
            // 
            // btnMoreTransporter
            // 
            this.btnMoreTransporter.Location = new System.Drawing.Point(504, 139);
            this.btnMoreTransporter.Name = "btnMoreTransporter";
            this.btnMoreTransporter.Size = new System.Drawing.Size(24, 23);
            this.btnMoreTransporter.TabIndex = 12;
            this.btnMoreTransporter.Text = "...";
            this.btnMoreTransporter.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(716, 530);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnMoreCustomer
            // 
            this.btnMoreCustomer.Location = new System.Drawing.Point(504, 24);
            this.btnMoreCustomer.Name = "btnMoreCustomer";
            this.btnMoreCustomer.Size = new System.Drawing.Size(24, 23);
            this.btnMoreCustomer.TabIndex = 2;
            this.btnMoreCustomer.Text = "...";
            this.btnMoreCustomer.UseVisualStyleBackColor = true;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(119, 224);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(62, 13);
            this.lbl.TabIndex = 32;
            this.lbl.Text = "NFs Origem";
            // 
            // clbNFreturn
            // 
            this.clbNFreturn.FormattingEnabled = true;
            this.clbNFreturn.Location = new System.Drawing.Point(14, 240);
            this.clbNFreturn.Name = "clbNFreturn";
            this.clbNFreturn.Size = new System.Drawing.Size(98, 109);
            this.clbNFreturn.TabIndex = 8;
            // 
            // lsbNFOrigin
            // 
            this.lsbNFOrigin.FormattingEnabled = true;
            this.lsbNFOrigin.Location = new System.Drawing.Point(122, 240);
            this.lsbNFOrigin.Name = "lsbNFOrigin";
            this.lsbNFOrigin.Size = new System.Drawing.Size(104, 108);
            this.lsbNFOrigin.TabIndex = 9;
            // 
            // clbProducts
            // 
            this.clbProducts.FormattingEnabled = true;
            this.clbProducts.Location = new System.Drawing.Point(534, 81);
            this.clbProducts.Name = "clbProducts";
            this.clbProducts.Size = new System.Drawing.Size(338, 259);
            this.clbProducts.TabIndex = 14;
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(11, 184);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(404, 20);
            this.txtArquivo.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Link do arquivo";
            // 
            // btnAddArquivo
            // 
            this.btnAddArquivo.Location = new System.Drawing.Point(421, 184);
            this.btnAddArquivo.Name = "btnAddArquivo";
            this.btnAddArquivo.Size = new System.Drawing.Size(106, 20);
            this.btnAddArquivo.TabIndex = 35;
            this.btnAddArquivo.Text = "Adicionar Arquivo";
            this.btnAddArquivo.UseVisualStyleBackColor = true;
            // 
            // frmCI_Conferencia_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 565);
            this.Controls.Add(this.btnAddArquivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtArquivo);
            this.Controls.Add(this.clbProducts);
            this.Controls.Add(this.lsbNFOrigin);
            this.Controls.Add(this.clbNFreturn);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnMoreCustomer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnMoreTransporter);
            this.Controls.Add(this.btnMoreResponsible);
            this.Controls.Add(this.btnMoreReason);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gpbPhysicalReturn);
            this.Controls.Add(this.txtTransporter);
            this.Controls.Add(this.txtTransporterId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnMoreNFs);
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
            this.Name = "frmCI_Conferencia_Add";
            this.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Border.ColorAngle = 45F;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Width = 5;
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Text = "Inserir C.I - Aba Logística";
            this.gpbOperationType.ResumeLayout(false);
            this.gpbOperationType.PerformLayout();
            this.gpbPhysicalReturn.ResumeLayout(false);
            this.gpbPhysicalReturn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReasonId;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox txtResponsible;
        private System.Windows.Forms.TextBox txtResponsibleId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtObservation;
        private System.Windows.Forms.GroupBox gpbOperationType;
        private System.Windows.Forms.RadioButton rdbPartialDevolution;
        private System.Windows.Forms.RadioButton rdbTotalReturn;
        private System.Windows.Forms.TextBox txtNF_rebill;
        private System.Windows.Forms.Label lblNF_rebill;
        private System.Windows.Forms.Button btnMoreNFs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTransporter;
        private System.Windows.Forms.TextBox txtTransporterId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gpbPhysicalReturn;
        private System.Windows.Forms.RadioButton rdbNao;
        private System.Windows.Forms.RadioButton rdbSim;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnMoreReason;
        private System.Windows.Forms.Button btnMoreResponsible;
        private System.Windows.Forms.Button btnMoreTransporter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMoreCustomer;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.CheckedListBox clbNFreturn;
        private System.Windows.Forms.ListBox lsbNFOrigin;
        private System.Windows.Forms.CheckedListBox clbProducts;
        private System.Windows.Forms.RadioButton rdbWithoutDevolution;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddArquivo;
    }
}