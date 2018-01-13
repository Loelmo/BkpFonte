
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaCidadePorNomeEstado
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
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaCidadePorNomeEstado'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaCidadePorNomeEstado
As    
BEGIN     
SET NOCOUNT ON  

	SELECT tc.CDA_CIDADE,
		   CER.CEA_ESCRITORIO_REGIONAL,
		   tc.CEA_ESTADO_REGIAO,
		   tc.TX_CIDADE,
		   tc.FL_ATIVO
	  FROM TBL_CIDADE tc 
	LEFT JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL CER ON TC.CDA_CIDADE = CER.CEA_CIDADE
	INNER JOIN TBL_ESCRITORIO_REGIONAL ER ON ER.CDA_ESCRITORIO_REGIONAL = CER.CEA_ESCRITORIO_REGIONAL
	 WHERE TC.CEA_ESTADO = @nIdEstado AND TC.TX_CIDADE = @sTX_NOME;
  
RETURN  
END  
    
--    
