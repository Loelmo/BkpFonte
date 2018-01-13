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
    /// Classe de Dados que representa um ArquivoGrupo
    /// </summary>
    public class DalArquivoGrupo
    {
        /// <summary>
        /// Inclui um registro na tabela ArquivoGrupo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objArquivoGrupo">Entidade que representa a tabela ArquivoGrupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de ArquivoGrupo</returns>
        public EntArquivoGrupo Inserir(EntArquivoGrupo objArquivoGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereArquivoGrupo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_ARQUIVO", DbType.Int32, objArquivoGrupo.Arquivo.IdArquivo);
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, objArquivoGrupo.AdmGrupo.IdGrupo);

            db.ExecuteNonQuery(dbCommand, transaction);

            return objArquivoGrupo;
        }

        /// <summary>
        /// Excluir um ArquivoGrupo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="IdArquivoGrupo">Id do ArquivoGrupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdArquivo, Int32 IdGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaArquivoGrupoPorId");
            db.AddInParameter(dbCommand, "@nCEA_ARQUIVO", DbType.Int32, IdArquivo);
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, IdGrupo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Excluir um ArquivoGrupo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="IdArquivoGrupo">Id do ArquivoGrupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void ExcluirPorArquivo(Int32 IdArquivo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaArquivoGrupoPorArquivo");
            db.AddInParameter(dbCommand, "@nCEA_ARQUIVO", DbType.Int32, IdArquivo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um ArquivoGrupo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntArquivoGrupo">EntArquivoGrupo</returns>
        public List<EntArquivoGrupo> ObterPorArquivoId(Int32 IdArquivo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaArquivoGrupoPorArquivo");
            db.AddInParameter(dbCommand, "@nCEA_ARQUIVO", DbType.Int32, IdArquivo);
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
        /// Popula ArquivoGrupo, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntArquivoGrupo">Lista de EntArquivoGrupo</list></returns>
        private List<EntArquivoGrupo> Popular(DbDataReader dtrDados)
        {
            List<EntArquivoGrupo> listEntReturn = new List<EntArquivoGrupo>();
            EntArquivoGrupo entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntArquivoGrupo();

                    entReturn.Arquivo.IdArquivo = ObjectUtils.ToInt(dtrDados["CEA_ARQUIVO"]);
                    entReturn.AdmGrupo.IdGrupo = ObjectUtils.ToInt(dtrDados["CEA_GRUPO"]);

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
