SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[STP_SelecionaTurmaCorrentePorIdUsuario]
(
 @nIdUsuario int
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
		TX_NUMERO,
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
		TX_NUMERO_CONTATO,
		TX_COMPLEMENTO_CONTATO,
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
		CEA_BAIRRO_CONTATO,
		STATUS
	FROM
		TBL_TURMA_EMP
	WHERE CEA_USUARIO = @nIdUsuario
	AND FL_ATIVO = 1;		
  
RETURN  
END  
    
--
