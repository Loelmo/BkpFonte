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
    /// Classe de Dados que representa um Grupo
    /// </summary>
    public class BllGrupo : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Grupo
        /// </summary>
        private DalGrupo dalGrupo = new DalGrupo();
        
        /// <summary>
        /// Inclui um Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objGrupo">Entidade do Grupo</param>
        /// <returns>Entidade de Grupo</returns>
        public EntGrupo InserirComEmpresas(EntGrupo objGrupo, List<EntEmpresaCadastro> lstEmpresaCadastro)
        {
            EntGrupo objRetorno = null;
            EntGrupoEmpresa objRetornoGrupoEmpresa = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalGrupo.Inserir(objGrupo, transaction, db);

                    foreach (EntEmpresaCadastro item in lstEmpresaCadastro)
                    {
                        EntGrupoEmpresa objGrupoEmpresa = new EntGrupoEmpresa();
                        objGrupoEmpresa.EmpresaCadastro = item;
                        objGrupoEmpresa.Grupo = objRetorno;
                        objRetornoGrupoEmpresa = new DalGrupoEmpresa().Inserir(objGrupoEmpresa, transaction, db);
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
            return objRetorno;
        }

        /// <summary>
        /// Altera um Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objGrupo">Entidade de Grupo</param>
        public void AlterarComEmpresas(EntGrupo objGrupo, List<EntEmpresaCadastro> lstEmpresaCadastro)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalGrupo.Alterar(objGrupo, transaction, db);
                    new DalGrupoEmpresa().ExcluirTodosPorGrupo(objGrupo.IdGrupo, transaction, db);
                    
                    foreach (EntEmpresaCadastro item in lstEmpresaCadastro)
                    {
                        EntGrupoEmpresa objGrupoEmpresa = new EntGrupoEmpresa();
                        objGrupoEmpresa.EmpresaCadastro = item;
                        objGrupoEmpresa.Grupo = objGrupo;
                        objGrupoEmpresa.Ativo = true;
                        new DalGrupoEmpresa().Inserir(objGrupoEmpresa, transaction, db);
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
        }

        /// <summary>
        /// Excluir um Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="IdGrupo">Id de Grupo</param>
        public void Excluir(Int32 IdGrupo)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalGrupo.Excluir(IdGrupo, transaction, db);
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

        /*/// <summary>
        /// Retorna uma Lista de entidade de Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntGrupo">Lista de EntGrupo</list></returns>
        public List<EntGrupo> ObterPorNome(String sNome)
        {
            List<EntGrupo> lstGrupo = new List<EntGrupo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstGrupo = dalGrupo.ObterPorNome(sNome, transaction, db);
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
            return lstGrupo;
        }*/

        /// <summary>
        /// Retorna um Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntGrupo">EntGrupo</returns>
        public EntGrupo ObterPorId(Int32 IdGrupo)
        {
            EntGrupo objGrupo = new EntGrupo();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objGrupo = dalGrupo.ObterPorId(IdGrupo, transaction, db);
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
            return objGrupo;
        }

        /// <summary>
        /// Retorna um Grupo
        /// </summary>
        /// <autor>Fernando  Carvalho</autor>
        /// <returns><type="EntGrupo">EntGrupo</returns>
        public List<EntGrupo> ObterPorIdTurmaEstado(Int32 IdTurma, Int32 IdEstado)
        {
            List<EntGrupo> objGrupo = new List<EntGrupo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objGrupo = dalGrupo.ObterPorIdTurmaEstado(IdTurma, IdEstado, transaction, db);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return objGrupo;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntGrupo">Lista de EntGrupo</list></returns>
        public List<EntGrupo> ObterTodosAtivos()
        {
            List<EntGrupo> lstGrupo = new List<EntGrupo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstGrupo = dalGrupo.ObterTodosAtivos(transaction, db);
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
            return lstGrupo;
        }

        /// <summary>
        /// Ativa ou Desativa uma Etapas
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        public void AtivaDesativaGrupo(EntGrupo objGrupo)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalGrupo.AtivaDesativaGrupo(objGrupo, transaction, db);
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
        /// Retorna um Boolean
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="String">Login</returns>
        public Boolean ExisteGrupoPorTurma(String Grupo, Int32 IdTurma)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalGrupo.ExisteGrupoPorTurma(Grupo, IdTurma, transaction, db);
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
    }
}
