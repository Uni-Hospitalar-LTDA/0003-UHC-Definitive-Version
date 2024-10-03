--Query versão 1.0.5 

go
use UHCDB

CREATE TABLE CredenciaisSwagger
(
	Id INT IDENTITY (1,1),
	Description VARCHAR(255),
	Obsevarion VARCHAR(MAX),
	RotaSwagger VARCHAR(255),
	LoginSwagger VARCHAR(50),
	SenhaSwagger VARCHAR(MAX),
	Matricula VARCHAR(50),
	DataCriacao DATETIME NOT NULL,
	DateEdicao DATETIME DEFAULT GETDATE(),
	Status SMALLINT DEFAULT 1
)