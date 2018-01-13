/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEtapasEstadual
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ETAPA
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 27/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEtapasEstadual'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaEtapasEstadual  
(  
 @nCEA_TURMA INT,
 @nCEA_ESTADO INT,
 @nCEA_USUARIO INT 
)  
As      
BEGIN       
SET NOCOUNT ON 
   
SELECT DISTINCT
	   E.CDA_ETAPA
      ,E.TX_ETAPA
      ,E.CEA_TURMA
      ,E.FL_ATIVO
      ,E.CEA_TIPO_ETAPA
      ,E.CEA_ESTADO
      ,TE.TX_TIPO_ETAPA
  FROM TBL_ETAPA E
  INNER JOIN TBL_TIPO_ETAPA TE ON TE.CDA_TIPO_ETAPA = E.CEA_TIPO_ETAPA
  INNER JOIN TBL_TURMA tt ON tt.CDA_TURMA = E.CEA_TURMA
  INNER JOIN TBL_ADM_RELGRUPOUSUARIO tar ON tar.CEA_TURMA = tt.CDA_TURMA AND (tar.CEA_ESTADO = e.CEA_ESTADO OR tar.CEA_ESTADO IS null)
  INNER JOIN TBL_ADM_USUARIORELGRUPOUSUARIO tau ON tau.CEA_RELGRUPOUSUARIO = tar.CDA_RELGRUPOUSUARIO
    
  WHERE tt.CDA_TURMA = @nCEA_TURMA
  AND tau.CEA_USUARIO = @nCEA_USUARIO
  AND e.CEA_ESTADO = @nCEA_ESTADO
RETURN    
END