namespace UHC3_Definitive_Version.App.ModFinanceiro.Cobranca
{
    partial class frmParametrosDeCobranca
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gpbNotification = new System.Windows.Forms.GroupBox();
            this.chkDueDateNotification = new System.Windows.Forms.CheckBox();
            this.chkNotifyOnDueDate = new System.Windows.Forms.CheckBox();
            this.lblDueDate_6 = new System.Windows.Forms.Label();
            this.lblDueDate_5 = new System.Windows.Forms.Label();
            this.txtDaysRecoveryNotification = new System.Windows.Forms.TextBox();
            this.lblDueDate_4 = new System.Windows.Forms.Label();
            this.lblDueDate_3 = new System.Windows.Forms.Label();
            this.lblDueDate_1 = new System.Windows.Forms.Label();
            this.txtDaysPostDueDateAlert = new System.Windows.Forms.TextBox();
            this.lblDueDate_2 = new System.Windows.Forms.Label();
            this.txtDaysDueDateAlert = new System.Windows.Forms.TextBox();
            this.gpbNotification.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(324, 155);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(405, 155);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // gpbNotification
            // 
            this.gpbNotification.Controls.Add(this.chkDueDateNotification);
            this.gpbNotification.Controls.Add(this.chkNotifyOnDueDate);
            this.gpbNotification.Controls.Add(this.lblDueDate_6);
            this.gpbNotification.Controls.Add(this.lblDueDate_5);
            this.gpbNotification.Controls.Add(this.txtDaysRecoveryNotification);
            this.gpbNotification.Controls.Add(this.lblDueDate_4);
            this.gpbNotification.Controls.Add(this.lblDueDate_3);
            this.gpbNotification.Controls.Add(this.lblDueDate_1);
            this.gpbNotification.Controls.Add(this.txtDaysPostDueDateAlert);
            this.gpbNotification.Controls.Add(this.lblDueDate_2);
            this.gpbNotification.Controls.Add(this.txtDaysDueDateAlert);
            this.gpbNotification.Location = new System.Drawing.Point(12, 12);
            this.gpbNotification.Name = "gpbNotification";
            this.gpbNotification.Size = new System.Drawing.Size(468, 137);
            this.gpbNotification.TabIndex = 3;
            this.gpbNotification.TabStop = false;
            this.gpbNotification.Text = "Configurar Notificações";
            // 
            // chkDueDateNotification
            // 
            this.chkDueDateNotification.AutoSize = true;
            this.chkDueDateNotification.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkDueDateNotification.Location = new System.Drawing.Point(401, 0);
            this.chkDueDateNotification.Name = "chkDueDateNotification";
            this.chkDueDateNotification.Size = new System.Drawing.Size(50, 17);
            this.chkDueDateNotification.TabIndex = 4;
            this.chkDueDateNotification.Text = "Ativo";
            this.chkDueDateNotification.UseVisualStyleBackColor = true;
            // 
            // chkNotifyOnDueDate
            // 
            this.chkNotifyOnDueDate.AutoSize = true;
            this.chkNotifyOnDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkNotifyOnDueDate.Location = new System.Drawing.Point(9, 107);
            this.chkNotifyOnDueDate.Name = "chkNotifyOnDueDate";
            this.chkNotifyOnDueDate.Size = new System.Drawing.Size(173, 17);
            this.chkNotifyOnDueDate.TabIndex = 3;
            this.chkNotifyOnDueDate.Text = "Notificar no Dia do Vencimento";
            this.chkNotifyOnDueDate.UseVisualStyleBackColor = true;
            // 
            // lblDueDate_6
            // 
            this.lblDueDate_6.AutoSize = true;
            this.lblDueDate_6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDueDate_6.Location = new System.Drawing.Point(417, 81);
            this.lblDueDate_6.Name = "lblDueDate_6";
            this.lblDueDate_6.Size = new System.Drawing.Size(34, 13);
            this.lblDueDate_6.TabIndex = 9;
            this.lblDueDate_6.Text = "Dia(s)";
            // 
            // lblDueDate_5
            // 
            this.lblDueDate_5.AutoSize = true;
            this.lblDueDate_5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDueDate_5.Location = new System.Drawing.Point(6, 81);
            this.lblDueDate_5.Name = "lblDueDate_5";
            this.lblDueDate_5.Size = new System.Drawing.Size(329, 13);
            this.lblDueDate_5.TabIndex = 8;
            this.lblDueDate_5.Text = "Após o Vencimento, a mensagem de Cobrança será enviada a cada";
            // 
            // txtDaysRecoveryNotification
            // 
            this.txtDaysRecoveryNotification.Location = new System.Drawing.Point(341, 78);
            this.txtDaysRecoveryNotification.Name = "txtDaysRecoveryNotification";
            this.txtDaysRecoveryNotification.Size = new System.Drawing.Size(70, 20);
            this.txtDaysRecoveryNotification.TabIndex = 2;
            // 
            // lblDueDate_4
            // 
            this.lblDueDate_4.AutoSize = true;
            this.lblDueDate_4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDueDate_4.Location = new System.Drawing.Point(332, 52);
            this.lblDueDate_4.Name = "lblDueDate_4";
            this.lblDueDate_4.Size = new System.Drawing.Size(120, 13);
            this.lblDueDate_4.TabIndex = 6;
            this.lblDueDate_4.Text = "Dia(s) até o Vencimento";
            // 
            // lblDueDate_3
            // 
            this.lblDueDate_3.AutoSize = true;
            this.lblDueDate_3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDueDate_3.Location = new System.Drawing.Point(6, 52);
            this.lblDueDate_3.Name = "lblDueDate_3";
            this.lblDueDate_3.Size = new System.Drawing.Size(247, 13);
            this.lblDueDate_3.TabIndex = 5;
            this.lblDueDate_3.Text = "Após o alerta,  a mensagem será reenviada a cada";
            // 
            // lblDueDate_1
            // 
            this.lblDueDate_1.AutoSize = true;
            this.lblDueDate_1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDueDate_1.Location = new System.Drawing.Point(6, 26);
            this.lblDueDate_1.Name = "lblDueDate_1";
            this.lblDueDate_1.Size = new System.Drawing.Size(40, 13);
            this.lblDueDate_1.TabIndex = 4;
            this.lblDueDate_1.Text = "Alertar ";
            // 
            // txtDaysPostDueDateAlert
            // 
            this.txtDaysPostDueDateAlert.Location = new System.Drawing.Point(256, 49);
            this.txtDaysPostDueDateAlert.Name = "txtDaysPostDueDateAlert";
            this.txtDaysPostDueDateAlert.Size = new System.Drawing.Size(70, 20);
            this.txtDaysPostDueDateAlert.TabIndex = 1;
            // 
            // lblDueDate_2
            // 
            this.lblDueDate_2.AutoSize = true;
            this.lblDueDate_2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDueDate_2.Location = new System.Drawing.Point(123, 26);
            this.lblDueDate_2.Name = "lblDueDate_2";
            this.lblDueDate_2.Size = new System.Drawing.Size(137, 13);
            this.lblDueDate_2.TabIndex = 2;
            this.lblDueDate_2.Text = "Dia(s) antes do Vencimento";
            // 
            // txtDaysDueDateAlert
            // 
            this.txtDaysDueDateAlert.Location = new System.Drawing.Point(47, 23);
            this.txtDaysDueDateAlert.Name = "txtDaysDueDateAlert";
            this.txtDaysDueDateAlert.Size = new System.Drawing.Size(70, 20);
            this.txtDaysDueDateAlert.TabIndex = 0;
            // 
            // frmParametrosDeCobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 186);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gpbNotification);
            this.Name = "frmParametrosDeCobranca";
            this.Text = "Configurar Parâmetros de Cobrança";
            this.gpbNotification.ResumeLayout(false);
            this.gpbNotification.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gpbNotification;
        private System.Windows.Forms.CheckBox chkDueDateNotification;
        private System.Windows.Forms.CheckBox chkNotifyOnDueDate;
        private System.Windows.Forms.Label lblDueDate_6;
        private System.Windows.Forms.Label lblDueDate_5;
        private System.Windows.Forms.TextBox txtDaysRecoveryNotification;
        private System.Windows.Forms.Label lblDueDate_4;
        private System.Windows.Forms.Label lblDueDate_3;
        private System.Windows.Forms.Label lblDueDate_1;
        private System.Windows.Forms.TextBox txtDaysPostDueDateAlert;
        private System.Windows.Forms.Label lblDueDate_2;
        private System.Windows.Forms.TextBox txtDaysDueDateAlert;
    }
}