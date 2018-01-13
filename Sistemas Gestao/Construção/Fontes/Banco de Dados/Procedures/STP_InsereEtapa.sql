/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_InsereEtapa

Tabelas utilizadas......: TBL_ETAPA
Procedures utilizadas ..: 
Criada por..............: Diogo T. Machado
Data criacao............: 13/01/2011


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_InsereEtapa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_InsereEtapa
    @CDA_ETAPA int OUTPUT,
    @TX_ETAPA varchar(200),
    @CEA_TURMA int,
    @FL_ATIVO int,
    @CEA_TIPO_ETAPA int,
    @CEA_ESTADO int
As  
BEGIN   

SET NOCOUNT ON

INSERT INTO  dbo.TBL_ETAPA
        (
          TX_ETAPA,
          CEA_TURMA,
          FL_ATIVO,
          CEA_TIPO_ETAPA,
          CEA_ESTADO
        ) 
        VALUES (
          @TX_ETAPA,
          @CEA_TURMA,
          @FL_ATIVO,
          @CEA_TIPO_ETAPA,
          @CEA_ESTADO
        )
	SET @CDA_ETAPA = @@IDENTITY;
RETURN
END
 
 
