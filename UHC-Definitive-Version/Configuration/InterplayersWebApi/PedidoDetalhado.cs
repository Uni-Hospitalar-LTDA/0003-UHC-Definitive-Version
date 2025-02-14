using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.Configuration.InterplayersWebApi
{
    public class PedidoDetalhado
    {
        public string CnpjCliente { get; set; }
        public string CnpjDistribuidor { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataProgramada { get; set; }
        public string NumeroPedidoErp { get; set; }
        public string NumeroPedidoCliente { get; set; }
        public int NumeroPedidoPortal { get; set; }
        public List<ItemDetalhado> Itens { get; set; }
        public string Status { get; set; }
        public string ErroProcessamento { get; set; }
        

        

    }

}
