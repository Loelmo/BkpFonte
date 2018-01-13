using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa um GrupoEmpresa
    /// </summary>
    public class DalTurmaQuestionario
    {

        /// <summary>
        /// Retorna uma lista de entidade de TurmaQuestionario
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTurmaQuestionario">Lista de EntTurmaQuestionario</list></returns>
        public List<EntTurmaQuestionario> ObterTodosPorTurma(Int32 nTurma, DbTransaction transaction, Database db)
        {
            List<EntTurmaQuestionario> listEntReturn = new List<EntTurmaQuestionario>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaQuestionarioPorTurma");
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, nTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord DataRecord in dtrDados)
                    {
                        EntTurmaQuestionario entReturn = new EntTurmaQuestionario();

                        entReturn.Ordem = ObjectUtils.ToInt(dtrDados["NU_ORDEM"]);
                        entReturn.Obrigatorio = ObjectUtils.ToBoolean(dtrDados["FL_OBRIGATORIO"]);
                        entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                        entReturn.Questionario.IdQuestionario = ObjectUtils.ToInt(dtrDados["CEA_QUESTIONARIO"]);
                        entReturn.Questionario.Questionario = ObjectUtils.ToString(dtrDados["TX_QUESTIONARIO"]);

                        listEntReturn.Add(entReturn);
                    }

                    return listEntReturn;
                }
                else
                {
                    return listEntReturn;
                }
            }
        }

        /// <summary>
        /// Inclui um registro na tabela Turma_Questionario
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objTurmaQuestionario">Entidade que representa a tabela Turma_Questionario</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de TurmaQuestionario</returns>
        public EntTurmaQuestionario Inserir(EntTurmaQuestionario objTurmaQuestionario, DbTransaction transaction, Database db)
        {
            EntTurmaQuestionario objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereTurmaQuestionario");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO", DbType.Int32, objTurmaQuestionario.Questionario.IdQuestionario);
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objTurmaQuestionario.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@FL_OBRIGATORIO", DbType.Boolean, objTurmaQuestionario.Obrigatorio);
            db.AddInParameter(dbCommand, "@NU_ORDEM", DbType.Int32, objTurmaQuestionario.Ordem);

            db.ExecuteNonQuery(dbCommand, transaction);

            return objRetorno;
        }

        /// <summary>
        /// Excluir um Questionario da Turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objTurmaQuestionario">Entidade que representa a tabela Turma Questionario</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void ExcluirTurmaQuestionario(EntTurmaQuestionario objTurmaQuestionario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaTurmaQuestionario");
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO", DbType.Int32, objTurmaQuestionario.Questionario.IdQuestionario);
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objTurmaQuestionario.Turma.IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }


        /// <summary>
        /// Excluir todos questionarios por turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="IdTurma">Id da Turma</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void ExcluirTodosPorTurma(int IdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaTurmaQuestionaroPorTurma");
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }





    }
}
