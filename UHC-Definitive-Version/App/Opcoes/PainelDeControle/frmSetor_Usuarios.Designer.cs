namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    partial class frmSetor_Usuarios
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
            this.cbxSetor = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lsbUsuarios = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodSetor = new System.Windows.Forms.TextBox();
            this.txtSetor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Apontar excluídos para:";
            // 
            // cbxSetor
            // 
            this.cbxSetor.FormattingEnabled = true;
            this.cbxSetor.Location = new System.Drawing.Point(84, 302);
            this.cbxSetor.Name = "cbxSetor";
            this.cbxSetor.Size = new System.Drawing.Size(224, 21);
            this.cbxSetor.TabIndex = 18;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(314, 300);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(61, 23);
            this.btnSalvar.TabIndex = 17;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(381, 300);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(61, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnRemover.Location = new System.Drawing.Point(47, 294);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(28, 28);
            this.btnRemover.TabIndex = 15;
            this.btnRemover.Text = "-";
            this.btnRemover.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAdd.Location = new System.Drawing.Point(13, 294);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 28);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lsbUsuarios
            // 
            this.lsbUsuarios.FormattingEnabled = true;
            this.lsbUsuarios.Location = new System.Drawing.Point(15, 51);
            this.lsbUsuarios.Name = "lsbUsuarios";
            this.lsbUsuarios.Size = new System.Drawing.Size(427, 225);
            this.lsbUsuarios.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Setor";
            // 
            // txtCodSetor
            // 
            this.txtCodSetor.Location = new System.Drawing.Point(15, 25);
            this.txtCodSetor.Name = "txtCodSetor";
            this.txtCodSetor.Size = new System.Drawing.Size(55, 20);
            this.txtCodSetor.TabIndex = 11;
            // 
            // txtSetor
            // 
            this.txtSetor.Location = new System.Drawing.Point(76, 25);
            this.txtSetor.Name = "txtSetor";
            this.txtSetor.Size = new System.Drawing.Size(366, 20);
            this.txtSetor.TabIndex = 10;
            // 
            // frmSetor_Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 331);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxSetor);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lsbUsuarios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodSetor);
            this.Controls.Add(this.txtSetor);
            this.Name = "frmSetor_Usuarios";
            this.Text = "Realocar Usuários por Setor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxSetor;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lsbUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodSetor;
        private System.Windows.Forms.TextBox txtSetor;
    }
}