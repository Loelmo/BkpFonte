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
    /// Classe de Dados que representa uma GrupoEmpresa
    /// </summary>
    public class BllTipoEtapa : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de dados DalTipoEtapa
        /// </summary>
        private DalTipoEtapa dalTipoEtapa = new DalTipoEtapa();

        
        /// <summary>
        /// Retorna uma lista de DalTipoEtapa
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <returns><type="EntTipoEtapa">EntTipoEtapa</returns>
        public List<EntTipoEtapa> ObterPorProtrama(Int32 nIdPrograma)
        {
            List<EntTipoEtapa> lstEntTipoEtapa = new List<EntTipoEtapa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEntTipoEtapa = dalTipoEtapa.ObterTipoEtapaPorPrograma(nIdPrograma, transaction, db);
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
            return lstEntTipoEtapa;

        }

   
    }
}
