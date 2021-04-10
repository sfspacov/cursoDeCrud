USE [Teste]
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

