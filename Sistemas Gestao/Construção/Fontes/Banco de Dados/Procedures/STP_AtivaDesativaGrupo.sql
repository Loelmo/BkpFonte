
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaGrupoPorId
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_GRUPO
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 27/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtivaDesativaGrupo'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_AtivaDesativaGrupo
(
@nCDA_GRUPO INT,
@bFL_ATIVO BIT
)
As    
BEGIN     

SET NOCOUNT ON  

UPDATE [TBL_GRUPO]
   SET [FL_ATIVO] = @bFL_ATIVO
  WHERE CDA_GRUPO = @nCDA_GRUPO
  
RETURN  

END  
    
--    
