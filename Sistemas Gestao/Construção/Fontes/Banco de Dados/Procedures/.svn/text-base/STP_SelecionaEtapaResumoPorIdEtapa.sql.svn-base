
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEtapaResumoPorIdEtapa
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ETAPA_RESUMO
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 17/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEtapaResumoPorIdEtapa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaEtapaResumoPorIdEtapa
(
 @nCDA_ETAPA INT
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT [CDA_ETAPA_RESUMO]
      ,[CEA_ETAPA]
      ,[TX_ACAO]
      ,[DT_ALTERACAO]
      ,[CEA_USUARIO]
  FROM [TBL_ETAPA_RESUMO]
  WHERE [CEA_ETAPA] = @nCDA_ETAPA
  
RETURN  
END  
    
--    
