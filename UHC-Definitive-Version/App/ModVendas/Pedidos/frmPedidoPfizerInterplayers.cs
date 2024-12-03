using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Configuration.InterplayersWebApi;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModVendas.AnaliseVendas
{
    public partial class frmPedidoPfizerInterplayers : CustomForm
    {
        public frmPedidoPfizerInterplayers()
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
        private async Task postPedidoAsync()
        {
            this.Cursor = Cursors.WaitCursor;

            // Validação de informações obrigatórias
            if (!this.requiredInformationValidation()) return;

            // Verifica se há dados na grade
            if (dgvData.Rows.Count == 0)
            {
                CustomNotification.defaultInformation("Nenhum dado encontrado na grade para enviar o pedido.");
                return;
            }

            // Cria uma nova lista de pedidos
            List<Pedido> listaPedidos = new List<Pedido>();

            // Cria uma nova instância do pedido
            Pedido pedido = new Pedido();

            // Busca o cliente pelo código
            var ce = Clientes_Externos.getClienteByCode(txtFornecedorId.Text);

            // Valida se o cliente foi encontrado
            if (ce == null)
            {
                CustomNotification.defaultAlert("Cliente não encontrado. Verifique o código do cliente.");
                return;
            }

            // Atribui o CNPJ do cliente
            pedido.CnpjCliente = Section.Cnpj;

            var fornecedores = await Fornecedores_Externos.getToListAsync();

            // Inicializa a lista Distribuidores, caso esteja nula
            pedido.Distribuidores = new List<Distribuidor>
    {
        new Distribuidor { CNPJ = fornecedores.Where(forn => forn.codigo == txtFornecedorId.Text.ToString()).FirstOrDefault().cnpj, Ordem = 0 }
    };

            // Atribui as outras informações do pedido
            pedido.Data = DateTime.Now;
            pedido.DataProgramada = dtpDataProgramada.Value;
            pedido.NumeroPedidoCliente = txtPedidoCliente.Text;

            // Inicializa a lista de itens
            List<Configuration.InterplayersWebApi.Item> itens = new List<Configuration.InterplayersWebApi.Item>();

            // Percorre as linhas da grade de dados e popula os itens
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["codEAN"].Value == null ||
                    row.Cells["quantidade"].Value == null ||
                    row.Cells["preco"].Value == null ||
                    row.Cells["desconto"].Value == null ||
                    row.Cells["lote"].Value == null)
                {
                    CustomNotification.defaultAlert($"Um ou mais itens possuem valores inválidos na linha {row.Index + 1}. Verifique os campos 'EAN', 'Quantidade', 'Preço', 'Desconto' e 'Lote'.");
                    return;
                }

                string ean = row.Cells["codEAN"].Value?.ToString();
                string lote = row.Cells["lote"].Value?.ToString();
                int quantidade;
                double preco, desconto;

                if (!int.TryParse(row.Cells["quantidade"].Value?.ToString(), out quantidade) ||
                    !double.TryParse(row.Cells["preco"].Value?.ToString(), out preco) ||
                    !double.TryParse(row.Cells["desconto"].Value?.ToString(), out desconto))
                {
                    CustomNotification.defaultAlert($"Erro de conversão em uma das colunas na linha {row.Index + 1}. Verifique os valores.");
                    return;
                }

                // Adiciona o item à lista se todos os dados forem válidos
                itens.Add(new Configuration.InterplayersWebApi.Item
                {
                    Ean = ean,
                    Quantidade = quantidade,
                    Preco = preco,
                    Desconto = desconto,
                    Lote = lote
                });
            }

            // Atribui os itens ao pedido
            pedido.Itens = itens;

            // Adiciona o pedido à lista de pedidos
            listaPedidos.Add(pedido);

            try
            {
                // Obtém as credenciais para autenticação
                CredenciaisSwagger cc_swagger = await CredenciaisSwagger.getToClassAsync("1");

                // Obtém o token de autenticação
                // Obtém o token de autenticação
                var token = await Token.POST(new Credentials
                {
                    UserLogin = cc_swagger.LoginSwagger,
                    Password = Cryptography.decrypt(cc_swagger.SenhaSwagger)
                }, cc_swagger.RotaSwagger);

                pedido.NumeroPedidoErp = (await Interplayers_Pfizer_Pedido.getNextCodeAsync()).ToString();

                // Faz o POST da lista de pedidos utilizando o token obtido
                string respostaJson = await Pedido.PostPedidoPfizerAsync(listaPedidos, token, cc_swagger);

                // Serializa o JSON enviado (a lista de pedidos)
                string jsonEnviado = JsonConvert.SerializeObject(listaPedidos, Formatting.Indented);

                // Desserializar a resposta JSON para a classe PedidoResposta
                var respostaObj = JsonConvert.DeserializeObject<PedidoResposta>(respostaJson);

                // Verificar se a resposta contém dados e se houve sucesso
                if (respostaObj != null && respostaObj.Success && respostaObj.Data.Count > 0)
                {
                    var pedidoPortal = respostaObj.Data[0].NumeroPedidoPortal;
                    var statusPedido = respostaObj.Data[0].Status;

                    // Notifica o usuário com as informações do número do pedido e o status
                    CustomNotification.defaultInformation($"Pedido enviado com sucesso!\nNúmero do Pedido: {pedidoPortal}\nStatus: {statusPedido}");

                    if (statusPedido == "AGUARDANDO_PROCESSAMENTO")
                    {
                        string resultado = await Pedido.PostNumeroPedidoPortalAsync(Convert.ToInt32(pedidoPortal), token, cc_swagger);
                    }

                    // Inserir os dados no banco de dados
                    await Interplayers_Pfizer_Pedido.insertAsync(new Interplayers_Pfizer_Pedido
                    {
                        Data_Registro = DateTime.Now.ToString(),
                        PedidoPfizer = pedidoPortal,
                        Retorno = statusPedido,
                        JsonEnviado = jsonEnviado, // Armazena o JSON enviado
                        Response = respostaJson,
                        Base = "InterPlayers",
                        Fabricante = "Pfizer"
                    });
                    this.Close();
                }
                else
                {
                    // Notifica o usuário caso haja um problema com a resposta
                    CustomNotification.defaultAlert("Não foi possível obter o número do pedido ou o status.");
                }

                // Exibe a resposta no console (para fins de depuração)
                Console.WriteLine(respostaJson);
            }
            catch (Exception ex)
            {
                // Exibe o erro no console ou log
                Console.WriteLine(ex.ToString());

                // Notifica o usuário do erro
                CustomNotification.defaultAlert("Ocorreu um erro ao enviar o pedido: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                
            }
        }

     



        /** Form Configuration **/
        private void ConfigureFormProperites()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmPedidoPfizerInterplayers_Load;
        }
        private void frmPedidoPfizerInterplayers_Load(object sender, EventArgs e)
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
            frmConsultarFornecedor frmConsultarFornecedor = new frmConsultarFornecedor();
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
        private async void txtFornecedorId_TextChanged(object sender, System.EventArgs e)
        {
            Fornecedores_Externos fe = await Fornecedores_Externos.getFornecedorByCodeAsync(txtFornecedorId.Text);
            txtFornecedor.Text = fe != null ? $"{fe?.razaoSocial} ({fe?.cnpj.ConvertToCNPJ()})" : string.Empty;
        }
        private void txtFornecedor_DoubleClick(object sender, EventArgs e)
        {
            btnMoreFornecedores_Click(null, null);
        }


    }
}
