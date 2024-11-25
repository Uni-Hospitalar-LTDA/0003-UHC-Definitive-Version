using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Configuration.InterplayersWebApi
{
    public class Interplayers_Pfizer_Pedido : Querys<Interplayers_Pfizer_Pedido>
    {
        public string id { get; set; }
        public string PedidoPfizer { get; set; }
        public string PedidoUni { get; set; } = "1";
        public string Retorno { get; set; }
        public string Data_Registro { get; set; }
        public string JsonEnviado { get; set; }
        public string Response { get; set; }
        public string Base { get; set; }
        public string Fabricante { get; set; }

        public async static Task<List<Interplayers_Pfizer_Pedido>> getAllToListAsync(DateTime dt1, DateTime dt2)
        {
            string query = $@" SELECT DISTINCT
	Pedido.Id,
	Pedido.PedidoPfizer,
	iif(PD_ELETRONICO.Num_PedVen!=0,PD_ELETRONICO.Num_PedVen,null) [PedidoUni],
	Pedido.Retorno,	
	Pedido.Data_Registro,
	Pedido.JsonEnviado,
	Pedido.response,
	Pedido.base,
	Pedido.fabricante
	

FROM {Connection.dbBase}.dbo.Interplayers_Pfizer_Pedido Pedido
left JOIN {Connection.dbDMD}.DBO.PDECB PD_ELETRONICO On PD_ELETRONICO.Cod_PedCli = Pedido.PedidoPfizer collate Latin1_General_CI_AS
WHERE  Data_Registro 
                               BETWEEN '{dt1.ToString("yyyyMMdd")}' and '{dt2.ToString("yyyyMMdd")}'";
            return await getAllToList(query);
        }



    }
}    
