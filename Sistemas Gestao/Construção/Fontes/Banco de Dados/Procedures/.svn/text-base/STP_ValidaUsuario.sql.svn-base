/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_ValidaUsuario
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_USUARIO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 10/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_ValidaUsuario'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

    
ALTER PROCEDURE [dbo].STP_ValidaUsuario
(
 @sLogin VARCHAR(200)
)
As   
BEGIN     
SET NOCOUNT ON  

IF (@sLogin = 'admin')
BEGIN
		SELECT
			 DISTINCT(tbu.CDA_USUARIO),  
			 tbu.TX_USUARIO,
			 tbu.TX_LOGIN,
			 tbu.TX_SENHA,
			 tbu.CEA_ESTADO,
			 tbu.FL_ATIVO,
			 tbu.TX_CPF,
			 tbu.TX_TELEFONE,
			 tbu.TX_EMAIL
		FROM TBL_ADM_USUARIO tbu
	   WHERE TX_LOGIN = @sLogin
	     AND tbu.FL_ATIVO = 1;	
	
END
ELSE
	BEGIN
		SELECT
			 DISTINCT(tbu.CDA_USUARIO),  
			 tbu.TX_USUARIO,
			 tbu.TX_LOGIN,
			 tbu.TX_SENHA,
			 tbu.CEA_ESTADO,
			 tbu.FL_ATIVO,
			 tbu.TX_CPF,
			 tbu.TX_TELEFONE,
			 tbu.TX_EMAIL
		FROM TBL_ADM_USUARIO tbu
	   INNER JOIN TBL_ADM_USUARIORELGRUPOUSUARIO tau ON tau.CEA_USUARIO = tbu.CDA_USUARIO
	   INNER JOIN TBL_ADM_RELGRUPOUSUARIO tar ON tar.CDA_RELGRUPOUSUARIO = tau.CEA_RELGRUPOUSUARIO
	   INNER JOIN TBL_TURMA tt ON tt.CDA_TURMA = tar.CEA_TURMA
	   WHERE TX_LOGIN = @sLogin;
  	END
RETURN  
END  
    
--    
