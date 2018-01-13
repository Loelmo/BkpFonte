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
    public class BllAdmFuncionalidade : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de AdmFuncionalidade
        /// </summary>
        private DalAdmFuncionalidade dalAdmFuncionalidade = new DalAdmFuncionalidade();


        /// <summary>
        /// Retorna um AdmFuncionalidade
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntAdmFuncionalidade">EntAdmFuncionalidade</returns>
        public EntAdmFuncionalidade ObterPorId(Int32 IdAdmFuncionalidade)
        {
            EntAdmFuncionalidade objAdmFuncionalidade = new EntAdmFuncionalidade();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objAdmFuncionalidade = dalAdmFuncionalidade.ObterPorId(IdAdmFuncionalidade, transaction, db);
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
            return objAdmFuncionalidade;
        }


        /// <summary>
        /// Retorna uma Lista de entidade de AdmFuncionalidade
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmFuncionalidade">Lista de EntAdmFuncionalidade</list></returns>
        public List<EntAdmFuncionalidade> ObterTodos()
        {
            List<EntAdmFuncionalidade> lstAdmFuncionalidade = new List<EntAdmFuncionalidade>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstAdmFuncionalidade = dalAdmFuncionalidade.ObterTodos(transaction, db);
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
            return lstAdmFuncionalidade;
        }


    }
}
