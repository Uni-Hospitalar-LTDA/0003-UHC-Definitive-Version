using System;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.NewIqvia
{
    public class IqviaLayout_Produto_Header
    {
        public string _010Tipo_de_Registro { get; set; } = "7";
        public string _020Fixo { get; set; } = "0";
        public string _030Seu_codigo_IQVIA { get; set; } = $"{Section.CodIqvia}";
        public string _040Razao_social { get; set; } = $"{Section.Empresa}";
        public string _050CNPJ { get; set; } = $"{Section.Cnpj}";
        public string _060Data_inicial { get; set; }
        public string _070Data_final { get; set; }
        public string _080Data_do_arquivo { get; set; } = $"{DateTime.Now.ToString("yyyyMMdd")}";
        public string _090Fixo { get; set; } = "1";
        public string _100Filler { get; set; } = "";
        public string _110Controle_interno_IQVIA { get; set; } = "imsbrpro7";

        public string getHeader()
        {
            string headerString =
              this._010Tipo_de_Registro?.PadRight(1).Substring(0, 1)
            + this._020Fixo?.PadRight(1).Substring(0, 1)
            + this._030Seu_codigo_IQVIA?.PadRight(4).Substring(0, 4)
            + this._040Razao_social?.PadRight(30).Substring(0, 30)
            + this._050CNPJ?.PadRight(14).Substring(0, 14)
            + this._060Data_inicial?.PadRight(8).Substring(0, 8)
            + this._070Data_final?.PadRight(8).Substring(0, 8)
            + this._080Data_do_arquivo?.PadRight(8).Substring(0, 8)
            + this._090Fixo?.PadRight(1).Substring(0, 1)
            + this._100Filler?.PadRight(118).Substring(0, 118)
            + this._110Controle_interno_IQVIA?.PadRight(9).Substring(0, 9);


            return headerString;
        }
    }
}
