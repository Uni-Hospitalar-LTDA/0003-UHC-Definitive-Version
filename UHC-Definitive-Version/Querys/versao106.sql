--go
--use UHCDB

--CREATE TABLE IqviaRestriction 
--(
--	Id INT IDENTITY(1,1) PRIMARY KEY,
--	Description VARCHAR(100),
--	Observation VARCHAR(500),
--	Status SMALLINT,
--	CreatedAt DATETIME DEFAULT GETDATE(),
--	EditedAt DATETIME,
--	lastUser INT,
--	InitialDate DATETIME,
--	FinalDate DATETIME
--)

--CREATE TABLE IqviaRestrictionItens
--(
--	Id INT IDENTITY(1,1) PRIMARY KEY,	
--	Observation VARCHAR(500),
--	Type VARCHAR(50),
--	KeyItem VARCHAR(255)
--)

--CREATE TABLE IqviaRestriction_IqviaRestrictionItens
--(
--	idIqviaRestriction INT FOREIGN KEY REFERENCES IqviaRestriction(Id),
--	idIqviaRestrictionItens INT FOREIGN KEY REFERENCES IqviaRestrictionItens(Id)
--)

CREATE TABLE LogIqvia 
(
	Id INT IDENTITY (1,1) PRIMARY KEY,
	idFTP INT FOREIGN KEY REFERENCES FTP(Id),
	Feedback VARCHAR(500),
	DataArquivo DATE,
	DataEnvio DATETIME,
	idUser INT,
	LayoutProduto SMALLINT,
	LayoutVendas SMALLINT,
	LayoutCliente SMALLINT
)

CREATE TABLE LogIqvia_IqviaRestriction
(
	idLogIqvia INT FOREIGN KEY REFERENCES LogIqvia(Id),
	idIqviaRestriction INT FOREIGN KEY REFERENCES IqviaRestriction(Id)
)