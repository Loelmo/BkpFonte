/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_DeletaGrupoPorId

Tabelas utilizadas......: TBL_GRUPO
Procedures utilizadas ..: 
Criada por..............: Fabio Senziani
Data criacao............: 27/12/10

Ultimas alteracoes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alteracao de parametros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_DeletaGrupoPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_DeletaGrupoPorId
(
 @nCDA_GRUPO int
)
As  
BEGIN   

SET NOCOUNT ON
	
	DELETE FROM TBL_GRUPO WHERE CDA_GRUPO = @nCDA_GRUPO;
	
RETURN
END



GO


