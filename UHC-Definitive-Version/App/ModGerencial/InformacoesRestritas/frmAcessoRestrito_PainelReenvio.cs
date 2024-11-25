using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.NewIqvia;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAcessoRestrito_PainelReenvio : CustomForm
    {
        /** Instance **/
        internal LogIqvia log = new LogIqvia();        
        List<FTP> Ftps = new List<FTP>();
               
        public frmAcessoRestrito_PainelReenvio()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();            
            ConfigureDateTimePickerProperties();
            ConfigureButtonProperties();
            ConfigureDataGridViewProperties();

            //Events
            ConfigureFormEvents();
        }

        /** Async Taks **/
        private async Task getFTPs()
        {
            Ftps = await FTP.getAllToListAsync();
        }
        private async Task getRestricoes()
        {
            dgvRestricoes.DataSource = (await IqviaRestriction.getAllEspecificoToDataTableAsync(log.Id,Convert.ToDateTime(log.DataArquivo)));
        }
        private async Task sendFTP()
        {
            if (clkListaColetores.CheckedItems.Count == 0)
            {
                CustomNotification.defaultAlert("Não há empresa selecionada");
                return;
            }

            if (CustomNotification.defaultQuestionAlert("Essa ação possui severas consequências, deseja seguir?") == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    btnSalvar.Enabled = false;
                    btnEnviar.Enabled = false;
                                           
                        

                        
                     

                        // Define o incremento proporcional por tarefa                        

                        // Iteração sobre as datas
                       
                            foreach (int index in clkListaColetores.CheckedIndices)
                            {
                                var ftp = Ftps[index];

                        int id = Convert.ToInt32(log.Id);
                                if (chkIgnorarRestricoes.Checked)
                        {
                            id = 0;
                        }
                                //Processa o envio consolidado
                                await ProcessAndLogAsync(
                                    ftp,
                                    Convert.ToDateTime(log.DataArquivo),
                                    Section.Unidade,
                                await IqviaLayout.exportarLayoutProdutoAsync(Convert.ToDateTime(log.DataArquivo),Convert.ToInt32(!chkIgnorarRestricoes.Checked),id),
                                await IqviaLayout.exportarLayoutClienteAsync(Convert.ToDateTime(log.DataArquivo), Convert.ToInt32(!chkIgnorarRestricoes.Checked), id),
                                await IqviaLayout.exportarLayoutVendasAsync(Convert.ToDateTime(log.DataArquivo), Convert.ToInt32(!chkIgnorarRestricoes.Checked), id)
                                );
                            }
                        

                        // Conclusão
                        CustomNotification.defaultInformation("Envio concluído!");
                    }
                                 
                catch (Exception ex)
                {
                    CustomNotification.defaultAlert($"Erro: {ex.Message}");
                }
                finally
                {
                    // Restauração do cursor e reset da ProgressBar
                    this.Cursor = Cursors.Default;
                    btnSalvar.Enabled = true;
                    btnEnviar.Enabled = true;

                }
            }
        }

        // Método auxiliar para processar e registrar os envios
        private async Task ProcessAndLogAsync(FTP ftp, DateTime date, string unidade, string layoutProduto, string layoutCliente, string layoutVendas)
        {
            try
            {
                // Envia o layout de Produto
                var resultadoProduto = "não marcado";
                if (chkProdutos.Checked)
                    resultadoProduto = await FTP.sendAsync(ftp, layoutProduto);


                // Envia o layout de Cliente
                var resultadoCliente = "não marcado";
                if (chkClientes.Checked) 
                    resultadoCliente= await FTP.sendAsync(ftp, layoutCliente);


                // Envia o layout de Vendas
                var resultadoVendas = "não marcado"; 
                if (chkVendas.Checked)
                    resultadoVendas = await FTP.sendAsync(ftp, layoutVendas);


                // Consolida e insere no banco
                string restricoes = "Restrições ignoradas: " + chkIgnorarRestricoes.Checked.ToString();
                string qtdRestricoes = "Qtd. Restrições: " + dgvRestricoes.Rows.Count.ToString();
                string feedback = $"Envio manualizado:({restricoes};{qtdRestricoes}) Produto: {resultadoProduto}; Cliente: {resultadoCliente}; Vendas: {resultadoVendas}";
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
            }
        }


        //Sync Methods
        private void getInitialParameters()
        {
            txtIdLog.Text = log.Id;
            dtpDataArquivo.Value = Convert.ToDateTime(log.DataArquivo);
            txtUnidade.Text = Section.Unidade;
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmAcessoRestrito_PainelReenvio_Load;
        }
        private async void frmAcessoRestrito_PainelReenvio_Load(object sender, EventArgs e)
        {
            //Pré events
            await getFTPs();
            await getRestricoes();
            getInitialParameters();
            ConfigureCheckedListBoxAttributes();

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
        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtIdLog.ReadOnly();
            txtUnidade.ReadOnly();
        }

        /** Configure DateTimePicker **/
        private void ConfigureDateTimePickerProperties()
        {
            dtpDataArquivo.Enabled = false;
        }

        /** Confiugre DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvRestricoes.toDefault();
            
        }
        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
            btnEnviar.Click += btnEnviar_Click;
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            await sendFTP();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                btnEnviar.Enabled = false;
                btnSalvar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                if (chkProdutos.Checked)
                    await IqviaLayout.exportarLayoutProdutoAsync(Convert.ToDateTime(log.DataArquivo), Convert.ToInt32(chkIgnorarRestricoes.Checked), Convert.ToInt32(log.Id));
                if (chkClientes.Checked)
                    await IqviaLayout.exportarLayoutClienteAsync(Convert.ToDateTime(log.DataArquivo), Convert.ToInt32(chkIgnorarRestricoes.Checked), Convert.ToInt32(log.Id));
                if (chkVendas.Checked)
                    await IqviaLayout.exportarLayoutVendasAsync(Convert.ToDateTime(log.DataArquivo), Convert.ToInt32(chkIgnorarRestricoes.Checked), Convert.ToInt32(log.Id));

                CustomNotification.defaultInformation("Arquivos salvos com sucesso na pasta base (Appdata) !");
                btnEnviar.Enabled = true;
                btnSalvar.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            catch
            (Exception ex) 
            {
                CustomNotification.defaultError(ex.Message);
                }
            
            
        }
    }
}
