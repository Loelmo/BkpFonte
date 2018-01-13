/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_VoltarEtapaDoQuestionarioEmpresa
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_QUESTIONARIO_EMPRESA
Procedures utilizadas ..:   
Criada por..............: Fabio Moraes
Data criacao............: 17/01/2011
Parmetros..............:   
    
Data  Nome   Descricao
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_VoltarEtapaDoQuestionarioEmpresa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_VoltarEtapaDoQuestionarioEmpresa
(
	@CDA_QUESTIONARIO_EMPRESA INT,
	@CDA_EMP_CADASTRO INT,
	@CEA_TIPO_ETAPA_ANTERIOR INT,
	@CEA_USUARIO INT
)
As   
BEGIN     

SET NOCOUNT ON  

--Atualiza o Questionario Atual para Inativo----------
UPDATE TBL_QUESTIONARIO_EMPRESA SET FL_ATIVO = 0, CEA_USUARIO = @CEA_USUARIO, DT_ALTERACAO = GETDATE() WHERE CDA_QUESTIONARIO_EMPRESA = @CDA_QUESTIONARIO_EMPRESA
------------------------------------------------------
----Obtem o Questionario anterior---------------------
DECLARE @CDA_QUESTIONARIO_EMPRESA_ANTERIOR INT
SET @CDA_QUESTIONARIO_EMPRESA_ANTERIOR = (SELECT QE.CDA_QUESTIONARIO_EMPRESA 
										  FROM TBL_QUESTIONARIO_EMPRESA QE
										  JOIN TBL_ETAPA E ON E.CDA_ETAPA = QE.CEA_ETAPA
										  WHERE QE.CEA_EMP_CADASTRO = @CDA_EMP_CADASTRO 
										  AND E.CEA_TIPO_ETAPA = @CEA_TIPO_ETAPA_ANTERIOR)
------------------------------------------------------
--Atualiza Questionario anterior para Não Passou para a proxima Etapa--------										  
UPDATE TBL_QUESTIONARIO_EMPRESA SET FL_PASSA_PROXIMA_ETAPA = 0, CEA_USUARIO = @CEA_USUARIO, DT_ALTERACAO = GETDATE() WHERE CDA_QUESTIONARIO_EMPRESA = @CDA_QUESTIONARIO_EMPRESA
-----------------------------------------------------------------------------

RETURN  
END  
    
--