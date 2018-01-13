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
    /// Classe de Dados que representa uma Etapa
    /// </summary>
    public class DalEtapa
    {

        /// <summary>
        /// Retorna uma lista de entidade de Etapas
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapa">Lista de EntEtapa</list></returns>
        public List<EntEtapa> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEtapa");
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
        /// Retorna um entidade de Etapa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapa">Lista de EntEtapa</list></returns>
        public EntEtapa ObterAtivaPorIdEstado(Int32 nIdEstado, Int32 nTipoEtapa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEtapaAtivaPorEstado");
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, nIdEstado);
            db.AddInParameter(dbCommand, "@nCEA_TIPO_ETAPA", DbType.Int32, nTipoEtapa);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, true);
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
        /// Retorna um entidade de Etapa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapa">Lista de EntEtapa</list></returns>
        public List<EntEtapa> ObterAtivaPorIdEstadoIdTurma(Int32 nIdEstado, Int32 nTipoEtapa, Int32 nIdTurma, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEtapaAtivaPorEstadoTurma");
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, nIdEstado);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, nIdTurma);
            db.AddInParameter(dbCommand, "@nCEA_TIPO_ETAPA", DbType.Int32, nTipoEtapa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCustom(dtrDados);
                }
                else
                {
                    return new List<EntEtapa>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Etapa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapa">Lista de EntEtapa</list></returns>
        public EntEtapa ObterProximaEtapaPorEtapaEstadoOrdem(Int32 IdEtapa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaProximaEtapaPorEtapaEstadoOrdem");
            db.AddInParameter(dbCommand, "@nCEA_ETAPA", DbType.Int32, IdEtapa);
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
        /// Retorna um entidade de Etapa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapa">Lista de EntEtapa</list></returns>
        public EntEtapa ObterEtapaAnteriorPorEtapaEstadoOrdem(Int32 IdEtapa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEtapaAnteriorPorEtapaEstadoOrdem");
            db.AddInParameter(dbCommand, "@nCEA_ETAPA", DbType.Int32, IdEtapa);
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
        /// Retorna um entidade de Etapa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapa">Lista de EntEtapa</list></returns>
        public List<EntEtapa> ObterPorIdEstado(Int32 nIdEstado, Int32 nTipoEtapa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEtapaPorEstado");
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, nIdEstado);
            db.AddInParameter(dbCommand, "@nCEA_TIPO_ETAPA", DbType.Int32, nTipoEtapa);
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
        /// Retorna um entidade de Etapa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapa">Lista de EntEtapa</list></returns>
        public List<EntEtapa> ObterEtapasEstaduais(Int32 IdTurma, Int32 IdEstado, Int32 IdUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEtapasEstadual");
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, IdEstado);
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
                    return new List<EntEtapa>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Etapa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapa">Lista de EntEtapa</list></returns>
        public List<EntEtapa> ObterEtapasNacionais(Int32 IdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEtapasNacionais");
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntEtapa>();
                }
            }
        }
        
        /// <summary>
        /// Retorna uma entidade de Etapa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapa">EntEtapa</list></returns>
        public EntEtapa ObterPorId(Int32 nIdEtapa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEtapaPorId");
            db.AddInParameter(dbCommand, "@nCDA_ETAPA", DbType.Int32, nIdEtapa);
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
        /// Retorna uma entidade de Etapa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapa">EntEtapa</list></returns>
        public EntEtapa ObterPorTipoEtapaTurma(Int32 nIdTipoEtapa, Int32 nIdTurma, Int32 nIdEstado, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEtapaPorTipoEtapaTurmaEstado");
            db.AddInParameter(dbCommand, "@nCEA_TIPO_ETAPA", DbType.Int32, nIdTipoEtapa);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IntUtils.ToIntNull(nIdTurma));
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(nIdEstado));
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return new EntEtapa();
                }
            }
        }

        /// <summary>
        /// Altera uma Etapa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objEtapa">Entidade de Etapa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AtivaDesativaEtapa(EntEtapa objEtapa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtivaDesativaEtapa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_ETAPA", DbType.Int32, objEtapa.IdEtapa);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objEtapa.Ativo);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera uma Etapa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objEtapa">Entidade de Etapa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void DesativaEtapasAnteriores(Int32 IdTurma, Int32 NuOrdemFluxo, Int32 IdEstado, Boolean FlNacional, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DesativaEtapasAnteriores");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            db.AddInParameter(dbCommand, "@NU_ORDEM_FLUXO", DbType.Int32, NuOrdemFluxo);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IdEstado);
            db.AddInParameter(dbCommand, "@FL_NACIONAL", DbType.Boolean, FlNacional);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna uma entidade de Etapa
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEtapa">EntEtapa</list></returns>
        public List<EntEtapa> ObterPorTurma(Int32 nIdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEtapaPorTurma");
            db.AddInParameter(dbCommand, "@nIdTURMA", DbType.Int32, nIdTurma);
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
        /// Popula Etapa, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntEtapa">Lista de EntEtapa</list></returns>
        private List<EntEtapa> Popular(DbDataReader dtrDados)
        {
            List<EntEtapa> listEntReturn = new List<EntEtapa>();
            EntEtapa entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntEtapa();

                    entReturn.IdEtapa = ObjectUtils.ToInt(dtrDados["CDA_Etapa"]);
                    entReturn.Etapa = ObjectUtils.ToString(dtrDados["TX_ETAPA"]);
                    entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                    entReturn.TipoEtapa.IdTipoEtapa = ObjectUtils.ToInt(dtrDados["CEA_TIPO_ETAPA"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);

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
        /// Popula Etapa, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntEtapa">Lista de EntEtapa</list></returns>
        private List<EntEtapa> PopularCustom(DbDataReader dtrDados)
        {
            List<EntEtapa> listEntReturn = new List<EntEtapa>();
            EntEtapa entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntEtapa();

                    entReturn.IdEtapa = ObjectUtils.ToInt(dtrDados["CDA_Etapa"]);
                    entReturn.Etapa = ObjectUtils.ToString(dtrDados["TX_ETAPA"]);
                    entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                    entReturn.TipoEtapa.IdTipoEtapa = ObjectUtils.ToInt(dtrDados["CEA_TIPO_ETAPA"]);
                    entReturn.TipoEtapa.TipoEtapa = ObjectUtils.ToString(dtrDados["TX_TIPO_ETAPA"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.Estado.Estado = ObjectUtils.ToString(dtrDados["TX_ESTADO"]);

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
        /// Inclui um registro na tabela EnEntEtapa        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objTurmaQuestionario">Entidade que representa a tabela Turma_Questionario</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de TurmaQuestionario</returns>
        public EntEtapa Inserir(EntEtapa objEtapa, DbTransaction transaction, Database db)
        {
            EntEtapa objRetorno = objEtapa;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereEtapa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@CDA_ETAPA", DbType.Int32, objEtapa.IdEtapa);
            db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, IntUtils.ToIntNull(objEtapa.TipoEtapa.IdTipoEtapa));
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, IntUtils.ToIntNull(objEtapa.Turma.IdTurma));
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objEtapa.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, objEtapa.Ativo);
            db.AddInParameter(dbCommand, "@TX_ETAPA", DbType.String, objEtapa.Etapa);

            db.ExecuteNonQuery(dbCommand, transaction);

            objRetorno.IdEtapa = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@CDA_ETAPA"));

            return objRetorno;
           
        }

        /// <summary>
        /// Excluir etapas da turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="IdTurma">Id da Turma</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void ExcluirTodosPorTurma(int IdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaEtapaPorTurma");
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

    }
}