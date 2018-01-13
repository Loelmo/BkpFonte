
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEmpresaCadastroPorFiltros
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
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEmpresaCadastroPorFiltros'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaEmpresaCadastroPorFiltros
(
@sCpfCnpj VARCHAR(200),  
@sRazaoSocial VARCHAR(200),  
@nCEA_ESTADO INT,  
@nCEA_ESCRITORIO_REGIONAL INT,  
@nCEA_CATEGORIA INT ,
@nCEA_TURMA INT 
)  
As      
BEGIN       
SET NOCOUNT ON    
  
SELECT  
CDA_EMP_CADASTRO  
,TX_RAZAO_SOCIAL  
,TX_NOME_FANTASIA  
,TX_CPF_CNPJ  
FROM TBL_EMP_CADASTRO EC  
JOIN TBL_TURMA_EMP TE ON TE.CEA_EMP_CADASTRO = EC.CDA_EMP_CADASTRO AND TE.FL_ATIVO = 1  
JOIN TBL_CIDADE C ON C.CDA_CIDADE = TE.CEA_CIDADE  
LEFT JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL CER ON CER.CEA_CIDADE = C.CDA_CIDADE  
INNER JOIN TBL_ESCRITORIO_REGIONAL ER ON ER.CDA_ESCRITORIO_REGIONAL = CER.CEA_ESCRITORIO_REGIONAL AND ER.CEA_TURMA = TE.CEA_TURMA
WHERE EC.TX_CPF_CNPJ like '%' + @sCpfCnpj + '%'  
AND EC.TX_RAZAO_SOCIAL like '%' + @sRazaoSocial + '%'  
AND ISNULL(TE.CEA_ESTADO, 0) = COALESCE(@nCEA_ESTADO, ISNULL(TE.CEA_ESTADO, 0))  
AND ISNULL(TE.CEA_CATEGORIA, 0) = COALESCE(@nCEA_CATEGORIA, ISNULL(TE.CEA_CATEGORIA, 0))  
AND ISNULL(CER.CEA_ESCRITORIO_REGIONAL, 0) = COALESCE(@nCEA_ESCRITORIO_REGIONAL, ISNULL(CER.CEA_ESCRITORIO_REGIONAL, 0))  
AND ER.CEA_TURMA = @nCEA_TURMA


RETURN  
END  
    
--    
