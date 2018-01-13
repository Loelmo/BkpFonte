/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaAdmFuncionalidadeRelGrupo
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_RELFUNCGRUPO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 15/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaAdmFuncionalidadeRelGrupo'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_SelecionaAdmFuncionalidadeRelGrupo
As   
BEGIN     

SET NOCOUNT ON  

	SELECT
		CEA_FUNCIONALIDADE,
		CEA_GRUPO,
		FL_INSERIR,
		FL_ATUALIZAR,
		FL_EXCLUIR,
		FL_MOSTRA_MENU
	FROM
		TBL_ADM_RELFUNCGRUPO
  
RETURN  
END  
    
--    
