/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_AtualizaAdmGrupo

Tabelas utilizadas......: TBL_ADM_GRUPO
Procedures utilizadas ..: 
Criada por..............: Fernando Carvalho
Data criacao............: 14/12/2010


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtualizaAdmGrupo'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_AtualizaAdmGrupo
    @nCDA_GRUPO int,
	@sTX_GRUPO VARCHAR(200),
	@sTX_DESCRICAO VARCHAR(200)
	           
As  
BEGIN   

SET NOCOUNT ON

	UPDATE TBL_ADM_GRUPO
	SET
		TX_GRUPO = @sTX_GRUPO,
		TX_DESCRICAO = @sTX_DESCRICAO
  WHERE CDA_GRUPO = @nCDA_GRUPO

RETURN
END
 
 
