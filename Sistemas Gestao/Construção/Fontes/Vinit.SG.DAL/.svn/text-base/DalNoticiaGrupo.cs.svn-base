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
    /// Classe de Dados que representa um NoticiaGrupo
    /// </summary>
    public class DalNoticiaGrupo
    {
        /// <summary>
        /// Inclui um registro na tabela NoticiaGrupo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objNoticiaGrupo">Entidade que representa a tabela NoticiaGrupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de NoticiaGrupo</returns>
        public EntNoticiaGrupo Inserir(EntNoticiaGrupo objNoticiaGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereNoticiaGrupo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_NOTICIA", DbType.Int32, objNoticiaGrupo.Noticia.IdNoticia);
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, objNoticiaGrupo.AdmGrupo.IdGrupo);

            db.ExecuteNonQuery(dbCommand, transaction);

            return objNoticiaGrupo;
        }

        /// <summary>
        /// Excluir um NoticiaGrupo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="IdNoticiaGrupo">Id do NoticiaGrupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdNoticia, Int32 IdGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaNoticiaGrupoPorId");
            db.AddInParameter(dbCommand, "@nCEA_NOTICIA", DbType.Int32, IdNoticia);
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, IdGrupo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Excluir um NoticiaGrupo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="IdNoticiaGrupo">Id do NoticiaGrupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void ExcluirPorNoticia(Int32 IdNoticia, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaNoticiaGrupoPorNoticia");
            db.AddInParameter(dbCommand, "@nCEA_NOTICIA", DbType.Int32, IdNoticia);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um NoticiaGrupo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntNoticiaGrupo">EntNoticiaGrupo</returns>
        public List<EntNoticiaGrupo> ObterPorNoticiaId(Int32 IdNoticia, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaNoticiaGrupoPorNoticia");
            db.AddInParameter(dbCommand, "@nCEA_NOTICIA", DbType.Int32, IdNoticia);
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
        /// Popula NoticiaGrupo, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntNoticiaGrupo">Lista de EntNoticiaGrupo</list></returns>
        private List<EntNoticiaGrupo> Popular(DbDataReader dtrDados)
        {
            List<EntNoticiaGrupo> listEntReturn = new List<EntNoticiaGrupo>();
            EntNoticiaGrupo entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntNoticiaGrupo();

                    entReturn.Noticia.IdNoticia = ObjectUtils.ToInt(dtrDados["CEA_NOTICIA"]);
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
