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
    /// Classe de Dados que representa um EstadoRegiao
    /// </summary>
    public class DalEstadoRegiao
    {
        /// <summary>
        /// Retorna uma lista de entidade de Regiao
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEstadoRegiao">Lista de EntEstadoRegiao</list></returns>
        public List<EntEstadoRegiao> ObterPorIdEstado(Int32 IdEstado, DbTransaction transaction, Database db)
        {

            List<EntEstadoRegiao> lstCidade = new List<EntEstadoRegiao>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEstadoRegiaoPorIdEstado");
            db.AddInParameter(dbCommand, "@nIdEstado", DbType.Int32, IdEstado);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntEstadoRegiao>();
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
        public List<EntEstadoRegiao> ObterTodos(DbTransaction transaction, Database db)
        {

            List<EntEstadoRegiao> lstEstadoRegiao = new List<EntEstadoRegiao>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEstadoRegiao");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntEstadoRegiao>();
                }
            }
        }

        /// <summary>
        /// Popula EstadoRegiao, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        private List<EntEstadoRegiao> Popular(DbDataReader dtrDados)
        {
            List<EntEstadoRegiao> listEntReturn = new List<EntEstadoRegiao>();
            EntEstadoRegiao entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntEstadoRegiao();

                    entReturn.IdEstadoRegiao = ObjectUtils.ToInt(dtrDados["CDA_ESTADO_REGIAO"]);
                    entReturn.EstadoRegiao = ObjectUtils.ToString(dtrDados["TX_ESTADO_REGIAO"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);

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
