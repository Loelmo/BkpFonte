using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.BLL;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using System.Data.Common;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa um ContatoNivelEscolaridade
    /// </summary>
    public class BllContatoNivelEscolaridade : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de ContatoNivelEscolaridade
        /// </summary>
        private DalContatoNivelEscolaridade dalContatoNivelEscolaridade = new DalContatoNivelEscolaridade();

        /// <summary>
        /// Retorna uma entidade de ContatoNivelEscolaridade
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntContatoNivelEscolaridade">EntContatoNivelEscolaridade</list></returns>
        public EntContatoNivelEscolaridade ObterPorId(Int32 IdContatoNivelEscolaridade)
        {
            EntContatoNivelEscolaridade objContatoNivelEscolaridade = new EntContatoNivelEscolaridade();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objContatoNivelEscolaridade = dalContatoNivelEscolaridade.ObterPorId(IdContatoNivelEscolaridade, transaction, db);
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
            return objContatoNivelEscolaridade;
        }

        /// <summary>
        /// Retorna uma entidade de ContatoNivelEscolaridade
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntContatoNivelEscolaridade">EntContatoNivelEscolaridade</list></returns>
        public List<EntContatoNivelEscolaridade> ObterTodos()
        {
            List<EntContatoNivelEscolaridade> lstContatoNivelEscolaridade = new List<EntContatoNivelEscolaridade>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstContatoNivelEscolaridade = dalContatoNivelEscolaridade.ObterTodos(transaction, db);
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
            return lstContatoNivelEscolaridade;
        }
    }
}
