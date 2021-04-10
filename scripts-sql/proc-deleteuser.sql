USE [Teste]
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

