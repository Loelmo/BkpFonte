
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaDesempenhoGlobal2011
Funcao..................:  
  
  
Tabelas utilizadas......: 
Procedures utilizadas ..:   
Criada por..............: Robinson Campos
Data criacao............: 10/02/2011
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaDesempenhoGlobal2011'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaDesempenhoGlobal2011
(
    @NomeFantasia VARCHAR(200),  
    @CPF_CNPJ VARCHAR(200),  
    @Regiao INT,  
    @Categoria INT,  
    @Grupo INT,  
    @Estado INT,  
    @EstadoRegiao INT,  
    @Cidade INT,  
    @EscritorioRegional INT,  
    @Status INT,
    @PremioEspecial INT,
    @Turma INT
)
As    
BEGIN     
SET NOCOUNT ON  


SELECT '1. Cliente' CRITERIO, 
       '9,0%' PONTUACAO_MAXIMA,
       CONVERT(DECIMAL(10,2),ROUND(ISNULL(SUM(tqp.NU_PONTO), 0) / CASE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) WHEN 0 THEN 1 ELSE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) END, 2, 1)) PONTUACAO_OBTIDA
  FROM TBL_QUESTIONARIO_PONTUACAO tqp
 INNER JOIN TBL_QUESTIONARIO tq ON tq.CDA_QUESTIONARIO = tqp.CEA_QUESTIONARIO
 INNER JOIN TBL_REL_TURMA_QUESTIONARIO trtq ON trtq.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe ON tqe.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_EMP_CADASTRO tec ON tec.CDA_EMP_CADASTRO = tqe.CEA_EMP_CADASTRO
 INNER JOIN TBL_TURMA_EMP tte ON tte.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_GRUPOEMPRESA tg ON tg.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_CIDADE tc ON tc.CDA_CIDADE = tte.CEA_CIDADE AND tc.CDA_CIDADE = tte.CEA_CIDADE_CONTATO
 INNER JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL trcer ON trcer.CEA_CIDADE = tc.CDA_CIDADE
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe2 ON tqe2.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_ETAPA te ON te.CDA_ETAPA = tqe2.CEA_ETAPA
WHERE tqp.CEA_CRITERIO = 75
   AND trtq.CEA_TURMA = @Turma
   AND tec.TX_NOME_FANTASIA LIKE '%' + @NomeFantasia + '%' 
   AND tec.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'  
   AND ISNULL(tte.CEA_CATEGORIA,0) = COALESCE(@Categoria, ISNULL(tte.CEA_CATEGORIA,0))  
   AND ISNULL(tg.CEA_GRUPO, 0) = COALESCE(@Grupo, ISNULL(tg.CEA_GRUPO, 0))  
   AND ISNULL(tte.CEA_ESTADO,0) = COALESCE(@Estado, ISNULL(tte.CEA_ESTADO,0))  
   AND ISNULL(tc.CEA_ESTADO_REGIAO, 0) = COALESCE(@EstadoRegiao, ISNULL(tc.CEA_ESTADO_REGIAO, 0))  
   AND ISNULL(tc.CDA_CIDADE,0) = COALESCE(@Cidade, ISNULL(tc.CDA_CIDADE,0))  
   AND ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0) = COALESCE(@EscritorioRegional, ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0))     
   AND ISNULL(te.CEA_TIPO_ETAPA, 0) = COALESCE(@Status, ISNULL(te.CEA_TIPO_ETAPA, 0))    
   AND tqe.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 6 ELSE tqe.CEA_QUESTIONARIO END
   AND tqe2.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 13 ELSE tqe2.CEA_QUESTIONARIO END
   
UNION

