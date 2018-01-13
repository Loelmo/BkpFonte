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
    public class BllGrupoEmpresa : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de GrupoEmpresa
        /// </summary>
        private DalGrupoEmpresa dalGrupoEmpresa = new DalGrupoEmpresa();

        /// <summary>
        /// Retorna uma lista de GrupoEmpresa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntGrupoEmpresa">EntGrupoEmpresa</returns>
        public List<EntGrupoEmpresa> ObterPorFiltro(String sGrupo, Int32 nEstado, Int32 nSetor, Int32 nTurma, Boolean bAtivo, Int32 nIdUsuario, Int32 nIdPrograma)
        {
            List<EntGrupoEmpresa> lstGrupoEmpresa = new List<EntGrupoEmpresa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstGrupoEmpresa = dalGrupoEmpresa.ObterPorFiltro(sGrupo, nEstado, nSetor, nTurma, nIdUsuario, bAtivo, nIdPrograma, transaction, db);
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
            return lstGrupoEmpresa;
        }

        /// <summary>
        /// Retorna uma lista de GrupoEmpresa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntGrupoEmpresa">EntGrupoEmpresa</returns>
        public List<EntGrupoEmpresa> ObterTodosPorGrupo(Int32 nGrupo)
        {
            List<EntGrupoEmpresa> lstGrupoEmpresa = new List<EntGrupoEmpresa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstGrupoEmpresa = dalGrupoEmpresa.ObterTodosPorGrupo(nGrupo, transaction, db);
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
            return lstGrupoEmpresa;

        }
        /// <summary>
        /// Inclui um Grupo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objGrupo">Entidade do GrupoEmpresa</param>
        /// <returns>Entidade de GrupoEmpresa</returns>
        public EntGrupoEmpresa Inserir(EntGrupoEmpresa objGrupoEmpresa)
        {
            EntGrupoEmpresa objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalGrupoEmpresa.Inserir(objGrupoEmpresa, transaction, db);
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
    }
}
