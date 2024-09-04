namespace UHC3_Definitive_Version
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSair = new System.Windows.Forms.PictureBox();
            this.btnOpcoes = new System.Windows.Forms.PictureBox();
            this.lblOpcoes = new System.Windows.Forms.Label();
            this.lblDeslogar = new System.Windows.Forms.Label();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpcoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnSair);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpcoes);
            this.splitContainer1.Panel1.Controls.Add(this.lblOpcoes);
            this.splitContainer1.Panel1.Controls.Add(this.lblDeslogar);
            this.splitContainer1.Panel1.Controls.Add(this.pcbLogo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.panel);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Size = new System.Drawing.Size(1087, 557);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.BackgroundImage = global::UHC3_Definitive_Version.Properties.Resources.logout;
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Location = new System.Drawing.Point(238, 508);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(30, 26);
            this.btnSair.TabIndex = 16;
            this.btnSair.TabStop = false;
            // 
            // btnOpcoes
            // 
            this.btnOpcoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpcoes.BackgroundImage = global::UHC3_Definitive_Version.Properties.Resources.settings;
            this.btnOpcoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpcoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpcoes.Location = new System.Drawing.Point(19, 507);
            this.btnOpcoes.Name = "btnOpcoes";
            this.btnOpcoes.Size = new System.Drawing.Size(30, 26);
            this.btnOpcoes.TabIndex = 15;
            this.btnOpcoes.TabStop = false;
            // 
            // lblOpcoes
            // 
            this.lblOpcoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOpcoes.AutoSize = true;
            this.lblOpcoes.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcoes.Location = new System.Drawing.Point(12, 532);
            this.lblOpcoes.Name = "lblOpcoes";
            this.lblOpcoes.Size = new System.Drawing.Size(47, 16);
            this.lblOpcoes.TabIndex = 14;
            this.lblOpcoes.Text = "Opções";
            // 
            // lblDeslogar
            // 
            this.lblDeslogar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeslogar.AutoSize = true;
            this.lblDeslogar.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeslogar.Location = new System.Drawing.Point(227, 532);
            this.lblDeslogar.Name = "lblDeslogar";
            this.lblDeslogar.Size = new System.Drawing.Size(53, 16);
            this.lblDeslogar.TabIndex = 13;
            this.lblDeslogar.Text = "Deslogar";
            // 
            // pcbLogo
            // 
            this.pcbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pcbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbLogo.Location = new System.Drawing.Point(12, 12);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(261, 101);
            this.pcbLogo.TabIndex = 0;
            this.pcbLogo.TabStop = false;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.BackgroundImage = global::UHC3_Definitive_Version.Properties.Resources.Background_Office_Gray;
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(795, 557);
            this.panel.TabIndex = 7;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 557);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMainMenu";
            this.Text = "Menu Principal";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpcoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblOpcoes;
        private System.Windows.Forms.Label lblDeslogar;
        private System.Windows.Forms.PictureBox btnOpcoes;
        private System.Windows.Forms.PictureBox btnSair;
    }
}

