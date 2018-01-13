
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaCargo
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_CARGO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 05/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaCargo'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaCargo  
As    
BEGIN     
SET NOCOUNT ON  

	SELECT
		CDA_CARGO,
		CODIGO,
		TX_CARGO
	FROM
		TBL_CARGO
  
RETURN  
END  
    
--    
