/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_AtivaInativaTurmaEmpresa

Tabelas utilizadas......: TBL_EMP_CADASTRO
Procedures utilizadas ..: 
Criada por..............: Fabio Moraes
Data criacao............: 12/01/2011


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtivaInativaTurmaEmpresa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_AtivaInativaTurmaEmpresa
	@bFL_ATIVO BIT,
	@nCEA_TURMA INT,
	@nCEA_EMP_CADASTRO INT
	
As  
BEGIN   

SET NOCOUNT ON

UPDATE TBL_TURMA_EMP
SET
	FL_ATIVO = @bFL_ATIVO
WHERE CEA_EMP_CADASTRO = @nCEA_EMP_CADASTRO 
AND CEA_TURMA = @nCEA_TURMA


RETURN
END
 
 
