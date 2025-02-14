namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    partial class frmGruposPermissao_Usuarios
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lsbUsuarios = new System.Windows.Forms.ListBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.txtCodGrupo = new System.Windows.Forms.TextBox();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(313, 286);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(61, 23);
            this.btnSalvar.TabIndex = 25;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(380, 286);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(61, 23);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnRemover.Location = new System.Drawing.Point(46, 282);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(28, 28);
            this.btnRemover.TabIndex = 23;
            this.btnRemover.Text = "-";
            this.btnRemover.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAdd.Location = new System.Drawing.Point(12, 282);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 28);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lsbUsuarios
            // 
            this.lsbUsuarios.FormattingEnabled = true;
            this.lsbUsuarios.Location = new System.Drawing.Point(15, 51);
            this.lsbUsuarios.Name = "lsbUsuarios";
            this.lsbUsuarios.Size = new System.Drawing.Size(427, 225);
            this.lsbUsuarios.TabIndex = 21;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(12, 9);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(36, 13);
            this.lblGrupo.TabIndex = 20;
            this.lblGrupo.Text = "Grupo";
            // 
            // txtCodGrupo
            // 
            this.txtCodGrupo.Location = new System.Drawing.Point(15, 25);
            this.txtCodGrupo.Name = "txtCodGrupo";
            this.txtCodGrupo.Size = new System.Drawing.Size(55, 20);
            this.txtCodGrupo.TabIndex = 19;
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(76, 25);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(366, 20);
            this.txtGrupo.TabIndex = 18;
            // 
            // frmGruposPermissao_Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 314);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lsbUsuarios);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.txtCodGrupo);
            this.Controls.Add(this.txtGrupo);
            this.Name = "frmGruposPermissao_Usuarios";
            this.Text = "Associar usuários ao grupo de permissão";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lsbUsuarios;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.TextBox txtCodGrupo;
        private System.Windows.Forms.TextBox txtGrupo;
    }
}