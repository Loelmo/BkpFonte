
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaAdmGrupoRelUsuarioPorId
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_RELGRUPOUSUARIO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 17/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaAdmGrupoRelUsuarioPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaAdmGrupoRelUsuarioPorId
(
    @nCDA_RELGRUPOUSUARIO int
)
As    
BEGIN     

SET NOCOUNT ON  

	SELECT
		CEA_GRUPO,
		CDA_RELGRUPOUSUARIO,
		CEA_ESCRITORIO_REGIONAL,
		CEA_ESTADO,
		CEA_TURMA,
		CEA_PROGRAMA
	FROM
		TBL_ADM_RELGRUPOUSUARIO
	WHERE CDA_RELGRUPOUSUARIO = @nCDA_RELGRUPOUSUARIO;
RETURN  

END  
    
--    
