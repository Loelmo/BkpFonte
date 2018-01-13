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
    /// Classe de Dados que representa um Cargo
    /// </summary>
    public class BllCargo : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Cargo
        /// </summary>
        private DalCargo dalCargo = new DalCargo();

        /// <summary>
        /// Retorna uma entidade de Cargo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntCargo">EntCargo</list></returns>
        public EntCargo ObterPorId(Int32 IdCargo)
        {
            EntCargo objCargo = new EntCargo();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objCargo = dalCargo.ObterPorId(IdCargo, transaction, db);
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
            return objCargo;
        }

        /// <summary>
        /// Retorna uma entidade de Cargo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntCargo">EntCargo</list></returns>
        public List<EntCargo> ObterTodos()
        {
            List<EntCargo> lstCargo = new List<EntCargo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCargo = dalCargo.ObterTodos(transaction, db);
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
            return lstCargo;
        }
    }
}
