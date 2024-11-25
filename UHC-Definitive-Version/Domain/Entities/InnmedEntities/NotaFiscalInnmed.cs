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
        public static async Task <NotaFiscalInnmed> getToClassAsync(string nf,DateTime dt1, DateTime dt2)
        {
            string query = $@" SELECT NF_Saida.num_nota [numero]
                                     ,NF_Saida.chv_acesso [chaveAcesso]  
                                     ,NF_Saida.dat_emissao [dataEmissao]
                                     ,NF_Saida.Vlr_TotalNota [valorTotal]
                                     ,NF_Saida.cod_cliente [idCliente]
                                FROM {Connection.dbDMD}.dbo.[NFSCB] NF_Saida WHERE Status = 'F' and num_nota = {nf}
                                and NF_Saida.Dat_Emissao BETWEEN '{dt1.ToString("yyyyMMdd")}' AND '{dt2.ToString("yyyyMMdd")}'
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
                                
                                WHERE Status = 'F' 
                                and NF_Saida.Dat_Emissao BETWEEN '{dt1.ToString("yyyyMMdd")}' 
                                AND '{dt2.ToString("yyyyMMdd")}'
                                order by num_nota desc 
                             ";
            
            return await getAllToDataTable(query);
        }

    }
}
