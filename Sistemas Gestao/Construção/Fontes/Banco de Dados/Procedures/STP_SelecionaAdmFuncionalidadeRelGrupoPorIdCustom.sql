/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaAdmFuncionalidadeRelGrupoPorIdCustom
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_FUNCIONALIDADE, TBL_ADM_RELFUNCGRUPO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 15/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaAdmFuncionalidadeRelGrupoPorIdCustom'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaAdmFuncionalidadeRelGrupoPorIdCustom
(
	@nIdAdmGrupo INT,
    @nIdPrograma int
)
As   
BEGIN     

SET NOCOUNT ON  

	SELECT
		taf.CDA_FUNCIONALIDADE,
		taf.TX_FUNCIONALIDADE,
		tar.CEA_GRUPO,
		COALESCE(tar.FL_INSERIR, 0) FL_INSERIR,
		COALESCE(tar.FL_ATUALIZAR, 0) FL_ATUALIZAR,
		COALESCE(tar.FL_EXCLUIR, 0) FL_EXCLUIR,
		COALESCE(tar.FL_MOSTRA_MENU, 0) FL_MOSTRA_MENU
	FROM
		TBL_ADM_FUNCIONALIDADE taf
	LEFT JOIN TBL_ADM_RELFUNCGRUPO tar 
		   ON tar.CEA_FUNCIONALIDADE = taf.CDA_FUNCIONALIDADE
		WHERE tar.CEA_GRUPO = @nIdAdmGrupo
		AND taf.CEA_PROGRAMA = @nIdPrograma
 
 UNION
 
	SELECT
		t.CDA_FUNCIONALIDADE,
		t.TX_FUNCIONALIDADE,
		0 CEA_GRUPO,
		0 FL_INSERIR,
		0 FL_ATUALIZAR,
		0 FL_EXCLUIR,
		0 FL_VISUALIZAR
	FROM
		TBL_ADM_FUNCIONALIDADE t
 	WHERE t.CEA_PROGRAMA = @nIdPrograma
 	 AND t.CDA_FUNCIONALIDADE  NOT IN ( SELECT taf.CDA_FUNCIONALIDADE  
											FROM TBL_ADM_RELFUNCGRUPO tar 
									  inner JOIN TBL_ADM_FUNCIONALIDADE taf   
											  ON taf.CDA_FUNCIONALIDADE  = tar.CEA_FUNCIONALIDADE 
										   WHERE tar.CEA_GRUPO = @nIdAdmGrupo  
										     AND taf.CEA_PROGRAMA = @nIdPrograma)		
		
		
		
	  
RETURN  
END  
    
--    
