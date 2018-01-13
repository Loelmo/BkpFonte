
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaCidade
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
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaCidade'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaCidade

BEGIN     
SET NOCOUNT ON  

	SELECT tc.CDA_CIDADE,
		   tc.CEA_ESTADO_REGIAO,
		   tc.TX_CIDADE,
		   tc.FL_ATIVO,
		   tc.COD_SIACWEB
	  FROM TBL_CIDADE tc 
  
RETURN  
END  
    
--    
