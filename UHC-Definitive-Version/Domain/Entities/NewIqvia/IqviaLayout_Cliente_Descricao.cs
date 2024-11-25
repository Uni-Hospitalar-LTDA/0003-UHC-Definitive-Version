using System;
using System.Collections.Generic;

namespace UHC3_Definitive_Version.Domain.Entities.NewIqvia
{
    public class IqviaLayout_Cliente_Descricao
    {
        public string _010Tipo_de_Registro { get; set; }
        public string _020Codigo_do_cliente { get; set; }      
        public string _030CNPJ_CRM { get; set; }               
        public string _040Flag { get; set; }                   
        public string _050Nome_fantasia { get; set; }          
        public string _060Razao_social { get; set; }           
        public string _070Flag_endereco { get; set; }          
        public string _080Endereco { get; set; }               
        public string _090Complemento { get; set; }            
        public string _100CEP { get; set; }                    
        public string _110Cidade { get; set; }                 
        public string _120Estado { get; set; }                 
        public string _130Telefone { get; set; }               
        public string _140Fax { get; set; }                    
        public string _150Data_cadastro { get; set; }          
        public string _160email { get; set; }                  
        public string _170URL { get; set; }                    
        public string _180Filler { get; set; }                 
        public string _190Controle_interno_IQVIA { get; set; } 

        public static string getDescriptions(List<IqviaLayout_Cliente_Descricao> descriptions)
        {
            string headerString = null;
            string descriptionTotal = null;
            int x = 1;

            foreach (var description in descriptions)
            {
                if (description != null)
                {
                    headerString =
                      description._010Tipo_de_Registro?.PadRight(1).Substring(0, 1)
                    + description._020Codigo_do_cliente?.PadLeft(14, '0').Substring(0, 14)
                    + description._030CNPJ_CRM?.PadLeft(14, '0').Substring(0, 14)
                    + description._040Flag?.PadRight(1).Substring(0, 1)
                    + description._050Nome_fantasia?.PadRight(40).Substring(0, 40)
                    + description._060Razao_social?.PadRight(40).Substring(0, 40)
                    + description._070Flag_endereco?.PadRight(1).Substring(0, 1)
                    + description._080Endereco?.PadRight(70).Substring(0, 70)
                    + description._090Complemento?.PadRight(20).Substring(0, 20)
                    + description._100CEP?.PadRight(8).Substring(0, 8)
                    + description._110Cidade?.PadRight(30).Substring(0, 30)
                    + description._120Estado?.PadRight(2).Substring(0, 2)
                    + description._130Telefone?.PadRight(20).Substring(0, 20)
                    + description._140Fax?.PadRight(20).Substring(0, 20)
                    + Convert.ToDateTime(description._150Data_cadastro?.PadRight(8).Substring(0, 8)).ToString("ddMMyyyy")
                    + description._160email?.PadRight(35).Substring(0, 35)
                    + description._170URL?.PadRight(25).Substring(0, 25)
                    + description._180Filler?.PadRight(5).Substring(0, 5)
                    + description._190Controle_interno_IQVIA?.PadRight(1).Substring(0, 1)
                    ;
                    if (x < descriptions.Count)
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
