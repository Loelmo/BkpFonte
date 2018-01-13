
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEscritoriosRegeionaisPermitidos
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ESCRITORIO_REGIONAL
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 08/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEscritoriosRegeionaisPermitidos'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaEscritoriosRegeionaisPermitidos
(
 @nIdUsuario INT,	
 @nIdPrograma INT
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT DISTINCT 
		   ter.CDA_ESCRITORIO_REGIONAL,
		   ter.CEA_ESTADO,
		   ter.TX_ESCRITORIO_REGIONAL,
		   ter.FL_ATIVO,
		   ter.CEA_TURMA,
		   taf.TX_FUNCIONALIDADE
	  FROM TBL_ESCRITORIO_REGIONAL ter	
	 INNER JOIN TBL_ADM_RELGRUPOUSUARIO tar ON tar.CEA_ESCRITORIO_REGIONAL = ter.CDA_ESCRITORIO_REGIONAL
	 INNER JOIN TBL_ADM_USUARIORELGRUPOUSUARIO tau ON tau.CEA_RELGRUPOUSUARIO = tar.CDA_RELGRUPOUSUARIO
	 INNER JOIN TBL_ADM_USUARIO tau2 ON tau2.CDA_USUARIO = tau.CEA_USUARIO
	 INNER JOIN TBL_PROGRAMA tp ON tp.CDA_PROGRAMA = tar.CEA_PROGRAMA
	 INNER JOIN TBL_ADM_GRUPO tag ON tag.CDA_GRUPO = tar.CEA_GRUPO
	 INNER JOIN TBL_ADM_RELFUNCGRUPO tar2 ON tar2.CEA_GRUPO = tag.CDA_GRUPO
	 INNER JOIN TBL_ADM_FUNCIONALIDADE taf ON taf.CDA_FUNCIONALIDADE = tar2.CEA_FUNCIONALIDADE
	 WHERE tau2.CDA_USUARIO = @nIdUsuario
	   AND tp.CDA_PROGRAMA = @nIdPrograma
	   AND ter.FL_ATIVO = 1
	ORDER BY ter.TX_ESCRITORIO_REGIONAL
   
   
  
RETURN  
END  
    
--    
