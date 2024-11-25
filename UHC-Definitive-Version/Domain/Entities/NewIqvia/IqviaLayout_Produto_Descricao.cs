using System;
using System.Collections.Generic;

namespace UHC3_Definitive_Version.Domain.Entities.NewIqvia
{
    public class IqviaLayout_Produto_Descricao
    {
        public string _010Tipo_de_Registro { get; set; } = "8";
        public string _020Embalagem { get; set; } = "";
        public string _030Fixo { get; set; } = "0";
        public string _040Codigo_do_produto { get; set; }
        public string _050Fixo { get; set; } = "0";
        public string _060Codigo_de_barras { get; set; }
        public string _070Flag { get; set; } = "1";
        public string _080Nome_do_produto_Apresentacao { get; set; }
        public string _090Filler { get; set; } = "";
        public string _100Fabricante { get; set; }
        public string _110Preco_fabrica { get; set; }
        public string _120Tipo_de_produto { get; set; } = "MEDICAMENTOS";
        public string _130Classificacao_fiscal { get; set; }
        public string _140Data_do_cadastro { get; set; }
        public string _150Controle_Interno_IQVIA { get; set; } = "P";

        public static string getDescricao(List<IqviaLayout_Produto_Descricao> descricao)
        {
            string headerString = null;
            string descriptionTotal = null;
            int x = 1;

            foreach (var descricao_lista in descricao)
            {
                if (descricao != null)
                {
                    headerString =
                    descricao_lista._010Tipo_de_Registro?.PadRight(1).Substring(0, 1)
                    + descricao_lista._020Embalagem?.PadRight(1).Substring(0, 1)
                    + descricao_lista._030Fixo?.PadRight(1).Substring(0, 1)
                    + descricao_lista._040Codigo_do_produto?.PadLeft(13, '0').Substring(0, 13)
                    + descricao_lista._050Fixo?.PadRight(1).Substring(0, 1)
                    + descricao_lista._060Codigo_de_barras?.PadRight(13).Substring(0, 13)
                    + descricao_lista._070Flag?.PadRight(1).Substring(0, 1)
                    + descricao_lista._080Nome_do_produto_Apresentacao?.PadRight(70).Substring(0, 70)
                    + descricao_lista._090Filler?.PadRight(8).Substring(0, 8)
                    + descricao_lista._100Fabricante?.PadRight(40).Substring(0, 40)
                    + descricao_lista._110Preco_fabrica?.Replace(",", "").PadLeft(9, '0').Substring(0, 9)
                    + descricao_lista._120Tipo_de_produto?.PadRight(20).Substring(0, 20)
                    + descricao_lista._130Classificacao_fiscal?.PadRight(15).Substring(0, 15)
                    + Convert.ToDateTime(descricao_lista._140Data_do_cadastro?.PadRight(8).Substring(0, 8)).ToString("ddMMyyyy")
                    + descricao_lista._150Controle_Interno_IQVIA?.PadRight(1).Substring(0, 1);

                    if (x < descricao.Count)
                        descriptionTotal = descriptionTotal + headerString + Environment.NewLine;
                    else
                        descriptionTotal = descriptionTotal + headerString;
                    x++;
                }
            }

            return descriptionTotal;
        }
    }
}
