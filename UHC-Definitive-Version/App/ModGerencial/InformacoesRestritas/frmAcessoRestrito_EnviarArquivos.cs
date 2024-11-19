using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.NewIqvia;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAcessoRestrito_EnviarArquivos : CustomForm
    {
        /** Instance **/
        List<FTP> Ftps = new List<FTP>();

        public frmAcessoRestrito_EnviarArquivos()
        {
            InitializeComponent();

            //Properties 
            ConfigureFormProperties();
            ConfigureComboBoxProperties();
            ConfigureButtonProperties();
            ConfigureDataGridViewProperties();
            ConfigureProgressBarProperties();

            //Events 
            ConfigureFormEvents();
        }

        /** Async Taks **/
        private async Task getFTPs()
        {
            Ftps = await FTP.getAllToListAsync();
        }
        private async Task sendFTP()
        {
            if (clkListaColetores.CheckedItems.Count == 0)
            {
                CustomNotification.defaultAlert("Não há empresa selecionada");
                return;
            }
               
            if (CustomNotification.defaultQuestionAlert("Os arquivos gerados serão enviados com as restrições vigentes, deseja seguir?") == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    if (cbxTipoArquivo.SelectedItem?.ToString() == "IMS (FTP)")
                    {
                        // Seleção da Unidade
                        string unidade = Section.Unidade;
                        Section.Unidade = cbxEmpresa.SelectedItem?.ToString();

                        // Obtém as datas selecionadas nos DateTimePickers
                        DateTime startDate = dtp0.Value.Date;
                        DateTime endDate = dtpf.Value.Date;

                        // Validação do intervalo de datas
                        if (startDate > endDate)
                        {
                            CustomNotification.defaultAlert("A data inicial não pode ser maior que a data final.");
                            return;
                        }

                        // Configuração da ProgressBar
                        int totalDays = (endDate - startDate).Days + 1; // Total de dias no intervalo
                        int totalTasks = totalDays * clkListaColetores.CheckedIndices.Count * 3; // Total de envios (Produto, Cliente, Vendas)
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = 1000; // Valor fixo
                        progressBar1.Value = 0;
                        progressBar1.Visible = true;

                        // Define o incremento proporcional por tarefa
                        double stepIncrement = (double)progressBar1.Maximum / totalTasks;

                        // Iteração sobre as datas
                        foreach (DateTime currentDate in GetDateRange(startDate, endDate))
                        {
                            foreach (int index in clkListaColetores.CheckedIndices)
                            {
                                var ftp = Ftps[index];

                                // Processa o envio consolidado
                                await ProcessAndLogAsync(
                                    ftp,
                                    currentDate,
                                    unidade,
                                    await IqviaLayout.exportarLayoutProdutoAsync(currentDate),
                                    await IqviaLayout.exportarLayoutClienteAsync(currentDate),
                                    await IqviaLayout.exportarLayoutVendasAsync(currentDate),
                                    stepIncrement
                                );
                            }
                        }

                        // Conclusão
                        CustomNotification.defaultInformation("Envio concluído!");
                    }
                    else
                    {
                        CustomNotification.defaultAlert("Sem correspondência");
                    }
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultAlert($"Erro: {ex.Message}");
                }
                finally
                {
                    // Restauração do cursor e reset da ProgressBar
                    this.Cursor = Cursors.Default;
                    progressBar1.Visible = false;
                    progressBar1.Value = 0;
                }
            }
        }






        // Método auxiliar para processar e registrar os envios
        private async Task ProcessAndLogAsync(FTP ftp, DateTime date, string unidade, string layoutProduto, string layoutCliente, string layoutVendas, double stepIncrement)
        {
            try
            {
                // Envia o layout de Produto
                var resultadoProduto = await FTP.sendAsync(ftp, layoutProduto);
                Invoke(new Action(() =>
                {
                    progressBar1.Value = Math.Min(progressBar1.Value + (int)stepIncrement, progressBar1.Maximum);
                }));

                // Envia o layout de Cliente
                var resultadoCliente = await FTP.sendAsync(ftp, layoutCliente);
                Invoke(new Action(() =>
                {
                    progressBar1.Value = Math.Min(progressBar1.Value + (int)stepIncrement, progressBar1.Maximum);
                }));

                // Envia o layout de Vendas
                var resultadoVendas = await FTP.sendAsync(ftp, layoutVendas);
                Invoke(new Action(() =>
                {
                    progressBar1.Value = Math.Min(progressBar1.Value + (int)stepIncrement, progressBar1.Maximum);
                }));

                // Consolida e insere no banco
                string feedback = $"Produto: {resultadoProduto}; Cliente: {resultadoCliente}; Vendas: {resultadoVendas}";
                await LogIqvia.insertAsync(new LogIqvia
                {
                    idFtp = ftp.id,
                    Feedback = feedback,
                    DataArquivo = date.ToString("yyyy-MM-dd"),
                    DataEnvio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    idUser = Section.idUsuario,
                    LayoutProduto = resultadoProduto.Contains("sucesso") ? "1" : "0",
                    LayoutCliente = resultadoCliente.Contains("sucesso") ? "1" : "0",
                    LayoutVendas = resultadoVendas.Contains("sucesso") ? "1" : "0"
                });
                int x = await LogIqvia.getLastCodeAsync();

                var Restricoes = await IqviaRestriction.getAllToListAsync(date);

                List<LogIqvia_IqviaRestriction> ll = new List<LogIqvia_IqviaRestriction>();
                foreach (var restriction in Restricoes)
                {
                    ll.Add(new LogIqvia_IqviaRestriction
                    {
                        idLogIqvia = x.ToString(),
                        idIqviaRestriction = restriction.Id
                    });
                }
                await LogIqvia_IqviaRestriction.insertAsync(ll);
                // Atualiza o DataGridView
                Invoke(new Action(() =>
                {
                    dgvData.Rows.Add(date.ToString("dd-MM-yyyy"), unidade, feedback, DateTime.Now);
                    dgvData.FirstDisplayedScrollingRowIndex = dgvData.Rows.Count - 1;
                }));
            }
            catch (Exception ex)
            {
                // Trata erros e insere no log
                await LogIqvia.insertAsync(new LogIqvia
                {
                    idFtp = ftp.id,
                    Feedback = $"Erro ao enviar: {ex.Message}",
                    DataArquivo = date.ToString("yyyy-MM-dd"),
                    DataEnvio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    idUser = Section.idUsuario,
                    LayoutProduto = "0",
                    LayoutCliente = "0",
                    LayoutVendas = "0"
                });
                int x = await LogIqvia.getLastCodeAsync();

                var Restricoes = await IqviaRestriction.getAllToListAsync(date);

                List<LogIqvia_IqviaRestriction> ll = new List<LogIqvia_IqviaRestriction>();
                foreach (var restriction in Restricoes)
                {
                    ll.Add(new LogIqvia_IqviaRestriction
                    {
                        idLogIqvia = x.ToString(),
                        idIqviaRestriction = restriction.Id
                    });
                }
                await LogIqvia_IqviaRestriction.insertAsync(ll);


                Invoke(new Action(() =>
                {
                    dgvData.Rows.Add(date.ToString("dd-MM-yyyy"), unidade, $"Erro ao enviar: {ex.Message}", DateTime.Now);
                    dgvData.FirstDisplayedScrollingRowIndex = dgvData.Rows.Count - 1;
                }));
            }
        }






        // Método para gerar o intervalo de datas, garantindo inclusão do último dia
        private IEnumerable<DateTime> GetDateRange(DateTime start, DateTime end)
        {
            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                yield return date;
            }
        }




        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmAcessoRestrito_EnviarArquivos_Load;
        }
        private async void frmAcessoRestrito_EnviarArquivos_Load(object sender, EventArgs e)
        {

            //Attributes pré events
            await getFTPs();
            ConfigureCheckedListBoxAttributes();
            ConfigureComboBoxAttributes();
            ConfigureDateTimePickerAttributes();

            


            //Events
            ConfigureButtonEvents();

        }

        /** CheckedBox Configuration **/
        private void ConfigureCheckedListBoxAttributes()
        {
          
            // Supondo que Ftps é uma lista de objetos com a propriedade "description"
            var descriptions = Ftps.Select(ftp => ftp.description).ToArray();
            clkListaColetores.Items.AddRange(descriptions);

        }


        /** ComboBox Configuration **/
        private void ConfigureComboBoxAttributes()
        {
            cbxTipoArquivo.Items.AddRange(new object[] {"IMS (FTP)", "Tradefy (FTP)" });
            cbxTipoArquivo.SelectedIndex = 0;
        }
        private void ConfigureComboBoxProperties()
        {
            cbxTipoArquivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbxEmpresa.toDefaultSeletorEmpresa();
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnEnviar.Click += btnEnviar_Click;
        }
        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            
            await sendFTP();
        }

        /** DataGridView Configuration **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.Columns.Add("Date","Data");
            dgvData.Columns.Add("Unidade", "Empresa");
            dgvData.Columns.Add("Log", "Log");
            dgvData.Columns.Add("DateTime", "Data-Hora");
        }

        /** DateTimePicker Configuration **/
        private void ConfigureDateTimePickerAttributes()
        {
            dtp0.Value = DateTime.Now;
            dtpf.Value = DateTime.Now;
        }

        /** ProgressBar Configuration **/
        private void ConfigureProgressBarProperties()
        {
            progressBar1.Visible = false;
        }
    }
}
