
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

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaGrupoPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaGrupoPorId
(
@CDA_GRUPO INT
)
As    
BEGIN     

SET NOCOUNT ON  

SELECT [CDA_GRUPO]
      ,[TX_GRUPO]
      ,[FL_ATIVO]
      ,[CEA_TURMA]
      ,[CEA_ESTADO]
      ,[CEA_SETOR]
      ,TX_DESCRICAO
  FROM [TBL_GRUPO]
  WHERE [CDA_GRUPO] = @CDA_GRUPO
  
RETURN  

END  
    
--    
