alter PROCEDURE [dbo].[STP_InsereQuestionarioEmpresa]      
    @nCEA_QUESTIONARIO_EMPRESA int OUTPUT,      
 @nCEA_QUESTIONARIO INT,      
 @CEA_EMPRESA_CADASTRO INT,      
 @CEA_ETAPA INT,      
 @CEA_PROGRAMA INT,      
 @FL_LEITURA BIT,      
 @FL_ATIVO BIT,      
 @FL_PASSA_PROXIMA_ETAPA BIT,      
 @FL_PREENCHE_QUESTIONARIO BIT,      
 @FL_SINCRONIZADO_SIAC BIT,      
 @TOTAL_PONTUACAO DECIMAL(18,5),      
 @DT_ALTERACAO DATETIME,      
 @DT_CADASTRO DATETIME,      
 @MOTIVO_EXCLUIU NTEXT,      
 @MOTIVO_VENCEU NTEXT,      
 @TX_PROTOCOLO VARCHAR(200),      
 @nCEA_USUARIO INT,    
 @FL_PARA_AVALIACAO BIT,
 @FL_ENVIAR_QUESTIONARIO bit
       
As        
BEGIN         
      
SET NOCOUNT ON      
      
INSERT INTO [TBL_QUESTIONARIO_EMPRESA]      
           ([CEA_PROGRAMA]      
           ,[CEA_EMP_CADASTRO]      
           ,[DT_CADASTRO]      
           ,[FL_ATIVO]      
           ,[TX_PROTOCOLO]      
           ,[CEA_USUARIO]      
           ,[DT_ALTERACAO]      
           ,[TX_MOTIVO_VENCEU]      
           ,[TX_MOTIVO_EXCLUIU]      
           ,[FL_LEITURA]      
           ,[NU_TOTAL_PONTUACAO]      
           ,[FL_SINCRONIZADO_SIAC]      
           ,[CEA_ETAPA]      
           ,[FL_PASSA_PROXIMA_ETAPA]      
           ,[CEA_QUESTIONARIO]      
           ,[FL_PREENCHE_QUESTIONARIO]    
           ,[FL_PARA_AVALIACAO]
           ,FL_ENVIAR_QUESTIONARIO)    
     VALUES      
           (@CEA_PROGRAMA      
           ,@CEA_EMPRESA_CADASTRO      
           ,@DT_CADASTRO      
           ,@FL_ATIVO      
           ,@TX_PROTOCOLO      
           ,@nCEA_USUARIO      
           ,@DT_ALTERACAO      
           ,@MOTIVO_VENCEU      
           ,@MOTIVO_EXCLUIU      
           ,@FL_LEITURA      
           ,@TOTAL_PONTUACAO      
           ,@FL_SINCRONIZADO_SIAC      
           ,@CEA_ETAPA      
           ,@FL_PASSA_PROXIMA_ETAPA      
           ,@nCEA_QUESTIONARIO      
           ,@FL_PREENCHE_QUESTIONARIO    
           ,@FL_PARA_AVALIACAO
           ,@FL_ENVIAR_QUESTIONARIO)      
      
      
 SET @nCEA_QUESTIONARIO_EMPRESA = @@IDENTITY;      
      
RETURN      
END 