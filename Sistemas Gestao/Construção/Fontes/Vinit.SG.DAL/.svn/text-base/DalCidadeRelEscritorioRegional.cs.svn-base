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
    /// Classe de Dados que representa uma Cidade
    /// </summary>
    public class DalCidadeRelEscritorioRegional
    {
        /// <summary>
        /// Inclui um registro na tabela EntRelCidadeEscritorioRegional
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objCidadeRelEscritorioRegional">Entidade que representa a tabela EntRelCidadeEscritorioRegional</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de EntCidadeRelEscritorioRegional</returns>
        public void Inserir(EntCidadeRelEscritorioRegional objCidadeRelEscritorioRegional, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereCidadeRelEscritorioRegional");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_CIDADE", DbType.Int32, objCidadeRelEscritorioRegional.Cidade.IdCidade);
            db.AddInParameter(dbCommand, "@nCEA_ESCRITORIO_REGIONAL", DbType.Int32, objCidadeRelEscritorioRegional.EscritorioRegional.IdEscritorioRegional);

            db.ExecuteNonQuery(dbCommand, transaction);
             
        }

        /// <summary>
        /// Excluir um EntCidadeRelEscritorioRegional
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void Excluir(Int32 IdEscritorioRegional, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaCidadeRelEscritorioRegional");
            db.AddInParameter(dbCommand, "@nIdEscritorioRegional", DbType.Int32, IdEscritorioRegional);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }


    }
}
