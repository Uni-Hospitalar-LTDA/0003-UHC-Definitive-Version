using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Drawing;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.App.ModVendas.Consultas
{
    public partial class frmAnaliseDebitoCreditoAche : CustomForm
    {
        /** Instance **/


        private class Information : Querys<Information>
        {
            public static async Task<System.Data.DataTable> getAllQuantitiesToDataTableAsync()
            {
                string query = $@"WITH QuantidadesAgrupadas AS (
   SELECT 
		  Produto.Cod_EAN 	
		 ,Produto.Codigo
		 ,Produto.Descricao		 
		 ,NF_Saida.Num_Nota
		 ,Vlr_Unitario = (SELECT top 1 nfsit.Prc_Unitario FROM DMD.dbo.NFSIT WHERE Num_Nota = NF_Saida.Num_Nota and Cod_Produto = produto.codigo) 
		 ,Qtd_Uni = (SELECT sum(nfsit.Qtd_Produto) FROM DMD.dbo.NFSIT WHERE Num_Nota = NF_Saida.Num_Nota and Cod_Produto = produto.codigo)  
		 ,SUM(debit.Qtde_Faturamento) [Qtd_Ache]
FROM [UHCDB].dbo.[DebitosAche] debit
JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_Nota = debit.Numero_NF
JOIN [DMD].dbo.[PRODU] Produto ON Produto.Cod_EAN = debit.Cod_EAN COLLATE SQL_Latin1_General_CP1_CI_AS
GROUP BY 
		  Produto.Cod_EAN 	
		 ,Produto.Descricao		 
		 ,NF_Saida.Num_Nota
		 ,produto.codigo
)
SELECT
   Produto.Codigo [Cód. Produto]
  ,Produto.Descricao [Produto]
  ,NF_Saida.Num_nota [NF]
  ,CONVERT(DATE,NF_Saida.Dat_Emissao) [Emissão NF]
  ,groupa.Qtd_Uni [Qtd. Uni]
  ,groupa.Qtd_Ache [Qtd. Aché]
  ,Qtd_Ache - Qtd_Uni [Diferença]  
FROM QuantidadesAgrupadas groupa
JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_Nota  = groupa.Num_Nota
JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = groupa.Codigo
WHERE groupa.Qtd_Uni <> groupa.Qtd_Ache
order by NF_saida.Num_Nota desc

";




                return await getAllToDataTable(query);
            }

            public static async Task<System.Data.DataTable> getAllValuesToDataTableAsync()
            {
                string query = $@"WITH QuantidadesAgrupadas AS (
   SELECT 
		  Produto.Cod_EAN 	
		 ,Produto.Codigo
		 ,Produto.Descricao		 
		 ,NF_Saida.Num_Nota
		 ,Vlr_Unitario = (SELECT top 1 nfsit.Prc_Unitario FROM DMD.dbo.NFSIT WHERE Num_Nota = NF_Saida.Num_Nota and Cod_Produto = produto.codigo) 
		 ,Qtd_Uni = (SELECT sum(nfsit.Qtd_Produto) FROM DMD.dbo.NFSIT WHERE Num_Nota = NF_Saida.Num_Nota and Cod_Produto = produto.codigo)  
		 ,SUM(debit.Qtde_Faturamento) [Qtd_Ache]
FROM [UHCDB].dbo.[DebitosAche] debit
JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_Nota = debit.Numero_NF
JOIN [DMD].dbo.[PRODU] Produto ON Produto.Cod_EAN = debit.Cod_EAN COLLATE SQL_Latin1_General_CP1_CI_AS
GROUP BY 
		  Produto.Cod_EAN 	
		 ,Produto.Descricao		 
		 ,NF_Saida.Num_Nota
		 ,produto.codigo
)
SELECT
   Produto.Codigo [Cód. Produto]
  ,Produto.Descricao [Produto]
  ,NF_Saida.Num_nota [NF]
  ,CONVERT(DATE,NF_Saida.Dat_Emissao) [Emissão NF]
  ,CONVERT(NUMERIC(12,4),groupa.Qtd_Uni * groupa.Vlr_Unitario) [Vlr. Uni]
  ,CONVERT(NUMERIC(12,4),groupa.Qtd_Ache * groupa.Vlr_Unitario) [Vlr. Aché]
  ,CONVERT(NUMERIC(12,4),groupa.Qtd_Ache * groupa.Vlr_Unitario - groupa.Qtd_Uni * groupa.Vlr_Unitario) [Diferença]  
FROM QuantidadesAgrupadas groupa
JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_Nota  = groupa.Num_Nota
JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = groupa.Codigo
WHERE groupa.Qtd_Uni <> groupa.Qtd_Ache
order by NF_saida.Num_Nota desc
";




                return await getAllToDataTable(query);
            }

        }


        public frmAnaliseDebitoCreditoAche()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureComboBoxProperties();
            ConfigureButtonProperties();

            flowLayoutPanel1.AutoScroll = true;


            ConfigureFormEvents();

        }

        public void createDiferenceByQuantitieGraph(System.Data.DataTable dados)
        {            
            // Cria um novo componente de gráfico
            var grafico = new LiveCharts.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill
            };

            // Prepara as séries de dados
            SeriesCollection series = new SeriesCollection();

            // Agrupa os dados por mês
            var dadosAgrupados = dados.AsEnumerable()
                                      .GroupBy(row => new { Ano = Convert.ToDateTime(row["Emissão NF"]).Year, Mes = Convert.ToDateTime(row["Emissão NF"]).Month })
                                      .OrderBy(group => group.Key.Ano).ThenBy(group => group.Key.Mes);

            foreach (var grupo in dadosAgrupados)
            {
                // Calcula a soma de Qtd. Uni e Qtd. Aché para cada mês
                int somaQtdUni = grupo.Sum(row => row.Field<int>("Qtd. Uni"));
                int somaQtdAche = grupo.Sum(row => row.Field<int>("Qtd. Aché"));
                int diferenca = somaQtdAche - somaQtdUni;

                // Adiciona as séries ao gráfico
                series.Add(new ColumnSeries
                {
                    Title = $"{grupo.Key.Ano}-{grupo.Key.Mes:D2} Uni:",
                    Values = new ChartValues<int> { somaQtdUni },
                    LabelPoint = point => point.Y.ToString("N0"),
                    DataLabels = true,
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(65, 105, 225)) // Royal Blue
                });

                series.Add(new ColumnSeries
                {
                    Title = $"{grupo.Key.Ano}-{grupo.Key.Mes:D2} Ach:",
                    Values = new ChartValues<int> { somaQtdAche },
                    LabelPoint = point => point.Y.ToString("N0"),
                    DataLabels = true,
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(85, 107, 47)) // Dark Olive Green
                });

                series.Add(new ColumnSeries
                {
                    Title = $"{grupo.Key.Ano}-{grupo.Key.Mes:D2} Dif:",
                    Values = new ChartValues<int> { diferenca },
                    LabelPoint = point => point.Y.ToString("N0"),
                    DataLabels = true,
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(205, 92, 92)) // Indian Red
                });
            }

            // Configura o gráfico
            grafico.Series = series;
            grafico.AxisX.Add(new Axis { Title = "Mês/Ano", LabelsRotation = 45 });
            grafico.AxisY.Add(new Axis { Title = "Quantidade" });
            //grafico.LegendLocation = LegendLocation.Right;


            GroupBox gp1 = new GroupBox();

            // Defina a posição e tamanho do Label
            Label lbl = new Label();
            lbl.Text = "Gráfico de Descr. de Quantidade";
            lbl.Font = new Font(gp1.Font.FontFamily, 10, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.TopCenter;
            lbl.AutoSize = true;

            // Defina a posição e tamanho do pieChart
            if (!flowLayoutPanel1.Controls.Contains(grafico))
            {
                grafico.BackColorTransparent = true;
                grafico.Dock = DockStyle.Fill;
            }

            // Adicione os controles ao GroupBox
            gp1.Controls.Add(lbl);
            gp1.Controls.Add(grafico);

            gp1.Height = 300;
            gp1.Width = 800;

            flowLayoutPanel1.Controls.Add(gp1);
            gp1.Invalidate();
            gp1.Refresh();

            grafico.BackColor = System.Drawing.Color.Transparent;
        }
        public void createPieChartByQuantitie(System.Data.DataTable dados)
        {

            // Cria um novo componente de gráfico
            var grafico = new LiveCharts.WinForms.PieChart
            {
                Dock = DockStyle.Fill
            };

            // Calcula a soma total de Qtd. Uni e Qtd. Aché
            int totalQtdUni = dados.AsEnumerable().Sum(row => row.Field<int>("Qtd. Uni"));
            int totalQtdAche = dados.AsEnumerable().Sum(row => row.Field<int>("Qtd. Aché"));

            // Calcula a porcentagem entregue
            double percentualEntregue = totalQtdUni != 0 ? (double)totalQtdAche / totalQtdUni * 100 : 0;
            double percentualNaoEntregue = 100 - percentualEntregue;

            // Cria as fatias do gráfico de pizza
            Func<ChartPoint, string> labelPointEntregue = chartPoint => $"Quantidade Contemplada: {totalQtdAche}";
            Func<ChartPoint, string> labelPointNaoEntregue = chartPoint => $"Quantidade Não Contemplada: {totalQtdUni - totalQtdAche}";

            grafico.Series = new SeriesCollection
    {
        new PieSeries
        {
            Title = "Quantificado",
            Values = new ChartValues<double> { percentualEntregue },
            DataLabels = true,
            LabelPoint = labelPointEntregue
        },
        new PieSeries
        {
            Title = "Não Quantificado",
            Values = new ChartValues<double> { percentualNaoEntregue },
            DataLabels = true,
            LabelPoint = labelPointNaoEntregue
        }
    };

            GroupBox gp1 = new GroupBox();

            // Defina a posição e tamanho do Label
            Label lbl = new Label();
            lbl.Text = "Gráfico de Descr. de Quantidade";
            lbl.Font = new Font(gp1.Font.FontFamily, 10, FontStyle.Bold);
            
            lbl.AutoSize = true;

            // Defina a posição e tamanho do pieChart
            if (!flowLayoutPanel1.Controls.Contains(grafico))
            {
                grafico.BackColorTransparent = true;
                grafico.Dock = DockStyle.Fill;
            }

            // Adicione os controles ao GroupBox
            gp1.Controls.Add(lbl);
            gp1.Controls.Add(grafico);

            gp1.Height = 300;
            gp1.Width = 300;

            flowLayoutPanel1.Controls.Add(gp1);
            gp1.Invalidate();
            gp1.Refresh();

            grafico.BackColor = System.Drawing.Color.Transparent;

        }


        public void createDiferenceByValueGraph(System.Data.DataTable dados)
        {
            // Cria um novo componente de gráfico
            var grafico = new LiveCharts.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill
            };

            // Prepara as séries de dados
            SeriesCollection series = new SeriesCollection();

            // Agrupa os dados por mês
            var dadosAgrupados = dados.AsEnumerable()
                                      .GroupBy(row => new { Ano = Convert.ToDateTime(row["Emissão NF"]).Year, Mes = Convert.ToDateTime(row["Emissão NF"]).Month })
                                      .OrderBy(group => group.Key.Ano).ThenBy(group => group.Key.Mes);

            foreach (var grupo in dadosAgrupados)
            {
                // Calcula a soma de Vlr. Uni e Vlr. Aché para cada mês
                double somaVlrUni = grupo.Sum(row => Convert.ToDouble(row["Vlr. Uni"] ?? 0));
                double somaVlrAche = grupo.Sum(row => Convert.ToDouble(row["Vlr. Aché"] ?? 0));
                double diferenca = somaVlrAche - somaVlrUni;

                // Adiciona as séries ao gráfico
                series.Add(new ColumnSeries
                {
                    Title = $"{grupo.Key.Ano}-{grupo.Key.Mes:D2} Uni:",

                    Values = new ChartValues<double> { somaVlrUni },
                    //DataLabels = true,
                    LabelPoint = point => point.Y.ToString("C"),
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(65, 105, 225)) // Royal Blue

                });

                series.Add(new ColumnSeries
                {
                    Title = $"{grupo.Key.Ano}-{grupo.Key.Mes:D2} Ach:",
                    Values = new ChartValues<double> { somaVlrAche },
                    //DataLabels = true,
                    LabelPoint = point => point.Y.ToString("C"),
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(85, 107, 47)) // Dark Olive Green

                });

                series.Add(new ColumnSeries
                {
                    Title = $"{grupo.Key.Ano}-{grupo.Key.Mes:D2} Dif:",
                    Values = new ChartValues<double> { diferenca },
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("C"),
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(205, 92, 92)) // Indian Red
                });
            }

            // Configura o gráfico
            grafico.Series = series;
            grafico.AxisX.Add(new Axis { Title = "Mês/Ano", LabelsRotation = 45 });
            grafico.AxisY.Add(new Axis { Title = "Quantidade" });
            //grafico.LegendLocation = LegendLocation.Right;


            GroupBox gp1 = new GroupBox();

            // Defina a posição e tamanho do Label
            Label lbl = new Label();
            lbl.Text = "Gráfico de Descr. de Valor";
            lbl.Font = new Font(gp1.Font.FontFamily, 10, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.TopCenter;
            lbl.AutoSize = true;

            // Defina a posição e tamanho do pieChart
            if (!flowLayoutPanel1.Controls.Contains(grafico))
            {                
                grafico.BackColorTransparent = true;
                grafico.Dock = DockStyle.Fill;
            }

            // Adicione os controles ao GroupBox
            gp1.Controls.Add(lbl);
            gp1.Controls.Add(grafico);

            gp1.Height = 300;
            gp1.Width = 800;

            flowLayoutPanel1.Controls.Add(gp1);
            gp1.Invalidate();
            gp1.Refresh();

            grafico.BackColor = System.Drawing.Color.Transparent;
        }
        public void createPieChartByValue(System.Data.DataTable dados)
        {
            // Cria um novo componente de gráfico
            var grafico = new LiveCharts.WinForms.PieChart
            {
                Dock = DockStyle.Fill
            };

            // Calcula a soma total de valores
            double totalVlrUni = dados.AsEnumerable().Sum(row => Convert.ToDouble(row["Vlr. Uni"]));
            double totalVlrAche = dados.AsEnumerable().Sum(row => Convert.ToDouble(row["Vlr. Aché"]));

            // Calcula a porcentagem entregue
            double percentualEntregue = totalVlrUni != 0 ? totalVlrAche / totalVlrUni * 100 : 0;
            double percentualNaoEntregue = 100 - percentualEntregue;

            // Cria as fatias do gráfico de pizza
            Func<ChartPoint, string> labelPointEntregue = chartPoint => $"Valor Contemplado: {totalVlrAche:C2}";
            Func<ChartPoint, string> labelPointNaoEntregue = chartPoint => $"Valor Não Contemplado: {totalVlrUni - totalVlrAche:C2}";

            grafico.Series = new SeriesCollection
    {
        new PieSeries
        {
            Title = "Quantificado",
            Values = new ChartValues<double> { percentualEntregue },
            DataLabels = true,
            LabelPoint = labelPointEntregue
        },
        new PieSeries
        {
            Title = "Não Quantificado",
            Values = new ChartValues<double> { percentualNaoEntregue },
            DataLabels = true,
            LabelPoint = labelPointNaoEntregue
        }
    };

            // Configuração do GroupBox e Label
            GroupBox gp1 = new GroupBox();
            Label lbl = new Label
            {
                Text = "Gráfico de Descr. de Valor",
                Font = new Font(gp1.Font.FontFamily, 10, FontStyle.Bold),
                AutoSize = true
            };

            // Configuração do pieChart
            if (!flowLayoutPanel1.Controls.Contains(grafico))
            {
                grafico.BackColorTransparent = true;
                grafico.Dock = DockStyle.Fill;
            }

            // Adiciona os controles ao GroupBox e ao container
            gp1.Controls.Add(lbl);
            gp1.Controls.Add(grafico);
            gp1.Height = 300;
            gp1.Width = 300;
            flowLayoutPanel1.Controls.Add(gp1);
            gp1.Refresh();

            grafico.BackColor = System.Drawing.Color.Transparent;
        }

        /** Async Tasks **/
        private async Task getData(int index)
        {

            try
            {
                if (index == 0)
                {
                    System.Data.DataTable dt = await Information.getAllQuantitiesToDataTableAsync();
                    dgvData.DataSource =dt;
                    dgvData.toDefault();
                    dgvData.Columns["Qtd. Uni"].ValueType = typeof(int);
                    dgvData.Columns["Qtd. Uni"].DefaultCellStyle.Format = "N0";
                    dgvData.Columns["Qtd. Aché"].ValueType = typeof(int);
                    dgvData.Columns["Qtd. Aché"].DefaultCellStyle.Format = "N0";
                    dgvData.Columns["Diferença"].ValueType = typeof(int);
                    dgvData.Columns["Diferença"].DefaultCellStyle.Format = "N0";                     
                    createDiferenceByQuantitieGraph(dt);
                    createPieChartByQuantitie(dt);
                }
                else if (index == 1)
                {
                    System.Data.DataTable dt = await Information.getAllValuesToDataTableAsync();
                    dgvData.DataSource = dt;
                    dgvData.toDefault();
                    dgvData.Columns["Vlr. Uni"].ValueType = typeof(double);
                    dgvData.Columns["Vlr. Uni"].DefaultCellStyle.Format = "C2";
                    dgvData.Columns["Vlr. Aché"].ValueType = typeof(double);
                    dgvData.Columns["Vlr. Aché"].DefaultCellStyle.Format = "C2";
                    dgvData.Columns["Diferença"].ValueType = typeof(double);
                    dgvData.Columns["Diferença"].DefaultCellStyle.Format = "C2";
                    createDiferenceByValueGraph(dt);
                    createPieChartByValue(dt);
                }
            }
            catch(Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }            
        }


        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmAnaliseDebitoCreditoAche_Load;
        }
        private void frmAnaliseDebitoCreditoAche_Load(object sender, EventArgs e)
        {

            /** Configure Attributes **/
            ConfigureComboBoxAttributes();
            
            
            /** Configure Events **/
            ConfigureButtonsEvents();
        }


        /** Configure ComboBox **/
        private void ConfigureComboBoxProperties()
        {
            cbxType.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void ConfigureComboBoxAttributes()
        {
            string[] strings = {"Visão Geral de Descrenpâncias de Quantidades", "Visão Geral de Descrenpâncias de Valores" };
            cbxType.Items.AddRange(strings);
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonsEvents()
        {
            btnFilter.Click += btnFilter_Click;
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            if (cbxType.SelectedIndex != -1) 
            {
                await getData(cbxType.SelectedIndex);
            }
        }
    }
}
