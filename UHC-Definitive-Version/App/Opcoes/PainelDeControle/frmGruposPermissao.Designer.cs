﻿namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    partial class frmGruposPermissao
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
            this.btnAssociar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.gpbFilters = new System.Windows.Forms.GroupBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.gpbStatus = new System.Windows.Forms.GroupBox();
            this.chkInativos = new System.Windows.Forms.CheckBox();
            this.chkAtivos = new System.Windows.Forms.CheckBox();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.gpbFilters.SuspendLayout();
            this.gpbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAssociar
            // 
            this.btnAssociar.Location = new System.Drawing.Point(12, 401);
            this.btnAssociar.Name = "btnAssociar";
            this.btnAssociar.Size = new System.Drawing.Size(148, 23);
            this.btnAssociar.TabIndex = 22;
            this.btnAssociar.Text = "Associar usuários ao Grupo";
            this.btnAssociar.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(562, 401);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(61, 23);
            this.btnFechar.TabIndex = 19;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(552, 104);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(71, 23);
            this.btnEditar.TabIndex = 18;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(12, 133);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(611, 262);
            this.dgvDados.TabIndex = 17;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(475, 104);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(71, 23);
            this.btnAdicionar.TabIndex = 16;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // gpbFilters
            // 
            this.gpbFilters.Controls.Add(this.btnPesquisar);
            this.gpbFilters.Controls.Add(this.gpbStatus);
            this.gpbFilters.Controls.Add(this.txtPesquisar);
            this.gpbFilters.Controls.Add(this.label1);
            this.gpbFilters.Location = new System.Drawing.Point(12, 12);
            this.gpbFilters.Name = "gpbFilters";
            this.gpbFilters.Size = new System.Drawing.Size(386, 115);
            this.gpbFilters.TabIndex = 23;
            this.gpbFilters.TabStop = false;
            this.gpbFilters.Text = "Filtros";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(314, 80);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(66, 23);
            this.btnPesquisar.TabIndex = 2;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // gpbStatus
            // 
            this.gpbStatus.Controls.Add(this.chkInativos);
            this.gpbStatus.Controls.Add(this.chkAtivos);
            this.gpbStatus.Location = new System.Drawing.Point(9, 59);
            this.gpbStatus.Name = "gpbStatus";
            this.gpbStatus.Size = new System.Drawing.Size(139, 44);
            this.gpbStatus.TabIndex = 1;
            this.gpbStatus.TabStop = false;
            this.gpbStatus.Text = "Status";
            // 
            // chkInativos
            // 
            this.chkInativos.AutoSize = true;
            this.chkInativos.Checked = true;
            this.chkInativos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInativos.Location = new System.Drawing.Point(67, 19);
            this.chkInativos.Name = "chkInativos";
            this.chkInativos.Size = new System.Drawing.Size(63, 17);
            this.chkInativos.TabIndex = 1;
            this.chkInativos.Text = "Inativos";
            this.chkInativos.UseVisualStyleBackColor = true;
            // 
            // chkAtivos
            // 
            this.chkAtivos.AutoSize = true;
            this.chkAtivos.Checked = true;
            this.chkAtivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivos.Location = new System.Drawing.Point(6, 19);
            this.chkAtivos.Name = "chkAtivos";
            this.chkAtivos.Size = new System.Drawing.Size(55, 17);
            this.chkAtivos.TabIndex = 0;
            this.chkAtivos.Text = "Ativos";
            this.chkAtivos.UseVisualStyleBackColor = true;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(6, 33);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(374, 20);
            this.txtPesquisar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Filtro Genérico (Id / Descrição)";
            // 
            // frmGruposPermissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 428);
            this.Controls.Add(this.gpbFilters);
            this.Controls.Add(this.btnAssociar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.btnAdicionar);
            this.Name = "frmGruposPermissao";
            this.Text = "Grupos de Permissão";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.gpbFilters.ResumeLayout(false);
            this.gpbFilters.PerformLayout();
            this.gpbStatus.ResumeLayout(false);
            this.gpbStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAssociar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.GroupBox gpbFilters;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.GroupBox gpbStatus;
        private System.Windows.Forms.CheckBox chkInativos;
        private System.Windows.Forms.CheckBox chkAtivos;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Label label1;
    }
}