/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaTurmaEmpresaPorTurmas
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_EMP_CADASTRO, TBL_TURMA_EMP
Procedures utilizadas ..:   
Criada por..............: Diogo T. Machado
Data criacao............: 12/01/2011 
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaTurmaEmpresaPorTurmas'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

    
ALTER PROCEDURE [dbo].STP_SelecionaTurmaEmpresaPorTurmas
(
 @nIdTurma INT 
)
As   
BEGIN     
SET NOCOUNT ON  

	SELECT
		E.CDA_EMP_CADASTRO,
		E.TX_RAZAO_SOCIAL,
        E.FL_ATIVO FL_E_ATIVO,
        E.TX_NOME_FANTASIA,
        E.TX_CPF_CNPJ,
        E.CEA_ESTADO,
        ET.CEA_TURMA,
        ET.FL_ATIVO FL_ET_ATIVO,
        CAT.CDA_CATEGORIA,
        CAT.TX_CATEGORIA
	FROM TBL_TURMA_EMP ET
    JOIN TBL_EMP_CADASTRO E ON E.CDA_EMP_CADASTRO = ET.CEA_EMP_CADASTRO
    JOIN TBL_CATEGORIA CAT ON CAT.CDA_CATEGORIA = ET.CEA_CATEGORIA
   WHERE CEA_TURMA = @nIdTurma;
  
RETURN  
END  
    
--    
