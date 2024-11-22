namespace UHC3_Definitive_Version.App.Opcoes.OpcoesDeDesenvolvedor
{
    partial class frmPermissoes_Add
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
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtDescricaoMae = new System.Windows.Forms.TextBox();
            this.lblFilhoDe = new System.Windows.Forms.Label();
            this.btnMaisMae = new System.Windows.Forms.Button();
            this.txtIdMae = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(560, 323);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 15;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(479, 323);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(9, 49);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(65, 13);
            this.lblObservacao.TabIndex = 13;
            this.lblObservacao.Text = "Observação";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(12, 65);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(623, 235);
            this.txtObservacao.TabIndex = 12;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(9, 10);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 11;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(12, 26);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(623, 20);
            this.txtDescricao.TabIndex = 10;
            // 
            // txtDescricaoMae
            // 
            this.txtDescricaoMae.Location = new System.Drawing.Point(77, 324);
            this.txtDescricaoMae.Name = "txtDescricaoMae";
            this.txtDescricaoMae.Size = new System.Drawing.Size(311, 20);
            this.txtDescricaoMae.TabIndex = 16;
            // 
            // lblFilhoDe
            // 
            this.lblFilhoDe.AutoSize = true;
            this.lblFilhoDe.Location = new System.Drawing.Point(12, 305);
            this.lblFilhoDe.Name = "lblFilhoDe";
            this.lblFilhoDe.Size = new System.Drawing.Size(47, 13);
            this.lblFilhoDe.TabIndex = 17;
            this.lblFilhoDe.Text = "Filho de:";
            // 
            // btnMaisMae
            // 
            this.btnMaisMae.Location = new System.Drawing.Point(394, 323);
            this.btnMaisMae.Name = "btnMaisMae";
            this.btnMaisMae.Size = new System.Drawing.Size(26, 23);
            this.btnMaisMae.TabIndex = 18;
            this.btnMaisMae.Text = "...";
            this.btnMaisMae.UseVisualStyleBackColor = true;
            // 
            // txtIdMae
            // 
            this.txtIdMae.Location = new System.Drawing.Point(12, 323);
            this.txtIdMae.Name = "txtIdMae";
            this.txtIdMae.Size = new System.Drawing.Size(59, 20);
            this.txtIdMae.TabIndex = 19;
            // 
            // frmPermissoes_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 352);
            this.Controls.Add(this.txtIdMae);
            this.Controls.Add(this.btnMaisMae);
            this.Controls.Add(this.lblFilhoDe);
            this.Controls.Add(this.txtDescricaoMae);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblObservacao);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Name = "frmPermissoes_Add";
            this.Text = "Permissões (Adicionar)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtDescricaoMae;
        private System.Windows.Forms.Label lblFilhoDe;
        private System.Windows.Forms.Button btnMaisMae;
        private System.Windows.Forms.TextBox txtIdMae;
    }
}