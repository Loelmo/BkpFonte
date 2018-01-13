using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using System.Data.Common;

namespace  Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa um ContatoFaixaEtaria
    /// </summary>
    public class BllContatoFaixaEtaria : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de ContatoFaixaEtaria
        /// </summary>
        private DalContatoFaixaEtaria dalContatoFaixaEtaria = new DalContatoFaixaEtaria();

        /// <summary>
        /// Retorna uma entidade de ContatoFaixaEtaria
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntContatoFaixaEtaria">EntContatoFaixaEtaria</list></returns>
        public EntContatoFaixaEtaria ObterPorId(Int32 IdContatoFaixaEtaria)
        {
            EntContatoFaixaEtaria objContatoFaixaEtaria = new EntContatoFaixaEtaria();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objContatoFaixaEtaria = dalContatoFaixaEtaria.ObterPorId(IdContatoFaixaEtaria, transaction, db);
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
            return objContatoFaixaEtaria;
        }

        /// <summary>
        /// Retorna uma entidade de ContatoFaixaEtaria
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntContatoFaixaEtaria">EntContatoFaixaEtaria</list></returns>
        public List<EntContatoFaixaEtaria> ObterTodos()
        {
            List<EntContatoFaixaEtaria> lstContatoFaixaEtaria = new List<EntContatoFaixaEtaria>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstContatoFaixaEtaria = dalContatoFaixaEtaria.ObterTodos(transaction, db);
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
            return lstContatoFaixaEtaria;
        }
    }
}
