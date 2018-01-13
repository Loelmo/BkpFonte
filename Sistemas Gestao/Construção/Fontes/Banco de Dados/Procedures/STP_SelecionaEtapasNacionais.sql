
/****** Object:  StoredProcedure [dbo].[STP_SelecionaEtapasNacionais]    Script Date: 02/18/2011 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[STP_SelecionaEtapasNacionais]  
(  
 @nCEA_TURMA INT
)  
As      
BEGIN       
SET NOCOUNT ON 
   
SELECT DISTINCT
	   E.CDA_ETAPA
      ,E.TX_ETAPA
      ,E.CEA_TURMA
      ,E.FL_ATIVO
      ,E.CEA_TIPO_ETAPA
      ,E.CEA_ESTADO
      ,TE.TX_TIPO_ETAPA
  FROM TBL_ETAPA E
  INNER JOIN TBL_TIPO_ETAPA TE ON TE.CDA_TIPO_ETAPA = E.CEA_TIPO_ETAPA
  INNER JOIN TBL_TURMA tt ON tt.CDA_TURMA = E.CEA_TURMA
    
  WHERE tt.CDA_TURMA = @nCEA_TURMA
RETURN    
END
