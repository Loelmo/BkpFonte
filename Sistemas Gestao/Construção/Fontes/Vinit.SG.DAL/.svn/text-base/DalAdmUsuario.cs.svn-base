using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Vinit.SG.Ent;
using Vinit.SG.Common;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa um EntUsuario
    /// </summary>
    public class DalAdmUsuario
    {
        /// <summary>
        /// Inclui um registro na tabela EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objUsuario">Entidade que representa a tabela EntUsuario</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de EntUsuario</returns>
        public EntAdmUsuario Inserir(EntAdmUsuario objUsuario, DbTransaction transaction, Database db)
        {
            EntAdmUsuario objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereUsuario");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_USUARIO", DbType.Int32, objUsuario.IdUsuario);
            db.AddInParameter(dbCommand, "@sTX_USUARIO", DbType.String, objUsuario.Usuario);
            db.AddInParameter(dbCommand, "@sTX_LOGIN", DbType.String, objUsuario.Login);
            db.AddInParameter(dbCommand, "@sTX_SENHA", DbType.String, objUsuario.Senha);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.String, objUsuario.Estado.IdEstado);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Int32, objUsuario.Ativo);
            db.AddInParameter(dbCommand, "@sTX_CPF", DbType.String, objUsuario.CPF);
            db.AddInParameter(dbCommand, "@sTX_TELEFONE", DbType.String, objUsuario.Telefone);
            db.AddInParameter(dbCommand, "@sTX_EMAIL", DbType.String, objUsuario.Email);

            db.ExecuteNonQuery(dbCommand, transaction);

            objUsuario.IdUsuario = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_USUARIO"));

            if (objUsuario.IdUsuario != int.MinValue)
                objRetorno = objUsuario;

            return objRetorno;
        }

        /// <summary>
        /// Altera um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objUsuario">Entidade do EntUsuario</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntAdmUsuario objUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaUsuario");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_USUARIO", DbType.Int32, objUsuario.IdUsuario);
            db.AddInParameter(dbCommand, "@sTX_USUARIO", DbType.String, objUsuario.Usuario);
            db.AddInParameter(dbCommand, "@sTX_LOGIN", DbType.String, objUsuario.Login);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.String, objUsuario.Estado.IdEstado);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Int32, objUsuario.Ativo);
            db.AddInParameter(dbCommand, "@sTX_CPF", DbType.String, objUsuario.CPF);
            db.AddInParameter(dbCommand, "@sTX_TELEFONE", DbType.String, objUsuario.Telefone);
            db.AddInParameter(dbCommand, "@sTX_EMAIL", DbType.String, objUsuario.Email);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objUsuario">Entidade do EntUsuario</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AlterarSenha(EntAdmUsuario objUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaUsuarioSomenteSenha");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_USUARIO", DbType.Int32, objUsuario.IdUsuario);
            db.AddInParameter(dbCommand, "@sTX_SENHA", DbType.String, objUsuario.Senha);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Excluir um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="IdUsuario">Id do EntUsuario</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaUsuarioPorId");
            db.AddInParameter(dbCommand, "@nIdUsuario", DbType.Int32, IdUsuario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntUsuario">EntUsuario</returns>
        public EntAdmUsuario ValidaUsuario(String sLogin, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_ValidaUsuario");
            db.AddInParameter(dbCommand, "@sLogin", DbType.String, sLogin);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return new EntAdmUsuario();
                }
            }
        }

        /// <summary>
        /// Retorna um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntUsuario">EntUsuario</returns>
        public EntAdmUsuario ObterPorSenha(String Senha, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaUsuarioPorSenha");
            db.AddInParameter(dbCommand, "@sSenha", DbType.String, Senha);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return new EntAdmUsuario();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntUsuario">Lista de EntUsuario</list></returns>
        public List<EntAdmUsuario> ObterPorFiltro(EntAdmUsuario objAdmUsuario, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaUsuarioPorFiltro");
            db.AddInParameter(dbCommand, "@nCDA_USUARIO", DbType.Int32, objAdmUsuario.IdUsuario);
            db.AddInParameter(dbCommand, "@nCDA_PROGRAMA", DbType.Int32, IdPrograma);
            db.AddInParameter(dbCommand, "@sTX_USUARIO", DbType.String, objAdmUsuario.Usuario);
            db.AddInParameter(dbCommand, "@sTX_LOGIN", DbType.String, objAdmUsuario.Login);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objAdmUsuario.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Int32, objAdmUsuario.Ativo);
            db.AddInParameter(dbCommand, "@sTX_CPF", DbType.String, objAdmUsuario.CPF);
            db.AddInParameter(dbCommand, "@sTX_TELEFONE", DbType.String, objAdmUsuario.Telefone);
            db.AddInParameter(dbCommand, "@sTX_EMAIL", DbType.String, objAdmUsuario.Email);

            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCustom(dtrDados);
                }
                else
                {
                    return new List<EntAdmUsuario>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntUsuario">Lista de EntUsuario</list></returns>
        public List<EntAdmUsuario> ObterPorFuncionalidade(String nomePagina, Int32 IdEstado, Int32 IdPrograma, Int32 IdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaUsuarioPorFuncionalidade");
            db.AddInParameter(dbCommand, "@sNOME_PAGINA", DbType.String, nomePagina);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, IntUtils.ToIntNullProc(IdEstado));
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, IdPrograma);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IntUtils.ToIntNullProc(IdTurma));

            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntAdmUsuario>();
                }
            }
        }

        /// <summary>
        /// Retorna um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntUsuario">EntUsuario</returns>
        public EntAdmUsuario ObterPorId(Int32 IdUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaUsuarioPorId");
            db.AddInParameter(dbCommand, "@nIdUsuario", DbType.String, IdUsuario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return new EntAdmUsuario();
                }
            }
        }

        /// <summary>
        /// Retorna um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntUsuario">EntUsuario</returns>
        public List<EntAdmUsuario> ObterPorIdGrupo(Int32 IdGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaUsuarioPorIdGrupo");
            db.AddInParameter(dbCommand, "@nIdGrupo", DbType.String, IdGrupo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntAdmUsuario>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntUsuario">Lista de EntUsuario</list></returns>
        public List<EntAdmUsuario> ObterTodosAssociados(Int32 IdGrupoUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaUsuarioAssociado");
            db.AddInParameter(dbCommand, "@nIdGrupoUsuario", DbType.Int32, IdGrupoUsuario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntAdmUsuario>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntUsuario">Lista de EntUsuario</list></returns>
        public List<EntAdmUsuario> ObterTodosDisponiveis(Int32 IdGrupoUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaUsuarioDisponiveis");
            db.AddInParameter(dbCommand, "@nIdGrupoUsuario", DbType.Int32, IdGrupoUsuario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntAdmUsuario>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntUsuario">Lista de EntUsuario</list></returns>
        public List<EntAdmUsuario> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaUsuario");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCustom(dtrDados);
                }
                else
                {
                    return new List<EntAdmUsuario>();
                }
            }
        }

        /// <summary>
        /// Popula EntUsuario, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntUsuario">Lista de EntUsuario</list></returns>
        private List<EntAdmUsuario> Popular(DbDataReader dtrDados)
        {
            List<EntAdmUsuario> listEntReturn = new List<EntAdmUsuario>();
            EntAdmUsuario entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntAdmUsuario();

                    entReturn.IdUsuario = ObjectUtils.ToInt(dtrDados["CDA_USUARIO"]);
                    entReturn.Usuario = ObjectUtils.ToString(dtrDados["TX_USUARIO"]);
                    entReturn.Login = ObjectUtils.ToString(dtrDados["TX_LOGIN"]);
                    entReturn.Senha = ObjectUtils.ToString(dtrDados["TX_SENHA"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.CPF = ObjectUtils.ToString(dtrDados["TX_CPF"]);
                    entReturn.Telefone = ObjectUtils.ToString(dtrDados["TX_TELEFONE"]);
                    entReturn.Email = ObjectUtils.ToString(dtrDados["TX_EMAIL"]);

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
        /// Popula EntUsuario, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntUsuario">Lista de EntUsuario</list></returns>
        private List<EntAdmUsuario> PopularCustom(DbDataReader dtrDados)
        {
            List<EntAdmUsuario> listEntReturn = new List<EntAdmUsuario>();
            EntAdmUsuario entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntAdmUsuario();

                    entReturn.IdUsuario = ObjectUtils.ToInt(dtrDados["CDA_USUARIO"]);
                    entReturn.Usuario = ObjectUtils.ToString(dtrDados["TX_USUARIO"]);
                    entReturn.Login = ObjectUtils.ToString(dtrDados["TX_LOGIN"]);
                    entReturn.Senha = ObjectUtils.ToString(dtrDados["TX_SENHA"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.Estado.Estado = ObjectUtils.ToString(dtrDados["TX_ESTADO"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.CPF = ObjectUtils.ToString(dtrDados["TX_CPF"]);
                    entReturn.Telefone = ObjectUtils.ToString(dtrDados["TX_TELEFONE"]);
                    entReturn.Email = ObjectUtils.ToString(dtrDados["TX_EMAIL"]);

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
        /// Retorna se o Usuário tem permissão aos botões de (Incluir, Alterar e Excluir)
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><"Boolean">Boolean</returns>
        public Boolean ObterPermissaoBotoes(EntAdmUsuario objUsuario, String Funcionalidade, EnumType.TipoAcao Acao, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_ObterPermissaoBotoes");
            db.AddInParameter(dbCommand, "@nIdUsuario", DbType.Int32, objUsuario.IdUsuario);
            db.AddInParameter(dbCommand, "@sFuncionalidade", DbType.String, Funcionalidade);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    dtrDados.Read();
                    switch (Acao)
                    {
                        case EnumType.TipoAcao.Inserir:
                            return ObjectUtils.ToBoolean(dtrDados["INSERIR"]);
                        case EnumType.TipoAcao.Atualizar:
                            return ObjectUtils.ToBoolean(dtrDados["ATUALIZAR"]);
                        case EnumType.TipoAcao.Excluir:
                           return ObjectUtils.ToBoolean(dtrDados["EXCLUIR"]);
                        default:
                            return false;
                    }

                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Retorna um Boolean
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="CPF">CPF</returns>
        public Boolean ExisteCPF(String CPF, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_ExisteUsuarioCPF");
            db.AddInParameter(dbCommand, "@sCPF", DbType.String, CPF);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            Int32 count = (Int32)db.ExecuteScalar(dbCommand, transaction);

            return count > 0;
        }

        /// <summary>
        /// Retorna um Boolean
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="Login">Login</returns>
        public Boolean ExisteUsuario(String Login, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_ExisteUsuario");
            db.AddInParameter(dbCommand, "@sLogin", DbType.String, Login);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            Int32 count = (Int32)db.ExecuteScalar(dbCommand, transaction);

            return count > 0;
        }
    }
}