SELECT '2. Sociedade' CRITERIO, 
       '6,0%' PONTUACAO_MAXIMA,
       CONVERT(DECIMAL(10,2),ROUND(ISNULL(SUM(tqp.NU_PONTO), 0) / CASE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) WHEN 0 THEN 1 ELSE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) END, 2, 1)) PONTUACAO_OBTIDA
  FROM TBL_QUESTIONARIO_PONTUACAO tqp
 INNER JOIN TBL_QUESTIONARIO tq ON tq.CDA_QUESTIONARIO = tqp.CEA_QUESTIONARIO
 INNER JOIN TBL_REL_TURMA_QUESTIONARIO trtq ON trtq.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe ON tqe.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_EMP_CADASTRO tec ON tec.CDA_EMP_CADASTRO = tqe.CEA_EMP_CADASTRO
 INNER JOIN TBL_TURMA_EMP tte ON tte.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_GRUPOEMPRESA tg ON tg.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_CIDADE tc ON tc.CDA_CIDADE = tte.CEA_CIDADE AND tc.CDA_CIDADE = tte.CEA_CIDADE_CONTATO
 INNER JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL trcer ON trcer.CEA_CIDADE = tc.CDA_CIDADE
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe2 ON tqe2.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_ETAPA te ON te.CDA_ETAPA = tqe2.CEA_ETAPA
 WHERE tqp.CEA_CRITERIO = 76
   AND trtq.CEA_TURMA = @Turma
   AND tec.TX_NOME_FANTASIA LIKE '%' + @NomeFantasia + '%' 
   AND tec.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'  
   AND ISNULL(tte.CEA_CATEGORIA,0) = COALESCE(@Categoria, ISNULL(tte.CEA_CATEGORIA,0))  
   AND ISNULL(tg.CEA_GRUPO, 0) = COALESCE(@Grupo, ISNULL(tg.CEA_GRUPO, 0))  
   AND ISNULL(tte.CEA_ESTADO,0) = COALESCE(@Estado, ISNULL(tte.CEA_ESTADO,0))  
   AND ISNULL(tc.CEA_ESTADO_REGIAO, 0) = COALESCE(@EstadoRegiao, ISNULL(tc.CEA_ESTADO_REGIAO, 0))  
   AND ISNULL(tc.CDA_CIDADE,0) = COALESCE(@Cidade, ISNULL(tc.CDA_CIDADE,0))  
   AND ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0) = COALESCE(@EscritorioRegional, ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0))      
   AND tqe.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 6 ELSE tqe.CEA_QUESTIONARIO END
   AND tqe2.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 13 ELSE tqe2.CEA_QUESTIONARIO END

UNION

SELECT '3. Lideran�a' CRITERIO, 
       '15,0%' PONTUACAO_MAXIMA,
       CONVERT(DECIMAL(10,2),ROUND(ISNULL(SUM(tqp.NU_PONTO), 0) / CASE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) WHEN 0 THEN 1 ELSE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) END, 2, 1)) PONTUACAO_OBTIDA
  FROM TBL_QUESTIONARIO_PONTUACAO tqp
 INNER JOIN TBL_QUESTIONARIO tq ON tq.CDA_QUESTIONARIO = tqp.CEA_QUESTIONARIO
 INNER JOIN TBL_REL_TURMA_QUESTIONARIO trtq ON trtq.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe ON tqe.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_EMP_CADASTRO tec ON tec.CDA_EMP_CADASTRO = tqe.CEA_EMP_CADASTRO
 INNER JOIN TBL_TURMA_EMP tte ON tte.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_GRUPOEMPRESA tg ON tg.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_CIDADE tc ON tc.CDA_CIDADE = tte.CEA_CIDADE AND tc.CDA_CIDADE = tte.CEA_CIDADE_CONTATO
 INNER JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL trcer ON trcer.CEA_CIDADE = tc.CDA_CIDADE
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe2 ON tqe2.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_ETAPA te ON te.CDA_ETAPA = tqe2.CEA_ETAPA
 WHERE tqp.CEA_CRITERIO = 77
   AND trtq.CEA_TURMA = @Turma
   AND tec.TX_NOME_FANTASIA LIKE '%' + @NomeFantasia + '%' 
   AND tec.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'  
   AND ISNULL(tte.CEA_CATEGORIA,0) = COALESCE(@Categoria, ISNULL(tte.CEA_CATEGORIA,0))  
   AND ISNULL(tg.CEA_GRUPO, 0) = COALESCE(@Grupo, ISNULL(tg.CEA_GRUPO, 0))  
   AND ISNULL(tte.CEA_ESTADO,0) = COALESCE(@Estado, ISNULL(tte.CEA_ESTADO,0))  
   AND ISNULL(tc.CEA_ESTADO_REGIAO, 0) = COALESCE(@EstadoRegiao, ISNULL(tc.CEA_ESTADO_REGIAO, 0))  
   AND ISNULL(tc.CDA_CIDADE,0) = COALESCE(@Cidade, ISNULL(tc.CDA_CIDADE,0))  
   AND ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0) = COALESCE(@EscritorioRegional, ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0))      
   AND tqe.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 6 ELSE tqe.CEA_QUESTIONARIO END
   AND tqe2.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 13 ELSE tqe2.CEA_QUESTIONARIO END

UNION

