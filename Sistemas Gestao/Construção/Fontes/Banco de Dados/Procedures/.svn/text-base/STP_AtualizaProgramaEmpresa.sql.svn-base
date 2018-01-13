
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_AtualizaProgramaEmpresa
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_PROGRAMA_EMPRESA
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 11/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
24/01/2011 @sTX_SENHA       Remoção de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtualizaProgramaEmpresa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

alter PROCEDURE [dbo].STP_AtualizaProgramaEmpresa
(
 @nCDA_PROGRAMA_EMPRESA int,  
 @sTX_SENHA  VARCHAR(200),  
 @nCEA_PROGRAMA INT,
 @nCEA_EMP_CADASTRO INT,
 @sTX_NOME_RESPONSAVEL VARCHAR(200),  
 @sTX_EMAIL_RESPONSAVEL VARCHAR(200)
)
As    
BEGIN     
SET NOCOUNT ON  

UPDATE TBL_PROGRAMA_EMPRESA
SET
	TX_SENHA = @sTX_SENHA,
	CEA_PROGRAMA = @nCEA_PROGRAMA,
	CEA_EMP_CADASTRO = @nCEA_EMP_CADASTRO,
	TX_NOME_RESPONSAVEL = @sTX_NOME_RESPONSAVEL,
	TX_EMAIL_RESPONSAVEL = @sTX_EMAIL_RESPONSAVEL
WHERE CDA_PROGRAMA_EMPRESA = @nCDA_PROGRAMA_EMPRESA;
  
RETURN  
END  
    
--    
