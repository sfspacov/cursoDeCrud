USE [Teste]
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

