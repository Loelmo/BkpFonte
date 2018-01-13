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
    /// Classe de Dados que representa um Turma
    /// </summary>
    public class BllTurma : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalTurma dalTurma = new DalTurma();

        /// <summary>
        /// Variável privada que representa uma classe de Estado
        /// </summary>
        private DalEstado dalEstado = new DalEstado();


        /// <summary>
        /// Retorna uma entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntTurma">EntTurma</list></returns>
        public EntTurma ObterPorId(Int32 IdTurma)
        {
            EntTurma objTurma = new EntTurma();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objTurma = dalTurma.ObterPorId(IdTurma, transaction, db);
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
            return objTurma;
        }

        /// <summary>
        /// Retorna uma entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntTurma">EntTurma</list></returns>
        public List<EntTurma> ObterAbertasPorProgramaEmpresaEstado(Int32 IdPrograma, Int32 IdEmpresaCadastro, Int32 IdEstado)
        {
            List<EntTurma> lstTurma = new List<EntTurma>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalTurma.ObterAbertasPorProgramaEmpresaEstado(IdPrograma, IdEmpresaCadastro, IdEstado, transaction, db);
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
            return lstTurma;
        }

        /// <summary>
        /// Retorna uma entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntTurma">EntTurma</list></returns>
        public List<EntTurma> ObterPorIdPrograma(Int32 IdPrograma)
        {
            List<EntTurma> lstTurma = new List<EntTurma>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalTurma.ObterPorIdPrograma(IdPrograma, transaction, db);
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
            return lstTurma;
        }

        /// <summary>
        /// Retorna uma entidade de Turma
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntTurma">EntTurma</list></returns>
        public EntTurma ObterTurmaAtiva(Int32 IdPrograma)
        {
            EntTurma objTurma = new EntTurma();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objTurma = dalTurma.ObterTurmaAtiva(IdPrograma, transaction, db);

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
            return objTurma;
        }

        /// <summary>
        /// Retorna uma entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntTurma">EntTurma</list></returns>
        public List<EntTurma> ObterTodos()
        {
            List<EntTurma> lstTurma = new List<EntTurma>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalTurma.ObterTodos(transaction, db);
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
            return lstTurma;
        }


        /// <summary>
        /// Retorna uma lista de entidade Turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <returns><type="EntTurma">EntTurma</list></returns>
        public List<EntTurma> ObterPorFiltro(String sNome, Int32 nEstado, Int32 nPrivada, DateTime dDataInicial, DateTime dDataFinal, Int32 nPrograma, Int32 IdUsuario)
        {
            List<EntTurma> lstTurma = new List<EntTurma>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                   
                    lstTurma = dalTurma.ObterPorFiltro(sNome,nEstado,nPrivada,dDataInicial,dDataFinal,nPrograma, IdUsuario,transaction, db);
                    

                    foreach (EntTurma objTurma in lstTurma)
                    {
                         objTurma.Estado = dalEstado.ObterPorId(objTurma.Estado.IdEstado, transaction, db);
                         if (StringUtils.IsEmpty(objTurma.Estado.Estado))
                         {
                             objTurma.Estado.Estado = "Todos";
                             objTurma.Estado.IdEstado = 0;
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
            return lstTurma;
        }
        /// <summary>
        /// Ativa ou Desativa uma Turma
        /// </summary>
        /// <param name="objTurma"></param>
        public void AtivaDesativaTurma(EntTurma objTurma)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalTurma.AtivaDesativaTurma(objTurma, transaction, db);
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
        /// Inclui uma Turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objTurma">Entidade de Turma</param>
        /// <returns>Entidade de Turma</returns>
        public EntTurma Inserir(EntTurma objTurma)
        {
            EntTurma objRetorno = null;
            EntTurmaQuestionario objTurmaQuestionario = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalTurma.Inserir(objTurma, transaction, db);

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
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                int count = 0;
                try
                {
                    if (objRetorno.IdTurma > 0)
                    {
                        //Gera Etapas da Turma
                        objRetorno.Etapas = new BllEtapa().GerarEtapasTurma(objTurma);
                       //Insere os questionarios da turma
                        new DalTurmaQuestionario().ExcluirTodosPorTurma(objTurma.IdTurma, transaction, db);
                        foreach (EntTurmaQuestionario item in objTurma.Questionarios)
                        {
                            count++;
                            item.Ordem = count;
                            item.Turma.IdTurma = objTurma.IdTurma;
                            objTurmaQuestionario = new DalTurmaQuestionario().Inserir(item, transaction, db);
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
            return objRetorno;
        }


        /// <summary>
        /// Altera uma Turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objTurma">Entidade de Turma</param>
        public void Alterar(EntTurma objTurma)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                int count = 0;

                try
                {
                    dalTurma.Alterar(objTurma, transaction, db);
                    new DalTurmaQuestionario().ExcluirTodosPorTurma(objTurma.IdTurma, transaction, db);

                    foreach (EntTurmaQuestionario item in objTurma.Questionarios)
                    {
                         count++;
                         item.Ordem = count;
                         item.Turma.IdTurma = objTurma.IdTurma;
                         EntTurmaQuestionario objTurmaQuestionario  = new DalTurmaQuestionario().Inserir(item, transaction, db);
                        //objRetorno.Questionarios.Add(objTurmaQuestionario);
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
        /// Retorna uma lista de entidade de Turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <returns><type="EntTurma">EntTurma</list></returns>
        public List<EntTurma> ObterTodasCompativeis(int IdTurma, int IdUsuario)
        {
            List<EntTurma> lstTurma = new List<EntTurma>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalTurma.ObterTodasCompativeis(IdTurma, IdUsuario, transaction, db);
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
            return lstTurma;
        }


    }
}
