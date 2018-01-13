/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEtapaResumoPorIdEstado
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ETAPA
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 16/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEtapaResumoPorIdEstado'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaEtapaResumoPorIdEstado  
(  
 @nCDA_TIPO_ETAPA INT,  
 @nIdEstado INT  
)  
As      
BEGIN       
SET NOCOUNT ON    
  
 SELECT [CDA_ETAPA_RESUMO]  
      ,[CEA_ETAPA]  
      ,[TX_ACAO]  
      ,[DT_ALTERACAO]  
      ,[CEA_USUARIO]  
  FROM [TBL_ETAPA_RESUMO] ER  
  JOIN TBL_ETAPA E ON E.CDA_ETAPA = ER.CEA_ETAPA  
  WHERE E.CEA_TIPO_ETAPA = @nCDA_TIPO_ETAPA AND E.CEA_ESTADO = @nIdEstado  
    
RETURN    
END    
      
--      