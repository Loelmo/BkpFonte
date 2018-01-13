using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using System.Data.Common;


namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa uma Criterio
    /// </summary>
    public class BllCriterio : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Criterio
        /// </summary>
        private DalCriterio dalCriterio = new DalCriterio();

        /// <summary>
        /// Retorna uma Lista de entriterio de Criterio
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntCriterio">Lista de EntCriterio</list></returns>
        public List<EntCriterio> ObterPorQuestionario(Int32 nIdQuestionario)
        {
            List<EntCriterio> lstCriterio = new List<EntCriterio>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCriterio = dalCriterio.ObterPorQuestionario(nIdQuestionario, transaction, db);
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
            return lstCriterio;
        }

        /// <summary>
        /// Retorna uma Lista de entriterio de Criterio
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntCriterio">Lista de EntCriterio</list></returns>
        public List<EntCriterio> ObterPorQuestionarioComPerguntas(Int32 nIdQuestionario)
        {
            List<EntCriterio> lstCriterio = new List<EntCriterio>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCriterio = dalCriterio.ObterPorQuestionarioComPerguntas(nIdQuestionario, transaction, db);
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
            return lstCriterio;
        }

    }
}
