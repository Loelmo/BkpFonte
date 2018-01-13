BEGIN TRAN

/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaQuestionarioPontuacaoPorIdQuestionarioEmpresa
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_QUESTIONARIO_PONTUACAO
Procedures utilizadas ..:   
Criada por..............: Thiago Moreira
Data criacao............: 27/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaQuestionarioPontuacaoPorIdQuestionarioEmpresa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_SelecionaQuestionarioPontuacaoPorIdQuestionarioEmpresa
(
 @nIdQuestionarioEmpresa int
)
As   
BEGIN     

SET NOCOUNT ON  

	SELECT QP.[CEA_QUESTIONARIO_EMPRESA]
	  ,QP.[CEA_CRITERIO]
	  ,QP.[NU_PONTO]
	  ,QP.[CEA_QUESTIONARIO]
	  ,QP.[FL_AVALIADOR]
	FROM [TBL_QUESTIONARIO_PONTUACAO] QP
	WHERE QP.CEA_QUESTIONARIO_EMPRESA = @nIdQuestionarioEmpresa
	  
RETURN  
END  
    
--    


ROLLBACK