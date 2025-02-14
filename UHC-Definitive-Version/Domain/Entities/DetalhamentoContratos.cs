using System;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class DetalhamentoContratos : Querys<DetalhamentoContratos>
    {
        public string cod_contrato { get; set; }
        public string cod_produto { get; set; }
        public string preco_compra_digitado { get; set; }  

        public async static Task deleteAsync(string cod_contrato,string cod_produto)
        {
            string query = $"DELETE FROM [{Connection.dbBase}].dbo.[{getClassName()}] WHERE cod_contrato = {cod_contrato} and cod_produto = {cod_produto}";
            Console.WriteLine(query);
            await execAsync(query);
        }
        
        
    }
}
