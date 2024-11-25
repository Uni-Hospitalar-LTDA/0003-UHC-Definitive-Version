using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Domain.Entities.Users;
using UHC3_Definitive_Version.App.Telas_Genericas;

namespace UHC3_Definitive_Version.App.ModLicitacao.Processos.AgendaProcessos
{
    public partial class frmCriarAgenda : CustomForm
    {
        /** Instance **/
        List<UHC3_Definitive_Version.Domain.Entities.Platform> platforms = new List<UHC3_Definitive_Version.Domain.Entities.Platform>();

        public frmCriarAgenda()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureDateTimePickerProperties();
            ConfigureTextBoxProperties();
            ConfigureComboBoxProperties();
            ConfigureButtonProperties();
            ConfigureFormEvents();            
        }
        
        /** Async Tasks**/
        private async Task getPlatformsAsync()
        {
            platforms = await UHC3_Definitive_Version.Domain.Entities.Platform.getAllToListAsync();
        }
        private async Task saveAsync()
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
                if ((cbxPlatform.SelectedValue != null|| cbxPlatform.SelectedIndex == -1)  && valid)
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
                    List<Process_Scheduler> process = new List<Process_Scheduler>();
                    process.Add(new Process_Scheduler
                    {
                        name = txtName.Text,
                        description = txtDescription.Text,
                        idPlatform = platforms.Where(x => x.name == cbxPlatform.Items[cbxPlatform.SelectedIndex]?.ToString()).FirstOrDefault().id?.ToString(),
                        idResponsible = txtResponsibleId.Text,
                        idCustomer = txtCustomerId.Text,
                        Lic = txtBidding.Text,
                        Process = txtProccess.Text,
                        Participation = 1.ToString(),
                        Dat_Scheduler = dtpSchedule.Value.ToString(),
                        link = txtLink.Text.Trim(),
                        idUser = Section.idUsuario
                    });

                    List<logProcess_Scheduler> log = new List<logProcess_Scheduler>();

                    
                    await Process_Scheduler.insertAsync(process);
                    await logProcess_Scheduler.insertAsync(log);
                    CustomNotification.defaultInformation();
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
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
        /** Form configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmAgenda_Load;
        }
        private async void frmAgenda_Load(object sender, EventArgs e)
        {
            ConfigureDatePickerAttributes();
            

            await ConfigureComboBoxAttributes();
            await ConfigureTextBoxAttributes();
            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
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

            

            txtUF.ReadOnly = true;
            txtUF.TabStop = false;
            txtUnity.ReadOnly = true;
            txtUnity.TabStop = false;
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
                    txt.Text = String.Empty;
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
            txtId.Text = (await Process_Scheduler.getNextCodeAsync()).ToString();
            txtName.Text = "AGD"+Section.Unidade+txtId.Text;
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
        }

        /** DateTimePicker configuration **/
        private void ConfigureDateTimePickerProperties()
        {
            dtpSchedule.Format = DateTimePickerFormat.Custom;
            dtpSchedule.CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy, HH:mm";

        }
        private void ConfigureDatePickerAttributes()
        {
            dtpSchedule.Value = DateTime.Now;
        }

        /** Button configuration **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();

        }
        private void ConfigureButtonEvents()
        {
            btnSave.Click += btnSave_Click;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert() == DialogResult.Yes)  
                await saveAsync();
        }
    }
}
