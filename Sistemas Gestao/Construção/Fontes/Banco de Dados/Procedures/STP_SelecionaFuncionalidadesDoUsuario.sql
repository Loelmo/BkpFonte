/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaFuncionalidadesDoUsuario
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_USUARIO, TBL_ADM_USUARIORELGRUPOUSUARIO, TBL_ADM_RELGRUPOUSUARIO, TBL_ADM_GRUPO, TBL_ADM_RELFUNCGRUPO
							TBL_ADM_FUNCIONALIDADE, TBL_TURMA
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 12/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaFuncionalidadesDoUsuario'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_SelecionaFuncionalidadesDoUsuario
(
 @nIdUsuario INT,
 @nIdPrograma INT 
)
As   
BEGIN     

SET NOCOUNT ON  

	SELECT DISTINCT
		tar2.FL_INSERIR,
		tar2.FL_ATUALIZAR,
		tar2.FL_EXCLUIR,
		tar2.FL_MOSTRA_MENU,
		taf.CEA_FUNCIONALIDADE_ORIGEM,
		taf.TX_FUNCIONALIDADE,
		taf.TX_URL,
		taf.CDA_FUNCIONALIDADE,
		taf.NU_ORDEM
	FROM
		TBL_ADM_USUARIO tu 
		INNER JOIN TBL_ADM_USUARIORELGRUPOUSUARIO tau ON tau.CEA_USUARIO = tu.CDA_USUARIO
		INNER JOIN TBL_ADM_RELGRUPOUSUARIO tar ON tar.CDA_RELGRUPOUSUARIO = tau.CEA_RELGRUPOUSUARIO
		INNER JOIN TBL_ADM_GRUPO tag ON tag.CDA_GRUPO = tar.CEA_GRUPO
		INNER JOIN TBL_ADM_RELFUNCGRUPO tar2 ON tar2.CEA_GRUPO = tag.CDA_GRUPO
		INNER JOIN TBL_ADM_FUNCIONALIDADE taf ON taf.CDA_FUNCIONALIDADE = tar2.CEA_FUNCIONALIDADE
		INNER JOIN TBL_TURMA tt ON tt.CDA_TURMA = tar.CEA_TURMA
	WHERE tar2.FL_MOSTRA_MENU = 1
	AND tu.CDA_USUARIO = @nIdUsuario
	AND taf.CEA_PROGRAMA = @nIdPrograma
   ORDER BY taf.NU_ORDEM, taf.CDA_FUNCIONALIDADE;
RETURN  
END  
    
--    


