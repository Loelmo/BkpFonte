using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.Ent;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Vinit.SG.Common;
using System.Data;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa um TurmaEmpresaSatisfacao
    /// </summary>
    public class DalTurmaEmpresaSatisfacao
    {
        /// <summary>
        /// Inclui um registro na tabela TurmaEmpresaSatisfacao
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objTurmaEmpresaSatisfacao">Entidade que representa a tabela TurmaEmpresaSatisfacao</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de TurmaEmpresaSatisfacao</returns>
        public void Inserir(EntTurmaEmpresaSatisfacao objTurmaEmpresaSatisfacao, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereTurmaEmpresaSatisfacao");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@TX_RESPOSTA_1", DbType.String, objTurmaEmpresaSatisfacao.Resposta1);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_2", DbType.String, objTurmaEmpresaSatisfacao.Resposta2);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_3", DbType.String, objTurmaEmpresaSatisfacao.Resposta3);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_4", DbType.String, objTurmaEmpresaSatisfacao.Resposta4);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_5", DbType.String, objTurmaEmpresaSatisfacao.Resposta5);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_6", DbType.String, objTurmaEmpresaSatisfacao.Resposta6);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_7", DbType.String, objTurmaEmpresaSatisfacao.Resposta7);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_8", DbType.String, objTurmaEmpresaSatisfacao.Resposta8);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_9", DbType.String, objTurmaEmpresaSatisfacao.Resposta9);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_10", DbType.String, objTurmaEmpresaSatisfacao.Resposta10);
            db.AddInParameter(dbCommand, "@CEA_EMPRESA_CADASTRO", DbType.Int32, objTurmaEmpresaSatisfacao.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objTurmaEmpresaSatisfacao.Turma.IdTurma);

            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera um TurmaEmpresaSatisfacao
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objTurmaEmpresaSatisfacao">Entidade do TurmaEmpresaSatisfacao</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntTurmaEmpresaSatisfacao objTurmaEmpresaSatisfacao, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaTurmaEmpresaSatisfacao");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@TX_RESPOSTA_1", DbType.String, objTurmaEmpresaSatisfacao.Resposta1);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_2", DbType.String, objTurmaEmpresaSatisfacao.Resposta2);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_3", DbType.String, objTurmaEmpresaSatisfacao.Resposta3);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_4", DbType.String, objTurmaEmpresaSatisfacao.Resposta4);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_5", DbType.String, objTurmaEmpresaSatisfacao.Resposta5);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_6", DbType.String, objTurmaEmpresaSatisfacao.Resposta6);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_7", DbType.String, objTurmaEmpresaSatisfacao.Resposta7);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_8", DbType.String, objTurmaEmpresaSatisfacao.Resposta8);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_9", DbType.String, objTurmaEmpresaSatisfacao.Resposta9);
            db.AddInParameter(dbCommand, "@TX_RESPOSTA_10", DbType.String, objTurmaEmpresaSatisfacao.Resposta10);
            db.AddInParameter(dbCommand, "@CEA_EMPRESA_CADASTRO", DbType.Int32, objTurmaEmpresaSatisfacao.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objTurmaEmpresaSatisfacao.Turma.IdTurma);

            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Excluir um TurmaEmpresaSatisfacao
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="IdTurmaEmpresaSatisfacao">Id do TurmaEmpresaSatisfacao</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdTurma, Int32 IdEmpresaCadastro, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaTurmaEmpresaSatisfacaoPorId");
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, IdTurma);
            db.AddInParameter(dbCommand, "@CEA_EMPRESA_CADASTRO", DbType.Int32, IdEmpresaCadastro);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um TurmaEmpresaSatisfacao
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntTurmaEmpresaSatisfacao">EntTurmaEmpresaSatisfacao</returns>
        public EntTurmaEmpresaSatisfacao ObterPorTurmaEmpresa(Int32 IdTurma, Int32 IdEmpresaCadastro, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaEmpresaSatisfacaoPorTurmaEmpresa");
            db.AddInParameter(dbCommand, "@CEA_EMPRESA_CADASTRO", DbType.Int32, IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Popula TurmaEmpresaSatisfacao, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntTurmaEmpresaSatisfacao">Lista de EntTurmaEmpresaSatisfacao</list></returns>
        private List<EntTurmaEmpresaSatisfacao> Popular(DbDataReader dtrDados)
        {
            List<EntTurmaEmpresaSatisfacao> listEntReturn = new List<EntTurmaEmpresaSatisfacao>();
            EntTurmaEmpresaSatisfacao entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntTurmaEmpresaSatisfacao();

                    entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                    entReturn.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CEA_EMPRESA_CADASTRO"]);
                    entReturn.Resposta1 = ObjectUtils.ToString(dtrDados["TX_RESPOSTA_1"]);
                    entReturn.Resposta2 = ObjectUtils.ToString(dtrDados["TX_RESPOSTA_2"]);
                    entReturn.Resposta3 = ObjectUtils.ToString(dtrDados["TX_RESPOSTA_3"]);
                    entReturn.Resposta4 = ObjectUtils.ToString(dtrDados["TX_RESPOSTA_4"]);
                    entReturn.Resposta5 = ObjectUtils.ToString(dtrDados["TX_RESPOSTA_5"]);
                    entReturn.Resposta6 = ObjectUtils.ToString(dtrDados["TX_RESPOSTA_6"]);
                    entReturn.Resposta7 = ObjectUtils.ToString(dtrDados["TX_RESPOSTA_7"]);
                    entReturn.Resposta8 = ObjectUtils.ToString(dtrDados["TX_RESPOSTA_8"]);
                    entReturn.Resposta9 = ObjectUtils.ToString(dtrDados["TX_RESPOSTA_9"]);
                    entReturn.Resposta10 = ObjectUtils.ToString(dtrDados["TX_RESPOSTA_10"]);

                    listEntReturn.Add(entReturn);
                }

                dtrDados.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listEntReturn;
        }

    }
}
