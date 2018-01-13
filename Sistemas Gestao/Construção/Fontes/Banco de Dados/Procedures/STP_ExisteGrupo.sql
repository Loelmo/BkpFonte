SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[STP_ExisteGrupo]
(
 @sNome VARCHAR(200),
 @nCEA_PROGRAMA INT
)
As    
BEGIN     

SET NOCOUNT ON  

  SELECT  COUNT(CDA_GRUPO)
   FROM TBL_ADM_GRUPO
  WHERE TX_GRUPO = @sNome AND CEA_PROGRAMA = @nCEA_PROGRAMA;
  
RETURN  

END  
    
--


