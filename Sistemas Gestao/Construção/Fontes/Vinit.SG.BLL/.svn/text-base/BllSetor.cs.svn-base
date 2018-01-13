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
    /// Classe de Dados que representa um Setor
    /// </summary>
    public class BllSetor : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Setor
        /// </summary>
        private DalSetor dalSetor = new DalSetor();

        /// <summary>
        /// Retorna uma entidade de Setor
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntSetor">EntSetor</list></returns>
        public EntSetor ObterPorId(Int32 IdSetor)
        {
            EntSetor objSetor = new EntSetor();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objSetor = dalSetor.ObterPorId(IdSetor, transaction, db);
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
            return objSetor;
        }

        /// <summary>
        /// Retorna uma entidade de Setor
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntSetor">EntSetor</list></returns>
        public List<EntSetor> ObterTodos()
        {
            List<EntSetor> lstSetor = new List<EntSetor>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstSetor = dalSetor.ObterTodos(transaction, db);
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
            return lstSetor;
        }
    }
}
