namespace UHC3_Definitive_Version.App.ModLogistica.CI
{
    partial class frmCI_Conferencia
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIdUhc2 = new System.Windows.Forms.Label();
            this.txtIdUhc2 = new System.Windows.Forms.TextBox();
            this.lblIdCI = new System.Windows.Forms.Label();
            this.txtIdCI = new System.Windows.Forms.TextBox();
            this.lblNFReturn = new System.Windows.Forms.Label();
            this.txtNFReturn = new System.Windows.Forms.TextBox();
            this.lblNFOrigin = new System.Windows.Forms.Label();
            this.txtNFOrigin = new System.Windows.Forms.TextBox();
            this.btnMoreTransporters = new System.Windows.Forms.Button();
            this.txtTransporter = new System.Windows.Forms.TextBox();
            this.txtTransporterId = new System.Windows.Forms.TextBox();
            this.lblTransporter = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkCompleted = new System.Windows.Forms.CheckBox();
            this.chkWaitingFinance = new System.Windows.Forms.CheckBox();
            this.chkPendent = new System.Windows.Forms.CheckBox();
            this.lblRebill = new System.Windows.Forms.Label();
            this.txtRebill = new System.Windows.Forms.TextBox();
            this.btnMoreCustomers = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pcbPendent = new System.Windows.Forms.PictureBox();
            this.pcbWaitingFinance = new System.Windows.Forms.PictureBox();
            this.pcbCompleted = new System.Windows.Forms.PictureBox();
            this.lblPendent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.lblWaitingFinance = new System.Windows.Forms.Label();
            this.lblLate = new System.Windows.Forms.Label();
            this.pcbLate = new System.Windows.Forms.PictureBox();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPendent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbWaitingFinance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCompleted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblIdUhc2);
            this.groupBox1.Controls.Add(this.txtIdUhc2);
            this.groupBox1.Controls.Add(this.lblIdCI);
            this.groupBox1.Controls.Add(this.txtIdCI);
            this.groupBox1.Controls.Add(this.lblNFReturn);
            this.groupBox1.Controls.Add(this.txtNFReturn);
            this.groupBox1.Controls.Add(this.lblNFOrigin);
            this.groupBox1.Controls.Add(this.txtNFOrigin);
            this.groupBox1.Controls.Add(this.btnMoreTransporters);
            this.groupBox1.Controls.Add(this.txtTransporter);
            this.groupBox1.Controls.Add(this.txtTransporterId);
            this.groupBox1.Controls.Add(this.lblTransporter);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lblRebill);
            this.groupBox1.Controls.Add(this.txtRebill);
            this.groupBox1.Controls.Add(this.btnMoreCustomers);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.txtCustomerId);
            this.groupBox1.Controls.Add(this.lblCustomer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // lblIdUhc2
            // 
            this.lblIdUhc2.AutoSize = true;
            this.lblIdUhc2.Location = new System.Drawing.Point(351, 96);
            this.lblIdUhc2.Name = "lblIdUhc2";
            this.lblIdUhc2.Size = new System.Drawing.Size(91, 13);
            this.lblIdUhc2.TabIndex = 29;
            this.lblIdUhc2.Text = "Id da CI no UHC2";
            // 
            // txtIdUhc2
            // 
            this.txtIdUhc2.Location = new System.Drawing.Point(351, 112);
            this.txtIdUhc2.Name = "txtIdUhc2";
            this.txtIdUhc2.Size = new System.Drawing.Size(79, 20);
            this.txtIdUhc2.TabIndex = 28;
            // 
            // lblIdCI
            // 
            this.lblIdCI.AutoSize = true;
            this.lblIdCI.Location = new System.Drawing.Point(266, 96);
            this.lblIdCI.Name = "lblIdCI";
            this.lblIdCI.Size = new System.Drawing.Size(44, 13);
            this.lblIdCI.TabIndex = 25;
            this.lblIdCI.Text = "Id da CI";
            // 
            // txtIdCI
            // 
            this.txtIdCI.Location = new System.Drawing.Point(266, 112);
            this.txtIdCI.Name = "txtIdCI";
            this.txtIdCI.Size = new System.Drawing.Size(79, 20);
            this.txtIdCI.TabIndex = 7;
            // 
            // lblNFReturn
            // 
            this.lblNFReturn.AutoSize = true;
            this.lblNFReturn.Location = new System.Drawing.Point(178, 96);
            this.lblNFReturn.Name = "lblNFReturn";
            this.lblNFReturn.Size = new System.Drawing.Size(76, 13);
            this.lblNFReturn.TabIndex = 23;
            this.lblNFReturn.Text = "NF Devolução";
            // 
            // txtNFReturn
            // 
            this.txtNFReturn.Location = new System.Drawing.Point(181, 112);
            this.txtNFReturn.Name = "txtNFReturn";
            this.txtNFReturn.Size = new System.Drawing.Size(79, 20);
            this.txtNFReturn.TabIndex = 6;
            // 
            // lblNFOrigin
            // 
            this.lblNFOrigin.AutoSize = true;
            this.lblNFOrigin.Location = new System.Drawing.Point(91, 96);
            this.lblNFOrigin.Name = "lblNFOrigin";
            this.lblNFOrigin.Size = new System.Drawing.Size(57, 13);
            this.lblNFOrigin.TabIndex = 21;
            this.lblNFOrigin.Text = "NF Origem";
            // 
            // txtNFOrigin
            // 
            this.txtNFOrigin.Location = new System.Drawing.Point(94, 112);
            this.txtNFOrigin.Name = "txtNFOrigin";
            this.txtNFOrigin.Size = new System.Drawing.Size(79, 20);
            this.txtNFOrigin.TabIndex = 5;
            // 
            // btnMoreTransporters
            // 
            this.btnMoreTransporters.Location = new System.Drawing.Point(500, 72);
            this.btnMoreTransporters.Name = "btnMoreTransporters";
            this.btnMoreTransporters.Size = new System.Drawing.Size(24, 23);
            this.btnMoreTransporters.TabIndex = 19;
            this.btnMoreTransporters.Text = "...";
            this.btnMoreTransporters.UseVisualStyleBackColor = true;
            // 
            // txtTransporter
            // 
            this.txtTransporter.Location = new System.Drawing.Point(80, 73);
            this.txtTransporter.Name = "txtTransporter";
            this.txtTransporter.Size = new System.Drawing.Size(414, 20);
            this.txtTransporter.TabIndex = 3;
            // 
            // txtTransporterId
            // 
            this.txtTransporterId.Location = new System.Drawing.Point(9, 73);
            this.txtTransporterId.Name = "txtTransporterId";
            this.txtTransporterId.Size = new System.Drawing.Size(65, 20);
            this.txtTransporterId.TabIndex = 2;
            // 
            // lblTransporter
            // 
            this.lblTransporter.AutoSize = true;
            this.lblTransporter.Location = new System.Drawing.Point(6, 57);
            this.lblTransporter.Name = "lblTransporter";
            this.lblTransporter.Size = new System.Drawing.Size(73, 13);
            this.lblTransporter.TabIndex = 16;
            this.lblTransporter.Text = "Transportador";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(463, 165);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkCompleted);
            this.groupBox2.Controls.Add(this.chkWaitingFinance);
            this.groupBox2.Controls.Add(this.chkPendent);
            this.groupBox2.Location = new System.Drawing.Point(9, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 48);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // chkCompleted
            // 
            this.chkCompleted.AutoSize = true;
            this.chkCompleted.Checked = true;
            this.chkCompleted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCompleted.Location = new System.Drawing.Point(206, 20);
            this.chkCompleted.Name = "chkCompleted";
            this.chkCompleted.Size = new System.Drawing.Size(75, 17);
            this.chkCompleted.TabIndex = 2;
            this.chkCompleted.Text = "Concluído";
            this.chkCompleted.UseVisualStyleBackColor = true;
            // 
            // chkWaitingFinance
            // 
            this.chkWaitingFinance.AutoSize = true;
            this.chkWaitingFinance.Checked = true;
            this.chkWaitingFinance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWaitingFinance.Location = new System.Drawing.Point(85, 20);
            this.chkWaitingFinance.Name = "chkWaitingFinance";
            this.chkWaitingFinance.Size = new System.Drawing.Size(115, 17);
            this.chkWaitingFinance.TabIndex = 1;
            this.chkWaitingFinance.Text = "Aguard. Financeiro";
            this.chkWaitingFinance.UseVisualStyleBackColor = true;
            // 
            // chkPendent
            // 
            this.chkPendent.AutoSize = true;
            this.chkPendent.Checked = true;
            this.chkPendent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPendent.Location = new System.Drawing.Point(7, 20);
            this.chkPendent.Name = "chkPendent";
            this.chkPendent.Size = new System.Drawing.Size(72, 17);
            this.chkPendent.TabIndex = 0;
            this.chkPendent.Text = "Pendente";
            this.chkPendent.UseVisualStyleBackColor = true;
            // 
            // lblRebill
            // 
            this.lblRebill.AutoSize = true;
            this.lblRebill.Location = new System.Drawing.Point(6, 96);
            this.lblRebill.Name = "lblRebill";
            this.lblRebill.Size = new System.Drawing.Size(65, 13);
            this.lblRebill.TabIndex = 10;
            this.lblRebill.Text = "NF Refatura";
            // 
            // txtRebill
            // 
            this.txtRebill.Location = new System.Drawing.Point(9, 112);
            this.txtRebill.Name = "txtRebill";
            this.txtRebill.Size = new System.Drawing.Size(79, 20);
            this.txtRebill.TabIndex = 4;
            // 
            // btnMoreCustomers
            // 
            this.btnMoreCustomers.Location = new System.Drawing.Point(500, 31);
            this.btnMoreCustomers.Name = "btnMoreCustomers";
            this.btnMoreCustomers.Size = new System.Drawing.Size(24, 23);
            this.btnMoreCustomers.TabIndex = 6;
            this.btnMoreCustomers.Text = "...";
            this.btnMoreCustomers.UseVisualStyleBackColor = true;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(80, 32);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(414, 20);
            this.txtCustomer.TabIndex = 1;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(9, 32);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(65, 20);
            this.txtCustomerId.TabIndex = 0;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(6, 16);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(39, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Cliente";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 218);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(1005, 352);
            this.dgvData.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(942, 576);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(942, 189);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(861, 189);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // pcbPendent
            // 
            this.pcbPendent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pcbPendent.BackColor = System.Drawing.Color.Khaki;
            this.pcbPendent.Location = new System.Drawing.Point(12, 576);
            this.pcbPendent.Name = "pcbPendent";
            this.pcbPendent.Size = new System.Drawing.Size(23, 23);
            this.pcbPendent.TabIndex = 5;
            this.pcbPendent.TabStop = false;
            // 
            // pcbWaitingFinance
            // 
            this.pcbWaitingFinance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pcbWaitingFinance.BackColor = System.Drawing.Color.LightBlue;
            this.pcbWaitingFinance.Location = new System.Drawing.Point(97, 576);
            this.pcbWaitingFinance.Name = "pcbWaitingFinance";
            this.pcbWaitingFinance.Size = new System.Drawing.Size(23, 23);
            this.pcbWaitingFinance.TabIndex = 6;
            this.pcbWaitingFinance.TabStop = false;
            // 
            // pcbCompleted
            // 
            this.pcbCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pcbCompleted.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pcbCompleted.Location = new System.Drawing.Point(249, 576);
            this.pcbCompleted.Name = "pcbCompleted";
            this.pcbCompleted.Size = new System.Drawing.Size(23, 23);
            this.pcbCompleted.TabIndex = 7;
            this.pcbCompleted.TabStop = false;
            // 
            // lblPendent
            // 
            this.lblPendent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPendent.AutoSize = true;
            this.lblPendent.Location = new System.Drawing.Point(38, 581);
            this.lblPendent.Name = "lblPendent";
            this.lblPendent.Size = new System.Drawing.Size(53, 13);
            this.lblPendent.TabIndex = 12;
            this.lblPendent.Text = "Pendente";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 581);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 13;
            // 
            // lblCompleted
            // 
            this.lblCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCompleted.AutoSize = true;
            this.lblCompleted.Location = new System.Drawing.Point(278, 581);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(56, 13);
            this.lblCompleted.TabIndex = 14;
            this.lblCompleted.Text = "Concluído";
            // 
            // lblWaitingFinance
            // 
            this.lblWaitingFinance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWaitingFinance.AutoSize = true;
            this.lblWaitingFinance.Location = new System.Drawing.Point(126, 581);
            this.lblWaitingFinance.Name = "lblWaitingFinance";
            this.lblWaitingFinance.Size = new System.Drawing.Size(117, 13);
            this.lblWaitingFinance.TabIndex = 15;
            this.lblWaitingFinance.Text = "Aguardando Financeiro";
            // 
            // lblLate
            // 
            this.lblLate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLate.AutoSize = true;
            this.lblLate.Location = new System.Drawing.Point(369, 581);
            this.lblLate.Name = "lblLate";
            this.lblLate.Size = new System.Drawing.Size(49, 13);
            this.lblLate.TabIndex = 17;
            this.lblLate.Text = "Atrasado";
            // 
            // pcbLate
            // 
            this.pcbLate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pcbLate.BackColor = System.Drawing.Color.IndianRed;
            this.pcbLate.Location = new System.Drawing.Point(340, 576);
            this.pcbLate.Name = "pcbLate";
            this.pcbLate.Size = new System.Drawing.Size(23, 23);
            this.pcbLate.TabIndex = 16;
            this.pcbLate.TabStop = false;
            // 
            // btnProducts
            // 
            this.btnProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProducts.Location = new System.Drawing.Point(780, 189);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(75, 23);
            this.btnProducts.TabIndex = 2;
            this.btnProducts.Text = "Produtos";
            this.btnProducts.UseVisualStyleBackColor = true;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizar.Location = new System.Drawing.Point(699, 189);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btnVisualizar.TabIndex = 1;
            this.btnVisualizar.Text = "Visualizar C.I";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            // 
            // frmCI_Conferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 611);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.lblLate);
            this.Controls.Add(this.pcbLate);
            this.Controls.Add(this.lblWaitingFinance);
            this.Controls.Add(this.lblCompleted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPendent);
            this.Controls.Add(this.pcbCompleted);
            this.Controls.Add(this.pcbWaitingFinance);
            this.Controls.Add(this.pcbPendent);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCI_Conferencia";
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Text = "Conferência de C.I - Aba Logística (Criar)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPendent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbWaitingFinance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCompleted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnMoreCustomers;
        private System.Windows.Forms.Label lblRebill;
        private System.Windows.Forms.TextBox txtRebill;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkCompleted;
        private System.Windows.Forms.CheckBox chkWaitingFinance;
        private System.Windows.Forms.CheckBox chkPendent;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.PictureBox pcbPendent;
        private System.Windows.Forms.PictureBox pcbWaitingFinance;
        private System.Windows.Forms.PictureBox pcbCompleted;
        private System.Windows.Forms.Label lblPendent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Label lblWaitingFinance;
        private System.Windows.Forms.Label lblLate;
        private System.Windows.Forms.PictureBox pcbLate;
        private System.Windows.Forms.Button btnMoreTransporters;
        private System.Windows.Forms.TextBox txtTransporter;
        private System.Windows.Forms.TextBox txtTransporterId;
        private System.Windows.Forms.Label lblTransporter;
        private System.Windows.Forms.Label lblNFReturn;
        private System.Windows.Forms.TextBox txtNFReturn;
        private System.Windows.Forms.Label lblNFOrigin;
        private System.Windows.Forms.TextBox txtNFOrigin;
        private System.Windows.Forms.Label lblIdCI;
        private System.Windows.Forms.TextBox txtIdCI;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Label lblIdUhc2;
        private System.Windows.Forms.TextBox txtIdUhc2;
        private System.Windows.Forms.Button btnVisualizar;
    }
}