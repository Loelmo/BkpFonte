
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_ObterPermissaoBotoes  
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_USUARIO, TBL_ADM_RELGRUPOUSUARIO, TBL_ADM_GRUPO, TBL_ADM_RELFUNCGRUPO, TBL_ADM_FUNCIONALIDADE
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 07/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_ObterPermissaoBotoes'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_ObterPermissaoBotoes  
    @nIdUsuario       int,
	@sFuncionalidade  VARCHAR(200)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT tau.CDA_USUARIO, tar2.FL_INSERIR, tar2.FL_ATUALIZAR, tar2.FL_EXCLUIR
      FROM TBL_ADM_USUARIO tau
     INNER JOIN TBL_ADM_USUARIORELGRUPOUSUARIO tau2 ON tau2.CEA_USUARIO = tau.CDA_USUARIO
     INNER JOIN TBL_ADM_RELGRUPOUSUARIO tar ON tar.CDA_RELGRUPOUSUARIO = tau2.CEA_RELGRUPOUSUARIO
     INNER JOIN TBL_ADM_GRUPO tag ON tag.CDA_GRUPO = tar.CEA_GRUPO
     INNER JOIN TBL_ADM_RELFUNCGRUPO tar2 ON tar2.CEA_GRUPO = tag.CDA_GRUPO
     INNER JOIN TBL_ADM_FUNCIONALIDADE taf ON taf.CDA_FUNCIONALIDADE = tar2.CEA_FUNCIONALIDADE
     WHERE tau.CDA_USUARIO = @nIdUsuario
	   AND taf.TX_FUNCIONALIDADE = @sFuncionalidade;
  
RETURN  
END  
    
--    
