/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_InsereCidade  
  
Tabelas utilizadas......: TBL_CIDADE
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 08/12/2010  
  
  
Ultimas alteraes:  
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   
---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_InsereCidade'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_InsereCidade
 @nCDA_CIDADE int OUTPUT,  
 @nCEA_ESCRITORIO_REGIONAL INT,
 @nCEA_ESTADO_REGIAO INT,
 @sTX_CIDADE VARCHAR(200),  
 @bFL_ATIVO BIT
 
As    
BEGIN     
  
SET NOCOUNT ON  
  

  
INSERT INTO [TBL_CIDADE]
           ([CEA_ESCRITORIO_REGIONAL]
           ,[CEA_ESTADO_REGIAO]
           ,[TX_CIDADE]
           ,[FL_ATIVO])
     VALUES
           ( @nCEA_ESCRITORIO_REGIONAL,
			 @nCEA_ESTADO_REGIAO,
			 @sTX_CIDADE,
			 @bFL_ATIVO)

  
 SET @nCDA_CIDADE = @@IDENTITY;  
  

  
RETURN  
END  
   
   