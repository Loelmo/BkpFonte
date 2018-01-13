/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaNumeroParticipantesPorEtapaEstadualEscritorioRegionalMpePorFiltros
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_QUESTIONARIO_EMPRESA
Procedures utilizadas ..:   
Criada por..............: Fabio Moraes
Data criacao............: 04/02/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaNumeroParticipantesPorEtapaEstadualEscritorioRegionalMpePorFiltros'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO


ALTER PROCEDURE [dbo].STP_SelecionaNumeroParticipantesPorEtapaEstadualEscritorioRegionalMpePorFiltros
(
	@CEA_TURMA INT,
	@CEA_CATEGORIA INT,
	@CEA_ESTADO INT,

    @INSCRITAS_ADMINISTRATIVO INT,
    @INSCRITAS_EMPRESA INT,
    @CANDIDATAS INT,
    @CLASSIFICADAS INT,
    @FINALISTAS INT,
    @VENCEDORAS INT,

	@QUESTIONARIO_GESTAO INT,
	@QUESTIONARIO_RESPSOCIAL INT,
	@QUESTIOARIO_INOVACAO INT,
	
	@sNOME_FANTASIA VARCHAR(500),    
	@CEA_NIVEL_ESCOLARIDADE INT,    
	@CEA_FAIXA_ETARIA INT,    
	@CEA_CIDADE INT,    
	@CEA_ESCRITORIO_REGIONAL INT,    
	@CEA_GRUPO INT,    
	@CEA_FATURAMENTO INT,    
	@PROTOCOLO VARCHAR(200),    
	@CPF_CNPJ VARCHAR(200),    
	@CEA_ESTADO_REGIAO INT,    
	@TX_SEXO_CONTATO VARCHAR(1),    
	@DATAINICIO DATETIME,    
	@DATAFIM DATETIME,    
	@NU_FUNCIONARIOS INT,    
	@TIPO_EMPRESA INT,
	@FL_QUESTIONARIO_INOVACAO BIT,
	@FL_QUESTIONARIO_RESP_SOCIAL BIT
)
As   
BEGIN     

SET NOCOUNT ON  

