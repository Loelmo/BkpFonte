/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_InsereEtapaResumo
  
Tabelas utilizadas......: TBL_CIDADE
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 17/12/2010  
  
  
Ultimas alteraes:  
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   
---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_InsereEtapaResumo'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_InsereEtapaResumo
 @nCDA_RESUMO_ETAPA int OUTPUT,  
 @nCEA_ETAPA INT,
 @sTX_ACAO VARCHAR(200),
 @dtDT_ALTERACAO datetime,
 @nCEA_USUARIO INT
 
As    
BEGIN     
  
SET NOCOUNT ON  
  
INSERT INTO [TBL_ETAPA_RESUMO]
           ([CEA_ETAPA]
           ,[TX_ACAO]
           ,[DT_ALTERACAO]
           ,[CEA_USUARIO])
     VALUES
           (@nCEA_ETAPA
           ,@sTX_ACAO
           ,@dtDT_ALTERACAO
           ,@nCEA_USUARIO)
  
 SET @nCDA_RESUMO_ETAPA = @@IDENTITY;  

RETURN  
END  
   
   