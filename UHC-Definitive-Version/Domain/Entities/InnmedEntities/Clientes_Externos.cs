using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    public class Clientes_Externos : Querys<Clientes_Externos>
    {
        public string codigo { get; set; }
        public string razao_social { get; set; }
        public string cgc_cpf { get; set; }
        public string esfera_Cliente { get; set; }
        public string grupo_Cliente { get; set; }
        public string uf { get; set; }

        public static List<Clientes_Externos> clientes = new List<Clientes_Externos>();
        public static string getDescripionByCode(string code)
        {
            string description = null;
            try
            {
                if (clientes.Count > 0 ? (!string.IsNullOrEmpty(code)) : false)
                    description = clientes.Where(p => p.codigo == code).FirstOrDefault()?.razao_social;
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
                description = null;
            }
            return description;
        }
        public static Clientes_Externos getClienteByCode(string code)
        {
            Clientes_Externos cliente = null;
            try
            {
                if (clientes.Count > 0 ? (!string.IsNullOrEmpty(code)) : false)
                    cliente = clientes.Where(p => p.codigo == code).FirstOrDefault();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
                cliente = null;
            }
            return cliente;

        }

        public static DataTable getToDataTable(string description)
        {
            DataTable dt = new DataTable();
            dt = clientes.Where(c => c.razao_social.ToUpper().Contains(description) || c.cgc_cpf.Contains(description)).ToList().AsDataTable();
            dt.Columns[0].ColumnName = "Código";
            dt.Columns[1].ColumnName = "Razão Social";
            dt.Columns[2].ColumnName = "CNPJ";
            dt.Columns[3].ColumnName = "Esfera do Cliente";
            dt.Columns[4].ColumnName = "Grupo do Cliente";
            dt.Columns[5].ColumnName = "UF";

            return dt;
        }

        public async static Task carregarAsync()
        {
            if (clientes.Count > 0)
            {

                string query = $@"
                        DECLARE @total INT;
                      SELECT @total = COUNT(*) FROM [DMD].dbo.[CLIEN] Cliente;

                      IF @total <> {clientes.Count()}
                      BEGIN 
                                SELECT Cliente.codigo
                                    ,Cliente.razao_social 
                                    ,Cliente.cgc_cpf
                                    ,CASE Cliente.Tipo_Consumidor 
									 WHEN 'P' THEN 'Órgão Público Federal'
									 WHEN 'M' THEN 'Órgão Público Municipal'
									 WHEN 'E' THEN 'Órgão Público Estadual'
									 WHEN 'N' THEN 'Cliente Privado não Final'
									 WHEN 'F' THEN 'Cliente Privado Final'
									 END [esfera_Cliente]
                                    ,Cliente.Cod_GrpCli [grupo_Cliente]
                                    ,Cod_Estado [uf]
                               FROM [DMD].dbo.[CLIEN] Cliente 
                        END";

                List<Clientes_Externos> novosClientes = await getAllToList(query);

                if (novosClientes.Count > 0)
                {
                    // Cria um dicionário auxiliar para armazenar os produtos existentes
                    var clientesExistentes = new Dictionary<int, Clientes_Externos>();

                    // Cria uma lista auxiliar para armazenar os códigos dos produtos existentes
                    var codigosClientesExistentes = new List<int>();

                    // Preenche o dicionário e a lista auxiliares
                    foreach (var clienteExistente in clientes)
                    {
                        clientesExistentes[Convert.ToInt32(clienteExistente.codigo)] = clienteExistente;
                        codigosClientesExistentes.Add(Convert.ToInt32(clienteExistente.codigo));
                    }

                    // Verifica se há novos produtos e adiciona ou atualiza a lista existente
                    foreach (var cliente in novosClientes)
                    {
                        if (!clientesExistentes.TryGetValue(Convert.ToInt32(cliente.codigo), out var clienteExistente))
                        {
                            // Se o produto não existe, adiciona na lista principal e no dicionário auxiliar
                            clientes.Add(cliente);
                            clientesExistentes[Convert.ToInt32(cliente.codigo)] = cliente;
                        }
                        else
                        {
                            // Se o produto existe, atualiza somente as informações necessárias
                            clienteExistente.razao_social = cliente.razao_social;
                            clienteExistente.cgc_cpf = cliente.cgc_cpf;
                            clienteExistente.esfera_Cliente = cliente.esfera_Cliente;
                            clienteExistente.grupo_Cliente = cliente.grupo_Cliente;
                            clienteExistente.uf = cliente.uf;
                        }
                    }

                    // Remove os produtos existentes que não foram atualizados
                    clientes.RemoveAll(p => !codigosClientesExistentes.Contains(Convert.ToInt32(p.codigo)));
                }
            }
            else
            {
                string query = $@"                        
                                SELECT Cliente.codigo
                                    ,Cliente.razao_social 
                                    ,Cliente.cgc_cpf
                                    ,CASE Cliente.Tipo_Consumidor 
									 WHEN 'P' THEN 'Órgão Público Federal'
									 WHEN 'M' THEN 'Órgão Público Municipal'
									 WHEN 'E' THEN 'Órgão Público Estadual'
									 WHEN 'N' THEN 'Cliente Privado não Final'
									 WHEN 'F' THEN 'Cliente Privado Final'
									 END [esfera_Cliente]
                                    ,Cliente.Cod_GrpCli [grupo_Cliente]									
                                    ,Cod_Estado [uf]
                               FROM [DMD].dbo.[CLIEN] Cliente ";

                clientes = await getAllToList(query);
            }
        }




    }
}
