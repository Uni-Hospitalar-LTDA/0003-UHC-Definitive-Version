using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    public class NotaFiscalInnmed : Querys <NotaFiscalInnmed>
    {
        public string  numero { get; set; }
        public string  chaveAcesso { get; set; }
        public string  dataEmissao { get; set; }
        public string  valorTotal { get; set; }
        public string  idCliente { get; set; }
        public static async Task <NotaFiscalInnmed> getToClassAsync(string nf)
        {
            string query = $@" SELECT num_nota [numero]
                                     ,chv_acesso [chaveAcesso]  
                                     ,dat_emissao [dataEmissao]
                                     ,Vlr_TotalNota [valorTotal]
                                     ,cod_cliente [idCliente]
                                FROM {Connection.dbDMD}.dbo.[NFSCB] WHERE Status = 'F' and num_nota = {nf}
                             ";
            return await getToClass(query);
        }
        public static async Task<DataTable> getAllToDataTableAsync(DateTime dt1, DateTime dt2)
        {
            string query = $@"SELECT top 1000  NF_Saida.num_nota [NF]                                     
                                     ,NF_Saida.Dat_emissao [Dat. Emissão]
                                     ,NF_Saida.cod_cliente [Id. Cliente]
                                     ,Cliente.Razao_Social [Cliente]
                                     ,Cliente.cgc_Cpf [CNPJ]
                                     ,NF_Saida.Vlr_TotalNota [Total]
                                      
                                FROM {Connection.dbDMD}.dbo.[NFSCB] NF_Saida
                                JOIN {Connection.dbDMD}.dbo.[CLIEN] Cliente ON Cliente.codigo = NF_Saida.Cod_Cliente
                                WHERE Status = 'F' order by num_nota desc and NF_Saida.Dat_Emissao BETWEEN '{dt1.ToString("yyyyMMdd")}' AND '{dt2.ToString("yyyyMMdd")}'
                             ";
            return await getAllToDataTable(query);
        }

    }

    public class CfopInnmed : Querys<CfopInnmed>
    {
        public string codigo { get; set; }
        public string description { get; set; }
        public string tipo { get; set; }
        public string tipoNf { get; set; }

        public static async Task<CfopInnmed> getToClassAsync(string codigo)
        {
            string query = $@" SELECT Codigo [codigo], descricao [description],tip_entsai [tipo], tip_notfis [tipoNf]
                                FROM {Connection.dbDMD}.dbo.[TBCFO]
                                where codigo = {codigo} 
                             ";
            return await getToClass(query);
        }
        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT Codigo[codigo], descricao[description], tip_entsai[tipo], tip_notfis[tipoNf]
                                FROM { Connection.dbDMD}.dbo.[TBCFO]
                             ";
            return await getAllToDataTable(query);
        }

    }
}
