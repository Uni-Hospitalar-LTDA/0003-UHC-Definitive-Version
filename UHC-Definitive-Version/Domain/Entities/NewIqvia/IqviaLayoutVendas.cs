using System;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.NewIqvia
{
    public class IqviaLayoutVendas : Querys<IqviaLayoutVendas>
    {





        private static string getQuery(DateTime date)
        {
            return $@"  SELECT
                                [index] = ROW_NUMBER() OVER(ORDER BY NF_Saida.Num_Nota)
                              ,_010Tipo_de_Registro = '{5}'
                              ,_020ID_Periodo = {date.ToString("dd")}
                              ,_030Codigo_cliente = isnull(NF_Saida.Cod_Cliente,'')
                              ,_040Flag_do_cliente = '{1}'
                              ,_050Fixo = '{0}'
                              ,_060Codigo_produto = isnull(NF_Saida_Itens.Cod_Produto,'')							  
                              ,_070Flag_produto = '{1}'
                              ,_080Flag_venda = CASE
													WHEN NF_Saida.Tip_Saida  = 'V' THEN 'N'
                                                    WHEN Cod_Cfo1 in (5910,6910) THEN 'N'
													ELSE 'D'
												END												
                              ,_090Quantidade = isnull(NF_Saida_Itens.Qtd_Produto,'')
                              ,_100Filler = '{"V"}'                       
                            FROM [{Connection.dbDMD}].dbo.[NFSCB] NF_Saida
                            JOIN [{Connection.dbDMD}].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida.Num_Nota = NF_Saida_Itens.Num_Nota
                            JOIN [{Connection.dbDMD}].dbo.[TBCFO] CFOP ON CFOP.Codigo = NF_Saida.Cod_Cfo1
							JOIN [{Connection.dbDMD}].dbo.[PRODU] Produto ON Produto.Codigo = NF_Saida_Itens.Cod_Produto
							JOIN [{Connection.dbDMD}].dbo.[FABRI] as Fabricante on Produto.Cod_Fabricante = Fabricante.Codigo						
							JOIN [{Connection.dbDMD}].dbo.[CLIEN] as Cliente on Cliente.Codigo = NF_Saida.Cod_Cliente	
                        WHERE STATUS = 'F' 
                        AND (NF_Saida.Dat_Emissao =  '{date.ToString("yyyyMMdd")}')";
        }  

        //private static string getLayoutToDataTableAsync()
        //{

        //}

        
    }
}
