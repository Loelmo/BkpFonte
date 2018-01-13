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
    /// Classe de Dados que representa um Questionario Empresa
    /// </summary>
    public class DalQuestionarioEmpresaResposta
    {

        /// <summary>
        /// Retorna Proxima Pergunta de um Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public EntQuestionarioEmpresaResposta ObterQuestionarioEmpresaRespostaPorPergunta(Int32 IdQuestionarioEmpresa, Int32 IdPergunta, bool isAvaliacao, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand;
            if (isAvaliacao)
            {
                dbCommand = db.GetStoredProcCommand("STP_SelecionaRespostaEmpresaAvaliacaoPorPergunta");
            }
            else
            {
                dbCommand = db.GetStoredProcCommand("STP_SelecionaRespostaEmpresaAutoAvaliacaoPorPergunta");
            }
            db.AddInParameter(dbCommand, "@nIdQuestionarioEmpresa", DbType.Int32, IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@nIdPergunta", DbType.Int32, IdPergunta);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna Proxima Pergunta de um Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public List<EntQuestionarioEmpresaResposta> ObterPorIdQuestionarioEmpresaResposta(Int32 IdQuestionarioEmpresa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand;
            dbCommand = db.GetStoredProcCommand("STP_SelecionaRespostaEmpresaPorQuestionarioEmpresa");
            db.AddInParameter(dbCommand, "@nIdQuestionarioEmpresa", DbType.Int32, IdQuestionarioEmpresa);
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
        /// Retorna Proxima Pergunta de um Questionario
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntPergunta">EntPergunta</list></returns>
        public List<EntQuestionarioEmpresaResposta> ObterRespostasEmpresaPorEmpresaParaAvaliacao(Int32 IdEmpresaCadastro, Int32 IdEtapa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand;
            dbCommand = db.GetStoredProcCommand("STP_SelecionaRespostasEmpresaPorEmpresaParaAvaliacao");
            db.AddInParameter(dbCommand, "@nIdEmpresaCadastro", DbType.Int32, IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nIdEtapa", DbType.Int32, IdEtapa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularAvaliacao(dtrDados);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Popula Questionario Empresa Resposta, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        private List<EntQuestionarioEmpresaResposta> Popular(DbDataReader dtrDados)
        {
            List<EntQuestionarioEmpresaResposta> listEntReturn = new List<EntQuestionarioEmpresaResposta>();
            EntQuestionarioEmpresaResposta entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntQuestionarioEmpresaResposta();
                    
                    entReturn.Justificativa = ObjectUtils.ToString(dtrDados["TX_JUSTIFICATIVA"]);
                    entReturn.OportunidadeMelhoria = ObjectUtils.ToString(dtrDados["TX_OPORTUNIDADE_MELHORIA"]);
                    entReturn.Pergunta.IdPergunta = ObjectUtils.ToInt(dtrDados["CEA_PERGUNTA"]);
                    entReturn.PontoForte = ObjectUtils.ToString(dtrDados["TX_PONTO_FORTE"]);
                    entReturn.QuestionarioEmpresa.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CEA_QUESTIONARIO_EMPRESA"]);
                    entReturn.Resposta.IdPerguntaResposta = ObjectUtils.ToInt(dtrDados["CEA_RESPOSTA"]);
                    if (dtrDados["FL_POSSUI_JUSTIFICATIVA"] != DBNull.Value)
                    {
                        entReturn.Resposta.PossuiJustificativa = ObjectUtils.ToBoolean(dtrDados["FL_POSSUI_JUSTIFICATIVA"]);
                    }
                    if (dtrDados["FL_RESPOSTA_BOOL"] != DBNull.Value)
                    {
                        entReturn.RespostaBool = ObjectUtils.ToBoolean(dtrDados["FL_RESPOSTA_BOOL"]);
                    }
                    entReturn.RespostaTexto = ObjectUtils.ToString(dtrDados["TX_RESPOSTA"]);
                    entReturn.UsuarioAvaliador.IdUsuario = ObjectUtils.ToInt(dtrDados["CEA_USUARIO_AVALIADOR"]);
                    entReturn.UsuarioDigitador.IdUsuario = ObjectUtils.ToInt(dtrDados["CEA_USUARIO_DIGITADOR"]);
                    entReturn.Valor01 = ObjectUtils.ToString(dtrDados["TX_VALOR_01"]);
                    entReturn.Valor02 = ObjectUtils.ToString(dtrDados["TX_VALOR_02"]);
                    entReturn.Valor03 = ObjectUtils.ToString(dtrDados["TX_VALOR_03"]);
                    entReturn.Valor04 = ObjectUtils.ToString(dtrDados["TX_VALOR_04"]);
                    entReturn.Valor05 = ObjectUtils.ToString(dtrDados["TX_VALOR_05"]);
                    entReturn.Valor06 = ObjectUtils.ToString(dtrDados["TX_VALOR_06"]);
                    entReturn.Valor07 = ObjectUtils.ToString(dtrDados["TX_VALOR_07"]);
                    entReturn.Valor08 = ObjectUtils.ToString(dtrDados["TX_VALOR_08"]);
                    entReturn.Valor09 = ObjectUtils.ToString(dtrDados["TX_VALOR_09"]);
                    entReturn.Valor10 = ObjectUtils.ToString(dtrDados["TX_VALOR_10"]);
                    try
                    {
                        entReturn.Pergunta.Criterio.IdCriterio = ObjectUtils.ToInt(dtrDados["CEA_CRITERIO"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.Pergunta.PerguntaTipo.IdPerguntaTipo = ObjectUtils.ToInt(dtrDados["CEA_PERGUNTA_TIPO"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.QuestionarioEmpresa.Etapa.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CEA_EMP_CADASTRO"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.QuestionarioEmpresa.Questionario.IdQuestionario = ObjectUtils.ToInt(dtrDados["CEA_QUESTIONARIO"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.Pergunta.Ordem = ObjectUtils.ToInt(dtrDados["NU_ORDEM"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.Resposta.Ponto = ObjectUtils.ToDecimal(dtrDados["NU_PONTO"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.Pergunta.Pergunta = ObjectUtils.ToString(dtrDados["TX_PERGUNTA"]);
                    }
                    catch { }
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

        /// <summary>
        /// Popula Questionario Empresa Resposta, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        private List<EntQuestionarioEmpresaResposta> PopularAvaliacao(DbDataReader dtrDados)
        {
            List<EntQuestionarioEmpresaResposta> listEntReturn = new List<EntQuestionarioEmpresaResposta>();
            EntQuestionarioEmpresaResposta entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntQuestionarioEmpresaResposta();

                    entReturn.Pergunta.IdPergunta = ObjectUtils.ToInt(dtrDados["CEA_PERGUNTA"]);
                    entReturn.Resposta.IdPerguntaResposta = ObjectUtils.ToInt(dtrDados["CEA_RESPOSTA"]);
                    entReturn.UsuarioAvaliador.IdUsuario = ObjectUtils.ToInt(dtrDados["CEA_USUARIO_AVALIADOR"]);
                    entReturn.QuestionarioEmpresa.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CEA_QUESTIONARIO_EMPRESA"]);
                    entReturn.Justificativa = ObjectUtils.ToString(dtrDados["TX_JUSTIFICATIVA"]);
                    entReturn.OportunidadeMelhoria = ObjectUtils.ToString(dtrDados["TX_OPORTUNIDADE_MELHORIA"]);
                    entReturn.Pergunta.Pergunta = ObjectUtils.ToString(dtrDados["TX_PERGUNTA"]);
                    entReturn.QuestionarioEmpresa.Questionario.Questionario = ObjectUtils.ToString(dtrDados["TX_QUESTIONARIO"]);
                    entReturn.QuestionarioEmpresa.Questionario.IdQuestionario = ObjectUtils.ToInt(dtrDados["CEA_QUESTIONARIO"]);
                    entReturn.QuestionarioEmpresa.Etapa.IdEtapa = ObjectUtils.ToInt(dtrDados["CEA_ETAPA"]);
                    entReturn.Pergunta.PerguntaTipo.IdPerguntaTipo = ObjectUtils.ToInt(dtrDados["CEA_PERGUNTA_TIPO"]);
                    entReturn.Pergunta.Ordem = ObjectUtils.ToInt(dtrDados["NU_ORDEM"]);
                    entReturn.Pergunta.NumeroQuestao = ObjectUtils.ToString(dtrDados["NU_QUESTAO"]);

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

        /// <summary>
        /// Inclui um registro na tabela
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objCidade">Entidade que representa a tabela Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Cidade</returns>
        public void Inserir(EntQuestionarioEmpresaResposta objQuestionarioEmpresaResposta, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereQuestionarioEmpresaResposta");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@nCEA_PERGUNTA", DbType.Int32, objQuestionarioEmpresaResposta.Pergunta.IdPergunta);
            db.AddInParameter(dbCommand, "@nCEA_RESPOSTA", DbType.Int32, objQuestionarioEmpresaResposta.Resposta.IdPerguntaResposta);
            if (objQuestionarioEmpresaResposta.UsuarioAvaliador != null && objQuestionarioEmpresaResposta.UsuarioAvaliador.IdUsuario > 0)
            {
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_AVALIADOR", DbType.Int32, objQuestionarioEmpresaResposta.UsuarioAvaliador.IdUsuario);
                db.AddInParameter(dbCommand, "@bFL_AVALIADOR", DbType.Boolean, true);
            }
            else
            {
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_AVALIADOR", DbType.Int32, DBNull.Value);
                db.AddInParameter(dbCommand, "@bFL_AVALIADOR", DbType.Boolean, false);
            }
            if (objQuestionarioEmpresaResposta.UsuarioDigitador != null && objQuestionarioEmpresaResposta.UsuarioDigitador.IdUsuario > 0)
            {
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_DIGITADOR", DbType.Int32, objQuestionarioEmpresaResposta.UsuarioDigitador.IdUsuario);
            }
            else
            {
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_DIGITADOR", DbType.Int32, DBNull.Value);
            }
            db.AddInParameter(dbCommand, "@sTX_RESPOSTA", DbType.String, objQuestionarioEmpresaResposta.RespostaTexto);
            db.AddInParameter(dbCommand, "@sTX_JUSTIFICATIVA", DbType.String, objQuestionarioEmpresaResposta.Justificativa);
            db.AddInParameter(dbCommand, "@sTX_OPORTUNIDADE_MELHORIA", DbType.String, objQuestionarioEmpresaResposta.OportunidadeMelhoria);
            db.AddInParameter(dbCommand, "@sTX_PONTO_FORTE", DbType.String, objQuestionarioEmpresaResposta.PontoForte);
            db.AddInParameter(dbCommand, "@FL_RESPOSTA_BOOL", DbType.Boolean, objQuestionarioEmpresaResposta.RespostaBool);
            db.AddInParameter(dbCommand, "@sTX_VALOR_01", DbType.String, objQuestionarioEmpresaResposta.Valor01);
            db.AddInParameter(dbCommand, "@sTX_VALOR_02", DbType.String, objQuestionarioEmpresaResposta.Valor02);
            db.AddInParameter(dbCommand, "@sTX_VALOR_03", DbType.String, objQuestionarioEmpresaResposta.Valor03);
            db.AddInParameter(dbCommand, "@sTX_VALOR_04", DbType.String, objQuestionarioEmpresaResposta.Valor04);
            db.AddInParameter(dbCommand, "@sTX_VALOR_05", DbType.String, objQuestionarioEmpresaResposta.Valor05);
            db.AddInParameter(dbCommand, "@sTX_VALOR_06", DbType.String, objQuestionarioEmpresaResposta.Valor06);
            db.AddInParameter(dbCommand, "@sTX_VALOR_07", DbType.String, objQuestionarioEmpresaResposta.Valor07);
            db.AddInParameter(dbCommand, "@sTX_VALOR_08", DbType.String, objQuestionarioEmpresaResposta.Valor08);
            db.AddInParameter(dbCommand, "@sTX_VALOR_09", DbType.String, objQuestionarioEmpresaResposta.Valor09);
            db.AddInParameter(dbCommand, "@sTX_VALOR_10", DbType.String, objQuestionarioEmpresaResposta.Valor10);

            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera uma Resposta
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objCidade">Entidade da Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntQuestionarioEmpresaResposta objQuestionarioEmpresaResposta, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = null;
            if (objQuestionarioEmpresaResposta.UsuarioAvaliador != null && objQuestionarioEmpresaResposta.UsuarioAvaliador.IdUsuario > 0)
            {
                dbCommand = db.GetStoredProcCommand("STP_AtualizaQuestionarioEmpresaRespostaAvaliador");
            }
            else
            {
                dbCommand = db.GetStoredProcCommand("STP_AtualizaQuestionarioEmpresaRespostaEmpresa");
            }
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioEmpresaResposta.QuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@nCEA_PERGUNTA", DbType.Int32, objQuestionarioEmpresaResposta.Pergunta.IdPergunta);
            db.AddInParameter(dbCommand, "@nCEA_RESPOSTA", DbType.Int32, objQuestionarioEmpresaResposta.Resposta.IdPerguntaResposta);
            db.AddInParameter(dbCommand, "@sTX_RESPOSTA", DbType.String, objQuestionarioEmpresaResposta.RespostaTexto);
            db.AddInParameter(dbCommand, "@sTX_JUSTIFICATIVA", DbType.String, objQuestionarioEmpresaResposta.Justificativa);
            db.AddInParameter(dbCommand, "@sTX_OPORTUNIDADE_MELHORIA", DbType.String, objQuestionarioEmpresaResposta.OportunidadeMelhoria);
            db.AddInParameter(dbCommand, "@sTX_PONTO_FORTE", DbType.String, objQuestionarioEmpresaResposta.PontoForte);
            db.AddInParameter(dbCommand, "@FL_RESPOSTA_BOOL", DbType.Boolean, objQuestionarioEmpresaResposta.RespostaBool);
            db.AddInParameter(dbCommand, "@sTX_VALOR_01", DbType.String, objQuestionarioEmpresaResposta.Valor01);
            db.AddInParameter(dbCommand, "@sTX_VALOR_02", DbType.String, objQuestionarioEmpresaResposta.Valor02);
            db.AddInParameter(dbCommand, "@sTX_VALOR_03", DbType.String, objQuestionarioEmpresaResposta.Valor03);
            db.AddInParameter(dbCommand, "@sTX_VALOR_04", DbType.String, objQuestionarioEmpresaResposta.Valor04);
            db.AddInParameter(dbCommand, "@sTX_VALOR_05", DbType.String, objQuestionarioEmpresaResposta.Valor05);
            db.AddInParameter(dbCommand, "@sTX_VALOR_06", DbType.String, objQuestionarioEmpresaResposta.Valor06);
            db.AddInParameter(dbCommand, "@sTX_VALOR_07", DbType.String, objQuestionarioEmpresaResposta.Valor07);
            db.AddInParameter(dbCommand, "@sTX_VALOR_08", DbType.String, objQuestionarioEmpresaResposta.Valor08);
            db.AddInParameter(dbCommand, "@sTX_VALOR_09", DbType.String, objQuestionarioEmpresaResposta.Valor09);
            db.AddInParameter(dbCommand, "@sTX_VALOR_10", DbType.String, objQuestionarioEmpresaResposta.Valor10);
            if (objQuestionarioEmpresaResposta.UsuarioAvaliador != null && objQuestionarioEmpresaResposta.UsuarioAvaliador.IdUsuario > 0)
            {
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_AVALIADOR", DbType.Int32, objQuestionarioEmpresaResposta.UsuarioAvaliador.IdUsuario);
            }
            else
            {
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_AVALIADOR", DbType.Int32, DBNull.Value);
            }
            if (objQuestionarioEmpresaResposta.UsuarioDigitador != null && objQuestionarioEmpresaResposta.UsuarioDigitador.IdUsuario > 0)
            {
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_DIGITADOR", DbType.Int32, objQuestionarioEmpresaResposta.UsuarioDigitador.IdUsuario);
            }
            else
            {
                db.AddInParameter(dbCommand, "@nCEA_USUARIO_DIGITADOR", DbType.Int32, DBNull.Value);
            }

            db.ExecuteNonQuery(dbCommand, transaction);
        }

    }
}
