namespace UHC3_Definitive_Version.App.ModGerencial
{
    partial class frmControladoria
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
            this.lblControladoria = new System.Windows.Forms.Label();
            this.gpbEmissaoArquivos = new System.Windows.Forms.GroupBox();
            this.lblArquivosIMS = new System.Windows.Forms.Label();
            this.gpbEmissaoArquivos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(717, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblControladoria
            // 
            this.lblControladoria.AutoSize = true;
            this.lblControladoria.BackColor = System.Drawing.Color.Gainsboro;
            this.lblControladoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.lblControladoria.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblControladoria.Location = new System.Drawing.Point(8, 9);
            this.lblControladoria.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblControladoria.Name = "lblControladoria";
            this.lblControladoria.Size = new System.Drawing.Size(274, 46);
            this.lblControladoria.TabIndex = 36;
            this.lblControladoria.Text = "Controladoria";
            // 
            // gpbEmissaoArquivos
            // 
            this.gpbEmissaoArquivos.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbEmissaoArquivos.Controls.Add(this.lblArquivosIMS);
            this.gpbEmissaoArquivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.gpbEmissaoArquivos.Location = new System.Drawing.Point(16, 58);
            this.gpbEmissaoArquivos.Name = "gpbEmissaoArquivos";
            this.gpbEmissaoArquivos.Size = new System.Drawing.Size(232, 85);
            this.gpbEmissaoArquivos.TabIndex = 35;
            this.gpbEmissaoArquivos.TabStop = false;
            this.gpbEmissaoArquivos.Text = "Emissão de Arquivos";
            // 
            // lblArquivosIMS
            // 
            this.lblArquivosIMS.AutoSize = true;
            this.lblArquivosIMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArquivosIMS.Location = new System.Drawing.Point(11, 25);
            this.lblArquivosIMS.Name = "lblArquivosIMS";
            this.lblArquivosIMS.Size = new System.Drawing.Size(95, 18);
            this.lblArquivosIMS.TabIndex = 3;
            this.lblArquivosIMS.Text = "Arquivos IMS";
            // 
            // frmControladoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblControladoria);
            this.Controls.Add(this.gpbEmissaoArquivos);
            this.Name = "frmControladoria";
            this.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Border.ColorAngle = 45F;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Width = 5;
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.Text = "Controladoria";
            this.gpbEmissaoArquivos.ResumeLayout(false);
            this.gpbEmissaoArquivos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblControladoria;
        private System.Windows.Forms.GroupBox gpbEmissaoArquivos;
        private System.Windows.Forms.Label lblArquivosIMS;
    }
}