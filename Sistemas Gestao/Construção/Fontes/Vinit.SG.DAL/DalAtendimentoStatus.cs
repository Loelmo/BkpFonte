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
    /// Classe de Dados que representa um AtendimentoStatus
    /// </summary>
    public class DalAtendimentoStatus
    {
        /// <summary>
        /// Retorna uma lista de entidade de AtendimentoStatus
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAtendimentoStatusCustom">EntAtendimentoStatusCustom</returns>
        public List<EntAtendimentoStatus> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAtendimentoStatus");
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
        /// Popula AtendimentoStatus, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntAtendimentoStatus">Lista de EntAtendimentoStatus</list></returns>
        private List<EntAtendimentoStatus> Popular(DbDataReader dtrDados)
        {
            List<EntAtendimentoStatus> listEntReturn = new List<EntAtendimentoStatus>();
            EntAtendimentoStatus entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntAtendimentoStatus();

                    entReturn.IdAtendimentoStatus = ObjectUtils.ToInt(dtrDados["CDA_ATENDIMENTO_STATUS"]);
                    entReturn.AtendimentoStatus = ObjectUtils.ToString(dtrDados["TX_ATENDIMENTO_STATUS"]);

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
