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
    /// Classe de Dados que representa um AdmGrupoS
    /// </summary>
    public class BllAdmGrupo : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de AdmGrupo
        /// </summary>
        private DalAdmGrupo dalAdmGrupo = new DalAdmGrupo();



        /// <summary>
        /// Inclui um AdmGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmGrupo">Entidade do AdmGrupo</param>
        /// <returns>Entidade de AdmGrupo</returns>
        public EntAdmGrupo Inserir(EntAdmGrupo objAdmGrupo, Int32 IdPrograma)
        {
            EntAdmGrupo objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalAdmGrupo.Inserir(objAdmGrupo, IdPrograma, transaction, db);
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
            return objRetorno;
        }


        /// <summary>
        /// Altera um AdmGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmGrupo">Entidade de AdmGrupo</param>
        public void Alterar(EntAdmGrupo objAdmGrupo)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalAdmGrupo.Alterar(objAdmGrupo, transaction, db);
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
        }


        /// <summary>
        /// Excluir um AdmGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="IdAdmGrupo">Id de AdmGrupo</param>
        public void Excluir(Int32 IdAdmGrupo)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalAdmGrupo.Excluir(IdAdmGrupo, transaction, db);
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
        }


        /// <summary>
        /// Retorna uma Lista de entidade de AdmGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmGrupo">Lista de EntAdmGrupo</list></returns>
        public List<EntAdmGrupo> ObterPorNome(String sNome)
        {
            List<EntAdmGrupo> lstAdmGrupo = new List<EntAdmGrupo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstAdmGrupo = dalAdmGrupo.ObterPorNome(sNome, transaction, db);
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
            return lstAdmGrupo;
        }

        /// <summary>
        /// Retorna um AdmGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntAdmGrupo">EntAdmGrupo</returns>
        public EntAdmGrupo ObterPorId(Int32 IdAdmGrupo)
        {
            EntAdmGrupo objAdmGrupo = new EntAdmGrupo();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objAdmGrupo = dalAdmGrupo.ObterPorId(IdAdmGrupo, transaction, db);
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
            return objAdmGrupo;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de AdmGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmGrupo">Lista de EntAdmGrupo</list></returns>
        public List<EntAdmGrupo> ObterTodos(Int32 IdPrograma)
        {
            List<EntAdmGrupo> lstAdmGrupo = new List<EntAdmGrupo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstAdmGrupo = dalAdmGrupo.ObterTodos(IdPrograma, transaction, db);
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
            return lstAdmGrupo;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de AdmGrupo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><list type="EntAdmGrupo">Lista de EntAdmGrupo</list></returns>
        public List<EntAdmGrupo> ObterTodosPorArquivo(Int32 IdArquivo, Int32 IdPrograma)
        {
            List<EntAdmGrupo> lstAdmGrupo = new List<EntAdmGrupo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstAdmGrupo = dalAdmGrupo.ObterTodosPorArquivo(IdArquivo, IdPrograma, transaction, db);
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
            return lstAdmGrupo;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de AdmGrupo
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><list type="EntAdmGrupo">Lista de EntAdmGrupo</list></returns>
        public List<EntAdmGrupo> ObterTodosPorNoticia(Int32 IdNoticia, Int32 IdPrograma)
        {
            List<EntAdmGrupo> lstAdmGrupo = new List<EntAdmGrupo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstAdmGrupo = dalAdmGrupo.ObterTodosPorNoticia(IdNoticia, IdPrograma, transaction, db);
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
            return lstAdmGrupo;
        }

    }
}
