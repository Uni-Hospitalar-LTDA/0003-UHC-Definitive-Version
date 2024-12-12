using UHC3_Definitive_Version.Configuration;
using System;
using System.Threading.Tasks;
using System.Globalization;

namespace UHC3_Definitive_Version.Domain.IMS
{
    public class Header_IMSVendas : Querys<Header_IMSVendas>
    {
        public string _010Tipo_de_Registro { get; set; }
        public string _020Fixo { get; set; }
        public string _030Seu_codigo_IQVIA { get; set; }
        public string _040Data_inicio { get; set; }
        public string _050Data_final { get; set; }
        public string _060Data_arquivo { get; set; }
        public string _070FLAG_periodicidade { get; set; }
        public string _080Filler { get; set; }
        public string _090Controle_interno_IQVIA { get; set; }



        private static string getHeader(Header_IMSVendas header)
        {
            string headerString =
              header._010Tipo_de_Registro.PadRight(1).Substring(0, 1)
             +header._020Fixo.PadRight(1).Substring(0, 1)
             +header._030Seu_codigo_IQVIA.PadRight(4).Substring(0, 4)
             +header._040Data_inicio.PadRight(8).Substring(0, 8)
             +header._050Data_final.PadRight(8).Substring(0, 8)
             +header._060Data_arquivo.PadRight(8).Substring(0, 8)
             +header._070FLAG_periodicidade.PadRight(1).Substring(0, 1)
             +header._080Filler.PadRight(3).Substring(0, 3)
             +header._090Controle_interno_IQVIA.PadRight(9).Substring(0, 9)

            ;

            return headerString;
        }

        public static async Task<string> getHeaderAsync(DateTime date)
        {
            string query = $@"SELECT                                                 
                           _010Tipo_de_Registro  = '{4}'
                           ,_020Fixo = '{0}'
                           ,_030Seu_codigo_IQVIA = '{Section.CodIqvia}'
                           ,_040Data_inicio = '{date.ToString("ddMMyyyy")}'
                           ,_050Data_final = '{date.ToString("ddMMyyyy")}'
                           ,_060Data_arquivo = '{DateTime.Now.ToString("ddMMyyyy")}'
                           ,_070FLAG_periodicidade = '{"D"}' 
                           ,_080Filler = ''
                           ,_090Controle_interno_IQVIA = '{"imsbrven4"}'                                             
                        ";

            return getHeader(await getToClass(query));
        }

    }
}
