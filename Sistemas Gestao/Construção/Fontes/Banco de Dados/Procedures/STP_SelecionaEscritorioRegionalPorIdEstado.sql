
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEscritorioRegionalPorIdEstado
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ESCRITORIO_REGIONAL
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 08/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEscritorioRegionalPorIdEstado'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaEscritorioRegionalPorIdEstado
(
 @nCEA_ESTADO INT
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT CDA_ESCRITORIO_REGIONAL
      ,CEA_ESTADO
      ,TX_ESCRITORIO_REGIONAL
      ,FL_ATIVO
      ,CEA_TURMA
	FROM TBL_ESCRITORIO_REGIONAL
	WHERE CEA_ESTADO = @nCEA_ESTADO
  
RETURN  
END  
    
--    
