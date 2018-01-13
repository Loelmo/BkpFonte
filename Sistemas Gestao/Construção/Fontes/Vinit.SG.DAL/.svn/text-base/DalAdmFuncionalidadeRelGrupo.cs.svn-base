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
    /// Classe de Dados que representa um AdmFuncionalidadeRelGrupo
    /// </summary>
    public class DalAdmFuncionalidadeRelGrupo
    {
        /// <summary>
        /// Inclui um registro na tabela AdmFuncionalidadeRelGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmFuncionalidadeRelGrupo">Entidade que representa a tabela AdmFuncionalidadeRelGrupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de AdmFuncionalidadeRelGrupo</returns>
        public EntAdmFuncionalidadeRelGrupo Inserir(EntAdmFuncionalidadeRelGrupo objAdmFuncionalidadeRelGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereAdmFuncionalidadeRelGrupo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_FUNCIONALIDADE", DbType.Int32, objAdmFuncionalidadeRelGrupo.AdmFuncionalidade.IdFuncionalidade);
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, objAdmFuncionalidadeRelGrupo.AdmGrupo.IdGrupo);
            db.AddInParameter(dbCommand, "@bFL_INSERIR", DbType.Int32, objAdmFuncionalidadeRelGrupo.Inserir);
            db.AddInParameter(dbCommand, "@bFL_ATUALIZAR", DbType.Int32, objAdmFuncionalidadeRelGrupo.Atualizar);
            db.AddInParameter(dbCommand, "@bFL_EXCLUIR", DbType.Int32, objAdmFuncionalidadeRelGrupo.Excluir);
            db.AddInParameter(dbCommand, "@bFL_MOSTRA_MENU", DbType.String, objAdmFuncionalidadeRelGrupo.Visualizar);

            db.ExecuteNonQuery(dbCommand, transaction);

            return objAdmFuncionalidadeRelGrupo;
        }

        /// <summary>
        /// Altera um AdmFuncionalidadeRelGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmFuncionalidadeRelGrupo">Entidade do AdmFuncionalidadeRelGrupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntAdmFuncionalidadeRelGrupo objAdmFuncionalidadeRelGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaAdmFuncionalidadeRelGrupo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_FUNCIONALIDADE", DbType.Int32, objAdmFuncionalidadeRelGrupo.AdmFuncionalidade.IdFuncionalidade);
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.String, objAdmFuncionalidadeRelGrupo.AdmGrupo.IdGrupo);
            db.AddInParameter(dbCommand, "@bFL_INSERIR", DbType.String, objAdmFuncionalidadeRelGrupo.Inserir);
            db.AddInParameter(dbCommand, "@bFL_ATUALIZAR", DbType.String, objAdmFuncionalidadeRelGrupo.Atualizar);
            db.AddInParameter(dbCommand, "@bFL_EXCLUIR", DbType.String, objAdmFuncionalidadeRelGrupo.Excluir);
            db.AddInParameter(dbCommand, "@bFL_MOSTRA_MENU", DbType.String, objAdmFuncionalidadeRelGrupo.Visualizar);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Excluir um AdmFuncionalidadeRelGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="IdAdmFuncionalidadeRelGrupo">Id do AdmFuncionalidadeRelGrupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdAdmFuncionalidade, Int32 IdAdmGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaAdmFuncionalidadeRelGrupoPorId");
            db.AddInParameter(dbCommand, "@nCEA_FUNCIONALIDADE", DbType.Int32, IdAdmFuncionalidade);
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, IdAdmGrupo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um Boolean
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><Boolean>Boolean</returns>
        public Boolean ExisteFuncionalidadeRelGrupo(Int32 IdAdmFuncionalidade, Int32 IdAdmGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_ExisteFuncionalidadeRelGrupo");
            db.AddInParameter(dbCommand, "@nCEA_FUNCIONALIDADE", DbType.Int32, IdAdmFuncionalidade);
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, IdAdmGrupo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            Int32 Count = (Int32)db.ExecuteScalar(dbCommand, transaction);

            return Count > 0;
            
        }


        /// <summary>
        /// Retorna um AdmFuncionalidadeRelGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAdmFuncionalidadeRelGrupo">EntAdmFuncionalidadeRelGrupo</returns>
        public EntAdmFuncionalidadeRelGrupo ObterPorId(Int32 IdAdmFuncionalidade, Int32 IdAdmGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmFuncionalidadeRelGrupoPorId");
            db.AddInParameter(dbCommand, "@nCEA_FUNCIONALIDADE", DbType.Int32, IdAdmFuncionalidade);
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, IdAdmGrupo);
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
        /// Retorna uma lista de entidade de AdmFuncionalidade x AdmFuncionalidadeGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAdmFuncionalidadeRelGrupoCustom">EntAdmFuncionalidadeRelGrupoCustom</returns>
        public List<EntAdmFuncionalidadeRelGrupoCustom> ObterTodosPorIdCustom(Int32 IdAdmGrupo, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmFuncionalidadeRelGrupoPorIdCustom");
            db.AddInParameter(dbCommand, "@nIdAdmGrupo", DbType.Int32, IdAdmGrupo);
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.Int32, IdPrograma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCustom(dtrDados);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de AdmFuncionalidadeRelGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntAdmFuncionalidadeRelGrupo">Lista de EntAdmFuncionalidadeRelGrupo</list></returns>
        public List<EntAdmFuncionalidadeRelGrupo> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmFuncionalidadeRelGrupo");
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
        /// Retorna uma lista de entidade de AdmFuncionalidade x AdmFuncionalidadeGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntAdmFuncionalidadeRelGrupoCustom">Lista de EntAdmFuncionalidadeRelGrupoCustom</list></returns>
        public List<EntAdmFuncionalidadeRelGrupoCustom> ObterTodosCustom(Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmFuncionalidadeRelGrupoCustom");
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.Int32, IdPrograma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCustom(dtrDados);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Popula AdmFuncionalidadeRelGrupo, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntAdmFuncionalidadeRelGrupo">Lista de EntAdmFuncionalidadeRelGrupo</list></returns>
        private List<EntAdmFuncionalidadeRelGrupo> Popular(DbDataReader dtrDados)
        {
            List<EntAdmFuncionalidadeRelGrupo> listEntReturn = new List<EntAdmFuncionalidadeRelGrupo>();
            EntAdmFuncionalidadeRelGrupo entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntAdmFuncionalidadeRelGrupo();

                    entReturn.AdmFuncionalidade.IdFuncionalidade = ObjectUtils.ToInt(dtrDados["CEA_FUNCIONALIDADE"]);
                    entReturn.AdmGrupo.IdGrupo = ObjectUtils.ToInt(dtrDados["CEA_GRUPO"]);
                    entReturn.Inserir = ObjectUtils.ToBoolean(dtrDados["FL_INSERIR"]);
                    entReturn.Atualizar = ObjectUtils.ToBoolean(dtrDados["FL_ATUALIZAR"]);
                    entReturn.Excluir = ObjectUtils.ToBoolean(dtrDados["FL_EXCLUIR"]);
                    entReturn.Visualizar = ObjectUtils.ToBoolean(dtrDados["FL_EXCLUIR"]);

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

        /// <summary>
        /// Popula AdmFuncionalidade x AdmFuncionalidadeGrupo, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntAdmFuncionalidadeRelGrupo">Lista de EntAdmFuncionalidadeRelGrupo</list></returns>
        private List<EntAdmFuncionalidadeRelGrupoCustom> PopularCustom(DbDataReader dtrDados)
        {
            List<EntAdmFuncionalidadeRelGrupoCustom> listEntReturn = new List<EntAdmFuncionalidadeRelGrupoCustom>();
            EntAdmFuncionalidadeRelGrupoCustom entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntAdmFuncionalidadeRelGrupoCustom();

                    entReturn.IdFuncionalidade = ObjectUtils.ToInt(dtrDados["CDA_FUNCIONALIDADE"]);
                    entReturn.Funcionalidade = ObjectUtils.ToString(dtrDados["TX_FUNCIONALIDADE"]);
                    entReturn.AdmGrupo.IdGrupo = ObjectUtils.ToInt(dtrDados["CEA_GRUPO"]);
                    entReturn.Inserir = ObjectUtils.ToBoolean(dtrDados["FL_INSERIR"]);
                    entReturn.Atualizar = ObjectUtils.ToBoolean(dtrDados["FL_ATUALIZAR"]);
                    entReturn.Excluir = ObjectUtils.ToBoolean(dtrDados["FL_EXCLUIR"]);
                    entReturn.Visualizar = ObjectUtils.ToBoolean(dtrDados["FL_MOSTRA_MENU"]);

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
