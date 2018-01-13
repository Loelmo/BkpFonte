
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaBairroPorId
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_BAIRRO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 04/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaBairroPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaBairroPorId
(
	@nIdBairro int
)  
As    
BEGIN     
SET NOCOUNT ON  

	SELECT
		CDA_BAIRRO,
		TX_BAIRRO,
		CEA_CIDADE
	FROM
		TBL_BAIRRO
	WHERE CDA_BAIRRO = @nIdBairro;
  
RETURN  
END  
    
--    
