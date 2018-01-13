/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_AtualizaTurma

Tabelas utilizadas......: TBL_TURMA
Procedures utilizadas ..: 
Criada por..............: Diogo T. Machado
Data criacao............: 10/01/2011


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtualizaTurma'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_AtualizaTurma
    @nCDA_TURMA int ,
    @CEA_PROGRAMA int,
    @CEA_ESTADO int,
	@TX_CICLO varchar(200),
	@TX_DESCRICAO varchar(254),
	@FL_PRIVADA bit  
	           
As  
BEGIN   

SET NOCOUNT ON

	UPDATE [TBL_TURMA]
	SET  CEA_PROGRAMA = @CEA_PROGRAMA ,
   		 CEA_ESTADO   = @CEA_ESTADO ,
		 TX_CICLO 	  = @TX_CICLO ,
		 TX_DESCRICAO = @TX_DESCRICAO ,
		 FL_PRIVADA   = @FL_PRIVADA   
	WHERE CDA_TURMA = @nCDA_TURMA

RETURN
END
 
 
