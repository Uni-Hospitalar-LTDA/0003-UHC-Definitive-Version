using UHC3_Definitive_Version.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.IMS
{
    public class Descricao_IMSVendas : Querys<Descricao_IMSVendas>
    {
        public string index { get; set; }
        public string block { get; set; }
		public string Num_Nota { get; set; }
        public string _010Tipo_de_Registro { get; set; }
        public string _020ID_Periodo { get; set; }
        public string _030Codigo_cliente { get; set; }
        public string _040Flag_do_cliente { get; set; }
        public string _050Fixo { get; set; }
        public string _060Codigo_produto { get; set; }
        public string _070Flag_produto { get; set; }
        public string _080Flag_venda { get; set; }
        public string _090Quantidade { get; set; }
        public string _100Filler { get; set; }


		public static string getLayout(DateTime date, string id)
		{
            string query = $@"

DECLARE @count INT
SELECT @count = COUNT(*) FROM [UHCDB].dbo.[Iqvia_LineBlock] WHERE id_Panel = {id}

IF @count > 0
BEGIN
    SELECT
    lineBlock.indexColumn [index],
    block = CASE 
                WHEN Produto_Dblocks.External_Code IS NOT NULL OR Cliente_Dblocks.External_Code IS NOT NULL OR Fabricante_Dblocks.External_Code IS NOT NULL OR NF_Saida_Itens_Dblocks.External_Code IS NOT NULL 
                THEN 'false' 
                ELSE 'true' 
            END,
	 NF_Saida.Num_Nota [Num_Nota],
    _010Tipo_de_Registro = '{5}',
    _020ID_Periodo = '{date.ToString("dd")}',
    _030Codigo_cliente = ISNULL(NF_Saida.Cod_Cliente, ''),
    _040Flag_do_cliente = '{1}',
    _050Fixo = '{0}',
    _060Codigo_produto = ISNULL(NF_Saida_Itens.Cod_Produto, ''),
    _070Flag_produto = '{1}',
    _080Flag_venda = CASE
                        WHEN NF_Saida.Tip_Saida = 'V' THEN 'N'
                        ELSE 'D'
                    END,
    _090Quantidade = SUM(ISNULL(lineBlock.qtdProduto, 0)),
    _100Filler = '{"V"}'                       
FROM [DMD].dbo.[NFSCB] NF_Saida
JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
JOIN [DMD].dbo.[TBCFO] CFOP ON CFOP.Codigo = NF_Saida.Cod_Cfo1
JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
JOIN [DMD].dbo.[FABRI] Fabricante ON Produto.Cod_Fabricante = Fabricante.Codigo						
JOIN [DMD].dbo.[CLIEN] Cliente ON NF_Saida.Cod_Cliente = Cliente.Codigo	
JOIN [UHCDB].dbo.[Iqvia_LineBlock] lineBlock ON lineBlock.Num_nota = NF_Saida_Itens.Num_Nota AND lineBlock.codProduto = NF_Saida_Itens.Cod_Produto
LEFT JOIN [UHCDB].dbo.[Iqvia_DetailedBlocks] Produto_Dblocks ON Produto_Dblocks.ID_Panel = {id} AND Produto_Dblocks.TypeBlock = 'P' AND Produto_Dblocks.External_Code = Produto.Codigo
LEFT JOIN [UHCDB].dbo.[Iqvia_DetailedBlocks] Cliente_Dblocks ON Cliente_Dblocks.ID_Panel = {id} AND Cliente_Dblocks.TypeBlock = 'C' AND Cliente_Dblocks.External_Code = Cliente.Codigo
LEFT JOIN [UHCDB].dbo.[Iqvia_DetailedBlocks] Fabricante_Dblocks ON Fabricante_Dblocks.ID_Panel = {id} AND Fabricante_Dblocks.TypeBlock = 'F' AND Fabricante_Dblocks.External_Code = Fabricante.Codigo
LEFT JOIN [UHCDB].dbo.[Iqvia_DetailedBlocks] NF_Saida_Itens_Dblocks ON NF_Saida_Itens_Dblocks.ID_Panel = {id} AND NF_Saida_Itens_Dblocks.TypeBlock = 'N' AND NF_Saida_Itens_Dblocks.External_Code = NF_Saida_Itens.Num_Nota
WHERE 
/** Condicional Temporária **/
								NOT (Fabricante.Fantasia LIKE '%EUROFARMA%' AND Tipo_Consumidor IN ('P','M','E'))
								AND
								/** Fim Condicional Temporária **/
STATUS = 'F' 
    AND (NF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}')
    AND (NF_Saida.Tip_Saida = 'V' OR NF_Saida.Tip_Saida = 'D')
    AND CFOP.Descricao NOT LIKE '%CONSIG%'
	AND lineBlock.qtdProduto <> 0
    and (NOT (Produto_Dblocks.External_Code IS NOT NULL OR Cliente_Dblocks.External_Code IS NOT NULL OR Fabricante_Dblocks.External_Code IS NOT NULL OR NF_Saida_Itens_Dblocks.External_Code IS NOT NULL ))
GROUP BY 
 lineBlock.indexColumn
,NF_Saida.Num_Nota
,NF_Saida_Itens.Num_Nota
,NF_Saida.Cod_Cliente
,NF_Saida_Itens.Cod_Produto
,NF_Saida_Itens.Qtd_Produto
,NF_Saida.Tip_Saida
,Produto_Dblocks.External_Code 
,Cliente_Dblocks.External_Code
,Fabricante_Dblocks.External_Code
,NF_Saida_Itens_Dblocks.External_Code 
order by lineBlock.indexColumn ASC

END
ELSE
BEGIN
    SELECT
    [index] = ROW_NUMBER() OVER(ORDER BY NF_Saida.Cod_Cliente ASC, NF_Saida_iTENS.Cod_Produto ASC)-1,
    block = CASE 
                WHEN Produto_Dblocks.External_Code IS NOT NULL OR Cliente_Dblocks.External_Code IS NOT NULL OR Fabricante_Dblocks.External_Code IS NOT NULL OR NF_Saida_Itens_Dblocks.External_Code IS NOT NULL 
                THEN 'false' 
                ELSE 'true' 
            END,
	 NF_Saida.Num_Nota [Num_Nota],
    _010Tipo_de_Registro = '{5}',
    _020ID_Periodo = '{date.ToString("dd")}',
    _030Codigo_cliente = ISNULL(NF_Saida.Cod_Cliente, ''),
    _040Flag_do_cliente = '{1}',
    _050Fixo = '{0}',
    _060Codigo_produto = ISNULL(NF_Saida_Itens.Cod_Produto, ''),
    _070Flag_produto = '{1}',
    _080Flag_venda = CASE
                        WHEN NF_Saida.Tip_Saida = 'V' THEN 'N'
                        ELSE 'D'
                    END,
    _090Quantidade = ISNULL(NF_Saida_Itens.Qtd_Produto, ''),
    _100Filler = '{"V"}'                       
FROM [DMD].dbo.[NFSCB] NF_Saida
JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
JOIN [DMD].dbo.[TBCFO] CFOP ON CFOP.Codigo = NF_Saida.Cod_Cfo1
JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
JOIN [DMD].dbo.[FABRI] Fabricante ON Produto.Cod_Fabricante = Fabricante.Codigo						
JOIN [DMD].dbo.[CLIEN] Cliente ON NF_Saida.Cod_Cliente = Cliente.Codigo	
LEFT JOIN [UHCDB].dbo.[Iqvia_DetailedBlocks] Produto_Dblocks ON Produto_Dblocks.ID_Panel = {id} AND Produto_Dblocks.TypeBlock = 'P' AND Produto_Dblocks.External_Code = Produto.Codigo
LEFT JOIN [UHCDB].dbo.[Iqvia_DetailedBlocks] Cliente_Dblocks ON Cliente_Dblocks.ID_Panel = {id} AND Cliente_Dblocks.TypeBlock = 'C' AND Cliente_Dblocks.External_Code = Cliente.Codigo
LEFT JOIN [UHCDB].dbo.[Iqvia_DetailedBlocks] Fabricante_Dblocks ON Fabricante_Dblocks.ID_Panel = {id} AND Fabricante_Dblocks.TypeBlock = 'F' AND Fabricante_Dblocks.External_Code = Fabricante.Codigo
LEFT JOIN [UHCDB].dbo.[Iqvia_DetailedBlocks] NF_Saida_Itens_Dblocks ON NF_Saida_Itens_Dblocks.ID_Panel = {id} AND NF_Saida_Itens_Dblocks.TypeBlock = 'N' AND NF_Saida_Itens_Dblocks.External_Code = NF_Saida_Itens.Num_Nota
WHERE
/** Condicional Temporária **/
								NOT (Fabricante.Fantasia LIKE '%EUROFARMA%' AND Tipo_Consumidor IN ('P','M','E'))
								AND
								/** Fim Condicional Temporária **/
STATUS = 'F' 
    AND (NF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}')
    AND (NF_Saida.Tip_Saida = 'V' OR NF_Saida.Tip_Saida = 'D')
    AND CFOP.Descricao NOT LIKE '%CONSIG%'
GROUP BY 
 NF_Saida.Num_Nota
,NF_Saida_Itens.Num_Nota
,NF_Saida.Cod_Cliente
,NF_Saida_Itens.Cod_Produto
,NF_Saida_Itens.Qtd_Produto
,NF_Saida.Tip_Saida
,Produto_Dblocks.External_Code 
,Cliente_Dblocks.External_Code
,Fabricante_Dblocks.External_Code,
NF_Saida_Itens_Dblocks.External_Code 
ORDER BY NF_Saida.Cod_Cliente ASC, NF_Saida_iTENS.Cod_Produto ASC		
END
";
            Console.WriteLine(query);
            return query;

		}
		public static async Task<List<Descricao_IMSVendas>> getBlocksToListAsync(DateTime date, string id)
        {
            return await getAllToList(getLayout(date,id));
        }

        private static Tuple<string,string> getLayoutQueries(DateTime date, string id)
        {                                    
            string queryAllow = $@"SELECT
                                [index] = ROW_NUMBER() OVER(ORDER BY NF_Saida.Num_Nota)
                              ,_010Tipo_de_Registro = '{5}'
                              ,_020ID_Periodo = '{date.ToString("dd")}'
                              ,_030Codigo_cliente = isnull(NF_Saida.Cod_Cliente,'')
                              ,_040Flag_do_cliente = '{1}'
                              ,_050Fixo = '{0}'
                              ,_060Codigo_produto = isnull(NF_Saida_Itens.Cod_Produto,'')							  
                              ,_070Flag_produto = '{1}'
                              ,_080Flag_venda = CASE
													WHEN NF_Saida.Tip_Saida  = 'V' THEN 'N'
													ELSE 'D'
												END												
                              ,_090Quantidade = isnull(NF_Saida_Itens.Qtd_Produto,'')
                              ,_100Filler = '{"V"}'                       
                            FROM [DMD].dbo.[NFSCB] NF_Saida
                            JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
                            JOIN [DMD].dbo.[TBCFO] CFOP ON CFOP.Codigo = NF_Saida.Cod_Cfo1
							JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
							JOIN [DMD].dbo.[FABRI] as Fabricante on Produto.Cod_Fabricante = Fabricante.Codigo						
							JOIN [DMD].dbo.[CLIEN] as Cliente on Cliente.Codigo = NF_Saida.Cod_Cliente	
                            WHERE STATUS = 'F' 
                            AND (NF_Saida.Dat_Emissao =  '{date.ToString("yyyyMMdd")}')
                            AND (NF_Saida.Tip_Saida = 'V' OR NF_Saida.Tip_Saida  ='D' )
                            AND (CFOP.Descricao NOT LIKE '%CONSIG%')																				
							AND 
							(
								(0 = (IIF(((SELECT external_Code 
										   FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
										   WHERE ID_Panel = {id} AND TypeBlock = 'P'
										   and external_code = Produto.codigo										   
										   )
										   IS NOT NULL),1,0))
								)
								AND
								(0 = (IIF(((SELECT external_Code 
										   FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
										   WHERE ID_Panel = {id} AND TypeBlock = 'C'
										   and external_Code = Cliente.Codigo
										   )
										   IS NOT NULL),1,0))
								)
								AND
								(0 = (IIF(((SELECT top 1 external_Code 
										    FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]										    
										    WHERE 
												ID_Panel ={id} AND TypeBlock = 'F'
												and external_Code = Fabricante.Codigo
										   )
										   IS NOT NULL),1,0))
								)
                                AND
                                /*Bloqueio de Produto por NF*/
								(0 = (IIF((SELECT External_Code 
										FROM [UHCDB].dbo.[Iqvia_DetailedBlocks] iBlocks
										JOIN [DMD].dbo.[NFSIT] iNF_Saida_Itens ON iNF_Saida_Itens.Num_Nota = iBlocks.External_Code
										WHERE TypeBlock = 'N' AND id_Panel = {id}
										AND iNF_Saida_Itens.Cod_Produto = Produto.Codigo
									) IS NOT NULL,1,0)))
                                AND 
								((
									0 = (IIF((SELECT External_Code 
									FROM [UHCDB].dbo.[Iqvia_DetailedBlocks] iBlocks
									JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iBlocks.External_Code
									WHERE TypeBlock = 'N' AND id_Panel = {id} 
									AND iNF_Saida.Cod_Cliente = Cliente.Codigo
	
									) IS NOT NULL,1,0))))
                                


							)
							
												"
                       ;
            string queryDeny = $@"
                            SELECT
                               							[index] = ROW_NUMBER() OVER(ORDER BY NF_Saida.Num_Nota) + (SELECT COUNT(*)  FROM [DMD].dbo.[NFSCB] NF_Saida
                            JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
                            JOIN [DMD].dbo.[TBCFO] CFOP ON CFOP.Codigo = NF_Saida.Cod_Cfo1
							JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
							JOIN [DMD].dbo.[FABRI] as Fabricante on Produto.Cod_Fabricante = Fabricante.Codigo						
							JOIN [DMD].dbo.[CLIEN] as Cliente on Cliente.Codigo = NF_Saida.Cod_Cliente	
                            WHERE STATUS = 'F' 
                            AND (NF_Saida.Dat_Emissao =  '20230303')
                            AND (NF_Saida.Tip_Saida = 'V' OR NF_Saida.Tip_Saida  ='D' )
                            AND (CFOP.Descricao NOT LIKE '%CONSIG%')																				
							AND 
							(
								(0 = (IIF(((SELECT external_Code 
										   FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
										   WHERE ID_Panel = 135 AND TypeBlock = 'P'
										   and external_code = Produto.codigo										   
										   )
										   IS NOT NULL),1,0))
								)
								AND
								(0 = (IIF(((SELECT external_Code 
										   FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
										   WHERE ID_Panel = 135 AND TypeBlock = 'C'
										   and external_Code = Cliente.Codigo
										   )
										   IS NOT NULL),1,0))
								)
								AND
								(0 = (IIF(((SELECT top 1 external_Code 
										    FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]										    
										    WHERE 
												ID_Panel =135 AND TypeBlock = 'F'
												and external_Code = Fabricante.Codigo
										   )
										   IS NOT NULL),1,0))
								)
                                AND
                                /*Bloqueio de Produto por NF*/
								(0 = (IIF((SELECT External_Code 
										FROM [UHCDB].dbo.[Iqvia_DetailedBlocks] iBlocks
										JOIN [DMD].dbo.[NFSIT] iNF_Saida_Itens ON iNF_Saida_Itens.Num_Nota = iBlocks.External_Code
										WHERE TypeBlock = 'N' AND id_Panel = 135
										AND iNF_Saida_Itens.Cod_Produto = Produto.Codigo
									) IS NOT NULL,1,0)))
                                AND 
								((
									0 = (IIF((SELECT External_Code 
									FROM [UHCDB].dbo.[Iqvia_DetailedBlocks] iBlocks
									JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iBlocks.External_Code
									WHERE TypeBlock = 'N' AND id_Panel = 135 
									AND iNF_Saida.Cod_Cliente = Cliente.Codigo
	
									) IS NOT NULL,1,0))))                                
							))
                              ,_010Tipo_de_Registro = '{5}'
                              ,_020ID_Periodo = '{date.ToString("dd")}'
                              ,_030Codigo_cliente = isnull(NF_Saida.Cod_Cliente,'')
                              ,_040Flag_do_cliente = '{1}'
                              ,_050Fixo = '{0}'
                              ,_060Codigo_produto = isnull(NF_Saida_Itens.Cod_Produto,'')							  
                              ,_070Flag_produto = '{1}'
                              ,_080Flag_venda = CASE
													WHEN NF_Saida.Tip_Saida  = 'V' THEN 'N'
													ELSE 'D'
												END												
                              ,_090Quantidade = isnull(NF_Saida_Itens.Qtd_Produto,'')
                              ,_100Filler = '{"V"}'                       
                            FROM [DMD].dbo.[NFSCB] NF_Saida
                            JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
                            JOIN [DMD].dbo.[TBCFO] CFOP ON CFOP.Codigo = NF_Saida.Cod_Cfo1
							JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
							JOIN [DMD].dbo.[FABRI] as Fabricante on Produto.Cod_Fabricante = Fabricante.Codigo						
							JOIN [DMD].dbo.[CLIEN] as Cliente on Cliente.Codigo = NF_Saida.Cod_Cliente	
                            WHERE STATUS = 'F' 
                            AND (NF_Saida.Dat_Emissao =  '{date.ToString("yyyyMMdd")}')
                            AND (NF_Saida.Tip_Saida = 'V' OR NF_Saida.Tip_Saida  ='D' )
                            AND (CFOP.Descricao NOT LIKE '%CONSIG%')																				
							AND 
							(
								(1 = (IIF(((SELECT external_Code 
										   FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
										   WHERE ID_Panel = {id} AND TypeBlock = 'P'
										   and external_code = Produto.codigo										   
										   )
										   IS NOT NULL),1,0))
								)
								OR
								(1 = (IIF(((SELECT external_Code 
										   FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
										   WHERE ID_Panel = {id} AND TypeBlock = 'C'
										   and external_Code = Cliente.Codigo
										   )
										   IS NOT NULL),1,0))
								)
								OR
								(1 = (IIF(((SELECT top 1 external_Code 
										    FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]										    
										    WHERE 
												ID_Panel ={id} AND TypeBlock = 'F'
												and external_Code = Fabricante.Codigo
										   )
										   IS NOT NULL),1,0))
								)
								OR
                                /*Bloqueio de Produto por NF*/
								(1 = (IIF((SELECT External_Code 
										FROM [UHCDB].dbo.[Iqvia_DetailedBlocks] iBlocks
										JOIN [DMD].dbo.[NFSIT] iNF_Saida_Itens ON iNF_Saida_Itens.Num_Nota = iBlocks.External_Code
										WHERE TypeBlock = 'N' AND id_Panel = {id}
										AND iNF_Saida_Itens.Cod_Produto = Produto.Codigo
									) IS NOT NULL,1,0)))
                                OR 
								((
									1 = (IIF((SELECT External_Code 
									FROM [UHCDB].dbo.[Iqvia_DetailedBlocks] iBlocks
									JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iBlocks.External_Code
									WHERE TypeBlock = 'N' AND id_Panel = {id} 
									AND iNF_Saida.Cod_Cliente = Cliente.Codigo
	
									) IS NOT NULL,1,0))))

							)
							
												"
                        ;
            return new Tuple<string, string>(queryAllow, queryDeny);
        }
        public static async Task<List<Descricao_IMSVendas>> gettAllBlocksToListAsync(DateTime date, string id)
		{
            string queryAllow = $@"SELECT
    [index] = ROW_NUMBER() OVER(ORDER BY NF_Saida.Cod_Cliente ASC, NF_Saida_iTENS.Cod_Produto ASC)-1,
    block = CASE 
                WHEN Produto_Dblocks.External_Code IS NOT NULL OR Cliente_Dblocks.External_Code IS NOT NULL OR Fabricante_Dblocks.External_Code IS NOT NULL OR NF_Saida_Itens_Dblocks.External_Code IS NOT NULL 
                THEN 'false' 
                ELSE 'true' 
            END,
	 NF_Saida.Num_Nota [Num_Nota],
    _010Tipo_de_Registro = '{5}',
    _020ID_Periodo = '{date.ToString("dd")}',
    _030Codigo_cliente = ISNULL(NF_Saida.Cod_Cliente, ''),
    _040Flag_do_cliente = '{1}',
    _050Fixo = '{0}',
    _060Codigo_produto = ISNULL(NF_Saida_Itens.Cod_Produto, ''),
    _070Flag_produto = '{1}',
    _080Flag_venda = CASE
                        WHEN NF_Saida.Tip_Saida = 'V' THEN 'N'
                        ELSE 'D'
                    END,
    _090Quantidade = ISNULL(NF_Saida_Itens.Qtd_Produto, ''),
    _100Filler = '{"V"}'                       
FROM [DMD].dbo.[NFSCB] NF_Saida
JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
JOIN [DMD].dbo.[TBCFO] CFOP ON CFOP.Codigo = NF_Saida.Cod_Cfo1
JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
JOIN [DMD].dbo.[FABRI] Fabricante ON Produto.Cod_Fabricante = Fabricante.Codigo						
JOIN [DMD].dbo.[CLIEN] Cliente ON NF_Saida.Cod_Cliente = Cliente.Codigo	
LEFT JOIN [UHCDB].dbo.[Iqvia_DetailedBlocks] Produto_Dblocks ON Produto_Dblocks.ID_Panel = {id} AND Produto_Dblocks.TypeBlock = 'P' AND Produto_Dblocks.External_Code = Produto.Codigo
LEFT JOIN [UHCDB].dbo.[Iqvia_DetailedBlocks] Cliente_Dblocks ON Cliente_Dblocks.ID_Panel = {id} AND Cliente_Dblocks.TypeBlock = 'C' AND Cliente_Dblocks.External_Code = Cliente.Codigo
LEFT JOIN [UHCDB].dbo.[Iqvia_DetailedBlocks] Fabricante_Dblocks ON Fabricante_Dblocks.ID_Panel = {id} AND Fabricante_Dblocks.TypeBlock = 'F' AND Fabricante_Dblocks.External_Code = Fabricante.Codigo
LEFT JOIN [UHCDB].dbo.[Iqvia_DetailedBlocks] NF_Saida_Itens_Dblocks ON NF_Saida_Itens_Dblocks.ID_Panel = {id} AND NF_Saida_Itens_Dblocks.TypeBlock = 'N' AND NF_Saida_Itens_Dblocks.External_Code = NF_Saida_Itens.Num_Nota
WHERE 
/** Condicional Temporária **/
								NOT (Fabricante.Fantasia LIKE '%EUROFARMA%' AND Tipo_Consumidor IN ('P','M','E'))
								AND
								/** Fim Condicional Temporária **/
STATUS = 'F' 
    AND (NF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}')
    AND (NF_Saida.Tip_Saida = 'V' OR NF_Saida.Tip_Saida = 'D')
    AND CFOP.Descricao NOT LIKE '%CONSIG%'
GROUP BY 
 NF_Saida.Num_Nota
,NF_Saida_Itens.Num_Nota
,NF_Saida.Cod_Cliente
,NF_Saida_Itens.Cod_Produto
,NF_Saida_Itens.Qtd_Produto
,NF_Saida.Tip_Saida
,Produto_Dblocks.External_Code 
,Cliente_Dblocks.External_Code
,Fabricante_Dblocks.External_Code,
NF_Saida_Itens_Dblocks.External_Code 
ORDER BY NF_Saida.Cod_Cliente ASC, NF_Saida_iTENS.Cod_Produto ASC												"
                      ;
            
			return await Descricao_IMSVendas.getAllToList(queryAllow);

        }
		
		private static string getDescricao(List<Descricao_IMSVendas> descricao)
        {
            string headerString = null;
            string descriptionTotal = null;
            int x = 1;

            foreach (var descricao_lista in descricao)
            {
                if (descricao != null && descricao_lista.block != "false")
                {
                    headerString =
                    descricao_lista._010Tipo_de_Registro?.PadRight(1).Substring(0, 1)
                   + descricao_lista._020ID_Periodo?.PadRight(2).Substring(0, 2)
                   + descricao_lista._030Codigo_cliente?.PadLeft(14, '0').Substring(0, 14)
                   + descricao_lista._040Flag_do_cliente?.PadRight(1).Substring(0, 1)
                   + descricao_lista._050Fixo?.PadRight(1).Substring(0, 1)
                   + descricao_lista._060Codigo_produto?.PadLeft(13, '0').Substring(0, 13)
                   + descricao_lista._070Flag_produto?.PadRight(1).Substring(0, 1)
                   + descricao_lista._080Flag_venda?.PadRight(1).Substring(0, 1)
                   + descricao_lista._090Quantidade?.PadLeft(8, '0').Substring(0, 8)
                   + descricao_lista._100Filler?.PadRight(1).Substring(0, 1);



                    if (x < descricao.Count)
                        descriptionTotal = descriptionTotal + headerString + Environment.NewLine;
                    else
                        descriptionTotal = descriptionTotal + headerString;
                    x++;
                }
            }

            return descriptionTotal;
        }
        public static async Task<Tuple<string, int,int,int>> getDescricao(DateTime date,string id)
        {

            //List<Descricao_IMSVendas> descricao = await getAllToList(getLayoutQueries(date,id).Item1);
            List<Descricao_IMSVendas> descricao = await getAllToList(getLayout(date, id));
            int qtdTotal = descricao.Count;
            //MessageBox.Show(qtdTotal.ToString());
            int qtdTotalItens = descricao.Sum(x => Convert.ToInt32(x._090Quantidade));
            int qtdTotalItensDev = descricao.Where(x => x._080Flag_venda.Equals("D")).Sum(x => Convert.ToInt32(x._090Quantidade));            
            return new Tuple<string, int,int,int>(getDescricao(descricao),qtdTotal,qtdTotalItens,qtdTotalItensDev);

        }
        public async static Task<Tuple<List<Descricao_IMSVendas>, List<Descricao_IMSVendas>>> getAllTolistAsync(DateTime date,string id)
        {
            var queries = getLayoutQueries(date, id);
            List<Descricao_IMSVendas> Alloweds = await getAllToList(queries.Item1);
            List<Descricao_IMSVendas> Denieds = await getAllToList(queries.Item2);
            return  new Tuple<List<Descricao_IMSVendas>, List<Descricao_IMSVendas>>(Alloweds,Denieds);
        }

    }

}
