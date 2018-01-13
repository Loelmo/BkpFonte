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
    /// Classe de Dados que representa um Resumo da Etapa
    /// </summary>
    public class DalEtapaResumo
    {

        /// <summary>
        /// Retorna uma entidade de Resumo da Etapa 
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapaResumo">EntEtapaResumo</list></returns>
        public List<EntEtapaResumo> ObterPorIdEtapa(Int32 nIdEtapa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEtapaResumoPorIdEtapa");
            db.AddInParameter(dbCommand, "@nCDA_ETAPA", DbType.Int32, nIdEtapa);
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
        /// Retorna uma entidade de Resumo da Etapa 
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapaResumo">EntEtapaResumo</list></returns>
        public List<EntEtapaResumo> ObterPorTurma(int IdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEtapaResumoTurma");
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, IdTurma);
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
        /// Inclui um registro na tabela TBL_ETAPA_RESUMO
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objEtapaResumo">Entidade que representa a tabela EtapaResumo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de EtapaResumo</returns>
        public EntEtapaResumo Inserir(EntEtapaResumo objEtapaResumo, DbTransaction transaction, Database db)
        {
            EntEtapaResumo objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereEtapaResumo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_RESUMO_ETAPA", DbType.Int32, objEtapaResumo.IdEtapaResumo);
            db.AddInParameter(dbCommand, "@nCEA_ETAPA", DbType.Int32, objEtapaResumo.Etapa.IdEtapa);
            db.AddInParameter(dbCommand, "@sTX_ACAO", DbType.String, objEtapaResumo.Acao);
            db.AddInParameter(dbCommand, "@dtDT_ALTERACAO", DbType.Date, DateTime.Now);
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, objEtapaResumo.AdmUsuario.IdUsuario);

            db.ExecuteNonQuery(dbCommand, transaction);

            objEtapaResumo.IdEtapaResumo = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_RESUMO_ETAPA"));

            if (objEtapaResumo.IdEtapaResumo != int.MinValue)
                objRetorno = objEtapaResumo;

            return objRetorno;
        }

        /// <summary>
        /// Popula Etapa Resumo, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntEtapaResumo">Lista de EntEtapaResumo</list></returns>
        private List<EntEtapaResumo> Popular(DbDataReader dtrDados)
        {
            List<EntEtapaResumo> listEntReturn = new List<EntEtapaResumo>();
            EntEtapaResumo entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntEtapaResumo();

                    entReturn.IdEtapaResumo = ObjectUtils.ToInt(dtrDados["CDA_ETAPA_RESUMO"]);
                    entReturn.Etapa.IdEtapa = ObjectUtils.ToInt(dtrDados["CEA_ETAPA"]);
                    entReturn.Acao = ObjectUtils.ToString(dtrDados["TX_ACAO"]);
                    entReturn.DataCadastro = ObjectUtils.ToDate(dtrDados["DT_ALTERACAO"]);
                    entReturn.AdmUsuario.IdUsuario = ObjectUtils.ToInt(dtrDados["CEA_USUARIO"]);
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