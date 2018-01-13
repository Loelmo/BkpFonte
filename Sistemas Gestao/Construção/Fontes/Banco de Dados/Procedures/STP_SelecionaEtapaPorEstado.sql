
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEtapaPorEstado
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

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEtapaPorEstado'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

  
ALTER PROCEDURE [dbo].STP_SelecionaEtapaPorEstado  
(  
@nCEA_ESTADO INT,  
@nCEA_TIPO_ETAPA INT  
)  
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
  WHERE CEA_ESTADO = @nCEA_ESTADO AND [CEA_TIPO_ETAPA] = @nCEA_TIPO_ETAPA  
    
RETURN    
  
END    
      
--      