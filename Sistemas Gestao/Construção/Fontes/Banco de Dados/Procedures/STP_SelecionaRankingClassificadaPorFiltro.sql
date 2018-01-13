SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[STP_SelecionaRankingClassificadaPorFiltro]
(
@CEA_TIPO_ETAPA INT,
@CEA_TIPO_ETAPA_FINAL INT,
@CEA_TURMA INT,
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
@CEA_QUESTIONARIO_INOVACAO INT,
@CEA_QUESTIONARIO_EMPREENDEDORISMO INT,
@CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL INT,
--------FILTROS DE TELA-------------------
@sNOME_FANTASIA VARCHAR(500),
@CEA_ESTADO INT,
@CEA_CATEGORIA INT,
@CEA_NIVEL_ESCOLARIDADE INT,
@CEA_FAIXA_ETARIA INT,
@CEA_CIDADE INT,
@CEA_ESCRITORIO_REGIONAL INT,
@STATUS INT,
@CEA_GRUPO INT,
@CEA_FATURAMENTO INT,
@PROTOCOLO VARCHAR(200),
@CPF_CNPJ VARCHAR(200),
@CEA_ESTADO_REGIAO INT,
@TX_SEXO_CONTATO VARCHAR(1),
@DATAINICIO DATETIME,
@DATAFIM DATETIME,
@NU_FUNCIONARIOS INT,
@TIPO_EMPRESA INT
------------------------------------------
)
As   
BEGIN     

SET NOCOUNT ON  

--Considera Respostas do Avaliador
DECLARE @bIS_AVALIADOR BIT
SET @bIS_AVALIADOR = 1
---------------------------------
--Considera Repostas da Empresa
DECLARE @bIS_EMPRESA BIT
SET @bIS_EMPRESA = 0
---------------------------------
--Maior nota da Categoria--------
DECLARE @MAIORNOTAPOSVISITA DECIMAL(18,5)
SET @MAIORNOTAPOSVISITA = ISNULL((SELECT MAX(QGESTAO.NU_TOTAL_PONTUACAO_AVALIADOR) FROM TBL_QUESTIONARIO_EMPRESA QGESTAO 
						JOIN TBL_ETAPA ETA ON ETA.CDA_ETAPA = QGESTAO.CEA_ETAPA
						WHERE QGESTAO.FL_ATIVO = 1 AND  ETA.CEA_TIPO_ETAPA = @CEA_TIPO_ETAPA), 0)
						
DECLARE @MAIORNOTAPREVISITA DECIMAL(18,5)
SET @MAIORNOTAPREVISITA = ISNULL((SELECT MAX(QGESTAO.NU_TOTAL_PONTUACAO) FROM TBL_QUESTIONARIO_EMPRESA QGESTAO 
						JOIN TBL_ETAPA ETA ON ETA.CDA_ETAPA = QGESTAO.CEA_ETAPA
						WHERE QGESTAO.FL_ATIVO = 1 AND  ETA.CEA_TIPO_ETAPA = @CEA_TIPO_ETAPA), 0)
---------------------------------

