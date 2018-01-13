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
    /// Classe de Dados que representa um Questionario Empresa
    /// </summary>
    public class DalPergunta
    {

        /// <summary>
        /// Retorna Proxima Pergunta de um Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public EntPergunta ObterProximaPerguntaPorQuestionarioEmpresa(Int32 IdQuestionarioEmpresa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaProximaPerguntaPorQuestionarioEmpresa");
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO_EMPRESA", DbType.Int32, IdQuestionarioEmpresa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados, transaction, db)[0];
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
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public EntPergunta ObterPerguntaProximaPorQuestionarioPergunta(Int32 IdQuestionario, Int32 IdPergunta, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaPerguntaProximaPorQuestionarioPergunta");
            db.AddInParameter(dbCommand, "@nCEA_PERGUNTA", DbType.Int32, IdPergunta);
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, IdQuestionario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados, transaction, db)[0];
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
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public EntPergunta ObterPerguntaAnteriorPorQuestionarioEmpresa(Int32 IdQuestionario, Int32 IdPergunta, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaPerguntaAnteriorPorQuestionarioPergunta");
            db.AddInParameter(dbCommand, "@nCEA_PERGUNTA", DbType.Int32, IdPergunta);
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, IdQuestionario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados, transaction, db)[0];
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
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public EntPergunta ObterPrimeiraPerguntaPorQuestionarioCriterio(Int32 IdQuestionario, Int32 IdCriterio, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaPrimeiraPerguntaPorQuestionarioCriterio");
            db.AddInParameter(dbCommand, "@nCEA_CRITERIO", DbType.Int32, IdCriterio);
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, IdQuestionario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados, transaction, db)[0];
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
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public EntPergunta ObterPerguntaPorId(Int32 IdPergunta, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaPerguntaPorId");
            db.AddInParameter(dbCommand, "@nCEA_PERGUNTA", DbType.Int32, IdPergunta);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados, transaction, db)[0];
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
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public List<EntPergunta> ObterPerguntasPorQuestionario(Int32 IdQuestionario, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaPerguntasPorQuestionario");
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, IdQuestionario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados, transaction, db);
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
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public List<EntPergunta> ObterResumoPorQuestionarioEmpresaTurma(Int32 IdQuestionario, Int32 IdEmpresaCadastro, Int32 IdTurma, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaResumoPerguntasPorQuestionarioEmpresaTurma");
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, IdQuestionario);
            db.AddInParameter(dbCommand, "@nCEA_EMPRESA_CADASTRO", DbType.Int32, IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCustom(dtrDados, transaction, db);
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
        private List<EntPergunta> Popular(DbDataReader dtrDados, DbTransaction transaction, Database db)
        {
            List<EntPergunta> listEntReturn = new List<EntPergunta>();
            EntPergunta entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntPergunta();
                    
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.Criterio.IdCriterio = ObjectUtils.ToInt(dtrDados["CEA_CRITERIO"]);
                    entReturn.Glossario = ObjectUtils.ToString(dtrDados["TX_GLOSSARIO"]);
                    entReturn.IdPergunta = ObjectUtils.ToInt(dtrDados["CDA_PERGUNTA"]);
                    entReturn.Ordem = ObjectUtils.ToInt(dtrDados["NU_ORDEM"]);
                    entReturn.Pergunta = ObjectUtils.ToString(dtrDados["TX_PERGUNTA"]);
                    entReturn.SaibaMais = ObjectUtils.ToString(dtrDados["TX_SAIBA_MAIS"]);
                    entReturn.PerguntaInterna = ObjectUtils.ToBoolean(dtrDados["FL_PERGUNTA_INTERNA"]);
                    entReturn.PerguntaTipo.IdPerguntaTipo = ObjectUtils.ToInt(dtrDados["CEA_PERGUNTA_TIPO"]);
                    entReturn.NumeroQuestao = ObjectUtils.ToString(dtrDados["NU_QUESTAO"]);
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
        private List<EntPergunta> PopularCustom(DbDataReader dtrDados, DbTransaction transaction, Database db)
        {
            List<EntPergunta> listEntReturn = new List<EntPergunta>();
            EntPergunta entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntPergunta();

                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.Criterio.IdCriterio = ObjectUtils.ToInt(dtrDados["CEA_CRITERIO"]);
                    entReturn.Glossario = ObjectUtils.ToString(dtrDados["TX_GLOSSARIO"]);
                    entReturn.IdPergunta = ObjectUtils.ToInt(dtrDados["CDA_PERGUNTA"]);
                    entReturn.Ordem = ObjectUtils.ToInt(dtrDados["NU_ORDEM"]);
                    entReturn.Pergunta = ObjectUtils.ToString(dtrDados["TX_PERGUNTA"]);
                    entReturn.SaibaMais = ObjectUtils.ToString(dtrDados["TX_SAIBA_MAIS"]);
                    entReturn.PerguntaInterna = ObjectUtils.ToBoolean(dtrDados["FL_PERGUNTA_INTERNA"]);
                    entReturn.PerguntaTipo.IdPerguntaTipo = ObjectUtils.ToInt(dtrDados["CEA_PERGUNTA_TIPO"]);
                    entReturn.NumeroQuestao = ObjectUtils.ToString(dtrDados["NU_QUESTAO"]);
                    entReturn.QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta = ObjectUtils.ToInt(dtrDados["FL_EMPRESA_PREENCHEU"]);
                    entReturn.QuestionarioEmpresaResposta.QuestionarioEmpresa.Questionario.IdQuestionario = ObjectUtils.ToInt(dtrDados["CEA_QUESTIONARIO"]);
                    entReturn.QuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                    entReturn.QuestionarioEmpresaResposta.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CEA_EMP_CADASTRO"]);
                    entReturn.QuestionarioEmpresaResposta.QuestionarioEmpresa.Etapa.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                    if (ObjectUtils.ToInt(dtrDados["FL_EMPRESA_PREENCHEU"]) == 0)
                    {
                        entReturn.QuestionarioEmpresaResposta.RespostaBool = false;
                    }
                    else
                    {
                        entReturn.QuestionarioEmpresaResposta.RespostaBool = true;
                    }
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
