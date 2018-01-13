/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaPorIdTipoFaturamento
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_FATURAMENTO
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 08/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaPorIdTipoFaturamento'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaPorIdTipoFaturamento  
(
	@nIdTipoFaturamento INT
)
As  
BEGIN     
SET NOCOUNT ON  

SELECT
	CDA_FATURAMENTO,
	TX_FATURAMENTO,
	TX_MENSURACAO_FATURAMENTO,
	CEA_FATURAMENTO_TIPO
FROM
	TBL_FATURAMENTO tf
	INNER JOIN TBL_FATURAMENTO_TIPO tft ON tft.CDA_FATURAMENTO_TIPO = tf.CEA_FATURAMENTO_TIPO
WHERE tft.CDA_FATURAMENTO_TIPO = @nIdTipoFaturamento;



RETURN  
END  
    
--    
