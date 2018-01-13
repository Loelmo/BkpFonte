
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaContatoNivelEscolaridadePorId
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_CONTATO_NIVEL_ESCOLARIDADE
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 05/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaContatoNivelEscolaridadePorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaContatoNivelEscolaridadePorId
(
	@nIdContatoNivelEscolaridade int
)  
As    
BEGIN     
SET NOCOUNT ON  

	SELECT
		CDA_NIVEL_ESCOLARIDADE,
		TX_NIVEL_ESCOLARIDADE,
		NU_ORDEM
	FROM
		TBL_CONTATO_NIVEL_ESCOLARIDADE
	WHERE CDA_NIVEL_ESCOLARIDADE = @nIdContatoNivelEscolaridade;
  
RETURN  
END  
    
--    
