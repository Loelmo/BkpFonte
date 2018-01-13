using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa um GrupoEmpresa
    /// </summary>
    public class DalTipoEtapa
    {

        /// <summary>
        /// Retorna uma lista de entidade de TurmaQuestionario
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTipoEtapa">Lista de EntTipoEtapa</list></returns>
        public List<EntTipoEtapa> ObterTipoEtapaPorPrograma(Int32 nIdPrograma, DbTransaction transaction, Database db)
        {
            List<EntTipoEtapa> listEntReturn = new List<EntTipoEtapa>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTipoEtapaPorPrograma");
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, nIdPrograma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                while (dtrDados.Read())
                {
                    EntTipoEtapa entReturn = new EntTipoEtapa();

                    entReturn.IdTipoEtapa = ObjectUtils.ToInt(dtrDados["CDA_TIPO_ETAPA"]);
                    entReturn.TipoEtapa = ObjectUtils.ToString(dtrDados["TX_TIPO_ETAPA"]);
                    entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);
                    entReturn.OrdemFluxo = ObjectUtils.ToInt(dtrDados["NU_ORDEM_FLUXO"]);
                    entReturn.InativaEtapasAnteriores = ObjectUtils.ToBoolean(dtrDados["FL_INATIVA_ETAPAS_ANTERIORES"]);
                    entReturn.EtapaNacional = ObjectUtils.ToBoolean(dtrDados["FL_TIPO_ETAPA_NACIONAL"]);

                    listEntReturn.Add(entReturn);
                }

                return listEntReturn;
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de TurmaQuestionario
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTipoEtapa">Lista de EntTipoEtapa</list></returns>
        public EntTipoEtapa ObterPorId(Int32 nIdTipoEtapa, DbTransaction transaction, Database db)
        {
            EntTipoEtapa entReturn = new EntTipoEtapa();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTipoEtapaPorId");
            db.AddInParameter(dbCommand, "@nCDA_TIPO_ETAPA", DbType.Int32, nIdTipoEtapa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados.Read())
                {
                    entReturn.IdTipoEtapa = ObjectUtils.ToInt(dtrDados["CDA_TIPO_ETAPA"]);
                    entReturn.TipoEtapa = ObjectUtils.ToString(dtrDados["TX_TIPO_ETAPA"]);
                    entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);
                    entReturn.OrdemFluxo = ObjectUtils.ToInt(dtrDados["NU_ORDEM_FLUXO"]);
                    entReturn.InativaEtapasAnteriores = ObjectUtils.ToBoolean(dtrDados["FL_INATIVA_ETAPAS_ANTERIORES"]);
                    entReturn.EtapaNacional = ObjectUtils.ToBoolean(dtrDados["FL_TIPO_ETAPA_NACIONAL"]);

                }
                return entReturn;
            }
        }
    }
}
