CREATE TABLE [Utilizador] (
    [id] int PRIMARY KEY IDENTITY(1, 1),
    [nome] nvarchar(255),
    [password] nvarchar(255)
    )
    GO

CREATE TABLE [Notificacao] (
    [id] int PRIMARY KEY IDENTITY(1, 1),
    [idUtilizador] int,
    [idProva] nvarchar(255)
    )
    GO

CREATE TABLE [Prova] (
    [id] nvarchar(255) PRIMARY KEY,
    [idEpoca] int,
    [ronda] int,
    [nomeProva] nvarchar(255),
    [data] date,
    [horaProva] time,
    [idLocalizacao] nvarchar(255)
    )
    GO

CREATE TABLE [Epoca] (
[ano] int PRIMARY KEY
)
    GO

CREATE TABLE [Localizacao] (
    [id] nvarchar(255) PRIMARY KEY,
    [nome] nvarchar(255),
    [nacionalidade] nvarchar(255),
    [latitude] float,
    [longitude] float
    )
    GO

CREATE TABLE [Qualificacao] (
    [id] int PRIMARY KEY IDENTITY(1, 1),
    [idProva] nvarchar(255),
    [idPiloto] nvarchar(255),
    [posicaoQualificacao] int,
    [qualificacao1] nvarchar(255),
    [qualificacao2] nvarchar(255),
    [qualificacao3] nvarchar(255)
    )
    GO

CREATE TABLE [Resultado] (
    [id] int PRIMARY KEY IDENTITY(1, 1),
    [idProva] nvarchar(255),
    [idPiloto] nvarchar(255),
    [posicaoFinal] int,
    [posicaoInicial] int,
    [tempo] nvarchar(255),
    [pontos] int,
    [estado] nvarchar(255)
    )
    GO

CREATE TABLE [Piloto] (
    [id] nvarchar(255) PRIMARY KEY,
    [nome] nvarchar(255)
    )
    GO

CREATE TABLE [PilotoEquipa] (
    [id] int PRIMARY KEY IDENTITY(1, 1),
    [idPiloto] nvarchar(255),
    [idEquipa] nvarchar(255),
    [idEpoca] int
    )
    GO

CREATE TABLE [Equipa] (
    [id] nvarchar(255) PRIMARY KEY,
    [nome] nvarchar(255),
    [nacionalidade] nvarchar(255)
    )
    GO

CREATE TABLE [Pais] (
    [nome] nvarchar(255) PRIMARY KEY,
    [nacionalidade] nvarchar(255)
    )
    GO

ALTER TABLE [Notificacao] ADD FOREIGN KEY ([idUtilizador]) REFERENCES [Utilizador] ([id])
    GO

ALTER TABLE [Notificacao] ADD FOREIGN KEY ([idProva]) REFERENCES [Prova] ([id])
    GO

ALTER TABLE [Prova] ADD FOREIGN KEY ([idEpoca]) REFERENCES [Epoca] ([ano])
    GO

ALTER TABLE [Prova] ADD FOREIGN KEY ([idLocalizacao]) REFERENCES [Localizacao] ([id])
    GO

ALTER TABLE [Localizacao] ADD FOREIGN KEY ([nacionalidade]) REFERENCES [Pais] ([nome])
    GO

ALTER TABLE [Qualificacao] ADD FOREIGN KEY ([idProva]) REFERENCES [Prova] ([id])
    GO

ALTER TABLE [Qualificacao] ADD FOREIGN KEY ([idPiloto]) REFERENCES [Piloto] ([id])
    GO

ALTER TABLE [Resultado] ADD FOREIGN KEY ([idProva]) REFERENCES [Prova] ([id])
    GO

ALTER TABLE [Resultado] ADD FOREIGN KEY ([idPiloto]) REFERENCES [Piloto] ([id])
    GO

ALTER TABLE [PilotoEquipa] ADD FOREIGN KEY ([idPiloto]) REFERENCES [Piloto] ([id])
    GO

ALTER TABLE [PilotoEquipa] ADD FOREIGN KEY ([idEquipa]) REFERENCES [Equipa] ([id])
    GO

ALTER TABLE [PilotoEquipa] ADD FOREIGN KEY ([idEpoca]) REFERENCES [Epoca] ([ano])
    GO
