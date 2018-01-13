
ALTER PROCEDURE [dbo].[STP_SelecionaQuestionarioEmpresaPorQuestionarioEmpresaTurma]
(
 @nCEA_QUESTIONARIO INT,
 @nCEA_EMP_CADASTRO INT,
 @nCEA_TURMA INT
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT qe.CDA_QUESTIONARIO_EMPRESA,
		   qe.CEA_EMP_CADASTRO,
		   qe.CEA_ETAPA,
		   qe.CEA_PROGRAMA,
		   qe.CEA_QUESTIONARIO,
		   qe.CEA_USUARIO,
		   qe.DT_ALTERACAO,
		   qe.DT_CADASTRO,
		   qe.FL_ATIVO,
		   qe.FL_LEITURA,
		   qe.FL_PASSA_PROXIMA_ETAPA,
		   qe.FL_SINCRONIZADO_SIAC,
		   qe.NU_TOTAL_PONTUACAO,
		   qe.TX_MOTIVO_EXCLUIU,
		   qe.TX_MOTIVO_VENCEU,
		   qe.TX_PROTOCOLO,
		   qe.FL_PREENCHE_QUESTIONARIO,
		   qe.FL_ENVIAR_QUESTIONARIO,
		   qe.FL_RELATORIO_GERADO
	  FROM TBL_QUESTIONARIO_EMPRESA qe
INNER JOIN TBL_ETAPA e ON e.CDA_ETAPA = qe.CEA_ETAPA
INNER JOIN TBL_TIPO_ETAPA TE ON TE.CDA_TIPO_ETAPA = E.CEA_TIPO_ETAPA
	 WHERE qe.CEA_EMP_CADASTRO = @nCEA_EMP_CADASTRO AND qe.CEA_QUESTIONARIO= @nCEA_QUESTIONARIO
		   AND e.CEA_TURMA = @nCEA_TURMA AND QE.FL_ATIVO = 1
  ORDER BY TE.NU_ORDEM_FLUXO DESC
  
RETURN  
END  
    
--    
