/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_DeletaTurmaQuestionario

Tabelas utilizadas......: TBL_REL_TURMA_QUESTIONARIO
Procedures utilizadas ..: 
Criada por..............: Diogo T. Machado
Data criacao............: 10/01/11

Ultimas alteracoes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alteracao de parametros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_DeletaTurmaQuestionario'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_DeletaTurmaQuestionario
(
 @CEA_QUESTIONARIO int,
 @CEA_TURMA int
)
As  
BEGIN   

SET NOCOUNT ON
	
	DELETE FROM TBL_REL_TURMA_QUESTIONARIO 
    WHERE CEA_QUESTIONARIO = @CEA_QUESTIONARIO
      AND CEA_TURMA = @CEA_TURMA;
	
RETURN
END



GO


