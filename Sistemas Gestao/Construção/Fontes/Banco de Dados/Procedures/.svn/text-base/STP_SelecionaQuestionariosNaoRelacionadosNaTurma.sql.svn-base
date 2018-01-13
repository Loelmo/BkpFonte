
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaQuestionariosNaoRelacionadosNaTurma
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_TURMA, TBL_REL_TURMA_QUESTIONARIO
Procedures utilizadas ..:   
Criada por..............: Diogo T. Machado
Data criacao............: 11/01/2011  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaQuestionariosNaoRelacionadosNaTurma'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaQuestionariosNaoRelacionadosNaTurma
(
 @nCEA_TURMA INT
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
		   q.DT_QUESTIONARIO
	  FROM TBL_QUESTIONARIO q
	 WHERE NOT EXISTS (SELECT CEA_QUESTIONARIO 
     					 FROM TBL_REL_TURMA_QUESTIONARIO tq
                        where CEA_TURMA = @nCEA_TURMA
                          AND CEA_QUESTIONARIO = q.CDA_QUESTIONARIO)
  
  
RETURN  
END  
    
--    
