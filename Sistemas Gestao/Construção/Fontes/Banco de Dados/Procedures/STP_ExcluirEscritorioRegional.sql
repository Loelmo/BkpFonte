/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_ExcluirEscritorioRegional

Tabelas utilizadas......: TBL_ESCRITORIO_REGIONAL
Procedures utilizadas ..: 
Criada por..............: Fabio Senziani
Data criacao............: 30/12/10

Ultimas alteracoes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alteracao de parametros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_ExcluirEscritorioRegional'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_ExcluirEscritorioRegional
(
 @nCDA_ESCRITORIO_REGIONAL int
)
As  
BEGIN   

SET NOCOUNT ON
	
	UPDATE TBL_ESCRITORIO_REGIONAL SET FL_ATIVO = 0 WHERE CDA_ESCRITORIO_REGIONAL = @nCDA_ESCRITORIO_REGIONAL
	
RETURN
END



GO


