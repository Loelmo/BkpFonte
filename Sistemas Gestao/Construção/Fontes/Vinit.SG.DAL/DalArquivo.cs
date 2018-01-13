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
    /// Classe de Dados que representa um Arquivo
    /// </summary>
    public class DalArquivo
    {
        /// <summary>
        /// Inclui um registro na tabela Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objArquivo">Entidade que representa a tabela Arquivo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Arquivo</returns>
        public EntArquivo Inserir(EntArquivo objArquivo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereArquivo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_ARQUIVO", DbType.Int32, objArquivo.IdArquivo);
            db.AddInParameter(dbCommand, "@nNUM_PRIORIDADE", DbType.Int32, objArquivo.Prioridade);
            db.AddInParameter(dbCommand, "@sTX_TITULO", DbType.String, objArquivo.Titulo);
            db.AddInParameter(dbCommand, "@sTX_CAMINHO", DbType.String, objArquivo.Arquivo);
            db.AddInParameter(dbCommand, "@DT_CADASTRO", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "@DT_ALTERACAO", DbType.DateTime, objArquivo.DataAlteracao);
            if(objArquivo.Estado.IdEstado > 0)
                db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, objArquivo.Estado.IdEstado);
            else
                db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, DBNull.Value);
            if (objArquivo.Programa.IdPrograma > 0)
                db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, objArquivo.Programa.IdPrograma);
            else
                db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, DBNull.Value);
            if (objArquivo.Turma.IdTurma > 0)
                db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objArquivo.Turma.IdTurma);
            else
                db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, DBNull.Value);

            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objArquivo.Ativo);
            db.AddInParameter(dbCommand, "@bFL_USUARIO_ADMINISTRATIVO", DbType.Boolean, objArquivo.UsuarioAdministrativo);

            db.ExecuteNonQuery(dbCommand, transaction);

            objArquivo.IdArquivo = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_ARQUIVO"));

            return objArquivo;
        }

        /// <summary>
        /// Altera um Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objArquivo">Entidade do Arquivo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntArquivo objArquivo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaArquivo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_ARQUIVO", DbType.Int32, objArquivo.IdArquivo);
            db.AddInParameter(dbCommand, "@nNUM_PRIORIDADE", DbType.Int32, objArquivo.Prioridade);
            db.AddInParameter(dbCommand, "@sTX_TITULO", DbType.String, objArquivo.Titulo);
            db.AddInParameter(dbCommand, "@sTX_CAMINHO", DbType.String, objArquivo.Arquivo);
            db.AddInParameter(dbCommand, "@DT_ALTERACAO", DbType.DateTime, objArquivo.DataAlteracao);
            if (objArquivo.Estado.IdEstado > 0)
                db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, objArquivo.Estado.IdEstado);
            else
                db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, DBNull.Value);
            if (objArquivo.Programa.IdPrograma > 0)
                db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, objArquivo.Programa.IdPrograma);
            else
                db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, DBNull.Value);
            if (objArquivo.Turma.IdTurma > 0)
                db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objArquivo.Turma.IdTurma);
            else
                db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, DBNull.Value);

            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objArquivo.Ativo);
            db.AddInParameter(dbCommand, "@bFL_USUARIO_ADMINISTRATIVO", DbType.Boolean, objArquivo.UsuarioAdministrativo);

            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Excluir um Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="IdArquivo">Id do Arquivo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdArquivo, Boolean flAtivo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaArquivoPorId");
            db.AddInParameter(dbCommand, "@nCDA_ARQUIVO", DbType.Int32, IdArquivo);
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, flAtivo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntArquivo">EntArquivo</returns>
        public EntArquivo ObterPorId(Int32 IdArquivo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaArquivoPorId");
            db.AddInParameter(dbCommand, "@nCDA_ARQUIVO", DbType.Int32, IdArquivo);
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
        /// Retorna uma lista de entidade de Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntArquivoCustom">EntArquivoCustom</returns>
        public List<EntArquivo> ObterPorFiltrosAdministrativo(Int32 IdUsuario, Int32 IdEstado, Int32 IdPrograma, Int32 IdTurma, String Titulo, DateTime DataInicio, DateTime DataFim, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaArquivoPorFiltrosAdministrativo");
            db.AddInParameter(dbCommand, "@IdUsuario", DbType.Int32, IdUsuario);
            db.AddInParameter(dbCommand, "@IdEstado", DbType.Int32, IdEstado);
            db.AddInParameter(dbCommand, "@IdPrograma", DbType.Int32, IdPrograma);
            db.AddInParameter(dbCommand, "@IdTurma", DbType.Int32, IdTurma);
            db.AddInParameter(dbCommand, "@Titulo", DbType.String, Titulo);
            db.AddInParameter(dbCommand, "@DataInicio", DbType.DateTime, DataInicio);
            db.AddInParameter(dbCommand, "@DataFim", DbType.DateTime, DataFim);
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
        /// Retorna uma lista de entidade de Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntArquivoCustom">EntArquivoCustom</returns>
        public List<EntArquivo> ObterPorFiltro(EntArquivo entArquivo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaArquivoPorFiltro");
            db.AddInParameter(dbCommand, "@Titulo", DbType.String, entArquivo.Titulo);
            if (entArquivo.Prioridade > 0)
                db.AddInParameter(dbCommand, "@nNUM_PRIORIDADE", DbType.Int32, entArquivo.Prioridade);
            else
                db.AddInParameter(dbCommand, "@nNUM_PRIORIDADE", DbType.Int32, DBNull.Value);
            if (entArquivo.DataCadastroFiltroInicial != null && entArquivo.DataCadastroFiltroInicial.Year > 1990)
                db.AddInParameter(dbCommand, "@DataInicio", DbType.DateTime, entArquivo.DataCadastroFiltroInicial);
            else
                db.AddInParameter(dbCommand, "@DataInicio", DbType.DateTime, DBNull.Value);
            if (entArquivo.DataCadastroFiltroFinal != null && entArquivo.DataCadastroFiltroFinal.Year > 1990)
                db.AddInParameter(dbCommand, "@DataFim", DbType.DateTime, entArquivo.DataCadastroFiltroFinal);
            else
                db.AddInParameter(dbCommand, "@DataFim", DbType.DateTime, DBNull.Value);
            db.AddInParameter(dbCommand, "@TipoUsuario", DbType.Boolean, entArquivo.UsuarioAdministrativo);
            if (entArquivo.IdGrupoFiltro > 0)
                db.AddInParameter(dbCommand, "@IdGrupo", DbType.Int32, entArquivo.IdGrupoFiltro);
            else
                db.AddInParameter(dbCommand, "@IdGrupo", DbType.Int32, DBNull.Value);
            if (entArquivo.Estado.IdEstado > 0)
                db.AddInParameter(dbCommand, "@IdEstado", DbType.Int32, entArquivo.Estado.IdEstado);
            else
                db.AddInParameter(dbCommand, "@IdEstado", DbType.Int32, DBNull.Value);
            if (entArquivo.Programa.IdPrograma > 0)
                db.AddInParameter(dbCommand, "@IdPrograma", DbType.Int32, entArquivo.Programa.IdPrograma);
            else
                db.AddInParameter(dbCommand, "@IdPrograma", DbType.Int32, DBNull.Value);
            if (entArquivo.Turma.IdTurma > 0)
                db.AddInParameter(dbCommand, "@IdTurma", DbType.Int32, entArquivo.Turma.IdTurma);
            else
                db.AddInParameter(dbCommand, "@IdTurma", DbType.Int32, DBNull.Value);
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, entArquivo.Ativo);
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
        /// Retorna uma lista de entidade de Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntArquivoCustom">EntArquivoCustom</returns>
        public List<EntArquivo> ObterPorEmpresa(Int32 IdEstado, Int32 IdPrograma, Int32 IdTurma, String Titulo, DateTime DataInicio, DateTime DataFim, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaArquivoPorEmpresa");
            db.AddInParameter(dbCommand, "@IdEstado", DbType.Int32, IdEstado);
            db.AddInParameter(dbCommand, "@IdPrograma", DbType.Int32, IdPrograma);
            db.AddInParameter(dbCommand, "@IdTurma", DbType.Int32, IdTurma);
            db.AddInParameter(dbCommand, "@Titulo", DbType.String, Titulo);
            db.AddInParameter(dbCommand, "@DataInicio", DbType.DateTime, DataInicio);
            db.AddInParameter(dbCommand, "@DataFim", DbType.DateTime, DataFim);
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
        /// Popula Arquivo, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntArquivo">Lista de EntArquivo</list></returns>
        private List<EntArquivo> Popular(DbDataReader dtrDados)
        {
            List<EntArquivo> listEntReturn = new List<EntArquivo>();
            EntArquivo entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntArquivo();

                    entReturn.IdArquivo = ObjectUtils.ToInt(dtrDados["CDA_ARQUIVO"]);
                    entReturn.Prioridade = ObjectUtils.ToInt(dtrDados["NUM_PRIORIDADE"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);
                    entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                    entReturn.Titulo = ObjectUtils.ToString(dtrDados["TX_TITULO"]);
                    entReturn.Arquivo = ObjectUtils.ToString(dtrDados["TX_CAMINHO"]);
                    entReturn.DataCadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                    entReturn.DataAlteracao = ObjectUtils.ToDate(dtrDados["DT_ALTERACAO"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.UsuarioAdministrativo = ObjectUtils.ToBoolean(dtrDados["FL_USUARIO_ADMINISTRATIVO"]);
                    try
                    {
                        entReturn.Estado.Estado = ObjectUtils.ToString(dtrDados["TX_ESTADO"]);
                    }catch{ }
                    try
                    {
                        entReturn.Programa.Programa = ObjectUtils.ToString(dtrDados["TX_PROGRAMA"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.Turma.Turma = ObjectUtils.ToString(dtrDados["TX_CICLO"]);
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
