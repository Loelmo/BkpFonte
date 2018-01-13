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
    /// Classe de Dados que representa um EstadoRegiao
    /// </summary>
    public class BllEstadoRegiao : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Estado
        /// </summary>
        private DalEstadoRegiao dalEstadoRegiao = new DalEstadoRegiao();

        /// <summary>
        /// Retorna uma Lista de entidade de Estado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        public List<EntEstadoRegiao> ObterPorIdEstado(Int32 IdEstado)
        {
            List<EntEstadoRegiao> lstEstadoRegiao = new List<EntEstadoRegiao>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEstadoRegiao = dalEstadoRegiao.ObterPorIdEstado(IdEstado, transaction, db);
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
            return lstEstadoRegiao;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Estado
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        public List<EntEstadoRegiao> ObterTodos()
        {
            List<EntEstadoRegiao> lstEstadoRegiao = new List<EntEstadoRegiao>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEstadoRegiao = dalEstadoRegiao.ObterTodos(transaction, db);
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
            return lstEstadoRegiao;
        }

    }
}
