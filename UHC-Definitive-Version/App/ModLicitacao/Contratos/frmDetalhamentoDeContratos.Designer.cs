namespace UHC3_Definitive_Version.App.ModLicitacao.AnaliseVendas
{
    partial class frmDetalhamentoDeContratos
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtGiroInicial = new System.Windows.Forms.TextBox();
            this.dgvColor = new System.Windows.Forms.DataGridView();
            this.lblFiltroPorPregao = new System.Windows.Forms.Label();
            this.txtFiltroPregao = new System.Windows.Forms.TextBox();
            this.txtGiroFinal = new System.Windows.Forms.TextBox();
            this.lblFiltroPorGiro = new System.Windows.Forms.Label();
            this.lblContadorDeLinhas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtCodFabricante = new System.Windows.Forms.TextBox();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblProdutoGenerico = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
            this.txtProdutoGenerico = new System.Windows.Forms.TextBox();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtDescricaoCliente = new System.Windows.Forms.TextBox();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.txtDescricaoFabricante = new System.Windows.Forms.TextBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnSalvarPrecosCompra = new System.Windows.Forms.Button();
            this.gpboxFiltro = new System.Windows.Forms.GroupBox();
            this.rdbDatInicioFinal = new System.Windows.Forms.RadioButton();
            this.rdbDatFinal = new System.Windows.Forms.RadioButton();
            this.rdbDatInicial = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gpboxFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Até";
            // 
            // txtGiroInicial
            // 
            this.txtGiroInicial.Location = new System.Drawing.Point(13, 392);
            this.txtGiroInicial.Name = "txtGiroInicial";
            this.txtGiroInicial.Size = new System.Drawing.Size(47, 20);
            this.txtGiroInicial.TabIndex = 61;
            // 
            // dgvColor
            // 
            this.dgvColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColor.Location = new System.Drawing.Point(480, 46);
            this.dgvColor.Name = "dgvColor";
            this.dgvColor.RowHeadersWidth = 51;
            this.dgvColor.Size = new System.Drawing.Size(218, 137);
            this.dgvColor.TabIndex = 60;
            // 
            // lblFiltroPorPregao
            // 
            this.lblFiltroPorPregao.AutoSize = true;
            this.lblFiltroPorPregao.Location = new System.Drawing.Point(14, 294);
            this.lblFiltroPorPregao.Name = "lblFiltroPorPregao";
            this.lblFiltroPorPregao.Size = new System.Drawing.Size(133, 13);
            this.lblFiltroPorPregao.TabIndex = 59;
            this.lblFiltroPorPregao.Text = "Filtro por Contrato (Pregão)";
            // 
            // txtFiltroPregao
            // 
            this.txtFiltroPregao.Location = new System.Drawing.Point(13, 310);
            this.txtFiltroPregao.Name = "txtFiltroPregao";
            this.txtFiltroPregao.Size = new System.Drawing.Size(558, 20);
            this.txtFiltroPregao.TabIndex = 58;
            // 
            // txtGiroFinal
            // 
            this.txtGiroFinal.Location = new System.Drawing.Point(91, 392);
            this.txtGiroFinal.Name = "txtGiroFinal";
            this.txtGiroFinal.Size = new System.Drawing.Size(47, 20);
            this.txtGiroFinal.TabIndex = 57;
            // 
            // lblFiltroPorGiro
            // 
            this.lblFiltroPorGiro.AutoSize = true;
            this.lblFiltroPorGiro.Location = new System.Drawing.Point(10, 372);
            this.lblFiltroPorGiro.Name = "lblFiltroPorGiro";
            this.lblFiltroPorGiro.Size = new System.Drawing.Size(102, 13);
            this.lblFiltroPorGiro.TabIndex = 56;
            this.lblFiltroPorGiro.Text = "Intervalo de Giro (%)";
            // 
            // lblContadorDeLinhas
            // 
            this.lblContadorDeLinhas.AutoSize = true;
            this.lblContadorDeLinhas.Location = new System.Drawing.Point(10, 415);
            this.lblContadorDeLinhas.Name = "lblContadorDeLinhas";
            this.lblContadorDeLinhas.Size = new System.Drawing.Size(74, 13);
            this.lblContadorDeLinhas.TabIndex = 55;
            this.lblContadorDeLinhas.Text = "Selected (1/x)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Filtro por Status";
            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(272, 348);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(299, 21);
            this.cbxStatus.TabIndex = 53;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(10, 333);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(83, 13);
            this.lblEstado.TabIndex = 52;
            this.lblEstado.Text = "Filtro por Estado";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(13, 349);
            this.txtEstado.MaxLength = 40;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(253, 20);
            this.txtEstado.TabIndex = 51;
            // 
            // txtCodFabricante
            // 
            this.txtCodFabricante.Location = new System.Drawing.Point(13, 163);
            this.txtCodFabricante.Name = "txtCodFabricante";
            this.txtCodFabricante.Size = new System.Drawing.Size(72, 20);
            this.txtCodFabricante.TabIndex = 39;
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(10, 147);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(100, 13);
            this.lblFabricante.TabIndex = 49;
            this.lblFabricante.Text = "Filtro por Fabricante";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(10, 106);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(82, 13);
            this.lblCliente.TabIndex = 48;
            this.lblCliente.Text = "Filtro por Cliente";
            // 
            // lblProdutoGenerico
            // 
            this.lblProdutoGenerico.AutoSize = true;
            this.lblProdutoGenerico.Location = new System.Drawing.Point(10, 69);
            this.lblProdutoGenerico.Name = "lblProdutoGenerico";
            this.lblProdutoGenerico.Size = new System.Drawing.Size(179, 13);
            this.lblProdutoGenerico.TabIndex = 47;
            this.lblProdutoGenerico.Text = "Filtro por Nome Genérico do Produto";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(10, 30);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(87, 13);
            this.lblProduto.TabIndex = 46;
            this.lblProduto.Text = "Filtro por Produto";
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Location = new System.Drawing.Point(13, 46);
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.Size = new System.Drawing.Size(72, 20);
            this.txtCodProduto.TabIndex = 35;
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.Location = new System.Drawing.Point(91, 46);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.Size = new System.Drawing.Size(383, 20);
            this.txtDescricaoProduto.TabIndex = 45;
            // 
            // txtProdutoGenerico
            // 
            this.txtProdutoGenerico.Location = new System.Drawing.Point(13, 83);
            this.txtProdutoGenerico.Name = "txtProdutoGenerico";
            this.txtProdutoGenerico.Size = new System.Drawing.Size(461, 20);
            this.txtProdutoGenerico.TabIndex = 36;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(13, 122);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(72, 20);
            this.txtCodCliente.TabIndex = 38;
            // 
            // txtDescricaoCliente
            // 
            this.txtDescricaoCliente.Location = new System.Drawing.Point(91, 122);
            this.txtDescricaoCliente.Name = "txtDescricaoCliente";
            this.txtDescricaoCliente.Size = new System.Drawing.Size(383, 20);
            this.txtDescricaoCliente.TabIndex = 42;
            // 
            // dtpInicial
            // 
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicial.Location = new System.Drawing.Point(13, 32);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpInicial.Size = new System.Drawing.Size(96, 20);
            this.dtpInicial.TabIndex = 40;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(115, 32);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpFinal.Size = new System.Drawing.Size(99, 20);
            this.dtpFinal.TabIndex = 41;
            // 
            // txtDescricaoFabricante
            // 
            this.txtDescricaoFabricante.Location = new System.Drawing.Point(91, 163);
            this.txtDescricaoFabricante.Name = "txtDescricaoFabricante";
            this.txtDescricaoFabricante.Size = new System.Drawing.Size(383, 20);
            this.txtDescricaoFabricante.TabIndex = 37;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(1024, 624);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 44;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 435);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.Size = new System.Drawing.Size(1087, 183);
            this.dgvData.TabIndex = 43;
            // 
            // btnSalvarPrecosCompra
            // 
            this.btnSalvarPrecosCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvarPrecosCompra.Location = new System.Drawing.Point(938, 405);
            this.btnSalvarPrecosCompra.Name = "btnSalvarPrecosCompra";
            this.btnSalvarPrecosCompra.Size = new System.Drawing.Size(161, 23);
            this.btnSalvarPrecosCompra.TabIndex = 63;
            this.btnSalvarPrecosCompra.Text = "Salvar preços de compra";
            this.btnSalvarPrecosCompra.UseVisualStyleBackColor = true;
            // 
            // gpboxFiltro
            // 
            this.gpboxFiltro.Controls.Add(this.rdbDatInicioFinal);
            this.gpboxFiltro.Controls.Add(this.dtpFinal);
            this.gpboxFiltro.Controls.Add(this.rdbDatFinal);
            this.gpboxFiltro.Controls.Add(this.dtpInicial);
            this.gpboxFiltro.Controls.Add(this.rdbDatInicial);
            this.gpboxFiltro.Location = new System.Drawing.Point(13, 204);
            this.gpboxFiltro.Name = "gpboxFiltro";
            this.gpboxFiltro.Size = new System.Drawing.Size(558, 82);
            this.gpboxFiltro.TabIndex = 64;
            this.gpboxFiltro.TabStop = false;
            this.gpboxFiltro.Text = "Filtro por Data do Contrato";
            // 
            // rdbDatInicioFinal
            // 
            this.rdbDatInicioFinal.AutoSize = true;
            this.rdbDatInicioFinal.Location = new System.Drawing.Point(255, 59);
            this.rdbDatInicioFinal.Name = "rdbDatInicioFinal";
            this.rdbDatInicioFinal.Size = new System.Drawing.Size(279, 17);
            this.rdbDatInicioFinal.TabIndex = 66;
            this.rdbDatInicioFinal.TabStop = true;
            this.rdbDatInicioFinal.Text = "Intervalo Geral do Contrato (Data de Início e Término)\n";
            this.rdbDatInicioFinal.UseVisualStyleBackColor = true;
            // 
            // rdbDatFinal
            // 
            this.rdbDatFinal.AutoSize = true;
            this.rdbDatFinal.Location = new System.Drawing.Point(255, 36);
            this.rdbDatFinal.Name = "rdbDatFinal";
            this.rdbDatFinal.Size = new System.Drawing.Size(180, 17);
            this.rdbDatFinal.TabIndex = 65;
            this.rdbDatFinal.TabStop = true;
            this.rdbDatFinal.Text = "Intervalo de Término do Contrato\n";
            this.rdbDatFinal.UseVisualStyleBackColor = true;
            // 
            // rdbDatInicial
            // 
            this.rdbDatInicial.AutoSize = true;
            this.rdbDatInicial.Location = new System.Drawing.Point(255, 13);
            this.rdbDatInicial.Name = "rdbDatInicial";
            this.rdbDatInicial.Size = new System.Drawing.Size(169, 17);
            this.rdbDatInicial.TabIndex = 42;
            this.rdbDatInicial.TabStop = true;
            this.rdbDatInicial.Text = "Intervalo de Início do Contrato\n";
            this.rdbDatInicial.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Image = global::UHC3_Definitive_Version.Properties.Resources.court;
            this.pictureBox1.Location = new System.Drawing.Point(607, 204);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // frmDetalhamentoDeContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 651);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gpboxFiltro);
            this.Controls.Add(this.btnSalvarPrecosCompra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGiroInicial);
            this.Controls.Add(this.dgvColor);
            this.Controls.Add(this.lblFiltroPorPregao);
            this.Controls.Add(this.txtFiltroPregao);
            this.Controls.Add(this.txtGiroFinal);
            this.Controls.Add(this.lblFiltroPorGiro);
            this.Controls.Add(this.lblContadorDeLinhas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxStatus);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtCodFabricante);
            this.Controls.Add(this.lblFabricante);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblProdutoGenerico);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.txtCodProduto);
            this.Controls.Add(this.txtDescricaoProduto);
            this.Controls.Add(this.txtProdutoGenerico);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.txtDescricaoCliente);
            this.Controls.Add(this.txtDescricaoFabricante);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dgvData);
            this.Name = "frmDetalhamentoDeContratos";
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
            this.Text = "Detalhamento de Contratos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gpboxFiltro.ResumeLayout(false);
            this.gpboxFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGiroInicial;
        private System.Windows.Forms.DataGridView dgvColor;
        private System.Windows.Forms.Label lblFiltroPorPregao;
        private System.Windows.Forms.TextBox txtFiltroPregao;
        private System.Windows.Forms.TextBox txtGiroFinal;
        private System.Windows.Forms.Label lblFiltroPorGiro;
        private System.Windows.Forms.Label lblContadorDeLinhas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtCodFabricante;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblProdutoGenerico;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtCodProduto;
        private System.Windows.Forms.TextBox txtDescricaoProduto;
        private System.Windows.Forms.TextBox txtProdutoGenerico;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TextBox txtDescricaoCliente;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.TextBox txtDescricaoFabricante;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnSalvarPrecosCompra;
        private System.Windows.Forms.GroupBox gpboxFiltro;
        private System.Windows.Forms.RadioButton rdbDatInicioFinal;
        private System.Windows.Forms.RadioButton rdbDatFinal;
        private System.Windows.Forms.RadioButton rdbDatInicial;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}