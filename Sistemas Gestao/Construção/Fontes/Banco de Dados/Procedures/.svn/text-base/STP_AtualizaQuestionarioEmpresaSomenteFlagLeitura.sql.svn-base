/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_AtualizaQuestionarioEmpresaSomenteFlagLeitura  
  
Tabelas utilizadas......: TBL_QUESTIONARIO_EMPRESA
Procedures utilizadas ..:   
Criada por..............: Robinson Campos
Data criacao............: 26/01/2011
  
  
Ultimas alteraes:  
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   
---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtualizaQuestionarioEmpresaSomenteFlagLeitura'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_AtualizaQuestionarioEmpresaSomenteFlagLeitura
 @nCDA_QUESTIONARIO_EMPRESA INT,  
 @bFL_LEITURA BIT  
As    
BEGIN     
  
SET NOCOUNT ON  

	UPDATE 
		TBL_QUESTIONARIO_EMPRESA 
	SET 
		FL_LEITURA = @bFL_LEITURA 
	WHERE 
		CDA_QUESTIONARIO_EMPRESA = @nCDA_QUESTIONARIO_EMPRESA  
		  
RETURN  
END  
   
   