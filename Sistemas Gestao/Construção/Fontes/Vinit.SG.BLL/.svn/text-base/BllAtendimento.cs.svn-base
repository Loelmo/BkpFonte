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
    /// Classe de Dados que representa uma Atendimento
    /// </summary>
    public class BllAtendimento : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Atendimento
        /// </summary>
        private DalAtendimento dalAtendimento = new DalAtendimento();

        /// <summary>
        /// Retorna uma Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntAtendimento">EntAtendimento</returns>
        public EntAtendimento ObterPorId(Int32 IdAtendimento)
        {
            EntAtendimento turmaEmpresa = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    turmaEmpresa = dalAtendimento.ObterPorId(IdAtendimento, transaction, db);
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
        /// Retorna uma Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntAtendimento">EntAtendimento</returns>
        public List<EntAtendimento> ObterPorFiltrosAdministrativo(Int32 IdUsuario, Int32 IdPrograma, Int32 IdTurma)
        {
            List<EntAtendimento> listaAtendimento = new List<EntAtendimento>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaAtendimento = dalAtendimento.ObterPorFiltrosAdministrativo(IdUsuario, IdPrograma, transaction, db);
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
            return listaAtendimento;
        }

        /// <summary>
        /// Retorna uma Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntAtendimento">EntAtendimento</returns>
        public List<EntAtendimento> ObterPorEmpresa(Int32 IdEstado, Int32 IdPrograma)
        {
            List<EntAtendimento> listaAtendimento = new List<EntAtendimento>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaAtendimento = dalAtendimento.ObterPorEmpresa(IdEstado, IdPrograma, transaction, db);
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
            return listaAtendimento;
        }

        /// <summary>
        /// Retorna uma Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntAtendimento">EntAtendimento</returns>
        public List<EntAtendimento> ObterPorFiltro(EntAtendimento entAtendimento)
        {
            List<EntAtendimento> listaAtendimento = new List<EntAtendimento>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaAtendimento = dalAtendimento.ObterPorFiltro(entAtendimento, transaction, db);
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
            return listaAtendimento;
        }

        /// <summary>
        /// Retorna uma Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntAtendimento">EntAtendimento</returns>
        public List<EntAtendimento> ObterPorFiltroEmpresa(EntAtendimento entAtendimento)
        {
            List<EntAtendimento> listaAtendimento = new List<EntAtendimento>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listaAtendimento = dalAtendimento.ObterPorFiltroEmpresa(entAtendimento, transaction, db);
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
            return listaAtendimento;
        }

        /// <summary>
        /// Retorna uma Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntAtendimento">EntAtendimento</returns>
        public EntAtendimento Inserir(EntAtendimento entAtendimento)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    entAtendimento = dalAtendimento.Inserir(entAtendimento, transaction, db);
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
            return entAtendimento;
        }

        /// <summary>
        /// Retorna uma Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntAtendimento">EntAtendimento</returns>
        public EntAtendimento Alterar(EntAtendimento entAtendimento)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalAtendimento.Alterar(entAtendimento, transaction, db);
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
            return entAtendimento;
        }

        /// <summary>
        /// Habilita/desabilita uma Atendimento
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntAtendimento">EntAtendimento</returns>
        public EntAtendimento Excluir(EntAtendimento entAtendimento)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    entAtendimento.Ativo = !entAtendimento.Ativo;
                    dalAtendimento.Excluir(entAtendimento.IdAtendimento, entAtendimento.Ativo, transaction, db);
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
            return entAtendimento;
        }

    }
}
