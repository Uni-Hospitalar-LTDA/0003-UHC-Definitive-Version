using System;
using System.Collections.Generic;

namespace UHC3_Definitive_Version.Domain.Entities.NewIqvia
{
    public class IqviaLayout_Venda_Description
    {
        public string _010Tipo_de_Registro { get; set; } = "5";
        public string _020ID_Periodo { get; set; } 
        public string _030Codigo_cliente { get; set; }
        public string _040Flag_do_cliente { get; set; } = "1";
        public string _050Fixo { get; set; } = "0";
        public string _060Codigo_produto { get; set; }
        public string _070Flag_produto { get; set; } = "1";
        public string _080Flag_venda { get; set; }
        public string _090Quantidade { get; set; }
        public string _100Filler { get; set; } = "V";

        public static string getDescricao(List<IqviaLayout_Venda_Description> descricao)
        {
            string headerString = null;
            string descriptionTotal = null;
            int x = 1;

            foreach (var descricao_lista in descricao)
            {               
                    headerString =
                    descricao_lista._010Tipo_de_Registro?.PadRight(1).Substring(0, 1)
                   + descricao_lista._020ID_Periodo?.PadRight(2).Substring(0, 2)
                   + descricao_lista._030Codigo_cliente?.PadLeft(14, '0').Substring(0, 14)
                   + descricao_lista._040Flag_do_cliente?.PadRight(1).Substring(0, 1)
                   + descricao_lista._050Fixo?.PadRight(1).Substring(0, 1)
                   + descricao_lista._060Codigo_produto?.PadLeft(13, '0').Substring(0, 13)
                   + descricao_lista._070Flag_produto?.PadRight(1).Substring(0, 1)
                   + descricao_lista._080Flag_venda?.PadRight(1).Substring(0, 1)
                   + descricao_lista._090Quantidade?.PadLeft(8, '0').Substring(0, 8)
                   + descricao_lista._100Filler?.PadRight(1).Substring(0, 1);

                    if (x < descricao.Count)
                        descriptionTotal = descriptionTotal + headerString + Environment.NewLine;
                    else
                        descriptionTotal = descriptionTotal + headerString;
                    x++;
                }            

            return descriptionTotal;
        }
    }
}
