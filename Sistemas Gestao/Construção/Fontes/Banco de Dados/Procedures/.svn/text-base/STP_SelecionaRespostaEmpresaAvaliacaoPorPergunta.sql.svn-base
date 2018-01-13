USE [Sistema Gestao]
GO
/****** Object:  StoredProcedure [dbo].[STP_SelecionaRespostaEmpresaAvaliacaoPorPergunta]    Script Date: 01/12/2011 13:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[STP_SelecionaRespostaEmpresaAvaliacaoPorPergunta]
(
 @nIdPergunta INT,
 @nIdQuestionarioEmpresa INT
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT pr.CDA_RESPOSTA,
		   pr.CEA_PERGUNTA,
		   pr.FL_POSSUI_JUSTIFICATIVA,
		   pr.LBL_RESPOSTA,
		   pr.LBL_VALOR_01,
		   pr.LBL_VALOR_02,
		   pr.LBL_VALOR_03,
		   pr.LBL_VALOR_04,
		   pr.LBL_VALOR_05,
		   pr.LBL_VALOR_06,
		   pr.LBL_VALOR_07,
		   pr.LBL_VALOR_08,
		   pr.LBL_VALOR_09,
		   pr.LBL_VALOR_10,
		   pr.NU_ORDEM,
		   pr.NU_PONTO,
		   pr.TX_RESPOSTA_AUTOMATICA,
		   qer.CEA_QUESTIONARIO_EMPRESA,
		   qer.CEA_USUARIO_DIGITADOR,
		   qer.CEA_USUARIO_AVALIADOR,
		   qer.FL_RESPOSTA_BOOL,
		   qer.TX_JUSTIFICATIVA,
		   qer.CEA_RESPOSTA,
		   qer.TX_OPORTUNIDADE_MELHORIA,
		   qer.TX_PONTO_FORTE,
		   qer.TX_RESPOSTA,
		   qer.TX_VALOR_01,
		   qer.TX_VALOR_02,
		   qer.TX_VALOR_03,
		   qer.TX_VALOR_04,
		   qer.TX_VALOR_05,
		   qer.TX_VALOR_06,
		   qer.TX_VALOR_07,
		   qer.TX_VALOR_08,
		   qer.TX_VALOR_09,
		   qer.TX_VALOR_10
	  FROM TBL_PERGUNTA_RESPOSTA pr
 INNER JOIN (SELECT * FROM TBL_QUESTIONARIO_EMPRESA_RESPOSTA WHERE CEA_QUESTIONARIO_EMPRESA = @nIdQuestionarioEmpresa AND CEA_USUARIO_AVALIADOR IS NOT NULL) qer ON qer.CEA_RESPOSTA = pr.CDA_RESPOSTA
	 WHERE pr.CEA_PERGUNTA = @nIdPergunta
  ORDER BY pr.NU_ORDEM
  
RETURN  
END  
    
--    
