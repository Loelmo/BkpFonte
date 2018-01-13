
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaSetorPorId
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

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaSetorPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaSetorPorId
(
@nCDA_SETOR INT
)
As    
BEGIN     

SET NOCOUNT ON  

SELECT [CDA_SETOR]
      ,[TX_SETOR]
      ,[FL_ATIVO]
  FROM [TBL_SETOR]
  WHERE CDA_SETOR = @nCDA_SETOR
  
RETURN  

END  
    
--    
