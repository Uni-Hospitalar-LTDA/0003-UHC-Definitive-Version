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


        public static Task<LogIqvia> getToClassAsync(int id)
        {
            string query = $@"SELECT top 1 * FROM LogIqvia
WHERE Id = '{id}'
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
   ,IIF(Users.name IS NULL,'ADMIN',Users.Name) [Por]
   
   
FROM LogIqvia
JOIN Ftp ON Ftp.id = LogIqvia.idFTP
LEFT JOIN Users ON Users.id = LogIqvia.idUser
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
,Users.name
ORDER BY LogIqvia.Id DESC";
            return await getAllToDataTable(query);

        }
        public static async Task<DataTable> getToDataTableSinteticoByDateAsync(DateTime dt0 , DateTime dtf)
        {
            string query = $@"WITH UltimosRegistros AS (
    SELECT 
        LogIqvia.Id,
        LogIqvia.DataArquivo,
        LogIqvia.idFTP,
        ROW_NUMBER() OVER (PARTITION BY LogIqvia.DataArquivo ORDER BY LogIqvia.Id DESC) AS RowNum
    FROM LogIqvia
)

SELECT 
    /** LogIqvia.Id,**/
    LogIqvia.DataArquivo AS [Arquivo do dia],
    Ftp.description AS [FTP],
    LogIqvia.Feedback,
    IIF(LogIqvia.LayoutProduto = 1, 'Enviado', 'Não enviado') AS [Produto],
    IIF(LogIqvia.LayoutVendas = 1, 'Enviado', 'Não enviado') AS [Vendas],
    IIF(LogIqvia.LayoutCliente = 1, 'Enviado', 'Não enviado') AS [Cliente],
    [Possui bloqueios?] = IIF(MAX(LI.idIqviaRestriction) IS NOT NULL, 'Sim', 'Não'),  
    LogIqvia.DataEnvio AS [Enviado em],
    IIF(Users.name IS NULL, 'ADMIN', Users.Name) AS [Por]
FROM LogIqvia
LEFT JOIN Ftp ON Ftp.id = LogIqvia.idFTP
LEFT JOIN Users ON Users.id = LogIqvia.idUser
LEFT JOIN LogIqvia_IqviaRestriction LI ON LI.idLogIqvia = LogIqvia.Id
JOIN UltimosRegistros UR ON UR.Id = LogIqvia.Id AND UR.RowNum = 1
WHERE LogIqvia.DataArquivo BETWEEN '{dt0.ToString("yyyyMMdd")}' AND '{dtf.ToString("yyyyMMdd")}'
GROUP BY 
    LogIqvia.Id,
    LogIqvia.DataArquivo,
    Ftp.description,
    LogIqvia.Feedback,
    LogIqvia.LayoutProduto,
    LogIqvia.LayoutVendas,
    LogIqvia.LayoutCliente,
    LogIqvia.DataEnvio,
    Users.name
ORDER BY LogIqvia.DataArquivo ASC;";

            return await getAllToDataTable(query);
        }

    }
}
