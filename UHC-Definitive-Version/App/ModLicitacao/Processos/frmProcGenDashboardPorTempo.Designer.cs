namespace UHC3_Definitive_Version.App.ModLicitacao.Processos.RelatoriosGerenciais
{
    partial class frmProcGenDashboardPorTempo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcGenDashboardPorTempo));
            this.gpbFilters = new System.Windows.Forms.GroupBox();
            this.gpbRegion = new System.Windows.Forms.GroupBox();
            this.chkSouth = new System.Windows.Forms.CheckBox();
            this.chkSoutheast = new System.Windows.Forms.CheckBox();
            this.chkMidwest = new System.Windows.Forms.CheckBox();
            this.chkNortheast = new System.Windows.Forms.CheckBox();
            this.chkNorth = new System.Windows.Forms.CheckBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.cbxPlatform = new System.Windows.Forms.ComboBox();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtResponsibleDescription = new System.Windows.Forms.TextBox();
            this.dtpInitial = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblResponsible = new System.Windows.Forms.Label();
            this.gpbUnity = new System.Windows.Forms.GroupBox();
            this.clbUnities = new System.Windows.Forms.CheckedListBox();
            this.txtResponsibleId = new System.Windows.Forms.TextBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtCustomerDescription = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.lblUF = new System.Windows.Forms.Label();
            this.gpbInformation = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.btnActiveFilter = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.gpbFilters.SuspendLayout();
            this.gpbRegion.SuspendLayout();
            this.gpbUnity.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbFilters
            // 
            this.gpbFilters.Controls.Add(this.gpbRegion);
            this.gpbFilters.Controls.Add(this.btnFilter);
            this.gpbFilters.Controls.Add(this.dtpFinal);
            this.gpbFilters.Controls.Add(this.cbxPlatform);
            this.gpbFilters.Controls.Add(this.lblPlatform);
            this.gpbFilters.Controls.Add(this.txtState);
            this.gpbFilters.Controls.Add(this.txtResponsibleDescription);
            this.gpbFilters.Controls.Add(this.dtpInitial);
            this.gpbFilters.Controls.Add(this.lblPeriod);
            this.gpbFilters.Controls.Add(this.lblResponsible);
            this.gpbFilters.Controls.Add(this.gpbUnity);
            this.gpbFilters.Controls.Add(this.txtResponsibleId);
            this.gpbFilters.Controls.Add(this.txtCustomerId);
            this.gpbFilters.Controls.Add(this.txtCustomerDescription);
            this.gpbFilters.Controls.Add(this.lblCustomer);
            this.gpbFilters.Controls.Add(this.txtUF);
            this.gpbFilters.Controls.Add(this.lblUF);
            this.gpbFilters.Location = new System.Drawing.Point(12, 27);
            this.gpbFilters.Name = "gpbFilters";
            this.gpbFilters.Size = new System.Drawing.Size(806, 174);
            this.gpbFilters.TabIndex = 0;
            this.gpbFilters.TabStop = false;
            this.gpbFilters.Text = "Filtros";
            // 
            // gpbRegion
            // 
            this.gpbRegion.Controls.Add(this.chkSouth);
            this.gpbRegion.Controls.Add(this.chkSoutheast);
            this.gpbRegion.Controls.Add(this.chkMidwest);
            this.gpbRegion.Controls.Add(this.chkNortheast);
            this.gpbRegion.Controls.Add(this.chkNorth);
            this.gpbRegion.Location = new System.Drawing.Point(695, 9);
            this.gpbRegion.Name = "gpbRegion";
            this.gpbRegion.Size = new System.Drawing.Size(100, 133);
            this.gpbRegion.TabIndex = 38;
            this.gpbRegion.TabStop = false;
            this.gpbRegion.Text = "Região";
            // 
            // chkSouth
            // 
            this.chkSouth.AutoSize = true;
            this.chkSouth.Location = new System.Drawing.Point(7, 110);
            this.chkSouth.Name = "chkSouth";
            this.chkSouth.Size = new System.Drawing.Size(41, 17);
            this.chkSouth.TabIndex = 4;
            this.chkSouth.Text = "Sul";
            this.chkSouth.UseVisualStyleBackColor = true;
            // 
            // chkSoutheast
            // 
            this.chkSoutheast.AutoSize = true;
            this.chkSoutheast.Location = new System.Drawing.Point(7, 89);
            this.chkSoutheast.Name = "chkSoutheast";
            this.chkSoutheast.Size = new System.Drawing.Size(65, 17);
            this.chkSoutheast.TabIndex = 3;
            this.chkSoutheast.Text = "Sudeste";
            this.chkSoutheast.UseVisualStyleBackColor = true;
            // 
            // chkMidwest
            // 
            this.chkMidwest.AutoSize = true;
            this.chkMidwest.Location = new System.Drawing.Point(7, 66);
            this.chkMidwest.Name = "chkMidwest";
            this.chkMidwest.Size = new System.Drawing.Size(88, 17);
            this.chkMidwest.TabIndex = 2;
            this.chkMidwest.Text = "Centro-Oeste";
            this.chkMidwest.UseVisualStyleBackColor = true;
            // 
            // chkNortheast
            // 
            this.chkNortheast.AutoSize = true;
            this.chkNortheast.Location = new System.Drawing.Point(7, 43);
            this.chkNortheast.Name = "chkNortheast";
            this.chkNortheast.Size = new System.Drawing.Size(69, 17);
            this.chkNortheast.TabIndex = 1;
            this.chkNortheast.Text = "Nordeste";
            this.chkNortheast.UseVisualStyleBackColor = true;
            // 
            // chkNorth
            // 
            this.chkNorth.AutoSize = true;
            this.chkNorth.Location = new System.Drawing.Point(7, 20);
            this.chkNorth.Name = "chkNorth";
            this.chkNorth.Size = new System.Drawing.Size(52, 17);
            this.chkNorth.TabIndex = 0;
            this.chkNorth.Text = "Norte";
            this.chkNorth.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(720, 145);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 37;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(376, 115);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(95, 20);
            this.dtpFinal.TabIndex = 34;
            // 
            // cbxPlatform
            // 
            this.cbxPlatform.FormattingEnabled = true;
            this.cbxPlatform.Location = new System.Drawing.Point(484, 114);
            this.cbxPlatform.Name = "cbxPlatform";
            this.cbxPlatform.Size = new System.Drawing.Size(196, 21);
            this.cbxPlatform.TabIndex = 26;
            // 
            // lblPlatform
            // 
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Location = new System.Drawing.Point(481, 99);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(57, 13);
            this.lblPlatform.TabIndex = 29;
            this.lblPlatform.Text = "Plataforma";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(64, 115);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(205, 20);
            this.txtState.TabIndex = 32;
            // 
            // txtResponsibleDescription
            // 
            this.txtResponsibleDescription.Location = new System.Drawing.Point(64, 35);
            this.txtResponsibleDescription.Name = "txtResponsibleDescription";
            this.txtResponsibleDescription.Size = new System.Drawing.Size(401, 20);
            this.txtResponsibleDescription.TabIndex = 23;
            // 
            // dtpInitial
            // 
            this.dtpInitial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInitial.Location = new System.Drawing.Point(275, 115);
            this.dtpInitial.Name = "dtpInitial";
            this.dtpInitial.Size = new System.Drawing.Size(95, 20);
            this.dtpInitial.TabIndex = 33;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(272, 99);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(45, 13);
            this.lblPeriod.TabIndex = 32;
            this.lblPeriod.Text = "Período";
            // 
            // lblResponsible
            // 
            this.lblResponsible.AutoSize = true;
            this.lblResponsible.Location = new System.Drawing.Point(3, 19);
            this.lblResponsible.Name = "lblResponsible";
            this.lblResponsible.Size = new System.Drawing.Size(69, 13);
            this.lblResponsible.TabIndex = 30;
            this.lblResponsible.Text = "Responsável";
            // 
            // gpbUnity
            // 
            this.gpbUnity.Controls.Add(this.clbUnities);
            this.gpbUnity.Location = new System.Drawing.Point(484, 9);
            this.gpbUnity.Name = "gpbUnity";
            this.gpbUnity.Size = new System.Drawing.Size(196, 88);
            this.gpbUnity.TabIndex = 35;
            this.gpbUnity.TabStop = false;
            this.gpbUnity.Text = "Unidade";
            // 
            // clbUnities
            // 
            this.clbUnities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbUnities.FormattingEnabled = true;
            this.clbUnities.Location = new System.Drawing.Point(3, 16);
            this.clbUnities.Name = "clbUnities";
            this.clbUnities.Size = new System.Drawing.Size(190, 69);
            this.clbUnities.TabIndex = 0;
            // 
            // txtResponsibleId
            // 
            this.txtResponsibleId.Location = new System.Drawing.Point(6, 35);
            this.txtResponsibleId.Name = "txtResponsibleId";
            this.txtResponsibleId.Size = new System.Drawing.Size(52, 20);
            this.txtResponsibleId.TabIndex = 22;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(6, 74);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(52, 20);
            this.txtCustomerId.TabIndex = 24;
            // 
            // txtCustomerDescription
            // 
            this.txtCustomerDescription.Location = new System.Drawing.Point(64, 74);
            this.txtCustomerDescription.Name = "txtCustomerDescription";
            this.txtCustomerDescription.Size = new System.Drawing.Size(401, 20);
            this.txtCustomerDescription.TabIndex = 25;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(3, 58);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(36, 13);
            this.lblCustomer.TabIndex = 28;
            this.lblCustomer.Text = "Orgão";
            // 
            // txtUF
            // 
            this.txtUF.Location = new System.Drawing.Point(6, 115);
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(52, 20);
            this.txtUF.TabIndex = 27;
            // 
            // lblUF
            // 
            this.lblUF.AutoSize = true;
            this.lblUF.Location = new System.Drawing.Point(3, 99);
            this.lblUF.Name = "lblUF";
            this.lblUF.Size = new System.Drawing.Size(21, 13);
            this.lblUF.TabIndex = 31;
            this.lblUF.Text = "UF";
            // 
            // gpbInformation
            // 
            this.gpbInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbInformation.Location = new System.Drawing.Point(12, 207);
            this.gpbInformation.Name = "gpbInformation";
            this.gpbInformation.Size = new System.Drawing.Size(1165, 292);
            this.gpbInformation.TabIndex = 2;
            this.gpbInformation.TabStop = false;
            this.gpbInformation.Text = "Informação";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1102, 505);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(824, 172);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(154, 23);
            this.btnData.TabIndex = 39;
            this.btnData.Text = "Acessar dados do Gráfico";
            this.btnData.UseVisualStyleBackColor = true;
            // 
            // btnActiveFilter
            // 
            this.btnActiveFilter.Location = new System.Drawing.Point(824, 36);
            this.btnActiveFilter.Name = "btnActiveFilter";
            this.btnActiveFilter.Size = new System.Drawing.Size(154, 23);
            this.btnActiveFilter.TabIndex = 40;
            this.btnActiveFilter.Text = "Ativar Filtro Multi-Empresa";
            this.btnActiveFilter.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(825, 62);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(343, 104);
            this.lblInfo.TabIndex = 39;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            // 
            // frmProcGenDashboardPorTempo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 535);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnActiveFilter);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gpbInformation);
            this.Controls.Add(this.gpbFilters);
            this.Name = "frmProcGenDashboardPorTempo";
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
            this.Text = "Relatórios Gerenciais (Analítico)";
            this.gpbFilters.ResumeLayout(false);
            this.gpbFilters.PerformLayout();
            this.gpbRegion.ResumeLayout(false);
            this.gpbRegion.PerformLayout();
            this.gpbUnity.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFilters;
        private System.Windows.Forms.Label lblUF;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.TextBox txtResponsibleDescription;
        private System.Windows.Forms.ComboBox cbxPlatform;
        private System.Windows.Forms.Label lblResponsible;
        private System.Windows.Forms.TextBox txtResponsibleId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtCustomerDescription;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInitial;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.GroupBox gpbUnity;
        private System.Windows.Forms.CheckedListBox clbUnities;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox gpbInformation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gpbRegion;
        private System.Windows.Forms.CheckBox chkSouth;
        private System.Windows.Forms.CheckBox chkSoutheast;
        private System.Windows.Forms.CheckBox chkMidwest;
        private System.Windows.Forms.CheckBox chkNortheast;
        private System.Windows.Forms.CheckBox chkNorth;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Button btnActiveFilter;
        internal System.Windows.Forms.Label lblInfo;
    }
}