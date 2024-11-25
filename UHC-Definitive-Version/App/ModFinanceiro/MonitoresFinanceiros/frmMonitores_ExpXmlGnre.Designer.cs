namespace UHC3_Definitive_Version.App.ModFinanceiro.MonitoresFinanceiros
{
    partial class frmMonitores_ExpXmlGnre
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SplitBase = new System.Windows.Forms.SplitContainer();
            this.splitFilter = new System.Windows.Forms.SplitContainer();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblNaoComtempladas = new System.Windows.Forms.Label();
            this.lblLinksUteis = new System.Windows.Forms.Label();
            this.lsbCredenciadas = new System.Windows.Forms.ListBox();
            this.lblEstadosBloqueados = new System.Windows.Forms.Label();
            this.lsbBloqueados = new System.Windows.Forms.ListBox();
            this.lblNaoExportadas = new System.Windows.Forms.Label();
            this.txtNaoExportadas = new System.Windows.Forms.TextBox();
            this.lblExportadas = new System.Windows.Forms.Label();
            this.txtExportadas = new System.Windows.Forms.TextBox();
            this.lblBloqueados = new System.Windows.Forms.Label();
            this.txtBloqueadas = new System.Windows.Forms.TextBox();
            this.lblVermelho = new System.Windows.Forms.Label();
            this.lblCinza = new System.Windows.Forms.Label();
            this.lblVerde = new System.Windows.Forms.Label();
            this.pnlCinza = new System.Windows.Forms.Panel();
            this.pnlVermelho = new System.Windows.Forms.Panel();
            this.pnlVerde = new System.Windows.Forms.Panel();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxBloqueados = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxExportados = new System.Windows.Forms.ComboBox();
            this.lblNF = new System.Windows.Forms.Label();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtUFDesc = new System.Windows.Forms.TextBox();
            this.txtCod_Cliente = new System.Windows.Forms.TextBox();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.dtpDtInicial = new System.Windows.Forms.DateTimePicker();
            this.lblDtInicial = new System.Windows.Forms.Label();
            this.dtpDtFinal = new System.Windows.Forms.DateTimePicker();
            this.lblDtFinal = new System.Windows.Forms.Label();
            this.lblExportacaoGNRE = new System.Windows.Forms.Label();
            this.splitOperation = new System.Windows.Forms.SplitContainer();
            this.splitGridObs = new System.Windows.Forms.SplitContainer();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.splitButtonsExport = new System.Windows.Forms.SplitContainer();
            this.btnRemoverTodos = new System.Windows.Forms.Button();
            this.btnExportarTodos = new System.Windows.Forms.Button();
            this.splitExportar = new System.Windows.Forms.SplitContainer();
            this.txtGuias = new System.Windows.Forms.TextBox();
            this.lblGuias = new System.Windows.Forms.Label();
            this.lsbExportar = new System.Windows.Forms.ListBox();
            this.btnBloquear = new System.Windows.Forms.Button();
            this.btnGerarManual = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFecharConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitBase)).BeginInit();
            this.SplitBase.Panel2.SuspendLayout();
            this.SplitBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitFilter)).BeginInit();
            this.splitFilter.Panel1.SuspendLayout();
            this.splitFilter.Panel2.SuspendLayout();
            this.splitFilter.SuspendLayout();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitOperation)).BeginInit();
            this.splitOperation.Panel1.SuspendLayout();
            this.splitOperation.Panel2.SuspendLayout();
            this.splitOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitGridObs)).BeginInit();
            this.splitGridObs.Panel1.SuspendLayout();
            this.splitGridObs.Panel2.SuspendLayout();
            this.splitGridObs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitButtonsExport)).BeginInit();
            this.splitButtonsExport.Panel1.SuspendLayout();
            this.splitButtonsExport.Panel2.SuspendLayout();
            this.splitButtonsExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitExportar)).BeginInit();
            this.splitExportar.Panel1.SuspendLayout();
            this.splitExportar.Panel2.SuspendLayout();
            this.splitExportar.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitBase
            // 
            this.SplitBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitBase.Location = new System.Drawing.Point(8, 8);
            this.SplitBase.Name = "SplitBase";
            this.SplitBase.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitBase.Panel2
            // 
            this.SplitBase.Panel2.Controls.Add(this.btnBloquear);
            this.SplitBase.Panel2.Controls.Add(this.btnGerarManual);
            this.SplitBase.Panel2.Controls.Add(this.btnCancelar);
            this.SplitBase.Panel2.Controls.Add(this.btnFecharConfirmar);
            this.SplitBase.Size = new System.Drawing.Size(1280, 659);
            this.SplitBase.SplitterDistance = 603;
            this.SplitBase.TabIndex = 2;
            // 
            // splitFilter
            // 
            this.splitFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitFilter.Location = new System.Drawing.Point(-1, 5);
            this.splitFilter.Name = "splitFilter";
            this.splitFilter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitFilter.Panel1
            // 
            this.splitFilter.Panel1.Controls.Add(this.linkLabel3);
            this.splitFilter.Panel1.Controls.Add(this.linkLabel2);
            this.splitFilter.Panel1.Controls.Add(this.linkLabel1);
            this.splitFilter.Panel1.Controls.Add(this.lblNaoComtempladas);
            this.splitFilter.Panel1.Controls.Add(this.lblLinksUteis);
            this.splitFilter.Panel1.Controls.Add(this.lsbCredenciadas);
            this.splitFilter.Panel1.Controls.Add(this.lblEstadosBloqueados);
            this.splitFilter.Panel1.Controls.Add(this.lsbBloqueados);
            this.splitFilter.Panel1.Controls.Add(this.lblNaoExportadas);
            this.splitFilter.Panel1.Controls.Add(this.txtNaoExportadas);
            this.splitFilter.Panel1.Controls.Add(this.lblExportadas);
            this.splitFilter.Panel1.Controls.Add(this.txtExportadas);
            this.splitFilter.Panel1.Controls.Add(this.lblBloqueados);
            this.splitFilter.Panel1.Controls.Add(this.txtBloqueadas);
            this.splitFilter.Panel1.Controls.Add(this.lblVermelho);
            this.splitFilter.Panel1.Controls.Add(this.lblCinza);
            this.splitFilter.Panel1.Controls.Add(this.lblVerde);
            this.splitFilter.Panel1.Controls.Add(this.pnlCinza);
            this.splitFilter.Panel1.Controls.Add(this.pnlVermelho);
            this.splitFilter.Panel1.Controls.Add(this.pnlVerde);
            this.splitFilter.Panel1.Controls.Add(this.gpbFiltros);
            this.splitFilter.Panel1.Controls.Add(this.lblExportacaoGNRE);
            this.splitFilter.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitFilter.Panel2
            // 
            this.splitFilter.Panel2.Controls.Add(this.splitOperation);
            this.splitFilter.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitFilter.Size = new System.Drawing.Size(1280, 603);
            this.splitFilter.SplitterDistance = 232;
            this.splitFilter.TabIndex = 1;
            // 
            // linkLabel3
            // 
            this.linkLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.linkLabel3.Location = new System.Drawing.Point(1019, 55);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(176, 15);
            this.linkLabel3.TabIndex = 99;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Abrir pasta de armazenamento";
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.linkLabel2.Location = new System.Drawing.Point(1019, 38);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(248, 15);
            this.linkLabel2.TabIndex = 98;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Site para importar o arquivo de XML de Lote";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.linkLabel1.Location = new System.Drawing.Point(1019, 22);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(186, 15);
            this.linkLabel1.TabIndex = 97;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Verificar disponibilidade das UFs";
            // 
            // lblNaoComtempladas
            // 
            this.lblNaoComtempladas.AutoSize = true;
            this.lblNaoComtempladas.Location = new System.Drawing.Point(651, 40);
            this.lblNaoComtempladas.Name = "lblNaoComtempladas";
            this.lblNaoComtempladas.Size = new System.Drawing.Size(94, 13);
            this.lblNaoComtempladas.TabIndex = 95;
            this.lblNaoComtempladas.Text = "UFs Credenciadas";
            // 
            // lblLinksUteis
            // 
            this.lblLinksUteis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLinksUteis.AutoSize = true;
            this.lblLinksUteis.Location = new System.Drawing.Point(1020, 9);
            this.lblLinksUteis.Name = "lblLinksUteis";
            this.lblLinksUteis.Size = new System.Drawing.Size(57, 13);
            this.lblLinksUteis.TabIndex = 96;
            this.lblLinksUteis.Text = "Links úteis";
            // 
            // lsbCredenciadas
            // 
            this.lsbCredenciadas.FormattingEnabled = true;
            this.lsbCredenciadas.Location = new System.Drawing.Point(654, 57);
            this.lsbCredenciadas.Name = "lsbCredenciadas";
            this.lsbCredenciadas.Size = new System.Drawing.Size(97, 95);
            this.lsbCredenciadas.TabIndex = 94;
            // 
            // lblEstadosBloqueados
            // 
            this.lblEstadosBloqueados.AutoSize = true;
            this.lblEstadosBloqueados.Location = new System.Drawing.Point(548, 41);
            this.lblEstadosBloqueados.Name = "lblEstadosBloqueados";
            this.lblEstadosBloqueados.Size = new System.Drawing.Size(84, 13);
            this.lblEstadosBloqueados.TabIndex = 93;
            this.lblEstadosBloqueados.Text = "UFs bloqueadas";
            // 
            // lsbBloqueados
            // 
            this.lsbBloqueados.FormattingEnabled = true;
            this.lsbBloqueados.Location = new System.Drawing.Point(551, 57);
            this.lsbBloqueados.Name = "lsbBloqueados";
            this.lsbBloqueados.Size = new System.Drawing.Size(97, 95);
            this.lsbBloqueados.TabIndex = 92;
            // 
            // lblNaoExportadas
            // 
            this.lblNaoExportadas.AutoSize = true;
            this.lblNaoExportadas.Location = new System.Drawing.Point(429, 119);
            this.lblNaoExportadas.Name = "lblNaoExportadas";
            this.lblNaoExportadas.Size = new System.Drawing.Size(102, 13);
            this.lblNaoExportadas.TabIndex = 90;
            this.lblNaoExportadas.Text = "NFs não exportadas";
            // 
            // txtNaoExportadas
            // 
            this.txtNaoExportadas.Location = new System.Drawing.Point(432, 135);
            this.txtNaoExportadas.Name = "txtNaoExportadas";
            this.txtNaoExportadas.Size = new System.Drawing.Size(100, 20);
            this.txtNaoExportadas.TabIndex = 91;
            // 
            // lblExportadas
            // 
            this.lblExportadas.AutoSize = true;
            this.lblExportadas.Location = new System.Drawing.Point(429, 80);
            this.lblExportadas.Name = "lblExportadas";
            this.lblExportadas.Size = new System.Drawing.Size(81, 13);
            this.lblExportadas.TabIndex = 88;
            this.lblExportadas.Text = "NFs exportadas";
            // 
            // txtExportadas
            // 
            this.txtExportadas.Location = new System.Drawing.Point(432, 96);
            this.txtExportadas.Name = "txtExportadas";
            this.txtExportadas.Size = new System.Drawing.Size(100, 20);
            this.txtExportadas.TabIndex = 89;
            // 
            // lblBloqueados
            // 
            this.lblBloqueados.AutoSize = true;
            this.lblBloqueados.Location = new System.Drawing.Point(429, 41);
            this.lblBloqueados.Name = "lblBloqueados";
            this.lblBloqueados.Size = new System.Drawing.Size(84, 13);
            this.lblBloqueados.TabIndex = 67;
            this.lblBloqueados.Text = "NFs bloqueadas";
            // 
            // txtBloqueadas
            // 
            this.txtBloqueadas.Location = new System.Drawing.Point(432, 57);
            this.txtBloqueadas.Name = "txtBloqueadas";
            this.txtBloqueadas.Size = new System.Drawing.Size(100, 20);
            this.txtBloqueadas.TabIndex = 87;
            // 
            // lblVermelho
            // 
            this.lblVermelho.AutoSize = true;
            this.lblVermelho.Location = new System.Drawing.Point(303, 202);
            this.lblVermelho.Name = "lblVermelho";
            this.lblVermelho.Size = new System.Drawing.Size(82, 13);
            this.lblVermelho.TabIndex = 80;
            this.lblVermelho.Text = "Guia bloqueada";
            // 
            // lblCinza
            // 
            this.lblCinza.AutoSize = true;
            this.lblCinza.Location = new System.Drawing.Point(193, 202);
            this.lblCinza.Name = "lblCinza";
            this.lblCinza.Size = new System.Drawing.Size(79, 13);
            this.lblCinza.TabIndex = 79;
            this.lblCinza.Text = "Guia exportada";
            // 
            // lblVerde
            // 
            this.lblVerde.AutoSize = true;
            this.lblVerde.Location = new System.Drawing.Point(37, 202);
            this.lblVerde.Name = "lblVerde";
            this.lblVerde.Size = new System.Drawing.Size(125, 13);
            this.lblVerde.TabIndex = 78;
            this.lblVerde.Text = "Estado não contemplado";
            // 
            // pnlCinza
            // 
            this.pnlCinza.BackColor = System.Drawing.Color.Tan;
            this.pnlCinza.Location = new System.Drawing.Point(168, 200);
            this.pnlCinza.Name = "pnlCinza";
            this.pnlCinza.Size = new System.Drawing.Size(19, 18);
            this.pnlCinza.TabIndex = 76;
            // 
            // pnlVermelho
            // 
            this.pnlVermelho.BackColor = System.Drawing.Color.Red;
            this.pnlVermelho.Location = new System.Drawing.Point(278, 200);
            this.pnlVermelho.Name = "pnlVermelho";
            this.pnlVermelho.Size = new System.Drawing.Size(19, 18);
            this.pnlVermelho.TabIndex = 77;
            // 
            // pnlVerde
            // 
            this.pnlVerde.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlVerde.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlVerde.Location = new System.Drawing.Point(12, 200);
            this.pnlVerde.Name = "pnlVerde";
            this.pnlVerde.Size = new System.Drawing.Size(19, 18);
            this.pnlVerde.TabIndex = 75;
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.label2);
            this.gpbFiltros.Controls.Add(this.cbxBloqueados);
            this.gpbFiltros.Controls.Add(this.label1);
            this.gpbFiltros.Controls.Add(this.cbxExportados);
            this.gpbFiltros.Controls.Add(this.lblNF);
            this.gpbFiltros.Controls.Add(this.txtNF);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.lblEstado);
            this.gpbFiltros.Controls.Add(this.lblCliente);
            this.gpbFiltros.Controls.Add(this.txtCliente);
            this.gpbFiltros.Controls.Add(this.txtUFDesc);
            this.gpbFiltros.Controls.Add(this.txtCod_Cliente);
            this.gpbFiltros.Controls.Add(this.txtUF);
            this.gpbFiltros.Controls.Add(this.dtpDtInicial);
            this.gpbFiltros.Controls.Add(this.lblDtInicial);
            this.gpbFiltros.Controls.Add(this.dtpDtFinal);
            this.gpbFiltros.Controls.Add(this.lblDtFinal);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 41);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(396, 147);
            this.gpbFiltros.TabIndex = 20;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Bloqueados";
            // 
            // cbxBloqueados
            // 
            this.cbxBloqueados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBloqueados.FormattingEnabled = true;
            this.cbxBloqueados.Location = new System.Drawing.Point(70, 112);
            this.cbxBloqueados.Name = "cbxBloqueados";
            this.cbxBloqueados.Size = new System.Drawing.Size(99, 21);
            this.cbxBloqueados.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Exportados";
            // 
            // cbxExportados
            // 
            this.cbxExportados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExportados.FormattingEnabled = true;
            this.cbxExportados.Location = new System.Drawing.Point(175, 112);
            this.cbxExportados.Name = "cbxExportados";
            this.cbxExportados.Size = new System.Drawing.Size(99, 21);
            this.cbxExportados.TabIndex = 4;
            // 
            // lblNF
            // 
            this.lblNF.AutoSize = true;
            this.lblNF.Location = new System.Drawing.Point(8, 97);
            this.lblNF.Name = "lblNF";
            this.lblNF.Size = new System.Drawing.Size(21, 13);
            this.lblNF.TabIndex = 62;
            this.lblNF.Text = "NF";
            // 
            // txtNF
            // 
            this.txtNF.Location = new System.Drawing.Point(8, 113);
            this.txtNF.MaxLength = 8;
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(56, 20);
            this.txtNF.TabIndex = 2;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(298, 103);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 37);
            this.btnPesquisar.TabIndex = 6;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(218, 57);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 58;
            this.lblEstado.Text = "Estado";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(8, 16);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 54;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(62, 32);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(316, 20);
            this.txtCliente.TabIndex = 3;
            this.txtCliente.TabStop = false;
            // 
            // txtUFDesc
            // 
            this.txtUFDesc.Location = new System.Drawing.Point(250, 73);
            this.txtUFDesc.Name = "txtUFDesc";
            this.txtUFDesc.ReadOnly = true;
            this.txtUFDesc.Size = new System.Drawing.Size(128, 20);
            this.txtUFDesc.TabIndex = 5;
            this.txtUFDesc.TabStop = false;
            // 
            // txtCod_Cliente
            // 
            this.txtCod_Cliente.Location = new System.Drawing.Point(8, 32);
            this.txtCod_Cliente.MaxLength = 5;
            this.txtCod_Cliente.Name = "txtCod_Cliente";
            this.txtCod_Cliente.Size = new System.Drawing.Size(48, 20);
            this.txtCod_Cliente.TabIndex = 5;
            // 
            // txtUF
            // 
            this.txtUF.Location = new System.Drawing.Point(218, 73);
            this.txtUF.MaxLength = 2;
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(26, 20);
            this.txtUF.TabIndex = 3;
            // 
            // dtpDtInicial
            // 
            this.dtpDtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtInicial.Location = new System.Drawing.Point(8, 73);
            this.dtpDtInicial.MinDate = new System.DateTime(2016, 6, 3, 0, 0, 0, 0);
            this.dtpDtInicial.Name = "dtpDtInicial";
            this.dtpDtInicial.Size = new System.Drawing.Size(99, 20);
            this.dtpDtInicial.TabIndex = 0;
            this.dtpDtInicial.Value = new System.DateTime(2019, 8, 14, 0, 0, 0, 0);
            // 
            // lblDtInicial
            // 
            this.lblDtInicial.AutoSize = true;
            this.lblDtInicial.Location = new System.Drawing.Point(8, 57);
            this.lblDtInicial.Name = "lblDtInicial";
            this.lblDtInicial.Size = new System.Drawing.Size(50, 13);
            this.lblDtInicial.TabIndex = 48;
            this.lblDtInicial.Text = "Dt. inicial";
            // 
            // dtpDtFinal
            // 
            this.dtpDtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtFinal.Location = new System.Drawing.Point(113, 73);
            this.dtpDtFinal.MinDate = new System.DateTime(2016, 6, 3, 0, 0, 0, 0);
            this.dtpDtFinal.Name = "dtpDtFinal";
            this.dtpDtFinal.Size = new System.Drawing.Size(99, 20);
            this.dtpDtFinal.TabIndex = 1;
            this.dtpDtFinal.Value = new System.DateTime(2019, 8, 14, 0, 0, 0, 0);
            // 
            // lblDtFinal
            // 
            this.lblDtFinal.AutoSize = true;
            this.lblDtFinal.Location = new System.Drawing.Point(113, 57);
            this.lblDtFinal.Name = "lblDtFinal";
            this.lblDtFinal.Size = new System.Drawing.Size(43, 13);
            this.lblDtFinal.TabIndex = 49;
            this.lblDtFinal.Text = "Dt. final";
            // 
            // lblExportacaoGNRE
            // 
            this.lblExportacaoGNRE.AutoSize = true;
            this.lblExportacaoGNRE.BackColor = System.Drawing.Color.Gainsboro;
            this.lblExportacaoGNRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportacaoGNRE.Location = new System.Drawing.Point(12, 9);
            this.lblExportacaoGNRE.Name = "lblExportacaoGNRE";
            this.lblExportacaoGNRE.Size = new System.Drawing.Size(235, 25);
            this.lblExportacaoGNRE.TabIndex = 19;
            this.lblExportacaoGNRE.Text = "Exportação de GNRE";
            // 
            // splitOperation
            // 
            this.splitOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitOperation.Location = new System.Drawing.Point(0, 0);
            this.splitOperation.Name = "splitOperation";
            // 
            // splitOperation.Panel1
            // 
            this.splitOperation.Panel1.Controls.Add(this.splitGridObs);
            this.splitOperation.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitOperation.Panel2
            // 
            this.splitOperation.Panel2.Controls.Add(this.splitButtonsExport);
            this.splitOperation.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitOperation.Size = new System.Drawing.Size(1280, 367);
            this.splitOperation.SplitterDistance = 1106;
            this.splitOperation.TabIndex = 1;
            // 
            // splitGridObs
            // 
            this.splitGridObs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitGridObs.Location = new System.Drawing.Point(0, 0);
            this.splitGridObs.Name = "splitGridObs";
            this.splitGridObs.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitGridObs.Panel1
            // 
            this.splitGridObs.Panel1.Controls.Add(this.dgvData);
            // 
            // splitGridObs.Panel2
            // 
            this.splitGridObs.Panel2.Controls.Add(this.txtObservacao);
            this.splitGridObs.Size = new System.Drawing.Size(1106, 367);
            this.splitGridObs.SplitterDistance = 313;
            this.splitGridObs.TabIndex = 7;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1106, 313);
            this.dgvData.TabIndex = 88;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservacao.Location = new System.Drawing.Point(0, 0);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(1106, 50);
            this.txtObservacao.TabIndex = 0;
            // 
            // splitButtonsExport
            // 
            this.splitButtonsExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitButtonsExport.Location = new System.Drawing.Point(0, 0);
            this.splitButtonsExport.Name = "splitButtonsExport";
            // 
            // splitButtonsExport.Panel1
            // 
            this.splitButtonsExport.Panel1.Controls.Add(this.btnRemoverTodos);
            this.splitButtonsExport.Panel1.Controls.Add(this.btnExportarTodos);
            // 
            // splitButtonsExport.Panel2
            // 
            this.splitButtonsExport.Panel2.Controls.Add(this.splitExportar);
            this.splitButtonsExport.Size = new System.Drawing.Size(170, 367);
            this.splitButtonsExport.SplitterDistance = 56;
            this.splitButtonsExport.TabIndex = 0;
            // 
            // btnRemoverTodos
            // 
            this.btnRemoverTodos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemoverTodos.BackColor = System.Drawing.Color.Firebrick;
            this.btnRemoverTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoverTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnRemoverTodos.ForeColor = System.Drawing.Color.White;
            this.btnRemoverTodos.Location = new System.Drawing.Point(11, 184);
            this.btnRemoverTodos.Name = "btnRemoverTodos";
            this.btnRemoverTodos.Size = new System.Drawing.Size(34, 30);
            this.btnRemoverTodos.TabIndex = 64;
            this.btnRemoverTodos.Text = "<<";
            this.btnRemoverTodos.UseVisualStyleBackColor = false;
            // 
            // btnExportarTodos
            // 
            this.btnExportarTodos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExportarTodos.BackColor = System.Drawing.Color.Firebrick;
            this.btnExportarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnExportarTodos.ForeColor = System.Drawing.Color.White;
            this.btnExportarTodos.Location = new System.Drawing.Point(11, 148);
            this.btnExportarTodos.Name = "btnExportarTodos";
            this.btnExportarTodos.Size = new System.Drawing.Size(34, 30);
            this.btnExportarTodos.TabIndex = 63;
            this.btnExportarTodos.Text = ">>";
            this.btnExportarTodos.UseVisualStyleBackColor = false;
            // 
            // splitExportar
            // 
            this.splitExportar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitExportar.Location = new System.Drawing.Point(0, 0);
            this.splitExportar.Name = "splitExportar";
            this.splitExportar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitExportar.Panel1
            // 
            this.splitExportar.Panel1.Controls.Add(this.txtGuias);
            this.splitExportar.Panel1.Controls.Add(this.lblGuias);
            // 
            // splitExportar.Panel2
            // 
            this.splitExportar.Panel2.Controls.Add(this.lsbExportar);
            this.splitExportar.Size = new System.Drawing.Size(110, 367);
            this.splitExportar.SplitterDistance = 36;
            this.splitExportar.TabIndex = 0;
            // 
            // txtGuias
            // 
            this.txtGuias.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtGuias.Location = new System.Drawing.Point(0, 16);
            this.txtGuias.MaxLength = 2;
            this.txtGuias.Name = "txtGuias";
            this.txtGuias.ReadOnly = true;
            this.txtGuias.Size = new System.Drawing.Size(110, 20);
            this.txtGuias.TabIndex = 83;
            // 
            // lblGuias
            // 
            this.lblGuias.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblGuias.AutoSize = true;
            this.lblGuias.BackColor = System.Drawing.Color.Transparent;
            this.lblGuias.Location = new System.Drawing.Point(22, 0);
            this.lblGuias.Name = "lblGuias";
            this.lblGuias.Size = new System.Drawing.Size(57, 13);
            this.lblGuias.TabIndex = 84;
            this.lblGuias.Text = "Qtd. Guias";
            // 
            // lsbExportar
            // 
            this.lsbExportar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbExportar.FormattingEnabled = true;
            this.lsbExportar.Location = new System.Drawing.Point(0, 0);
            this.lsbExportar.Name = "lsbExportar";
            this.lsbExportar.Size = new System.Drawing.Size(110, 327);
            this.lsbExportar.TabIndex = 91;
            // 
            // btnBloquear
            // 
            this.btnBloquear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBloquear.BackColor = System.Drawing.Color.DarkRed;
            this.btnBloquear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBloquear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnBloquear.ForeColor = System.Drawing.Color.White;
            this.btnBloquear.Location = new System.Drawing.Point(12, 11);
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(79, 34);
            this.btnBloquear.TabIndex = 66;
            this.btnBloquear.Text = "Bloquear";
            this.btnBloquear.UseVisualStyleBackColor = false;
            // 
            // btnGerarManual
            // 
            this.btnGerarManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGerarManual.BackColor = System.Drawing.Color.OliveDrab;
            this.btnGerarManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnGerarManual.ForeColor = System.Drawing.Color.White;
            this.btnGerarManual.Location = new System.Drawing.Point(94, 11);
            this.btnGerarManual.Name = "btnGerarManual";
            this.btnGerarManual.Size = new System.Drawing.Size(100, 34);
            this.btnGerarManual.TabIndex = 65;
            this.btnGerarManual.Text = "Gerar manual";
            this.btnGerarManual.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(1112, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 34);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnFecharConfirmar
            // 
            this.btnFecharConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFecharConfirmar.BackColor = System.Drawing.Color.Green;
            this.btnFecharConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnFecharConfirmar.Location = new System.Drawing.Point(1189, 11);
            this.btnFecharConfirmar.Name = "btnFecharConfirmar";
            this.btnFecharConfirmar.Size = new System.Drawing.Size(82, 34);
            this.btnFecharConfirmar.TabIndex = 0;
            this.btnFecharConfirmar.Text = "Exportar";
            this.btnFecharConfirmar.UseVisualStyleBackColor = false;
            // 
            // frmMonitores_ExpXmlGnre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 659);
            this.Controls.Add(this.splitFilter);
            this.Controls.Add(this.SplitBase);
            this.Name = "frmMonitores_ExpXmlGnre";
            this.Text = "Monitor GNRE";
            this.SplitBase.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitBase)).EndInit();
            this.SplitBase.ResumeLayout(false);
            this.splitFilter.Panel1.ResumeLayout(false);
            this.splitFilter.Panel1.PerformLayout();
            this.splitFilter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitFilter)).EndInit();
            this.splitFilter.ResumeLayout(false);
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            this.splitOperation.Panel1.ResumeLayout(false);
            this.splitOperation.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitOperation)).EndInit();
            this.splitOperation.ResumeLayout(false);
            this.splitGridObs.Panel1.ResumeLayout(false);
            this.splitGridObs.Panel2.ResumeLayout(false);
            this.splitGridObs.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitGridObs)).EndInit();
            this.splitGridObs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.splitButtonsExport.Panel1.ResumeLayout(false);
            this.splitButtonsExport.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitButtonsExport)).EndInit();
            this.splitButtonsExport.ResumeLayout(false);
            this.splitExportar.Panel1.ResumeLayout(false);
            this.splitExportar.Panel1.PerformLayout();
            this.splitExportar.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitExportar)).EndInit();
            this.splitExportar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitBase;
        private System.Windows.Forms.Button btnBloquear;
        private System.Windows.Forms.Button btnGerarManual;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFecharConfirmar;
        private System.Windows.Forms.SplitContainer splitFilter;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblNaoComtempladas;
        private System.Windows.Forms.Label lblLinksUteis;
        private System.Windows.Forms.ListBox lsbCredenciadas;
        private System.Windows.Forms.Label lblEstadosBloqueados;
        private System.Windows.Forms.ListBox lsbBloqueados;
        private System.Windows.Forms.Label lblNaoExportadas;
        private System.Windows.Forms.TextBox txtNaoExportadas;
        private System.Windows.Forms.Label lblExportadas;
        private System.Windows.Forms.TextBox txtExportadas;
        private System.Windows.Forms.Label lblBloqueados;
        private System.Windows.Forms.TextBox txtBloqueadas;
        private System.Windows.Forms.Label lblVermelho;
        private System.Windows.Forms.Label lblCinza;
        private System.Windows.Forms.Label lblVerde;
        private System.Windows.Forms.Panel pnlCinza;
        private System.Windows.Forms.Panel pnlVermelho;
        private System.Windows.Forms.Panel pnlVerde;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxBloqueados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxExportados;
        private System.Windows.Forms.Label lblNF;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtUFDesc;
        private System.Windows.Forms.TextBox txtCod_Cliente;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.DateTimePicker dtpDtInicial;
        private System.Windows.Forms.Label lblDtInicial;
        private System.Windows.Forms.DateTimePicker dtpDtFinal;
        private System.Windows.Forms.Label lblDtFinal;
        private System.Windows.Forms.Label lblExportacaoGNRE;
        private System.Windows.Forms.SplitContainer splitOperation;
        private System.Windows.Forms.SplitContainer splitGridObs;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.SplitContainer splitButtonsExport;
        private System.Windows.Forms.Button btnRemoverTodos;
        private System.Windows.Forms.Button btnExportarTodos;
        private System.Windows.Forms.SplitContainer splitExportar;
        private System.Windows.Forms.TextBox txtGuias;
        private System.Windows.Forms.Label lblGuias;
        private System.Windows.Forms.ListBox lsbExportar;
    }
}