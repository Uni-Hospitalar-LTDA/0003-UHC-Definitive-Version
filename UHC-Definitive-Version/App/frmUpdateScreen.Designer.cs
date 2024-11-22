namespace UHC_DEFINITIVE_VERSION.App
{
    partial class frmUpdateScreen
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblQueroSaber = new System.Windows.Forms.LinkLabel();
            this.lblNovidades = new System.Windows.Forms.Label();
            this.lblTextoMissao = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Verificando novas atualizações...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 505);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(846, 29);
            this.progressBar1.TabIndex = 2;
            // 
            // lblQueroSaber
            // 
            this.lblQueroSaber.AutoSize = true;
            this.lblQueroSaber.Location = new System.Drawing.Point(790, 186);
            this.lblQueroSaber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQueroSaber.Name = "lblQueroSaber";
            this.lblQueroSaber.Size = new System.Drawing.Size(68, 13);
            this.lblQueroSaber.TabIndex = 9;
            this.lblQueroSaber.TabStop = true;
            this.lblQueroSaber.Text = "Quero saber!";
            // 
            // lblNovidades
            // 
            this.lblNovidades.AutoSize = true;
            this.lblNovidades.BackColor = System.Drawing.Color.Transparent;
            this.lblNovidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblNovidades.Location = new System.Drawing.Point(556, 179);
            this.lblNovidades.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNovidades.Name = "lblNovidades";
            this.lblNovidades.Size = new System.Drawing.Size(233, 25);
            this.lblNovidades.TabIndex = 8;
            this.lblNovidades.Text = "Quais são as novidades?";
            // 
            // lblTextoMissao
            // 
            this.lblTextoMissao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblTextoMissao.AutoEllipsis = true;
            this.lblTextoMissao.AutoSize = true;
            this.lblTextoMissao.BackColor = System.Drawing.Color.Transparent;
            this.lblTextoMissao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTextoMissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoMissao.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTextoMissao.Location = new System.Drawing.Point(557, 262);
            this.lblTextoMissao.Name = "lblTextoMissao";
            this.lblTextoMissao.Size = new System.Drawing.Size(301, 80);
            this.lblTextoMissao.TabIndex = 13;
            this.lblTextoMissao.Text = "Ser uma empresa sólida, confiável na \r\ndistribuição de medicamentos, buscando \r\ns" +
    "empre surpreender todos os clientes na \r\nbusca pela melhor prestação de serviços" +
    ".";
            this.lblTextoMissao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(561, 207);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(297, 292);
            this.txtInfo.TabIndex = 14;
            // 
            // frmUpdateScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UHC3_Definitive_Version.Properties.Resources.Uni_Hospitalar_Load;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(887, 546);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lblTextoMissao);
            this.Controls.Add(this.lblQueroSaber);
            this.Controls.Add(this.lblNovidades);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Name = "frmUpdateScreen";
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
            this.Text = "Tela de Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.LinkLabel lblQueroSaber;
        private System.Windows.Forms.Label lblNovidades;
        private System.Windows.Forms.Label lblTextoMissao;
        private System.Windows.Forms.TextBox txtInfo;
    }
}