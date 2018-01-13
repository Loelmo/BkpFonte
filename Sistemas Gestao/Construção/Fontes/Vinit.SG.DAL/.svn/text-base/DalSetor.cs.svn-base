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
    public class DalSetor
    {
        /// <summary>
        /// Retorna um entidade de Setor
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntSetor">Lista de EntSetor</list></returns>
        public EntSetor ObterPorId(Int32 nIdSetor, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaSetorPorId");
            db.AddInParameter(dbCommand, "@nCDA_Setor", DbType.String, nIdSetor);
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
        /// Retorna um entidade de Setor
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntSetor">Lista de EntSetor</list></returns>
        public List<EntSetor> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaSetor");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntSetor>();
                }
            }
        }

        /// <summary>
        /// Popula Setor, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntSetor">Lista de EntSetor</list></returns>
        private List<EntSetor> Popular(DbDataReader dtrDados)
        {
            List<EntSetor> listEntReturn = new List<EntSetor>();
            EntSetor entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntSetor();

                    entReturn.IdSetor = ObjectUtils.ToInt(dtrDados["CDA_SETOR"]);
                    entReturn.Setor = ObjectUtils.ToString(dtrDados["TX_SETOR"]);
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
