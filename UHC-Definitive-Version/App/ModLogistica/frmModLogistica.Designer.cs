namespace UHC3_Definitive_Version.App.ModLogistica
{
    partial class frmModLogistica
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
            this.btnDeslogar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gpbCI = new System.Windows.Forms.GroupBox();
            this.btnMotivosCI = new System.Windows.Forms.Button();
            this.btnConferenciaCI = new System.Windows.Forms.Button();
            this.lblLogistica = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.gpbCI.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeslogar
            // 
            this.btnDeslogar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeslogar.Location = new System.Drawing.Point(627, 417);
            this.btnDeslogar.Name = "btnDeslogar";
            this.btnDeslogar.Size = new System.Drawing.Size(75, 23);
            this.btnDeslogar.TabIndex = 82;
            this.btnDeslogar.Text = "Deslogar";
            this.btnDeslogar.UseVisualStyleBackColor = true;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.Location = new System.Drawing.Point(708, 417);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 81;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.gpbCI);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 60);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(764, 347);
            this.flowLayoutPanel1.TabIndex = 80;
            // 
            // gpbCI
            // 
            this.gpbCI.Controls.Add(this.btnMotivosCI);
            this.gpbCI.Controls.Add(this.btnConferenciaCI);
            this.gpbCI.ForeColor = System.Drawing.Color.White;
            this.gpbCI.Location = new System.Drawing.Point(3, 3);
            this.gpbCI.Name = "gpbCI";
            this.gpbCI.Size = new System.Drawing.Size(188, 258);
            this.gpbCI.TabIndex = 7;
            this.gpbCI.TabStop = false;
            this.gpbCI.Text = "C.I.";
            // 
            // btnMotivosCI
            // 
            this.btnMotivosCI.ForeColor = System.Drawing.Color.Black;
            this.btnMotivosCI.Location = new System.Drawing.Point(6, 64);
            this.btnMotivosCI.Name = "btnMotivosCI";
            this.btnMotivosCI.Size = new System.Drawing.Size(170, 39);
            this.btnMotivosCI.TabIndex = 14;
            this.btnMotivosCI.Text = "Motivos de C.I.";
            this.btnMotivosCI.UseVisualStyleBackColor = true;
            // 
            // btnConferenciaCI
            // 
            this.btnConferenciaCI.ForeColor = System.Drawing.Color.Black;
            this.btnConferenciaCI.Location = new System.Drawing.Point(6, 19);
            this.btnConferenciaCI.Name = "btnConferenciaCI";
            this.btnConferenciaCI.Size = new System.Drawing.Size(170, 39);
            this.btnConferenciaCI.TabIndex = 13;
            this.btnConferenciaCI.Text = "Conferência de C.I.";
            this.btnConferenciaCI.UseVisualStyleBackColor = true;
            // 
            // lblLogistica
            // 
            this.lblLogistica.AutoSize = true;
            this.lblLogistica.BackColor = System.Drawing.Color.Transparent;
            this.lblLogistica.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.lblLogistica.ForeColor = System.Drawing.Color.Transparent;
            this.lblLogistica.Location = new System.Drawing.Point(18, 11);
            this.lblLogistica.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblLogistica.Name = "lblLogistica";
            this.lblLogistica.Size = new System.Drawing.Size(396, 46);
            this.lblLogistica.TabIndex = 79;
            this.lblLogistica.Text = "Módulo de Logística";
            // 
            // frmModLogistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeslogar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblLogistica);
            this.Name = "frmModLogistica";
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
            this.Text = "Módulo de Logística";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gpbCI.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeslogar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox gpbCI;
        private System.Windows.Forms.Button btnConferenciaCI;
        private System.Windows.Forms.Label lblLogistica;
        private System.Windows.Forms.Button btnMotivosCI;
    }
}