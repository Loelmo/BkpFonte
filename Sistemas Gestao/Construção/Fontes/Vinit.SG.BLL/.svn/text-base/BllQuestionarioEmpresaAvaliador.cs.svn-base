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
    /// Classe de Dados que representa um QuestionarioEmpresaAvaliador
    /// </summary>
    public class BllQuestionarioEmpresaAvaliador : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de QuestionarioEmpresaAvaliador
        /// </summary>
        private DalQuestionarioEmpresaAvaliador dalQuestionarioEmpresaAvaliador = new DalQuestionarioEmpresaAvaliador();

        /// <summary>
        /// Retorna uma entidade de QuestionarioEmpresaAvaliador
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><type="EntQuestionarioEmpresa">EntQuestionarioEmpresaAvaliador</list></returns>
        public List<EntQuestionarioEmpresaAvaliador> ObterPorIdQuestionarioEmpresa(Int32 IdQuestionarioEmpresa)
        {
            List<EntQuestionarioEmpresaAvaliador> objQuestionarioEmpresaAvaliador = new List<EntQuestionarioEmpresaAvaliador>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objQuestionarioEmpresaAvaliador = dalQuestionarioEmpresaAvaliador.ObterPorIdQuestionarioEmpresa(IdQuestionarioEmpresa, transaction, db);
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
            return objQuestionarioEmpresaAvaliador;
        }

        /// <summary>
        /// Inclui um QuestionarioEmpresaAvaliador
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objQuestionarioEmpresaAvaliador">Entidade do EntQuestionarioEmpresaAvaliador</param>
        /// <returns>Entidade de QuestionarioEmpresaAvaliador</returns>
        public EntQuestionarioEmpresaAvaliador Inserir(EntQuestionarioEmpresaAvaliador objQuestionarioEmpresaAvaliador)
        {
            EntQuestionarioEmpresaAvaliador objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalQuestionarioEmpresaAvaliador.Inserir(objQuestionarioEmpresaAvaliador, transaction, db);
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
            return objRetorno;
        }

        /// <summary>
        /// Inclui um QuestionarioEmpresaAvaliador
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objQuestionarioEmpresaAvaliador">Entidade do EntQuestionarioEmpresaAvaliador</param>
        /// <returns>Entidade de QuestionarioEmpresaAvaliador</returns>
        public void Alterar(EntQuestionarioEmpresaAvaliador objQuestionarioEmpresaAvaliador)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalQuestionarioEmpresaAvaliador.Alterar(objQuestionarioEmpresaAvaliador, transaction, db);
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
        /// Inclui um QuestionarioEmpresaAvaliador
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objQuestionarioEmpresaAvaliador">Entidade do EntQuestionarioEmpresaAvaliador</param>
        /// <returns>Entidade de QuestionarioEmpresaAvaliador</returns>
        public void RemoverPorQuestionarioEmpresa(Int32 IdQuestionarioEmpresa)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalQuestionarioEmpresaAvaliador.RemoverPorQuestionarioEmpresa(IdQuestionarioEmpresa, transaction, db);
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
    }
}
