/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_AlteraEscritorioRegionalDaCidade

Tabelas utilizadas......: TBL_CIDADE
Procedures utilizadas ..: 
Criada por..............: Fabio Senziani
Data criacao............: 30/12/10

Ultimas alteracoes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alteracao de parametros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AlteraEscritorioRegionalDaCidade'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_AlteraEscritorioRegionalDaCidade
(
 @nCDA_ESCRITORIO_REGIONAL INT
)
As  
BEGIN   

SET NOCOUNT ON
	
	UPDATE TBL_CIDADE SET CEA_ESCRITORIO_REGIONAL = null WHERE CEA_ESCRITORIO_REGIONAL = @nCDA_ESCRITORIO_REGIONAL
	
RETURN
END



GO


