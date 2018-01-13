
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaAtividadeEconomica
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ATIVIDADE_ECONOMICA
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 05/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaAtividadeEconomica'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaAtividadeEconomica  
As    
BEGIN     
SET NOCOUNT ON  

	SELECT
		CDA_ATIVIDADE_ECONOMICA,
		TX_ATIVIDADE_ECONOMICA,
		FL_ATIVO,
		TX_SECAO,
		TX_DIVISAO,
		TX_GRUPO,
		TX_CLASSE,
		CODIGO
	FROM
		TBL_ATIVIDADE_ECONOMICA
  
RETURN  
END  
    
--    
