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
    /// Classe de Dados que representa um EntFuncionalidade
    /// </summary>
    public class DalFuncionalidade
    {
        /// <summary>
        /// Retorna um EntFuncionalidade
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntFuncionalidade">EntFuncionalidade</returns>
        public List<EntFuncionalidade> ObterFuncionalidadeDoUsuario(Int32 IdUsuario, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaFuncionalidadesDoUsuario");
            db.AddInParameter(dbCommand, "@nIdUsuario", DbType.String, IdUsuario);
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.String, IdPrograma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntFuncionalidade>();
                }
            }
        }

        /// <summary>
        /// Popula EntFuncionalidade, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntFuncionalidade">Lista de EntFuncionalidade</list></returns>
        private List<EntFuncionalidade> Popular(DbDataReader dtrDados)
        {
            List<EntFuncionalidade> listEntReturn = new List<EntFuncionalidade>();
            EntFuncionalidade entReturn;
            
            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntFuncionalidade();

                    entReturn.IdFuncionalidade = ObjectUtils.ToInt(dtrDados["CDA_FUNCIONALIDADE"]);
                    entReturn.Inserir = ObjectUtils.ToBoolean(dtrDados["FL_INSERIR"]);
                    entReturn.Alterar = ObjectUtils.ToBoolean(dtrDados["FL_ATUALIZAR"]);
                    entReturn.Excluir = ObjectUtils.ToBoolean(dtrDados["FL_EXCLUIR"]);
                    entReturn.NomePagina = ObjectUtils.ToString(dtrDados["TX_FUNCIONALIDADE"]);
                    entReturn.URL = ObjectUtils.ToString(dtrDados["TX_URL"]);
                    entReturn.Pai = ObjectUtils.ToInt(dtrDados["CEA_FUNCIONALIDADE_ORIGEM"]);
                    entReturn.Menu = ObjectUtils.ToBoolean(dtrDados["FL_MOSTRA_MENU"]);

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