SELECT distinct
EC.CDA_EMP_CADASTRO,
QE.CDA_QUESTIONARIO_EMPRESA,
QE.TX_PROTOCOLO,
EC.TX_CPF_CNPJ,
EC.TX_RAZAO_SOCIAL,
QE.FL_PARA_AVALIACAO,
QE.FL_PASSA_PROXIMA_ETAPA,
ET.FL_ATIVO AS FL_ETAPA_ATIVA,
ET.CDA_ETAPA,
--Possui Question�rio de Responsabilidade Social----------       
ISNULL((SELECT QRESP.CDA_QUESTIONARIO_EMPRESA FROM TBL_QUESTIONARIO_EMPRESA QRESP INNER JOIN TBL_ETAPA ET1 ON ET1.CDA_ETAPA = QRESP.CEA_ETAPA WHERE ET1.CEA_TIPO_ETAPA = @CEA_TIPO_ETAPA AND QRESP.CEA_EMP_CADASTRO = EC.CDA_EMP_CADASTRO AND QRESP.FL_ATIVO = 1 AND QRESP.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL AND QE.TX_PROTOCOLO is Not Null), 0) [PossuiResponsabilidadeSocial],
----------------------------------------------------------
--Possui do Question�rio de Inova��o------------        
ISNULL((SELECT QINOVA.CDA_QUESTIONARIO_EMPRESA FROM TBL_QUESTIONARIO_EMPRESA QINOVA INNER JOIN TBL_ETAPA ET1 ON ET1.CDA_ETAPA = QINOVA.CEA_ETAPA WHERE ET1.CEA_TIPO_ETAPA = @CEA_TIPO_ETAPA AND QINOVA.CEA_EMP_CADASTRO = EC.CDA_EMP_CADASTRO AND QINOVA.FL_ATIVO = 1 AND QINOVA.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_INOVACAO AND QE.TX_PROTOCOLO is Not Null), 0) [PossuiInovacao],
------------------------------------------------
--Verifica se a Empresa � Finalista do Question�rio de Responsabilidade Social----------       
ISNULL((SELECT QFINAL.CDA_QUESTIONARIO_EMPRESA FROM TBL_QUESTIONARIO_EMPRESA QFINAL 
		JOIN TBL_ETAPA ETFINAL ON ETFINAL.CDA_ETAPA = QFINAL.CEA_ETAPA
		JOIN TBL_TIPO_ETAPA TIEFINAL ON TIEFINAL.CDA_TIPO_ETAPA = ETFINAL.CEA_TIPO_ETAPA 
		WHERE ETFINAL.CEA_TIPO_ETAPA = @CEA_TIPO_ETAPA_FINAL 
		AND QFINAL.CEA_EMP_CADASTRO = EC.CDA_EMP_CADASTRO 
		AND QFINAL.FL_ATIVO = 1 
		AND QFINAL.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL 
		AND QFINAL.TX_PROTOCOLO is Not Null), 0) [FinalistaResponsabilidadeSocial],
----------------------------------------------------------
--Verifica se a Empresa � Finalista do Question�rio de Inova��o------------        
ISNULL((SELECT QFINAL.CDA_QUESTIONARIO_EMPRESA FROM TBL_QUESTIONARIO_EMPRESA QFINAL 
		JOIN TBL_ETAPA ETFINAL ON ETFINAL.CDA_ETAPA = QFINAL.CEA_ETAPA
		JOIN TBL_TIPO_ETAPA TIEFINAL ON TIEFINAL.CDA_TIPO_ETAPA = ETFINAL.CEA_TIPO_ETAPA 
		WHERE ETFINAL.CEA_TIPO_ETAPA = @CEA_TIPO_ETAPA_FINAL 
		AND QFINAL.CEA_EMP_CADASTRO = EC.CDA_EMP_CADASTRO 
		AND QFINAL.FL_ATIVO = 1 
		AND QFINAL.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_INOVACAO 
		AND QFINAL.TX_PROTOCOLO is Not Null), 0) [FinalistaInovacao],
------------------------------------------------
--Verifica se a Empresa � Finalista---------        
ISNULL((SELECT QFINAL.CDA_QUESTIONARIO_EMPRESA FROM TBL_QUESTIONARIO_EMPRESA QFINAL 
		JOIN TBL_ETAPA ETFINAL ON ETFINAL.CDA_ETAPA = QFINAL.CEA_ETAPA
		JOIN TBL_TIPO_ETAPA TIEFINAL ON TIEFINAL.CDA_TIPO_ETAPA = ETFINAL.CEA_TIPO_ETAPA 
		WHERE ETFINAL.CEA_TIPO_ETAPA = @CEA_TIPO_ETAPA_FINAL 
		AND QFINAL.CEA_EMP_CADASTRO = EC.CDA_EMP_CADASTRO 
		AND QFINAL.FL_ATIVO = 1 
		AND QFINAL.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_GESTAO 
		AND QFINAL.TX_PROTOCOLO is Not Null), 0) [Finalista],
