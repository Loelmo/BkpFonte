/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaAtividadeEconomicaPorFiltro
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ATIVIDADE_ECONOMICA
Procedures utilizadas ..:   
Criada por..............: Robinson Campos
Data criacao............: 14/02/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaAtividadeEconomicaPorFiltro'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaAtividadeEconomicaPorFiltro
@nCODIGO INT,
@sTX_ATIVIDADE_ECONOMICA VARCHAR(200)
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
	WHERE
		ISNULL(CODIGO, '0') LIKE '%' + COALESCE(CAST(@nCODIGO AS VARCHAR(10)), ISNULL(CAST(CODIGO AS VARCHAR(10)), '0')) + '%'
	AND	ISNULL(TX_ATIVIDADE_ECONOMICA, '0') LIKE  '%' + COALESCE(@sTX_ATIVIDADE_ECONOMICA, ISNULL(TX_ATIVIDADE_ECONOMICA, '0')) + '%'
  
RETURN  
END  
    
--    
