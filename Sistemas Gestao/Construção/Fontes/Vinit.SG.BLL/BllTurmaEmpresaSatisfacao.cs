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
    /// Classe de Dados que representa uma TurmaEmpresaSatisfacao
    /// </summary>
    public class BllTurmaEmpresaSatisfacao : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de TurmaEmpresaSatisfacao
        /// </summary>
        private DalTurmaEmpresaSatisfacao dalTurmaEmpresaSatisfacao = new DalTurmaEmpresaSatisfacao();

        /// <summary>
        /// Retorna uma TurmaEmpresaSatisfacao
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntTurmaEmpresaSatisfacao">EntTurmaEmpresaSatisfacao</returns>
        public EntTurmaEmpresaSatisfacao ObterPorTurmaEmpresa(Int32 IdTurma, Int32 IdEmpresaCadastro)
        {
            EntTurmaEmpresaSatisfacao turmaEmpresa = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    turmaEmpresa = dalTurmaEmpresaSatisfacao.ObterPorTurmaEmpresa(IdTurma, IdEmpresaCadastro, transaction, db);
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
            return turmaEmpresa;
        }

        /// <summary>
        /// Retorna uma TurmaEmpresaSatisfacao
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntTurmaEmpresaSatisfacao">EntTurmaEmpresaSatisfacao</returns>
        public void Inserir(EntTurmaEmpresaSatisfacao entTurmaEmpresaSatisfacao)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalTurmaEmpresaSatisfacao.Inserir(entTurmaEmpresaSatisfacao, transaction, db);
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
        /// Retorna uma TurmaEmpresaSatisfacao
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntTurmaEmpresaSatisfacao">EntTurmaEmpresaSatisfacao</returns>
        public EntTurmaEmpresaSatisfacao Alterar(EntTurmaEmpresaSatisfacao entTurmaEmpresaSatisfacao)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalTurmaEmpresaSatisfacao.Alterar(entTurmaEmpresaSatisfacao, transaction, db);
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
            return entTurmaEmpresaSatisfacao;
        }

        /// <summary>
        /// Habilita/desabilita uma TurmaEmpresaSatisfacao
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntTurmaEmpresaSatisfacao">EntTurmaEmpresaSatisfacao</returns>
        public EntTurmaEmpresaSatisfacao Excluir(EntTurmaEmpresaSatisfacao entTurmaEmpresaSatisfacao)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalTurmaEmpresaSatisfacao.Excluir(entTurmaEmpresaSatisfacao.Turma.IdTurma, entTurmaEmpresaSatisfacao.EmpresaCadastro.IdEmpresaCadastro, transaction, db);
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
            return entTurmaEmpresaSatisfacao;
        }

    }
}
