using System;
using System.Data;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAnaliseIqviaSintetico : CustomForm
    {
        /** Instance **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();

        internal class RelatorioIqviaSintetico : Querys<RelatorioIqviaSintetico>
        {
            public async static Task<DataTable> getRelatorioIqviaSinteticoToDataTableAsync(DateTime dt0, DateTime dtf)
            {
                string query = $@"
            DECLARE @DATA1 DATE = '20240901';
DECLARE @DATA2 DATE = '20240930';

-- Geração de todas as datas entre o intervalo
WITH DateRange AS
(
    SELECT @DATA1 AS Data
    UNION ALL
    SELECT DATEADD(DAY, 1, Data)
    FROM DateRange
    WHERE DATEADD(DAY, 1, Data) <= @DATA2
),
Relatorio AS
(
    SELECT  
        CONVERT(DATE, NF_Saida.Dat_Emissao) [Data],	
        SUM(IIF(Tip_Saida = 'V', NF_Saida_Itens.Qtd_Produto, 0)) [Vendas],
        SUM(IIF(Tip_Saida = 'O', NF_Saida_Itens.Qtd_Produto, 0)) [Outras Entradas],
        SUM(IIF(Tip_Saida = 'D', NF_Saida_Itens.Qtd_Produto, 0)) [Devolução],	
        SUM(IIF(Cliente.Tipo_Consumidor IN ('P', 'M', 'E') AND Fabricante.Fantasia LIKE 'EURO%' , NF_Saida_Itens.Qtd_Produto, 0)) [Eurofarma Público],	
        SUM(IIF(Grupo_Cliente.Des_GrpCli LIKE 'DIST%' , NF_Saida_Itens.Qtd_Produto, 0)) [Distribuidor],	
        SUM(IIF(Grupo_Cliente.Des_GrpCli LIKE 'FARM%' OR Grupo_CLiente.Des_GrpCli LIKE 'DROG%' , NF_Saida_Itens.Qtd_Produto, 0)) [Farmácia]
    FROM sp_hospitalar.[DMD].dbo.[NFSCB] NF_Saida
    JOIN sp_hospitalar.[DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
    JOIN sp_hospitalar.[DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente
    JOIN sp_hospitalar.[DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
    JOIN sp_hospitalar.[DMD].dbo.[FABRI] Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante
    JOIN sp_hospitalar.[DMD].dbo.[GRCLI] Grupo_Cliente ON Grupo_Cliente.Cod_GrpCli = Cliente.Cod_GrpCli
    WHERE NF_Saida.Dat_Emissao BETWEEN @DATA1 AND @DATA2
    AND Status = 'F'
    GROUP BY NF_Saida.Dat_Emissao
)

-- Realiza o LEFT JOIN com a tabela de datas
SELECT 
    D.Data,
    ISNULL(R.Vendas, 0) AS Vendas,
    ISNULL(R.[Outras Entradas], 0) AS [Outras Entradas],
    ISNULL(R.Devolução, 0) AS Devolução,
    ISNULL(R.[Eurofarma Público], 0) AS [Eurofarma Público],
    ISNULL(R.Distribuidor, 0) AS Distribuidor,
    ISNULL(R.Farmácia, 0) AS Farmácia,
    Total = ISNULL((R.Vendas + R.[Outras Entradas] + R.Devolução) - (R.[Eurofarma Público]), 0)
FROM DateRange D
LEFT JOIN Relatorio R ON D.Data = R.Data
ORDER BY D.Data

OPTION (MAXRECURSION 0); -- Permite que a CTE tenha mais de 100 recursões

";
                return await getAllToDataTable(query);
            }
        }


        public frmAnaliseIqviaSintetico()
        {
            InitializeComponent();


            //Properties
            CustomFormProperites();
            ConfigureMenuStripProperties();
            ConfigureButtonProperties();


            //Events
            CustomFormEvents();
        }

        /** Async tasks **/
        private async Task getRelatorioAsync()
        {
            dgvData.DataSource = await RelatorioIqviaSintetico.getRelatorioIqviaSinteticoToDataTableAsync(dtpDataInicial.Value,dtpDataFinal.Value); 
        }

        /** Form Configuration **/
        private void CustomFormProperites()
        {
            this.defaultFixedForm();
        }
        private void CustomFormEvents()
        {
            this.Load += frmAnaliseIqviaSintetico_Load;
        }
        private void frmAnaliseIqviaSintetico_Load(object sender, EventArgs e)
        {
            //Pre events
            ConfigureDateTimePickerAttributes();

            ConfigureButtonEvents();



            //Post events
            btnFiltrar_Click(null,null);
        }


        /** DateTimePicker configuration **/
        private void ConfigureDateTimePickerAttributes()
        {
            dtpDataInicial.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDataFinal.Value = DateTime.Today;

        }


        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnFiltrar.Click += btnFiltrar_Click;
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
