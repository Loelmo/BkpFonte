/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaUsuarioAssociado
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_USUARIO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 21/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaUsuarioAssociado'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_SelecionaUsuarioAssociado
(
 @nIdGrupoUsuario int  
)
As   
BEGIN     

SET NOCOUNT ON  

 SELECT    
    tau.CDA_USUARIO CDA_USUARIO,    
    tau.TX_USUARIO TX_USUARIO,    
    tau.TX_LOGIN TX_LOGIN,    
    tau.TX_SENHA TX_SENHA,    
    tau.CEA_ESTADO CEA_ESTADO,    
    tau.FL_ATIVO FL_ATIVO,    
    tau.TX_CPF TX_CPF,    
    tau.TX_TELEFONE TX_TELEFONE,    
    tau.TX_EMAIL TX_EMAIL    
  FROM TBL_ADM_USUARIO tau  
 INNER JOIN TBL_ADM_USUARIORELGRUPOUSUARIO taug ON taug.CEA_USUARIO = tau.CDA_USUARIO
 INNER JOIN TBL_ADM_RELGRUPOUSUARIO tar ON tar.CDA_RELGRUPOUSUARIO = taug.CEA_RELGRUPOUSUARIO
 WHERE tar.CDA_RELGRUPOUSUARIO = @nIdGrupoUsuario;
  
RETURN  
END  
    
--    
