
/****** Object:  StoredProcedure [dbo].[STP_SelecionaCategoria]    Script Date: 02/18/2011 14:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[STP_SelecionaCategoria]
As    
BEGIN     
SET NOCOUNT ON  

SELECT [CDA_CATEGORIA]
      ,[TX_CATEGORIA]
      ,[FL_ATIVO]
      ,[FL_ACEITA_CPF]
  FROM [TBL_CATEGORIA]
	WHERE FL_ATIVO = 'TRUE'
ORDER BY TX_CATEGORIA
RETURN  
END  
    
--
