/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_AtualizaAdmFuncionalidadeRelGrupo

Tabelas utilizadas......: TBL_ADM_RELFUNCGRUPO
Procedures utilizadas ..: 
Criada por..............: Fernando Carvalho
Data criacao............: 15/12/2010


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtualizaAdmFuncionalidadeRelGrupo'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_AtualizaAdmFuncionalidadeRelGrupo
    @nCEA_FUNCIONALIDADE int,
    @nCEA_GRUPO int,
	@bFL_INSERIR BIT,
	@bFL_ATUALIZAR BIT,
	@bFL_EXCLUIR BIT,
	@bFL_MOSTRA_MENU BIT 
	           
As  
BEGIN   

SET NOCOUNT ON

	UPDATE TBL_ADM_RELFUNCGRUPO
	SET
		FL_INSERIR = @bFL_INSERIR,
		FL_ATUALIZAR = @bFL_ATUALIZAR,
		FL_EXCLUIR = @bFL_EXCLUIR,
		FL_MOSTRA_MENU = @bFL_MOSTRA_MENU
  WHERE CEA_FUNCIONALIDADE = @nCEA_FUNCIONALIDADE
    AND CEA_GRUPO = @nCEA_GRUPO

RETURN
END
 
 
