
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaTurmasPermitidas
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
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaTurmasPermitidas'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaTurmasPermitidas
(
 @nIdUsuario INT,
 @nIdPrograma INT
)
As    
BEGIN     
SET NOCOUNT ON  

  SELECT DISTINCT
		 tt.CEA_PROGRAMA, 
		 tt.CDA_TURMA, 
		 tt.TX_CICLO, 
		 tt.FL_ATIVO, 
		 tt.DT_CADASTRO,
		 tt.TX_DESCRICAO, 
		 tt.CEA_ESTADO, 
		 tt.FL_PRIVADA,
		 taf.TX_FUNCIONALIDADE
    FROM TBL_TURMA tt
   INNER JOIN TBL_ADM_RELGRUPOUSUARIO tar3 ON tar3.CEA_TURMA = tt.CDA_TURMA
   INNER JOIN TBL_ADM_USUARIORELGRUPOUSUARIO tau ON tau.CEA_RELGRUPOUSUARIO = tar3.CDA_RELGRUPOUSUARIO
   INNER JOIN TBL_ADM_USUARIO tau2 ON tau2.CDA_USUARIO = tau.CEA_USUARIO
   INNER JOIN TBL_PROGRAMA tp ON tp.CDA_PROGRAMA = tar3.CEA_PROGRAMA
   INNER JOIN TBL_ADM_GRUPO tag ON tag.CDA_GRUPO = tar3.CEA_GRUPO
   INNER JOIN TBL_ADM_RELFUNCGRUPO tar4 ON tar4.CEA_GRUPO = tag.CDA_GRUPO
   INNER JOIN TBL_ADM_FUNCIONALIDADE taf ON taf.CDA_FUNCIONALIDADE = tar4.CEA_FUNCIONALIDADE
   WHERE tau2.CDA_USUARIO = @nIdUsuario
     AND tp.CDA_PROGRAMA = @nIdPrograma
  --   AND tt.FL_ATIVO = 1  
  --   and taf.TX_FUNCIONALIDADE = 'Candidatas'
  
RETURN  
END  
    
--    
