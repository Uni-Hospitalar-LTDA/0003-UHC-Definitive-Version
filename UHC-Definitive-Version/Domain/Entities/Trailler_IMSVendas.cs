using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.IMS
{
    public class Trailer_IMSVendas : Querys<Trailer_IMSVendas>
    {
        public string _010Tipo_de_Registro { get; set; }
        public string _020Fixo { get; set; }
        public string _030Seu_Código_IQVIA { get; set; }
        public string _040Total_de_Registros { get; set; }
        public string _050Total_unidades { get; set; }
        public string _060Total_de_Unidades_devolucoes { get; set; }
        public string _070Controle_interno_IQVIA { get; set; }


        private static string getTrailler(Trailer_IMSVendas trailler)
        {
            string headerString = null;
            headerString =
              trailler._010Tipo_de_Registro?.PadRight(1).Substring(0, 1)
             +trailler._020Fixo?.PadRight(1).Substring(0, 1)
             +trailler._030Seu_Código_IQVIA?.PadRight(4).Substring(0, 4)
             +trailler._040Total_de_Registros?.PadLeft(8, '0').Substring(0, 8)
             +trailler._050Total_unidades?.PadLeft(10,'0').Substring(0, 10)
             +trailler._060Total_de_Unidades_devolucoes?.PadLeft(10,'0').Substring(0, 10)
             +trailler._070Controle_interno_IQVIA?.PadRight(9).Substring(0, 9)


            ;
            return headerString;
        }

        public static async Task<string> getTraillerAsync(int totalGeral,int totalUnidades, int totalUnidadesDevolucao)
        {
            string query = $@"select
		                     _010Tipo_de_Registro =  '{6}'
		                    ,_020Fixo = '{0}'
		                    ,_030Seu_Código_IQVIA = '{Section.CodIqvia}'
		                    ,_040Total_de_Registros = '{totalGeral}'
		                    ,_050Total_unidades = '{totalUnidades}'
		                    ,_060Total_de_Unidades_devolucoes = '{totalUnidadesDevolucao}' 
		                    ,_070Controle_interno_IQVIA = '{"imsbrven6"}'
                          FROM [DMD].dbo.[PRODU] Produto";

            return getTrailler(await getToClass(query));
        }


    }
}