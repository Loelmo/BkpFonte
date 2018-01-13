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
    /// Classe de Dados que representa um ProgramaEmpresa
    /// </summary>
    public class BllProgramaEmpresa : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de ProgramaEmpresa
        /// </summary>
        private DalProgramaEmpresa dalProgramaEmpresa = new DalProgramaEmpresa();

        /// <summary>
        /// Retorna uma ProgramaEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public EntProgramaEmpresa ObterPorProgramaEmpresa(Int32 IdPrograma, Int32 IdEmpresaCadastro)
        {
            EntProgramaEmpresa turmaEmpresa = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    turmaEmpresa = dalProgramaEmpresa.ObterPorProgramaEmpresa(IdPrograma, IdEmpresaCadastro, transaction, db);
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
        /// Inclui um ProgramaEmpresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objProgramaEmpresa">Entidade do ProgramaEmpresa</param>
        /// <returns>Entidade de ProgramaEmpresa</returns>
        public EntProgramaEmpresa Inserir(EntProgramaEmpresa objProgramaEmpresa)
        {
            EntProgramaEmpresa objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalProgramaEmpresa.Inserir(objProgramaEmpresa, transaction, db);
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
        /// Altera um ProgramaEmpresa
        /// </summary>
        /// <autor>Paulo Apoloni</autor>
        /// <param name="objProgramaEmpresa">Entidade do ProgramaEmpresa</param>
        /// <returns>Entidade de ProgramaEmpresa</returns>
        public void Alterar(EntProgramaEmpresa objProgramaEmpresa)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalProgramaEmpresa.Alterar(objProgramaEmpresa, transaction, db);
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
