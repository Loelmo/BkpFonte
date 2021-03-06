USE [SISTEMA GESTAO_desenv]
GO
/****** Object:  StoredProcedure [dbo].[STP_AtualizaNoticia]    Script Date: 02/17/2011 18:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[STP_AtualizaNoticia]
 @nCDA_NOTICIA INT,  
 @sTX_TITULO NTEXT,  
 @sTX_CONTEUDO NTEXT,  
 @sTX_IMAGEM_URL NTEXT,
 @DT_ALTERACAO DATETIME,
 @nCEA_ESTADO INT,
 @nCEA_PROGRAMA INT,
 @nCEA_TURMA INT,
 @bFL_ATIVO BIT,
 @bFL_USUARIO_ADMINISTRATIVO BIT,
 @DT_VIGENCIA_FIM DATETIME
	           
As  
BEGIN   

SET NOCOUNT ON

UPDATE [TBL_NOTICIA]
   SET [CEA_ESTADO] = @nCEA_ESTADO
      ,[CEA_PROGRAMA] = @nCEA_PROGRAMA
      ,[CEA_TURMA] = @nCEA_TURMA
      ,[TX_TITULO] = @sTX_TITULO
      ,[TX_CONTEUDO] = @sTX_CONTEUDO
      ,[DT_ALTERACAO] = @DT_ALTERACAO
      ,[FL_ATIVO] = @bFL_ATIVO
      ,[FL_USUARIO_ADMINISTRATIVO] = @bFL_USUARIO_ADMINISTRATIVO
      ,[TX_IMAGEM_URL] = @sTX_IMAGEM_URL
      ,DT_VIGENCIA_FIM = @DT_VIGENCIA_FIM
 WHERE CDA_NOTICIA = @nCDA_NOTICIA

RETURN
END
