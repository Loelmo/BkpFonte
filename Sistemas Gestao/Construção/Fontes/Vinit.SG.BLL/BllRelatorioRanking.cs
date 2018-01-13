using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using System.Data.Common;
using Vinit.SG.Common;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa um Relatorio Ranking
    /// </summary>
    public class BllRelatorioRanking : BllQuestionarioEmpresaCalculoPontuacao
    {
        /// <summary>
        /// Variável privada que representa uma classe de DalRelatorioRanking
        /// </summary>
        private DalRelatorioRanking dalRelatorioRanking = new DalRelatorioRanking();

        /// <summary>
        /// Variável privada que representa uma classe de DalRelatorioRanking
        /// </summary>
        private DalEtapa dalEtapa = new DalEtapa();

        /// <summary>
        /// Retorna uma Lista de entidade de Ranking Finalista
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><list type="EntAdmGrupo">Lista de RelRankingFinalista</list></returns>
        public List<RelRankingFinalista> ObterRankingFinalistaPorFiltro(RelFiltroRanking objRelFiltroRanking)
        {
            List<RelRankingFinalista> lstRelRankingFinalista = new List<RelRankingFinalista>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstRelRankingFinalista = dalRelatorioRanking.ObterRankingFinalistaPorFiltro(objRelFiltroRanking, transaction, db);
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
            return lstRelRankingFinalista;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Ranking Finalista
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmGrupo">Lista de RelRankingCandidataEstadual</list></returns>
        public List<RelRankingCandidataEstadual> ObterRankingCandidataPorFiltro(RelFiltroRanking objRelFiltroRanking)
        {
            List<RelRankingCandidataEstadual> lstRelRankingFinalista = new List<RelRankingCandidataEstadual>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstRelRankingFinalista = dalRelatorioRanking.ObterRankingCandidataPorFiltro(objRelFiltroRanking, transaction, db);
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
            return lstRelRankingFinalista;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Ranking Finalista
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmGrupo">Lista de RelRankingCandidataEstadual</list></returns>
        public List<RelRankingCandidataNacional> ObterRankingCandidataNacionalPorFiltro(RelFiltroRanking objRelFiltroRanking)
        {
            List<RelRankingCandidataNacional> lstRelRankingFinalista = new List<RelRankingCandidataNacional>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstRelRankingFinalista = dalRelatorioRanking.ObterRankingCandidataNacionalPorFiltro(objRelFiltroRanking, transaction, db);
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
            return lstRelRankingFinalista;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Ranking Classificada
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <returns><list type="EntAdmGrupo">Lista de RelRankingClassificada</list></returns>
        /// 
        public List<RelRankingClassificada> ObterRankingClassificadaPorFiltro(RelFiltroRanking objRelFiltroRanking)
        {
            List<RelRankingClassificada> lstRelRankingClassificada = new List<RelRankingClassificada>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstRelRankingClassificada = dalRelatorioRanking.ObterRankingClassificadaPorFiltro(objRelFiltroRanking, transaction, db);
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
            return lstRelRankingClassificada;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Ranking Classificada
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <returns><list type="EntAdmGrupo">Lista de RelRankingClassificada</list></returns>
        /// 
        public List<EntComparacaoResultados> ComparacaoResultadosFase1Fase4PreVista(RelFiltroRanking objRelFiltroRanking)
        {
            List<EntComparacaoResultados> lstRelRankingClassificada = new List<EntComparacaoResultados>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstRelRankingClassificada = dalRelatorioRanking.ComparacaoResultadosFase1Fase4PreVista(objRelFiltroRanking, transaction, db);
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
            return lstRelRankingClassificada;
        }


        /// <summary>
        /// Retorna uma Lista de entidade de Ranking Classificada
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <returns><list type="EntAdmGrupo">Lista de RelRankingClassificada</list></returns>
        /// 
        public List<RelRankingPegFase2> ObterRankingPegFase2PorFiltro(RelFiltroRanking objRelFiltroRanking)
        {
            List<RelRankingPegFase2> lstRelRankingFase2 = new List<RelRankingPegFase2>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstRelRankingFase2 = dalRelatorioRanking.ObterRankingPegFase2PorFiltro(objRelFiltroRanking, transaction, db);
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
            return lstRelRankingFase2;
        }

        /// <summary>
        /// Desclassifica Questionario Empresa
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objQuestionarioEmpresa">EntQuestionarioEmpresa</param>
        public void DesclassificaQuestionarioEmpresa(EntQuestionarioEmpresa objQuestionarioEmpresa)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalRelatorioRanking.DesclassificaQuestionarioEmpresa(objQuestionarioEmpresa, transaction, db);
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

        public void EncaminharEtapaAnterior(Int32 IdEmpresaCadastro, Int32 IdQuestionario, Int32 IdEtapa, Boolean FlQuestionarioUnico)
        {
            EntEtapa etapa = new BllEtapa().ObterPorId(IdEtapa);
            if (FlQuestionarioUnico)
            {
                EntQuestionarioEmpresa questionarioEmpresa = new BllQuestionarioEmpresa().ObterQuestionarioAtivoPorEtapa(IdQuestionario, IdEmpresaCadastro, IdEtapa);
                DesabilitaProximosQuestionarios(questionarioEmpresa, IdEmpresaCadastro, etapa.Turma.IdTurma, questionarioEmpresa.Protocolo);
            }
            else
            {
                List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterEnviadosPorIdEtapaIdEmpresa(IdEtapa, IdEmpresaCadastro);
                foreach (EntQuestionario questionario in listaQuestionarios)
                {
                    if (questionario.EmpresaParticipa)
                    {
                        EntQuestionarioEmpresa questionarioEmpresa = new BllQuestionarioEmpresa().ObterQuestionarioAtivoPorEtapa(questionario.IdQuestionario, IdEmpresaCadastro, IdEtapa);
                        DesabilitaProximosQuestionarios(questionarioEmpresa, IdEmpresaCadastro, etapa.Turma.IdTurma, questionarioEmpresa.Protocolo);
                        DesabilitaPassaProximaEtapa(questionarioEmpresa);
                    }
                }
            }
        }

        public void EncaminharProximaEtapa(Int32 IdEmpresaCadastro, Int32 IdQuestionario, Int32 IdEtapa, Boolean FlQuestionarioUnico)
        {
            EntEtapa etapa = new BllEtapa().ObterPorId(IdEtapa);
            if (FlQuestionarioUnico)
            {
                EntQuestionarioEmpresa questionarioEmpresa = new BllQuestionarioEmpresa().ObterQuestionarioAtivoPorEtapa(IdQuestionario, IdEmpresaCadastro, IdEtapa);
                ProcessaQuestionarios(questionarioEmpresa, IdEmpresaCadastro, etapa.Turma.IdTurma, questionarioEmpresa.Protocolo);
            }
            else
            {
                List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterEnviadosPorIdEtapaIdEmpresa(IdEtapa, IdEmpresaCadastro);
                foreach (EntQuestionario questionario in listaQuestionarios)
                {
                    if (questionario.EmpresaParticipa)
                    {
                        EntQuestionarioEmpresa questionarioEmpresa = new BllQuestionarioEmpresa().ObterQuestionarioAtivoPorEtapa(questionario.IdQuestionario, IdEmpresaCadastro, IdEtapa);
                        ProcessaQuestionarios(questionarioEmpresa, IdEmpresaCadastro, etapa.Turma.IdTurma, questionarioEmpresa.Protocolo);
                    }
                }
            }
        }

        private void ProcessaQuestionarios(EntQuestionarioEmpresa questionarioEmpresa, Int32 IdEmpresaCadastro, Int32 IdTurma, String Protocolo)
        {
            questionarioEmpresa = this.FechaQuestionarioEmpresa(questionarioEmpresa, questionarioEmpresa.Protocolo, false);
            this.GeraProximosQuestionarios(questionarioEmpresa, questionarioEmpresa.Protocolo, false);
        }

        private void DesabilitaProximosQuestionarios(EntQuestionarioEmpresa questionarioEmpresa, Int32 IdEmpresaCadastro, Int32 IdTurma, String Protocolo)
        {
            EntEtapa etapa = new BllEtapa().ObterProximaEtapaPorEtapaEstadoOrdem(questionarioEmpresa.Etapa.IdEtapa);
            new BllQuestionarioEmpresa().DesabilitaAnteriores(questionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, etapa.IdEtapa, questionarioEmpresa.Questionario.IdQuestionario);
        }

        private void DesabilitaPassaProximaEtapa(EntQuestionarioEmpresa questionarioEmpresa)
        {
            questionarioEmpresa.PassaProximaEtapa = false;
            questionarioEmpresa.DtAlteracao = DateTime.Now;
            new BllQuestionarioEmpresa().Alterar(questionarioEmpresa);
        }

        /// <summary>
        /// Devolver para o Avaliador
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// /// <param name="objQuestionarioEmpresaAvaliador">EntQuestionarioEmpresaAvaliador</param>
        public void DevolverParaAvaliador(EntQuestionarioEmpresaAvaliador objQuestionarioEmpresaAvaliador)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalRelatorioRanking.DevolverParaAvaliador(objQuestionarioEmpresaAvaliador, transaction, db);
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
        /// Retorna uma Lista de entidade de Ranking Finalista
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntAdmGrupo">Lista de RelRankingCandidataEstadual</list></returns>
        public List<RelAvaliacao> ObterAvaliacaoPorFiltro(RelFiltroRanking objRelFiltroRanking)
        {
            List<RelAvaliacao> lstRelAvaliacao = new List<RelAvaliacao>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstRelAvaliacao = dalRelatorioRanking.ObterAvaliacaoPorFiltro(objRelFiltroRanking, transaction, db);
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
            return lstRelAvaliacao;
        }

    }
}
