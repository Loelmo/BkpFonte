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
    /// Classe de Dados que representa uma AtendimentoSistema
    /// </summary>
    public class BllAtendimentoSistema : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de AtendimentoSistema
        /// </summary>
        private DalAtendimentoSistema dalAtendimentoSistema = new DalAtendimentoSistema();

        /// <summary>
        /// Retorna uma AtendimentoSistema
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntAtendimentoSistema">EntAtendimentoSistema</returns>
        public List<EntAtendimentoSistema> ObterTodos()
        {
            List<EntAtendimentoSistema> listaAtendimentoSistema = new List<EntAtendimentoSistema>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaAtendimentoSistema = dalAtendimentoSistema.ObterTodos(transaction, db);
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
            return listaAtendimentoSistema;
        }

    }
}
