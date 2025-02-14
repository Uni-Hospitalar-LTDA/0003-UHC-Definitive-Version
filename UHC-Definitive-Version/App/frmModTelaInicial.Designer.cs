namespace UHC3_Definitive_Version.App
{
    partial class frmModTelaInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModTelaInicial));
            this.lblTextoMissao = new System.Windows.Forms.Label();
            this.lblMissao = new System.Windows.Forms.Label();
            this.picMainDesign = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMainDesign)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTextoMissao
            // 
            this.lblTextoMissao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblTextoMissao.AutoEllipsis = true;
            this.lblTextoMissao.AutoSize = true;
            this.lblTextoMissao.BackColor = System.Drawing.Color.Transparent;
            this.lblTextoMissao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTextoMissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoMissao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTextoMissao.Location = new System.Drawing.Point(120, 84);
            this.lblTextoMissao.Name = "lblTextoMissao";
            this.lblTextoMissao.Size = new System.Drawing.Size(711, 40);
            this.lblTextoMissao.TabIndex = 12;
            this.lblTextoMissao.Text = "Ser uma empresa sólida, confiável na distribuição de medicamentos, buscando sempr" +
    "e surpreender\r\ntodos os clientes na busca pela melhor prestação de serviços.";
            this.lblTextoMissao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMissao
            // 
            this.lblMissao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblMissao.AutoSize = true;
            this.lblMissao.BackColor = System.Drawing.Color.Transparent;
            this.lblMissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissao.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMissao.Location = new System.Drawing.Point(118, 53);
            this.lblMissao.Name = "lblMissao";
            this.lblMissao.Size = new System.Drawing.Size(106, 31);
            this.lblMissao.TabIndex = 11;
            this.lblMissao.Text = "Missão";
            // 
            // picMainDesign
            // 
            this.picMainDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picMainDesign.BackColor = System.Drawing.Color.Transparent;
            this.picMainDesign.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picMainDesign.Image = ((System.Drawing.Image)(resources.GetObject("picMainDesign.Image")));
            this.picMainDesign.Location = new System.Drawing.Point(-10, -16);
            this.picMainDesign.Margin = new System.Windows.Forms.Padding(0);
            this.picMainDesign.Name = "picMainDesign";
            this.picMainDesign.Size = new System.Drawing.Size(925, 581);
            this.picMainDesign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMainDesign.TabIndex = 13;
            this.picMainDesign.TabStop = false;
            // 
            // frmModTelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 574);
            this.Controls.Add(this.lblTextoMissao);
            this.Controls.Add(this.lblMissao);
            this.Controls.Add(this.picMainDesign);
            this.Name = "frmModTelaInicial";
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
            this.Text = "frmTelaInicial";
            ((System.ComponentModel.ISupportInitialize)(this.picMainDesign)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTextoMissao;
        private System.Windows.Forms.Label lblMissao;
        private System.Windows.Forms.PictureBox picMainDesign;
    }
}