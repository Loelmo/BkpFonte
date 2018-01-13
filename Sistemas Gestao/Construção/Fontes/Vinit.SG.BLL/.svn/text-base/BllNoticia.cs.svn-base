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
    /// Classe de Dados que representa uma Noticia
    /// </summary>
    public class BllNoticia : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Noticia
        /// </summary>
        private DalNoticia dalNoticia = new DalNoticia();

        /// <summary>
        /// Variável privada que representa uma classe de NoticiaGrupo
        /// </summary>
        private DalNoticiaGrupo dalNoticiaGrupo = new DalNoticiaGrupo();

        /// <summary>
        /// Retorna uma Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntNoticia">EntNoticia</returns>
        public EntNoticia ObterPorId(Int32 IdNoticia)
        {
            EntNoticia turmaEmpresa = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    turmaEmpresa = dalNoticia.ObterPorId(IdNoticia, transaction, db);
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
        /// Retorna uma Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntNoticia">EntNoticia</returns>
        public List<EntNoticia> ObterPorFiltrosAdministrativo(Int32 IdUsuario, Int32 IdEstado, Int32 IdPrograma, Int32 IdTurma, String Titulo, DateTime DataInicio, DateTime DataFim)
        {
            List<EntNoticia> listaNoticia = new List<EntNoticia>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaNoticia = dalNoticia.ObterPorFiltrosAdministrativo(IdUsuario, IdEstado, IdPrograma, IdTurma, Titulo, DataInicio, DataFim, transaction, db);
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
            return listaNoticia;
        }

        /// <summary>
        /// Retorna uma Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntNoticia">EntNoticia</returns>
        public List<EntNoticia> ObterPorEmpresa(Int32 IdEstado, Int32 IdPrograma, Int32 IdTurma, String Titulo, DateTime DataInicio, DateTime DataFim)
        {
            List<EntNoticia> listaNoticia = new List<EntNoticia>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaNoticia = dalNoticia.ObterPorEmpresa(IdEstado, IdPrograma, IdTurma, Titulo, DataInicio, DataFim, transaction, db);
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
            return listaNoticia;
        }

        /// <summary>
        /// Retorna uma Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntNoticia">EntNoticia</returns>
        public List<EntNoticia> ObterPorFiltro(EntNoticia entNoticia)
        {
            List<EntNoticia> listaNoticia = new List<EntNoticia>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaNoticia = dalNoticia.ObterPorFiltro(entNoticia, transaction, db);
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
            return listaNoticia;
        }

        /// <summary>
        /// Retorna uma Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntNoticia">EntNoticia</returns>
        public EntNoticia Inserir(EntNoticia entNoticia)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    entNoticia = dalNoticia.Inserir(entNoticia, transaction, db);
                    foreach (EntNoticiaGrupo grupo in entNoticia.ListNoticiaGrupo)
                    {
                        grupo.Noticia.IdNoticia = entNoticia.IdNoticia;
                        dalNoticiaGrupo.Inserir(grupo, transaction, db);
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
            return entNoticia;
        }

        /// <summary>
        /// Retorna uma Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntNoticia">EntNoticia</returns>
        public EntNoticia Alterar(EntNoticia entNoticia)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalNoticia.Alterar(entNoticia, transaction, db);
                    dalNoticiaGrupo.ExcluirPorNoticia(entNoticia.IdNoticia, transaction, db);
                    foreach (EntNoticiaGrupo grupo in entNoticia.ListNoticiaGrupo)
                    {
                        dalNoticiaGrupo.Inserir(grupo, transaction, db);
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
            return entNoticia;
        }

        /// <summary>
        /// Habilita/desabilita uma Noticia
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntNoticia">EntNoticia</returns>
        public EntNoticia Excluir(EntNoticia entNoticia)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    entNoticia.Ativo = !entNoticia.Ativo;
                    dalNoticia.Excluir(entNoticia.IdNoticia, entNoticia.Ativo, transaction, db);
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
            return entNoticia;
        }

    }
}
