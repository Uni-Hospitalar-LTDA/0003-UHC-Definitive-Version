using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using System.Drawing;
using System.Collections.Generic;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.App.ModLicitacao.Processos.RelatoriosGerenciais
{
    public partial class frmProcGenDashboardPorResponsavel : CustomForm
    {
        /** Instance **/
        int graphHeight = 350;
        int graphWidth = 350;
        CustomMenuStrip menuStrip = new CustomMenuStrip();


        private class DashboardPorResponsavel : Querys<DashboardPorResponsavel>
        {
            public static async Task<DataTable> getProcessXResponsibleAsync(DateTime ini, DateTime fin, bool pe, bool ce, bool sp)
            {
                string date1 = ini.ToString("yyyyMMdd");
                string date2 = fin.ToString("yyyyMMdd");

                List<string> queries = new List<string>();

                if (pe)
                {
                    queries.Add($@"SELECT 
                        Responsible.name COLLATE SQL_Latin1_General_CP1_CI_AS [Responsável]
                        ,COUNT (*) [Processos]
                        FROM [UHCDB].dbo.[Process_Scheduler] process
                        JOIN [UHCDB].dbo.[Users] Responsible ON Responsible.id = process.IdResponsible
                        WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                        GROUP BY 
                        Responsible.name");
                }

                if (ce)
                {
                    queries.Add($@"SELECT 
                        Responsible.name COLLATE SQL_Latin1_General_CP1_CI_AS [Responsável]
                        ,COUNT (*) [Processos]
                        FROM UNI_CEARA.[UHCDB].dbo.[Process_Scheduler] process
                        JOIN UNI_CEARA.[UHCDB].dbo.[Users] Responsible ON Responsible.id = process.IdResponsible
                        WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                        GROUP BY 
                        Responsible.name");
                }

                if (sp)
                {
                    queries.Add($@"SELECT 
                        Responsible.name COLLATE SQL_Latin1_General_CP1_CI_AS [Responsável]
                        ,COUNT (*) [Processos]
                        FROM SP_HOSPITALAR.[UHCDB].dbo.[Process_Scheduler] process
                        JOIN SP_HOSPITALAR.[UHCDB].dbo.[Users] Responsible ON Responsible.id = process.IdResponsible
                        WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                        GROUP BY 
                        Responsible.name");
                }

                string combinedQuery = string.Join(" UNION ALL ", queries);

                // Consolidate the results using GROUP BY for same Responsável
                combinedQuery = $@"
    SELECT [Responsável], SUM([Processos]) AS [Processos]
    FROM (
        {combinedQuery}
    ) AS Subquery
    GROUP BY [Responsável]
";
                Console.WriteLine(combinedQuery);
                return await getAllToDataTable(combinedQuery);
            }
            public static async Task<DataTable> getPerformanceXResponsibleAsync(DateTime ini, DateTime fin, bool pe, bool ce, bool sp)
            {
                string date1 = ini.ToString("yyyyMMdd");
                string date2 = fin.ToString("yyyyMMdd");

                List<string> queries = new List<string>();

                if (pe)
                {
                    queries.Add($@"SELECT 
                        Responsible.name COLLATE SQL_Latin1_General_CP1_CI_AS [Responsável]
                        ,COUNT (*) [Processos]
                        ,SUM(PARTICIPATION) [Participação]
                        ,CONVERT(NUMERIC(10,2),ROUND(SUM(PARTICIPATION)/CONVERT(NUMERIC(6,2),COUNT (*)),2)) * 100 [%]
                        FROM [UHCDB].dbo.[Process_Scheduler] process
                        JOIN [UHCDB].dbo.[Users] Responsible ON Responsible.id = process.IdResponsible
                        WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                        GROUP BY 
                        Responsible.name");
                }

                if (ce)
                {
                    queries.Add($@"SELECT 
                        Responsible.name COLLATE SQL_Latin1_General_CP1_CI_AS [Responsável]
                        ,COUNT (*) [Processos]
                        ,SUM(PARTICIPATION) [Participação]
                        ,CONVERT(NUMERIC(10,2),ROUND(SUM(PARTICIPATION)/CONVERT(NUMERIC(6,2),COUNT (*)),2)) * 100 [%]
                        FROM UNI_CEARA.[UHCDB].dbo.[Process_Scheduler] process
                        JOIN UNI_CEARA.[UHCDB].dbo.[Users] Responsible ON Responsible.id = process.IdResponsible
                        WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                        GROUP BY 
                        Responsible.name");
                }

                if (sp)
                {
                    queries.Add($@"SELECT 
                        Responsible.name COLLATE SQL_Latin1_General_CP1_CI_AS [Responsável]
                        ,COUNT (*) [Processos]
                        ,SUM(PARTICIPATION) [Participação]
                        ,CONVERT(NUMERIC(10,2),ROUND(SUM(PARTICIPATION)/CONVERT(NUMERIC(6,2),COUNT (*)),2)) * 100 [%]
                        FROM SP_HOSPITALAR.[UHCDB].dbo.[Process_Scheduler] process
                        JOIN SP_HOSPITALAR.[UHCDB].dbo.[Users] Responsible ON Responsible.id = process.IdResponsible
                        WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                        GROUP BY 
                        Responsible.name");
                }

                string combinedQuery = string.Join(" UNION ALL ", queries);

                // Consolidate the results using GROUP BY for same Responsável
                combinedQuery = $@"
    SELECT 
        [Responsável], 
        SUM([Processos]) AS [Processos], 
        SUM([Participação]) AS [Participação],
        SUM([%]) AS [%]
    FROM (
        {combinedQuery}
    ) AS Subquery
    GROUP BY [Responsável]
";

                Console.WriteLine(combinedQuery);
                return await getAllToDataTable(combinedQuery);
            }
            public static async Task<DataTable> getPlatformXProcess(DateTime ini, DateTime fin, bool pe, bool ce, bool sp)
            {
                string date1 = ini.ToString("yyyyMMdd");
                string date2 = fin.ToString("yyyyMMdd");

                List<string> queries = new List<string>();

                if (pe)
                {
                    queries.Add($@"SELECT 
                        Platform.name COLLATE SQL_Latin1_General_CP1_CI_AS [Plataforma]
                        ,COUNT (*) [Processos]
                        FROM [UHCDB].dbo.[Process_Scheduler] process
                        JOIN [UHCDB].dbo.[Platform] ON Platform.id = process.IdPlatform
                        WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                        GROUP BY 
                        Platform.name");
                }

                if (ce)
                {
                    queries.Add($@"SELECT 
                        Platform.name COLLATE SQL_Latin1_General_CP1_CI_AS [Plataforma]
                        ,COUNT (*) [Processos]
                        FROM UNI_CEARA.[UHCDB].dbo.[Process_Scheduler] process
                        JOIN UNI_CEARA.[UHCDB].dbo.[Platform] ON Platform.id = process.IdPlatform
                        WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                        GROUP BY 
                        Platform.name");
                }

                if (sp)
                {
                    queries.Add($@"SELECT 
                        Platform.name COLLATE SQL_Latin1_General_CP1_CI_AS [Plataforma]
                        ,COUNT (*) [Processos]
                        FROM SP_HOSPITALAR.[UHCDB].dbo.[Process_Scheduler] process
                        JOIN SP_HOSPITALAR.[UHCDB].dbo.[Platform] ON Platform.id = process.IdPlatform
                        WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                        GROUP BY 
                        Platform.name");
                }

                string combinedQuery = string.Join(" UNION ALL ", queries);

                // Consolidate the results using GROUP BY for same Plataforma
                combinedQuery = $@"
    SELECT 
        [Plataforma], 
        SUM([Processos]) AS [Processos]
    FROM (
        {combinedQuery}
    ) AS Subquery
    GROUP BY [Plataforma]
";

                return await getAllToDataTable(combinedQuery);
            }
            public static async Task<DataTable> getStateXProcess(DateTime ini, DateTime fin, bool pe, bool ce, bool sp)
            {
                string date1 = ini.ToString("yyyyMMdd");
                string date2 = fin.ToString("yyyyMMdd");

                List<string> queries = new List<string>();

                if (pe)
                {
                    queries.Add($@"SELECT 
                        Cliente.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS [UF]
                        ,COUNT (*) [Processos]
                        FROM [UHCDB].dbo.[Process_Scheduler] process
                        JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = process.idCustomer
                        WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                        GROUP BY 
                        Cliente.Cod_Estado");
                }

                if (ce)
                {
                    queries.Add($@"SELECT 
                        Cliente.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS [UF]
                        ,COUNT (*) [Processos]
                        FROM UNI_CEARA.[UHCDB].dbo.[Process_Scheduler] process
                        JOIN UNI_CEARA.[DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = process.idCustomer
                        WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                        GROUP BY 
                        Cliente.Cod_Estado");
                }

                if (sp)
                {
                    queries.Add($@"SELECT 
                        Cliente.Cod_Estado COLLATE SQL_Latin1_General_CP1_CI_AS [UF]
                        ,COUNT (*) [Processos]
                        FROM SP_HOSPITALAR.[UHCDB].dbo.[Process_Scheduler] process
                        JOIN SP_HOSPITALAR.[DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = process.idCustomer
                        WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                        GROUP BY 
                        Cliente.Cod_Estado");
                }

                string combinedQuery = string.Join(" UNION ALL ", queries);

                // Consolidate the results using GROUP BY for same UF
                combinedQuery = $@"
    SELECT 
        [UF], 
        SUM([Processos]) AS [Processos]
    FROM (
        {combinedQuery}
    ) AS Subquery
    GROUP BY [UF]
";

                return await getAllToDataTable(combinedQuery);
            }
            public static async Task<DataTable> getPerformanceXStateAsync(DateTime ini, DateTime fin, bool pe, bool ce, bool sp)
            {
                string date1 = ini.ToString("yyyyMMdd");
                string date2 = fin.ToString("yyyyMMdd");
                List<string> queries = new List<string>();

                if (pe)
                {
                    queries.Add($@"
            SELECT 
                'PE' AS [UF]
                ,COUNT (*) [Processos]
                ,SUM(PARTICIPATION) [Participação]
                ,CONVERT(NUMERIC(10,2),ROUND(SUM(PARTICIPATION)/CONVERT(NUMERIC(6,2),COUNT (*)),2)) * 100 [%]
            FROM [UHCDB].dbo.[Process_Scheduler] process
            JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = process.idCustomer
            WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
        ");
                }
                if (ce)
                {
                    queries.Add($@"
            SELECT 
                'CE' AS [UF]
                ,COUNT (*) [Processos]
                ,SUM(PARTICIPATION) [Participação]
                ,CONVERT(NUMERIC(10,2),ROUND(SUM(PARTICIPATION)/CONVERT(NUMERIC(6,2),COUNT (*)),2)) * 100 [%]
            FROM UNI_CEARA.[UHCDB].dbo.[Process_Scheduler] process
            JOIN UNI_CEARA.[DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = process.idCustomer
            WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
        ");
                }
                if (sp)
                {
                    queries.Add($@"
            SELECT 
                'SP' AS [UF]
                ,COUNT (*) [Processos]
                ,SUM(PARTICIPATION) [Participação]
                ,CONVERT(NUMERIC(10,2),ROUND(SUM(PARTICIPATION)/CONVERT(NUMERIC(6,2),COUNT (*)),2)) * 100 [%]
            FROM SP_HOSPITALAR.[UHCDB].dbo.[Process_Scheduler] process
            JOIN SP_HOSPITALAR.[DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = process.idCustomer
            WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
        ");
                }

                string combinedQuery = string.Join(" UNION ALL ", queries);

                // Consolidate the results using GROUP BY
                combinedQuery = $@"
        SELECT [UF], SUM(Processos) AS [Processos], SUM([Participação]) AS [Participação], AVG([%]) AS [%]
        FROM (
            {combinedQuery}
        ) AS Subquery
        GROUP BY [UF]
    ";

                Console.WriteLine(combinedQuery);
                return await getAllToDataTable(combinedQuery);
            }
            public static async Task<DataTable> getYesXnoAsync(DateTime ini, DateTime fin, bool pe, bool ce, bool sp)
            {
                string date1 = ini.ToString("yyyyMMdd");
                string date2 = fin.ToString("yyyyMMdd");

                List<string> queries = new List<string>();

                if (pe)
                {
                    queries.Add($@"
            SELECT 
                'Sim' AS [Participação], 
                SUM(CASE WHEN Participation = 1 THEN 1 ELSE 0 END) AS Processos
            FROM [UHCDB].dbo.[Process_Scheduler]
            WHERE Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
            UNION ALL
            SELECT 
                'Não',
                SUM(CASE WHEN Participation = 0 THEN 1 ELSE 0 END)
            FROM [UHCDB].dbo.[Process_Scheduler]    
            WHERE Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
        ");
                }
                if (ce)
                {
                    queries.Add($@"
            SELECT 
                'Sim' AS [Participação],
                SUM(CASE WHEN Participation = 1 THEN 1 ELSE 0 END) AS Processos
            FROM UNI_CEARA.[UHCDB].dbo.[Process_Scheduler]
            WHERE Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
            UNION ALL
            SELECT 
                'Não',
                SUM(CASE WHEN Participation = 0 THEN 1 ELSE 0 END)
            FROM UNI_CEARA.[UHCDB].dbo.[Process_Scheduler]	
            WHERE Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
        ");
                }
                if (sp)
                {
                    queries.Add($@"
            SELECT 
                'Sim' AS [Participação],
                SUM(CASE WHEN Participation = 1 THEN 1 ELSE 0 END) AS Processos
            FROM SP_HOSPITALAR.[UHCDB].dbo.[Process_Scheduler]
            WHERE Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
            UNION ALL
            SELECT 
                'Não',
                SUM(CASE WHEN Participation = 0 THEN 1 ELSE 0 END)
            FROM SP_HOSPITALAR.[UHCDB].dbo.[Process_Scheduler]
            WHERE Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
        ");
                }

                string combinedQuery = string.Join(" UNION ALL ", queries);

                // Consolidate the results using GROUP BY
                combinedQuery = $@"
        SELECT [Participação], SUM(Processos) AS TotalParticipacao
        FROM (
            {combinedQuery}
        ) AS Subquery
        GROUP BY [Participação]
    ";

                return await getAllToDataTableMultiFilter(combinedQuery);
            }
            public static async Task<DataTable> getProcessXCustomerAsync(DateTime ini, DateTime fin, bool pe, bool ce, bool sp)
            {
                string date1 = ini.ToString("yyyyMMdd");
                string date2 = fin.ToString("yyyyMMdd");
                string query = $@"SELECT 
                                   Cliente.Razao_Social [Órgão]
                                    ,COUNT (*) [Processos]
                                    FROM [UHCDB].dbo.[Process_Scheduler] process
                                    JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = process.idCustomer
                                    WHERE process.Dat_Scheduler BETWEEN '{date1}' AND '{date2}'
                                    GROUP BY 
                                    Cliente.Razao_Social 
                                    order by Processos desc";

                string unidade = string.Empty;

                if (pe)
                    unidade = "UNI HOSPITALAR";
                else if (ce)
                    unidade = "UNI CEARÁ";
                else if (sp)
                    unidade = "SP HOSPITALAR";

                
                return await getAllToDataTableMultiFilter(query, unidade);
            }
        }
        
        


        public frmProcGenDashboardPorResponsavel()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureDataGridViewProperties();
            ConfigureComboBoxProperties();
            ConfigureButtonProperties();
            ConfigureMenuStripProperties();
            flowLayoutPanel1.AutoScroll = true;


            ConfigureFormEvents();
        }

        /** Async Tasks **/
        DataTable processXresponsible = new DataTable();
        DataTable performanceXresponsible = new DataTable();
        DataTable platformXprocess = new DataTable();
        DataTable stateXprocess = new DataTable();
        DataTable performanceXstate = new DataTable();
        DataTable yesXno = new DataTable();
        DataTable customerXprocess = new DataTable();
        private async Task getInformation()
        {
            bool pe = false;
            bool ce = false;
            bool sp = false;
            int cc = 0; //Controla o filtro multiempresas
            foreach (var item in clbUnities.CheckedItems)
            {
                if (item.Equals("UNI HOSPITALAR"))
                {
                    pe = true;
                    cc++;
                }
                if (item.Equals("UNI CEARÁ"))
                {
                    ce = true;
                    cc++;
                }
                if (item.Equals("SP HOSPITALAR"))
                {
                    sp = true;
                    cc++;
                }
            }
            try
            {
                processXresponsible = await DashboardPorResponsavel.getProcessXResponsibleAsync(dtpInitial.Value, dtpFinal.Value,pe, ce, sp);
                performanceXresponsible = await DashboardPorResponsavel.getPerformanceXResponsibleAsync
                    (dtpInitial.Value, dtpFinal.Value,pe,ce,sp);
                platformXprocess = await DashboardPorResponsavel.getPlatformXProcess(dtpInitial.Value, dtpFinal.Value, pe, ce, sp);
                stateXprocess = await DashboardPorResponsavel.getStateXProcess(dtpInitial.Value, dtpFinal.Value, pe, ce, sp );
                performanceXstate = await DashboardPorResponsavel.getPerformanceXStateAsync(dtpInitial.Value, dtpFinal.Value, pe, ce, sp);
                yesXno = await DashboardPorResponsavel.getYesXnoAsync(dtpInitial.Value, dtpFinal.Value, pe, ce, sp);

                if (cc <= 1)
                    customerXprocess = await DashboardPorResponsavel.getProcessXCustomerAsync(dtpInitial.Value, dtpFinal.Value, pe, ce, sp);
                else
                    customerXprocess = null;

                

                flowLayoutPanel1.Controls.Clear();
                /**Graph instance generation **/

                try
                {
                    GeneratePieChartprocessXresponsible(processXresponsible);
                    GenerateBarChartperformanceXresponsible(performanceXresponsible);
                    GeneratePieChartplatformXprocess(platformXprocess);
                    GeneratePieChartstateXprocess(stateXprocess);
                    GenerateBarChartperformanceXstate(performanceXstate);
                    GeneratePieChartyesXno(yesXno);
                    if (cc <= 1)
                        GeneratePieChartcustomerXprocess(customerXprocess);
                }
                catch
                {

                }

            }
            catch (Exception ex) 
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                cbxInfo_SelectedIndexChanged(this, new EventArgs());
            }
           
            
            
        }

        /** Gerar Gráficos **/
        LiveCharts.WinForms.PieChart pieChart;
        LiveCharts.WinForms.CartesianChart barChart;
        public void GeneratePieChartprocessXresponsible(DataTable table)
        {
            pieChart = new LiveCharts.WinForms.PieChart();
            var seriesCollection = new SeriesCollection();

            foreach (DataRow row in table.Rows)
            {
                var pieSeries = new PieSeries
                {
                    Values = new ChartValues<double> { Convert.ToDouble(row[1]) },
                    Title = row[0].ToString(),
                    DataLabels = true,
                    LabelPoint = point => point.Y + " Processos"
                };
                seriesCollection.Add(pieSeries);
            }
            pieChart.Series = seriesCollection;

            GroupBox gp1 = new GroupBox();

            // Defina a posição e tamanho do Label
            Label lbl = new Label();
            lbl.Text = "Processos x Responsáveis";
            lbl.Font = new Font(gp1.Font.FontFamily, 10, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.TopCenter;
            lbl.AutoSize = true;

            // Defina a posição e tamanho do pieChart
            if (!flowLayoutPanel1.Controls.Contains(pieChart))
            {
                pieChart.BackColorTransparent = true;                
                pieChart.Dock  = DockStyle.Fill;
            }

            // Adicione os controles ao GroupBox
            gp1.Controls.Add(lbl);
            gp1.Controls.Add(pieChart);

            gp1.Height = graphHeight;
            gp1.Width = graphWidth;

            flowLayoutPanel1.Controls.Add(gp1);
            gp1.Invalidate();
            gp1.Refresh();

            pieChart.BackColor = System.Drawing.Color.Transparent;
            pieChart.DataClick += (sender, chartPoint) =>
            {
                //MessageBox.Show($"Você clicou em {chartPoint.SeriesView.Title} com valor {chartPoint.Y}.");
                frmProcGenDashboardPorResponsavel_Visualizer frm = new frmProcGenDashboardPorResponsavel_Visualizer();
                frm.graphType = 0;
                frm.dt = table;
                frm.Show();
            };
        }        
        public void GenerateBarChartperformanceXresponsible(DataTable table)
        {
            barChart = new LiveCharts.WinForms.CartesianChart();
            
            var seriesCollection = new SeriesCollection();

            var participationValues = new ChartValues<double>();
            var processValues = new ChartValues<double>();
            var labels = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                participationValues.Add(Convert.ToDouble(row["Participação"]));
                processValues.Add(Convert.ToDouble(row["Processos"]));
                labels.Add(row["Responsável"].ToString());
            }

            var participationSeries = new ColumnSeries
            {
                Title = "Participação",
                Values = participationValues,
                DataLabels = true,
                LabelPoint = point => point.Y.ToString()
            };

            var processSeries = new ColumnSeries
            {
                Title = "Processos",
                Values = processValues,
                DataLabels = true,
                LabelPoint = point => point.Y.ToString()
            };

            
            seriesCollection.Add(processSeries);
            seriesCollection.Add(participationSeries);

            barChart.Series = seriesCollection;

            barChart.AxisX.Add(new Axis
            {
                Labels = labels,
                Title = "Responsável"
            });

            barChart.AxisY.Add(new Axis
            {
                Title = "Valores"
            });

           
            GroupBox gp1 = new GroupBox();

            // Defina a posição e tamanho do Label
            Label lbl = new Label();
            lbl.Text = "Performance x Responsáveis";
            lbl.Font = new Font(gp1.Font.FontFamily, 10, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.TopCenter;
            lbl.AutoSize = true;

            if (!flowLayoutPanel1.Controls.Contains(barChart))
            {                
                barChart.BackColorTransparent = true;
                barChart.Dock = DockStyle.Fill;
            }

            // Adicione os controles ao GroupBox
            gp1.Controls.Add(lbl);
            gp1.Controls.Add(barChart);

            gp1.Height = graphHeight;
            gp1.Width = graphWidth;

            flowLayoutPanel1.Controls.Add(gp1);
            gp1.Invalidate();
            gp1.Refresh();

            barChart.BackColor = System.Drawing.Color.Transparent;
            barChart.DataClick += (sender, chartPoint) =>
            {
                //MessageBox.Show($"Você clicou em {chartPoint.SeriesView.Title} com valor {chartPoint.Y}.");
                frmProcGenDashboardPorResponsavel_Visualizer frm = new frmProcGenDashboardPorResponsavel_Visualizer();
                frm.graphType = 1;
                frm.dt = table;
                frm.Show();
            };
        }
        public void GeneratePieChartplatformXprocess(DataTable table)
        {
            pieChart = new LiveCharts.WinForms.PieChart();
            var seriesCollection = new SeriesCollection();

            foreach (DataRow row in table.Rows)
            {
                var pieSeries = new PieSeries
                {
                    Values = new ChartValues<double> { Convert.ToDouble(row[1]) },
                    Title = row[0].ToString(),
                    DataLabels = true,
                    LabelPoint = point => point.Y + " Processos"
                };
                seriesCollection.Add(pieSeries);
            }
            pieChart.Series = seriesCollection;


            // Define a cor de fundo do gráfico para branco
            pieChart.DefaultLegend.Visibility = System.Windows.Visibility.Hidden;
            pieChart.BackColorTransparent = true;

            GroupBox gp1 = new GroupBox();

            // Defina a posição e tamanho do Label
            Label lbl = new Label();
            lbl.Text = "Processos x Plataformas";
            lbl.Font = new Font(gp1.Font.FontFamily, 10, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.TopCenter;
            lbl.AutoSize = true;

            // Defina a posição e tamanho do pieChart
            if (!flowLayoutPanel1.Controls.Contains(pieChart))
            {
                pieChart.BackColorTransparent = true;
                pieChart.Dock = DockStyle.Fill;
            }

            // Adicione os controles ao GroupBox
            gp1.Controls.Add(lbl);
            gp1.Controls.Add(pieChart);

            gp1.Height = graphHeight;
            gp1.Width = graphWidth;

            flowLayoutPanel1.Controls.Add(gp1);
            gp1.Invalidate();
            gp1.Refresh();

            pieChart.BackColor = System.Drawing.Color.Transparent;

            pieChart.DataClick += (sender, chartPoint) =>
            {
                //MessageBox.Show($"Você clicou em {chartPoint.SeriesView.Title} com valor {chartPoint.Y}.");
                frmProcGenDashboardPorResponsavel_Visualizer frm = new frmProcGenDashboardPorResponsavel_Visualizer();
                frm.graphType = 2;
                frm.dt = table;
                frm.Show();
            };
        }
        public void GeneratePieChartstateXprocess(DataTable table)
        {
            pieChart = new LiveCharts.WinForms.PieChart();
            var seriesCollection = new SeriesCollection();

            foreach (DataRow row in table.Rows)
            {
                var pieSeries = new PieSeries
                {
                    Values = new ChartValues<double> { Convert.ToDouble(row[1]) },
                    Title = row[0].ToString(),
                    DataLabels = true,
                    LabelPoint = point => point.Y + " Processos"
                };
                seriesCollection.Add(pieSeries);
            }
            pieChart.Series = seriesCollection;


            // Define a cor de fundo do gráfico para branco
            pieChart.DefaultLegend.Visibility = System.Windows.Visibility.Hidden;
            pieChart.BackColorTransparent = true;
            GroupBox gp1 = new GroupBox();

            // Defina a posição e tamanho do Label
            Label lbl = new Label();
            lbl.Text = "Processos x UFs";
            lbl.Font = new Font(gp1.Font.FontFamily, 10, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.TopCenter;
            lbl.AutoSize = true;

            // Defina a posição e tamanho do pieChart
            if (!flowLayoutPanel1.Controls.Contains(pieChart))
            {
                pieChart.BackColorTransparent = true;
                pieChart.Dock = DockStyle.Fill;
            }

            // Adicione os controles ao GroupBox
            gp1.Controls.Add(lbl);
            gp1.Controls.Add(pieChart);

            gp1.Height = graphHeight;
            gp1.Width = graphWidth;

            flowLayoutPanel1.Controls.Add(gp1);
            gp1.Invalidate();
            gp1.Refresh();
            pieChart.BackColor = System.Drawing.Color.Transparent;

            pieChart.DataClick += (sender, chartPoint) =>
            {
                //MessageBox.Show($"Você clicou em {chartPoint.SeriesView.Title} com valor {chartPoint.Y}.");
                frmProcGenDashboardPorResponsavel_Visualizer frm = new frmProcGenDashboardPorResponsavel_Visualizer();
                frm.graphType = 3;
                frm.dt = table;
                frm.Show();
            };
        }
        public void GenerateBarChartperformanceXstate(DataTable table)
        {
            barChart = new LiveCharts.WinForms.CartesianChart();

            var seriesCollection = new SeriesCollection();

            var participationValues = new ChartValues<double>();
            var processValues = new ChartValues<double>();
            var labels = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                participationValues.Add(Convert.ToDouble(row["Participação"]));
                processValues.Add(Convert.ToDouble(row["Processos"]));
                labels.Add(row["UF"].ToString());
            }

            var participationSeries = new ColumnSeries
            {
                Title = "Participação",
                Values = participationValues,
                DataLabels = true,
                LabelPoint = point => point.Y.ToString()
            };

            var processSeries = new ColumnSeries
            {
                Title = "Processos",
                Values = processValues,
                DataLabels = true,
                LabelPoint = point => point.Y.ToString()
            };


            seriesCollection.Add(processSeries);
            seriesCollection.Add(participationSeries);

            barChart.Series = seriesCollection;

            barChart.AxisX.Add(new Axis
            {
                Labels = labels,
                Title = "UF"
            });

            barChart.AxisY.Add(new Axis
            {
                Title = "Valores"
            });

            GroupBox gp1 = new GroupBox();

            // Defina a posição e tamanho do Label
            Label lbl = new Label();
            lbl.Text = "Performance x UF";
            lbl.Font = new Font(gp1.Font.FontFamily, 10, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.TopCenter;
            lbl.AutoSize = true;

            if (!flowLayoutPanel1.Controls.Contains(barChart))
            {
                barChart.BackColorTransparent = true;
                barChart.Dock = DockStyle.Fill;
            }

            // Adicione os controles ao GroupBox
            gp1.Controls.Add(lbl);
            gp1.Controls.Add(barChart);

            gp1.Height = graphHeight;
            gp1.Width = graphWidth;

            flowLayoutPanel1.Controls.Add(gp1);
            gp1.Invalidate();
            gp1.Refresh();
            barChart.BackColor = System.Drawing.Color.Transparent;
            barChart.DataClick += (sender, chartPoint) =>
            {
                //MessageBox.Show($"Você clicou em {chartPoint.SeriesView.Title} com valor {chartPoint.Y}.");
                frmProcGenDashboardPorResponsavel_Visualizer frm = new frmProcGenDashboardPorResponsavel_Visualizer();
                frm.graphType = 4;
                frm.dt = table;
                frm.Show();
            };
        }
        public void GeneratePieChartyesXno(DataTable table)
        {
            pieChart = new LiveCharts.WinForms.PieChart();
            var seriesCollection = new SeriesCollection();

            foreach (DataRow row in table.Rows)
            {
                var pieSeries = new PieSeries
                {
                    Values = new ChartValues<double> { Convert.ToDouble(row[1]) },
                    Title = row[0].ToString(),
                    DataLabels = true,
                    LabelPoint = point => point.Y + " Processos"
                };
                seriesCollection.Add(pieSeries);
            }
            pieChart.Series = seriesCollection;


            // Define a cor de fundo do gráfico para branco
            pieChart.DefaultLegend.Visibility = System.Windows.Visibility.Hidden;
            pieChart.BackColorTransparent = true;

            GroupBox gp1 = new GroupBox();

            // Defina a posição e tamanho do Label
            Label lbl = new Label();
            lbl.Text = "Índice de Participação";
            lbl.Font = new Font(gp1.Font.FontFamily, 10, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.TopCenter;
            lbl.AutoSize = true;

            // Defina a posição e tamanho do pieChart
            if (!flowLayoutPanel1.Controls.Contains(pieChart))
            {
                pieChart.BackColorTransparent = true;
                pieChart.Dock = DockStyle.Fill;
            }

            // Adicione os controles ao GroupBox
            gp1.Controls.Add(lbl);
            gp1.Controls.Add(pieChart);

            gp1.Height = graphHeight;
            gp1.Width = graphWidth;

            flowLayoutPanel1.Controls.Add(gp1);
            gp1.Invalidate();
            gp1.Refresh();
            pieChart.BackColor = System.Drawing.Color.Transparent;

            pieChart.DataClick += (sender, chartPoint) =>
            {
                //MessageBox.Show($"Você clicou em {chartPoint.SeriesView.Title} com valor {chartPoint.Y}.");
                frmProcGenDashboardPorResponsavel_Visualizer frm = new frmProcGenDashboardPorResponsavel_Visualizer();
                frm.graphType = 5;
                frm.dt = table;
                frm.Show();
            };
        }
        public void GeneratePieChartcustomerXprocess(DataTable table)
        {            
            pieChart = new LiveCharts.WinForms.PieChart();
            var seriesCollection = new SeriesCollection();

            // Ordenar o DataTable baseado na coluna de valores (coluna 1)
            DataView dv = table.DefaultView;
            dv.Sort = table.Columns[1].ColumnName + " DESC";
            DataTable sortedTable = dv.ToTable();

            double otherSum = 0;
            int rowCount = 0;

            foreach (DataRow row in sortedTable.Rows)
            {
                rowCount++;

                if (rowCount <= 10)
                {
                    var pieSeries = new PieSeries
                    {
                        Values = new ChartValues<double> { Convert.ToDouble(row[1]) },
                        Title = row[0].ToString(),
                        DataLabels = true,
                        LabelPoint = point => point.Y + " Processos"
                    };
                    seriesCollection.Add(pieSeries);
                }
                else
                {
                    otherSum += Convert.ToDouble(row[1]);
                }
            }

            if (otherSum > 0)
            {
                var pieSeriesOther = new PieSeries
                {
                    Values = new ChartValues<double> { otherSum },
                    Title = "Outros",
                    DataLabels = true,
                    LabelPoint = point => point.Y + " Processos"
                };
                seriesCollection.Add(pieSeriesOther);
            }

            pieChart.Series = seriesCollection;

            // Define a cor de fundo do gráfico para branco
            pieChart.DefaultLegend.Visibility = System.Windows.Visibility.Hidden;
            pieChart.BackColorTransparent = true;
            GroupBox gp1 = new GroupBox();

            // Defina a posição e tamanho do Label
            Label lbl = new Label();
            lbl.Text = "Processos x Órgãos";
            lbl.Font = new Font(gp1.Font.FontFamily, 10, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.TopCenter;
            lbl.AutoSize = true;

            // Defina a posição e tamanho do pieChart
            if (!flowLayoutPanel1.Controls.Contains(pieChart))
            {
                pieChart.BackColorTransparent = true;
                pieChart.Dock = DockStyle.Fill;
            }

            // Adicione os controles ao GroupBox
            gp1.Controls.Add(lbl);
            gp1.Controls.Add(pieChart);

            gp1.Height = graphHeight;
            gp1.Width = graphWidth;

            flowLayoutPanel1.Controls.Add(gp1);
            gp1.Invalidate();
            gp1.Refresh();
            pieChart.BackColor = System.Drawing.Color.Transparent;

            pieChart.DataClick += (sender, chartPoint) =>
            {
                //MessageBox.Show($"Você clicou em {chartPoint.SeriesView.Title} com valor {chartPoint.Y}.");
                frmProcGenDashboardPorResponsavel_Visualizer frm = new frmProcGenDashboardPorResponsavel_Visualizer();
                frm.graphType = 6;
                frm.dt = table;
                frm.Show();
            };
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmProcessos_RelatoriosGerenciais_Load;
        }
        private async void frmProcessos_RelatoriosGerenciais_Load(object sender, EventArgs e)
        {
            ConfigureDateTimePickerAttributes();
            ConfigureCheckedListBoxAttributes();
            ConfigureComboBoxAttributes();

            try 
            {
                await getInformation();
            }
            catch (Exception)
            {
                CustomNotification.defaultAlert("Não há dados lançados para consulta!");
            }
            

            
            dgvData.DataSource = processXresponsible;
            dgvData.AutoResizeColumns();
            ConfigureComboBoxEvents();
            ConfigureButtonEvents();            

        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.MultiSelect = true;
        }

        /** Configure CheckedListBox **/
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

            //clbUnities.Enabled = false;
        }

        /** Configure DateTimePicker **/
        private void ConfigureDateTimePickerAttributes()
        {
            dtpInitial.Value = Convert.ToDateTime("01/01/"+DateTime.Now.Year.ToString());
            dtpFinal.Value = Convert.ToDateTime("31/12/" + DateTime.Now.Year.ToString());
        }

        /** Configure ComboBox **/
        private void ConfigureComboBoxProperties()
        {
            cbxInfo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void ConfigureComboBoxAttributes()
        {
            cbxInfo.Items.Add("Processos x Responsável");
            cbxInfo.SelectedIndex = 0;
            cbxInfo.Items.Add("Performance x Responsável");
            cbxInfo.Items.Add("Processos x Plataforma");
            cbxInfo.Items.Add("Processos x UF");
            cbxInfo.Items.Add("Performance x UF");
            cbxInfo.Items.Add("Processos x Participação");
            cbxInfo.Items.Add("Processos x Órgãos");
        }
        private void ConfigureComboBoxEvents()
        {
            cbxInfo.SelectedIndexChanged += cbxInfo_SelectedIndexChanged;
        }
        private void cbxInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvData.DataSource = new DataTable();
            if (cbxInfo.SelectedIndex == 0)
            {                
                dgvData.DataSource = processXresponsible;
            }
            else if (cbxInfo.SelectedIndex == 1)
            {
                dgvData.DataSource = performanceXresponsible;
            }
            else if (cbxInfo.SelectedIndex == 2)
            {
                dgvData.DataSource = platformXprocess;
            }
            else if (cbxInfo.SelectedIndex == 3)
            {
                dgvData.DataSource = stateXprocess;
            }
            else if (cbxInfo.SelectedIndex == 4)
            {
                dgvData.DataSource = performanceXstate;
            }
            else if (cbxInfo.SelectedIndex == 5)
            {
                dgvData.DataSource = yesXno;
            }
            else if (cbxInfo.SelectedIndex == 6)
            {
                dgvData.DataSource = customerXprocess;
            }
            dgvData.AutoResizeColumns();
        }

        /** Configure Buttons **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();   
        }        
        private void ConfigureButtonEvents()
        {
            btnFilter.Click += btnFilter_Click;
        }
        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await getInformation();
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
