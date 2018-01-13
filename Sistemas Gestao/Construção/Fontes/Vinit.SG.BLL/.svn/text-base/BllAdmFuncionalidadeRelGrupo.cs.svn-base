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
    /// Classe de Dados que representa um EntUsuario
    /// </summary>
    public class BllAdmFuncionalidadeRelGrupo : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de AdmFuncionalidadeRelGrupo
        /// </summary>
        private DalAdmFuncionalidadeRelGrupo dalAdmFuncionalidadeRelGrupo = new DalAdmFuncionalidadeRelGrupo();

        /// <summary>
        /// Variável privada que representa uma classe de AdmFuncionalidade
        /// </summary>
        private DalAdmFuncionalidade dalAdmFuncionalidade = new DalAdmFuncionalidade();

        /// <summary>
        /// Variável privada que representa uma classe de AdmGrupo
        /// </summary>
        private DalAdmGrupo dalAdmGrupo = new DalAdmGrupo();

        /// <summary>
        /// Inclui um AdmFuncionalidadeRelGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmFuncionalidadeRelGrupo">Entidade do AdmFuncionalidadeRelGrupo</param>
        /// <returns>Entidade de AdmFuncionalidadeRelGrupo</returns>
        public EntAdmFuncionalidadeRelGrupo Inserir(EntAdmFuncionalidadeRelGrupo objAdmFuncionalidadeRelGrupo)
        {
            EntAdmFuncionalidadeRelGrupo objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalAdmFuncionalidadeRelGrupo.Inserir(objAdmFuncionalidadeRelGrupo, transaction, db);
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
        /// Inclui um AdmFuncionalidadeRelGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmFuncionalidadeRelGrupo">Entidade do AdmFuncionalidadeRelGrupo</param>
        /// <returns>Entidade de AdmFuncionalidadeRelGrupo</returns>
        public String InserirCustom(List<EntAdmFuncionalidadeRelGrupoCustom> lstAdmFuncionalidadeRelGrupo, Int32 IdPrograma)
        {
            String msg = "";
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    if (lstAdmFuncionalidadeRelGrupo.Count > 0)
                    {
                        EntAdmGrupo objAdmGrupo = lstAdmFuncionalidadeRelGrupo[0].AdmGrupo;


                        if (objAdmGrupo.IdGrupo == 0)
                        {
                            if (dalAdmGrupo.ExisteGrupo(objAdmGrupo.Grupo, IdPrograma, transaction, db))
                            {
                                msg = "Grupo de Acesso já existente!";
                            }
                            else
                            {
                                dalAdmGrupo.Inserir(objAdmGrupo, IdPrograma, transaction, db);
                                msg = "Grupo de Acesso inserido com sucesso!";
                            }
                        }
                        else
                        {
                            dalAdmGrupo.Alterar(objAdmGrupo, transaction, db);
                            msg = "Grupo de Acesso Alterado com sucesso!";
                        }


                        foreach (EntAdmFuncionalidadeRelGrupoCustom objAdmFuncionalidadeRelGrupoCustom in lstAdmFuncionalidadeRelGrupo)
                        {
                            EntAdmFuncionalidadeRelGrupo objAdmFuncionalidadeRelGrupo = new EntAdmFuncionalidadeRelGrupo();

                            if (objAdmFuncionalidadeRelGrupoCustom.Visualizar)
                            {
                                objAdmFuncionalidadeRelGrupo.AdmGrupo = objAdmGrupo;
                                objAdmFuncionalidadeRelGrupo.AdmFuncionalidade.IdFuncionalidade = objAdmFuncionalidadeRelGrupoCustom.IdFuncionalidade;
                                objAdmFuncionalidadeRelGrupo.Inserir = objAdmFuncionalidadeRelGrupoCustom.Inserir;
                                objAdmFuncionalidadeRelGrupo.Atualizar = objAdmFuncionalidadeRelGrupoCustom.Atualizar;
                                objAdmFuncionalidadeRelGrupo.Excluir = objAdmFuncionalidadeRelGrupoCustom.Excluir;
                                objAdmFuncionalidadeRelGrupo.Visualizar = objAdmFuncionalidadeRelGrupoCustom.Visualizar;

                                if (this.ExisteFuncionalidadeRelGrupo(objAdmFuncionalidadeRelGrupo.AdmFuncionalidade.IdFuncionalidade, objAdmFuncionalidadeRelGrupo.AdmGrupo.IdGrupo))
                                {
                                    dalAdmFuncionalidadeRelGrupo.Alterar(objAdmFuncionalidadeRelGrupo, transaction, db);
                                }
                                else
                                {
                                    dalAdmFuncionalidadeRelGrupo.Inserir(objAdmFuncionalidadeRelGrupo, transaction, db);
                                }
                            }
                            else
                            {
                                objAdmFuncionalidadeRelGrupo.AdmGrupo = objAdmGrupo;
                                objAdmFuncionalidadeRelGrupo.AdmFuncionalidade.IdFuncionalidade = objAdmFuncionalidadeRelGrupoCustom.IdFuncionalidade;

                                dalAdmFuncionalidadeRelGrupo.Excluir(objAdmFuncionalidadeRelGrupo.AdmFuncionalidade.IdFuncionalidade, objAdmFuncionalidadeRelGrupoCustom.AdmGrupo.IdGrupo, transaction, db);
                            }
                        }
                        
                        transaction.Commit();
                    }
                    return msg;
                }
                catch
                {
                    transaction.Rollback();
                    return "Erro ao tentar Gravar o Grupo de Acesso!";
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Altera um AdmFuncionalidadeRelGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmFuncionalidadeRelGrupo">Entidade de AdmFuncionalidadeRelGrupo</param>
        public void Alterar(EntAdmFuncionalidadeRelGrupo objAdmFuncionalidadeRelGrupo)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalAdmFuncionalidadeRelGrupo.Alterar(objAdmFuncionalidadeRelGrupo, transaction, db);
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
        /// Excluir um AdmFuncionalidadeRelGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="IdAdmFuncionalidadeRelGrupo">Id de AdmFuncionalidadeRelGrupo</param>
        public void Excluir(Int32 IdAdmFuncionalidade, Int32 IdAdmGrupo)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalAdmFuncionalidadeRelGrupo.Excluir(IdAdmFuncionalidade, IdAdmGrupo, transaction, db);
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
        /// <returns><Boolean>Boolean</returns>
        public Boolean ExisteFuncionalidadeRelGrupo(Int32 IdAdmFuncionalidade, Int32 IdAdmGrupo)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalAdmFuncionalidadeRelGrupo.ExisteFuncionalidadeRelGrupo(IdAdmFuncionalidade, IdAdmGrupo, transaction, db);
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

        /// <summary>
        /// Retorna um AdmFuncionalidadeRelGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntAdmFuncionalidadeRelGrupo">EntAdmFuncionalidadeRelGrupo</returns>
        public EntAdmFuncionalidadeRelGrupo ObterPorId(Int32 IdAdmFuncionalidade, Int32 IdAdmGrupo)
        {
            EntAdmFuncionalidadeRelGrupo objAdmFuncionalidadeRelGrupo = new EntAdmFuncionalidadeRelGrupo();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objAdmFuncionalidadeRelGrupo = dalAdmFuncionalidadeRelGrupo.ObterPorId(IdAdmFuncionalidade, IdAdmGrupo, transaction, db);
                    objAdmFuncionalidadeRelGrupo.AdmFuncionalidade = dalAdmFuncionalidade.ObterPorId(objAdmFuncionalidadeRelGrupo.AdmFuncionalidade.IdFuncionalidade, transaction, db);
                    objAdmFuncionalidadeRelGrupo.AdmGrupo = dalAdmGrupo.ObterPorId(objAdmFuncionalidadeRelGrupo.AdmGrupo.IdGrupo, transaction, db);
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
            return objAdmFuncionalidadeRelGrupo;
        }

        /// <summary>
        /// Retorna um AdmFuncionalidadeRelGrupoCustom
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntAdmFuncionalidadeRelGrupoCustom">EntAdmFuncionalidadeRelGrupoCustom</returns>
        public List<EntAdmFuncionalidadeRelGrupoCustom> ObterPorIdCustom(ref EntAdmGrupo objAdmGrupo, Int32 IdPrograma)
        {
            List<EntAdmFuncionalidadeRelGrupoCustom> lstAdmFuncionalidadeRelGrupoCustom = new List<EntAdmFuncionalidadeRelGrupoCustom>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstAdmFuncionalidadeRelGrupoCustom = dalAdmFuncionalidadeRelGrupo.ObterTodosPorIdCustom(objAdmGrupo.IdGrupo, IdPrograma, transaction, db);
                    
                    if ((lstAdmFuncionalidadeRelGrupoCustom != null) && (lstAdmFuncionalidadeRelGrupoCustom.Count > 0))
                    {
                        objAdmGrupo = dalAdmGrupo.ObterPorId(objAdmGrupo.IdGrupo, transaction, db);
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
            return lstAdmFuncionalidadeRelGrupoCustom;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de AdmFuncionalidadeRelGrupo
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmFuncionalidadeRelGrupo">Lista de EntAdmFuncionalidadeRelGrupo</list></returns>
        public List<EntAdmFuncionalidadeRelGrupo> ObterTodos()
        {
            List<EntAdmFuncionalidadeRelGrupo> lstAdmFuncionalidadeRelGrupo = new List<EntAdmFuncionalidadeRelGrupo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstAdmFuncionalidadeRelGrupo = dalAdmFuncionalidadeRelGrupo.ObterTodos(transaction, db);
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
            return lstAdmFuncionalidadeRelGrupo;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de EntAdmFuncionalidadeRelGrupoCustom
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmFuncionalidade">Lista de EntAdmFuncionalidadeRelGrupoCustom</list></returns>
        public List<EntAdmFuncionalidadeRelGrupoCustom> ObterTodosCustom(Int32 IdPrograma)
        {
            List<EntAdmFuncionalidadeRelGrupoCustom> lstAdmFuncionalidadeRelGrupoCustom = new List<EntAdmFuncionalidadeRelGrupoCustom>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstAdmFuncionalidadeRelGrupoCustom = dalAdmFuncionalidadeRelGrupo.ObterTodosCustom(IdPrograma, transaction, db);
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
            return lstAdmFuncionalidadeRelGrupoCustom;
        }

    }
}
