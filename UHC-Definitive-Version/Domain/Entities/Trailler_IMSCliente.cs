using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.IMS
{
    public class Trailler_IMSCliente : Querys<Trailler_IMSCliente>
    {
        public string _010Tipo_de_Registro { get; set; }
        public string _020Fixo { get; set; }
        public string _030Seu_codigo_IQVIA { get; set; }
        public string _040Total_de_registros { get; set; }
        public string _050Filler { get; set; }
        public string _060Filler { get; set; }
        public string _070Controle_interno_IQVIA { get; set; }

        private static string getTrailler(Trailler_IMSCliente trailler)
        {
            string headerString = null;                                       
                    headerString =
                      trailler._010Tipo_de_Registro?.PadRight(1).Substring(0, 1)
                    + trailler._020Fixo?.PadLeft(1).Substring(0, 1)
                    + trailler._030Seu_codigo_IQVIA?.PadLeft(4).Substring(0, 4)
                    + trailler._040Total_de_registros?.PadLeft(8,'0').Substring(0, 8)
                    + trailler._050Filler?.PadRight(200).Substring(0, 200)
                    + trailler._060Filler?.PadRight(132).Substring(0, 132)
                    + trailler._070Controle_interno_IQVIA?.PadRight(9).Substring(0, 9)                    
                    ;                                                
            return headerString;            
        }

        internal static async Task<string> getTraillerAsync(int total)
        {
            string query = $@"SELECT 
                        	 _010Tipo_de_Registro = '{3}'
                        	,_020Fixo = '{0}'
                        	,_030Seu_codigo_IQVIA = '{Section.CodIqvia}'
                        	,_040Total_de_registros = '{total+2}'
                        	,_050Filler = ''
                        	,_060Filler  =''
                        	,_070Controle_interno_IQVIA = '{"imsbrcli3"}'                        	                      
                        ";

            return getTrailler(await getToClass(query));
        }


    }
}