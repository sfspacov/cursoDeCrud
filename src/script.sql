IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'AulaCrud')
BEGIN	
	CREATE DATABASE [AulaCrud];		
END
ELSE
BEGIN
	raiserror('BANCO DE DADOS AulaCrud JA EXISTE!', 20, -1) with log
END
GO
USE [AulaCrud]
GO

/****** Object:  Table [dbo].[UF]    Script Date: 10/04/2021 15:36:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UF](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](15) NOT NULL,
	[Abbreviation] [varchar](2) NOT NULL,
	CONSTRAINT [PK_UF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Cidade]    Script Date: 10/04/2021 15:35:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](26) NOT NULL,
	[IdUf] [int] NOT NULL,
	[Capital] [bit] NOT NULL,
	CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cidade]  WITH CHECK ADD  CONSTRAINT [FK_City_UF] FOREIGN KEY([IdUf])
REFERENCES [dbo].[UF] ([Id])
GO

ALTER TABLE [dbo].[Cidade] CHECK CONSTRAINT [FK_City_UF]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 10/04/2021 15:36:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[CPF] [varchar](14) NOT NULL,
	[Name] [nvarchar](26) NOT NULL,
	[IdCity] [int] NOT NULL,
	CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 10/04/2021 15:38:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE	Procedure [dbo].[UpdateUser]
@Name varchar(26),
@Cpf varchar(14),
@NewCpf varchar(14),
@IdCity int
AS
UPDATE Usuario
SET Name =@Name,
	CPF = @NewCpf,
	IdCity = @IdCity
WHERE Cpf=@Cpf
GO

/****** Object:  StoredProcedure [dbo].[SelectUser]    Script Date: 10/04/2021 15:37:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SelectUser]
@Cpf varchar(14)
AS
SELECT 
	u.Name,
	u.Cpf,
	c.Name as City,
	c.Id as IdCity,
	c.IdUf
FROM Usuario u JOIN Cidade c
ON u.IdCity = c.Id
WHERE cpf = ISNULL(@Cpf,cpf)
GO

/****** Object:  StoredProcedure [dbo].[SelectUf]    Script Date: 10/04/2021 15:37:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SelectUf]

AS
SELECT Id, Name, Abbreviation FROM Uf ORDER BY Name
GO


/****** Object:  StoredProcedure [dbo].[SelectCity]    Script Date: 10/04/2021 15:37:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create Procedure [dbo].[SelectCity]
@IdUf int
AS
SELECT Id, Name, IdUf, Capital FROM Cidade WHERE IdUF = @IdUf ORDER BY [Name]
GO

/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 10/04/2021 15:37:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE	Procedure [dbo].[InsertUser]  --INSERT PROC NAME HERE
@Name varchar(26),
@Cpf varchar(14),
@IdCity int
AS
INSERT INTO Usuario ([Name], Cpf, IdCity) VALUES (@Name, @Cpf, @IdCity)
GO


/****** Object:  StoredProcedure [dbo].[InsertUf]    Script Date: 10/04/2021 15:37:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE	Procedure [dbo].[InsertUf]  --INSERT PROC NAME HERE
@Name varchar(26),
@Abbreviation varchar(2)

AS
INSERT INTO Uf (Name, Abbreviation)
OUTPUT Inserted.Id
VALUES (@Name, @Abbreviation)
GO


/****** Object:  StoredProcedure [dbo].[InsertCity]    Script Date: 10/04/2021 15:36:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE	Procedure [dbo].[InsertCity]  --INSERT PROC NAME HERE
@Name varchar(26),
@Capital bit,
@IdUf int
AS
INSERT INTO Cidade (Name, IdUf, Capital)
OUTPUT Inserted.Id
VALUES (@Name, @IdUf, @Capital)
GO

/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 10/04/2021 15:36:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[DeleteUser]
@Cpf varchar(14)
AS
DELETE FROM Usuario WHERE Cpf = @Cpf
GO

EXEC InsertUf 'Sao Paulo', 'SP'
EXEC InsertUf 'Bahia', 'BA'
EXEC InsertUf 'Rio de Janeiro', 'RJ'

GO
DECLARE @IdUf INT

SET @IdUf = (SELECT TOP 1 Id FROM Uf WHERE Abbreviation='SP')
EXEC InsertCity 'Sao Paulo', 1, @IdUf
EXEC InsertCity 'Ubatuba', 0, @IdUf
EXEC InsertCity 'Ilha Bela', 0, @IdUf

SET @IdUf = (SELECT TOP 1 Id FROM Uf WHERE Abbreviation='BA')

EXEC InsertCity 'Salvador',1, @IdUf
EXEC InsertCity 'Ilheus',0, @IdUf
EXEC InsertCity 'Porto Seguro',0, @IdUf

SET @IdUf = (SELECT TOP 1 Id FROM Uf WHERE Abbreviation='RJ')
EXEC InsertCity 'Rio de Janeiro',1, @IdUf
EXEC InsertCity 'Buzios',0, @IdUf
EXEC InsertCity 'Arraial do Cabo',0, @IdUf

EXEC InsertUser 'Caetano Veloso', '307.756.160-36', 1
EXEC InsertUser 'Chico Science', '708.068.890-63', 2
EXEC InsertUser 'Cartola', '221.070.340-95', 3
EXEC InsertUser 'Tim Maia', '521.874.640-16', 5
EXEC InsertUser 'Raul Seixas', '805.739.620-22', 4
EXEC InsertUser 'David Gilmore', '547.755.250-69', 6


EXEC InsertUser 'Usuario teste', '370.393.678-90', 1

PRINT ' '
PRINT 'BANCO DE DADOS AulaCrud CRIADO COM SUCESSO!!'
PRINT ' '