SELECT '4. Estrat�gias e Planos' CRITERIO,		
       '9,0%' PONTUACAO_MAXIMA,
       CONVERT(DECIMAL(10,2),ROUND(ISNULL(SUM(tqp.NU_PONTO), 0) / CASE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) WHEN 0 THEN 1 ELSE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) END, 2, 1)) PONTUACAO_OBTIDA
  FROM TBL_QUESTIONARIO_PONTUACAO tqp
 INNER JOIN TBL_QUESTIONARIO tq ON tq.CDA_QUESTIONARIO = tqp.CEA_QUESTIONARIO
 INNER JOIN TBL_REL_TURMA_QUESTIONARIO trtq ON trtq.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe ON tqe.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_EMP_CADASTRO tec ON tec.CDA_EMP_CADASTRO = tqe.CEA_EMP_CADASTRO
 INNER JOIN TBL_TURMA_EMP tte ON tte.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_GRUPOEMPRESA tg ON tg.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_CIDADE tc ON tc.CDA_CIDADE = tte.CEA_CIDADE AND tc.CDA_CIDADE = tte.CEA_CIDADE_CONTATO
 INNER JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL trcer ON trcer.CEA_CIDADE = tc.CDA_CIDADE
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe2 ON tqe2.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_ETAPA te ON te.CDA_ETAPA = tqe2.CEA_ETAPA
 WHERE tqp.CEA_CRITERIO = 78
   AND trtq.CEA_TURMA = @Turma
   AND tec.TX_NOME_FANTASIA LIKE '%' + @NomeFantasia + '%' 
   AND tec.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'  
   AND ISNULL(tte.CEA_CATEGORIA,0) = COALESCE(@Categoria, ISNULL(tte.CEA_CATEGORIA,0))  
   AND ISNULL(tg.CEA_GRUPO, 0) = COALESCE(@Grupo, ISNULL(tg.CEA_GRUPO, 0))  
   AND ISNULL(tte.CEA_ESTADO,0) = COALESCE(@Estado, ISNULL(tte.CEA_ESTADO,0))  
   AND ISNULL(tc.CEA_ESTADO_REGIAO, 0) = COALESCE(@EstadoRegiao, ISNULL(tc.CEA_ESTADO_REGIAO, 0))  
   AND ISNULL(tc.CDA_CIDADE,0) = COALESCE(@Cidade, ISNULL(tc.CDA_CIDADE,0))  
   AND ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0) = COALESCE(@EscritorioRegional, ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0))      
   AND tqe.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 6 ELSE tqe.CEA_QUESTIONARIO END
   AND tqe2.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 13 ELSE tqe2.CEA_QUESTIONARIO END

UNION

SELECT '5. Pessoas' CRITERIO, 
       '9,0%' PONTUACAO_MAXIMA,
       CONVERT(DECIMAL(10,2),ROUND(ISNULL(SUM(tqp.NU_PONTO), 0) / CASE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) WHEN 0 THEN 1 ELSE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) END, 2, 1)) PONTUACAO_OBTIDA
  FROM TBL_QUESTIONARIO_PONTUACAO tqp
 INNER JOIN TBL_QUESTIONARIO tq ON tq.CDA_QUESTIONARIO = tqp.CEA_QUESTIONARIO
 INNER JOIN TBL_REL_TURMA_QUESTIONARIO trtq ON trtq.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe ON tqe.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_EMP_CADASTRO tec ON tec.CDA_EMP_CADASTRO = tqe.CEA_EMP_CADASTRO
 INNER JOIN TBL_TURMA_EMP tte ON tte.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_GRUPOEMPRESA tg ON tg.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_CIDADE tc ON tc.CDA_CIDADE = tte.CEA_CIDADE AND tc.CDA_CIDADE = tte.CEA_CIDADE_CONTATO
 INNER JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL trcer ON trcer.CEA_CIDADE = tc.CDA_CIDADE
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe2 ON tqe2.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_ETAPA te ON te.CDA_ETAPA = tqe2.CEA_ETAPA
 WHERE tqp.CEA_CRITERIO = 79
   AND trtq.CEA_TURMA = @Turma
   AND tec.TX_NOME_FANTASIA LIKE '%' + @NomeFantasia + '%' 
   AND tec.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'  
   AND ISNULL(tte.CEA_CATEGORIA,0) = COALESCE(@Categoria, ISNULL(tte.CEA_CATEGORIA,0))  
   AND ISNULL(tg.CEA_GRUPO, 0) = COALESCE(@Grupo, ISNULL(tg.CEA_GRUPO, 0))  
   AND ISNULL(tte.CEA_ESTADO,0) = COALESCE(@Estado, ISNULL(tte.CEA_ESTADO,0))  
   AND ISNULL(tc.CEA_ESTADO_REGIAO, 0) = COALESCE(@EstadoRegiao, ISNULL(tc.CEA_ESTADO_REGIAO, 0))  
   AND ISNULL(tc.CDA_CIDADE,0) = COALESCE(@Cidade, ISNULL(tc.CDA_CIDADE,0))  
   AND ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0) = COALESCE(@EscritorioRegional, ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0))      
   AND tqe.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 6 ELSE tqe.CEA_QUESTIONARIO END
   AND tqe2.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 13 ELSE tqe2.CEA_QUESTIONARIO END

