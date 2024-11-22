using System.Data;
using System.IO;
using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace UHC3_Definitive_Version.App.ModAdmistrativo.Fretes
{
    public partial class frmFretes_ConveresorDeLayout : CustomForm
    {
        public frmFretes_ConveresorDeLayout()
        {
            InitializeComponent();

            //Properties 
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();

            //Events
            ConfigureFormEvents();

        }


        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmFretes_ConversorDeLayout_Load;
        }
        private void frmFretes_ConversorDeLayout_Load(object sender, EventArgs e)
        {
            ConfigureButtonEvents();
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtArchive.ReadOnly = true;
            txtArchive.TabStop = false;
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnImport.Click += btnImport_Click;
            btnExport.Click += btnExport_Click;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFrete = new OpenFileDialog();
            ofdFrete.Filter = "Documento Excel|*.xlsx;*.xls";

            if (ofdFrete.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        string arquivo = ofdFrete.FileName;
                        DataSet output = LoadDataFromExcel(arquivo);

                        this.Invoke((Action)delegate
                        {
                            dgvData.DataSource = output.Tables[0];
                            dgvData.AutoGenerateColumns = true;
                            dgvData.toDefault();
                            dgvData.MultiSelect = true;
                        });
                    }
                    catch (Exception ex)
                    {
                        this.Invoke((Action)delegate
                        {
                            CustomNotification.defaultAlert(ex.Message);
                        });
                    }
                    finally
                    {
                        this.Invoke((Action)delegate
                        {
                            this.Cursor = Cursors.Default;
                        });
                    }
                });
            }
        }

        private DataSet LoadDataFromExcel(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            DataSet dataSet = new DataSet();

            using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
            {
                foreach (var worksheet in package.Workbook.Worksheets)
                {
                    DataTable dataTable = new DataTable(worksheet.Name);

                    // Add columns to the DataTable
                    foreach (var headerCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        string columnName = headerCell.Text;
                        string originalColumnName = columnName;
                        int duplicateIndex = 1;

                        // Ensure unique column names
                        while (dataTable.Columns.Contains(columnName))
                        {
                            columnName = $"{originalColumnName}_{duplicateIndex}";
                            duplicateIndex++;
                        }

                        dataTable.Columns.Add(columnName);
                    }

                    // Add rows to the DataTable
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        DataRow newRow = dataTable.NewRow();
                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            newRow[col - 1] = worksheet.Cells[row, col].Text;
                        }
                        dataTable.Rows.Add(newRow);
                    }

                    dataSet.Tables.Add(dataTable);
                }
            }

            return dataSet;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                Exportacao.toTXTseparatedByDotComma(dgvData);
            }
            else
            {
                CustomNotification.defaultAlert("Nenhum layout foi carregado.");
            }
        }
    }
}
