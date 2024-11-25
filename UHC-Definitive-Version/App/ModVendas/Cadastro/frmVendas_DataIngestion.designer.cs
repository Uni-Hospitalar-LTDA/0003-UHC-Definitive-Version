namespace UHC3_Definitive_Version.App.ModVendas.Cadastros
{
    partial class frmVendas_DataIngestion
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
            this.lblSelector = new System.Windows.Forms.Label();
            this.cbxSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArchiveName = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.lblData = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelector
            // 
            this.lblSelector.AutoSize = true;
            this.lblSelector.Location = new System.Drawing.Point(12, 9);
            this.lblSelector.Name = "lblSelector";
            this.lblSelector.Size = new System.Drawing.Size(146, 13);
            this.lblSelector.TabIndex = 0;
            this.lblSelector.Text = "Selecione o Tipo de Ingestão";
            // 
            // cbxSelector
            // 
            this.cbxSelector.FormattingEnabled = true;
            this.cbxSelector.Location = new System.Drawing.Point(15, 25);
            this.cbxSelector.Name = "cbxSelector";
            this.cbxSelector.Size = new System.Drawing.Size(265, 21);
            this.cbxSelector.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome do Arquivo";
            // 
            // txtArchiveName
            // 
            this.txtArchiveName.Location = new System.Drawing.Point(15, 66);
            this.txtArchiveName.Name = "txtArchiveName";
            this.txtArchiveName.Size = new System.Drawing.Size(773, 20);
            this.txtArchiveName.TabIndex = 3;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(286, 23);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Abrir";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 105);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(776, 309);
            this.dgvData.TabIndex = 4;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(12, 89);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(38, 13);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "Dados";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(713, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(632, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(367, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(421, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(367, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(106, 13);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Nome da Importação";
            // 
            // frmVendas_DataIngestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtArchiveName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxSelector);
            this.Controls.Add(this.lblSelector);
            this.Name = "frmVendas_DataIngestion";
            this.Text = "Ingestão de Dados de Vendas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelector;
        private System.Windows.Forms.ComboBox cbxSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArchiveName;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
    }
}