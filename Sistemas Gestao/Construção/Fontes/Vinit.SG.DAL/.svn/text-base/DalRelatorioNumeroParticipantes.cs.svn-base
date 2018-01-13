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
    /// Classe de Dados que representa um Relatório de Numero de Participantes
    /// </summary>
    public class DalRelatorioNumeroParticipantes
    {

        /// <summary>
        /// Retorna o numero de participantes do FGA por Estado e Etapa
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntRelatorioNumeroParticipantesFga">Lista de EntRelatorioNumeroParticipantesFga</list></returns>
        public List<RelRelatorioNumeroParticipantes> ObterParticipantesPorEstadoEtapa(RelFiltroGeral Filtro, DbTransaction transaction, Database db)
        {
            List<RelRelatorioNumeroParticipantes> lstRetorno = new List<RelRelatorioNumeroParticipantes>();

            String NomeProc = "";
            if (Filtro.Programa == EntPrograma.PROGRAMA_MPE)
            {
                NomeProc = "STP_Seleciona_NumeroParticipantesEstadoEtapaMpe";
            }
            else if (Filtro.Programa == EntPrograma.PROGRAMA_FGA)
            {
                NomeProc = "STP_Seleciona_NumeroParticipantesEstadoEtapaFga";
            }
            else if (Filtro.Programa == EntPrograma.PROGRAMA_PEG)
            {
                NomeProc = "STP_Seleciona_NumeroParticipantesEstadoEtapaPeg";
            }

            DbCommand dbCommand = db.GetStoredProcCommand(NomeProc);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            //--------Parametros --------------------------------------------------
            if (Filtro.Programa == EntPrograma.PROGRAMA_MPE)
            {
                db.AddInParameter(dbCommand, "@InscriçãoCandidaturaEmpresa", DbType.Int32, (int)EnumType.TipoEtapaMpe.InscriçãoCandidaturaEmpresa);
                db.AddInParameter(dbCommand, "@InscriçãoCandidaturaAdministrativo", DbType.Int32, (int)EnumType.TipoEtapaMpe.InscriçãoCandidaturaAdministrativo);
                db.AddInParameter(dbCommand, "@ClassificaçãoEstadual", DbType.Int32, (int)EnumType.TipoEtapaMpe.ClassificaçãoEstadual);
                db.AddInParameter(dbCommand, "@AvaliacaoEstadual", DbType.Int32, (int)EnumType.TipoEtapaMpe.AvaliacaoEstadual);
                db.AddInParameter(dbCommand, "@JulgamentoFinalistasEstaduais", DbType.Int32, (int)EnumType.TipoEtapaMpe.JulgamentoFinalistasEstaduais);
                db.AddInParameter(dbCommand, "@ClassificacaoNacional", DbType.Int32, (int)EnumType.TipoEtapaMpe.ClassificacaoNacional);
                db.AddInParameter(dbCommand, "@AvaliacaoNacional", DbType.Int32, (int)EnumType.TipoEtapaMpe.AvaliacaoNacional);
                db.AddInParameter(dbCommand, "@JulgamentoFinalistasNacionais", DbType.Int32, (int)EnumType.TipoEtapaMpe.JulgamentoFinalistasNacionais);
                db.AddInParameter(dbCommand, "@EncerramentoNacional", DbType.Int32, (int)EnumType.TipoEtapaMpe.EncerramentoNacional);
            }
            else if (Filtro.Programa == EntPrograma.PROGRAMA_FGA)
            {
                db.AddInParameter(dbCommand, "@Autodiagnostico", DbType.Int32, (int)EnumType.TipoEtapaFga.Autodiagnostico);
                db.AddInParameter(dbCommand, "@AutodiagnosticoAdministrativo", DbType.Int32, (int)EnumType.TipoEtapaFga.AutodiagnosticoAdministrativo);
                db.AddInParameter(dbCommand, "@ValidacaoAnaliseRespostas", DbType.Int32, (int)EnumType.TipoEtapaFga.ValidacaoAnaliseRespostas);
                db.AddInParameter(dbCommand, "@VisitaPreviaPreClassificadas", DbType.Int32, (int)EnumType.TipoEtapaFga.VisitaPreviaPreClassificadas);
                db.AddInParameter(dbCommand, "@NovoCicloFase4", DbType.Int32, (int)EnumType.TipoEtapaFga.NovoCicloFase4);
                db.AddInParameter(dbCommand, "@Encerramento", DbType.Int32, (int)EnumType.TipoEtapaFga.Encerramento);
            }
            else if (Filtro.Programa == EntPrograma.PROGRAMA_PEG)
            {
                db.AddInParameter(dbCommand, "@Autodiagnostico", DbType.Int32, (int)EnumType.TipoEtapaPeg.Autodiagnostico);
                db.AddInParameter(dbCommand, "@AutodiagnosticoAdministrativo", DbType.Int32, (int)EnumType.TipoEtapaPeg.AutodiagnosticoAdministrativo);
                db.AddInParameter(dbCommand, "@ValidacaoAnaliseRespostas", DbType.Int32, (int)EnumType.TipoEtapaPeg.ValidacaoAnaliseRespostas);
                db.AddInParameter(dbCommand, "@VisitaPreviaPreClassificadas", DbType.Int32, (int)EnumType.TipoEtapaPeg.VisitaPreviaPreClassificadas);
                db.AddInParameter(dbCommand, "@PlanoEmpresarialFase2", DbType.Int32, (int)EnumType.TipoEtapaPeg.PlanoEmpresarialFase2);
                db.AddInParameter(dbCommand, "@GestãoDoResultadoFase3", DbType.Int32, (int)EnumType.TipoEtapaPeg.GestãoDoResultadoFase3);
                db.AddInParameter(dbCommand, "@NovoCicloFase4", DbType.Int32, (int)EnumType.TipoEtapaPeg.NovoCicloFase4);
                db.AddInParameter(dbCommand, "@Encerramento", DbType.Int32, (int)EnumType.TipoEtapaPeg.Encerramento);
            }

            //--------FILTROS DE TELA----------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, Filtro.Turma);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(0));//Na grid sempre vai trazer todos os estados
            db.AddInParameter(dbCommand, "@sNOME_FANTASIA", DbType.String, Filtro.Nome);
            db.AddInParameter(dbCommand, "@CEA_CATEGORIA", DbType.Int32, IntUtils.ToIntNull(0));
            db.AddInParameter(dbCommand, "@CEA_NIVEL_ESCOLARIDADE", DbType.Int32, IntUtils.ToIntNull(Filtro.EscolaridadeRepresentante));
            db.AddInParameter(dbCommand, "@CEA_FAIXA_ETARIA", DbType.Int32, IntUtils.ToIntNull(Filtro.FaixaEtariaRepresentante));
            db.AddInParameter(dbCommand, "@CEA_CIDADE", DbType.Int32, IntUtils.ToIntNull(Filtro.Municipio));
            db.AddInParameter(dbCommand, "@CEA_ESCRITORIO_REGIONAL", DbType.Int32, IntUtils.ToIntNull(Filtro.EscritorioRegional));
            ////db.AddInParameter(dbCommand, "@STATUS", DbType.Int32, IntUtils.ToIntNull(Filtro.Status));
            db.AddInParameter(dbCommand, "@CEA_GRUPO", DbType.Int32, IntUtils.ToIntNull(Filtro.Grupo));
            db.AddInParameter(dbCommand, "@CEA_FATURAMENTO", DbType.Int32, IntUtils.ToIntNull(Filtro.FaixaFaturamento));
            db.AddInParameter(dbCommand, "@PROTOCOLO", DbType.String, Filtro.Protocolo);
            db.AddInParameter(dbCommand, "@CPF_CNPJ", DbType.String, Filtro.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@CEA_ESTADO_REGIAO", DbType.Int32, IntUtils.ToIntNull(Filtro.EstadoRegiao));
            db.AddInParameter(dbCommand, "@TX_SEXO_CONTATO", DbType.String, StringUtils.ToObject(Filtro.SexoRepresentante));
            db.AddInParameter(dbCommand, "@DATAINICIO", DbType.DateTime, DateUtils.ToObject(Filtro.Inicio));
            db.AddInParameter(dbCommand, "@DATAFIM", DbType.DateTime, DateUtils.ToObject(Filtro.Fim));
            db.AddInParameter(dbCommand, "@NU_FUNCIONARIOS", DbType.Int32, IntUtils.ToIntNull(Filtro.NumeroFuncionarios));
            db.AddInParameter(dbCommand, "@TIPO_EMPRESA", DbType.Int32, IntUtils.ToIntNull(Filtro.TipoEmpresa));
            //-------------------------------------------------------------------
            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {

                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord DataRecord in dtrDados)
                    {
                        RelRelatorioNumeroParticipantes objRelatorio = new RelRelatorioNumeroParticipantes();
                        objRelatorio.Estado = ObjectUtils.ToString(dtrDados["TX_ESTADO"]);
                        objRelatorio.IdEstado = ObjectUtils.ToInt(dtrDados["CDA_ESTADO"]);
                        objRelatorio.QtdInscritas = ObjectUtils.ToInt(dtrDados["N_QtdInscritas"]);
                        objRelatorio.QtdVencedoras = ObjectUtils.ToInt(dtrDados["N_QtdVencedoras"]);

                        if (Filtro.Programa == EntPrograma.PROGRAMA_MPE)
                        {
                            objRelatorio.QtdMpeCandidatasEstadual = ObjectUtils.ToInt(dtrDados["N_QtdMpeCandidatasEstadual"]);
                            objRelatorio.QtdMpeClassificadasEstadual = ObjectUtils.ToInt(dtrDados["N_QtdMpeClassificadasEstadual"]);
                            objRelatorio.QtdMpeFinalistasEstadual = ObjectUtils.ToInt(dtrDados["N_QtdMpeFinalistasEstadual"]);
                            objRelatorio.QtdMpeVencedorasEstadual = ObjectUtils.ToInt(dtrDados["N_QtdMpeVencedorasEstadual"]);
                            objRelatorio.QtdMpeCandidatasNacional = ObjectUtils.ToInt(dtrDados["N_QtdMpeCandidatasNacional"]);
                            objRelatorio.QtdMpeClassificadasNacional = ObjectUtils.ToInt(dtrDados["N_QtdMpeClassificadasNacional"]);
                            objRelatorio.QtdMpeFinalistasNacional = ObjectUtils.ToInt(dtrDados["N_QtdMpeFinalistasNacional"]);
                        }
                        else if (Filtro.Programa == EntPrograma.PROGRAMA_FGA || Filtro.Programa == EntPrograma.PROGRAMA_PEG)
                        {
                            objRelatorio.QtdAutodiagnostico = ObjectUtils.ToInt(dtrDados["N_QtdAutodiagnostico"]);
                            objRelatorio.TotalQtdFase4 = ObjectUtils.ToInt(dtrDados["N_QtdFase4"]);
                            objRelatorio.QtdPreClassificadas = ObjectUtils.ToInt(dtrDados["N_QtdPreClassificadas"]);
                            objRelatorio.QtdValidacaoRespostas = ObjectUtils.ToInt(dtrDados["N_QtdValidacaoRespostas"]);
                            if (Filtro.Programa == EntPrograma.PROGRAMA_PEG)
                            {
                                objRelatorio.TotalQtdFase2 = ObjectUtils.ToInt(dtrDados["N_QtdFase2"]);
                                objRelatorio.TotalQtdFase3 = ObjectUtils.ToInt(dtrDados["N_QtdFase3"]);
                            }
                        }

                        lstRetorno.Add(objRelatorio);
                    }

                    return lstRetorno;
                }
                else
                {
                    return new List<RelRelatorioNumeroParticipantes>();
                }
            }
        }

        /// <summary>
        /// Retorna o numero de participantes do FGA por Categoria e Etapa
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntRelatorioNumeroParticipantesFga">Lista de EntRelatorioNumeroParticipantesFga</list></returns>
        public List<RelRelatorioNumeroParticipantes> ObterParticipantesPorCategoriaEtapa(RelFiltroGeral Filtro, DbTransaction transaction, Database db)
        {
            List<RelRelatorioNumeroParticipantes> lstRetorno = new List<RelRelatorioNumeroParticipantes>();

            String NomeProc = "";
            if (Filtro.Programa == EntPrograma.PROGRAMA_MPE)
            {
                NomeProc = "STP_Seleciona_NumeroParticipantesCategoriaEtapaMpe";
            }
            else if (Filtro.Programa == EntPrograma.PROGRAMA_FGA)
            {
                NomeProc = "STP_Seleciona_NumeroParticipantesCategoriaEtapaFga";
            }
            else if (Filtro.Programa == EntPrograma.PROGRAMA_PEG)
            {
                NomeProc = "STP_Seleciona_NumeroParticipantesCategoriaEtapaPeg";
            }

            DbCommand dbCommand = db.GetStoredProcCommand(NomeProc);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            //--------Parametros do FGA--------------------------------------------
            db.AddInParameter(dbCommand, "@Autodiagnostico", DbType.Int32, (int)EnumType.TipoEtapaFga.Autodiagnostico);
            db.AddInParameter(dbCommand, "@AutodiagnosticoAdministrativo", DbType.Int32, (int)EnumType.TipoEtapaFga.AutodiagnosticoAdministrativo);
            db.AddInParameter(dbCommand, "@ValidacaoAnaliseRespostas", DbType.Int32, (int)EnumType.TipoEtapaFga.ValidacaoAnaliseRespostas);
            db.AddInParameter(dbCommand, "@VisitaPreviaPreClassificadas", DbType.Int32, (int)EnumType.TipoEtapaFga.VisitaPreviaPreClassificadas);
            db.AddInParameter(dbCommand, "@NovoCicloFase4", DbType.Int32, (int)EnumType.TipoEtapaFga.NovoCicloFase4);
            db.AddInParameter(dbCommand, "@Encerramento", DbType.Int32, (int)EnumType.TipoEtapaFga.Encerramento);

            //--------FILTROS DE TELA----------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, Filtro.Turma);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(0));//Na grid sempre vai trazer todos os estados
            db.AddInParameter(dbCommand, "@sNOME_FANTASIA", DbType.String, Filtro.Nome);
            db.AddInParameter(dbCommand, "@CEA_CATEGORIA", DbType.Int32, IntUtils.ToIntNull(0));
            db.AddInParameter(dbCommand, "@CEA_NIVEL_ESCOLARIDADE", DbType.Int32, IntUtils.ToIntNull(Filtro.EscolaridadeRepresentante));
            db.AddInParameter(dbCommand, "@CEA_FAIXA_ETARIA", DbType.Int32, IntUtils.ToIntNull(Filtro.FaixaEtariaRepresentante));
            db.AddInParameter(dbCommand, "@CEA_CIDADE", DbType.Int32, IntUtils.ToIntNull(Filtro.Municipio));
            db.AddInParameter(dbCommand, "@CEA_ESCRITORIO_REGIONAL", DbType.Int32, IntUtils.ToIntNull(Filtro.EscritorioRegional));
            ////db.AddInParameter(dbCommand, "@STATUS", DbType.Int32, IntUtils.ToIntNull(Filtro.Status));
            db.AddInParameter(dbCommand, "@CEA_GRUPO", DbType.Int32, IntUtils.ToIntNull(Filtro.Grupo));
            db.AddInParameter(dbCommand, "@CEA_FATURAMENTO", DbType.Int32, IntUtils.ToIntNull(Filtro.FaixaFaturamento));
            db.AddInParameter(dbCommand, "@PROTOCOLO", DbType.String, Filtro.Protocolo);
            db.AddInParameter(dbCommand, "@CPF_CNPJ", DbType.String, Filtro.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@CEA_ESTADO_REGIAO", DbType.Int32, IntUtils.ToIntNull(Filtro.EstadoRegiao));
            db.AddInParameter(dbCommand, "@TX_SEXO_CONTATO", DbType.String, Filtro.SexoRepresentante);
            db.AddInParameter(dbCommand, "@DATAINICIO", DbType.DateTime, DateUtils.ToObject(Filtro.Inicio));
            db.AddInParameter(dbCommand, "@DATAFIM", DbType.DateTime, DateUtils.ToObject(Filtro.Fim));
            db.AddInParameter(dbCommand, "@NU_FUNCIONARIOS", DbType.Int32, IntUtils.ToIntNull(Filtro.NumeroFuncionarios));
            db.AddInParameter(dbCommand, "@TIPO_EMPRESA", DbType.Int32, IntUtils.ToIntNull(Filtro.TipoEmpresa));
            //-------------------------------------------------------------------
            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {

                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord DataRecord in dtrDados)
                    {
                        RelRelatorioNumeroParticipantes objRelatorio = new RelRelatorioNumeroParticipantes();
                        objRelatorio.Categoria = ObjectUtils.ToString(dtrDados["TX_CATEGORIA"]);
                        objRelatorio.IdCategoria = ObjectUtils.ToInt(dtrDados["CDA_CATEGORIA"]);
                        objRelatorio.QtdInscritas = ObjectUtils.ToInt(dtrDados["N_QtdInscritas"]);
                        objRelatorio.QtdVencedoras = ObjectUtils.ToInt(dtrDados["N_QtdVencedoras"]);

                        if (Filtro.Programa == EntPrograma.PROGRAMA_MPE)
                        {
                            objRelatorio.QtdMpeCandidatasEstadual = ObjectUtils.ToInt(dtrDados["N_QtdMpeCandidatasEstadual"]);
                            objRelatorio.QtdMpeClassificadasEstadual = ObjectUtils.ToInt(dtrDados["N_QtdMpeClassificadasEstadual"]);
                            objRelatorio.QtdMpeFinalistasEstadual = ObjectUtils.ToInt(dtrDados["N_QtdMpeFinalistasEstadual"]);
                            objRelatorio.QtdMpeVencedorasEstadual = ObjectUtils.ToInt(dtrDados["N_QtdMpeVencedorasEstadual"]);
                            objRelatorio.QtdMpeCandidatasNacional = ObjectUtils.ToInt(dtrDados["N_QtdMpeCandidatasNacional"]);
                            objRelatorio.QtdMpeClassificadasNacional = ObjectUtils.ToInt(dtrDados["N_QtdMpeClassificadasNacional"]);
                            objRelatorio.QtdMpeFinalistasNacional = ObjectUtils.ToInt(dtrDados["N_QtdMpeFinalistasNacional"]);
                        }
                        else if (Filtro.Programa == EntPrograma.PROGRAMA_FGA || Filtro.Programa == EntPrograma.PROGRAMA_PEG)
                        {
                            objRelatorio.QtdAutodiagnostico = ObjectUtils.ToInt(dtrDados["N_QtdAutodiagnostico"]);
                            objRelatorio.TotalQtdFase4 = ObjectUtils.ToInt(dtrDados["N_QtdFase4"]);
                            objRelatorio.QtdPreClassificadas = ObjectUtils.ToInt(dtrDados["N_QtdPreClassificadas"]);
                            objRelatorio.QtdValidacaoRespostas = ObjectUtils.ToInt(dtrDados["N_QtdValidacaoRespostas"]);
                            if (Filtro.Programa == EntPrograma.PROGRAMA_PEG)
                            {
                                objRelatorio.TotalQtdFase2 = ObjectUtils.ToInt(dtrDados["N_QtdFase2"]);
                                objRelatorio.TotalQtdFase3 = ObjectUtils.ToInt(dtrDados["N_QtdFase3"]);
                            }
                        }

                        lstRetorno.Add(objRelatorio);
                    }

                    return lstRetorno;
                }
                else
                {
                    return new List<RelRelatorioNumeroParticipantes>();
                }

            }

        }

        /// <summary>
        /// Retorna o numero de participantes do MPE por Estado e Etapa
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="RelParticipantesPorEtapa">Lista de RelParticipantesPorEtapa</list></returns>
        public List<RelParticipantesPorEtapa> ObterParticipantesPorEtapaPorEstado(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            List<RelParticipantesPorEtapa> lstRetorno = new List<RelParticipantesPorEtapa>();

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaNumeroParticipantesPorEtapaEstadualMpePorFiltros");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            //--------FILTROS DE TELA----------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objRelFiltroRanking.Turma);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Estado));

            //-------TipoEtapa-----------------------------------------------------
            db.AddInParameter(dbCommand, "@INSCRITAS_ADMINISTRATIVO", DbType.Int32, EnumType.TipoEtapaMpe.InscriçãoCandidaturaAdministrativo);
            db.AddInParameter(dbCommand, "@INSCRITAS_EMPRESA", DbType.Int32, EnumType.TipoEtapaMpe.InscriçãoCandidaturaEmpresa);
            db.AddInParameter(dbCommand, "@CANDIDATAS", DbType.Int32, EnumType.TipoEtapaMpe.ClassificaçãoEstadual);
            db.AddInParameter(dbCommand, "@CLASSIFICADAS", DbType.Int32, EnumType.TipoEtapaMpe.AvaliacaoEstadual);
            db.AddInParameter(dbCommand, "@FINALISTAS", DbType.Int32, EnumType.TipoEtapaMpe.JulgamentoFinalistasEstaduais);
            db.AddInParameter(dbCommand, "@VENCEDORAS", DbType.Int32, EnumType.TipoEtapaMpe.ClassificacaoNacional);

            //-------Questionario-----------------------------------------------------
            db.AddInParameter(dbCommand, "@QUESTIONARIO_GESTAO", DbType.Int32, EnumType.Questionario.Gestao);
            db.AddInParameter(dbCommand, "@QUESTIONARIO_RESPSOCIAL", DbType.Int32, EnumType.Questionario.ResponsabilidadeSocial);
            db.AddInParameter(dbCommand, "@QUESTIOARIO_INOVACAO", DbType.Int32, EnumType.Questionario.Inovacao);

            //--------FILTROS DE TELA----------------------------------------------
            db.AddInParameter(dbCommand, "@sRAZAO_SOCIAL", DbType.String, objRelFiltroRanking.RazaoSocial);
            db.AddInParameter(dbCommand, "@sNOME_FANTASIA", DbType.String, objRelFiltroRanking.NomeFantasia);
            db.AddInParameter(dbCommand, "@CEA_CATEGORIA", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Categoria));
            db.AddInParameter(dbCommand, "@CEA_NIVEL_ESCOLARIDADE", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.EscolaridadeRepresentante));
            db.AddInParameter(dbCommand, "@CEA_FAIXA_ETARIA", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.FaixaEtariaRepresentante));
            db.AddInParameter(dbCommand, "@CEA_CIDADE", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Municipio));
            db.AddInParameter(dbCommand, "@CEA_ESCRITORIO_REGIONAL", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.EscritorioRegional));
            db.AddInParameter(dbCommand, "@CEA_GRUPO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Grupo));
            db.AddInParameter(dbCommand, "@CEA_FATURAMENTO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.FaixaFaturamento));
            db.AddInParameter(dbCommand, "@PROTOCOLO", DbType.String, objRelFiltroRanking.Protocolo);
            db.AddInParameter(dbCommand, "@CPF_CNPJ", DbType.String, objRelFiltroRanking.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@CEA_ESTADO_REGIAO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.EstadoRegiao));
            db.AddInParameter(dbCommand, "@TX_SEXO_CONTATO", DbType.String, StringUtils.ToObject(objRelFiltroRanking.SexoRepresentante));
            db.AddInParameter(dbCommand, "@DATAINICIO", DbType.DateTime, DateUtils.ToObject(objRelFiltroRanking.Inicio));
            db.AddInParameter(dbCommand, "@DATAFIM", DbType.DateTime, DateUtils.ToObject(objRelFiltroRanking.Fim));
            db.AddInParameter(dbCommand, "@NU_FUNCIONARIOS", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.NumeroFuncionarios));
            db.AddInParameter(dbCommand, "@TIPO_EMPRESA", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.TipoEmpresa));

            db.AddInParameter(dbCommand, "@FL_QUESTIONARIO_INOVACAO", DbType.Boolean, objRelFiltroRanking.PremioEspecial);
            db.AddInParameter(dbCommand, "@FL_QUESTIONARIO_RESP_SOCIAL", DbType.Boolean, objRelFiltroRanking.PremioEspecial);

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {

                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord DataRecord in dtrDados)
                    {
                        RelParticipantesPorEtapa objRelatorio = new RelParticipantesPorEtapa();
                        objRelatorio.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CDA_ESTADO"]);
                        objRelatorio.Estado.Estado = ObjectUtils.ToString(dtrDados["TX_ESTADO"]);
                        objRelatorio.TotalInscritas = ObjectUtils.ToInt(dtrDados["TotalInscritas"]);
                        objRelatorio.TotalCandidatas = ObjectUtils.ToInt(dtrDados["TotalCandidatas"]);
                        objRelatorio.TotalClassificadas = ObjectUtils.ToInt(dtrDados["TotalClassificadas"]);
                        objRelatorio.TotalFinalistasGestao = ObjectUtils.ToInt(dtrDados["TotalFinalistasGestao"]);
                        objRelatorio.TotalFinalistasRespSocial = ObjectUtils.ToInt(dtrDados["TotalFinalistasRespSocial"]);
                        objRelatorio.TotalFinalistasInovacao = ObjectUtils.ToInt(dtrDados["TotalFinalistasInovacao"]);
                        objRelatorio.TotalVencedoraGestao = ObjectUtils.ToInt(dtrDados["TotalVencedoraGestao"]);
                        objRelatorio.TotalVencedoraRespSocial = ObjectUtils.ToInt(dtrDados["TotalVencedoraRespSocial"]);
                        objRelatorio.TotalVencedoraInovacao = ObjectUtils.ToInt(dtrDados["TotalVencedoraInovacao"]);


                        lstRetorno.Add(objRelatorio);
                    }

                    return lstRetorno;
                }
                else
                {
                    return new List<RelParticipantesPorEtapa>();
                }

            }
        }

        /// <summary>
        /// Retorna um Relatorio de Ranking Candidata Estadual
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCargo">Lista de RelRankingCandidata</list></returns>
        public List<RelRelatorioQuestoesEspeciais> ObterRelatorioQuestoesEspeciais(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            List<RelRelatorioQuestoesEspeciais> lstRetorno = new List<RelRelatorioQuestoesEspeciais>();

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaRelatorioQuestoesEspeciaisPorFiltro");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_MPE)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaMpe);
            }
            else if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_FGA)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaFga);
            }
            else if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_PEG)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaPeg);
            }

            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objRelFiltroRanking.Turma);
            db.AddInParameter(dbCommand, "@FL_AVALIADOR", DbType.Boolean, false);
            //----------CRITERIOS GESTÃO-------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_CLIENTE", DbType.Int32, (int)EnumType.CriteriosGestao.Cliente);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_SOCIEDADE", DbType.Int32, (int)EnumType.CriteriosGestao.Sociedade);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_LIDERANCA", DbType.Int32, (int)EnumType.CriteriosGestao.Lideranca);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_ESTRATEGIA_PLANO", DbType.Int32, (int)EnumType.CriteriosGestao.EstrategiaPlano);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PESSOAS", DbType.Int32, (int)EnumType.CriteriosGestao.Pessoas);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PROCESSOS", DbType.Int32, (int)EnumType.CriteriosGestao.Processos);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_INFORMACAO_CONHECIMENTO", DbType.Int32, (int)EnumType.CriteriosGestao.InformacaoConhecimento);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_CONTROLE", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoControle);
            //----------PERGUNTAS-------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_PERGUNTA_9", DbType.Int32, 180);
            db.AddInParameter(dbCommand, "@CEA_PERGUNTA_10", DbType.Int32, 181);
            db.AddInParameter(dbCommand, "@CEA_PERGUNTA_11", DbType.Int32, 182);
            db.AddInParameter(dbCommand, "@CEA_PERGUNTA_16", DbType.Int32, 187);
            db.AddInParameter(dbCommand, "@CEA_PERGUNTA_20", DbType.Int32, 191);
            db.AddInParameter(dbCommand, "@CEA_PERGUNTA_23", DbType.Int32, 194);
            db.AddInParameter(dbCommand, "@CEA_PERGUNTA_31", DbType.Int32, 202);
            //-------QUESTIONARIOS-------------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO", DbType.Int32, EntQuestionario.QUESTIONARIO_GESTAO_2011);
            //--------FILTROS DE TELA----------------------------------------------
            db.AddInParameter(dbCommand, "@sRAZAO_SOCIAL", DbType.String, objRelFiltroRanking.RazaoSocial);
            db.AddInParameter(dbCommand, "@sNOME_FANTASIA", DbType.String, objRelFiltroRanking.NomeFantasia);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Estado));
            db.AddInParameter(dbCommand, "@CEA_CATEGORIA", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Categoria));
            db.AddInParameter(dbCommand, "@CEA_NIVEL_ESCOLARIDADE", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.EscolaridadeRepresentante));
            db.AddInParameter(dbCommand, "@CEA_FAIXA_ETARIA", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.FaixaEtariaRepresentante));
            db.AddInParameter(dbCommand, "@CEA_CIDADE", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Municipio));
            db.AddInParameter(dbCommand, "@CEA_ESCRITORIO_REGIONAL", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.EscritorioRegional));
            db.AddInParameter(dbCommand, "@STATUS", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Status));
            db.AddInParameter(dbCommand, "@CEA_GRUPO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Grupo));
            db.AddInParameter(dbCommand, "@CEA_FATURAMENTO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.FaixaFaturamento));
            db.AddInParameter(dbCommand, "@PROTOCOLO", DbType.String, objRelFiltroRanking.Protocolo);
            db.AddInParameter(dbCommand, "@CPF_CNPJ", DbType.String, objRelFiltroRanking.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@CEA_ESTADO_REGIAO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.EstadoRegiao));
            db.AddInParameter(dbCommand, "@TX_SEXO_CONTATO", DbType.String, StringUtils.ToObject(objRelFiltroRanking.SexoRepresentante));
            db.AddInParameter(dbCommand, "@DATAINICIO", DbType.DateTime, DateUtils.ToObject(objRelFiltroRanking.Inicio));
            db.AddInParameter(dbCommand, "@DATAFIM", DbType.DateTime, DateUtils.ToObject(objRelFiltroRanking.Fim));
            db.AddInParameter(dbCommand, "@NU_FUNCIONARIOS", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.NumeroFuncionarios));
            db.AddInParameter(dbCommand, "@TIPO_EMPRESA", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.TipoEmpresa));


            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord DataRecord in dtrDados)
                    {
                        RelRelatorioQuestoesEspeciais objRelatorio = new RelRelatorioQuestoesEspeciais();
                        objRelatorio.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                        objRelatorio.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                        objRelatorio.Protocolo = ObjectUtils.ToString(dtrDados["TX_PROTOCOLO"]);
                        objRelatorio.CpfCnpj = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                        objRelatorio.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL"]);
                        objRelatorio.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                        objRelatorio.IdEtapa = ObjectUtils.ToInt(dtrDados["CDA_ETAPA"]);
                        objRelatorio.PontuacaoTotal = ObjectUtils.ToDouble(dtrDados["PontuacaoTotal"]);
                        objRelatorio.CriterioCliente = ObjectUtils.ToDouble(dtrDados["CriterioCliente"]);
                        objRelatorio.CriterioSociedade = ObjectUtils.ToDouble(dtrDados["CriterioSociedade"]);
                        objRelatorio.CriterioLideranca = ObjectUtils.ToDouble(dtrDados["CriterioLideranca"]);
                        objRelatorio.CriterioEstrategiaPlanos = ObjectUtils.ToDouble(dtrDados["CriterioEstrategiaPlanos"]);
                        objRelatorio.CriterioPessoas = ObjectUtils.ToDouble(dtrDados["CriterioPessoas"]);
                        objRelatorio.CriterioProcessos = ObjectUtils.ToDouble(dtrDados["CriterioProcessos"]);
                        objRelatorio.CriterioInformacoesConhecimento = ObjectUtils.ToDouble(dtrDados["CriterioInformacoesConhecimento"]);
                        objRelatorio.CriterioResultado = ObjectUtils.ToDouble(dtrDados["CriterioResultado"]);
                        objRelatorio.PontuacaoQuestoesEspeciais = ObjectUtils.ToDouble(dtrDados["PontuacaoQuestoesEspeciais"]);
                        objRelatorio.PontuacaoQuestao9 = ObjectUtils.ToDouble(dtrDados["PontuacaoQuestao9"]);
                        objRelatorio.RespostaQuestao9 = ObjectUtils.ToInt(dtrDados["RespostaQuestao9"]);
                        objRelatorio.PontuacaoQuestao10 = ObjectUtils.ToDouble(dtrDados["PontuacaoQuestao10"]);
                        objRelatorio.RespostaQuestao10 = ObjectUtils.ToInt(dtrDados["RespostaQuestao10"]);
                        objRelatorio.PontuacaoQuestao11 = ObjectUtils.ToDouble(dtrDados["PontuacaoQuestao11"]);
                        objRelatorio.RespostaQuestao11 = ObjectUtils.ToInt(dtrDados["RespostaQuestao11"]);
                        objRelatorio.PontuacaoQuestao16 = ObjectUtils.ToDouble(dtrDados["PontuacaoQuestao16"]);
                        objRelatorio.RespostaQuestao16 = ObjectUtils.ToInt(dtrDados["RespostaQuestao16"]);
                        objRelatorio.PontuacaoQuestao20 = ObjectUtils.ToDouble(dtrDados["PontuacaoQuestao20"]);
                        objRelatorio.RespostaQuestao20 = ObjectUtils.ToInt(dtrDados["RespostaQuestao20"]);
                        objRelatorio.PontuacaoQuestao23 = ObjectUtils.ToDouble(dtrDados["PontuacaoQuestao23"]);
                        objRelatorio.RespostaQuestao23 = ObjectUtils.ToInt(dtrDados["RespostaQuestao23"]);
                        objRelatorio.PontuacaoQuestao31 = ObjectUtils.ToDouble(dtrDados["PontuacaoQuestao31"]);
                        objRelatorio.RespostaQuestao31 = ObjectUtils.ToInt(dtrDados["RespostaQuestao31"]);

                        lstRetorno.Add(objRelatorio);
                    }

                    return lstRetorno;
                }
                else
                {
                    return new List<RelRelatorioQuestoesEspeciais>();
                }
            }
        }

        /// <summary>
        /// Retorna o numero de participantes do MPE por Categoria e Etapa
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="RelParticipantesPorEtapa">Lista de RelParticipantesPorEtapa</list></returns>
        public List<RelParticipantesPorEtapa> ObterParticipantesPorEtapaPorCategoria(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            List<RelParticipantesPorEtapa> lstRetorno = new List<RelParticipantesPorEtapa>();

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaNumeroParticipantesPorEtapaEstadualCategoriaMpePorFiltros");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            //--------FILTROS DE TELA----------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objRelFiltroRanking.Turma);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Estado));

            //-------TipoEtapa-----------------------------------------------------
            db.AddInParameter(dbCommand, "@INSCRITAS_ADMINISTRATIVO", DbType.Int32, EnumType.TipoEtapaMpe.InscriçãoCandidaturaAdministrativo);
            db.AddInParameter(dbCommand, "@INSCRITAS_EMPRESA", DbType.Int32, EnumType.TipoEtapaMpe.InscriçãoCandidaturaEmpresa);
            db.AddInParameter(dbCommand, "@CANDIDATAS", DbType.Int32, EnumType.TipoEtapaMpe.ClassificaçãoEstadual);
            db.AddInParameter(dbCommand, "@CLASSIFICADAS", DbType.Int32, EnumType.TipoEtapaMpe.AvaliacaoEstadual);
            db.AddInParameter(dbCommand, "@FINALISTAS", DbType.Int32, EnumType.TipoEtapaMpe.JulgamentoFinalistasEstaduais);
            db.AddInParameter(dbCommand, "@VENCEDORAS", DbType.Int32, EnumType.TipoEtapaMpe.ClassificacaoNacional);

            //-------Questionario-----------------------------------------------------
            db.AddInParameter(dbCommand, "@QUESTIONARIO_GESTAO", DbType.Int32, EnumType.Questionario.Gestao);
            db.AddInParameter(dbCommand, "@QUESTIONARIO_RESPSOCIAL", DbType.Int32, EnumType.Questionario.ResponsabilidadeSocial);
            db.AddInParameter(dbCommand, "@QUESTIOARIO_INOVACAO", DbType.Int32, EnumType.Questionario.Inovacao);

            //--------FILTROS DE TELA----------------------------------------------
            db.AddInParameter(dbCommand, "@sRAZAO_SOCIAL", DbType.String, objRelFiltroRanking.RazaoSocial);
            db.AddInParameter(dbCommand, "@sNOME_FANTASIA", DbType.String, objRelFiltroRanking.NomeFantasia);
            db.AddInParameter(dbCommand, "@CEA_CATEGORIA", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Categoria));
            db.AddInParameter(dbCommand, "@CEA_NIVEL_ESCOLARIDADE", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.EscolaridadeRepresentante));
            db.AddInParameter(dbCommand, "@CEA_FAIXA_ETARIA", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.FaixaEtariaRepresentante));
            db.AddInParameter(dbCommand, "@CEA_CIDADE", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Municipio));
            db.AddInParameter(dbCommand, "@CEA_ESCRITORIO_REGIONAL", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.EscritorioRegional));
            db.AddInParameter(dbCommand, "@CEA_GRUPO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Grupo));
            db.AddInParameter(dbCommand, "@CEA_FATURAMENTO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.FaixaFaturamento));
            db.AddInParameter(dbCommand, "@PROTOCOLO", DbType.String, objRelFiltroRanking.Protocolo);
            db.AddInParameter(dbCommand, "@CPF_CNPJ", DbType.String, objRelFiltroRanking.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@CEA_ESTADO_REGIAO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.EstadoRegiao));
            db.AddInParameter(dbCommand, "@TX_SEXO_CONTATO", DbType.String, StringUtils.ToObject(objRelFiltroRanking.SexoRepresentante));
            db.AddInParameter(dbCommand, "@DATAINICIO", DbType.DateTime, DateUtils.ToObject(objRelFiltroRanking.Inicio));
            db.AddInParameter(dbCommand, "@DATAFIM", DbType.DateTime, DateUtils.ToObject(objRelFiltroRanking.Fim));
            db.AddInParameter(dbCommand, "@NU_FUNCIONARIOS", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.NumeroFuncionarios));
            db.AddInParameter(dbCommand, "@TIPO_EMPRESA", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.TipoEmpresa));

            db.AddInParameter(dbCommand, "@FL_QUESTIONARIO_INOVACAO", DbType.Boolean, objRelFiltroRanking.PremioEspecial);
            db.AddInParameter(dbCommand, "@FL_QUESTIONARIO_RESP_SOCIAL", DbType.Boolean, objRelFiltroRanking.PremioEspecial);

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {

                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord DataRecord in dtrDados)
                    {
                        RelParticipantesPorEtapa objRelatorio = new RelParticipantesPorEtapa();
                        objRelatorio.Categoria.IdCategoria = ObjectUtils.ToInt(dtrDados["CDA_CATEGORIA"]);
                        objRelatorio.Categoria.Categoria = ObjectUtils.ToString(dtrDados["TX_CATEGORIA"]);
                        objRelatorio.TotalInscritas = ObjectUtils.ToInt(dtrDados["TotalInscritas"]);
                        objRelatorio.TotalCandidatas = ObjectUtils.ToInt(dtrDados["TotalCandidatas"]);
                        objRelatorio.TotalClassificadas = ObjectUtils.ToInt(dtrDados["TotalClassificadas"]);
                        objRelatorio.TotalFinalistasGestao = ObjectUtils.ToInt(dtrDados["TotalFinalistasGestao"]);
                        objRelatorio.TotalFinalistasRespSocial = ObjectUtils.ToInt(dtrDados["TotalFinalistasRespSocial"]);
                        objRelatorio.TotalFinalistasInovacao = ObjectUtils.ToInt(dtrDados["TotalFinalistasInovacao"]);
                        objRelatorio.TotalVencedoraGestao = ObjectUtils.ToInt(dtrDados["TotalVencedoraGestao"]);
                        objRelatorio.TotalVencedoraRespSocial = ObjectUtils.ToInt(dtrDados["TotalVencedoraRespSocial"]);
                        objRelatorio.TotalVencedoraInovacao = ObjectUtils.ToInt(dtrDados["TotalVencedoraInovacao"]);


                        lstRetorno.Add(objRelatorio);
                    }

                    return lstRetorno;
                }
                else
                {
                    return new List<RelParticipantesPorEtapa>();
                }

            }
        }
    }
}
