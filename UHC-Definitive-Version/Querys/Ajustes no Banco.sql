USE UHCDB;
GO

-- Renomear coluna com checagem de existência
IF EXISTS(SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'active')
BEGIN
    EXEC sp_rename 'Users.active', 'Status', 'COLUMN';
END;
GO

-- Adicionar e atualizar Status na tabela Sector
IF COL_LENGTH('Sector', 'Status') IS NULL
BEGIN
    ALTER TABLE Sector ADD Status SMALLINT DEFAULT 1;
    UPDATE Sector SET Status = 1;
END;
GO

-- Adicionar e atualizar Status na tabela Groups
IF COL_LENGTH('Groups', 'Status') IS NULL
BEGIN
    ALTER TABLE Groups ADD Status SMALLINT DEFAULT 1;
    UPDATE Groups SET Status = 1;
END;
GO

-- Criar tabela Logs se não existir
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

-- Criar tabela MonitorGnre se não existir
IF OBJECT_ID('dbo.MonitorGnre', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.MonitorGnre(
        num_Nota INT NULL,
        Data_Bloqueio DATETIME NULL,
        Data_Exportacao DATETIME NULL,
        flg_BloqExport SMALLINT NULL,
        Observacao VARCHAR(500) NULL,
        idUsers INT NULL
    );
END;
GO

-- Criar tabela Users se não existir
IF OBJECT_ID('dbo.Users', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users(
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Login VARCHAR(55) NULL,
        Name VARCHAR(255) NULL,
        Email VARCHAR(255) NULL,
        Password VARCHAR(MAX),
        idSector INT FOREIGN KEY REFERENCES Sector(ID),
        SetPassword SMALLINT,		
        Status SMALLINT DEFAULT 1
    );
END;
GO



go
use UHCDB
-- Drop tabela Groups_Action se existir
IF OBJECT_ID('dbo.Groups_Action', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Groups_Action;
END;
GO

-- Drop tabela Groups_Screen se existir
IF OBJECT_ID('dbo.Groups_Screen', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Groups_Screen;
END;
GO

-- Drop tabela Groups_SubModule se existir
IF OBJECT_ID('dbo.Groups_SubModule', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Groups_SubModule;
END;
GO

-- Drop tabela Groups_Module se existir
IF OBJECT_ID('dbo.Groups_Module', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Groups_Module;
END;
GO

-- Drop tabela Users_Groups se existir
IF OBJECT_ID('dbo.Users_Groups', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Users_Groups;
END;
GO

-- Drop tabela Groups se existir
IF OBJECT_ID('dbo.Groups', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Groups;
END;
GO

-- Drop tabela Action se existir
IF OBJECT_ID('dbo.Action', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Action;
END;
GO

-- Drop tabela Screen se existir
IF OBJECT_ID('dbo.Screen', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Screen;
END;
GO

-- Drop tabela SubModule se existir
IF OBJECT_ID('dbo.SubModule', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.SubModule;
END;
GO

-- Drop tabela Module se existir
IF OBJECT_ID('dbo.Module', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Module;
END;
GO

-- Criar tabela Module se não existir
IF OBJECT_ID('dbo.Module', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Module(
        Id INT IDENTITY(1,1) PRIMARY KEY,        
        Name VARCHAR(500) NULL,
        Description VARCHAR(MAX) NULL
    );
END;
GO

-- Criar tabela SubModule se não existir
IF OBJECT_ID('dbo.SubModule', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SubModule(
        Id INT IDENTITY(1,1) PRIMARY KEY,        
        Name VARCHAR(500) NULL,
        Description VARCHAR(MAX) NULL,		
        idModule INT FOREIGN KEY REFERENCES Module(Id)
    );
END;
GO

-- Criar tabela Screen se não existir
IF OBJECT_ID('dbo.Screen', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Screen(
        Id INT IDENTITY(1,1) PRIMARY KEY,        
        Name VARCHAR(500) NULL,
        Description VARCHAR(MAX) NULL,		
        idSubModule INT FOREIGN KEY REFERENCES SubModule(Id)
    );
END;
GO

-- Criar tabela Action se não existir
IF OBJECT_ID('dbo.Action', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Action(
        Id INT IDENTITY(1,1) PRIMARY KEY,        
        Name VARCHAR(500) NULL,
        Description VARCHAR(MAX) NULL,		
        idScreen INT FOREIGN KEY REFERENCES Screen(Id)
    );
END;
GO

-- Criar tabela Groups se não existir
IF OBJECT_ID('dbo.Groups', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Groups(
        Id INT IDENTITY(1,1) PRIMARY KEY,        
        Name VARCHAR(500) NULL,
        Description VARCHAR(MAX) NULL,
        Status SMALLINT DEFAULT 1
    );
END;
GO

-- Criar tabela Users_Groups se não existir
IF OBJECT_ID('dbo.Users_Groups', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users_Groups(
       idUsers INT FOREIGN KEY REFERENCES Users(Id),					
       idGroups INT FOREIGN KEY REFERENCES Groups(Id)
    );
END;
GO

-- Criar tabela Groups_Module se não existir
IF OBJECT_ID('dbo.Groups_Module', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Groups_Module(
        idGroups INT FOREIGN KEY REFERENCES Groups(Id),
        idModule INT FOREIGN KEY REFERENCES Module(Id)
    );
END;
GO

-- Criar tabela Groups_SubModule se não existir
IF OBJECT_ID('dbo.Groups_SubModule', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Groups_SubModule(
        idGroups INT FOREIGN KEY REFERENCES Groups(Id),
        idSubModule INT FOREIGN KEY REFERENCES SubModule(Id)
    );
END;
GO

-- Criar tabela Groups_Screen se não existir
IF OBJECT_ID('dbo.Groups_Screen', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Groups_Screen(
        idGroups INT FOREIGN KEY REFERENCES Groups(Id),
        idScreen INT FOREIGN KEY REFERENCES Screen(Id)
    );
END;
GO

-- Criar tabela Groups_Action se não existir
IF OBJECT_ID('dbo.Groups_Action', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Groups_Action(
        idGroups INT FOREIGN KEY REFERENCES Groups(Id),
        idAction INT FOREIGN KEY REFERENCES Action(Id)
    );
END;
GO 

-- Criar tabela City se não existir
IF OBJECT_ID('dbo.City', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[City](
        idIBGE VARCHAR(7) NOT NULL,
        description VARCHAR(255) NOT NULL,
        idCounty VARCHAR(5) NOT NULL,
        capital SMALLINT NULL,
        idIBGE_State VARCHAR(2) NOT NULL,
        CONSTRAINT [PKCity] PRIMARY KEY CLUSTERED (idIBGE ASC)
    );
    ALTER TABLE [dbo].[City] ADD DEFAULT ((0)) FOR [capital];
    ALTER TABLE [dbo].[City]  WITH NOCHECK ADD FOREIGN KEY([idIBGE_State]) REFERENCES [dbo].[State]([idIBGE]);
END;
GO

-- Inserir dados nas tabelas State e City
INSERT INTO State (idIBGE, uf, description, region)
SELECT * FROM UHCDB.dbo.State;

INSERT INTO City (idIBGE, description, idCounty, capital, idIBGE_State)
SELECT * FROM UHCDB.dbo.City;
GO

-- Inserir dados no módulo se não existir
IF NOT EXISTS (SELECT 1 FROM Module WHERE Name = 'Administrativo')
BEGIN
    INSERT INTO Module (Name, Description)
    VALUES
    ('Administrativo','Módulo de Operações Administrativas'),
    ('Financeiro','Módulo das operações Financeiras.'),
    ('Licitação','Módulo das operações Licitatórias.'),
    ('Logística','Módulo de Logística'),
    ('Vendas','Módulo voltado a equipe operacional de vendas.'),
    ('Gerencial','Módulo Gerencial, contém o mais diversos relatórios e indicadores para a alta gestão.'),
    ('Opções','Módulo das opções da ferramenta.'),
    ('Contábil / Fiscal','Módulo de Operações Fiscal Contábeis');
END;
GO --ok

-- Inserir dados no SubModule e Screen apenas se não existir
-- SubModules do módulo Administrativo
IF NOT EXISTS (SELECT 1 FROM SubModule WHERE Name = 'Cadastral' AND idModule = 1)
BEGIN
    INSERT INTO SubModule (Name, Description, idModule)
    VALUES
    ('Cadastral','',1),
    ('Canhotos','',1),
    ('Fretes','',1);
END;
GO

-- Inserir dados nas Screens apenas se não existir
IF NOT EXISTS (SELECT 1 FROM Screen WHERE Name = 'Informações de Transportadora' AND idSubModule = 1)
BEGIN
    INSERT INTO Screen (Name, Description, idSubModule)
    VALUES
    ('Informações de Transportadora','',1),
    ('Controle de Canhotos','',2),
    ('Relatório de Ausências','',2),
    ('Conversor para Layout','',3),
    ('Conferência de Fretes','',3),
    ('Relatório Analítico','',3),
    ('Manutenção de Fretes','',3);
END;
GO

-- Inserir dados no SubModule financeiro apenas se não existir
IF NOT EXISTS (SELECT 1 FROM SubModule WHERE Name = 'Acompanhamento' AND idModule = 2)
BEGIN
    INSERT INTO SubModule (Name, Description, idModule)
    VALUES
    ('Acompanhamento','',2),
    ('CI','',2),
    ('Cadastral','',2),
    ('Cobrança','',2),
    ('Monitores Financeiros','',2),
    ('Pagamento','',2),
    ('Recebimento','',2);
END;
GO

-- Inserir dados nas Screens financeiras apenas se não existir
IF NOT EXISTS (SELECT 1 FROM Screen WHERE Name = 'Títulos Vs Empenho' AND idSubModule = 4)
BEGIN
    INSERT INTO Screen (Name, Description, idSubModule)
    VALUES
    ('Títulos Vs Empenho','',4),
    ('Conferência de CI','',5),
    ('Encaminhamentos','',5),
    ('Responsáveis','',5),
    ('Contatos do Cliente','',6),
    ('Parâmetros de Cobrança','',7),
    ('Monitor GNRE','',8),
    ('Contas a Pagar','',9),
    ('Contas a Receber','',10),
    ('Contas Recebidas','',10),
    ('Recebimento Público e Privado','',10);
END;
GO

-- Criação de tabelas adicionais conforme o necessário
CREATE TABLE DetalhamentoContratos (
    cod_contrato INT,
    cod_produto INT,
    preco_compra_digitado NUMERIC(16,4) DEFAULT 0.0
);
GO

CREATE TABLE IntUpdate (
    Id INT IDENTITY (1,1),
    Version VARCHAR(20),
    Description VARCHAR(MAX)
);
GO
