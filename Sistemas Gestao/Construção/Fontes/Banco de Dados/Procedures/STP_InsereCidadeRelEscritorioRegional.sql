/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_InsereCidadeRelEscritorioRegional

Tabelas utilizadas......: TBL_ETAPA
Procedures utilizadas ..: 
Criada por..............: Fernando
Data criacao............: 13/01/2011


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_InsereCidadeRelEscritorioRegional'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_InsereCidadeRelEscritorioRegional
    @nCEA_CIDADE int,
    @nCEA_ESCRITORIO_REGIONAL int
As  
BEGIN   

SET NOCOUNT ON

INSERT INTO TBL_REL_CIDADE_ESCRITORIO_REGIONAL
(
	CEA_CIDADE,
	CEA_ESCRITORIO_REGIONAL
)
VALUES
(
	@nCEA_CIDADE,
	@nCEA_ESCRITORIO_REGIONAL
)

RETURN
END
 
 
