/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaAdmFuncionalidadePorId
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_FUNCIONALIDADE
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 15/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaAdmFuncionalidadePorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_SelecionaAdmFuncionalidadePorId
(
    @nCDA_FUNCIONALIDADE int
)
As   
BEGIN     

SET NOCOUNT ON  

	SELECT
		CDA_FUNCIONALIDADE,
		CEA_TIPOFUNCIONALIDADE,
		CEA_FUNCIONALIDADE_ORIGEM,
		TX_FUNCIONALIDADE,
		TX_URL,
		TX_TABLE
	FROM
		TBL_ADM_FUNCIONALIDADE
  WHERE CDA_FUNCIONALIDADE = @nCDA_FUNCIONALIDADE
	  
RETURN  
END  
    
--    
