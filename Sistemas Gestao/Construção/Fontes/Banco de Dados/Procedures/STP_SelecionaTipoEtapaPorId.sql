USE [Sistema Gestao]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


    
CREATE PROCEDURE [dbo].[STP_SelecionaTipoEtapaPorId]
(
 @nCDA_TIPO_ETAPA INT 
)
As   
BEGIN     
SET NOCOUNT ON  

	 
 SELECT	CDA_TIPO_ETAPA,
 		TX_TIPO_ETAPA,
  		CEA_PROGRAMA,
  	 	NU_ORDEM_FLUXO,
  		FL_INATIVA_ETAPAS_ANTERIORES,
  		FL_TIPO_ETAPA_NACIONAL
   FROM dbo.TBL_TIPO_ETAPA 
   WHERE CDA_TIPO_ETAPA = @nCDA_TIPO_ETAPA
   ORDER BY NU_ORDEM_FLUXO
	
  
RETURN  
END  
    
--
