
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaBairroPorCidade
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_BAIRRO, TBL_CIDADE
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 04/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaBairroPorCidade'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaBairroPorCidade
(
	@nIdCidade int
)  
As    
BEGIN     
SET NOCOUNT ON  

	SELECT CDA_BAIRRO,
		   TX_BAIRRO,
		   CEA_CIDADE
	  FROM TBL_BAIRRO ta
	 INNER JOIN TBL_CIDADE tc ON tc.CDA_CIDADE = ta.CEA_CIDADE
	 WHERE tc.CDA_CIDADE = @nIdCidade;
  
RETURN  
END  
    
--    
