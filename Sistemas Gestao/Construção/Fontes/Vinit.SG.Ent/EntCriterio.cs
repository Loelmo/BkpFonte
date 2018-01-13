using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.Common;
namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Criterio
    /// </summary>
    [Serializable()]
    public class EntCriterio
    {
        public Int32 IdCriterio { get; set; }

        public String Criterio { get; set; }

        public String Ajuda { get; set; }

        public Int32 Ordem { get; set; }

        private EntQuestionario _Questionario;
        public EntQuestionario Questionario
        {
            get
            {
                if (_Questionario == null)
                {
                    _Questionario = new EntQuestionario();
                }
                return _Questionario;
            }

            set { _Questionario = value; }
        }

        private String _QuestionarioGestaoPorExtenso;
        public String QuestionarioGestaoPorExtenso
        {
            get
            {
                String Extenso = "";

                switch ((EnumType.CriteriosGestao)this.IdCriterio)
                {
                    case EnumType.CriteriosGestao.Cliente:

                        Extenso = "Clientes";

                        break;
                    case EnumType.CriteriosGestao.Sociedade:

                        Extenso = "Sociedade";

                        break;
                    case EnumType.CriteriosGestao.Lideranca:

                        Extenso = "Liderança";

                        break;
                    case EnumType.CriteriosGestao.EstrategiaPlano:

                        Extenso = "Estratégias e Planos";

                        break;
                    case EnumType.CriteriosGestao.Pessoas:

                        Extenso = "Pessoas";

                        break;
                    case EnumType.CriteriosGestao.Processos:

                        Extenso = "Processos";

                        break;
                    case EnumType.CriteriosGestao.InformacaoConhecimento:

                        Extenso = "Informações e Conhecimento";

                        break;
                    case EnumType.CriteriosGestao.ResultadoControle:

                        Extenso = "Resultados";

                        break;
                    case EnumType.CriteriosGestao.ResultadoTendencia:

                        Extenso = "Resultados Tendência";

                        break;
                    default:

                        Extenso = "";

                        break;
                }

                return Extenso;
            }
        }

        private String _QuestionarioGestaoPontuacaoMaxima;
        public String QuestionarioGestaoPontuacaoMaxima
        {
            get
            {
                String Maxima = "";

                switch ((EnumType.CriteriosGestao)this.IdCriterio)
                {
                    case EnumType.CriteriosGestao.Cliente:

                        Maxima = "9,00%";

                        break;
                    case EnumType.CriteriosGestao.Sociedade:

                        Maxima = "6,00%";

                        break;
                    case EnumType.CriteriosGestao.Lideranca:

                        Maxima = "15,00%";

                        break;
                    case EnumType.CriteriosGestao.EstrategiaPlano:

                        Maxima = "9,00%";

                        break;
                    case EnumType.CriteriosGestao.Pessoas:

                        Maxima = "9,00%";

                        break;
                    case EnumType.CriteriosGestao.Processos:

                        Maxima = "16,00%";

                        break;
                    case EnumType.CriteriosGestao.InformacaoConhecimento:

                        Maxima = "6,00%";

                        break;
                    case EnumType.CriteriosGestao.ResultadoControle:

                        Maxima = "9,00%";

                        break;
                    case EnumType.CriteriosGestao.ResultadoTendencia:

                        Maxima = "21,00%";

                        break;
                    default:

                        Maxima = "";

                        break;
                }

                return Maxima;
            }
        }

        private Double _QuestionarioGestaoPontuacaoAnterior;
        public Double QuestionarioGestaoPontuacaoAnterior
        {
            get
            {
                Double Maxima = 0;

                switch ((EnumType.CriteriosGestao)this.IdCriterio)
                {
                    case EnumType.CriteriosGestao.Cliente:

                        Maxima = 4.74;

                        break;
                    case EnumType.CriteriosGestao.Sociedade:

                        Maxima = 3.14;

                        break;
                    case EnumType.CriteriosGestao.Lideranca:

                        Maxima = 8.14;

                        break;
                    case EnumType.CriteriosGestao.EstrategiaPlano:

                        Maxima = 3.64;

                        break;
                    case EnumType.CriteriosGestao.Pessoas:

                        Maxima = 4.89;

                        break;
                    case EnumType.CriteriosGestao.Processos:

                        Maxima = 9.17;

                        break;
                    case EnumType.CriteriosGestao.InformacaoConhecimento:

                        Maxima = 2.53;

                        break;
                    case EnumType.CriteriosGestao.ResultadoControle:

                        Maxima = 3.42;

                        break;
                    case EnumType.CriteriosGestao.ResultadoTendencia:

                        Maxima = 3.42;

                        break;
                    default:

                        Maxima = 0;

                        break;
                }

                return Maxima;
            }
        }

        private String _QuestionarioEmpreendedorismoPorExtenso;
        public String QuestionarioEmpreendedorismoPorExtenso
        {
            get
            {
                String Extenso = "";

                switch ((EnumType.CriteriosEmpreendedorismo)this.IdCriterio)
                {
                    case EnumType.CriteriosEmpreendedorismo.BuscaOportunidadeIniciativa:

                        Extenso = "Busca de Oportunidade e Iniciativa";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.Persistencia:

                        Extenso = "Persistência";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.Comprometimento:

                        Extenso = "Comprometimento";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.ExigenciaQualidadeEficiencia:

                        Extenso = "Exigência de Qualidade e Eficiência";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.CorrerRiscosCalculados:

                        Extenso = "Correr Riscos Calculados";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.EstabelecimentoMetas:

                        Extenso = "Estabelecimento de Metas";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.BuscaInformacao:

                        Extenso = "Busca de Informações";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.PlanejamentoMonitoramentoSistematico:

                        Extenso = "Planejamento e Monitoramento Sistemático";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.PersuasaoRedeContatos:

                        Extenso = "Persuasão e Rede de Contatos";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.IndependenciaAutoconfianca:

                        Extenso = "Independência e Autoconfiança";

                        break;
                    default:

                        Extenso = "";

                        break;
                }

                return Extenso;
            }
        }

        private String _QuestionarioEmpreendedorismoPontuacaoMaxima;
        public String QuestionarioEmpreendedorismoPontuacaoMaxima
        {
            get
            {
                String Extenso = "";

                switch ((EnumType.CriteriosEmpreendedorismo)this.IdCriterio)
                {
                    case EnumType.CriteriosEmpreendedorismo.BuscaOportunidadeIniciativa:

                        Extenso = "10,00%";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.Persistencia:

                        Extenso = "10,00%";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.Comprometimento:

                        Extenso = "10,00%";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.ExigenciaQualidadeEficiencia:

                        Extenso = "10,00%";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.CorrerRiscosCalculados:

                        Extenso = "10,00%";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.EstabelecimentoMetas:

                        Extenso = "10,00%";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.BuscaInformacao:

                        Extenso = "10,00%";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.PlanejamentoMonitoramentoSistematico:

                        Extenso = "10,00%";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.PersuasaoRedeContatos:

                        Extenso = "10,00%";

                        break;
                    case EnumType.CriteriosEmpreendedorismo.IndependenciaAutoconfianca:

                        Extenso = "10,00%";

                        break;
                    default:

                        Extenso = "";

                        break;
                }

                return Extenso;
            }
        }
    }
}
