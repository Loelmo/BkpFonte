/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_InsereAdmGrupoRelUsuario

Tabelas utilizadas......: TBL_ADM_RELGRUPOUSUARIO
Procedures utilizadas ..: 
Criada por..............: Fernando Carvalho
Data criacao............: 17/12/2010


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_InsereAdmGrupoRelUsuario'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_InsereAdmGrupoRelUsuario
    @nCDA_RELGRUPOUSUARIO int OUTPUT,
	@nCEA_GRUPO INT,
	@nCEA_ESCRITORIO_REGIONAL INT,
	@nCEA_ESTADO INT,
	@nCEA_TURMA INT,
	@nCEA_PROGRAMA INT
As  
BEGIN   

SET NOCOUNT ON

INSERT INTO TBL_ADM_RELGRUPOUSUARIO
(
	CEA_GRUPO,
	CEA_ESCRITORIO_REGIONAL,
	CEA_ESTADO,
	CEA_TURMA,
	CEA_PROGRAMA
)
VALUES
(
	@nCEA_GRUPO,
	@nCEA_ESCRITORIO_REGIONAL,
	@nCEA_ESTADO,
	@nCEA_TURMA,
	@nCEA_PROGRAMA
)

	SET @nCDA_RELGRUPOUSUARIO = @@IDENTITY;

RETURN
END
 
 
