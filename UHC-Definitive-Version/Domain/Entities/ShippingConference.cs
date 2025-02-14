using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class ShippingConference : Querys<ShippingConference>
    {
        public string Num_Nota { get; set; }
        public string Num_CTE { get; set; }
        public string idTransporter { get; set; }
        public string calculatedValue { get; set; }
        public string realValue { get; set; }
        public string observation { get; set; }
        public string date_register { get; set; } = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        public string idUser { get; set; } = "1";

        public static async Task<DataTable> getUncheckedShippingConferenceAsync(System.DateTime dt1, System.DateTime dt2, string idTransporter, string nfe)
        {
            string date = $@"'{dt1.ToString("yyyyMMdd")}' AND '{dt2.ToString("yyyyMMdd")}'";
            string transporter = !string.IsNullOrEmpty(idTransporter) ? $"AND Transportador.Codigo = {idTransporter}" : null;
            string NF = !string.IsNullOrEmpty(nfe) ? $"{nfe}" : null;
            string query = $@"-- Common Table Expression for Readability
WITH PercentagesCTE_Saida AS (
    SELECT 
        NF_Saida.Num_Nota,
        CASE 
            WHEN pCity.idIbge_City = CONVERT(INT, NF_Saida.Cod_CidIbge) THEN pCity.cityPercentage
            ELSE 
                CASE 
                    WHEN pState.UF = CONVERT(VARCHAR, NF_Saida.Estado) COLLATE SQL_Latin1_General_CP1_CI_AS 
					THEN pState.capitalPercentage
                    ELSE 0.0
                END
        END AS CalculatedPercentage
		,		
		CASE 
            WHEN pCity.idIbge_City = CONVERT(INT, NF_Saida.Cod_CidIbge) 
			THEN 
				iif (pCity.cityPercentage * NF_Saida.Vlr_TotalNota < pCity.cityMinValue,pCity.cityMinValue ,pCity.cityPercentage * NF_Saida.Vlr_TotalNota)
            ELSE 
                CASE 
                    WHEN pState.UF = CONVERT(VARCHAR, NF_Saida.Estado) COLLATE SQL_Latin1_General_CP1_CI_AS 
					THEN 
					iif ((pState.capitalPercentage * NF_Saida.Vlr_TotalNota) < pState.capitalMinPrice
					     ,pState.capitalMinPrice 
						 ,pState.capitalPercentage * NF_Saida.Vlr_TotalNota)                    
                END
        END 				
		as _CalculatedValue
		,		
		observation = 
		CASE
		WHEN pCity.idIbge_City = CONVERT(INT,NF_Saida.Cod_CidIbge)
		THEN
				iif (pCity.cityPercentage * NF_Saida.Vlr_TotalNota < pCity.cityMinValue
				,'Percentual aplicado: '+CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),round(pCity.cityPercentage*100,2))) + ' % Valor: R$ '+CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),ROUND(pCity.cityMinValue,2)))
				,'Percentual aplicado: '+CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),round(pCity.cityPercentage*100,2))) +' %')
		ELSE
		CASE 
                    WHEN pState.UF = CONVERT(VARCHAR, NF_Saida.Estado) COLLATE SQL_Latin1_General_CP1_CI_AS 
					THEN 					
					CASE
					when city.capital = 1
					then
					iif ((pState.capitalPercentage * NF_Saida.Vlr_TotalNota) < pState.capitalMinPrice
					     ,'Percentual capital aplicado: ' +CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),round(pState.CapitalPercentage*100,2)))+ ' % Valor: R$ ' +CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),ROUND(pState.capitalMinPrice,2)))
						 ,'Percentual capital aplicado: ' +CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),round(pState.CapitalPercentage*100,2))) + ' %')                    
					when city.capital = 0
					then
					iif ((pState.inlandPercentage * NF_Saida.Vlr_TotalNota) < pState.inlandMinPrice
					     ,'Percentual interior aplicado: ' +CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),round(pState.CapitalPercentage*100,2)))+ ' % Valor: R$ ' +CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),ROUND(pState.capitalMinPrice,2)))
						 ,'Percentual interior aplicado: ' +CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),round(pState.CapitalPercentage*100,2))) + ' %')                    
					END
                END
		end
    FROM [DMD].dbo.[NFSCB] NF_Saida
    JOIN [DMD].dbo.[TRANS] Transportador ON Transportador.Codigo = NF_Saida.Cod_Transportadora
    LEFT JOIN [UHCDB].dbo.[ShippingPercentageCity] pCity ON pCity.idTransporter = Transportador.Codigo
    LEFT JOIN [UHCDB].dbo.[ShippingPercentageState] pState ON pState.idTransporter = Transportador.Codigo
	JOIN [UHCDB].dbo.[CITY] City ON City.idIBGE = CONVERT(INT,NF_Saida.Cod_CidIbge)
    WHERE NF_Saida.SER_NOTA NOT LIKE 'XXX' 
        AND NF_Saida.Status NOT LIKE 'C' 
        AND NF_Saida.Dat_Emissao BETWEEN {date}
		{transporter}
		
		

),