------------------------------------------------------------------------
------------------------POS-VISITA--------------------------------------
ISNULL(P1, 0) [CriterioClientePosVisita],
ISNULL(P2, 0) [CriterioSociedadePosVisita],
ISNULL(P3, 0) [CriterioLiderancaPosVisita],
ISNULL(P4, 0) [CriterioEstrategiaPlanosPosVisita],
ISNULL(P5, 0) [CriterioPessoasPosVisita],
ISNULL(P6, 0) [CriterioProcessosPosVisita],
ISNULL(P7, 0) [CriterioInformacoesConhecimentoPosVisita],
ISNULL(P8, 0) [CriterioResultadoControlePosVisita],
ISNULL(P9, 0) [CriterioResultadoTendenciaPosVisita],
ISNULL(P1, 0) + ISNULL(P2, 0) + ISNULL(P3, 0) + ISNULL(P4, 0) + ISNULL(P5, 0) + ISNULL(P6, 0) + ISNULL(P7, 0) + ISNULL(P8, 0) + ISNULL(P9, 0) [PontuacaoTotalPosVisita],
ISNULL(P1, 0) + ISNULL(P2, 0) + ISNULL(P3, 0) + ISNULL(P4, 0) + ISNULL(P5, 0) + ISNULL(P6, 0) + ISNULL(P7, 0)  [TotalEnfoquePosVisita],
ISNULL(P8, 0)  [ResultadoControlePosVisita],
ISNULL(P9, 0)  [ResultadoTendenciaPosVisita],
@MAIORNOTAPOSVISITA [MaiorNotaPosVisita],
--Pontua��o do Question�rio de Empreendedorismo----        
ISNULL((SELECT QEMP.NU_TOTAL_PONTUACAO_AVALIADOR FROM TBL_QUESTIONARIO_EMPRESA QEMP INNER JOIN TBL_ETAPA ET1 ON ET1.CDA_ETAPA = QEMP.CEA_ETAPA WHERE ET1.CEA_TIPO_ETAPA = @CEA_TIPO_ETAPA AND QEMP.CEA_EMP_CADASTRO = EC.CDA_EMP_CADASTRO AND QEMP.FL_ATIVO = 1 AND QEMP.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_EMPREENDEDORISMO AND QE.TX_PROTOCOLO is Not Null), 0) [TotalEmpreendedorismoPosVisita],
---------------------------------------------------
--Pontua��o do Question�rio de Responsabilidade Social----        
ISNULL((SELECT QEMPRESP.NU_TOTAL_PONTUACAO_AVALIADOR FROM TBL_QUESTIONARIO_EMPRESA QEMPRESP INNER JOIN TBL_ETAPA ET1 ON ET1.CDA_ETAPA = QEMPRESP.CEA_ETAPA WHERE ET1.CEA_TIPO_ETAPA = @CEA_TIPO_ETAPA AND QEMPRESP.CEA_EMP_CADASTRO = EC.CDA_EMP_CADASTRO AND QEMPRESP.FL_ATIVO = 1 AND QEMPRESP.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL AND QE.TX_PROTOCOLO is Not Null), 0) [PontuacaoTotalResponsabilidadeSocial],
---------------------------------------------------
--Pontua��o do Question�rio de Inovacao----        
ISNULL((SELECT QEMPINOV.NU_TOTAL_PONTUACAO_AVALIADOR FROM TBL_QUESTIONARIO_EMPRESA QEMPINOV INNER JOIN TBL_ETAPA ET1 ON ET1.CDA_ETAPA = QEMPINOV.CEA_ETAPA WHERE ET1.CEA_TIPO_ETAPA = @CEA_TIPO_ETAPA AND QEMPINOV.CEA_EMP_CADASTRO = EC.CDA_EMP_CADASTRO AND QEMPINOV.FL_ATIVO = 1 AND QEMPINOV.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_INOVACAO AND QE.TX_PROTOCOLO is Not Null), 0) [PontuacaoTotalInovacao],
---------------------------------------------------
--------Rela��o com a Melhor da Categoria-------

