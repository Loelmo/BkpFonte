using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Vinit.SG.Ent;
using Vinit.SG.Common;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa LogAcao
    /// </summary>
    public class DalLogAcao
    {
        /// <summary>
        /// Inclui um registro na tabela LogAcao
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objLogAcao">Entidade que representa a tabela LogAcao</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de LogAcao</returns>
        public EntLogAcao Inserir(EntLogAcao objLogAcao, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereLogAcao");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_LOG_ACAO", DbType.Int32, objLogAcao.IdLogAcao);
            db.AddInParameter(dbCommand, "@CEA_EMP_CADASTRO", DbType.Int32, objLogAcao.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@CEA_USUARIO", DbType.Int32, objLogAcao.Usuario.IdUsuario);
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objLogAcao.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@CEA_TIPO_ACAO", DbType.Int32, objLogAcao.TipoAcao.IdTipoAcao);

            db.ExecuteNonQuery(dbCommand, transaction);

            objLogAcao.IdLogAcao = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_LOG_ACAO"));

            return objLogAcao;
        }
    }
}
