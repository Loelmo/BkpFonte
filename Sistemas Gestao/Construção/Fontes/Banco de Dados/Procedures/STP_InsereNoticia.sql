USE [SISTEMA GESTAO_desenv]
GO
/****** Object:  StoredProcedure [dbo].[STP_InsereNoticia]    Script Date: 02/17/2011 18:38:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[STP_InsereNoticia]
 @nCDA_NOTICIA int OUTPUT,  
 @sTX_TITULO NTEXT,  
 @sTX_CONTEUDO NTEXT,  
 @sTX_IMAGEM_URL NTEXT,
 @DT_CADASTRO DATETIME,
 @DT_ALTERACAO DATETIME,
 @nCEA_ESTADO INT,
 @nCEA_PROGRAMA INT,
 @nCEA_TURMA INT,
 @bFL_ATIVO BIT,
 @bFL_USUARIO_ADMINISTRATIVO BIT,
 @DT_VIGENCIA_FIM DATETIME
 
AS    
BEGIN     
  
SET NOCOUNT ON  
  
INSERT INTO [TBL_NOTICIA]
           ([CEA_ESTADO]
           ,[CEA_PROGRAMA]
           ,[CEA_TURMA]
           ,[TX_TITULO]
           ,[TX_CONTEUDO]
           ,[DT_CADASTRO]
           ,[DT_ALTERACAO]
           ,[FL_ATIVO]
           ,[FL_USUARIO_ADMINISTRATIVO]
           ,[TX_IMAGEM_URL]
           ,DT_VIGENCIA_FIM)
     VALUES
           (@nCEA_ESTADO
           ,@nCEA_PROGRAMA
           ,@nCEA_TURMA
           ,@sTX_TITULO
           ,@sTX_CONTEUDO
           ,@DT_CADASTRO
           ,@DT_ALTERACAO
           ,@bFL_ATIVO
           ,@bFL_USUARIO_ADMINISTRATIVO
           ,@sTX_IMAGEM_URL
           ,@DT_VIGENCIA_FIM)

  
 SET @nCDA_NOTICIA = @@IDENTITY;  
  

  
RETURN  
END
