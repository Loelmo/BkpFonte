/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_InsereQuestionarioEmpresaAvaliador

Tabelas utilizadas......: TBL_QUESTIONARIO_EMPRESA_AVALIADOR
Procedures utilizadas ..: 
Criada por..............: Fernando Carvalho
Data criacao............: 19/01/2011


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_InsereQuestionarioEmpresaAvaliador'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_InsereQuestionarioEmpresaAvaliador
    @nCDA_QUESTIONARIO_EMPRESA_AVALIADOR int OUTPUT,
    @nCEA_QUESTIONARIO_EMPRESA INT,
	@nCEA_USUARIO INT,
	@bFL_AVALIADO BIT,
	@sTX_MOTIVO_DEVOLUCAO VARCHAR(200),
	@sTX_MELHOR_PRATICA VARCHAR(200),
	@sTX_BANCA VARCHAR(200),
	@bFL_PRIMARIO BIT

	           
As  
BEGIN   

SET NOCOUNT ON

INSERT INTO TBL_QUESTIONARIO_EMPRESA_AVALIADOR
(
	CEA_QUESTIONARIO_EMPRESA,
	CEA_USUARIO,
	FL_AVALIADO,
	TX_MOTIVO_DEVOLUCAO,
	TX_MELHOR_PRATICA,
	TX_BANCA,
	FL_PRIMARIO
)
VALUES
(
    @nCEA_QUESTIONARIO_EMPRESA,
	@nCEA_USUARIO,
	@bFL_AVALIADO,
	@sTX_MOTIVO_DEVOLUCAO,
	@sTX_MELHOR_PRATICA,
	@sTX_BANCA,
	@bFL_PRIMARIO
)

	SET @nCDA_QUESTIONARIO_EMPRESA_AVALIADOR = @@IDENTITY;

RETURN
END
 
 