SELECT CAT.CDA_CATEGORIA, CAT.TX_CATEGORIA
	 -- Inscritas
	 ,	(SELECT COUNT(DISTINCT TE.CEA_EMP_CADASTRO)  FROM  TBL_TURMA_EMP TE
		JOIN TBL_EMP_CADASTRO EMP ON EMP.CDA_EMP_CADASTRO = TE.CEA_EMP_CADASTRO
		JOIN TBL_TURMA_EMP TURMA_EMP ON TURMA_EMP.CEA_EMP_CADASTRO = EMP.CDA_EMP_CADASTRO AND TURMA_EMP.CEA_TURMA = @CEA_TURMA
		JOIN TBL_ESTADO E ON E.CDA_ESTADO = TE.CEA_ESTADO 
		LEFT JOIN TBL_ESTADO_REGIAO ESR ON ESR.CDA_ESTADO_REGIAO = E.CDA_ESTADO
		LEFT JOIN TBL_ESCRITORIO_REGIONAL ER ON ER.CEA_ESTADO = E.CDA_ESTADO
		LEFT JOIN TBL_GRUPOEMPRESA GE ON GE.CEA_EMP_CADASTRO = EMP.CDA_EMP_CADASTRO  
		JOIN TBL_TURMA T ON TE.CEA_TURMA = T.CDA_TURMA
		LEFT JOIN TBL_QUESTIONARIO_EMPRESA QE ON T.CEA_PROGRAMA = QE.CEA_PROGRAMA AND QE.CEA_EMP_CADASTRO = EMP.CDA_EMP_CADASTRO
		WHERE TURMA_EMP.CEA_ESTADO =  ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMP.CEA_ESTADO = ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMP.TX_NOME_FANTASIA like '%' + @sNOME_FANTASIA + '%'
		AND ISNULL(TE.CEA_CATEGORIA, 0) = COALESCE(@CEA_CATEGORIA, ISNULL(CAT.CDA_CATEGORIA, 0))    
		AND ISNULL(TE.CEA_NIVEL_ESCOLARIDADE, 0) = COALESCE(@CEA_NIVEL_ESCOLARIDADE, ISNULL(TE.CEA_NIVEL_ESCOLARIDADE, 0))    
		AND ISNULL(TE.CEA_FAIXA_ETARIA, 0) = COALESCE(@CEA_FAIXA_ETARIA, ISNULL(TE.CEA_FAIXA_ETARIA, 0))    
		AND ISNULL(TE.CEA_CIDADE, 0) = COALESCE(@CEA_CIDADE, ISNULL(TE.CEA_CIDADE, 0))
		AND ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0) = COALESCE(@CEA_ESCRITORIO_REGIONAL, ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0))    
		--AND ISNULL(GE.CEA_GRUPO, 0) = COALESCE(@CEA_GRUPO, ISNULL(GE.CEA_GRUPO, 0))    
		AND ISNULL(TE.CEA_FATURAMENTO, 0) = COALESCE(@CEA_FATURAMENTO, ISNULL(TE.CEA_FATURAMENTO, 0))    
		AND ISNULL(QE.TX_PROTOCOLO, '') like '%' + @PROTOCOLO + '%'    
		AND EMP.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'    
		AND ISNULL(ESR.CDA_ESTADO_REGIAO, 0) = COALESCE(@CEA_ESTADO_REGIAO, ISNULL(ESR.CDA_ESTADO_REGIAO, 0))    
		AND ISNULL(TE.TX_SEXO_CONTATO, 0) like '%' + COALESCE(@TX_SEXO_CONTATO, ISNULL(TE.TX_SEXO_CONTATO, 0)) + '%' 
		AND TE.DT_ULTIMA_ALTERACAO BETWEEN @DATAINICIO AND @DATAFIM    
		AND ISNULL(TE.NU_FUNCIONARIO, 0) = COALESCE(@NU_FUNCIONARIOS, ISNULL(TE.NU_FUNCIONARIO, 0))    
		AND ISNULL(TE.CEA_TIPO_EMPRESA, 0) = COALESCE(@TIPO_EMPRESA, ISNULL(TE.CEA_TIPO_EMPRESA, 0))
		--Possui Questionário de Responsabilidade Social----------       
		AND (@FL_QUESTIONARIO_RESP_SOCIAL = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QRESP WHERE QRESP.CEA_EMP_CADASTRO = EMP.CDA_EMP_CADASTRO AND QRESP.FL_ATIVO = 1 AND QRESP.CEA_QUESTIONARIO = @QUESTIONARIO_RESPSOCIAL), 0) ELSE 0 END
		----------------------------------------------------------
		--Possui do Questionário de Inovação------------        
		OR @FL_QUESTIONARIO_INOVACAO = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QINOVA WHERE QINOVA.CEA_EMP_CADASTRO = EMP.CDA_EMP_CADASTRO AND QINOVA.FL_ATIVO = 1 AND QINOVA.CEA_QUESTIONARIO = @QUESTIOARIO_INOVACAO), 0) ELSE 0 END)
		)		
		[TotalInscritas]
    
	 -- Candidatas
	 ,(SELECT COUNT(DISTINCT QCAN.CDA_QUESTIONARIO_EMPRESA)  FROM  TBL_QUESTIONARIO_EMPRESA QCAN
		JOIN TBL_ETAPA ETAPACAN ON ETAPACAN.CDA_ETAPA = QCAN.CEA_ETAPA
		JOIN TBL_EMP_CADASTRO EMPCAN ON EMPCAN.CDA_EMP_CADASTRO = QCAN.CEA_EMP_CADASTRO
		JOIN TBL_TURMA_EMP TECAN ON TECAN.CEA_EMP_CADASTRO = EMPCAN.CDA_EMP_CADASTRO AND TECAN.CEA_TURMA = @CEA_TURMA
		JOIN TBL_ESTADO E ON E.CDA_ESTADO = TECAN.CEA_ESTADO 
		LEFT JOIN TBL_ESTADO_REGIAO ESR ON ESR.CDA_ESTADO_REGIAO = E.CDA_ESTADO
		LEFT JOIN TBL_ESCRITORIO_REGIONAL ER ON ER.CEA_ESTADO = E.CDA_ESTADO
		LEFT JOIN TBL_GRUPOEMPRESA GE ON GE.CEA_EMP_CADASTRO = EMPCAN.CDA_EMP_CADASTRO  
		JOIN TBL_TURMA T ON TECAN.CEA_TURMA = T.CDA_TURMA
		WHERE QCAN.FL_ATIVO = 1
		AND QCAN.TX_PROTOCOLO IS NOT NULL
		AND ETAPACAN.CEA_TIPO_ETAPA = @CANDIDATAS
		AND ETAPACAN.CEA_TURMA = @CEA_TURMA
		AND TECAN.CEA_TURMA =  @CEA_TURMA
		AND QCAN.CEA_QUESTIONARIO = @QUESTIONARIO_GESTAO
		AND TECAN.CEA_ESTADO =  ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPCAN.CEA_ESTADO = ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPCAN.TX_NOME_FANTASIA like '%' + @sNOME_FANTASIA + '%'
		AND ISNULL(TECAN.CEA_CATEGORIA, 0) = COALESCE(@CEA_CATEGORIA, ISNULL(CAT.CDA_CATEGORIA, 0))    
		AND ISNULL(TECAN.CEA_NIVEL_ESCOLARIDADE, 0) = COALESCE(@CEA_NIVEL_ESCOLARIDADE, ISNULL(TECAN.CEA_NIVEL_ESCOLARIDADE, 0))    
		AND ISNULL(TECAN.CEA_FAIXA_ETARIA, 0) = COALESCE(@CEA_FAIXA_ETARIA, ISNULL(TECAN.CEA_FAIXA_ETARIA, 0))    
		AND ISNULL(TECAN.CEA_CIDADE, 0) = COALESCE(@CEA_CIDADE, ISNULL(TECAN.CEA_CIDADE, 0))
		AND ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0) = COALESCE(@CEA_ESCRITORIO_REGIONAL, ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0))    
		--AND ISNULL(GE.CEA_GRUPO, 0) = COALESCE(@CEA_GRUPO, ISNULL(GE.CEA_GRUPO, 0))    
		AND ISNULL(TECAN.CEA_FATURAMENTO, 0) = COALESCE(@CEA_FATURAMENTO, ISNULL(TECAN.CEA_FATURAMENTO, 0))    
		AND ISNULL(QCAN.TX_PROTOCOLO, '') like '%' + @PROTOCOLO + '%'    
		AND EMPCAN.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'    
		AND ISNULL(ESR.CDA_ESTADO_REGIAO, 0) = COALESCE(@CEA_ESTADO_REGIAO, ISNULL(ESR.CDA_ESTADO_REGIAO, 0))    
		AND ISNULL(TECAN.TX_SEXO_CONTATO, 0) like '%' + COALESCE(@TX_SEXO_CONTATO, ISNULL(TECAN.TX_SEXO_CONTATO, 0)) + '%'   
		AND TECAN.DT_ULTIMA_ALTERACAO BETWEEN @DATAINICIO AND @DATAFIM    
		AND ISNULL(TECAN.NU_FUNCIONARIO, 0) = COALESCE(@NU_FUNCIONARIOS, ISNULL(TECAN.NU_FUNCIONARIO, 0))    
		AND ISNULL(TECAN.CEA_TIPO_EMPRESA, 0) = COALESCE(@TIPO_EMPRESA, ISNULL(TECAN.CEA_TIPO_EMPRESA, 0))
		--Possui Questionário de Responsabilidade Social----------       
		AND (@FL_QUESTIONARIO_RESP_SOCIAL = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QRESP WHERE QRESP.CEA_EMP_CADASTRO = EMPCAN.CDA_EMP_CADASTRO AND QRESP.FL_ATIVO = 1 AND QRESP.CEA_QUESTIONARIO = @QUESTIONARIO_RESPSOCIAL), 0) ELSE 0 END
		----------------------------------------------------------
		--Possui do Questionário de Inovação------------        
		OR @FL_QUESTIONARIO_INOVACAO = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QINOVA WHERE QINOVA.CEA_EMP_CADASTRO = EMPCAN.CDA_EMP_CADASTRO AND QINOVA.FL_ATIVO = 1 AND QINOVA.CEA_QUESTIONARIO = @QUESTIOARIO_INOVACAO), 0) ELSE 0 END)
		) 
		[TotalCandidatas]
		
	 -- Classificadas
	 ,(SELECT COUNT(DISTINCT QCLA.CDA_QUESTIONARIO_EMPRESA)  FROM  TBL_QUESTIONARIO_EMPRESA QCLA
		JOIN TBL_ETAPA ETAPACLA ON ETAPACLA.CDA_ETAPA = QCLA.CEA_ETAPA
		JOIN TBL_EMP_CADASTRO EMPCLA ON EMPCLA.CDA_EMP_CADASTRO = QCLA.CEA_EMP_CADASTRO
		JOIN TBL_TURMA_EMP TECLA ON TECLA.CEA_EMP_CADASTRO = EMPCLA.CDA_EMP_CADASTRO AND TECLA.CEA_TURMA = @CEA_TURMA
		JOIN TBL_ESTADO E ON E.CDA_ESTADO = TECLA.CEA_ESTADO 
		LEFT JOIN TBL_ESTADO_REGIAO ESR ON ESR.CDA_ESTADO_REGIAO = E.CDA_ESTADO
		LEFT JOIN TBL_ESCRITORIO_REGIONAL ER ON ER.CEA_ESTADO = E.CDA_ESTADO
		LEFT JOIN TBL_GRUPOEMPRESA GE ON GE.CEA_EMP_CADASTRO = EMPCLA.CDA_EMP_CADASTRO  
		JOIN TBL_TURMA T ON TECLA.CEA_TURMA = T.CDA_TURMA
		WHERE QCLA.FL_ATIVO = 1
		AND QCLA.TX_PROTOCOLO IS NOT NULL
		AND ETAPACLA.CEA_TIPO_ETAPA = @CLASSIFICADAS
		AND ETAPACLA.CEA_TURMA = @CEA_TURMA
		AND TECLA.CEA_TURMA =  @CEA_TURMA
		AND QCLA.CEA_QUESTIONARIO = @QUESTIONARIO_GESTAO
		AND TECLA.CEA_ESTADO =  ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPCLA.CEA_ESTADO = ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPCLA.TX_NOME_FANTASIA like '%' + @sNOME_FANTASIA + '%'
		AND ISNULL(TECLA.CEA_CATEGORIA, 0) = COALESCE(@CEA_CATEGORIA, ISNULL(CAT.CDA_CATEGORIA, 0))    
		AND ISNULL(TECLA.CEA_NIVEL_ESCOLARIDADE, 0) = COALESCE(@CEA_NIVEL_ESCOLARIDADE, ISNULL(TECLA.CEA_NIVEL_ESCOLARIDADE, 0))    
		AND ISNULL(TECLA.CEA_FAIXA_ETARIA, 0) = COALESCE(@CEA_FAIXA_ETARIA, ISNULL(TECLA.CEA_FAIXA_ETARIA, 0))    
		AND ISNULL(TECLA.CEA_CIDADE, 0) = COALESCE(@CEA_CIDADE, ISNULL(TECLA.CEA_CIDADE, 0))
		AND ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0) = COALESCE(@CEA_ESCRITORIO_REGIONAL, ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0))    
		--AND ISNULL(GE.CEA_GRUPO, 0) = COALESCE(@CEA_GRUPO, ISNULL(GE.CEA_GRUPO, 0))    
		AND ISNULL(TECLA.CEA_FATURAMENTO, 0) = COALESCE(@CEA_FATURAMENTO, ISNULL(TECLA.CEA_FATURAMENTO, 0))    
		AND ISNULL(QCLA.TX_PROTOCOLO, '') like '%' + @PROTOCOLO + '%'    
		AND EMPCLA.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'    
		AND ISNULL(ESR.CDA_ESTADO_REGIAO, 0) = COALESCE(@CEA_ESTADO_REGIAO, ISNULL(ESR.CDA_ESTADO_REGIAO, 0))    
		AND ISNULL(TECLA.TX_SEXO_CONTATO, 0) like '%' + COALESCE(@TX_SEXO_CONTATO, ISNULL(TECLA.TX_SEXO_CONTATO, 0)) + '%'   
		AND TECLA.DT_ULTIMA_ALTERACAO BETWEEN @DATAINICIO AND @DATAFIM    
		AND ISNULL(TECLA.NU_FUNCIONARIO, 0) = COALESCE(@NU_FUNCIONARIOS, ISNULL(TECLA.NU_FUNCIONARIO, 0))    
		AND ISNULL(TECLA.CEA_TIPO_EMPRESA, 0) = COALESCE(@TIPO_EMPRESA, ISNULL(TECLA.CEA_TIPO_EMPRESA, 0))
		--Possui Questionário de Responsabilidade Social----------       
		AND (@FL_QUESTIONARIO_RESP_SOCIAL = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QRESP WHERE QRESP.CEA_EMP_CADASTRO = EMPCLA.CDA_EMP_CADASTRO AND QRESP.FL_ATIVO = 1 AND QRESP.CEA_QUESTIONARIO = @QUESTIONARIO_RESPSOCIAL), 0) ELSE 0 END
		----------------------------------------------------------
		--Possui do Questionário de Inovação------------        
		OR @FL_QUESTIONARIO_INOVACAO = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QINOVA WHERE QINOVA.CEA_EMP_CADASTRO = EMPCLA.CDA_EMP_CADASTRO AND QINOVA.FL_ATIVO = 1 AND QINOVA.CEA_QUESTIONARIO = @QUESTIOARIO_INOVACAO), 0) ELSE 0 END)
		) 
		[TotalClassificadas]
		
	 -- Finalistas Gestão
	 ,(SELECT COUNT(DISTINCT QFIN.CDA_QUESTIONARIO_EMPRESA)  FROM  TBL_QUESTIONARIO_EMPRESA QFIN
		JOIN TBL_ETAPA ETAPAFIN ON ETAPAFIN.CDA_ETAPA = QFIN.CEA_ETAPA
		JOIN TBL_EMP_CADASTRO EMPFIN ON EMPFIN.CDA_EMP_CADASTRO = QFIN.CEA_EMP_CADASTRO
		JOIN TBL_TURMA_EMP TEFIN ON TEFIN.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND TEFIN.CEA_TURMA = @CEA_TURMA
		JOIN TBL_ESTADO E ON E.CDA_ESTADO = TEFIN.CEA_ESTADO 
		LEFT JOIN TBL_ESTADO_REGIAO ESR ON ESR.CDA_ESTADO_REGIAO = E.CDA_ESTADO
		LEFT JOIN TBL_ESCRITORIO_REGIONAL ER ON ER.CEA_ESTADO = E.CDA_ESTADO
		LEFT JOIN TBL_GRUPOEMPRESA GE ON GE.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO  
		JOIN TBL_TURMA T ON TEFIN.CEA_TURMA = T.CDA_TURMA
		WHERE QFIN.FL_ATIVO = 1
		AND QFIN.TX_PROTOCOLO IS NOT NULL
		AND ETAPAFIN.CEA_TIPO_ETAPA = @FINALISTAS
		AND ETAPAFIN.CEA_TURMA = @CEA_TURMA
		AND TEFIN.CEA_TURMA =  @CEA_TURMA
		AND QFIN.CEA_QUESTIONARIO = @QUESTIONARIO_GESTAO
		AND TEFIN.CEA_ESTADO =  ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPFIN.CEA_ESTADO = ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPFIN.TX_NOME_FANTASIA like '%' + @sNOME_FANTASIA + '%'
		AND ISNULL(TEFIN.CEA_CATEGORIA, 0) = COALESCE(@CEA_CATEGORIA, ISNULL(CAT.CDA_CATEGORIA, 0))    
		AND ISNULL(TEFIN.CEA_NIVEL_ESCOLARIDADE, 0) = COALESCE(@CEA_NIVEL_ESCOLARIDADE, ISNULL(TEFIN.CEA_NIVEL_ESCOLARIDADE, 0))    
		AND ISNULL(TEFIN.CEA_FAIXA_ETARIA, 0) = COALESCE(@CEA_FAIXA_ETARIA, ISNULL(TEFIN.CEA_FAIXA_ETARIA, 0))    
		AND ISNULL(TEFIN.CEA_CIDADE, 0) = COALESCE(@CEA_CIDADE, ISNULL(TEFIN.CEA_CIDADE, 0))
		AND ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0) = COALESCE(@CEA_ESCRITORIO_REGIONAL, ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0))    
		--AND ISNULL(GE.CEA_GRUPO, 0) = COALESCE(@CEA_GRUPO, ISNULL(GE.CEA_GRUPO, 0))    
		AND ISNULL(TEFIN.CEA_FATURAMENTO, 0) = COALESCE(@CEA_FATURAMENTO, ISNULL(TEFIN.CEA_FATURAMENTO, 0))    
		AND ISNULL(QFIN.TX_PROTOCOLO, '') like '%' + @PROTOCOLO + '%'    
		AND EMPFIN.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'    
		AND ISNULL(ESR.CDA_ESTADO_REGIAO, 0) = COALESCE(@CEA_ESTADO_REGIAO, ISNULL(ESR.CDA_ESTADO_REGIAO, 0))    
		AND ISNULL(TEFIN.TX_SEXO_CONTATO, 0) like '%' + COALESCE(@TX_SEXO_CONTATO, ISNULL(TEFIN.TX_SEXO_CONTATO, 0)) + '%'   
		AND TEFIN.DT_ULTIMA_ALTERACAO BETWEEN @DATAINICIO AND @DATAFIM    
		AND ISNULL(TEFIN.NU_FUNCIONARIO, 0) = COALESCE(@NU_FUNCIONARIOS, ISNULL(TEFIN.NU_FUNCIONARIO, 0))    
		AND ISNULL(TEFIN.CEA_TIPO_EMPRESA, 0) = COALESCE(@TIPO_EMPRESA, ISNULL(TEFIN.CEA_TIPO_EMPRESA, 0))
		--Possui Questionário de Responsabilidade Social----------       
		AND (@FL_QUESTIONARIO_RESP_SOCIAL = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QRESP WHERE QRESP.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND QRESP.FL_ATIVO = 1 AND QRESP.CEA_QUESTIONARIO = @QUESTIONARIO_RESPSOCIAL), 0) ELSE 0 END
		----------------------------------------------------------
		--Possui do Questionário de Inovação------------        
		OR @FL_QUESTIONARIO_INOVACAO = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QINOVA WHERE QINOVA.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND QINOVA.FL_ATIVO = 1 AND QINOVA.CEA_QUESTIONARIO = @QUESTIOARIO_INOVACAO), 0) ELSE 0 END)
		)
		 [TotalFinalistasGestao]
		
	 -- Finalistas Responsabilidade Social
	 ,(SELECT COUNT(DISTINCT QFIN.CDA_QUESTIONARIO_EMPRESA)  FROM  TBL_QUESTIONARIO_EMPRESA QFIN
		JOIN TBL_ETAPA ETAPAFIN ON ETAPAFIN.CDA_ETAPA = QFIN.CEA_ETAPA
		JOIN TBL_EMP_CADASTRO EMPFIN ON EMPFIN.CDA_EMP_CADASTRO = QFIN.CEA_EMP_CADASTRO
		JOIN TBL_TURMA_EMP TEFIN ON TEFIN.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND TEFIN.CEA_TURMA = @CEA_TURMA
		JOIN TBL_ESTADO E ON E.CDA_ESTADO = TEFIN.CEA_ESTADO 
		LEFT JOIN TBL_ESTADO_REGIAO ESR ON ESR.CDA_ESTADO_REGIAO = E.CDA_ESTADO
		LEFT JOIN TBL_ESCRITORIO_REGIONAL ER ON ER.CEA_ESTADO = E.CDA_ESTADO
		LEFT JOIN TBL_GRUPOEMPRESA GE ON GE.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO  
		JOIN TBL_TURMA T ON TEFIN.CEA_TURMA = T.CDA_TURMA
		WHERE QFIN.FL_ATIVO = 1
		AND QFIN.TX_PROTOCOLO IS NOT NULL
		AND ETAPAFIN.CEA_TIPO_ETAPA = @FINALISTAS
		AND ETAPAFIN.CEA_TURMA = @CEA_TURMA
		AND TEFIN.CEA_TURMA =  @CEA_TURMA
		AND QFIN.CEA_QUESTIONARIO = @QUESTIONARIO_RESPSOCIAL
		AND TEFIN.CEA_ESTADO =  ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPFIN.CEA_ESTADO = ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPFIN.TX_NOME_FANTASIA like '%' + @sNOME_FANTASIA + '%'
		AND ISNULL(TEFIN.CEA_CATEGORIA, 0) = COALESCE(@CEA_CATEGORIA, ISNULL(CAT.CDA_CATEGORIA, 0))    
		AND ISNULL(TEFIN.CEA_NIVEL_ESCOLARIDADE, 0) = COALESCE(@CEA_NIVEL_ESCOLARIDADE, ISNULL(TEFIN.CEA_NIVEL_ESCOLARIDADE, 0))    
		AND ISNULL(TEFIN.CEA_FAIXA_ETARIA, 0) = COALESCE(@CEA_FAIXA_ETARIA, ISNULL(TEFIN.CEA_FAIXA_ETARIA, 0))    
		AND ISNULL(TEFIN.CEA_CIDADE, 0) = COALESCE(@CEA_CIDADE, ISNULL(TEFIN.CEA_CIDADE, 0))
		AND ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0) = COALESCE(@CEA_ESCRITORIO_REGIONAL, ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0))    
		--AND ISNULL(GE.CEA_GRUPO, 0) = COALESCE(@CEA_GRUPO, ISNULL(GE.CEA_GRUPO, 0))    
		AND ISNULL(TEFIN.CEA_FATURAMENTO, 0) = COALESCE(@CEA_FATURAMENTO, ISNULL(TEFIN.CEA_FATURAMENTO, 0))    
		AND ISNULL(QFIN.TX_PROTOCOLO, '') like '%' + @PROTOCOLO + '%'    
		AND EMPFIN.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'    
		AND ISNULL(ESR.CDA_ESTADO_REGIAO, 0) = COALESCE(@CEA_ESTADO_REGIAO, ISNULL(ESR.CDA_ESTADO_REGIAO, 0))    
		AND ISNULL(TEFIN.TX_SEXO_CONTATO, 0) like '%' + COALESCE(@TX_SEXO_CONTATO, ISNULL(TEFIN.TX_SEXO_CONTATO, 0)) + '%'   
		AND TEFIN.DT_ULTIMA_ALTERACAO BETWEEN @DATAINICIO AND @DATAFIM    
		AND ISNULL(TEFIN.NU_FUNCIONARIO, 0) = COALESCE(@NU_FUNCIONARIOS, ISNULL(TEFIN.NU_FUNCIONARIO, 0))    
		AND ISNULL(TEFIN.CEA_TIPO_EMPRESA, 0) = COALESCE(@TIPO_EMPRESA, ISNULL(TEFIN.CEA_TIPO_EMPRESA, 0))
		--Possui Questionário de Responsabilidade Social----------       
		AND (@FL_QUESTIONARIO_RESP_SOCIAL = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QRESP WHERE QRESP.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND QRESP.FL_ATIVO = 1 AND QRESP.CEA_QUESTIONARIO = @QUESTIONARIO_RESPSOCIAL), 0) ELSE 0 END
		----------------------------------------------------------
		--Possui do Questionário de Inovação------------        
		OR @FL_QUESTIONARIO_INOVACAO = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QINOVA WHERE QINOVA.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND QINOVA.FL_ATIVO = 1 AND QINOVA.CEA_QUESTIONARIO = @QUESTIOARIO_INOVACAO), 0) ELSE 0 END)
		) 
		[TotalFinalistasRespSocial]
		
	 -- Finalistas Inovação
	 ,(SELECT COUNT(DISTINCT QFIN.CDA_QUESTIONARIO_EMPRESA)  FROM  TBL_QUESTIONARIO_EMPRESA QFIN
		JOIN TBL_ETAPA ETAPAFIN ON ETAPAFIN.CDA_ETAPA = QFIN.CEA_ETAPA
		JOIN TBL_EMP_CADASTRO EMPFIN ON EMPFIN.CDA_EMP_CADASTRO = QFIN.CEA_EMP_CADASTRO
		JOIN TBL_TURMA_EMP TEFIN ON TEFIN.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND TEFIN.CEA_TURMA = @CEA_TURMA
		JOIN TBL_ESTADO E ON E.CDA_ESTADO = TEFIN.CEA_ESTADO 
		LEFT JOIN TBL_ESTADO_REGIAO ESR ON ESR.CDA_ESTADO_REGIAO = E.CDA_ESTADO
		LEFT JOIN TBL_ESCRITORIO_REGIONAL ER ON ER.CEA_ESTADO = E.CDA_ESTADO
		LEFT JOIN TBL_GRUPOEMPRESA GE ON GE.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO  
		JOIN TBL_TURMA T ON TEFIN.CEA_TURMA = T.CDA_TURMA
		WHERE QFIN.FL_ATIVO = 1
		AND QFIN.TX_PROTOCOLO IS NOT NULL
		AND ETAPAFIN.CEA_TIPO_ETAPA = @FINALISTAS
		AND ETAPAFIN.CEA_TURMA = @CEA_TURMA
		AND TEFIN.CEA_TURMA =  @CEA_TURMA
		AND QFIN.CEA_QUESTIONARIO = @QUESTIOARIO_INOVACAO
		AND TEFIN.CEA_ESTADO =  ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPFIN.CEA_ESTADO = ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPFIN.TX_NOME_FANTASIA like '%' + @sNOME_FANTASIA + '%'
		AND ISNULL(TEFIN.CEA_CATEGORIA, 0) = COALESCE(@CEA_CATEGORIA, ISNULL(CAT.CDA_CATEGORIA, 0))    
		AND ISNULL(TEFIN.CEA_NIVEL_ESCOLARIDADE, 0) = COALESCE(@CEA_NIVEL_ESCOLARIDADE, ISNULL(TEFIN.CEA_NIVEL_ESCOLARIDADE, 0))    
		AND ISNULL(TEFIN.CEA_FAIXA_ETARIA, 0) = COALESCE(@CEA_FAIXA_ETARIA, ISNULL(TEFIN.CEA_FAIXA_ETARIA, 0))    
		AND ISNULL(TEFIN.CEA_CIDADE, 0) = COALESCE(@CEA_CIDADE, ISNULL(TEFIN.CEA_CIDADE, 0))
		AND ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0) = COALESCE(@CEA_ESCRITORIO_REGIONAL, ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0))    
		--AND ISNULL(GE.CEA_GRUPO, 0) = COALESCE(@CEA_GRUPO, ISNULL(GE.CEA_GRUPO, 0))    
		AND ISNULL(TEFIN.CEA_FATURAMENTO, 0) = COALESCE(@CEA_FATURAMENTO, ISNULL(TEFIN.CEA_FATURAMENTO, 0))    
		AND ISNULL(QFIN.TX_PROTOCOLO, '') like '%' + @PROTOCOLO + '%'    
		AND EMPFIN.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'    
		AND ISNULL(ESR.CDA_ESTADO_REGIAO, 0) = COALESCE(@CEA_ESTADO_REGIAO, ISNULL(ESR.CDA_ESTADO_REGIAO, 0))    
		AND ISNULL(TEFIN.TX_SEXO_CONTATO, 0) like '%' + COALESCE(@TX_SEXO_CONTATO, ISNULL(TEFIN.TX_SEXO_CONTATO, 0)) + '%'   
		AND TEFIN.DT_ULTIMA_ALTERACAO BETWEEN @DATAINICIO AND @DATAFIM    
		AND ISNULL(TEFIN.NU_FUNCIONARIO, 0) = COALESCE(@NU_FUNCIONARIOS, ISNULL(TEFIN.NU_FUNCIONARIO, 0))    
		AND ISNULL(TEFIN.CEA_TIPO_EMPRESA, 0) = COALESCE(@TIPO_EMPRESA, ISNULL(TEFIN.CEA_TIPO_EMPRESA, 0))
		--Possui Questionário de Responsabilidade Social----------       
		AND (@FL_QUESTIONARIO_RESP_SOCIAL = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QRESP WHERE QRESP.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND QRESP.FL_ATIVO = 1 AND QRESP.CEA_QUESTIONARIO = @QUESTIONARIO_RESPSOCIAL), 0) ELSE 0 END
		----------------------------------------------------------
		--Possui do Questionário de Inovação------------        
		OR @FL_QUESTIONARIO_INOVACAO = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QINOVA WHERE QINOVA.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND QINOVA.FL_ATIVO = 1 AND QINOVA.CEA_QUESTIONARIO = @QUESTIOARIO_INOVACAO), 0) ELSE 0 END)
		) 
		[TotalFinalistasInovacao]	
		
	 -- Vencedora Gestão
	 ,(SELECT COUNT(DISTINCT QFIN.CDA_QUESTIONARIO_EMPRESA)  FROM  TBL_QUESTIONARIO_EMPRESA QFIN
		JOIN TBL_ETAPA ETAPAFIN ON ETAPAFIN.CDA_ETAPA = QFIN.CEA_ETAPA
		JOIN TBL_EMP_CADASTRO EMPFIN ON EMPFIN.CDA_EMP_CADASTRO = QFIN.CEA_EMP_CADASTRO
		JOIN TBL_TURMA_EMP TEFIN ON TEFIN.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND TEFIN.CEA_TURMA = @CEA_TURMA
		JOIN TBL_ESTADO E ON E.CDA_ESTADO = TEFIN.CEA_ESTADO 
		LEFT JOIN TBL_ESTADO_REGIAO ESR ON ESR.CDA_ESTADO_REGIAO = E.CDA_ESTADO
		LEFT JOIN TBL_ESCRITORIO_REGIONAL ER ON ER.CEA_ESTADO = E.CDA_ESTADO
		LEFT JOIN TBL_GRUPOEMPRESA GE ON GE.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO  
		JOIN TBL_TURMA T ON TEFIN.CEA_TURMA = T.CDA_TURMA
		WHERE QFIN.FL_ATIVO = 1
		AND QFIN.TX_PROTOCOLO IS NOT NULL
		AND ETAPAFIN.CEA_TIPO_ETAPA = @VENCEDORAS
		AND ETAPAFIN.CEA_TURMA = @CEA_TURMA
		AND TEFIN.CEA_TURMA =  @CEA_TURMA
		AND QFIN.CEA_QUESTIONARIO = @QUESTIONARIO_GESTAO
		AND TEFIN.CEA_ESTADO =  ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPFIN.CEA_ESTADO = ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPFIN.TX_NOME_FANTASIA like '%' + @sNOME_FANTASIA + '%'
		AND ISNULL(TEFIN.CEA_CATEGORIA, 0) = COALESCE(@CEA_CATEGORIA, ISNULL(CAT.CDA_CATEGORIA, 0))    
		AND ISNULL(TEFIN.CEA_NIVEL_ESCOLARIDADE, 0) = COALESCE(@CEA_NIVEL_ESCOLARIDADE, ISNULL(TEFIN.CEA_NIVEL_ESCOLARIDADE, 0))    
		AND ISNULL(TEFIN.CEA_FAIXA_ETARIA, 0) = COALESCE(@CEA_FAIXA_ETARIA, ISNULL(TEFIN.CEA_FAIXA_ETARIA, 0))    
		AND ISNULL(TEFIN.CEA_CIDADE, 0) = COALESCE(@CEA_CIDADE, ISNULL(TEFIN.CEA_CIDADE, 0))
		AND ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0) = COALESCE(@CEA_ESCRITORIO_REGIONAL, ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0))    
		--AND ISNULL(GE.CEA_GRUPO, 0) = COALESCE(@CEA_GRUPO, ISNULL(GE.CEA_GRUPO, 0))    
		AND ISNULL(TEFIN.CEA_FATURAMENTO, 0) = COALESCE(@CEA_FATURAMENTO, ISNULL(TEFIN.CEA_FATURAMENTO, 0))    
		AND ISNULL(QFIN.TX_PROTOCOLO, '') like '%' + @PROTOCOLO + '%'    
		AND EMPFIN.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'    
		AND ISNULL(ESR.CDA_ESTADO_REGIAO, 0) = COALESCE(@CEA_ESTADO_REGIAO, ISNULL(ESR.CDA_ESTADO_REGIAO, 0))    
		AND ISNULL(TEFIN.TX_SEXO_CONTATO, 0) like '%' + COALESCE(@TX_SEXO_CONTATO, ISNULL(TEFIN.TX_SEXO_CONTATO, 0)) + '%'   
		AND TEFIN.DT_ULTIMA_ALTERACAO BETWEEN @DATAINICIO AND @DATAFIM    
		AND ISNULL(TEFIN.NU_FUNCIONARIO, 0) = COALESCE(@NU_FUNCIONARIOS, ISNULL(TEFIN.NU_FUNCIONARIO, 0))    
		AND ISNULL(TEFIN.CEA_TIPO_EMPRESA, 0) = COALESCE(@TIPO_EMPRESA, ISNULL(TEFIN.CEA_TIPO_EMPRESA, 0))
		--Possui Questionário de Responsabilidade Social----------       
		AND (@FL_QUESTIONARIO_RESP_SOCIAL = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QRESP WHERE QRESP.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND QRESP.FL_ATIVO = 1 AND QRESP.CEA_QUESTIONARIO = @QUESTIONARIO_RESPSOCIAL), 0) ELSE 0 END
		----------------------------------------------------------
		--Possui do Questionário de Inovação------------        
		OR @FL_QUESTIONARIO_INOVACAO = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QINOVA WHERE QINOVA.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND QINOVA.FL_ATIVO = 1 AND QINOVA.CEA_QUESTIONARIO = @QUESTIOARIO_INOVACAO), 0) ELSE 0 END)
		)
		 [TotalVencedoraGestao]
		
	 -- Vencedora Responsabilidade Social
	 ,(SELECT COUNT(DISTINCT QFIN.CDA_QUESTIONARIO_EMPRESA)  FROM  TBL_QUESTIONARIO_EMPRESA QFIN
		JOIN TBL_ETAPA ETAPAFIN ON ETAPAFIN.CDA_ETAPA = QFIN.CEA_ETAPA
		JOIN TBL_EMP_CADASTRO EMPFIN ON EMPFIN.CDA_EMP_CADASTRO = QFIN.CEA_EMP_CADASTRO
		JOIN TBL_TURMA_EMP TEFIN ON TEFIN.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND TEFIN.CEA_TURMA = @CEA_TURMA
		JOIN TBL_ESTADO E ON E.CDA_ESTADO = TEFIN.CEA_ESTADO 
		LEFT JOIN TBL_ESTADO_REGIAO ESR ON ESR.CDA_ESTADO_REGIAO = E.CDA_ESTADO
		LEFT JOIN TBL_ESCRITORIO_REGIONAL ER ON ER.CEA_ESTADO = E.CDA_ESTADO
		LEFT JOIN TBL_GRUPOEMPRESA GE ON GE.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO  
		JOIN TBL_TURMA T ON TEFIN.CEA_TURMA = T.CDA_TURMA
		WHERE QFIN.FL_ATIVO = 1
		AND QFIN.TX_PROTOCOLO IS NOT NULL
		AND ETAPAFIN.CEA_TIPO_ETAPA = @VENCEDORAS
		AND ETAPAFIN.CEA_TURMA = @CEA_TURMA
		AND TEFIN.CEA_TURMA =  @CEA_TURMA
		AND QFIN.CEA_QUESTIONARIO = @QUESTIONARIO_RESPSOCIAL
		AND TEFIN.CEA_ESTADO =  ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPFIN.CEA_ESTADO = ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPFIN.TX_NOME_FANTASIA like '%' + @sNOME_FANTASIA + '%'
		AND ISNULL(TEFIN.CEA_CATEGORIA, 0) = COALESCE(@CEA_CATEGORIA, ISNULL(CAT.CDA_CATEGORIA, 0))    
		AND ISNULL(TEFIN.CEA_NIVEL_ESCOLARIDADE, 0) = COALESCE(@CEA_NIVEL_ESCOLARIDADE, ISNULL(TEFIN.CEA_NIVEL_ESCOLARIDADE, 0))    
		AND ISNULL(TEFIN.CEA_FAIXA_ETARIA, 0) = COALESCE(@CEA_FAIXA_ETARIA, ISNULL(TEFIN.CEA_FAIXA_ETARIA, 0))    
		AND ISNULL(TEFIN.CEA_CIDADE, 0) = COALESCE(@CEA_CIDADE, ISNULL(TEFIN.CEA_CIDADE, 0))
		AND ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0) = COALESCE(@CEA_ESCRITORIO_REGIONAL, ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0))    
		--AND ISNULL(GE.CEA_GRUPO, 0) = COALESCE(@CEA_GRUPO, ISNULL(GE.CEA_GRUPO, 0))    
		AND ISNULL(TEFIN.CEA_FATURAMENTO, 0) = COALESCE(@CEA_FATURAMENTO, ISNULL(TEFIN.CEA_FATURAMENTO, 0))    
		AND ISNULL(QFIN.TX_PROTOCOLO, '') like '%' + @PROTOCOLO + '%'    
		AND EMPFIN.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'    
		AND ISNULL(ESR.CDA_ESTADO_REGIAO, 0) = COALESCE(@CEA_ESTADO_REGIAO, ISNULL(ESR.CDA_ESTADO_REGIAO, 0))    
		AND ISNULL(TEFIN.TX_SEXO_CONTATO, 0) like '%' + COALESCE(@TX_SEXO_CONTATO, ISNULL(TEFIN.TX_SEXO_CONTATO, 0)) + '%'   
		AND TEFIN.DT_ULTIMA_ALTERACAO BETWEEN @DATAINICIO AND @DATAFIM    
		AND ISNULL(TEFIN.NU_FUNCIONARIO, 0) = COALESCE(@NU_FUNCIONARIOS, ISNULL(TEFIN.NU_FUNCIONARIO, 0))    
		AND ISNULL(TEFIN.CEA_TIPO_EMPRESA, 0) = COALESCE(@TIPO_EMPRESA, ISNULL(TEFIN.CEA_TIPO_EMPRESA, 0))
		--Possui Questionário de Responsabilidade Social----------       
		AND (@FL_QUESTIONARIO_RESP_SOCIAL = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QRESP WHERE QRESP.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND QRESP.FL_ATIVO = 1 AND QRESP.CEA_QUESTIONARIO = @QUESTIONARIO_RESPSOCIAL), 0) ELSE 0 END
		----------------------------------------------------------
		--Possui do Questionário de Inovação------------        
		OR @FL_QUESTIONARIO_INOVACAO = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QINOVA WHERE QINOVA.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND QINOVA.FL_ATIVO = 1 AND QINOVA.CEA_QUESTIONARIO = @QUESTIOARIO_INOVACAO), 0) ELSE 0 END)
		)
		 [TotalVencedoraRespSocial]
		
	 -- Vencedora Inovação
	 ,(SELECT COUNT(DISTINCT QFIN.CDA_QUESTIONARIO_EMPRESA)  FROM  TBL_QUESTIONARIO_EMPRESA QFIN
		JOIN TBL_ETAPA ETAPAFIN ON ETAPAFIN.CDA_ETAPA = QFIN.CEA_ETAPA
		JOIN TBL_EMP_CADASTRO EMPFIN ON EMPFIN.CDA_EMP_CADASTRO = QFIN.CEA_EMP_CADASTRO
		JOIN TBL_TURMA_EMP TEFIN ON TEFIN.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND TEFIN.CEA_TURMA = @CEA_TURMA
		JOIN TBL_ESTADO E ON E.CDA_ESTADO = TEFIN.CEA_ESTADO 
		LEFT JOIN TBL_ESTADO_REGIAO ESR ON ESR.CDA_ESTADO_REGIAO = E.CDA_ESTADO
		LEFT JOIN TBL_ESCRITORIO_REGIONAL ER ON ER.CEA_ESTADO = E.CDA_ESTADO
		LEFT JOIN TBL_GRUPOEMPRESA GE ON GE.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO  
		JOIN TBL_TURMA T ON TEFIN.CEA_TURMA = T.CDA_TURMA
		WHERE QFIN.FL_ATIVO = 1
		AND QFIN.TX_PROTOCOLO IS NOT NULL
		AND ETAPAFIN.CEA_TIPO_ETAPA = @VENCEDORAS
		AND ETAPAFIN.CEA_TURMA = @CEA_TURMA
		AND TEFIN.CEA_TURMA =  @CEA_TURMA
		AND QFIN.CEA_QUESTIONARIO = @QUESTIOARIO_INOVACAO
		AND TEFIN.CEA_ESTADO =  ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPFIN.CEA_ESTADO = ISNULL(@CEA_ESTADO, E.CDA_ESTADO)
		AND EMPFIN.TX_NOME_FANTASIA like '%' + @sNOME_FANTASIA + '%'
		AND ISNULL(TEFIN.CEA_CATEGORIA, 0) = COALESCE(@CEA_CATEGORIA, ISNULL(CAT.CDA_CATEGORIA, 0))    
		AND ISNULL(TEFIN.CEA_NIVEL_ESCOLARIDADE, 0) = COALESCE(@CEA_NIVEL_ESCOLARIDADE, ISNULL(TEFIN.CEA_NIVEL_ESCOLARIDADE, 0))    
		AND ISNULL(TEFIN.CEA_FAIXA_ETARIA, 0) = COALESCE(@CEA_FAIXA_ETARIA, ISNULL(TEFIN.CEA_FAIXA_ETARIA, 0))    
		AND ISNULL(TEFIN.CEA_CIDADE, 0) = COALESCE(@CEA_CIDADE, ISNULL(TEFIN.CEA_CIDADE, 0))
		AND ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0) = COALESCE(@CEA_ESCRITORIO_REGIONAL, ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0))    
		--AND ISNULL(GE.CEA_GRUPO, 0) = COALESCE(@CEA_GRUPO, ISNULL(GE.CEA_GRUPO, 0))    
		AND ISNULL(TEFIN.CEA_FATURAMENTO, 0) = COALESCE(@CEA_FATURAMENTO, ISNULL(TEFIN.CEA_FATURAMENTO, 0))    
		AND ISNULL(QFIN.TX_PROTOCOLO, '') like '%' + @PROTOCOLO + '%'    
		AND EMPFIN.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'    
		AND ISNULL(ESR.CDA_ESTADO_REGIAO, 0) = COALESCE(@CEA_ESTADO_REGIAO, ISNULL(ESR.CDA_ESTADO_REGIAO, 0))    
		AND ISNULL(TEFIN.TX_SEXO_CONTATO, 0) like '%' + COALESCE(@TX_SEXO_CONTATO, ISNULL(TEFIN.TX_SEXO_CONTATO, 0)) + '%'   
		AND TEFIN.DT_ULTIMA_ALTERACAO BETWEEN @DATAINICIO AND @DATAFIM    
		AND ISNULL(TEFIN.NU_FUNCIONARIO, 0) = COALESCE(@NU_FUNCIONARIOS, ISNULL(TEFIN.NU_FUNCIONARIO, 0))    
		AND ISNULL(TEFIN.CEA_TIPO_EMPRESA, 0) = COALESCE(@TIPO_EMPRESA, ISNULL(TEFIN.CEA_TIPO_EMPRESA, 0))
		--Possui Questionário de Responsabilidade Social----------       
		AND (@FL_QUESTIONARIO_RESP_SOCIAL = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QRESP WHERE QRESP.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND QRESP.FL_ATIVO = 1 AND QRESP.CEA_QUESTIONARIO = @QUESTIONARIO_RESPSOCIAL), 0) ELSE 0 END
		----------------------------------------------------------
		--Possui do Questionário de Inovação------------        
		OR @FL_QUESTIONARIO_INOVACAO = CASE  WHEN @FL_QUESTIONARIO_RESP_SOCIAL = 1 THEN ISNULL((SELECT TOP 1 1 FROM TBL_QUESTIONARIO_EMPRESA QINOVA WHERE QINOVA.CEA_EMP_CADASTRO = EMPFIN.CDA_EMP_CADASTRO AND QINOVA.FL_ATIVO = 1 AND QINOVA.CEA_QUESTIONARIO = @QUESTIOARIO_INOVACAO), 0) ELSE 0 END)
		)
		 [TotalVencedoraInovacao]	

  FROM TBL_CATEGORIA CAT
  WHERE CAT.CDA_CATEGORIA = COALESCE(@CEA_CATEGORIA, CAT.CDA_CATEGORIA) 
  AND CAT.FL_ATIVO = 1;

RETURN  
END  
    
--    
