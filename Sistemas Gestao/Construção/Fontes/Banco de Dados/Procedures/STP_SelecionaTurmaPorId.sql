
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaTurmaPorId
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_TURMA
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 13/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaTurmaPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaTurmaPorId
(
 @nCDA_TURMA INT
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT [CEA_PROGRAMA]
      ,[CDA_TURMA]
      ,[TX_CICLO]
      ,[FL_ATIVO]
      ,[DT_CADASTRO]
      ,[TX_DESCRICAO]
      ,[CEA_ESTADO]
      ,[FL_PRIVADA]
  FROM [TBL_TURMA]
  WHERE [CDA_TURMA] = @nCDA_TURMA
  
RETURN  
END  
    
--    
