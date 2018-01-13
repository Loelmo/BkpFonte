
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaGrupoPorIdTurmaEstado
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_GRUPO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 16/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaGrupoPorIdTurmaEstado'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaGrupoPorIdTurmaEstado
(
	@IdTurma INT,
	@IdEstado INT
)
As    
BEGIN     

SET NOCOUNT ON  

	SELECT CDA_GRUPO,
		   TX_GRUPO,
		   FL_ATIVO,
		   CEA_TURMA,
		   CEA_ESTADO,
		   CEA_SETOR,
		   TX_DESCRICAO
	  FROM TBL_GRUPO
	 WHERE CEA_TURMA = COALESCE(@IdTurma, CEA_TURMA)
	   AND CEA_ESTADO = COALESCE(@IdEstado, CEA_ESTADO)
	ORDER BY TX_GRUPO
RETURN  

END  
    
--    
