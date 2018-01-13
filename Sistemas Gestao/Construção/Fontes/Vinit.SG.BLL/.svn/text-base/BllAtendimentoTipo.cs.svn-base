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
    /// Classe de Dados que representa uma AtendimentoTipo
    /// </summary>
    public class BllAtendimentoTipo : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de AtendimentoTipo
        /// </summary>
        private DalAtendimentoTipo dalAtendimentoTipo = new DalAtendimentoTipo();

        /// <summary>
        /// Retorna uma AtendimentoTipo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntAtendimentoTipo">EntAtendimentoTipo</returns>
        public List<EntAtendimentoTipo> ObterTodos()
        {
            List<EntAtendimentoTipo> listaAtendimentoTipo = new List<EntAtendimentoTipo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaAtendimentoTipo = dalAtendimentoTipo.ObterTodos(transaction, db);
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
            return listaAtendimentoTipo;
        }

    }
}
