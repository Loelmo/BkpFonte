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
    /// Classe de Dados que representa um Tipo Empresa
    /// </summary>
    public class BllTipoEmpresa : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Tipo Empresa
        /// </summary>
        private DalTipoEmpresa dalTipoEmpresa = new DalTipoEmpresa();

        /// <summary>
        /// Retorna uma entidade de Tipo Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntTipoEmpresa">EntTipoEmpresa</list></returns>
        public EntTipoEmpresa ObterPorId(Int32 IdTipoEmpresa)
        {
            EntTipoEmpresa objTipoEmpresa = new EntTipoEmpresa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objTipoEmpresa = dalTipoEmpresa.ObterPorId(IdTipoEmpresa, transaction, db);
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
            return objTipoEmpresa;
        }

        /// <summary>
        /// Retorna uma entidade de Tipo Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntTipoEmpresa">EntTipoEmpresa</list></returns>
        public List<EntTipoEmpresa> ObterTodos()
        {
            List<EntTipoEmpresa> lstTipoEmpresa = new List<EntTipoEmpresa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTipoEmpresa = dalTipoEmpresa.ObterTodos(transaction, db);
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
            return lstTipoEmpresa;
        }

        /// <summary>
        /// Retorna uma entidade de Tipo Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntTipoEmpresa">EntTipoEmpresa</list></returns>
        public List<EntTipoEmpresa> ObterTodosFga()
        {
            List<EntTipoEmpresa> lstTipoEmpresa = new List<EntTipoEmpresa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTipoEmpresa = dalTipoEmpresa.ObterTodosFga(transaction, db);
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
            return lstTipoEmpresa;
        }
    }
}
