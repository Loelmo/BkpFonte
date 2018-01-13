/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_DeletaAdmGrupoPorId

Tabelas utilizadas......: TBL_ADM_GRUPO
Procedures utilizadas ..: 
Criada por..............: Fernando Carvalho
Data criacao............: 14/12/10

Ultimas alteracoes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alteracao de parametros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_DeletaAdmGrupoPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_DeletaAdmGrupoPorId
(
 @nCDA_GRUPO int
)
As  
BEGIN   

SET NOCOUNT ON
	
	DELETE FROM TBL_ADM_GRUPO WHERE CDA_GRUPO = @nCDA_GRUPO;
	
RETURN
END



GO


