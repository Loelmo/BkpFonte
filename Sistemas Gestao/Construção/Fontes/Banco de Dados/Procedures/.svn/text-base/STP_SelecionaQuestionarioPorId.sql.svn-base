USE [Sistema Gestao]
GO
/****** Object:  StoredProcedure [dbo].[STP_SelecionaQuestionariosPorTurma]    Script Date: 01/12/2011 14:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[STP_SelecionaQuestionarioPorId]
(
 @nIdQuestionario INT
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT q.CDA_QUESTIONARIO,
		   q.TX_QUESTIONARIO,
		   q.TX_DESCRICAO,
		   q.FL_ATIVO,
		   q.FL_PUBLICADO,
		   q.NU_CICLO,
		   q.DT_QUESTIONARIO,
		   q.FL_PREENCHIMENTO_RAPIDO
	  FROM TBL_QUESTIONARIO q
	 WHERE q.CDA_QUESTIONARIO = @nIdQuestionario
  
RETURN  
END  
    
--    
