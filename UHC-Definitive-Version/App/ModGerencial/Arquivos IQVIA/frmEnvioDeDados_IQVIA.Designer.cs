namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    partial class frmEnvioDeDados_IQVIA
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkArchiveList = new System.Windows.Forms.CheckedListBox();
            this.chkFTPList = new System.Windows.Forms.CheckedListBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblDataFiltro = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 171);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(262, 23);
            this.progressBar1.TabIndex = 19;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(281, 171);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "FTPs de envio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Lista de Arquivos";
            // 
            // chkArchiveList
            // 
            this.chkArchiveList.FormattingEnabled = true;
            this.chkArchiveList.Location = new System.Drawing.Point(13, 29);
            this.chkArchiveList.Name = "chkArchiveList";
            this.chkArchiveList.Size = new System.Drawing.Size(155, 94);
            this.chkArchiveList.TabIndex = 15;
            // 
            // chkFTPList
            // 
            this.chkFTPList.FormattingEnabled = true;
            this.chkFTPList.Location = new System.Drawing.Point(174, 29);
            this.chkFTPList.Name = "chkFTPList";
            this.chkFTPList.Size = new System.Drawing.Size(260, 94);
            this.chkFTPList.TabIndex = 14;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(362, 171);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 13;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            // 
            // lblDataFiltro
            // 
            this.lblDataFiltro.AutoSize = true;
            this.lblDataFiltro.Location = new System.Drawing.Point(13, 129);
            this.lblDataFiltro.Name = "lblDataFiltro";
            this.lblDataFiltro.Size = new System.Drawing.Size(105, 13);
            this.lblDataFiltro.TabIndex = 12;
            this.lblDataFiltro.Text = "Intervalo de Seleção";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Location = new System.Drawing.Point(228, 145);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(209, 20);
            this.dtpFinal.TabIndex = 11;
            // 
            // dtpInicial
            // 
            this.dtpInicial.Location = new System.Drawing.Point(13, 145);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(209, 20);
            this.dtpInicial.TabIndex = 10;
            // 
            // frmEnvioDeDados_IQVIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 206);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkArchiveList);
            this.Controls.Add(this.chkFTPList);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.lblDataFiltro);
            this.Controls.Add(this.dtpFinal);
            this.Controls.Add(this.dtpInicial);
            this.Name = "frmEnvioDeDados_IQVIA";
            this.Text = "Envio de Arquivos IQVIA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chkArchiveList;
        private System.Windows.Forms.CheckedListBox chkFTPList;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblDataFiltro;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInicial;
    }
}