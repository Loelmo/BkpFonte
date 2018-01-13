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
    /// Classe de Dados que representa um AtividadeEconomica
    /// </summary>
    public class DalAtividadeEconomica
    {
        /// <summary>
        /// Retorna um entidade de AtividadeEconomica
        /// </summary>
        /// <autor>Fernando Carvalo</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntAtividadeEconomica">Lista de EntAtividadeEconomica</list></returns>
        public EntAtividadeEconomica ObterPorId(Int32 IdAtividadeEconomica, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAtividadeEconomicaPorId");
            db.AddInParameter(dbCommand, "@nIdAtividadeEconomica", DbType.String, IdAtividadeEconomica);
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
        /// Retorna uma lista entidade de AtividadeEconomica
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntAtividadeEconomica">Lista de EntAtividadeEconomica</list></returns>
        public List<EntAtividadeEconomica> ObterPorFiltro(EntAtividadeEconomica objAtividadeEconomica, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAtividadeEconomicaPorFiltro");
            db.AddInParameter(dbCommand, "@nCODIGO", DbType.Int32, IntUtils.ToIntNull(objAtividadeEconomica.Codigo));
            db.AddInParameter(dbCommand, "@sTX_ATIVIDADE_ECONOMICA", DbType.String, StringUtils.ToObject(objAtividadeEconomica.AtividadeEconomica));
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntAtividadeEconomica>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de AtividadeEconomica
        /// </summary>
        /// <autor>Fernando Carvalo</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntAtividadeEconomica">Lista de EntAtividadeEconomica</list></returns>
        public EntAtividadeEconomica ObterPorNome(String AtividadeEconomica, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAtividadeEconomicaPorNome");
            db.AddInParameter(dbCommand, "@sAtividadeEconomica", DbType.String, AtividadeEconomica);
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
        /// Altera um Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objEscritorioRegional">Entidade do Escritório Regional</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AlterarDadosSiac(EntAtividadeEconomica objAtividadeEconomica, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_Siac_AtualizaAtividadeEconomica");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCOD_SIAC", DbType.Int32, objAtividadeEconomica.Codigo);
            db.AddInParameter(dbCommand, "@sTX_DESCRICAO", DbType.Int32, objAtividadeEconomica.AtividadeEconomica);
            db.AddInParameter(dbCommand, "@nCDA_ATIVIDADE_ECONOMICA", DbType.Int32, objAtividadeEconomica.IdAtividadeEconomica);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um entidade de AtividadeEconomica
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntAtividadeEconomica">Lista de EntAtividadeEconomica</list></returns>
        public List<EntAtividadeEconomica> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAtividadeEconomica");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntAtividadeEconomica>();
                }
            }
        }

        /// <summary>
        /// Popula AtividadeEconomica, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntAtividadeEconomica">Lista de EntAtividadeEconomica</list></returns>
        private List<EntAtividadeEconomica> Popular(DbDataReader dtrDados)
        {
            List<EntAtividadeEconomica> listEntReturn = new List<EntAtividadeEconomica>();
            EntAtividadeEconomica entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntAtividadeEconomica();

                    entReturn.IdAtividadeEconomica = ObjectUtils.ToInt(dtrDados["CDA_ATIVIDADE_ECONOMICA"]);
                    entReturn.AtividadeEconomica = ObjectUtils.ToString(dtrDados["TX_ATIVIDADE_ECONOMICA"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.Secao = ObjectUtils.ToString(dtrDados["TX_SECAO"]);
                    entReturn.Divisao = ObjectUtils.ToString(dtrDados["TX_DIVISAO"]);
                    entReturn.Grupo = ObjectUtils.ToString(dtrDados["TX_GRUPO"]);
                    entReturn.Classe = ObjectUtils.ToString(dtrDados["TX_CLASSE"]);
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
