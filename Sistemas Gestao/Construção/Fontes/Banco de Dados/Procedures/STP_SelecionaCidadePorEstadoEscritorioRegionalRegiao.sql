
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaCidadePorEstadoEscritorioRegionalRegiao
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_CIDADE
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 08/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaCidadePorEstadoEscritorioRegionalRegiao'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaCidadePorEstadoEscritorioRegionalRegiao
(
 @nIdEstado INT,
 @nIdEscritorioRegional INT,
 @nIdRegiao INT,
 @nIdTurma INT 
)
As    
BEGIN     
SET NOCOUNT ON  

 SELECT DISTINCT  
     tc.CDA_CIDADE,  
     CER.CEA_ESCRITORIO_REGIONAL,  
     tc.CEA_ESTADO_REGIAO,  
     tc.TX_CIDADE,  
     tc.FL_ATIVO,
     tc.COD_SIACWEB
   FROM TBL_CIDADE tc   
  LEFT JOIN TBL_ESTADO_REGIAO ter ON ter.CDA_ESTADO_REGIAO = tc.CEA_ESTADO_REGIAO  
  LEFT JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL CER ON TC.CDA_CIDADE = CER.CEA_CIDADE  
  LEFT JOIN TBL_ESCRITORIO_REGIONAL ter2 ON ter2.CDA_ESCRITORIO_REGIONAL = CER.CEA_ESCRITORIO_REGIONAL AND ter2.CEA_TURMA = @nIdTurma 
  LEFT JOIN TBL_ESTADO te ON te.CDA_ESTADO = ter2.CEA_ESTADO  
  WHERE te.CDA_ESTADO = @nIdEstado  
  	AND tc.FL_ATIVO = 1
 
AND ISNULL(CER.CEA_ESCRITORIO_REGIONAL, 0) = COALESCE(@nIdEscritorioRegional, ISNULL(CER.CEA_ESCRITORIO_REGIONAL, 0))
AND ISNULL(tc.CEA_ESTADO_REGIAO, 0) = COALESCE(@nIdRegiao, ISNULL(tc.CEA_ESTADO_REGIAO, 0))  
 ORDER BY tc.TX_CIDADE
  
RETURN  
END  
    
--    
