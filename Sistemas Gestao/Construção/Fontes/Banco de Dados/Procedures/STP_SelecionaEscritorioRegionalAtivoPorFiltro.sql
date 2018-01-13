
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaEscritorioRegionalAtivoPorFiltro
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_ADM_RELGRUPOUSUARIO
Procedures utilizadas ..:   
Criada por..............: Autor desconhecido, pq ele nao subiu a proc no SVN
Data criacao............: desconhecido
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEscritorioRegionalAtivoPorFiltro'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO
  
alter PROCEDURE [dbo].[STP_SelecionaEscritorioRegionalAtivoPorFiltro]  
(  
 @sTX_ESCRITORIO_REGIONAL VARCHAR(255),  
 @nCEA_ESTADO INT,  
 @nCEA_TURMA INT,  
 @nCEA_PROGRAMA INT,  
 @FL_ATIVO BIT,
 @nCEA_USUARIO INT 
)  
As      
BEGIN       
SET NOCOUNT ON    
  
 SELECT DISTINCT ER.CDA_ESCRITORIO_REGIONAL  
      ,ER.CEA_ESTADO  
      ,ER.TX_ESCRITORIO_REGIONAL  
      ,ER.FL_ATIVO  
      ,ER.CEA_TURMA  
      ,T.TX_CICLO AS TX_TURMA  
      ,E.TX_ESTADO  
 FROM TBL_ESCRITORIO_REGIONAL ER  
 INNER JOIN TBL_TURMA T ON T.CDA_TURMA = ER.CEA_TURMA  
 INNER JOIN TBL_ESTADO E ON E.CDA_ESTADO = ER.CEA_ESTADO  
 INNER JOIN TBL_ADM_RELGRUPOUSUARIO tar ON (tar.CEA_TURMA = t.CDA_TURMA AND (tar.CEA_ESTADO = e.CDA_ESTADO OR tar.CEA_ESTADO IS NULL))
 INNER JOIN TBL_ADM_USUARIORELGRUPOUSUARIO tau ON tau.CEA_RELGRUPOUSUARIO = tar.CDA_RELGRUPOUSUARIO
 WHERE t.CDA_TURMA = @nCEA_TURMA
 AND T.CEA_PROGRAMA = @nCEA_PROGRAMA
 AND tau.CEA_USUARIO = @nCEA_USUARIO
 AND ISNULL(E.CDA_ESTADO, 0) = COALESCE(@nCEA_ESTADO, ISNULL(E.CDA_ESTADO, 0))
 AND (TX_ESCRITORIO_REGIONAL like '%' + @sTX_ESCRITORIO_REGIONAL + '%')  
 AND ER.FL_ATIVO = @FL_ATIVO
 ORDER BY TX_ESCRITORIO_REGIONAL  
    
RETURN    
END    
      
--      