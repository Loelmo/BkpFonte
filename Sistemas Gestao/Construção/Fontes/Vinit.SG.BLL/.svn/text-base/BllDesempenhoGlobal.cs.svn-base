using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using System.Data.Common;
using Vinit.SG.BLL;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa um Desempenho Global
    /// </summary>
    public class BllDesempenhoGlobal : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de DalRelatorioRanking
        /// </summary>
        private DalDesempenhoGlobal dalDesempenhoGlobal = new DalDesempenhoGlobal();

        /// <summary>
        /// Retorna uma Lista de entidade de Desempenho Global
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        public List<EntDesempenhoGlobal> GerarDesempenhoGlobal2010(EntDesempenhoGlobal objDesempenhoGlobal)
        {
            List<EntDesempenhoGlobal> lstDesempenhoGlobal = new List<EntDesempenhoGlobal>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstDesempenhoGlobal = dalDesempenhoGlobal.GerarDesempenhoGlobal2010(objDesempenhoGlobal, transaction, db);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return lstDesempenhoGlobal;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Desempenho Global
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        public List<EntDesempenhoGlobal> GerarDesempenhoGlobal2011(EntDesempenhoGlobal objDesempenhoGlobal)
        {
            List<EntDesempenhoGlobal> lstDesempenhoGlobal = new List<EntDesempenhoGlobal>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstDesempenhoGlobal = dalDesempenhoGlobal.GerarDesempenhoGlobal2011(objDesempenhoGlobal, transaction, db);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return lstDesempenhoGlobal;
        }
    }
}
