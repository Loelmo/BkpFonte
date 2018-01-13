
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaSetor
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_SETOR
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 22/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaSetor'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaSetor
As    
BEGIN     
SET NOCOUNT ON  

SELECT [CDA_SETOR]
      ,[TX_SETOR]
      ,[FL_ATIVO]
  FROM [TBL_SETOR]
  
RETURN  
END  
    
--    
