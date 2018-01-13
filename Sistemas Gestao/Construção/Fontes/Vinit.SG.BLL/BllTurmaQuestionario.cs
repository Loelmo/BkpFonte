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
    /// Classe de Dados que representa uma GrupoEmpresa
    /// </summary>
    public class BllTurmaQuestionario : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de dados TurmaQuestionario
        /// </summary>
        private DalTurmaQuestionario dalTurmaQuestionario = new DalTurmaQuestionario();

        
        /// <summary>
        /// Retorna uma lista de TurmaQuestionario
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <returns><type="EntTurmaQuestionario">EntTurmaQuestionario</returns>
        public List<EntTurmaQuestionario> ObterTodosPorTurma(Int32 nTurma)
        {
            List<EntTurmaQuestionario> lstEntQuestionario = new List<EntTurmaQuestionario>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEntQuestionario = dalTurmaQuestionario.ObterTodosPorTurma(nTurma, transaction, db);
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
            return lstEntQuestionario;

        }

        /// <summary>
        /// Excluir TurmaQuestionario
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objTurmaEmpresa">Id de Grupo</param>
        public void Excluir(EntTurmaQuestionario objTurmaEmpresa)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalTurmaQuestionario.ExcluirTurmaQuestionario(objTurmaEmpresa, transaction, db);
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
