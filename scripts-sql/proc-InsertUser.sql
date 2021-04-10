USE [Teste]
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

