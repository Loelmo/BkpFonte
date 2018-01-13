/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaAdmFuncionalidadeRelGrupoCustom
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_FUNCIONALIDADE, TBL_ADM_RELFUNCGRUPO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 15/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaAdmFuncionalidadeRelGrupoCustom'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaAdmFuncionalidadeRelGrupoCustom
(
    @nIdPrograma int
)
As   
BEGIN     

SET NOCOUNT ON  

	SELECT
		taf.CDA_FUNCIONALIDADE,
		taf.TX_FUNCIONALIDADE,
		0 CEA_GRUPO,
		0 FL_INSERIR,
		0 FL_ATUALIZAR,
		0 FL_EXCLUIR,
		0 FL_MOSTRA_MENU
	FROM
		TBL_ADM_FUNCIONALIDADE taf
	WHERE taf.CEA_PROGRAMA = @nIdPrograma;
	  
RETURN  
END  
    
--    
