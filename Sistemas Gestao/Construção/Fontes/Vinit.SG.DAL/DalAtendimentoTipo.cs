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
    /// Classe de Dados que representa um AtendimentoTipo
    /// </summary>
    public class DalAtendimentoTipo
    {
        /// <summary>
        /// Retorna uma lista de entidade de AtendimentoTipo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAtendimentoTipoCustom">EntAtendimentoTipoCustom</returns>
        public List<EntAtendimentoTipo> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAtendimentoTipo");
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
        /// Popula AtendimentoTipo, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntAtendimentoTipo">Lista de EntAtendimentoTipo</list></returns>
        private List<EntAtendimentoTipo> Popular(DbDataReader dtrDados)
        {
            List<EntAtendimentoTipo> listEntReturn = new List<EntAtendimentoTipo>();
            EntAtendimentoTipo entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntAtendimentoTipo();

                    entReturn.IdAtendimentoTipo = ObjectUtils.ToInt(dtrDados["CDA_ATENDIMENTO_TIPO"]);
                    entReturn.AtendimentoTipo = ObjectUtils.ToString(dtrDados["TX_ATENDIMENTO_TIPO"]);

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
