/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaTurmaEmpresaPorIdEmpresa
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_EMP_CADASTRO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 09/01/2011 
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaTurmaEmpresaPorIdEmpresa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

    
ALTER PROCEDURE [dbo].STP_SelecionaTurmaEmpresaPorIdEmpresa
(
 @nIdEmpresa INT 
)
As   
BEGIN     
SET NOCOUNT ON  

	SELECT
		CEA_EMP_CADASTRO,
		CEA_CATEGORIA,
		CEA_ATIVIDADE_ECONOMICA,
		CEA_FATURAMENTO,
		NU_FUNCIONARIO,
		TX_CEP,
		TX_ENDERECO,
		TX_COMPLEMENTO,
		FL_ATIVO,
		CEA_USUARIO,
		CEA_CIDADE,
		DT_ULTIMA_ALTERACAO,
		CEA_ESTADO,
		CEA_PAIS,
		DT_CADASTRO,
		TX_ATIVIDADE_ECONOMICA,
		FL_PARTICIPA_PROGRAMA,
		TX_NOME_CONTATO,
		TX_TELEFONE_CONTATO,
		TX_CELULAR_CONTATO,
		TX_EMAIL_CONTATO,
		TX_MENSAGEM_CONTATO,
		TX_CPF_CONTATO,
		DT_DATA_NASCIMENTO_CONTATO,
		TX_ENDERECO_CONTATO,
		TX_SEXO_CONTATO,
		CEA_NIVEL_ESCOLARIDADE,
		CEA_FAIXA_ETARIA,
		CEA_TURMA,
		CEA_TIPO_EMPRESA,
		CEA_BAIRRO,
		CEA_CARGO,
		TX_CEP_CONTATO,
		FL_PERGUNTA1,
		FL_PERGUNTA2,
		FL_PERGUNTA3,
		FL_PERGUNTA4,
		CEA_ESTADO_CONTATO,
		CEA_CIDADE_CONTATO,
		CEA_BAIRRO_CONTATO
	FROM TBL_TURMA_EMP
   WHERE CEA_EMP_CADASTRO = @nIdEmpresa;
  
RETURN  
END  
    
--    
