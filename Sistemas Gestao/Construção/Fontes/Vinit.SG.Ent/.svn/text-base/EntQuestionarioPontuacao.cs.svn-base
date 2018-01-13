using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.Common;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um QuestionarioPontuacao
    /// </summary>
    [Serializable()]
    public class EntQuestionarioPontuacao
    {
        public Decimal Ponto { get; set; }
        public Boolean Avaliador { get; set; }
        public String CriterioPorExtenso
        {
            get
            {
                switch ((EnumType.CriteriosGestao)this.Criterio.IdCriterio)
                {
                    case EnumType.CriteriosGestao.Cliente:
                        CriterioPorExtenso = "Cliente";
                        break;
                    case EnumType.CriteriosGestao.Sociedade:
                        CriterioPorExtenso = "Sociedade";
                        break;
                    case EnumType.CriteriosGestao.Lideranca:
                        CriterioPorExtenso = "Liderança";
                        break;
                    case EnumType.CriteriosGestao.EstrategiaPlano:
                        CriterioPorExtenso = "Estratégia e Plano";
                        break;
                    case EnumType.CriteriosGestao.Pessoas:
                        CriterioPorExtenso = "Pessoas";
                        break;
                    case EnumType.CriteriosGestao.Processos:
                        CriterioPorExtenso = "Processos";
                        break;
                    case EnumType.CriteriosGestao.InformacaoConhecimento:
                        CriterioPorExtenso = "Informação e Conhecimento";
                        break;
                    case EnumType.CriteriosGestao.ResultadoControle:
                        CriterioPorExtenso = "Resultados";
                        break;
                    case EnumType.CriteriosGestao.ResultadoTendencia:
                        CriterioPorExtenso = "Resultado de Tendência";
                        break;
                    default:
                        CriterioPorExtenso = "";
                        break;
                }

                return CriterioPorExtenso;
            }
            set { CriterioPorExtenso = value; }
        }

        private EntQuestionarioEmpresa _QuestionarioEmpresa;
        public EntQuestionarioEmpresa QuestionarioEmpresa
        {
            get
            {
                if (_QuestionarioEmpresa == null)
                {
                    _QuestionarioEmpresa = new EntQuestionarioEmpresa();
                }
                return _QuestionarioEmpresa;
            }

            set { _QuestionarioEmpresa = value; }
        }

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

        private EntCriterio _Criterio;
        public EntCriterio Criterio
        {
            get
            {
                if (_Criterio == null)
                {
                    _Criterio = new EntCriterio();
                }
                return _Criterio;
            }

            set { _Criterio = value; }
        }
    }
}
