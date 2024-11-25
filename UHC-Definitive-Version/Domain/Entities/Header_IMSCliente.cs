using UHC3_Definitive_Version.Configuration;
using System;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.IMS
{
    public class Header_IMSCliente : Querys<Header_IMSCliente>
    {
        public string _010Tipo_de_registro { get; private set; } 
        public string _020Fixo { get; private set; } 
        public string _030Seu_codigo_IQVIA { get; set; }
        public string _040Razao_Social { get; set; }
        public string _050CNPJ { get; set; }
        public string _060Data_inicio { get; set; }
        public string _070Data_final { get; set; }
        public string _080Data_arquivo { get; private set; } 
        public string _090Fixo { get; private set; } 
        public string _100Filler { get; private set; } 
        public string _110Filler { get; private set; } 
        public string _120Controle_interno_IQVIA { get; private set; } 


        private static string getHeader(Header_IMSCliente header)
        {
            string headerString =
              header._010Tipo_de_registro.PadRight(1).Substring(0, 1)
            + header._020Fixo.PadRight(1).Substring(0, 1)
            + header._030Seu_codigo_IQVIA.PadRight(4).Substring(0, 4)
            + header._040Razao_Social.PadRight(30).Substring(0, 30)
            + header._050CNPJ.PadRight(14).Substring(0, 14)
            + header._060Data_inicio.PadRight(8).Substring(0, 8)
            + header._070Data_final.PadRight(8).Substring(0, 8)
            + header._080Data_arquivo.PadRight(8).Substring(0, 8)
            + header._090Fixo.PadRight(1).Substring(0, 1)
            + header._100Filler.PadRight(100).Substring(0, 100)
            + header._110Filler.PadRight(171).Substring(0, 171)
            + header._120Controle_interno_IQVIA.PadRight(9).Substring(0, 9);

            return headerString;
        }
        public static async Task<string> getHeaderAsync(DateTime date)
        {           
            string query = $@"SELECT      
                                 _010Tipo_de_registro = '{1}'
                                ,_020Fixo = '{0}'
                                ,_030Seu_codigo_IQVIA = '{Section.CodIqvia}'
                            	,[_040Razao_Social] = Empresa.Razao_Social
                            	,[_050CNPJ] = Empresa.CGC                           	  
                                ,_060Data_inicio = '{date.ToString("ddMMyyyy")}'
                                ,_070Data_final = '{date.ToString("ddMMyyyy")}'
                                ,_080Data_arquivo = '{DateTime.Now.ToString("ddMMyyyy")}'
                                ,_090Fixo = '{1}'
                                ,_100Filler = ''
                                ,_110Filler = ''
                                ,_120Controle_interno_IQVIA = '{"imsbrcli1"}'
                        FROM [DMD].dbo.[EMPRE] Empresa";
            return getHeader(await getToClass(query));


        }

      

    }
}