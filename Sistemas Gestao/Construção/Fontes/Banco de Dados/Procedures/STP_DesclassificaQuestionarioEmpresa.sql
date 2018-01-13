/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_DesclassificaQuestionarioEmpresa  
  
Tabelas utilizadas......: TBL_QUESTIONARIO_EMPRESA
Procedures utilizadas ..:   
Criada por..............: Robinson Campos
Data criacao............: 18/01/2011 
  
  
Ultimas alteraes:  
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   
---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_DesclassificaQuestionarioEmpresa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_DesclassificaQuestionarioEmpresa
( 
 @CDA_QUESTIONARIO_EMPRESA INT,
 @TX_MOTIVO_EXCLUIU TEXT
)
As    
BEGIN     
  
SET NOCOUNT ON  

UPDATE [TBL_QUESTIONARIO_EMPRESA]
   SET TX_MOTIVO_EXCLUIU = @TX_MOTIVO_EXCLUIU
 WHERE 
	CDA_QUESTIONARIO_EMPRESA = @CDA_QUESTIONARIO_EMPRESA
	
	
RETURN  
END