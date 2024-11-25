using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.App.ModLicitacao.Processos.AgendaProcessos
{
    public partial class frmEditarAgenda : CustomForm
    {

        /** Instance **/        
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        List<UHC3_Definitive_Version.Domain.Entities.Platform> platforms = new List<UHC3_Definitive_Version.Domain.Entities.Platform>();
        internal Process_Scheduler ps { get; set; }
        ProcessScheduleJustify justify = new ProcessScheduleJustify();
        internal string status { get; set; }
        private string horaOriginal { get; set; }

        public frmEditarAgenda()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureDateTimePickerProperties();
            ConfigureTextBoxProperties();
            ConfigureComboBoxProperties();
            ConfigureButtonProperties();
            ConfigureMenuStripProperties();
            ConfigureFormEvents();

        }


        /** Async Tasks**/
        private async Task getPlatformsAsync()
        {
            platforms = await UHC3_Definitive_Version.Domain.Entities.Platform.getAllToListAsync();
        }
        private async Task updateAsync()
        {
            try
            {
                bool valid = true;
                /** Validations **/
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    CustomNotification.defaultAlert("O campo (Agenda) não pode estar vazio.");
                    txtDescription.Focus();
                    valid = false;
                }
                if ((cbxPlatform.SelectedValue != null || cbxPlatform.SelectedIndex == -1) && valid)
                {
                    CustomNotification.defaultAlert("A plataforma deve ser anexada.");
                    valid = false;
                }
                if (string.IsNullOrEmpty(txtResponsibleDescription.Text) && valid)
                {
                    CustomNotification.defaultAlert("O campo (Responsável) não pode estar vazio.");
                    txtDescription.Focus();
                    valid = false;
                }
                if (string.IsNullOrEmpty(txtCustomerDescription.Text) && valid)
                {
                    CustomNotification.defaultAlert("O campo (Orgão) não pode estar vazio.");
                    txtDescription.Focus();
                    valid = false;
                }

                if (string.IsNullOrEmpty(txtBidding.Text) && valid)
                {
                    CustomNotification.defaultAlert("O campo (Licitação) não pode estar vazio.");
                    txtDescription.Focus();
                    valid = false;
                }

                if (string.IsNullOrEmpty(txtProccess.Text) && valid)
                {
                    CustomNotification.defaultAlert("O campo (Processo) não pode estar vazio.");
                    txtDescription.Focus();
                    valid = false;
                }

                if (valid)
                {

                    var process = (new Process_Scheduler
                    {
                        id = txtId.Text,
                        name = txtName.Text,
                        description = txtDescription.Text,
                        idPlatform = platforms.Where(x => x.name == cbxPlatform.Items[cbxPlatform.SelectedIndex]?.ToString()).FirstOrDefault().id?.ToString(),
                        idResponsible = txtResponsibleId.Text,
                        idCustomer = txtCustomerId.Text,
                        Lic = txtBidding.Text,
                        Process = txtProccess.Text,
                        Participation = rdbYes.Checked ? 1.ToString() : 0.ToString(),
                        Dat_Scheduler = dtpSchedule.Value.ToString(),
                        idJustify = justify.id,
                        link = txtLink.Text

                    });


                    await Process_Scheduler.updateAsync(process);

                    List<logProcess_Scheduler> log = new List<logProcess_Scheduler>();
                    log.Add(new logProcess_Scheduler
                    {
                        idProcess_Scheduler = ps.id
                        ,
                        Dat_Schedule = dtpSchedule.Value.ToString()
                        ,
                        Dat_Modification = DateTime.Now.ToString()
                        ,
                        idUser = Section.idUsuario
                        ,
                        Observation = frmReagenda.MotivoReagendamento
                    });
                    await logProcess_Scheduler.insertAsync(log);

                    CustomNotification.defaultInformation();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /** Sync Methods **/
        public bool IsValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;

            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp ||
                    uriResult.Scheme == Uri.UriSchemeHttps ||
                    uriResult.Scheme == Uri.UriSchemeFtp);
        }
        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmEditarAgenda_Load;
        }
        private async void frmEditarAgenda_Load(object sender, EventArgs e)
        {



            ConfigureRadioButtonAttributes();
            await ConfigureComboBoxAttributes();

            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
            


            await ConfigureTextBoxAttributes();
            await ConfigureDatePickerAttributes();

            horaOriginal = dtpSchedule.Value.ToString();
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtId.ReadOnly = true;
            txtId.TabStop = false;

            txtResponsibleId.JustNumbers();
            txtResponsibleDescription.ReadOnly = true;
            txtResponsibleDescription.TabStop = false;
            txtResponsibleId.MaxLength = 8;
            txtCustomerId.JustNumbers();

            txtCustomerDescription.ReadOnly = true;
            txtCustomerDescription.TabStop = false;
            txtCustomerDescription.MaxLength = 8;
            txtJustify.ReadOnly = true;
            txtJustify.TabStop = false;

            txtUF.ReadOnly = true;
            txtUF.TabStop = false;
            txtUnity.ReadOnly = true;
            txtUnity.TabStop = false;

            txtStatus.ReadOnly = true;
            txtStatus.TabStop = false;
        }
        private void ConfigureTextBoxEvents()
        {
            txtResponsibleId.TextChanged += txtResponsibleId_TextChanged;
            txtResponsibleDescription.DoubleClick += txtResponsibleDescription_DoubleClick;

            txtCustomerId.TextChanged += txtCustomerId_TextChanged;
            txtCustomerDescription.DoubleClick += txtCustomerDescription_DoubleClick;

            txtLink.LostFocus += txtLink_LostFocus;

        }
        private void txtLink_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = ((TextBox)sender);
            if (txt.Text != string.Empty)
            {
                if (txt.Text.StartsWith(@"G:\"))
                {
                    CustomNotification.defaultAlert("Link inválido: A cópia de pastas locais do drive não é permitida.");
                    txt.Text = String.Empty;
                }
                else if (!IsValidUrl(txt.Text))
                {
                    CustomNotification.defaultAlert("O link disponibilizado para acesso ao pregão é inválido, por favor verifique a informação.");
                };
            }
        }

        private async void txtResponsibleId_TextChanged(object sender, EventArgs e)
        {
            Users user = await LicUser.getToClassAsync(txtResponsibleId.Text);
            if (user != null)
            {
                txtResponsibleDescription.Text = user.name;
            }
        }
        private async void txtResponsibleDescription_DoubleClick(object sender, EventArgs e)
        {

            frmGeneric_ConsultaComSelecao responsible = new frmGeneric_ConsultaComSelecao();
            string query = $@"SELECT								 Users.id                                  
                                    ,Users.name [Nome]                                    
                                    ,Sector.description [Setor]                                    
                                FROM [UHCDB].dbo.[Users]
								JOIN [UHCDB].dbo.[Sector] Sector ON Sector.id = Users.idSector
                                WHERE 
									(Sector.description LIKE 'LICIT%' OR Sector.description LIKE 'DIRET%')
									 AND Users.active = 1
									";
            responsible.consulta = await LicUser.getAllToDataTable(query);
            responsible.elemento = "Responsável";
            responsible.ShowDialog();
            txtResponsibleId.Text = responsible.extendedCode;

        }
        private async void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            LicCustomer customer = await LicCustomer.getToClassAsync(txtCustomerId.Text);
            if (customer != null)
            {
                txtCustomerDescription.Text = customer.razao_social;
                txtUF.Text = customer.Cod_Estado;
                txtUnity.Text = customer.Unity;
            }
        }
        private async void txtCustomerDescription_DoubleClick(object sender, EventArgs e)
        {

            frmGeneric_ConsultaComSelecao customer = new frmGeneric_ConsultaComSelecao();
            string query = $@"SELECT 
                            	 Codigo [Código]
                            	,Razao_Social [Órgão]
                            	,[CNPJ] =      FORMAT(CAST(SUBSTRING(REPLACE(Cgc_Cpf, '.', ''), 1, 2) AS INT), '00') + '.' +
                                        FORMAT(CAST(SUBSTRING(REPLACE(Cgc_Cpf, '.', ''), 3, 3) AS INT), '000') + '.' +
                                        FORMAT(CAST(SUBSTRING(REPLACE(Cgc_Cpf, '.', ''), 6, 3) AS INT), '000') + '/' +
                                        FORMAT(CAST(SUBSTRING(REPLACE(Cgc_Cpf, '.', ''), 9, 4) AS INT), '0000') + '-' +
                                        FORMAT(CAST(SUBSTRING(REPLACE(Cgc_Cpf, '.', ''), 13, 2) AS INT), '00') 
                            	,[Esfera] = CASE Tipo_Consumidor 				
                            					WHEN 'P' THEN 'Órgão Público Federal'
                            					WHEN 'E' THEN 'Órgão Público Estadual'
                            					WHEN 'M' THEN 'Órgão Público Municipal'
                            				END
                            	
                            
                            FROM 
                            [DMD].dbo.[CLIEN] Cliente
                            WHERE 
                            Tipo_Consumidor IN ('P','M','E')
									";
            customer.consulta = await LicUser.getAllToDataTable(query);
            customer.elemento = "Órgão";
            customer.ShowDialog();
            txtCustomerId.Text = customer.extendedCode;

        }

        private async Task ConfigureTextBoxAttributes()
        {
            justify = await ProcessScheduleJustify.getToClassAsync(ps.idJustify);
            txtId.Text = ps.id;
            txtName.Text = ps.name;
            txtResponsibleId.Text = ps.idResponsible;
            txtCustomerId.Text = ps.idCustomer;
            txtBidding.Text = ps.Lic;
            txtProccess.Text = ps.Process;
            txtStatus.Text = status;
            txtDescription.Text = ps.description;
            txtJustify.Text = justify.description;
            txtLink.Text = ps.link;


        }

        /** ComboBox Configuration  **/
        private void ConfigureComboBoxProperties()
        {
            cbxPlatform.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private async Task ConfigureComboBoxAttributes()
        {
            await getPlatformsAsync();
            foreach (var p in platforms)
            {
                cbxPlatform.Items.Add(p.name);
            }

            cbxPlatform.Text = platforms.Where(x => x.id == ps.idPlatform).FirstOrDefault().name?.ToString();
        }

        /** DateTimePicker configuration **/
        private void ConfigureDateTimePickerProperties()
        {
            dtpSchedule.Format = DateTimePickerFormat.Custom;
            dtpSchedule.CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy, HH:mm";
            dtpFirstData.Format = DateTimePickerFormat.Custom;
            dtpFirstData.CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy, HH:mm";
            dtpFirstData.Enabled = false;
        }
        private async Task ConfigureDatePickerAttributes()
        {

            var log = await logProcess_Scheduler.getToClassAsync(ps.id);
            dtpSchedule.Value = Convert.ToDateTime(ps.Dat_Scheduler);
            try
            {
                if (log != null)
                    dtpFirstData.Value = Convert.ToDateTime(log.Dat_Schedule);
            }
            catch
            {
                dtpFirstData.Value = dtpSchedule.Value;
            }


        }

        /** Button configuration **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
            
        }
        private void ConfigureButtonEvents()
        {
            btnSave.Click += btnSave_Click;
            btnJustifies.Click += btnJustifies_Click;
            btnAbrirArquivo.Click += btnAbrirArquivo_Click;
        }
        private async void btnJustifies_Click(object sender, EventArgs e)
        {
            frmGeneric_ConsultaComSelecao frmConsultaGenerica = new frmGeneric_ConsultaComSelecao();
            frmConsultaGenerica.consulta = await ProcessScheduleJustify.getAllToDataTableAsync();
            frmConsultaGenerica.elemento = "Justificativa";
            frmConsultaGenerica.ShowDialog();
            justify = await ProcessScheduleJustify.getToClassAsync(frmConsultaGenerica.extendedCode);
            txtJustify.Text = justify.description;

        }
        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
           var result = CustomNotification.defaultQuestionAlert("Você está prestes a ser redirecionado para o diretório do pregão. Deseja continuar?");

            if (result == DialogResult.Yes)
            {
                // Ação quando o usuário pressiona "Yes"
                try
                {
                    System.Diagnostics.Process.Start(ps.link);
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultAlert("Falha ao abrir o Link: " + ex.Message);
                }
            }

        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (horaOriginal != dtpSchedule.Value.ToString())
                {
                    frmReagenda reagendamento = new frmReagenda();
                    reagendamento.ShowDialog();
                    if (frmReagenda.MotivoReagendamento != null)
                    {
                        await updateAsync();
                    }
                }
                else if (horaOriginal == dtpSchedule.Value.ToString())
                {
                    frmReagenda.MotivoReagendamento = null;
                    await updateAsync();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /** Configure RadioButton **/
        private void ConfigureRadioButtonAttributes()
        {
            if (ps.Participation == "1")
            {
                rdbYes.Checked = true;
            }
            else
            {
                rdbNo.Checked = true;
            }
        }

        /** Menu Strip Configuration **/
        private void ConfigureMenuStripProperties()
        {
            CustomToolStripMenuItem menuArquivo = new CustomToolStripMenuItem("Arquivo");
            CustomToolStripMenuItem itemArquivoLogs = new CustomToolStripMenuItem("Verificar Logs de Data");
            

            // Adicionando o item 'Empresa' e seu evento de clique
            menuArquivo.DropDownItems.Add(itemArquivoLogs);            

            // Adiciona o menuConfiguracao ao menu principal
            menuStrip.Items.Add(menuArquivo);
            this.Controls.Add(menuStrip);

        }

        private async void stripMenuVerifyLogDate_Click(object sender, EventArgs e)
        {
            frmConsultaGenerica visualizer = new frmConsultaGenerica();
            visualizer.consulta = await logProcess_Scheduler.getAllToDataTableAsync(ps.id);
            visualizer.ShowDialog();
        }

    }
}
