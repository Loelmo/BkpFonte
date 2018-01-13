USE [Sistema Gestao]
GO
/****** Object:  StoredProcedure [dbo].[STP_SelecionaPerguntaPorId]    Script Date: 01/12/2011 15:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[STP_SelecionaPerguntasPorQuestionario]
(
 @nCEA_QUESTIONARIO INT
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT p.CDA_PERGUNTA,
		   p.CEA_CRITERIO,
		   p.CEA_PERGUNTA_TIPO,
		   p.FL_ATIVO,
		   p.NU_ORDEM,
		   p.TX_GLOSSARIO,
		   p.TX_PERGUNTA,
		   p.TX_SAIBA_MAIS
	  FROM TBL_PERGUNTA p
	  INNER JOIN TBL_CRITERIO c ON c.CDA_CRITERIO = p.CEA_CRITERIO
	 WHERE c.CEA_QUESTIONARIO = @nCEA_QUESTIONARIO
	  ORDER BY p.NU_ORDEM
  
RETURN  
END  
    
--    
