namespace UHC3_Definitive_Version.App.ModFinanceiro.Pagamentos
{
    partial class frmRankingContasPagar
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.lblVlrTotal = new System.Windows.Forms.Label();
            this.txtVlrTotal = new System.Windows.Forms.TextBox();
            this.lblMediaTotal = new System.Windows.Forms.Label();
            this.lblMediaTop10 = new System.Windows.Forms.Label();
            this.txtMediaTop10 = new System.Windows.Forms.TextBox();
            this.txtMediaTotal = new System.Windows.Forms.TextBox();
            this.dtpDatCorte = new System.Windows.Forms.DateTimePicker();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.gpbInformacoes = new System.Windows.Forms.GroupBox();
            this.lblData = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gpbInformacoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 115);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(928, 304);
            this.dgvData.TabIndex = 2;
            // 
            // lblVlrTotal
            // 
            this.lblVlrTotal.AutoSize = true;
            this.lblVlrTotal.Location = new System.Drawing.Point(256, 20);
            this.lblVlrTotal.Name = "lblVlrTotal";
            this.lblVlrTotal.Size = new System.Drawing.Size(58, 13);
            this.lblVlrTotal.TabIndex = 14;
            this.lblVlrTotal.Text = "Valor Total";
            // 
            // txtVlrTotal
            // 
            this.txtVlrTotal.Location = new System.Drawing.Point(259, 36);
            this.txtVlrTotal.Name = "txtVlrTotal";
            this.txtVlrTotal.Size = new System.Drawing.Size(108, 20);
            this.txtVlrTotal.TabIndex = 15;
            // 
            // lblMediaTotal
            // 
            this.lblMediaTotal.AutoSize = true;
            this.lblMediaTotal.Location = new System.Drawing.Point(133, 20);
            this.lblMediaTotal.Name = "lblMediaTotal";
            this.lblMediaTotal.Size = new System.Drawing.Size(63, 13);
            this.lblMediaTotal.TabIndex = 10;
            this.lblMediaTotal.Text = "Média Total";
            // 
            // lblMediaTop10
            // 
            this.lblMediaTop10.AutoSize = true;
            this.lblMediaTop10.Location = new System.Drawing.Point(3, 20);
            this.lblMediaTop10.Name = "lblMediaTop10";
            this.lblMediaTop10.Size = new System.Drawing.Size(70, 13);
            this.lblMediaTop10.TabIndex = 12;
            this.lblMediaTop10.Text = "Média Top10";
            // 
            // txtMediaTop10
            // 
            this.txtMediaTop10.Location = new System.Drawing.Point(6, 36);
            this.txtMediaTop10.Name = "txtMediaTop10";
            this.txtMediaTop10.Size = new System.Drawing.Size(108, 20);
            this.txtMediaTop10.TabIndex = 13;
            // 
            // txtMediaTotal
            // 
            this.txtMediaTotal.Location = new System.Drawing.Point(136, 36);
            this.txtMediaTotal.Name = "txtMediaTotal";
            this.txtMediaTotal.Size = new System.Drawing.Size(108, 20);
            this.txtMediaTotal.TabIndex = 11;
            // 
            // dtpDatCorte
            // 
            this.dtpDatCorte.Location = new System.Drawing.Point(12, 50);
            this.dtpDatCorte.Name = "dtpDatCorte";
            this.dtpDatCorte.Size = new System.Drawing.Size(230, 20);
            this.dtpDatCorte.TabIndex = 16;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(248, 47);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 18;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // gpbInformacoes
            // 
            this.gpbInformacoes.Controls.Add(this.txtMediaTop10);
            this.gpbInformacoes.Controls.Add(this.lblMediaTop10);
            this.gpbInformacoes.Controls.Add(this.txtMediaTotal);
            this.gpbInformacoes.Controls.Add(this.lblMediaTotal);
            this.gpbInformacoes.Controls.Add(this.lblVlrTotal);
            this.gpbInformacoes.Controls.Add(this.txtVlrTotal);
            this.gpbInformacoes.Location = new System.Drawing.Point(389, 31);
            this.gpbInformacoes.Name = "gpbInformacoes";
            this.gpbInformacoes.Size = new System.Drawing.Size(382, 78);
            this.gpbInformacoes.TabIndex = 19;
            this.gpbInformacoes.TabStop = false;
            this.gpbInformacoes.Text = "informações";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(9, 31);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(109, 16);
            this.lblData.TabIndex = 20;
            this.lblData.Text = "Selecione a data";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(865, 425);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 21;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // frmRankingContasPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 455);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.gpbInformacoes);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dtpDatCorte);
            this.Controls.Add(this.dgvData);
            this.Name = "frmRankingContasPagar";
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
            this.Text = "Ranking a Pagar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gpbInformacoes.ResumeLayout(false);
            this.gpbInformacoes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lblVlrTotal;
        private System.Windows.Forms.TextBox txtVlrTotal;
        private System.Windows.Forms.Label lblMediaTotal;
        private System.Windows.Forms.Label lblMediaTop10;
        private System.Windows.Forms.TextBox txtMediaTop10;
        private System.Windows.Forms.TextBox txtMediaTotal;
        private System.Windows.Forms.DateTimePicker dtpDatCorte;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.GroupBox gpbInformacoes;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Button btnFechar;
    }
}