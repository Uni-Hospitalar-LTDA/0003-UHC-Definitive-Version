namespace UHC3_Definitive_Version.App.ModLicitacao.Cadastro
{
    partial class frmEditarPlataforma
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAccessLink = new System.Windows.Forms.Label();
            this.txtAccessLink = new System.Windows.Forms.TextBox();
            this.lblPlatformDescription = new System.Windows.Forms.Label();
            this.txtPlatformDescription = new System.Windows.Forms.TextBox();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.txtPlatformId = new System.Windows.Forms.TextBox();
            this.txtPlatformName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(360, 201);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(279, 201);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblAccessLink
            // 
            this.lblAccessLink.AutoSize = true;
            this.lblAccessLink.Location = new System.Drawing.Point(8, 49);
            this.lblAccessLink.Name = "lblAccessLink";
            this.lblAccessLink.Size = new System.Drawing.Size(80, 13);
            this.lblAccessLink.TabIndex = 28;
            this.lblAccessLink.Text = "Link de Acesso";
            // 
            // txtAccessLink
            // 
            this.txtAccessLink.Location = new System.Drawing.Point(11, 65);
            this.txtAccessLink.Name = "txtAccessLink";
            this.txtAccessLink.Size = new System.Drawing.Size(424, 20);
            this.txtAccessLink.TabIndex = 22;
            // 
            // lblPlatformDescription
            // 
            this.lblPlatformDescription.AutoSize = true;
            this.lblPlatformDescription.Location = new System.Drawing.Point(8, 88);
            this.lblPlatformDescription.Name = "lblPlatformDescription";
            this.lblPlatformDescription.Size = new System.Drawing.Size(65, 13);
            this.lblPlatformDescription.TabIndex = 27;
            this.lblPlatformDescription.Text = "Observação";
            // 
            // txtPlatformDescription
            // 
            this.txtPlatformDescription.Location = new System.Drawing.Point(11, 104);
            this.txtPlatformDescription.Multiline = true;
            this.txtPlatformDescription.Name = "txtPlatformDescription";
            this.txtPlatformDescription.Size = new System.Drawing.Size(424, 91);
            this.txtPlatformDescription.TabIndex = 23;
            // 
            // lblPlatform
            // 
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Location = new System.Drawing.Point(8, 7);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(57, 13);
            this.lblPlatform.TabIndex = 26;
            this.lblPlatform.Text = "Plataforma";
            // 
            // txtPlatformId
            // 
            this.txtPlatformId.Location = new System.Drawing.Point(11, 23);
            this.txtPlatformId.Name = "txtPlatformId";
            this.txtPlatformId.Size = new System.Drawing.Size(52, 20);
            this.txtPlatformId.TabIndex = 20;
            // 
            // txtPlatformName
            // 
            this.txtPlatformName.Location = new System.Drawing.Point(69, 23);
            this.txtPlatformName.Name = "txtPlatformName";
            this.txtPlatformName.Size = new System.Drawing.Size(366, 20);
            this.txtPlatformName.TabIndex = 21;
            // 
            // frmEditarPlataforma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 230);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAccessLink);
            this.Controls.Add(this.txtAccessLink);
            this.Controls.Add(this.lblPlatformDescription);
            this.Controls.Add(this.txtPlatformDescription);
            this.Controls.Add(this.lblPlatform);
            this.Controls.Add(this.txtPlatformId);
            this.Controls.Add(this.txtPlatformName);
            this.Name = "frmEditarPlataforma";
            this.Text = "Editar Plataforma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAccessLink;
        private System.Windows.Forms.TextBox txtAccessLink;
        private System.Windows.Forms.Label lblPlatformDescription;
        private System.Windows.Forms.TextBox txtPlatformDescription;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.TextBox txtPlatformId;
        private System.Windows.Forms.TextBox txtPlatformName;
    }
}