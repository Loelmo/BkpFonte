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
    /// Classe de Dados que representa um Relatorio RAA
    /// </summary>
    public class BllRelatorio : BllBase
    {
        /// <summary>
        /// Retorna um relatorio de RAA
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntEtapa">EntEtapa</returns>
        public List<EntRelatorioRAA> RelRAAPorFiltro(Int32 IdEmpresaCadastro, Int32 IdTurma, Int32 IdPrograma, Boolean? IsAvaliador)
        {
            DalRelatorioRAA dalRelatorio = new DalRelatorioRAA();
            List<EntRelatorioRAA> objRelatorioRAA = new List<EntRelatorioRAA>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRelatorioRAA = dalRelatorio.ObterRelatorioPorFiltro(IdEmpresaCadastro, IdTurma, IdPrograma, IsAvaliador, transaction, db);

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
            return objRelatorioRAA;
        }

        /// <summary>
        /// Retorna um relatorio de Numero de Participantes FGA
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <returns><type="EntRelatorioNumeroParticipantesFga">EntRelatorioNumeroParticipantesFga</returns>
        public List<RelRelatorioNumeroParticipantes> RelNumeroParticipantesEtapaFga(RelFiltroGeral Filtro, int CategoriaEstado)
        {
            DalRelatorioNumeroParticipantes dalRelatorio = new DalRelatorioNumeroParticipantes();
            List<RelRelatorioNumeroParticipantes> objRelatorio = new List<RelRelatorioNumeroParticipantes>();
            RelRelatorioNumeroParticipantes Totais = new RelRelatorioNumeroParticipantes();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    if (CategoriaEstado == 1)
                        objRelatorio = dalRelatorio.ObterParticipantesPorEstadoEtapa(Filtro, transaction, db);
                    else
                        objRelatorio = dalRelatorio.ObterParticipantesPorCategoriaEtapa(Filtro, transaction, db);

                    Totais.TotalQtdAutodiagnostico = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdAutodiagnostico);
                    Totais.TotalQtdFase2 = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdFase2);
                    Totais.TotalQtdFase3 = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdFase3);
                    Totais.TotalQtdFase4 = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdFase4);
                    Totais.TotalQtdInscritas = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdInscritas);
                    Totais.TotalQtdMpeCandidatasEstadual = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdMpeCandidatasEstadual);
                    Totais.TotalQtdMpeCandidatasNacional = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdMpeCandidatasNacional);
                    Totais.TotalQtdMpeClassificadasEstadual = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdMpeClassificadasEstadual);
                    Totais.TotalQtdMpeClassificadasNacional = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdMpeClassificadasNacional);
                    Totais.TotalQtdMpeFinalistasEstadual = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdMpeFinalistasEstadual);
                    Totais.TotalQtdMpeFinalistasNacional = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdMpeFinalistasNacional);
                    Totais.TotalQtdMpeVencedorasEstadual = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdMpeVencedorasEstadual);
                    Totais.TotalQtdPreClassificadas = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdPreClassificadas);
                    Totais.TotalQtdValidacaoRespostas = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdValidacaoRespostas);
                    Totais.TotalQtdVencedoras = objRelatorio.Sum<RelRelatorioNumeroParticipantes>(Total => Total.QtdVencedoras);

                    for (int i = 0; i < objRelatorio.Count; i++)
                    {
                        if (CategoriaEstado == 1)
                        {
                            objRelatorio[i].PercEstadoAutodiagnostico = CalculaPorcentagem(objRelatorio[i].QtdAutodiagnostico, Totais.TotalQtdAutodiagnostico);
                            objRelatorio[i].PercEstadoFase2 = CalculaPorcentagem(objRelatorio[i].QtdFase2, Totais.TotalQtdFase2);
                            objRelatorio[i].PercEstadoFase3 = CalculaPorcentagem(objRelatorio[i].QtdFase3, Totais.TotalQtdFase3);
                            objRelatorio[i].PercEstadoFase4 = CalculaPorcentagem(objRelatorio[i].QtdFase4, Totais.TotalQtdFase4);
                            objRelatorio[i].PercEstadoInscritas = CalculaPorcentagem(objRelatorio[i].QtdInscritas, Totais.TotalQtdInscritas);
                            objRelatorio[i].PercEstadoMpeCandidatasEstadual = CalculaPorcentagem(objRelatorio[i].QtdMpeCandidatasEstadual, Totais.TotalQtdMpeCandidatasEstadual);
                            objRelatorio[i].PercEstadoMpeCandidatasNacional = CalculaPorcentagem(objRelatorio[i].QtdMpeCandidatasNacional, Totais.TotalQtdMpeCandidatasNacional);
                            objRelatorio[i].PercEstadoMpeClassificadasEstadual = CalculaPorcentagem(objRelatorio[i].QtdMpeClassificadasEstadual, Totais.TotalQtdMpeClassificadasEstadual);
                            objRelatorio[i].PercEstadoMpeClassificadasNacional = CalculaPorcentagem(objRelatorio[i].QtdMpeClassificadasNacional, Totais.TotalQtdMpeClassificadasNacional);
                            objRelatorio[i].PercEstadoMpeFinalistasEstadual = CalculaPorcentagem(objRelatorio[i].QtdMpeFinalistasEstadual, Totais.TotalQtdMpeFinalistasEstadual);
                            objRelatorio[i].PercEstadoMpeFinalistasNacional = CalculaPorcentagem(objRelatorio[i].QtdMpeFinalistasNacional, Totais.TotalQtdMpeFinalistasNacional);
                            objRelatorio[i].PercEstadoMpeVencedorasEstadual = CalculaPorcentagem(objRelatorio[i].QtdMpeVencedorasEstadual, Totais.TotalQtdMpeVencedorasEstadual);
                            objRelatorio[i].PercEstadoPreClassificadas = CalculaPorcentagem(objRelatorio[i].QtdPreClassificadas, Totais.TotalQtdPreClassificadas);
                            objRelatorio[i].PercEstadoValidacaoRespostas = CalculaPorcentagem(objRelatorio[i].QtdValidacaoRespostas, Totais.TotalQtdValidacaoRespostas);
                            objRelatorio[i].PercEstadoVencedoras = CalculaPorcentagem(objRelatorio[i].QtdVencedoras, Totais.TotalQtdVencedoras);
                        }
                        else
                        {
                            objRelatorio[i].PercCategoriaAutodiagnostico = CalculaPorcentagem(objRelatorio[i].QtdAutodiagnostico, Totais.TotalQtdAutodiagnostico);
                            objRelatorio[i].PercCategoriaFase2 = CalculaPorcentagem(objRelatorio[i].QtdFase2, Totais.TotalQtdFase2);
                            objRelatorio[i].PercCategoriaFase3 = CalculaPorcentagem(objRelatorio[i].QtdFase3, Totais.TotalQtdFase3);
                            objRelatorio[i].PercCategoriaFase4 = CalculaPorcentagem(objRelatorio[i].QtdFase4, Totais.TotalQtdFase4);
                            objRelatorio[i].PercCategoriaInscritas = CalculaPorcentagem(objRelatorio[i].QtdInscritas, Totais.TotalQtdInscritas);
                            objRelatorio[i].PercCategoriaMpeCandidatasEstadual = CalculaPorcentagem(objRelatorio[i].QtdMpeCandidatasEstadual, Totais.TotalQtdMpeCandidatasEstadual);
                            objRelatorio[i].PercCategoriaMpeCandidatasNacional = CalculaPorcentagem(objRelatorio[i].QtdMpeCandidatasNacional, Totais.TotalQtdMpeCandidatasNacional);
                            objRelatorio[i].PercCategoriaMpeClassificadasEstadual = CalculaPorcentagem(objRelatorio[i].QtdMpeClassificadasEstadual, Totais.TotalQtdMpeClassificadasEstadual);
                            objRelatorio[i].PercCategoriaMpeClassificadasNacional = CalculaPorcentagem(objRelatorio[i].QtdMpeClassificadasNacional, Totais.TotalQtdMpeClassificadasNacional);
                            objRelatorio[i].PercCategoriaMpeFinalistasEstadual = CalculaPorcentagem(objRelatorio[i].QtdMpeFinalistasEstadual, Totais.TotalQtdMpeFinalistasEstadual);
                            objRelatorio[i].PercCategoriaMpeFinalistasNacional = CalculaPorcentagem(objRelatorio[i].QtdMpeFinalistasNacional, Totais.TotalQtdMpeFinalistasNacional);
                            objRelatorio[i].PercCategoriaMpeVencedorasEstadual = CalculaPorcentagem(objRelatorio[i].QtdMpeVencedorasEstadual, Totais.TotalQtdMpeVencedorasEstadual);
                            objRelatorio[i].PercCategoriaPreClassificadas = CalculaPorcentagem(objRelatorio[i].QtdPreClassificadas, Totais.TotalQtdPreClassificadas);
                            objRelatorio[i].PercCategoriaValidacaoRespostas = CalculaPorcentagem(objRelatorio[i].QtdValidacaoRespostas, Totais.TotalQtdValidacaoRespostas);
                            objRelatorio[i].PercCategoriaVencedoras = CalculaPorcentagem(objRelatorio[i].QtdVencedoras, Totais.TotalQtdVencedoras);
                        }

                        objRelatorio[i].TotalQtdAutodiagnostico = Totais.TotalQtdAutodiagnostico;
                        objRelatorio[i].TotalQtdFase2 = Totais.TotalQtdFase2;
                        objRelatorio[i].TotalQtdFase3 = Totais.TotalQtdFase3;
                        objRelatorio[i].TotalQtdFase4 = Totais.TotalQtdFase4;
                        objRelatorio[i].TotalQtdInscritas = Totais.TotalQtdInscritas;
                        objRelatorio[i].TotalQtdMpeCandidatasEstadual = Totais.TotalQtdMpeCandidatasEstadual;
                        objRelatorio[i].TotalQtdMpeCandidatasNacional = Totais.TotalQtdMpeCandidatasNacional;
                        objRelatorio[i].TotalQtdMpeClassificadasEstadual = Totais.TotalQtdMpeClassificadasEstadual;
                        objRelatorio[i].TotalQtdMpeClassificadasNacional = Totais.TotalQtdMpeClassificadasNacional;
                        objRelatorio[i].TotalQtdMpeFinalistasEstadual = Totais.TotalQtdMpeFinalistasEstadual;
                        objRelatorio[i].TotalQtdMpeFinalistasNacional = Totais.TotalQtdMpeFinalistasNacional;
                        objRelatorio[i].TotalQtdMpeVencedorasEstadual = Totais.TotalQtdMpeVencedorasEstadual;
                        objRelatorio[i].TotalQtdPreClassificadas = Totais.TotalQtdPreClassificadas;
                        objRelatorio[i].TotalQtdValidacaoRespostas = Totais.TotalQtdValidacaoRespostas;
                        objRelatorio[i].TotalQtdVencedoras = Totais.TotalQtdVencedoras;
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
            return objRelatorio;
        }

        private decimal CalculaPorcentagem(decimal numerador, decimal denominador)
        {
            decimal res = 0;
            if (denominador > 0)
            {
                res = (numerador / denominador);
            }
            return res;

        }

        /// <summary>
        /// Retorna uma Lista de entidade de Relatorio
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><list type="EntAdmGrupo">Lista de RelRankingCandidataEstadual</list></returns>
        public List<RelRelatorioQuestoesEspeciais> ObterRelatorioQuestoesEspeciais(RelFiltroRanking objRelFiltroRanking)
        {
            DalRelatorioNumeroParticipantes dalRelatorio = new DalRelatorioNumeroParticipantes();
            List<RelRelatorioQuestoesEspeciais> lstRelRankingFinalista = new List<RelRelatorioQuestoesEspeciais>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstRelRankingFinalista = dalRelatorio.ObterRelatorioQuestoesEspeciais(objRelFiltroRanking, transaction, db);
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
        /// Retorna um relatorio de Numero de Participantes MPE
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <returns><type="RelParticipantesPorEtapa">RelParticipantesPorEtapa</returns>
        public List<RelParticipantesPorEtapa> ObterParticipantesPorEtapaPorEstado(RelFiltroRanking objRelFiltroRanking)
        {
            DalRelatorioNumeroParticipantes dalRelatorio = new DalRelatorioNumeroParticipantes();
            List<RelParticipantesPorEtapa> objRelatorio = new List<RelParticipantesPorEtapa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRelatorio = dalRelatorio.ObterParticipantesPorEtapaPorEstado(objRelFiltroRanking, transaction, db);

                    Int32 TotalInscritasPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalInscritas);
                    Int32 TotalCandidatasPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalCandidatas);
                    Int32 TotalClassificadasPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalClassificadas);
                    Int32 TotalFinalistasGestaoPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalFinalistasGestao);
                    Int32 TotalFinalistasRespSocialPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalFinalistasRespSocial);
                    Int32 TotalFinalistasInovacaoPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalFinalistasInovacao);
                    Int32 TotalVencedoraGestaoPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalVencedoraGestao);
                    Int32 TotalVencedoraRespSocialPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalVencedoraRespSocial);
                    Int32 TotalVencedoraInovacaoPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalVencedoraInovacao);

                    foreach (RelParticipantesPorEtapa item in objRelatorio)
                    {
                        item.TotalInscritasPorTurma = TotalInscritasPorTurma;
                        item.TotalCandidatasPorTurma = TotalCandidatasPorTurma;
                        item.TotalClassificadasPorTurma = TotalClassificadasPorTurma;
                        item.TotalFinalistasGestaoPorTurma = TotalFinalistasGestaoPorTurma;
                        item.TotalFinalistasRespSocialPorTurma = TotalFinalistasRespSocialPorTurma;
                        item.TotalFinalistasInovacaoPorTurma = TotalFinalistasInovacaoPorTurma;
                        item.TotalVencedoraGestaoPorTurma = TotalVencedoraGestaoPorTurma;
                        item.TotalVencedoraRespSocialPorTurma = TotalVencedoraRespSocialPorTurma;
                        item.TotalVencedoraInovacaoPorTurma = TotalVencedoraInovacaoPorTurma;
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
            return objRelatorio;
        }

        /// <summary>
        /// Retorna um relatorio de Numero de Participantes MPE
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <returns><type="RelParticipantesPorEtapa">RelParticipantesPorEtapa</returns>
        public List<RelParticipantesPorEtapa> ObterParticipantesPorEtapaPorCategoria(RelFiltroRanking objRelFiltroRanking)
        {
            DalRelatorioNumeroParticipantes dalRelatorio = new DalRelatorioNumeroParticipantes();
            List<RelParticipantesPorEtapa> objRelatorio = new List<RelParticipantesPorEtapa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRelatorio = dalRelatorio.ObterParticipantesPorEtapaPorCategoria(objRelFiltroRanking, transaction, db);

                    Int32 TotalInscritasPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalInscritas);
                    Int32 TotalCandidatasPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalCandidatas);
                    Int32 TotalClassificadasPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalClassificadas);
                    Int32 TotalFinalistasGestaoPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalFinalistasGestao);
                    Int32 TotalFinalistasRespSocialPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalFinalistasRespSocial);
                    Int32 TotalFinalistasInovacaoPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalFinalistasInovacao);
                    Int32 TotalVencedoraGestaoPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalVencedoraGestao);
                    Int32 TotalVencedoraRespSocialPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalVencedoraRespSocial);
                    Int32 TotalVencedoraInovacaoPorTurma = objRelatorio.Sum<RelParticipantesPorEtapa>(objParticipantesPorEtapa => objParticipantesPorEtapa.TotalVencedoraInovacao);

                    foreach (RelParticipantesPorEtapa item in objRelatorio)
                    {
                        item.TotalInscritasPorTurma = TotalInscritasPorTurma;
                        item.TotalCandidatasPorTurma = TotalCandidatasPorTurma;
                        item.TotalClassificadasPorTurma = TotalClassificadasPorTurma;
                        item.TotalFinalistasGestaoPorTurma = TotalFinalistasGestaoPorTurma;
                        item.TotalFinalistasRespSocialPorTurma = TotalFinalistasRespSocialPorTurma;
                        item.TotalFinalistasInovacaoPorTurma = TotalFinalistasInovacaoPorTurma;
                        item.TotalVencedoraGestaoPorTurma = TotalVencedoraGestaoPorTurma;
                        item.TotalVencedoraRespSocialPorTurma = TotalVencedoraRespSocialPorTurma;
                        item.TotalVencedoraInovacaoPorTurma = TotalVencedoraInovacaoPorTurma;
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
            return objRelatorio;
        }
    }
}