using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.IMS;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmVisualizarLayout_IQVIA : CustomForm
    {
        /** Atributes **/
        public frmVisualizarLayout_IQVIA()
        {
            InitializeComponent();
            this.defaultMaximableForm();

            btnFechar.toDefaultCloseButton();
            this.Load += frmVisualizarLayoutIqvia_Load;


        }

        /** Instância **/
        internal string id { get; set; }
        internal string tipo { get; set; }
        internal DateTime date { get; set; }

        List<Descricao_IMSCliente> Clientes_descriptionsAllowed = new List<Descricao_IMSCliente>();
        List<Descricao_IMSCliente> Clientes_descriptionsDenied = new List<Descricao_IMSCliente>();

        List<Descricao_IMSVendas> Vendas_descriptionsAllowed = new List<Descricao_IMSVendas>();
        List<Descricao_IMSVendas> Vendas_descriptionsDenied = new List<Descricao_IMSVendas>();

        List<Descricao_IMSProduto> Produtos_descriptionsAllowed = new List<Descricao_IMSProduto>();
        List<Descricao_IMSProduto> Produtos_descriptionsDenied = new List<Descricao_IMSProduto>();

        public class LineBlock
        {
            public int indexColumn { get; set; }
            public int qtdAnterior { get; set; }
            public int codCliente { get; set; }
            public int codProduto { get; set; }
            public int qtdAtual { get; set; } = -1;
        }

        List<LineBlock> lineBlocks = new List<LineBlock>();


        /** Tasks **/
        private async Task loadDescription(string tipo)
        {
            this.Cursor = Cursors.WaitCursor;
            clearData();
            dgvData.MultiSelect = true;
            dgvData.SelectionMode = DataGridViewSelectionMode.CellSelect;
            enableButtons(false);
            try
            {
                if (tipo.Equals("P"))
                {
                    var descriptions = await IMSProduto.getDescriptionsAsync(date, id);
                    //Produtos_descriptionsAllowed = descriptions.Item1;
                    //Produtos_descriptionsDenied = descriptions.Item2;
                    dgvData.Columns.Add("codigo", "Cód. Produto");
                    dgvData.Columns.Add("description", "Produto");
                    dgvData.Columns.Add("cod_barras", "Cód. Barras");
                    dgvData.Columns.Add("fabricante", "Fabricante");
                    dgvData.Columns.Add("prc_fabrica", "Prc. Fábrica");
                    dgvData.Columns.Add("cl_fiscal", "Class. Fiscal");
                    dgvData.Columns.Add("dat_cadastro", "Dat. Cadastro");



                    foreach (var description in Produtos_descriptionsAllowed)
                    {
                        dgvData.Rows.Add
                           (
                             description._040Codigo_do_produto
                            , Produtos_Externos.produtos.Find(p => p.codigo == description._040Codigo_do_produto).descricao
                            , description._060Codigo_de_barras
                            , description._100Fabricante
                            , description._110Preco_fabrica
                            , description._130Classificacao_fiscal
                            , description._140Data_do_cadastro
                           );
                    }
                    foreach (var description in Produtos_descriptionsDenied)
                    {
                        dgvData.Rows.Add
                            (
                              description._040Codigo_do_produto
                             , Produtos_Externos.produtos.Find(p => p.codigo == description._040Codigo_do_produto).descricao
                             , description._060Codigo_de_barras
                             , description._100Fabricante
                             , description._110Preco_fabrica
                             , description._130Classificacao_fiscal
                             , description._140Data_do_cadastro
                            );
                        dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                    }

                }
                else if (tipo.Equals("V"))
                {
                    Vendas_descriptionsAllowed.Clear();
                    Vendas_descriptionsDenied.Clear();
                    var descriptions = await Descricao_IMSVendas.gettAllBlocksToListAsync(date, id);
                    Vendas_descriptionsAllowed = descriptions;

                    dgvData.Columns.Add("index", "index");
                    dgvData.Columns["index"].Visible = false;
                    dgvData.Columns.Add("Num_Nota", "NF");
                    dgvData.Columns.Add("codigo_cliente", "Cód. Cliente");
                    dgvData.Columns.Add("description_cliente", "Cliente");
                    dgvData.Columns.Add("codigo_produto", "Cód. Produto");
                    dgvData.Columns.Add("description_produto", "Produto");
                    dgvData.Columns.Add("flag_venda", "Tipo");
                    dgvData.Columns.Add("quantidade", "Quantidade");


                    foreach (var description in Vendas_descriptionsAllowed)
                    {
                        lineBlocks.Add(new LineBlock
                        {
                            indexColumn = Convert.ToInt32(description.index) - 1
                            ,
                            qtdAnterior = Convert.ToInt32(description._090Quantidade)
                        });

                        if (description.block == "false")
                        {
                            dgvData.Rows.Add(description.index, description.Num_Nota, description._030Codigo_cliente
                                            , Clientes_Externos.clientes.Find(p => p.codigo == description._030Codigo_cliente).razao_social
                                            , description._060Codigo_produto
                                            , Produtos_Externos.produtos.Find(p => p.codigo == description._060Codigo_produto).descricao
                                            , description._080Flag_venda.Replace("N", "Venda").Replace("D", "Devolução")
                                            , description._090Quantidade
                                );
                            dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                        }
                        else
                        {
                            dgvData.Rows.Add(description.index, description.Num_Nota, description._030Codigo_cliente
                                                                        , Clientes_Externos.clientes.Find(p => p.codigo == description._030Codigo_cliente).razao_social
                                                                        , description._060Codigo_produto
                                                                        , Produtos_Externos.produtos.Find(p => p.codigo == description._060Codigo_produto).descricao
                                                                        , description._080Flag_venda.Replace("N", "Venda").Replace("D", "Devolução")
                                                                        , description._090Quantidade
                                                            );
                        }

                    }
                }
                else if (tipo.Equals("C"))
                {
                    Clientes_descriptionsAllowed.Clear();
                    Clientes_descriptionsDenied.Clear();
                    var descripitions = await IMSCliente.getDescriptionsAsync(date, id);
                    Clientes_descriptionsAllowed = descripitions.Item1;
                    Clientes_descriptionsDenied = descripitions.Item2;

                    dgvData.Columns.Add("codigo_cliente", "Cód. Cliente");
                    dgvData.Columns.Add("description_cliente", "Cliente");
                    dgvData.Columns.Add("cnpj", "CNPJ");

                    foreach (var description in Clientes_descriptionsAllowed)
                    {
                        dgvData.Rows.Add(
                            description._020Codigo_do_cliente
                           , Clientes_Externos.clientes.Find(c => c.codigo == description._020Codigo_do_cliente).razao_social
                           , Clientes_Externos.clientes.Find(c => c.codigo == description._020Codigo_do_cliente).cgc_cpf
                        );
                    }
                    foreach (var description in Clientes_descriptionsDenied)
                    {
                        dgvData.Rows.Add(
                            description._020Codigo_do_cliente
                           , Clientes_Externos.clientes.Find(c => c.codigo == description._020Codigo_do_cliente).razao_social
                           , Clientes_Externos.clientes.Find(c => c.codigo == description._020Codigo_do_cliente).cgc_cpf
                        );
                        dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                    }

                }
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                dgvData.Columns[0].ValueType = typeof(int);
                //dgvData.Sort(dgvData.Columns[0], ListSortDirection.Ascending);
                dgvData.AutoResizeColumns();
                enableButtons(true);
                await chargeLineBlocks();
            }

            this.Cursor = Cursors.Default;
        }
        private async Task saveLineBlock()
        {
            if (DialogResult.No ==
                CustomNotification.defaultQuestionAlert("Bloqueios remanescentes por Produto e Cliente deverão ser removidos manualmente em caso de alteração, deseja prosseguir?"))
                return;

            await Iqvia_DetailedBlocks.deleteLineBlockAsync(id);
            await Iqvia_LineBlock.deleteAsync(id);

            List<Iqvia_DetailedBlocks> detailedBlocks = new List<Iqvia_DetailedBlocks>();
            List<Iqvia_LineBlock> lineBlock_table = new List<Iqvia_LineBlock>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                lineBlock_table.Add(new Iqvia_LineBlock
                {
                    indexColumn = row.Cells["index"].Value.ToString()
                    ,
                    id_Panel = id
                    ,
                    codCliente = row.Cells["codigo_cliente"].Value.ToString()
                    ,
                    codProduto = row.Cells["codigo_produto"].Value.ToString()
                    ,
                    qtdProduto = row.Cells["quantidade"].Value.ToString()
                    ,
                    Num_Nota = row.Cells["Num_Nota"].Value.ToString()
                });
            }

            foreach (var lineBlock in lineBlocks)
            {
                if (lineBlock.qtdAtual != -1)
                {
                    detailedBlocks.Add(new Iqvia_DetailedBlocks
                    {
                        id_Panel = id,
                        TypeBlock = "L"
                        ,
                        cod_Cliente = lineBlock.codCliente.ToString()
                        ,
                        cod_Produto = lineBlock.codProduto.ToString()
                       ,
                        indexColumn = (lineBlock.indexColumn).ToString()
                       ,
                        qtd_Produto = lineBlock.qtdAtual.ToString()
                    });
                }
            }
            await Iqvia_LineBlock.insertAsync(lineBlock_table);
            await Iqvia_DetailedBlocks.insertAsync(detailedBlocks);
            await checkBlockCliente(dgvData);
            await checkBlockProduto(dgvData);
            await Iqvia_Panel.updateHasBlock(id);
        }
        private async Task chargeLineBlocks()
        {
            foreach (var lineBlock in (await Iqvia_DetailedBlocks.getAllToListAsync(id)))
            {
                if (Convert.ToInt32(lineBlock.indexColumn) >= 0 && !string.IsNullOrEmpty(lineBlock.indexColumn))
                {
                    dgvData.Rows[Convert.ToInt32(lineBlock.indexColumn)].Cells["quantidade"].Value = lineBlock.qtd_Produto;
                }

            }
        }
        private async Task checkBlockCliente(DataGridView dgv)
        {
            Dictionary<string, int> totalPorCliente = new Dictionary<string, int>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string codCliente = row.Cells["Codigo_Cliente"].Value.ToString();
                int qtdItens = Convert.ToInt32(row.Cells["Quantidade"].Value);

                if (totalPorCliente.ContainsKey(codCliente))
                {
                    totalPorCliente[codCliente] += qtdItens;
                }
                else
                {
                    totalPorCliente.Add(codCliente, qtdItens);
                }
            }

            bool temSomaZero = false;

            foreach (KeyValuePair<string, int> item in totalPorCliente)
            {
                if (item.Value == 0)
                {
                    temSomaZero = true;
                    break;
                }
            }

            if (temSomaZero)
            {
                foreach (KeyValuePair<string, int> item in totalPorCliente)
                {
                    if (item.Value == 0)
                    {
                        List<Iqvia_DetailedBlocks> iqvia_DetailedBlocks = new List<Iqvia_DetailedBlocks>();

                        // Adicione o condicional aqui:
                        if (totalPorCliente[item.Key] == 0)
                        {
                            for (int x = 0; x < 3; x++)
                            {
                                iqvia_DetailedBlocks.Add(new Iqvia_DetailedBlocks
                                {
                                    id_Panel = (Convert.ToInt32(id) - x).ToString()
                                    ,
                                    TypeBlock = "C"
                                    ,
                                    external_Code = item.Key
                                    ,
                                    indexColumn = "-1"
                                });
                                await Iqvia_Panel.updateHasBlock((Convert.ToInt32(id) - x).ToString());
                            }
                            await Iqvia_DetailedBlocks.insertAsync(iqvia_DetailedBlocks);
                        }
                    }
                }
            }
        }
        private async Task checkBlockProduto(DataGridView dgv)
        {
            Dictionary<string, int> totalPorProduto = new Dictionary<string, int>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string codProduto = row.Cells["Codigo_Produto"].Value.ToString();
                int qtdItens = Convert.ToInt32(row.Cells["Quantidade"].Value);

                if (totalPorProduto.ContainsKey(codProduto))
                {
                    totalPorProduto[codProduto] += qtdItens;
                }
                else
                {
                    totalPorProduto.Add(codProduto, qtdItens);
                }
            }

            bool temSomaZero = false;

            foreach (KeyValuePair<string, int> item in totalPorProduto)
            {
                if (item.Value == 0)
                {
                    temSomaZero = true;
                    break;
                }
            }

            if (temSomaZero)
            {

                foreach (KeyValuePair<string, int> item in totalPorProduto)
                {
                    if (item.Value == 0)
                    {
                        if (totalPorProduto[item.Key] == 0)
                        {
                            List<Iqvia_DetailedBlocks> iqvia_DetailedBlocks = new List<Iqvia_DetailedBlocks>();
                            iqvia_DetailedBlocks.Clear();
                            for (int x = 0; x < 3; x++)
                            {
                                iqvia_DetailedBlocks.Add(new Iqvia_DetailedBlocks
                                {
                                    id_Panel = (Convert.ToInt32(id) - x).ToString()
                                    ,
                                    TypeBlock = "P"
                                    ,
                                    external_Code = item.Key
                                    ,
                                    indexColumn = "-1"
                                });

                                await Iqvia_Panel.updateHasBlock((Convert.ToInt32(id) - x).ToString());

                            }
                            await Iqvia_DetailedBlocks.insertAsync(iqvia_DetailedBlocks);
                        }
                    }
                }
            }
        }

        /** Functions **/
        private void clearData()
        {
            Clientes_descriptionsAllowed = new List<Descricao_IMSCliente>();
            Clientes_descriptionsDenied = new List<Descricao_IMSCliente>();
            Vendas_descriptionsAllowed = new List<Descricao_IMSVendas>();
            Vendas_descriptionsDenied = new List<Descricao_IMSVendas>();
            Produtos_descriptionsAllowed = new List<Descricao_IMSProduto>();
            Produtos_descriptionsDenied = new List<Descricao_IMSProduto>();
            dgvData.Rows.Clear();
            dgvData.Columns.Clear();
            lineBlocks.Clear();
        }
        private void pesquisarDados(string text)
        {
            dgvData.Rows.Clear();
            try
            {
                if (tipo == "C")
                {
                    var allowSelect = from item in Clientes_descriptionsAllowed.AsEnumerable()
                                      where (item._030CNPJ_CRM.Contains(text.ToUpper())
                                             || item._060Razao_social.Contains(text.ToUpper())
                                             || item._020Codigo_do_cliente.Contains(text.ToUpper())
                                             )
                                      select new { item };
                    foreach (var description in allowSelect)
                    {
                        dgvData.Rows.Add(description.item._020Codigo_do_cliente, description.item._060Razao_social, description.item._030CNPJ_CRM.ConvertToCNPJ());
                    }



                    var denySelect = from item in Clientes_descriptionsDenied.AsEnumerable()
                                     where (item._030CNPJ_CRM.Contains(text.ToUpper())
                                            || item._060Razao_social.Contains(text.ToUpper())
                                            || item._020Codigo_do_cliente.Contains(text.ToUpper())
                                            )
                                     select new { item };
                    foreach (var description in denySelect)
                    {
                        dgvData.Rows.Add(description.item._020Codigo_do_cliente, description.item._060Razao_social, description.item._030CNPJ_CRM.ConvertToCNPJ());
                        dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                }
                else if (tipo == "V")
                {
                    var allowSelect = from item in Vendas_descriptionsAllowed.AsEnumerable()
                                      where (item._030Codigo_cliente.Contains(text.ToUpper())
                                             || item._060Codigo_produto.Contains(text.ToUpper())
                                             || item._080Flag_venda.Contains(text.ToUpper())
                                             || item._090Quantidade.Contains(text.ToUpper())
                                             )
                                      select new { item };
                    int index = 0;
                    foreach (var description in allowSelect)
                    {
                        dgvData.Rows.Add(index++
                                        , description.item.Num_Nota
                                        , description.item._030Codigo_cliente
                                        , Clientes_Externos.clientes.Find(p => p.codigo == description.item._030Codigo_cliente).razao_social
                                        , description.item._060Codigo_produto
                                        , Produtos_Externos.produtos.Find(p => p.codigo == description.item._060Codigo_produto).descricao
                                        , description.item._080Flag_venda.Replace("N", "Venda").Replace("D", "Devolução")
                                        , description.item._090Quantidade
                            );

                    }

                    var denySelect = from item in Vendas_descriptionsDenied.AsEnumerable()
                                     where (item._030Codigo_cliente.Contains(text.ToUpper())
                                            || item._060Codigo_produto.Contains(text.ToUpper())
                                            || item._080Flag_venda.Contains(text.ToUpper())
                                            || item._090Quantidade.Contains(text.ToUpper())
                                            )
                                     select new { item };

                    foreach (var description in denySelect)
                    {
                        dgvData.Rows.Add(
                                            index++
                                        , description.item.Num_Nota
                                        , description.item._030Codigo_cliente
                                        , Clientes_Externos.clientes.Find(p => p.codigo == description.item._030Codigo_cliente).razao_social
                                        , description.item._060Codigo_produto
                                        , Produtos_Externos.produtos.Find(p => p.codigo == description.item._060Codigo_produto).descricao
                                        , description.item._080Flag_venda.Replace("N", "Venda").Replace("D", "Devolução")
                                        , description.item._090Quantidade
                            );
                        dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                }
                else if (tipo == "P")
                {
                    var allowSelect = from item in Produtos_descriptionsAllowed.AsEnumerable()
                                      where (item._040Codigo_do_produto.Contains(text.ToUpper())
                                             || item._080Nome_do_produto_Apresentacao.Contains(text.ToUpper())
                                             || item._100Fabricante.Contains(text.ToUpper())
                                             || item._110Preco_fabrica.Contains(text.ToUpper())
                                             || item._060Codigo_de_barras.Contains(text.ToUpper())
                                             )
                                      select new { item };

                    foreach (var description in allowSelect)
                    {
                        dgvData.Rows.Add
                           (
                             description.item._040Codigo_do_produto
                            , Produtos_Externos.produtos.Find(p => p.codigo == description.item._040Codigo_do_produto).descricao
                            , description.item._060Codigo_de_barras
                            , description.item._100Fabricante
                            , description.item._110Preco_fabrica
                            , description.item._130Classificacao_fiscal
                            , description.item._140Data_do_cadastro
                           );
                    }


                    var denySelect = from item in Produtos_descriptionsAllowed.AsEnumerable()
                                     where (item._040Codigo_do_produto.Contains(text.ToUpper())
                                            || item._080Nome_do_produto_Apresentacao.Contains(text.ToUpper())
                                            || item._100Fabricante.Contains(text.ToUpper())
                                            || item._110Preco_fabrica.Contains(text.ToUpper())
                                            || item._060Codigo_de_barras.Contains(text.ToUpper())
                                            )
                                     select new { item };
                    foreach (var description in denySelect)
                    {
                        dgvData.Rows.Add
                            (
                              description.item._040Codigo_do_produto
                             , Produtos_Externos.produtos.Find(p => p.codigo == description.item._040Codigo_do_produto).descricao
                             , description.item._060Codigo_de_barras
                             , description.item._100Fabricante
                             , description.item._110Preco_fabrica
                             , description.item._130Classificacao_fiscal
                             , description.item._140Data_do_cadastro
                            );
                        dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                dgvData.Columns[0].ValueType = typeof(int);
                dgvData.Sort(dgvData.Columns[0], ListSortDirection.Ascending);
                dgvData.AutoResizeColumns();
            }
        }
        private void enableButtons(bool enable)
        {
            btnPesquisar.Enabled = enable;
            btnRefresh.Enabled = enable;
            btnBloqueioDeLinha.Enabled = enable;
        }




        /** Event Load  **/
        private async void frmVisualizarLayoutIqvia_Load(object sender, EventArgs e)
        {

            //Funções bloqueadas apenas para o Layout V
            btnBloqueioDeLinha.Visible = false;
            btnRemoverBloqueio.Visible = false;
            btnCancelar.Visible = false;

            string tipo_Layout = null;

            if (tipo == "V")
            {
                tipo_Layout = "Vendas";
                btnBloqueioDeLinha.Visible = true;
                btnRemoverBloqueio.Visible = true;

            }
            else if (tipo == "C")
                tipo_Layout = "Clientes";
            else if (tipo == "P")
                tipo_Layout = "Produtos";
            dgvData.toDefault();
            lblTitle.Text = $"ID: {id} - {tipo_Layout}";

            await loadDescription(tipo);

            ConfigureSystemEvents();
            ConfigureDataGridsViewEvents();

        }


        /** DataGridView event **/
        private void ConfigureDataGridsViewEvents()
        {
            dgvData.CellValidating += dgvData_CellValidating;
            dgvData.CellValueChanged += dgvData_CellValueChanged;
        }
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int index = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["index"].Value);
            if (!string.IsNullOrEmpty(dgvData.Rows[index].Cells["quantidade"].Value?.ToString()))
            {
                lineBlocks.Find(i => i.indexColumn == index).qtdAtual = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["quantidade"].Value);
                lineBlocks.Find(i => i.indexColumn == index).codProduto = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["codigo_Produto"].Value);
                lineBlocks.Find(i => i.indexColumn == index).codCliente = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["codigo_Cliente"].Value);


                if (index == e.RowIndex)
                {
                    if (lineBlocks.Find(i => i.indexColumn == index).qtdAtual == 0)
                    {
                        dgvData.Rows[index].DefaultCellStyle.BackColor = Color.Gray;
                    }
                    else if (lineBlocks.Find(i => i.indexColumn == index).qtdAnterior != lineBlocks.Find(i => i.indexColumn == index).qtdAtual)
                    {
                        dgvData.Rows[index].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        dgvData.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
                else
                {
                    if (lineBlocks.Find(i => i.indexColumn == index).qtdAtual == 0)
                    {
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
                    }
                    else if (lineBlocks.Find(i => i.indexColumn == index).qtdAnterior != lineBlocks.Find(i => i.indexColumn == index).qtdAtual)
                    {
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
        }
        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvData.Columns["quantidade"] != null)
            {
                if (e.ColumnIndex == dgvData.Columns["quantidade"].Index) // Verifica se a coluna é a que você deseja validar
                {
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString())) // Verifica se o valor inserido é uma string vazia
                    {
                        CustomNotification  .defaultAlert("Valor não pode ser vazio"); // Define a mensagem de erro
                        e.Cancel = true; // Cancela a edição da célula
                    }
                    else
                    {
                        double value;
                        if (!double.TryParse(e.FormattedValue.ToString(), out value)) // Verifica se o valor inserido é numérico
                        {
                            CustomNotification.defaultAlert("Valor deve ser numérico");  // Define a mensagem de erro
                            e.Cancel = true; // Cancela a edição da célula
                        }
                    }
                }
            }
        }



        /** System Buttons **/
        private void ConfigureSystemEvents()
        {
            btnPesquisar.Click += btnPesquisar_Click;
            txtPesquisar.KeyDown += txtPesquisar_KeyDown;
            btnBloqueioDeLinha.Click += btnBloqueioDeLinha_Click;
            btnRemoverBloqueio.Click += btnRemoverBloqueio_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnRefresh.Click += btnRefresh_Click;
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisarDados(txtPesquisar.Text);
        }
        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            pesquisarDados(txtPesquisar.Text);
        }
        private async void btnBloqueioDeLinha_Click(object sender, EventArgs e)
        {

            if (btnBloqueioDeLinha.Text == "Salvar")
            {
                btnBloqueioDeLinha.Text = "Bloqueio de linha";
                btnCancelar.Visible = false;
                await saveLineBlock();
                frmVisualizarLayoutIqvia_Load(this, e);
            }
            else
            {
                dgvData.ReadOnly = false;
                dgvData.Columns["codigo_Cliente"].ReadOnly = true;
                dgvData.Columns["codigo_produto"].ReadOnly = true;
                dgvData.Columns["description_Cliente"].ReadOnly = true;
                dgvData.Columns["description_produto"].ReadOnly = true;
                dgvData.Columns["flag_venda"].ReadOnly = true;

                btnBloqueioDeLinha.Text = "Salvar";

                btnCancelar.Visible = true;

                CustomNotification.defaultInformation("Controle de linha ativado!");
            }
        }
        private async void btnRemoverBloqueio_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == CustomNotification.defaultQuestionAlert("Esta ação irá remover todas as alterações feitas, deseja continuar"))
            {
                await Iqvia_DetailedBlocks.deleteLineBlockAsync(id);
                await Iqvia_LineBlock.deleteAsync(id);
                for (int x = 0; x < 3; x++)
                {
                    await Iqvia_Panel.updateHasBlock((Convert.ToInt32(id) - x).ToString());

                }

                btnRefresh_Click(sender, e);


            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == CustomNotification.defaultQuestionAlert("Esta ação irá cancelar todas as alterações feitas, deseja continuar"))
                frmVisualizarLayoutIqvia_Load(this, e);
        }
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            clearData();
            await loadDescription(tipo);
        }

      

    }
}
