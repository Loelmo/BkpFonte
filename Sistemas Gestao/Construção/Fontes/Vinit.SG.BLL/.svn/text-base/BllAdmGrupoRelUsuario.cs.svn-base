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
    /// Classe de Dados que representa um AdmGrupoRelUsuario
    /// </summary>
    public class BllAdmGrupoRelUsuario : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de AdmGrupoRelUsuario
        /// </summary>
        private DalAdmGrupoRelUsuario dalAdmGrupoRelUsuario = new DalAdmGrupoRelUsuario();

        /// <summary>
        /// Variável privada que representa uma classe de AdmUsuarioGrupoRelUsuario
        /// </summary>
        private DalAdmUsuarioRelGrupoUsuario dalAdmUsuarioRelGrupoUsuario = new DalAdmUsuarioRelGrupoUsuario();
        
        /// <summary>
        /// Inclui um AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmGrupoRelUsuario">Entidade do AdmGrupoRelUsuario</param>
        /// <returns>Entidade de AdmGrupoRelUsuario</returns>
        public EntAdmGrupoRelUsuario Inserir(EntAdmGrupoRelUsuario objAdmGrupoRelUsuario)
        {
            EntAdmGrupoRelUsuario objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalAdmGrupoRelUsuario.Inserir(objAdmGrupoRelUsuario, transaction, db);

                    foreach (EntAdmUsuario objUsuario in objAdmGrupoRelUsuario.lstUsuarioAssociados)
                    {
                        EntAdmUsuarioRelGrupoUsuario objAdmUsuarioRelGrupoUsuario = new EntAdmUsuarioRelGrupoUsuario();
                        objAdmUsuarioRelGrupoUsuario.AdmGrupoRelUsuario.IdGrupoUsuario = objAdmGrupoRelUsuario.IdGrupoUsuario;
                        objAdmUsuarioRelGrupoUsuario.AdmUsuario = objUsuario;

                        dalAdmUsuarioRelGrupoUsuario.Inserir(objAdmUsuarioRelGrupoUsuario, transaction, db);
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
        /// Altera um AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmGrupoRelUsuario">Entidade de AdmGrupoRelUsuario</param>
        public void Alterar(EntAdmGrupoRelUsuario objAdmGrupoRelUsuario)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalAdmGrupoRelUsuario.Alterar(objAdmGrupoRelUsuario, transaction, db);

                    dalAdmUsuarioRelGrupoUsuario.Excluir(objAdmGrupoRelUsuario.IdGrupoUsuario, transaction, db);
                    

                    foreach (EntAdmUsuario objUsuario in objAdmGrupoRelUsuario.lstUsuarioAssociados)
                    {
                        EntAdmUsuarioRelGrupoUsuario objAdmUsuarioRelGrupoUsuario = new EntAdmUsuarioRelGrupoUsuario();
                        objAdmUsuarioRelGrupoUsuario.AdmUsuario.IdUsuario = objUsuario.IdUsuario;
                        objAdmUsuarioRelGrupoUsuario.AdmGrupoRelUsuario.IdGrupoUsuario = objAdmGrupoRelUsuario.IdGrupoUsuario;

                        dalAdmUsuarioRelGrupoUsuario.Inserir(objAdmUsuarioRelGrupoUsuario, transaction, db);
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
        /// Insere Usuarios no Grupo Acesso já existente
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmGrupoRelUsuario">Entidade de AdmGrupoRelUsuario</param>
        public void InserirUsuarios(EntAdmGrupoRelUsuario objAdmGrupoRelUsuario)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    foreach (EntAdmUsuario objUsuario in objAdmGrupoRelUsuario.lstUsuarioAssociados)
                    {
                        if (!dalAdmUsuarioRelGrupoUsuario.ExisteUsuario(objAdmGrupoRelUsuario.IdGrupoUsuario, objUsuario.IdUsuario, transaction, db))
                        {
                            EntAdmUsuarioRelGrupoUsuario objAdmUsuarioRelGrupoUsuario = new EntAdmUsuarioRelGrupoUsuario();
                            objAdmUsuarioRelGrupoUsuario.AdmUsuario.IdUsuario = objUsuario.IdUsuario;
                            objAdmUsuarioRelGrupoUsuario.AdmGrupoRelUsuario.IdGrupoUsuario = objAdmGrupoRelUsuario.IdGrupoUsuario;

                            dalAdmUsuarioRelGrupoUsuario.Inserir(objAdmUsuarioRelGrupoUsuario, transaction, db);
                        }
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
        /// Excluir um AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="IdAdmGrupoRelUsuario">Id de AdmGrupoRelUsuario</param>
        public void Excluir(Int32 IdAdmGrupoRelUsuario)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    new DalAdmUsuarioRelGrupoUsuario().Excluir(IdAdmGrupoRelUsuario, transaction, db);
                    dalAdmGrupoRelUsuario.Excluir(IdAdmGrupoRelUsuario, transaction, db);
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
        /// Retorna um AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntAdmGrupoRelUsuario">EntAdmGrupoRelUsuario</returns>
        public EntAdmGrupoRelUsuario ObterPorId(Int32 IdAdmGrupoRelUsuario)
        {
            EntAdmGrupoRelUsuario objAdmGrupoRelUsuario = new EntAdmGrupoRelUsuario();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objAdmGrupoRelUsuario = dalAdmGrupoRelUsuario.ObterPorId(IdAdmGrupoRelUsuario, transaction, db);
                    objAdmGrupoRelUsuario.lstUsuarioAssociados = new BllAdmUsuario().ObterTodosAssociados(objAdmGrupoRelUsuario.IdGrupoUsuario);
                    objAdmGrupoRelUsuario.lstUsuarioDisponiveis = new BllAdmUsuario().ObterTodosDisponiveis(objAdmGrupoRelUsuario.IdGrupoUsuario);
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
            return objAdmGrupoRelUsuario;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmGrupoRelUsuario">Lista de EntAdmGrupoRelUsuario</list></returns>
        public List<EntAdmGrupoRelUsuario> ObterPorIdGrupo(Int32 IdGrupo, Int32 IdPrograma, Int32 IdUsuario)
        {
            List<EntAdmGrupoRelUsuario> lstAdmGrupoRelUsuario = new List<EntAdmGrupoRelUsuario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstAdmGrupoRelUsuario = dalAdmGrupoRelUsuario.ObterPorIdGrupo(IdGrupo, IdPrograma, IdUsuario, transaction, db);

                    foreach (EntAdmGrupoRelUsuario objGrupoUsuario in lstAdmGrupoRelUsuario)
                    {
                        objGrupoUsuario.Turma = new BllTurma().ObterPorId(objGrupoUsuario.Turma.IdTurma);
                        objGrupoUsuario.EscritorioRegional = new BllEscritorioRegional().ObterPorId(objGrupoUsuario.EscritorioRegional.IdEscritorioRegional);
                        objGrupoUsuario.Estado = new BllEstado().ObterPorId(objGrupoUsuario.Estado.IdEstado);
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
            return lstAdmGrupoRelUsuario;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmGrupoRelUsuario">Lista de EntAdmGrupoRelUsuario</list></returns>
        public List<EntAdmGrupoRelUsuario> ObterPorIdUsuario(Int32 IdUsuario, Int32 IdPrograma)
        {
            List<EntAdmGrupoRelUsuario> lstAdmGrupoRelUsuario = new List<EntAdmGrupoRelUsuario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstAdmGrupoRelUsuario = dalAdmGrupoRelUsuario.ObterPorIdUsuario(IdUsuario, IdPrograma, transaction, db);

                    foreach (EntAdmGrupoRelUsuario objGrupoUsuario in lstAdmGrupoRelUsuario)
                    {
                        objGrupoUsuario.Turma = new BllTurma().ObterPorId(objGrupoUsuario.Turma.IdTurma);
                        objGrupoUsuario.EscritorioRegional = new BllEscritorioRegional().ObterPorId(objGrupoUsuario.EscritorioRegional.IdEscritorioRegional);
                        objGrupoUsuario.Estado = new BllEstado().ObterPorId(objGrupoUsuario.Estado.IdEstado);
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
            return lstAdmGrupoRelUsuario;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de AdmGrupoRelUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmGrupoRelUsuario">Lista de EntAdmGrupoRelUsuario</list></returns>
        public List<EntAdmGrupoRelUsuario> ObterTodos()
        {
            List<EntAdmGrupoRelUsuario> lstAdmGrupoRelUsuario = new List<EntAdmGrupoRelUsuario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstAdmGrupoRelUsuario = dalAdmGrupoRelUsuario.ObterTodos(transaction, db);
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
            return lstAdmGrupoRelUsuario;
        }


        /// <summary>
        /// Retorna um Boolean
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="Boolean">Boolean</returns>
        public Boolean ExisteAssociacao(ref EntAdmGrupoRelUsuario objAdmGrupoRelUsuario)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    EntAdmGrupoRelUsuario auxAdmGrupoRelUsuario = objAdmGrupoRelUsuario;

                    Boolean bExiste = dalAdmGrupoRelUsuario.ExisteAssociacao(ref auxAdmGrupoRelUsuario, transaction, db);
                    objAdmGrupoRelUsuario.IdGrupoUsuario = auxAdmGrupoRelUsuario.IdGrupoUsuario;

                    return bExiste;
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
            return false;
        }

    }
}
