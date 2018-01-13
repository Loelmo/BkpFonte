/*   
------------------------------------------------------------------------------------------   
Procedure...............: STP_SelecionaEmpresaCadastroPorId
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_EMP_CADASTRO
Procedures utilizadas ..:   
Criada por..............: Fernando Carvalho
Data criacao............: 09/01/2011 
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/

DECLARE @NAME_PROCEDURE VARCHAR(250) = 'STP_SelecionaEmpresaCadastroPorId'

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(@NAME_PROCEDURE) and sysstat & 0xf = 4)
BEGIN
  EXEC ('CREATE PROCEDURE [dbo].['+ @NAME_PROCEDURE +'] AS')
END
GO

    
ALTER PROCEDURE [dbo].STP_SelecionaEmpresaCadastroPorId
(
 @nIdEmpresaCadastro INT 
)
As   
BEGIN     
SET NOCOUNT ON  

  SELECT tec.CDA_EMP_CADASTRO,
		 tec.TX_RAZAO_SOCIAL,
		 tec.TX_NOME_FANTASIA,
		 tec.TX_CPF_CNPJ,
		 tec.FL_PESSOA_JURIDICA,
		 tec.FL_ATIVO,
		 tec.DT_ABERTURA_EMPRESA,
		 tec.FL_PARTICIPOU_MPE_2006,
		 tec.FL_PARTICIPOU_MPE_2007,
		 tec.FL_PARTICIPOU_MPE_2008,
		 tec.FL_PARTICIPOU_MPE_2009,
		 tec.FL_PARTICIPOU_MPE_2010,
		 tec.FL_PARTICIPOU_MPE_2011,
 		 tec.CEA_ESTADO
    FROM TBL_EMP_CADASTRO tec 
   WHERE tec.CDA_EMP_CADASTRO = @nIdEmpresaCadastro;
  
RETURN  
END  
    
--    
