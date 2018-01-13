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
    /// Classe de Dados que representa um Noticia
    /// </summary>
    public class DalNoticia
    {
        /// <summary>
        /// Inclui um registro na tabela Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objNoticia">Entidade que representa a tabela Noticia</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Noticia</returns>
        public EntNoticia Inserir(EntNoticia objNoticia, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereNoticia");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_NOTICIA", DbType.Int32, objNoticia.IdNoticia);
            db.AddInParameter(dbCommand, "@sTX_TITULO", DbType.String, objNoticia.Titulo);
            db.AddInParameter(dbCommand, "@sTX_IMAGEM_URL", DbType.String, objNoticia.UrlImagem);
            db.AddInParameter(dbCommand, "@sTX_CONTEUDO", DbType.String, objNoticia.Noticia);
            db.AddInParameter(dbCommand, "@DT_VIGENCIA_FIM", DbType.DateTime, DateUtils.ToDateObject(objNoticia.DataVigenciaFim));
            db.AddInParameter(dbCommand, "@DT_CADASTRO", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "@DT_ALTERACAO", DbType.DateTime, objNoticia.DataAlteracao);
            if(objNoticia.Estado.IdEstado > 0)
                db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, objNoticia.Estado.IdEstado);
            else
                db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, DBNull.Value);
            if (objNoticia.Programa.IdPrograma > 0)
                db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, objNoticia.Programa.IdPrograma);
            else
                db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, DBNull.Value);
            if (objNoticia.Turma.IdTurma > 0)
                db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objNoticia.Turma.IdTurma);
            else
                db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, DBNull.Value);

            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objNoticia.Ativo);
            db.AddInParameter(dbCommand, "@bFL_USUARIO_ADMINISTRATIVO", DbType.Boolean, objNoticia.UsuarioAdministrativo);

            db.ExecuteNonQuery(dbCommand, transaction);

            objNoticia.IdNoticia = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_NOTICIA"));

            return objNoticia;
        }

        /// <summary>
        /// Altera um Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objNoticia">Entidade do Noticia</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntNoticia objNoticia, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaNoticia");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_NOTICIA", DbType.Int32, objNoticia.IdNoticia);
            db.AddInParameter(dbCommand, "@sTX_TITULO", DbType.String, objNoticia.Titulo);
            db.AddInParameter(dbCommand, "@sTX_IMAGEM_URL", DbType.String, objNoticia.UrlImagem);
            db.AddInParameter(dbCommand, "@sTX_CONTEUDO", DbType.String, objNoticia.Noticia);
