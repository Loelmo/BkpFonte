/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_AtualizaEscritorioRegional

Tabelas utilizadas......: TBL_ESCRITORIO_REGIONAL
Procedures utilizadas ..: 
Criada por..............: Fabio Senziani
Data criacao............: 10/12/2010


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtualizaEscritorioRegional'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_AtualizaEscritorioRegional
    @nCDA_ESCRITORIO_REGIONAL int,
	@nCEA_ESTADO INT,
	@sTX_ESCRITORIO_REGIONAL VARCHAR(200),  
	@bFL_ATIVO BIT,
	@nCEA_TURMA INT
	           
As  
BEGIN   

SET NOCOUNT ON

	UPDATE [TBL_ESCRITORIO_REGIONAL]
	SET [CEA_ESTADO] = @nCEA_ESTADO
      ,[TX_ESCRITORIO_REGIONAL] = @sTX_ESCRITORIO_REGIONAL
      ,[FL_ATIVO] = @bFL_ATIVO
      ,[CEA_TURMA] = @nCEA_TURMA
	WHERE CDA_ESCRITORIO_REGIONAL = @nCDA_ESCRITORIO_REGIONAL

RETURN
END
 
 
