/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_AtualizaQuestionarioEmpresa

Tabelas utilizadas......: TBL_QUESTIONARIO_EMPRESA
Procedures utilizadas ..: 
Criada por..............: Fernando Carvalho
Data criacao............: 11/03/11

Ultimas alteracoes:
Data		Nome			Descricao 
---------- ---------------- -------------------------------------------------- 
dd/mm/aaaa XXXXXXXX			Alteracao de parametros 
---------- ---------------- -------------------------------------------------- 
*/  
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtualizaQuestionarioEmpresa'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].[STP_AtualizaQuestionarioEmpresa]    
    @nCEA_QUESTIONARIO_EMPRESA INT,    
 @nCEA_QUESTIONARIO INT,    
 @CEA_EMPRESA_CADASTRO INT,    
 @CEA_ETAPA INT,    
 @CEA_PROGRAMA INT,    
 @FL_LEITURA BIT,    
 @FL_ATIVO BIT,    
 @FL_PASSA_PROXIMA_ETAPA BIT,    
 @FL_PREENCHE_QUESTIONARIO BIT,    
 @FL_SINCRONIZADO_SIAC BIT,    
 @TOTAL_PONTUACAO DECIMAL(18,5),    
 @DT_ALTERACAO DATETIME,    
 @DT_CADASTRO DATETIME,    
 @MOTIVO_EXCLUIU NTEXT,    
 @MOTIVO_VENCEU NTEXT,    
 @TX_PROTOCOLO VARCHAR(200),    
 @nCEA_USUARIO INT,    
 @FL_MARCA_QUESTOES_ESPECIAIS BIT,  
 @FL_ENVIAR_QUESTIONARIO BIT   
     
As      
BEGIN       
    
SET NOCOUNT ON    
    
UPDATE [TBL_QUESTIONARIO_EMPRESA]    
   SET [CEA_PROGRAMA] = @CEA_PROGRAMA    
      ,[CEA_EMP_CADASTRO] = @CEA_EMPRESA_CADASTRO    
      ,[DT_CADASTRO] = @DT_CADASTRO    
      ,[FL_ATIVO] = @FL_ATIVO    
      ,[TX_PROTOCOLO] = @TX_PROTOCOLO    
      ,[CEA_USUARIO] = @nCEA_USUARIO    
      ,[DT_ALTERACAO] = @DT_ALTERACAO    
      ,[TX_MOTIVO_VENCEU] = @MOTIVO_VENCEU    
      ,[TX_MOTIVO_EXCLUIU] = @MOTIVO_EXCLUIU    
      ,[FL_LEITURA] = @FL_LEITURA    
      ,[NU_TOTAL_PONTUACAO] = @TOTAL_PONTUACAO    
      ,[FL_SINCRONIZADO_SIAC] = @FL_SINCRONIZADO_SIAC    
      ,[CEA_ETAPA] = @CEA_ETAPA    
      ,[FL_PASSA_PROXIMA_ETAPA] = @FL_PASSA_PROXIMA_ETAPA    
      ,[CEA_QUESTIONARIO] = @nCEA_QUESTIONARIO    
      ,[FL_PREENCHE_QUESTIONARIO] = @FL_PREENCHE_QUESTIONARIO    
      ,FL_MARCA_QUESTOES_ESPECIAIS_FGA = @FL_MARCA_QUESTOES_ESPECIAIS    
      ,FL_ENVIAR_QUESTIONARIO = @FL_ENVIAR_QUESTIONARIO  
 WHERE CDA_QUESTIONARIO_EMPRESA = @nCEA_QUESTIONARIO_EMPRESA    
    
    
RETURN    
END 