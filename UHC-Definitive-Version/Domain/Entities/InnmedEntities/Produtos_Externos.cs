using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    public class Produtos_Externos : Querys<Produtos_Externos>
    {
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string cod_EAN { get; set; }
        public string Des_NomGen { get; set; }
        public string Qtd_Disponivel { get; set; }
        public string Tipo { get; set; }
        public string prcUltimaEntrada { get; set; }
        public string Cod_Fabricante { get; set; }
        public string Vencimento { get; set; }

        public static List<Produtos_Externos> produtos = new List<Produtos_Externos>();

        public static string getDescripionByCode(string code)
        {
            string description = null;
            try
            {
                if (produtos.Count > 0 ? (!string.IsNullOrEmpty(code)) : false)
                    description = produtos.Where(p => p.codigo == code).FirstOrDefault()?.descricao;
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
                description = null;
            }
            return description;
        }

        public static Produtos_Externos getProductByCode(string code)
        {
            Produtos_Externos produto = null;
            try
            {
                if (produtos.Count > 0 ? (!string.IsNullOrEmpty(code)) : false)
                    produto = produtos.Where(p => p.codigo == code).FirstOrDefault();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
                produto = null;
            }
            return produto;
        }

        public static DataTable getToDataTable(string description)
        {
            DataTable dt = new DataTable();
            dt = produtos.Where(p => p.descricao.ToUpper().Contains(description)).ToList().AsDataTable();
            dt.Columns[0].ColumnName = "Código";
            dt.Columns[1].ColumnName = "Descrição";
            dt.Columns[2].ColumnName = "Cód. EAN";

            return dt;
        }

        public static List<Produtos_Externos> getToListByFilter(string description)
        {
            return produtos.Where(p => p.descricao.ToUpper().Contains(description)).ToList();
        }

        public async static Task<DataTable> getLotesByCodeAsync(string code)
        {
            string query = $@"SELECT   Lotes.Cod_Lote[Lote]
		                    ,Lotes.Dat_Vencim [Vencimento]
		                    ,Lotes.Qtd_Saldo [Saldo] 
                            FROM [DMD].dbo.[PRLOT] Lotes
                            WHERE Qtd_Saldo > 0 
                            AND Lotes.Cod_Produt  = {code}
                           ORDER BY Dat_Vencim asc";
            return await getAllToDataTable(query);
        }


        public async static Task carregarAsync()
        {

            if (produtos.Count > 0)
            {
                string query =
                    $@"
                      DECLARE @total INT;
                      SELECT @total = COUNT(*) FROM [DMD].dbo.[PRODU] Produto;

                      IF @total <> {produtos.Count()}
                      BEGIN 
                          SELECT Produto.codigo
                                ,Produto.descricao 
                                ,Produto.cod_ean
                                ,Produto.Des_NomGen
                                ,Produto.Qtd_Disponivel
                                ,Tipo = CASE Produto.flg_Oncologico WHEN 1 THEN 'Oncológico' ELSE 'Hospitalar' END
                                ,Produto.Prc_UltEnt [prcUltimaEntrada]
                                ,Produto.Cod_Fabricante
                                ,[Vencimento] = (SELECT top 1 Lotes.Dat_Vencim [Vencimento] 
												 FROM [DMD].dbo.[PRLOT] Lotes 
												 WHERE Lotes.Cod_Produt = Produto.Codigo
												 AND Lotes.Qtd_Saldo > 0
												 ORDER BY Dat_Vencim ASC
												 )

                          FROM [DMD].dbo.[PRODU] Produto;
                      END";

                List<Produtos_Externos> novosProdutos = await getAllToList(query);

                if (novosProdutos.Count > 0)
                {
                    // Cria um dicionário auxiliar para armazenar os produtos existentes
                    var produtosExistentes = new Dictionary<int, Produtos_Externos>();

                    // Cria uma lista auxiliar para armazenar os códigos dos produtos existentes
                    var codigosProdutosExistentes = new List<int>();

                    // Preenche o dicionário e a lista auxiliares
                    foreach (var produtoExistente in produtos)
                    {
                        produtosExistentes[Convert.ToInt32(produtoExistente.codigo)] = produtoExistente;
                        codigosProdutosExistentes.Add(Convert.ToInt32(produtoExistente.codigo));
                    }

                    // Verifica se há novos produtos e adiciona ou atualiza a lista existente
                    foreach (var produto in novosProdutos)
                    {
                        if (!produtosExistentes.TryGetValue(Convert.ToInt32(produto.codigo), out var produtoExistente))
                        {
                            // Se o produto não existe, adiciona na lista principal e no dicionário auxiliar
                            produtos.Add(produto);
                            produtosExistentes[Convert.ToInt32(produto.codigo)] = produto;
                        }
                        else
                        {
                            // Se o produto existe, atualiza somente as informações necessárias
                            produtoExistente.descricao = produto.descricao;
                            produtoExistente.cod_EAN = produto.cod_EAN;
                            produtoExistente.Des_NomGen = produto.Des_NomGen;
                            produtoExistente.Qtd_Disponivel = produto.Qtd_Disponivel;
                            produtoExistente.Tipo = produto.Tipo;
                            produtoExistente.prcUltimaEntrada = produto.prcUltimaEntrada;
                            produtoExistente.Cod_Fabricante = produto.Cod_Fabricante;
                            produtoExistente.Vencimento = produto.Vencimento;
                        }
                    }

                    // Remove os produtos existentes que não foram atualizados
                    produtos.RemoveAll(p => !codigosProdutosExistentes.Contains(Convert.ToInt32(p.codigo)));
                }
            }
            else
            {
                string query = $@"SELECT Produto.codigo
                  ,Produto.descricao
                  ,Produto.cod_ean
                  ,Produto.Des_NomGen
                  ,Produto.Qtd_Disponivel
                  ,Tipo = CASE Produto.flg_Oncologico WHEN 1 THEN 'Oncológico' ELSE 'Hospitalar' END
                  ,Produto.Prc_UltEnt[prcUltimaEntrada]
                  ,Produto.Cod_Fabricante
                  ,[Vencimento] = (SELECT top 1 Lotes.Dat_Vencim [Vencimento] 
												 FROM [DMD].dbo.[PRLOT] Lotes 
												 WHERE Lotes.Cod_Produt = Produto.Codigo
												 AND Lotes.Qtd_Saldo > 0
												 ORDER BY Dat_Vencim ASC
												 )
                    FROM[DMD].dbo.[PRODU] Produto";
                produtos = await getAllToList(query);
            }

        }

        /** Obtem o produto em tempo real**/
        public static int getStockFromExternalProduct(string id)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Section.Unidade))
            {
                conn.Open();

                // Use parâmetros para evitar injeções de SQL
                string query = "SELECT Qtd_Disponivel FROM [DMD].dbo.[PRODU] WHERE Codigo = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    // Usando SqlDataAdapter para preencher um DataTable
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);  // Sem usar Task.Run, pois agora é síncrono

                        if (dt.Rows.Count > 0)
                        {
                            int qtdStock = Convert.ToInt32(dt.Rows[0][0]);
                            return qtdStock;
                        }
                        else
                        {
                            throw new Exception("Produto não encontrado.");
                        }
                    }
                }
            }
        }

    }
    }
