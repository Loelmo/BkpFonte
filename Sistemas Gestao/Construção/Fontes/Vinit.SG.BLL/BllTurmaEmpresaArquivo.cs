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
    /// Classe de Dados que representa um TurmaEmpresaArquivo
    /// </summary>
    public class BllTurmaEmpresaArquivo : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de TurmaEmpresaArquivo
        /// </summary>
        private DalTurmaEmpresaArquivo dalTurmaEmpresaArquivo = new DalTurmaEmpresaArquivo();

        /// <summary>
        /// Inclui um TurmaEmpresaArquivo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objTurmaEmpresaArquivo">Entidade do TurmaEmpresaArquivo</param>
        /// <returns>Entidade de TurmaEmpresaArquivo</returns>
        public EntTurmaEmpresaArquivo Inserir(EntTurmaEmpresaArquivo objTurmaEmpresaArquivo)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objTurmaEmpresaArquivo = dalTurmaEmpresaArquivo.Inserir(objTurmaEmpresaArquivo, transaction, db);

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
            return objTurmaEmpresaArquivo;
        }


        /// <summary>
        /// Altera um TurmaEmpresaArquivo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objTurmaEmpresaArquivo">Entidade de TurmaEmpresaArquivo</param>
        public void Alterar(EntTurmaEmpresaArquivo objTurmaEmpresaArquivo)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalTurmaEmpresaArquivo.Alterar(objTurmaEmpresaArquivo, transaction, db);

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
        /// Retorna uma entidade de TurmaEmpresaArquivo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntTurmaEmpresaArquivo">EntTurmaEmpresaArquivo</list></returns>
        public EntTurmaEmpresaArquivo ObterPorId(Int32 IdTurmaEmpresaArquivo)
        {
            EntTurmaEmpresaArquivo objTurmaEmpresaArquivo = new EntTurmaEmpresaArquivo();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objTurmaEmpresaArquivo = dalTurmaEmpresaArquivo.ObterPorId(IdTurmaEmpresaArquivo, transaction, db);
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
            return objTurmaEmpresaArquivo;
        }

        /// <summary>
        /// Retorna uma entidade de TurmaEmpresaArquivo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntTurmaEmpresaArquivo">EntTurmaEmpresaArquivo</list></returns>
        public List<EntTurmaEmpresaArquivo> ObterPorEmpresaCadastroTurma(Int32 IdEmpresaCadastro, Int32 IdTurma)
        {
            List<EntTurmaEmpresaArquivo> lstTurmaEmpresaArquivo = new List<EntTurmaEmpresaArquivo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurmaEmpresaArquivo = dalTurmaEmpresaArquivo.ObterPorEmpresaCadastroTurma(IdEmpresaCadastro, IdTurma, transaction, db);
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
            return lstTurmaEmpresaArquivo;
        }

    }
}
