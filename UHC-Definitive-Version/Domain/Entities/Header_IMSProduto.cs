using UHC3_Definitive_Version.Configuration;
using System;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Domain.IMS
{
    public class Header_IMSProduto : Querys<Header_IMSProduto>
    {
        public string _010Tipo_de_Registro { get; set; }
        public string _020Fixo { get; set; }
        public string _030Seu_codigo_IQVIA { get; set; }
        public string _040Razao_social { get; set; }
        public string _050CNPJ { get; set; }
        public string _060Data_inicial { get; set; }
        public string _070Data_final { get; set; }
        public string _080Data_do_arquivo { get; set; }
        public string _090Fixo { get; set; }
        public string _100Filler { get; set; }
        public string _110Controle_interno_IQVIA { get; set; }


        private static string getHeader(Header_IMSProduto header)
        {
            string headerString =
             header._010Tipo_de_Registro?.PadRight(1).Substring(0, 1)
            + header._020Fixo?.PadRight(1).Substring(0, 1)
            + header._030Seu_codigo_IQVIA?.PadRight(4).Substring(0, 4)
            + header._040Razao_social?.PadRight(30).Substring(0, 30)
            + header._050CNPJ?.PadRight(14).Substring(0, 14)
            + header._060Data_inicial?.PadRight(8).Substring(0, 8)
            + header._070Data_final?.PadRight(8).Substring(0, 8)
            + header._080Data_do_arquivo?.PadRight(8).Substring(0, 8)
            + header._090Fixo?.PadRight(1).Substring(0, 1)
            + header._100Filler?.PadRight(118).Substring(0, 118)
            + header._110Controle_interno_IQVIA?.PadRight(9).Substring(0, 9);


            return headerString;
        }

        public static async Task<string> getHeaderAsync(DateTime date)
        {
            string query = $@"SELECT                                                 
                            _010Tipo_de_Registro = '{7}'
                            ,_020Fixo		      = '{0}'
                            ,_030Seu_codigo_IQVIA	  = '{Section.CodIqvia}'
                            ,_040Razao_social		  = Empresa.Razao_Social
                            ,_050CNPJ				= Empresa.CGC
                            ,_060Data_inicial		= '{date.ToString("ddMMyyyy")}'
                            ,_070Data_final			= '{date.ToString("ddMMyyyy")}'
                            ,_080Data_do_arquivo	= '{DateTime.Now.ToString("ddMMyyyy")}'
                            ,_090Fixo			= '{1}'
                            ,_100Filler			= ''
                            ,_110Controle_interno_IQVIA = '{"imsbrpro7"}'
						FROM [DMD].dbo.[EMPRE] Empresa            	                      
                        ";

            return getHeader(await getToClass(query));

        }

    }
}
