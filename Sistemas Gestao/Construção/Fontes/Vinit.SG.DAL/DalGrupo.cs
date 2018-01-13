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
    /// Classe de Dados que representa um Grupo
    /// </summary>
    public class DalGrupo
    {
        /// <summary>
        /// Inclui um registro na tabela Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objGrupo">Entidade que representa a tabela Grupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Grupo</returns>
        public EntGrupo Inserir(EntGrupo objGrupo, DbTransaction transaction, Database db)
        {
            EntGrupo objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereGrupo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_GRUPO", DbType.Int32, objGrupo.IdGrupo);
            db.AddInParameter(dbCommand, "@TX_GRUPO", DbType.String, objGrupo.Grupo);
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, objGrupo.Ativo);
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objGrupo.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objGrupo.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@CEA_SETOR", DbType.Int32, objGrupo.Setor.IdSetor);
            db.AddInParameter(dbCommand, "@TX_DESCRICAO", DbType.String, objGrupo.Descricao);

            db.ExecuteNonQuery(dbCommand, transaction);

            objGrupo.IdGrupo = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_GRUPO"));

            if (objGrupo.IdGrupo != int.MinValue)
                objRetorno = objGrupo;

            return objRetorno;
        }

        /// <summary>
        /// Altera um Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objGrupo">Entidade do Grupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntGrupo objGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaGrupo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_GRUPO", DbType.Int32, objGrupo.IdGrupo);
            db.AddInParameter(dbCommand, "@TX_GRUPO", DbType.String, objGrupo.Grupo);
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, objGrupo.Ativo);
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objGrupo.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, objGrupo.Estado.IdEstado);
            db.AddInParameter(dbCommand, "@CEA_SETOR", DbType.Int32, objGrupo.Setor.IdSetor);
            db.AddInParameter(dbCommand, "@TX_DESCRICAO", DbType.String, objGrupo.Descricao);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Excluir um Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="IdGrupo">Id do Grupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaGrupoPorId");
            db.AddInParameter(dbCommand, "@nCDA_GRUPO", DbType.Int32, IdGrupo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntGrupo">EntGrupo</returns>
        public EntGrupo ObterPorId(Int32 IdGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaGrupoPorId");
            db.AddInParameter(dbCommand, "@CDA_GRUPO", DbType.String, IdGrupo);
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
        /// Retorna um Grupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntGrupo">EntGrupo</returns>
        public List<EntGrupo> ObterPorIdTurmaEstado(Int32 IdTurma, Int32 IdEstado, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaGrupoPorIdTurmaEstado");
            db.AddInParameter(dbCommand, "@IdTurma", DbType.String, IntUtils.ToIntNull(IdTurma));
            db.AddInParameter(dbCommand, "@IdEstado", DbType.String, IntUtils.ToIntNull(IdEstado));
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntGrupo>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntGrupo">Lista de EntGrupo</list></returns>
        public List<EntGrupo> ObterTodosAtivos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaGruposAtivos");
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
        /// Popula Grupo, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntGrupo">Lista de EntGrupo</list></returns>
        private List<EntGrupo> Popular(DbDataReader dtrDados)
        {
            List<EntGrupo> listEntReturn = new List<EntGrupo>();
            EntGrupo entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntGrupo();

                    entReturn.IdGrupo = ObjectUtils.ToInt(dtrDados["CDA_GRUPO"]);
                    entReturn.Grupo = ObjectUtils.ToString(dtrDados["TX_GRUPO"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.Setor.IdSetor = ObjectUtils.ToInt(dtrDados["CEA_SETOR"]);
                    entReturn.Descricao = ObjectUtils.ToString(dtrDados["TX_DESCRICAO"]);

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
        /// Altera uma Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objGrupo">Entidade de Grupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AtivaDesativaGrupo(EntGrupo objGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtivaDesativaGrupo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_GRUPO", DbType.Int32, objGrupo.IdGrupo);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Int32, objGrupo.Ativo);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um Boolean
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>     
        public Boolean ExisteGrupoPorTurma(String Grupo, Int32 IdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_ExisteGrupoPorTurma");
            db.AddInParameter(dbCommand, "@sGrupo", DbType.String, Grupo);
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            Int32 count = (Int32)db.ExecuteScalar(dbCommand, transaction);

            return count > 0;
        }
    }
}
