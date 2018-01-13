using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa um Turma
    /// </summary>
    public class BllPergunta : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalPergunta dalPergunta = new DalPergunta();

        /// <summary>
        /// Retorna uma entidade de Pergunta
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntPergunta">EntPergunta</list></returns>
        public EntPergunta ObterProximaPerguntaQuestionario(Int32 IdQuestionarioEmpresa, Int32 IdQuestionario)
        {
            EntPergunta objPergunta = new EntPergunta();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objPergunta = dalPergunta.ObterProximaPerguntaPorQuestionarioEmpresa(IdQuestionarioEmpresa, transaction, db);
                    if (objPergunta == null)
                    {
                        objPergunta = dalPergunta.ObterPerguntasPorQuestionario(IdQuestionario, transaction, db)[0];
                    }
                    objPergunta.ListPerguntaResposta = new DalPerguntaResposta().ObterRespostasPorPergunta(objPergunta.IdPergunta, transaction, db);
                    objPergunta.QuestionarioEmpresaResposta = new DalQuestionarioEmpresaResposta().ObterQuestionarioEmpresaRespostaPorPergunta(IdQuestionarioEmpresa, objPergunta.IdPergunta, false, transaction, db);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return objPergunta;
        }

        /// <summary>
        /// Retorna uma entidade de Pergunta
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntPergunta">EntPergunta</list></returns>
        public EntPergunta ObterPerguntaProximaPorQuestionarioPergunta(Int32 IdQuestionario, Int32 IdPergunta)
        {
            EntPergunta objPergunta = new EntPergunta();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objPergunta = dalPergunta.ObterPerguntaProximaPorQuestionarioPergunta(IdQuestionario, IdPergunta, transaction, db);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return objPergunta;
        }

        /// <summary>
        /// Retorna uma entidade de Pergunta
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntPergunta">EntPergunta</list></returns>
        public EntPergunta ObterPerguntaAnteriorPorQuestionarioPergunta(Int32 IdQuestionario, Int32 IdPergunta)
        {
            EntPergunta objPergunta = new EntPergunta();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objPergunta = dalPergunta.ObterPerguntaAnteriorPorQuestionarioEmpresa(IdQuestionario, IdPergunta, transaction, db);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return objPergunta;
        }

        /// <summary>
        /// Retorna uma entidade de Pergunta
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntPergunta">EntPergunta</list></returns>
        public EntPergunta ObterPrimeiraPerguntaPorQuestionarioCriterio(Int32 IdQuestionario, Int32 IdCriterio)
        {
            EntPergunta objPergunta = new EntPergunta();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objPergunta = dalPergunta.ObterPrimeiraPerguntaPorQuestionarioCriterio(IdQuestionario, IdCriterio, transaction, db);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return objPergunta;
        }

        /// <summary>
        /// Retorna uma entidade de Pergunta
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntPergunta">EntPergunta</list></returns>
        public EntPergunta ObterPerguntaPorQuestionarioEmpresaPergunta(Int32 IdQuestionarioEmpresa, Int32 IdPergunta, bool isAvaliador)
        {
            EntPergunta objPergunta = new EntPergunta();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objPergunta = dalPergunta.ObterPerguntaPorId(IdPergunta, transaction, db);
                    if (objPergunta != null)
                    {
                        objPergunta.ListPerguntaResposta = new DalPerguntaResposta().ObterRespostasPorPergunta(objPergunta.IdPergunta, transaction, db);
                        objPergunta.QuestionarioEmpresaResposta = new DalQuestionarioEmpresaResposta().ObterQuestionarioEmpresaRespostaPorPergunta(IdQuestionarioEmpresa, objPergunta.IdPergunta, isAvaliador, transaction, db);
                        if (objPergunta.QuestionarioEmpresaResposta == null)
                        {
                            objPergunta.QuestionarioEmpresaResposta = new DalQuestionarioEmpresaResposta().ObterQuestionarioEmpresaRespostaPorPergunta(IdQuestionarioEmpresa, objPergunta.IdPergunta, false, transaction, db);
                        }
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return objPergunta;
        }

        /// <summary>
        /// Retorna uma entidade de Pergunta
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntPergunta">EntPergunta</list></returns>
        public List<EntPergunta> ObterPerguntasPorQuestionarioEmpresa(Int32 IdQuestionario, Int32 IdQuestionarioEmpresa, bool isAvaliador)
        {
            List<EntPergunta> objPergunta = new List<EntPergunta>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objPergunta = dalPergunta.ObterPerguntasPorQuestionario(IdQuestionario, transaction, db);
                    foreach (EntPergunta p in objPergunta)
                    {
                        p.ListPerguntaResposta = new DalPerguntaResposta().ObterRespostasPorPergunta(p.IdPergunta, transaction, db);
                        p.QuestionarioEmpresaResposta = new DalQuestionarioEmpresaResposta().ObterQuestionarioEmpresaRespostaPorPergunta(IdQuestionarioEmpresa, p.IdPergunta, false, transaction, db);
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return objPergunta;
        }

        /// <summary>
        /// Retorna uma entidade de Pergunta
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntPergunta">EntPergunta</list></returns>
        public List<EntPergunta> ObterPerguntasQuestionarioDesempenhoGlobal(Int32 IdQuestionario)
        {
            List<EntPergunta> objPergunta = new List<EntPergunta>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objPergunta = dalPergunta.ObterPerguntasPorQuestionario(IdQuestionario, transaction, db);
                    foreach (EntPergunta p in objPergunta)
                    {
                        p.ListPerguntaResposta = new DalPerguntaResposta().ObterRespostasDesempenhoGlobal(p.IdPergunta, transaction, db);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return objPergunta;
        }
    }
}
