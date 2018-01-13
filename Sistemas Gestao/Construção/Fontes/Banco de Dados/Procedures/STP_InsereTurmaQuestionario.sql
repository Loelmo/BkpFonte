/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_InsereTurmaQuestionario

Tabelas utilizadas......: TBL_REL_TURMA_QUESTIONARIO
Procedures utilizadas ..: 
Criada por..............: Diogo T. Machado
Data criacao............: 10/01/2011


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_InsereTurmaQuestionario'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_InsereTurmaQuestionario
    @CEA_QUESTIONARIO int,
	@CEA_TURMA int,
	@FL_OBRIGATORIO int,
    @NU_ORDEM int
As  
BEGIN   

SET NOCOUNT ON

INSERT INTO [TBL_REL_TURMA_QUESTIONARIO]
           ([CEA_QUESTIONARIO]
           ,[CEA_TURMA]
           ,[FL_OBRIGATORIO]
           ,[NU_ORDEM])
     VALUES
           (@CEA_QUESTIONARIO
           ,@CEA_TURMA
           ,@FL_OBRIGATORIO
           ,@NU_ORDEM)
	
RETURN
END
 
 
