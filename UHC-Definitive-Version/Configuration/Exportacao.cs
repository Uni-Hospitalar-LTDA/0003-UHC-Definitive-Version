using ClosedXML.Excel;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace UHC3_Definitive_Version.Configuration
{
    public class Exportacao
    {


        /** Excel Exportation **/
        public static void abrirDataGridViewEmExcel(DataGridView _dgv)
        {
            //Copy to clipboard
            _dgv.SelectAll();
            _dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            DataObject dataObj = _dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

            Excel.Application app;
            Excel.Workbook MapaChiesi;
            Excel.Worksheet abaEstoque;

            object misValue = System.Reflection.Missing.Value;
            app = new Excel.Application();
            app.Visible = true;
            MapaChiesi = app.Workbooks.Add(misValue);
            abaEstoque = (Excel.Worksheet)MapaChiesi.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)abaEstoque.Cells[1, 1];
            CR.Rows.AutoFit();
            CR.Select();
            Excel.Range rng1 = abaEstoque.get_Range("A1", "Z1");
            rng1.Font.Bold = true;
            rng1.Font.ColorIndex = 3;
            rng1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            abaEstoque.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            abaEstoque.Name = "Arquivo"; //Adicionando o nome a planilha

            //Identar tabela
            foreach (Excel.Worksheet wrkst in MapaChiesi.Worksheets)
            {
                Excel.Range usedrange = wrkst.UsedRange;
                usedrange.Columns.AutoFit();
            }
        }
        public static void exportarExcelComContaLinhas(DataGridView dataGridView, string filename, Action<int> updateProgress, CancellationToken cancellationToken)
        {
            try
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn col in dataGridView.Columns)
                {
                    dt.Columns.Add(col.HeaderText);
                }

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string cellValue = cell.Value?.ToString();
                        if (cellValue != null && cellValue.StartsWith("R$"))
                        {
                            cellValue = cellValue.Replace("R$", "").Trim();
                            if (double.TryParse(cellValue, out double numericValue))
                            {
                                dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = numericValue;
                            }
                        }
                        else
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cellValue;
                        }
                    }

                    int progress = (int)(((float)(dt.Rows.Count) / dataGridView.Rows.Count) * 100);
                    updateProgress(progress);
                }

                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add(dt, "Sheet1");
                    int lastRowIndex = ws.LastRowUsed().RowNumber();

                    // Adding the row count at the end
                    ws.Cell(lastRowIndex + 1, 1).Value = "Total de Registros: ";
                    ws.Cell(lastRowIndex + 1, 2).Value = dt.Rows.Count;

                    workbook.SaveAs(filename);
                }
            }
            catch (OperationCanceledException)
            {
                // Operation was cancelled
            }
        }
        public static void exportarExcelComSoma(DataGridView dataGridView, string filepath, Action<int> updateProgress, CancellationToken cancellationToken)
        {
            if (dataGridView == null || dataGridView.Rows.Count == 0)
            {
                throw new ArgumentException("O DataGridView não pode ser nulo ou vazio.");
            }
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");

                var headerRange = worksheet.Range(1, 1, 1, dataGridView.Columns.Count);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.DarkGray;

                int totalRows = dataGridView.Rows.Count;
                int totalColumns = dataGridView.Columns.Count;

                for (int colIndex = 1; colIndex <= totalColumns; colIndex++)
                {
                    var cell = worksheet.Cell(1, colIndex);
                    cell.Value = dataGridView.Columns[colIndex - 1].HeaderText;
                }

                for (int rowIndex = 1; rowIndex <= totalRows; rowIndex++)
                {
                    for (int colIndex = 1; colIndex <= totalColumns; colIndex++)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                        }

                        var cell = worksheet.Cell(rowIndex + 1, colIndex);
                        var cellValue = dataGridView.Rows[rowIndex - 1].Cells[colIndex - 1].Value;

                        if (cellValue != null)
                        {
                            if (colIndex == totalColumns) // Última coluna
                            {
                                string stringValue = cellValue.ToString();

                                // Remover separadores e outros caracteres de formatação, se necessário
                                stringValue = stringValue.Replace(",", ".");

                                // Tente converter usando a cultura correta
                                if (double.TryParse(stringValue, NumberStyles.Any, new CultureInfo("en-US"), out double numericValue))
                                {
                                    cell.Value = numericValue;
                                    cell.Style.NumberFormat.SetFormat("#,##0.00"); // Formatação para a última coluna
                                }
                                else
                                {
                                    cell.Value = stringValue; // Se não puder converter, use o valor como está
                                }
                            }
                            else
                            {
                                cell.Value = cellValue.ToString();
                            }
                        }

                        if (rowIndex % 2 == 0)
                        {
                            cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                        }

                        updateProgress((int)(rowIndex * 100.0 / totalRows));
                    }
                }

                var lastColumnSumCell = worksheet.Cell(totalRows + 2, totalColumns);
                lastColumnSumCell.FormulaA1 = $"SUM({worksheet.Cell(2, totalColumns).Address}:{worksheet.Cell(totalRows + 1, totalColumns).Address})";
                lastColumnSumCell.Style.Font.Bold = true;
                lastColumnSumCell.Style.Fill.BackgroundColor = XLColor.Yellow;
                lastColumnSumCell.Style.NumberFormat.SetFormat("#,##0.00"); // Formatação para a célula de soma

                workbook.SaveAs(filepath);
            }
        }
    }
}