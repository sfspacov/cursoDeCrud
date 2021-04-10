USE [Teste]
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

