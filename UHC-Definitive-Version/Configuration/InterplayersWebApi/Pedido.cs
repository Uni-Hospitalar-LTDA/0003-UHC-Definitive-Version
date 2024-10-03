using System;
using System.Collections.Generic;

namespace UHC3_Definitive_Version.Configuration.InterplayersWebApi
{
    public class Pedido
    {
        public string CnpjCliente { get; set; }
        public List<Distribuidor> Distribuidores { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataProgramada { get; set; }
        public string NumeroPedidoErp { get; set; }
        public string NumeroPedidoCliente { get; set; }
        public List<Item> Itens { get; set; }
    }
}
