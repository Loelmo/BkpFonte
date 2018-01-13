alter PROCEDURE [dbo].[STP_InsereEscritorioRegional]    
 @nCDA_ESCRITORIO_REGIONAL int OUTPUT,    
 @nCEA_ESTADO INT,  
 @sTX_ESCRITORIO_REGIONAL VARCHAR(200),    
 @bFL_ATIVO BIT,  
 @nCEA_TURMA INT  
   
As      
BEGIN       

    
SET NOCOUNT ON    
    
INSERT INTO TBL_ESCRITORIO_REGIONAL  
           (CEA_ESTADO  
           ,TX_ESCRITORIO_REGIONAL  
           ,FL_ATIVO  
           ,CEA_TURMA)  
     VALUES  
           (@nCEA_ESTADO,  
		   @sTX_ESCRITORIO_REGIONAL,    
		   @bFL_ATIVO,  
		   @nCEA_TURMA)  
    
 SET @nCDA_ESCRITORIO_REGIONAL = @@IDENTITY;    
  
RETURN    
END  