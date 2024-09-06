using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.ModAdmistrativo.Cadastral
{
    public partial class frmCadastroTransportador_PrctFreteCidade : CustomForm
    {
        /** Instance  **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();
        internal string transporterId { get; set; }
        internal string transporderDescription { get; set; }
        private List<ShippingPercentageCity> shippingPercentageCities = new List<ShippingPercentageCity>();
        private List<State> states = new List<State>();
        private List<City> cities = new List<City>();
        private List<CitiesScreen> citiesScreen = new List<CitiesScreen>();
        private bool shouldClearCell = false;  // Variável para rastrear se a célula deve ser limpa
        internal class CitiesScreen
        {
            public string idIbge_City { get; set; }
            public string uf { get; set; }
            public string cityDescription { get; set; }
        }

        public frmCadastroTransportador_PrctFreteCidade()
        {
            InitializeComponent();

            //Properties
            ConfigureMenuStripProperties();
            ConfigureFormProperties();
            ConfigureDataGridViewProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();
            
            //Events
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private async Task getStates()
        {
            states = await State.getAllToListAsync();
        }
        private async Task getCities()
        {
            cities = await City.getAllToListAsync();
        }
        private async Task saveAsync()
        {
            List<ShippingPercentageCity> list = new List<ShippingPercentageCity>();


            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells[1].Value?.ToString())
                    && !row.Cells[1].Value.ToString().Equals("N/D")
                    )
                {
                    list.Add(new ShippingPercentageCity
                    {
                        idTransporter = transporterId
                        ,
                        idIbge_City = row.Cells[0].Value.ToString()
                        ,
                        cityPercentage = row.Cells[3].Value.ToString().ConvertPercentageToDouble().ToString()
                        ,
                        cityMinValue = row.Cells[4].Value.ToString().ConvertCoinToDouble().ToString()
                    });
                }

            }


            try
            {
                await ShippingPercentageCity.deleteAsync(transporterId);
                await ShippingPercentageCity.insertAsync(list);
                CustomNotification.defaultInformation();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }
        private async Task getParameters()
        {
            try
            {
                if (await ShippingPercentageCity.exist(transporterId))
                {
                    shippingPercentageCities = (await ShippingPercentageCity.getAllToListByCodeAsync(transporterId));
                }
            }
            catch
            {

            }
        }

        /** Sync Methods **/
        private void getScreenInformation()
        {
            var query = from city in cities
                        join state in states on city.idIBGE_State equals state.idIBGE
                        select new { city, state };
            foreach (var info in query)
            {
                citiesScreen.Add(new CitiesScreen
                {
                    idIbge_City = info.city.idIBGE
                    ,
                    cityDescription = info.city.description
                    ,
                    uf = info.state.uf
                });
            }

        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCadastroTransportador_PcrtFreteCidade_Load;
        }
        private async void frmCadastroTransportador_PcrtFreteCidade_Load(object sender, EventArgs e)
        {

            await getStates();
            await getCities();
            getScreenInformation();
            await getParameters();
            ConfigureTextBoxAttributes();
            ConfigureDataGridViewAttributes();
            ConfigureDataGridViewEvents();
            ConfigureButtonEvents();
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxAttributes()
        {
            txtTransporterId.Text = transporterId;
            txtTransporterDescription.Text = transporderDescription;
        }
        private void ConfigureTextBoxProperties()
        {
            txtTransporterId.ReadOnly = true;
            txtTransporterId.TabStop = false;

            txtTransporterDescription.ReadOnly = true;
            txtTransporterDescription.TabStop = false;
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewAttributes()
        {

            if (shippingPercentageCities.Count > 0)
            {
                foreach (var city in shippingPercentageCities)
                {
                    var c = citiesScreen.Where(x => x.idIbge_City.Equals(city.idIbge_City)).FirstOrDefault();
                    dgvData.Rows.Add(
                          city.idIbge_City
                         , c.cityDescription
                         , c.uf
                         , Convert.ToDouble(city.cityPercentage).ToString("P2")
                         , Convert.ToDouble(city.cityMinValue).ToString("C2")
                         );
                }
            }
        }
        private void ConfigureDataGridViewProperties()
        {
            dgvData.Columns.Add("idIBGE", "Cód. IBGE");
            dgvData.Columns.Add("county", "Município'");
            dgvData.Columns.Add("UF", "UF");
            dgvData.Columns.Add("percentage", "%");
            dgvData.Columns.Add("minPrice", "Prc. Mínimo");
            dgvData.toDefault();
            dgvData.ReadOnly = false;
            dgvData.Columns[1].ReadOnly = true;
            dgvData.Columns[2].ReadOnly = true;
            dgvData.AllowUserToAddRows = true;
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvData.EditingControlShowing += dgvData_EditingControlShowing;
            dgvData.CellEndEdit += dgvData_CellEndEdit;
            dgvData.CellBeginEdit += dgvData_CellBeginEdit;  // Adicione esta linha
            dgvData.KeyDown += dgvData_KeyDown;

        }
        private void dgvData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string columnName = dgv.Columns[e.ColumnIndex].Name;

            // Se a célula já contém dados, defina a flag para limpá-la
            if ((columnName == "idIBGE" || columnName == "percentage" || columnName == "minPrice") && dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                shouldClearCell = true;
            }
        }
        private void dgvData_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewCell cell in dgv.SelectedCells)
                {
                    if (!cell.ReadOnly)
                    {
                        if (cell.ColumnIndex == 0)
                        {
                            cell.Value = null;
                            dgv.CurrentRow.Cells[1].Value = null;
                            dgv.CurrentRow.Cells[2].Value = null;
                            dgv.CurrentRow.Cells[3].Value = null;
                            dgv.CurrentRow.Cells[4].Value = null;
                        }
                        else
                        {
                            cell.Value = null;
                        }
                    }
                }
            }

        }
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                TextBox textBox = e.Control as TextBox;

                if (textBox != null && dgv.CurrentCell != null)
                {
                    string columnName = dgv.Columns[dgv.CurrentCell.ColumnIndex].Name;

                    if (columnName == "idIBGE")
                    {
                        textBox.KeyPress -= NumericCell_KeyPress; // Remove o manipulador existente
                        textBox.KeyPress += IdIBGECell_KeyPress; // Adiciona o manipulador para idIBGE
                    }
                    else if (columnName == "percentage")
                    {
                        textBox.KeyPress -= NumericCell_KeyPress; // Remove o manipulador existente
                        textBox.KeyPress += PercentageCell_KeyPress; // Adiciona o manipulador para porcentagem
                    }
                    else if (columnName == "minPrice")
                    {
                        textBox.KeyPress -= NumericCell_KeyPress; // Remove o manipulador existente
                        textBox.KeyPress += CoinCell_KeyPress; // Adiciona o manipulador para preço
                    }
                    else
                    {
                        textBox.KeyPress -= PercentageCell_KeyPress; // Remove os manipuladores existentes
                        textBox.KeyPress -= CoinCell_KeyPress;
                        textBox.KeyPress += NumericCell_KeyPress; // Adiciona o manipulador padrão para números decimais
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void IdIBGECell_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                TextBox textBox = sender as TextBox;

                // Se a célula deve ser limpa, limpe-a e redefina a flag
                if (shouldClearCell)
                {
                    textBox.Text = "";
                    shouldClearCell = false;
                }

                // Permite apenas números inteiros
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Verifica o comprimento
                if (textBox.Text.Length >= 7 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
            catch (Exception)
            {

            }
        }
        private void NumericCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;

                // Se a célula deve ser limpa, limpe-a e redefina a flag
                if (shouldClearCell)
                {
                    textBox.Text = "";
                    shouldClearCell = false;
                }
                // Permite apenas números decimais e o caractere de ponto
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }

                // Permite apenas um ponto decimal
                if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(','))
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {

            }
        }
        private void PercentageCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Se a célula deve ser limpa, limpe-a e redefina a flag
            if (shouldClearCell)
            {
                textBox.Text = "";
                shouldClearCell = false;
            }
            NumericCell_KeyPress(sender, e); // Reutiliza a lógica de entrada numérica
        }
        private void CoinCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumericCell_KeyPress(sender, e); // Reutiliza a lógica de entrada numérica
        }
        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridView dgv = sender as DataGridView;
                string columnName = dgv.Columns[e.ColumnIndex].Name;

                if (columnName == "idIBGE")
                {
                    if (int.TryParse(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out int value))
                    {
                        // Verifica se o valor já existe na coluna 0
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.Index != e.RowIndex && row.Cells[0].Value != null && row.Cells[0].Value.ToString() == value.ToString())
                            {
                                CustomNotification.defaultAlert("O valor já existe na coluna idIBGE.");
                                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                                return;
                            }
                        }

                        if (value.ToString().Length != 7)
                        {
                            CustomNotification.defaultAlert("O campo idIBGE deve ter 7 dígitos.");
                            dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                        }
                        else
                        {
                            var city = citiesScreen.Where(x => x.idIbge_City.Equals(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)).FirstOrDefault();
                            if (city != null)
                            {
                                dgv.Rows[e.RowIndex].Cells[1].Value = city.cityDescription;
                                dgv.Rows[e.RowIndex].Cells[2].Value = city.uf;
                                dgv.Rows[e.RowIndex].Cells[3].Value = "0,00 %";
                                dgv.Rows[e.RowIndex].Cells[4].Value = "0,00 R$";
                            }
                            else
                            {
                                dgv.Rows[e.RowIndex].Cells[1].Value = "N/D";
                                dgv.Rows[e.RowIndex].Cells[2].Value = "N/D";
                            }
                        }
                    }
                }
                else if (columnName == "percentage")
                {
                    if (decimal.TryParse(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out decimal value))
                    {
                        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (value / 100).ToString("P"); // Converte para porcentagem
                    }
                }
                else if (columnName == "minPrice")
                {
                    if (decimal.TryParse(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out decimal value))
                    {
                        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value.ToString("C"); // Converte para preço
                    }
                }

                dgvData.AutoResizeColumns();
            }
            catch (Exception)
            {

            }
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSave.Click += btnSave_Click;
            btnCounties.Click += btnCounties_Click;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            await saveAsync();
        }
        private async void btnCounties_Click(object sender, EventArgs e)
        {
            frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
            frmGeneric_ConsultaComSelecao.consulta = await City.getAllToDataTableAsync();
            frmGeneric_ConsultaComSelecao.ShowDialog();
            if (frmGeneric_ConsultaComSelecao.extendedCode != null)
            {
                var city = citiesScreen.Where(x => x.idIbge_City.Equals(frmGeneric_ConsultaComSelecao.extendedCode)).FirstOrDefault();
                dgvData.Rows.Add(frmGeneric_ConsultaComSelecao.extendedCode
                                , city.cityDescription
                                , city.uf
                                , 0.0.ToString("P2")
                                , 0.0.ToString("C2")
                                );
            }
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

            menuArquivo.DropDownItems.Add(itemArquivoAbrir);
            menuArquivo.DropDownItems.Add(itemArquivoExportar);
            itemArquivoAbrir.DropDownItems.Add(itemArquivoAbrirExcel);
            itemArquivoExportar.DropDownItems.Add(itemArquivoExportarExcel);

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
