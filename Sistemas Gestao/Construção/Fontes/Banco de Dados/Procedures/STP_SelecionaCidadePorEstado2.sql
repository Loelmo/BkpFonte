
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaCidadePorEstado2
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_CIDADE
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 08/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaCidadePorEstado2'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaCidadePorEstado2
(
 @nIdEstado INT
)
As    
BEGIN     
SET NOCOUNT ON  


 SELECT tc.CDA_CIDADE,  
     tc.CEA_ESTADO_REGIAO,  
     tc.TX_CIDADE,  
     tc.FL_ATIVO
   FROM TBL_CIDADE tc   
  WHERE TC.CEA_ESTADO = @nIdEstado 
  ORDER BY TX_CIDADE;  
    
  
RETURN  
END  
    
--    
    
--      