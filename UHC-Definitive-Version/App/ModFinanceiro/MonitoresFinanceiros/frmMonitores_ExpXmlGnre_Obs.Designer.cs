namespace UHC3_Definitive_Version.App.ModFinanceiro.MonitoresFinanceiros
{
    partial class frmMonitores_ExpXmlGnre_Obs
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
            this.lblNFs = new System.Windows.Forms.Label();
            this.lsbNfs = new System.Windows.Forms.ListBox();
            this.lblObs = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNFs
            // 
            this.lblNFs.AutoSize = true;
            this.lblNFs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNFs.Location = new System.Drawing.Point(306, 11);
            this.lblNFs.Name = "lblNFs";
            this.lblNFs.Size = new System.Drawing.Size(35, 16);
            this.lblNFs.TabIndex = 87;
            this.lblNFs.Text = "NFs";
            // 
            // lsbNfs
            // 
            this.lsbNfs.FormattingEnabled = true;
            this.lsbNfs.Location = new System.Drawing.Point(308, 30);
            this.lsbNfs.Margin = new System.Windows.Forms.Padding(2);
            this.lsbNfs.Name = "lsbNfs";
            this.lsbNfs.Size = new System.Drawing.Size(102, 160);
            this.lsbNfs.TabIndex = 86;
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObs.Location = new System.Drawing.Point(13, 11);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(196, 16);
            this.lblObs.TabIndex = 85;
            this.lblObs.Text = "Observação sobre a GNRE";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(337, 198);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(73, 34);
            this.btnCancelar.TabIndex = 84;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.Green;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(231, 198);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 34);
            this.btnConfirmar.TabIndex = 83;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(16, 30);
            this.txtObs.MaxLength = 300;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(288, 160);
            this.txtObs.TabIndex = 82;
            // 
            // frmMonitores_ExpXmlGnre_Obs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 242);
            this.Controls.Add(this.lblNFs);
            this.Controls.Add(this.lsbNfs);
            this.Controls.Add(this.lblObs);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtObs);
            this.Name = "frmMonitores_ExpXmlGnre_Obs";
            this.Text = "Gerar Manual";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNFs;
        private System.Windows.Forms.ListBox lsbNfs;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.TextBox txtObs;
    }
}