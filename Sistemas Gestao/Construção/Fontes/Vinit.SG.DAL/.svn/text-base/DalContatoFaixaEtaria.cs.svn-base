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
    /// Classe de Dados que representa um Faixa Etaria
    /// </summary>
    public class DalContatoFaixaEtaria
    {
        /// <summary>
        /// Retorna um entidade de FaixaEtaria
        /// </summary>
        /// <autor>Fernando Carvalo</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntContatoFaixaEtaria">Lista de EntContatoFaixaEtaria</list></returns>
        public EntContatoFaixaEtaria ObterPorId(Int32 IdContatoFaixaEtaria, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaContatoFaixaEtariaPorId");
            db.AddInParameter(dbCommand, "@nIdContatoFaixaEtaria", DbType.String, IdContatoFaixaEtaria);
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
        /// Retorna um entidade de ContatoFaixaEtaria
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntContatoFaixaEtaria">Lista de EntContatoFaixaEtaria</list></returns>
        public List<EntContatoFaixaEtaria> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaContatoFaixaEtaria");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntContatoFaixaEtaria>();
                }
            }
        }

        /// <summary>
        /// Popula ContatoFaixaEtaria, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntContatoFaixaEtaria">Lista de EntContatoFaixaEtaria</list></returns>
        private List<EntContatoFaixaEtaria> Popular(DbDataReader dtrDados)
        {
            List<EntContatoFaixaEtaria> listEntReturn = new List<EntContatoFaixaEtaria>();
            EntContatoFaixaEtaria entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntContatoFaixaEtaria();

                    entReturn.IdContatoFaixaEtaria = ObjectUtils.ToInt(dtrDados["CDA_FAIXA_ETARIA"]);
                    entReturn.ContatoFaixaEtaria = ObjectUtils.ToString(dtrDados["TX_FAIXA_ETARIA"]);
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
