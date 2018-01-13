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
    /// Classe de Dados que representa um AdmGrupoRelUsuario
    /// </summary>
    public class DalAdmGrupoRelUsuario
    {
        /// <summary>
        /// Inclui um registro na tabela AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmGrupoRelUsuario">Entidade que representa a tabela AdmGrupoRelUsuario</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de AdmGrupoRelUsuario</returns>
        public EntAdmGrupoRelUsuario Inserir(EntAdmGrupoRelUsuario objAdmGrupoRelUsuario, DbTransaction transaction, Database db)
        {
            EntAdmGrupoRelUsuario objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereAdmGrupoRelUsuario");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_RELGRUPOUSUARIO", DbType.Int32, objAdmGrupoRelUsuario.IdGrupoUsuario);
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, objAdmGrupoRelUsuario.AdmGrupo.IdGrupo);
            db.AddInParameter(dbCommand, "@nCEA_ESCRITORIO_REGIONAL", DbType.Int32, IntUtils.ToIntNull(objAdmGrupoRelUsuario.EscritorioRegional.IdEscritorioRegional));
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objAdmGrupoRelUsuario.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objAdmGrupoRelUsuario.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, objAdmGrupoRelUsuario.Programa.IdPrograma);


            db.ExecuteNonQuery(dbCommand, transaction);

            objAdmGrupoRelUsuario.IdGrupoUsuario = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_RELGRUPOUSUARIO"));

            if (objAdmGrupoRelUsuario.IdGrupoUsuario != int.MinValue)
                objRetorno = objAdmGrupoRelUsuario;

            return objAdmGrupoRelUsuario;
        }

        /// <summary>
        /// Altera um AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmGrupoRelUsuario">Entidade do AdmGrupoRelUsuario</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntAdmGrupoRelUsuario objAdmGrupoRelUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaAdmGrupoRelUsuario");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_RELGRUPOUSUARIO", DbType.Int32, objAdmGrupoRelUsuario.IdGrupoUsuario);
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, objAdmGrupoRelUsuario.AdmGrupo.IdGrupo);
            db.AddInParameter(dbCommand, "@nCEA_ESCRITORIO_REGIONAL", DbType.Int32, IntUtils.ToIntNull(objAdmGrupoRelUsuario.EscritorioRegional.IdEscritorioRegional));
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objAdmGrupoRelUsuario.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objAdmGrupoRelUsuario.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, objAdmGrupoRelUsuario.Programa.IdPrograma);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Excluir um AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="IdAdmGrupoRelUsuario">Id do AdmGrupoRelUsuario</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdAdmGrupoRelUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaAdmGrupoRelUsuarioPorId");
            db.AddInParameter(dbCommand, "@nCDA_RELGRUPOUSUARIO", DbType.Int32, IdAdmGrupoRelUsuario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAdmGrupoRelUsuario">EntAdmGrupoRelUsuario</returns>
        public EntAdmGrupoRelUsuario ObterPorId(Int32 IdAdmGrupoRelUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmGrupoRelUsuarioPorId");
            db.AddInParameter(dbCommand, "@nCDA_RELGRUPOUSUARIO", DbType.Int32, IdAdmGrupoRelUsuario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return new EntAdmGrupoRelUsuario();
                }
            }
        }

        /// <summary>
        /// Retorna um AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAdmGrupoRelUsuario">EntAdmGrupoRelUsuario</returns>
        public List<EntAdmGrupoRelUsuario> ObterPorIdGrupo(Int32 IdAdmGrupo, Int32 IdPrograma, Int32 IdUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmGrupoRelUsuarioPorIdGrupo");
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, IdAdmGrupo);
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, IdPrograma);
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, IdUsuario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntAdmGrupoRelUsuario>();
                }
            }
        }

        /// <summary>
        /// Retorna um AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAdmGrupoRelUsuario">EntAdmGrupoRelUsuario</returns>
        public List<EntAdmGrupoRelUsuario> ObterPorIdUsuario(Int32 IdUsuario, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmGrupoRelUsuarioPorIdUsuario");
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, IdPrograma);
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, IdUsuario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntAdmGrupoRelUsuario>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntAdmGrupoRelUsuario">Lista de EntAdmGrupoRelUsuario</list></returns>
        public List<EntAdmGrupoRelUsuario> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAdmGrupoRelUsuario");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntAdmGrupoRelUsuario>();
                }
            }
        }

        /// <summary>
        /// Popula AdmGrupoRelUsuario, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntAdmGrupoRelUsuario">Lista de EntAdmGrupoRelUsuario</list></returns>
        private List<EntAdmGrupoRelUsuario> Popular(DbDataReader dtrDados)
        {
            List<EntAdmGrupoRelUsuario> listEntReturn = new List<EntAdmGrupoRelUsuario>();
            EntAdmGrupoRelUsuario entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntAdmGrupoRelUsuario();

                    entReturn.IdGrupoUsuario = ObjectUtils.ToInt(dtrDados["CDA_RELGRUPOUSUARIO"]);
                    entReturn.AdmGrupo.IdGrupo = ObjectUtils.ToInt(dtrDados["CEA_GRUPO"]);
                    entReturn.EscritorioRegional.IdEscritorioRegional = ObjectUtils.ToInt(dtrDados["CEA_ESCRITORIO_REGIONAL"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                    entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);

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
        /// Retorna um Boolean
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="IdUsuario">IdUsuario</returns>
        public Boolean ExisteAssociacao(ref EntAdmGrupoRelUsuario objAdmGrupoRelUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_ExisteAssociacao");
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.Int32, objAdmGrupoRelUsuario.Programa.IdPrograma);
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, objAdmGrupoRelUsuario.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nIdEstado", DbType.Int32, objAdmGrupoRelUsuario.Estado.IdEstado);
            db.AddInParameter(dbCommand, "@nIdEscritorioRegional", DbType.Int32, objAdmGrupoRelUsuario.EscritorioRegional.IdEscritorioRegional);
            db.AddInParameter(dbCommand, "@nIdGrupo", DbType.Int32, objAdmGrupoRelUsuario.AdmGrupo.IdGrupo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    objAdmGrupoRelUsuario = this.Popular(dtrDados)[0];
                    return true;
                }
            }

            return false;
        }
    }
}
