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
            string queryAllow = $@"SELECT _010Tipo_de_Registro = '{2}',
       _020Codigo_do_cliente = NF_Saida.cod_cliente,
       _030CNPJ_CRM = NF_Saida.cgc,
       _040Flag = '{1}',
       _050Nome_fantasia = Isnull(Cliente.fantasia, ''),
       _060Razao_social = Isnull(Cliente.razao_social, ''),
       _070Flag_endereco = '{1}',
       _080Endereco = Isnull(Cliente.endereco + ', ' + Cliente.numero, ''),
       _090Complemento = Isnull(Cliente.complemento, ''),
       _100CEP = Isnull(Cliente.cep, ''),
       _110Cidade = Isnull(Cidade.descricao, ''),
       _120Estado = Isnull(Cliente.cod_estado, ''),
       _130Telefone = Isnull('(' + Cliente.cod_ddd_1 + ') ' + Cliente.fone1, '')
       ,
       _140Fax = Isnull(Cliente.fax, ''),
       _150Data_cadastro = Isnull(Cliente.data_cadastro, ''),
       _160email = Isnull(Cliente.email, ''),
       _170URL = '',
       _180Filler = '',
       _190Controle_interno_IQVIA = '{"C"}'
FROM   [DMD].dbo.[nfscb] NF_Saida
       JOIN [DMD].dbo.[clien] Cliente
         ON NF_Saida.cod_cliente = Cliente.codigo
       JOIN [DMD].dbo.[cidad] Cidade
         ON Cidade.codigo = Cliente.cod_cidade
       JOIN [DMD].dbo.[nfsit] NF_Saida_Itens
         ON NF_Saida_Itens.num_nota = NF_Saida.num_nota
       JOIN [DMD].dbo.[produ] Produto
         ON Produto.codigo = NF_Saida_Itens.cod_produto
       JOIN [DMD].dbo.[fabri] Fabricante
         ON Fabricante.codigo = Produto.cod_fabricante
WHERE
  /*Condicional Data*/
  NF_Saida.dat_emissao = '{date.ToString("yyyyMMdd")}'
  /*Condicional tipo de saída*/
  AND ( NF_Saida.tip_saida = 'V'
         OR NF_Saida.tip_saida = 'D'
         OR NF_Saida.cod_cfo1 IN ( 5910, 6910 ) )
  /*Condicionais de Bloqueio*/
  AND
  /* Bloqueio principal por Cliente */
  ( 0 = Iif(EXISTS (SELECT 1
                    FROM   [UHCDB].dbo.[iqvia_detailedblocks]
                    WHERE  typeblock = 'C'
                           AND id_panel = {id}
                           AND external_code = Cliente.codigo), 1, 0) )
  AND
  /* Bloqueio secundário por produtos */
  ( 0 = Iif(EXISTS (SELECT 1
                    FROM   [UHCDB].dbo.[iqvia_detailedblocks]
                    WHERE  typeblock = 'P'
                           AND id_panel = {id}
                           AND EXISTS (SELECT 1
                                       FROM   [DMD].dbo.[nfsit] NF_Saida_Itens
                                              JOIN [DMD].dbo.[nfscb] NF_Saida
                                                ON NF_Saida.num_nota =
                                                   NF_Saida_Itens.num_nota
                                       WHERE  NF_Saida.dat_emissao =
                                              '{date.ToString("yyyyMMdd")}'
                                              AND cod_cliente = Cliente.codigo
                                              AND cod_produto = external_code)),
        1
        ,
          0) )
  AND
  /* Bloqueio secundário por Fornecedor */
  ( 0 = Iif(EXISTS (SELECT 1
                    FROM   [UHCDB].dbo.[iqvia_detailedblocks]
                    WHERE  typeblock = 'F'
                           AND id_panel = {id}
                           AND EXISTS (SELECT 1
                                       FROM   [DMD].dbo.[nfsit] iNF_Saida_Itens
                                              JOIN [DMD].dbo.[nfscb] iNF_Saida
                                                ON iNF_Saida.num_nota =
                                                   iNF_Saida_Itens.num_nota
                                              JOIN [DMD].dbo.[produ] iProduto
                                                ON iProduto.codigo =
                                                   iNF_Saida_Itens.cod_produto
                                       WHERE  iNF_Saida.dat_emissao = '{date.ToString("yyyyMMdd")}'
                                              AND iNF_Saida.cod_cliente =
                                                  Cliente.codigo
                                              AND iProduto.cod_fabricante =
                                                  external_code)), 1, 0) )
  AND
  /* Verificação de existência de bloqueio por nota */
  ( 0 = Iif(EXISTS (SELECT 1
                    FROM   [UHCDB].dbo.[iqvia_detailedblocks] iBlocks
                           JOIN [DMD].dbo.[nfscb] iNF_Saida
                             ON iNF_Saida.num_nota = iBlocks.external_code
                    WHERE  typeblock = 'N'
                           AND id_panel = {id}
                           AND iNF_Saida.cod_cliente = Cliente.codigo), 1, 0) )
