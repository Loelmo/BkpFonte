
/****** Object:  StoredProcedure [dbo].[STP_InsereBairro]    Script Date: 02/18/2011 14:17:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[STP_InsereTipoEmpresa]
 @nCDA_TIPO_EMPRESA int OUTPUT,  
 @sTX_TIPO_EMPRESA VARCHAR(200),  
 @nCOD_SIACWEB INT
 
As    
BEGIN     
  
SET NOCOUNT ON  
  

  
INSERT INTO [TBL_TIPO_EMP]
           ([TX_TIPO_EMPRESA]
           ,COD_SIACWEB)
     VALUES
           ( @sTX_TIPO_EMPRESA,
			 @nCOD_SIACWEB);

  
 SET @nCDA_TIPO_EMPRESA = @@IDENTITY;  
  
  
RETURN  
END
