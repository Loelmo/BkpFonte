/* 
------------------------------------------------------------------------------------------ 
Procedure...............: STP_AtualizaRelatorioGeradoPorProtocolo

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
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_AtualizaRelatorioGeradoPorProtocolo'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_AtualizaRelatorioGeradoPorProtocolo 
 @TX_PROTOCOLO VARCHAR(200),
 @FL_RELATORIO_GERADO BIT 
   
As    
BEGIN     
  
SET NOCOUNT ON  
  
UPDATE TBL_QUESTIONARIO_EMPRESA
   SET FL_RELATORIO_GERADO = @FL_RELATORIO_GERADO
 WHERE TX_PROTOCOLO = @TX_PROTOCOLO  
  
  
RETURN  
END  