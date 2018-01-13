/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_DeletaAdmGrupoRelUsuarioPorId

Tabelas utilizadas......: TBL_ADM_RELGRUPOUSUARIO
Procedures utilizadas ..: 
Criada por..............: Fernando Carvalho
Data criacao............: 17/12/10

Ultimas alteracoes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alteracao de parametros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_DeletaAdmGrupoRelUsuarioPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_DeletaAdmGrupoRelUsuarioPorId
(
    @nCDA_RELGRUPOUSUARIO int
)
As  
BEGIN   

SET NOCOUNT ON
	DELETE FROM TBL_ADM_RELGRUPOUSUARIO WHERE CDA_RELGRUPOUSUARIO = @nCDA_RELGRUPOUSUARIO;
RETURN
END



GO


