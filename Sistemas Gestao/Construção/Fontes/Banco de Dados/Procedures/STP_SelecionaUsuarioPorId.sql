/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaUsuarioPorId
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_USUARIO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 09/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaUsuarioPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_SelecionaUsuarioPorId
(
 @nIdUsuario int
)
As   
BEGIN     

SET NOCOUNT ON  

	SELECT
		 CDA_USUARIO,
		 TX_USUARIO,
		 TX_LOGIN,
		 TX_SENHA,
		 CEA_ESTADO,
		 FL_ATIVO,
		 TX_CPF,
		 TX_TELEFONE,
		 TX_EMAIL
	FROM TBL_ADM_USUARIO
   WHERE CDA_USUARIO = @nIdUsuario;
  
RETURN  
END  
    
--    
