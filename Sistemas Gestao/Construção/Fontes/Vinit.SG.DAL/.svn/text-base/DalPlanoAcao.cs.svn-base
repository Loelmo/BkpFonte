using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.Ent;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using Vinit.SG.Common;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa um PlanoAcao
    /// </summary>
    public class DalPlanoAcao
    {
        /// <summary>
        /// Retorna um entidade de PlanoAcao
        /// </summary>
        /// <autor>Fernando Carvalo</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPlanoAcao">Lista de EntPlanoAcao</list></returns>
        public EntPlanoAcao ObterPorId(Int32 IdPlanoAcao, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaPlanoAcaoPorId");
            db.AddInParameter(dbCommand, "@nIdPlanoAcao", DbType.Int32, IdPlanoAcao);
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
        /// Retorna um entidade de PlanoAcao
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPlanoAcao">Lista de EntPlanoAcao</list></returns>
        public List<EntPlanoAcao> ObterPorEmpresaCadastroTurma(Int32 IdEmpresaCadastro, Int32 IdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaPlanoAcaoPorEmpresaCadastroTurma");
            db.AddInParameter(dbCommand, "@IdEmpresaCadastro", DbType.Int32, IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@IdTurma", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntPlanoAcao>();
                }
            }
        }

        /// <summary>
        /// Inclui um registro na tabela TBL_PLANO_ACAO
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade que representa a tabela Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Cidade</returns>
        public EntPlanoAcao Inserir(EntPlanoAcao objPlanoAcao, DbTransaction transaction, Database db)
        {
            EntPlanoAcao objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InserePlanoAcao");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_PLANO_ACAO", DbType.Int32, objPlanoAcao.IdPlanoAcao);
            db.AddInParameter(dbCommand, "@nCEA_EMPRESA_CADASTRO", DbType.Int32, objPlanoAcao.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objPlanoAcao.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, objPlanoAcao.Usuario.IdUsuario);
            db.AddInParameter(dbCommand, "@sTX_PLANO_ACAO", DbType.String, objPlanoAcao.PlanoAcao);
            db.AddInParameter(dbCommand, "@sTX_ACAO_CORRESPONDENTE", DbType.String, objPlanoAcao.AcaoCorrespondente);
            db.AddInParameter(dbCommand, "@sTX_PONTO_MELHORIA", DbType.String, objPlanoAcao.PontoMelhoria);
            db.AddInParameter(dbCommand, "@sTX_PRAZO", DbType.String, objPlanoAcao.Prazo);
            db.AddInParameter(dbCommand, "@sTX_RESPONSAVEL", DbType.String, objPlanoAcao.Responsavel);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objPlanoAcao.Ativo);
            db.AddInParameter(dbCommand, "@bFL_EVOLUCAO", DbType.Boolean, objPlanoAcao.Evolucao);
            db.AddInParameter(dbCommand, "@dDT_CADASTRO", DbType.DateTime, objPlanoAcao.DtCadastro);

            db.ExecuteNonQuery(dbCommand, transaction);

            objPlanoAcao.IdPlanoAcao = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_PLANO_ACAO"));

            if (objPlanoAcao.IdPlanoAcao != int.MinValue)
                objRetorno = objPlanoAcao;

            return objRetorno;
        }

        /// <summary>
        /// Altera uma Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade da Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntPlanoAcao objPlanoAcao, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaPlanoAcao");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_PLANO_ACAO", DbType.Int32, objPlanoAcao.IdPlanoAcao);
            db.AddInParameter(dbCommand, "@nCEA_EMPRESA_CADASTRO", DbType.Int32, objPlanoAcao.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objPlanoAcao.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, objPlanoAcao.Usuario.IdUsuario);
            db.AddInParameter(dbCommand, "@sTX_PLANO_ACAO", DbType.String, objPlanoAcao.PlanoAcao);
            db.AddInParameter(dbCommand, "@sTX_ACAO_CORRESPONDENTE", DbType.String, objPlanoAcao.AcaoCorrespondente);
            db.AddInParameter(dbCommand, "@sTX_PONTO_MELHORIA", DbType.String, objPlanoAcao.PontoMelhoria);
            db.AddInParameter(dbCommand, "@sTX_PRAZO", DbType.String, objPlanoAcao.Prazo);
            db.AddInParameter(dbCommand, "@sTX_RESPONSAVEL", DbType.String, objPlanoAcao.Responsavel);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objPlanoAcao.Ativo);
            db.AddInParameter(dbCommand, "@bFL_EVOLUCAO", DbType.Boolean, objPlanoAcao.Evolucao);
            db.AddInParameter(dbCommand, "@dDT_ALTERACAO", DbType.DateTime, objPlanoAcao.DtAlteracao);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Popula PlanoAcao, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntPlanoAcao">Lista de EntPlanoAcao</list></returns>
        private List<EntPlanoAcao> Popular(DbDataReader dtrDados)
        {
            List<EntPlanoAcao> listEntReturn = new List<EntPlanoAcao>();
            EntPlanoAcao entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntPlanoAcao();

                    entReturn.IdPlanoAcao = ObjectUtils.ToInt(dtrDados["CDA_PLANO_ACAO"]);
                    entReturn.PlanoAcao = ObjectUtils.ToString(dtrDados["TX_PLANO_ACAO"]);
                    entReturn.AcaoCorrespondente = ObjectUtils.ToString(dtrDados["TX_ACAO_CORRESPONDENTE"]);
                    entReturn.PontoMelhoria = ObjectUtils.ToString(dtrDados["TX_PONTO_MELHORIA"]);
                    entReturn.Prazo = ObjectUtils.ToString(dtrDados["TX_PRAZO"]);
                    entReturn.Responsavel = ObjectUtils.ToString(dtrDados["TX_RESPONSAVEL"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.Evolucao = ObjectUtils.ToBoolean(dtrDados["FL_EVOLUCAO"]);
                    entReturn.DtCadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                    entReturn.DtAlteracao = ObjectUtils.ToDate(dtrDados["DT_ALTERACAO"]);
                    entReturn.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CEA_EMPRESA_CADASTRO"]);
                    entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                    entReturn.Usuario.IdUsuario = ObjectUtils.ToInt(dtrDados["CEA_USUARIO"]);
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
