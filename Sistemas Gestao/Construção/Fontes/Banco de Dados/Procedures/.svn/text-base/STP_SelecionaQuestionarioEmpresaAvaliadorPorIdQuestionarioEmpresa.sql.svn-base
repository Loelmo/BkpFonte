BEGIN TRAN

/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaQuestionarioEmpresaAvaliadorPorIdQuestionarioEmpresa
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_QUESTIONARIO_EMPRESA_AVALIADOR
Procedures utilizadas ..:   
Criada por..............: Robinson Campos
Data criacao............: 18/01/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaQuestionarioEmpresaAvaliadorPorIdQuestionarioEmpresa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_SelecionaQuestionarioEmpresaAvaliadorPorIdQuestionarioEmpresa
(
 @nIdQuestionarioEmpresa int
)
As   
BEGIN     

SET NOCOUNT ON  

	SELECT TOP 1
		CDA_QUESTIONARIO_EMPRESA_AVALIADOR,
		CEA_QUESTIONARIO_EMPRESA,
		CEA_USUARIO,
		FL_AVALIADO,
		TX_MOTIVO_DEVOLUCAO,
		TX_MELHOR_PRATICA,
		TX_BANCA,
		FL_PRIMARIO
	FROM TBL_QUESTIONARIO_EMPRESA_AVALIADOR
   WHERE CEA_QUESTIONARIO_EMPRESA = @nIdQuestionarioEmpresa;
  
RETURN  
END  
    
--    


ROLLBACK