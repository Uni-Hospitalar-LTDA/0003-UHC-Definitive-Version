using UHC3_Definitive_Version.Configuration;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace UHC3_Definitive_Version.Domain.IMS
{
    public class Descricao_IMSCliente : Querys<Descricao_IMSCliente>
    {
        public string _010Tipo_de_Registro { get; set; }
        public string _020Codigo_do_cliente { get; set; }
        public string _030CNPJ_CRM {get;set;}
        public string _040Flag { get; set; }
        public string _050Nome_fantasia { get; set; }
        public string _060Razao_social { get; set; }
        public string _070Flag_endereco { get; set; }
        public string _080Endereco { get; set; }
        public string _090Complemento { get; set; }
        public string _100CEP { get; set; }
        public string _110Cidade { get; set; }
        public string _120Estado { get; set; }
        public string _130Telefone { get; set; } 
        public string _140Fax { get; set; } 
        public string _150Data_cadastro { get; set; } 
        public string _160email {get;set;} 
        public string _170URL { get; set; } 
        public string _180Filler { get; set; }
        public string _190Controle_interno_IQVIA { get; set; }
                
        private static string getDescriptions(List<Descricao_IMSCliente> descriptions)
        {
            string headerString = null;
            string descriptionTotal = null;
            int x = 1;

                foreach (var description in descriptions)
                {                                    
                    if (description != null)
                    {                                                
                        headerString =
                          description._010Tipo_de_Registro?.PadRight(1).Substring(0, 1)
                        + description._020Codigo_do_cliente?.PadLeft(14, '0').Substring(0, 14)
                        + description._030CNPJ_CRM?.PadLeft(14, '0').Substring(0, 14)
                        + description._040Flag?.PadRight(1).Substring(0, 1)
                        + description._050Nome_fantasia?.PadRight(40).Substring(0, 40)
                        + description._060Razao_social?.PadRight(40).Substring(0, 40)
                        + description._070Flag_endereco?.PadRight(1).Substring(0, 1)
                        + description._080Endereco?.PadRight(70).Substring(0, 70)
                        + description._090Complemento?.PadRight(20).Substring(0, 20)
                        + description._100CEP?.PadRight(8).Substring(0, 8)
                        + description._110Cidade?.PadRight(30).Substring(0, 30)
                        + description._120Estado?.PadRight(2).Substring(0, 2)
                        + description._130Telefone?.PadRight(20).Substring(0, 20)
                        + description._140Fax?.PadRight(20).Substring(0, 20)
                        + Convert.ToDateTime(description._150Data_cadastro?.PadRight(8).Substring(0, 8)).ToString("ddMMyyyy")
                        + description._160email?.PadRight(35).Substring(0, 35)
                        + description._170URL?.PadRight(25).Substring(0, 25)
                        + description._180Filler?.PadRight(5).Substring(0, 5)
                        + description._190Controle_interno_IQVIA?.PadRight(1).Substring(0, 1)
                        ;
                    if (x < descriptions.Count)
                        descriptionTotal = descriptionTotal + headerString + Environment.NewLine;
                    else
                        descriptionTotal = descriptionTotal + headerString;
                    x++;
                    }
                }
                           
            return descriptionTotal;        
        }
       
        private static Tuple<string,string> getLayoutQueries(DateTime date,string id)
        {
            string queryAllow = $@"SELECT 
                        	 _010Tipo_de_Registro = '{2}'
                        	,_020Codigo_do_cliente = NF_Saida.Cod_Cliente
                        	,_030CNPJ_CRM = NF_Saida.Cgc
                        	,_040Flag = '{1}'
                        	,_050Nome_fantasia = isnull(Cliente.Fantasia,'')
                        	,_060Razao_social = isnull(Cliente.Razao_Social,'')
                        	,_070Flag_endereco = '{1}'
                        	,_080Endereco = isnull(Cliente.Endereco+', '+Cliente.Numero,'')
                        	,_090Complemento = isnull(Cliente.Complemento,'')
                        	,_100CEP = isnull(Cliente.Cep,'')
                        	,_110Cidade = isnull(Cidade.Descricao,'')
                        	,_120Estado = isnull(Cliente.Cod_Estado,'')
                        	,_130Telefone = isnull('('+Cliente.Cod_DDD_1+') ' + Cliente.Fone1,'')
                        	,_140Fax = isnull(Cliente.Fax,'')
                        	,_150Data_cadastro = isnull(Cliente.Data_Cadastro,'')
                        	,_160email = isnull(Cliente.Email,'')
                        	,_170URL = ''
                        	,_180Filler = ''
                        	,_190Controle_interno_IQVIA  = '{"C"}'
                        FROM [DMD].dbo.[NFSCB] NF_Saida
                        JOIN [DMD].dbo.[CLIEN] Cliente ON NF_Saida.Cod_Cliente = Cliente.Codigo
                        JOIN [DMD].dbo.[CIDAD] Cidade ON Cidade.Codigo = Cliente.Cod_Cidade  
                        JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida_Itens.Num_Nota = NF_Saida.Num_Nota
						JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
						JOIN [DMD].dbo.[FABRI] Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante
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
						/*Condicionais de Bloqueio*/

						AND 
							/*Bloqueio principal por Cliente */
							(0 = (IIF((SELECT distinct external_Code
															 FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
															 WHERE typeBlock = 'C'
															 AND id_Panel = {id} 
															 AND external_Code = Cliente.Codigo) IS NOT NULL
									      ,1,0))
							 AND 							 
						      /*Bloqueio secundário por produtos*/
							 (0 =(SELECT 
								 (IIF(
								     (SELECT Count(*) 
									  FROM [DMD].dbo.[NFSIT] NF_Saida_Itens
									  JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
									  WHERE NF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'
											AND Cod_Cliente = Cliente.Codigo ) 											
											=								  
	   								 (SELECT count(distinct external_Code)
								      FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
								      WHERE (typeBlock = 'P' AND id_Panel = {id} )
									        AND 1 = IIF((SELECT Cod_Produto
																 FROM [DMD].dbo.[NFSIT] NF_Saida_Itens
																 JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
																 WHERE NF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'
																 AND Cod_Cliente = Cliente.Codigo 
																 AND Cod_Produto = external_Code) IS NOT NULL,1,0))
								,1,0))))

								AND 
								/*Bloqueio secundário por Fornecedor*/
								(0 = (IIF(
								     (SELECT Count(*) 
									  FROM [DMD].dbo.[NFSIT] NF_Saida_Itens
									  JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
									  JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
									  WHERE NF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'
											AND Cod_Cliente = Cliente.Codigo ) 											
											=								  
	   								 (SELECT count(*)
								      FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
								      WHERE (typeBlock = 'F' AND id_Panel = {id})
									        AND 1 = (IIF((SELECT TOP 1 Cod_Fabricante
																 FROM [DMD].dbo.[NFSIT] iNF_Saida_Itens
																 JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iNF_Saida_Itens.Num_Nota
																 JOIN [DMD].dbo.[PRODU] iProduto ON iProduto.Codigo = iNF_Saida_Itens.Cod_Produto
																 WHERE iNF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'
																 AND iNF_Saida .Cod_Cliente = Cliente.Codigo
																 AND iProduto.Cod_Fabricante = External_code) IS NOT NULL,1,0) )
								),1,0)))		
								AND 
								((
									0 = (IIF((SELECT distinct External_Code 
									FROM [UHCDB].dbo.[Iqvia_DetailedBlocks] iBlocks
									JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iBlocks.External_Code
									WHERE TypeBlock = 'N' AND id_Panel = {id} 
									AND iNF_Saida.Cod_Cliente = Cliente.Codigo
	
									) IS NOT NULL,1,0))))
								)                               
                        GROUP BY 
                        		NF_Saida.Cod_Cliente
                        	   ,NF_Saida.Cgc
                        	   ,Cliente.Fantasia
                        	   ,Cliente.Razao_Social
                        	   ,Cliente.Endereco
                               ,Cliente.Numero
                        	   ,Cliente.Complemento
                        	   ,Cliente.Cep
                        	   ,Cidade.Descricao
                        	   ,Cliente.Cod_Estado
                               ,Cliente.Cod_DDD_1                        	   
                               ,Cliente.Fone1
                        	   ,Cliente.Fax
                        	   ,Cliente.Data_Cadastro
                        	   ,Cliente.Email         "
                       ;
			string queryDeny = $@"SELECT 
                        	 _010Tipo_de_Registro = '{2}'
                        	,_020Codigo_do_cliente = NF_Saida.Cod_Cliente
                        	,_030CNPJ_CRM = NF_Saida.Cgc
                        	,_040Flag = '{1}'
                        	,_050Nome_fantasia = isnull(Cliente.Fantasia,'')
                        	,_060Razao_social = isnull(Cliente.Razao_Social,'')
                        	,_070Flag_endereco = '{1}'
                        	,_080Endereco = isnull(Cliente.Endereco+', '+Cliente.Numero,'')
                        	,_090Complemento = isnull(Cliente.Complemento,'')
                        	,_100CEP = isnull(Cliente.Cep,'')
                        	,_110Cidade = isnull(Cidade.Descricao,'')
                        	,_120Estado = isnull(Cliente.Cod_Estado,'')
                        	,_130Telefone = isnull('('+Cliente.Cod_DDD_1+') ' + Cliente.Fone1,'')
                        	,_140Fax = isnull(Cliente.Fax,'')
                        	,_150Data_cadastro = isnull(Cliente.Data_Cadastro,'')
                        	,_160email = isnull(Cliente.Email,'')
                        	,_170URL = ''
                        	,_180Filler = ''
                        	,_190Controle_interno_IQVIA  = '{"C"}'
                        FROM [DMD].dbo.[NFSCB] NF_Saida
                        JOIN [DMD].dbo.[CLIEN] Cliente ON NF_Saida.Cod_Cliente = Cliente.Codigo
                        JOIN [DMD].dbo.[CIDAD] Cidade ON Cidade.Codigo = Cliente.Cod_Cidade  
                        JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida_Itens.Num_Nota = NF_Saida.Num_Nota
						JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
						JOIN [DMD].dbo.[FABRI] Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante
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
						/*Condicionais de Bloqueio*/

						AND 
							/*Bloqueio principal por Cliente */
							(1 = (IIF((SELECT distinct external_Code
															 FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
															 WHERE typeBlock = 'C'
															 AND id_Panel = {id} 
															 AND external_Code = Cliente.Codigo) IS NOT NULL
									      ,1,0))
							 OR 							 
						      /*Bloqueio secundário por produtos*/
							 (1 =(SELECT 
								 (IIF(
								     (SELECT Count(*) 
									  FROM [DMD].dbo.[NFSIT] NF_Saida_Itens
									  JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
									  WHERE NF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'
											AND Cod_Cliente = Cliente.Codigo ) 											
											=								  
	   								 (
                                        SELECT count(distinct external_Code)
								      FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
								      WHERE ( typeBlock = 'P' or (TypeBlock ='F' AND external_Code = Produto.Cod_Fabricante)
									  AND id_Panel = {id})
									        AND (1 = 
											
											
											
											( IIF((SELECT Cod_Produto
														 FROM [DMD].dbo.[NFSIT] iNF_Saida_Itens
														 JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iNF_Saida_Itens.Num_Nota
														 JOIN [DMD].dbo.[PRODU] iProduto ON iProduto.Codigo = iNF_Saida_Itens.Cod_Produto
														 WHERE iNF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'
															   AND Cod_Cliente = Cliente.Codigo
															   AND Cod_Produto = external_Code) IS NOT NULL,1,0)															   															   															   
															   )
															   OR
											1= ( IIF((SELECT Cod_Fabricante
														 FROM [DMD].dbo.[NFSIT] iNF_Saida_Itens
														 JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iNF_Saida_Itens.Num_Nota
														 JOIN [DMD].dbo.[PRODU] iProduto ON iProduto.Codigo = iNF_Saida_Itens.Cod_Produto
														 WHERE iNF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'
															   AND Cod_Cliente =Cliente.Codigo
															   AND Cod_Fabricante = external_Code) IS NOT NULL,1,0)															   															   															   
															   )
															   ))
								,1,0))))

								OR 
								/*Bloqueio secundário por Fornecedor*/
								(1 = (IIF(
								     (SELECT Count(*) 
									  FROM [DMD].dbo.[NFSIT] NF_Saida_Itens
									  JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
									  JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
									  WHERE NF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'
											AND Cod_Cliente = Cliente.Codigo ) 											
											=								  
	   								 (SELECT count(*)
								      FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
								      WHERE (typeBlock = 'F' AND id_Panel = {id})
									        AND 1 = (IIF((SELECT TOP 1 Cod_Fabricante
																 FROM [DMD].dbo.[NFSIT] iNF_Saida_Itens
																 JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iNF_Saida_Itens.Num_Nota
																 JOIN [DMD].dbo.[PRODU] iProduto ON iProduto.Codigo = iNF_Saida_Itens.Cod_Produto
																 WHERE iNF_Saida.Dat_Emissao = '{date.ToString("yyyyMMdd")}'
																 AND iNF_Saida .Cod_Cliente = Cliente.Codigo
																 AND iProduto.Cod_Fabricante = External_code)IS NOT NULL,1,0) )
								),1,0)))
                                OR								
								((
									1 = (IIF((SELECT External_Code 
									FROM [UHCDB].dbo.[Iqvia_DetailedBlocks] iBlocks
									JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iBlocks.External_Code
									WHERE TypeBlock = 'N' AND id_Panel = {id} 
									AND iNF_Saida.Cod_Cliente = Cliente.Codigo
	
									) IS NOT NULL,1,0))))								
																	
								)                               
                        GROUP BY 
                        		NF_Saida.Cod_Cliente
                        	   ,NF_Saida.Cgc
                        	   ,Cliente.Fantasia
                        	   ,Cliente.Razao_Social
                        	   ,Cliente.Endereco
                               ,Cliente.Numero
                        	   ,Cliente.Complemento
                        	   ,Cliente.Cep
                        	   ,Cidade.Descricao
                        	   ,Cliente.Cod_Estado
                               ,Cliente.Cod_DDD_1                        	   
                        	   ,Cliente.Fone1
                        	   ,Cliente.Fax
                        	   ,Cliente.Data_Cadastro
                        	   ,Cliente.Email        "
                        ;
            Console.WriteLine(queryAllow);
            return new Tuple<string, string>(queryAllow, queryDeny);
            
        }

        public static async Task<Tuple<string,int>> getDescriptionAsync(DateTime date, string id)
        {
                       
            List<Descricao_IMSCliente> descriptions = await getAllToList(getLayoutQueries(date,id).Item1);  
            
            return new Tuple<string, int>(getDescriptions(descriptions),descriptions.Count);
        }
        public async static Task<Tuple<List<Descricao_IMSCliente>, List<Descricao_IMSCliente>>> getAllTolistAsync(DateTime date, string id)
        {
           var queries = getLayoutQueries(date,id);
            List<Descricao_IMSCliente> Alloweds = await getAllToList(queries.Item1);
            List<Descricao_IMSCliente> Denieds = await getAllToList(queries.Item2);
            return new Tuple<List<Descricao_IMSCliente>, List<Descricao_IMSCliente>>(Alloweds,Denieds);
        }

    }
}