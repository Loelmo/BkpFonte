using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.Ent;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Vinit.SG.Common;
using System.Data;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa uma Pergunta Resposta
    /// </summary>
    public class DalPerguntaResposta
    {

        /// <summary>
        /// Retorna Proxima Pergunta de um Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public List<EntPerguntaResposta> ObterRespostasPorPergunta(Int32 IdPergunta, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaRespostasPorPergunta");
            db.AddInParameter(dbCommand, "@nIdPergunta", DbType.Int32, IdPergunta);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna Proxima Pergunta de um Questionario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public List<EntPerguntaResposta> ObterRespostasDesempenhoGlobal(Int32 IdPergunta, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaRespostasDesempenhoGlobal");
            db.AddInParameter(dbCommand, "@nIdPergunta", DbType.Int32, IdPergunta);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    List<EntPerguntaResposta> listEntReturn = new List<EntPerguntaResposta>();
                    EntPerguntaResposta entReturn;

                    Double Total, Parcial, Resultado = 0;

                    while (dtrDados.Read())
                    {
                        entReturn = new EntPerguntaResposta();

                        Total = ObjectUtils.ToDouble(dtrDados["TOTAL"]);
                        Parcial = ObjectUtils.ToDouble(dtrDados["PARCIAL"]);
                        Resultado =  Math.Round(Parcial * 100 / Total, 2);

                        entReturn.PerguntaResposta = Resultado.ToString() + "% (" +
                                                     ObjectUtils.ToString(dtrDados["PARCIAL"]) + ") - " + 
                                                     ObjectUtils.ToString(dtrDados["LBL_RESPOSTA"]);
                        listEntReturn.Add(entReturn);
                    }

                    dtrDados.Close();

                    return listEntReturn;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna PerguntaResposta
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public EntPerguntaResposta ObterPorId(Int32 IdPerguntaResposta, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaPerguntaRespostaPorId");
            db.AddInParameter(dbCommand, "@nIdPerguntaResposta", DbType.Int32, IdPerguntaResposta);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Popula Questionario Empresa, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        private List<EntPerguntaResposta> Popular(DbDataReader dtrDados)
        {
            List<EntPerguntaResposta> listEntReturn = new List<EntPerguntaResposta>();
            EntPerguntaResposta entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntPerguntaResposta();

                    entReturn.IdPerguntaResposta = ObjectUtils.ToInt(dtrDados["CDA_RESPOSTA"]);
                    entReturn.Ordem = ObjectUtils.ToInt(dtrDados["NU_ORDEM"]);
                    entReturn.Pergunta.IdPergunta = ObjectUtils.ToInt(dtrDados["CEA_PERGUNTA"]);
                    entReturn.PerguntaResposta = ObjectUtils.ToString(dtrDados["LBL_RESPOSTA"]);
                    entReturn.Ponto = ObjectUtils.ToInt(dtrDados["NU_PONTO"]);
                    entReturn.PossuiJustificativa = ObjectUtils.ToBoolean(dtrDados["FL_POSSUI_JUSTIFICATIVA"]);
                    entReturn.RespostaAutomatica = ObjectUtils.ToString(dtrDados["TX_RESPOSTA_AUTOMATICA"]);
                    entReturn.Valor1 = ObjectUtils.ToString(dtrDados["LBL_VALOR_01"]);
                    entReturn.Valor2 = ObjectUtils.ToString(dtrDados["LBL_VALOR_02"]);
                    entReturn.Valor3 = ObjectUtils.ToString(dtrDados["LBL_VALOR_03"]);
                    entReturn.Valor4 = ObjectUtils.ToString(dtrDados["LBL_VALOR_04"]);
                    entReturn.Valor5 = ObjectUtils.ToString(dtrDados["LBL_VALOR_05"]);
                    entReturn.Valor6 = ObjectUtils.ToString(dtrDados["LBL_VALOR_06"]);
                    entReturn.Valor7 = ObjectUtils.ToString(dtrDados["LBL_VALOR_07"]);
                    entReturn.Valor8 = ObjectUtils.ToString(dtrDados["LBL_VALOR_08"]);
                    entReturn.Valor9 = ObjectUtils.ToString(dtrDados["LBL_VALOR_09"]);
                    entReturn.Valor10 = ObjectUtils.ToString(dtrDados["LBL_VALOR_10"]);
                    listEntReturn.Add(entReturn);
                }

                dtrDados.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listEntReturn;
        }


        /// <summary>
        /// Popula Questionario Empresa, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        private List<EntPerguntaResposta> Popular(DbDataReader dtrDados, DbTransaction transaction, Database db)
        {
            List<EntPerguntaResposta> listEntReturn = new List<EntPerguntaResposta>();
            EntPerguntaResposta entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntPerguntaResposta();

                    entReturn.IdPerguntaResposta = ObjectUtils.ToInt(dtrDados["CDA_RESPOSTA"]);
                    entReturn.Pergunta.IdPergunta = ObjectUtils.ToInt(dtrDados["CEA_PERGUNTA"]);
                    entReturn.PossuiJustificativa = ObjectUtils.ToBoolean(dtrDados["FL_POSSUI_JUSTIFICATIVA"]);
                    entReturn.PerguntaResposta = ObjectUtils.ToString(dtrDados["LBL_RESPOSTA"]);
                    entReturn.Valor1 = ObjectUtils.ToString(dtrDados["LBL_VALOR_01"]);
                    entReturn.Valor2 = ObjectUtils.ToString(dtrDados["LBL_VALOR_02"]);
                    entReturn.Valor3 = ObjectUtils.ToString(dtrDados["LBL_VALOR_03"]);
                    entReturn.Valor4 = ObjectUtils.ToString(dtrDados["LBL_VALOR_04"]);
                    entReturn.Valor5 = ObjectUtils.ToString(dtrDados["LBL_VALOR_05"]);
                    entReturn.Valor6 = ObjectUtils.ToString(dtrDados["LBL_VALOR_06"]);
                    entReturn.Valor7 = ObjectUtils.ToString(dtrDados["LBL_VALOR_07"]);
                    entReturn.Valor8 = ObjectUtils.ToString(dtrDados["LBL_VALOR_08"]);
                    entReturn.Valor9 = ObjectUtils.ToString(dtrDados["LBL_VALOR_09"]);
                    entReturn.Valor10 = ObjectUtils.ToString(dtrDados["LBL_VALOR_10"]);
                    entReturn.Ordem = ObjectUtils.ToInt(dtrDados["NU_ORDEM"]);
                    entReturn.Ponto = ObjectUtils.ToInt(dtrDados["NU_PONTO"]);
                    entReturn.RespostaAutomatica = ObjectUtils.ToString(dtrDados["TX_RESPOSTA_AUTOMATICA"]);
                    listEntReturn.Add(entReturn);
                }

                dtrDados.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listEntReturn;
        }
    }
}
