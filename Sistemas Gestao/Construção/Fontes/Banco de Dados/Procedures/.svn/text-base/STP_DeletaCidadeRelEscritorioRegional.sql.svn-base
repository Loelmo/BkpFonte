/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_DeletaCidadeRelEscritorioRegional

Tabelas utilizadas......: TBL_GRUPO
Procedures utilizadas ..: 
Criada por..............: Fernando Carvalho
Data criacao............: 27/12/10

Ultimas alteracoes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alteracao de parametros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_DeletaCidadeRelEscritorioRegional'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

alter PROCEDURE [dbo].STP_DeletaCidadeRelEscritorioRegional
(
 @nIdEscritorioRegional INT
)
As  
BEGIN   

SET NOCOUNT ON
	
	DELETE FROM TBL_REL_CIDADE_ESCRITORIO_REGIONAL
	WHERE CEA_ESCRITORIO_REGIONAL = @nIdEscritorioRegional
	
RETURN
END



GO


