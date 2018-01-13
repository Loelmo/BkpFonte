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
    /// Classe de Dados que representa um AtividadeEconomica
    /// </summary>
    public class BllAtividadeEconomica : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de AtividadeEconomica
        /// </summary>
        private DalAtividadeEconomica dalAtividadeEconomica = new DalAtividadeEconomica();

        /// <summary>
        /// Retorna uma entidade de AtividadeEconomica
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntAtividadeEconomica">EntAtividadeEconomica</list></returns>
        public EntAtividadeEconomica ObterPorId(Int32 IdAtividadeEconomica)
        {
            EntAtividadeEconomica objAtividadeEconomica = new EntAtividadeEconomica();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objAtividadeEconomica = dalAtividadeEconomica.ObterPorId(IdAtividadeEconomica, transaction, db);
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
            return objAtividadeEconomica;
        }

        /// <summary>
        /// Retorna uma lista entidade de AtividadeEconomica
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><type="EntAtividadeEconomica">EntAtividadeEconomica</list></returns>
        public List<EntAtividadeEconomica> ObterPorFiltro(EntAtividadeEconomica objEntAtividadeEconomica)
        {
            List<EntAtividadeEconomica> objAtividadeEconomica = new List<EntAtividadeEconomica>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objAtividadeEconomica = dalAtividadeEconomica.ObterPorFiltro(objEntAtividadeEconomica, transaction, db);
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
            return objAtividadeEconomica;
        }

        /// <summary>
        /// Retorna uma entidade de AtividadeEconomica
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntAtividadeEconomica">EntAtividadeEconomica</list></returns>
        public List<EntAtividadeEconomica> ObterTodos()
        {
            List<EntAtividadeEconomica> lstAtividadeEconomica = new List<EntAtividadeEconomica>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstAtividadeEconomica = dalAtividadeEconomica.ObterTodos(transaction, db);
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
            return lstAtividadeEconomica;
        }
    }
}
