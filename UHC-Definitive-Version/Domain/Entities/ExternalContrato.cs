using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class ExternalContrato : Querys<ExternalContrato>
    {
        public string UF { get; set; }
        public string cod_cliente { get; set; }
        public string rzsocial_cliente { get; set; }
        public string esfera_cliente { get; set; }
        public string cod_contrato { get; set; }
        public string contrato { get; set; }
        public string cod_produto { get; set; }
        public string produto { get; set; }
        public string nmgenerico_produto { get; set; }

        public string Preco_unitario { get; set; }
        public string fabricanteFantasia { get; set; }
        public string qtd_pedido { get; set; }
        public string qtd_faturada { get; set; }
        public string saldo { get; set; }
        public string giro { get; set; }
        public string status { get; set; }
        public string data_inicio { get; set; }
        public string data_Final { get; set; }



        public async static Task<List<ExternalContrato>> getAllToListAsync()
        {
            string query = $@"SELECT 
                            	Cliente.Cod_Estado [uf]
                               ,Cliente.Codigo [cod_cliente]
                               ,Cliente.Razao_Social [rzsocial_cliente]
                               ,CASE Tipo_Consumidor 
                                WHEN 'P' THEN 'Órgão Público Federal'
                            	WHEN 'M' THEN 'Órgão Público Municipal'
                            	WHEN 'E' THEN 'Órgão Público Estadual'
                            	WHEN 'F' THEN 'Cliente Privado Final'
                            	WHEN 'N' THEN 'Cliente Privado Não Final'
                            	END [esfera_cliente]
                            	,Contrato.Cod_Contrato 
                            	,Contrato.Num_Contrato [contrato]
                            	,Produto.Codigo  [cod_produto]
                            	,Produto.Descricao [produto]
                            	,Produto.Des_NomGen [nmgenerico_produto]
                                ,Contrato_Itens.Prc_Unitario [Preco_unitario]
                            	,Fabricante.Fantasia [fabricanteFantasia]
                            	,Contrato_Itens.Qtd_Pedido 
                            	,Contrato_Itens.Qtd_Faturada 
                            	,(Contrato_Itens.Qtd_Pedido - Contrato_Itens.Qtd_Faturada) [Saldo]
                            	,[Giro] = CONVERT(NUMERIC(10,2),ROUND(CONVERT(NUMERIC(10,2),Contrato_Itens.Qtd_Faturada)/CONVERT(NUMERIC(10,2),Contrato_Itens.Qtd_Pedido),2))                            	
                            	,CASE Sta_Contrato
                            		WHEN 1 THEN 'Em Aberto'
                            		WHEN 2 THEN 'Em Andamento'
                            		WHEN 3 THEN 'Vencido'
                            		WHEN 4 THEN 'Finalizado'
                            		WHEN 5 THEN 'Cancelado'
                            	 END [Status]
                            	 ,Contrato.Dat_InicioCtr [Data_inicio] 
                            	 ,Contrato.Dat_FimCtr [data_Final]
                            	   
                            FROM [DMD].dbo.[CTRCB] Contrato
                            JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = Contrato.Cod_Cliente
                            JOIN [DMD].dbo.[CTRIT] Contrato_Itens ON Contrato_Itens.Cod_Contrato = Contrato.Cod_Contrato
                            JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = Contrato_Itens.Cod_Produto
                            JOIN [DMD].dbo.[FABRI] Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante
                            WHERE Qtd_Pedido > 0 ";

            return await getAllToList(query);

        }







        public async static Task<DataTable> getDetailedContractsToDataTableAsync(DateTime dateInicial, DateTime dateFinal, string produto, string cliente, string fabricante, string estado)
        {
            string query = $@"SELECT 
                            	Cliente.Cod_Estado [UF]
                               ,Cliente.Codigo [Código do Órgão]
                               ,Cliente.Razao_Social [Órgão]   
                               ,CASE Tipo_Consumidor 
                                WHEN 'P' THEN 'Órgão Público Federal'
                            	WHEN 'M' THEN 'Órgão Público Municipal'
                            	WHEN 'E' THEN 'Órgão Público Estadual'
                            	WHEN 'F' THEN 'Cliente Privado Final'
                            	WHEN 'N' THEN 'Cliente Privado Não Final'
                            	END [Tipo do Órgão]
                            	,Contrato.Cod_Contrato [Cód Pregão (Contrato)]
                            	,Contrato.Num_Contrato [Pregão (Contrato)]
                            	,Produto.Codigo [Cód. Produto]
                            	,Produto.Descricao [Produto]
                            	,Produto.Des_NomGen [Nome Genérico]
                                ,Contrato_Itens.Prc_Unitario [Preco_unitario]
                            	,Fabricante.Fantasia [Fabricante]
                            	,Contrato_Itens.Qtd_Pedido [Qtd. Contrato]
                            	,Contrato_Itens.Qtd_Faturada [Qtd. Faturada]
                            	,(Contrato_Itens.Qtd_Pedido - Contrato_Itens.Qtd_Faturada) [Saldo]
                            	,[Giro] = CONVERT(NUMERIC(10,2),ROUND(CONVERT(NUMERIC(10,2),Contrato_Itens.Qtd_Faturada)/CONVERT(NUMERIC(10,2),Contrato_Itens.Qtd_Pedido),2))
                            	,Contrato.Sta_Contrato
                            	,CASE Sta_Contrato
                            		WHEN 1 THEN 'Em Aberto'
                            		WHEN 2 THEN 'Em Andamento'
                            		WHEN 3 THEN 'Vencido'
                            		WHEN 4 THEN 'Finalizado'
                            		WHEN 5 THEN 'Cancelado'
                            	 END [Status]
                            	 ,Contrato.Dat_InicioCtr [Início do Contrato]
                            	 ,Contrato.Dat_FimCtr [Fim do Contrato]
                            	   
                            FROM [DMD].dbo.[CTRCB] Contrato
                            JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = Contrato.Cod_Cliente
                            JOIN [DMD].dbo.[CTRIT] Contrato_Itens ON Contrato_Itens.Cod_Contrato = Contrato.Cod_Contrato
                            JOIN [DMD].dbo.[PRODU] Produto ON Produto.Codigo = Contrato_Itens.Cod_Produto
                            JOIN [DMD].dbo.[FABRI] Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante
                            WHERE Qtd_Pedido > 0 
                            AND(Contrato.Dat_InicioCtr >= '{dateInicial.ToString("yyyyMMdd")}' AND Contrato.Dat_InicioCtr <= '{dateFinal.ToString("yyyyMMdd")}')
                            AND Produto.Descricao LIKE '%{produto}%'
                            AND Cliente.Razao_Social LIKE '%{cliente}%'
                            AND Fabricante.Fantasia LIKE '%{fabricante}%'                            
                            ";
            Console.WriteLine(query);
            return await getAllToDataTable(query);
        }
    }
}
