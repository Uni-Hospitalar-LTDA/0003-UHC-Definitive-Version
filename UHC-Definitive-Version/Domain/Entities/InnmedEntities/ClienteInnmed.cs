using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    internal class ClienteInnmed : Querys<ClienteInnmed>
    {
        public string id { get; set; }
        public string description { get; set; } //Razao social
        public string cnpj { get; set; }
        public string fantasia { get; set; }
        public string endereco { get; set; }
        public string complemento { get; set; }
        public string cep { get;set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string telefone { get; set; }
        public string dataCadastro { get; set; }
        public string email { get; set; }



        public static async Task<ClienteInnmed> getToClassAsync(string id)
        {
            string query = $@"SELECT 
                              Cliente.codigo [id]
                             ,Cliente.Razao_Social [description]
                             ,Cliente.cgc_cpf [cnpj]    
                             ,Cliente.fantasia
                             ,Cliente.endereco
                             ,Cliente.complemento
                             ,Cliente.cep
                             ,Cidade.Descricao [Cidade]
                             ,Estado.Descricao [Estado]
                             ,Cliente.Cod_DDD_1 + Cliente.Fone1 [telefone]
                             ,Cliente.Data_Cadastro [dataCadastro]
                             ,Cliente.email    
                              FROM {Connection.dbDMD}.dbo.[CLIEN] Cliente
                              JOIN {Connection.dbDMD}.dbo.[ESTAD] Estado ON Cliente.Cod_Estado = Estado.Codigo
							  JOIN {Connection.dbDMD}.dbo.[CIDAD] Cidade ON Cliente.Cod_Cidade = Cidade.Codigo
                              WHERE Cliente.Codigo = {id}";

            return await getToClass(query);
        }

        public static async Task<DataTable> getAllToDataTableAsync()
        {
            string query = $@"SELECT codigo [id],fantasia [Cliente Innmed], [CNPJ] = CGC_CPF
                              FROM {Connection.dbDMD}.dbo.[CLIEN]";

            return await getAllToDataTable(query);
        }
    }
}
