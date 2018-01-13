/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_AtualizaUsuario

Tabelas utilizadas......: TBL_ADM_USUARIO
Procedures utilizadas ..: 
Criada por..............: Fernando Carvalho
Data criacao............: 08/12/2010


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtualizaUsuario'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].[STP_AtualizaUsuario]
    @nCDA_USUARIO int,
	@sTX_USUARIO VARCHAR(200),
	@sTX_LOGIN VARCHAR(200),
	@nCEA_ESTADO INT,
	@bFL_ATIVO BIT,
	@sTX_CPF VARCHAR(11),
	@sTX_TELEFONE VARCHAR(40),
	@sTX_EMAIL VARCHAR(200)
	           
As  
BEGIN   

SET NOCOUNT ON

	UPDATE TBL_ADM_USUARIO
	SET
		TX_USUARIO = @sTX_USUARIO,
		TX_LOGIN = @sTX_LOGIN,
		CEA_ESTADO = @nCEA_ESTADO,
		FL_ATIVO = @bFL_ATIVO,
		TX_CPF = @sTX_CPF,
		TX_TELEFONE = @sTX_TELEFONE,
		TX_EMAIL = @sTX_EMAIL
  WHERE CDA_USUARIO = @nCDA_USUARIO

RETURN
END