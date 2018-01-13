using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.Ent;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using Vinit.SG.Common;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa um Cargo
    /// </summary>
    public class DalCargo
    {
        /// <summary>
        /// Retorna um entidade de Cargo
        /// </summary>
        /// <autor>Fernando Carvalo</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCargo">Lista de EntCargo</list></returns>
        public EntCargo ObterPorId(Int32 IdCargo, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCargoPorId");
            db.AddInParameter(dbCommand, "@nIdCargo", DbType.String, IdCargo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Cargo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCargo">Lista de EntCargo</list></returns>
        public List<EntCargo> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCargo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntCargo>();
                }
            }
        }

        /// <summary>
        /// Popula Cargo, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntCargo">Lista de EntCargo</list></returns>
        private List<EntCargo> Popular(DbDataReader dtrDados)
        {
            List<EntCargo> listEntReturn = new List<EntCargo>();
            EntCargo entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntCargo();

                    entReturn.IdCargo = ObjectUtils.ToInt(dtrDados["CDA_CARGO"]);
                    entReturn.Cargo = ObjectUtils.ToString(dtrDados["TX_CARGO"]);
                    entReturn.Codigo = ObjectUtils.ToInt(dtrDados["CODIGO"]);
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
