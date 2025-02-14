namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    partial class frmControladoria_Arquivos_IQVIA
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
            this.btnRemoverBloqueios = new System.Windows.Forms.Button();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpDataBase = new System.Windows.Forms.DateTimePicker();
            this.txtNArquivos = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnVerificarArquivo = new System.Windows.Forms.Button();
            this.btnGerarArquivosEnvio = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblIMSPanel = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnBloqueioDetalhado = new System.Windows.Forms.Button();
            this.gpbEnvioHabilitado = new System.Windows.Forms.GroupBox();
            this.chkVendas = new System.Windows.Forms.CheckBox();
            this.chkProdutos = new System.Windows.Forms.CheckBox();
            this.chkClientes = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gpbEnvioHabilitado.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemoverBloqueios
            // 
            this.btnRemoverBloqueios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverBloqueios.Location = new System.Drawing.Point(706, 103);
            this.btnRemoverBloqueios.Name = "btnRemoverBloqueios";
            this.btnRemoverBloqueios.Size = new System.Drawing.Size(117, 23);
            this.btnRemoverBloqueios.TabIndex = 112;
            this.btnRemoverBloqueios.Text = "Remover bloqueios";
            this.btnRemoverBloqueios.UseVisualStyleBackColor = true;
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFinal.Location = new System.Drawing.Point(190, 106);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(100, 20);
            this.dtpDataFinal.TabIndex = 108;
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicial.Location = new System.Drawing.Point(84, 106);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(100, 20);
            this.dtpDataInicial.TabIndex = 106;
            // 
            // dtpDataBase
            // 
            this.dtpDataBase.Location = new System.Drawing.Point(164, 18);
            this.dtpDataBase.Name = "dtpDataBase";
            this.dtpDataBase.Size = new System.Drawing.Size(232, 20);
            this.dtpDataBase.TabIndex = 104;
            // 
            // txtNArquivos
            // 
            this.txtNArquivos.Location = new System.Drawing.Point(351, 44);
            this.txtNArquivos.MaxLength = 3;
            this.txtNArquivos.Name = "txtNArquivos";
            this.txtNArquivos.Size = new System.Drawing.Size(45, 20);
            this.txtNArquivos.TabIndex = 102;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(829, 103);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 23);
            this.btnRefresh.TabIndex = 113;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnVerificarArquivo
            // 
            this.btnVerificarArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerificarArquivo.Location = new System.Drawing.Point(460, 103);
            this.btnVerificarArquivo.Name = "btnVerificarArquivo";
            this.btnVerificarArquivo.Size = new System.Drawing.Size(117, 23);
            this.btnVerificarArquivo.TabIndex = 110;
            this.btnVerificarArquivo.Text = "Verificar arquivo";
            this.btnVerificarArquivo.UseVisualStyleBackColor = true;
            // 
            // btnGerarArquivosEnvio
            // 
            this.btnGerarArquivosEnvio.Location = new System.Drawing.Point(164, 42);
            this.btnGerarArquivosEnvio.Name = "btnGerarArquivosEnvio";
            this.btnGerarArquivosEnvio.Size = new System.Drawing.Size(181, 23);
            this.btnGerarArquivosEnvio.TabIndex = 105;
            this.btnGerarArquivosEnvio.Text = "Gerar Arquivos";
            this.btnGerarArquivosEnvio.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(790, 594);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 114;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(871, 594);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 115;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblIMSPanel
            // 
            this.lblIMSPanel.AutoSize = true;
            this.lblIMSPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblIMSPanel.Location = new System.Drawing.Point(11, 110);
            this.lblIMSPanel.Name = "lblIMSPanel";
            this.lblIMSPanel.Size = new System.Drawing.Size(68, 13);
            this.lblIMSPanel.TabIndex = 107;
            this.lblIMSPanel.Text = "Painel IMS";
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(13, 129);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.Size = new System.Drawing.Size(933, 459);
            this.dgvData.TabIndex = 109;
            // 
            // btnBloqueioDetalhado
            // 
            this.btnBloqueioDetalhado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBloqueioDetalhado.Location = new System.Drawing.Point(583, 103);
            this.btnBloqueioDetalhado.Name = "btnBloqueioDetalhado";
            this.btnBloqueioDetalhado.Size = new System.Drawing.Size(117, 23);
            this.btnBloqueioDetalhado.TabIndex = 111;
            this.btnBloqueioDetalhado.Text = "Bloqueio detalhado";
            this.btnBloqueioDetalhado.UseVisualStyleBackColor = true;
            // 
            // gpbEnvioHabilitado
            // 
            this.gpbEnvioHabilitado.Controls.Add(this.chkVendas);
            this.gpbEnvioHabilitado.Controls.Add(this.chkProdutos);
            this.gpbEnvioHabilitado.Controls.Add(this.chkClientes);
            this.gpbEnvioHabilitado.Location = new System.Drawing.Point(13, 10);
            this.gpbEnvioHabilitado.Name = "gpbEnvioHabilitado";
            this.gpbEnvioHabilitado.Size = new System.Drawing.Size(145, 93);
            this.gpbEnvioHabilitado.TabIndex = 103;
            this.gpbEnvioHabilitado.TabStop = false;
            this.gpbEnvioHabilitado.Text = "Envio Habilitado";
            // 
            // chkVendas
            // 
            this.chkVendas.AutoSize = true;
            this.chkVendas.Location = new System.Drawing.Point(6, 65);
            this.chkVendas.Name = "chkVendas";
            this.chkVendas.Size = new System.Drawing.Size(116, 17);
            this.chkVendas.TabIndex = 2;
            this.chkVendas.Text = "Arquivo de Vendas";
            this.chkVendas.UseVisualStyleBackColor = true;
            // 
            // chkProdutos
            // 
            this.chkProdutos.AutoSize = true;
            this.chkProdutos.Location = new System.Drawing.Point(6, 42);
            this.chkProdutos.Name = "chkProdutos";
            this.chkProdutos.Size = new System.Drawing.Size(122, 17);
            this.chkProdutos.TabIndex = 1;
            this.chkProdutos.Text = "Arquivo de Produtos";
            this.chkProdutos.UseVisualStyleBackColor = true;
            // 
            // chkClientes
            // 
            this.chkClientes.AutoSize = true;
            this.chkClientes.Location = new System.Drawing.Point(6, 19);
            this.chkClientes.Name = "chkClientes";
            this.chkClientes.Size = new System.Drawing.Size(117, 17);
            this.chkClientes.TabIndex = 0;
            this.chkClientes.Text = "Arquivo de Clientes";
            this.chkClientes.UseVisualStyleBackColor = true;
            // 
            // frmControladoria_Arquivos_IQVIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 625);
            this.Controls.Add(this.btnRemoverBloqueios);
            this.Controls.Add(this.dtpDataFinal);
            this.Controls.Add(this.dtpDataInicial);
            this.Controls.Add(this.dtpDataBase);
            this.Controls.Add(this.txtNArquivos);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnVerificarArquivo);
            this.Controls.Add(this.btnGerarArquivosEnvio);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblIMSPanel);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnBloqueioDetalhado);
            this.Controls.Add(this.gpbEnvioHabilitado);
            this.Name = "frmControladoria_Arquivos_IQVIA";
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
            this.Text = "Controladoria de Arquivos IQVIA";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gpbEnvioHabilitado.ResumeLayout(false);
            this.gpbEnvioHabilitado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRemoverBloqueios;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.DateTimePicker dtpDataBase;
        private System.Windows.Forms.TextBox txtNArquivos;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnVerificarArquivo;
        private System.Windows.Forms.Button btnGerarArquivosEnvio;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblIMSPanel;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnBloqueioDetalhado;
        private System.Windows.Forms.GroupBox gpbEnvioHabilitado;
        private System.Windows.Forms.CheckBox chkVendas;
        private System.Windows.Forms.CheckBox chkProdutos;
        private System.Windows.Forms.CheckBox chkClientes;
    }
}