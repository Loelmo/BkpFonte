/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_InsereTurma

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
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_InsereTurma'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_InsereTurma
    @nCDA_TURMA int OUTPUT,
    @CEA_PROGRAMA int,
    @CEA_ESTADO int,
	@TX_CICLO varchar(200),
	@FL_ATIVO bit,
	@DT_CADASTRO datetime,
	@TX_DESCRICAO varchar(254),
	@FL_PRIVADA bit     
As  
BEGIN   

SET NOCOUNT ON

INSERT INTO  dbo.TBL_TURMA
			(
  			 CEA_PROGRAMA,
 			 TX_CICLO,
 			 FL_ATIVO,
 			 DT_CADASTRO,
 			 TX_DESCRICAO,
 			 CEA_ESTADO,
 			 FL_PRIVADA
			) 
			VALUES 
            (
 			 @CEA_PROGRAMA,
  			 @TX_CICLO,
  			 @FL_ATIVO,
 			 @DT_CADASTRO,
 			 @TX_DESCRICAO,
 			 @CEA_ESTADO,
 			 @FL_PRIVADA
			)

	SET @nCDA_TURMA = @@IDENTITY;

RETURN
END
 
 
