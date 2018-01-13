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
    /// Classe de Dados que representa um AdmGrupo
    /// </summary>
    public class DalAdmUsuarioRelGrupoUsuario
    {

        /// <summary>
        /// Inclui um registro na tabela AdmUsuarioRelGrupoUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objAdmUsuarioRelGrupoUsuario">Entidade que representa a tabela AdmUsuarioRelGrupoUsuario</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de AdmUsuarioRelGrupoUsuario</returns>
        public EntAdmUsuarioRelGrupoUsuario Inserir(EntAdmUsuarioRelGrupoUsuario objAdmUsuarioRelGrupoUsuario, DbTransaction transaction, Database db)
        {
            EntAdmUsuarioRelGrupoUsuario objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereAdmUsuarioRelGrupoUsuario");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nIdUsuarioRelGrupoUsuario", DbType.Int32, objAdmUsuarioRelGrupoUsuario.IdUsuarioGrupoUsuario);
            db.AddInParameter(dbCommand, "@nIdUsuario", DbType.String, objAdmUsuarioRelGrupoUsuario.AdmUsuario.IdUsuario);
            db.AddInParameter(dbCommand, "@nIdGrupoUsuario", DbType.String, objAdmUsuarioRelGrupoUsuario.AdmGrupoRelUsuario.IdGrupoUsuario);

            db.ExecuteNonQuery(dbCommand, transaction);

            objAdmUsuarioRelGrupoUsuario.IdUsuarioGrupoUsuario = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nIdUsuarioRelGrupoUsuario"));

            if (objAdmUsuarioRelGrupoUsuario.IdUsuarioGrupoUsuario != int.MinValue)
                objRetorno = objAdmUsuarioRelGrupoUsuario;

            return objRetorno;
        }

        /// <summary>
        /// Excluir um AdmUsuarioRelGrupoUsuario
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="EntAdmUsuarioRelGrupoUsuario">Entidade de AdmUsuarioRelGrupoUsuario</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdGrupoUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaAdmUsuarioRelGrupoUsuario");
            db.AddInParameter(dbCommand, "@nIdGrupoUsuario", DbType.String, IdGrupoUsuario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um Boolean
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="IdUsuario">IdUsuario</returns>
        public Boolean ExisteUsuario(Int32 IdGrupoUsuario, Int32 IdUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_ExisteUsuarioRelGrupoUsuario");
            db.AddInParameter(dbCommand, "@nIdGrupoUsuario", DbType.Int32, IdGrupoUsuario);
            db.AddInParameter(dbCommand, "@nIdUsuario", DbType.Int32, IdUsuario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            Int32 count = (Int32)db.ExecuteScalar(dbCommand, transaction);

            return count > 0;
        }
    }
}
