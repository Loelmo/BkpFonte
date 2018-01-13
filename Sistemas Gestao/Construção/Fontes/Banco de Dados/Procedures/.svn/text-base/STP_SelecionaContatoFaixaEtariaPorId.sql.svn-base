
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaContatoFaixaEtariaPorId
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_CONTATO_FAIXA_ETARIA
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 05/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaContatoFaixaEtariaPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaContatoFaixaEtariaPorId  
(
	@nIdContatoFaixaEtaria int
)  
As  
BEGIN     
SET NOCOUNT ON  

	SELECT
		CDA_FAIXA_ETARIA,
		TX_FAIXA_ETARIA
	FROM
		TBL_CONTATO_FAIXA_ETARIA
	WHERE CDA_FAIXA_ETARIA = @nIdContatoFaixaEtaria;
  
RETURN  
END  
    
--    
