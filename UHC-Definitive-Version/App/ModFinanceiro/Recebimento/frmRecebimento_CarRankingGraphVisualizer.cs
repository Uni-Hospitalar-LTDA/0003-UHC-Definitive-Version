using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using DocumentFormat.OpenXml.Bibliography;
using static UHC3_Definitive_Version.App.ModFinanceiro.Recebimento.frmRecebimento_CarRanking;

namespace UHC3_Definitive_Version.App.ModFinanceiro.Recebimento
{
    public partial class frmRecebimento_CarRankingGraphVisualizer : CustomForm
    {
        public frmRecebimento_CarRankingGraphVisualizer()
        {
            InitializeComponent();

            ConfigureFormProperties();
            ConfigureGroupBoxProperties();

            ConfigureFormEvents();
        }

        public int chartType { get; set; } = 0; // 0 - Scatter | 1 - Pie
        LiveCharts.WinForms.CartesianChart cartesianChart1 { get; set; } = new LiveCharts.WinForms.CartesianChart();
        LiveCharts.WinForms.PieChart pieChart1 { get; set; } = new LiveCharts.WinForms.PieChart();

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();  
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmRecebimento_CarRankingGraphVisualizer_Load;

        }
        private void frmRecebimento_CarRankingGraphVisualizer_Load(object sender, EventArgs e)
        {
            ConfigureStripMenuEvents();
        }

        /** Configure GroupBox **/
        private void ConfigureGroupBoxProperties()
        {

        }
        internal void GerarGrafico(List<Report> reports)
        {
            // Agrupar pelo customerId e ordenar de forma decrescente
            var dadosAgrupados = reports
                .GroupBy(r => new { r.customerId, r.customer })
                .Select(g => new
                {
                    CustomerId = g.Key.customerId,
                    Customer = g.Key.customer,
                    TotalValue = g.Sum(r => Convert.ToDouble(r.billsToReceiveValue))
                })
                .OrderByDescending(g => g.TotalValue)
                .Take(30)
                .ToList();

            // Configurar as séries do gráfico
            var seriesCollection = new SeriesCollection();
            foreach (var dado in dadosAgrupados)
            {
                seriesCollection.Add(new RowSeries
                {
                    Title = $"[{dado.CustomerId}] - {dado.Customer}",
                    Values = new ChartValues<double> { dado.TotalValue },
                    DataLabels = true,
                    LabelPoint = point => point.X.ToString("C2")
                });
            }

            // Configurar o gráfico
            cartesianChart1.Series = seriesCollection;

            // Configurar o eixo Y
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Top 10",
                Labels = dadosAgrupados.Select(d => $"[{d.CustomerId}]").ToArray(),
                Position = AxisPosition.RightTop // Mover os labels para a parte inferior
            });

            // Configurar o eixo X
            cartesianChart1.AxisX.Add(new Axis
            {
                LabelFormatter = value => value.ToString("C2")
            });

            cartesianChart1.Invalidate();
            groupBox1.Controls.Add(cartesianChart1);
            cartesianChart1.Dock = DockStyle.Fill;
        }
        internal void GerarGraficoPizza(List<Report> reports)
        {
            // Agrupar pelo customerId, ordenar de forma decrescente e pegar os 5 primeiros
            var top5 = reports
                .GroupBy(r => new { r.customerId, r.customer })
                .Select(g => new
                {
                    CustomerId = g.Key.customerId,
                    Customer = g.Key.customer,
                    TotalValue = g.Sum(r => Convert.ToDouble(r.billsToReceiveValue))
                })
                .OrderByDescending(g => g.TotalValue)
                .Take(5)
                .ToList();

            // Calcular a soma dos valores dos registros restantes
            var outrosValue = reports
                .Where(r => !top5.Any(t => t.CustomerId == r.customerId))
                .Sum(r => Convert.ToDouble(r.billsToReceiveValue));

            // Configurar as séries do gráfico de pizza
            var pieSeriesCollection = new SeriesCollection();
            foreach (var dado in top5)
            {
                pieSeriesCollection.Add(new PieSeries
                {
                    Title = $"[{dado.CustomerId}] - {dado.Customer}",
                    Values = new ChartValues<double> { dado.TotalValue },
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("C2")
                });
            }
            foreach (var dado in top5)
            {
                var pieSeries = new PieSeries
                {
                    Title = $"[{dado.CustomerId}] - {dado.Customer}",
                    Values = new ChartValues<double> { dado.TotalValue },
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("C2")
                };

                pieSeriesCollection.Add(pieSeries);
            }

            // Adicionar a fatia "Outros" se houver valor
            if (outrosValue > 0)
            {
                pieSeriesCollection.Add(new PieSeries
                {
                    Title = "Outros",
                    Values = new ChartValues<double> { outrosValue },
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("C2")
                });
            }

            // Configurar o gráfico de pizza
            pieChart1.Series = pieSeriesCollection;
            pieChart1.LegendLocation = LegendLocation.Right; // Posicionar a legenda à direita
            pieChart1.Invalidate();

            groupBox1.Controls.Add(pieChart1);
            pieChart1.Dock = DockStyle.Fill;
        }


        /** Configure Button **/
        private void ConfigureStripMenuEvents()
        {
            //stripMenuExportChart.Click += stripMenuExportChart_Click;
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
                if (groupBox1.Controls[0] is LiveCharts.WinForms.CartesianChart)
                {
                    Exportacao.chartToPNG(cartesianChart1, path);
                }
                else
                {
                    Exportacao.chartToPNG(pieChart1, path);
                }
            }

        }
    }
}
