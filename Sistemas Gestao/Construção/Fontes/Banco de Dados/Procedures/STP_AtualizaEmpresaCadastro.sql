/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_AtualizaEmpresaCadastro

Tabelas utilizadas......: TBL_EMP_CADASTRO
Procedures utilizadas ..: 
Criada por..............: Fernando Carvalho
Data criacao............: 11/01/2011


ltimas alteraes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alterao de parmetros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtualizaEmpresaCadastro'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_AtualizaEmpresaCadastro
    @nCDA_EMP_CADASTRO int,
	@sTX_RAZAO_SOCIAL VARCHAR(200),
	@sTX_NOME_FANTASIA VARCHAR(200),
	@sTX_CPF_CNPJ VARCHAR(200),
	@bFL_PESSOA_JURIDICA BIT,
	@bFL_ATIVO BIT,
	@dDT_ABERTURA_EMPRESA DATETIME,
	@bFL_PARTICIPOU_MPE_2006 BIT,
	@bFL_PARTICIPOU_MPE_2007 BIT,
	@bFL_PARTICIPOU_MPE_2008 BIT,
	@bFL_PARTICIPOU_MPE_2009 BIT,
	@bFL_PARTICIPOU_MPE_2010 BIT,
	@bFL_PARTICIPOU_MPE_2011 BIT,
	@nCEA_ESTADO INT 
As  
BEGIN   

SET NOCOUNT ON

UPDATE TBL_EMP_CADASTRO
SET
	TX_RAZAO_SOCIAL = @sTX_RAZAO_SOCIAL,
	TX_NOME_FANTASIA = @sTX_NOME_FANTASIA,
	TX_CPF_CNPJ = @sTX_CPF_CNPJ,
	FL_PESSOA_JURIDICA = @bFL_PESSOA_JURIDICA,
	FL_ATIVO = @bFL_ATIVO,
	DT_ABERTURA_EMPRESA = @dDT_ABERTURA_EMPRESA,
	FL_PARTICIPOU_MPE_2006 = @bFL_PARTICIPOU_MPE_2006,
    FL_PARTICIPOU_MPE_2007 = @bFL_PARTICIPOU_MPE_2007,
	FL_PARTICIPOU_MPE_2008 = @bFL_PARTICIPOU_MPE_2008,
	FL_PARTICIPOU_MPE_2009 = @bFL_PARTICIPOU_MPE_2009,
	FL_PARTICIPOU_MPE_2010 = @bFL_PARTICIPOU_MPE_2010,
	FL_PARTICIPOU_MPE_2011 = @bFL_PARTICIPOU_MPE_2011,
	CEA_ESTADO = @nCEA_ESTADO 
WHERE CDA_EMP_CADASTRO = @nCDA_EMP_CADASTRO;

RETURN
END
 
 