PercentagesCTE_Entrada AS (
    SELECT 
        NF_Entrada.Numero,
        CASE 
            WHEN pCity.idIbge_City = CONVERT(INT, NF_Entrada.Cod_CidIbge) THEN pCity.cityPercentage
            ELSE 
                CASE 
                    WHEN pState.UF = CONVERT(VARCHAR, NF_Entrada.Cod_UfOrigem) COLLATE SQL_Latin1_General_CP1_CI_AS 
					THEN pState.capitalPercentage
                    ELSE 0.0
                END
        END AS CalculatedPercentage
		,		
		CASE 
            WHEN pCity.idIbge_City = CONVERT(INT, NF_Entrada.Cod_CidIbge) 
			THEN 
				iif (pCity.cityPercentage * NF_Entrada.Vlr_Nota < pCity.cityMinValue,pCity.cityMinValue ,pCity.cityPercentage * NF_Entrada.Vlr_Nota)
            ELSE 
                CASE 
                    WHEN pState.UF = CONVERT(VARCHAR, NF_Entrada.Cod_UfOrigem) COLLATE SQL_Latin1_General_CP1_CI_AS 
					THEN 
					iif ((pState.capitalPercentage * NF_Entrada.Vlr_Nota) < pState.capitalMinPrice
					     ,pState.capitalMinPrice 
						 ,pState.capitalPercentage * NF_Entrada.Vlr_Nota)                    
                END
        END 
		
		
		as _CalculatedValue
		,
		observation = 
		CASE
		WHEN pCity.idIbge_City = CONVERT(INT,NF_Entrada.Cod_CidIbge)
		THEN
				iif (pCity.cityPercentage * NF_Entrada.Vlr_Nota < pCity.cityMinValue
				,'Percentual aplicado: '+CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),round(pCity.cityPercentage*100,2))) + ' % Valor: R$ '+CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),ROUND(pCity.cityMinValue,2)))
				,'Percentual aplicado: '+CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),round(pCity.cityPercentage*100,2)))+' %') 
		ELSE
		CASE 
                    WHEN pState.UF = CONVERT(VARCHAR, NF_Entrada.Cod_UfOrigem) COLLATE SQL_Latin1_General_CP1_CI_AS 
					THEN 					
					CASE
					when city.capital = 1
					then
					iif ((pState.capitalPercentage * NF_Entrada.Vlr_Nota) < pState.capitalMinPrice
					     ,'Percentual capital aplicado: ' +CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),round(pState.CapitalPercentage*100,2)))+ ' % Valor: R$ ' +CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),ROUND(pState.capitalMinPrice,2)))
						 ,'Percentual capital aplicado: ' +CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),round(pState.CapitalPercentage*100,2)))+ ' %')                    
					when city.capital = 0
					then
					iif ((pState.inlandPercentage * NF_Entrada.Vlr_Nota) < pState.inlandMinPrice
					     ,'Percentual interior aplicado: ' +CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),round(pState.CapitalPercentage*100,2)))+ ' % Valor: R$ ' +CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),ROUND(pState.capitalMinPrice,2)))
						 ,'Percentual interior aplicado: ' +CONVERT(VARCHAR,CONVERT(NUMERIC(12,2),round(pState.CapitalPercentage*100,2))) + ' %')                    
					END
                END
		end
    FROM [DMD].dbo.[NFECB] NF_Entrada
    JOIN [DMD].dbo.[TRANS] Transportador ON Transportador.Codigo = NF_Entrada.Cod_Transp
    LEFT JOIN [UHCDB].dbo.[ShippingPercentageCity] pCity ON pCity.idTransporter = Transportador.Codigo
    LEFT JOIN [UHCDB].dbo.[ShippingPercentageState] pState ON pState.idTransporter = Transportador.Codigo
	JOIN [UHCDB].dbo.[CITY] City ON City.idIBGE = CONVERT(INT,NF_Entrada.Cod_CidIbge)
    WHERE NF_Entrada.Status NOT LIKE 'C' AND Tip_NF = 'D'
        AND NF_Entrada.Dat_Emissao BETWEEN {date}
		{transporter}
)

