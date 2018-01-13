
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEstadosPermitido
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ESTADO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 12/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEstadosPermitido'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaEstadosPermitido
(
 @nIdUsuario INT,
 @nIdPrograma INT
)
As    
BEGIN     
SET NOCOUNT ON  

  SELECT DISTINCT
		 te.CDA_ESTADO,
		 te.TX_SIGLA,
		 te.TX_ESTADO,
		 te.TX_STYLE,
		 te.TX_EMAIL,
		 te.FL_ATIVO,
		 tt.CDA_TURMA,
		 taf.TX_FUNCIONALIDADE
	FROM TBL_ESTADO te 
   INNER JOIN TBL_ADM_RELGRUPOUSUARIO tar ON tar.CEA_ESTADO = te.CDA_ESTADO
   INNER JOIN TBL_ADM_USUARIORELGRUPOUSUARIO tau ON tau.CEA_RELGRUPOUSUARIO = tar.CDA_RELGRUPOUSUARIO
   INNER JOIN TBL_ADM_USUARIO tau2 ON tau2.CDA_USUARIO = tau.CEA_USUARIO
   INNER JOIN TBL_TURMA tt ON tt.CDA_TURMA = tar.CEA_TURMA
   INNER JOIN TBL_PROGRAMA tp ON tp.CDA_PROGRAMA = tar.CEA_PROGRAMA
   INNER JOIN TBL_ADM_GRUPO tag ON tag.CDA_GRUPO = tar.CEA_GRUPO
   INNER JOIN TBL_ADM_RELFUNCGRUPO tar2 ON tar2.CEA_GRUPO = tag.CDA_GRUPO
   INNER JOIN TBL_ADM_FUNCIONALIDADE taf ON taf.CDA_FUNCIONALIDADE = tar2.CEA_FUNCIONALIDADE
   WHERE tau2.CDA_USUARIO = @nIdUsuario
   AND tp.CDA_PROGRAMA = @nIdPrograma
  ORDER BY te.TX_ESTADO
  
RETURN  
END  
    
--    
