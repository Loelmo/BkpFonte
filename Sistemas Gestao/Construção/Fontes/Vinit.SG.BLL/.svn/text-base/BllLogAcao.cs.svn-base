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
    public class BllLogAcao : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de LogAcao
        /// </summary>
        private DalLogAcao dalLogAcao = new DalLogAcao();

        /// <summary>
        /// Inclui um logacao
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objGrupo">Entidade do LogAcao</param>
        /// <returns>Entidade de LogAcao</returns>
        public EntLogAcao Inserir(Int32 IdTurma, Int32 IdEmpresaCadastro, Int32 IdUsuario, Int32 IdTipoAcao)
        {
            EntLogAcao objRetorno = new EntLogAcao();
            objRetorno.EmpresaCadastro.IdEmpresaCadastro = IdEmpresaCadastro;
            objRetorno.Turma.IdTurma = IdTurma;
            objRetorno.TipoAcao.IdTipoAcao = IdTipoAcao;
            objRetorno.Usuario.IdUsuario = IdUsuario;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalLogAcao.Inserir(objRetorno, transaction, db);
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
