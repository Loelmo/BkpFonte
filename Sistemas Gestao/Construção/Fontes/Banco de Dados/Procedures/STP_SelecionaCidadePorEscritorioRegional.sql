
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaCidadePorEscritorioRegional
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
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaCidadePorEscritorioRegional'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaCidadePorEscritorioRegional
(
 @nIdEscritorioRegional INT
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT [CDA_CIDADE]
      ,[CEA_ESCRITORIO_REGIONAL]
      ,[CEA_ESTADO_REGIAO]
      ,[TX_CIDADE]
      ,[FL_ATIVO]
	FROM [TBL_CIDADE] C
	INNER JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL CER ON C.CDA_CIDADE = CER.CEA_CIDADE
	WHERE [CEA_ESCRITORIO_REGIONAL] = @nIdEscritorioRegional
  
RETURN  
END  
    
--    
