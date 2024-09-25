using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain
{
    public class DebitosAche : Querys<DebitosAche>
    {
        public string idDataIngestion { get; set; }
        public string Cod_EAN { get; set; }
        public string Apresentacao { get; set; }
        public string CNPJ_Distribuidor { get; set; }
        public string Numero_NF { get; set; }
        public string Qtde_Faturamento { get; set; }
        public string Valor_Bruto { get; set; }
        public string prct_Desconto { get; set; }
        public string prct_Desconto_Padrao { get; set; }
        public string prct_Custo_Margem { get; set; }
        public string prct_Debito { get; set; }
        public string Valor_Debito_Bruto { get; set; }
        public string prct_Repasse_ICMS { get; set; }
        public string Valor_Repasse_ICMS { get; set; }
        public string Valor_Debito_Final { get; set; }
        public string RF_Ajuste_Tributario { get; set; }
        public string RF_Valor_Debito { get; set; }
        public string RF_Aliquota_Interestadual { get; set; }
        public string RF_PISCofins { get; set; }
        public string RF_RedutorICMS { get; set; }

    }
}
