/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaQuestionarioPontuacaoPorQuestionario
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_QUESTIONARIO_PONTUACAO
Procedures utilizadas ..:   
Criada por..............: Robinson Campos
Data criacao............: 27/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaQuestionarioPontuacaoPorQuestionario'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_SelecionaQuestionarioPontuacaoPorQuestionario
(
 @nIdEmpresaCadastro int,
 @nIdTurma int,
 @nIdQuestionario int,
 @bIsAvaliador bit
)
As   
BEGIN     

SET NOCOUNT ON  

	SELECT 
		TBL_QUESTIONARIO_PONTUACAO.CEA_QUESTIONARIO_EMPRESA
		,TBL_QUESTIONARIO_PONTUACAO.CEA_CRITERIO
		,TBL_QUESTIONARIO_PONTUACAO.NU_PONTO
		,TBL_QUESTIONARIO_PONTUACAO.CEA_QUESTIONARIO
		,TBL_QUESTIONARIO_PONTUACAO.FL_AVALIADOR
	FROM TBL_TURMA
			INNER JOIN TBL_TURMA_EMP ON TBL_TURMA.CDA_TURMA = TBL_TURMA_EMP.CEA_TURMA
			INNER JOIN TBL_QUESTIONARIO_EMPRESA ON TBL_TURMA_EMP.CEA_EMP_CADASTRO = TBL_QUESTIONARIO_EMPRESA.CEA_EMP_CADASTRO
			INNER JOIN TBL_QUESTIONARIO_PONTUACAO ON TBL_QUESTIONARIO_EMPRESA.CDA_QUESTIONARIO_EMPRESA = TBL_QUESTIONARIO_PONTUACAO.CEA_QUESTIONARIO_EMPRESA
	WHERE TBL_QUESTIONARIO_PONTUACAO.CEA_QUESTIONARIO = @nIdQuestionario
	AND TBL_TURMA_EMP.CEA_EMP_CADASTRO = @nIdEmpresaCadastro
	AND TBL_TURMA.CDA_TURMA = @nIdTurma
	AND TBL_QUESTIONARIO_EMPRESA.FL_ATIVO = 1
	AND TBL_QUESTIONARIO_EMPRESA.TX_PROTOCOLO IS NOT NULL 
	AND TBL_QUESTIONARIO_PONTUACAO.FL_AVALIADOR = @bIsAvaliador
	ORDER BY [CEA_CRITERIO]
	  
RETURN  
END  
    
--    
