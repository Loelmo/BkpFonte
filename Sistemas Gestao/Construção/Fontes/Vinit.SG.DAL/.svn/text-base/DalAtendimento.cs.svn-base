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
    /// Classe de Dados que representa um Atendimento
    /// </summary>
    public class DalAtendimento
    {
        /// <summary>
        /// Inclui um registro na tabela Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objAtendimento">Entidade que representa a tabela Atendimento</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Atendimento</returns>
        public EntAtendimento Inserir(EntAtendimento objAtendimento, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereAtendimento");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_ATENDIMENTO", DbType.Int32, objAtendimento.IdAtendimento);
            db.AddInParameter(dbCommand, "@nCEA_ATENDIMENTO_SISTEMA", DbType.Int32, objAtendimento.AtendimentoSistema.IdAtendimentoSistema);
            db.AddInParameter(dbCommand, "@nCEA_ATENDIMENTO_STATUS", DbType.Int32, objAtendimento.AtendimentoStatus.IdAtendimentoStatus);
            db.AddInParameter(dbCommand, "@nCEA_ATENDIMENTO_TIPO", DbType.Int32, objAtendimento.AtendimentoTipo.IdAtendimentoTipo);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objAtendimento.Ativo);
            db.AddInParameter(dbCommand, "@DT_CADASTRO", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "@DT_ALTERACAO", DbType.DateTime, objAtendimento.DataAlteracao);
            db.AddInParameter(dbCommand, "@sTX_DESCRICAO", DbType.String, objAtendimento.Descricao);
            db.AddInParameter(dbCommand, "@sTX_TITULO", DbType.String, objAtendimento.Titulo);
            if (objAtendimento.EmpresaOrigem.IdEmpresaCadastro > 0)
                db.AddInParameter(dbCommand, "@nCEA_EMPRESA_ORIGEM", DbType.String, objAtendimento.EmpresaOrigem.IdEmpresaCadastro);
            else
                db.AddInParameter(dbCommand, "@nCEA_EMPRESA_ORIGEM", DbType.String, DBNull.Value);
            if (objAtendimento.UsuarioOrigem.IdUsuario > 0)
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_ORIGEM", DbType.String, objAtendimento.UsuarioOrigem.IdUsuario);
            else
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_ORIGEM", DbType.String, DBNull.Value);
            if (objAtendimento.UsuarioResponsavel.IdUsuario > 0)
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_RESPONSAVEL", DbType.String, objAtendimento.UsuarioResponsavel.IdUsuario);
            else
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_RESPONSAVEL", DbType.String, DBNull.Value);
            if (objAtendimento.Programa.IdPrograma > 0)
                db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, objAtendimento.Programa.IdPrograma);
            else
                db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, DBNull.Value);

            db.ExecuteNonQuery(dbCommand, transaction);

            objAtendimento.IdAtendimento = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_ATENDIMENTO"));

            return objAtendimento;
        }

        /// <summary>
        /// Altera um Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objAtendimento">Entidade do Atendimento</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntAtendimento objAtendimento, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaAtendimento");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_ATENDIMENTO", DbType.Int32, objAtendimento.IdAtendimento);
            db.AddInParameter(dbCommand, "@nCEA_ATENDIMENTO_SISTEMA", DbType.Int32, objAtendimento.AtendimentoSistema.IdAtendimentoSistema);
            db.AddInParameter(dbCommand, "@nCEA_ATENDIMENTO_STATUS", DbType.Int32, objAtendimento.AtendimentoStatus.IdAtendimentoStatus);
            db.AddInParameter(dbCommand, "@nCEA_ATENDIMENTO_TIPO", DbType.Int32, objAtendimento.AtendimentoTipo.IdAtendimentoTipo);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objAtendimento.Ativo);
            db.AddInParameter(dbCommand, "@DT_CADASTRO", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "@DT_ALTERACAO", DbType.DateTime, objAtendimento.DataAlteracao);
            db.AddInParameter(dbCommand, "@sTX_DESCRICAO", DbType.String, objAtendimento.Descricao);
            db.AddInParameter(dbCommand, "@sTX_TITULO", DbType.String, objAtendimento.Titulo);
            if (objAtendimento.EmpresaOrigem.IdEmpresaCadastro > 0)
                db.AddInParameter(dbCommand, "@nCEA_EMPRESA_ORIGEM", DbType.String, objAtendimento.EmpresaOrigem.IdEmpresaCadastro);
            else
                db.AddInParameter(dbCommand, "@nCEA_EMPRESA_ORIGEM", DbType.String, DBNull.Value);
            if (objAtendimento.UsuarioOrigem.IdUsuario > 0)
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_ORIGEM", DbType.String, objAtendimento.UsuarioOrigem.IdUsuario);
            else
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_ORIGEM", DbType.String, DBNull.Value);
            if (objAtendimento.UsuarioResponsavel.IdUsuario > 0)
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_RESPONSAVEL", DbType.String, objAtendimento.UsuarioResponsavel.IdUsuario);
            else
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_RESPONSAVEL", DbType.String, DBNull.Value);
            if (objAtendimento.Programa.IdPrograma > 0)
                db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, objAtendimento.Programa.IdPrograma);
            else
                db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, DBNull.Value);

            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Excluir um Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="IdAtendimento">Id do Atendimento</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdAtendimento, Boolean flAtivo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaAtendimentoPorId");
            db.AddInParameter(dbCommand, "@nCDA_ATENDIMENTO", DbType.Int32, IdAtendimento);
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, flAtivo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAtendimento">EntAtendimento</returns>
        public EntAtendimento ObterPorId(Int32 IdAtendimento, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAtendimentoPorId");
            db.AddInParameter(dbCommand, "@nCDA_ATENDIMENTO", DbType.Int32, IdAtendimento);
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
        /// Retorna uma lista de entidade de Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAtendimentoCustom">EntAtendimentoCustom</returns>
        public List<EntAtendimento> ObterPorFiltrosAdministrativo(Int32 IdUsuario, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAtendimentoPorFiltrosAdministrativo");
            db.AddInParameter(dbCommand, "@IdUsuario", DbType.Int32, IdUsuario);
            db.AddInParameter(dbCommand, "@IdPrograma", DbType.Int32, IdPrograma);
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
        /// Retorna uma lista de entidade de Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAtendimentoCustom">EntAtendimentoCustom</returns>
        public List<EntAtendimento> ObterPorFiltro(EntAtendimento entAtendimento, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAtendimentoPorFiltro");
            db.AddInParameter(dbCommand, "@Titulo", DbType.String, entAtendimento.Titulo);
            db.AddInParameter(dbCommand, "@IdPrograma", DbType.Int32, entAtendimento.Programa.IdPrograma);
            if (entAtendimento.IdAtendimento > 0)
                db.AddInParameter(dbCommand, "@IdAtendimento", DbType.Int32, entAtendimento.IdAtendimento);
            else
                db.AddInParameter(dbCommand, "@IdAtendimento", DbType.Int32, DBNull.Value);
            if (entAtendimento.AtendimentoTipo.IdAtendimentoTipo > 0)
                db.AddInParameter(dbCommand, "@IdTipoAtendimento", DbType.Int32, entAtendimento.AtendimentoTipo.IdAtendimentoTipo);
            else
                db.AddInParameter(dbCommand, "@IdTipoAtendimento", DbType.Int32, DBNull.Value);
            if (entAtendimento.AtendimentoStatus.IdAtendimentoStatus > 0)
                db.AddInParameter(dbCommand, "@IdStatusAtendimento", DbType.Int32, entAtendimento.AtendimentoStatus.IdAtendimentoStatus);
            else
                db.AddInParameter(dbCommand, "@IdStatusAtendimento", DbType.Int32, DBNull.Value);
            if (entAtendimento.AtendimentoSistema.IdAtendimentoSistema > 0)
                db.AddInParameter(dbCommand, "@IdSistemaAtendimento", DbType.Int32, entAtendimento.AtendimentoSistema.IdAtendimentoSistema);
            else
                db.AddInParameter(dbCommand, "@IdSistemaAtendimento", DbType.Int32, DBNull.Value);
            if (entAtendimento.DataCadastroFiltroInicial != null && entAtendimento.DataCadastroFiltroInicial.Year > 1990)
                db.AddInParameter(dbCommand, "@DataInicio", DbType.DateTime, entAtendimento.DataCadastroFiltroInicial);
            else
                db.AddInParameter(dbCommand, "@DataInicio", DbType.DateTime, DBNull.Value);
            if (entAtendimento.DataCadastroFiltroFinal != null && entAtendimento.DataCadastroFiltroFinal.Year > 1990)
                db.AddInParameter(dbCommand, "@DataFim", DbType.DateTime, entAtendimento.DataCadastroFiltroFinal);
            else
                db.AddInParameter(dbCommand, "@DataFim", DbType.DateTime, DBNull.Value);
            if (entAtendimento.UsuarioResponsavel.Usuario != null && !entAtendimento.UsuarioResponsavel.Usuario.Equals(""))
                db.AddInParameter(dbCommand, "@UsuarioResponsavel", DbType.String, entAtendimento.UsuarioResponsavel.Usuario);
            else
                db.AddInParameter(dbCommand, "@UsuarioResponsavel", DbType.String, DBNull.Value);
            if (entAtendimento.IdEstado > 0)
                db.AddInParameter(dbCommand, "@IdEstado", DbType.Int32, entAtendimento.IdEstado);
            else
                db.AddInParameter(dbCommand, "@IdEstado", DbType.Int32, DBNull.Value);
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
        /// Retorna uma lista de entidade de Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAtendimentoCustom">EntAtendimentoCustom</returns>
        public List<EntAtendimento> ObterPorFiltroEmpresa(EntAtendimento entAtendimento, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAtendimentoPorFiltroEmpresa");
            db.AddInParameter(dbCommand, "@Titulo", DbType.String, entAtendimento.Titulo);
            db.AddInParameter(dbCommand, "@IdPrograma", DbType.Int32, entAtendimento.Programa.IdPrograma);
            db.AddInParameter(dbCommand, "@IdEmpresaOrigem", DbType.Int32, entAtendimento.EmpresaOrigem.IdEmpresaCadastro);
            if (entAtendimento.IdAtendimento > 0)
                db.AddInParameter(dbCommand, "@IdAtendimento", DbType.Int32, entAtendimento.IdAtendimento);
            else
                db.AddInParameter(dbCommand, "@IdAtendimento", DbType.Int32, DBNull.Value);
            if (entAtendimento.AtendimentoTipo.IdAtendimentoTipo > 0)
                db.AddInParameter(dbCommand, "@IdTipoAtendimento", DbType.Int32, entAtendimento.AtendimentoTipo.IdAtendimentoTipo);
            else
                db.AddInParameter(dbCommand, "@IdTipoAtendimento", DbType.Int32, DBNull.Value);
            if (entAtendimento.AtendimentoStatus.IdAtendimentoStatus > 0)
                db.AddInParameter(dbCommand, "@IdStatusAtendimento", DbType.Int32, entAtendimento.AtendimentoStatus.IdAtendimentoStatus);
            else
                db.AddInParameter(dbCommand, "@IdStatusAtendimento", DbType.Int32, DBNull.Value);
            if (entAtendimento.AtendimentoSistema.IdAtendimentoSistema > 0)
                db.AddInParameter(dbCommand, "@IdSistemaAtendimento", DbType.Int32, entAtendimento.AtendimentoSistema.IdAtendimentoSistema);
            else
                db.AddInParameter(dbCommand, "@IdSistemaAtendimento", DbType.Int32, DBNull.Value);
            if (entAtendimento.DataCadastroFiltroInicial != null && entAtendimento.DataCadastroFiltroInicial.Year > 1990)
                db.AddInParameter(dbCommand, "@DataInicio", DbType.DateTime, entAtendimento.DataCadastroFiltroInicial);
            else
                db.AddInParameter(dbCommand, "@DataInicio", DbType.DateTime, DBNull.Value);
            if (entAtendimento.DataCadastroFiltroFinal != null && entAtendimento.DataCadastroFiltroFinal.Year > 1990)
                db.AddInParameter(dbCommand, "@DataFim", DbType.DateTime, entAtendimento.DataCadastroFiltroFinal);
            else
                db.AddInParameter(dbCommand, "@DataFim", DbType.DateTime, DBNull.Value);
            if (entAtendimento.UsuarioResponsavel.Usuario != null && !entAtendimento.UsuarioResponsavel.Usuario.Equals(""))
                db.AddInParameter(dbCommand, "@UsuarioResponsavel", DbType.String, entAtendimento.UsuarioResponsavel.Usuario);
            else
                db.AddInParameter(dbCommand, "@UsuarioResponsavel", DbType.String, DBNull.Value);
            if (entAtendimento.IdEstado > 0)
                db.AddInParameter(dbCommand, "@IdEstado", DbType.Int32, entAtendimento.IdEstado);
            else
                db.AddInParameter(dbCommand, "@IdEstado", DbType.Int32, DBNull.Value);
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
        /// Retorna uma lista de entidade de Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntAtendimentoCustom">EntAtendimentoCustom</returns>
        public List<EntAtendimento> ObterPorEmpresa(Int32 IdEmpresa, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAtendimentoPorEmpresa");
            db.AddInParameter(dbCommand, "@IdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@IdPrograma", DbType.Int32, IdPrograma);
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
        /// Popula Atendimento, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntAtendimento">Lista de EntAtendimento</list></returns>
        private List<EntAtendimento> Popular(DbDataReader dtrDados)
        {
            List<EntAtendimento> listEntReturn = new List<EntAtendimento>();
            EntAtendimento entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntAtendimento();

                    entReturn.IdAtendimento = ObjectUtils.ToInt(dtrDados["CDA_ATENDIMENTO"]);
                    entReturn.AtendimentoSistema.IdAtendimentoSistema = ObjectUtils.ToInt(dtrDados["CEA_ATENDIMENTO_SISTEMA"]);
                    entReturn.AtendimentoStatus.IdAtendimentoStatus = ObjectUtils.ToInt(dtrDados["CEA_ATENDIMENTO_STATUS"]);
                    entReturn.AtendimentoTipo.IdAtendimentoTipo = ObjectUtils.ToInt(dtrDados["CEA_ATENDIMENTO_TIPO"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.DataCadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                    entReturn.DataAlteracao = ObjectUtils.ToDate(dtrDados["DT_ALTERACAO"]);
                    entReturn.Titulo = ObjectUtils.ToString(dtrDados["TX_TITULO"]);
                    entReturn.Descricao = ObjectUtils.ToString(dtrDados["TX_DESCRICAO"]);
                    try
                    {
                        entReturn.AtendimentoSistema.AtendimentoSistema = ObjectUtils.ToString(dtrDados["TX_ATENDIMENTO_SISTEMA"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.AtendimentoStatus.AtendimentoStatus = ObjectUtils.ToString(dtrDados["TX_ATENDIMENTO_STATUS"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.AtendimentoTipo.AtendimentoTipo = ObjectUtils.ToString(dtrDados["TX_ATENDIMENTO_TIPO"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.EmpresaOrigem.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CEA_EMPRESA_ORIGEM"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.UsuarioOrigem.IdUsuario = ObjectUtils.ToInt(dtrDados["CEA_USUARIO_ORIGEM"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.UsuarioResponsavel.IdUsuario = ObjectUtils.ToInt(dtrDados["CEA_USUARIO_RESPONSAVEL"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.Programa.Programa = ObjectUtils.ToString(dtrDados["TX_PROGRAMA"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.AtendimentoTipo.AtendimentoTipo = ObjectUtils.ToString(dtrDados["TX_ATENDIMENTO_TIPO"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.AtendimentoStatus.AtendimentoStatus = ObjectUtils.ToString(dtrDados["TX_ATENDIMENTO_STATUS"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.EmpresaOrigem.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_EMPRESA_ORIGEM"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.UsuarioOrigem.Usuario = ObjectUtils.ToString(dtrDados["TX_USUARIO_ORIGEM"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.UsuarioResponsavel.Usuario = ObjectUtils.ToString(dtrDados["TX_USUARIO_RESPONSAVEL"]);
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
