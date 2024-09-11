using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.IMS
{
    public class Trailer_IMSProduto : Querys<Trailer_IMSProduto>
    {
        public string _010Tipo_de_Registro { get; set; }
        public string _020Fixo { get; set; }
        public string _030Seu_codigo_IQVIA { get; set; }
        public string _040Total_de_registros { get; set; }
        public string _050Filler { get; set; }
        public string _060Controle_interno_IQVIA { get; set; }

        private static string getTrailler(Trailer_IMSProduto trailler)
        {
            string headerString = null;
            headerString =
              trailler._010Tipo_de_Registro?.PadRight(1).Substring(0, 1)
            + trailler._020Fixo?.PadLeft(1).Substring(0, 1)
            + trailler._030Seu_codigo_IQVIA?.PadLeft(4).Substring(0, 4)
            + trailler._040Total_de_registros?.PadLeft(8, '0').Substring(0, 8)
            + trailler._050Filler?.PadRight(179).Substring(0, 179)
            + trailler._060Controle_interno_IQVIA?.PadRight(9).Substring(0, 9)
            
            ;
            return headerString;
        }

        public static async Task<string> getTraillerAsync(int total)
        {
            string query = $@"SELECT 
                        	 _010Tipo_de_Registro = '{9}'
                        	,_020Fixo = '{0}'
                        	,_030Seu_codigo_IQVIA = '{Section.CodIqvia}'
                        	,_040Total_de_registros = '{total+2}'
                        	,_050Filler = ''
                        	,_060Controle_interno_IQVIA = '{"imsbrpro9"}'                        	                      
                        ";

            return getTrailler(await getToClass(query));
        }


    }
}