using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Vinit.SG.Common
{
    /// <summary>
    /// Classe para armazenar todos os Enum em comun
    /// </summary>
    public class EnumType
    {
        public enum TipoAcao { Inserir = 1, Atualizar, Excluir, Ativar, Inativar }
        public enum Status { Inscrita = 1, Candidata, Classificada, Finalista }
        public enum StateIA { Inserir, Alterar }
        public enum Programa { MPE = 1, FGA, PEG }

        public enum Questionario { Gestao2010 = 5, Gestao = 6, Empreendedorismo = 14, ResponsabilidadeSocial = 13, Inovacao = 9 }
        public enum CriteriosGestao { Cliente = 75, Sociedade = 76, Lideranca = 77, EstrategiaPlano = 78, Pessoas = 79, Processos = 80, InformacaoConhecimento = 81, ResultadoControle = 82, ResultadoTendencia = 83 }
        public enum CriteriosGestao2010 { Cliente = 21, Sociedade = 22, Lideranca = 23, EstrategiaPlano = 24, Pessoas = 25, Processos = 26, InformacaoConhecimento = 27, ResultadoControle = 61, ResultadoTendencia = 62 }
        public enum CriteriosEmpreendedorismo { BuscaOportunidadeIniciativa = 29, Persistencia = 30, Comprometimento = 31, ExigenciaQualidadeEficiencia = 32, CorrerRiscosCalculados = 33, EstabelecimentoMetas = 34, BuscaInformacao = 35, PlanejamentoMonitoramentoSistematico = 36, PersuasaoRedeContatos = 37, IndependenciaAutoconfianca = 38 }
        public enum CriterioResponsabilidadeSocial { ResponsabilidadeSocial = 39 }
        public enum CriterioInovacao { Inovacao = 63 }

        public enum TipoEtapaMpe
        {
            InscriçãoCandidaturaEmpresa = 10,
            InscriçãoCandidaturaAdministrativo = 11,
            ClassificaçãoEstadual = 9,
            AvaliacaoEstadual = 12,
            JulgamentoFinalistasEstaduais = 13,
            EncerramentoEstadual = 14,
            ClassificacaoNacional = 15,
            AvaliacaoNacional = 16,
            JulgamentoFinalistasNacionais = 17,
            EncerramentoNacional = 18
        }

        public enum TipoEtapaFga
        {
            Autodiagnostico = 3,
            AutodiagnosticoAdministrativo = 4,
            ValidacaoAnaliseRespostas = 5,
            VisitaPreviaPreClassificadas = 6,
            NovoCicloFase4 = 7,
            Encerramento = 8
        }

        public enum TipoEtapaPeg
        {
            Autodiagnostico = 19,
            AutodiagnosticoAdministrativo = 20,
            ValidacaoAnaliseRespostas = 21,
            VisitaPreviaPreClassificadas = 22,
            PlanoEmpresarialFase2 = 23,
            GestãoDoResultadoFase3 = 24,
            NovoCicloFase4 = 25,
            Encerramento = 26
        }

        public enum TipoDropDownList
        {
            Categoria, Faturamento, Escolaridade, TipoEmpresa, FaixaEtaria, Cargo, AtividadeEconomica
        }

        public enum TipoRelatorio { Simplificado = 0, Detalhado = 1 }

        public enum EtapaRanking { Candidata = 0, Classificada = 1, Finalista = 2, Fase2Peg = 3, Fase3Peg = 4, Fase4 = 5 }

        public enum RelatorioFiltro { NumeroParticipantesPorEtapaFga = 0, DesempenhoGlobalFga = 1 }


        public enum Tabela
        {
            [Description("TBL_ADM_FUNCIONALIDADE")]
            EntAdmFuncinalidade,
            [Description("TBL_ETAPA")]
            EntEtapa/*,
            /*EntAdmGrupo = "TBL_ADM_GRUPO",
            EntRelFuncGrupo = "TBL_ADM_RELFUNCGRUPO",
            EntGrupoRelUsuario = "TBL_ADM_RELGRUPOUSUARIO",
            EntAdmTipoFuncionalidade = "TBL_ADM_TIPOFUNCIONALIDADE",
            EntAdmUsuario = "TBL_ADM_USUARIO",
            EntCategoria = "TBL_CATEGORIA",
            EntChamado = "TBL_CHAMADO",
            EntCidade = "TBL_CIDADE",
            "TBL_CONTATO_FAIXA_ETARIA",
            "TBL_CONTATO_NIVEL_ESCOLARIDADE",
            "TBL_CONTEUDO",
            "TBL_CRITERIO",
            "TBL_DOWNLOAD",
            "TBL_EMP_CADASTRO",
            "TBL_ESCRITORIO_REGIONAL",
            "TBL_ESTADO",
            "TBL_ESTADO_REGIAO",
            "TBL_FATURAMENTO",
            "TBL_GRUPO",
            "TBL_GRUPOEMPRESA",
            "TBL_LOG_ACAO",
            "TBL_PAIS",
            "TBL_PERGUNTA",
            "TBL_PERGUNTA_RESPOSTA",
            "TBL_PERGUNTA_TIPO",
            "TBL_PROGRAMA",
            "TBL_QUESTIONARIO",
            "TBL_QUESTIONARIO_EMPRESA",
            "TBL_QUESTIONARIO_EMPRESA_AVALIADOR",
            "TBL_QUESTIONARIO_EMPRESA_RESPOSTA",
            "TBL_QUESTIONARIO_PONTUACAO",
            "TBL_ATIVIDADE_ECONOMICA",
            "TBL_REL_CATEGORIA_RAMO_ATIVIDADE",
            "TBL_REL_CICLO_QUESTIONARIO",
            "TBL_TIPO_ACAO",
            "TBL_TIPO_ETAPA",
            "TBL_TURMA",
            "TBL_TURMA_EMP",
            "TBL_FATURAMENTO_TIPO"*/
        }

    }
}
