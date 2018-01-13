
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaProgramaEmpresaPorId
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_TURMA
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 11/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaProgramaEmpresaPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

alter PROCEDURE [dbo].STP_SelecionaProgramaEmpresaPorId
(
 @nIdEmpresaPrograma INT,
 @nIdPrograma INT
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT
		CDA_PROGRAMA_EMPRESA,
		TX_SENHA,
		CEA_PROGRAMA,
		CEA_EMP_CADASTRO,
		TX_NOME_RESPONSAVEL,
		TX_EMAIL_RESPONSAVEL
	FROM
		TBL_PROGRAMA_EMPRESA
	WHERE CEA_EMP_CADASTRO = @nIdEmpresaPrograma
	  AND CEA_PROGRAMA = @nIdPrograma;
  
RETURN  
END  
    
--    
