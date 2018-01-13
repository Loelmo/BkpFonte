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
    /// Classe de Dados que representa um Questionario Empresa Avaliador
    /// </summary>
    public class DalQuestionarioEmpresaAvaliador
    {

        /// <summary>
        /// Inclui um registro na tabela QuestionarioEmpresaAvaliador
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objQuestionarioEmpresaAvaliador">Entidade que representa a tabela QuestionarioEmpresaAvaliador</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de EntQuestionarioEmpresaAvaliador</returns>
        public EntQuestionarioEmpresaAvaliador Inserir(EntQuestionarioEmpresaAvaliador objQuestionarioEmpresaAvaliador, DbTransaction transaction, Database db)
        {
            EntQuestionarioEmpresaAvaliador objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereQuestionarioEmpresaAvaliador");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_QUESTIONARIO_EMPRESA_AVALIADOR", DbType.Int32, objQuestionarioEmpresaAvaliador.IdQuestionarioEmpresaAvaliador);
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioEmpresaAvaliador.QuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, objQuestionarioEmpresaAvaliador.Usuario.IdUsuario);
            db.AddInParameter(dbCommand, "@bFL_AVALIADO", DbType.Boolean, objQuestionarioEmpresaAvaliador.Avaliado);
            if (objQuestionarioEmpresaAvaliador.MotivoDevolucao == "")
            {
                db.AddInParameter(dbCommand, "@sTX_MOTIVO_DEVOLUCAO", DbType.String, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "@sTX_MOTIVO_DEVOLUCAO", DbType.String, objQuestionarioEmpresaAvaliador.MotivoDevolucao);
            }
            db.AddInParameter(dbCommand, "@sTX_MELHOR_PRATICA", DbType.String, objQuestionarioEmpresaAvaliador.MelhorPratica);
            db.AddInParameter(dbCommand, "@sTX_BANCA", DbType.String, objQuestionarioEmpresaAvaliador.Banca);
            db.AddInParameter(dbCommand, "@bFL_PRIMARIO", DbType.Boolean, objQuestionarioEmpresaAvaliador.Primario);

            db.ExecuteNonQuery(dbCommand, transaction);

            objQuestionarioEmpresaAvaliador.IdQuestionarioEmpresaAvaliador = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_QUESTIONARIO_EMPRESA_AVALIADOR"));

            if (objQuestionarioEmpresaAvaliador.IdQuestionarioEmpresaAvaliador != int.MinValue)
                objRetorno = objQuestionarioEmpresaAvaliador;

            return objRetorno;
        }

        /// <summary>
        /// Inclui um registro na tabela QuestionarioEmpresaAvaliador
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objQuestionarioEmpresaAvaliador">Entidade que representa a tabela QuestionarioEmpresaAvaliador</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de EntQuestionarioEmpresaAvaliador</returns>
        public void Alterar(EntQuestionarioEmpresaAvaliador objQuestionarioEmpresaAvaliador, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaQuestionarioEmpresaAvaliador");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_QUESTIONARIO_EMPRESA_AVALIADOR", DbType.Int32, objQuestionarioEmpresaAvaliador.IdQuestionarioEmpresaAvaliador);
            db.AddInParameter(dbCommand, "@bFL_AVALIADO", DbType.Boolean, objQuestionarioEmpresaAvaliador.Avaliado);
            if (objQuestionarioEmpresaAvaliador.MotivoDevolucao == "")
            {
                db.AddInParameter(dbCommand, "@sTX_MOTIVO_DEVOLUCAO", DbType.String, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "@sTX_MOTIVO_DEVOLUCAO", DbType.String, objQuestionarioEmpresaAvaliador.MotivoDevolucao);
            }
            db.AddInParameter(dbCommand, "@sTX_MELHOR_PRATICA", DbType.String, objQuestionarioEmpresaAvaliador.MelhorPratica);
            db.AddInParameter(dbCommand, "@sTX_BANCA", DbType.String, objQuestionarioEmpresaAvaliador.Banca);

            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Inclui um registro na tabela QuestionarioEmpresaAvaliador
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objQuestionarioEmpresaAvaliador">Entidade que representa a tabela QuestionarioEmpresaAvaliador</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de EntQuestionarioEmpresaAvaliador</returns>
        public void RemoverPorQuestionarioEmpresa(Int32 IdQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_RemoverQuestionarioEmpresaAvaliadorPorQuestionarioEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO_EMPRESA", DbType.Int32, IdQuestionarioEmpresa);

            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um entidade de Questionario Empresa Avaliador
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresaAvaliador</list></returns>
        public List<EntQuestionarioEmpresaAvaliador> ObterPorIdQuestionarioEmpresa(Int32 IdQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaAvaliadorPorIdQuestionarioEmpresa");
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO_EMPRESA", DbType.Int32, IdQuestionarioEmpresa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return null;
                }
            }
        }
               
        /// <summary>
        /// Popula Questionario Empresa Avaliador, conforme DataReader passado
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntQuestionarioEmpresaAvaliador">Lista de EntQuestionarioEmpresaAvaliador</list></returns>
        private List<EntQuestionarioEmpresaAvaliador> Popular(DbDataReader dtrDados)
        {
            List<EntQuestionarioEmpresaAvaliador> listEntReturn = new List<EntQuestionarioEmpresaAvaliador>();
            EntQuestionarioEmpresaAvaliador entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntQuestionarioEmpresaAvaliador();
                    
                    entReturn.IdQuestionarioEmpresaAvaliador = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA_AVALIADOR"]);
                    entReturn.QuestionarioEmpresa.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CEA_QUESTIONARIO_EMPRESA"]);
                    entReturn.Usuario.IdUsuario = ObjectUtils.ToInt(dtrDados["CEA_USUARIO"]);
                    entReturn.Avaliado = ObjectUtils.ToBoolean(dtrDados["FL_AVALIADO"]);
                    entReturn.MotivoDevolucao = ObjectUtils.ToString(dtrDados["TX_MOTIVO_DEVOLUCAO"]);
                    entReturn.MelhorPratica = ObjectUtils.ToString(dtrDados["TX_MELHOR_PRATICA"]);
                    entReturn.Banca = ObjectUtils.ToString(dtrDados["TX_BANCA"]);
                    entReturn.Primario = ObjectUtils.ToBoolean(dtrDados["FL_PRIMARIO"]);
                    listEntReturn.Add(entReturn);
                }

                dtrDados.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listEntReturn;
        }
    }
}
