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
    /// Classe de Dados que representa um AdmGrupo
    /// </summary>
    public class DalAdmGrupo
    {
        /// <summary>
        /// Inclui um registro na tabela AdmGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdnGrupo">Entidade que representa a tabela AdmGrupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de AdmGrupo</returns>
        public EntAdmGrupo Inserir(EntAdmGrupo objAdmGrupo, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            EntAdmGrupo objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereAdmGrupo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_GRUPO", DbType.Int32, objAdmGrupo.IdGrupo);
            db.AddInParameter(dbCommand, "@sTX_GRUPO", DbType.String, objAdmGrupo.Grupo);
            db.AddInParameter(dbCommand, "@sTX_DESCRICAO", DbType.String, objAdmGrupo.Descricao);
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, IdPrograma);

            db.ExecuteNonQuery(dbCommand, transaction);

            objAdmGrupo.IdGrupo = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_GRUPO"));

            if (objAdmGrupo.IdGrupo != int.MinValue)
                objRetorno = objAdmGrupo;

            return objRetorno;
        }

        /// <summary>
        /// Altera um AdmGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmGrupo">Entidade do AdmGrupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntAdmGrupo objAdmGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaAdmGrupo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_GRUPO", DbType.Int32, objAdmGrupo.IdGrupo);
            db.AddInParameter(dbCommand, "@sTX_GRUPO", DbType.String, objAdmGrupo.Grupo);
            db.AddInParameter(dbCommand, "@sTX_DESCRICAO", DbType.String, objAdmGrupo.Descricao);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Excluir um AdmGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="IdAdmGrupo">Id do AdmGrupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdAdmGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaAdmGrupoPorId");
            db.AddInParameter(dbCommand, "@nCDA_GRUPO", DbType.Int32, IdAdmGrupo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna uma lista de entidade de AdmGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntAdmGrupo">Lista de AdmGrupo</list></returns>
        public List<EntAdmGrupo> ObterPorNome(String sNome, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmGrupoPorNome");
            db.AddInParameter(dbCommand, "@sNome", DbType.String, sNome);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntAdmGrupo>();
                }
            }
        }

        /// <summary>
        /// Retorna uma Boolean
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><Boolean>Boolean</returns>
        public Boolean ExisteGrupo(String sNome, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_ExisteGrupo");
            db.AddInParameter(dbCommand, "@sNome", DbType.String, sNome);
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, IdPrograma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            Int32 Count = (Int32)db.ExecuteScalar(dbCommand, transaction);

            return Count > 0;

        }

        /// <summary>
        /// Retorna um AdmGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAdmGrupo">EntAdmGrupo</returns>
        public EntAdmGrupo ObterPorId(Int32 IdAdmGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmGrupoPorId");
            db.AddInParameter(dbCommand, "@nIdAdmGrupo", DbType.String, IdAdmGrupo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return new EntAdmGrupo();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de AdmGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntAdmGrupo">Lista de EntAdmGrupo</list></returns>
        public List<EntAdmGrupo> ObterTodos(Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmGrupo");
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, IdPrograma);
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
        /// Retorna uma lista de entidade de AdmGrupo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntAdmGrupo">Lista de EntAdmGrupo</list></returns>
        public List<EntAdmGrupo> ObterTodosPorArquivo(Int32 IdArquivo, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmGrupoPorArquivo");
            db.AddInParameter(dbCommand, "@nIdArquivo", DbType.Int32, IdArquivo);
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, IdPrograma);
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
        /// Retorna uma lista de entidade de AdmGrupo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntAdmGrupo">Lista de EntAdmGrupo</list></returns>
        public List<EntAdmGrupo> ObterTodosPorNoticia(Int32 IdNoticia, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmGrupoPorNoticia");
            db.AddInParameter(dbCommand, "@nIdNoticia", DbType.Int32, IdNoticia);
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, IdPrograma);
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
        /// Popula AdmGrupo, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntAdmGrupo">Lista de EntAdmGrupo</list></returns>
        private List<EntAdmGrupo> Popular(DbDataReader dtrDados)
        {
            List<EntAdmGrupo> listEntReturn = new List<EntAdmGrupo>();
            EntAdmGrupo entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntAdmGrupo();

                    entReturn.IdGrupo = ObjectUtils.ToInt(dtrDados["CDA_GRUPO"]);
                    entReturn.Grupo = ObjectUtils.ToString(dtrDados["TX_GRUPO"]);
                    entReturn.Descricao = ObjectUtils.ToString(dtrDados["TX_DESCRICAO"]);
                    entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);
                    try
                    {
                        if (ObjectUtils.ToInt(dtrDados["FL_SELECIONADO"]) > 0)
                        {
                            entReturn.Selecionado = true;
                        }
                        else
                        {
                            entReturn.Selecionado = false;
                        }
                    }
                    catch { }

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