------------------------------------------------------------------------
------------------------PRE-VISITA--------------------------------------
ISNULL(P10, 0) [CriterioClientePreVisita],
ISNULL(P11, 0) [CriterioSociedadePreVisita],
ISNULL(P12, 0) [CriterioLiderancaPreVisita],
ISNULL(P13, 0) [CriterioEstrategiaPlanosPreVisita],
ISNULL(P14, 0) [CriterioPessoasPreVisita],
ISNULL(P15, 0) [CriterioProcessosPreVisita],
ISNULL(P16, 0) [CriterioInformacoesConhecimentoPreVisita],
ISNULL(P17, 0) [CriterioResultadoControlePreVisita],
ISNULL(P18, 0) [CriterioResultadoTendenciaPreVisita],
ISNULL(P10, 0) + ISNULL(P11, 0) + ISNULL(P12, 0) + ISNULL(P13, 0) + ISNULL(P14, 0) + ISNULL(P15, 0) + ISNULL(P16, 0) + ISNULL(P17, 0) [PontuacaoRankingPreVisita],
ISNULL(P10, 0) + ISNULL(P11, 0) + ISNULL(P12, 0) + ISNULL(P13, 0) + ISNULL(P14, 0) + ISNULL(P15, 0) + ISNULL(P16, 0) + ISNULL(P17, 0) + ISNULL(P18, 0) [PontuacaoTotalPreVisita],
ISNULL(P10, 0) + ISNULL(P11, 0) + ISNULL(P12, 0) + ISNULL(P13, 0) + ISNULL(P14, 0) + ISNULL(P15, 0) + ISNULL(P16, 0) [TotalEnfoquePreVisita],
ISNULL(P17, 0) [ResultadoControlePreVisita],
ISNULL(P18, 0) [ResultadoTendenciaPreVisita],
@MAIORNOTAPREVISITA [MaiorNotaPreVisita]
--------Rela��o com a Melhor da Categoria-------
--CASE WHEN @MAIORNOTAPREVISITA > 0 THEN ((QE.NU_TOTAL_PONTUACAO_AVALIADOR * 100)/@MAIORNOTAPREVISITA) ELSE 0 END [RelacaoComMelhorDaCategoriaPreVisita]



------------------------------------------------------------------------
FROM TBL_TURMA_EMP TE
JOIN TBL_EMP_CADASTRO EC ON EC.CDA_EMP_CADASTRO = TE.CEA_EMP_CADASTRO
JOIN TBL_QUESTIONARIO_EMPRESA QE ON QE.CEA_EMP_CADASTRO = TE.CEA_EMP_CADASTRO
JOIN TBL_ETAPA ET ON ET.CDA_ETAPA = QE.CEA_ETAPA
JOIN TBL_TIPO_ETAPA TIE ON TIE.CDA_TIPO_ETAPA = ET.CEA_TIPO_ETAPA
------------------------POS-VISITA--------------------------------------
--Crit�rio Cliente--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P1, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA, FL_AVALIADOR    
       FROM  TBL_QUESTIONARIO_PONTUACAO      
       WHERE CEA_CRITERIO = @CEA_CRITERIO_CLIENTE AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP1     
       ON QP1.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA
----------------------
--Crit�rio Sociedade--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P2, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_SOCIEDADE AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP2     
       ON QP2.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA
----------------------
--Crit�rio Lideran�a--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P3, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_LIDERANCA AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP3     
       ON QP3.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA 
----------------------         
--Crit�rio Estrategia e Planos--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P4, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_ESTRATEGIA_PLANO AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP4     
       ON QP4.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA 
----------------------
--Crit�rio Pessoas--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P5, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_PESSOAS AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP5     
       ON QP5.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA 
