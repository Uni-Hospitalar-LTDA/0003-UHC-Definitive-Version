﻿namespace UHC3_Definitive_Version.App.ModGerencial
{
    partial class frmModGerencial
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
            this.lblGerencial = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gpbControladoriaDeDados = new System.Windows.Forms.GroupBox();
            this.btnValidacaoIntegridade = new System.Windows.Forms.Button();
            this.btnAuditoriaDeDados = new System.Windows.Forms.Button();
            this.btnEnvioDeDados = new System.Windows.Forms.Button();
            this.btnRestricaoDeDados = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMargemCompraVenda = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.gpbControladoriaDeDados.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGerencial
            // 
            this.lblGerencial.AutoSize = true;
            this.lblGerencial.BackColor = System.Drawing.Color.Transparent;
            this.lblGerencial.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.lblGerencial.ForeColor = System.Drawing.Color.Transparent;
            this.lblGerencial.Location = new System.Drawing.Point(17, 9);
            this.lblGerencial.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblGerencial.Name = "lblGerencial";
            this.lblGerencial.Size = new System.Drawing.Size(300, 46);
            this.lblGerencial.TabIndex = 21;
            this.lblGerencial.Text = "Área Gerencial";
            this.lblGerencial.Click += new System.EventHandler(this.lblGerencial_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.gpbControladoriaDeDados);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 52);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(764, 347);
            this.flowLayoutPanel1.TabIndex = 67;
            // 
            // gpbControladoriaDeDados
            // 
            this.gpbControladoriaDeDados.Controls.Add(this.btnValidacaoIntegridade);
            this.gpbControladoriaDeDados.Controls.Add(this.btnAuditoriaDeDados);
            this.gpbControladoriaDeDados.Controls.Add(this.btnEnvioDeDados);
            this.gpbControladoriaDeDados.Controls.Add(this.btnRestricaoDeDados);
            this.gpbControladoriaDeDados.ForeColor = System.Drawing.Color.White;
            this.gpbControladoriaDeDados.Location = new System.Drawing.Point(3, 3);
            this.gpbControladoriaDeDados.Name = "gpbControladoriaDeDados";
            this.gpbControladoriaDeDados.Size = new System.Drawing.Size(188, 258);
            this.gpbControladoriaDeDados.TabIndex = 15;
            this.gpbControladoriaDeDados.TabStop = false;
            this.gpbControladoriaDeDados.Text = "Relatórios";
            // 
            // btnValidacaoIntegridade
            // 
            this.btnValidacaoIntegridade.ForeColor = System.Drawing.Color.Black;
            this.btnValidacaoIntegridade.Location = new System.Drawing.Point(6, 154);
            this.btnValidacaoIntegridade.Name = "btnValidacaoIntegridade";
            this.btnValidacaoIntegridade.Size = new System.Drawing.Size(170, 39);
            this.btnValidacaoIntegridade.TabIndex = 16;
            this.btnValidacaoIntegridade.Text = "4. Validação de Integridade";
            this.btnValidacaoIntegridade.UseVisualStyleBackColor = true;
            // 
            // btnAuditoriaDeDados
            // 
            this.btnAuditoriaDeDados.ForeColor = System.Drawing.Color.Black;
            this.btnAuditoriaDeDados.Location = new System.Drawing.Point(6, 109);
            this.btnAuditoriaDeDados.Name = "btnAuditoriaDeDados";
            this.btnAuditoriaDeDados.Size = new System.Drawing.Size(170, 39);
            this.btnAuditoriaDeDados.TabIndex = 15;
            this.btnAuditoriaDeDados.Text = "3. Auditoria de Dados";
            this.btnAuditoriaDeDados.UseVisualStyleBackColor = true;
            // 
            // btnEnvioDeDados
            // 
            this.btnEnvioDeDados.ForeColor = System.Drawing.Color.Black;
            this.btnEnvioDeDados.Location = new System.Drawing.Point(6, 64);
            this.btnEnvioDeDados.Name = "btnEnvioDeDados";
            this.btnEnvioDeDados.Size = new System.Drawing.Size(170, 39);
            this.btnEnvioDeDados.TabIndex = 14;
            this.btnEnvioDeDados.Text = "2. Envio de Dados";
            this.btnEnvioDeDados.UseVisualStyleBackColor = true;
            // 
            // btnRestricaoDeDados
            // 
            this.btnRestricaoDeDados.ForeColor = System.Drawing.Color.Black;
            this.btnRestricaoDeDados.Location = new System.Drawing.Point(6, 19);
            this.btnRestricaoDeDados.Name = "btnRestricaoDeDados";
            this.btnRestricaoDeDados.Size = new System.Drawing.Size(170, 39);
            this.btnRestricaoDeDados.TabIndex = 13;
            this.btnRestricaoDeDados.Text = "1. Restrição de Dados";
            this.btnRestricaoDeDados.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMargemCompraVenda);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(197, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 258);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Relatórios";
            // 
            // btnMargemCompraVenda
            // 
            this.btnMargemCompraVenda.ForeColor = System.Drawing.Color.Black;
            this.btnMargemCompraVenda.Location = new System.Drawing.Point(6, 19);
            this.btnMargemCompraVenda.Name = "btnMargemCompraVenda";
            this.btnMargemCompraVenda.Size = new System.Drawing.Size(170, 39);
            this.btnMargemCompraVenda.TabIndex = 13;
            this.btnMargemCompraVenda.Text = "Margem de Compra / Venda";
            this.btnMargemCompraVenda.UseVisualStyleBackColor = true;
            // 
            // frmModGerencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblGerencial);
            this.Name = "frmModGerencial";
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
            this.Text = "Módulo Gerencial";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gpbControladoriaDeDados.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGerencial;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMargemCompraVenda;
        private System.Windows.Forms.GroupBox gpbControladoriaDeDados;
        private System.Windows.Forms.Button btnValidacaoIntegridade;
        private System.Windows.Forms.Button btnAuditoriaDeDados;
        private System.Windows.Forms.Button btnEnvioDeDados;
        private System.Windows.Forms.Button btnRestricaoDeDados;
    }
}