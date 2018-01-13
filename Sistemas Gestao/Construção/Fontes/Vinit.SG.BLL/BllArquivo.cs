using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using System.Data.Common;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa uma Arquivo
    /// </summary>
    public class BllArquivo : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Arquivo
        /// </summary>
        private DalArquivo dalArquivo = new DalArquivo();

        /// <summary>
        /// Variável privada que representa uma classe de ArquivoGrupo
        /// </summary>
        private DalArquivoGrupo dalArquivoGrupo = new DalArquivoGrupo();

        /// <summary>
        /// Retorna uma Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntArquivo">EntArquivo</returns>
        public EntArquivo ObterPorId(Int32 IdArquivo)
        {
            EntArquivo turmaEmpresa = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    turmaEmpresa = dalArquivo.ObterPorId(IdArquivo, transaction, db);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return turmaEmpresa;
        }

        /// <summary>
        /// Retorna uma Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntArquivo">EntArquivo</returns>
        public List<EntArquivo> ObterPorFiltrosAdministrativo(Int32 IdUsuario, Int32 IdEstado, Int32 IdPrograma, Int32 IdTurma, String Titulo, DateTime DataInicio, DateTime DataFim)
        {
            List<EntArquivo> listaArquivo = new List<EntArquivo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaArquivo = dalArquivo.ObterPorFiltrosAdministrativo(IdUsuario, IdEstado, IdPrograma, IdTurma, Titulo, DataInicio, DataFim, transaction, db);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return listaArquivo;
        }

        /// <summary>
        /// Retorna uma Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntArquivo">EntArquivo</returns>
        public List<EntArquivo> ObterPorEmpresa(Int32 IdEstado, Int32 IdPrograma, Int32 IdTurma, String Titulo, DateTime DataInicio, DateTime DataFim)
        {
            List<EntArquivo> listaArquivo = new List<EntArquivo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaArquivo = dalArquivo.ObterPorEmpresa(IdEstado, IdPrograma, IdTurma, Titulo, DataInicio, DataFim, transaction, db);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return listaArquivo;
        }

        /// <summary>
        /// Retorna uma Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntArquivo">EntArquivo</returns>
        public List<EntArquivo> ObterPorFiltro(EntArquivo entArquivo)
        {
            List<EntArquivo> listaArquivo = new List<EntArquivo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaArquivo = dalArquivo.ObterPorFiltro(entArquivo, transaction, db);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return listaArquivo;
        }

        /// <summary>
        /// Retorna uma Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntArquivo">EntArquivo</returns>
        public EntArquivo Inserir(EntArquivo entArquivo)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    entArquivo = dalArquivo.Inserir(entArquivo, transaction, db);
                    foreach (EntArquivoGrupo grupo in entArquivo.ListArquivoGrupo)
                    {
                        grupo.Arquivo.IdArquivo = entArquivo.IdArquivo;
                        dalArquivoGrupo.Inserir(grupo, transaction, db);
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return entArquivo;
        }

        /// <summary>
        /// Retorna uma Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntArquivo">EntArquivo</returns>
        public EntArquivo Alterar(EntArquivo entArquivo)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalArquivo.Alterar(entArquivo, transaction, db);
                    dalArquivoGrupo.ExcluirPorArquivo(entArquivo.IdArquivo, transaction, db);
                    foreach (EntArquivoGrupo grupo in entArquivo.ListArquivoGrupo)
                    {
                        dalArquivoGrupo.Inserir(grupo, transaction, db);
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return entArquivo;
        }

        /// <summary>
        /// Habilita/desabilita uma Arquivo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntArquivo">EntArquivo</returns>
        public EntArquivo Excluir(EntArquivo entArquivo)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    entArquivo.Ativo = !entArquivo.Ativo;
                    dalArquivo.Excluir(entArquivo.IdArquivo, entArquivo.Ativo, transaction, db);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return entArquivo;
        }

    }
}
