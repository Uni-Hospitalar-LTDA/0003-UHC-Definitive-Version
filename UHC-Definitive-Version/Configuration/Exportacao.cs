using ClosedXML.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using UHC3_Definitive_Version.Customization;
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



        /** Inerentes ao envio de e-mails **/
        public static byte[] toByteExcelFromArchives(List<Archive> archives)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                foreach (var archive in archives)
                {
                    wb.Worksheets.Add(archive.data, archive.description);
                }

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    wb.SaveAs(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
        public static byte[] toByteExcelFromArchive(Archive archive)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(archive.data, archive.description);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    wb.SaveAs(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }

        /** XML **/
        public static void toXml(DataGridView dataGridView, string filename)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML File|*.xml";
            saveFileDialog.Title = "Salvar arquivo XML";
            saveFileDialog.FileName = filename;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t",
                    NewLineChars = Environment.NewLine,
                    NewLineHandling = NewLineHandling.Replace
                };

                using (XmlWriter writer = XmlWriter.Create(saveFileDialog.FileName, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Rows");

                    foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
                    {
                        if (!dataGridViewRow.IsNewRow) // Ignore the new row used for adding data
                        {
                            writer.WriteStartElement("Row");

                            foreach (DataGridViewCell cell in dataGridViewRow.Cells)
                            {
                                writer.WriteStartElement(dataGridView.Columns[cell.ColumnIndex].Name);
                                if (cell.Value != null)
                                {
                                    writer.WriteString(cell.Value?.ToString());
                                }
                                writer.WriteEndElement();
                            }

                            writer.WriteEndElement();
                        }
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }
        public static string toXmlWithPath(DataTable dataTable, string filename)
        {
            try
            {
                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), filename + ".xml");

                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t",
                    NewLineChars = Environment.NewLine,
                    NewLineHandling = NewLineHandling.Replace
                };
                using (XmlWriter writer = XmlWriter.Create(path, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Rows");


                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        writer.WriteStartElement("Row");

                        foreach (DataColumn column in dataTable.Columns)
                        {
                            writer.WriteStartElement(column.ColumnName.substituirCaracteresEspeciais().Replace(" ", string.Empty));
                            var cellValue = dataRow[column];
                            if (cellValue != null)
                            {
                                writer.WriteString(cellValue.ToString());
                            }
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                return path;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /** Json **/
        public static void toJson(DataGridView dataGridView, string filename)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON File|*.json";
            saveFileDialog.Title = "Salvar arquivo JSON";
            saveFileDialog.FileName = filename;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;

                foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataGridViewCell cell in dataGridViewRow.Cells)
                    {
                        row[dataGridView.Columns[cell.ColumnIndex].Name] = cell.Value;
                    }
                    rows.Add(row);
                }

                string json = JsonConvert.SerializeObject(rows, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }
        public static string toJsonWithPath(DataTable dataTable, string filename)
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), filename + ".json");

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn column in dataTable.Columns)
                {
                    row[column.ColumnName] = dataRow[column];
                }
                rows.Add(row);
            }

            string json = JsonConvert.SerializeObject(rows, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, json);
            return path;
        }


        /** txt **/
        /** Método de exportação atualizado **/
        public static void toTXTseparatedByDotComma(DataGridView _dgv)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                FileName = $"{Guid.NewGuid().ToString()}-{DateTime.Now:ddMMyy-hhmmss}.txt",
                Filter = "Arquivo de texto (*.txt)|*.txt"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        foreach (DataGridViewRow dgvRow in _dgv.Rows)
                        {
                            if (dgvRow.Cells[10].Value == null || dgvRow.Cells[10].Value is DBNull) continue;
                            string primaryKey = dgvRow.Cells[10].Value.ToString().Replace("-1", "");

                            if (dgvRow.Cells[11].Value != null && !(dgvRow.Cells[11].Value is DBNull) && dgvRow.Cells[11].Value.ToString().Contains("/"))
                            {
                                string[] codes = dgvRow.Cells[11].Value.ToString().Split('/');
                                double originalValue;
                                if (double.TryParse(dgvRow.Cells[49].Value?.ToString(), out originalValue))
                                {
                                    double valueForEachCode = originalValue / codes.Length;

                                    foreach (var code in codes)
                                    {
                                        string line = GenerateLine(primaryKey, code, valueForEachCode);
                                        sw.WriteLine(line);
                                    }
                                }
                            }
                            else
                            {
                                string code = dgvRow.Cells[11].Value == null || dgvRow.Cells[11].Value is DBNull ? string.Empty : dgvRow.Cells[11].Value.ToString();
                                double value;
                                if (double.TryParse(dgvRow.Cells[49].Value?.ToString(), out value))
                                {
                                    string line = GenerateLine(primaryKey, code, value);
                                    sw.WriteLine(line);
                                }
                            }
                        }
                    }

                    // Mensagem de confirmação
                    CustomNotification.defaultInformation("Exportado com sucesso");
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                }
            }
        }

        private static string GenerateLine(string primaryKey, string code, double value)
        {
            // Tratamento de valores nulos e conversão para string
            string primaryKeyStr = primaryKey ?? string.Empty;
            string codeStr = code ?? string.Empty;
            string valueStr = value.ToString("F2").Replace(".", ",");

            return $"{primaryKeyStr};;{codeStr};;{valueStr};;";
        }
    }
}