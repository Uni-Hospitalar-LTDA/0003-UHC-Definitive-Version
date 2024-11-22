using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;


namespace UHC3_Definitive_Version.Domain.IMS
{
    public class Descricao_IMSProduto : Querys<Descricao_IMSProduto>
    {
        public string _010Tipo_de_Registro { get; set; }
        public string _020Embalagem { get; set; }
        public string _030Fixo { get; set; }
        public string _040Codigo_do_produto { get; set; }
        public string _050Fixo { get; set; }
        public string _060Codigo_de_barras { get; set; }
        public string _070Flag { get; set; }
        public string _080Nome_do_produto_Apresentacao { get; set; }
        public string _090Filler { get; set; }
        public string _100Fabricante { get; set; }
        public string _110Preco_fabrica { get; set; }
        public string _120Tipo_de_produto { get; set; }
        public string _130Classificacao_fiscal { get; set; }
        public string _140Data_do_cadastro { get; set; }
        public string _150Controle_Interno_IQVIA { get; set; }

        public static Tuple<string, string> getLayoutQueries(DateTime date, string id)
        {
            string queryAllow = $@"SELECT       distinct                                          
                         _010Tipo_de_Registro = '{8}'
                        ,_020Embalagem = ''
                        ,_030Fixo = '{0}'
                        ,_040Codigo_do_produto = produto.Codigo
                        ,_050Fixo = '{0}'
                        ,_060Codigo_de_barras = isnull(Produto.Cod_EAN,'')
                        ,_070Flag = '{1}'
                        ,_080Nome_do_produto_apresentacao = Produto.Descricao
                        ,_090Filler = ''
                        ,_100Fabricante = fabricante.Fantasia
                        ,_110Preco_fabrica = CONVERT(NUMERIC(14,2),ROUND(Produto.Prc_CustoMedio,2))
                        ,_120Tipo_de_Produto = '{"MEDICAMENTOS"}'
                        ,_130Classificacao_fiscal = Produto.Cod_ClaFis
                        ,_140Data_do_cadastro =  isnull(Produto.Dat_Cadastro,'')
                        ,_150Controle_Interno_IQVIA = 'P'                                                   
                    FROM [DMD].dbo.[NFSCB] NF_Saida
                    JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida_Itens.Num_Nota = NF_Saida.Num_Nota
                    JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
                    JOIN [DMD].dbo.[FABRI] Fabricante ON Produto.Cod_Fabricante = Fabricante.Codigo						
                    JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente	
                    WHERE         								

{(Section.Unidade == "SP HOSPITALAR" ? "" : $@"/** Condicional Temporária **/
                            NOT (Fabricante.Fantasia LIKE '%EUROFARMA%' AND Tipo_Consumidor IN ('P','M','E'))
                            AND
                            /** Fim Condicional Temporária **/
                            ")}


                            /*Condicional Data*/
                            NF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'                               
                            /*Condicional tipo de saída*/
                            AND (NF_Saida.Tip_Saida = 'V' OR NF_Saida.Tip_Saida = 'D' OR NF_Saida.Cod_CFO1 in (5910,6910))					    																
                            AND (
                                0 = (IIF(EXISTS(SELECT 1
                                                FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
                                                WHERE typeBlock = 'P'
                                                AND id_Panel = {id}  
                                                AND external_Code = Produto.Codigo),1,0))
                                )
                            AND 

                              /*Bloqueio secundário por Clientes*/
                              0 = (IIF(NOT EXISTS(
                                  SELECT 1
                                  FROM [DMD].dbo.[NFSIT] iNF_Saida_Itens
                                  JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iNF_Saida_Itens.Num_Nota
                                  WHERE iNF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'
                                  AND iNF_Saida_Itens.Cod_Produto = Produto.Codigo),1,0)
                              )
                              AND 
                              /*Bloqueio secundário por Fornecedor*/
                              0 = (IIF(EXISTS(
                                  SELECT 1
                                  FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
                                  WHERE TypeBlock = 'F'
                                  AND id_Panel = {id} 
                                  AND external_Code = Produto.Cod_Fabricante),1,0))
                              AND
                              /*Bloqueio de Produto por NF*/
                              0 = (IIF(EXISTS(
                                  SELECT 1 
                                  FROM [UHCDB].dbo.[Iqvia_DetailedBlocks] iBlocks
                                  JOIN [DMD].dbo.[NFSIT] iNF_Saida_Itens ON iNF_Saida_Itens.Num_Nota = iBlocks.External_Code
                                  WHERE TypeBlock = 'N' AND id_Panel = {id}
                                  AND iNF_Saida_Itens.Cod_Produto = Produto.Codigo),1,0))
                    ";

            string queryDeny = $@"SELECT            distinct                                     
                         _010Tipo_de_Registro = '{8}'
                        ,_020Embalagem = ''
                        ,_030Fixo = '{0}'
                        ,_040Codigo_do_produto = produto.Codigo
                        ,_050Fixo = '{0}'
                        ,_060Codigo_de_barras = isnull(Produto.Cod_EAN,'')
                        ,_070Flag = '{1}'
                        ,_080Nome_do_produto_apresentacao = Produto.Descricao
                        ,_090Filler = ''
                        ,_100Fabricante = fabricante.Fantasia
                        ,_110Preco_fabrica = CONVERT(NUMERIC(14,2),ROUND(Produto.Prc_CustoMedio,2))
                        ,_120Tipo_de_Produto = ''
                        ,_130Classificacao_fiscal = Produto.Cod_ClaFis
                        ,_140Data_do_cadastro =  isnull(Produto.Dat_Cadastro,'')
                        ,_150Controle_Interno_IQVIA = 'P'                                                   
                    FROM [DMD].dbo.[NFSCB] NF_Saida
                    JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida_Itens.Num_Nota = NF_Saida.Num_Nota
                    JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
                    JOIN [DMD].dbo.[FABRI] Fabricante ON Produto.Cod_Fabricante = Fabricante.Codigo						
                    JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente	
                    WHERE                       

{(Section.Unidade == "SP HOSPITALAR" ? "" : $@"/** Condicional Temporária **/
                            NOT (Fabricante.Fantasia LIKE '%EUROFARMA%' AND Tipo_Consumidor IN ('P','M','E'))
                            AND
                            /** Fim Condicional Temporária **/
                            ")}

                            /*Condicional Data*/
                            NF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'                               
                            /*Condicional tipo de saída*/
                            AND (NF_Saida.Tip_Saida = 'V' OR NF_Saida.Tip_Saida = 'D' OR NF_Saida.Cod_CFO1 in (5910,6910))					    																
                            AND (
                                1 = (IIF(EXISTS(SELECT 1
                                                FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
                                                WHERE typeBlock = 'P'
                                                AND id_Panel = {id}  
                                                AND external_Code = Produto.Codigo),1,0))
                                )
                            OR 

                              /*Bloqueio secundário por Clientes*/
                              1 = (IIF(NOT EXISTS(
                                  SELECT 1
                                  FROM [DMD].dbo.[NFSIT] iNF_Saida_Itens
                                  JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iNF_Saida_Itens.Num_Nota
                                  WHERE iNF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'
                                  AND iNF_Saida_Itens.Cod_Produto = Produto.Codigo),1,0)
                              )
                              OR 
                              /*Bloqueio secundário por Fornecedor*/
                              1 = (IIF(EXISTS(
                                  SELECT 1
                                  FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
                                  WHERE TypeBlock = 'F'
                                  AND id_Panel = {id} 
                                  AND external_Code = Produto.Cod_Fabricante),1,0))
                              OR
                              /*Bloqueio de Produto por NF*/
                              1 = (IIF(EXISTS(
                                  SELECT 1 
                                  FROM [UHCDB].dbo.[Iqvia_DetailedBlocks] iBlocks
                                  JOIN [DMD].dbo.[NFSIT] iNF_Saida_Itens ON iNF_Saida_Itens.Num_Nota = iBlocks.External_Code
                                  WHERE TypeBlock = 'N' AND id_Panel = {id}
                                  AND iNF_Saida_Itens.Cod_Produto = Produto.Codigo),1,0))
                    ";

            return new Tuple<string, string>(queryAllow, queryDeny);
        }


        private static string getDescricao(List<Descricao_IMSProduto> descricao)
        {
            string headerString = null;
            string descriptionTotal = null;
            int x = 1;

            foreach(var descricao_lista in descricao)
            {
                if(descricao != null)
                {
                    headerString =
                    descricao_lista._010Tipo_de_Registro?.PadRight(1).Substring(0, 1)
                    + descricao_lista._020Embalagem?.PadRight(1).Substring(0, 1)
                    + descricao_lista._030Fixo?.PadRight(1).Substring(0, 1)
                    + descricao_lista._040Codigo_do_produto?.PadLeft(13, '0').Substring(0, 13)
                    + descricao_lista._050Fixo?.PadRight(1).Substring(0, 1)
                    + descricao_lista._060Codigo_de_barras?.PadRight(13).Substring(0, 13)
                    + descricao_lista._070Flag?.PadRight(1).Substring(0, 1)
                    + descricao_lista._080Nome_do_produto_Apresentacao?.PadRight(70).Substring(0, 70)
                    + descricao_lista._090Filler?.PadRight(8).Substring(0, 8)
                    + descricao_lista._100Fabricante?.PadRight(40).Substring(0, 40)
                    + descricao_lista._110Preco_fabrica?.Replace(",", "").PadLeft(9,'0').Substring(0, 9)
                    + descricao_lista._120Tipo_de_produto?.PadRight(20).Substring(0, 20)
                    + descricao_lista._130Classificacao_fiscal?.PadRight(15).Substring(0, 15)
                    + Convert.ToDateTime(descricao_lista._140Data_do_cadastro?.PadRight(8).Substring(0, 8)).ToString("ddMMyyyy")
                    + descricao_lista._150Controle_Interno_IQVIA?.PadRight(1).Substring(0, 1);

                    if (x < descricao.Count)
                        descriptionTotal = descriptionTotal + headerString + Environment.NewLine;
                    else
                        descriptionTotal = descriptionTotal + headerString;
                    x++;
                }
            }
       
            return descriptionTotal;
        }
        public static async Task<Tuple<string, int>> getDescricao(DateTime date,string id)
        {
            
            List<Descricao_IMSProduto> descricao = await getAllToList(getLayoutQueries(date,id).Item1);
                 return new Tuple<string,int>(getDescricao(descricao), descricao.Count);

        }

        public async static Task<Tuple<List<Descricao_IMSProduto>,List<Descricao_IMSProduto>>> getAllTolistAsync(DateTime date,string id)
        {
            var queries = getLayoutQueries(date,id);
			Console.WriteLine(queries.Item1);
            Console.WriteLine(queries.Item2);
            List<Descricao_IMSProduto> Alloweds = await getAllToList(queries.Item1);
			List<Descricao_IMSProduto> Denieds = await getAllToList(queries.Item2);
			return new Tuple<List<Descricao_IMSProduto>, List<Descricao_IMSProduto>>(Alloweds,Denieds);
        }




    }

}
