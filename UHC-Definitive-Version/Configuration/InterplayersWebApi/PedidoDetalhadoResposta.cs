using System.Collections.Generic;

namespace UHC3_Definitive_Version.Configuration.InterplayersWebApi
{
    public class PedidoDetalhadoResposta
    {
        public bool Success { get; set; }
        public List<PedidoDetalhado> Data { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
        public object Errors { get; set; }
    }

}
