using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAnaliseIqviaSintetico : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        string unidade_Login;
        public class RelatorioAnaliseIqvia : Querys<RelatorioAnaliseIqvia>
        {

            public string Query { get; set; }

            public static async  Task<RelatorioAnaliseIqvia> getQueryAsync()
            {
                string query = $@"SELECT * FROM {Connection.dbBase}.dbo.{RelatorioAnaliseIqvia.getClassName()}";
                return await getToClass(query);
            }
            public static async Task<DataTable> getRelatorioIqviaAnaliticoToDataTableAsync(DateTime data)
            {
                string query = $@"  DECLARE @DATA DATE = '{data}';
                                                                   
                            SELECT
	  NF_Saida.Num_Nota [NF]
	  ,NF_Saida.Cod_Cliente [Cód Cliente]
	  ,Cliente.Razao_Social [Cliente]
	  ,IIF(Cliente.Tipo_Consumidor IN ('N','F'),'Privado','Público') [Consumidor]
	  ,GrupoCliente.Des_GrpCli [Grupo]
	  ,Cod_Cfo1 [CFOP]
	  ,cfop.Descricao [Desc. CFOP]
	  ,MONTH(DAT_EMISSAO) [Mês]
	  ,NF_Saida_Itens.Cod_Produto
	  ,Produto.Descricao [Produto]
	  ,Fabricante.Fantasia [Fabricante]
	  ,SUM(NF_Saida_Itens.Qtd_Produto) [Qtd. Produto]		 	 
FROM {Connection.dbDMD}.dbo.NFSCB NF_Saida
JOIN {Connection.dbDMD}.dbo.NFSIT NF_Saida_Itens ON NF_Saida_Itens.Num_Nota = NF_Saida.Num_Nota
JOIN {Connection.dbDMD}.dbo.CLIEN Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente
JOIN {Connection.dbDMD}.dbo.PRODU Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
JOIN {Connection.dbDMD}.dbo.FABRI Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante
JOIN {Connection.dbDMD}.dbo.GRCLI GrupoCliente ON GrupoCliente.Cod_GrpCli = Cliente.Cod_GrpCli
JOIN {Connection.dbDMD}.dbo.TBCFO Cfop ON Cfop.Codigo = NF_Saida.Cod_Cfo1
WHERE 
Status = 'F'
AND NF_Saida.Dat_Emissao = @DATA


GROUP BY 
NF_Saida.Num_Nota
,NF_Saida.Cod_Cliente 
,Cliente.Razao_Social 
,Cliente.Tipo_Consumidor
,Cod_Cfo1 
,NF_Saida_Itens.Cod_Produto
,Produto.Descricao
,MONTH(DAT_EMISSAO)
,Fabricante.Fantasia
,GrupoCliente.Des_GrpCli
,cfop.Descricao
ORDER BY [Qtd. Produto] DESC

                    ";
                Console.Write(query);
                return await getAllToDataTable(query);
            }
            public static async Task<DataTable> getRelatorioIqviaSinteticoToDataTableAsync(DateTime dt0, DateTime dtf)
            {
                string q = (await RelatorioAnaliseIqvia.getQueryAsync())?.Query;

                if (string.IsNullOrEmpty(q))
                {
                    CustomNotification.defaultAlert("Query não registrada");
                }

                string query = $@"  DECLARE @DATA1 DATE = '{dt0}';
                                    DECLARE @DATA2 DATE = '{dtf}';                                
                    {q}";
                Console.Write(query);
                return await getAllToDataTable(query);
            }
        }

        


        public frmAnaliseIqviaSintetico()
        {
            InitializeComponent();

            //unidade_Login = Section.Unidade;
            //Properties
            CustomFormProperites();
            ConfigureMenuStripProperties();
            ConfigureButtonProperties();
            ConfigureComboBoxProperties();
            ConfigureDataGridViewProperties();


            //Events
            CustomFormEvents();
        }

        /** Async tasks **/
        private async Task getRelatorioAsync()
        {
            
            Section.Unidade = cbxUnidade.SelectedItem?.ToString();
            dgvData.DataSource = await RelatorioAnaliseIqvia.getRelatorioIqviaSinteticoToDataTableAsync(dtpDataInicial.Value,dtpDataFinal.Value);
            dgvData.Columns[0].ValueType = typeof(DateTime);
            dgvData.Columns[dgvData.Columns.Count-1].ValueType = typeof(int);
            dgvData.Columns[dgvData.Columns.Count - 1].DefaultCellStyle.Format = "N0";


            int sum = 0;
            foreach (DataGridViewRow _row in dgvData.Rows)
            {
                sum += Convert.ToInt32(_row.Cells[dgvData.Columns.Count - 1].Value);
            }
            txtQtdsTotais.Text = sum.ToString("N0");

        }

        public DataTable FiltrarPossibilidades(DataTable dataTable, string[] grupos, string[] fabricantes, int qtdAlvo)
        {
            // DataTable para armazenar os resultados
            DataTable resultadoTable = new DataTable();
            resultadoTable.Columns.Add("ID", typeof(int));
            resultadoTable.Columns.Add("Cliente", typeof(string));
            resultadoTable.Columns.Add("Qtd. Produto", typeof(int));
            resultadoTable.Columns.Add("Probabilidade", typeof(string));

            int indice = 1;

            // Primeiro, tentamos filtrar usando os parâmetros específicos (grupos e fabricantes)
            Console.WriteLine("Tentando encontrar combinações com parâmetros específicos...");
            var linhasFiltradas = FiltrarLinhasEspecificas(dataTable, grupos, fabricantes);

            if (!linhasFiltradas.Any())
            {
                // Caso não tenha encontrado resultados específicos, fazemos uma busca geral
                Console.WriteLine("Nenhuma combinação específica encontrada, buscando combinações gerais...");
                linhasFiltradas = dataTable.AsEnumerable().ToList();
            }

            // Obter as quantidades de produtos
            var quantidades = linhasFiltradas.Select(row => row.Field<int>("Qtd. Produto")).ToList();

            // Encontrar combinações de soma
            var combinacoesEncontradas = EncontrarCombinacoesSoma(quantidades, qtdAlvo);

            Console.WriteLine($"Total de combinações encontradas: {combinacoesEncontradas.Count}");

            // Calcular a relevância para cada combinação e obter as 500 melhores
            var combinacoesRelevantes = combinacoesEncontradas
                .Select(combinacao => new
                {
                    Combinacao = combinacao,
                    Relevancia = CalcularRelevancia(combinacao, qtdAlvo)
                })
                .OrderByDescending(x => x.Relevancia)
                .Take(500) // Limitando a 500 recomendações mais relevantes
                .ToList();

            foreach (var item in combinacoesRelevantes)
            {
                foreach (var qtd in item.Combinacao)
                {
                    var linha = linhasFiltradas.FirstOrDefault(r => r.Field<int>("Qtd. Produto") == qtd);
                    if (linha != null)
                    {
                        string cliente = linha.Field<string>("Cliente");
                        resultadoTable.Rows.Add(
                            indice,
                            cliente,
                            linha.Field<int>("Qtd. Produto"),
                            item.Relevancia > 0.8 ? "Alta" : item.Relevancia > 0.4 ? "Média" : "Baixa"
                        );
                        Console.WriteLine($"Adicionando linha Cliente: {cliente}, Qtd. Produto: {linha.Field<int>("Qtd. Produto")}, Relevância: {item.Relevancia}");
                    }
                }
                indice++;
            }

            Console.WriteLine("Processamento de FiltrarPossibilidades concluído.");
            return resultadoTable;
        }

        // Função para filtrar linhas específicas com base em grupos e fabricantes
        private List<DataRow> FiltrarLinhasEspecificas(DataTable dataTable, string[] grupos, string[] fabricantes)
        {
            return dataTable.AsEnumerable()
                .Where(row =>
                {
                    bool grupoMatch = grupos.Length == 0 || AproximaGrupoOuCliente(row, grupos);
                    bool fabricanteMatch = fabricantes.Length == 0 || AproximaFabricante(row, fabricantes);

                    Console.WriteLine($"Linha ID: {row.Field<int>("NF")} - Grupo Match: {grupoMatch}, Fabricante Match: {fabricanteMatch}");
                    return grupoMatch && fabricanteMatch;
                })
                .ToList();
        }

        // Função para encontrar combinações de quantidades que somam ao alvo
        private List<List<int>> EncontrarCombinacoesSoma(List<int> valores, int alvo)
        {
            List<List<int>> resultado = new List<List<int>>();
            Console.WriteLine("Iniciando busca de combinações de soma...");

            // Função recursiva para buscar combinações
            void Backtrack(int start, int somaAtual, List<int> caminho)
            {
                if (somaAtual == alvo)
                {
                    resultado.Add(new List<int>(caminho));
                    Console.WriteLine($"Combinação encontrada: {string.Join(", ", caminho)}");
                    return;
                }
                if (somaAtual > alvo) return;

                for (int i = start; i < valores.Count; i++)
                {
                    caminho.Add(valores[i]);
                    Backtrack(i + 1, somaAtual + valores[i], caminho);
                    caminho.RemoveAt(caminho.Count - 1);
                }
            }

            Backtrack(0, 0, new List<int>());
            Console.WriteLine($"Total de combinações encontradas: {resultado.Count}");
            return resultado;
        }

        // Função para calcular a relevância da combinação
        private double CalcularRelevancia(List<int> combinacao, int alvo)
        {
            double soma = combinacao.Sum();
            double similaridade = 1 - Math.Abs(soma - alvo) / (double)alvo;
            return Math.Max(0, similaridade); // Relevância varia entre 0 e 1
        }

        private bool AproximaGrupoOuCliente(DataRow row, string[] grupos)
        {
            string cliente = row.Field<string>("Cliente");
            string grupo = row.Field<string>("Grupo");

            bool resultado = grupos.Any(g => DistanciaLevenshtein(g, cliente) <= 2 || DistanciaLevenshtein(g, grupo) <= 2);
            Console.WriteLine($"Comparação AproximaGrupoOuCliente - Cliente: {cliente}, Grupo: {grupo}, Resultado: {resultado}");
            return resultado;
        }

        private bool AproximaFabricante(DataRow row, string[] fabricantes, bool matchAll = false)
        {
            string fabricante = row.Field<string>("Fabricante");

            if (matchAll)
            {
                return ContainsAll(fabricante, fabricantes);
            }
            else
            {
                return ContainsAny(fabricante, fabricantes);
            }
        }

        private bool ContainsAny(string source, string[] substrings)
        {
            bool result = substrings.Any(substring => source.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0);
            Console.WriteLine($"ContainsAny - Fonte: {source}, Substrings: {string.Join(", ", substrings)}, Resultado: {result}");
            return result;
        }

        private bool ContainsAll(string source, string[] substrings)
        {
            bool result = substrings.All(substring => source.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0);
            Console.WriteLine($"ContainsAll - Fonte: {source}, Substrings: {string.Join(", ", substrings)}, Resultado: {result}");
            return result;
        }

        // Função para calcular a distância de Levenshtein
        private int DistanciaLevenshtein(string s, string t)
        {
            int[,] d = new int[s.Length + 1, t.Length + 1];

            for (int i = 0; i <= s.Length; i++) d[i, 0] = i;
            for (int j = 0; j <= t.Length; j++) d[0, j] = j;

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= t.Length; j++)
                {
                    int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            return d[s.Length, t.Length];
        }





        /** Form Configuration **/
        private void CustomFormProperites()
        {
            this.defaultFixedForm();
        }
        private void CustomFormEvents()
        {
            this.Load += frmAnaliseIqviaSintetico_Load;
            this.FormClosing += frmAnaliseIqviaSintetico_FormClosing;
        }

        private void frmAnaliseIqviaSintetico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Section.Unidade = unidade_Login;
        }

        private void frmAnaliseIqviaSintetico_Load(object sender, EventArgs e)
        {
            //Pre events
            ConfigureDateTimePickerAttributes();

            ConfigureButtonEvents();
            ConfigureDataGridViewEvents();


            //Post events
            btnFiltrar_Click(null,null);
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtQtdsTotais.ReadOnly();
            txtValorBuscado.JustNumbers();
        }

        /** DateTimePicker configuration **/
        private void ConfigureDateTimePickerAttributes()
        {
            dtpDataInicial.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDataFinal.Value = DateTime.Today;

        }

        /** ComboBox Configuration **/
        private void ConfigureComboBoxProperties()
        {
            cbxUnidade.Items.AddRange(new object[]
            {
                "UNI HOSPITALAR",
                "UNI CEARÁ",
                "SP HOSPITALAR"
            });
            cbxUnidade.SelectedIndex = 0;
            cbxUnidade.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnFiltrar.Click += btnFiltrar_Click;
            btnSugestoes.Click += btnSugestoes_Click;
        }

        private async void btnSugestoes_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null) 
            {
                var sugestoes = await RelatorioAnaliseIqvia.getRelatorioIqviaAnaliticoToDataTableAsync(Convert.ToDateTime(dgvData.CurrentRow.Cells[0].Value));

                string[] grupos = {"Farmacia","Drogaria"};
                string[] fabricantes = { "Eurofarma"};
                frmConsultaGenerica frmConsultaGenerica = new frmConsultaGenerica();
                this.Cursor = Cursors.WaitCursor;
                frmGeneric_ProgressForm frmGeneric_ProgressForm = new frmGeneric_ProgressForm();
                frmGeneric_ProgressForm.chargeText = "Calculando... ";
                frmGeneric_ProgressForm.Show();
                frmConsultaGenerica.consulta = FiltrarPossibilidades(sugestoes,grupos,fabricantes, Convert.ToInt32(txtValorBuscado.Text));
                frmGeneric_ProgressForm.Close();
                this.Cursor = Cursors.Default;
                CustomNotification.defaultInformation();
                frmConsultaGenerica.ShowDialog(); 
            }
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            await getRelatorioAsync();
        }


        /** Menu Strip Configuration **/
        private void ConfigureMenuStripProperties()
        {
            CustomToolStripMenuItem menuArquivo = new CustomToolStripMenuItem("Arquivo");
            CustomToolStripMenuItem itemArquivoAbrir = new CustomToolStripMenuItem("Abrir");
            CustomToolStripMenuItem itemArquivoAbrirExcel = new CustomToolStripMenuItem("Excel");
            CustomToolStripMenuItem itemArquivoExportar = new CustomToolStripMenuItem("Exportar");
            CustomToolStripMenuItem itemArquivoExportarExcel = new CustomToolStripMenuItem("Excel");

            CustomToolStripMenuItem menuConfiguracoes = new CustomToolStripMenuItem("Configurações");
            CustomToolStripMenuItem menuConfiguracoesParametrizacao = new CustomToolStripMenuItem("Parametrização");

            itemArquivoAbrirExcel.Click += ItemArquivoAbrirExcel_Click;
            itemArquivoExportarExcel.Click += ItemArquivoExportarExcel_Click;
            menuConfiguracoesParametrizacao.Click += menuConfiguracoesParametrizacao_Click;

            // Adicionando o item 'Empresa' e seu evento de clique

            menuArquivo.DropDownItems.Add(itemArquivoAbrir);
            menuArquivo.DropDownItems.Add(itemArquivoExportar);
            menuArquivo.DropDownItems.Add(menuConfiguracoes);
            
            itemArquivoAbrir.DropDownItems.Add(itemArquivoAbrirExcel);
            itemArquivoExportar.DropDownItems.Add(itemArquivoExportarExcel);

            menuConfiguracoes.DropDownItems.Add(menuConfiguracoesParametrizacao);
            // Adiciona o menuConfiguracao ao menu principal
            menuStrip.Items.Add(menuArquivo);
            this.Controls.Add(menuStrip);

        }
        private void menuConfiguracoesParametrizacao_Click(object sender, EventArgs e)
        {
            frmAnaliseIqviaSintetico_Parametrizacao frmAnaliseIqviaSintetico_Parametrizacao = new frmAnaliseIqviaSintetico_Parametrizacao();
            frmAnaliseIqviaSintetico_Parametrizacao.ShowDialog();
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

        /** Configure DataGridView  **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvData.DoubleClick += dgvData_DoubleClick;
        }
        private async void dgvData_DoubleClick(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                frmConsultaGenerica frmConsultaGenerica = new frmConsultaGenerica();
                frmConsultaGenerica.consulta = await RelatorioAnaliseIqvia.getRelatorioIqviaAnaliticoToDataTableAsync(Convert.ToDateTime(dgvData.CurrentRow.Cells[0].Value)) ;
                frmConsultaGenerica.ShowDialog();
            }
        }
    }
}
