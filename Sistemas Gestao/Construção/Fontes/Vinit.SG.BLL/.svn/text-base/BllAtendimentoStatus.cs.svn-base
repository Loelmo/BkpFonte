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
    /// Classe de Dados que representa uma AtendimentoStatus
    /// </summary>
    public class BllAtendimentoStatus : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de AtendimentoStatus
        /// </summary>
        private DalAtendimentoStatus dalAtendimentoStatus = new DalAtendimentoStatus();

        /// <summary>
        /// Retorna uma AtendimentoStatus
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntAtendimentoStatus">EntAtendimentoStatus</returns>
        public List<EntAtendimentoStatus> ObterTodos()
        {
            List<EntAtendimentoStatus> listaAtendimentoStatus = new List<EntAtendimentoStatus>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaAtendimentoStatus = dalAtendimentoStatus.ObterTodos(transaction, db);
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
            return listaAtendimentoStatus;
        }

    }
}
