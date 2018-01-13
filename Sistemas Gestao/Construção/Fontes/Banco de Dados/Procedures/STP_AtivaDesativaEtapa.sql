
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEtapaPorId
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

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtivaDesativaEtapa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_AtivaDesativaEtapa
(
@nCDA_ETAPA INT,
@bFL_ATIVO BIT
)
As    
BEGIN     

SET NOCOUNT ON  

UPDATE [TBL_ETAPA]
   SET [FL_ATIVO] = @bFL_ATIVO
  WHERE CDA_ETAPA = @nCDA_ETAPA
  
RETURN  

END  
    
--    
