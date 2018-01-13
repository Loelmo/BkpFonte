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
    public class BllQuestionarioEmpresaResposta : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalQuestionarioEmpresaResposta dalQuestionarioEmpresaResposta = new DalQuestionarioEmpresaResposta();

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalQuestionarioEmpresa dalQuestionarioEmpresa = new DalQuestionarioEmpresa();

        public void InserirAtualizar(EntQuestionarioEmpresaResposta objQuestionarioEmpresaResposta)
        {
            this.InserirAtualizar(objQuestionarioEmpresaResposta, true);
        }

        /// <summary>
        /// Inclui uma QuestionarioEmpresaResposta
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objQuestionarioEmpresaResposta">Entidade da QuestionarioEmpresaResposta</param>
        /// <returns>Entidade de QuestionarioEmpresaResposta</returns>
        public void InserirAtualizar(EntQuestionarioEmpresaResposta objQuestionarioEmpresaResposta, Boolean AlteraEnviaQuestionario)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    bool isAvaliador = false;
                    if(objQuestionarioEmpresaResposta.UsuarioAvaliador != null && objQuestionarioEmpresaResposta.UsuarioAvaliador.IdUsuario > 0){
                        isAvaliador = true;
                    }
                    EntQuestionarioEmpresaResposta temp = dalQuestionarioEmpresaResposta.ObterQuestionarioEmpresaRespostaPorPergunta(objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa, objQuestionarioEmpresaResposta.Pergunta.IdPergunta, isAvaliador, transaction, db);

                    if (AlteraEnviaQuestionario)
                    {
                        EntQuestionarioEmpresa objQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorId(objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa);
                        objQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterQuestionarioAtivoPorEtapa(objQuestionarioEmpresa.Questionario.IdQuestionario, objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, objQuestionarioEmpresa.Etapa.IdEtapa);
                        objQuestionarioEmpresa.EnviaQuestionario = false;
                        dalQuestionarioEmpresa.AlterarSomenteEnviaQuestionario(objQuestionarioEmpresa, transaction, db);
                    }

                    if (temp != null && temp.QuestionarioEmpresa.IdQuestionarioEmpresa > 0)
                    {
                        dalQuestionarioEmpresaResposta.Alterar(objQuestionarioEmpresaResposta, transaction, db);
                    }
                    else
                    {
                        dalQuestionarioEmpresaResposta.Inserir(objQuestionarioEmpresaResposta, transaction, db);
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
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Ranking Finalista
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmGrupo">Lista de RelRankingCandidataEstadual</list></returns>
        public List<EntQuestionarioEmpresaResposta> ObterRespostasEmpresaPorEmpresaParaAvaliacao(Int32 IdEmpresaCadastro, Int32 IdEtapa)
        {
            List<EntQuestionarioEmpresaResposta> lstRelAvaliacao = new List<EntQuestionarioEmpresaResposta>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstRelAvaliacao = dalQuestionarioEmpresaResposta.ObterRespostasEmpresaPorEmpresaParaAvaliacao(IdEmpresaCadastro, IdEtapa, transaction, db);
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
            return lstRelAvaliacao;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Ranking Finalista
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmGrupo">Lista de RelRankingCandidataEstadual</list></returns>
        public EntQuestionarioEmpresaResposta ObterRespostaEmpresaPorQuestionarioEmpresaPergunta(Int32 IdQuestionarioEmpresa, Int32 IdPergunta)
        {
            EntQuestionarioEmpresaResposta relAvaliacao = new EntQuestionarioEmpresaResposta();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    relAvaliacao = dalQuestionarioEmpresaResposta.ObterQuestionarioEmpresaRespostaPorPergunta(IdQuestionarioEmpresa, IdPergunta, true, transaction, db);
                    if (relAvaliacao == null)
                    {
                        relAvaliacao = dalQuestionarioEmpresaResposta.ObterQuestionarioEmpresaRespostaPorPergunta(IdQuestionarioEmpresa, IdPergunta, false, transaction, db);
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
            return relAvaliacao;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Ranking Finalista
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <returns><list type="EntAdmGrupo">Lista de RelRankingCandidataEstadual</list></returns>
        public EntQuestionarioEmpresaResposta ObterQuestionarioEmpresaRespostaPorPergunta(Int32 IdQuestionarioEmpresa, Int32 IdPergunta, bool isAvaliacao)
        {
            EntQuestionarioEmpresaResposta objQuestionarioEmpresaResposta = new EntQuestionarioEmpresaResposta();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objQuestionarioEmpresaResposta = dalQuestionarioEmpresaResposta.ObterQuestionarioEmpresaRespostaPorPergunta(IdQuestionarioEmpresa, IdPergunta, true, transaction, db);
                    if (objQuestionarioEmpresaResposta == null)
                    {
                        objQuestionarioEmpresaResposta = dalQuestionarioEmpresaResposta.ObterQuestionarioEmpresaRespostaPorPergunta(IdQuestionarioEmpresa, IdPergunta, false, transaction, db);
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
            return objQuestionarioEmpresaResposta;
        }

    }
}
