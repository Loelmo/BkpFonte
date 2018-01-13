using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa um Turma
    /// </summary>
    public class BllPerguntaResposta : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalPerguntaResposta dalPerguntaResposta = new DalPerguntaResposta();

        /// <summary>
        /// Retorna uma entidade de PerguntaResposta
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntPergunta">EntPerguntaResposta</list></returns>
        public EntPerguntaResposta ObterPorId(Int32 IdPerguntaResposta)
        {
            EntPerguntaResposta objPerguntaResposta = new EntPerguntaResposta();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objPerguntaResposta = dalPerguntaResposta.ObterPorId(IdPerguntaResposta, transaction, db);

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
            return objPerguntaResposta;
        }

    }
}