UNION

SELECT '6. Processos' CRITERIO, 
       '16,0%' PONTUACAO_MAXIMA,
       CONVERT(DECIMAL(10,2),ROUND(ISNULL(SUM(tqp.NU_PONTO), 0) / CASE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) WHEN 0 THEN 1 ELSE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) END, 2, 1)) PONTUACAO_OBTIDA
  FROM TBL_QUESTIONARIO_PONTUACAO tqp
 INNER JOIN TBL_QUESTIONARIO tq ON tq.CDA_QUESTIONARIO = tqp.CEA_QUESTIONARIO
 INNER JOIN TBL_REL_TURMA_QUESTIONARIO trtq ON trtq.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe ON tqe.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_EMP_CADASTRO tec ON tec.CDA_EMP_CADASTRO = tqe.CEA_EMP_CADASTRO
 INNER JOIN TBL_TURMA_EMP tte ON tte.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_GRUPOEMPRESA tg ON tg.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_CIDADE tc ON tc.CDA_CIDADE = tte.CEA_CIDADE AND tc.CDA_CIDADE = tte.CEA_CIDADE_CONTATO
 INNER JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL trcer ON trcer.CEA_CIDADE = tc.CDA_CIDADE
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe2 ON tqe2.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_ETAPA te ON te.CDA_ETAPA = tqe2.CEA_ETAPA
 WHERE tqp.CEA_CRITERIO = 80
   AND trtq.CEA_TURMA = @Turma
   AND tec.TX_NOME_FANTASIA LIKE '%' + @NomeFantasia + '%' 
   AND tec.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'  
   AND ISNULL(tte.CEA_CATEGORIA,0) = COALESCE(@Categoria, ISNULL(tte.CEA_CATEGORIA,0))  
   AND ISNULL(tg.CEA_GRUPO, 0) = COALESCE(@Grupo, ISNULL(tg.CEA_GRUPO, 0))  
   AND ISNULL(tte.CEA_ESTADO,0) = COALESCE(@Estado, ISNULL(tte.CEA_ESTADO,0))  
   AND ISNULL(tc.CEA_ESTADO_REGIAO, 0) = COALESCE(@EstadoRegiao, ISNULL(tc.CEA_ESTADO_REGIAO, 0))  
   AND ISNULL(tc.CDA_CIDADE,0) = COALESCE(@Cidade, ISNULL(tc.CDA_CIDADE,0))  
   AND ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0) = COALESCE(@EscritorioRegional, ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0))      
   AND tqe.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 6 ELSE tqe.CEA_QUESTIONARIO END
   AND tqe2.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 13 ELSE tqe2.CEA_QUESTIONARIO END

UNION

SELECT '7. Informa��es e conhecimento' CRITERIO, 
       '6,0%' PONTUACAO_MAXIMA,
       CONVERT(DECIMAL(10,2),ROUND(ISNULL(SUM(tqp.NU_PONTO), 0) / CASE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) WHEN 0 THEN 1 ELSE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) END, 2, 1)) PONTUACAO_OBTIDA
  FROM TBL_QUESTIONARIO_PONTUACAO tqp
 INNER JOIN TBL_QUESTIONARIO tq ON tq.CDA_QUESTIONARIO = tqp.CEA_QUESTIONARIO
 INNER JOIN TBL_REL_TURMA_QUESTIONARIO trtq ON trtq.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe ON tqe.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_EMP_CADASTRO tec ON tec.CDA_EMP_CADASTRO = tqe.CEA_EMP_CADASTRO
 INNER JOIN TBL_TURMA_EMP tte ON tte.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_GRUPOEMPRESA tg ON tg.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_CIDADE tc ON tc.CDA_CIDADE = tte.CEA_CIDADE AND tc.CDA_CIDADE = tte.CEA_CIDADE_CONTATO
 INNER JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL trcer ON trcer.CEA_CIDADE = tc.CDA_CIDADE
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe2 ON tqe2.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_ETAPA te ON te.CDA_ETAPA = tqe2.CEA_ETAPA
 WHERE tqp.CEA_CRITERIO = 81
   AND trtq.CEA_TURMA = @Turma
   AND tec.TX_NOME_FANTASIA LIKE '%' + @NomeFantasia + '%' 
   AND tec.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'  
   AND ISNULL(tte.CEA_CATEGORIA,0) = COALESCE(@Categoria, ISNULL(tte.CEA_CATEGORIA,0))  
   AND ISNULL(tg.CEA_GRUPO, 0) = COALESCE(@Grupo, ISNULL(tg.CEA_GRUPO, 0))  
   AND ISNULL(tte.CEA_ESTADO,0) = COALESCE(@Estado, ISNULL(tte.CEA_ESTADO,0))  
   AND ISNULL(tc.CEA_ESTADO_REGIAO, 0) = COALESCE(@EstadoRegiao, ISNULL(tc.CEA_ESTADO_REGIAO, 0))  
   AND ISNULL(tc.CDA_CIDADE,0) = COALESCE(@Cidade, ISNULL(tc.CDA_CIDADE,0))  
   AND ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0) = COALESCE(@EscritorioRegional, ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0))      
   AND tqe.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 6 ELSE tqe.CEA_QUESTIONARIO END
   AND tqe2.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 13 ELSE tqe2.CEA_QUESTIONARIO END

