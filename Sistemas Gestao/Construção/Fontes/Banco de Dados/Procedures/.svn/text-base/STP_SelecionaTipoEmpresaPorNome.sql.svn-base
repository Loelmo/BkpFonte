
/****** Object:  StoredProcedure [dbo].[STP_SelecionaTipoEmpresaPorId]    Script Date: 02/18/2011 14:06:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[STP_SelecionaTipoEmpresaPorNome]
(
 @sTipoEmpresa VARCHAR(255)
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT
		CDA_TIPO_EMPRESA,
		TX_TIPO_EMPRESA,
		COD_SIACWEB
	FROM
		TBL_TIPO_EMP
	WHERE TX_TIPO_EMPRESA = @sTipoEmpresa;
	

  
RETURN  
END  
    
--
