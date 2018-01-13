/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEstadoRegiao
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ESTADO_REGIAO
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 08/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEstadoRegiao'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaEstadoRegiao  
As    
BEGIN     
SET NOCOUNT ON  

SELECT [CDA_ESTADO_REGIAO]
      ,[CEA_ESTADO]
      ,[TX_ESTADO_REGIAO]
      ,[FL_ATIVO]
FROM [TBL_ESTADO_REGIAO]

RETURN  
END  
    
--    
