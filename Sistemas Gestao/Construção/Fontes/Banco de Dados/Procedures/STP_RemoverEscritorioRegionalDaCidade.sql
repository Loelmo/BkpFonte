/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_RemoverEscritorioRegionalDaCidade  
  
Tabelas utilizadas......: TBL_CIDADE
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 13/12/2010  
  
  
Ultimas alteraes:  
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   
---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_RemoverEscritorioRegionalDaCidade'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_RemoverEscritorioRegionalDaCidade
 @nCDA_CIDADE int
 
As    
BEGIN     
  
SET NOCOUNT ON  

	UPDATE [TBL_CIDADE]
	SET [CEA_ESCRITORIO_REGIONAL] = null
	WHERE CDA_CIDADE = @nCDA_CIDADE
  
RETURN  
END  
   
   