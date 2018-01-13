
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaTurmaCompativel
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_TURMA
Procedures utilizadas ..:   
Criada por..............: Diogo T. Machado
Data criacao............: 12/01/2011  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    
DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaTurmaCompativel'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

ALTER PROCEDURE [dbo].STP_SelecionaTurmaCompativel
(
 @nIdTurma int
)
As    
BEGIN     
SET NOCOUNT ON  

	SELECT 
	   T.CEA_PROGRAMA,
       T.CDA_TURMA,
       T.TX_CICLO,
       T.FL_ATIVO,
       T.DT_CADASTRO,
       T.TX_DESCRICAO,
       T.CEA_ESTADO,
       T.CEA_ESTADO,
       T.FL_PRIVADA
  FROM TBL_TURMA T
  JOIN TBL_ETAPA ET ON ET.CEA_TURMA = T.CDA_TURMA
  JOIN TBL_TIPO_ETAPA TP ON TP.CDA_TIPO_ETAPA = ET.CEA_TIPO_ETAPA 
  WHERE T.CEA_PROGRAMA = (SELECT TAUX.CEA_PROGRAMA  FROM TBL_TURMA TAUX WHERE TAUX.CDA_TURMA = @nIdturma)
  AND EXISTS (SELECT 1 
                FROM TBL_TURMA TAUX 
                JOIN TBL_ETAPA ETAUX ON ETAUX.CEA_TURMA = TAUX.CDA_TURMA
  				JOIN TBL_TIPO_ETAPA TPAUX ON TPAUX.CDA_TIPO_ETAPA = ETAUX.CEA_TIPO_ETAPA
                WHERE TPAUX.CDA_TIPO_ETAPA = TP.CDA_TIPO_ETAPA
                  AND ETAUX.FL_ATIVO = ET.FL_ATIVO)  
  
RETURN  
END  
    
--    
