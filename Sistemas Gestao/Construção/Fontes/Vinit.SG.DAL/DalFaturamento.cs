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
    /// Classe de Dados que representa um Faturamento
    /// </summary>
    public class DalFaturamento
    {
        /// <summary>
        /// Retorna uma lista de entidade de Estado
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        public List<EntFaturamento> ObterPorIdTipoFaturamento(Int32 IdTipoFaturamento, DbTransaction transaction, Database db)
        {

            List<EntFaturamento> lstFaturamento = new List<EntFaturamento>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaPorIdTipoFaturamento");
            db.AddInParameter(dbCommand, "@nIdTipoFaturamento", DbType.String, IdTipoFaturamento);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntFaturamento>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Estado
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        public List<EntFaturamento> ObterTodos(DbTransaction transaction, Database db)
        {

            List<EntFaturamento> lstFaturamento = new List<EntFaturamento>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaFaturamento");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntFaturamento>();
                }
            }
        }

        /// <summary>
        /// Popula Faturamento, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        private List<EntFaturamento> Popular(DbDataReader dtrDados)
        {
            List<EntFaturamento> listEntReturn = new List<EntFaturamento>();
            EntFaturamento entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntFaturamento();

                    entReturn.IdFaturamento = ObjectUtils.ToInt(dtrDados["CDA_FATURAMENTO"]);
                    entReturn.Faturamento = ObjectUtils.ToString(dtrDados["TX_FATURAMENTO"]);
                    entReturn.MensuracaoFaturamento = ObjectUtils.ToString(dtrDados["TX_MENSURACAO_FATURAMENTO"]);
                    entReturn.FaturamentoTipo.IdFaturamentoTipo = ObjectUtils.ToInt(dtrDados["CEA_FATURAMENTO_TIPO"]);

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
