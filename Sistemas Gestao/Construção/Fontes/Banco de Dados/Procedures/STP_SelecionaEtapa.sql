
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEtapa
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ETAPA
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 15/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEtapa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaEtapa
As    
BEGIN     

SET NOCOUNT ON  

SELECT [CDA_ETAPA]
      ,[TX_ETAPA]
      ,[CEA_TURMA]
      ,[FL_ATIVO]
      ,[CEA_TIPO_ETAPA]
      ,[CEA_ESTADO]
  FROM [TBL_ETAPA]
  
RETURN  

END  
    
--    
