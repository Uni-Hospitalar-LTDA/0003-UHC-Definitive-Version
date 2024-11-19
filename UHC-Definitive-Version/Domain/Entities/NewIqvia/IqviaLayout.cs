using OfficeOpenXml.Export.HtmlExport.StyleCollectors.StyleContracts;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Domain.IMS;

namespace UHC3_Definitive_Version.Domain.Entities.NewIqvia
{
    public class IqviaLayout : Querys<IqviaLayout>
    {
        public string NotaFiscal { get; set; }
        public string bloqueio { get; set; }
        public string DatEmissao { get; set; }
        public string CFOP { get; set; }
        public string EntSai { get; set; }
        public string Tip_NotFis { get; set; }
        public string idFabricante { get; set; }
        public string Fabricante { get; set; }
        public string idProduto { get; set; }
        public string Produto { get; set; }
        public string eanProduto { get; set; }
        public string Qtd { get; set; }
        public string idCliente { get; set; }
        public string Cliente { get; set; }
        public string Cnpj { get; set; }
        public string idGrupoCliente { get; set; }
        public string GrupoCliente { get; set; }
        public string Esfera { get; set; }

        private static string getBaseQuery(DateTime dt, int bloqueio = 1)
        {
            return $@"  DECLARE @DATE DATE = '{dt.ToString("yyyyMMdd")}';
                        DECLARE @BLOQUEIO INT = {bloqueio};
                        WITH Sellout AS (
                            SELECT
                                NF_Saida.Num_Nota		AS NotaFiscal,
                                NF_Saida.Dat_Emissao	AS DatEmissao,
                                Cfop.Codigo				AS CFOP,
                                Cfop.Tip_EntSai			AS EntSai,
                                Cfop.Tip_NotFis			AS Tip_NotFis,
                                Fabricante.Codigo		AS idFabricante,
                                Fabricante.Fantasia		AS Fabricante,
                                Produto.Codigo			AS idProduto,
                                Produto.Descricao		AS Produto,
                                Produto.Cod_EAN			AS eanProduto,
                                NF_Saida_Itens.Qtd_Produto AS Qtd,
                                Cliente.Codigo			AS idCliente,
                                Cliente.Razao_Social	AS Cliente,
                                Cliente.Cgc_Cpf			AS Cnpj,
                                GrupoCliente.Cod_GrpCli AS idGrupoCliente,
                                GrupoCliente.Des_GrpCli AS GrupoCliente,
                                IIF(Cliente.Tipo_Consumidor IN ('P','E','M'), 'Público', 'Privado') AS Esfera
                            FROM [{Connection.dbDMD}].dbo.[NFSCB] NF_Saida
                            JOIN [{Connection.dbDMD}].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
                            JOIN [{Connection.dbDMD}].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
                            JOIN [{Connection.dbDMD}].dbo.[FABRI] Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante
                            JOIN [{Connection.dbDMD}].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente	
                            JOIN [{Connection.dbDMD}].dbo.[GRCLI] GrupoCliente ON GrupoCliente.Cod_GrpCli = Cliente.Cod_GrpCli 
                            JOIN [{Connection.dbDMD}].dbo.[TBCFO] Cfop ON Cfop.Codigo = NF_Saida.Cod_Cfo1
                            WHERE NF_Saida.STATUS = 'F'
                              AND NF_Saida.Dat_Emissao = @DATE
                        ),
                        
                        Sellin AS (
                            SELECT
                                NF_Entrada.Numero		AS NotaFiscal,
                                NF_Entrada.Dat_Emissao	AS DatEmissao,
                                Cfop.Codigo				AS CFOP,
                                Cfop.Tip_EntSai			AS EntSai,
                                Cfop.Tip_NotFis			AS Tip_NotFis,
                                Fabricante.Codigo		AS idFabricante,
                                Fabricante.Fantasia		AS Fabricante,
                                Produto.Codigo			AS idProduto,
                                Produto.Descricao		AS Produto,
                                Produto.Cod_EAN			AS eanProduto,
                                NF_Entrada_Itens.Qtd_Pedido AS Qtd,
                                Cliente.Codigo			AS idCliente,
                                Cliente.Razao_Social	AS Cliente,
                                Cliente.Cgc_Cpf			AS Cnpj,
                                GrupoCliente.Cod_GrpCli AS idGrupoCliente,
                                GrupoCliente.Des_GrpCli AS GrupoCliente,
                                IIF(ISNULL(Cliente.Tipo_Consumidor,'F') IN ('P','E','M'), 'Público', 'Privado') AS Esfera
                            FROM [{Connection.dbDMD}].dbo.[NFECB] NF_Entrada
                            JOIN [{Connection.dbDMD}].dbo.[NFEIT] NF_Entrada_Itens ON NF_Entrada.Protocolo = NF_Entrada_Itens.Protocolo
                            JOIN [{Connection.dbDMD}].dbo.[PRODU] Produto ON Produto.Codigo = NF_Entrada_Itens.Cod_Produto
                            JOIN [{Connection.dbDMD}].dbo.[FABRI] Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante
                            JOIN [{Connection.dbDMD}].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Entrada.Cod_EmiCliente
                            JOIN [{Connection.dbDMD}].dbo.[GRCLI] GrupoCliente ON GrupoCliente.Cod_GrpCli = Cliente.Cod_GrpCli
                            JOIN [{Connection.dbDMD}].dbo.[TBCFO] Cfop ON Cfop.Codigo = NF_Entrada.Cod_Cfo
                            WHERE NF_Entrada.STATUS = 'F'
                              AND NF_Entrada.Dat_Emissao = @DATE
                        ),
                        
                        InOut AS (
                            SELECT * FROM Sellin
                            UNION ALL
                            SELECT * FROM Sellout
                        )
                        
                        /** Consulta para registros sem bloqueio **/
                        SELECT 
                            InOut.NotaFiscal,
                            NULL AS Bloqueio,
                            CONVERT(DATE, InOut.DatEmissao) AS DatEmissao,
                            InOut.CFOP,
                            InOut.EntSai,
                            InOut.Tip_NotFis,
                            InOut.idFabricante,
                            InOut.Fabricante,
                            InOut.idProduto,
                            InOut.Produto,
                            InOut.eanProduto,
                            InOut.Qtd,
                            InOut.idCliente,
                            InOut.Cliente,
                            InOut.Cnpj,
                            InOut.idGrupoCliente,
                            InOut.GrupoCliente,
                            InOut.Esfera
                        FROM InOut
                        LEFT JOIN [{Connection.dbBase}].dbo.[{IqviaRestriction.getClassName()}] rest 
                            ON InOut.DatEmissao BETWEEN rest.InitialDate AND rest.FinalDate
                            AND rest.Status = @BLOQUEIO
                        WHERE rest.id IS NULL
                            OR NOT EXISTS (
                                SELECT 1 
                                FROM [{Connection.dbBase}].dbo.[{IqviaRestrictionItens.getClassName()}] subItem
                                JOIN [{Connection.dbBase}].dbo.[{IqviaRestriction_IqviaRestrictionItens.getClassName()}] RI ON RI.idIqviaRestrictionItens = subItem.Id
                                WHERE ri.idIqviaRestriction = rest.id
                                  AND (
                                    (subItem.type = 'Fabricante' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idFabricante)) OR
                                    (subItem.type = 'Fabricante + Esfera' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idFabricante) + ',' + InOut.Esfera) OR
                                    (subItem.type = 'Produto' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idProduto)) OR
                                    (subItem.type = 'Produto + Esfera' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idProduto) + ',' + InOut.Esfera) OR
                                    (subItem.type = 'Produto + Cliente' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idProduto) + ',' + CONVERT(NVARCHAR(100), InOut.idCliente)) OR
                                    (subItem.type = 'Cliente' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idCliente)) OR
                                    (subItem.type = 'Nota' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.NotaFiscal)) OR
                                    (subItem.type = 'Grupo de Cliente' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idGrupoCliente)) OR
                                    (subItem.type = 'Grupo de Cliente + Esfera' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idGrupoCliente) + ',' + InOut.Esfera) OR
                                    (subItem.type = 'CFOP' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.CFOP))
                                  )
                            )
                        
                        UNION ALL
                        
                        /** Consulta para registros com bloqueio **/
                        SELECT 
                            InOut.NotaFiscal,
                            'Restrição: ' + rest.Description AS Bloqueio,
                            CONVERT(DATE, InOut.DatEmissao) AS DatEmissao,
                            InOut.CFOP,
                            InOut.EntSai,
                            InOut.Tip_NotFis,
                            InOut.idFabricante,
                            InOut.Fabricante,
                            InOut.idProduto,
                            InOut.Produto,
                            InOut.eanProduto,
                            InOut.Qtd,
                            InOut.idCliente,
                            InOut.Cliente,
                            InOut.Cnpj,
                            InOut.idGrupoCliente,
                            InOut.GrupoCliente,
                            InOut.Esfera
                        FROM InOut
                        JOIN [{Connection.dbBase}].dbo.[{IqviaRestriction.getClassName()}] rest 
                            ON InOut.DatEmissao BETWEEN rest.InitialDate AND rest.FinalDate
                            AND rest.Status = @BLOQUEIO
                        WHERE EXISTS (
                            SELECT 1 
                            FROM [{Connection.dbBase}].DBO.[{IqviaRestrictionItens.getClassName()}] subItem
                            JOIN [{Connection.dbBase}].DBO.[{IqviaRestriction_IqviaRestrictionItens.getClassName()}] RI ON RI.idIqviaRestrictionItens = subItem.Id
                            WHERE ri.idIqviaRestriction = rest.id
                              AND (
                                (subItem.type = 'Fabricante' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idFabricante)) OR
                                (subItem.type = 'Fabricante + Esfera' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idFabricante) + ',' + InOut.Esfera) OR
                                (subItem.type = 'Produto' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idProduto)) OR
                                (subItem.type = 'Produto + Esfera' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idProduto) + ',' + InOut.Esfera) OR
                                (subItem.type = 'Produto + Cliente' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idProduto) + ',' + CONVERT(NVARCHAR(100), InOut.idCliente)) OR
                                (subItem.type = 'Cliente' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idCliente)) OR
                                (subItem.type = 'Nota' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.NotaFiscal)) OR
                                (subItem.type = 'Grupo de Cliente' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idGrupoCliente)) OR
                                (subItem.type = 'Grupo de Cliente + Esfera' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.idGrupoCliente) + ',' + InOut.Esfera) OR
                                (subItem.type = 'CFOP' AND subItem.KeyItem = CONVERT(NVARCHAR(100), InOut.CFOP))
                              )
                        )
                        ORDER BY NotaFiscal ASC;";
        }
        public static async Task<List<IqviaLayout>> getAllToListAsync(DateTime dt, int bloqueio = 1)
        {
            string query = getBaseQuery(dt, bloqueio);
            return await getAllToList(query);
        }



        /** GETS **/
        public static async Task<DataTable> getLayoutVendasAsync(DateTime dt, int bloqueio = 1)
        {
            var baseDados = await getAllToListAsync(dt, bloqueio);

            //Description
            var produtoData = baseDados;

            List<IqviaLayout_Venda_Description> description_Venda = new List<IqviaLayout_Venda_Description>();
            foreach (var venda in produtoData)
            {
                description_Venda.Add(new IqviaLayout_Venda_Description
                {
                    _020ID_Periodo = dt.ToString("dd"),
                    _030Codigo_cliente = venda.idCliente,
                    _060Codigo_produto = venda.idProduto,
                    _080Flag_venda = venda.EntSai == "S" ? "N" : "D",
                    _090Quantidade = venda.Qtd
                });
            }

            var resultado = produtoData.Select(v => new
            {
                v.NotaFiscal,
                v.bloqueio,
                v.DatEmissao,
                v.CFOP,
                v.EntSai,
                v.Tip_NotFis,
                v.idProduto,
                v.Produto,
                v.Fabricante,
                v.idCliente,
                v.Cliente,
                v.Esfera,
                v.Qtd
            }).ToList();

            return resultado.AsDataTable();





        }
        public static async Task<DataTable> getLayoutClienteAsync(DateTime dt, int bloqueio = 1)
        {
            var baseDados = await getAllToListAsync(dt, bloqueio);           

            //Description
            var clienteData = baseDados.Where(x => string.IsNullOrEmpty(x.bloqueio))
           .GroupBy(n => new { n.idCliente, n.Cliente, n.Cnpj })
           .Select(g => new
           {
               idCliente = g.Key.idCliente,
               Cliente = g.Key.Cliente,
               Cnpj = g.Key.Cnpj
           })
           .ToList();
            

         

            return clienteData.AsDataTable();
        }
        public static async Task<DataTable> getLayoutProdutoAsync(DateTime dt, int bloqueio = 1)
        {
            var baseDados = await getAllToListAsync(dt, bloqueio);

            //Description
            var produtoData = baseDados.Where(x => string.IsNullOrEmpty(x.bloqueio))
           .GroupBy(n => new { n.idProduto, n.Produto, n.eanProduto })
           .Select(g => new
           {
               idProduto = g.Key.idProduto,
               Produto = g.Key.Produto,
               eanProduto = g.Key.eanProduto
           })
           .ToList();


            return produtoData.AsDataTable();





        }


        /** Exports **/
        public static async Task<string> exportarLayoutClienteAsync(DateTime dt, int bloqueio = 1)
        {
            var baseDados = await getAllToListAsync(dt,bloqueio);            


            //Header
            IqviaLayout_Cliente_Header cliente_Header = new IqviaLayout_Cliente_Header();
            cliente_Header._010Tipo_de_registro = "1";
            cliente_Header._020Fixo = "0";
            cliente_Header._030Seu_codigo_IQVIA = Section.CodIqvia;
            cliente_Header._040Razao_Social = Section.Empresa;
            cliente_Header._050CNPJ = Section.Cnpj;
            cliente_Header._060Data_inicio = dt.ToString("ddMMyyyy");
            cliente_Header._070Data_final = dt.ToString("ddMMyyyy");
            cliente_Header._080Data_arquivo = DateTime.Now.ToString("ddMMyyyy");
            cliente_Header._090Fixo = "1";
            cliente_Header._100Filler = "";
            cliente_Header._110Filler = "";
            cliente_Header._120Controle_interno_IQVIA = "imsbrcli1";
            
            string header = cliente_Header.getHeader();

            //Description
            var clienteData = baseDados.Where(x=>string.IsNullOrEmpty(x.bloqueio))
           .GroupBy(n => new { n.idCliente, n.Cliente, n.Cnpj })
           .Select(g => new
           {
               idCliente = g.Key.idCliente,
               Cliente = g.Key.Cliente,
               Cnpj = g.Key.Cnpj
           })
           .ToList();

            List<IqviaLayout_Cliente_Descricao> cliente_Description = new List<IqviaLayout_Cliente_Descricao>();
            foreach (var cliente in clienteData)
            {
                var clienteInnmed = await ClienteInnmed.getToClassAsync(cliente.idCliente);
                cliente_Description.Add(new IqviaLayout_Cliente_Descricao
                {
                    
                            _010Tipo_de_Registro = "2",
                            _020Codigo_do_cliente = string.IsNullOrEmpty(clienteInnmed.id) ? "" : clienteInnmed.id,
                            _030CNPJ_CRM = string.IsNullOrEmpty(clienteInnmed.cnpj) ? "": clienteInnmed.cnpj,
                            _040Flag = "1",
                            _050Nome_fantasia = string.IsNullOrEmpty(clienteInnmed.fantasia) ? "": clienteInnmed.fantasia,
                            _060Razao_social = string.IsNullOrEmpty(clienteInnmed.description) ? "" : clienteInnmed.description,
                            _070Flag_endereco = "1",
                            _080Endereco = string.IsNullOrEmpty(clienteInnmed.endereco) ? "" : clienteInnmed.endereco,
                            _090Complemento = string.IsNullOrEmpty(clienteInnmed.complemento) ? "" : clienteInnmed.complemento,
                            _100CEP = string.IsNullOrEmpty(clienteInnmed.cep) ? "" : clienteInnmed.cep,
                            _110Cidade = string.IsNullOrEmpty(clienteInnmed.cidade) ? "" : clienteInnmed.cidade,
                            _120Estado = string.IsNullOrEmpty(clienteInnmed.estado) ? "" : clienteInnmed.estado,
                            _130Telefone = string.IsNullOrEmpty(clienteInnmed.telefone) ? "" : clienteInnmed.telefone,
                            _140Fax = "",
                            _150Data_cadastro = string.IsNullOrEmpty(clienteInnmed.dataCadastro) ? "" : clienteInnmed.dataCadastro,
                            _160email = string.IsNullOrEmpty(clienteInnmed.email) ? "" : clienteInnmed.email,
                            _170URL = "",
                            _180Filler = "",
                            _190Controle_interno_IQVIA = "C",
            });
                //Console.WriteLine(clienteInnmed.cidade);
            }

            string description = IqviaLayout_Cliente_Descricao.getDescriptions(cliente_Description);

            //Trailler
            IqviaLayout_Cliente_Trailer trailer_Cliente = new IqviaLayout_Cliente_Trailer();
            trailer_Cliente._010Tipo_de_Registro = "3";
            trailer_Cliente._020Fixo = "0";
            trailer_Cliente._030Seu_codigo_IQVIA = Section.CodIqvia;
            trailer_Cliente._040Total_de_registros = (cliente_Description.Count() + 2).ToString();
            trailer_Cliente._070Controle_interno_IQVIA = "imsbrcli3";

            string trailer = trailer_Cliente.getTrailler();

            List<string> arquivo = new List<string>();
            arquivo.Add(header);
            arquivo.Add(description);
            arquivo.Add(trailer);

            string archiveName = $"C{Section.CodIqvia}M{dt.ToString("MM")}.D{dt.ToString("dd")}";

            return salvarArquivo(arquivo, archiveName);

        }
        public static async Task<string> exportarLayoutProdutoAsync(DateTime dt, int bloqueio = 1)
        {
            var baseDados = await getAllToListAsync(dt, bloqueio);

            IqviaLayout_Produto_Header header_Produto = new IqviaLayout_Produto_Header();
            header_Produto._060Data_inicial = $"{dt.ToString("yyyyMMdd")}";
            header_Produto._070Data_final = $"{dt.ToString("yyyyMMdd")}";
            string header = header_Produto.getHeader();


            //Description
            var produtoData = baseDados.Where(x => string.IsNullOrEmpty(x.bloqueio))
           .GroupBy(n => new { n.idProduto, n.Produto, n.eanProduto })
           .Select(g => new
           {
               idProduto = g.Key.idProduto,
               Produto = g.Key.Produto,
               eanProduto = g.Key.eanProduto
           })
           .ToList();

            List<IqviaLayout_Produto_Descricao> description_Produto = new List<IqviaLayout_Produto_Descricao>();
            foreach (var produto in produtoData)
            {
                var produtoInnmed = await ProdutoInnmed.getToClassAsync(produto.idProduto);
                var fabricanteInnmed = await FabricanteInnmed.getToClassAsync(produtoInnmed.idFabricante);
                description_Produto.Add(new IqviaLayout_Produto_Descricao
                {
                    _040Codigo_do_produto = produtoInnmed.id
                   ,_060Codigo_de_barras = string.IsNullOrEmpty(produtoInnmed.ean) ? "" : produtoInnmed.ean
                   ,_080Nome_do_produto_Apresentacao = produto.Produto
                   ,_100Fabricante = fabricanteInnmed.description
                   ,_110Preco_fabrica = produtoInnmed.precoFabrica
                   ,_130Classificacao_fiscal = string.IsNullOrEmpty(produtoInnmed.classFiscal) ? "" : produtoInnmed.classFiscal
                   ,_140Data_do_cadastro = string.IsNullOrEmpty(produtoInnmed.datCadastro) ? "" : produtoInnmed.datCadastro

                });
            }

            string description = IqviaLayout_Produto_Descricao.getDescricao(description_Produto);

            IqviaLayout_Produto_Trailer trailer_Produto = new IqviaLayout_Produto_Trailer();
            trailer_Produto._040Total_de_registros = (description_Produto.Count()+2).ToString();

            string trailer = trailer_Produto.getTrailer();

            List<string> arquivo = new List<string>();
            arquivo.Add(header);
            arquivo.Add(description);
            arquivo.Add(trailer);

            string archiveName = $"P{Section.CodIqvia}M{dt.ToString("MM")}.D{dt.ToString("dd")}";

            return salvarArquivo(arquivo, archiveName);

        }        
        public static async Task<string> exportarLayoutVendasAsync(DateTime dt, int bloqueio = 1)
        {
            var baseDados = await getAllToListAsync(dt, bloqueio);

            IqviaLayout_Venda_Header header_Venda = new IqviaLayout_Venda_Header();
            header_Venda._040Data_inicio = $"{dt.ToString("yyyyMMdd")}";
            header_Venda._050Data_final = $"{dt.ToString("yyyyMMdd")}";

            string header = header_Venda.getHeader();



            //Description
            var produtoData = baseDados.Where(x => string.IsNullOrEmpty(x.bloqueio));

            List<IqviaLayout_Venda_Description> description_Venda = new List<IqviaLayout_Venda_Description>();
            foreach (var venda in produtoData)
            {
                description_Venda.Add(new IqviaLayout_Venda_Description
                {
                    _020ID_Periodo = dt.ToString("dd"),
                    _030Codigo_cliente = venda.idCliente,
                    _060Codigo_produto = venda.idProduto,
                    _080Flag_venda = venda.EntSai == "S" ? "N" : "D",
                    _090Quantidade = venda.Qtd
                });
            }

            string description = IqviaLayout_Venda_Description.getDescricao(description_Venda);             

            IqviaLayout_Venda_Trailer trailer_Venda = new IqviaLayout_Venda_Trailer();
            trailer_Venda._040Total_de_Registros = (description_Venda.Count+2).ToString();
            trailer_Venda._050Total_unidades = description_Venda.Where(v => v._080Flag_venda == "N").Sum(v => int.TryParse(v._090Quantidade?.ToString(), out int qtd) ? qtd : 0).ToString();
            trailer_Venda._060Total_de_Unidades_devolucoes = description_Venda.Where(v => v._080Flag_venda == "D").Sum(v => int.TryParse(v._090Quantidade?.ToString(), out int qtd) ? qtd : 0).ToString();
            string trailer = trailer_Venda.getTrailer();

            List<string> arquivo = new List<string>();
            arquivo.Add(header);
            arquivo.Add(description);
            arquivo.Add(trailer);

            string archiveName = $"V{Section.CodIqvia}M{dt.ToString("MM")}.D{dt.ToString("dd")}";

            return salvarArquivo(arquivo, archiveName);
        }

        public static string salvarArquivo(List<string> linhas, string nomeArquivo)
        {
            try
            {
                // Construindo o caminho da pasta padrão no AppData
                string pastaDestino = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Iqvia_Closeup");

                // Garantindo que a pasta exista
                if (!Directory.Exists(pastaDestino))
                {
                    Directory.CreateDirectory(pastaDestino);
                }

                // Definindo o nome completo do arquivo (nome + extensão)
                string caminhoArquivo = Path.Combine(pastaDestino, $"{nomeArquivo}");

                // Concatenando as strings com quebra de linha
                string conteudo = string.Join(Environment.NewLine, linhas);

                // Escrevendo no arquivo
                File.WriteAllText(caminhoArquivo, conteudo);

                return caminhoArquivo;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o arquivo: {ex.Message}");
                return null;
            }
        }

    }
}
