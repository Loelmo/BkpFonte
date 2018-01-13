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
    /// Classe de Dados que representa um Estado
    /// </summary>
    public class BllEstado : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Estado
        /// </summary>
        private DalEstado dalEstado = new DalEstado();

        /// <summary>
        /// Retorna um Estado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><"EntEstado">EntEstado</returns>
        public EntEstado ObterPorId(Int32 IdEstado)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalEstado.ObterPorId(IdEstado, transaction, db);
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
        /// Retorna um Estado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><"EntEstado">EntEstado</returns>
        public List<EntEstado> ObterEstadosPorTurma(Int32 IdTurma, Int32 IdTipoEtapa)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalEstado.ObterEstadosPorTurma(IdTurma, IdTipoEtapa, transaction, db);
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
        /// Retorna uma Lista de entidade de Estado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        public List<EntEstado> ObterTodos()
        {
            List<EntEstado> lstEstado = new List<EntEstado>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEstado = dalEstado.ObterTodos(transaction, db);
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
            return lstEstado;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Estado
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        public List<EntEstado> ObterEstadoEmpresasInscritasPorFiltro(RelFiltroRanking objRelFiltroRanking)
        {
            List<EntEstado> lstEstado = new List<EntEstado>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEstado = dalEstado.ObterEstadoEmpresasInscritasPorFiltro(objRelFiltroRanking, transaction, db);
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
            return lstEstado;
        }
    }
}
