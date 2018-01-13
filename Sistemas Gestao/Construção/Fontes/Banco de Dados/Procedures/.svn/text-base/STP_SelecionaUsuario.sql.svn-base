
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaUsuario
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_USUARIO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 08/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaUsuario'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaUsuario
As    
BEGIN     

SET NOCOUNT ON  

	SELECT
		tau.CDA_USUARIO,
		tau.TX_USUARIO,
		tau.TX_LOGIN,
		tau.TX_SENHA,
		tau.CEA_ESTADO,
		tau.FL_ATIVO,
		tau.TX_CPF,
		tau.TX_TELEFONE,
		tau.TX_EMAIL,
		te.TX_ESTADO
	FROM
		TBL_ADM_USUARIO tau
		INNER JOIN TBL_ESTADO te ON tau.CEA_ESTADO = te.CDA_ESTADO
  
RETURN  

END  
    
--    
