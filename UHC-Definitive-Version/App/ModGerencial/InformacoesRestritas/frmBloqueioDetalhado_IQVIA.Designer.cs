namespace UHC3_Definitive_Version.ModGerencial.Controladoria
{
    partial class frmBloqueioDetalhado_IQVIA
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lsbLayousAssociados = new System.Windows.Forms.ListBox();
            this.lblLayoutsSelecionados = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.tabFabricante = new System.Windows.Forms.TabPage();
            this.dgvFabricante = new System.Windows.Forms.DataGridView();
            this.tabNF = new System.Windows.Forms.TabPage();
            this.dgvNF = new System.Windows.Forms.DataGridView();
            this.tabProduto = new System.Windows.Forms.TabPage();
            this.dgvProduto = new System.Windows.Forms.DataGridView();
            this.tabCliente = new System.Windows.Forms.TabPage();
            this.dgvCliente = new System.Windows.Forms.DataGridView();
            this.tabBloqueios = new System.Windows.Forms.TabControl();
            this.tabFabricante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFabricante)).BeginInit();
            this.tabNF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNF)).BeginInit();
            this.tabProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).BeginInit();
            this.tabCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).BeginInit();
            this.tabBloqueios.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(640, 594);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(721, 594);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(53, 20);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Título";
            // 
            // lsbLayousAssociados
            // 
            this.lsbLayousAssociados.FormattingEnabled = true;
            this.lsbLayousAssociados.Location = new System.Drawing.Point(571, 29);
            this.lsbLayousAssociados.Name = "lsbLayousAssociados";
            this.lsbLayousAssociados.Size = new System.Drawing.Size(225, 69);
            this.lsbLayousAssociados.TabIndex = 6;
            this.lsbLayousAssociados.SelectedIndexChanged += new System.EventHandler(this.lsbLayousAssociados_SelectedIndexChanged);
            // 
            // lblLayoutsSelecionados
            // 
            this.lblLayoutsSelecionados.AutoSize = true;
            this.lblLayoutsSelecionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblLayoutsSelecionados.Location = new System.Drawing.Point(568, 13);
            this.lblLayoutsSelecionados.Name = "lblLayoutsSelecionados";
            this.lblLayoutsSelecionados.Size = new System.Drawing.Size(119, 13);
            this.lblLayoutsSelecionados.TabIndex = 7;
            this.lblLayoutsSelecionados.Text = "Layouts Associados";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(4, 587);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(136, 23);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // tabFabricante
            // 
            this.tabFabricante.Controls.Add(this.dgvFabricante);
            this.tabFabricante.Location = new System.Drawing.Point(4, 22);
            this.tabFabricante.Name = "tabFabricante";
            this.tabFabricante.Padding = new System.Windows.Forms.Padding(3);
            this.tabFabricante.Size = new System.Drawing.Size(792, 480);
            this.tabFabricante.TabIndex = 3;
            this.tabFabricante.Text = "Fabricante";
            this.tabFabricante.UseVisualStyleBackColor = true;
            // 
            // dgvFabricante
            // 
            this.dgvFabricante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFabricante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFabricante.Location = new System.Drawing.Point(3, 3);
            this.dgvFabricante.Name = "dgvFabricante";
            this.dgvFabricante.RowHeadersWidth = 51;
            this.dgvFabricante.Size = new System.Drawing.Size(786, 474);
            this.dgvFabricante.TabIndex = 1;
            // 
            // tabNF
            // 
            this.tabNF.Controls.Add(this.dgvNF);
            this.tabNF.Location = new System.Drawing.Point(4, 22);
            this.tabNF.Name = "tabNF";
            this.tabNF.Padding = new System.Windows.Forms.Padding(3);
            this.tabNF.Size = new System.Drawing.Size(792, 480);
            this.tabNF.TabIndex = 2;
            this.tabNF.Text = "NF";
            this.tabNF.UseVisualStyleBackColor = true;
            // 
            // dgvNF
            // 
            this.dgvNF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNF.Location = new System.Drawing.Point(3, 3);
            this.dgvNF.Name = "dgvNF";
            this.dgvNF.RowHeadersWidth = 51;
            this.dgvNF.Size = new System.Drawing.Size(786, 474);
            this.dgvNF.TabIndex = 1;
            this.dgvNF.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvNF_MouseDoubleClick);
            // 
            // tabProduto
            // 
            this.tabProduto.Controls.Add(this.dgvProduto);
            this.tabProduto.Location = new System.Drawing.Point(4, 22);
            this.tabProduto.Name = "tabProduto";
            this.tabProduto.Padding = new System.Windows.Forms.Padding(3);
            this.tabProduto.Size = new System.Drawing.Size(792, 480);
            this.tabProduto.TabIndex = 1;
            this.tabProduto.Text = "Produto";
            this.tabProduto.UseVisualStyleBackColor = true;
            // 
            // dgvProduto
            // 
            this.dgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduto.Location = new System.Drawing.Point(3, 3);
            this.dgvProduto.Name = "dgvProduto";
            this.dgvProduto.RowHeadersWidth = 51;
            this.dgvProduto.Size = new System.Drawing.Size(786, 474);
            this.dgvProduto.TabIndex = 1;
            // 
            // tabCliente
            // 
            this.tabCliente.Controls.Add(this.dgvCliente);
            this.tabCliente.Location = new System.Drawing.Point(4, 22);
            this.tabCliente.Name = "tabCliente";
            this.tabCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tabCliente.Size = new System.Drawing.Size(792, 480);
            this.tabCliente.TabIndex = 0;
            this.tabCliente.Text = "Cliente";
            this.tabCliente.UseVisualStyleBackColor = true;
            // 
            // dgvCliente
            // 
            this.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCliente.Location = new System.Drawing.Point(3, 3);
            this.dgvCliente.Name = "dgvCliente";
            this.dgvCliente.RowHeadersWidth = 51;
            this.dgvCliente.Size = new System.Drawing.Size(786, 474);
            this.dgvCliente.TabIndex = 0;

            // 
            // tabBloqueios
            // 
            this.tabBloqueios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBloqueios.Controls.Add(this.tabCliente);
            this.tabBloqueios.Controls.Add(this.tabProduto);
            this.tabBloqueios.Controls.Add(this.tabNF);
            this.tabBloqueios.Controls.Add(this.tabFabricante);
            this.tabBloqueios.Location = new System.Drawing.Point(0, 82);
            this.tabBloqueios.Name = "tabBloqueios";
            this.tabBloqueios.SelectedIndex = 0;
            this.tabBloqueios.Size = new System.Drawing.Size(800, 506);
            this.tabBloqueios.TabIndex = 0;
            this.tabBloqueios.SelectedIndexChanged += new System.EventHandler(this.tabBloqueios_SelectedIndexChanged);
            // 
            // frmBloqueioDetalhado_IQVIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 624);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.lblLayoutsSelecionados);
            this.Controls.Add(this.lsbLayousAssociados);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.tabBloqueios);
            this.Name = "frmBloqueioDetalhado_IQVIA";
            this.Text = "Bloqueio detalhado";
            this.Load += new System.EventHandler(this.frmBloqueioDetalhado_Load);
            this.tabFabricante.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFabricante)).EndInit();
            this.tabNF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNF)).EndInit();
            this.tabProduto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).EndInit();
            this.tabCliente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).EndInit();
            this.tabBloqueios.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lsbLayousAssociados;
        private System.Windows.Forms.Label lblLayoutsSelecionados;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TabPage tabFabricante;
        private System.Windows.Forms.DataGridView dgvFabricante;
        private System.Windows.Forms.TabPage tabNF;
        private System.Windows.Forms.DataGridView dgvNF;
        private System.Windows.Forms.TabPage tabProduto;
        private System.Windows.Forms.DataGridView dgvProduto;
        private System.Windows.Forms.TabPage tabCliente;
        private System.Windows.Forms.DataGridView dgvCliente;
        private System.Windows.Forms.TabControl tabBloqueios;
    }
}