SELECT distinct
    NF_Saida.Num_Nota [NF],
    Transportador.Codigo [Código],
    Transportador.Razao_Social [Transprotador],
    Convert(DATE,NF_Saida.Dat_Emissao) [Emissão],
    NF_Saida.Estado [Estado],
    NF_Saida.Cidade [Cidade],
    NF_Saida.Vlr_TotalNota [Vlr. Total],    
	CalculatedPercentage [%],
	_CalculatedValue [Vlr. Calculado],
	[Vlr. Real] =  _CalculatedValue,
	CTE = '',
	[Observação] = PercentagesCTE_Saida.observation
FROM [DMD].dbo.[NFSCB] NF_Saida
JOIN [DMD].dbo.[TRANS] Transportador ON Transportador.Codigo = NF_Saida.Cod_Transportadora
LEFT JOIN [UHCDB].dbo.[ShippingConference] ShippingConference ON ShippingConference.Num_Nota = NF_Saida.Num_Nota
LEFT JOIN PercentagesCTE_Saida ON PercentagesCTE_Saida.Num_Nota = NF_Saida.Num_Nota 
WHERE ShippingConference.Num_Nota IS NULL
AND NF_Saida.Dat_Emissao BETWEEN {date}
{transporter}
AND NF_Saida.Num_Nota like '%{NF}%' 
and _CalculatedValue is not null

UNION 

SELECT 
	NF_Entrada.Numero,
    Transportador.Codigo,
    Transportador.Razao_Social,
    Convert(DATE,NF_Entrada.Dat_Emissao),
    NF_Entrada.Cod_UfOrigem state,
    NF_Entrada.Cidade city,
    NF_Entrada.Vlr_Nota nfValue,    
	CalculatedPercentage AS percentage,
	_CalculatedValue AS calculatedValue,
	[transporterValue] =  _CalculatedValue,
	cte = '',
	observation = PercentagesCTE_Entrada.observation
