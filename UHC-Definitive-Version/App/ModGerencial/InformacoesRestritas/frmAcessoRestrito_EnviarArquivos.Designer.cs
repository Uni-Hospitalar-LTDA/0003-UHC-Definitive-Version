namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    partial class frmAcessoRestrito_EnviarArquivos
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
            this.lblTipoArquivo = new System.Windows.Forms.Label();
            this.cbxTipoArquivo = new System.Windows.Forms.ComboBox();
            this.lblEmpresaEmissora = new System.Windows.Forms.Label();
            this.cbxEmpresa = new System.Windows.Forms.ComboBox();
            this.lblColetores = new System.Windows.Forms.Label();
            this.clkListaColetores = new System.Windows.Forms.CheckedListBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.lblLogs = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblInterval = new System.Windows.Forms.Label();
            this.dtp0 = new System.Windows.Forms.DateTimePicker();
            this.dtpf = new System.Windows.Forms.DateTimePicker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTipoArquivo
            // 
            this.lblTipoArquivo.AutoSize = true;
            this.lblTipoArquivo.Location = new System.Drawing.Point(12, 9);
            this.lblTipoArquivo.Name = "lblTipoArquivo";
            this.lblTipoArquivo.Size = new System.Drawing.Size(82, 13);
            this.lblTipoArquivo.TabIndex = 0;
            this.lblTipoArquivo.Text = "Tipo do Arquivo";
            // 
            // cbxTipoArquivo
            // 
            this.cbxTipoArquivo.FormattingEnabled = true;
            this.cbxTipoArquivo.Location = new System.Drawing.Point(15, 25);
            this.cbxTipoArquivo.Name = "cbxTipoArquivo";
            this.cbxTipoArquivo.Size = new System.Drawing.Size(267, 21);
            this.cbxTipoArquivo.TabIndex = 1;
            // 
            // lblEmpresaEmissora
            // 
            this.lblEmpresaEmissora.AutoSize = true;
            this.lblEmpresaEmissora.Location = new System.Drawing.Point(12, 49);
            this.lblEmpresaEmissora.Name = "lblEmpresaEmissora";
            this.lblEmpresaEmissora.Size = new System.Drawing.Size(93, 13);
            this.lblEmpresaEmissora.TabIndex = 2;
            this.lblEmpresaEmissora.Text = "Empresa Emissora";
            // 
            // cbxEmpresa
            // 
            this.cbxEmpresa.FormattingEnabled = true;
            this.cbxEmpresa.Location = new System.Drawing.Point(15, 65);
            this.cbxEmpresa.Name = "cbxEmpresa";
            this.cbxEmpresa.Size = new System.Drawing.Size(267, 21);
            this.cbxEmpresa.TabIndex = 3;
            // 
            // lblColetores
            // 
            this.lblColetores.AutoSize = true;
            this.lblColetores.Location = new System.Drawing.Point(12, 134);
            this.lblColetores.Name = "lblColetores";
            this.lblColetores.Size = new System.Drawing.Size(51, 13);
            this.lblColetores.TabIndex = 4;
            this.lblColetores.Text = "Coletores";
            // 
            // clkListaColetores
            // 
            this.clkListaColetores.FormattingEnabled = true;
            this.clkListaColetores.Location = new System.Drawing.Point(15, 150);
            this.clkListaColetores.Name = "clkListaColetores";
            this.clkListaColetores.Size = new System.Drawing.Size(267, 169);
            this.clkListaColetores.TabIndex = 5;
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(288, 25);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(500, 295);
            this.dgvData.TabIndex = 6;
            // 
            // lblLogs
            // 
            this.lblLogs.AutoSize = true;
            this.lblLogs.Location = new System.Drawing.Point(285, 9);
            this.lblLogs.Name = "lblLogs";
            this.lblLogs.Size = new System.Drawing.Size(30, 13);
            this.lblLogs.TabIndex = 7;
            this.lblLogs.Text = "Logs";
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(713, 326);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 8;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Location = new System.Drawing.Point(632, 326);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(12, 89);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(94, 13);
            this.lblInterval.TabIndex = 10;
            this.lblInterval.Text = "Intervalo de Datas";
            // 
            // dtp0
            // 
            this.dtp0.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp0.Location = new System.Drawing.Point(15, 105);
            this.dtp0.Name = "dtp0";
            this.dtp0.Size = new System.Drawing.Size(102, 20);
            this.dtp0.TabIndex = 11;
            // 
            // dtpf
            // 
            this.dtpf.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpf.Location = new System.Drawing.Point(123, 105);
            this.dtpf.Name = "dtpf";
            this.dtpf.Size = new System.Drawing.Size(102, 20);
            this.dtpf.TabIndex = 12;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(288, 325);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(338, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // frmAcessoRestrito_EnviarArquivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 355);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dtpf);
            this.Controls.Add(this.dtp0);
            this.Controls.Add(this.lblInterval);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblLogs);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.clkListaColetores);
            this.Controls.Add(this.lblColetores);
            this.Controls.Add(this.cbxEmpresa);
            this.Controls.Add(this.lblEmpresaEmissora);
            this.Controls.Add(this.cbxTipoArquivo);
            this.Controls.Add(this.lblTipoArquivo);
            this.Name = "frmAcessoRestrito_EnviarArquivos";
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
            this.Text = "Envio de Informação para os Coletores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipoArquivo;
        private System.Windows.Forms.ComboBox cbxTipoArquivo;
        private System.Windows.Forms.Label lblEmpresaEmissora;
        private System.Windows.Forms.ComboBox cbxEmpresa;
        private System.Windows.Forms.Label lblColetores;
        private System.Windows.Forms.CheckedListBox clkListaColetores;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lblLogs;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.DateTimePicker dtp0;
        private System.Windows.Forms.DateTimePicker dtpf;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}