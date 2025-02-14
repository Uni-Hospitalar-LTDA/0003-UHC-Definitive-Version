using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class ExternalNF : Querys<ExternalNF>
    {
        public string NotaFiscal { get; set; }
        public string DataEmissao { get; set; }
        public string Cfop { get; set; }
        public string DescricaoCfop { get; set; }
        public string valorNota { get; set; }
        public string Tipo { get; set; }
        public string DescricaoTipo { get; set; }
        public string Cod_Cliente { get; set; }

        public async static Task<ExternalNF> getToClassAsync(string nf)
        {
            try
            {
                if (nf != null)
                {
                    string query = $@"SELECT
                                	 [NotaFiscal] = NF_Saida.Num_Nota
                                    ,[DataEmissao] = NF_Saida.Dat_Emissao
                                    ,[valorNota] = NF_Saida.Vlr_TotalNota
                                	,[Cfop] = CFOP.Codigo
                                	,[DescricaoCfop] = CFOP.Descricao
                                	,[Tipo] = NF_Saida.Tip_Saida
                                	,[DescricaoTipo] = CASE NF_Saida.Tip_Saida
                                						WHEN 'O' THEN 'Outras saídas'
                                						WHEN 'D' THEN 'Saída por devolução'
                                						WHEN 'V' THEN 'Saída por Venda'
                                					   END
                                	,[Cod_Cliente] = NF_Saida.Cod_Cliente 
                                FROM [DMD].dbo.[NFSCB] NF_Saida
                                JOIN [DMD].dbo.[TBCFO] CFOP ON CFOP.Codigo = NF_Saida.Cod_Cfo1
                                WHERE NF_Saida.Num_Nota = {nf}
                                AND STATUS = 'F'";

                    return await getToClass(query);
                }
                else return null;
            }
            catch
            {
                return null;
            }

        }
        public async static Task<DataTable> getProductsToDataTableAsync(string nf)
        {
            string query = $@"SELECT
                                   	 [Cód. Produto] = Produto.Codigo
                                   	 ,[Produto] = Produto.Descricao
                                   	 ,[EAN] = Produto.Cod_EAN
                                   	 ,[Quantidade] = NF_Saida_Itens.Qtd_Produto
                                   	 ,[Valor Unitário] = NF_Saida_Itens.Prc_Unitario
                                     ,[Valor Total] =  NF_Saida_Itens.Qtd_Produto * NF_Saida_Itens.Prc_Unitario
                                   FROM [DMD].dbo.[NFSCB] NF_Saida
                                   JOIN [DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida_Itens.Num_Nota = NF_Saida.Num_Nota
                                   JOIN [DMD].dbo.[PRODU] Produto ON NF_Saida_Itens.Cod_Produto = Produto.Codigo
                                   WHERE NF_Saida.Num_Nota = {nf}";

            return await Produtos_Externos.getAllToDataTable(query);
        }

    }
}
