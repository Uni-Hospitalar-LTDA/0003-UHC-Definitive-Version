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
            this.cbxUnidade = new System.Windows.Forms.ComboBox();
            this.lblUnidade = new System.Windows.Forms.Label();
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
            this.txtGrupos = new System.Windows.Forms.TextBox();
            this.lblGrupos = new System.Windows.Forms.Label();
            this.lblFabricantes = new System.Windows.Forms.Label();
            this.txtFabricantes = new System.Windows.Forms.TextBox();
            this.lblEsfera = new System.Windows.Forms.Label();
            this.txtEsfera = new System.Windows.Forms.TextBox();
            this.gpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // gpFiltros
            // 
            this.gpFiltros.Controls.Add(this.cbxUnidade);
            this.gpFiltros.Controls.Add(this.lblUnidade);
            this.gpFiltros.Controls.Add(this.btnFiltrar);
            this.gpFiltros.Controls.Add(this.lblIntervaloDeDatas);
            this.gpFiltros.Controls.Add(this.dtpDataFinal);
            this.gpFiltros.Controls.Add(this.dtpDataInicial);
            this.gpFiltros.Location = new System.Drawing.Point(12, 29);
            this.gpFiltros.Name = "gpFiltros";
            this.gpFiltros.Size = new System.Drawing.Size(222, 104);
            this.gpFiltros.TabIndex = 0;
            this.gpFiltros.TabStop = false;
            this.gpFiltros.Text = "Filtros";
            // 
            // cbxUnidade
            // 
            this.cbxUnidade.FormattingEnabled = true;
            this.cbxUnidade.Location = new System.Drawing.Point(9, 73);
            this.cbxUnidade.Name = "cbxUnidade";
            this.cbxUnidade.Size = new System.Drawing.Size(115, 21);
            this.cbxUnidade.TabIndex = 2;
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.Location = new System.Drawing.Point(6, 57);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(47, 13);
            this.lblUnidade.TabIndex = 4;
            this.lblUnidade.Text = "Unidade";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(133, 71);
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
            this.dgvData.Location = new System.Drawing.Point(12, 139);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(891, 346);
            this.dgvData.TabIndex = 1;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(828, 491);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(237, 27);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(64, 13);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Qtds. Totais";
            // 
            // txtQtdsTotais
            // 
            this.txtQtdsTotais.Location = new System.Drawing.Point(240, 43);
            this.txtQtdsTotais.Name = "txtQtdsTotais";
            this.txtQtdsTotais.Size = new System.Drawing.Size(111, 20);
            this.txtQtdsTotais.TabIndex = 1;
            // 
            // txtValorBuscado
            // 
            this.txtValorBuscado.Location = new System.Drawing.Point(357, 43);
            this.txtValorBuscado.Name = "txtValorBuscado";
            this.txtValorBuscado.Size = new System.Drawing.Size(111, 20);
            this.txtValorBuscado.TabIndex = 2;
            // 
            // lblValorBuscado
            // 
            this.lblValorBuscado.AutoSize = true;
            this.lblValorBuscado.Location = new System.Drawing.Point(354, 27);
            this.lblValorBuscado.Name = "lblValorBuscado";
            this.lblValorBuscado.Size = new System.Drawing.Size(75, 13);
            this.lblValorBuscado.TabIndex = 6;
            this.lblValorBuscado.Text = "Valor buscado";
            // 
            // btnSugestoes
            // 
            this.btnSugestoes.Location = new System.Drawing.Point(474, 41);
            this.btnSugestoes.Name = "btnSugestoes";
            this.btnSugestoes.Size = new System.Drawing.Size(31, 23);
            this.btnSugestoes.TabIndex = 4;
            this.btnSugestoes.Text = "...";
            this.btnSugestoes.UseVisualStyleBackColor = true;
            // 
            // txtGrupos
            // 
            this.txtGrupos.Location = new System.Drawing.Point(240, 83);
            this.txtGrupos.Multiline = true;
            this.txtGrupos.Name = "txtGrupos";
            this.txtGrupos.Size = new System.Drawing.Size(189, 50);
            this.txtGrupos.TabIndex = 3;
            // 
            // lblGrupos
            // 
            this.lblGrupos.AutoSize = true;
            this.lblGrupos.Location = new System.Drawing.Point(240, 67);
            this.lblGrupos.Name = "lblGrupos";
            this.lblGrupos.Size = new System.Drawing.Size(41, 13);
            this.lblGrupos.TabIndex = 8;
            this.lblGrupos.Text = "Grupos";
            // 
            // lblFabricantes
            // 
            this.lblFabricantes.AutoSize = true;
            this.lblFabricantes.Location = new System.Drawing.Point(435, 67);
            this.lblFabricantes.Name = "lblFabricantes";
            this.lblFabricantes.Size = new System.Drawing.Size(62, 13);
            this.lblFabricantes.TabIndex = 10;
            this.lblFabricantes.Text = "Fabricantes";
            // 
            // txtFabricantes
            // 
            this.txtFabricantes.Location = new System.Drawing.Point(435, 83);
            this.txtFabricantes.Multiline = true;
            this.txtFabricantes.Name = "txtFabricantes";
            this.txtFabricantes.Size = new System.Drawing.Size(189, 50);
            this.txtFabricantes.TabIndex = 4;
            // 
            // lblEsfera
            // 
            this.lblEsfera.AutoSize = true;
            this.lblEsfera.Location = new System.Drawing.Point(630, 67);
            this.lblEsfera.Name = "lblEsfera";
            this.lblEsfera.Size = new System.Drawing.Size(37, 13);
            this.lblEsfera.TabIndex = 12;
            this.lblEsfera.Text = "Esfera";
            // 
            // txtEsfera
            // 
            this.txtEsfera.Location = new System.Drawing.Point(630, 83);
            this.txtEsfera.Multiline = true;
            this.txtEsfera.Name = "txtEsfera";
            this.txtEsfera.Size = new System.Drawing.Size(189, 50);
            this.txtEsfera.TabIndex = 5;
            // 
            // frmAnaliseIqviaSintetico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 521);
            this.Controls.Add(this.lblEsfera);
            this.Controls.Add(this.txtEsfera);
            this.Controls.Add(this.lblFabricantes);
            this.Controls.Add(this.txtFabricantes);
            this.Controls.Add(this.lblGrupos);
            this.Controls.Add(this.txtGrupos);
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
        private System.Windows.Forms.Label lblUnidade;
        private System.Windows.Forms.ComboBox cbxUnidade;
        private System.Windows.Forms.TextBox txtGrupos;
        private System.Windows.Forms.Label lblGrupos;
        private System.Windows.Forms.Label lblFabricantes;
        private System.Windows.Forms.TextBox txtFabricantes;
        private System.Windows.Forms.Label lblEsfera;
        private System.Windows.Forms.TextBox txtEsfera;
    }
}