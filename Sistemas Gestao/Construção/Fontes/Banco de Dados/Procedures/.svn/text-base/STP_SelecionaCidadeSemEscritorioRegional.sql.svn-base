
/*   
------------------------------------------------------------------------------------------      
Procedure...............: STP_SelecionaCidadeSemEscritorioRegional
Funcao..................:  
  
  
Tabelas utilizadas......: TBL_CIDADE
Procedures utilizadas ..:   
Criada por..............: Fabio Senziani
Data criacao............: 08/12/2010  
Parmetros..............:   
    
Data  Nome   Descricao   
---------- ---------------- --------------------------------------------------   
dd/mm/aaaa XXXXXXXX   Alterao de parmetros   

---------- ---------------- --------------------------------------------------   
*/    


ALTER PROCEDURE [dbo].STP_SelecionaCidadeSemEscritorioRegional
(  
@nCEA_ESTADO INT,
@nCEA_ESCRITORIO_REGIONAL INT,
@nCEA_TURMA INT 
)  
As   
BEGIN     
SET NOCOUNT ON  
   
  
 SELECT DISTINCT 
	   C.CDA_CIDADE
      ,CER.CEA_ESCRITORIO_REGIONAL
      ,C.CEA_ESTADO_REGIAO
      ,C.TX_CIDADE  
      ,C.FL_ATIVO
 FROM TBL_CIDADE C  
 LEFT JOIN TBL_REL_CIDADE_ESCRITORIO_REGIONAL CER ON CER.CEA_CIDADE = C.CDA_CIDADE  
 INNER JOIN TBL_ESCRITORIO_REGIONAL ter ON ter.CDA_ESCRITORIO_REGIONAL = CER.CEA_ESCRITORIO_REGIONAL
WHERE CER.CEA_ESCRITORIO_REGIONAL <> @nCEA_ESCRITORIO_REGIONAL 
  AND C.CEA_ESTADO = @nCEA_ESTADO  
  AND ter.CEA_TURMA = @nCEA_TURMA
ORDER BY C.TX_CIDADE
    
  
RETURN  
END  
    
--    
