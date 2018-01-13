/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_InsereGrupoEmpresa

Tabelas utilizadas......: TBL_GRUPO
Procedures utilizadas ..: 
Criada por..............: Fabio Senziani
Data criacao............: 27/12/2010


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_InsereGrupoEmpresa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_InsereGrupoEmpresa
    @nCDA_GRUPO_EMPRESA int OUTPUT,
	@CEA_EMP_CADASTRO int,
	@CEA_GRUPO int
As  
BEGIN   

SET NOCOUNT ON

INSERT INTO [TBL_GRUPOEMPRESA]
           ([DT_CADASTRO]
           ,[CEA_GRUPO]
           ,[CEA_EMP_CADASTRO])
     VALUES
           (GETDATE()
           ,@CEA_GRUPO
           ,@CEA_EMP_CADASTRO)

	SET @nCDA_GRUPO_EMPRESA = @@IDENTITY;

RETURN
END
 
 