GROUP  BY NF_Saida.cod_cliente,
          NF_Saida.cgc,
          Cliente.fantasia,
          Cliente.razao_social,
          Cliente.endereco,
          Cliente.numero,
          Cliente.complemento,
          Cliente.cep,
          Cidade.descricao,
          Cliente.cod_estado,
          Cliente.cod_ddd_1,
          Cliente.fone1,
          Cliente.fax,
          Cliente.data_cadastro,
          Cliente.email  "
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
						
                      /* Condicionais de Bloqueio */
    AND NOT EXISTS (
        /* Bloqueio por Cliente */
        SELECT 1
        FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
        WHERE typeBlock = 'C'
          AND id_Panel = 2434 
          AND external_Code = Cliente.Codigo
    )
    AND NOT EXISTS (
        /* Bloqueio por Produto ou Fabricante */
        SELECT 1
        FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
        WHERE (typeBlock = 'P' OR (typeBlock = 'F' AND external_Code = Produto.Cod_Fabricante))
          AND id_Panel = 2434
          AND (
              EXISTS (SELECT 1
                      FROM [DMD].dbo.[NFSIT] iNF_Saida_Itens
                      JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iNF_Saida_Itens.Num_Nota
                      JOIN [DMD].dbo.[PRODU] iProduto ON iProduto.Codigo = iNF_Saida_Itens.Cod_Produto
                      WHERE iNF_Saida.Dat_Emissao = '04-11-2024'
                        AND Cod_Cliente = Cliente.Codigo
                        AND Cod_Produto = external_Code)
              OR EXISTS (SELECT 1
                         FROM [DMD].dbo.[NFSIT] iNF_Saida_Itens
                         JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iNF_Saida_Itens.Num_Nota
                         JOIN [DMD].dbo.[PRODU] iProduto ON iProduto.Codigo = iNF_Saida_Itens.Cod_Produto
                         WHERE iNF_Saida.Dat_Emissao = '04-11-2024'
                           AND Cod_Cliente = Cliente.Codigo
                           AND Cod_Fabricante = external_Code)
          )
    )
    AND NOT EXISTS (
        /* Bloqueio por Fornecedor */
        SELECT 1
        FROM [UHCDB].dbo.[Iqvia_DetailedBlocks]
        WHERE typeBlock = 'F'
          AND id_Panel = 2434
          AND EXISTS (SELECT 1
                      FROM [DMD].dbo.[NFSIT] iNF_Saida_Itens
                      JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iNF_Saida_Itens.Num_Nota
                      JOIN [DMD].dbo.[PRODU] iProduto ON iProduto.Codigo = iNF_Saida_Itens.Cod_Produto
                      WHERE iNF_Saida.Dat_Emissao = '04-11-2024'
                        AND Cod_Cliente = Cliente.Codigo
                        AND iProduto.Cod_Fabricante = external_Code)
    )
    AND NOT EXISTS (
        /* Bloqueio por Nota */
        SELECT 1
        FROM [UHCDB].dbo.[Iqvia_DetailedBlocks] iBlocks
        JOIN [DMD].dbo.[NFSCB] iNF_Saida ON iNF_Saida.Num_Nota = iBlocks.External_Code
        WHERE TypeBlock = 'N'
          AND id_Panel = 2434 
          AND iNF_Saida.Cod_Cliente = Cliente.Codigo
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
   ,Cliente.Email "
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