UNION

SELECT '8. Resultados' CRITERIO, 
       '30,0%' PONTUACAO_MAXIMA,
       CONVERT(DECIMAL(10,2),ROUND(ISNULL(SUM(tqp.NU_PONTO), 0) / CASE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) WHEN 0 THEN 1 ELSE COUNT(tqp.CEA_QUESTIONARIO_EMPRESA) END, 2, 1)) PONTUACAO_OBTIDA
  FROM TBL_QUESTIONARIO_PONTUACAO tqp
 INNER JOIN TBL_QUESTIONARIO tq ON tq.CDA_QUESTIONARIO = tqp.CEA_QUESTIONARIO
 INNER JOIN TBL_REL_TURMA_QUESTIONARIO trtq ON trtq.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe ON tqe.CEA_QUESTIONARIO = tq.CDA_QUESTIONARIO
 INNER JOIN TBL_EMP_CADASTRO tec ON tec.CDA_EMP_CADASTRO = tqe.CEA_EMP_CADASTRO
 INNER JOIN TBL_TURMA_EMP tte ON tte.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_GRUPOEMPRESA tg ON tg.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_CIDADE tc ON tc.CDA_CIDADE = tte.CEA_CIDADE AND tc.CDA_CIDADE = tte.CEA_CIDADE_CONTATO
 INNER JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL trcer ON trcer.CEA_CIDADE = tc.CDA_CIDADE
 INNER JOIN TBL_QUESTIONARIO_EMPRESA tqe2 ON tqe2.CEA_EMP_CADASTRO = tec.CDA_EMP_CADASTRO
 INNER JOIN TBL_ETAPA te ON te.CDA_ETAPA = tqe2.CEA_ETAPA
 WHERE tqp.CEA_CRITERIO = 82
   AND trtq.CEA_TURMA = @Turma
   AND tec.TX_NOME_FANTASIA LIKE '%' + @NomeFantasia + '%' 
   AND tec.TX_CPF_CNPJ like '%' + @CPF_CNPJ + '%'  
   AND ISNULL(tte.CEA_CATEGORIA,0) = COALESCE(@Categoria, ISNULL(tte.CEA_CATEGORIA,0))  
   AND ISNULL(tg.CEA_GRUPO, 0) = COALESCE(@Grupo, ISNULL(tg.CEA_GRUPO, 0))  
   AND ISNULL(tte.CEA_ESTADO,0) = COALESCE(@Estado, ISNULL(tte.CEA_ESTADO,0))  
   AND ISNULL(tc.CEA_ESTADO_REGIAO, 0) = COALESCE(@EstadoRegiao, ISNULL(tc.CEA_ESTADO_REGIAO, 0))  
   AND ISNULL(tc.CDA_CIDADE,0) = COALESCE(@Cidade, ISNULL(tc.CDA_CIDADE,0))  
   AND ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0) = COALESCE(@EscritorioRegional, ISNULL(trcer.CEA_ESCRITORIO_REGIONAL, 0))   
   AND tqe.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 6 ELSE tqe.CEA_QUESTIONARIO END
   AND tqe2.CEA_QUESTIONARIO = CASE @PremioEspecial WHEN 1 THEN 13 ELSE tqe2.CEA_QUESTIONARIO END

RETURN  
END  
    
--    
