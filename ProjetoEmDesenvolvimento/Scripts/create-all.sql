--CRIACAO DE BANCO DE DADOS
USE [master]
GO

/****** Object:  Database [AulaCrud]    Script Date: 17/05/2021 20:56:50 ******/
CREATE DATABASE [AulaCrud]
GO
-- CRIACAO DE TABELA UF

USE [AulaCrud]
GO

CREATE TABLE [dbo].[UF](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Abbreviation] [varchar](2) NOT NULL,
	[Nome] [varchar](20) NOT NULL,
 CONSTRAINT [PK_UF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

CREATE TABLE [dbo].[Cidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUf] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
    [IsCapital] [bit] NOT NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

ALTER TABLE [dbo].[Cidade]  WITH CHECK ADD  CONSTRAINT [FK_Cidade_UF] FOREIGN KEY([IdUf])
REFERENCES [dbo].[UF] ([Id])
GO

ALTER TABLE [dbo].[Cidade] CHECK CONSTRAINT [FK_Cidade_UF]
GO

CREATE TABLE [dbo].[Usuario](
	[CPF] [varchar](14) NOT NULL,
	[IdCity] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[CPF] ASC
))

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Cidade] FOREIGN KEY([IdCity])
REFERENCES [dbo].[Cidade] ([Id])
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Cidade]
GO

INSERT INTO UF
VALUES
('BA', 'Bahia'),
('SP', 'São Paulo'),
('TO', 'Tocantins') 

INSERT INTO Cidade
VALUES
('1', 'Salvador', 1),
('1', 'Ilhéus', 0),
('2', 'Santos', 0),
('2', 'Cotia', 0),
('3', 'Palmas', 1),
('3', 'Tocantinópolis', 0)

CREATE PROCEDURE [dbo].[DeleteUsuario]
    @cpf varchar(14)
AS
    DELETE FROM usuario WHERE cpf=@cpf
GO

CREATE PROCEDURE [dbo].[ListarUsuario]
AS
SELECT
    CPF    
    ,u.Nome
    ,c.Nome Cidade
    ,c.Id IdCity
    ,c.IdUf
FROM Usuario AS u
JOIN Cidade AS c ON u.IdCity = c.Id
GO

CREATE PROCEDURE [dbo].[UpdateUsuario]
    @idCity int,
    @cpf varchar(14),
    @Nome varchar(50)

AS
UPDATE Usuario
SET     
    IdCity = @idCity,
    Nome = @nome
WHERE CPF = @cpf
GO