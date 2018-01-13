
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEmpresaCadastroNaoInscritasPorFiltro
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_EMP_CADASTRO
Procedures utilizadas ..:   
Criada por..............: Diogo T. Machado
Data criacao............: 14/12/2011  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEmpresaCadastroNaoInscritasPorFiltro'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaEmpresaCadastroNaoInscritasPorFiltro
(
@sCpfCnpj VARCHAR(200),
@sRazaoSocial VARCHAR(200),
@nCEA_ESTADO INT,
@nCEA_TURMA INT

)
As    
BEGIN     
SET NOCOUNT ON  

SELECT
EMP.CDA_EMP_CADASTRO
,EMP.TX_RAZAO_SOCIAL
,EMP.TX_NOME_FANTASIA
,EMP.TX_CPF_CNPJ
,EMP.CEA_ESTADO
,ES.TX_ESTADO
FROM TBL_EMP_CADASTRO EMP
JOIN TBL_ESTADO ES ON ES.CDA_ESTADO = EMP.CEA_ESTADO
WHERE EMP.TX_CPF_CNPJ like '%' + @sCpfCnpj + '%'
AND EMP.TX_RAZAO_SOCIAL like '%' + @sRazaoSocial + '%'
AND EMP.CEA_ESTADO = COALESCE(@nCEA_ESTADO, EMP.CEA_ESTADO)
AND NOT EXISTS (SELECT 1 FROM TBL_TURMA_EMP TE WHERE TE.CEA_TURMA = @nCEA_TURMA AND TE.CEA_EMP_CADASTRO = EMP.CDA_EMP_CADASTRO)

RETURN  
END  
    
--    
