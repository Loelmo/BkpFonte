/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_DeletaEtapaPorTurma

Tabelas utilizadas......: TBL_ETAPA
Procedures utilizadas ..: 
Criada por..............: Diogo T. Machado
Data criacao............: 13/01/11

Ultimas alteracoes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alteracao de parametros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_DeletaEtapaPorTurma'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_DeletaEtapaPorTurma
(
  @CEA_TURMA int
)
As  
BEGIN   

SET NOCOUNT ON
	
	DELETE FROM TBL_ETAPA 
    WHERE CEA_TURMA = @CEA_TURMA;
	
RETURN
END



GO


