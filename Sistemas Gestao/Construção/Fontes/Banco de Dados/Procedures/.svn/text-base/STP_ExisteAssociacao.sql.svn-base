/*     
------------------------------------------------------------------------------------------     
Procedure...............: STP_ExisteAssociacao  
Funcao..................:    
    
    
Tabelas utilizadas......: TBL_ADM_RELGRUPOUSUARIO  
Procedures utilizadas ..:     
Criada por..............: Fernando Carvalho  
Data criacao............: 21/12/2010    
Parmetros..............:     
      
Data  Nome   Descricao     
---------- ---------------- --------------------------------------------------     
dd/mm/aaaa XXXXXXXX   Alterao de parmetros     
  
---------- ---------------- --------------------------------------------------     
*/      
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_ExisteAssociacao'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_ExisteAssociacao
(  
 @nIdPrograma INT,  
 @nIdTurma INT,  
 @nIdEstado INT,  
 @nIdEscritorioRegional INT,
 @nIdGrupo INT 
)  
As     
BEGIN       
  
SET NOCOUNT ON    
  
SELECT  
 CEA_GRUPO,  
 CDA_RELGRUPOUSUARIO,  
 CEA_ESCRITORIO_REGIONAL,  
 CEA_ESTADO,  
 CEA_TURMA,  
 CEA_PROGRAMA  
   FROM TBL_ADM_RELGRUPOUSUARIO tar   
  WHERE tar.CEA_PROGRAMA = @nIdPrograma  
    AND tar.CEA_TURMA = @nIdTurma  
    AND tar.CEA_GRUPO = @nIdGrupo
	AND ISNULL(CEA_ESTADO, 0) = COALESCE(@nIdEstado, ISNULL(CEA_ESTADO, 0))
	AND ISNULL(CEA_ESCRITORIO_REGIONAL, 0) = COALESCE(@nIdEscritorioRegional, ISNULL(CEA_ESCRITORIO_REGIONAL, 0))    
    
RETURN    
END    
      
--      