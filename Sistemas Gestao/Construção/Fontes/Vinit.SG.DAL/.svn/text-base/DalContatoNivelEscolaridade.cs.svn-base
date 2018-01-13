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
    /// Classe de Dados que representa um Nivel Escolaridade
    /// </summary>
    public class DalContatoNivelEscolaridade
    {
        /// <summary>
        /// Retorna um entidade de NivelEscolaridade
        /// </summary>
        /// <autor>Fernando Carvalo</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntContatoNivelEscolaridade">Lista de EntContatoNivelEscolaridade</list></returns>
        public EntContatoNivelEscolaridade ObterPorId(Int32 IdContatoNivelEscolaridade, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaContatoNivelEscolaridadePorId");
            db.AddInParameter(dbCommand, "@nIdContatoNivelEscolaridade", DbType.String, IdContatoNivelEscolaridade);
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
        /// Retorna um entidade de ContatoNivelEscolaridade
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntContatoNivelEscolaridade">Lista de EntContatoNivelEscolaridade</list></returns>
        public List<EntContatoNivelEscolaridade> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaContatoNivelEscolaridade");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntContatoNivelEscolaridade>();
                }
            }
        }

        /// <summary>
        /// Popula ContatoNivelEscolaridade, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntContatoNivelEscolaridade">Lista de EntContatoNivelEscolaridade</list></returns>
        private List<EntContatoNivelEscolaridade> Popular(DbDataReader dtrDados)
        {
            List<EntContatoNivelEscolaridade> listEntReturn = new List<EntContatoNivelEscolaridade>();
            EntContatoNivelEscolaridade entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntContatoNivelEscolaridade();

                    entReturn.IdContatoNivelEscolaridade = ObjectUtils.ToInt(dtrDados["CDA_NIVEL_ESCOLARIDADE"]);
                    entReturn.ContatoNivelEscolaridade = ObjectUtils.ToString(dtrDados["TX_NIVEL_ESCOLARIDADE"]);
                    entReturn.Ordem = ObjectUtils.ToInt(dtrDados["NU_ORDEM"]);
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
