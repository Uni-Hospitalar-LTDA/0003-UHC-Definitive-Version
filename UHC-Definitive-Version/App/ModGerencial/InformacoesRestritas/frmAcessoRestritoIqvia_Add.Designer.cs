namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    partial class frmAcessoRestritoIqvia_Add
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtObservation = new System.Windows.Forms.TextBox();
            this.lblObservation = new System.Windows.Forms.Label();
            this.dtpInitialDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFinalDate = new System.Windows.Forms.DateTimePicker();
            this.lblVigencia = new System.Windows.Forms.Label();
            this.gpbItens = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.gpbItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(62, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Descrição *";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(15, 25);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(391, 20);
            this.txtDescription.TabIndex = 0;
            // 
            // txtObservation
            // 
            this.txtObservation.Location = new System.Drawing.Point(15, 103);
            this.txtObservation.Multiline = true;
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(595, 112);
            this.txtObservation.TabIndex = 3;
            // 
            // lblObservation
            // 
            this.lblObservation.AutoSize = true;
            this.lblObservation.Location = new System.Drawing.Point(12, 87);
            this.lblObservation.Name = "lblObservation";
            this.lblObservation.Size = new System.Drawing.Size(65, 13);
            this.lblObservation.TabIndex = 2;
            this.lblObservation.Text = "Observação";
            // 
            // dtpInitialDate
            // 
            this.dtpInitialDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInitialDate.Location = new System.Drawing.Point(15, 64);
            this.dtpInitialDate.Name = "dtpInitialDate";
            this.dtpInitialDate.Size = new System.Drawing.Size(97, 20);
            this.dtpInitialDate.TabIndex = 1;
            // 
            // dtpFinalDate
            // 
            this.dtpFinalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinalDate.Location = new System.Drawing.Point(118, 64);
            this.dtpFinalDate.Name = "dtpFinalDate";
            this.dtpFinalDate.Size = new System.Drawing.Size(97, 20);
            this.dtpFinalDate.TabIndex = 2;
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.Location = new System.Drawing.Point(12, 48);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(55, 13);
            this.lblVigencia.TabIndex = 6;
            this.lblVigencia.Text = "Vigência *";
            // 
            // gpbItens
            // 
            this.gpbItens.Controls.Add(this.dgvData);
            this.gpbItens.Location = new System.Drawing.Point(15, 221);
            this.gpbItens.Name = "gpbItens";
            this.gpbItens.Size = new System.Drawing.Size(595, 236);
            this.gpbItens.TabIndex = 7;
            this.gpbItens.TabStop = false;
            this.gpbItens.Text = "Itens *";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 16);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(589, 217);
            this.dgvData.TabIndex = 0;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(15, 463);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(25, 23);
            this.btnAdicionar.TabIndex = 4;
            this.btnAdicionar.Text = "+";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(42, 463);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(25, 23);
            this.btnRemover.TabIndex = 5;
            this.btnRemover.Text = "-";
            this.btnRemover.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(535, 463);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(454, 463);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // frmAcessoRestritoIqvia_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 499);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.gpbItens);
            this.Controls.Add(this.lblVigencia);
            this.Controls.Add(this.dtpFinalDate);
            this.Controls.Add(this.dtpInitialDate);
            this.Controls.Add(this.txtObservation);
            this.Controls.Add(this.lblObservation);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Name = "frmAcessoRestritoIqvia_Add";
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
            this.Text = "Acesso Restrito - Iqvia (Adicionar)";
            this.gpbItens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtObservation;
        private System.Windows.Forms.Label lblObservation;
        private System.Windows.Forms.DateTimePicker dtpInitialDate;
        private System.Windows.Forms.DateTimePicker dtpFinalDate;
        private System.Windows.Forms.Label lblVigencia;
        private System.Windows.Forms.GroupBox gpbItens;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView dgvData;
    }
}