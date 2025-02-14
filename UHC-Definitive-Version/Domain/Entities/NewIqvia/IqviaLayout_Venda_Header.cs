using System;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.NewIqvia
{
    public class IqviaLayout_Venda_Header
    {
        public string _010Tipo_de_Registro { get; set; } = "4";
        public string _020Fixo { get; set; } = "0";
        public string _030Seu_codigo_IQVIA { get; set; } = $"{Section.CodIqvia}";
        public string _040Data_inicio { get; set; } 
        public string _050Data_final { get; set; }
        public string _060Data_arquivo { get; set; } = $"{DateTime.Now.ToString("ddMMyyyy")}";
        public string _070FLAG_periodicidade { get; set; } = "D";
        public string _080Filler { get; set; } = "";
        public string _090Controle_interno_IQVIA { get; set; } = "imsbrven4";



        public string getHeader()
        {
            string headerString =
               this._010Tipo_de_Registro.PadRight(1).Substring(0, 1)
             + this._020Fixo.PadRight(1).Substring(0, 1)
             + this._030Seu_codigo_IQVIA.PadRight(4).Substring(0, 4)
             + this._040Data_inicio.PadRight(8).Substring(0, 8)
             + this._050Data_final.PadRight(8).Substring(0, 8)
             + this._060Data_arquivo.PadRight(8).Substring(0, 8)
             + this._070FLAG_periodicidade.PadRight(1).Substring(0, 1)
             + this._080Filler.PadRight(3).Substring(0, 3)
             + this._090Controle_interno_IQVIA.PadRight(9).Substring(0, 9)

            ;

            return headerString;
        }

    }
}
