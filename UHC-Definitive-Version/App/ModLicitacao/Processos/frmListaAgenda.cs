using System;
using System.Collections.Generic;
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
    public partial class frmListaAgenda : CustomForm
    {
        /** Instance **/
        List<UHC3_Definitive_Version.Domain.Entities.Platform> platforms = new List<UHC3_Definitive_Version.Domain.Entities.Platform>();
        public int LinhaSelecionada { get; set; }
        
        
        public frmListaAgenda()
        {
            InitializeComponent();


            ConfigureFormProperties();
            ConfigureDataGridViewProperties();
            ConfigureComboBoxProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();
            ConfigureFormEvents();
        }

        /** DateTimePicker Configuration **/
        private void ConfigureDateTimePicketAttributes()
        {
            dtpInicial.Value = DateTime.Now;
            dtpFinal.Value = DateTime.Now.AddDays(92);
        }



        /** Async Methods **/
        private async Task getPlatformsAsync()
        {
            platforms = await UHC3_Definitive_Version.Domain.Entities.Platform.getAllToListAsync();
        }
        public async Task getSchedulerAsync()
        {
            string customerId = string.IsNullOrEmpty(txtCustomerId.Text) ? string.Empty : txtCustomerId.Text;
            string responsibleId = string.IsNullOrEmpty(txtResponsibleId.Text) ? string.Empty : txtResponsibleId.Text;
            string platformid = null;
            if (cbxPlatform?.SelectedIndex != -1 && cbxPlatform?.SelectedIndex != 0)
                platformid = platforms.Where(x => x.name == cbxPlatform.Items[cbxPlatform.SelectedIndex]?.ToString()).FirstOrDefault().id?.ToString();
            string status = null;
            status += (chkProgrammedStatus.Checked ? "P" : null);            
            status += (chkFeedback.Checked ? "A" : null);
            status += (chkFinished.Checked ? "F" : null);
            string paticipation = null;
            paticipation += (chkYes.Checked ? "1" : null);
            paticipation += (chkNo.Checked ? "0" : null);
            if(paticipation.Contains("1") && paticipation.Contains("0"))
            {
                paticipation = (chkNo.Checked && chkYes.Checked ? "B" : null); // Caso as opções sim e não estejam marcadas ele irá atribuir a variável "B" de "BOTH" 
            }
            string dataInicio = dtpInicial.Value.ToString("yyyy-MM-dd");
            string dataFinal = dtpFinal.Value.ToString("yyyy-MM-dd");
            
            dgvData.SuspendLayout();
            dgvData.DataSource = await Process_Scheduler.getAllToDataTableWithFilterAsync(txtName.Text, customerId, responsibleId, platformid, status, dataInicio, dataFinal, paticipation);            
            dgvData.AutoResizeColumns();
            dgvData.ResumeLayout();
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
            this.WindowState = FormWindowState.Normal;
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmListaAgenda_Load;
        }
        private async void frmListaAgenda_Load(object sender, System.EventArgs e)
        {
            ConfigureDateTimePicketAttributes();
            await ConfigureComboBoxAttributes();
            await getPlatformsAsync();
            await getSchedulerAsync();

            

            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
            ConfigureDataGridViewEvents();
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvData.DoubleClick += dgvData_DoubleClick;
        }

        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        /** ComboBox Configuration  **/
        private void ConfigureComboBoxProperties()
        {
            cbxPlatform.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private async Task ConfigureComboBoxAttributes()
        {
            await getPlatformsAsync();
            cbxPlatform.Items.Add("Todos");
            cbxPlatform.SelectedIndex = 0;
            foreach (var p in platforms)
            {
                cbxPlatform.Items.Add(p.name);
            }
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {

            txtResponsibleId.JustNumbers();
            txtResponsibleDescription.ReadOnly = true;
            txtResponsibleDescription.TabStop = false;
            txtResponsibleId.MaxLength = 3;

            txtCustomerId.JustNumbers();
            txtCustomerDescription.ReadOnly = true;
            txtCustomerDescription.TabStop = false;
            txtCustomerDescription.MaxLength = 8;


        }
        private void ConfigureTextBoxEvents()
        {
            txtResponsibleId.TextChanged += txtResponsibleId_TextChanged;
            txtResponsibleDescription.DoubleClick += txtResponsibleDescription_DoubleClick;

            txtCustomerId.TextChanged += txtCustomerId_TextChanged;
            txtCustomerDescription.DoubleClick += txtCustomerDescription_DoubleClick;

            txtResponsibleId.KeyDown += txtGeneric_KeyDown;
            txtCustomerId.KeyDown += txtGeneric_KeyDown;
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
        private void txtGeneric_KeyDown(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e); 
        }
        
        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSearch.Click += btnSearch_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnClear.Click += btnClear_Click;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCriarAgenda frmCriarAgenda = new frmCriarAgenda();
            frmCriarAgenda.ShowDialog();
            btnSearch_Click(sender, e);
        }
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0) 
            {
                frmEditarAgenda frmEditarAgenda = new frmEditarAgenda();
                frmEditarAgenda.ps = await Process_Scheduler.getToClassAsync(dgvData.CurrentRow.Cells[0].Value.ToString());
                frmEditarAgenda.status = dgvData.CurrentRow.Cells["Status"].Value.ToString();
                frmEditarAgenda.ShowDialog();
                btnSearch_Click(sender, e);
            }
        }  
        private async void btnSearch_Click(object sender, System.EventArgs e)
        {      
            await getSchedulerAsync();
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            dtpInicial.Value = DateTime.Now;
            dtpFinal.Value = DateTime.Now.AddDays(92);
            txtResponsibleId.Clear();
            txtName.Clear();
            txtCustomerId.Clear();
            chkYes.Checked = false;
            chkNo.Checked = false;
            chkProgrammedStatus.Checked = false;
            chkFinished.Checked = false;    
            chkFeedback.Checked = false;    
            await getSchedulerAsync();
        }

    }
}
