/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaFaturamento
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_FATURAMENTO
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 08/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaFaturamento'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaFaturamento  
As    
BEGIN     
SET NOCOUNT ON  

SELECT [CDA_FATURAMENTO]
      ,[TX_FATURAMENTO]
      ,[TX_MENSURACAO_FATURAMENTO]
      ,[CEA_FATURAMENTO_TIPO]
  FROM [TBL_FATURAMENTO]



RETURN  
END  
    
--    
