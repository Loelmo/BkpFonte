using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.Ent;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Vinit.SG.Common;
using System.Data;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa uma Criterio
    /// </summary>
    public class DalCriterio
    {
        /// <summary>
        /// Retorna uma lista de entriterio de Criterio
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCriterio">Lista de EntCriterio</list></returns>
        public List<EntCriterio> ObterPorQuestionario(Int32 nIdQuestionario, DbTransaction transaction, Database db)
        {

            List<EntCriterio> lstCriterio = new List<EntCriterio>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCriterioPorQuestionario");
            db.AddInParameter(dbCommand, "@nIdQuestionario", DbType.Int32, nIdQuestionario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entriterio de Criterio
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCriterio">Lista de EntCriterio</list></returns>
        public List<EntCriterio> ObterPorQuestionarioComPerguntas(Int32 nIdQuestionario, DbTransaction transaction, Database db)
        {

            List<EntCriterio> lstCriterio = new List<EntCriterio>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCriterioPorQuestionarioComPerguntas");
            db.AddInParameter(dbCommand, "@nIdQuestionario", DbType.Int32, nIdQuestionario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Popula Criterio, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntCriterio">Lista de EntCriterio</list></returns>
        private List<EntCriterio> Popular(DbDataReader dtrDados)
        {
            List<EntCriterio> listEntReturn = new List<EntCriterio>();
            EntCriterio entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntCriterio();

                    entReturn.IdCriterio = ObjectUtils.ToInt(dtrDados["CDA_CRITERIO"]);
                    entReturn.Questionario.IdQuestionario = ObjectUtils.ToInt(dtrDados["CEA_QUESTIONARIO"]);
                    entReturn.Criterio = ObjectUtils.ToString(dtrDados["TX_CRITERIO"]);
                    entReturn.Ordem = ObjectUtils.ToInt(dtrDados["NU_ORDEM"]);
                    entReturn.Ajuda = ObjectUtils.ToString(dtrDados["TX_AJUDA"]);


                    listEntReturn.Add(entReturn);
                }

                dtrDados.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listEntReturn;
        }

    }
}
