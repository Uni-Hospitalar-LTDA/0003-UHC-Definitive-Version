using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.ModVendas.Cadastros
{
    public partial class frmVendas_DataIngestion : CustomForm
    {
        public frmVendas_DataIngestion()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureComboBoxProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();
            ConfigureLabelProperties();

            ConfigureFormEvents();
        }

        /** Sync Methods **/

        private DataTable LoadDataFromExcel(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Adicione esta linha

            using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                DataTable dataTable = new DataTable();

                // Adiciona colunas ao DataTable
                foreach (var headerCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                {
                    dataTable.Columns.Add(headerCell.Text);
                }

                // Adiciona linhas ao DataTable
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    DataRow newRow = dataTable.NewRow();
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        newRow[col - 1] = worksheet.Cells[row, col].Text;
                    }
                    dataTable.Rows.Add(newRow);
                }
                return dataTable;
            }
        }

        private bool layoutValidation()
        {
            bool validate = true; // Inicialmente definido como verdadeiro

            List<string> expectedColumns = new List<string>
            {
                "Cód# EAN",
                "Apresentação",
                "CNPJ Distribuidor",
                "Numero NF",
                "Qtde# Faturamento",
                "Valor Bruto",
                "% Desconto",
                "% Desconto Padrão",
                "% Custo de Margem",
                "% Débito",
                "Valor Débito Bruto",
                "% Repasse ICMS",
                "Valor Repasse ICMS",
                "Valor Débito Final",
                "RF Ajuste Tributário",
                "RF Valor Débito",
                "RF Aliquota Interestadual",
                "RF PISCofins",
                "RF RedutorICMS"
            };

            foreach (string columnName in expectedColumns)
            {
                if (!dgvData.Columns.Contains(columnName))
                {
                    validate = false; // Se alguma coluna estiver ausente, definimos como falso                    
                }
            }

            if (!validate)
            {
                string filename = Path.GetTempFileName();

                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("/**************************************/");
                    writer.WriteLine("Coluna           |  Sim  |  Não  |");
                    writer.WriteLine("-----------------------------------");

                    foreach (string coluna in expectedColumns)
                    {
                        bool colunaPresente = dgvData.Columns.Contains(coluna);
                        string sim = colunaPresente ? "   X   " : "       ";
                        string nao = colunaPresente ? "       " : "   X   ";

                        writer.WriteLine($"{coluna,-16} |{sim}|{nao}|");
                        writer.WriteLine("-----------------------------------");
                    }

                    // Saída do texto para o arquivo
                    writer.Close();

                    // Remova ou comente a linha abaixo se você não quiser abrir o arquivo de texto no programa padrão
                    Process.Start(filename);
                }
            }
            return validate;
        }

        private void getData()
        {
            try
            {
                dgvData.DataSource = LoadDataFromExcel(txtArchiveName.Text);
            }
            catch (Exception ex)
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
            this.Load += frmVendas_DataIngestion_Load;
        }
        private void frmVendas_DataIngestion_Load(object sender, EventArgs e)
        {
            ConfigureComboBoxAttributes();
            ConfigureButtonEvents();
            ConfigureComboBoxEvents();
            ConfigureDataGridViewProperties();
        }

        /** Configure ComboBox **/
        private void ConfigureComboBoxProperties()
        {
            cbxSelector.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void ConfigureComboBoxAttributes()
        {
            cbxSelector.Items.Add("Planilha de Débito da Aché (Em .xlsx)");
        }
        private void ConfigureComboBoxEvents()
        {
            cbxSelector.SelectedIndexChanged += cbxSelector_SelectedIndexChanged;
        }
        private void cbxSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSelector.SelectedItem != null)
            {
                btnOpen.Enabled = true;
                txtName.Visible = true;
                lblName.Visible = true;
                btnSave.Visible = true;
            }
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnOpen.Enabled = false;
            btnSave.Visible = false;
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnOpen.Click += btnOpen_Click;
            btnSave.Click += btnSave_Click;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                CustomNotification.defaultAlert("Dê uma descrição para a importação");
                return;
            }

            if (DialogResult.Yes == CustomNotification.defaultQuestionAlert("Deseja importar o Layout?"))
            {
                await saveAsync();
            };
        }

        private async Task saveAsync()
        {
            bool saved = false;
            List<DataIngestion> di = new List<DataIngestion>();

            di.Add(new DataIngestion
            {
                name = txtName.Text,
                idUser = Section.idUsuario
            });
            await DataIngestion.insertAsync(di);

            if (cbxSelector.SelectedIndex == 0)
            {
                List<DebitosAche> debitos = new List<DebitosAche>();

                var id = await DataIngestion.getLastCodeAsync();
                foreach (DataGridViewRow _row in dgvData.Rows)
                {
                    try
                    {
                        debitos.Add(new DebitosAche
                        {
                            idDataIngestion = id.ToString(),
                            Cod_EAN = _row.Cells["Cód# EAN"].Value?.ToString(),
                            Apresentacao = _row.Cells["Apresentação"].Value?.ToString(),
                            CNPJ_Distribuidor = _row.Cells["CNPJ Distribuidor"].Value?.ToString(),
                            Numero_NF = _row.Cells["Numero NF"].Value?.ToString(),
                            Qtde_Faturamento = _row.Cells["Qtde# Faturamento"].Value?.ToString(),
                            Valor_Bruto = _row.Cells["Valor Bruto"].Value?.ToString().Replace(",","."),
                            prct_Desconto = _row.Cells["% Desconto"].Value?.ToString().Replace(",", "."),
                            prct_Desconto_Padrao = _row.Cells["% Desconto Padrão"].Value?.ToString().Replace(",", "."),
                            prct_Custo_Margem = string.IsNullOrEmpty(_row.Cells["% Custo de Margem"].Value?.ToString().Replace(",", ".")) ? "0.0" : _row.Cells["% Custo de Margem"].Value?.ToString().Replace(",", "."),
                            prct_Debito = string.IsNullOrEmpty(_row.Cells["% Débito"].Value?.ToString()) ? "0.0" : _row.Cells["% Débito"].Value?.ToString().Replace(",", "."),
                            Valor_Debito_Bruto = _row.Cells["Valor Débito Bruto"].Value?.ToString().Replace(",", "."),
                            prct_Repasse_ICMS = _row.Cells["% Repasse ICMS"].Value?.ToString().Replace(",", "."),
                            Valor_Repasse_ICMS = _row.Cells["Valor Repasse ICMS"].Value?.ToString().Replace(",", "."),
                            Valor_Debito_Final = _row.Cells["Valor Débito Final"].Value?.ToString().Replace(",", "."),
                            RF_Ajuste_Tributario = _row.Cells["RF Ajuste Tributário"].Value?.ToString().Replace(",", "."),
                            RF_Valor_Debito = _row.Cells["RF Valor Débito"].Value?.ToString().Replace(",", "."),
                            RF_Aliquota_Interestadual = _row.Cells["RF Aliquota Interestadual"].Value?.ToString().Replace(",", "."),
                            RF_PISCofins = _row.Cells["RF PISCofins"].Value?.ToString().Replace(",", "."),
                            RF_RedutorICMS = _row.Cells["RF RedutorICMS"].Value?.ToString().Replace(",", "."),
                        });
                    }
                    catch (Exception ex)
                    {
                        CustomNotification.defaultError(ex.Message);
                        continue; // Pula para a próxima linha em caso de erro
                    }
                }

                try
                {
                    await DebitosAche.insertAsync(debitos);
                    saved = true;
                }
                catch (Exception ex)
                {
                    saved = false;
                    CustomNotification.defaultError(ex.Message);
                }
            }

            if (saved)
                CustomNotification.defaultInformation();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Archives | *.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                txtArchiveName.Text = ofd.FileName;
                getData();
                if (!layoutValidation())
                {
                    CustomNotification.defaultAlert("Layout inválido");
                    btnSave.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
        }

        /** Configure TexBox **/
        private void ConfigureTextBoxProperties()
        {
            txtArchiveName.ReadOnly = true;
            txtArchiveName.TabStop = false;
            txtName.Visible = false;
        }

        /** Configure Label **/
        private void ConfigureLabelProperties()
        {
            lblName.Visible = false;
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.MultiSelect = true;
        }
    }
}
