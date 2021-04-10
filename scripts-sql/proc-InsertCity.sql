USE [Teste]
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

