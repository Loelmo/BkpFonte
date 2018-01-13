
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaGrupoEmpresaPorFiltros
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_GRUPOEMPRESA
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 22/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaGrupoEmpresaPorFiltros'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaGrupoEmpresaPorFiltros
(
@sTX_GRUPO VARCHAR(200),
@nCEA_ESTADO INT,
@nCEA_SETOR INT,
@nCEA_TURMA INT,
 @bFL_ATIVO BIT,
@nCEA_USUARIO INT,
@nCEA_PROGRAMA INT
)
As    
BEGIN     
SET NOCOUNT ON  

SELECT DISTINCT 
	tg.CDA_GRUPO,
	tg.TX_GRUPO, 
	tg.FL_ATIVO,
	(SELECT COUNT(DISTINCT B.CEA_EMP_CADASTRO) FROM TBL_GRUPOEMPRESA B WHERE B.CEA_GRUPO = tg.CDA_GRUPO) AS COUNT,
	ts.CDA_SETOR,
	ts.TX_SETOR,
	tt.CDA_TURMA,
	tt.TX_CICLO,
	te2.CDA_ESTADO,
	te2.TX_ESTADO
FROM TBL_GRUPO tg
INNER JOIN TBL_TURMA tt ON tt.CDA_TURMA = tg.CEA_TURMA
INNER JOIN TBL_SETOR ts ON ts.CDA_SETOR = tg.CEA_SETOR
INNER JOIN TBL_ADM_RELGRUPOUSUARIO tar ON tar.CEA_TURMA = tt.CDA_TURMA
INNER JOIN TBL_ADM_USUARIORELGRUPOUSUARIO tau ON tau.CEA_RELGRUPOUSUARIO = tar.CDA_RELGRUPOUSUARIO

INNER JOIN TBL_ADM_USUARIO tau2 ON tau2.CDA_USUARIO = tau.CEA_USUARIO
left JOIN TBL_ESTADO te ON te.CDA_ESTADO = tar.CEA_ESTADO
inner JOIN TBL_ESTADO te2 ON te2.CDA_ESTADO = TG.CEA_ESTADO
   WHERE tau2.CDA_USUARIO = @nCEA_USUARIO
     AND tar.CEA_PROGRAMA = @nCEA_PROGRAMA
     AND (tg.CEA_ESTADO = te.CDA_ESTADO or tar.CEA_ESTADO is null)
     AND tg.TX_GRUPO like '%' + @sTX_GRUPO + '%'  
     AND ISNULL(tg.CEA_ESTADO, 0) = COALESCE(@nCEA_ESTADO, ISNULL(tg.CEA_ESTADO, 0))
     AND ISNULL(tg.CEA_SETOR, 0) = COALESCE(@nCEA_SETOR, ISNULL(tg.CEA_SETOR, 0))
     AND tg.CEA_TURMA = COALESCE(@nCEA_TURMA, tg.CEA_TURMA)
     AND tg.FL_ATIVO = @bFL_ATIVO; 

RETURN  
END  
    
--    
