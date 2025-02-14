using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class GNRE_Lote
    {
        public static void exportar(string path, List<string> nfs)
        {
            // Cria o objeto TLote_GNRE com guias
            TLote_GNRE lote = new TLote_GNRE();
            Guias guias = new Guias();
            guias.TDadosGNRE = getGNRElote2_0(nfs);
            lote.Guias = guias;

            // Configuração correta do namespace e schema para o cabeçalho
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "http://www.gnre.pe.gov.br");
            ns.Add("xsd", "http://www.w3.org/2001/XMLSchema");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            // Verifica e cria diretório se necessário
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Gera o nome do arquivo
            string fileName = path + gerarNomeArquivoLoteGnre();

            // Serializa o objeto para XML com o namespace correto
            XmlSerializer serializer = new XmlSerializer(typeof(TLote_GNRE));
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, lote, ns);
            }

            // Altera diretamente no arquivo XML
            AjustarCNPJparaCPF(fileName);
        }

        /// <summary>
        /// Ajusta o CNPJ para CPF no arquivo XML se o valor tiver 9 dígitos.
        /// </summary>
        /// <param name="filePath">Caminho do arquivo XML a ser ajustado.</param>
        private static void AjustarCNPJparaCPF(string filePath)
        {
            // Lê todo o conteúdo do arquivo XML
            string xmlContent = File.ReadAllText(filePath);

            // Usa Regex para localizar e ajustar os valores de CNPJ com 9 dígitos
            string pattern = @"<CNPJ>(\d{11})</CNPJ>";
            string replacement = @"<CPF>$1</CPF>";
            string adjustedXml = System.Text.RegularExpressions.Regex.Replace(xmlContent, pattern, replacement);

            // Reescreve o arquivo com as alterações
            File.WriteAllText(filePath, adjustedXml);
        }


        public static string gerarNomeArquivoLoteGnre()
        {
            string dataAtual = DateTime.Now.ToString("ddMMyyyy");
            string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string nomeAleatorio = new string(
                Enumerable.Repeat(caracteresPermitidos, 8)
                .Select(s => s[random.Next(s.Length)])
                .ToArray()
            );
            return $"GNRElote_{dataAtual}_{nomeAleatorio}.xml";
        }

        private static List<TDadosGNRE> getGNRElote2_0(List<string> nfs)
        {
            try
            {
                List<TDadosGNRE> dadosGNREs = new List<TDadosGNRE>();

                foreach (var nf in nfs)
                {
                    using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Section.Unidade))
                    {
                        TDadosGNRE dadosGNRE = new TDadosGNRE();
                        ContribuinteEmitente contribuinteEmitente = new ContribuinteEmitente();
                        Identificacao identificacaoEmitente = new Identificacao();
                        Identificacao identificacaoDestinatario = new Identificacao();
                        ItensGNRE itensGNRE = new ItensGNRE();
                        Item item = new Item();
                        DocumentoOrigem documentoOrigem = new DocumentoOrigem();
                        Referencia referencia = new Referencia();
                        Valor valor = new Valor();
                        CamposExtras camposExtras = new CamposExtras();
                        List<CampoExtra> campoExtra = new List<CampoExtra>();
                        ContribuinteDestinatario contribuinteDestinatario = new ContribuinteDestinatario();
                        //MessageBox.Show(Session.Unidade + " " + nf);
                        conn.Open();
                        SqlCommand command = conn.CreateCommand();
                        command.CommandText = $@" SELECT distinct
          [ufFavorecida] = NF_Saida.Estado
         ,[tipoGnre] = '0'
         ,[receita] = '100102'
         ,[cnpjEmitente] = Empresa.CGC
         ,[razaoSocialEmitente] = Empresa.Razao_Social
         ,[enderecoEmitente] = Empresa.Endereco +', '+ Empresa.Numero 
         ,[municipioEmitente] = municipioEmitente.idCounty
         ,[ufEmitente] = Empresa.Estado
         ,[cepEmitente] = Empresa.CEP
         ,[telefoneEmitente] = Empresa.Cod_DDD + empresa.Fone
         ,[documentoOrigem_Tipo_Text] = 
         CASE
         	WHEN NF_Saida.Estado ='RJ' THEN '24'+','+NF_Saida.Chv_Acesso
            WHEN NF_Saida.Estado ='PE' THEN '24'+','+NF_Saida.Chv_Acesso
        	WHEN NF_Saida.Estado ='AM' THEN '22'+','+NF_Saida.Chv_Acesso
            WHEN NF_Saida.Estado ='MT' THEN '22'+','+NF_Saida.Chv_Acesso    
            WHEN NF_Saida.Estado ='RN' THEN '22'+','+NF_Saida.Chv_Acesso 
            WHEN NF_Saida.Estado ='RS' THEN '22'+','+NF_Saida.Chv_Acesso 
            WHEN NF_Saida.Estado ='SC' THEN '24'+','+NF_Saida.Chv_Acesso      
            ELSE '10'+','+CONVERT(VARCHAR,NF_Saida.Num_Nota)
         END		
         ,[dataVencimento] = CONVERT(DATE,GETDATE())
         ,[valor_Tipo_Text] = 
         '11'+','+convert(varchar,CONVERT(NUMERIC(18,2),NF_SAIDA.Vlr_IcmIntUfDes))
         ,[cnpjDestinatario] = Cliente.Cgc_Cpf
         ,[razaoSocialDestinatario] = Cliente.Razao_Social		
         ,[municipioDestinatario] = municipioDestinatario.idCounty
         ,[camposExta_campoExtra1_codigo_valor]= 
         CASE
         	WHEN NF_Saida.Estado ='RJ' THEN '117'+','+CONVERT(VARCHAR,CONVERT(DATE,GETDATE()))
        	WHEN NF_Saida.Estado ='AC' THEN '120'+','+NF_Saida.Chv_Acesso
        	WHEN NF_Saida.Estado ='AL' THEN '90'+','+NF_Saida.Chv_Acesso
        	WHEN NF_Saida.Estado ='AP' THEN '47'+','+NF_Saida.Chv_Acesso
        	WHEN NF_Saida.Estado ='BA' THEN '86'+','+NF_Saida.Chv_Acesso
        	WHEN NF_Saida.Estado ='GO' THEN '102'+','+NF_Saida.Chv_Acesso
            WHEN NF_Saida.Estado ='MA' THEN '94'+','+NF_Saida.Chv_Acesso
            WHEN NF_Saida.Estado ='MS' THEN '88'+','+NF_Saida.Chv_Acesso
            WHEN NF_Saida.Estado ='PA' THEN '101'+','+NF_Saida.Chv_Acesso
            WHEN NF_Saida.Estado ='PB' THEN '99'+','+NF_Saida.Chv_Acesso
            WHEN NF_Saida.Estado ='PR' THEN '107'+','+NF_Saida.Chv_Acesso
            WHEN NF_Saida.Estado ='RO' THEN '83'+','+NF_Saida.Chv_Acesso
            WHEN NF_Saida.Estado ='RR' THEN '36'+','+NF_Saida.Chv_Acesso
            WHEN NF_Saida.Estado ='SE' THEN '77'+','+NF_Saida.Chv_Acesso    
            WHEN NF_Saida.Estado ='TO' THEN '80'+','+NF_Saida.Chv_Acesso
         END	
         ,[referencia] = CASE			
        					WHEN NF_Saida.Estado = 'AC' THEN ','+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
        					WHEN NF_Saida.Estado = 'AL' THEN ','+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
        					WHEN NF_Saida.Estado = 'AM' THEN '0,'+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
        					WHEN NF_Saida.Estado = 'AP' THEN '0,'+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
        					WHEN NF_Saida.Estado = 'BA' THEN '0,'+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
        					WHEN NF_Saida.Estado = 'DF' THEN ','+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
        					WHEN NF_Saida.Estado = 'GO' THEN ','+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
        WHEN NF_Saida.Estado = 'MA' THEN ','+CONVERT(VARCHAR, MONTH(GETDATE()))+','+CONVERT(VARCHAR, YEAR(GETDATE()))+','
                            WHEN NF_Saida.Estado = 'MT' THEN ','+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
                            WHEN NF_Saida.Estado = 'PA' THEN ','+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
                            WHEN NF_Saida.Estado = 'PB' THEN ','+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
                            WHEN NF_Saida.Estado = 'RN' THEN ','+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
                            WHEN NF_Saida.Estado = 'RO' THEN ','+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
                            WHEN NF_Saida.Estado = 'RR' THEN ','+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
                            WHEN NF_Saida.Estado = 'SE' THEN ','+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','
                            WHEN NF_Saida.Estado = 'TO' THEN ','+CONVERT(VARCHAR,MONTH(GETDATE()))+','+CONVERT(VARCHAR,YEAR(GETDATE()))+','

        				END
        ,[DetalhamentoReceita] = 
                            CASE
                                WHEN NF_Saida.Estado = 'MT' THEN '000055'
                            END
                        ,[Produto] = CASE 
        				    WHEN NF_Saida.Estado = 'MA' THEN '23'
        			    END

         ,[valor] = CONVERT(NUMERIC(18,2),NF_SAIDA.Vlr_IcmIntUfDes)
        ,[valorFCP] = CONVERT(NUMERIC(18,2),NF_SAIDA.Vlr_IcmFcpUfDes) 
        ,[valorFCP_Principal] = '11'+','+convert(varchar,CONVERT(NUMERIC(18,2),NF_SAIDA.Vlr_IcmFcpUfDes))

        FROM [{Connection.dbDMD}].dbo.[NFSCB] NF_Saida
        CROSS JOIN [{Connection.dbDMD}].dbo.[EMPRE] Empresa
        JOIN [{Connection.dbDMD}].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente
        JOIN [{Connection.dbDMD}].dbo.[ESTAD] Estado ON Estado.Codigo = NF_Saida.Estado
        LEFT JOIN [{Connection.dbBase}].dbo.City municipioEmitente ON municipioEmitente.description = Empresa.Cidade  collate Latin1_General_CI_AS
        LEFT JOIN [{Connection.dbBase}].dbo.City municipioDestinatario ON (municipioDestinatario.description = NF_Saida.Cidade  collate Latin1_General_CI_AS
                                                  AND municipioDestinatario.idIBGE_State = Estado.Cod_Ibge collate Latin1_General_CI_AS) 
                                                   WHERE NUM_NOTA = {nf}";
                        Console.WriteLine(command.CommandText);
                        SqlDataReader reader;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["ufFavorecida"] != null)
                            {
                                dadosGNRE.UfFavorecida = reader["ufFavorecida"].ToString();
                                dadosGNRE.TipoGnre = reader["tipoGnre"].ToString();

                                dadosGNRE.ContribuinteEmitente = contribuinteEmitente;
                                contribuinteEmitente.Identificacao = identificacaoEmitente;
                                identificacaoEmitente.CNPJ = reader["cnpjEmitente"].ToString();
                                contribuinteEmitente.RazaoSocial = reader["razaoSocialEmitente"].ToString();
                                contribuinteEmitente.Endereco = reader["enderecoEmitente"].ToString();
                                contribuinteEmitente.Municipio = reader["municipioEmitente"].ToString().Trim();
                                contribuinteEmitente.Uf = reader["ufEmitente"].ToString();
                                contribuinteEmitente.Cep = reader["cepEmitente"].ToString();
                                contribuinteEmitente.Telefone = reader["telefoneEmitente"].ToString();
                                dadosGNRE.ItensGNRE = itensGNRE;
                                itensGNRE.Item = item;
                                item.Receita = reader["receita"].ToString();

                                if (!string.IsNullOrEmpty(reader["DetalhamentoReceita"].ToString()))
                                    item.DetalhamentoReceita = reader["DetalhamentoReceita"].ToString();

                                item.DocumentoOrigem = documentoOrigem;

                                if (!string.IsNullOrEmpty(reader["Produto"].ToString()))
                                {
                                    item.Produto = reader["Produto"].ToString();
                                }

                                if (!string.IsNullOrEmpty(reader["documentoOrigem_Tipo_Text"].ToString()))
                                {
                                    string[] doc = reader["documentoOrigem_Tipo_Text"].ToString().Split(',');
                                    documentoOrigem.Tipo = doc[0];
                                    documentoOrigem.Text = doc[1];
                                }

                                if (!string.IsNullOrEmpty(reader["referencia"].ToString()))
                                {
                                    string[] refer = reader["referencia"].ToString().Split(',');
                                    if (!string.IsNullOrEmpty(refer[0]))
                                        referencia.Periodo = refer[0];

                                    referencia.Mes = Convert.ToInt32(refer[1]).ToString("D2");
                                    referencia.Ano = refer[2];
                                    if (!string.IsNullOrEmpty(refer[3]))
                                        referencia.parcela = refer[3];

                                    item.Referencia = referencia;
                                }

                                item.DataVencimento = DateTime.Now.ToString("yyyy-MM-dd");

                                // Inicializar lista de valores
                                item.Valores = new List<Valor>();

                                // Adicionar o valor principal
                                string[] val = reader["valor_Tipo_Text"].ToString().Split(',');
                                item.Valores.Add(new Valor
                                {
                                    Tipo = val[0],
                                    Text = val[1]
                                });

                                // Adicionar o valor FCP, se aplicável
                                if (!string.IsNullOrEmpty(reader["valorFCP"].ToString()))
                                {
                                    item.Valores.Add(new Valor
                                    {
                                        Tipo = "12", // Código para o FCP
                                        Text = reader["valorFCP"].ToString().Replace(",", ".")
                                    });
                                }

                                // Verifica se o CNPJ do destinatário tem 9 caracteres
                                string cnpjDestinatario = reader["cnpjDestinatario"].ToString();
                                if (cnpjDestinatario.Length == 9)
                                {
                                    // CNPJ possui 9 caracteres, os campos do contribuinte destinatário são mantidos vazios
                                    contribuinteDestinatario = new ContribuinteDestinatario(); // Recria vazio
                                    identificacaoDestinatario = new Identificacao(); // Recria vazio
                                }
                                else
                                {
                                    // CNPJ não possui 9 caracteres, preenche normalmente os dados do destinatário
                                    item.ContribuinteDestinatario = contribuinteDestinatario;
                                    contribuinteDestinatario.Identificacao = identificacaoDestinatario;
                                    identificacaoDestinatario.CNPJ = cnpjDestinatario;
                                    contribuinteDestinatario.RazaoSocial = reader["razaoSocialDestinatario"].ToString();
                                    contribuinteDestinatario.Municipio = reader["municipioDestinatario"].ToString().Trim();
                                }

                                if (!string.IsNullOrEmpty(reader["camposExta_campoExtra1_codigo_valor"].ToString()))
                                {
                                    item.CamposExtras = camposExtras;
                                    camposExtras.CampoExtra = campoExtra;
                                    string[] campo1 = reader["camposExta_campoExtra1_codigo_valor"].ToString().Split(',');
                                    campoExtra.Add(new CampoExtra { Codigo = campo1[0], Valor = campo1[1] });
                                }

                                // Calcula o valor total somando todos os valores na lista
                                decimal valorTotal = item.Valores.Sum(v => Convert.ToDecimal(v.Text.Replace(".", ",")));
                                dadosGNRE.ValorGNRE = valorTotal.ToString().Replace(",", ".");
                                dadosGNRE.DataPagamento = DateTime.Now.ToString("yyyy-MM-dd");

                                dadosGNREs.Add(dadosGNRE);
                            }
                        }

                    }
                }
                return dadosGNREs;
            }
            catch (Exception ex)
            {

                CustomNotification.defaultError("Erro na função " + ex.Message);
                return null;
            }
            finally
            {
                //CustomMessage.Sucess();
            }
        }













        /** Layout 2.0 **/

        [XmlRoot(ElementName = "identificacao", Namespace = "http://www.gnre.pe.gov.br")]
        public class Identificacao
        {
            private string v;

            public Identificacao()
            {
            }

            public Identificacao(string v)
            {
                this.v = v;
            }

            [XmlElement(ElementName = "CNPJ", Namespace = "http://www.gnre.pe.gov.br")]
            public string CNPJ { get; set; }
        }

        [XmlRoot(ElementName = "contribuinteEmitente", Namespace = "http://www.gnre.pe.gov.br")]
        public class ContribuinteEmitente
        {
            private string v1;
            private string v2;
            private string v3;
            private string v4;
            private string v5;
            private string v6;

            public ContribuinteEmitente()
            {
            }

            public ContribuinteEmitente(Identificacao identificacao, string v1, string v2, string v3, string v4, string v5, string v6)
            {
                Identificacao = identificacao;
                this.v1 = v1;
                this.v2 = v2;
                this.v3 = v3;
                this.v4 = v4;
                this.v5 = v5;
                this.v6 = v6;
            }

            [XmlElement(ElementName = "identificacao", Namespace = "http://www.gnre.pe.gov.br")]
            public Identificacao Identificacao { get; set; }
            [XmlElement(ElementName = "razaoSocial", Namespace = "http://www.gnre.pe.gov.br")]
            public string RazaoSocial { get; set; }
            [XmlElement(ElementName = "endereco", Namespace = "http://www.gnre.pe.gov.br")]
            public string Endereco { get; set; }
            [XmlElement(ElementName = "municipio", Namespace = "http://www.gnre.pe.gov.br")]
            public string Municipio { get; set; }
            [XmlElement(ElementName = "uf", Namespace = "http://www.gnre.pe.gov.br")]
            public string Uf { get; set; }
            [XmlElement(ElementName = "cep", Namespace = "http://www.gnre.pe.gov.br")]
            public string Cep { get; set; }
            [XmlElement(ElementName = "telefone", Namespace = "http://www.gnre.pe.gov.br")]
            public string Telefone { get; set; }
        }

        [XmlRoot(ElementName = "documentoOrigem", Namespace = "http://www.gnre.pe.gov.br")]
        public class DocumentoOrigem
        {
            [XmlAttribute(AttributeName = "tipo")]
            public string Tipo { get; set; }
            [XmlText]
            public string Text { get; set; }
        }

        [XmlRoot(ElementName = "valor", Namespace = "http://www.gnre.pe.gov.br")]
        public class Valor
        {
            [XmlAttribute(AttributeName = "tipo")]
            public string Tipo { get; set; }
            [XmlText]
            public string Text { get; set; }

            public Valor Clone()
            {
                return new Valor
                {
                    Tipo = this.Tipo,
                    Text = this.Text
                };
            }
        }

        [XmlRoot(ElementName = "contribuinteDestinatario", Namespace = "http://www.gnre.pe.gov.br")]
        public class ContribuinteDestinatario
        {
            private string v1;
            private string v2;
            private string v3;
            private string v4;
            private string v5;
            private string v6;

            public ContribuinteDestinatario()
            {
            }

            public ContribuinteDestinatario(Identificacao identificacao, string v1, string v2, string v3, string v4, string v5, string v6)
            {
                Identificacao = identificacao;
                this.v1 = v1;
                this.v2 = v2;
                this.v3 = v3;
                this.v4 = v4;
                this.v5 = v5;
                this.v6 = v6;
            }

            [XmlElement(ElementName = "identificacao", Namespace = "http://www.gnre.pe.gov.br")]
            public Identificacao Identificacao { get; set; }
            [XmlElement(ElementName = "razaoSocial", Namespace = "http://www.gnre.pe.gov.br")]
            public string RazaoSocial { get; set; }
            [XmlElement(ElementName = "municipio", Namespace = "http://www.gnre.pe.gov.br")]
            public string Municipio { get; set; }
        }

        [XmlRoot(ElementName = "campoExtra", Namespace = "http://www.gnre.pe.gov.br")]
        public class CampoExtra
        {
            private string v1;
            private string v2;

            public CampoExtra()
            {
            }

            public CampoExtra(string v1, string v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }

            [XmlElement(ElementName = "codigo", Namespace = "http://www.gnre.pe.gov.br")]
            public string Codigo { get; set; }
            [XmlElement(ElementName = "valor", Namespace = "http://www.gnre.pe.gov.br")]
            public string Valor { get; set; }
        }

        [XmlRoot(ElementName = "camposExtras", Namespace = "http://www.gnre.pe.gov.br")]
        public class CamposExtras
        {
            private CampoExtra[] campoExtras;

            public CamposExtras()
            {
            }

            public CamposExtras(CampoExtra[] campoExtras)
            {
                this.campoExtras = campoExtras;
            }

            [XmlElement(ElementName = "campoExtra", Namespace = "http://www.gnre.pe.gov.br")]
            public List<CampoExtra> CampoExtra { get; set; }
        }

        [XmlRoot(ElementName = "item", Namespace = "http://www.gnre.pe.gov.br")]
        public class Item
        {
            public Item()
            {
                Valores = new List<Valor>(); // Inicializa a lista de valores
            }

            [XmlElement(ElementName = "receita", Namespace = "http://www.gnre.pe.gov.br")]
            public string Receita { get; set; }

            [XmlElement(ElementName = "detalhamentoReceita", Namespace = "http://www.gnre.pe.gov.br")]
            public string DetalhamentoReceita { get; set; }

            [XmlElement(ElementName = "documentoOrigem", Namespace = "http://www.gnre.pe.gov.br")]
            public DocumentoOrigem DocumentoOrigem { get; set; }

            [XmlElement(ElementName = "produto", Namespace = "http://www.gnre.pe.gov.br")]
            public string Produto { get; set; }

            [XmlElement(ElementName = "referencia", Namespace = "http://www.gnre.pe.gov.br")]
            public Referencia Referencia { get; set; }

            [XmlElement(ElementName = "dataVencimento", Namespace = "http://www.gnre.pe.gov.br")]
            public string DataVencimento { get; set; }

            // Alteração: Lista de Valores
            [XmlElement(ElementName = "valor", Namespace = "http://www.gnre.pe.gov.br")]
            public List<Valor> Valores { get; set; } // Agora é uma lista de valores

            [XmlElement(ElementName = "contribuinteDestinatario", Namespace = "http://www.gnre.pe.gov.br")]
            public ContribuinteDestinatario ContribuinteDestinatario { get; set; }

            [XmlElement(ElementName = "camposExtras", Namespace = "http://www.gnre.pe.gov.br")]
            public CamposExtras CamposExtras { get; set; }

            public Item Clone()
            {
                var clone = new Item
                {
                    Receita = this.Receita,
                    DetalhamentoReceita = this.DetalhamentoReceita,
                    DocumentoOrigem = this.DocumentoOrigem,
                    Produto = this.Produto,
                    Referencia = this.Referencia,
                    DataVencimento = this.DataVencimento,
                    Valores = this.Valores.Select(v => v.Clone()).ToList(), // Clona a lista de valores
                    ContribuinteDestinatario = this.ContribuinteDestinatario,
                    CamposExtras = this.CamposExtras
                };

                return clone;
            }
        }


        [XmlRoot(ElementName = "itensGNRE", Namespace = "http://www.gnre.pe.gov.br")]
        public class Referencia
        {
            [XmlElement(ElementName = "periodo", Namespace = "http://www.gnre.pe.gov.br")]
            public string Periodo { get; set; }
            [XmlElement(ElementName = "mes", Namespace = "http://www.gnre.pe.gov.br")]
            public string Mes { get; set; }
            [XmlElement(ElementName = "ano", Namespace = "http://www.gnre.pe.gov.br")]
            public string Ano { get; set; }
            [XmlElement(ElementName = "parcela", Namespace = "http://www.gnre.pe.gov.br")]
            public string parcela { get; set; }

        }

        [XmlRoot(ElementName = "itensGNRE", Namespace = "http://www.gnre.pe.gov.br")]
        public class ItensGNRE
        {
            public ItensGNRE()
            {
            }

            public ItensGNRE(Item item)
            {
                Item = item;
            }

            [XmlElement(ElementName = "item", Namespace = "http://www.gnre.pe.gov.br")]
            public Item Item { get; set; }


            public ItensGNRE Clone()
            {
                return new ItensGNRE()
                {
                    Item = this.Item?.Clone()
                };
            }

        }

        [XmlRoot(ElementName = "TDadosGNRE", Namespace = "http://www.gnre.pe.gov.br")]
        public class TDadosGNRE
        {
            private string v1;
            private string v2;
            private string v3;
            private string v4;
            private string v5;
            private CamposExtras camposExtras;
            private ContribuinteDestinatario contribuinteDestinatario;

            public TDadosGNRE()
            {
            }

            public TDadosGNRE(string v1, string v2, string v3, ContribuinteEmitente contribuinteEmitente, ItensGNRE itensGNRE, string v4, string v5, CamposExtras camposExtras, ContribuinteDestinatario contribuinteDestinatario)
            {
                this.v1 = v1;
                this.v2 = v2;
                this.v3 = v3;
                ContribuinteEmitente = contribuinteEmitente;
                ItensGNRE = itensGNRE;
                this.v4 = v4;
                this.v5 = v5;
                this.camposExtras = camposExtras;
                this.contribuinteDestinatario = contribuinteDestinatario;
            }

            [XmlElement(ElementName = "ufFavorecida", Namespace = "http://www.gnre.pe.gov.br")]
            public string UfFavorecida { get; set; }
            [XmlElement(ElementName = "tipoGnre", Namespace = "http://www.gnre.pe.gov.br")]
            public string TipoGnre { get; set; }
            [XmlElement(ElementName = "contribuinteEmitente", Namespace = "http://www.gnre.pe.gov.br")]
            public ContribuinteEmitente ContribuinteEmitente { get; set; }
            [XmlElement(ElementName = "itensGNRE", Namespace = "http://www.gnre.pe.gov.br")]
            public ItensGNRE ItensGNRE { get; set; }
            [XmlElement(ElementName = "valorGNRE", Namespace = "http://www.gnre.pe.gov.br")]
            public string ValorGNRE { get; set; }
            [XmlElement(ElementName = "dataPagamento", Namespace = "http://www.gnre.pe.gov.br")]
            public string DataPagamento { get; set; }
            [XmlAttribute(AttributeName = "versao")]
            public string Versao { get; set; } = "2.00";

            public TDadosGNRE Clone()
            {
                return new TDadosGNRE
                {

                    v1 = this.v1,
                    v2 = this.v2,
                    v3 = this.v3,
                    v4 = this.v4,
                    v5 = this.v5,
                    camposExtras = this.camposExtras,
                    contribuinteDestinatario = this.contribuinteDestinatario,
                    UfFavorecida = this.UfFavorecida,
                    TipoGnre = this.TipoGnre,
                    ContribuinteEmitente = this.ContribuinteEmitente,
                    ItensGNRE = this.ItensGNRE.Clone(),
                    ValorGNRE = this.ValorGNRE,
                    DataPagamento = this.DataPagamento,
                    Versao = this.Versao
                };
            }
        }

        [XmlRoot(ElementName = "guias", Namespace = "http://www.gnre.pe.gov.br")]
        public class Guias
        {
            private TDadosGNRE dadosGNRE;

            public Guias()
            {
            }

            public Guias(TDadosGNRE dadosGNRE)
            {
                this.dadosGNRE = dadosGNRE;
            }

            [XmlElement(ElementName = "TDadosGNRE", Namespace = "http://www.gnre.pe.gov.br")]
            public List<TDadosGNRE> TDadosGNRE { get; set; }
        }

        [XmlRoot(ElementName = "TLote_GNRE", Namespace = "http://www.gnre.pe.gov.br")]
        public class TLote_GNRE
        {
            public TLote_GNRE()
            {
            }

            public TLote_GNRE(Guias guias)
            {
                Guias = guias;
            }

            [XmlElement(ElementName = "guias", Namespace = "http://www.gnre.pe.gov.br")]
            public Guias Guias { get; set; }
            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; } = "http://www.gnre.pe.gov.br";
            [XmlAttribute(AttributeName = "versao")]
            public string Versao { get; set; } = "2.00";
        }

    }
}
