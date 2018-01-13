/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_ExisteUsuarioRelGrupoUsuario
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_RELGRUPOUSUARIO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 21/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_ExisteUsuarioRelGrupoUsuario'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_ExisteUsuarioRelGrupoUsuario
(
 @nIdGrupoUsuario INT,
 @nIdUsuario INT 
)
As   
BEGIN     

SET NOCOUNT ON  

 SELECT COUNT(CDA_USUARIORELGRUPOUSUARIO)
   FROM	TBL_ADM_USUARIORELGRUPOUSUARIO
  WHERE CEA_RELGRUPOUSUARIO = @nIdGrupoUsuario
    AND CEA_USUARIO = @nIdUsuario;
  
RETURN  
END  
    
--    
