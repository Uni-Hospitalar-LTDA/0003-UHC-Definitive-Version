namespace UHC3_Definitive_Version.Domain.Entities.NewIqvia
{
    public class IqviaLayout_Cliente_Trailer
    {
        public string _010Tipo_de_Registro { get; set; }
        public string _020Fixo { get; set; }
        public string _030Seu_codigo_IQVIA { get; set; }
        public string _040Total_de_registros { get; set; }
        public string _050Filler { get; set; } = "";
        public string _060Filler { get; set; } = "";
        public string _070Controle_interno_IQVIA { get; set; }

        public string getTrailler()
        {
            string headerString = null;
            headerString =
              this._010Tipo_de_Registro?.PadRight(1).Substring(0, 1)
            + this._020Fixo?.PadLeft(1).Substring(0, 1)
            + this._030Seu_codigo_IQVIA?.PadLeft(4).Substring(0, 4)
            + this._040Total_de_registros?.PadLeft(8, '0').Substring(0, 8)
            + this._050Filler?.PadRight(200).Substring(0, 200)
            + this._060Filler?.PadRight(132).Substring(0, 132)
            + this._070Controle_interno_IQVIA?.PadRight(9).Substring(0, 9)
            ;
            return headerString;
        }
    }

}
