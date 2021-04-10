USE [Teste]
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

