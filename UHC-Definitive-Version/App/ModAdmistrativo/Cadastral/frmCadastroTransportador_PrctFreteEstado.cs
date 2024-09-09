using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.ModAdmistrativo.Cadastral
{
    public partial class frmCadastroTransportador_PrctFreteEstado : CustomForm
    {

        /** Instance **/
        internal string transporterId { get; set; }
        internal string transporderDescription { get; set; }
        private List<ShippingPercentageState> shippingPercentageStates = new List<ShippingPercentageState>();

        public frmCadastroTransportador_PrctFreteEstado()
        {
            InitializeComponent();

            //Properties 
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();


            //Events 
            ConfigureFormEvents();
        }

        /** Async Taks **/
        private async Task saveAsync()
        {
            List<ShippingPercentageState> shippingPercentageStates = new List<ShippingPercentageState>();
            foreach (DataGridViewRow _row in dgvData.Rows)
            {
                shippingPercentageStates.Add(new ShippingPercentageState
                {
                    idTransporter = txtTransporterId.Text
                    ,uf = _row.Cells["uf"].Value.ToString()
                    ,capitalPercentage = _row.Cells["capitalPercentage"].Value.ToString().ConvertPercentageToDouble().ToString()
                    ,capitalMinPrice = _row.Cells["capitalMinPrice"].Value.ToString().ConvertCoinToDouble().ToString()
                    ,inlandPercentage = _row.Cells["inlandPercentage"].Value.ToString().ConvertPercentageToDouble().ToString()
                    ,inlandMinPrice = _row.Cells["inlandMinPrice"].Value.ToString().ConvertCoinToDouble().ToString()
                });
            }

            try
            {
                await ShippingPercentageState.deleteAsync(txtTransporterId.Text);
                await ShippingPercentageState.insertAsync(shippingPercentageStates);
                CustomNotification.defaultInformation("Parâmetros atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }

        }
        private async Task getParameters()
        {
            if (await ShippingPercentageState.exist(transporterId))
            {
                shippingPercentageStates = (await ShippingPercentageState.getAllToListByCodeAsync(transporterId));
            }
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCadastroTransportador_PcrtFreteEstado_Load;
        }
        private async void frmCadastroTransportador_PcrtFreteEstado_Load(object sender, EventArgs e)
        {
            await getParameters();

            ConfigureTextBoxAttributes();
            ConfigureDataGridViewAttributes();
            ConfigureDataGridViewProperties();
            ConfigureButtonEvents();
            ConfigureDataGridViewEvents();
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewAttributes()
        {


            // Crie as colunas do DataGridView
            dgvData.Columns.Add("UF", "UF");
            dgvData.Columns.Add("capitalPercentage", "% Capital");
            dgvData.Columns.Add("capitalMinPrice", "Prc. Mínimo Capital");
            dgvData.Columns.Add("inlandPercentage", "% Interior");
            dgvData.Columns.Add("inLandMinPrice", "Prc. Máximo Capital");




            // Preencha o DataGridView com os dados dos estados
            if (shippingPercentageStates.Count == 0)
            {
                // Preencha os estados e valores fictícios
                string[] siglasEstados = { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };


                // Ordene os estados em ordem alfabética
                Array.Sort(siglasEstados);
                foreach (string estado in siglasEstados)
                {
                    dgvData.Rows.Add(estado, "0,0%", "R$ 0,00", "0,0%", "R$ 0,00");
                }
            }
            else
            {
                foreach (var estado in shippingPercentageStates)
                {
                    dgvData.Rows.Add(
                        estado.uf
                       , Convert.ToDouble(estado.capitalPercentage).ToString("P2")
                       , Convert.ToDouble(estado.capitalMinPrice).ToString("C2")
                       , Convert.ToDouble(estado.inlandPercentage).ToString("P2")
                       , Convert.ToDouble(estado.inlandMinPrice).ToString("C2"));
                }
            }
        }
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.ReadOnly = false;
            dgvData.Columns[0].ReadOnly = true;
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvData.EditingControlShowing += dgvData_EditingControlShowing;
            dgvData.CellEndEdit += dgvData_CellEndEdit;
        }
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            TextBox textBox = e.Control as TextBox;

            if (textBox != null && dgv.CurrentCell != null)
            {
                string columnName = dgv.Columns[dgv.CurrentCell.ColumnIndex].Name;

                if (columnName == "capitalPercentage" || columnName == "inlandPercentage")
                {
                    textBox.KeyPress -= NumericCell_KeyPress; // Remove o manipulador existente
                    textBox.KeyPress += PercentageCell_KeyPress; // Adiciona o manipulador para porcentagem
                }
                else if (columnName == "capitalMinPrice" || columnName == "inLandMinPrice")
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
        private void NumericCell_KeyPress(object sender, KeyPressEventArgs e)
        {
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
        private void PercentageCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumericCell_KeyPress(sender, e); // Reutiliza a lógica de entrada numérica
        }
        private void CoinCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumericCell_KeyPress(sender, e); // Reutiliza a lógica de entrada numérica
        }
        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string columnName = dgv.Columns[e.ColumnIndex].Name;

            if (columnName == "capitalPercentage" || columnName == "inlandPercentage")
            {
                if (decimal.TryParse(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out decimal value))
                {
                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (value / 100).ToString("P"); // Converte para porcentagem
                }
            }
            else if (columnName == "capitalMinPrice" || columnName == "inLandMinPrice")
            {
                if (decimal.TryParse(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out decimal value))
                {
                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value.ToString("C"); // Converte para preço
                }
            }
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

        /** Configure Button**/
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
            await saveAsync();
        }
    }
}
