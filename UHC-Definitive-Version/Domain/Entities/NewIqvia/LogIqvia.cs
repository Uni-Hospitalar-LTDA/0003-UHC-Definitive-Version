using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities.NewIqvia
{

    public class LogIqvia : Querys<LogIqvia>
    {
        public string Id { get; set; }
        public string idFtp { get; set; }
        public string Feedback { get; set; }        
        public string DataArquivo { get; set; }
        public string DataEnvio { get; set; }
        public string idUser { get; set; }
        public string LayoutProduto { get; set; }
        public string LayoutVendas { get; set; }
        public string LayoutCliente { get; set; }


        public static Task<LogIqvia> getToClassAsync(DateTime dt)
        {
            string query = $@"SELECT top 1 * FROM LogIqvia
WHERE DataArquivo = '{dt.ToString("yyyyMMdd")}'
ORDER BY DataEnvio DESC";
            return getToClass(query);
        }

        public static async Task<DataTable> getToDataTableByDateAsync(DateTime dt)
        {
            string query = $@"SELECT 
	LogIqvia.Id
   ,Logiqvia.DataArquivo [Arquivo do dia]
   ,Ftp.description [FTP]
   ,LogIqvia.Feedback
   ,IIF(LogIqvia.LayoutProduto=1,'Enviado','Não enviado') [Produto]
   ,IIF(LogIqvia.LayoutVendas=1,'Enviado','Não enviado') [Vendas]
   ,IIF(LogIqvia.LayoutCliente=1,'Enviado','Não enviado') [Cliente]
   ,[Possui bloqueios?] = IIF(max(LI.idIqviaRestriction) IS NOT NULL, 'Sim','Não')  
   ,LogIqvia.DataEnvio [Enviado em]
   ,Users.name [Por]
   
   
FROM LogIqvia
JOIN Ftp ON Ftp.id = LogIqvia.idFTP
JOIN Users ON Users.id = LogIqvia.idUser
LEFT JOIN LogIqvia_IqviaRestriction LI ON LI.idLogIqvia = LogIqvia.Id
WHERE LogIqvia.DataArquivo = '{dt.ToString("yyyyMMdd")}'

GROUP BY 
 LogIqvia.Id
,Logiqvia.DataArquivo
,Ftp.description
,LogIqvia.Feedback
,LogIqvia.LayoutProduto
,LogIqvia.LayoutVendas
,LogIqvia.LayoutCliente
,LogIqvia.DataEnvio
,Users.name";
            return await getAllToDataTable(query);

        }
    }
}
