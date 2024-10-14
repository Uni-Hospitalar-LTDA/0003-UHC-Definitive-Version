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


CREATE TABLE  Interplayers_Pfizer_Pedido
 (
     Id INT IDENTITY (1,1),
     PedidoPfizer VARCHAR(50),
     PedidoUni VARCHAR(50),
     Retorno VARCHAR(500),
     Data_Registro DATETIME,
	 JsonEnviado VARCHAR(MAX),
	 Response VARCHAR(MAX),
	 Base VARCHAR(255),
	 Babricante VARCHAR(255)
)


