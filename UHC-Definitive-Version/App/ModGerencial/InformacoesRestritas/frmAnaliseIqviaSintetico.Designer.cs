namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    partial class frmAnaliseIqviaSintetico
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
            this.gpFiltros = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lblIntervaloDeDatas = new System.Windows.Forms.Label();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtQtdsTotais = new System.Windows.Forms.TextBox();
            this.txtValorBuscado = new System.Windows.Forms.TextBox();
            this.lblValorBuscado = new System.Windows.Forms.Label();
            this.btnSugestoes = new System.Windows.Forms.Button();
            this.gpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // gpFiltros
            // 
            this.gpFiltros.Controls.Add(this.btnFiltrar);
            this.gpFiltros.Controls.Add(this.lblIntervaloDeDatas);
            this.gpFiltros.Controls.Add(this.dtpDataFinal);
            this.gpFiltros.Controls.Add(this.dtpDataInicial);
            this.gpFiltros.Location = new System.Drawing.Point(12, 29);
            this.gpFiltros.Name = "gpFiltros";
            this.gpFiltros.Size = new System.Drawing.Size(299, 71);
            this.gpFiltros.TabIndex = 0;
            this.gpFiltros.TabStop = false;
            this.gpFiltros.Text = "Filtros";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(214, 32);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // lblIntervaloDeDatas
            // 
            this.lblIntervaloDeDatas.AutoSize = true;
            this.lblIntervaloDeDatas.Location = new System.Drawing.Point(6, 18);
            this.lblIntervaloDeDatas.Name = "lblIntervaloDeDatas";
            this.lblIntervaloDeDatas.Size = new System.Drawing.Size(94, 13);
            this.lblIntervaloDeDatas.TabIndex = 2;
            this.lblIntervaloDeDatas.Text = "Intervalo de Datas";
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFinal.Location = new System.Drawing.Point(110, 34);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(98, 20);
            this.dtpDataFinal.TabIndex = 1;
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicial.Location = new System.Drawing.Point(6, 34);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(98, 20);
            this.dtpDataInicial.TabIndex = 0;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 106);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(891, 379);
            this.dgvData.TabIndex = 1;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(828, 491);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(317, 29);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(64, 13);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Qtds. Totais";
            // 
            // txtQtdsTotais
            // 
            this.txtQtdsTotais.Location = new System.Drawing.Point(320, 45);
            this.txtQtdsTotais.Name = "txtQtdsTotais";
            this.txtQtdsTotais.Size = new System.Drawing.Size(111, 20);
            this.txtQtdsTotais.TabIndex = 4;
            // 
            // txtValorBuscado
            // 
            this.txtValorBuscado.Location = new System.Drawing.Point(437, 45);
            this.txtValorBuscado.Name = "txtValorBuscado";
            this.txtValorBuscado.Size = new System.Drawing.Size(111, 20);
            this.txtValorBuscado.TabIndex = 5;
            // 
            // lblValorBuscado
            // 
            this.lblValorBuscado.AutoSize = true;
            this.lblValorBuscado.Location = new System.Drawing.Point(434, 29);
            this.lblValorBuscado.Name = "lblValorBuscado";
            this.lblValorBuscado.Size = new System.Drawing.Size(75, 13);
            this.lblValorBuscado.TabIndex = 6;
            this.lblValorBuscado.Text = "Valor buscado";
            // 
            // btnSugestoes
            // 
            this.btnSugestoes.Location = new System.Drawing.Point(554, 43);
            this.btnSugestoes.Name = "btnSugestoes";
            this.btnSugestoes.Size = new System.Drawing.Size(31, 23);
            this.btnSugestoes.TabIndex = 4;
            this.btnSugestoes.Text = "...";
            this.btnSugestoes.UseVisualStyleBackColor = true;
            // 
            // frmAnaliseIqviaSintetico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 521);
            this.Controls.Add(this.btnSugestoes);
            this.Controls.Add(this.lblValorBuscado);
            this.Controls.Add(this.txtValorBuscado);
            this.Controls.Add(this.txtQtdsTotais);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.gpFiltros);
            this.Name = "frmAnaliseIqviaSintetico";
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
            this.Text = "Análise de Vendas Iqvia (Sintético)";
            this.gpFiltros.ResumeLayout(false);
            this.gpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpFiltros;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.Label lblIntervaloDeDatas;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtQtdsTotais;
        private System.Windows.Forms.TextBox txtValorBuscado;
        private System.Windows.Forms.Label lblValorBuscado;
        private System.Windows.Forms.Button btnSugestoes;
    }
}