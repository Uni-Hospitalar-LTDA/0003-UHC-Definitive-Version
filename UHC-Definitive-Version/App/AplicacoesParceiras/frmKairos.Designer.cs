namespace UHC3_Definitive_Version.App.AplicacoesParceiras
{
    partial class frmKairos
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
            this.btnNotOpen = new System.Windows.Forms.Button();
            this.btnAttKairos = new System.Windows.Forms.Button();
            this.btnOpenKairos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnNotOpen
            // 
            this.btnNotOpen.Location = new System.Drawing.Point(158, 85);
            this.btnNotOpen.Name = "btnNotOpen";
            this.btnNotOpen.Size = new System.Drawing.Size(103, 23);
            this.btnNotOpen.TabIndex = 8;
            this.btnNotOpen.Text = "Kairos não abre";
            this.btnNotOpen.UseVisualStyleBackColor = true;
            // 
            // btnAttKairos
            // 
            this.btnAttKairos.Location = new System.Drawing.Point(158, 27);
            this.btnAttKairos.Name = "btnAttKairos";
            this.btnAttKairos.Size = new System.Drawing.Size(103, 23);
            this.btnAttKairos.TabIndex = 5;
            this.btnAttKairos.Text = "Atualizar Kairos";
            this.btnAttKairos.UseVisualStyleBackColor = true;
            // 
            // btnOpenKairos
            // 
            this.btnOpenKairos.Location = new System.Drawing.Point(158, 56);
            this.btnOpenKairos.Name = "btnOpenKairos";
            this.btnOpenKairos.Size = new System.Drawing.Size(103, 23);
            this.btnOpenKairos.TabIndex = 7;
            this.btnOpenKairos.Text = "Abrir Kairos";
            this.btnOpenKairos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Selecione o (Mes/Ano) da versão desejada";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // frmKairos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 116);
            this.Controls.Add(this.btnNotOpen);
            this.Controls.Add(this.btnAttKairos);
            this.Controls.Add(this.btnOpenKairos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "frmKairos";
            this.Text = "Kairos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNotOpen;
        private System.Windows.Forms.Button btnAttKairos;
        private System.Windows.Forms.Button btnOpenKairos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}