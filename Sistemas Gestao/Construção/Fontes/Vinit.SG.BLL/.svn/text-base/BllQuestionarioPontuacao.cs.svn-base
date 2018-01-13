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
    public class BllQuestionarioPontuacao : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalQuestionarioPontuacao dalQuestionarioPontuacao = new DalQuestionarioPontuacao();

        /// <summary>
        /// Inclui uma QuestionarioPontuacao
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objQuestionarioPontuacao">Entidade da QuestionarioPontuacao</param>
        /// <returns>Entidade de QuestionarioPontuacao</returns>
        public void Inserir(EntQuestionarioPontuacao objQuestionarioPontuacao)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalQuestionarioPontuacao.Inserir(objQuestionarioPontuacao, transaction, db);
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
        /// Inclui uma QuestionarioPontuacao
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objQuestionarioPontuacao">Entidade da QuestionarioPontuacao</param>
        /// <returns>Entidade de QuestionarioPontuacao</returns>
        public void ExcluirPorIdQuestionarioEmpresa(Int32 IdQuestionarioEmpresa)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalQuestionarioPontuacao.ExcluirPorIdQuestionarioEmpresa(IdQuestionarioEmpresa, transaction, db);
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
        /// Retorna uma Lista de Qestionario Pontuação
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><"EntEstado">Lista de Qestionario Pontuação</returns>
        public List<EntQuestionarioPontuacao> ObterPorQuestionarioEmpresa(Int32 IdQuestionarioEmpresa, Boolean IsAvaliador)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalQuestionarioPontuacao.ObterPorQuestionarioEmpresa(IdQuestionarioEmpresa, IsAvaliador, transaction, db);
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
        }

        /// <summary>
        /// Retorna uma Lista de Qestionario Pontuação
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><"EntEstado">Lista de Qestionario Pontuação</returns>
        public List<EntQuestionarioPontuacao> ObterPorQuestionario(Int32 IdEmpresaCadastro, Int32 IdTurma, Int32 IdQuestionario, Boolean IsAvaliador)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalQuestionarioPontuacao.ObterPorQuestionario(IdEmpresaCadastro, IdTurma, IdQuestionario, IsAvaliador, transaction, db);
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
        }

    }
}
