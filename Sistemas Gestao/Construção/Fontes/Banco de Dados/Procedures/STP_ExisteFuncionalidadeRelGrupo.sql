/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_ExisteFuncionalidadeRelGrupo
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_RELFUNCGRUPO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 15/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_ExisteFuncionalidadeRelGrupo'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_ExisteFuncionalidadeRelGrupo
(
    @nCEA_FUNCIONALIDADE int,
    @nCEA_GRUPO int
)
As   
BEGIN     

SET NOCOUNT ON  

	SELECT COUNT(CEA_FUNCIONALIDADE)
	FROM
		TBL_ADM_RELFUNCGRUPO
  WHERE CEA_FUNCIONALIDADE = @nCEA_FUNCIONALIDADE
	AND CEA_GRUPO = @nCEA_GRUPO		
  
RETURN  
END  
    
--    
