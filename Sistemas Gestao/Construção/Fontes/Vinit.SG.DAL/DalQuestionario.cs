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
    /// Classe de Dados que representa um Turma
    /// </summary>
    public class DalQuestionario
    {

        /// <summary>
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionario">Lista de EntQuestionario</list></returns>
        public EntQuestionario ObterPorId(Int32 nIdQuestionario, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioPorId");
            db.AddInParameter(dbCommand, "@nIdQuestionario", DbType.Int32, nIdQuestionario);
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
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionario">Lista de EntQuestionario</list></returns>
        public List<EntQuestionario> ObterObrigatoriosPorIdTurma(Int32 nIdTurma, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionariosObrigatoriosPorTurma");
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, nIdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntQuestionario>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionario">Lista de EntQuestionario</list></returns>
        public List<EntQuestionario> ObterAbertosPorIdTurmaIdEmpresa(Int32 nIdTurma, Int32 nIdEmpCadastro, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionariosAbertosPorTurmaEmpresa");
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, nIdTurma);
            db.AddInParameter(dbCommand, "@nIdEmpCadastro", DbType.Int32, nIdEmpCadastro);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntQuestionario>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionario">Lista de EntQuestionario</list></returns>
        public List<EntQuestionario> ObterEnviadosPorIdTurmaIdEmpresa(Int32 nIdTurma, Int32 nIdEmpCadastro, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionariosEnviadosPorTurmaEmpresa");
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, nIdTurma);
            db.AddInParameter(dbCommand, "@nIdEmpCadastro", DbType.Int32, nIdEmpCadastro);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntQuestionario>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionario">Lista de EntQuestionario</list></returns>
        public List<EntQuestionario> ObterEnviadosPorIdEtapaIdEmpresa(Int32 nIdEtapa, Int32 nIdEmpCadastro, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionariosEnviadosPorEtapaEmpresa");
            db.AddInParameter(dbCommand, "@nIdEtapa", DbType.Int32, nIdEtapa);
            db.AddInParameter(dbCommand, "@nIdEmpCadastro", DbType.Int32, nIdEmpCadastro);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntQuestionario>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionario">Lista de EntQuestionario</list></returns>
        public List<EntQuestionario> ObterAbertosPorIdTurmaIdEmpresaIdEtapa(Int32 nIdTurma, Int32 nIdEmpCadastro, Int32 nIdEtapa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionariosAbertosPorTurmaEmpresaEtapa");
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, nIdTurma);
            db.AddInParameter(dbCommand, "@nIdEmpCadastro", DbType.Int32, nIdEmpCadastro);
            db.AddInParameter(dbCommand, "@nIdEtapa", DbType.Int32, nIdEtapa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntQuestionario>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionario">Lista de EntQuestionario</list></returns>
        public EntQuestionario ObterPorIdTurmaIdQuestionarioEmpresa(Int32 nIdTurma, Int32 nIdQuestionarioEmpresa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionariosPorTurmaQuestionarioEmpresa");
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, nIdTurma);
            db.AddInParameter(dbCommand, "@nIdQuestionarioEmpresa", DbType.Int32, nIdQuestionarioEmpresa);
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
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionario">Lista de EntQuestionario</list></returns>
        public List<EntQuestionario> ObterPorIdTurma(Int32 nIdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionariosPorTurma");
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, nIdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntQuestionario>();
                }
            }
        }


        /// <summary>
        /// Retorna um entidade de Questionario
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionario">Lista de EntQuestionario</list></returns>
        public List<EntQuestionario> ObterTodosNaoRelacionadosNaTuma(Int32 nIdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionariosNaoRelacionadosNaTurma");
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, nIdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntQuestionario>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Questionario
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionario">Lista de EntQuestionario</list></returns>
        public List<EntQuestionario> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarios");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntQuestionario>();
                }
            }
        }

        /// <summary>
        /// Popula Turma, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntQuestionario">Lista de EntQuestionario</list></returns>
        private List<EntQuestionario> Popular(DbDataReader dtrDados)
        {
            List<EntQuestionario> listEntReturn = new List<EntQuestionario>();
            EntQuestionario entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntQuestionario();

                    entReturn.IdQuestionario = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO"]);
                    entReturn.Questionario = ObjectUtils.ToString(dtrDados["TX_QUESTIONARIO"]);
                    entReturn.Descricao = ObjectUtils.ToString(dtrDados["TX_DESCRICAO"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    
                    try
                    {
                        entReturn.PreenchimentoRapido = ObjectUtils.ToBoolean(dtrDados["FL_PREENCHIMENTO_RAPIDO"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.Obrigatorio = ObjectUtils.ToBoolean(dtrDados["FL_OBRIGATORIO"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.Protocolo = ObjectUtils.ToString(dtrDados["TX_PROTOCOLO"]);
                    }
                    catch { }

                    entReturn.Publicado = ObjectUtils.ToBoolean(dtrDados["FL_PUBLICADO"]);
                    entReturn.Ciclo = ObjectUtils.ToInt(dtrDados["NU_CICLO"]);
                    entReturn.DtQuestionario = ObjectUtils.ToDate(dtrDados["DT_QUESTIONARIO"]);
                    try
                    {
                        entReturn.EmpresaParticipa = ObjectUtils.ToBoolean(dtrDados["FL_PREENCHE_QUESTIONARIO"]);
                    }catch{}
                    try
                    {
                        entReturn.PorcentagemPreenchida = ObjectUtils.ToInt(dtrDados["PORCENTAGEM"]);
                        if (entReturn.PorcentagemPreenchida > 100)
                        {
                            entReturn.PorcentagemPreenchida = 100;
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
