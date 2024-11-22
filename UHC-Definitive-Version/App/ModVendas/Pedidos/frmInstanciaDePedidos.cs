using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.ModVendas.AnaliseVendas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Configuration.InterplayersWebApi;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;


namespace UHC3_Definitive_Version.App.ModVendas.Pedidos
{
    public partial class frmInstanciaDePedidos : CustomForm
    {

        List<Interplayers_Pfizer_Pedido> pedidosPfizer = new List<Interplayers_Pfizer_Pedido>();
        public frmInstanciaDePedidos()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureDataGridViewProperties();
            ConfigureButtonProperties();
            ConfigureProgressBarProperties();

            //Events
            ConfigureFormEvents();

        }

        /** Async Tasks **/
        private async Task getInterplayers_PedidoPfizer()
        {
            carregando(true);
            progressBar1.Value = 0;

            try
            {
                // Obtém a lista de pedidos
                var pedidosPfizer = await Interplayers_Pfizer_Pedido.getAllToListAsync(dtpDataInicial.Value, dtpDataFinal.Value);

                // Ordenar os pedidos pela coluna "Id" de forma decrescente
                pedidosPfizer = pedidosPfizer.OrderByDescending(p => Convert.ToInt32(p.id)).ToList();

                // Define o valor máximo da barra de progresso com base no número total de pedidos
                int totalPedidos = pedidosPfizer.Count;
                if (totalPedidos == 0)
                {
                    progressBar1.Maximum = 1; // Define um valor mínimo de 1 para evitar problemas
                }
                else
                {
                    progressBar1.Maximum = totalPedidos + 20; // Adiciona margem para credenciais e outras etapas
                }

                // Atualiza o progresso para 10% após obter a lista de pedidos
                progressBar1.Value = Math.Min(progressBar1.Value + 10, progressBar1.Maximum);

                // Obtém as credenciais para autenticação
                var cc_swagger = await CredenciaisSwagger.getToClassAsync("1");

                // Obtém o token de autenticação
                var token = await Token.POST(new Credentials
                {
                    UserLogin = cc_swagger.LoginSwagger,
                    Password = Cryptography.decrypt(cc_swagger.SenhaSwagger)
                });

                // Atualiza o progresso após obter o token
                progressBar1.Value = Math.Min(progressBar1.Value + 10, progressBar1.Maximum);

                // Progresso por pedido
                int progressIncrement = totalPedidos > 0 ? 60 / totalPedidos : 0; // Incrementa o progresso até 60%

                // Lista de tarefas para buscar os detalhes de cada pedido
                var tasks = pedidosPfizer.Select(async pedido =>
                {
                    var respostaPedido = await Pedido.GetPedidoPorIdAsync(pedido.PedidoPfizer, token, cc_swagger);
                    var status = respostaPedido?.Data?.FirstOrDefault()?.Status ?? "Indefinido"; // Captura o status, ou define como "Indefinido"

                    // Adiciona os dados à grade
                    dgvData.Invoke(new Action(() =>
                    {
                        dgvData.Rows.Add(Convert.ToInt32(pedido.id),
                            pedido.PedidoPfizer,
                            Convert.ToInt32(pedido.PedidoUni) == 1 ? string.Empty : pedido.PedidoUni,
                            pedido.Data_Registro,
                            AddSpaceBeforeSecondUppercase(status),
                            pedido.Base,
                            pedido.Fabricante);
                    }));

                    // Incrementa a `ProgressBar` conforme os pedidos são processados
                    dgvData.Invoke(new Action(() =>
                    {
                        progressBar1.Value = Math.Min(progressBar1.Value + progressIncrement, progressBar1.Maximum);
                    }));
                });

                // Executa todas as requisições de forma paralela
                await Task.WhenAll(tasks);

                // Ajusta automaticamente o tamanho das colunas
                dgvData.AutoResizeColumns();
                dgvData.Sort(dgvData.Columns[0], System.ComponentModel.ListSortDirection.Descending);

                // Define a `ProgressBar` como 100% ao final
                progressBar1.Value = progressBar1.Maximum;
                CustomNotification.defaultInformation();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                carregando(false); // Finaliza o efeito de carregamento
            }
        }

        /** Sync Methods **/        
        public string AddSpaceBeforeSecondUppercase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            int upperCaseCount = 0;
            for (int i = 1; i < input.Length; i++) // Começa em 1, já que a primeira letra pode ser maiúscula
            {
                if (char.IsUpper(input[i]))
                {
                    upperCaseCount++;

                    // Verifica se encontrou a segunda letra maiúscula
                    if (upperCaseCount == 1)
                    {
                        // Adiciona um espaço antes da letra maiúscula
                        input = input.Insert(i, " ");
                        i++; // Incrementa para ajustar a posição após a inserção do espaço
                        upperCaseCount = 0; // Reinicia a contagem
                    }
                }
            }