----------------------    
--Crit�rio Processos--
   LEFT JOIN (  SELECT SUM(NU_PONTO) AS P6, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_PROCESSOS AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP6     
       ON QP6.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA   
----------------------
--Crit�rio Informa��es e Conhecimento-         
   LEFT JOIN (  SELECT SUM(NU_PONTO) AS P7, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_INFORMACAO_CONHECIMENTO AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP7     
       ON QP7.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA     
----------------------
--Crit�rio Resultado de Controle--       
   LEFT JOIN (  SELECT SUM(NU_PONTO) AS P8, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_RESULTADO_CONTROLE AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP8     
       ON QP8.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA     
----------------------
--Crit�rio Resultado de Tend�ncia--        
   LEFT JOIN (  SELECT SUM(NU_PONTO) AS P9, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_RESULTADO_TENDENCIA AND FL_AVALIADOR = COALESCE(@bIS_AVALIADOR, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP9     
       ON QP9.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA           
------------------------------------------------------------------------
------------------------PRE-VISITA--------------------------------------
--Crit�rio Cliente--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P10, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA, FL_AVALIADOR    
       FROM  TBL_QUESTIONARIO_PONTUACAO      
       WHERE CEA_CRITERIO = @CEA_CRITERIO_CLIENTE AND FL_AVALIADOR = COALESCE(@bIS_EMPRESA, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP10     
       ON QP10.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA
----------------------
--Crit�rio Sociedade--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P11, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_SOCIEDADE AND FL_AVALIADOR = COALESCE(@bIS_EMPRESA, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP11    
       ON QP11.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA
----------------------
--Crit�rio Lideran�a--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P12, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_LIDERANCA AND FL_AVALIADOR = COALESCE(@bIS_EMPRESA, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP12     
       ON QP12.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA 
----------------------         
--Crit�rio Estrategia e Planos--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P13, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_ESTRATEGIA_PLANO AND FL_AVALIADOR = COALESCE(@bIS_EMPRESA, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP13    
       ON QP13.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA 
----------------------
--Crit�rio Pessoas--
LEFT JOIN (  SELECT SUM(NU_PONTO) AS P14, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_PESSOAS AND FL_AVALIADOR = COALESCE(@bIS_EMPRESA, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP14     
       ON QP14.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA 
----------------------    
--Crit�rio Processos--
   LEFT JOIN (  SELECT SUM(NU_PONTO) AS P15, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_PROCESSOS AND FL_AVALIADOR = COALESCE(@bIS_EMPRESA, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP15     
       ON QP15.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA   
----------------------
--Crit�rio Informa��es e Conhecimento-         
   LEFT JOIN (  SELECT SUM(NU_PONTO) AS P16, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_INFORMACAO_CONHECIMENTO AND FL_AVALIADOR = COALESCE(@bIS_EMPRESA, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP16     
       ON QP16.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA     
----------------------
--Crit�rio Resultado de Controle--       
   LEFT JOIN (  SELECT SUM(NU_PONTO) AS P17, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_RESULTADO_CONTROLE AND FL_AVALIADOR = COALESCE(@bIS_EMPRESA, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP17     
       ON QP17.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA     
----------------------
--Crit�rio Resultado de Tend�ncia--        
   LEFT JOIN (  SELECT SUM(NU_PONTO) AS P18, CEA_CRITERIO, CEA_QUESTIONARIO_EMPRESA    
       FROM TBL_QUESTIONARIO_PONTUACAO     
       WHERE CEA_CRITERIO = @CEA_CRITERIO_RESULTADO_TENDENCIA AND FL_AVALIADOR = COALESCE(@bIS_EMPRESA, FL_AVALIADOR)  
       GROUP BY CEA_QUESTIONARIO_EMPRESA, CEA_CRITERIO, FL_AVALIADOR) QP18     
       ON QP18.CEA_QUESTIONARIO_EMPRESA = QE.CDA_QUESTIONARIO_EMPRESA  
------------------------------------------------------------------------ 
-----------FILTROS DE TELA----------------------------------------------
JOIN TBL_CARGO CA ON CA.CDA_CARGO = TE.CEA_CARGO        
JOIN TBL_BAIRRO BA ON BA.CDA_BAIRRO = TE.CEA_BAIRRO
JOIN TBL_CIDADE CI ON CI.CDA_CIDADE = TE.CEA_CIDADE
JOIN TBL_ESTADO ES ON ES.CDA_ESTADO = TE.CEA_ESTADO
JOIN TBL_TIPO_EMP TI ON TI.CDA_TIPO_EMPRESA = TE.CEA_TIPO_EMPRESA
JOIN TBL_FATURAMENTO FA ON FA.CDA_FATURAMENTO = TE.CEA_FATURAMENTO
JOIN TBL_CATEGORIA CAT ON CAT.CDA_CATEGORIA = TE.CEA_CATEGORIA
JOIN TBL_ATIVIDADE_ECONOMICA AE ON AE.CDA_ATIVIDADE_ECONOMICA = TE.CEA_ATIVIDADE_ECONOMICA
JOIN TBL_CONTATO_NIVEL_ESCOLARIDADE NE ON NE.CDA_NIVEL_ESCOLARIDADE = TE.CEA_NIVEL_ESCOLARIDADE
JOIN TBL_CONTATO_FAIXA_ETARIA FE ON FE.CDA_FAIXA_ETARIA = TE.CEA_FAIXA_ETARIA
LEFT JOIN TBL_ESCRITORIO_REGIONAL ER ON ER.CEA_ESTADO = ES.CDA_ESTADO
LEFT JOIN TBL_GRUPOEMPRESA GE ON GE.CEA_EMP_CADASTRO = EC.CDA_EMP_CADASTRO
LEFT JOIN TBL_ESTADO_REGIAO ESR ON ESR.CDA_ESTADO_REGIAO = ES.CDA_ESTADO
-----------------------------------------------------------------------------
WHERE ET.CEA_TIPO_ETAPA = @CEA_TIPO_ETAPA
AND EC.FL_ATIVO = 1
AND TE.FL_ATIVO = 1
AND QE.FL_ATIVO = 1
AND QE.TX_PROTOCOLO is Not Null
AND QE.CEA_QUESTIONARIO = @CEA_QUESTIONARIO_GESTAO
AND TE.CEA_TURMA = @CEA_TURMA
------------------------------FILTROS DE TELA------------------------------
AND EC.TX_NOME_FANTASIA like '%' + @sNOME_FANTASIA + '%'
AND TE.CEA_ESTADO = COALESCE(@CEA_ESTADO, TE.CEA_ESTADO)
AND TE.CEA_CATEGORIA = COALESCE(@CEA_CATEGORIA, TE.CEA_CATEGORIA)
AND TE.CEA_NIVEL_ESCOLARIDADE = COALESCE(@CEA_NIVEL_ESCOLARIDADE, TE.CEA_NIVEL_ESCOLARIDADE )
AND TE.CEA_FAIXA_ETARIA = COALESCE(@CEA_FAIXA_ETARIA, TE.CEA_FAIXA_ETARIA)
AND TE.CEA_CIDADE = COALESCE(@CEA_CIDADE, TE.CEA_CIDADE)
AND ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0) = COALESCE(@CEA_ESCRITORIO_REGIONAL, ISNULL(ER.CDA_ESCRITORIO_REGIONAL, 0))
AND ISNULL(TE.STATUS, 0) = COALESCE(@STATUS, ISNULL(TE.STATUS, 0))
AND ISNULL(GE.CEA_GRUPO, 0) = COALESCE(@CEA_GRUPO, ISNULL(GE.CEA_GRUPO, 0))
AND ISNULL(TE.CEA_FATURAMENTO, 0) = COALESCE(@CEA_FATURAMENTO, ISNULL(TE.CEA_FATURAMENTO, 0))
AND ISNULL(QE.TX_PROTOCOLO, '') like '%' + @PROTOCOLO + '%'
AND EC.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'
AND ISNULL(ESR.CDA_ESTADO_REGIAO, 0) = COALESCE(@CEA_ESTADO_REGIAO, ISNULL(ESR.CDA_ESTADO_REGIAO, 0))
AND ISNULL(TE.TX_SEXO_CONTATO, 0) = COALESCE(@TX_SEXO_CONTATO, ISNULL(TE.TX_SEXO_CONTATO, 0))
AND TE.DT_ULTIMA_ALTERACAO BETWEEN @DATAINICIO AND @DATAFIM
AND ISNULL(TE.NU_FUNCIONARIO, 0) = COALESCE(@NU_FUNCIONARIOS, ISNULL(TE.NU_FUNCIONARIO, 0))
AND ISNULL(TE.CEA_TIPO_EMPRESA, 0) =  COALESCE(@TIPO_EMPRESA, ISNULL(TE.CEA_TIPO_EMPRESA, 0))
-----------------------------------------------------------------------------
ORDER BY [PontuacaoTotalPosVisita]
RETURN  
END  
    
--
