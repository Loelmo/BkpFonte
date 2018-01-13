
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.Ent;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using Vinit.SG.Common;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa um Relatorio Ranking
    /// </summary>
    public class DalRelatorioRanking
    {
        /// <summary>
        /// Retorna um Relatorio de Ranking Finalista
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCargo">Lista de RelRankingFinalista</list></returns>
        public List<RelRankingFinalista> ObterRankingFinalistaPorFiltro(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaRankingFinalistaPorFiltro");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, objRelFiltroRanking.TipoEtapaMpe);
            if (objRelFiltroRanking.TipoEtapaMpe == EnumType.TipoEtapaMpe.JulgamentoFinalistasEstaduais)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, EnumType.TipoEtapaMpe.ClassificacaoNacional);
            }
            else if (objRelFiltroRanking.TipoEtapaMpe == EnumType.TipoEtapaMpe.JulgamentoFinalistasNacionais)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, EnumType.TipoEtapaMpe.EncerramentoNacional);
            }
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objRelFiltroRanking.Turma);
            //----------CRITERIOS GESTÃO-------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_CLIENTE", DbType.Int32, (int)EnumType.CriteriosGestao.Cliente);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_SOCIEDADE", DbType.Int32, (int)EnumType.CriteriosGestao.Sociedade);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_LIDERANCA", DbType.Int32, (int)EnumType.CriteriosGestao.Lideranca);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_ESTRATEGIA_PLANO", DbType.Int32, (int)EnumType.CriteriosGestao.EstrategiaPlano);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PESSOAS", DbType.Int32, (int)EnumType.CriteriosGestao.Pessoas);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PROCESSOS", DbType.Int32, (int)EnumType.CriteriosGestao.Processos);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_INFORMACAO_CONHECIMENTO", DbType.Int32, (int)EnumType.CriteriosGestao.InformacaoConhecimento);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_CONTROLE", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoControle);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_TENDENCIA", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoTendencia);
            //---------------------------------------------------------------------
            //-------QUESTIONARIOS-------------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO", DbType.Int32, (int)objRelFiltroRanking.Questionario);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_GESTAO", DbType.Int32, (int)EnumType.Questionario.Gestao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_INOVACAO", DbType.Int32, (int)EnumType.Questionario.Inovacao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_EMPREENDEDORISMO", DbType.Int32, (int)EnumType.Questionario.Empreendedorismo);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL", DbType.Int32, (int)EnumType.Questionario.ResponsabilidadeSocial);
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
            //-------------------------------------------------------------------
            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularRankingFinalista(dtrDados);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Popula Relatorio Ranking Finalista, conforme DataReader passado
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntCargo">Lista de RelRankingFinalista</list></returns>
        private List<RelRankingFinalista> PopularRankingFinalista(DbDataReader dtrDados)
        {
            List<RelRankingFinalista> listEntReturn = new List<RelRankingFinalista>();
            RelRankingFinalista entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new RelRankingFinalista();

                    entReturn.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                    entReturn.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                    entReturn.CpfCnpj = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                    entReturn.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL"]);
                    entReturn.PontuacaoTotalPosVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPosVisita"]);
                    entReturn.EnfoquePosVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePosVisita"]);
                    entReturn.ResultadoControlePosVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePosVisita"]);
                    entReturn.ResultadoTendenciaPosVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPosVisita"]);
                    entReturn.TotalEmpreendendorismoPosVisita = ObjectUtils.ToDouble(dtrDados["TotalEmpreendedorismoPosVisita"]);
                    //entReturn.RelacaoMelhorCategoriaPosVisita = ObjectUtils.ToDouble(dtrDados["RelacaoComMelhorDaCategoriaPosVisita"]);
                    entReturn.PontuacaoRankingPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoRankingPreVisita"]);
                    entReturn.EnfoquePreVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePreVisita"]);
                    entReturn.ResultadoControlePreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePreVisita"]);
                    entReturn.ResultadoTendenciaPreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPreVisita"]);
                    entReturn.PontuacaoTotalPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPreVisita"]);
                    //entReturn.RelacaoMelhorCategoriaPreVisita = ObjectUtils.ToDouble(dtrDados["RelacaoComMelhorDaCategoriaPreVisita"]);
                    entReturn.Vencedor = ObjectUtils.ToBoolean(dtrDados["Vencedor"]);
                    entReturn.PontuacaoTotalResponsabilidadeSocial = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalResponsabilidadeSocial"]);
                    entReturn.PontuacaoTotalInovacao = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalInovacao"]);
                    entReturn.MaiorNotaPreVisita = ObjectUtils.ToDouble(dtrDados["MaiorNotaPreVisita"]);
                    entReturn.MaiorNotaPosVisita = ObjectUtils.ToDouble(dtrDados["MaiorNotaPosVisita"]);

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
        /// Retorna um Relatorio de Ranking Candidata Estadual
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCargo">Lista de RelRankingCandidata</list></returns>
        public List<RelRankingCandidataEstadual> ObterRankingCandidataPorFiltro(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaRankingCandidataPorFiltro");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            if(objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_MPE){
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaMpe);
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaMpe.AvaliacaoEstadual);
            }
            else if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_FGA)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaFga);
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaFga.VisitaPreviaPreClassificadas);
            }
            else if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_PEG)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaPeg);
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaPeg.VisitaPreviaPreClassificadas);
            }

            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objRelFiltroRanking.Turma);
            //----------CRITERIOS GESTÃO-------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_CLIENTE", DbType.Int32, (int)EnumType.CriteriosGestao.Cliente);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_SOCIEDADE", DbType.Int32, (int)EnumType.CriteriosGestao.Sociedade);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_LIDERANCA", DbType.Int32, (int)EnumType.CriteriosGestao.Lideranca);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_ESTRATEGIA_PLANO", DbType.Int32, (int)EnumType.CriteriosGestao.EstrategiaPlano);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PESSOAS", DbType.Int32, (int)EnumType.CriteriosGestao.Pessoas);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PROCESSOS", DbType.Int32, (int)EnumType.CriteriosGestao.Processos);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_INFORMACAO_CONHECIMENTO", DbType.Int32, (int)EnumType.CriteriosGestao.InformacaoConhecimento);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_CONTROLE", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoControle);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_TENDENCIA", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoTendencia);
            //---------------------------------------------------------------------
            //-------QUESTIONARIOS-------------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_GESTAO", DbType.Int32, (int)EnumType.Questionario.Gestao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_INOVACAO", DbType.Int32, (int)EnumType.Questionario.Inovacao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_EMPREENDEDORISMO", DbType.Int32, (int)EnumType.Questionario.Empreendedorismo);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL", DbType.Int32, (int)EnumType.Questionario.ResponsabilidadeSocial);
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
                    return this.PopularRankingCandidataEstadual(dtrDados);
                }
                else
                {
                    return new List<RelRankingCandidataEstadual>();
                }
            }
        }

        /// <summary>
        /// Popula Relatorio Ranking Finalista, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntCargo">Lista de RelRankingFinalista</list></returns>
        private List<RelRankingCandidataEstadual> PopularRankingCandidataEstadual(DbDataReader dtrDados)
        {
            List<RelRankingCandidataEstadual> listEntReturn = new List<RelRankingCandidataEstadual>();
            RelRankingCandidataEstadual entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new RelRankingCandidataEstadual();

                    entReturn.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                    entReturn.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                    entReturn.CpfCnpj = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                    entReturn.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.NumeroFuncionarios = ObjectUtils.ToInt(dtrDados["NU_FUNCIONARIO"]);
                    entReturn.DataAbertura = ObjectUtils.ToDate(dtrDados["DT_ABERTURA_EMPRESA"]);
                    entReturn.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL"]);
                    entReturn.IdAvaliadorSenior = ObjectUtils.ToInt(dtrDados["CEA_USUARIO_AVALIADOR_SENIOR"]);
                    entReturn.IdAvaliadorAcompanhante = ObjectUtils.ToInt(dtrDados["CEA_USUARIO_AVALIADOR_ACOMPANHANTE"]);
                    entReturn.NomeAvaliadorSenior = ObjectUtils.ToString(dtrDados["NOME_USUARIO_AVALIADOR_SENIOR"]);
                    entReturn.NomeAvaliadorAcompanhante = ObjectUtils.ToString(dtrDados["NOME_USUARIO_AVALIADOR_ACOMPANHANTE"]);
                    entReturn.EnfoquePreVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePreVisita"]);
                    entReturn.ResultadoControlePreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePreVisita"]);
                    entReturn.ResultadoTendenciaPreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPreVisita"]);
                    entReturn.PontuacaoTotalPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPreVisita"]);
                    entReturn.Classificar = ObjectUtils.ToBoolean(dtrDados["FL_PASSA_PROXIMA_ETAPA"]);
                    entReturn.Protocolo = ObjectUtils.ToString(dtrDados["TX_PROTOCOLO"]);
                    entReturn.EtapaAtiva = ObjectUtils.ToBoolean(dtrDados["FL_ETAPA_ATIVA"]);
                    entReturn.JaAvaliada = ObjectUtils.ToBoolean(dtrDados["JaAvaliado"]);
                    entReturn.Excluido = ObjectUtils.ToBoolean(dtrDados["FL_EXCLUIDO"]);
                    entReturn.IdEtapa = ObjectUtils.ToInt(dtrDados["CDA_ETAPA"]);
                    entReturn.IdFaturamento = ObjectUtils.ToInt(dtrDados["CDA_FATURAMENTO"]);
                    entReturn.PossuiResponsabilidadeSocial = ObjectUtils.ToBoolean(dtrDados["PossuiResponsabilidadeSocial"]);
                    entReturn.MarcaQuestoesEspeciais = ObjectUtils.ToBoolean(dtrDados["FL_MARCA_QUESTOES_ESPECIAIS_FGA"]);
                    entReturn.TotalResponsabilidadeSocial = ObjectUtils.ToDouble(dtrDados["TotalResponsabilidadeSocial"]);
                    entReturn.PossuiInovacao = ObjectUtils.ToBoolean(dtrDados["PossuiInovacao"]);
                    entReturn.PontuacaoInovacao = ObjectUtils.ToDouble(dtrDados["PontuacaoInovacao"]);

                    entReturn.PontuacaoTotalResponsabilidadeSocial = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalResponsabilidadeSocial"]);
                    entReturn.PontuacaoTotalInovacao = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalInovacao"]);

                    entReturn.CriterioClientePreVisita = ObjectUtils.ToDouble(dtrDados["CriterioClientePreVisita"]);
                    entReturn.CriterioSociedadePreVisita = ObjectUtils.ToDouble(dtrDados["CriterioSociedadePreVisita"]);
                    entReturn.CriterioLiderancaPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioLiderancaPreVisita"]);
                    entReturn.CriterioEstrategiaPlanosPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioEstrategiaPlanosPreVisita"]);
                    entReturn.CriterioPessoasPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioPessoasPreVisita"]);
                    entReturn.CriterioProcessosPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioProcessosPreVisita"]);
                    entReturn.CriterioInformacoesConhecimentoPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioInformacoesConhecimentoPreVisita"]);
                    entReturn.MaiorNotaPreVisita = ObjectUtils.ToDouble(dtrDados["MaiorNotaPreVisita"]);

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
        /// Retorna um Relatorio de Ranking Candidata Estadual
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCargo">Lista de RelRankingCandidata</list></returns>
        public List<RelRankingCandidataNacional> ObterRankingCandidataNacionalPorFiltro(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaRankingCandidataNacionalPorFiltro");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_MPE)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaMpe);
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaMpe.AvaliacaoEstadual);
            }
            else if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_FGA)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaFga);
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaFga.VisitaPreviaPreClassificadas);
            }
            else if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_PEG)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaPeg);
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaPeg.VisitaPreviaPreClassificadas);
            }

            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objRelFiltroRanking.Turma);
            //----------CRITERIOS GESTÃO-------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_CLIENTE", DbType.Int32, (int)EnumType.CriteriosGestao.Cliente);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_SOCIEDADE", DbType.Int32, (int)EnumType.CriteriosGestao.Sociedade);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_LIDERANCA", DbType.Int32, (int)EnumType.CriteriosGestao.Lideranca);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_ESTRATEGIA_PLANO", DbType.Int32, (int)EnumType.CriteriosGestao.EstrategiaPlano);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PESSOAS", DbType.Int32, (int)EnumType.CriteriosGestao.Pessoas);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PROCESSOS", DbType.Int32, (int)EnumType.CriteriosGestao.Processos);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_INFORMACAO_CONHECIMENTO", DbType.Int32, (int)EnumType.CriteriosGestao.InformacaoConhecimento);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_CONTROLE", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoControle);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_TENDENCIA", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoTendencia);
            //---------------------------------------------------------------------
            //-------QUESTIONARIOS-------------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO", DbType.Int32, objRelFiltroRanking.Questionario);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_GESTAO", DbType.Int32, (int)EnumType.Questionario.Gestao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_INOVACAO", DbType.Int32, (int)EnumType.Questionario.Inovacao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_EMPREENDEDORISMO", DbType.Int32, (int)EnumType.Questionario.Empreendedorismo);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL", DbType.Int32, (int)EnumType.Questionario.ResponsabilidadeSocial);
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
                    return this.PopularRankingCandidataNacional(dtrDados);
                }
                else
                {
                    return new List<RelRankingCandidataNacional>();
                }
            }
        }

        /// <summary>
        /// Popula Relatorio Ranking Finalista, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntCargo">Lista de RelRankingFinalista</list></returns>
        private List<RelRankingCandidataNacional> PopularRankingCandidataNacional(DbDataReader dtrDados)
        {
            List<RelRankingCandidataNacional> listEntReturn = new List<RelRankingCandidataNacional>();
            RelRankingCandidataNacional entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new RelRankingCandidataNacional();

                    entReturn.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                    entReturn.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                    entReturn.IdQuestionario = ObjectUtils.ToInt(dtrDados["CEA_QUESTIONARIO"]);
                    entReturn.CpfCnpj = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                    entReturn.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL"]);
                    entReturn.IdAvaliadorSenior = ObjectUtils.ToInt(dtrDados["CEA_USUARIO_AVALIADOR_SENIOR"]);
                    entReturn.IdAvaliadorAcompanhante = ObjectUtils.ToInt(dtrDados["CEA_USUARIO_AVALIADOR_ACOMPANHANTE"]);
                    entReturn.NomeAvaliadorSenior = ObjectUtils.ToString(dtrDados["NOME_USUARIO_AVALIADOR_SENIOR"]);
                    entReturn.NomeAvaliadorAcompanhante = ObjectUtils.ToString(dtrDados["NOME_USUARIO_AVALIADOR_ACOMPANHANTE"]);
                    entReturn.EnfoquePreVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePreVisita"]);
                    entReturn.ResultadoControlePreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePreVisita"]);
                    entReturn.ResultadoTendenciaPreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPreVisita"]);
                    entReturn.PontuacaoTotalPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPreVisita"]);
                    entReturn.Classificar = ObjectUtils.ToBoolean(dtrDados["FL_PASSA_PROXIMA_ETAPA"]);
                    entReturn.Protocolo = ObjectUtils.ToString(dtrDados["TX_PROTOCOLO"]);
                    entReturn.EtapaAtiva = ObjectUtils.ToBoolean(dtrDados["FL_ETAPA_ATIVA"]);
                    entReturn.Excluido = ObjectUtils.ToBoolean(dtrDados["FL_EXCLUIDO"]);
                    entReturn.IdEtapa = ObjectUtils.ToInt(dtrDados["CDA_ETAPA"]);
                    entReturn.PossuiResponsabilidadeSocial = ObjectUtils.ToBoolean(dtrDados["PossuiResponsabilidadeSocial"]);
                    entReturn.TotalResponsabilidadeSocial = ObjectUtils.ToDouble(dtrDados["TotalResponsabilidadeSocial"]);
                    entReturn.PossuiInovacao = ObjectUtils.ToBoolean(dtrDados["PossuiInovacao"]);
                    entReturn.PontuacaoInovacao = ObjectUtils.ToDouble(dtrDados["PontuacaoInovacao"]);

                    entReturn.PontuacaoTotalResponsabilidadeSocial = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalResponsabilidadeSocial"]);
                    entReturn.PontuacaoTotalInovacao = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalInovacao"]);

                    entReturn.CriterioClientePreVisita = ObjectUtils.ToDouble(dtrDados["CriterioClientePreVisita"]);
                    entReturn.CriterioSociedadePreVisita = ObjectUtils.ToDouble(dtrDados["CriterioSociedadePreVisita"]);
                    entReturn.CriterioLiderancaPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioLiderancaPreVisita"]);
                    entReturn.CriterioEstrategiaPlanosPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioEstrategiaPlanosPreVisita"]);
                    entReturn.CriterioPessoasPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioPessoasPreVisita"]);
                    entReturn.CriterioProcessosPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioProcessosPreVisita"]);
                    entReturn.CriterioInformacoesConhecimentoPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioInformacoesConhecimentoPreVisita"]);
                    entReturn.MaiorNotaPreVisita = ObjectUtils.ToDouble(dtrDados["MaiorNotaPreVisita"]);

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
        /// Popula Relatorio Ranking Finalista, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntCargo">Lista de RelRankingFinalista</list></returns>
        private List<RelAvaliacao> PopularAvaliacao(DbDataReader dtrDados)
        {
            List<RelAvaliacao> listEntReturn = new List<RelAvaliacao>();
            RelAvaliacao entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new RelAvaliacao();

                    entReturn.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                    entReturn.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                    entReturn.CpfCnpj = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                    entReturn.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL"]);
                    entReturn.Protocolo = ObjectUtils.ToString(dtrDados["TX_PROTOCOLO"]);
                    entReturn.DtAlteracao = ObjectUtils.ToDate(dtrDados["DT_ALTERACAO"]);
                    entReturn.Estado = ObjectUtils.ToString(dtrDados["TX_SIGLA"]);
                    entReturn.MotivoDevolucao = ObjectUtils.ToString(dtrDados["TX_MOTIVO_DEVOLUCAO"]);
                    entReturn.IdEtapa = ObjectUtils.ToInt(dtrDados["CEA_ETAPA"]);
                    entReturn.Avaliado = ObjectUtils.ToBoolean(dtrDados["FL_AVALIADO"]);
                    entReturn.Devolvido = ObjectUtils.ToBoolean(dtrDados["Devolvido"]);

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
        /// Retorna um entidade de Ranking
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntRanking">Lista de EntRanking</list></returns>
        public List<RelRankingClassificada> ObterRankingClassificadaPorFiltro(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaRankingClassificadaPorFiltro");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_MPE)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaMpe);
                if (objRelFiltroRanking.TipoEtapaMpe == EnumType.TipoEtapaMpe.AvaliacaoEstadual)
                {
                    db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaMpe.JulgamentoFinalistasEstaduais);
                }
                else if (objRelFiltroRanking.TipoEtapaMpe == EnumType.TipoEtapaMpe.AvaliacaoNacional)
                {
                    db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaMpe.JulgamentoFinalistasNacionais);
                }
            }
            else if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_FGA)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaFga);
                if (objRelFiltroRanking.TipoEtapaFga == EnumType.TipoEtapaFga.VisitaPreviaPreClassificadas)
                {
                    db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaFga.NovoCicloFase4);
                }
                else if (objRelFiltroRanking.TipoEtapaFga == EnumType.TipoEtapaFga.NovoCicloFase4)
                {
                    db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaFga.Encerramento);
                }
            }
            else if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_PEG)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaPeg);
                if (objRelFiltroRanking.TipoEtapaPeg == EnumType.TipoEtapaPeg.VisitaPreviaPreClassificadas)
                {
                    db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaPeg.NovoCicloFase4);
                }
                else if (objRelFiltroRanking.TipoEtapaPeg == EnumType.TipoEtapaPeg.NovoCicloFase4)
                {
                    db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaPeg.Encerramento);
                }
            }
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objRelFiltroRanking.Turma);
            //----------CRITERIOS GESTÃO-------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_CLIENTE", DbType.Int32, (int)EnumType.CriteriosGestao.Cliente);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_SOCIEDADE", DbType.Int32, (int)EnumType.CriteriosGestao.Sociedade);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_LIDERANCA", DbType.Int32, (int)EnumType.CriteriosGestao.Lideranca);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_ESTRATEGIA_PLANO", DbType.Int32, (int)EnumType.CriteriosGestao.EstrategiaPlano);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PESSOAS", DbType.Int32, (int)EnumType.CriteriosGestao.Pessoas);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PROCESSOS", DbType.Int32, (int)EnumType.CriteriosGestao.Processos);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_INFORMACAO_CONHECIMENTO", DbType.Int32, (int)EnumType.CriteriosGestao.InformacaoConhecimento);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_CONTROLE", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoControle);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_TENDENCIA", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoTendencia);
            //---------------------------------------------------------------------
            //-------QUESTIONARIOS-------------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_GESTAO", DbType.Int32, (int)EnumType.Questionario.Gestao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_INOVACAO", DbType.Int32, (int)EnumType.Questionario.Inovacao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_EMPREENDEDORISMO", DbType.Int32, (int)EnumType.Questionario.Empreendedorismo);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL", DbType.Int32, (int)EnumType.Questionario.ResponsabilidadeSocial);
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
                    return this.PopularRankingClassificada(dtrDados);
                }
                else
                {
                    return new List<RelRankingClassificada>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Ranking
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntRanking">Lista de EntRanking</list></returns>
        public List<EntComparacaoResultados> ComparacaoResultadosFase1Fase4PreVista(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_ComparacaoResultadosFase1Fase4PreVista");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_MPE)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA1", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaMpe);
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA4", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaMpe);
                if (objRelFiltroRanking.TipoEtapaMpe == EnumType.TipoEtapaMpe.AvaliacaoEstadual)
                {
                    db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaMpe.JulgamentoFinalistasEstaduais);
                }
                else if (objRelFiltroRanking.TipoEtapaMpe == EnumType.TipoEtapaMpe.AvaliacaoNacional)
                {
                    db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaMpe.JulgamentoFinalistasNacionais);
                }
            }
            else if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_FGA)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA1", DbType.Int32, (int)EnumType.TipoEtapaFga.VisitaPreviaPreClassificadas);
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA4", DbType.Int32, (int)EnumType.TipoEtapaFga.NovoCicloFase4);
                if (objRelFiltroRanking.TipoEtapaFga == EnumType.TipoEtapaFga.VisitaPreviaPreClassificadas)
                {
                    db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaFga.NovoCicloFase4);
                }
                else if (objRelFiltroRanking.TipoEtapaFga == EnumType.TipoEtapaFga.NovoCicloFase4)
                {
                    db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaFga.Encerramento);
                }
            }
            else if (objRelFiltroRanking.Programa == EntPrograma.PROGRAMA_PEG)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA1", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaPeg);
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA4", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaPeg);
                if (objRelFiltroRanking.TipoEtapaPeg == EnumType.TipoEtapaPeg.VisitaPreviaPreClassificadas)
                {
                    db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaPeg.NovoCicloFase4);
                }
                else if (objRelFiltroRanking.TipoEtapaPeg == EnumType.TipoEtapaPeg.NovoCicloFase4)
                {
                    db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaPeg.Encerramento);
                }
            }
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objRelFiltroRanking.Turma);
            //----------CRITERIOS GESTÃO-------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_CLIENTE", DbType.Int32, (int)EnumType.CriteriosGestao.Cliente);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_SOCIEDADE", DbType.Int32, (int)EnumType.CriteriosGestao.Sociedade);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_LIDERANCA", DbType.Int32, (int)EnumType.CriteriosGestao.Lideranca);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_ESTRATEGIA_PLANO", DbType.Int32, (int)EnumType.CriteriosGestao.EstrategiaPlano);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PESSOAS", DbType.Int32, (int)EnumType.CriteriosGestao.Pessoas);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PROCESSOS", DbType.Int32, (int)EnumType.CriteriosGestao.Processos);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_INFORMACAO_CONHECIMENTO", DbType.Int32, (int)EnumType.CriteriosGestao.InformacaoConhecimento);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_CONTROLE", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoControle);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_TENDENCIA", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoTendencia);
            //---------------------------------------------------------------------
            //-------QUESTIONARIOS-------------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_GESTAO", DbType.Int32, (int)EnumType.Questionario.Gestao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_INOVACAO", DbType.Int32, (int)EnumType.Questionario.Inovacao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_EMPREENDEDORISMO", DbType.Int32, (int)EnumType.Questionario.Empreendedorismo);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL", DbType.Int32, (int)EnumType.Questionario.ResponsabilidadeSocial);
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
                    return this.PopularComparacaoResultados(dtrDados);
                }
                else
                {
                    return new List<EntComparacaoResultados>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Ranking
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntRanking">Lista de EntRanking</list></returns>
        public List<RelRankingPegFase2> ObterRankingPegFase2PorFiltro(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaRankingFase2PorFiltro");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaPeg);
            if (objRelFiltroRanking.TipoEtapaPeg == EnumType.TipoEtapaPeg.PlanoEmpresarialFase2)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaPeg.GestãoDoResultadoFase3);
            }
            else if (objRelFiltroRanking.TipoEtapaPeg == EnumType.TipoEtapaPeg.GestãoDoResultadoFase3)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, (int)EnumType.TipoEtapaPeg.NovoCicloFase4);
            }
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objRelFiltroRanking.Turma);
            //----------CRITERIOS GESTÃO-------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_CLIENTE", DbType.Int32, (int)EnumType.CriteriosGestao.Cliente);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_SOCIEDADE", DbType.Int32, (int)EnumType.CriteriosGestao.Sociedade);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_LIDERANCA", DbType.Int32, (int)EnumType.CriteriosGestao.Lideranca);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_ESTRATEGIA_PLANO", DbType.Int32, (int)EnumType.CriteriosGestao.EstrategiaPlano);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PESSOAS", DbType.Int32, (int)EnumType.CriteriosGestao.Pessoas);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PROCESSOS", DbType.Int32, (int)EnumType.CriteriosGestao.Processos);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_INFORMACAO_CONHECIMENTO", DbType.Int32, (int)EnumType.CriteriosGestao.InformacaoConhecimento);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_CONTROLE", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoControle);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_TENDENCIA", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoTendencia);
            //---------------------------------------------------------------------
            //-------QUESTIONARIOS-------------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_GESTAO", DbType.Int32, (int)EnumType.Questionario.Gestao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_INOVACAO", DbType.Int32, (int)EnumType.Questionario.Inovacao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_EMPREENDEDORISMO", DbType.Int32, (int)EnumType.Questionario.Empreendedorismo);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL", DbType.Int32, (int)EnumType.Questionario.ResponsabilidadeSocial);
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
                    return this.PopularRankingPegFase2(dtrDados);
                }
                else
                {
                    return new List<RelRankingPegFase2>();
                }
            }
        }

        /// <summary>
        /// Popula Etapa, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntRanking">Lista de EntRanking</list></returns>
        private List<RelRankingClassificada> PopularRankingClassificada(DbDataReader dtrDados)
        {
            List<RelRankingClassificada> listEntReturn = new List<RelRankingClassificada>();
            RelRankingClassificada entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new RelRankingClassificada();

                    entReturn.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                    entReturn.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                    entReturn.IdEtapa = ObjectUtils.ToInt(dtrDados["CDA_ETAPA"]);
                    entReturn.Protocolo = ObjectUtils.ToString(dtrDados["TX_PROTOCOLO"]);
                    entReturn.CpfCnpj = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                    entReturn.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL"]);
                    entReturn.PassaProximaFase = ObjectUtils.ToBoolean(dtrDados["FL_PASSA_PROXIMA_ETAPA"]);
                    entReturn.MarcaQuestoesEspeciais = ObjectUtils.ToBoolean(dtrDados["FL_MARCA_QUESTOES_ESPECIAIS_FGA"]);
                    entReturn.PontuacaoTotalPosVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPosVisita"]);
                    entReturn.EnfoquePosVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePosVisita"]);
                    entReturn.ResultadoControlePosVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePosVisita"]);
                    entReturn.ResultadoTendenciaPosVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPosVisita"]);
                    entReturn.TotalEmpreendendorismoPosVisita = ObjectUtils.ToDouble(dtrDados["TotalEmpreendedorismoPosVisita"]);
                    //entReturn.RelacaoMelhorCategoriaPosVisita = ObjectUtils.ToDouble(dtrDados["RelacaoComMelhorDaCategoriaPosVisita"]);
                    entReturn.PontuacaoRankingPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoRankingPreVisita"]);
                    entReturn.EtapaAtiva = ObjectUtils.ToBoolean(dtrDados["FL_ETAPA_ATIVA"]);
                    entReturn.EnfoquePreVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePreVisita"]);
                    entReturn.ResultadoControlePreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePreVisita"]);
                    entReturn.ResultadoTendenciaPreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPreVisita"]);
                    entReturn.PontuacaoTotalPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPreVisita"]);
                    //entReturn.RelacaoMelhorCategoriaPreVisita = ObjectUtils.ToDouble(dtrDados["RelacaoComMelhorDaCategoriaPreVisita"]);
                    entReturn.PossuiResponsabilidadeSocial = ObjectUtils.ToBoolean(dtrDados["PossuiResponsabilidadeSocial"]);
                    entReturn.PossuiInovacao = ObjectUtils.ToBoolean(dtrDados["PossuiInovacao"]);
                    entReturn.Finalista = ObjectUtils.ToBoolean(dtrDados["Finalista"]);
                    entReturn.FinalistaResponsabilidadeSocial = ObjectUtils.ToBoolean(dtrDados["FinalistaResponsabilidadeSocial"]);
                    entReturn.FinalistaInovacao = ObjectUtils.ToBoolean(dtrDados["FinalistaInovacao"]);
                    entReturn.ParaAvaliacao = ObjectUtils.ToBoolean(dtrDados["FL_PARA_AVALIACAO"]);

                    entReturn.CriterioClientePosVisita = ObjectUtils.ToDouble(dtrDados["CriterioClientePosVisita"]);
                    entReturn.CriterioSociedadePosVisita = ObjectUtils.ToDouble(dtrDados["CriterioSociedadePosVisita"]);
                    entReturn.CriterioLiderancaPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioLiderancaPosVisita"]);
                    entReturn.CriterioEstrategiaPlanosPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioEstrategiaPlanosPosVisita"]);
                    entReturn.CriterioPessoasPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioPessoasPosVisita"]);
                    entReturn.CriterioProcessosPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioProcessosPosVisita"]);
                    entReturn.CriterioInformacoesConhecimentoPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioInformacoesConhecimentoPosVisita"]);

                    entReturn.CriterioClientePreVisita = ObjectUtils.ToDouble(dtrDados["CriterioClientePreVisita"]);
                    entReturn.CriterioSociedadePreVisita = ObjectUtils.ToDouble(dtrDados["CriterioSociedadePreVisita"]);
                    entReturn.CriterioLiderancaPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioLiderancaPreVisita"]);
                    entReturn.CriterioEstrategiaPlanosPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioEstrategiaPlanosPreVisita"]);
                    entReturn.CriterioPessoasPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioPessoasPreVisita"]);
                    entReturn.CriterioProcessosPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioProcessosPreVisita"]);
                    entReturn.CriterioInformacoesConhecimentoPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioInformacoesConhecimentoPreVisita"]);
                    entReturn.PontuacaoTotalResponsabilidadeSocial = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalResponsabilidadeSocial"]);
                    entReturn.PontuacaoTotalInovacao = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalInovacao"]);
                    entReturn.MaiorNotaPreVisita = ObjectUtils.ToDouble(dtrDados["MaiorNotaPreVisita"]);
                    entReturn.MaiorNotaPosVisita = ObjectUtils.ToDouble(dtrDados["MaiorNotaPosVisita"]);

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
        /// Popula Etapa, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntRanking">Lista de EntRanking</list></returns>
        private List<EntComparacaoResultados> PopularComparacaoResultados(DbDataReader dtrDados)
        {
            List<EntComparacaoResultados> listEntReturn = new List<EntComparacaoResultados>();
            EntComparacaoResultados entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntComparacaoResultados();

                    //Fase 1
                    entReturn.Fase1.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO_F1"]);
                    entReturn.Fase1.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA_F1"]);
                    entReturn.Fase1.IdEtapa = ObjectUtils.ToInt(dtrDados["CDA_ETAPA_F1"]);
                    entReturn.Fase1.Protocolo = ObjectUtils.ToString(dtrDados["TX_PROTOCOLO_F1"]);
                    entReturn.Fase1.CpfCnpj = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ_F1"]);
                    entReturn.Fase1.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL_F1"]);
                    entReturn.Fase1.PassaProximaFase = ObjectUtils.ToBoolean(dtrDados["FL_PASSA_PROXIMA_ETAPA_F1"]);
                    entReturn.Fase1.MarcaQuestoesEspeciais = ObjectUtils.ToBoolean(dtrDados["FL_MARCA_QUESTOES_ESPECIAIS_FGA_F1"]);
                    entReturn.Fase1.PontuacaoTotalPosVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPosVisita_F1"]);
                    entReturn.Fase1.EnfoquePosVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePosVisita_F1"]);
                    entReturn.Fase1.ResultadoControlePosVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePosVisita_F1"]);
                    entReturn.Fase1.ResultadoTendenciaPosVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPosVisita_F1"]);
                    entReturn.Fase1.TotalEmpreendendorismoPosVisita = ObjectUtils.ToDouble(dtrDados["TotalEmpreendedorismoPosVisita_F1"]);
                    //entReturn.RelacaoMelhorCategoriaPosVisita = ObjectUtils.ToDouble(dtrDados["RelacaoComMelhorDaCategoriaPosVisita"]);
                    entReturn.Fase1.PontuacaoRankingPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoRankingPreVisita_F1"]);
                    entReturn.Fase1.EtapaAtiva = ObjectUtils.ToBoolean(dtrDados["FL_ETAPA_ATIVA_F1"]);
                    entReturn.Fase1.EnfoquePreVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePreVisita_F1"]);
                    entReturn.Fase1.ResultadoControlePreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePreVisita_F1"]);
                    entReturn.Fase1.ResultadoTendenciaPreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPreVisita_F1"]);
                    entReturn.Fase1.PontuacaoTotalPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPreVisita_F1"]);
                    //entReturn.RelacaoMelhorCategoriaPreVisita = ObjectUtils.ToDouble(dtrDados["RelacaoComMelhorDaCategoriaPreVisita"]);
                    entReturn.Fase1.PossuiResponsabilidadeSocial = ObjectUtils.ToBoolean(dtrDados["PossuiResponsabilidadeSocial_F1"]);
                    entReturn.Fase1.PossuiInovacao = ObjectUtils.ToBoolean(dtrDados["PossuiInovacao_F1"]);
                    entReturn.Fase1.Finalista = ObjectUtils.ToBoolean(dtrDados["Finalista_F1"]);
                    entReturn.Fase1.FinalistaResponsabilidadeSocial = ObjectUtils.ToBoolean(dtrDados["FinalistaResponsabilidadeSocial_F1"]);
                    entReturn.Fase1.FinalistaInovacao = ObjectUtils.ToBoolean(dtrDados["FinalistaInovacao_F1"]);
                    entReturn.Fase1.ParaAvaliacao = ObjectUtils.ToBoolean(dtrDados["FL_PARA_AVALIACAO_F1"]);

                    entReturn.Fase1.CriterioClientePosVisita = ObjectUtils.ToDouble(dtrDados["CriterioClientePosVisita_F1"]);
                    entReturn.Fase1.CriterioSociedadePosVisita = ObjectUtils.ToDouble(dtrDados["CriterioSociedadePosVisita_F1"]);
                    entReturn.Fase1.CriterioLiderancaPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioLiderancaPosVisita_F1"]);
                    entReturn.Fase1.CriterioEstrategiaPlanosPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioEstrategiaPlanosPosVisita_F1"]);
                    entReturn.Fase1.CriterioPessoasPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioPessoasPosVisita_F1"]);
                    entReturn.Fase1.CriterioProcessosPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioProcessosPosVisita_F1"]);
                    entReturn.Fase1.CriterioInformacoesConhecimentoPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioInformacoesConhecimentoPosVisita_F1"]);

                    entReturn.Fase1.CriterioClientePreVisita = ObjectUtils.ToDouble(dtrDados["CriterioClientePreVisita_F1"]);
                    entReturn.Fase1.CriterioSociedadePreVisita = ObjectUtils.ToDouble(dtrDados["CriterioSociedadePreVisita_F1"]);
                    entReturn.Fase1.CriterioLiderancaPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioLiderancaPreVisita_F1"]);
                    entReturn.Fase1.CriterioEstrategiaPlanosPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioEstrategiaPlanosPreVisita_F1"]);
                    entReturn.Fase1.CriterioPessoasPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioPessoasPreVisita_F1"]);
                    entReturn.Fase1.CriterioProcessosPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioProcessosPreVisita_F1"]);
                    entReturn.Fase1.CriterioInformacoesConhecimentoPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioInformacoesConhecimentoPreVisita_F1"]);
                    entReturn.Fase1.PontuacaoTotalResponsabilidadeSocial = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalResponsabilidadeSocial_F1"]);
                    entReturn.Fase1.PontuacaoTotalInovacao = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalInovacao_F1"]);
                    entReturn.Fase1.MaiorNotaPreVisita = ObjectUtils.ToDouble(dtrDados["MaiorNotaPreVisita_F1"]);
                    entReturn.Fase1.MaiorNotaPosVisita = ObjectUtils.ToDouble(dtrDados["MaiorNotaPosVisita_F1"]);


                    // Fase 4
                    entReturn.Fase4.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO_F4"]);
                    entReturn.Fase4.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA_F4"]);
                    entReturn.Fase4.IdEtapa = ObjectUtils.ToInt(dtrDados["CDA_ETAPA_F4"]);
                    entReturn.Fase4.Protocolo = ObjectUtils.ToString(dtrDados["TX_PROTOCOLO_F4"]);
                    entReturn.Fase4.CpfCnpj = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ_F4"]);
                    entReturn.Fase4.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL_F4"]);
                    entReturn.Fase4.PassaProximaFase = ObjectUtils.ToBoolean(dtrDados["FL_PASSA_PROXIMA_ETAPA_F4"]);
                    entReturn.Fase4.MarcaQuestoesEspeciais = ObjectUtils.ToBoolean(dtrDados["FL_MARCA_QUESTOES_ESPECIAIS_FGA_F4"]);
                    entReturn.Fase4.PontuacaoTotalPosVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPosVisita_F4"]);
                    entReturn.Fase4.EnfoquePosVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePosVisita_F4"]);
                    entReturn.Fase4.ResultadoControlePosVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePosVisita_F4"]);
                    entReturn.Fase4.ResultadoTendenciaPosVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPosVisita_F4"]);
                    entReturn.Fase4.TotalEmpreendendorismoPosVisita = ObjectUtils.ToDouble(dtrDados["TotalEmpreendedorismoPosVisita_F4"]);
                    //entReturn.RelacaoMelhorCategoriaPosVisita = ObjectUtils.ToDouble(dtrDados["RelacaoComMelhorDaCategoriaPosVisita"]);
                    entReturn.Fase4.PontuacaoRankingPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoRankingPreVisita_F4"]);
                    entReturn.Fase4.EtapaAtiva = ObjectUtils.ToBoolean(dtrDados["FL_ETAPA_ATIVA_F4"]);
                    entReturn.Fase4.EnfoquePreVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePreVisita_F4"]);
                    entReturn.Fase4.ResultadoControlePreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePreVisita_F4"]);
                    entReturn.Fase4.ResultadoTendenciaPreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPreVisita_F4"]);
                    entReturn.Fase4.PontuacaoTotalPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPreVisita_F4"]);
                    //entReturn.RelacaoMelhorCategoriaPreVisita = ObjectUtils.ToDouble(dtrDados["RelacaoComMelhorDaCategoriaPreVisita"]);
                    entReturn.Fase4.PossuiResponsabilidadeSocial = ObjectUtils.ToBoolean(dtrDados["PossuiResponsabilidadeSocial_F4"]);
                    entReturn.Fase4.PossuiInovacao = ObjectUtils.ToBoolean(dtrDados["PossuiInovacao_F4"]);
                    entReturn.Fase4.Finalista = ObjectUtils.ToBoolean(dtrDados["Finalista_F4"]);
                    entReturn.Fase4.FinalistaResponsabilidadeSocial = ObjectUtils.ToBoolean(dtrDados["FinalistaResponsabilidadeSocial_F4"]);
                    entReturn.Fase4.FinalistaInovacao = ObjectUtils.ToBoolean(dtrDados["FinalistaInovacao_F4"]);
                    entReturn.Fase4.ParaAvaliacao = ObjectUtils.ToBoolean(dtrDados["FL_PARA_AVALIACAO_F4"]);

                    entReturn.Fase4.CriterioClientePosVisita = ObjectUtils.ToDouble(dtrDados["CriterioClientePosVisita_F4"]);
                    entReturn.Fase4.CriterioSociedadePosVisita = ObjectUtils.ToDouble(dtrDados["CriterioSociedadePosVisita_F4"]);
                    entReturn.Fase4.CriterioLiderancaPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioLiderancaPosVisita_F4"]);
                    entReturn.Fase4.CriterioEstrategiaPlanosPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioEstrategiaPlanosPosVisita_F4"]);
                    entReturn.Fase4.CriterioPessoasPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioPessoasPosVisita_F4"]);
                    entReturn.Fase4.CriterioProcessosPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioProcessosPosVisita_F4"]);
                    entReturn.Fase4.CriterioInformacoesConhecimentoPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioInformacoesConhecimentoPosVisita_F4"]);

                    entReturn.Fase4.CriterioClientePreVisita = ObjectUtils.ToDouble(dtrDados["CriterioClientePreVisita_F4"]);
                    entReturn.Fase4.CriterioSociedadePreVisita = ObjectUtils.ToDouble(dtrDados["CriterioSociedadePreVisita_F4"]);
                    entReturn.Fase4.CriterioLiderancaPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioLiderancaPreVisita_F4"]);
                    entReturn.Fase4.CriterioEstrategiaPlanosPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioEstrategiaPlanosPreVisita_F4"]);
                    entReturn.Fase4.CriterioPessoasPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioPessoasPreVisita_F4"]);
                    entReturn.Fase4.CriterioProcessosPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioProcessosPreVisita_F4"]);
                    entReturn.Fase4.CriterioInformacoesConhecimentoPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioInformacoesConhecimentoPreVisita_F4"]);
                    entReturn.Fase4.PontuacaoTotalResponsabilidadeSocial = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalResponsabilidadeSocial_F4"]);
                    entReturn.Fase4.PontuacaoTotalInovacao = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalInovacao_F4"]);
                    entReturn.Fase4.MaiorNotaPreVisita = ObjectUtils.ToDouble(dtrDados["MaiorNotaPreVisita_F4"]);
                    entReturn.Fase4.MaiorNotaPosVisita = ObjectUtils.ToDouble(dtrDados["MaiorNotaPosVisita_F4"]);

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
        /// Popula Etapa, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntRanking">Lista de EntRanking</list></returns>
        private List<RelRankingPegFase2> PopularRankingPegFase2(DbDataReader dtrDados)
        {
            List<RelRankingPegFase2> listEntReturn = new List<RelRankingPegFase2>();
            RelRankingPegFase2 entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new RelRankingPegFase2();

                    entReturn.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                    entReturn.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                    entReturn.CpfCnpj = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                    entReturn.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL"]);
                    entReturn.PontuacaoTotalPosVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPosVisita"]);
                    entReturn.EnfoquePosVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePosVisita"]);
                    entReturn.ResultadoControlePosVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePosVisita"]);
                    entReturn.ResultadoTendenciaPosVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPosVisita"]);
                    entReturn.TotalEmpreendendorismoPosVisita = ObjectUtils.ToDouble(dtrDados["TotalEmpreendedorismoPosVisita"]);
                    //entReturn.RelacaoMelhorCategoriaPosVisita = ObjectUtils.ToDouble(dtrDados["RelacaoComMelhorDaCategoriaPosVisita"]);
                    entReturn.PontuacaoRankingPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoRankingPreVisita"]);
                    entReturn.EnfoquePreVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePreVisita"]);
                    entReturn.ResultadoControlePreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePreVisita"]);
                    entReturn.ResultadoTendenciaPreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPreVisita"]);
                    entReturn.PontuacaoTotalPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPreVisita"]);
                    //entReturn.RelacaoMelhorCategoriaPreVisita = ObjectUtils.ToDouble(dtrDados["RelacaoComMelhorDaCategoriaPreVisita"]);
                    entReturn.PassaProximaFase = ObjectUtils.ToBoolean(dtrDados["FL_PASSA_PROXIMA_ETAPA"]);
                    entReturn.EtapaAtiva = ObjectUtils.ToBoolean(dtrDados["FL_ETAPA_ATIVA"]);
                    entReturn.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);

                    entReturn.CriterioClientePosVisita = ObjectUtils.ToDouble(dtrDados["CriterioClientePosVisita"]);
                    entReturn.CriterioSociedadePosVisita = ObjectUtils.ToDouble(dtrDados["CriterioSociedadePosVisita"]);
                    entReturn.CriterioLiderancaPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioLiderancaPosVisita"]);
                    entReturn.CriterioEstrategiaPlanosPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioEstrategiaPlanosPosVisita"]);
                    entReturn.CriterioPessoasPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioPessoasPosVisita"]);
                    entReturn.CriterioProcessosPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioProcessosPosVisita"]);
                    entReturn.CriterioInformacoesConhecimentoPosVisita = ObjectUtils.ToDouble(dtrDados["CriterioInformacoesConhecimentoPosVisita"]);

                    entReturn.CriterioClientePreVisita = ObjectUtils.ToDouble(dtrDados["CriterioClientePreVisita"]);
                    entReturn.CriterioSociedadePreVisita = ObjectUtils.ToDouble(dtrDados["CriterioSociedadePreVisita"]);
                    entReturn.CriterioLiderancaPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioLiderancaPreVisita"]);
                    entReturn.CriterioEstrategiaPlanosPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioEstrategiaPlanosPreVisita"]);
                    entReturn.CriterioPessoasPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioPessoasPreVisita"]);
                    entReturn.CriterioProcessosPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioProcessosPreVisita"]);
                    entReturn.CriterioInformacoesConhecimentoPreVisita = ObjectUtils.ToDouble(dtrDados["CriterioInformacoesConhecimentoPreVisita"]);
                    entReturn.PontuacaoTotalResponsabilidadeSocial = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalResponsabilidadeSocial"]);
                    entReturn.PontuacaoTotalInovacao = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalInovacao"]);
                    entReturn.MaiorNotaPreVisita = ObjectUtils.ToDouble(dtrDados["MaiorNotaPreVisita"]);
                    entReturn.MaiorNotaPosVisita = ObjectUtils.ToDouble(dtrDados["MaiorNotaPosVisita"]);

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
        /// Encaminhar para Próxima Etapa
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objQuestionarioEmpresa">EntQuestionarioEmpresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void EncaminharProximaEtapa(EntQuestionarioEmpresa objQuestionarioEmpresa, Boolean IsInicioEtapaNacional, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AlterarEtapaDoQuestionarioEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@CDA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_PROXIMA", DbType.Int32, objQuestionarioEmpresa.Etapa.TipoEtapa.IdTipoEtapa);
            db.AddInParameter(dbCommand, "@TX_MOTIVO_VENCEU", DbType.String, objQuestionarioEmpresa.MotivoVenceu);
            db.AddInParameter(dbCommand, "@IS_INICIO_ETAPA_NACIONAL", DbType.String, IsInicioEtapaNacional);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Encaminhar para Etapa Anterior
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objQuestionarioEmpresa">EntQuestionarioEmpresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void EncaminharEtapaAnterior(EntQuestionarioEmpresa objQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_VoltarEtapaDoQuestionarioEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@CDA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@CDA_EMP_CADASTRO", DbType.Int32, objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_ANTERIOR", DbType.Int32, objQuestionarioEmpresa.Etapa.TipoEtapa.IdTipoEtapa);
            db.AddInParameter(dbCommand, "@CEA_USUARIO", DbType.Int32, objQuestionarioEmpresa.Usuario.IdUsuario);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Desclassifica Questionario Empresa
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objQuestionarioEmpresa">EntQuestionarioEmpresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void DesclassificaQuestionarioEmpresa(EntQuestionarioEmpresa objQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DesclassificaQuestionarioEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@CDA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@TX_MOTIVO_EXCLUIU", DbType.String, objQuestionarioEmpresa.MotivoExcluiu);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Devolver para o Avaliador
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void DevolverParaAvaliador(EntQuestionarioEmpresaAvaliador objQuestionarioEmpresaAvaliador, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaDisponibilidadeDaAvaliacao");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@CDA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioEmpresaAvaliador.QuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@FL_PARA_AVALIACAO", DbType.Boolean, objQuestionarioEmpresaAvaliador.QuestionarioEmpresa.ParaAvaliador);
            db.AddInParameter(dbCommand, "@TX_MOTIVO_DEVOLUCAO", DbType.String, objQuestionarioEmpresaAvaliador.MotivoDevolucao);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um Relatorio de Ranking Candidata Estadual
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCargo">Lista de RelRankingCandidata</list></returns>
        public List<RelAvaliacao> ObterAvaliacaoPorFiltro(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaAvaliacaoPorFiltro");
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
            //-------QUESTIONARIOS-------------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_GESTAO", DbType.Int32, (int)EnumType.Questionario.Gestao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_INOVACAO", DbType.Int32, (int)EnumType.Questionario.Inovacao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_EMPREENDEDORISMO", DbType.Int32, (int)EnumType.Questionario.Empreendedorismo);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL", DbType.Int32, (int)EnumType.Questionario.ResponsabilidadeSocial);
            //--------FILTROS DE TELA----------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_USUARIO", DbType.Int32, objRelFiltroRanking.IdUsuario);
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
                    return this.PopularAvaliacao(dtrDados);
                }
                else
                {
                    return new List<RelAvaliacao>();
                }
            }
        }
    }
}
