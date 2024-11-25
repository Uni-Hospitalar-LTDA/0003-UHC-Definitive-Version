namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    partial class frmAcessoRestrito_PainelReenvio
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
            this.lblIdLog = new System.Windows.Forms.Label();
            this.txtIdLog = new System.Windows.Forms.TextBox();
            this.dtpDataArquivo = new System.Windows.Forms.DateTimePicker();
            this.lblDataArquivo = new System.Windows.Forms.Label();
            this.txtUnidade = new System.Windows.Forms.TextBox();
            this.lblUnidade = new System.Windows.Forms.Label();
            this.clkListaColetores = new System.Windows.Forms.CheckedListBox();
            this.lblColetores = new System.Windows.Forms.Label();
            this.dgvRestricoes = new System.Windows.Forms.DataGridView();
            this.lblListaRestricoes = new System.Windows.Forms.Label();
            this.chkIgnorarRestricoes = new System.Windows.Forms.CheckBox();
            this.gpbLayouts = new System.Windows.Forms.GroupBox();
            this.chkClientes = new System.Windows.Forms.CheckBox();
            this.chkProdutos = new System.Windows.Forms.CheckBox();
            this.chkVendas = new System.Windows.Forms.CheckBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestricoes)).BeginInit();
            this.gpbLayouts.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIdLog
            // 
            this.lblIdLog.AutoSize = true;
            this.lblIdLog.Location = new System.Drawing.Point(12, 9);
            this.lblIdLog.Name = "lblIdLog";
            this.lblIdLog.Size = new System.Drawing.Size(37, 13);
            this.lblIdLog.TabIndex = 0;
            this.lblIdLog.Text = "Id Log";
            // 
            // txtIdLog
            // 
            this.txtIdLog.Location = new System.Drawing.Point(15, 25);
            this.txtIdLog.Name = "txtIdLog";
            this.txtIdLog.Size = new System.Drawing.Size(66, 20);
            this.txtIdLog.TabIndex = 1;
            // 
            // dtpDataArquivo
            // 
            this.dtpDataArquivo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataArquivo.Location = new System.Drawing.Point(12, 64);
            this.dtpDataArquivo.Name = "dtpDataArquivo";
            this.dtpDataArquivo.Size = new System.Drawing.Size(102, 20);
            this.dtpDataArquivo.TabIndex = 2;
            // 
            // lblDataArquivo
            // 
            this.lblDataArquivo.AutoSize = true;
            this.lblDataArquivo.Location = new System.Drawing.Point(12, 48);
            this.lblDataArquivo.Name = "lblDataArquivo";
            this.lblDataArquivo.Size = new System.Drawing.Size(69, 13);
            this.lblDataArquivo.TabIndex = 3;
            this.lblDataArquivo.Text = "Data Arquivo";
            // 
            // txtUnidade
            // 
            this.txtUnidade.Location = new System.Drawing.Point(15, 103);
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.Size = new System.Drawing.Size(267, 20);
            this.txtUnidade.TabIndex = 5;
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.Location = new System.Drawing.Point(12, 87);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(47, 13);
            this.lblUnidade.TabIndex = 4;
            this.lblUnidade.Text = "Unidade";
            // 
            // clkListaColetores
            // 
            this.clkListaColetores.FormattingEnabled = true;
            this.clkListaColetores.Location = new System.Drawing.Point(15, 142);
            this.clkListaColetores.Name = "clkListaColetores";
            this.clkListaColetores.Size = new System.Drawing.Size(267, 169);
            this.clkListaColetores.TabIndex = 7;
            // 
            // lblColetores
            // 
            this.lblColetores.AutoSize = true;
            this.lblColetores.Location = new System.Drawing.Point(12, 126);
            this.lblColetores.Name = "lblColetores";
            this.lblColetores.Size = new System.Drawing.Size(51, 13);
            this.lblColetores.TabIndex = 6;
            this.lblColetores.Text = "Coletores";
            // 
            // dgvRestricoes
            // 
            this.dgvRestricoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRestricoes.Location = new System.Drawing.Point(313, 25);
            this.dgvRestricoes.Name = "dgvRestricoes";
            this.dgvRestricoes.Size = new System.Drawing.Size(376, 147);
            this.dgvRestricoes.TabIndex = 8;
            // 
            // lblListaRestricoes
            // 
            this.lblListaRestricoes.AutoSize = true;
            this.lblListaRestricoes.Location = new System.Drawing.Point(310, 9);
            this.lblListaRestricoes.Name = "lblListaRestricoes";
            this.lblListaRestricoes.Size = new System.Drawing.Size(97, 13);
            this.lblListaRestricoes.TabIndex = 9;
            this.lblListaRestricoes.Text = "Lista de Restrições";
            // 
            // chkIgnorarRestricoes
            // 
            this.chkIgnorarRestricoes.AutoSize = true;
            this.chkIgnorarRestricoes.Location = new System.Drawing.Point(582, 178);
            this.chkIgnorarRestricoes.Name = "chkIgnorarRestricoes";
            this.chkIgnorarRestricoes.Size = new System.Drawing.Size(107, 17);
            this.chkIgnorarRestricoes.TabIndex = 10;
            this.chkIgnorarRestricoes.Text = "Ignorar restrições";
            this.chkIgnorarRestricoes.UseVisualStyleBackColor = true;
            // 
            // gpbLayouts
            // 
            this.gpbLayouts.Controls.Add(this.chkVendas);
            this.gpbLayouts.Controls.Add(this.chkProdutos);
            this.gpbLayouts.Controls.Add(this.chkClientes);
            this.gpbLayouts.Location = new System.Drawing.Point(313, 178);
            this.gpbLayouts.Name = "gpbLayouts";
            this.gpbLayouts.Size = new System.Drawing.Size(94, 100);
            this.gpbLayouts.TabIndex = 11;
            this.gpbLayouts.TabStop = false;
            this.gpbLayouts.Text = "Layouts";
            // 
            // chkClientes
            // 
            this.chkClientes.AutoSize = true;
            this.chkClientes.Checked = true;
            this.chkClientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClientes.Location = new System.Drawing.Point(6, 42);
            this.chkClientes.Name = "chkClientes";
            this.chkClientes.Size = new System.Drawing.Size(63, 17);
            this.chkClientes.TabIndex = 11;
            this.chkClientes.Text = "Clientes";
            this.chkClientes.UseVisualStyleBackColor = true;
            // 
            // chkProdutos
            // 
            this.chkProdutos.AutoSize = true;
            this.chkProdutos.Checked = true;
            this.chkProdutos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProdutos.Location = new System.Drawing.Point(6, 19);
            this.chkProdutos.Name = "chkProdutos";
            this.chkProdutos.Size = new System.Drawing.Size(68, 17);
            this.chkProdutos.TabIndex = 11;
            this.chkProdutos.Text = "Produtos";
            this.chkProdutos.UseVisualStyleBackColor = true;
            // 
            // chkVendas
            // 
            this.chkVendas.AutoSize = true;
            this.chkVendas.Checked = true;
            this.chkVendas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVendas.Location = new System.Drawing.Point(6, 65);
            this.chkVendas.Name = "chkVendas";
            this.chkVendas.Size = new System.Drawing.Size(62, 17);
            this.chkVendas.TabIndex = 12;
            this.chkVendas.Text = "Vendas";
            this.chkVendas.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(622, 288);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 12;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(541, 288);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 12;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(460, 288);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // frmAcessoRestrito_PainelReenvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 321);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gpbLayouts);
            this.Controls.Add(this.chkIgnorarRestricoes);
            this.Controls.Add(this.lblListaRestricoes);
            this.Controls.Add(this.dgvRestricoes);
            this.Controls.Add(this.clkListaColetores);
            this.Controls.Add(this.lblColetores);
            this.Controls.Add(this.txtUnidade);
            this.Controls.Add(this.lblUnidade);
            this.Controls.Add(this.lblDataArquivo);
            this.Controls.Add(this.dtpDataArquivo);
            this.Controls.Add(this.txtIdLog);
            this.Controls.Add(this.lblIdLog);
            this.Name = "frmAcessoRestrito_PainelReenvio";
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
            this.Text = "Painel de Reenvio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestricoes)).EndInit();
            this.gpbLayouts.ResumeLayout(false);
            this.gpbLayouts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdLog;
        private System.Windows.Forms.TextBox txtIdLog;
        private System.Windows.Forms.DateTimePicker dtpDataArquivo;
        private System.Windows.Forms.Label lblDataArquivo;
        private System.Windows.Forms.TextBox txtUnidade;
        private System.Windows.Forms.Label lblUnidade;
        private System.Windows.Forms.CheckedListBox clkListaColetores;
        private System.Windows.Forms.Label lblColetores;
        private System.Windows.Forms.DataGridView dgvRestricoes;
        private System.Windows.Forms.Label lblListaRestricoes;
        private System.Windows.Forms.CheckBox chkIgnorarRestricoes;
        private System.Windows.Forms.GroupBox gpbLayouts;
        private System.Windows.Forms.CheckBox chkVendas;
        private System.Windows.Forms.CheckBox chkProdutos;
        private System.Windows.Forms.CheckBox chkClientes;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnSalvar;
    }
}