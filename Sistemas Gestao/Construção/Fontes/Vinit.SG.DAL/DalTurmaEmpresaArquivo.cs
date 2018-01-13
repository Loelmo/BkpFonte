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
    /// Classe de Dados que representa um TurmaEmpresaArquivo
    /// </summary>
    public class DalTurmaEmpresaArquivo
    {
        /// <summary>
        /// Retorna um entidade de TurmaEmpresaArquivo
        /// </summary>
        /// <autor>Fernando Carvalo</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTurmaEmpresaArquivo">Lista de EntTurmaEmpresaArquivo</list></returns>
        public EntTurmaEmpresaArquivo ObterPorId(Int32 IdTurmaEmpresaArquivo, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaEmpresaArquivoPorId");
            db.AddInParameter(dbCommand, "@nIdTurmaEmpresaArquivo", DbType.String, IdTurmaEmpresaArquivo);
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
        /// Retorna um entidade de TurmaEmpresaArquivo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTurmaEmpresaArquivo">Lista de EntTurmaEmpresaArquivo</list></returns>
        public List<EntTurmaEmpresaArquivo> ObterPorEmpresaCadastroTurma(Int32 IdEmpresaCadastro, Int32 IdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaEmpresaArquivoPorEmpresaCadastroTurma");
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
                    return new List<EntTurmaEmpresaArquivo>();
                }
            }
        }

        /// <summary>
        /// Inclui um registro na tabela TBL_TURMA_EMPRESA_ARQUIVO
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade que representa a tabela Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Cidade</returns>
        public EntTurmaEmpresaArquivo Inserir(EntTurmaEmpresaArquivo objTurmaEmpresaArquivo, DbTransaction transaction, Database db)
        {
            EntTurmaEmpresaArquivo objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereTurmaEmpresaArquivo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_TURMA_EMPRESA_ARQUIVO", DbType.Int32, objTurmaEmpresaArquivo.IdTurmaEmpresaArquivo);
            db.AddInParameter(dbCommand, "@nCEA_EMPRESA_CADASTRO", DbType.Int32, objTurmaEmpresaArquivo.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objTurmaEmpresaArquivo.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, objTurmaEmpresaArquivo.Usuario.IdUsuario);
            db.AddInParameter(dbCommand, "@sTX_NOME", DbType.String, objTurmaEmpresaArquivo.Nome);
            db.AddInParameter(dbCommand, "@sTX_ARQUIVO", DbType.String, objTurmaEmpresaArquivo.Arquivo);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objTurmaEmpresaArquivo.Ativo);
            db.AddInParameter(dbCommand, "@dDT_CADASTRO", DbType.DateTime, objTurmaEmpresaArquivo.DtCadastro);

            db.ExecuteNonQuery(dbCommand, transaction);

            objTurmaEmpresaArquivo.IdTurmaEmpresaArquivo = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_TURMA_EMPRESA_ARQUIVO"));

            if (objTurmaEmpresaArquivo.IdTurmaEmpresaArquivo != int.MinValue)
                objRetorno = objTurmaEmpresaArquivo;

            return objRetorno;
        }

        /// <summary>
        /// Altera uma Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade da Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntTurmaEmpresaArquivo objTurmaEmpresaArquivo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaTurmaEmpresaArquivo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_TURMA_EMPRESA_ARQUIVO", DbType.Int32, objTurmaEmpresaArquivo.IdTurmaEmpresaArquivo);
            db.AddInParameter(dbCommand, "@nCEA_EMPRESA_CADASTRO", DbType.Int32, objTurmaEmpresaArquivo.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objTurmaEmpresaArquivo.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, objTurmaEmpresaArquivo.Usuario.IdUsuario);
            db.AddInParameter(dbCommand, "@sTX_NOME", DbType.String, objTurmaEmpresaArquivo.Nome);
            db.AddInParameter(dbCommand, "@sTX_ARQUIVO", DbType.String, objTurmaEmpresaArquivo.Arquivo);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objTurmaEmpresaArquivo.Ativo);
            db.AddInParameter(dbCommand, "@dDT_ALTERACAO", DbType.DateTime, objTurmaEmpresaArquivo.DtAlteracao);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Popula TurmaEmpresaArquivo, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntTurmaEmpresaArquivo">Lista de EntTurmaEmpresaArquivo</list></returns>
        private List<EntTurmaEmpresaArquivo> Popular(DbDataReader dtrDados)
        {
            List<EntTurmaEmpresaArquivo> listEntReturn = new List<EntTurmaEmpresaArquivo>();
            EntTurmaEmpresaArquivo entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntTurmaEmpresaArquivo();

                    entReturn.IdTurmaEmpresaArquivo = ObjectUtils.ToInt(dtrDados["CDA_TURMA_EMPRESA_ARQUIVO"]);
                    entReturn.Nome = ObjectUtils.ToString(dtrDados["TX_NOME"]);
                    entReturn.Arquivo = ObjectUtils.ToString(dtrDados["TX_ARQUIVO"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
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
