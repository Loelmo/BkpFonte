
/****** Object:  StoredProcedure [dbo].[STP_SelecionaEstadosPorTurma]    Script Date: 02/18/2011 11:14:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[STP_SelecionaEstadosPorTurma]
(
 @nIdTurma INT,
 @nIdTipoEtapa INT
)
As    
BEGIN     
SET NOCOUNT ON  

   	SELECT te2.CDA_ESTADO, 
   		   te2.TX_SIGLA, 
   		   te2.TX_ESTADO, 
   		   te2.TX_STYLE, 
   		   te2.TX_EMAIL,
   	       te2.FL_ATIVO, 
   	       te2.COD_SIACWEB
   	  FROM TBL_ETAPA te 
   	 INNER JOIN TBL_TURMA tt ON tt.CDA_TURMA = te.CEA_TURMA
   	 INNER JOIN TBL_ESTADO te2 ON te.CEA_ESTADO = te2.CDA_ESTADO OR TE.CEA_ESTADO IS NULL
   	 WHERE te.FL_ATIVO = 1 
   	   AND te.CEA_TIPO_ETAPA = @nIdTipoEtapa --11
   	   AND tt.CDA_TURMA = @nIdTurma
     ORDER BY te2.TX_ESTADO
  
RETURN  
END  
    
--
