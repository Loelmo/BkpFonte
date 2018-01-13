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
    /// Classe de Dados que representa um AdmUsuarioRelGrupoUsuario
    /// </summary>
    public class BllAdmUsuarioRelGrupoUsuario : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de AdmUsuarioGrupoRelUsuario
        /// </summary>
        private DalAdmUsuarioRelGrupoUsuario dalAdmUsuarioRelGrupoUsuario = new DalAdmUsuarioRelGrupoUsuario();
                                                                                   

        /// <summary>
        /// Inclui um AdmUsuarioRelGrupoUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmUsuarioRelGrupoUsuario">Entidade do AdmUsuarioRelGrupoUsuario</param>
        /// <returns>Entidade de AdmUsuarioRelGrupoUsuario</returns>
        public EntAdmUsuarioRelGrupoUsuario Inserir(EntAdmUsuarioRelGrupoUsuario objAdmUsuarioRelGrupoUsuario)
        {
            EntAdmUsuarioRelGrupoUsuario objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalAdmUsuarioRelGrupoUsuario.Inserir(objAdmUsuarioRelGrupoUsuario, transaction, db);
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
        /// Excluir um AdmUsuarioRelGrupoUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="EntAdmUsuarioRelGrupoUsuario">Entidade de AdmUsuarioRelGrupoUsuario</param>
        public void Excluir(Int32 IdGrupoUsuario)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalAdmUsuarioRelGrupoUsuario.Excluir(IdGrupoUsuario, transaction, db);
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
        /// Inclui uma lista de AdmUsuarioRelGrupoUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmUsuarioRelGrupoUsuario">Entidade do AdmUsuarioRelGrupoUsuario</param>
        /// <returns>Entidade de AdmUsuarioRelGrupoUsuario</returns>
        public void InserirLista(List<EntAdmUsuario> lstAdmUsuario, Int32 IdGrupoUsuario)
        {
            
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    foreach (EntAdmUsuario objAdmUsuario in lstAdmUsuario)
                    {
                        EntAdmUsuarioRelGrupoUsuario objEntAdmUsuarioRelGrupoUsuario = new EntAdmUsuarioRelGrupoUsuario();
                        objEntAdmUsuarioRelGrupoUsuario.AdmUsuario.IdUsuario = objAdmUsuario.IdUsuario;
                        objEntAdmUsuarioRelGrupoUsuario.AdmGrupoRelUsuario.IdGrupoUsuario = IdGrupoUsuario;

                        dalAdmUsuarioRelGrupoUsuario.Inserir(objEntAdmUsuarioRelGrupoUsuario, transaction, db);
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

        

    }
}
