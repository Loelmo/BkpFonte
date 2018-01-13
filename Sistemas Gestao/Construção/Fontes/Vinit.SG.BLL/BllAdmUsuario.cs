using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using System.Data.Common;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa um EntUsuario
    /// </summary>
    public class BllAdmUsuario : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de EntUsuario
        /// </summary>
        private DalAdmUsuario dalUsuario = new DalAdmUsuario();

        /// <summary>
        /// Variável privada que representa uma classe de Estado
        /// </summary>
        private DalEstado dalEstado = new DalEstado();

        /// <summary>
        /// Variável privada que representa uma classe de Funcionalidade
        /// </summary>
        private DalFuncionalidade dalFuncionalidade = new DalFuncionalidade();

        /// <summary>
        /// Variável privada que representa uma classe de EscritorioRegional
        /// </summary>
        private DalEscritorioRegional dalEscritorioRegional = new DalEscritorioRegional();

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalTurma dalTurma = new DalTurma();

        /// <summary>
        /// Inclui um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objUsuario">Entidade do EntUsuario</param>
        /// <returns>Entidade de EntUsuario</returns>
        public EntAdmUsuario Inserir(EntAdmUsuario objUsuario)
        {
            EntAdmUsuario objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalUsuario.Inserir(objUsuario, transaction, db);
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
        /// Altera um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objUsuario">Entidade de EntUsuario</param>
        public void Alterar(EntAdmUsuario objUsuario)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalUsuario.Alterar(objUsuario, transaction, db);
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
        /// Altera um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objUsuario">Entidade de EntUsuario</param>
        public void AlterarSenha(EntAdmUsuario objUsuario)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalUsuario.AlterarSenha(objUsuario, transaction, db);
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
        /// Excluir um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="IdUsuario">Id de EntUsuario</param>
        public void Excluir(Int32 IdUsuario)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalUsuario.Excluir(IdUsuario, transaction, db);
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
        /// Retorna um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntUsuario">EntUsuario</returns>
        public EntAdmUsuario ValidaUsuario(String sLogin)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalUsuario.ValidaUsuario(sLogin, transaction, db);
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
        /// Retorna um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntUsuario">EntUsuario</returns>
        public EntAdmUsuario ObterPorSenha(String Senha)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalUsuario.ObterPorSenha(Senha, transaction, db);
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
        /// <returns><type="String">CPF</returns>
        public Boolean ExisteCPF(String CPF)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalUsuario.ExisteCPF(CPF, transaction, db);
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
        }

        /// <summary>
        /// Retorna um Boolean
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="String">Login</returns>
        public Boolean ExisteUsuario(String Login)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalUsuario.ExisteUsuario(Login, transaction, db);
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
        /// Retorna uma Lista de entidade de EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntUsuario">Lista de EntUsuario</list></returns>
        public List<EntAdmUsuario> ObterPorFiltro(EntAdmUsuario objAdmUsuario, Int32 IdPrograma)
        {
            List<EntAdmUsuario> lstUsuario = new List<EntAdmUsuario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstUsuario = dalUsuario.ObterPorFiltro(objAdmUsuario, IdPrograma, transaction, db);
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
            return lstUsuario;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntUsuario">Lista de EntUsuario</list></returns>
        public List<EntAdmUsuario> ObterPorFuncionalidade(String nomePagina, Int32 IdEstado, Int32 IdPrograma, Int32 IdTurma)
        {
            List<EntAdmUsuario> lstUsuario = new List<EntAdmUsuario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstUsuario = dalUsuario.ObterPorFuncionalidade(nomePagina, IdEstado, IdPrograma, IdTurma, transaction, db);
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
            return lstUsuario;
        }

        /// <summary>
        /// Retorna um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntUsuario">EntUsuario</returns>
        public EntAdmUsuario ObterPorId(Int32 IdUsuario)
        {
            EntAdmUsuario objUsuario = new EntAdmUsuario();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objUsuario = dalUsuario.ObterPorId(IdUsuario, transaction, db);
                    objUsuario.Estado = dalEstado.ObterPorId(objUsuario.Estado.IdEstado, transaction, db);
                    
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
            return objUsuario;
        }

        /// <summary>
        /// Retorna um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntUsuario">EntUsuario</returns>
        public List<EntAdmUsuario> ObterPorIdGrupo(Int32 IdGrupo)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalUsuario.ObterPorIdGrupo(IdGrupo, transaction, db);
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
        }

        /// <summary>
        /// Retorna um EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntUsuario">EntUsuario</returns>
        public EntAdmUsuario ObterPorPermissoes(Int32 IdUsuario, Int32 IdPrograma)
        {
            EntAdmUsuario objUsuario = new EntAdmUsuario();
            
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objUsuario = dalUsuario.ObterPorId(IdUsuario, transaction, db);
                    objUsuario.Estado = dalEstado.ObterPorId(objUsuario.Estado.IdEstado, transaction, db);
                    objUsuario.lstEstadoPermitidos = dalEstado.ObterEstadosPermitido(IdUsuario, IdPrograma, transaction, db);
                    objUsuario.lstFuncionalidade = ObterFuncionalidadeDoUsuario(dalFuncionalidade.ObterFuncionalidadeDoUsuario(IdUsuario, IdPrograma, transaction, db));
                    objUsuario.lstTurmasPermitidas = dalTurma.ObterTurmasPermitidas(IdUsuario, IdPrograma, transaction, db);
                    objUsuario.lstEscritoriosRegionaisPermitidos = dalEscritorioRegional.ObterEscritoriosRegeionaisPermitidos(IdUsuario, IdPrograma, transaction, db);

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
            return objUsuario;
        }

        private List<EntFuncionalidade> ObterFuncionalidadeDoUsuario(List<EntFuncionalidade> lstFuncionalidades)
        {
            List<EntFuncionalidade> lstFuncionalidadesAux = new List<EntFuncionalidade>();
            
            Int32 aux = 1;
            Int32 count = 0;

            for (Int32 i = 0; i < lstFuncionalidades.Count ; i++)
            {
                EntFuncionalidade itemAux = new EntFuncionalidade();
                if (aux == lstFuncionalidades.Count)
                {
                    if (i == 0 || lstFuncionalidades[i - 1].IdFuncionalidade != lstFuncionalidades[i].IdFuncionalidade)
                    {
                        itemAux = lstFuncionalidades[i];
                        lstFuncionalidadesAux.Add(itemAux);
                    }
                    break;
                }
                if (lstFuncionalidades[i].IdFuncionalidade == lstFuncionalidades[aux].IdFuncionalidade)
                {
                    itemAux.Alterar = (lstFuncionalidades[i].Alterar || lstFuncionalidades[aux].Alterar);
                    itemAux.Excluir = (lstFuncionalidades[i].Excluir || lstFuncionalidades[aux].Excluir);
                    itemAux.Inserir = (lstFuncionalidades[i].Inserir || lstFuncionalidades[aux].Inserir);
                    itemAux.Menu = (lstFuncionalidades[i].Menu || lstFuncionalidades[aux].Menu);
                    itemAux.IdFuncionalidade = lstFuncionalidades[i].IdFuncionalidade;
                    itemAux.Pai = lstFuncionalidades[i].Pai;
                    itemAux.URL = lstFuncionalidades[i].URL;
                    itemAux.NomePagina = lstFuncionalidades[i].NomePagina;
                    
                    aux++;
                    count++;
                }
                else
                {
                    i = i + count;
                    itemAux = lstFuncionalidades[i];
                    count = 0;
                }

                lstFuncionalidadesAux.Add(itemAux);
                aux++;
                
            }

            return lstFuncionalidadesAux;
        }


        /// <summary>
        /// Retorna uma Lista de entidade de EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntUsuario">Lista de EntUsuario</list></returns>
        public List<EntAdmUsuario> ObterTodosAssociados(Int32 IdGrupoUsuario)
        {
            List<EntAdmUsuario> lstUsuario = new List<EntAdmUsuario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstUsuario = dalUsuario.ObterTodosAssociados(IdGrupoUsuario, transaction, db);
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
            return lstUsuario;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntUsuario">Lista de EntUsuario</list></returns>
        public List<EntAdmUsuario> ObterTodosDisponiveis(Int32 IdGrupoUsuario)
        {
            List<EntAdmUsuario> lstUsuario = new List<EntAdmUsuario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstUsuario = dalUsuario.ObterTodosDisponiveis(IdGrupoUsuario, transaction, db);
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
            return lstUsuario;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de EntUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntUsuario">Lista de EntUsuario</list></returns>
        public List<EntAdmUsuario> ObterTodos()
        {
            List<EntAdmUsuario> lstUsuario = new List<EntAdmUsuario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstUsuario = dalUsuario.ObterTodos(transaction, db);
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
            return lstUsuario;
        }

        ///// <summary>
        ///// Retorna a permissao do usuario ao botao
        ///// </summary>
        ///// <autor>Fernando Carvalho</autor>
        ///// <returns><type="Boolean">Boolean</list></returns>
        //public Boolean ObterPermissaoBotoes(EntAdmUsuario Usuario, String Funcionalidade, EnumType.TipoAcao Acao)
        //{
        //    Boolean bPermisao = false;

        //    using (DbConnection connection = db.CreateConnection())
        //    {
        //        connection.Open();
        //        DbTransaction transaction = connection.BeginTransaction();
        //        try
        //        {
        //            bPermisao = dalUsuario.ObterPermissaoBotoes(Usuario, Funcionalidade, Acao, transaction, db);
        //            transaction.Commit();
        //        }
        //        catch
        //        {
        //            transaction.Rollback();
        //            throw;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return bPermisao;
        //}


    }
}
