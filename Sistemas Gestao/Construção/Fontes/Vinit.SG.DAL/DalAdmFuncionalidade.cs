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
    /// Classe de Dados que representa um AdmFuncionalidade
    /// </summary>
    public class DalAdmFuncionalidade
    {
        /// <summary>
        /// Retorna um AdmFuncionalidade
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAdmFuncionalidade">EntAdmFuncionalidade</returns>
        public EntAdmFuncionalidade ObterPorId(Int32 IdAdmFuncionalidade, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmFuncionalidadePorId");
            db.AddInParameter(dbCommand, "@nIdAdmFuncionalidade", DbType.String, IdAdmFuncionalidade);
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
        /// Retorna uma lista de entidade de AdmFuncionalidade
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntAdmFuncionalidade">Lista de EntAdmFuncionalidade</list></returns>
        public List<EntAdmFuncionalidade> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmFuncionalidade");
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
        /// Popula AdmFuncionalidade, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntAdmFuncionalidade">Lista de EntAdmFuncionalidade</list></returns>
        private List<EntAdmFuncionalidade> Popular(DbDataReader dtrDados)
        {
            List<EntAdmFuncionalidade> listEntReturn = new List<EntAdmFuncionalidade>();
            EntAdmFuncionalidade entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntAdmFuncionalidade();

                    entReturn.IdFuncionalidade = ObjectUtils.ToInt(dtrDados["CDA_FUNCIONALIDADE"]);
                    entReturn.AdmTipoFuncionalidade.IdTipoFuncionalidade = ObjectUtils.ToInt(dtrDados["CEA_TIPOFUNCIONALIDADE"]);
                    entReturn.AdmFuncionalidadeOrigem.IdFuncionalidade = ObjectUtils.ToInt(dtrDados["CEA_FUNCIONALIDADE_ORIGEM"]);
                    entReturn.Funcionalidade = ObjectUtils.ToString(dtrDados["TX_FUNCIONALIDADE"]);
                    entReturn.URL = ObjectUtils.ToString(dtrDados["TX_URL"]);
                    entReturn.Table = ObjectUtils.ToString(dtrDados["TX_TABLE"]);
                    entReturn.MostraMenu = ObjectUtils.ToBoolean(dtrDados["FL_MOSTRA_MENU"]);

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
