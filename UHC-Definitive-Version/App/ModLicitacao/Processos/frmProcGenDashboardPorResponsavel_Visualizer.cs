using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

using System.Windows.Forms;

namespace UHC3_Definitive_Version.App.ModLicitacao.Processos.RelatoriosGerenciais
{
    public partial class frmProcGenDashboardPorResponsavel_Visualizer : CustomForm
    {
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal int graphType { get; set; }
        internal System.Data.DataTable dt { get; set; } = new System.Data.DataTable();

        LiveCharts.WinForms.CartesianChart cartesianChart = new LiveCharts.WinForms.CartesianChart();
        LiveCharts.WinForms.PieChart pieChart = new LiveCharts.WinForms.PieChart();


        /** Sync Method **/
        private void getGraph(int graphType)
        {
            if (graphType == 0)
                GeneratePieChartprocessXresponsible(dt);
            else if (graphType == 1)
                GenerateBarChartperformanceXresponsible(dt);
            else if (graphType == 2)
                GeneratePieChartplatformXprocess(dt); 
            else if (graphType == 3)
                GeneratePieChartstateXprocess(dt);
            else if (graphType == 4)
                GenerateBarChartperformanceXstate(dt);
            else if (graphType == 5)
                GeneratePieChartyesXno(dt);
            else if (graphType == 6)            
                GeneratePieChartcustomerXprocess(dt);         
        }

        public frmProcGenDashboardPorResponsavel_Visualizer()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureFormEvents();
            ConfigureMenuStripProperties();

            btnFechar.toDefaultCloseButton();
            
        }



        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
            this.WindowState = FormWindowState.Normal;
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmProcGenDashboardPorResponsavel_Visualizer_Load;
        }
        private void frmProcGenDashboardPorResponsavel_Visualizer_Load(object sender, EventArgs e)
        {
            getGraph(graphType);
        }

        /** Generating Graphs **/
        //0
        public void GeneratePieChartprocessXresponsible(System.Data.DataTable table)
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

            pieChart.BackColorTransparent = true;

            
            // Define a localização da legenda
            pieChart.LegendLocation = LegendLocation.Right;
            

            pieChart.BackColor = Color.White;
            pieChart.Dock = DockStyle.Fill;
            groupBox1.Controls.Add(pieChart);
        }
        //1
        public void GenerateBarChartperformanceXresponsible(System.Data.DataTable table)
        {
            cartesianChart = new LiveCharts.WinForms.CartesianChart();

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

            cartesianChart.Series = seriesCollection;

            cartesianChart.AxisX.Add(new Axis
            {
                Labels = labels,
                Title = "Responsável"
            });

            cartesianChart.AxisY.Add(new Axis
            {
                Title = "Valores"
            });

            // Define a cor de fundo do gráfico para branco
            cartesianChart.BackColorTransparent = true;

            // Se barChartProcXResp não estiver no formulário, adicione-o agora
            cartesianChart.LegendLocation = LegendLocation.Top;
            cartesianChart.BackColor = Color.White; 
            cartesianChart.Dock = DockStyle.Fill;
            groupBox1.Controls.Add(cartesianChart);
            
        }
        //2
        public void GeneratePieChartplatformXprocess(System.Data.DataTable table)
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

            pieChart.BackColorTransparent = true;
            pieChart.LegendLocation = LegendLocation.Right;

            pieChart.BackColor = Color.White;
            pieChart.Dock = DockStyle.Fill;
            groupBox1.Controls.Add(pieChart);

        }
        //3
        public void GeneratePieChartstateXprocess(System.Data.DataTable table)
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

            pieChart.BackColorTransparent = true;
            pieChart.LegendLocation = LegendLocation.Right;

            pieChart.BackColor = Color.White;
            pieChart.Dock = DockStyle.Fill;
            groupBox1.Controls.Add(pieChart);

        }
        //4
        public void GenerateBarChartperformanceXstate(System.Data.DataTable table)
        {
            cartesianChart = new LiveCharts.WinForms.CartesianChart();

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

            cartesianChart.Series = seriesCollection;

            cartesianChart.AxisX.Add(new Axis
            {
                Labels = labels,
                Title = "UF"
            });

            cartesianChart.AxisY.Add(new Axis
            {
                Title = "Valores"
            });

            // Define a cor de fundo do gráfico para branco
            cartesianChart.BackColorTransparent = true;

            // Se barChartProcXResp não estiver no formulário, adicione-o agora
            cartesianChart.LegendLocation = LegendLocation.Top;
            cartesianChart.BackColor = Color.White;
            cartesianChart.Dock = DockStyle.Fill;
            groupBox1.Controls.Add(cartesianChart);
        }
        //5
        public void GeneratePieChartyesXno(System.Data.DataTable table)
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

            pieChart.BackColorTransparent = true;
            pieChart.LegendLocation = LegendLocation.Right;

            pieChart.BackColor = Color.White;
            pieChart.Dock = DockStyle.Fill;
            groupBox1.Controls.Add(pieChart);

        }
        //6
        public void GeneratePieChartcustomerXprocess(System.Data.DataTable table)
        {
            pieChart = new LiveCharts.WinForms.PieChart();
            var seriesCollection = new SeriesCollection();

            // Ordenar o DataTable baseado na coluna de valores (coluna 1)
            DataView dv = table.DefaultView;
            dv.Sort = table.Columns[1].ColumnName + " DESC";
            System.Data.DataTable sortedTable = dv.ToTable();

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
            
            
            pieChart.BackColorTransparent = true;
            pieChart.Dock = DockStyle.Fill;
            

            // Adicione os controles ao GroupBox            
            groupBox1.Controls.Add(pieChart);            
            groupBox1.Invalidate();
            groupBox1.Refresh();
            pieChart.BackColor = Color.Transparent;

           
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
                    Exportacao.chartToPNG(cartesianChart, path);
                }
                else
                {
                    Exportacao.chartToPNG(pieChart, path);
                }
            }

        }
    }
}
