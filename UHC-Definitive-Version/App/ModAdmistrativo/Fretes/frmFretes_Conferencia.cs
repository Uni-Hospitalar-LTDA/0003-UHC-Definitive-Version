using System.Collections.Generic;
using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.Customization;
using System.Data;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Domain.Entities;
using System.Linq;
using System.Text;
using System.IO;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.App.Telas_Genericas;

namespace UHC3_Definitive_Version.App.ModAdmistrativo.Fretes
{
    public partial class frmFretes_Conferencia : CustomForm
    {
        public frmFretes_Conferencia()
        {
            InitializeComponent();

            ConfigureFormProperties(); 
            ConfigureButtonProperties();
            ConfigureDataGridViewProperties();
            ConfigureTextBoxProperties();
            ConfigureListBoxProperties();
            ConfigureLabelProperties();

            ConfigureFormEvents();
            
        }


        /** Async Methods **/
        private async Task getConferenceListAsync()
        {

            DataTable dt = await ShippingConference.getUncheckedShippingConferenceAsync(dtpInitialDate.Value, dtpFinalDate.Value, txtTransporterId.Text, txtNF.Text);
            dgvData.Invoke((Action)delegate
            {
                dgvData.DataSource = dt;
                dgvData.AutoResizeColumns();
            });


            infoCalculate();
        }
        private async Task saveAsync()
        {

            if (Convert.ToInt32(txtTotalCheck.Text) > 0)
            {
                List<ShippingConference> sc = new List<ShippingConference>();

                foreach (DataGridViewRow _row in dgvData.Rows)
                {
                    if (!string.IsNullOrEmpty(_row.Cells[10].Value?.ToString()))
                    {
                        sc.Add(new ShippingConference
                        {
                            Num_Nota = _row.Cells[0].Value.ToString()
                           ,
                            Num_CTE = _row.Cells[10].Value.ToString()
                           ,
                            idTransporter = _row.Cells[1].Value.ToString()
                           ,
                            calculatedValue = _row.Cells[8].Value.ToString()
                           ,
                            realValue = _row.Cells[9].Value.ToString()
                           ,
                            observation = _row.Cells[11].Value.ToString()

                        });

                    }
                }


                try
                {
                    await ShippingConference.insertAsync(sc);
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.WaitCursor;
                    await getConferenceListAsync();
                    this.Cursor = Cursors.Default;
                }
            }

        }

