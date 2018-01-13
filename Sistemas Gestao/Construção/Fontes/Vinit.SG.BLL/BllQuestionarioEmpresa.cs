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
    public class BllQuestionarioEmpresa : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalQuestionarioEmpresa dalQuestionarioEmpresa = new DalQuestionarioEmpresa();

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalQuestionarioEmpresaAvaliador dalQuestionarioEmpresaAvaliador = new DalQuestionarioEmpresaAvaliador();

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalQuestionarioEmpresaResposta dalQuestionarioEmpresaResposta = new DalQuestionarioEmpresaResposta();

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalQuestionarioPontuacao dalQuestionarioPontuacao = new DalQuestionarioPontuacao();

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalQuestionario dalQuestionario = new DalQuestionario();

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalEtapa dalEtapa = new DalEtapa();

        /// <summary>
        /// Retorna uma entidade de QuestionarioEmpresa
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterPorId(Int32 IdQuestionarioEmpresa)
        {
            EntQuestionarioEmpresa objQuestionarioEmpresa = new EntQuestionarioEmpresa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objQuestionarioEmpresa = dalQuestionarioEmpresa.ObterPorId(IdQuestionarioEmpresa, transaction, db);
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
            return objQuestionarioEmpresa;
        }

        /// <summary>
        /// Retorna uma entidade de QuestionarioEmpresa
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        public String ObterResumoPorId(Int32 IdQuestionarioEmpresa)
        {
            String res = "";

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    res = dalQuestionarioEmpresa.ObterResumoPorId(IdQuestionarioEmpresa, transaction, db);
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
            return res;
        }

        /// <summary>
        /// Retorna uma entidade de QuestionarioEmpresa
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <returns><type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterQuestionarioEmpresaRelatorioRAAPorFiltros(EntQuestionarioEmpresa objQuestionarioEmpresa, EntTurma objTurma)
        {
            EntQuestionarioEmpresa objReturn = new EntQuestionarioEmpresa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objReturn = dalQuestionarioEmpresa.ObterQuestionarioEmpresaRelatorioRAAPorFiltros(objQuestionarioEmpresa, objTurma, transaction, db);
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
            return objReturn;
        }

        /// <summary>
        /// Retorna uma entidade de QuestionarioEmpresa
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        public List<EntQuestionarioEmpresa> ObterPorProtocolo(String Protocolo)
        {
            List<EntQuestionarioEmpresa> objQuestionarioEmpresa = new List<EntQuestionarioEmpresa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objQuestionarioEmpresa = dalQuestionarioEmpresa.ObterPorProtocolo(Protocolo, transaction, db);
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
            return objQuestionarioEmpresa;
        }

        /// <summary>
        /// Retorna uma entidade de QuestionarioEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterQuestionarioAberto(Int32 IdQuestionario, Int32 IdEmpCadastro, Int32 IdTurma)
        {
            EntQuestionarioEmpresa objQuestionarioEmpresa = new EntQuestionarioEmpresa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objQuestionarioEmpresa = dalQuestionarioEmpresa.ObterQuestionarioAberto(IdQuestionario, IdEmpCadastro, IdTurma, transaction, db);
                    if (objQuestionarioEmpresa != null)
                    {
                        objQuestionarioEmpresa.ListQuestionarioEmpresaAvaliador = dalQuestionarioEmpresaAvaliador.ObterPorIdQuestionarioEmpresa(objQuestionarioEmpresa.IdQuestionarioEmpresa, transaction, db);
                        objQuestionarioEmpresa.ListQuestionarioEmpresaResposta = dalQuestionarioEmpresaResposta.ObterPorIdQuestionarioEmpresaResposta(objQuestionarioEmpresa.IdQuestionarioEmpresa, transaction, db);
                        objQuestionarioEmpresa.ListQuestionarioPontuacao = dalQuestionarioPontuacao.ObterPorIdQuestionarioEmpresa(objQuestionarioEmpresa.IdQuestionarioEmpresa, transaction, db);
                        objQuestionarioEmpresa.Questionario = dalQuestionario.ObterPorId(IdQuestionario, transaction, db);
                        objQuestionarioEmpresa.Etapa = dalEtapa.ObterPorId(objQuestionarioEmpresa.Etapa.IdEtapa, transaction, db);
                    }
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
            return objQuestionarioEmpresa;
        }

        /// <summary>
        /// Retorna uma entidade de QuestionarioEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterQuestionarioAtivoPorTurma(Int32 IdQuestionario, Int32 IdEmpCadastro, Int32 IdTurma)
        {
            EntQuestionarioEmpresa objQuestionarioEmpresa = new EntQuestionarioEmpresa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objQuestionarioEmpresa = dalQuestionarioEmpresa.ObterQuestionarioPorTurmaQuestionarioEmpresa(IdQuestionario, IdEmpCadastro, IdTurma, transaction, db);
                    objQuestionarioEmpresa.ListQuestionarioEmpresaAvaliador = dalQuestionarioEmpresaAvaliador.ObterPorIdQuestionarioEmpresa(objQuestionarioEmpresa.IdQuestionarioEmpresa, transaction, db);
                    objQuestionarioEmpresa.ListQuestionarioEmpresaResposta = dalQuestionarioEmpresaResposta.ObterPorIdQuestionarioEmpresaResposta(objQuestionarioEmpresa.IdQuestionarioEmpresa, transaction, db);
                    objQuestionarioEmpresa.ListQuestionarioPontuacao = dalQuestionarioPontuacao.ObterPorIdQuestionarioEmpresa(objQuestionarioEmpresa.IdQuestionarioEmpresa, transaction, db);
                    objQuestionarioEmpresa.Questionario = dalQuestionario.ObterPorId(IdQuestionario, transaction, db);
                    objQuestionarioEmpresa.Etapa = dalEtapa.ObterPorId(objQuestionarioEmpresa.Etapa.IdEtapa, transaction, db);
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
            return objQuestionarioEmpresa;
        }

        /// <summary>
        /// Retorna uma entidade de QuestionarioEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterQuestionarioAtivoPorEtapa(Int32 IdQuestionario, Int32 IdEmpCadastro, Int32 IdEtapa)
        {
            EntQuestionarioEmpresa objQuestionarioEmpresa = new EntQuestionarioEmpresa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objQuestionarioEmpresa = dalQuestionarioEmpresa.ObterQuestionarioPorEtapaQuestionarioEmpresa(IdQuestionario, IdEmpCadastro, IdEtapa, transaction, db);
                    objQuestionarioEmpresa.ListQuestionarioEmpresaAvaliador = dalQuestionarioEmpresaAvaliador.ObterPorIdQuestionarioEmpresa(objQuestionarioEmpresa.IdQuestionarioEmpresa, transaction, db);
                    objQuestionarioEmpresa.ListQuestionarioEmpresaResposta = dalQuestionarioEmpresaResposta.ObterPorIdQuestionarioEmpresaResposta(objQuestionarioEmpresa.IdQuestionarioEmpresa, transaction, db);
                    objQuestionarioEmpresa.ListQuestionarioPontuacao = dalQuestionarioPontuacao.ObterPorIdQuestionarioEmpresa(objQuestionarioEmpresa.IdQuestionarioEmpresa, transaction, db);
                    objQuestionarioEmpresa.Questionario = dalQuestionario.ObterPorId(IdQuestionario, transaction, db);
                    objQuestionarioEmpresa.Etapa = dalEtapa.ObterPorId(objQuestionarioEmpresa.Etapa.IdEtapa, transaction, db);
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
            return objQuestionarioEmpresa;
        }

        /// <summary>
        /// Retorna uma entidade de QuestionarioEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterQuestionarioPorTurmaQuestionarioEmpresa(Int32 IdQuestionario, Int32 IdEmpCadastro, Int32 IdTurma)
        {
            EntQuestionarioEmpresa objQuestionarioEmpresa = new EntQuestionarioEmpresa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objQuestionarioEmpresa = dalQuestionarioEmpresa.ObterQuestionarioPorTurmaQuestionarioEmpresa(IdQuestionario, IdEmpCadastro, IdTurma, transaction, db);
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
            return objQuestionarioEmpresa;
        }

        /// <summary>
        /// Retorna uma entidade de QuestionarioEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        public List<EntQuestionarioEmpresa> ObterQuestionarioPorTurmaEmpresa(Int32 IdEmpCadastro, Int32 IdTurma)
        {
            List<EntQuestionarioEmpresa> listQuestionarioEmpresa = new List<EntQuestionarioEmpresa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listQuestionarioEmpresa = dalQuestionarioEmpresa.ObterQuestionarioPorTurmaEmpresa(IdEmpCadastro, IdTurma, transaction, db);
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
            return listQuestionarioEmpresa;
        }

        /// <summary>
        /// Retorna uma entidade de QuestionarioEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        public List<EntQuestionarioEmpresa> ObterQuestionarioEmpresaAtivoPorTurmaEmpresa(Int32 IdEmpCadastro, Int32 IdTurma)
        {
            List<EntQuestionarioEmpresa> listQuestionarioEmpresa = new List<EntQuestionarioEmpresa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listQuestionarioEmpresa = dalQuestionarioEmpresa.ObterQuestionarioEmpresaAtivoPorTurmaEmpresa(IdEmpCadastro, IdTurma, transaction, db);
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
            return listQuestionarioEmpresa;
        }

        /// <summary>
        /// Retorna uma entidade de QuestionarioEmpresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        public List<EntQuestionarioEmpresa> ObterQuestionarioEmpresaAtivoPorEmpresaEtapa(Int32 IdEmpCadastro, Int32 IdEtapa)
        {
            List<EntQuestionarioEmpresa> listQuestionarioEmpresa = new List<EntQuestionarioEmpresa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    listQuestionarioEmpresa = dalQuestionarioEmpresa.ObterQuestionarioEmpresaAtivoPorEmpresaEtapa(IdEmpCadastro, IdEtapa, transaction, db);
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
            return listQuestionarioEmpresa;
        }

        /// <summary>
        /// Inclui uma QuestionarioEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objQuestionarioEmpresa">Entidade de QuestionarioEmpresa</param>
        /// <returns>Entidade de QuestionarioEmpresa</returns>
        public EntQuestionarioEmpresa Inserir(EntQuestionarioEmpresa objQuestionarioEmpresa)
        {
            EntQuestionarioEmpresa objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalQuestionarioEmpresa.Inserir(objQuestionarioEmpresa, transaction, db);

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

        


        
        /// <summary>
        /// Altera a coluna de relatorio gerado dos qustionarios
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        public void AlterarRelatorioGeradoPorProtocolo(String Protocolo, Boolean RelatorioGerado)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalQuestionarioEmpresa.AlterarRelatorioGeradoPorProtocolo(Protocolo, RelatorioGerado, transaction, db);

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
        }

        /// <summary>
        /// Altera um Questionario Empresa somente "Flag Leitura"
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objQuestionarioEmpresa">Entidade de QuestionarioEmpresa</param>
        /// <returns>Entidade de QuestionarioEmpresa</returns>
        public void AlterarSomenteFlagLeitura(Int32 IdQuestionarioEmpresa, Boolean Leitura)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalQuestionarioEmpresa.AlterarSomenteFlagLeitura(IdQuestionarioEmpresa, Leitura, transaction, db);

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
        }

        /// <summary>
        /// Altera um Questionario Empresa somente "Flag Leitura"
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objQuestionarioEmpresa">Entidade de QuestionarioEmpresa</param>
        /// <returns>Entidade de QuestionarioEmpresa</returns>
        public void AlterarSomenteDesclassificar(EntQuestionarioEmpresa objQuestionarioEmpresa)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalQuestionarioEmpresa.AlterarSomenteDesclassificar(objQuestionarioEmpresa, transaction, db);

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
        }

        /// <summary>
        /// Altera um Questionario Empresa somente "Flag Leitura"
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objQuestionarioEmpresa">Entidade de QuestionarioEmpresa</param>
        /// <returns>Entidade de QuestionarioEmpresa</returns>
        public void AlterarSomentePassaProximaEtapa(Int32 IdQuestionarioEmpresa)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalQuestionarioEmpresa.AlterarSomentePassaProximaEtapa(IdQuestionarioEmpresa, transaction, db);

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
        }

        /// <summary>
        /// Altera um Questionario Empresa somente "Flag Leitura"
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objQuestionarioEmpresa">Entidade de QuestionarioEmpresa</param>
        /// <returns>Entidade de QuestionarioEmpresa</returns>
        public void AlterarSomenteResumo(Int32 IdQuestionarioEmpresa, String Resumo)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalQuestionarioEmpresa.AlterarSomenteResumo(IdQuestionarioEmpresa, Resumo, transaction, db);

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
        }

        /// <summary>
        /// Altera um Questionario Empresa somente "Flag Leitura"
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objQuestionarioEmpresa">Entidade de QuestionarioEmpresa</param>
        /// <returns>Entidade de QuestionarioEmpresa</returns>
        public void AlterarInsereDevolucao(Int32 IdQuestionarioEmpresa, String Resumo)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalQuestionarioEmpresa.AlterarInsereDevolucao(IdQuestionarioEmpresa, Resumo, transaction, db);

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
        }

        /// <summary>
        /// Inclui uma QuestionarioEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objQuestionarioEmpresa">Entidade de QuestionarioEmpresa</param>
        /// <returns>Entidade de QuestionarioEmpresa</returns>
        public void DesabilitaAnteriores(Int32 IdEmpresaCadastro, Int32 IdEtapa, Int32 IdQuestionario)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalQuestionarioEmpresa.DesabilitaAnteriores(IdEmpresaCadastro, IdEtapa, IdQuestionario, transaction, db);

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
        }

        /// <summary>
        /// Inclui uma QuestionarioEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objQuestionarioEmpresa">Entidade de QuestionarioEmpresa</param>
        /// <returns>Entidade de QuestionarioEmpresa</returns>
        public EntQuestionarioEmpresa InserirComFilhos(EntQuestionarioEmpresa objQuestionarioEmpresa)
        {
            EntQuestionarioEmpresa objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalQuestionarioEmpresa.Inserir(objQuestionarioEmpresa, transaction, db);

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
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    foreach (EntQuestionarioEmpresaResposta resposta in objQuestionarioEmpresa.ListQuestionarioEmpresaResposta)
                    {
                        resposta.QuestionarioEmpresa.IdQuestionarioEmpresa = objRetorno.IdQuestionarioEmpresa;
                        new BllQuestionarioEmpresaResposta().InserirAtualizar(resposta, false);
                    }
                    foreach (EntQuestionarioPontuacao pontuacao in objQuestionarioEmpresa.ListQuestionarioPontuacao)
                    {
                        pontuacao.QuestionarioEmpresa.IdQuestionarioEmpresa = objRetorno.IdQuestionarioEmpresa;
                        new BllQuestionarioPontuacao().Inserir(pontuacao);
                    }
                    foreach (EntQuestionarioEmpresaAvaliador avaliador in objQuestionarioEmpresa.ListQuestionarioEmpresaAvaliador)
                    {
                        avaliador.IdQuestionarioEmpresaAvaliador = 0;
                        avaliador.Avaliado = false;
                        avaliador.QuestionarioEmpresa.IdQuestionarioEmpresa = objRetorno.IdQuestionarioEmpresa;
                        new BllQuestionarioEmpresaAvaliador().Inserir(avaliador);
                    }

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

        /// <summary>
        /// Altera uma QuestionarioEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objQuestionarioEmpresa">Entidade de QuestionarioEmpresa</param>
        public void Alterar(EntQuestionarioEmpresa objQuestionarioEmpresa)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalQuestionarioEmpresa.Alterar(objQuestionarioEmpresa, transaction, db);

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
        }

        /// <summary>
        /// Altera uma QuestionarioEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objQuestionarioEmpresa">Entidade de QuestionarioEmpresa</param>
        public EntQuestionarioEmpresa ObterQuestionarioEmpresaPorFiltros(EntQuestionarioEmpresa objQuestionarioEmpresa)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    objQuestionarioEmpresa = dalQuestionarioEmpresa.ObterQuestionarioEmpresaPorFiltros(objQuestionarioEmpresa, transaction, db);
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
            return objQuestionarioEmpresa;
        }

    }
}
