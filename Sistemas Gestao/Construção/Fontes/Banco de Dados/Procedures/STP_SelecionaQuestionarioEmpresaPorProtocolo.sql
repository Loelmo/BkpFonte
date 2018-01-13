
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaQuestionarioEmpresaPorProtocolo
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_QUESTIONARIO_EMPRESA
Procedures utilizadas ..:   
Criada por..............: Robinson Campos
Data criacao............: 26/01/2011  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaQuestionarioEmpresaPorProtocolo'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaQuestionarioEmpresaPorProtocolo
(
 @sTX_PROTOCOLO NVARCHAR(50)  
)
As    
BEGIN     

SET NOCOUNT ON  

	SELECT  Top 1 
		CDA_QUESTIONARIO_EMPRESA,
		CEA_PROGRAMA,
		CEA_EMP_CADASTRO,
		DT_CADASTRO,
		FL_ATIVO,
		ISNULL(TX_PROTOCOLO, '') [TX_PROTOCOLO],
		CEA_USUARIO,
		DT_ALTERACAO,
		TX_MOTIVO_VENCEU,
		TX_MOTIVO_EXCLUIU,
		FL_LEITURA,
		NU_TOTAL_PONTUACAO,
		FL_SINCRONIZADO_SIAC,
		CEA_ETAPA,
		FL_PASSA_PROXIMA_ETAPA,
		CEA_QUESTIONARIO,
		FL_PREENCHE_QUESTIONARIO,
		CEA_QUESTIONARIO_EMPRESA_PAI,
		NU_TOTAL_PONTUACAO_AVALIADOR,
		FL_PARA_AVALIACAO,
		FL_ENVIAR_QUESTIONARIO,
		FL_RELATORIO_GERADO
	FROM 
		TBL_QUESTIONARIO_EMPRESA 
	WHERE   
		TX_PROTOCOLO = @sTX_PROTOCOLO  

RETURN  

END  
    
--    
