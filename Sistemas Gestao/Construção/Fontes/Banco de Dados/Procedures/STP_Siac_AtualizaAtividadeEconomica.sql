USE [Sistema Gestao]
GO
/****** Object:  StoredProcedure [dbo].[STP_Siac_AtualizaBairro]    Script Date: 02/07/2011 15:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[STP_Siac_AtualizaAtividadeEconomica]
    @nCOD_SIAC int ,
	@nCDA_ATIVIDADE_ECONOMICA INT,
	@sTX_DESCRICAO VARCHAR(255)
	           
As  
BEGIN   

SET NOCOUNT ON

	UPDATE [TBL_ATIVIDADE_ECONOMICA]
	SET  CODIGO = @nCOD_SIAC, TX_ATIVIDADE_ECONOMICA = @sTX_DESCRICAO
	WHERE CDA_ATIVIDADE_ECONOMICA = @nCDA_ATIVIDADE_ECONOMICA

RETURN
END
