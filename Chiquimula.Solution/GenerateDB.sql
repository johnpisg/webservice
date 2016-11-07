GO
CREATE TABLE [dbo].[Imagen] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]  VARCHAR (500)  NOT NULL,
    [path]    VARCHAR (2500) NOT NULL,
    [sitioId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE TABLE [dbo].[Video] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]  VARCHAR (500)  NOT NULL,
    [path]    VARCHAR (2500) NOT NULL,
    [sitioId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE TABLE [dbo].[Sitio] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [nombre]      VARCHAR (500)  NOT NULL,
    [titulo]      VARCHAR (500)  NOT NULL,
    [descripcion] VARCHAR (4000) NOT NULL,
    [ranking]     FLOAT (53)     NOT NULL,
    [imagenId]    INT            NULL,
    [horario]     VARCHAR (250)  NOT NULL,
    [precio]      FLOAT (53)     NOT NULL,
    [info]        VARCHAR (4000) NULL,
    [datos]       VARCHAR (4000) NULL,
    [masdatos]    VARCHAR (4000) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Sitio_To_Imagen] FOREIGN KEY ([imagenId]) REFERENCES [dbo].[Imagen] ([Id])
);
GO
CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] VARCHAR(500) NOT NULL UNIQUE, 
    [Password] VARCHAR(MAX) NOT NULL, 
    [Usuario] VARCHAR(500) NOT NULL
)
GO