            return input;
        }
        private void carregando(bool carregando)
        {
            
            if (carregando)
            {
                this.Cursor = Cursors.WaitCursor;
                dgvData.Rows.Clear();
                progressBar1.Value = 0;
                progressBar1.Visible = carregando;
                btnFechar.Enabled = !carregando;
                btnFiltrar.Enabled = !carregando;
                //btnProcessarPedido.Enabled = !carregando;
            }
            else
            {
                progressBar1.Value = 0;
                progressBar1.Visible = !carregando;
                btnFechar.Enabled = !carregando;
                btnFiltrar.Enabled = !carregando;
                //btnProcessarPedido.Enabled = !carregando;
                progressBar1.Visible = false;
                this.Cursor = Cursors.Default;

            }
            
        }
        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmInstanciaDePedidos_Load;
        }
        private void frmInstanciaDePedidos_Load(object sender, EventArgs e)
        {
            //Pré load events
            ConfigureDateTimePickerAttributes();

            //Events
            ConfigureButtonEvents();

            //Pós load events
            btnFiltrar_Click(null,null);
        }

        /** Configure DateTimePicker **/
        private void ConfigureDateTimePickerAttributes()
        {
            dtpDataInicial.Value = DateTime.Now.AddDays(-7);
            dtpDataFinal.Value = DateTime.Now.AddDays(7);
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            dgvData.Columns.Add("id","Id");
            dgvData.Columns["Id"].ValueType = typeof(int);
            dgvData.Columns.Add("PedidoPfizer", "Pedido OL");
            dgvData.Columns.Add("PedidoUni", "Num. Pedido");
            dgvData.Columns.Add("DataRegistro", "Data_Registro");
            dgvData.Columns.Add("Status", "Status");
            dgvData.Columns.Add("Base", "Base");                        
            dgvData.Columns.Add("Fabricante", "Fabricante");


            

        }

        /** Configure ProgressBar **/
        private void ConfigureProgressBarProperties()
        {
            progressBar1.Visible = false;
            progressBar1.Maximum = 100;
            progressBar1.Style = ProgressBarStyle.Blocks;
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
            btnProcessarPedido.Visible = false;
        }
        private void ConfigureButtonEvents()
        {
            btnPostarPrePedido.Click += btnPostarPrePedido_Click;
            btnFiltrar.Click += btnFiltrar_Click;
            btnProcessarPedido.Click += btnProcessarPedido_Click;
        }
        private async void btnProcessarPedido_Click(object sender, EventArgs e)
        {         

            if (dgvData.CurrentRow != null)
                try
                {
                    // Obtém as credenciais para autenticação
                    var cc_swagger = await CredenciaisSwagger.getToClassAsync("1");

                    // Obtém o token de autenticação
                    var token = await Token.POST(new Credentials
                    {
                        UserLogin = cc_swagger.LoginSwagger,
                        Password = Cryptography.decrypt(cc_swagger.SenhaSwagger)
                    });

                    // Valida o token
                    if (token == null || !token.success)
                    {
                        CustomNotification.defaultAlert("Erro ao obter o token de autenticação.");
                        return;
                    }

                    // Número do Pedido Portal
                    int numeroPedidoPortal;
                    if (!int.TryParse(dgvData.CurrentRow.Cells["PedidoPfizer"].Value.ToString(), out numeroPedidoPortal))
                    {
                        CustomNotification.defaultAlert("Por favor, insira um número de pedido válido.");
                        return;
                    }

                    // Chama o método PostNumeroPedidoPortalAsync
                    string resultado = await Pedido.PostNumeroPedidoPortalAsync(numeroPedidoPortal, token, cc_swagger);

                    // Exibe a resposta no console ou em uma notificação
                    Console.WriteLine(resultado);
                    //if (CustomNotification.defaultQuestionAlert($"Pedido {numeroPedidoPortal} enviado com sucesso! Deseja recarregar a tela?") == DialogResult.Yes)
                    //{
                    //    btnFiltrar_Click(null,null);
                    //};

                }
                catch (Exception ex)
                {
                    // Em caso de erro
                    CustomNotification.defaultError("Erro ao enviar o pedido: " + ex.Message);
                }
            

        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            await getInterplayers_PedidoPfizer();

        }
        private void btnPostarPrePedido_Click(object sender, EventArgs e)
        {
            frmPedidoPfizerInterplayers frmPedidoPfizerInterplayers = new frmPedidoPfizerInterplayers();
            frmPedidoPfizerInterplayers.ShowDialog();
            btnFiltrar_Click(null, null);
        }
        
    }
}
