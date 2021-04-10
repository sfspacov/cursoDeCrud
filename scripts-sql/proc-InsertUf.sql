USE [Teste]
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

