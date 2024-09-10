using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModAdmistrativo.Canhotos
{

    public partial class frmRelatorioAusencias : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        List<Contact_Mail> contacts = new List<Contact_Mail>();
        internal class RelatorioAusenciaCanhotos : Querys<RelatorioAusenciaCanhotos>
        {
            public static async Task<DataTable> getAllToDataTableAsync(DateTime dtInicial, DateTime dtFinal, string hasPayed, string hasPacked, string hasInvoiceStub, string transporter)
            {

                string hasPayed_query = null;
                string hasPacked_query = null;
                string hasInvoiceStub_query = null;
                string transporter_query = null;

                if (!string.IsNullOrEmpty(hasPayed))
                {
                    hasPayed_query = (hasPayed.Equals("Sim") ?
                    " AND Baixas_Recebidas.Dat_Registro is not null "
                    :
                    " AND (Baixas_Recebidas.Dat_Registro is null and Contas_Recebidas.Status <> 'B')"
                    );
                }

                if (!string.IsNullOrEmpty(hasPacked))
                {
                    hasPacked_query = (hasPacked.Equals("Sim") ?
                        " AND Romaneio.Num_Nota IS NOT NULL "
                        :
                        " AND Romaneio.Num_Nota IS NULL");
                }
                if (!string.IsNullOrEmpty(hasInvoiceStub))
                {
                    hasInvoiceStub_query = (hasInvoiceStub.Equals("Sim") ?
                        " AND Canhoto.Num_Nota IS NOT NULL"
                        :
                        " AND Canhoto.Num_Nota IS NULL");
                }
                if (!string.IsNullOrEmpty(transporter))
                {
                    transporter_query = $" AND Transportador.Codigo = {transporter}";
                }
                string query = $@"

SELECT 
	  NF_Saida.Num_Nota [NF]
	 ,NF_Saida.Dat_Emissao [Emissão]
	 ,NF_Saida.Cod_Cliente [Cód. Cliente]
	 ,Cliente.Razao_Social [Cliente]
	 ,NF_Saida.Cod_Cfo1 [Cód. CFOP]
	 ,CFOP.Descricao [CFOP]
	 ,NF_Saida.Cod_Transportadora [Cód. Responsável]
	 ,Transportador.Razao_Social [Responsável]
FROM [DMD].dbo.[NFSCB] NF_Saida
JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente
JOIN [DMD].dbo.[TBCFO] CFOP ON CFOP.Codigo = NF_Saida.Cod_Cfo1
LEFT JOIN [DMD].dbo.[TRANS] Transportador ON Transportador.Codigo = NF_Saida.Cod_Transportadora
LEFT JOIN [DMD].dbo.[CTREC] Contas_Recebidas ON Contas_Recebidas.Num_NfOrigem = NF_Saida.Num_Nota 
LEFT JOIN [DMD].dbo.[BXREC] Baixas_Recebidas ON Baixas_Recebidas.Cod_Documento = Contas_Recebidas.Cod_Documento
LEFT JOIN [UHCDB].dbo.[NF_Canhotos] Canhoto ON NF_Saida.Num_Nota = Canhoto.Num_Nota
LEFT JOIN [DMD].dbo.[RMNIT] Romaneio ON Romaneio.Num_Nota = NF_Saida.num_nota
WHERE NF_Saida.Status = 'F' AND Tip_Saida <> 'D'
	  AND NF_SAIDA.Dat_Emissao BETWEEN '{dtInicial.ToShortDateString()}' and '{dtFinal.ToShortDateString()}'

/** Canhotos **/
{(!string.IsNullOrEmpty(hasInvoiceStub) ? hasInvoiceStub_query : null)} 

/** Romaneio **/
{(!string.IsNullOrEmpty(hasPacked) ? hasPacked_query : null)} 

/** Baixa **/
{hasPayed_query}

/** Transportador **/
{transporter_query}



UNION ALL
SELECT 
	  NF_Entrada.Numero [NF]
	 ,NF_Entrada.Dat_Emissao [Emissão]
	 ,NF_Entrada.Cod_EmiCliente [Cód. Cliente]
	 ,Cliente.Razao_Social [Cliente]
	 ,NF_Entrada.Cod_Cfo [Cód. CFOP]
	 ,CFOP.Descricao [CFOP]
	 ,NF_Entrada.Cod_Transp [Cód. Responsável]
	 ,Transportador.Razao_Social [Responsável]
FROM [DMD].dbo.[NFECB] NF_Entrada
JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.CODIGO = NF_Entrada.Cod_EmiCliente 
JOIN [DMD].dbo.[TBCFO] CFOP ON CFOP.CODIGO = NF_Entrada.Cod_Cfo 
LEFT JOIN [DMD].dbo.[TRANS] Transportador ON Transportador.Codigo = NF_Entrada.Cod_Transp
LEFT JOIN [DMD].dbo.[CTREC] Contas_Recebidas ON Contas_Recebidas.Num_NfOrigem = NF_Entrada.Numero
LEFT JOIN [DMD].dbo.[BXREC] Baixas_Recebidas ON Baixas_Recebidas.Cod_Documento = Contas_Recebidas.Cod_Documento
LEFT JOIN [UHCDB].dbo.[NF_Canhotos] Canhoto ON NF_Entrada.Numero = Canhoto.Num_Nota
LEFT JOIN [DMD].dbo.[RMNIT] Romaneio ON Romaneio.Num_Nota = NF_Entrada.Numero
WHERE 
NF_Entrada.Status = 'F' 
AND NF_Entrada.Tip_NF = ('D') 
AND NF_Entrada.Dat_Emissao 
BETWEEN '{dtInicial.ToShortDateString()}' and '{dtFinal.ToShortDateString()}'




/** Canhotos **/
{(!string.IsNullOrEmpty(hasInvoiceStub) ? hasInvoiceStub_query : null)}  

/** Romaneio **/
{(!string.IsNullOrEmpty(hasPacked) ? hasPacked_query : null)} 

/** Baixa **/
{hasPayed_query}

/** Transportador **/
{transporter_query}

ORDER BY [NF]";
                Console.WriteLine(query);
                return await getAllToDataTable(query);
            }
        }
        public frmRelatorioAusencias()
        {
            InitializeComponent();

            //Properties
            ConfigureMenuStripProperties();
            ConfigureFormProperties();
            ConfigureLinkLabelProperties();
            ConfigureTextBoxProperties();
            ConfigureComboBoxProperties();
            ConfigureDataGridViewProperties();
            ConfiguteButtonsProperties();
            ConfigureProgressBarProperties();

            //Events 
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private async Task getReport()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string hasPayed_ = cbxHasPayedFilter.SelectedItem.ToString();
                string hasPacked_ = cbxHasPackedFilter.SelectedItem.ToString();
                string hasInvoiceStub_ = cbxHasInvoiceStubFilter.SelectedItem.ToString();
                string transporter = (!string.IsNullOrEmpty(txtTransportadora.Text) ? txtCodTransportadora.Text : null);
                dgvData.DataSource = await RelatorioAusenciaCanhotos.getAllToDataTableAsync(dtpInitial.Value, dtpFinal.Value
                    , (hasPayed_.Equals(cbxHasPayedFilter.Items[2]) ? null : hasPayed_)
                    , (hasPacked_.Equals(cbxHasPackedFilter.Items[2]) ? null : hasPacked_)
                    , (hasInvoiceStub_.Equals(cbxHasInvoiceStubFilter.Items[2]) ? null : hasInvoiceStub_)
                    , transporter);
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
                this.Cursor = Cursors.Default;
            }
        }
        private async Task getEmailsToNotify()
        {
            contacts = await Contact_Mail.getAllToListByTransporterAsync(txtCodTransportadora.Text);
        }

        /** Form Configuration **/
        private void ConfigureFormEvents()
        {
            this.Load += frmRelatorioAusencias_Load; ;
        }

        private async void frmRelatorioAusencias_Load(object sender, EventArgs e)
        {
            //Atributes 
            ConfigureDateTimePickerAttributes();
            ConfigureComboBexAttributes();

            //Pré load events 
            await getReport();

            //Events 
            ConfigureTextBoxEvents();
            ConfigureButtonsEvents();
            ConfigureLinkLabelEvents();            
        }

        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }

        /** Configure ProgressBar **/
        private void ConfigureProgressBarProperties()
        {
            progressBar1.Visible = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
        }

        /** Configure ComboBox**/
        private void ConfigureComboBoxProperties()
        {
            cbxHasPayedFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxHasPackedFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxHasInvoiceStubFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void ConfigureComboBexAttributes()
        {
            string[] options = { "Sim", "Não", "Todos" };
            cbxHasPayedFilter.Items.AddRange(options);
            cbxHasPackedFilter.Items.AddRange(options);
            cbxHasInvoiceStubFilter.Items.AddRange(options);
            cbxHasPayedFilter.SelectedItem = options[0];
            cbxHasPackedFilter.SelectedItem = options[0];
            cbxHasInvoiceStubFilter.SelectedItem = options[1];
        }

        /** Configure DateTimePicker **/
        private void ConfigureDateTimePickerAttributes()
        {
            dtpInitial.Value = DateTime.Today.AddDays(-15);
            dtpFinal.Value = DateTime.Today;
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.MultiSelect = true;
            dgvData.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
        }

        /** Configure Link Label**/
        private void ConfigureLinkLabelProperties()
        {
            linklblNotifyByMail.Visible = false;
        }
        private void ConfigureLinkLabelEvents()
        {
            linklblNotifyByMail.Click += linklblNotifyByMail_Click;
        }
        private async void linklblNotifyByMail_Click(object sender, EventArgs e)
        {

            if (dgvData.Rows.Count > 0)
            {
                /** Get Contacts **/
                string subject = "Cobrança de Canhotos Pendentes - Ação Necessária";
                string bodyContent = $@"Prezada equipe da {txtTransportadora.Text},

                Esperamos que este e-mail o encontre bem. Gostaríamos de chamar sua atenção para um assunto importante relacionado aos canhotos de entregas efetuadas por sua transportadora no período entre {dtpInitial.Value.ToShortDateString()} e {dtpFinal.Value.ToShortDateString()}.

                De acordo com nossos registros, constatamos que existem alguns canhotos de entregas que ainda não foram devidamente processados em nosso sistema. Como sabemos, a efetivação desses canhotos é um processo essencial para o correto fechamento das operações de transporte e o posterior faturamento dos serviços prestados.

                Diante disso, solicitamos gentilmente que verifiquem internamente a situação dos canhotos pendentes no período mencionado e nos enviem as informações o mais breve possível. Caso já tenham providenciado o envio desses documentos, pedimos que desconsiderem esta mensagem.
                Ressaltamos a importância de responderem a este e-mail com as devidas atualizações sobre os canhotos, pois a falta de retorno pode acarretar em atrasos no processo de faturamento e, consequentemente, impactar o fluxo financeiro de ambas as empresas.

                Por favor, encaminhem as informações para o seguinte endereço de e-mail: administrativo@unihospitalar.com.br. Caso tenham alguma observação ou dificuldade para cumprir o prazo, solicitamos que entrem em contato conosco para que possamos encontrar uma solução conjunta.
                Agradecemos desde já a atenção e colaboração de sua equipe para a resolução desta questão. Estamos à disposição para auxiliar em qualquer dúvida que possa surgir.";



                string bottomMessage = @"Atenciosamente,
                                         Intelligence Bot";
                List<Archive> archives = new List<Archive>();
                List<string> nameArchives = new List<string>();
                archives.Add(new Archive()
                {
                    Id = 1
                   ,
                    description = "Canhotos_Pendentes_" + DateTime.Now.ToString("ddMMyyyy")
                   ,
                    data = (DataTable)dgvData.DataSource
                   ,
                    query = null
                   ,
                    format = "E"
                   ,
                    titleReport = "Canhotos_Pendentes"
                });

                foreach (var archive in archives)
                {
                    nameArchives.Add(archive.description);
                }
                await getEmailsToNotify();
                List<string> emails = new List<string>();
                foreach (var contact in contacts)
                {
                    emails.Add(contact.mail);
                }
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    progressBar1.Visible = true;
                    Email.getMailCredentials();
                    await Email.SendEmailWithExcelAttachment(emails, "administrativo@unihospitalar.com.br", subject, bodyContent, nameArchives, bottomMessage, Section.logoEmail, archives, false);
                    CustomNotification.defaultInformation("E-mail de cobrança enviado com sucesso!");
                    this.Cursor = Cursors.Default;
                    progressBar1.Visible = false;
                }
                catch (Exception )
                {
                    CustomNotification.defaultAlert("Alerta: Verifique se existem contatos cadastrados para a transportadora.");
                }
            }
            else
            {
                CustomNotification.defaultAlert("Não existem dados para realizar a notificação.");
            }

        }

        /** Configure Buttons **/
        private void ConfiguteButtonsProperties()
        {
            btnFechar.toDefaultCloseButton();

        }
        private void ConfigureButtonsEvents()
        {
            btnPesquisar.Click += btnPesquisar_Click;
        }
        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            await getReport();

        }

        /** Configure TextBoxes **/
        private void ConfigureTextBoxProperties()
        {
            txtTransportadora.ReadOnly = true;
            txtTransportadora.TabStop = false;
            txtCodTransportadora.MaxLength = 5;
            txtCodTransportadora.JustNumbers();
        }
        private void ConfigureTextBoxEvents()
        {
            txtCodTransportadora.TextChanged += txtCodTransportadora_TextChanged;
            txtTransportadora.DoubleClick += txtTransportadora_DoubleClick;
            txtTransportadora.TextChanged += txtTransportadora_TextChanged;
        }
        private async void txtCodTransportadora_TextChanged(object sender, EventArgs e)
        {
            txtTransportadora.Text = await Transportadores_Externos.getDescriptionByCode(txtCodTransportadora.Text);
        }
        private void txtTransportadora_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            frmConsultarTransportador.ShowDialog();
            txtCodTransportadora.Text = frmConsultarTransportador.extendedCode;
        }
        private async void txtTransportadora_TextChanged(object sender, EventArgs e)
        {
            await getReport();
            if (!string.IsNullOrEmpty(((TextBox)sender).Text))
                linklblNotifyByMail.Visible = true;
            else
                linklblNotifyByMail.Visible = false;
        }

        /** Menu Strip Configuration **/
        private void ConfigureMenuStripProperties()
        {
            CustomToolStripMenuItem menuArquivo = new CustomToolStripMenuItem("Arquivo");
            CustomToolStripMenuItem itemArquivoAbrir = new CustomToolStripMenuItem("Abrir");
            CustomToolStripMenuItem itemArquivoAbrirExcel = new CustomToolStripMenuItem("Excel");
            CustomToolStripMenuItem itemArquivoExportar = new CustomToolStripMenuItem("Exportar");
            CustomToolStripMenuItem itemArquivoExportarExcel = new CustomToolStripMenuItem("Excel");


            itemArquivoAbrirExcel.Click += ItemArquivoAbrirExcel_Click;
            itemArquivoExportarExcel.Click += ItemArquivoExportarExcel_Click;

            // Adicionando o item 'Empresa' e seu evento de clique

            menuArquivo.DropDownItems.Add(itemArquivoAbrir);
            menuArquivo.DropDownItems.Add(itemArquivoExportar);
            itemArquivoAbrir.DropDownItems.Add(itemArquivoAbrirExcel);
            itemArquivoExportar.DropDownItems.Add(itemArquivoExportarExcel);

            // Adiciona o menuConfiguracao ao menu principal
            menuStrip.Items.Add(menuArquivo);
            this.Controls.Add(menuStrip);

        }
        private void ItemArquivoAbrirExcel_Click(object sender, EventArgs e)
        {
            Exportacao.abrirDataGridViewEmExcel(dgvData);
        }
        private void ItemArquivoExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {

                //this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (dgvData.Rows.Count > 0)
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel File|*.xlsx";
                        saveFileDialog.Title = "Save Excel File";
                        saveFileDialog.FileName = $"{this.Text.substituirCaracteresEspeciais()}_{DateTime.Now.ToString("ddMMyyyy_HHmm")}";
                        saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        saveFileDialog.RestoreDirectory = true;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            RunMethodWithProgressBar((progress, cancellationToken) => Exportacao.exportarExcelComContaLinhas(dgvData, saveFileDialog.FileName, progress, cancellationToken));
                        }
                    }
                }
                catch (OperationCanceledException)
                {

                }
            }
        }
    }
}
