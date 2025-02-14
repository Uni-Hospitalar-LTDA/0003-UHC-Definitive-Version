namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    partial class frmGruposPermissao_Editar
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treePermission = new System.Windows.Forms.TreeView();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.txtCodGrupo = new System.Windows.Forms.TextBox();
            this.txtDescricaoGrupo = new System.Windows.Forms.TextBox();
            this.lblGroupDescription = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.gpbPermissaoSelecionada = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblNomeGrupo = new System.Windows.Forms.Label();
            this.txtNomeGrupo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpbPermissaoSelecionada.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treePermission);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkAtivo);
            this.splitContainer1.Panel2.Controls.Add(this.txtCodGrupo);
            this.splitContainer1.Panel2.Controls.Add(this.txtDescricaoGrupo);
            this.splitContainer1.Panel2.Controls.Add(this.lblGroupDescription);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnSalvar);
            this.splitContainer1.Panel2.Controls.Add(this.gpbPermissaoSelecionada);
            this.splitContainer1.Panel2.Controls.Add(this.lblNomeGrupo);
            this.splitContainer1.Panel2.Controls.Add(this.txtNomeGrupo);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 373;
            this.splitContainer1.TabIndex = 3;
            // 
            // treePermission
            // 
            this.treePermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePermission.Location = new System.Drawing.Point(0, 0);
            this.treePermission.Name = "treePermission";
            this.treePermission.Size = new System.Drawing.Size(373, 450);
            this.treePermission.TabIndex = 0;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(361, 10);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(50, 17);
            this.chkAtivo.TabIndex = 8;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // txtCodGrupo
            // 
            this.txtCodGrupo.Location = new System.Drawing.Point(12, 30);
            this.txtCodGrupo.Name = "txtCodGrupo";
            this.txtCodGrupo.Size = new System.Drawing.Size(55, 20);
            this.txtCodGrupo.TabIndex = 7;
            // 
            // txtDescricaoGrupo
            // 
            this.txtDescricaoGrupo.Location = new System.Drawing.Point(12, 69);
            this.txtDescricaoGrupo.Multiline = true;
            this.txtDescricaoGrupo.Name = "txtDescricaoGrupo";
            this.txtDescricaoGrupo.Size = new System.Drawing.Size(399, 40);
            this.txtDescricaoGrupo.TabIndex = 3;
            // 
            // lblGroupDescription
            // 
            this.lblGroupDescription.AutoSize = true;
            this.lblGroupDescription.Location = new System.Drawing.Point(12, 53);
            this.lblGroupDescription.Name = "lblGroupDescription";
            this.lblGroupDescription.Size = new System.Drawing.Size(55, 13);
            this.lblGroupDescription.TabIndex = 6;
            this.lblGroupDescription.Text = "Descrição";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(336, 415);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(255, 415);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // gpbPermissaoSelecionada
            // 
            this.gpbPermissaoSelecionada.Controls.Add(this.lblDescription);
            this.gpbPermissaoSelecionada.Controls.Add(this.txtName);
            this.gpbPermissaoSelecionada.Controls.Add(this.lblName);
            this.gpbPermissaoSelecionada.Controls.Add(this.txtDescription);
            this.gpbPermissaoSelecionada.Location = new System.Drawing.Point(12, 115);
            this.gpbPermissaoSelecionada.Name = "gpbPermissaoSelecionada";
            this.gpbPermissaoSelecionada.Size = new System.Drawing.Size(399, 196);
            this.gpbPermissaoSelecionada.TabIndex = 3;
            this.gpbPermissaoSelecionada.TabStop = false;
            this.gpbPermissaoSelecionada.Text = "Permissão Selecionada";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 55);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(55, 13);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Descrição";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(9, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(384, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Nome";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(9, 71);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(384, 110);
            this.txtDescription.TabIndex = 1;
            // 
            // lblNomeGrupo
            // 
            this.lblNomeGrupo.AutoSize = true;
            this.lblNomeGrupo.Location = new System.Drawing.Point(9, 14);
            this.lblNomeGrupo.Name = "lblNomeGrupo";
            this.lblNomeGrupo.Size = new System.Drawing.Size(82, 13);
            this.lblNomeGrupo.TabIndex = 1;
            this.lblNomeGrupo.Text = "Nome do Grupo";
            // 
            // txtNomeGrupo
            // 
            this.txtNomeGrupo.Location = new System.Drawing.Point(73, 30);
            this.txtNomeGrupo.Name = "txtNomeGrupo";
            this.txtNomeGrupo.Size = new System.Drawing.Size(338, 20);
            this.txtNomeGrupo.TabIndex = 2;
            // 
            // frmGruposPermissao_Editar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmGruposPermissao_Editar";
            this.Text = "Grupos de Permissão (Editar)";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpbPermissaoSelecionada.ResumeLayout(false);
            this.gpbPermissaoSelecionada.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treePermission;
        private System.Windows.Forms.TextBox txtCodGrupo;
        private System.Windows.Forms.TextBox txtDescricaoGrupo;
        private System.Windows.Forms.Label lblGroupDescription;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.GroupBox gpbPermissaoSelecionada;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblNomeGrupo;
        private System.Windows.Forms.TextBox txtNomeGrupo;
        private System.Windows.Forms.CheckBox chkAtivo;
    }
}