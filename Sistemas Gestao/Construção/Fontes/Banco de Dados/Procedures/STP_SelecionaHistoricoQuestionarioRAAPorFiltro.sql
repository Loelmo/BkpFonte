USE [Sistema Gestao]
GO
/****** Object:  StoredProcedure [dbo].[STP_SelecionaHistoricoQuestionarioRAAPorFiltro]    Script Date: 02/14/2011 17:57:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[STP_SelecionaHistoricoQuestionarioRAAPorFiltro]
(
	@nCDA_EMP_CADASTRO	INT,  
	@nCEA_TURMA			INT,  
	@bIS_AVALIADOR		BIT,
	@CEA_TIPO_ETAPA_CANDIDATURA_EMPRESA			INT,
	@CEA_TIPO_ETAPA_CANDIDATURA_ADMINISTRATIVO	INT,
	
----------CRITERIOS GEST�O--------------------
@CEA_CRITERIO_CLIENTE INT,
@CEA_CRITERIO_SOCIEDADE INT,
@CEA_CRITERIO_LIDERANCA INT,
@CEA_CRITERIO_ESTRATEGIA_PLANO INT,
@CEA_CRITERIO_PESSOAS INT,
@CEA_CRITERIO_PROCESSOS INT,
@CEA_CRITERIO_INFORMACAO_CONHECIMENTO INT,
@CEA_CRITERIO_RESULTADO_CONTROLE INT,
@CEA_CRITERIO_RESULTADO_TENDENCIA INT,
------------------------------------------
-------QUESTIONARIOS----------------------
@CEA_QUESTIONARIO_GESTAO INT,
@CEA_QUESTIONARIO_EMPREENDEDORISMO INT,
@CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL INT,
@CEA_QUESTIONARIO_INOVACAO INT
)  
As    
BEGIN     
SET NOCOUNT ON  

	SELECT distinct
		 QE.CDA_QUESTIONARIO_EMPRESA
		,QE.CEA_PROGRAMA
		,QE.CEA_EMP_CADASTRO 
		,QE.TX_PROTOCOLO
		,P.TX_PROGRAMA
		,P.CDA_PROGRAMA
		,QE.DT_CADASTRO
		,CAT.TX_CATEGORIA
		,AE.TX_ATIVIDADE_ECONOMICA
		,FA.TX_FATURAMENTO
		,BA.TX_BAIRRO
		,CI.TX_CIDADE
		,ES.TX_ESTADO
		,CA.TX_CARGO
		,TE.TX_EMAIL_CONTATO
		,ISNULL(FL_AVALIADOR, 0) FL_AVALIADOR
		,ISNULL(P1, 0) CriterioCliente
		,ISNULL(P2, 0) CriterioSociedade
		,ISNULL(P3, 0) CriterioLideranca
		,ISNULL(P4, 0) CriterioEstrategiaPlano
		,ISNULL(P5, 0) CriterioPessoa
		,ISNULL(P6, 0) CriterioProcesso
		,ISNULL(P7, 0) CriterioInformacaoConhecimento
		,ISNULL(P8, 0) CriterioResultadoControle
		,ISNULL(P9, 0) CriterioResultadoTendencia
		--Pontua��o do Question�rio de Empreendedorismo----        
		,ISNULL(QEMP.NU_TOTAL_PONTUACAO, 0) AvaliacaoEmpreendedor
		--Pontua��o do Question�rio de Responsabilidade Social----        
		,ISNULL(QRESP.NU_TOTAL_PONTUACAO, 0) AvaliacaoResponsabilidadeSocial
		--Pontua��o do Question�rio de Inova��o----        
		,ISNULL(QINOV.NU_TOTAL_PONTUACAO, 0) AvaliacaoInovacao
		---------------------------------------------------
		,ISNULL(P1, 0) + ISNULL(P2, 0) + ISNULL(P3, 0) + ISNULL(P4, 0) + ISNULL(P5, 0) + ISNULL(P6, 0) + ISNULL(P7, 0) + ISNULL(P8, 0) + ISNULL(P9, 0) TotalGestao
	 FROM 
		TBL_QUESTIONARIO_EMPRESA QE 
			JOIN TBL_ETAPA ETA ON ETA.CDA_ETAPA = QE.CEA_ETAPA
			JOIN TBL_PROGRAMA P ON P.CDA_PROGRAMA = QE.CEA_PROGRAMA
			JOIN TBL_TURMA T ON T.CEA_PROGRAMA = P.CDA_PROGRAMA AND ETA.CEA_TURMA = T.CDA_TURMA
			JOIN TBL_TURMA_EMP TE ON T.CDA_TURMA = TE.CEA_TURMA AND QE.CEA_EMP_CADASTRO = TE.CEA_EMP_CADASTRO
			JOIN TBL_TIPO_ETAPA TIE ON TIE.CDA_TIPO_ETAPA = ETA.CEA_TIPO_ETAPA 
			JOIN TBL_CARGO CA ON CA.CDA_CARGO = TE.CEA_CARGO
			JOIN TBL_BAIRRO BA ON BA.CDA_BAIRRO = TE.CEA_BAIRRO
			JOIN TBL_CIDADE CI ON CI.CDA_CIDADE = TE.CEA_CIDADE
			JOIN TBL_ESTADO ES ON ES.CDA_ESTADO = TE.CEA_ESTADO
			JOIN TBL_FATURAMENTO FA ON FA.CDA_FATURAMENTO = TE.CEA_FATURAMENTO
			JOIN TBL_CATEGORIA CAT ON CAT.CDA_CATEGORIA = TE.CEA_CATEGORIA
			JOIN TBL_ATIVIDADE_ECONOMICA AE ON AE.CDA_ATIVIDADE_ECONOMICA = TE.CEA_ATIVIDADE_ECONOMICA
			--Crit�rio Cliente--
LEFT JOIN TBL_QUESTIONARIO_EMPRESA QEMP on QEMP.CEA_EMP_CADASTRO = QE.CEA_EMP_CADASTRO AND QEMP.TX_PROTOCOLO = QE.TX_PROTOCOLO AND QEMP.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_EMPREENDEDORISMO 
LEFT JOIN TBL_QUESTIONARIO_EMPRESA QRESP on QRESP.CEA_EMP_CADASTRO = QE.CEA_EMP_CADASTRO AND QRESP.TX_PROTOCOLO = QE.TX_PROTOCOLO AND QRESP.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL
LEFT JOIN TBL_QUESTIONARIO_EMPRESA QINOV on QINOV.CEA_EMP_CADASTRO = QE.CEA_EMP_CADASTRO AND QINOV.TX_PROTOCOLO = QE.TX_PROTOCOLO AND QINOV.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_INOVACAO 
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P1, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA, FL_AVALIADOR    
       FROM  TBL_QUESTIONARIO_PONTUACAO      
       WHERE CEA_CRITERIO = @CEA_CRITERIO_CLIENTE AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP1     
       ON QP1.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA
------------------------
----Crit�rio Sociedade--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P2, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_SOCIEDADE AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP2     
       ON QP2.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA
------------------------
----Crit�rio Lideran�a--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P3, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_LIDERANCA AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP3     
       ON QP3.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA 
------------------------         
----Crit�rio Estrategia e Planos--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P4, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_ESTRATEGIA_PLANO AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP4     
       ON QP4.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA 
------------------------
----Crit�rio Pessoas--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P5, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_PESSOAS AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP5     
       ON QP5.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA 
------------------------    
----Crit�rio Processos--
   LEFT JOIN (  SELECT SUM(NU_PONTO) AS P6, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_PROCESSOS AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP6     
       ON QP6.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA   
------------------------
----Crit�rio Informa��es e Conhecimento-         
   LEFT JOIN (  SELECT SUM(NU_PONTO) AS P7, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_INFORMACAO_CONHECIMENTO AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP7     
       ON QP7.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA     
------------------------
----Crit�rio Resultado de Controle--       
   LEFT JOIN (  SELECT SUM(NU_PONTO) AS P8, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_RESULTADO_CONTROLE AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP8     
       ON QP8.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA     
------------------------
----Crit�rio Resultado de Tend�ncia--        
   LEFT JOIN (  SELECT SUM(NU_PONTO) AS P9, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_RESULTADO_TENDENCIA AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP9     
       ON QP9.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA           
	WHERE 	QE.TX_PROTOCOLO IS NOT NULL			
	AND		QE.CEA_EMP_CADASTRO = @nCDA_EMP_CADASTRO
	AND		TE.FL_ATIVO = 1
	AND		T.CDA_TURMA			= @nCEA_TURMA
	AND		QE.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_GESTAO
	AND		ETA.CEA_TIPO_ETAPA	IN (@CEA_TIPO_ETAPA_CANDIDATURA_EMPRESA, @CEA_TIPO_ETAPA_CANDIDATURA_ADMINISTRATIVO)
	ORDER BY 
		QE.DT_CADASTRO DESC;  
  
RETURN  
END  
    
--