namespace UHC3_Definitive_Version.App.Opcoes.OpcoesDeDesenvolvedor
{
    partial class frmOpcoesDesenvolvedor
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
            this.btnLiberarUpdate = new System.Windows.Forms.Button();
            this.btnPermissoes = new System.Windows.Forms.Button();
            this.btnAtivarRollBack = new System.Windows.Forms.Button();
            this.btnBasesSwagger = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLiberarUpdate
            // 
            this.btnLiberarUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnLiberarUpdate.Location = new System.Drawing.Point(12, 12);
            this.btnLiberarUpdate.Name = "btnLiberarUpdate";
            this.btnLiberarUpdate.Size = new System.Drawing.Size(170, 39);
            this.btnLiberarUpdate.TabIndex = 3;
            this.btnLiberarUpdate.Text = "Liberar Update";
            this.btnLiberarUpdate.UseVisualStyleBackColor = true;
            // 
            // btnPermissoes
            // 
            this.btnPermissoes.ForeColor = System.Drawing.Color.Black;
            this.btnPermissoes.Location = new System.Drawing.Point(12, 57);
            this.btnPermissoes.Name = "btnPermissoes";
            this.btnPermissoes.Size = new System.Drawing.Size(170, 39);
            this.btnPermissoes.TabIndex = 4;
            this.btnPermissoes.Text = "Manutenção das Permissões";
            this.btnPermissoes.UseVisualStyleBackColor = true;
            // 
            // btnAtivarRollBack
            // 
            this.btnAtivarRollBack.ForeColor = System.Drawing.Color.Black;
            this.btnAtivarRollBack.Location = new System.Drawing.Point(188, 12);
            this.btnAtivarRollBack.Name = "btnAtivarRollBack";
            this.btnAtivarRollBack.Size = new System.Drawing.Size(170, 39);
            this.btnAtivarRollBack.TabIndex = 5;
            this.btnAtivarRollBack.Text = "Ativar rollback";
            this.btnAtivarRollBack.UseVisualStyleBackColor = true;
            // 
            // btnBasesSwagger
            // 
            this.btnBasesSwagger.ForeColor = System.Drawing.Color.Black;
            this.btnBasesSwagger.Location = new System.Drawing.Point(188, 57);
            this.btnBasesSwagger.Name = "btnBasesSwagger";
            this.btnBasesSwagger.Size = new System.Drawing.Size(170, 39);
            this.btnBasesSwagger.TabIndex = 6;
            this.btnBasesSwagger.Text = "Bases Swagger";
            this.btnBasesSwagger.UseVisualStyleBackColor = true;
            // 
            // frmOpcoesDesenvolvedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBasesSwagger);
            this.Controls.Add(this.btnAtivarRollBack);
            this.Controls.Add(this.btnPermissoes);
            this.Controls.Add(this.btnLiberarUpdate);
            this.Name = "frmOpcoesDesenvolvedor";
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
            this.Text = "Opções de Desenvolvedor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLiberarUpdate;
        private System.Windows.Forms.Button btnPermissoes;
        private System.Windows.Forms.Button btnAtivarRollBack;
        private System.Windows.Forms.Button btnBasesSwagger;
    }
}