//            db.AddInParameter(dbCommand, "@DT_CADASTRO", DbType.DateTime, objNoticia.DataCadastro);
            db.AddInParameter(dbCommand, "@DT_ALTERACAO", DbType.DateTime, objNoticia.DataAlteracao);
            db.AddInParameter(dbCommand, "@DT_VIGENCIA_FIM", DbType.DateTime, DateUtils.ToDateObject(objNoticia.DataVigenciaFim));
            if (objNoticia.Estado.IdEstado > 0)
                db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, objNoticia.Estado.IdEstado);
            else
                db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, DBNull.Value);
            if (objNoticia.Programa.IdPrograma > 0)
                db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, objNoticia.Programa.IdPrograma);
            else
                db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, DBNull.Value);
            if (objNoticia.Turma.IdTurma > 0)
                db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objNoticia.Turma.IdTurma);
            else
                db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, DBNull.Value);

            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objNoticia.Ativo);
            db.AddInParameter(dbCommand, "@bFL_USUARIO_ADMINISTRATIVO", DbType.Boolean, objNoticia.UsuarioAdministrativo);

            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Excluir um Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="IdNoticia">Id do Noticia</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdNoticia, Boolean flAtivo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaNoticiaPorId");
            db.AddInParameter(dbCommand, "@nCDA_NOTICIA", DbType.Int32, IdNoticia);
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, flAtivo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntNoticia">EntNoticia</returns>
        public EntNoticia ObterPorId(Int32 IdNoticia, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaNoticiaPorId");
            db.AddInParameter(dbCommand, "@nCDA_NOTICIA", DbType.Int32, IdNoticia);
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
        /// Retorna uma lista de entidade de Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntNoticiaCustom">EntNoticiaCustom</returns>
        public List<EntNoticia> ObterPorFiltrosAdministrativo(Int32 IdUsuario, Int32 IdEstado, Int32 IdPrograma, Int32 IdTurma, String Titulo, DateTime DataInicio, DateTime DataFim, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaNoticiaPorFiltrosAdministrativo");
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
        /// Retorna uma lista de entidade de Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntNoticiaCustom">EntNoticiaCustom</returns>
        public List<EntNoticia> ObterPorFiltro(EntNoticia entNoticia, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaNoticiaPorFiltro");
            db.AddInParameter(dbCommand, "@Titulo", DbType.String, entNoticia.Titulo);
            db.AddInParameter(dbCommand, "@DataInicio", DbType.DateTime, entNoticia.DataCadastroFiltroInicial);
            db.AddInParameter(dbCommand, "@DataFim", DbType.DateTime, entNoticia.DataCadastroFiltroFinal);
            db.AddInParameter(dbCommand, "@TipoUsuario", DbType.Boolean, entNoticia.UsuarioAdministrativo);
            if (entNoticia.IdGrupoFiltro > 0)
                db.AddInParameter(dbCommand, "@IdGrupo", DbType.Int32, entNoticia.IdGrupoFiltro);
            else
                db.AddInParameter(dbCommand, "@IdGrupo", DbType.Int32, DBNull.Value);
            if (entNoticia.Estado.IdEstado > 0)
                db.AddInParameter(dbCommand, "@IdEstado", DbType.Int32, entNoticia.Estado.IdEstado);
            else
                db.AddInParameter(dbCommand, "@IdEstado", DbType.Int32, DBNull.Value);
            if (entNoticia.Programa.IdPrograma > 0)
                db.AddInParameter(dbCommand, "@IdPrograma", DbType.Int32, entNoticia.Programa.IdPrograma);
            else
                db.AddInParameter(dbCommand, "@IdPrograma", DbType.Int32, DBNull.Value);
            if (entNoticia.Turma.IdTurma > 0)
                db.AddInParameter(dbCommand, "@IdTurma", DbType.Int32, entNoticia.Turma.IdTurma);
            else
                db.AddInParameter(dbCommand, "@IdTurma", DbType.Int32, DBNull.Value);
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, entNoticia.Ativo);
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
        /// Retorna uma lista de entidade de Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntNoticiaCustom">EntNoticiaCustom</returns>
        public List<EntNoticia> ObterPorEmpresa(Int32 IdEstado, Int32 IdPrograma, Int32 IdTurma, String Titulo, DateTime DataInicio, DateTime DataFim, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaNoticiaPorEmpresa");
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
        /// Popula Noticia, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntNoticia">Lista de EntNoticia</list></returns>
        private List<EntNoticia> Popular(DbDataReader dtrDados)
        {
            List<EntNoticia> listEntReturn = new List<EntNoticia>();
            EntNoticia entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntNoticia();

                    entReturn.IdNoticia = ObjectUtils.ToInt(dtrDados["CDA_NOTICIA"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);
                    entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                    entReturn.Titulo = ObjectUtils.ToString(dtrDados["TX_TITULO"]);
                    entReturn.UrlImagem = ObjectUtils.ToString(dtrDados["TX_IMAGEM_URL"]);
                    entReturn.Noticia = ObjectUtils.ToString(dtrDados["TX_CONTEUDO"]);
                    entReturn.DataCadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                    entReturn.DataVigenciaFim = ObjectUtils.ToDate(dtrDados["DT_VIGENCIA_FIM"]);
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
