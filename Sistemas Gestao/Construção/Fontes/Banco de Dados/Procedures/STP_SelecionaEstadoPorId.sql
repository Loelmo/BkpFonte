
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEstadoPorId
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ESTADO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 14/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEstadoPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaEstadoPorId
(
 @nIdEstado int
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT
		CDA_ESTADO,
		TX_SIGLA,
		TX_ESTADO,
		TX_STYLE,
		TX_EMAIL,
		FL_ATIVO
	FROM
		TBL_ESTADO
	WHERE CDA_ESTADO = @nIdEstado;		
  
RETURN  
END  
    
--    
