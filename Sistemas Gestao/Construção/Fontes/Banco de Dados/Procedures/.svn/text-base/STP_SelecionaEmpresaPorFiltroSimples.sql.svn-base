
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEmpresaPorFiltroSimples
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_EMP_CADASTRO, TBL_TURMA_EMP
Procedures utilizadas ..:   
Criada por..............: Diogo T. Machado
Data criacao............: 17/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEmpresaPorFiltroSimples'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaEmpresaPorFiltroSimples
(
@sNOME_FANTASIA VARCHAR(500),
@CEA_ESTADO INT,
@CEA_CATEGORIA INT,
@CEA_TURMA INT,
@CPF_CNPJ VARCHAR(200)

)
As    
BEGIN     
SET NOCOUNT ON  

 SELECT DISTINCT
		--TBL_EMP_CADASTRO 
		 TE.CEA_EMP_CADASTRO
        ,TE.FL_ATIVO
		,E.TX_RAZAO_SOCIAL
        ,E.TX_NOME_FANTASIA
        ,E.TX_CPF_CNPJ
        --TBL_ESTADO
        ,ES.CDA_ESTADO
        ,ES.TX_ESTADO
        --TBL_CATEGORIA
        ,TE.CEA_CATEGORIA
        ,CAT.TX_CATEGORIA
FROM TBL_EMP_CADASTRO E
JOIN TBL_TURMA_EMP TE ON TE.CEA_EMP_CADASTRO = E.CDA_EMP_CADASTRO  
LEFT JOIN TBL_ESTADO ES ON ES.CDA_ESTADO = E.CEA_ESTADO
LEFT JOIN TBL_CATEGORIA CAT ON CAT.CDA_CATEGORIA = TE.CEA_CATEGORIA
WHERE E.TX_NOME_FANTASIA like '%' + @sNOME_FANTASIA + '%'
AND ISNULL(E.CEA_ESTADO,0) = COALESCE(@CEA_ESTADO, ISNULL(E.CEA_ESTADO,0))
AND ISNULL(TE.CEA_CATEGORIA,0) = COALESCE(@CEA_CATEGORIA, ISNULL(TE.CEA_CATEGORIA,0))
AND ISNULL(TE.CEA_TURMA, 0) = COALESCE(@CEA_TURMA, ISNULL(TE.CEA_TURMA, 0))
AND E.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'
RETURN  
END  
    
--    
