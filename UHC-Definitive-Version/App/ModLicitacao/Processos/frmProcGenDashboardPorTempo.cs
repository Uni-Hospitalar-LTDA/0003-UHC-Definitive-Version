using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.App.ModLicitacao.Processos.RelatoriosGerenciais
{
    public partial class frmProcGenDashboardPorTempo : CustomForm
    {
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        DataTable information = new DataTable();
        List<UHC3_Definitive_Version.Domain.Entities.Platform> platforms = new List<UHC3_Definitive_Version.Domain.Entities.Platform>();
        LiveCharts.WinForms.CartesianChart lineChart = new LiveCharts.WinForms.CartesianChart();
        /** Instance **/
        private class Dashboard : Querys<Dashboard>
        {
            

            public static async Task<DataTable> getAllToDataTableAsync(DateTime ini, DateTime fin
                , string region, string responsible, string customer
                , string state, string platform)
            {
                string date1 = ini.ToString("yyyyMMdd");
                string date2 = fin.ToString("yyyyMMdd");
                string query = $@"SELECT 
									process.Dat_Scheduler [Data]
                                   ,COUNT (*) [Processos]
                                   ,Participation 
                                    FROM [UHCDB].dbo.[Process_Scheduler] process          
                                    JOIN [DMD].dbo.[CLIEN] Customer ON Customer.Codigo = process.idCustomer
                                    JOIN [UHCDB].dbo.[State] ON State.uf = Customer.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS									
                                    WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                                    AND ({region})
                                    AND ({responsible})
                                    AND ({customer})
                                    AND ({state})
                                    AND ({platform})
                                    GROUP BY 
                                    process.Dat_Scheduler
                                    ,Participation ";
                Console.WriteLine(query);
                return await getAllToDataTable(query);
            }



            public static async Task<DataTable> getAllToDataTableVisualizerAsync(DateTime ini, DateTime fin
                , string region, string responsible, string customer
                , string state, string platform)
            {
                string date1 = ini.ToString("yyyyMMdd");
                string date2 = fin.ToString("yyyyMMdd");
                string query = $@"SELECT distinct
									 process.Id
									,process.name [Nome]
									,process.Dat_Scheduler [Agendamento]
									,Customer.Codigo [Cód. Cliente]
									,Customer.Razao_Social [Razão Social]
									,CASE Participation WHEN 1 THEN 'Sim' ELSE 'Não' END [Participação]									
									,[Status] = 
                                		CASE 
                                			WHEN Dat_Scheduler > GETDATE() AND SendedProcesses.id is null THEN 'Programado'			
											WHEN SendedProcesses.idProcessSchedule IS NOT NULL
											AND process.idJustify is not null THEN 'Finalizado'
                                			WHEN SendedProcesses.idProcessSchedule IS NOT NULL
											AND process.idJustify is null THEN 'Aguardando Feedback'
											ELSE 'Não notificado'
                                		 END           
                                    FROM [UHCDB].dbo.[Process_Scheduler] process          
                                    JOIN [DMD].dbo.[CLIEN] Customer ON Customer.Codigo = process.idCustomer
                                    JOIN [UHCDB].dbo.[State] ON State.uf = Customer.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS									
									LEFT JOIN [UHCDB].dbo.Notifier_ProcessLic SendedProcesses ON SendedProcesses.idProcessSchedule = process.Id								
                                    WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                                    AND ({region})
                                    AND ({responsible})
                                    AND ({customer})
                                    AND ({state})
                                    AND ({platform})                                    
                                    ";
                Console.WriteLine(query);
                return await getAllToDataTable(query);
            }

            public static async Task<DataTable> getAllToDataTableMultiFilterAsync(DateTime ini, DateTime fin
                , string region
                , string state, bool pe, bool ce, bool sp)
            {
                string date1 = ini.ToString("yyyyMMdd");
                string date2 = fin.ToString("yyyyMMdd");
                List<string> queries = new List<string>();

                string baseQueryPE = $@"SELECT 
                            process.Dat_Scheduler [Data]
                           ,COUNT (*) [Processos]
                           ,Participation 
                            FROM [UHCDB].dbo.[Process_Scheduler] process          
                            JOIN [DMD].dbo.[CLIEN] Customer ON Customer.Codigo = process.idCustomer
                            JOIN [UHCDB].dbo.[State] ON State.uf = Customer.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS									
                            WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                            AND ({region})                                    
                            AND ({state})                                    
                            GROUP BY 
                            process.Dat_Scheduler
                            ,Participation ";
                string baseQueryCE = $@"SELECT 
                            process.Dat_Scheduler [Data]
                           ,COUNT (*) [Processos]
                           ,Participation 
                            FROM UNI_CEARA.[UHCDB].dbo.[Process_Scheduler] process          
                            JOIN UNI_CEARA.[DMD].dbo.[CLIEN] Customer ON Customer.Codigo = process.idCustomer
                            JOIN UNI_CEARA.[UHCDB].dbo.[State] ON State.uf = Customer.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS									
                            WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                            AND ({region})                                    
                            AND ({state})                                    
                            GROUP BY 
                            process.Dat_Scheduler
                            ,Participation ";
                string baseQuerySP = $@"SELECT 
                            process.Dat_Scheduler [Data]
                           ,COUNT (*) [Processos]
                           ,Participation 
                            FROM SP_HOSPITALAR.[UHCDB].dbo.[Process_Scheduler] process          
                            JOIN SP_HOSPITALAR.[DMD].dbo.[CLIEN] Customer ON Customer.Codigo = process.idCustomer
                            JOIN SP_HOSPITALAR.[UHCDB].dbo.[State] ON State.uf = Customer.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS									
                            WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                            AND ({region})                                    
                            AND ({state})                                    
                            GROUP BY 
                            process.Dat_Scheduler
                            ,Participation ";

                if (pe)
                {
                    queries.Add(baseQueryPE);
                }
                if (ce)
                {
                    queries.Add(baseQueryCE);
                }
                if (sp)
                {
                    queries.Add(baseQuerySP);
                }

                string combinedQuery = string.Join(" UNION ALL ", queries);
                Console.WriteLine(combinedQuery);
                return await getAllToDataTableMultiFilter(combinedQuery);
            }


            public static async Task<DataTable> getAllToDataTableVisualizerMultiFilterAsync(DateTime ini, DateTime fin
                , string region
                , string state, bool pe, bool ce, bool sp)
            {
                       string date1 = ini.ToString("yyyyMMdd");
                string date2 = fin.ToString("yyyyMMdd");
                List<string> queries = new List<string>();

                string baseQueryPE = $@"SELECT distinct
     process.Id
    ,process.name COLLATE SQL_Latin1_General_CP1_CI_AS [Nome]
    ,process.Dat_Scheduler
    ,Customer.Codigo  [Cód. Cliente]
    ,Customer.Razao_Social COLLATE SQL_Latin1_General_CP1_CI_AS [Razão Social]
    ,CASE Participation WHEN 1 THEN 'Sim' ELSE 'Não' END COLLATE SQL_Latin1_General_CP1_CI_AS [Participação]								
									,[Status] = 
                                		CASE 
                                			WHEN Dat_Scheduler > GETDATE() AND SendedProcesses.id is null THEN 'Programado'			
											WHEN SendedProcesses.idProcessSchedule IS NOT NULL
											AND process.idJustify is not null THEN 'Finalizado'
                                			WHEN SendedProcesses.idProcessSchedule IS NOT NULL
											AND process.idJustify is null THEN 'Aguardando Feedback'
											ELSE 'Não notificado'
                                		 END     
,[Unidade] = 'PE'
                                    FROM [UHCDB].dbo.[Process_Scheduler] process          
                                    JOIN [DMD].dbo.[CLIEN] Customer ON Customer.Codigo = process.idCustomer
                                    JOIN [UHCDB].dbo.[State] ON State.uf = Customer.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS									
									LEFT JOIN [UHCDB].dbo.Notifier_ProcessLic SendedProcesses ON SendedProcesses.idProcessSchedule = process.Id								
                                    WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                                    AND ({region})                                    
                                    AND ({state})";
                string baseQueryCE = $@"SELECT distinct
     process.Id
    ,process.name COLLATE SQL_Latin1_General_CP1_CI_AS [Nome]
    ,process.Dat_Scheduler
    ,Customer.Codigo  [Cód. Cliente]
    ,Customer.Razao_Social COLLATE SQL_Latin1_General_CP1_CI_AS [Razão Social]
    ,CASE Participation WHEN 1 THEN 'Sim' ELSE 'Não' END COLLATE SQL_Latin1_General_CP1_CI_AS [Participação]							
									,[Status] = 
                                		CASE 
                                			WHEN Dat_Scheduler > GETDATE() AND SendedProcesses.id is null THEN 'Programado'			
											WHEN SendedProcesses.idProcessSchedule IS NOT NULL
											AND process.idJustify is not null THEN 'Finalizado'
                                			WHEN SendedProcesses.idProcessSchedule IS NOT NULL
											AND process.idJustify is null THEN 'Aguardando Feedback'
											ELSE 'Não notificado'
                                		 END    
,[Unidade] = 'CE'
                                    FROM Uni_Ceara.[UHCDB].dbo.[Process_Scheduler] process          
                                    JOIN Uni_Ceara.[DMD].dbo.[CLIEN] Customer ON Customer.Codigo = process.idCustomer
                                    JOIN Uni_Ceara.[UHCDB].dbo.[State] ON State.uf = Customer.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS									
									LEFT JOIN [UHCDB].dbo.Notifier_ProcessLic SendedProcesses ON SendedProcesses.idProcessSchedule = process.Id								
                                    WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                                    AND ({region})                                    
                                    AND ({state})";
                string baseQuerySP = $@"SELECT distinct
     process.Id
    ,process.name COLLATE SQL_Latin1_General_CP1_CI_AS [Nome]
    ,process.Dat_Scheduler
    ,Customer.Codigo  [Cód. Cliente]
    ,Customer.Razao_Social COLLATE SQL_Latin1_General_CP1_CI_AS [Razão Social]
    ,CASE Participation WHEN 1 THEN 'Sim' ELSE 'Não' END COLLATE SQL_Latin1_General_CP1_CI_AS [Participação]								
									,[Status] = 
                                		CASE 
                                			WHEN Dat_Scheduler > GETDATE() AND SendedProcesses.id is null THEN 'Programado'			
											WHEN SendedProcesses.idProcessSchedule IS NOT NULL
											AND process.idJustify is not null THEN 'Finalizado'
                                			WHEN SendedProcesses.idProcessSchedule IS NOT NULL
											AND process.idJustify is null THEN 'Aguardando Feedback'
											ELSE 'Não notificado'
                                		 END           
,[Unidade] = 'SP'
                                    FROM SP_Hospitalar.[UHCDB].dbo.[Process_Scheduler] process          
                                    JOIN SP_Hospitalar.[DMD].dbo.[CLIEN] Customer ON Customer.Codigo = process.idCustomer
                                    JOIN SP_Hospitalar.[UHCDB].dbo.[State] ON State.uf = Customer.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS									
									LEFT JOIN [UHCDB].dbo.Notifier_ProcessLic SendedProcesses ON SendedProcesses.idProcessSchedule = process.Id								
                                    WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                                    AND ({region})                                    
                                    AND ({state})";

                if (pe)
                {
                    queries.Add(baseQueryPE);
                }
                if (ce)
                {
                    queries.Add(baseQueryCE);
                }
                if (sp)
                {
                    queries.Add(baseQuerySP);
                }


                string combinedQuery = string.Join(" UNION ALL ", queries);
                Console.WriteLine(combinedQuery);
                return await getAllToDataTableMultiFilter(combinedQuery);
            }
        }
        
        public frmProcGenDashboardPorTempo()
        {
            InitializeComponent();


            ConfigureFormProperties();
            ConfigureTextBoxProperties(); 
            ConfigureButtonProperties();

            ConfigureMenuStripProperties();

            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private async Task getInformationAsync()
        {

            /** Responsible filter **/
            string responsibleFilter = string.Empty;
            if (!string.IsNullOrEmpty(txtResponsibleDescription.Text))
                responsibleFilter = "idResponsible = " + txtResponsibleId.Text;
            else
                responsibleFilter = "1=1";

            /** Customer  Filter **/
            string customerFilter = string.Empty;
            if (!string.IsNullOrEmpty(txtCustomerDescription.Text))
                customerFilter = "idCustomer = " + txtCustomerId.Text;
            else
                customerFilter = "1=1";

            /** State filter **/            
            string stateFilter = string.Empty;
            if (!string.IsNullOrEmpty(txtState.Text))
                stateFilter = "State.uf = '" + txtUF.Text+ "'";
            else
                stateFilter = "1=1";

            /** Platform filter **/
            string platformFilter = string.Empty;
            if (cbxPlatform?.SelectedIndex != -1 && cbxPlatform?.SelectedIndex != 0)
                platformFilter = "idPlatform = " + platforms.Where(x => x.name == cbxPlatform.Items[cbxPlatform.SelectedIndex]?.ToString()).FirstOrDefault().id?.ToString();
            else
                platformFilter = "1=1";
            /** Region filter **/
            string regionFilter = string.Empty;
            if (chkNorth.Checked)
                regionFilter += "State.Region = 'NORTE'";
            if (chkNortheast.Checked)
                regionFilter += (string.IsNullOrEmpty(regionFilter) ? "" : " OR ") + "State.Region = 'NORDESTE'";
            if (chkMidwest.Checked)
                regionFilter += (string.IsNullOrEmpty(regionFilter) ? "" : " OR ") + "State.Region = 'CENTROOESTE'";
            if (chkSoutheast.Checked)
                regionFilter += (string.IsNullOrEmpty(regionFilter) ? "" : " OR ") + "State.Region = 'SUDESTE'";
            if (chkSouth.Checked)
                regionFilter += (string.IsNullOrEmpty(regionFilter) ? "" : " OR ") + "State.Region = 'SUL'";

            if (string.IsNullOrEmpty(regionFilter))
                regionFilter = "1=1";


            
            bool pe = false;
            bool ce = false;
            bool sp = false;
            if (multiFilter == 1)
            {
                foreach (var item in clbUnities.CheckedItems)
                {
                    if (item.Equals("UNI HOSPITALAR"))
                    {
                        pe = true;
                    }
                    if (item.Equals("UNI CEARÁ"))
                    {
                        ce = true;
                    }
                    if (item.Equals("SP HOSPITALAR"))
                    {
                        sp = true;
                    }                    
                }
                information = await Dashboard.getAllToDataTableMultiFilterAsync(dtpInitial.Value, dtpFinal.Value
                , regionFilter,stateFilter,pe,ce,sp);
            }
            else
            {
                information = await Dashboard.getAllToDataTableAsync(dtpInitial.Value, dtpFinal.Value
                , regionFilter, responsibleFilter, customerFilter, stateFilter, platformFilter);
            }


            /** Graph Info **/
            gpbInformation.Controls.Clear();
            try
            {
                if (information != null)
                {
                    GenerateLineChartFromDataTable(information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private async Task getPlatformsAsync()
        {
            platforms = await UHC3_Definitive_Version.Domain.Entities.Platform.getAllToListAsync();
        }

        /** Graphs Generation **/
        public void GenerateLineChartFromDataTable(DataTable table)
        {
            // Criar dicionários para armazenar a soma dos processos e participações por mês
            Dictionary<string, double> dataPerMonthProcess = new Dictionary<string, double>();
            Dictionary<string, double> dataPerMonthParticipation = new Dictionary<string, double>();

            // Processar cada linha da tabela
            foreach (DataRow row in table.Rows)
            {
                DateTime date = DateTime.ParseExact(row["Data"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                double processes = Convert.ToDouble(row["Processos"]);
                double participation = Convert.ToDouble(row["Participation"]);

                string monthKey = date.Year + "-" + date.Month;

                // Process data for processes
                if (dataPerMonthProcess.ContainsKey(monthKey))
                {
                    dataPerMonthProcess[monthKey] += processes;
                }
                else
                {
                    dataPerMonthProcess[monthKey] = processes;
                }

                // Process data for participation
                if (dataPerMonthParticipation.ContainsKey(monthKey))
                {
                    dataPerMonthParticipation[monthKey] += participation;
                }
                else
                {
                    dataPerMonthParticipation[monthKey] = participation;
                }
            }

            // Ordenar os dados pelo mês
            var orderedDataProcess = dataPerMonthProcess.OrderBy(x => DateTime.ParseExact(x.Key, "yyyy-M", CultureInfo.InvariantCulture)).ToList();
            var orderedDataParticipation = dataPerMonthParticipation.OrderBy(x => DateTime.ParseExact(x.Key, "yyyy-M", CultureInfo.InvariantCulture)).ToList();

            // Criar o gráfico de linhas
            lineChart = new LiveCharts.WinForms.CartesianChart();

            // Processos por Mês
            var lineSeriesProcess = new LiveCharts.Wpf.LineSeries
            {
                Title = "Processos por Mês",
                Values = new ChartValues<double>(orderedDataProcess.Select(x => x.Value)),
                DataLabels = true,
                LabelPoint = point => point.Y + " Processos"
            };

            // Participação por Mês
            var lineSeriesParticipation = new LiveCharts.Wpf.LineSeries
            {
                Title = "Participação por Mês",
                Values = new ChartValues<double>(orderedDataParticipation.Select(x => x.Value)),
                DataLabels = true,
                LabelPoint = point => point.Y + " Participações"
            };

            lineChart.Series = new SeriesCollection { lineSeriesProcess, lineSeriesParticipation };
            lineChart.AxisX.Add(new Axis
            {
                Title = "Mês",
                Labels = orderedDataProcess.Select(x => x.Key).ToList() // As dataPerMonthProcess e dataPerMonthParticipation possuem as mesmas chaves, podemos usar qualquer um para o eixo X.
            });

            lineChart.AxisY.Add(new Axis
            {
                Title = "Valores",
                LabelFormatter = value => value.ToString()
            });

            // Aqui, adicione o lineChart ao seu formulário conforme necessário
            lineChart.Dock = DockStyle.Fill;
            lineChart.LegendLocation = LegendLocation.Bottom;
            gpbInformation.Controls.Add(lineChart);
        }
        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmProcGenDashboardPorTempo_Load;
        }
        private async void frmProcGenDashboardPorTempo_Load(object sender, EventArgs e)
        {

            lblInfo.Visible = false;

            ConfigureDateTimePickerAttributes();
            ConfigureCheckedListBoxAttributes();
            ConfigureCheckBoxAttributes();
            await ConfigureComboBoxAttributes();            
            await getInformationAsync();            

            ConfigureTextBoxEvents();
            ConfigureButtonEvents();


        }

        /** DateTimePicker Configuration **/        
        private void ConfigureDateTimePickerAttributes()
        {
            dtpInitial.Value = Convert.ToDateTime("01/01/" + DateTime.Now.Year.ToString());
            dtpFinal.Value = Convert.ToDateTime("31/12/" + DateTime.Now.Year.ToString());
        }

        /** Configure CheckedListBox**/
        private void ConfigureCheckedListBoxAttributes()
        {

            clbUnities.Items.Add("UNI HOSPITALAR", CheckState.Unchecked);
            clbUnities.Items.Add("UNI CEARÁ", CheckState.Unchecked);
            clbUnities.Items.Add("SP HOSPITALAR", CheckState.Unchecked);

            for (int i = 0; i < clbUnities.Items.Count; i++)
            {
                if (Section.Unidade == clbUnities.Items[i].ToString())
                {
                    try
                    {
                        clbUnities.SetItemChecked(i, true); // Marcar o item como selecionado                        
                        int index = i;                        
                    }
                    catch (Exception ex)
                    {
                        CustomNotification.defaultAlert(ex.Message);
                    }
                }
            }

            clbUnities.Enabled = false;
        }
        /** Configure CheckBox **/
        private void ConfigureCheckBoxAttributes()
        {
            chkNorth.Checked = true;
            chkNortheast.Checked = true;
            chkMidwest.Checked = true;
            chkSoutheast.Checked = true;
            chkSouth.Checked = true;
        }

        /** Configure ComboBox **/
        private async Task ConfigureComboBoxAttributes()
        {
            await getPlatformsAsync();
            cbxPlatform.Items.Add("Todas");
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
            txtResponsibleId.MaxLength = 8;
            txtCustomerId.JustNumbers();
            txtCustomerDescription.ReadOnly = true;
            txtCustomerDescription.TabStop = false;
            txtCustomerDescription.MaxLength = 8;

            txtUF.MaxLength = 2;
            txtState.ReadOnly = true;
            txtState.TabStop = false;            
        }
        private void ConfigureTextBoxEvents()
        {
            txtResponsibleId.TextChanged += txtResponsibleId_TextChanged;
            txtResponsibleDescription.DoubleClick += txtResponsibleDescription_DoubleClick;

            txtCustomerId.TextChanged += txtCustomerId_TextChanged;
            txtCustomerDescription.DoubleClick += txtCustomerDescription_DoubleClick;

            txtUF.TextChanged += txtUF_TextChanged;


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
        private async void txtUF_TextChanged(object sender, EventArgs e)
        {
            txtState.Text = (await State.getToClassAsync(txtUF.Text)).description;
        }
       
        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnFilter.Click += btnFilter_Click;
            btnData.Click += btnData_Click;
            btnActiveFilter.Click += btnActiveFilter_Click;
        }

        int multiFilter = 0;
        private void btnActiveFilter_Click(object sender, EventArgs e)
        {
            if (multiFilter == 0)
            {
                multiFilter = 1;
                txtResponsibleId.ReadOnly = true;
                txtCustomerId.ReadOnly = true;
                txtUF.ReadOnly = true;
                gpbRegion.Enabled = false;
                btnActiveFilter.Text = btnActiveFilter.Text.Replace("Ativar", "Desativar");
                lblInfo.Visible = true;
                clbUnities.Enabled = true;
            }
            else if (multiFilter == 1)
            {
                multiFilter = 0;                
                txtResponsibleId.ReadOnly = !true;
                txtCustomerId.ReadOnly =!true;
                txtUF.ReadOnly = !true;
                gpbRegion.Enabled = !false;
                btnActiveFilter.Text = btnActiveFilter.Text.Replace("Desativar", "Ativar");
                lblInfo.Visible = !false;
                clbUnities.Enabled = !true;
            }

        }

        private async void btnData_Click(object sender, EventArgs e)
        {
            frmConsultaGenerica frmConsultaGenerica = new frmConsultaGenerica();
            /** Responsible filter **/
            string responsibleFilter = string.Empty;
            if (!string.IsNullOrEmpty(txtResponsibleDescription.Text))
                responsibleFilter = "idResponsible = " + txtResponsibleId.Text;
            else
                responsibleFilter = "1=1";

            /** Customer  Filter **/
            string customerFilter = string.Empty;
            if (!string.IsNullOrEmpty(txtCustomerDescription.Text))
                customerFilter = "idCustomer = " + txtCustomerId.Text;
            else
                customerFilter = "1=1";

            /** State filter **/
            string stateFilter = string.Empty;
            if (!string.IsNullOrEmpty(txtState.Text))
                stateFilter = "State.uf = '" + txtUF.Text + "'";
            else
                stateFilter = "1=1";

            /** Platform filter **/
            string platformFilter = string.Empty;
            if (cbxPlatform?.SelectedIndex != -1 && cbxPlatform?.SelectedIndex != 0)
                platformFilter = "idPlatform = " + platforms.Where(x => x.name == cbxPlatform.Items[cbxPlatform.SelectedIndex]?.ToString()).FirstOrDefault().id?.ToString();
            else
                platformFilter = "1=1";
            /** Region filter **/
            string regionFilter = string.Empty;
            if (chkNorth.Checked)
                regionFilter += "State.Region = 'NORTE'";
            if (chkNortheast.Checked)
                regionFilter += (string.IsNullOrEmpty(regionFilter) ? "" : " OR ") + "State.Region = 'NORDESTE'";
            if (chkMidwest.Checked)
                regionFilter += (string.IsNullOrEmpty(regionFilter) ? "" : " OR ") + "State.Region = 'CENTROOESTE'";
            if (chkSoutheast.Checked)
                regionFilter += (string.IsNullOrEmpty(regionFilter) ? "" : " OR ") + "State.Region = 'SUDESTE'";
            if (chkSouth.Checked)
                regionFilter += (string.IsNullOrEmpty(regionFilter) ? "" : " OR ") + "State.Region = 'SUL'";

            if (string.IsNullOrEmpty(regionFilter))
                regionFilter = "1=1";



            /** get info **/
            bool pe = false;
            bool ce = false;
            bool sp = false;
            if (multiFilter == 1)
            {
                foreach (var item in clbUnities.CheckedItems)
                {
                    if (item.Equals("UNI HOSPITALAR"))
                    {
                        pe = true;
                    }
                    if (item.Equals("UNI CEARÁ"))
                    {
                        ce = true;
                    }
                    if (item.Equals("SP HOSPITALAR"))
                    {
                        sp = true;
                    }
                }
                information = await Dashboard.getAllToDataTableVisualizerMultiFilterAsync(dtpInitial.Value, dtpFinal.Value
                , regionFilter, stateFilter, pe, ce, sp);
            }
            else
            {
                information = await Dashboard.getAllToDataTableVisualizerAsync(dtpInitial.Value, dtpFinal.Value
                    , regionFilter, responsibleFilter, customerFilter, stateFilter, platformFilter);
            }

            frmConsultaGenerica.consulta = information;            
            frmConsultaGenerica.Show();
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await getInformationAsync();
        }

        
        /** Menu Strip Configuration **/
        private void ConfigureMenuStripProperties()
        {
            CustomToolStripMenuItem menuArquivo = new CustomToolStripMenuItem("Arquivo");
            CustomToolStripMenuItem itemArquivoExportarGrafico = new CustomToolStripMenuItem("Exportar Gráfico");

            itemArquivoExportarGrafico.Click += stripMenuExportChart_Click;

            // Adicionando o item 'Empresa' e seu evento de clique

            menuArquivo.DropDownItems.Add(itemArquivoExportarGrafico);

            // Adiciona o menuConfiguracao ao menu principal
            menuStrip.Items.Add(menuArquivo);
            this.Controls.Add(menuStrip);

        }
        private void stripMenuExportChart_Click(object sender, EventArgs e)
        {

            // Criar uma instância de SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png";
            saveFileDialog.Title = "Salvar Gráfico como Imagem PNG";
            saveFileDialog.FileName = "grafico.png";

            // Mostrar o SaveFileDialog e verificar se o usuário clicou no botão 'Salvar'
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Sobrecarregar o string path com o caminho escolhido pelo usuário
                string path = saveFileDialog.FileName;

                // Verificar o tipo de controle e exportar o gráfico correspondente
                if (this.Controls[0] is LiveCharts.WinForms.CartesianChart)
                {
                    Exportacao.chartToPNG(lineChart, path);
                }
            }

        }
    }
}