        /** Sync Methods **/
        private void calculate(string term)
        {
            try
            {
                // Função auxiliar para verificar se a expressão já contém adição ou subtração
                bool ContainsAddOrSub(string expr)
                {
                    return expr.Contains(" + ") || expr.Contains(" - ");
                }

                if (term == "add")
                {
                    txtCalc_Log.Text += txtCalc_Display.Text + " + ";
                    txtCalc_Display.Text = string.Empty;
                }
                else if (term == "sub")
                {
                    txtCalc_Log.Text += txtCalc_Display.Text + " - ";
                    txtCalc_Display.Text = string.Empty;
                }
                else if (term == "div" || term == "mult")
                {
                    if (ContainsAddOrSub(txtCalc_Log.Text))
                    {
                        txtCalc_Log.Text = "(" + txtCalc_Log.Text.TrimEnd() + txtCalc_Display.Text + " )" + (term == "div" ? " / " : " * ");
                    }
                    else
                    {
                        txtCalc_Log.Text += txtCalc_Display.Text + (term == "div" ? " / " : " * ");
                    }
                    txtCalc_Display.Text = string.Empty;
                }
                else if (term == "equal")
                {
                    txtCalc_Log.Text += txtCalc_Display.Text;
                    txtCalc_Display.Text = calculateExpression(txtCalc_Log.Text).ToString("N2");
                    txtCalc_Log.Text = string.Empty;
                    txtCalc_Display.ReadOnly = true;
                    txtCalc_Log.ReadOnly = true;
                }
                else if (term == "del")
                {
                    txtCalc_Display.Text = string.Empty;
                    txtCalc_Display.ReadOnly = false;
                    txtCalc_Log.ReadOnly = false;
                }
            }
            catch (Exception)
            {
                btnCalc_Clear_Click(btnCalc_Clear, new EventArgs());
            }
        }
        private void setDataGridViewColor()
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells[8].Value != null && row.Cells[9].Value != null)
                {
                    double value8;
                    double value9;

                    if (double.TryParse(row.Cells[8].Value.ToString(), out value8) &&
                        double.TryParse(row.Cells[9].Value.ToString(), out value9))
                    {
                        if (row.DefaultCellStyle.BackColor != System.Drawing.Color.DarkOliveGreen)
                        {
                            if (value8 != value9)
                            {
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.IndianRed;
                            }
                            else if (row.Cells[10].Value != null && !string.IsNullOrWhiteSpace(row.Cells[10].Value.ToString()))
                            {
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.PaleGoldenrod;
                            }
                        }
                    }
                }
            }
        }
        private void calculatePercent()
        {
            double percentageValue = string.IsNullOrEmpty(txtPercentageValue.Text) ? 0.0 : Convert.ToDouble(txtPercentageValue.Text);
            double percentagePercent = string.IsNullOrEmpty(txtPercentagePercent.Text) ? 0.0 : Convert.ToDouble(txtPercentagePercent.Text);
            try
            {
                txtPercentageResult.Text = (percentageValue * (percentagePercent / 100)).ToString("C2"); 
            }
            catch
            {
                txtPercentageValue.Text = 0.0.ToString("C2");
                txtPercentagePercent.Text = 0.0.ToString("C2");
                txtPercentageResult.Text = 0.0.ToString("C2");
            }
        }
        private double calculateExpression(string expression)
        {
            while (expression.Contains("("))
            {
                int lastOpenParenthesis = expression.LastIndexOf("(");
                int firstCloseParenthesisAfterLastOpen = expression.IndexOf(")", lastOpenParenthesis);
                if (firstCloseParenthesisAfterLastOpen == -1)
                {
                    throw new Exception("Parênteses desequilibrados");
                }

                string innerExpression = expression.Substring(lastOpenParenthesis + 1, firstCloseParenthesisAfterLastOpen - lastOpenParenthesis - 1);
                double innerValue = calculateSimpleExpression(innerExpression);

                expression = expression.Substring(0, lastOpenParenthesis) +
                             innerValue.ToString() +
                             expression.Substring(firstCloseParenthesisAfterLastOpen + 1);
            }
            return calculateSimpleExpression(expression);
        }
        private double calculateSimpleExpression(string expression)
        {
            if (expression.EndsWith("+") || expression.EndsWith("-") || expression.EndsWith("*") || expression.EndsWith("/") || expression.EndsWith("%"))
            {
                expression = expression.Substring(0, expression.Length - 1);
            }

            List<double> numbers = new List<double>();
            List<char> operations = new List<char>();

            StringBuilder currentNumber = new StringBuilder();
            bool isPercentage = false;

            foreach (char c in expression)
            {
                if (char.IsDigit(c) || c == ',' || c == '.')
                {
                    currentNumber.Append(c);
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/' || c == '%')
                {
                    if (currentNumber.Length > 0)
                    {
                        if (double.TryParse(currentNumber.ToString(), out double parsedNumber))
                        {
                            if (isPercentage)
                            {
                                parsedNumber = numbers.Last() * (parsedNumber / 100);
                                if (operations.Count > 0)
                                {
                                    char lastOperation = operations.Last();
                                    if (lastOperation == '+')
                                    {
                                        numbers[numbers.Count - 1] += parsedNumber;
                                    }
                                    else if (lastOperation == '-')
                                    {
                                        numbers[numbers.Count - 1] -= parsedNumber;
                                    }
                                    else if (lastOperation == '*')
                                    {
                                        numbers[numbers.Count - 1] *= parsedNumber;
                                    }
                                    else if (lastOperation == '/')
                                    {
                                        numbers[numbers.Count - 1] /= parsedNumber;
                                    }
                                }
                                operations.RemoveAt(operations.Count - 1);
                            }
                            else
                            {
                                numbers.Add(parsedNumber);
                            }

                            currentNumber.Clear();
                            isPercentage = false;
                        }
                    }
                    if (c != '%')
                    {
                        operations.Add(c);
                    }
                    if (c == '%')
                    {
                        isPercentage = true;
                    }
                }
            }

            if (double.TryParse(currentNumber.ToString(), out double lastNumber))
            {
                numbers.Add(isPercentage ? lastNumber / 100 : lastNumber);
            }

            for (int i = 0; i < operations.Count; i++)
            {
                if (operations[i] == '*' || operations[i] == '/')
                {
                    double result = operations[i] == '*' ? numbers[i] * numbers[i + 1] : numbers[i] / numbers[i + 1];
                    numbers[i] = result;
                    numbers.RemoveAt(i + 1);
                    operations.RemoveAt(i);
                    i--;
                }
            }

            double sum = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (operations[i - 1] == '+')
                {
                    sum += numbers[i];
                }
                else if (operations[i - 1] == '-')
                {
                    sum -= numbers[i];
                }
            }

            return sum;
        }
        private void infoCalculate()
        {
            txtTotalQuantity.Invoke((Action)delegate
            {
                txtTotalQuantity.Text = dgvData.Rows.Count.ToString("N0");

            });
            int qtdCheck = 0;
            int qtdUncheck = 0;
            double Value = 0.0;
            double ValueChecked = 0.0;
            foreach (DataGridViewRow _row in dgvData.Rows)
            {
                if (string.IsNullOrEmpty(_row.Cells[10].Value.ToString()))
                    qtdUncheck++;
                else
                    qtdCheck++;

                Value += Convert.ToDouble(_row.Cells[9].Value);
                if (!string.IsNullOrEmpty(_row.Cells[10].Value?.ToString()))
                    ValueChecked += Convert.ToDouble(_row.Cells[9].Value);
            }
            txtTotalCheck.Invoke((Action)delegate
            {
                txtTotalCheck.Text = qtdCheck.ToString("N0");
            });

            txtTotalUnchecked.Invoke((Action)delegate
            {
                txtTotalUnchecked.Text = qtdUncheck.ToString("N0");
            });
            txtTotalValue.Invoke((Action)delegate
            {
                txtTotalValue.Text = Value.ToString("C2");
            });
            txtTotalChecked.Invoke((Action)delegate
            {
                txtTotalChecked.Text = ValueChecked.ToString("C2");
            });
        }

        private void ConfigureDateTimePickerAttributes()
        {
            dtpFinalDate.Value = DateTime.Now;
            dtpInitialDate.Value = DateTime.Now.AddDays(-30);
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.ReadOnly = true;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.MultiSelect = true;

        }
        private async void ConfigureDataGridViewAttributes()
        {
            this.Cursor = Cursors.WaitCursor;
            await Task.Factory.StartNew(() => getConferenceListAsync());
            this.Cursor = Cursors.Default;

            dgvData.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (col.Index != (dgvData.Columns.Count - 2) && col.Index != dgvData.Columns.Count - 3)
                {
                    col.ReadOnly = true;
                }
            }
            AjustarDataGridView(dgvData);
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvData.CellEndEdit += dgvData_EndOfEdit;
            dgvData.CellEnter += dgvData_CellEnter;
            dgvData.DoubleClick += dgvData_DoubleClick;
            dgvData.ColumnHeaderMouseClick += dgvData_ColumnHeaderMouseClick;
            dgvData.KeyDown += dgvData_KeyDown;
        }
        private void dgvData_ColumnHeaderMouseClick(object sender, EventArgs e)
        {
            setDataGridViewColor();
        }
        private void dgvData_EndOfEdit(object sender, EventArgs e)
        {
            dgvData.AutoResizeColumns();
            infoCalculate();
            setDataGridViewColor();


        }
        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (dgvData.CurrentCell.ColumnIndex == 10)
                {
                    dgvData.CurrentCell.Value = string.Empty;
                    dgvData.CurrentRow.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }
        private void dgvData_CellEnter(object sander, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                txtAppliedPercentage.Text = (Convert.ToDouble(dgvData.CurrentRow.Cells[8].Value)
                    / Convert.ToDouble(dgvData.CurrentRow.Cells[6].Value)).ToString("P4");
            }
        }
        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                txtPercentageValue.Text = dgvData.CurrentRow.Cells[6].Value.ToString();
            }
        }
        public static void AjustarDataGridView(DataGridView dataGridView)
        {
            // Definir as configurações de coluna para cada coluna do DataGridView

            // Coluna 07 - Valores em Moeda (R$) com 2 casas decimais
            dataGridView.Columns[6].DefaultCellStyle.Format = "C2";

            // Coluna 08 - Valores em %
            dataGridView.Columns[7].DefaultCellStyle.Format = "P";

            // Coluna 09 - Valores em Moeda (R$) com 2 casas decimais
            dataGridView.Columns[8].DefaultCellStyle.Format = "C2";

            // Coluna 10 - Campo editável, aceita somente números decimais
            DataGridViewTextBoxColumn coluna10 = (DataGridViewTextBoxColumn)dataGridView.Columns[9];
            coluna10.DefaultCellStyle.Format = "C2";
            coluna10.DefaultCellStyle.NullValue = "0.00";
            coluna10.ValueType = typeof(decimal);

            // Adicione o evento KeyPress para a coluna 9
            dataGridView.EditingControlShowing += (sender, e) =>
            {
                if (dataGridView.CurrentCell.ColumnIndex == 9) // Verifique se a coluna é a coluna 9
                {
                    TextBox textBox = e.Control as TextBox;
                    try
                    {
                        if (textBox != null)
                        {
                            textBox.KeyPress += (s, eArgs) =>
                            {
                                if (!char.IsControl(eArgs.KeyChar) && !char.IsDigit(eArgs.KeyChar) && eArgs.KeyChar != '.' && eArgs.KeyChar != ',')
                                {
                                    eArgs.Handled = true;
                                }
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomNotification.defaultAlert(ex.Message);
                    }
                }
            };

            // Configuração para a coluna 11 - Campo editável e aceita somente números
            DataGridViewTextBoxColumn coluna11 = (DataGridViewTextBoxColumn)dataGridView.Columns[10];
            coluna11.DefaultCellStyle.Format = "";
            coluna11.ValueType = typeof(string);

            dataGridView.EditingControlShowing += (sender, e) =>
            {
                if (dataGridView.CurrentCell.ColumnIndex == 10)
                {
                    TextBox textBox = e.Control as TextBox;
                    if (textBox != null)
                    {
                        // Desanexa qualquer evento existente para evitar duplicação
                        textBox.KeyPress -= TextBox_KeyPress;

                        // Anexa o evento
                        textBox.KeyPress += TextBox_KeyPress;
                    }
                }
            };
        }
        private static void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (char.IsControl(e.KeyChar))
            {
                // Permite backspace e outros caracteres de controle
                return;
            }

            string currentText = textBox.Text + e.KeyChar;

            // Limita a entrada para até 10 caracteres e somente dígitos
            if (currentText.Length > 10 || !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void btnMoreTransporter_Click(object sender, EventArgs e)
        {
            frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            frmConsultarTransportador.ShowDialog();
            txtTransporterId.Text = frmConsultarTransportador.extendedCode;
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmFretes_Conferencia_Load;
        }
        private void frmFretes_Conferencia_Load(object sender, EventArgs e)
        {
            ConfigureDateTimePickerAttributes();
            ConfigureDataGridViewAttributes();
            ConfigureDataGridViewEvents();
            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
            ConfigureListBoxEvents();
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtDefaultObservation.Anchor = AnchorStyles.Right | AnchorStyles.Top;


            /** Transproter description **/
            txtTransporterDescription.ReadOnly = true;
            txtTransporterDescription.TabStop = false;

            /** Transporter Id**/
            txtTransporterId.JustNumbers();
            txtTransporterId.MaxLength = 8;

            /** NF Filter **/
            txtNF.JustNumbers();
            txtNF.MaxLength = 12;

            /** Calculator Display **/
            txtCalc_Display.TextAlign = HorizontalAlignment.Right;
            txtCalc_Display.justDecimalNumbers();
            txtCalc_Display.MaxLength = 12;

            /** Calculadora (%) **/
            txtPercentagePercent.TextAlign = HorizontalAlignment.Right;
            txtPercentagePercent.justDecimalNumbers();
            txtPercentagePercent.MaxLength = 6;

            txtPercentageValue.TextAlign = HorizontalAlignment.Right;
            txtPercentageValue.justDecimalNumbers();
            txtPercentageValue.MaxLength = 16;


            txtPercentageResult.ReadOnly = true;
            txtPercentageResult.TabStop = false;

            txtAppliedPercentage.ReadOnly = true;
            txtAppliedPercentage.TabStop = false;



            txtTotalQuantity.ReadOnly = true;
            txtTotalQuantity.TabStop = false;

            txtTotalCheck.ReadOnly = true;
            txtTotalCheck.TabStop = false;

            txtTotalUnchecked.ReadOnly = true;
            txtTotalUnchecked.TabStop = false;

            txtTotalValue.ReadOnly = true;
            txtTotalValue.TabStop = false;

            txtTotalChecked.ReadOnly = true;
            txtTotalChecked.TabStop = false;


        }
        private void ConfigureTextBoxEvents()
        {
            txtCalc_Display.KeyDown += txtCalc_Display_KeyDown;
            txtPercentageValue.KeyDown += txtPercentage_KeyDown;
            txtPercentagePercent.KeyDown += txtPercentage_KeyDown;


            txtTransporterId.TextChanged += txtCodTransportador_TextChanged;
            txtTransporterDescription.TextChanged += txtDescricaoTransportador_TextChanged;
            txtTransporterDescription.DoubleClick += txtDescricaoTransportador_DoubleClick;

            txtTransporterId.KeyDown += searchWithEnter;
            dtpInitialDate.KeyDown += searchWithEnter;
            dtpFinalDate.KeyDown += searchWithEnter;
            txtNF.KeyDown += searchWithEnter;
        }
        private void txtPercentage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                calculatePercent();
            }
        }
        private void txtCalc_Display_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Add)
            {
                calculate("add");
            }
            else if (e.KeyData == Keys.Subtract)
            {
                calculate("sub");
            }
            else if (e.KeyData == Keys.Divide)
            {
                calculate("div");
            }
            else if (e.KeyData == Keys.Multiply)
            {
                calculate("mult");
            }
            else if (e.KeyCode == Keys.Delete)
            {
                calculate("del");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                calculate("equal");
            }
        }
        private async void txtCodTransportador_TextChanged(object sender, EventArgs e)
        {
            txtTransporterDescription.Text = await Transportadores_Externos.getDescriptionByCode(txtTransporterId.Text);
        }
        private async void txtDescricaoTransportador_TextChanged(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            if (!string.IsNullOrEmpty(txt.Text.Trim()))
            {
                btnImportLayout.Visible = true;
                this.Cursor = Cursors.WaitCursor;
                await getConferenceListAsync();
                this.Cursor = Cursors.Default;
            }
            else
            {
                btnImportLayout.Visible = false;
            }
        }
        private void txtDescricaoTransportador_DoubleClick(object sender, EventArgs e)
        {
            frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            frmConsultarTransportador.ShowDialog();
            txtTransporterId.Text = frmConsultarTransportador.extendedCode;
        }
        private async void searchWithEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                await getConferenceListAsync();
            }
        }

        /** Configure ListBox **/
        private void ConfigureListBoxEvents()
        {
            lsbExcept.DoubleClick += lsbExcept_DoubleClick;

        }
        private void ConfigureListBoxProperties()
        {
            lsbExcept.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        }
        private void lsbExcept_DoubleClick(object sender, EventArgs e)
        {
            if (lsbExcept.SelectedItem != null)
                txtDefaultObservation.Text = lsbExcept.SelectedItem.ToString();

        }

        /** Configure Labels **/
        private void ConfigureLabelProperties()
        {
            lblObservation.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            lblObservacaoPadrao.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        }

        /** Configure Button **/
        private void ConfigureButtonEvents()
        {
            btnCalc_1.Click += btnCalc_1_Click;
            btnCalc_2.Click += btnCalc_2_Click;
            btnCalc_3.Click += btnCalc_3_Click;
            btnCalc_4.Click += btnCalc_4_Click;
            btnCalc_5.Click += btnCalc_5_Click;
            btnCalc_6.Click += btnCalc_6_Click;
            btnCalc_7.Click += btnCalc_7_Click;
            btnCalc_8.Click += btnCalc_8_Click;
            btnCalc_9.Click += btnCalc_9_Click;
            btnCalc_0.Click += btnCalc_0_Click;


            btnCalc_Comma.Click += btnCalc_Comma_Click;

            btnCalc_Sum.Click += btnCalc_Sum_Click;
            btnCalc_Subs.Click += btnCalc_Subs_Click;
            btnCalc_Div.Click += btnCalc_Div_Click;
            btnCalc_Mult.Click += btnCalc_Mult_Click;
            btnCalc_BackSpace.Click += btnCalc_BackSpace_Click;
            btnCalc_Clear.Click += btnCalc_Clear_Click;
            btnCalc_Equal.Click += btnCalc_Equal_Click;


            btnPercentageResult.Click += btnPercentageResult_Click;
            btnApplyOnSelected.Click += btnApplyOnSelected_Click;
            btnImportLayout.Click += btnImportLayout_Click;
            btnSearch.Click += btnSearch_Click;
            btnSave.Click += btnSave_Click;


            //botão transportador
            btnMoreTransporter.Click += btnMoreTransporter_Click;
        }
        private void ConfigureButtonProperties()
        {
            btnImportLayout.Visible = false;
            btnClose.toDefaultCloseButton();


            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApplyOnSelected.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        }
        private void btnPercentageResult_Click(object sender, EventArgs e)
        {
            calculatePercent();
        }
        private void btnApplyOnSelected_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                if (string.IsNullOrEmpty(txtDefaultObservation.Text))
                {
                    CustomNotification.defaultAlert("Selecione ou digite uma mensagem.");
                    return;
                }
                foreach (DataGridViewRow _row in dgvData.SelectedRows)
                {
                    _row.DefaultCellStyle.BackColor = System.Drawing.Color.DarkOliveGreen;
                    _row.Cells[11].Value = txtDefaultObservation.Text;
                }
            }
        }
        private void btnImportLayout_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFrete = new OpenFileDialog();
            ofdFrete.Filter = "Documentos de texto|*.txt";
            if (ofdFrete.ShowDialog() != DialogResult.OK)
            {
                return; // cancelou o diálogo
            }

            string arq_Path = ofdFrete.FileName;
            try
            {
                using (StreamReader FluxoTexto = new StreamReader(arq_Path))
                {
                    while (!FluxoTexto.EndOfStream) // Enquanto não for o fim do arquivo
                    {
                        string LinhaTexto = FluxoTexto.ReadLine();
                        if (string.IsNullOrWhiteSpace(LinhaTexto)) continue; // Pula linhas vazias

                        // Dividir a linha por ";" para extrair os tokens
                        string[] tokens = LinhaTexto.Split(';');

                        // Verifica se temos tokens suficientes para evitar erros
                        if (tokens.Length < 2) continue;

                        // Encontrar a linha correspondente no DataGridView
                        foreach (DataGridViewRow row in dgvData.Rows)
                        {
                            if (row.Cells[0].Value?.ToString() == tokens[2]) // Compara token[1] com row.Cells[0]
                            {
                                // Suponhamos que você quer preencher a célula na coluna 9 com tokens[2] e a célula na coluna 10 com tokens[0]
                                // Ajuste os índices conforme necessário para o seu caso
                                row.Cells[9].Value = Convert.ToDouble(tokens[4]); // Atualiza a célula na coluna 9 com o valor de tokens[2]
                                row.Cells[10].Value = tokens[0]; // Atualiza a célula na coluna 10 com o valor de tokens[0]

                                // Adicione mais atualizações de células aqui conforme necessário
                                break; // Sai do loop após a atualização para evitar múltiplas atualizações desnecessárias
                            }
                        }
                    }
                    CustomNotification.defaultInformation();
                }

                infoCalculate(); // Atualiza informações após a importação (supondo que seja um método necessário após a importação)
            }
            catch (IOException ioExcept)
            {
                // Trata exceções de entrada/saída, como problemas ao ler o arquivo
                MessageBox.Show($"Erro ao ler o arquivo: {ioExcept.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            await getConferenceListAsync();
            this.Cursor = Cursors.Default;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTotalCheck.Text) > 0)
            {
                if (DialogResult.Yes == CustomNotification.defaultQuestionAlert($"Você irá salvar {txtTotalCheck.Text} registro(s), deseja continuar?"))
                    await saveAsync();
            }
            else
            {
                CustomNotification.defaultAlert("Não há nenhum registro para ser inserido.");
            }
        }
        private void btnCalc_1_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                txtCalc_Display.Text += "1";
        }
        private void btnCalc_2_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                txtCalc_Display.Text += "2";
        }
        private void btnCalc_3_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                txtCalc_Display.Text += "3";
        }
        private void btnCalc_4_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                txtCalc_Display.Text += "4";
        }
        private void btnCalc_5_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                txtCalc_Display.Text += "5";
        }
        private void btnCalc_6_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                txtCalc_Display.Text += "6";
        }
        private void btnCalc_7_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                txtCalc_Display.Text += "7";
        }
        private void btnCalc_8_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                txtCalc_Display.Text += "8";
        }
        private void btnCalc_9_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                txtCalc_Display.Text += "9";
        }
        private void btnCalc_0_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                txtCalc_Display.Text += "0";
        }
        private void btnCalc_Comma_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                txtCalc_Display.Text += ",";
        }
        private void btnCalc_Sum_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                calculate("add");
        }
        private void btnCalc_Subs_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                calculate("sub");
        }
        private void btnCalc_Div_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                calculate("div");
        }
        private void btnCalc_Mult_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                calculate("mult");
        }
        private void btnCalc_BackSpace_Click(object sender, EventArgs e)
        {
            if (txtCalc_Display.Text.Length > 0 && !txtCalc_Display.ReadOnly)
            {
                txtCalc_Display.Text = txtCalc_Display.Text.Substring(0, txtCalc_Display.Text.Length - 1);
            }
        }
        private void btnCalc_Clear_Click(object sender, EventArgs e)
        {
            txtCalc_Display.Text = "";
            txtCalc_Log.Text = string.Empty;
            txtCalc_Display.ReadOnly = false;
            txtCalc_Log.ReadOnly = false;

        }
        private void btnCalc_Equal_Click(object sender, EventArgs e)
        {
            if (!txtCalc_Display.ReadOnly)
                calculate("equal");
        }
    }
}
