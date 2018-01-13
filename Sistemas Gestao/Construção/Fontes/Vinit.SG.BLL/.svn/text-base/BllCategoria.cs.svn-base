using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace Vinit.SG.BLL
{

    /// <summary>
    /// Classe de Dados que representa um Categoria
    /// </summary>
    public class BllCategoria : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Categoria
        /// </summary>
        private DalCategoria dalCategoria = new DalCategoria();

        /// <summary>
        /// Retorna uma entidade de Categoria
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntCategoria">EntCategoria</list></returns>
        public EntCategoria ObterPorId(Int32 IdCategoria)
        {
            EntCategoria objCategoria = new EntCategoria();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objCategoria = dalCategoria.ObterPorId(IdCategoria, transaction, db);
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
            return objCategoria;
        }

        /// <summary>
        /// Retorna uma entidade de Categoria
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntCategoria">EntCategoria</list></returns>
        public List<EntCategoria> ObterTodos(bool flCpf)
        {
            List<EntCategoria> lstCategoria = new List<EntCategoria>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCategoria = dalCategoria.ObterTodos(flCpf, transaction, db);
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
            return lstCategoria;
        }

        /// <summary>
        /// Retorna uma entidade de Categoria
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntCategoria">EntCategoria</list></returns>
        public List<EntCategoria> ObterTodosFga(bool flCpf)
        {
            List<EntCategoria> lstCategoria = new List<EntCategoria>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCategoria = dalCategoria.ObterTodosFga(flCpf, transaction, db);
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
            return lstCategoria;
        }

        /// <summary>
        /// Retorna uma entidade de Categoria
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntCategoria">EntCategoria</list></returns>
        public List<EntCategoria> ObterTodos()
        {
            List<EntCategoria> lstCategoria = new List<EntCategoria>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCategoria = dalCategoria.ObterTodos(transaction, db);
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
            return lstCategoria;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Categoria
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><list type="EntEstado">Lista de EntCategoria</list></returns>
        public List<EntCategoriaCustom> ObterCategoriaEmpresasInscritasPorFiltro(RelFiltroRanking objRelFiltroRanking)
        {
            List<EntCategoriaCustom> lstCategoria = new List<EntCategoriaCustom>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCategoria = dalCategoria.ObterCategoriaEmpresasInscritasPorFiltro(objRelFiltroRanking, transaction, db);
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
            return lstCategoria;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Categoria
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><list type="EntEstado">Lista de EntCategoria</list></returns>
        public List<EntCategoriaCustom> ObterDigitadorEmpresasInscritasPorFiltro(RelFiltroRanking objRelFiltroRanking)
        {
            List<EntCategoriaCustom> lstCategoria = new List<EntCategoriaCustom>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCategoria = dalCategoria.ObterDigitadorEmpresasInscritasPorFiltro(objRelFiltroRanking, transaction, db);
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
            return lstCategoria;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Categoria
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><list type="EntEstado">Lista de EntCategoria</list></returns>
        public List<EntCategoriaCustom> ObterAdminEmpresasInscritasPorFiltro(RelFiltroRanking objRelFiltroRanking)
        {
            List<EntCategoriaCustom> lstCategoria = new List<EntCategoriaCustom>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCategoria = dalCategoria.ObterAdminEmpresasInscritasPorFiltro(objRelFiltroRanking, transaction, db);
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
            return lstCategoria;
        }
    }
}
