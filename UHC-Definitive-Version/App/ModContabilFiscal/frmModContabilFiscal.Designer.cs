namespace UHC3_Definitive_Version.App.ModContabilFiscal
{
    partial class frmModContabilFiscal
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gpbConfiguracao = new System.Windows.Forms.GroupBox();
            this.btnParametrizacaoFiscalPorUf = new System.Windows.Forms.Button();
            this.gpbRelatorios = new System.Windows.Forms.GroupBox();
            this.btnRelatorioDifalDevSintetico = new System.Windows.Forms.Button();
            this.btnRelatorioDifalDevAnalitico = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.gpbConfiguracao.SuspendLayout();
            this.gpbRelatorios.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(472, 46);
            this.lblTitle.TabIndex = 66;
            this.lblTitle.Text = "Módulo Contábil / Fiscal";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.gpbConfiguracao);
            this.flowLayoutPanel1.Controls.Add(this.gpbRelatorios);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 350);
            this.flowLayoutPanel1.TabIndex = 67;
            // 
            // gpbConfiguracao
            // 
            this.gpbConfiguracao.Controls.Add(this.btnParametrizacaoFiscalPorUf);
            this.gpbConfiguracao.ForeColor = System.Drawing.Color.White;
            this.gpbConfiguracao.Location = new System.Drawing.Point(3, 3);
            this.gpbConfiguracao.Name = "gpbConfiguracao";
            this.gpbConfiguracao.Size = new System.Drawing.Size(188, 258);
            this.gpbConfiguracao.TabIndex = 6;
            this.gpbConfiguracao.TabStop = false;
            this.gpbConfiguracao.Text = "Configurações";
            // 
            // btnParametrizacaoFiscalPorUf
            // 
            this.btnParametrizacaoFiscalPorUf.ForeColor = System.Drawing.Color.Black;
            this.btnParametrizacaoFiscalPorUf.Location = new System.Drawing.Point(8, 19);
            this.btnParametrizacaoFiscalPorUf.Name = "btnParametrizacaoFiscalPorUf";
            this.btnParametrizacaoFiscalPorUf.Size = new System.Drawing.Size(170, 39);
            this.btnParametrizacaoFiscalPorUf.TabIndex = 2;
            this.btnParametrizacaoFiscalPorUf.Text = "Parametrização Fiscal por UF";
            this.btnParametrizacaoFiscalPorUf.UseVisualStyleBackColor = true;
            // 
            // gpbRelatorios
            // 
            this.gpbRelatorios.Controls.Add(this.btnRelatorioDifalDevSintetico);
            this.gpbRelatorios.Controls.Add(this.btnRelatorioDifalDevAnalitico);
            this.gpbRelatorios.ForeColor = System.Drawing.Color.White;
            this.gpbRelatorios.Location = new System.Drawing.Point(197, 3);
            this.gpbRelatorios.Name = "gpbRelatorios";
            this.gpbRelatorios.Size = new System.Drawing.Size(188, 258);
            this.gpbRelatorios.TabIndex = 5;
            this.gpbRelatorios.TabStop = false;
            this.gpbRelatorios.Text = "Relatórios";
            // 
            // btnRelatorioDifalDevSintetico
            // 
            this.btnRelatorioDifalDevSintetico.ForeColor = System.Drawing.Color.Black;
            this.btnRelatorioDifalDevSintetico.Location = new System.Drawing.Point(8, 64);
            this.btnRelatorioDifalDevSintetico.Name = "btnRelatorioDifalDevSintetico";
            this.btnRelatorioDifalDevSintetico.Size = new System.Drawing.Size(170, 39);
            this.btnRelatorioDifalDevSintetico.TabIndex = 3;
            this.btnRelatorioDifalDevSintetico.Text = "Relação de Difal x Dev. (Sintético)";
            this.btnRelatorioDifalDevSintetico.UseVisualStyleBackColor = true;
            // 
            // btnRelatorioDifalDevAnalitico
            // 
            this.btnRelatorioDifalDevAnalitico.ForeColor = System.Drawing.Color.Black;
            this.btnRelatorioDifalDevAnalitico.Location = new System.Drawing.Point(8, 19);
            this.btnRelatorioDifalDevAnalitico.Name = "btnRelatorioDifalDevAnalitico";
            this.btnRelatorioDifalDevAnalitico.Size = new System.Drawing.Size(170, 39);
            this.btnRelatorioDifalDevAnalitico.TabIndex = 2;
            this.btnRelatorioDifalDevAnalitico.Text = "Relação de Difal x Dev. (Analítico)";
            this.btnRelatorioDifalDevAnalitico.UseVisualStyleBackColor = true;
            // 
            // frmModContabilFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmModContabilFiscal";
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
            this.Text = "Módulo Contábil / Fiscal";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gpbConfiguracao.ResumeLayout(false);
            this.gpbRelatorios.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox gpbConfiguracao;
        private System.Windows.Forms.Button btnParametrizacaoFiscalPorUf;
        private System.Windows.Forms.GroupBox gpbRelatorios;
        private System.Windows.Forms.Button btnRelatorioDifalDevSintetico;
        private System.Windows.Forms.Button btnRelatorioDifalDevAnalitico;
    }
}