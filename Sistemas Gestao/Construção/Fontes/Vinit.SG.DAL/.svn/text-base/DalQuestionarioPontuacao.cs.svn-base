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
    /// Classe de Dados que representa um Questionario Empresa
    /// </summary>
    public class DalQuestionarioPontuacao
    {
        /// <summary>
        /// Popula Questionario Empresa Pontuacao, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        private List<EntQuestionarioPontuacao> Popular(DbDataReader dtrDados)
        {
            List<EntQuestionarioPontuacao> listEntReturn = new List<EntQuestionarioPontuacao>();
            EntQuestionarioPontuacao entReturn;

            try
            {
                foreach (DbDataRecord DataRecord in dtrDados)
                {
                    entReturn = new EntQuestionarioPontuacao();
                    entReturn = PopularRow(DataRecord);
                    listEntReturn.Add(entReturn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listEntReturn;
        }

        /// <summary>
        /// Popula Questionario Empresa Pontuacao, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        private EntQuestionarioPontuacao PopularRow(DbDataRecord DataRecord)
        {
            EntQuestionarioPontuacao entReturn;

            try
            {
                entReturn = new EntQuestionarioPontuacao();

                entReturn.QuestionarioEmpresa.IdQuestionarioEmpresa = ObjectUtils.ToInt(DataRecord["CEA_QUESTIONARIO_EMPRESA"]);
                entReturn.Questionario.IdQuestionario = ObjectUtils.ToInt(DataRecord["CEA_QUESTIONARIO"]);
                entReturn.Avaliador = ObjectUtils.ToBoolean(DataRecord["FL_AVALIADOR"]);
                entReturn.Criterio.IdCriterio = ObjectUtils.ToInt(DataRecord["CEA_CRITERIO"]);
                entReturn.Ponto = ObjectUtils.ToDecimal(DataRecord["NU_PONTO"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entReturn;
        }

        /// <summary>
        /// Retorna um entidade de Questionario Empresa Avaliador
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresaAvaliador</list></returns>
        public List<EntQuestionarioPontuacao> ObterPorIdQuestionarioEmpresa(Int32 IdQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioPontuacaoPorIdQuestionarioEmpresa");
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO_EMPRESA", DbType.Int32, IdQuestionarioEmpresa);
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
        /// Retorna uma lista de Questionario Pontuacao
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioPontuacao</list></returns>
        public List<EntQuestionarioPontuacao> ObterPorQuestionarioEmpresa(Int32 IdQuestionarioEmpresa, Boolean IsAvaliador, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioPontuacaoPorQuestionarioEmpresa");
            db.AddInParameter(dbCommand, "@nIdQuestionarioEmpresa", DbType.Int32, IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@bIsAvaliador", DbType.Boolean, IsAvaliador);
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
        /// Retorna um entidade de Questionario Pontuação
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioPontuacao</list></returns>
        public List<EntQuestionarioPontuacao> ObterPorQuestionario(Int32 IdEmpresaCadastro, Int32 IdTurma,  Int32 IdQuestionario, Boolean IsAvaliador, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioPontuacaoPorQuestionario");
            db.AddInParameter(dbCommand, "@nIdEmpresaCadastro", DbType.Int32, IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, IdTurma);
            db.AddInParameter(dbCommand, "@nIdQuestionario", DbType.Int32, IdQuestionario);
            db.AddInParameter(dbCommand, "@bIsAvaliador", DbType.Boolean, IsAvaliador);
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
        /// Retorna um entidade de Questionario Pontuação
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioPontuacao</list></returns>
        public void ExcluirPorIdQuestionarioEmpresa(Int32 IdQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaQuestionarioPontuacaoPorIdQuestionarioEmpresa");
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO_EMPRESA", DbType.Int32, IdQuestionarioEmpresa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Inclui um registro na tabela
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objCidade">Entidade que representa a tabela Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Cidade</returns>
        public void Inserir(EntQuestionarioPontuacao objQuestionarioPontuacao, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereQuestionarioPontuacao");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioPontuacao.QuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@nCEA_CRITERIO", DbType.Int32, objQuestionarioPontuacao.Criterio.IdCriterio);
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, objQuestionarioPontuacao.Questionario.IdQuestionario);
            db.AddInParameter(dbCommand, "@nNU_PONTO", DbType.Decimal, objQuestionarioPontuacao.Ponto);
            db.AddInParameter(dbCommand, "@FL_AVALIADOR", DbType.Boolean, objQuestionarioPontuacao.Avaliador);

            db.ExecuteNonQuery(dbCommand, transaction);
        }
    }
}
