using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.ModVendas.AnaliseVendas;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Configuration.InterplayersWebApi;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModVendas.Pedidos
{
    public partial class frmPedidoBayerInterplayers : CustomForm
    {
        public frmPedidoBayerInterplayers()
        {
            InitializeComponent();

            /** Properties **/
            ConfigureFormProperites();
            ConfigureTextBoxProperties();
            ConfigureDataGridViewProperties();
            ConfigureButtonProperties();

            /** Events **/
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        /** Async Tasks **/
        private async Task postPedidoAsync()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Log de início do processo
                Console.WriteLine("Iniciando envio de pedido...");

                // Validação de informações obrigatórias
                if (!this.requiredInformationValidation())
                {
                    Console.WriteLine("Validação de informações obrigatórias falhou.");
                    return;
                }

                // Verifica se há dados na grade
                if (dgvData.Rows.Count == 0)
                {
                    CustomNotification.defaultInformation("Nenhum dado encontrado na grade para enviar o pedido.");
                    Console.WriteLine("Nenhum dado na grade.");
                    return;
                }

                // Cria uma nova lista de pedidos
                List<Pedido> listaPedidos = new List<Pedido>();
                Pedido pedido = new Pedido();

                // Busca o cliente pelo código
                var ce = Clientes_Externos.getClienteByCode(txtFornecedorId.Text);
                Console.WriteLine($"Cliente buscado pelo código: {txtFornecedorId.Text}");

                // Valida se o cliente foi encontrado
                if (ce == null)
                {
                    CustomNotification.defaultAlert("Cliente não encontrado. Verifique o código do cliente.");
                    Console.WriteLine("Cliente não encontrado.");
                    return;
                }

                // Atribui o CNPJ do cliente
                Clientes_Externos clientes_Externos = new Clientes_Externos();
                clientes_Externos = Clientes_Externos.getClienteByCode(txtFornecedorId.Text);
                pedido.CnpjCliente = clientes_Externos.cgc_cpf;
                Console.WriteLine($"CNPJ do cliente atribuído: {clientes_Externos.cgc_cpf}");

                // Busca fornecedores
                var fornecedores = await Fornecedores_Externos.getToListAsync();
                Console.WriteLine($"Fornecedores carregados: {fornecedores.Count}");

                // Inicializa a lista Distribuidores
                var distribuidor = Section.Cnpj;
                if (distribuidor == null)
                {
                    CustomNotification.defaultAlert("Fornecedor não encontrado.");
                    Console.WriteLine("Fornecedor não encontrado.");
                    return;
                }
                pedido.Distribuidores = new List<Distribuidor>
                {
                    new Distribuidor { CNPJ = distribuidor, Ordem = 0 }
                };
                Console.WriteLine($"Distribuidor atribuído: {distribuidor}");

                // Atribui outras informações do pedido
                pedido.Data = DateTime.Now;
                pedido.DataProgramada = dtpDataProgramada.Value;
                pedido.NumeroPedidoErp = txtPedidoCliente.Text;
                pedido.NumeroPedidoCliente = txtPedidoCliente.Text;
                Console.WriteLine($"Data do pedido: {pedido.Data}, Data Programada: {pedido.DataProgramada}, Número Pedido Cliente: {pedido.NumeroPedidoCliente}");

                // Inicializa e popula a lista de itens
                List<Configuration.InterplayersWebApi.Item> itens = new List<Configuration.InterplayersWebApi.Item>();

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells["codEAN"].Value == null ||
                        row.Cells["quantidade"].Value == null ||
                        row.Cells["preco"].Value == null ||
                        row.Cells["desconto"].Value == null ||
                        row.Cells["lote"].Value == null)
                    {
                        CustomNotification.defaultAlert($"Valores inválidos na linha {row.Index + 1}.");
                        Console.WriteLine($"Valores inválidos na linha {row.Index + 1}.");
                        return;
                    }

                    string ean = row.Cells["codEAN"].Value?.ToString();
                    string lote = row.Cells["lote"].Value?.ToString();
                    if (!int.TryParse(row.Cells["quantidade"].Value?.ToString(), out int quantidade) ||
                        !double.TryParse(row.Cells["preco"].Value?.ToString(), out double preco) ||
                        !double.TryParse(row.Cells["desconto"].Value?.ToString(), out double desconto))
                    {
                        CustomNotification.defaultAlert($"Erro de conversão na linha {row.Index + 1}.");
                        Console.WriteLine($"Erro de conversão na linha {row.Index + 1}.");
                        return;
                    }

                    itens.Add(new Configuration.InterplayersWebApi.Item
                    {
                        Ean = ean,
                        Quantidade = quantidade,
                        Preco = preco,
                        Desconto = desconto,
                        Lote = lote
                    });
                }

                pedido.Itens = itens;
                listaPedidos.Add(pedido);
                Console.WriteLine($"Itens do pedido: {JsonConvert.SerializeObject(itens, Formatting.Indented)}");

                // Obtém credenciais
                CredenciaisSwagger cc_swagger = await CredenciaisSwagger.getToClassAsync("2");
                Console.WriteLine($"Credenciais obtidas para '2': {cc_swagger.RotaSwagger}, {cc_swagger.LoginSwagger} e {Cryptography.decrypt(cc_swagger.SenhaSwagger)}");
                
                 //Obtém o token de autenticação
                var token = await Token.POST(new Credentials
                {
                    UserLogin = cc_swagger.LoginSwagger,
                    Password = Cryptography.decrypt(cc_swagger.SenhaSwagger)
                }, cc_swagger.RotaSwagger);
                Console.WriteLine("Token obtido com sucesso. " + token.data.token);

                pedido.NumeroPedidoErp = (await Interplayers_Pfizer_Pedido.getNextCodeAsync()).ToString();
                Console.WriteLine($"Número do Pedido ERP gerado: {pedido.NumeroPedidoErp}");

                // Envia o pedido
                string respostaJson = await Pedido.PostPedidoBayerAsync(listaPedidos, token, cc_swagger);
                Console.WriteLine($"Resposta da API: {respostaJson}");

                //// Processa a resposta
                var respostaObj = JsonConvert.DeserializeObject<PedidoResposta>(respostaJson);
                if (respostaObj != null && respostaObj.Success && respostaObj.Data.Count > 0)
                {
                    var pedidoPortal = respostaObj.Data[0].NumeroPedidoPortal;
                    var statusPedido = respostaObj.Data[0].Status;
                    Console.WriteLine($"Pedido enviado com sucesso: {pedidoPortal}, Status: {statusPedido}");

                    if (statusPedido == "AGUARDANDO_PROCESSAMENTO")
                    {
                        string resultado = await Pedido.PostNumeroPedidoPortalAsync(Convert.ToInt32(pedidoPortal), token, cc_swagger);
                        Console.WriteLine($"Resultado do PostNumeroPedidoPortalAsync: {resultado}");
                    }

                    await Interplayers_Pfizer_Pedido.insertAsync(new Interplayers_Pfizer_Pedido
                    {
                        Data_Registro = DateTime.Now.ToString(),
                        PedidoPfizer = pedidoPortal,
                        Retorno = statusPedido,
                        JsonEnviado = JsonConvert.SerializeObject(listaPedidos, Formatting.Indented),
                        Response = respostaJson,
                        Base = "InterPlayers",
                        Fabricante = "Bayer"
                    });

                    CustomNotification.defaultInformation($"Pedido enviado com sucesso!\nNúmero do Pedido: {pedidoPortal}\nStatus: {statusPedido}");
                    //this.Close();
                }
                else
                {
                    Console.WriteLine("Resposta inválida ou falha na API.");
                    CustomNotification.defaultAlert("Não foi possível obter o número do pedido ou o status.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex}");
                CustomNotification.defaultAlert("Ocorreu um erro ao enviar o pedido: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                Console.WriteLine("Processo de envio de pedido finalizado.");
            }
        }


        /** Form Configuration **/
        private void ConfigureFormProperites()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmPedidoBayerInterplayers_Load; 
        }
        private void frmPedidoBayerInterplayers_Load(object sender, EventArgs e)
        {
            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
        }
     

        /** DataGridView Configuration **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.Columns.Add("codInterno", "Cód. Interno");
            dgvData.Columns.Add("codEAN", "EAN");
            dgvData.Columns.Add("descricao", "Produto");
            dgvData.Columns.Add("quantidade", "Quantidade");
            dgvData.Columns.Add("preco", "Prc. Interno (R$)");
            dgvData.Columns.Add("desconto", "Desconto (R$)");
            dgvData.Columns.Add("lote", "Lote");

            dgvData.Columns["desconto"].ValueType = typeof(double);
            dgvData.Columns["preco"].ValueType = typeof(double);
            dgvData.Columns["quantidade"].ValueType = typeof(int);

            dgvData.Columns["desconto"].DefaultCellStyle.Format = "C2";
            dgvData.Columns["preco"].DefaultCellStyle.Format = "C2";
            dgvData.Columns["quantidade"].DefaultCellStyle.Format = "N0";

            dgvData.toDefault(false);
        }




        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnMoreFornecedores.Click += btnMoreFornecedores_Click;
            btnAdd.Click += btnAdd_Click;
            btnRemover.Click += btnRemover_Click;
            btnPostarPedido.Click += btnPostarPedido_Click;

        }
        private async void btnPostarPedido_Click(object sender, EventArgs e)
        {
            await postPedidoAsync();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
                dgvData.Rows.Remove(dgvData.CurrentRow);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdicionarProdutoAoPedido frmAdicionarProdutoAoPedido = new frmAdicionarProdutoAoPedido();
            frmAdicionarProdutoAoPedido.ShowDialog();
            if (frmAdicionarProdutoAoPedido.pe.codigo != null)
            {

                dgvData.Rows.Add(frmAdicionarProdutoAoPedido.pe.codigo
                                , frmAdicionarProdutoAoPedido.pe.cod_EAN
                                , frmAdicionarProdutoAoPedido.pe.descricao
                                , frmAdicionarProdutoAoPedido.Quantidade
                                , frmAdicionarProdutoAoPedido.Preco
                                , frmAdicionarProdutoAoPedido.Desconto
                                , frmAdicionarProdutoAoPedido.Lote
                    );
            }
        }
        private void btnMoreFornecedores_Click(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarFornecedor = new frmConsultarCliente();
            frmConsultarFornecedor.ShowDialog();
            txtFornecedorId.Text = frmConsultarFornecedor.extendedCode;
        }


        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtFornecedor.ReadOnly();
            txtFornecedorId.JustNumbers();
        }
        private void ConfigureTextBoxEvents()
        {
            txtFornecedorId.TextChanged += txtFornecedorId_TextChanged;
            txtFornecedor.DoubleClick += txtFornecedor_DoubleClick;
        }
        private void txtFornecedorId_TextChanged(object sender, System.EventArgs e)
        {
            Clientes_Externos fe = Clientes_Externos.getClienteByCode(txtFornecedorId.Text);
            txtFornecedor.Text = fe != null ? $"{fe?.razao_social} ({fe?.cgc_cpf.ConvertToCNPJ()})" : string.Empty;
        }
        private void txtFornecedor_DoubleClick(object sender, EventArgs e)
        {
            btnMoreFornecedores_Click(null, null);
        }
    }
}
