
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaTurmaQuestionarioPorTurma
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_REL_TURMA_QUESTIONARIO
Procedures utilizadas ..:   
Criada por..............: Diogo T. Machado
Data criacao............: 09/01/2011  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaTurmaQuestionarioPorTurma'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaTurmaQuestionarioPorTurma
(
 @nCEA_TURMA INT
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT QT.CEA_QUESTIONARIO
      ,QT.CEA_TURMA
      ,QT.FL_OBRIGATORIO
      ,QT.NU_ORDEM
      ,Q.TX_QUESTIONARIO
  FROM [TBL_REL_TURMA_QUESTIONARIO] QT
  INNER JOIN TBL_QUESTIONARIO Q ON Q.CDA_QUESTIONARIO = QT.CEA_QUESTIONARIO
  WHERE QT.CEA_TURMA = @nCEA_TURMA
  ORDER BY NU_ORDEM
  
RETURN  
END  
    
--    
