
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaGrupoEmpresaPorGrupo
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
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaGrupoEmpresaPorGrupo'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaGrupoEmpresaPorGrupo
(
@CDA_GRUPO INT
)
As    
BEGIN     
SET NOCOUNT ON  

SELECT DISTINCT
GE.CDA_GRUPO_EMPRESA,
GE.DT_CADASTRO,
GE.CEA_EMP_CADASTRO,
GE.CEA_GRUPO, 
GE.FL_ATIVO,
G.CDA_GRUPO, 
G.TX_GRUPO,
EC.CDA_EMP_CADASTRO,
EC.TX_CPF_CNPJ,
EC.TX_RAZAO_SOCIAL,
EC.TX_NOME_FANTASIA
FROM TBL_GRUPO G
JOIN TBL_GRUPOEMPRESA GE ON GE.CEA_GRUPO = G.CDA_GRUPO
JOIN TBL_EMP_CADASTRO EC ON EC.CDA_EMP_CADASTRO = GE.CEA_EMP_CADASTRO
WHERE 
G.CDA_GRUPO = @CDA_GRUPO

RETURN  
END  
    
--    