FROM [DMD].dbo.[NFECB] NF_Entrada
JOIN [DMD].dbo.[TRANS] Transportador ON Transportador.Codigo = NF_Entrada.Cod_Transp
LEFT JOIN [UHCDB].dbo.[ShippingConference] ShippingConference ON ShippingConference.Num_Nota = NF_Entrada.Numero
LEFT JOIN PercentagesCTE_Entrada ON PercentagesCTE_Entrada.Numero = NF_Entrada.Numero 
WHERE ShippingConference.Num_Nota IS NULL
AND NF_Entrada.Dat_Emissao BETWEEN {date}
{transporter}
AND NF_Entrada.Numero like '%{NF}%' 
and _CalculatedValue is not null
";

            Console.WriteLine(query);
            return await getAllToDataTable(query);
        }

        public static async Task<DataTable> getShippingConferenceToUpdateAsync(System.DateTime dt1, System.DateTime dt2, string idTransporter, string nfe, string cte)
        {

            string date = $@"CONVERT(DATE,'{dt1.ToString("yyyyMMdd")}') AND CONVERT(DATE,'{dt2.ToString("yyyyMMdd")}')";
            string transporter = !string.IsNullOrEmpty(idTransporter) ? $"AND Transportador.Codigo = {idTransporter}" : null;
            string NF = !string.IsNullOrEmpty(nfe) ? $"{nfe}" : null;
            string CTE = !string.IsNullOrEmpty(cte) ? $"{cte}" : null;

            string query = $@"SELECT TOP 100
	 NF_Saida.Num_Nota [NF]
	,shipping.Num_CTE  [CTE]
	,idTransporter [Cód. Transportador]
	,[Transprotador] = Transportador.Fantasia
	,NF_Saida.Cidade
	,NF_Saida.Estado
	,NF_Saida.Vlr_TotalNota [Vlr. Total]
	,shipping.calculatedValue [Vlr. Calculado]
	,shipping.realValue [Vlr. Real]
	,[Equivalência] = shipping.realValue - shipping.calculatedValue
	,Registro = CONVERT(DATE,shipping.dat_register)
	,shipping.Observation [Observação]
	
FROM [UHCDB].dbo.[ShippingConference] shipping
JOIN [DMD].dbo.[NFSCB] NF_Saida ON NF_Saida.Num_nota = shipping.Num_Nota
join [DMD].dbo.[TRANS] Transportador ON Transportador.Codigo = idTransporter
WHERE
CONVERT(DATE,Shipping.Dat_register) BETWEEN {date}
{transporter}
AND Shipping.Num_Nota LIKE '%{NF}%'
AND Shipping.Num_CTE LIKE '%{CTE}%'
UNION ALL

SELECT TOP 100
	 shipping.Num_Nota [NF]
	,shipping.Num_CTE  [CTE]
	,idTransporter [Cód. Transportador]
	,[Transprotador] = Transportador.Fantasia
	,NF_Entrada.Cidade
	,NF_Entrada.Cod_UfOrigem
	,NF_Entrada.Vlr_Nota [Vlr. Total]
	,shipping.calculatedValue [Vlr. Calculado]
	,shipping.realValue [Vlr. Real]
	,[Equivalência] = shipping.realValue - shipping.calculatedValue
	,Registro = CONVERT(DATE,shipping.dat_register)
	,shipping.Observation [Observação]
FROM [UHCDB].dbo.[ShippingConference] shipping
JOIN [DMD].dbo.[NFECB] NF_Entrada ON 
(NF_Entrada.Numero = shipping.Num_Nota) AND NF_Entrada.Tip_NF = 'D'
join [DMD].dbo.[TRANS] Transportador ON Transportador.Codigo = idTransporter
WHERE 
CONVERT(DATE,Shipping.Dat_register) BETWEEN {date}
{transporter}
AND Shipping.Num_Nota LIKE '%{NF}%'
AND Shipping.Num_CTE LIKE '%{CTE}%'
ORDER BY 
	Registro desc
	,NF DESC
	";

            return await getAllToDataTable(query);
        }

        public async static Task updateAsync(string nf, string cte, string rv, string observation)
        {
            using (SqlConnection conn = Connection.getInstancia().getConnectionApp(Section.Unidade))
            {
                SqlTransaction transaction = null;
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    transaction = conn.BeginTransaction();
                    command.Connection = conn;
                    command.Transaction = transaction;
                    command.CommandText = $@"UPDATE [UHCDB].dbo.[ShippingConference]
												 SET  Num_CTE = {cte}
												 	,realValue = {rv.Replace(",", ".")}
												 	,Observation = '{observation}' 
												 	,dat_register = getdate()
												 	,idUser = {Section.idUsuario}
												 WHERE 
												 Num_Nota = {nf}";

                    Console.WriteLine(command.CommandText);
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                    transaction.Rollback();
                    conn.Close();
                }
                finally
                {
                    transaction.Commit();
                    conn.Close();
                }
            }
        }
    }
}
