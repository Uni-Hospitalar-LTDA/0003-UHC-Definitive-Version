using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class NF_Canhotos : Querys<NF_Canhotos>
    {
        public string Num_Nota { get; set; }
        public string Dat_Canhoto { get; set; }
        public string Dat_Entrada { get; set; }
        public string idUsers { get; set; }


        public static async Task<List<NF_Canhotos>> getAllToCheckToListAsync(DateTime dt1, DateTime dt2, string codCliente = null, string codTransportador = null)
        {

            string entrada_Clientes = string.Empty;
            string saida_Clientes = string.Empty;

            string entrada_Transportador = string.Empty;
            string saida_Transportador = string.Empty;

            if (!string.IsNullOrEmpty(codCliente))
            {
                entrada_Clientes = $" AND NF_Entrada.Cod_EmiCliente = {codCliente}";
                saida_Clientes = $" AND NF_Saida.Cod_Cliente = {codCliente}";
            }
            if (!string.IsNullOrEmpty(codTransportador))
            {
                entrada_Transportador = $" AND NF_Entrada.Cod_Transp = {codTransportador}";
                saida_Transportador = $" AND NF_Saida.Cod_Transportadora = {codTransportador}";
            }

            //,NF_Entrada.Cod_EmiCliente

            string query = $@"SELECT 
                                	 NF_Saida.Num_Nota
                                    ,null [Dat_Canhoto]
                                    ,null [Dat_Entrada]
                                    ,null [idUsers]
                               FROM [DMD].dbo.[NFSCB] NF_Saida                                                              
                               WHERE NF_Saida.STATUS = 'F' AND NOT Ser_Nota = 'XXX'
							   AND NF_Saida.Num_Nota NOT IN (SELECT Num_Nota FROM [UHCDB].dbo.[NF_Canhotos])							   							   							   
                               AND NF_Saida.Dat_Emissao BETWEEN '{dt1.ToString("yyyyMMdd")}' AND '{dt2.ToString("yyyyMMdd")}'
                               {saida_Clientes}
                               {saida_Transportador}
                               UNION ALL
                               SELECT 
                               	    NF_Entrada.Numero [Num_Nota]
                                    ,null [Dat_Canhoto]
                                    ,null [Dat_Entrada]
                                    ,null [idUsers]
                               FROM [DMD].dbo.[NFECB] NF_Entrada                               
                               WHERE NF_Entrada.STATUS = 'F' AND NF_Entrada.Tip_NF = 'D'                                
                               AND NF_Entrada.Numero NOT IN (select num_nota from dmd.[dbo].nfscb)
							   AND NF_Entrada.Numero NOT IN (SELECT Num_Nota FROM [UHCDB].dbo.[NF_Canhotos])
                               AND NF_Entrada.Dat_Emissao BETWEEN '{dt1.ToString("yyyyMMdd")}' AND '{dt2.ToString("yyyyMMdd")}'       
                               {entrada_Clientes}
                               {entrada_Transportador}
                               ORDER BY Num_Nota DESC";
            Console.WriteLine(query);
            return await getAllToList(query);
        }
        public static async Task<List<NF_Canhotos>> getAllToCheckToListAsync(string nf)
        {
            string query = $@"SELECT 
                                	 NF_Saida.Num_Nota
                                    ,null [Dat_Canhoto]
                                    ,null [Dat_Entrada]
                                    ,null [idUsers]
                               FROM [DMD].dbo.[NFSCB] NF_Saida                                                              
                               WHERE NF_Saida.STATUS = 'F' AND NOT Ser_Nota = 'XXX'
							   AND NF_Saida.Num_Nota NOT IN (SELECT TOP 1 Num_Nota from [UHCDB].dbo.[NF_Canhotos] WHERE Num_Nota = {nf})
                               AND NF_Saida.Num_Nota = {nf}
                               UNION ALL
                               SELECT 
                               	    Numero [Num_Nota]
                                    ,null [Dat_Canhoto]
                                    ,null [Dat_Entrada]
                                    ,null [idUsers]
                               FROM [DMD].dbo.[NFECB] NF_Entrada                               
                               WHERE NF_Entrada.STATUS = 'F' AND NF_Entrada.Tip_NF = 'D'                                
                               AND NF_Entrada.Numero NOT IN (select num_nota from dmd.[dbo].nfscb)
							   AND NF_Entrada.Numero NOT IN (SELECT TOP 1 Num_Nota from [UHCDB].dbo.[NF_Canhotos] WHERE Num_Nota = {nf})
                               AND NF_Entrada.Numero = {nf}";

            return await getAllToList(query);
        }
    }
}
