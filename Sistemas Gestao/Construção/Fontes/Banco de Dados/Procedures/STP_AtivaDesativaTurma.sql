
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_AtivaDesativaTurma
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_TURMA
Procedures utilizadas ..:   
Criada por..............: Diogo T. Machado
Data criacao............: 09/01/2011  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtivaDesativaTurma'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_AtivaDesativaTurma
(
@nCDA_Turma INT,
@nFL_ATIVO INT
)
As    
BEGIN     

SET NOCOUNT ON  

UPDATE [TBL_TURMA]
   SET [FL_ATIVO] = @nFL_ATIVO
  WHERE CDA_TURMA = @nCDA_TURMA
  
RETURN  

END  
    
--    
