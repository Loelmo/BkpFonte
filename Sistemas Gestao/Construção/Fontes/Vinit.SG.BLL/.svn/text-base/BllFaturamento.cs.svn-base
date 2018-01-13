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
    /// Classe de Dados que representa um Faturamento
    /// </summary>
    public class BllFaturamento : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Estado
        /// </summary>
        private DalFaturamento dalFaturamento = new DalFaturamento();

        /// <summary>
        /// Retorna uma Lista de entidade de Estado
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        public List<EntFaturamento> ObterTodos()
        {
            List<EntFaturamento> lstFaturamento = new List<EntFaturamento>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstFaturamento = dalFaturamento.ObterTodos(transaction, db);
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
            return lstFaturamento;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Estado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        public List<EntFaturamento> ObterPorIdTipoFaturamento(Int32 IdTipoFaturamento)
        {
            List<EntFaturamento> lstFaturamento = new List<EntFaturamento>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstFaturamento = dalFaturamento.ObterPorIdTipoFaturamento(IdTipoFaturamento, transaction, db);
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
            return lstFaturamento;
        }
    }
}
