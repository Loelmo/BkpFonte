/*     
------------------------------------------------------------------------------------------     
Procedure...............: STP_ExisteAssociacao  
Funcao..................:    
    
    
Tabelas utilizadas......: STP_ExisteEscritorioRegional  
Procedures utilizadas ..:     
Criada por..............: Fernando Carvalho  
Data criacao............: 21/12/2010    
Parmetros..............:     
      
Data  Nome   Descricao     
---------- ---------------- --------------------------------------------------     
dd/mm/aaaa XXXXXXXX   Alterao de parmetros     
  
---------- ---------------- --------------------------------------------------     
*/      
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_ExisteEscritorioRegional'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_ExisteEscritorioRegional
(  
 @sTX_ESCRITORIO_REGIONAL VARCHAR(255),  
 @nCEA_ESTADO INT,  
 @nCEA_TURMA INT,  
 @nCEA_PROGRAMA INT
)  
As     
BEGIN       
  
SET NOCOUNT ON    
  
 SELECT COUNT(CDA_ESCRITORIO_REGIONAL)
   FROM TBL_ESCRITORIO_REGIONAL ER  
  INNER JOIN TBL_TURMA T ON T.CDA_TURMA = ER.CEA_TURMA  
  INNER JOIN TBL_ESTADO E ON E.CDA_ESTADO = ER.CEA_ESTADO  
  WHERE ER.CEA_ESTADO = @nCEA_ESTADO
    AND CEA_TURMA = @nCEA_TURMA
    AND T.CEA_PROGRAMA = @nCEA_PROGRAMA
    AND TX_ESCRITORIO_REGIONAL = @sTX_ESCRITORIO_REGIONAL
    
RETURN    
END    
      
--      