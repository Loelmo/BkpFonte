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
    /// Classe de Dados que representa um Bairro
    /// </summary>
    public class BllBairro : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Bairro
        /// </summary>
        private DalBairro dalBairro = new DalBairro();

        /// <summary>
        /// Retorna uma entidade de Bairro
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntBairro">EntBairro</list></returns>
        public EntBairro ObterPorId(Int32 IdBairro)
        {
            EntBairro objBairro = new EntBairro();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objBairro = dalBairro.ObterPorId(IdBairro, transaction, db);
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
            return objBairro;
        }

        /// <summary>
        /// Retorna uma entidade de Bairro
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntBairro">EntBairro</list></returns>
        public List<EntBairro> ObterPorCidade(Int32 IdCidade)
        {
            List<EntBairro> lstBairro = new List<EntBairro>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstBairro = dalBairro.ObterPorCidade(IdCidade, transaction, db);
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
            return lstBairro;
        }

        /// <summary>
        /// Retorna uma entidade de Bairro
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntBairro">EntBairro</list></returns>
        public List<EntBairro> ObterTodos()
        {
            List<EntBairro> lstBairro = new List<EntBairro>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstBairro = dalBairro.ObterTodos(transaction, db);
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
            return lstBairro;
        }
    }
}
