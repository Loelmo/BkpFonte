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
    public class BllQuestionario : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalQuestionario dalQuestionario = new DalQuestionario();

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalPergunta dalPergunta = new DalPergunta();

       /// <summary>
       /// Variavel que representa lista de questionarios associados a uma turma
       /// </summary>
        private List<EntTurmaQuestionario> QuestAssociados;

        /// <summary>
        /// Retorna uma entidade de Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionario">EntQuestionario</list></returns>
        public List<EntQuestionario> ObterPorIdTurma(Int32 IdTurma)
        {
            List<EntQuestionario> lstTurma = new List<EntQuestionario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalQuestionario.ObterPorIdTurma(IdTurma, transaction, db);
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
        /// Retorna uma entidade de Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionario">EntQuestionario</list></returns>
        public EntQuestionario ObterPorId(Int32 IdQuestionario)
        {
            EntQuestionario lstTurma = new EntQuestionario();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalQuestionario.ObterPorId(IdQuestionario, transaction, db);
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
        /// Retorna uma lista de Questionarios
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionario">EntQuestionario</list></returns>
        public List<EntQuestionario> ObterObrigatoriosPorIdTurma(Int32 IdTurma)
        {
            List<EntQuestionario> lstTurma = new List<EntQuestionario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalQuestionario.ObterObrigatoriosPorIdTurma(IdTurma, transaction, db);
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
        /// Retorna uma entidade de Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionario">EntQuestionario</list></returns>
        public List<EntQuestionario> ObterAbertosPorIdTurmaIdEmpresa(Int32 IdTurma, Int32 IdEmpCadastro)
        {
            List<EntQuestionario> lstTurma = new List<EntQuestionario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalQuestionario.ObterAbertosPorIdTurmaIdEmpresa(IdTurma, IdEmpCadastro, transaction, db);
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
        /// Retorna uma entidade de Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionario">EntQuestionario</list></returns>
        public List<EntQuestionario> ObterResumoPorIdTurmaIdEmpresa(Int32 IdTurma, Int32 IdEmpCadastro)
        {
            List<EntQuestionario> lstTurma = new List<EntQuestionario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalQuestionario.ObterAbertosPorIdTurmaIdEmpresa(IdTurma, IdEmpCadastro, transaction, db);
                    foreach (EntQuestionario objQuestionario in lstTurma)
                    {
                        objQuestionario.ListPergunta = dalPergunta.ObterResumoPorQuestionarioEmpresaTurma(objQuestionario.IdQuestionario, IdEmpCadastro, IdTurma, transaction, db);
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
        /// Retorna uma entidade de Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionario">EntQuestionario</list></returns>
        public List<EntQuestionario> ObterEnviadosPorIdTurmaIdEmpresa(Int32 IdTurma, Int32 IdEmpCadastro)
        {
            List<EntQuestionario> lstTurma = new List<EntQuestionario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalQuestionario.ObterEnviadosPorIdTurmaIdEmpresa(IdTurma, IdEmpCadastro, transaction, db);
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
        /// Retorna uma entidade de Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionario">EntQuestionario</list></returns>
        public List<EntQuestionario> ObterEnviadosPorIdEtapaIdEmpresa(Int32 IdEtapa, Int32 IdEmpCadastro)
        {
            List<EntQuestionario> lstTurma = new List<EntQuestionario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalQuestionario.ObterEnviadosPorIdEtapaIdEmpresa(IdEtapa, IdEmpCadastro, transaction, db);
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
        /// Retorna uma entidade de Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionario">EntQuestionario</list></returns>
        public List<EntQuestionario> ObterAbertosPorIdTurmaIdEmpresaIdEtapa(Int32 IdTurma, Int32 IdEmpCadastro, Int32 IdEtapa)
        {
            List<EntQuestionario> lstTurma = new List<EntQuestionario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalQuestionario.ObterAbertosPorIdTurmaIdEmpresaIdEtapa(IdTurma, IdEmpCadastro, IdEtapa, transaction, db);
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
        /// Retorna uma entidade de Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionario">EntQuestionario</list></returns>
        public EntQuestionario ObterPorIdTurmaIdQuestionarioEmpresa(Int32 IdTurma, Int32 IdQuestionarioEmpresa)
        {
            EntQuestionario lstTurma = new EntQuestionario();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalQuestionario.ObterPorIdTurmaIdQuestionarioEmpresa(IdTurma, IdQuestionarioEmpresa, transaction, db);
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
        /// Retorna uma entidade de Questionario
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <returns><type="EntQuestionario">EntQuestionario</list></returns>
        public List<EntQuestionario> ObterTodosQuestionarios()
        {
            List<EntQuestionario> lstTurma = new List<EntQuestionario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurma = dalQuestionario.ObterTodos(transaction, db);
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
        /// Filtra os objetos da primeira lista trazendo somente os objetos que não estão na segunda lista
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <returns><type="EntQuestionario">EntQuestionario</list></returns>
        public List<EntQuestionario> ObterQuestionariosPorFiltro(List<EntQuestionario> lstTodas, List<EntTurmaQuestionario> lstAssociadas)
        {
            QuestAssociados = lstAssociadas;
            List<EntQuestionario> lstFiltrada = lstTodas.FindAll(FiltroQuestionarios);
            QuestAssociados = null;
            return lstFiltrada;
        }

        private bool FiltroQuestionarios(EntQuestionario q)
        {
            foreach (EntTurmaQuestionario item in QuestAssociados)
            {
                if (q.IdQuestionario == item.Questionario.IdQuestionario)
                {
                   return false;
                }
                   
            }
            return true;
        }

      

    }
}
