
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaTipoEmpresa
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_TIPO_EMP
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 04/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaTipoEmpresa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaTipoEmpresa
As    
BEGIN     
SET NOCOUNT ON  

  SELECT CDA_TIPO_EMPRESA,
		 TX_TIPO_EMPRESA
	FROM TBL_TIPO_EMP
   WHERE COD_SIACWEB IS not null
   ORDER BY NU_ORDER


  
RETURN  
END  
    
--    
