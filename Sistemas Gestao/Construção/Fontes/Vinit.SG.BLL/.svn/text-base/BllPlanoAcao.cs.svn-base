using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using System.Data.Common;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa um PlanoAcao
    /// </summary>
    public class BllPlanoAcao : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de PlanoAcao
        /// </summary>
        private DalPlanoAcao dalPlanoAcao = new DalPlanoAcao();

        /// <summary>
        /// Inclui um PlanoAcao
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objPlanoAcao">Entidade do PlanoAcao</param>
        /// <returns>Entidade de PlanoAcao</returns>
        public EntPlanoAcao Inserir(EntPlanoAcao objPlanoAcao)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objPlanoAcao = dalPlanoAcao.Inserir(objPlanoAcao, transaction, db);

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
            return objPlanoAcao;
        }


        /// <summary>
        /// Altera um PlanoAcao
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objPlanoAcao">Entidade de PlanoAcao</param>
        public void Alterar(EntPlanoAcao objPlanoAcao)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalPlanoAcao.Alterar(objPlanoAcao, transaction, db);

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
        /// Retorna uma entidade de PlanoAcao
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntPlanoAcao">EntPlanoAcao</list></returns>
        public EntPlanoAcao ObterPorId(Int32 IdPlanoAcao)
        {
            EntPlanoAcao objPlanoAcao = new EntPlanoAcao();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objPlanoAcao = dalPlanoAcao.ObterPorId(IdPlanoAcao, transaction, db);
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
            return objPlanoAcao;
        }

        /// <summary>
        /// Retorna uma entidade de PlanoAcao
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntPlanoAcao">EntPlanoAcao</list></returns>
        public List<EntPlanoAcao> ObterPorEmpresaCadastroTurma(Int32 IdEmpresaCadastro, Int32 IdTurma)
        {
            List<EntPlanoAcao> lstPlanoAcao = new List<EntPlanoAcao>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstPlanoAcao = dalPlanoAcao.ObterPorEmpresaCadastroTurma(IdEmpresaCadastro, IdTurma, transaction, db);
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
            return lstPlanoAcao;
        }

    }
}
