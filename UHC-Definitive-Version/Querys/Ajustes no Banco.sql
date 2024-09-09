/** Para os bancos de SP, CE e PE**/
EXEC sp_rename 'Users.active', 'Status', 'COLUMN';


IF OBJECT_ID('dbo.Logs', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Logs(
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Description VARCHAR(100) NULL,
		Data DATETIME,
		tipoRegistro VARCHAR(100) NULL,
		idRegistro VARCHAR(20) NULL,
		idUsuario VARCHAR(20) NULL
    );


END;
GO