namespace UHC3_Definitive_Version.Domain.Entities.NewIqvia
{
    public class IqviaLayout_Cliente_Header
    {
        public string _010Tipo_de_registro { get; set; }
        public string _020Fixo { get; set; }
        public string _030Seu_codigo_IQVIA { get; set; }
        public string _040Razao_Social { get; set; }
        public string _050CNPJ { get; set; }
        public string _060Data_inicio { get; set; }
        public string _070Data_final { get; set; }
        public string _080Data_arquivo { get; set; }
        public string _090Fixo { get;  set; }
        public string _100Filler { get;  set; }
        public string _110Filler { get;  set; }
        public string _120Controle_interno_IQVIA { get; set; }

        public string getHeader()
        {
            string headerString =
              this._010Tipo_de_registro.PadRight(1).Substring(0, 1)
            + this._020Fixo.PadRight(1).Substring(0, 1)
            + this._030Seu_codigo_IQVIA.PadRight(4).Substring(0, 4)
            + this._040Razao_Social.PadRight(30).Substring(0, 30)
            + this._050CNPJ.PadRight(14).Substring(0, 14)
            + this._060Data_inicio.PadRight(8).Substring(0, 8)
            + this._070Data_final.PadRight(8).Substring(0, 8)
            + this._080Data_arquivo.PadRight(8).Substring(0, 8)
            + this._090Fixo.PadRight(1).Substring(0, 1)
            + this._100Filler.PadRight(100).Substring(0, 100)
            + this._110Filler.PadRight(171).Substring(0, 171)
            + this._120Controle_interno_IQVIA.PadRight(9).Substring(0, 9);

            return headerString;
        }
    }

}
